using AutoMapper;
using AutoMapper.Execution;
using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using FPM.Repositories.IRepository;
using FPM.Repositories.Repository;
using FPM.Resourses;
using FPM.Resourses.DTOs.Email.Request;
using FPM.Resourses.DTOs.Reminder;
using FPM.Resourses.DTOs.Segment.Request;
using FPM.Resourses.DTOs.Segment.Response;
using FPM.Resourses.Enums;
using FPM.Resourses.Results;
using FPM.Services.IServices;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Services
{
    public class PreproductionSegmentService : BaseService, IPreproductionSegmentService
    {


        #region Prperty
        private readonly IPreproducitonSegmentRepository _preproducitonSegmentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPreproductionMemberRepository _preproductionMemberRepository;
        private readonly ISegmentMemberRepository _segmentMemberRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMailService _mailService;
        private readonly IFileService _fileService;
        private readonly IUriService _uriService;
        #endregion



        #region Contructor
        public PreproductionSegmentService(IPreproducitonSegmentRepository preproducitonSegmentRepository,
                                           IUserRepository userRepository,
                                           IMailService mailService,
                                           IFileService fileService,
                                           IUriService uriService,
                                           IPreproductionMemberRepository preproductionMemberRepository,
                                           ISegmentMemberRepository segmentMemberRepository,
                                           IUnitOfWork unitOfWork,
            IMapper mapper, IOptionsMonitor<ResponseMessage> responseMessage) : base(mapper, responseMessage)
        {
            this._preproducitonSegmentRepository = preproducitonSegmentRepository;
            this._userRepository = userRepository;
            this._preproductionMemberRepository = preproductionMemberRepository;
            this._segmentMemberRepository = segmentMemberRepository;
            this._mailService = mailService;
            this._uriService = uriService;
            this._uriService = uriService;
            this._unitOfWork = unitOfWork;
        }


        #endregion

        #region Method
        public async Task<BaseResult<PreproductionSegmentResponse>> CreateAsync(CreateSegmentRequest request)
        {
            var segment = Mapper.Map<PreproductionSegment>(request);

            try
            {
                await _preproducitonSegmentRepository.InsertAsync(segment);
                await _unitOfWork.SaveChangeAsync();

                return GetBaseResult(CodeMessage._200, Mapper.Map<PreproductionSegmentResponse>(segment));
            }
            catch (Exception ex)
            {

                return GetBaseResult<PreproductionSegmentResponse>(CodeMessage._99, status: Resourses.Enums.StatusEnum.Failed);
            }

        }

        public async Task<BaseResult<PreproductionSegmentResponse>> DeleteAsync(int segmentId)
        {
            var segment = await _preproducitonSegmentRepository.FindAsync(segmentId);
            if (!segment.HasData) return GetBaseResult<PreproductionSegmentResponse>(CodeMessage._212, status: Resourses.Enums.StatusEnum.Failed);

            segment.Data.IsDeleted = true;
            try
            {
                _preproducitonSegmentRepository.Update(segment.Data);

                _unitOfWork.SaveChange();

                return GetBaseResult<PreproductionSegmentResponse>(CodeMessage._200, status: Resourses.Enums.StatusEnum.Success);
            }
            catch (Exception ex)
            {
                return GetBaseResult<PreproductionSegmentResponse>(CodeMessage._99, status: Resourses.Enums.StatusEnum.Failed);
            }


        }

        public async Task<BaseResult<IEnumerable<PreproductionSegmentResponse>>> GetAllAsync(int preproductionSegment)
        {
            var result = await _preproducitonSegmentRepository.GetAllSegmentAsync(preproductionSegment);
            if (!result.HasData) return GetBaseResult<IEnumerable<PreproductionSegmentResponse>>(CodeMessage._211, status: Resourses.Enums.StatusEnum.Failed);

            return GetBaseResult(CodeMessage._200, Mapper.Map<IEnumerable<PreproductionSegmentResponse>>(result.Data));
        }

        public async Task<BaseResult<PreproductionSegmentResponse>> UpdateAsync(UpdateSegmentRequest request)
        {
            var segment = await _preproducitonSegmentRepository.FindAsync(request.Id);
            if (!segment.HasData) return GetBaseResult<PreproductionSegmentResponse>(CodeMessage._212, status: Resourses.Enums.StatusEnum.Failed);

            Mapper.Map<UpdateSegmentRequest, PreproductionSegment>(request, segment.Data);

            try
            {
                _preproducitonSegmentRepository.Update(segment.Data);

                _unitOfWork.SaveChange();

                return GetBaseResult(CodeMessage._200, Mapper.Map<PreproductionSegmentResponse>(segment.Data));
            }
            catch (Exception ex)
            {
                return GetBaseResult<PreproductionSegmentResponse>(CodeMessage._99, status: Resourses.Enums.StatusEnum.Failed);
            }

        }

        public async Task<BaseResult<PreproductionSegmentMemberResponse>> AddMemberAsync(CreateSegmentMemberRequest request)
        {
            var segment = await _preproducitonSegmentRepository.FindAsync(request.PreProductionSegmentId);
            if (!segment.HasData) return GetBaseResult<PreproductionSegmentMemberResponse>(CodeMessage._214, status: Resourses.Enums.StatusEnum.Failed);

            var preMember = await _preproductionMemberRepository.FindAsync(request.PreproductionPlanMemberId);

            if (!preMember.HasData) return GetBaseResult<PreproductionSegmentMemberResponse>(CodeMessage._214, status: Resourses.Enums.StatusEnum.Failed);
            var user = await _userRepository.FindAsync(preMember.Data.MemberId.GetValueOrDefault());

            if (!user.HasData) return GetBaseResult<PreproductionSegmentMemberResponse>(CodeMessage._214, status: Resourses.Enums.StatusEnum.Failed);


            var member = Mapper.Map<PreproductionsegmentMember>(request);
            member.User = user.Data;
            try
            {
                await _segmentMemberRepository.InsertAsync(member);
                await _unitOfWork.SaveChangeAsync();
                return GetBaseResult(CodeMessage._200, Mapper.Map<PreproductionSegmentMemberResponse>(member));
            }
            catch (Exception ex)
            {
                return GetBaseResult<PreproductionSegmentMemberResponse>(CodeMessage._99, status: Resourses.Enums.StatusEnum.Failed);

            }
        }

        public async Task<BaseResult<PreproductionSegmentMemberResponse>> UpdateMemberAsync(UpdateSegmentMemberRequest request)
        {
            var segmentMemberInfo = await _segmentMemberRepository.GetByIdAsync(request.Id);
            if (!segmentMemberInfo.HasData) return GetBaseResult<PreproductionSegmentMemberResponse>(CodeMessage._212, status: Resourses.Enums.StatusEnum.Failed);

            //cập nhật tổng thời gian làm và tổng lương
            var preMemberInfo = await _preproductionMemberRepository.GetMemberByIdAsync(segmentMemberInfo.Data.PlanMemberId.GetValueOrDefault());
            if (!preMemberInfo.HasData) return GetBaseResult<PreproductionSegmentMemberResponse>(CodeMessage._212, status: Resourses.Enums.StatusEnum.Failed);

            preMemberInfo.Data.TotalWorkingHour = preMemberInfo.Data.TotalWorkingHour - segmentMemberInfo.Data.WorkingHour.GetValueOrDefault() + request.WorkingHour.GetValueOrDefault();
            preMemberInfo.Data.TotalSalary = GetSumSalary(salary: preMemberInfo.Data.Salary, preMemberInfo.Data.SalaryType, preMemberInfo.Data.TotalWorkingHour);

            Mapper.Map<UpdateSegmentMemberRequest,PreproductionsegmentMember>(request, segmentMemberInfo.Data);
            
            try
            {
                _segmentMemberRepository.Update(segmentMemberInfo.Data);
                _preproductionMemberRepository.Update(preMemberInfo.Data);
                _unitOfWork.SaveChange();
                return GetBaseResult(CodeMessage._200, Mapper.Map<PreproductionSegmentMemberResponse>(segmentMemberInfo.Data));
            }
            catch (Exception ex)
            {
                return GetBaseResult<PreproductionSegmentMemberResponse>(CodeMessage._99, status: Resourses.Enums.StatusEnum.Failed);

            }

        }

        public async Task<BaseResult<PreproductionSegmentMemberResponse>> RemoveMemberAsync(int segmentMemberId)
        {
            var segmentMember = await _segmentMemberRepository.FindAsync(segmentMemberId);

            if(!segmentMember.HasData) return GetBaseResult<PreproductionSegmentMemberResponse>(CodeMessage._212, status: Resourses.Enums.StatusEnum.Failed);
            try
            {
                _segmentMemberRepository.DeleteById(segmentMemberId);
                _unitOfWork.SaveChange();

                return GetBaseResult<PreproductionSegmentMemberResponse>(CodeMessage._212, status: Resourses.Enums.StatusEnum.Success);
            }
            catch (Exception ex) 
            {
                return GetBaseResult<PreproductionSegmentMemberResponse>(CodeMessage._99, status: Resourses.Enums.StatusEnum.Failed);
            }
            
        }

        public async Task<BaseResult<PreproductionSegmentResponse>> GetAllSegmentInPreproductionByIdSeg(int id)
        {
            var result = await _preproducitonSegmentRepository.GetByIdAync(id);

            if (!result.HasData) return GetBaseResult<PreproductionSegmentResponse>(CodeMessage._211, status: Resourses.Enums.StatusEnum.Failed);

            return GetBaseResult(CodeMessage._200, Mapper.Map<PreproductionSegmentResponse>(result.Data));

        }

        public async Task<BaseResult<IEnumerable<ReminderReponse>>> SendMailReminderAsync(SendRemindRequest remindRequest)
        {
            var userInfo = await _preproducitonSegmentRepository.GetAllSegmentRemindAsync(remindRequest.SegId);
            if (!userInfo.HasData)
                return GetBaseResult<IEnumerable<ReminderReponse>>(CodeMessage._211, status: StatusEnum.Failed);

            var userMap = Mapper.Map<IEnumerable<ReminderReponse>>(userInfo.Data);

            foreach (var user in userMap)
            {
       
                var project = user.PreProduction?.Name;
                var address = user.Address;
                DateTime fromDate = user.FromDate ?? DateTime.MinValue;


                var teamInSegment = user.PreproductionsegmentMembers
                    .Where(member => member.User != null
                        && !string.IsNullOrEmpty(member.User.FirstName)
                        && !string.IsNullOrEmpty(member.User.LastName))
                    .Select(member => $"{member.User.FirstName} {member.User.LastName}-{member.User.Tel}")
                    .ToList();

                foreach (var member in user.PreproductionsegmentMembers)
                {
                    if (member.User != null && !string.IsNullOrEmpty(member.User.Email))
                    {
              
                        string email = member.User.Email;
                        string fullName = $"{member.User.FirstName} {member.User.LastName}".Trim();

                        if (string.IsNullOrEmpty(fullName))
                            fullName = "Không có tên";


                        var sendmailRequest = new SendEmailRequest
                        {
                            ToMailRendMind = new List<string> { email }, 
                            Name = fullName,                            
                            Address = address,
                            Project = project,
                            Date = fromDate,
                            Subject = "Thông tin tài khoản",
                            Content = HtmlAccountInfoMailBodyReminder(
                                teamInSegment,  
                                fullName,       
                                project,
                                fromDate,
                                address
                            )
                        };

                        // Gửi email
                        await _mailService.SendEmailReminderAsync(sendmailRequest);
                    }
                }
            }

            return GetBaseResult(CodeMessage._200, Mapper.Map<IEnumerable<ReminderReponse>>(userInfo.Data));
        }


        #endregion

        #region PrivateWork
        private decimal GetSumSalary(decimal salary, SalaryTypeEnum type, decimal workingHour)
        {
            decimal sumSalary = 0;

            switch (type)
            {
                case SalaryTypeEnum.Hour:
                    sumSalary = salary * workingHour;
                    break;

                case SalaryTypeEnum.Day:
                    sumSalary = (salary / 24) * workingHour;
                    break;

                case SalaryTypeEnum.Month:
                    sumSalary = (salary / (24 * 30)) * workingHour;
                    break;

                case SalaryTypeEnum.Week:
                    sumSalary = (salary / (24 * 7)) * workingHour;
                    break;
            }
            return sumSalary;
        }


        private static string HtmlAccountInfoMailBodyReminder(List<string> team,string fullname,string project,DateTime date,string address )
        {
            string fullNameWithPhone = string.Join(", ", fullname);
            int phoneIndex = fullNameWithPhone.IndexOf("Số Điện Thoại");

            string fullNameFormatted = phoneIndex > -1
    ? fullNameWithPhone.Substring(0, phoneIndex).Trim()
    : fullNameWithPhone;
            string teamSeg = string.Join(", ", team);
            return
                $@"<html>
<body style='font-family: Arial, sans-serif; line-height: 1.6;'>
    <p>Kính gửi :{fullNameFormatted}</p>

    <p>Đây là email nhắc nhở về công việc <strong>Quay Phim  {project} </strong> mà chúng ta đã thảo luận. Theo kế hoạch:</p>
    <p>Thành viên trong phân đoạn   :{teamSeg}<br></p>
    <p>Ngày bắt đầu: <strong>{date}</strong></p>
    <table style='border-collapse: collapse; width: 100%; max-width: 600px; margin: 20px 0;'>
        <thead>
            <tr style='background-color: #f2f2f2;'>
                <th style='border: 1px solid #ddd; padding: 8px; text-align: left;'>Hạng mục công việc</th>
                <th style='border: 1px solid #ddd; padding: 8px; text-align: left;'>Trạng thái</th>
            </tr>
        </thead>
        <tbody>
           
            <tr>
                <td style='border: 1px solid #ddd; padding: 8px;'>Liên hệ với diễn viên và đội hậu kỳ</td>
                <td style='border: 1px solid #ddd; padding: 8px;'>Hoàn tất</td>
            </tr>
            <tr>
                <td style='border: 1px solid #ddd; padding: 8px;'>Địa điểm quay</td>
                <td style='border: 1px solid #ddd; padding: 8px;'>{address}</td>
            </tr>
        </tbody>
    </table>
  
    <p>Nếu có bất kỳ khó khăn hoặc thắc mắc nào cần giải quyết, vui lòng phản hồi email này hoặc liên hệ qua số điện thoại <strong>0123-456-789</strong> để chúng ta cùng phối hợp xử lý.</p>
    <p>Rất mong nhận được sự hợp tác của các anh/chị để hoàn thành công việc đúng tiến độ.</p>
    <p>Xin cảm ơn!</p>
    <p>Trân trọng,</p>
    <p><strong>Nguyễn Văn Tiến</strong><br>Quản lý Dự Án<br>Email: <a href='mailto:nguyenvana@company.com'>nguyenvana@company.com</a> | SĐT: 0123-456-789</p>
</body>
</html>";


        }



        #endregion

    }




}
