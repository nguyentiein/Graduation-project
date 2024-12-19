using AutoMapper;
using FPM.Repositories.Infrastructure;
using FPM.Repositories.IRepository;
using FPM.Resourses;
using FPM.Resourses.Enums;
using FPM.Resourses.Results;
using FPM.Resourses.DTOs;
using FPM.Resourses.DTOs.User.Request;
using FPM.Resourses.DTOs.User.Response;
using FPM.Services.IServices;
using Microsoft.Extensions.Options;
using FPM.Extensions;
using Microsoft.AspNetCore.Http;
using FPM.Core.Entities;
using FPM.Resourses.DTOs.Email.Request;
using FPM.Resourses.DTOs.Reminder;
using FPM.Resourses.DTOs.Team.Response;
using FPM.Repositories.Repository;
using System.Net.Http;

namespace FPM.Services.Services
{
    public class UserService : BaseService, IUserService
    {
        #region Method
        private readonly IUserRepository _userRespository;
        private readonly IRoleRepository _roleRespository;
        private readonly IMailService _mailService;
        private readonly IFileService _fileService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUriService _uriService;
        #endregion
        #region Constructor
        public UserService(IUserRepository userRespository,
            IRoleRepository roleRepository,
            IMailService mailService,
            IFileService fileService,
            IUnitOfWork unitOfWork,
            IUriService uriService,
            IMapper mapper, IOptionsMonitor<ResponseMessage> responseMessage) : base(mapper, responseMessage)
        {
            this._mailService = mailService;
            this._roleRespository = roleRepository;
            this._userRespository = userRespository;
            this._fileService = fileService;
            this._unitOfWork = unitOfWork;
            this._uriService = uriService;
        }
        #endregion
        public async Task<BaseResult<UserResponse>> CreateAsync(CreateUserRequest request)
        {
            var user = Mapper.Map<User>(request);
            var listUser = await _userRespository.GetAllAsync();

            var checkUserName = listUser.Where(x => x.UserName == request.UserName.Trim()|| x.Email==request.Email.Trim()).FirstOrDefault();
            if (checkUserName != null) return GetBaseResult<UserResponse>(CodeMessage._211, status: StatusEnum.Failed, message: "Tên Tài Khoản và Email  đã tồn tại");

            if (request.RoleId !=null || request.RoleId.Count > 0)
            foreach(var id in request.RoleId)
            {
                 var roleInfo = await _roleRespository.FindAsync(id);
                 if (!roleInfo.HasData) return GetBaseResult<UserResponse>(CodeMessage._211, status: StatusEnum.Failed, message: "Role không tồn tại");

                 user.Roles.Add(roleInfo.Data);   
            }
            //user.PassWord = GenerateRandomPassword();
            user.Status = (UserEnum)1;
            user.PassWord = "123456";
            await _userRespository.InsertAsync(user);
            await _unitOfWork.SaveChangeAsync();

            //sendMail account

            var sendMailAccount = await SendMailAccountAsync(user.Id);
            if(sendMailAccount.StatusCode != "200")
            {
                return GetBaseResult<UserResponse>(CodeMessage._217, status: StatusEnum.Failed);
            }
            return GetBaseResult(CodeMessage._200,Mapper.Map<UserResponse>(user));
        }
        public async Task<BaseResult<string>> resetPassword(ResetPasswordRequest request)
        {
            var user = await _userRespository.GetUserById(request.userId);

            if (!user.HasData)
                return GetBaseResult<string>(CodeMessage._211, status: StatusEnum.Failed, message: "User không tồn tại");
            if (user.Data.PassWord != request.currentPassword)
                return GetBaseResult<string>(CodeMessage._211, status: StatusEnum.Failed, message: "Mật khẩu hiện tại không đúng");


            if (request.newPassword == request.currentPassword)
                return GetBaseResult<string>(CodeMessage._211, status: StatusEnum.Failed, message: "Mật khẩu mới phai khac mat khau cu");

            if (request.newPassword != request.cfPassword)
                return GetBaseResult<string>(CodeMessage._211, status: StatusEnum.Failed, message: "Mật khẩu mới và xác nhận mật khẩu không khớp");

            user.Data.PassWord = request.newPassword;
            _userRespository.Update(user.Data);
            await _unitOfWork.SaveChangeAsync();
            return GetBaseResult<string>(CodeMessage._200, "Password đã được cập nhật thành công.");
        }
        public async Task<BaseResult<IEnumerable<UserResponse>>> GetAllAsync()
        {
            var result = await _userRespository.GetAllUserAsync();

            if (!result.HasData) return GetBaseResult<IEnumerable<UserResponse>>(CodeMessage._211, status: Resourses.Enums.StatusEnum.Failed);

            return GetBaseResult(CodeMessage._200, Mapper.Map<IEnumerable<UserResponse>>(result.Data));
        }

        public async Task<BaseResult<UserResponse>> GetAllByIdAsync(int id)
        {

            var result = await _userRespository.GetUserById(id);

            if (!result.HasData) return GetBaseResult<UserResponse>(CodeMessage._211, status: Resourses.Enums.StatusEnum.Failed);



            return GetBaseResult(CodeMessage._200, Mapper.Map<UserResponse>(result.Data));

        }

        public async Task<BaseResult<IEnumerable<UserResponse>>> GetUsersByRoleAsync(string username)
        {
            var result = await _userRespository.getUserByUserName(username);

            if (!result.HasData)
                return GetBaseResult<IEnumerable<UserResponse>>(CodeMessage._211, status: Resourses.Enums.StatusEnum.Failed);
            var userResponses = result.Data.Select(user =>
            {
                user.AvatarUrl = string.Concat(_uriService.GetBaseUri(), user.AvatarUrl); 
                return Mapper.Map<UserResponse>(user);
            });
            return GetBaseResult(CodeMessage._200, userResponses);
        }


        public async Task<PaginationResult<IEnumerable<UserResponse>>> PaginationUserAsync(FilterModelRequest<FilterUserRequest> request)
        {
            var resourse = await _userRespository.PaginationUserAsync(request);

            var users = Mapper.Map<IEnumerable<UserResponse>>(resourse.data);

            var result = GetPaginationResult(CodeMessage._200, users);

            result.CreatePaginationResponse(request, resourse.numberRecord);

            return result;

        }

        public async Task<BaseResult<object>> SendMailAccountAsync(int userId)
        {
            var userInfo = await _userRespository.GetUserById(userId);
            if(!userInfo.HasData) return GetBaseResult<object>(CodeMessage._211, StatusEnum.Failed);

            var sendmailRequest = new SendEmailRequest
            {
                ToMail = userInfo.Data.Email,
                Subject = "Thông tin tài khoản",
                Content = HtmlAccountInfoMailBody(userInfo.Data.FirstName, userInfo.Data.UserName, userInfo.Data.PassWord)
            };
            await _mailService.SendEmailAsync(sendmailRequest);

            return GetBaseResult<object>(CodeMessage._200, StatusEnum.Success);
        }

        public async Task<BaseResult<UserResponse>> UpdateAvatarAsync(IFormFile file, int userId, string WebRootPath)
        {
            var uploadFile = await _fileService.SaveImageAsync(file, WebRootPath);
            if (uploadFile.status == 0) return GetBaseResult<UserResponse>(CodeMessage._239, status: Resourses.Enums.StatusEnum.Failed);

            var user = await _userRespository.FindAsync(userId);
            if (!user.HasData) GetBaseResult<UserResponse>(CodeMessage._211, status: Resourses.Enums.StatusEnum.Failed);

            user.Data.AvatarUrl = uploadFile.message;

            _userRespository.Update(user.Data);
            await _unitOfWork.SaveChangeAsync();

            var result = Mapper.Map<UserResponse>(user.Data);
            //result.AvatarUrl = string.Concat(_uriService.GetBaseUri(), result.AvatarUrl);
            return GetBaseResult(CodeMessage._200, result);

        }

        public async Task<BaseResult<UserResponse>> UpdateProfileAsync(int userId, UpdateUserProfileRequest request)
        {
            var result = await _userRespository.FindAsync(userId);

            if (!result.HasData) return GetBaseResult<UserResponse>(CodeMessage._211, status: Resourses.Enums.StatusEnum.Failed);

            Mapper.Map<UpdateUserProfileRequest, User>(request, result.Data);

            try
            {
                _userRespository.Update(result.Data);
                await _unitOfWork.SaveChangeAsync();

                return GetBaseResult(CodeMessage._200, Mapper.Map<UserResponse>(result.Data));
            }
            catch (Exception ex)
            {
                return GetBaseResult<UserResponse>(CodeMessage._99, status: StatusEnum.Failed, message: ex.Message);
            }
            

        }
        public async Task<BaseResult<IEnumerable<ReminderReponse>>> SendMailReminderAsync()
        {
            var userInfo = await _userRespository.GetAllUserRemindAsync();
            var userMap = Mapper.Map<IEnumerable<ReminderReponse>>(userInfo.Data);
            if (!userInfo.HasData) return GetBaseResult<IEnumerable<ReminderReponse>>(CodeMessage._211, status: StatusEnum.Failed);

            foreach (var user in userMap)
            {
                var sendmailRequest = new SendEmailRequest
                {
                    ToMail = user.PreProduction.Name,
                    Subject = "Thông tin tài khoản",
                    Content = HtmlAccountInfoMailBodyReminder()
                };

                await _mailService.SendEmailAsync(sendmailRequest);
            }


            return GetBaseResult(CodeMessage._200, Mapper.Map<IEnumerable<ReminderReponse>>(userInfo.Data));

        }
        #region PrivateWork
        private static string HtmlAccountInfoMailBody(string firstName, string userName, string password)
        {
            return $@"<html>
<body style='font-family: Arial, sans-serif; line-height: 1.6;'>
    <p>Dear <strong>{firstName}</strong>,</p>
    <p>Cảm ơn bạn đã tham cùng chúng tôi. Dưới đây là thông tin đăng nhập của bạn:</p>
    <table style='border-collapse: collapse; width: 100%; max-width: 600px; margin: 20px 0;'>
        <thead>
            <tr style='background-color: #f2f2f2;'>
                <th style='border: 1px solid #ddd; padding: 8px; text-align: left;'>Tên tài khoản</th>
                <th style='border: 1px solid #ddd; padding: 8px; text-align: left;'>Mật khẩu</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td style='border: 1px solid #ddd; padding: 8px;'>{userName}</td>
                <td style='border: 1px solid #ddd; padding: 8px;'>{password}</td>
            </tr>
        </tbody>
    </table>
    <p style='margin-top: 20px;'>Vui lòng giữ thông tin này an toàn. Nếu bạn có bất kỳ câu hỏi nào, vui lòng liên hệ với nhóm hỗ trợ của chúng tôi.</p>
    <p>Trân trọng,</p>
    <p><strong>Đội ngũ dịch vụ</strong></p>
</body>
</html>";
        }

        private static string GenerateRandomPassword(int length = 6)
        {
            {
                if (length < 6)
                    throw new ArgumentException("Password length should be at least 8 characters for better security.");

                const string upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                const string lowerCase = "abcdefghijklmnopqrstuvwxyz";
                const string digits = "0123456789";
                const string specialChars = "!@#$%^&*()-_=+<>?";

                // Combine all character sets
                string allChars = upperCase + lowerCase + digits + specialChars;

                Random random = new Random();

                // Ensure the password contains at least one character from each set
                string password = new string(Enumerable.Repeat(upperCase, 1)
                    .Concat(Enumerable.Repeat(lowerCase, 1))
                    .Concat(Enumerable.Repeat(digits, 1))
                    .Concat(Enumerable.Repeat(specialChars, 1))
                    .SelectMany(s => s)
                    .OrderBy(_ => random.Next())
                    .ToArray());

                // Fill the rest of the password with random characters
                password += new string(Enumerable.Repeat(allChars, length - 4)
                    .Select(s => s[random.Next(s.Length)])
                    .ToArray());

                // Shuffle the password to randomize character positions
                password = new string(password.OrderBy(_ => random.Next()).ToArray());

                return password;
            }
        }

        private static string HtmlAccountInfoMailBodyReminder()
        {

            return

                $@"<html>
<body style='font-family: Arial, sans-serif; line-height: 1.6;'>
    <p>Kính gửi Đội Nhóm Quay Phim,</p>
    <p>Đây là email nhắc nhở về công việc <strong>Quay Phim </strong> mà chúng ta đã thảo luận. Theo kế hoạch:</p>
    <table style='border-collapse: collapse; width: 100%; max-width: 600px; margin: 20px 0;'>
        <thead>
            <tr style='background-color: #f2f2f2;'>
                <th style='border: 1px solid #ddd; padding: 8px; text-align: left;'>Hạng mục công việc</th>
                <th style='border: 1px solid #ddd; padding: 8px; text-align: left;'>Trạng thái</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td style='border: 1px solid #ddd; padding: 8px;'>Chuẩn bị thiết bị quay phim</td>
                <td style='border: 1px solid #ddd; padding: 8px;'>Đang xử lý</td>
            </tr>
            <tr>
                <td style='border: 1px solid #ddd; padding: 8px;'>Xác nhận kịch bản</td>
                <td style='border: 1px solid #ddd; padding: 8px;'>Chưa bắt đầu</td>
            </tr>
            <tr>
                <td style='border: 1px solid #ddd; padding: 8px;'>Liên hệ với diễn viên và đội hậu kỳ</td>
                <td style='border: 1px solid #ddd; padding: 8px;'>Hoàn tất</td>
            </tr>
            <tr>
                <td style='border: 1px solid #ddd; padding: 8px;'>Địa điểm quay</td>
                <td style='border: 1px solid #ddd; padding: 8px;'>Đang chuẩn bị</td>
            </tr>
        </tbody>
    </table>
    <p>Hạn hoàn thành: <strong>30/11/2024</strong></p>
    <p>Nếu có bất kỳ khó khăn hoặc thắc mắc nào cần giải quyết, vui lòng phản hồi email này hoặc liên hệ qua số điện thoại <strong>0123-456-789</strong> để chúng ta cùng phối hợp xử lý.</p>
    <p>Rất mong nhận được sự hợp tác của các anh/chị để hoàn thành công việc đúng tiến độ.</p>
    <p>Xin cảm ơn!</p>
    <p>Trân trọng,</p>
    <p><strong>Nguyễn Văn Tiến</strong><br>Quản lý Dự Án<br>Email: <a href='mailto:nguyenvana@company.com'>nguyenvana@company.com</a> | SĐT: 0123-456-789</p>
</body>
</html>";


        }

        public async Task<BaseResult<string>> SendVerificationCodeAsync(string email)
        {
            var user = await _userRespository.getUserByEmail(email);
            if (!user.HasData)
            {
                return GetBaseResult<string>(CodeMessage._211, status: StatusEnum.Failed, message: "Email không tồn tại");
            }
            var verificationCode = new Random().Next(100000, 999999).ToString();

            user.Data.verificationCode = verificationCode;
            _userRespository.Update(user.Data);
            await _unitOfWork.SaveChangeAsync();

            var emailBody = $"Mã xác thực của bạn là: {verificationCode}";

            await _mailService.SendEmailsAsync(user.Data.Email, "Mã xác thực quên mật khẩu", emailBody);

            return GetBaseResult(CodeMessage._200, "Mã xác thực đã được gửi vào email của bạn");
        }

        public async Task<BaseResult<string>> ForgotPasswordAsync(ForgotPasswordRequest request)
        {
            var user = await _userRespository.getUserByEmail(request.Email);
            if (!user.HasData)
            {
                return GetBaseResult<string>(CodeMessage._211, status: StatusEnum.Failed, message: "Email không tồn tại");
            }
            if (user.Data.verificationCode!=request.VerificationCode)
            {
                return GetBaseResult<string>(CodeMessage._211, status: StatusEnum.Failed, message: "ma xac thuc khong dung");
            }
            if (request.NewPassword != request.ConfirmPassword)
            {
                return GetBaseResult<string>(CodeMessage._211, status: StatusEnum.Failed, message: "Mật khẩu mới và xác nhận không khớp");
            
            }
            user.Data.PassWord = request.NewPassword;
            user.Data.verificationCode = null;
            _userRespository.Update(user.Data);
            await _unitOfWork.SaveChangeAsync();

            return GetBaseResult<string>(CodeMessage._200, "Mật khẩu đã được cập nhật thành công.");
        }


        #endregion
    }
}
