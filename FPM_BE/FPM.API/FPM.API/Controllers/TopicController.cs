using FPM.API.Authorization;
using FPM.Core.Entities;
using FPM.Resourses;
using FPM.Resourses.DTOs.CommonCategory.Request;
using FPM.Resourses.DTOs.TeamMember.Request;
using FPM.Resourses.DTOs.Teams.Request;
using FPM.Resourses.DTOs.Topic.Request;
using FPM.Services.IServices;
using FPM.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FPM.API.Controllers
{
    [Route("api/v1/topic")]
    [ApiController]
    public class TopicController : ParentController
    {

        private readonly ITopicServices _topicService;

        public TopicController(ITopicServices topicService, IOptionsMonitor<ResponseMessage> responseMessage, IMapper mapper) : base(responseMessage, mapper)
        {
            this._topicService = topicService;
        }

        [HttpGet("GetTopicByType")]
        public async Task<IActionResult> GetTopicByTypeAsync(int type, int? parentId)
        {
            var request = new SearchTopicRequest { Type = type, ParentId = parentId };
            var result = await _topicService.GetTopicByTypeAsync(request);
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateTopicAsync(CreateTopicRequest request)
        {

            var user = (User)HttpContext.Items["User"];
            var response = await _topicService.CreateNewTopicAsync(user.Id, request);
            return Ok(response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteTopicAsync(int id)
        {
            var response = await _topicService.DeleteAsync(id);
            return Ok(response);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateTopicAsync(int id, UpdateTopicRequest updateRequest)
        {
            updateRequest.Id = id;
            var response = await _topicService.UpdateTopicAsync(updateRequest);
            return Ok(response);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetTopicByIdAsync(int id)
        {
            var reponse = await _topicService.GetTopicByIdAsync(id);
            return Ok(reponse);
        }

    }
}
