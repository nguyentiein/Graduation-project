using FPM.API.Authorization;
using FPM.Resourses;
using FPM.Resourses.DTOs.User.Request;
using FPM.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FPM.API.Controllers
{
    [Route("api/v1/account")]
    public class AccountController : ParentController
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService,
            IOptionsMonitor<ResponseMessage> responseMessage, IMapper mapper) : base(responseMessage, mapper)
        {
            _accountService = accountService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest loginrequest)
        {
            var result = await _accountService.LoginAsync(loginrequest);
            return Ok(result);
        }

        [HttpPatch("UpdateAccount/{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateAccountAsync(int id,[FromBody] UpdateAccountRequest request)
        {
            request.UserId = id;
            var result = await _accountService.UpdateAccountAsync(request);
            return Ok(result);
        }

    }
}
