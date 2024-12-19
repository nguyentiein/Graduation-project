using FPM.Resourses;
using FPM.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FPM.API.Controllers
{
    [Route("api/v1/role")]
    [ApiController]
    public class RoleController : ParentController
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService, IOptionsMonitor<ResponseMessage> responseMessage, IMapper mapper) : base(responseMessage, mapper)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _roleService.GetAllRoleAsync();
            return Ok(response);
        }

    }
}
