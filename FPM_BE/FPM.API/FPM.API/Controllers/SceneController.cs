using FPM.Resourses;
using FPM.Resourses.DTOs.Scene.Request;
using FPM.Resourses.DTOs.SceneExpense.Request;
using FPM.Resourses.Enums;
using FPM.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FPM.API.Controllers
{
    [Route("api/v1/scene")]
    [ApiController]
    public class SceneController : ParentController
    {
        private readonly ISceneService _sceneService;
        public SceneController(ISceneService sceneService, IOptionsMonitor<ResponseMessage> responseMessage, IMapper mapper) : base(responseMessage, mapper)
        {
            _sceneService = sceneService;
        }

        [HttpGet("getAllInSegment/{segmentId}")]
        public async Task<ActionResult> GetAllSceneInSegment(int segmentId)
        {
            var response = await _sceneService.GetAllSceneInSegmentAsync(segmentId);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSceneAsync(AddSceneRequest request)
        {
            var response = await _sceneService.CreateAsync(request);
            return Ok(response);
        }

        [HttpGet("{id}&&{videoType}")]
        public async Task<ActionResult> GetByIdAsync(int id,VideoTypeEnum videoType)
        {
            var response = await _sceneService.GetByIdAsync(id,videoType);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSceneAsync(int id, UpdateSceneRequest request)
        {
            request.Id = id;
            var response = await _sceneService.UpdateSceneAsync(request);
            return Ok(response);
        }

        [HttpGet("GetAllExpense/{sceneId}")]
        public async Task<ActionResult> GetAllExpenseAsync(int sceneId)
        {
            var reponse =  await _sceneService.GetAllSceneExpenseBySceneIdAsync(sceneId);
            return Ok(reponse);
        }


        [HttpPost("CreateExpense")]
        public async Task<IActionResult> CreateExpenseAsync(CreateSceneExpenseRequest request)
        {
            var response = await _sceneService.CreateSceneExpenseAsync(request);
            return Ok(response);

        }

        [HttpPut("UpdateSceneExpense/{sceneExpenseId}")]
        public async Task<IActionResult> UpdateExpenseAsync(int sceneExpenseId, UpdateSceneExpenseRequest request)
        {
            request.Id=sceneExpenseId;
            var response = await _sceneService.UpdateSceneExpenseAsync(request);
            return Ok(response);

        }

        [HttpDelete("RemoveSceneExpense/{sceneExpenseId}")]
        public async Task<IActionResult> DeleteSceneExpenseAsync(int sceneExpenseId)
        {
            var response = await _sceneService.RemoveSceneExpenseAsync(sceneExpenseId);

            return Ok(response);
        }

    }
}
