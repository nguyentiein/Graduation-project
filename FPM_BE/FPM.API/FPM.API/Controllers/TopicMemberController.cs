using FPM.Resourses;
using FPM.Resourses.DTOs.TeamMember.Request;
using FPM.Resourses.DTOs.Topic.Request;
using FPM.Resourses.DTOs.TopicMember.Request;
using FPM.Services.IServices;
using FPM.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FPM.API.Controllers
{
    [Route("api/v1/topic-member")]
    [ApiController]
    public class TopicMemberController : ParentController
    {
        private readonly ITopicMemberService _topicMemberService;
        public TopicMemberController(ITopicMemberService topicMemberService, IOptionsMonitor<ResponseMessage> responseMessage, IMapper mapper) : base(responseMessage, mapper)
        {
            _topicMemberService = topicMemberService;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateNewTeamMemberAsync(CreateTopicMemberRequest request)
        {
            var response = await _topicMemberService.CreateNewTopicMemberAsync(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeamMemberById(int id)
        {
            var reponse = await _topicMemberService.GetTopicMemberByTopicId(id);
            return Ok(reponse);
        }
        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> DeleteTeamMemAsync(int id)
        {
            var response = await _topicMemberService.DeleteAsync(id);
            return Ok(response);
        }

    }
}
