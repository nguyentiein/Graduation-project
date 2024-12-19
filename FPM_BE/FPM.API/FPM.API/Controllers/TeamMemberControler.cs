using FPM.IServices;
using FPM.Resourses;
using FPM.Resourses.DTOs.TeamMember.Request;
using FPM.Resourses.DTOs.Test.Request;
using FPM.Services;
using FPM.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FPM.API.Controllers
{

    [Route("api/v1/teamMember")]
    [ApiController]
    public class TeamMemberControler : ParentController
    {
        private readonly ITeamMemeberService _teamMemberService;    
        public TeamMemberControler(ITeamMemeberService testService, IOptionsMonitor<ResponseMessage> responseMessage, IMapper mapper) : base(responseMessage, mapper)
        {
            this._teamMemberService = testService;
        }
       
        [HttpPost("Create")]
        public async Task<IActionResult> CreateNewTeamMemberAsync(CreateTeamMerberRequest request)
        {
            var response = await _teamMemberService.CreateNewTeamMemberAsync(request);
            return Ok(response);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetTeamMemberById(int id)
        {
            var reponse = await _teamMemberService.GetTeamMemberByTeamId(id);
            return Ok(reponse);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteTeamMemAsync(int id)
        {
            var response = await _teamMemberService.DeleteAsync(id);
            return Ok(response);
        }


        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateTestAsync(int id, UpdateTeamMerberRequest request)
        {
            request.Id = id;
            var response = await _teamMemberService.UpdateTeamMemberAsync(request);
            return Ok(response);
        }
    }
}

