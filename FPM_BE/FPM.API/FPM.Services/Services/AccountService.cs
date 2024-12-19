using AutoMapper;
using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using FPM.Repositories.IRepository;
using FPM.Resourses;
using FPM.Resourses.DTOs.User.Request;
using FPM.Resourses.DTOs.User.Response;
using FPM.Resourses.Results;
using FPM.Services.IServices;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Services
{
    public class AccountService : BaseService, IAccountService
    {
        #region Property
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;


        #endregion

        #region Contructor
        public AccountService(IUserRepository userRepository,
                              IUnitOfWork unitOfWork,
                              IRoleRepository roleRepository,
                              IMapper mapper, IOptionsMonitor<ResponseMessage> responseMessage) : base(mapper, responseMessage)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _unitOfWork = unitOfWork;
        }


        #endregion

        #region Action

        public async Task<BaseResult<LoginResponse>> LoginAsync(LoginRequest request)
        {
            var checkUser = await _userRepository.ValidateLoginAsync(request.UserName, request.Password);
            if (!checkUser.IsExist) return GetBaseResult<LoginResponse>(CodeMessage._230, status: Resourses.Enums.StatusEnum.Failed);
            string token = generateJwtToken(checkUser.Data);
            var result = Mapper.Map<LoginResponse>(checkUser.Data);
            result.AccessToken = token;
            result.ExpireTimeUTC = DateTime.UtcNow.AddMinutes(JwtConfig.AccessTokenExpiration);
            return GetBaseResult(CodeMessage._200,result);

        }

        public async Task<BaseResult<UserResponse>> UpdateAccountAsync(UpdateAccountRequest request)
        {
            var userInfo = await _userRepository.GetUserById(request.UserId);
            if (!userInfo.HasData) return GetBaseResult<UserResponse>(CodeMessage._211, status: Resourses.Enums.StatusEnum.Failed);


            if(request.RoleId != null)
            {
                userInfo.Data.Roles.Clear();
                foreach(var id in request.RoleId)
                {
                    var roleInfo = await _roleRepository.FindAsync(id);
                    if(!roleInfo.HasData) return GetBaseResult<UserResponse>(CodeMessage._211, status: Resourses.Enums.StatusEnum.Failed);
                    userInfo.Data.Roles.Add(roleInfo.Data);
                }
            }
            if(request.Status != null)
            {
                userInfo.Data.Status = request.Status.GetValueOrDefault();
            }
            try
            {
                _userRepository.Update(userInfo.Data);
                await _unitOfWork.SaveChangeAsync();
                return GetBaseResult(CodeMessage._200, Mapper.Map<UserResponse>(userInfo.Data));
            }
            catch (Exception ex)
            {
                return GetBaseResult<UserResponse>(CodeMessage._99, status: Resourses.Enums.StatusEnum.Failed,message:ex.Message);
            }


        }

        #endregion

        #region PrivateWork
        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtConfig.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("Id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(JwtConfig.AccessTokenExpiration),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        #endregion

    }
}
