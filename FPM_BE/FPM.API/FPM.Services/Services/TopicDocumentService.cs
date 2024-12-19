using AutoMapper;
using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using FPM.Repositories.IRepository;
using FPM.Repositories.Repository;
using FPM.Resourses;
using FPM.Resourses.DTOs.TopicDocument.Request;
using FPM.Resourses.DTOs.TopicDocument.Response;
using FPM.Resourses.Enums;
using FPM.Resourses.Results;
using FPM.Services.IServices;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Services
{
    public class TopicDocumentService : BaseService, ITopicDocumentService
    {
        #region Property
        private readonly ITopicDocumentRepository _topicDocumentRepository;
        private readonly ITopicRepository _topicRepository;
        private readonly IUploadPartRepository _uploadPartRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IFileService _fileService;
        private readonly IUriService _uriService;
        private readonly IMailService _mailService;
        private readonly INotificationRepository _notificationRepository;
        #endregion

        #region Contructor
        public TopicDocumentService(ITopicDocumentRepository topicDocumentRepository,
                                    ITopicRepository topicRepository,
                                    IUploadPartRepository uploadPartRepository,
                                    IFileService fileService,
                                    IUnitOfWork unitOfWork,
                                    IUriService uriService,
                                    IUserRepository userRepository,
                                    IMailService mailService,
                                    INotificationRepository notificationRepository,
        IMapper mapper, IOptionsMonitor<ResponseMessage> responseMessage) : base(mapper, responseMessage)
        {
            _topicDocumentRepository = topicDocumentRepository;
            _topicRepository = topicRepository;
            _uploadPartRepository = uploadPartRepository;
            _unitOfWork = unitOfWork;
            _fileService = fileService;
            _uriService = uriService;
            _userRepository = userRepository;
            _mailService = mailService;
            _notificationRepository = notificationRepository;
        }
        #endregion

        #region Method
        public async Task<BaseResult<TopicDocumentResponse>> ApproveDocumentAsync(int topicDocumentId, DocumentStatusEnum documentStatus,int userId, string? comment)
        {
            var document = await  _topicDocumentRepository.FindAsync(topicDocumentId);
            
            if (!document.HasData) return GetBaseResult<TopicDocumentResponse>(CodeMessage._211, status: StatusEnum.Failed);

            document.Data.Status = documentStatus;
            document.Data.ApproveBy = userId;
            document.Data.Comment = comment;
            _topicDocumentRepository.Update(document.Data);
            _unitOfWork.SaveChange();

            await SendNotificationAndEmail(document.Data, userId, documentStatus);

            return GetBaseResult(CodeMessage._200, Mapper.Map<TopicDocumentResponse>(document.Data));

        }

        

        public async Task<BaseResult<TopicDocumentResponse>> CreateTopicDocumentAsync(int userId, CreateTopicDocumentRequest request, string webRootPath)
        {
            var creator = await _userRepository.GetUserById(userId);
            string creatorName = $"{creator.Data.FirstName} {creator.Data.LastName}".Trim();
            var topic = await _topicRepository.GetTopicByIdAsync(request.TopicId);
            if (!topic.HasData)
            {
                return GetBaseResult<TopicDocumentResponse>(CodeMessage._236, status: Resourses.Enums.StatusEnum.Failed);
            }
            var topicDocument = Mapper.Map<TopicDocument>(request);
            topicDocument.CreateBy = userId;
            topicDocument.UploadPart = await _fileService.UploadDocAsync(userId, request.File,webRootPath);
            if (topicDocument.UploadPart == null)
            {
                return GetBaseResult<TopicDocumentResponse>(CodeMessage._99, status: Resourses.Enums.StatusEnum.Failed);
            }
            await _topicDocumentRepository.InsertAsync(topicDocument);
            await _unitOfWork.SaveChangeAsync();
            var result = Mapper.Map<TopicDocumentResponse>(topicDocument);
            result.FileUrl = $"/api/v1/document/GetFile?fileName={topicDocument.UploadPart.FileUrl}";

            await SendNotificationToDirectors(result.FileUrl, topicDocument.UploadPart.FileName);
            var directorsResult = await _userRepository.getUserByUserName("Director");
            if (directorsResult.HasData)
            {
          
                var directors = directorsResult.Data;
                foreach (var director in directors)
                {
                    var notification = new Notify
                    {
                        SenderId = userId,
                        CreatedAt = DateTime.Now,
                        UserId = director.Id,
                        ActionType = 1,
                        ObjectType = 0,
                        ObjectId = topicDocument.Id,
                        Title = $"Tài liệu mới được tạo bởi {creatorName}",
                        Detail = $"Tài liệu '{topicDocument.UploadPart.FileName}' đã được tải lên và cần phê duyệt.",
                        Status = 0
                    };
                    await _notificationRepository.InsertAsync(notification);
                    await _unitOfWork.SaveChangeAsync();
                }
            }
            return GetBaseResult(CodeMessage._200, result);
        }

        

        public async Task<BaseResult<TopicDocumentResponse>> DeleteDocumentAsync(int topicDocumentId, string webRootPath)
        {
            var document = await _topicDocumentRepository.GetTopicDocumentByIdAsync(topicDocumentId);
            
            if (!document.HasData) return GetBaseResult<TopicDocumentResponse>(CodeMessage._211, status: StatusEnum.Failed);

            _fileService.RemoveFile(document.Data.UploadPart, webRootPath);

            document.Data.UploadPart.IsDeleted =true;

            _uploadPartRepository.Update(document.Data.UploadPart);

            document.Data.UploadPart = null;
            _topicDocumentRepository.Delete(document.Data);
            await _unitOfWork.SaveChangeAsync();

            return GetBaseResult<TopicDocumentResponse>(CodeMessage._200, status: StatusEnum.Success);

        }

        public async Task<BaseResult<IEnumerable<TopicDocumentResponse>>> SearchDocumentAsync(SearchDocumentModel request)
        {
            var result = await _topicDocumentRepository.SearchDocumentAsync(request);

            if (!result.HasData) return GetBaseResult<IEnumerable<TopicDocumentResponse>>(CodeMessage._211, status: StatusEnum.Failed);

            

            foreach(var document in result.Data)
            {
                document.FileUrl =  "/api/v1/document/GetFile?fileName=" + document.UploadPart.FileUrl;
            }

            return GetBaseResult(CodeMessage._200, Mapper.Map<IEnumerable<TopicDocumentResponse>>(result.Data));

        }

        public async Task<BaseResult<TopicDocumentResponse>> UpdateDocumentAsync(int userId,int topicDocumentId, UpdateDocumentRequest request, string webRootPath)
        {
            var document = await _topicDocumentRepository.GetTopicDocumentByIdAsync(topicDocumentId);

            if (!document.HasData) return GetBaseResult<TopicDocumentResponse>(CodeMessage._211, status: StatusEnum.Failed);

            document.Data.Description = request.Description != null ? request.Description : document.Data.Description;


            //nếu file == null thì không tạo upload file
            if(request.File != null )
            {
                _fileService.RemoveFile(document.Data.UploadPart,webRootPath);
                var uploadPart = await _fileService.UploadDocAsync(userId, request.File,webRootPath);
                if (uploadPart != null)
                {
                    await _uploadPartRepository.InsertAsync(uploadPart);
                    await _unitOfWork.SaveChangeAsync();
                }
                document.Data.UploadPart = uploadPart;

            }
            document.Data.Status = DocumentStatusEnum.Checking;
            _topicDocumentRepository.Update(document.Data);
            _unitOfWork.SaveChange();

            var result = Mapper.Map<TopicDocumentResponse>(document.Data);

            result.FileUrl = "/api/v1/document/GetFile?fileName=" + document.Data.UploadPart.FileLocation;

            return GetBaseResult(CodeMessage._200, result);

        }
        #endregion
        #region Private Work
        private async Task SendNotificationAndEmail(TopicDocument document, int userId, DocumentStatusEnum documentStatus)
        {
            string subject = string.Empty;
            string body = string.Empty;
            if (documentStatus == DocumentStatusEnum.Approved)
            {
                subject = "Tài liệu đã được phê duyệt";

            }
            else if (documentStatus == DocumentStatusEnum.Reject)
            {
                subject = "Tài liệu bị từ chối";
            }
            var userResult = await _userRepository.getUserByUserName("Scriptor");
            if (userResult.HasData)
            {
                foreach (var director in userResult.Data)
                {
                    await _mailService.SendEmailsAsync(director.Email, subject, body);
                }
            }

            var notification = new Notify
            {
                SenderId = userId,
                CreatedAt = DateTime.Now,
                UserId = document.CreateBy,
                ActionType = documentStatus == DocumentStatusEnum.Approved ? 1 : 0,
                ObjectType = 2,
                ObjectId = document.Id,
                Title = subject,
                Detail = body,
                Status = 2
            };

            await _notificationRepository.InsertAsync(notification);
            await _unitOfWork.SaveChangeAsync();
        }
        private async Task SendNotificationToDirectors(string fileUrl, string fileName)
        {
            var directorsResult = await _userRepository.getUserByUserName("Director");
            if (directorsResult.HasData)
            {
                var directors = directorsResult.Data;
                var subject = "Thông báo: File kịch bản mới cần phê duyệt";
                var body = CreateEmailBody(fileUrl, fileName);

                foreach (var director in directors)
                {
                    await _mailService.SendEmailsAsync(director.Email, subject, body);
                }
            }
        }
        private string CreateEmailBody(string fileUrl, string fileName)
        {
            return $@"
<!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Thông báo phê duyệt file</title>
    <style>
        body {{
            font-family: Arial, sans-serif;
            line-height: 1.6;
            background-color: #f9f9f9;
            margin: 0;
            padding: 0;
        }}
        .email-container {{
            max-width: 600px;
            margin: 20px auto;
            padding: 20px;
            background-color: #ffffff;
            border: 1px solid #ddd;
            border-radius: 8px;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
        }}
        .header {{
            text-align: center;
            background-color: #007BFF;
            color: #ffffff;
            padding: 10px 0;
            border-radius: 8px 8px 0 0;
        }}
        .header h1 {{
            font-size: 20px;
            margin: 0;
        }}
        .content {{
            padding: 20px;
            color: #333333;
        }}
        .content p {{
            margin: 10px 0;
        }}
        .content a {{
            color: #007BFF;
            text-decoration: none;
        }}
        .content a:hover {{
            text-decoration: underline;
        }}
        .footer {{
            text-align: center;
            font-size: 12px;
            color: #666666;
            margin-top: 20px;
        }}
    </style>
</head>
<body>
    <div class='email-container'>
        <div class='header'>
            <h1>Thông báo phê duyệt file</h1>
        </div>
        <div class='content'>
            <p>Xin chào <strong>Director</strong>,</p>
            <p>Một file mới đã được upload lên hệ thống và cần được phê duyệt. Dưới đây là thông tin chi tiết:</p>
            <ul>
                <li><strong>Tên file:</strong> {fileName}</li>
                <li><strong>Link:</strong> <a href='{fileUrl}' target='_blank'>Nhấn vào đây để kiểm tra</a></li>
            </ul>
            <p>Vui lòng kiểm tra và xử lý.</p>
            <p>Trân trọng,</p>
            <p><strong>Hệ thống quản lý</strong></p>
        </div>
        <div class='footer'>
            <p>&copy; {DateTime.Now.Year} Hệ thống quản lý. Tất cả các quyền được bảo lưu.</p>
        </div>
    </div>
</body>
</html>";
        }

        private string CreateEmailApproveBody(string fileUrl, string fileName)
        {

            return $@"
<!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Thông báo phê duyệt tài liệu</title>
    <style>
        body {{
            font-family: Arial, sans-serif;
            line-height: 1.6;
            background-color: #f9f9f9;
            margin: 0;
            padding: 0;
        }}
        .email-container {{
            max-width: 600px;
            margin: 20px auto;
            padding: 20px;
            background-color: #ffffff;
            border: 1px solid #ddd;
            border-radius: 8px;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
        }}
        .header {{
            text-align: center;
            background-color: #007BFF;
            color: #ffffff;
            padding: 10px 0;
            border-radius: 8px 8px 0 0;
        }}
        .header h1 {{
            font-size: 20px;
            margin: 0;
        }}
        .content {{
            padding: 20px;
            color: #333333;
        }}
        .content p {{
            margin: 10px 0;
        }}
        .content a {{
            color: #007BFF;
            text-decoration: none;
        }}
        .content a:hover {{
            text-decoration: underline;
        }}
        .footer {{
            text-align: center;
            font-size: 12px;
            color: #666666;
            margin-top: 20px;
        }}
    </style>
</head>
<body>
    <div class='email-container'>
        <div class='header'>
            <h1>Thông báo phê duyệt tài liệu</h1>
        </div>
        <div class='content'>
            <p>Xin chào <strong>Director</strong>,</p>
            <p>Tài liệu '{fileName}' đã duoc duyet. Dưới đây là thông tin chi tiết:</p>
            <ul>
                <li><strong>Tên file:</strong> {fileName}</li>
                <li><strong>Link:</strong> <a href='{fileUrl}' target='_blank'>Nhấn vào đây để kiểm tra</a></li>
            </ul>
            <p>Trân trọng,</p>
            <p><strong>Hệ thống quản lý</strong></p>
        </div>
        <div class='footer'>
            <p>&copy; {DateTime.Now.Year} Hệ thống quản lý. Tất cả các quyền được bảo lưu.</p>
        </div>
    </div>
</body>
</html>";
        }
        #endregion
    }
}
