using AutoMapper;
using FPM.Repositories.IRepository;
using FPM.Resourses;
using FPM.Resourses.DTOs.User.Response;
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
    public class RoleService : BaseService, IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository, IMapper mapper, IOptionsMonitor<ResponseMessage> responseMessage) : base(mapper, responseMessage)
        {
            _roleRepository = roleRepository;
        }

        public async Task<BaseResult<IEnumerable<RoleResponse>>> GetAllRoleAsync()
        {
            var listRole = await _roleRepository.GetAllAsync();
            return GetBaseResult(CodeMessage._200,Mapper.Map<IEnumerable<RoleResponse>>(listRole));
        }
    }
}
