using FPM.Resourses;
using FPM.Resourses.DTOs.Team.Request;
using FPM.Resourses.DTOs.Teams.Request;
using FPM.Resourses.DTOs.Test.Request;
using FPM.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FPM.API.Controllers
{
    [Route("api/v1/team")]
    [ApiController]
    public class TeamController : ParentController
    {
        private readonly ITeamService _teamservice;
        public TeamController(ITeamService teamService, IOptionsMonitor<ResponseMessage> responseMessage, IMapper mapper) : base(responseMessage, mapper)
        {
            this._teamservice = teamService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTeamDetailAsync()
        {
            var reponse = await _teamservice.GetAllTeamUserAsync();
            return Ok(reponse);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetAllTeamDetailByIdAsync(int id)
        {
            var reponse = await _teamservice.GetAllTeamDetailByIdAsync(id);
            return Ok(reponse);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeamAsync(CreateTeamRequest createRequest)
        {
            var response = await _teamservice.CreateNewTeamAsync(createRequest);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeamAsync(int id, UpdateTeamRequest updateRequest)
        {
            updateRequest.Id = id;
            var response = await _teamservice.UpdateTeamAsync(updateRequest);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestAsync(int id)
        {
            var response = await _teamservice.DeleteAsync(id);
            return Ok(response);
        }

    }
}
