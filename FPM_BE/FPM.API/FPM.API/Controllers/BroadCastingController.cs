using FPM.API.Authorization;
using FPM.Core.Entities;
using FPM.Resourses;
using FPM.Resourses.DTOs.Broadcasting.Request;
using FPM.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FPM.API.Controllers
{
    [Route("api/v1/broadcasting")]
    [ApiController]
    public class BroadCastingController : ParentController
    {
        private readonly IBroadcastingService _broadcastingService;
        private readonly IHostEnvironment _hostEnvironment;

        public BroadCastingController(IBroadcastingService broadcastingService,
                                      IHostEnvironment hostEnvironment,
                                      IOptionsMonitor<ResponseMessage> responseMessage, IMapper mapper) : base(responseMessage, mapper)
        {
            _broadcastingService = broadcastingService;
            _hostEnvironment = hostEnvironment;
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateBroadcastingRequest request)
        {
            var response = await _broadcastingService.CreateAsync(request);
            return Ok(response);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody]UpdateBroadcastingRequest request)
        {
            request.Id = id;
            var response = await _broadcastingService.UpdateAsync(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await _broadcastingService.DeleteAsync(id);
            return Ok(response);
        }

        [HttpPost("uploadDocument")]
        [Authorize]
        public async Task<IActionResult> UploadDocumentAsync([FromForm]UploadBroadcastingDocumentRequest request)
        {
            var user = (User)HttpContext.Items["User"];
            var response = await _broadcastingService.UploadDocumentAsync(user.Id, request, _hostEnvironment.ContentRootPath);
            return Ok(response);
        }
        //[HttpPatch("updateDocument/{id}")]
        //public async Task<IActionResult> UpdateDocumentAsync(int id, [FromQuery]Update)
        //{

        //}

        [HttpGet("GetAllDocument/{broadcastingId}")]
        public async Task<IActionResult> GetAllDocumentAsync(int broadcastingId)
        {
            var response = await _broadcastingService.GetAllDocumentAsync(broadcastingId);
            return Ok(response);
        }

    }
}
