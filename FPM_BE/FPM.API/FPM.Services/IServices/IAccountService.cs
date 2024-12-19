using FPM.Resourses.DTOs.User.Request;
using FPM.Resourses.DTOs.User.Response;
using FPM.Resourses.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.IServices
{
    public interface IAccountService
    {
        Task<BaseResult<LoginResponse>> LoginAsync(LoginRequest request);

        Task<BaseResult<UserResponse>> UpdateAccountAsync(UpdateAccountRequest request);

    }
}
