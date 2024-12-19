using FPM.Resourses.DTOs.User.Request;
using FPM.Resourses.DTOs;
using FPM.Resourses.DTOs.User.Response;
using FPM.Resourses.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FPM.Resourses.DTOs.Reminder;

namespace FPM.Services.IServices
{
    public interface IUserService
    {
        Task<BaseResult<UserResponse>> GetAllByIdAsync(int id);
        Task<BaseResult<IEnumerable<UserResponse>>> GetAllAsync();
        Task<PaginationResult<IEnumerable<UserResponse>>> PaginationUserAsync(FilterModelRequest<FilterUserRequest> request);
        Task<BaseResult<UserResponse>> UpdateAvatarAsync(IFormFile file, int userId,string WebRootPath);
        Task<BaseResult<UserResponse>> UpdateProfileAsync(int userId, UpdateUserProfileRequest request);

        Task<BaseResult<object>> SendMailAccountAsync(int userId);

        Task<BaseResult<UserResponse>> CreateAsync(CreateUserRequest request);

        //Task<BaseResult<UserResponse>> GetUsersByRoleAsync(string username);
        Task<BaseResult<IEnumerable<ReminderReponse>>> SendMailReminderAsync();
        Task<BaseResult<string>> resetPassword(ResetPasswordRequest request);
        Task<BaseResult<string>> SendVerificationCodeAsync(string email);
        Task<BaseResult<string>> ForgotPasswordAsync(ForgotPasswordRequest request);
    }
}