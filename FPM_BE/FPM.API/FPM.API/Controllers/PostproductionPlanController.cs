using FPM.Resourses;
using FPM.Resourses.DTOs.PostproductionPlanning.Request;
using FPM.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Microsoft.Extensions.Options;

namespace FPM.API.Controllers
{
    [Route("api/v1/postProduction")]
    [ApiController]
    public class PostproductionPlanController : ParentController
    {
        private readonly IPostproductionPlanService _postproductionPlanService;
        public PostproductionPlanController(IPostproductionPlanService postproductionPlanService,
                                            IOptionsMonitor<ResponseMessage> responseMessage, IMapper mapper) : base(responseMessage, mapper)
        {
            _postproductionPlanService = postproductionPlanService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _postproductionPlanService.GetAllPostproductionPlanAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var response = await _postproductionPlanService.GetByIdAsync(id);
            return Ok(response);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, UpdatePostproductionPlanRequest request)
        {
            request.Id = id;
            var response = await _postproductionPlanService.UpdateAsync(request);
            return Ok(response);
        }

        [HttpGet("getAllWithBroadcasting")]
        public async Task<IActionResult> GetAllPostproductionAndBroadcastingAsync()
        {
            var response = await _postproductionPlanService.GetAllPostProductionAndBroadcastingAsync();
            return Ok(response);
        }


    }
}
