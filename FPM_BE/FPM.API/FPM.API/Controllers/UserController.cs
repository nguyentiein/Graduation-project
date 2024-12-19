using FPM.API.Authorization;
using FPM.Core.Entities;
using FPM.Resourses;
using FPM.Resourses.DTOs;
using FPM.Resourses.DTOs.User.Request;
using FPM.Resourses.Enums;
using FPM.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FPM.API.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    public class UserController : ParentController
    {
        private readonly IUserService _userService;
        private readonly IHostEnvironment _hostEnvironment;

        public UserController(IUserService userService,
                              IHostEnvironment hostEnvironment,
                              IOptionsMonitor<ResponseMessage> responseMessage, IMapper mapper) : base(responseMessage, mapper)
        {
            this._userService = userService;
            this._hostEnvironment = hostEnvironment;
        }

        [HttpPost("Pagination")]
        public async Task<IActionResult> Pagination(FilterModelRequest<FilterUserRequest> request)
        {
            var result = await _userService.PaginationUserAsync(request);

            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _userService.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _userService.GetAllByIdAsync(id);

            return Ok(result);
        }

        [HttpGet("GetProfile")]
        [Authorize]
        public async Task<IActionResult> GetUserById()
        {
            var user = (User)HttpContext.Items["User"];
            var result = await _userService.GetAllByIdAsync(user.Id);

            return Ok(result);
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            if (request == null)
            {
                return BadRequest(new { message = "Yêu cầu không hợp lệ" });
            }

            var result = await _userService.resetPassword(request);

            return Ok(result); 
        }

        [HttpPost("via-email")]
        public async Task<IActionResult> ForgotPassword([FromBody] Via_EmailRequest request)
        {
            var result = await _userService.SendVerificationCodeAsync(request.Email);
            if (result.Status == StatusEnum.Failed)
            {
                return BadRequest(result);
            }

            return Ok(new { message = "Mã xác thực đã được gửi vào email của bạn" });
        }

        [HttpPost("reset-password-email")]
        public async Task<IActionResult> resetPassword([FromBody] ForgotPasswordRequest request)
        {
            var result = await _userService.ForgotPasswordAsync(request);
            if (result.Status == StatusEnum.Failed)
            {
                return BadRequest(result);
            }

            return Ok(new { message = "Mật khẩu đã được cập nhật thành công." });
        }

        [HttpPost("upload-avatar")]
        [Authorize]
        public async Task<IActionResult> UpdateAvatar(IFormFile imageFile)
        {
            var user = (User)HttpContext.Items["User"];
            string webRootPath = _hostEnvironment.ContentRootPath;
            var result = await  _userService.UpdateAvatarAsync(imageFile, user.Id,webRootPath);

            return Ok(result);
        }

        [HttpPost("update")]
        [Authorize]
        public async Task<IActionResult> UpdateProfile(UpdateUserProfileRequest request)
        {
            //merge
            var user = (User)HttpContext.Items["User"];
            var result = await _userService.UpdateProfileAsync(user.Id, request);

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateUserRequest request)
        {
            var response =  await _userService.CreateAsync(request);
            return Ok(response);
        }
        [HttpPost("sendMailAccount")]
        public async Task<IActionResult> SendMailAccountAsync(int userId)
        {
            var response = await _userService.SendMailAccountAsync(userId);
            return Ok(response);
        }

        [HttpPost("sendMailReminder")]
        public async Task<IActionResult> sendMailReminder()
        {
            var response = await _userService.SendMailReminderAsync();
            return Ok(response);
        }

    }
}
