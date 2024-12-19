using AutoMapper;
using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using FPM.Repositories.IRepository;
using FPM.Repositories.Repository;
using FPM.Resourses;
using FPM.Resourses.DTOs.CommonCategory.Response;
using FPM.Resourses.DTOs.Team.Response;
using FPM.Resourses.DTOs.Teams.Request;
using FPM.Resourses.DTOs.Topic.Reponse;
using FPM.Resourses.DTOs.Topic.Request;
using FPM.Resourses.DTOs.TopicMember.Reponse;
using FPM.Resourses.Enums;
using FPM.Resourses.Results;
using FPM.Services.IServices;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FPM.Services.Services
{
    public class TopicServices : BaseService, ITopicServices
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMailService _mailService;
        private readonly INotificationRepository _notificationRepository;
        public TopicServices(INotificationRepository notificationRepository, IMailService mailService, IUserRepository userRepository, ITopicRepository topicRepository, IUnitOfWork unitOfWork,IMapper mapper, IOptionsMonitor<ResponseMessage> responseMessage) : base(mapper, responseMessage)
        {
            _userRepository = userRepository;
            _topicRepository = topicRepository;
            _unitOfWork = unitOfWork;
            _mailService = mailService;
            _notificationRepository = notificationRepository;

        }

        public async Task<BaseResult<TopicResponse>> CreateNewTopicAsync(int userId, CreateTopicRequest request)
        {
            try
            {
                
                var model = Mapper.Map<Topic>(request);
                await _topicRepository.InsertAsync(model);
                await _unitOfWork.SaveChangeAsync();
                var response = Mapper.Map<TopicResponse>(model);
                await SendNotificationToLeader(response.Name, response.Description);

                var creator = await _userRepository.GetUserById(userId);
                string creatorName = $"{creator.Data.FirstName} {creator.Data.LastName}".Trim();
                var leaderResult = await _userRepository.getUserByUserName("Leader");

                if (leaderResult.HasData)
                {
                    var directors = leaderResult.Data;
                    foreach (var director in directors)
                    {
                        var objectType = request.Type == 1 ? 1 : 0;

                        var title = request.Type == 1
                            ? $"Đề cương mới: {response.Name} được tạo bởi {creatorName}"
                            : $"Chủ đề mới: {response.Name} được tạo bởi {creatorName}";

                        var detail = request.Type == 1
                            ? $"Đề cương '{response.Name}' đã được tạo và cần phê duyệt."
                            : $"Chủ đề '{response.Name}' đã được tạo và cần phê duyệt.";
                        var notification = new Notify
                        {
                            SenderId = userId,
                            CreatedAt = DateTime.Now,
                            UserId = director.Id,
                            ActionType = 1,
                            ObjectType = objectType,
                            ObjectId = response.Id,
                            Title = title,
                            Detail = detail,
                            Status = 0
                        };
                        await _notificationRepository.InsertAsync(notification);
                    }
                    await _unitOfWork.SaveChangeAsync();
                }

                return GetBaseResult(CodeMessage._200, response);
            }
            catch (ArgumentException ex)
            {
                return GetBaseResult<TopicResponse>(CodeMessage._98, status: StatusEnum.Failed, message: ex.Message);
            }
        }

        private async Task SendNotificationToLeader(string topicTitle, string topicDescription)
        {
            var leaderResult = await _userRepository.getUserByUserName("Leader");
            if (leaderResult.HasData)
            {
                var leader = leaderResult.Data;
                var subject = "Thông báo: Topic mới cần phê duyệt";
                var body = CreateEmailBodyForTopic(topicTitle, topicDescription);

                foreach (var l in leader)
                {
                    await _mailService.SendEmailsAsync(l.Email, subject, body);
                }
            }
        }

        public async Task<BaseResult<TopicResponse>> DeleteAsync(int id)
        {
            //validate data
            var testModel = await _topicRepository.FindAsync(id);
            var status = await _topicRepository.GetTopicByIdAsync(id);
            var (hasData, topics) = await _topicRepository.GetTopicByIdAsync(id);

                var topic = topics.FirstOrDefault();
                
                var status01 = topic.Status;


            if (status01 == 3)
            {
                return GetBaseResult<TopicResponse>(CodeMessage._212, status: StatusEnum.Failed);
            }
            testModel.Data.IsDeleted = true;


            if (!testModel.HasData)
            {
                return GetBaseResult<TopicResponse>(CodeMessage._212, status: StatusEnum.Failed);
            }

            _topicRepository.Update(testModel.Data);
            await _unitOfWork.SaveChangeAsync();

            return GetBaseResult<TopicResponse>(CodeMessage._200, status: StatusEnum.Success);
        }

        public async Task<BaseResult<IEnumerable<TopicResponse>>> GetTopicByIdAsync(int id)
        {
            var result = await _topicRepository.GetTopicByIdAsync(id);
            if (!result.HasData)
            {
                return GetBaseResult<IEnumerable<TopicResponse>>(CodeMessage._212, status: StatusEnum.Failed);
            }

            return GetBaseResult(CodeMessage._200, Mapper.Map<IEnumerable<TopicResponse>>(result.Data));
        }

        public async Task<BaseResult<IEnumerable<TopicResponse>>> GetTopicByTypeAsync(SearchTopicRequest request)
        {
            var result = await _topicRepository.GetTopicByTypeAsync(request);
            if (result.hasData)
            {
                return GetBaseResult(CodeMessage._200, Mapper.Map<IEnumerable<TopicResponse>>(result.data));
            }
            else
                return GetBaseResult<IEnumerable<TopicResponse>>(CodeMessage._211, status: Resourses.Enums.StatusEnum.Failed);

        }

        public async Task<BaseResult<TopicResponse>> UpdateTopicAsync(UpdateTopicRequest request)
        {
           try {
                //validate data
                var testModel = await _topicRepository.FindAsync(request.Id);
                if (!testModel.HasData)
                {
                    return GetBaseResult<TopicResponse>(CodeMessage._212, status: StatusEnum.Failed);
                }
                Mapper.Map<UpdateTopicRequest, Topic>(request, testModel.Data);

                _topicRepository.Update(testModel.Data);
                await _unitOfWork.SaveChangeAsync();
                return GetBaseResult(CodeMessage._200, Mapper.Map<TopicResponse>(testModel.Data));

            }
            catch
            {
                return GetBaseResult<TopicResponse>(CodeMessage._239, status: StatusEnum.Failed);
            }
        }

        private async Task SendNotificationToDirectors(int topicId, string topicTitle, string subject, string body, string senderId, string userId)
        {
            var creator = await _userRepository.GetUserById(int.Parse(userId));
            string creatorName = $"{creator.Data.FirstName} {creator.Data.LastName}".Trim();
            var leaderResult = await _userRepository.getUserByUserName("Leader");
            if (leaderResult.HasData)
            {
                var directors = leaderResult.Data;
                foreach (var director in directors)
                {
                    await _mailService.SendEmailsAsync(director.Email, subject, body);

                    var notification = new Notify
                    {
                        SenderId = int.Parse(senderId), 
                        CreatedAt = DateTime.Now,
                        UserId = director.Id,
                        ActionType = 1, 
                        ObjectType = 3, 
                        ObjectId = topicId,
                        Title = $"Chủ đề mới: {topicTitle} được tạo bởi {creatorName} ",
                        Detail = $"Chủ đề '{topicTitle}' đã được tạo và cần phê duyệt.",
                        Status = 0 
                    };
                    await _notificationRepository.InsertAsync(notification);
                }
                await _unitOfWork.SaveChangeAsync();
            }
        }



        private string CreateEmailBodyForTopic(string topicTitle, string topicDescription)
        {
            return $@"
<!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Thông báo chủ đề mới</title>
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
            <h1>Thông báo chủ đề mới</h1>
        </div>
        <div class='content'>
            <p>Xin chào <strong>Director</strong>,</p>
            <p>Một chủ đề mới đã được tạo trên hệ thống:</p>
            <ul>
                <li><strong>Tiêu đề:</strong> {topicTitle}</li>
                <li><strong>Mô tả:</strong> {topicDescription}</li>
            </ul>
            <p>Vui lòng truy cập hệ thống để xem chi tiết.</p>
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

    }
}
