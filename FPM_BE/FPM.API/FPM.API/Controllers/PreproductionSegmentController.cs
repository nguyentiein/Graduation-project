using FPM.Resourses;
using FPM.Resourses.DTOs.Segment.Request;
using FPM.Services.IServices;
using FPM.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FPM.API.Controllers
{
    [Route("api/v1/preproductionSegment")]
    [ApiController]
    public class PreproductionSegmentController : ParentController
    {
        private readonly IPreproductionSegmentService _preproductionSegmentService;
        public PreproductionSegmentController(IPreproductionSegmentService preproductionSegmentService,
            IOptionsMonitor<ResponseMessage> responseMessage, IMapper mapper) : base(responseMessage, mapper)
        {
            this._preproductionSegmentService = preproductionSegmentService;
        }

        [HttpGet("GetByPreproduction/{PreproductionId}")]
        public async Task<ActionResult> GetAllSegmentInPreproduction(int PreproductionId)
        {
            var response = await _preproductionSegmentService.GetAllAsync(PreproductionId);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetAllSegmentInPreproductionByIdSeg(int id)
        {
            var response = await _preproductionSegmentService.GetAllSegmentInPreproductionByIdSeg(id);

            return Ok(response);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateSegmentAsync(CreateSegmentRequest request)
        {
            var response = await _preproductionSegmentService.CreateAsync(request);
            return Ok(response);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateSegmentAsync(int id,UpdateSegmentRequest request)
        {
            request.Id = id;
            var response = await _preproductionSegmentService.UpdateAsync(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await _preproductionSegmentService.DeleteAsync(id);
            return Ok(response);
        }
        [HttpPost("AddMember")]
        public async Task<IActionResult> AddMemberAsync(CreateSegmentMemberRequest request)
        {
            var response = await _preproductionSegmentService.AddMemberAsync(request);
            return Ok(response);
        }
        [HttpPut("UpdateMemberInfo/{id}")]
        public async Task<IActionResult> UpdateMember(int id, UpdateSegmentMemberRequest request)
        {
            request.Id = id;
            var response = await _preproductionSegmentService.UpdateMemberAsync(request);
            return Ok(response);
        }
        [HttpDelete("RemoveMember/{id}")]
        public async Task<IActionResult> RemoveMemberAsync(int id)
        {
            var response = await _preproductionSegmentService.RemoveMemberAsync(id);

            return Ok(response);
        }
        [HttpPost("sendMailReminder")]
        public async Task<IActionResult> sendMailReminder(SendRemindRequest remindRequest)
        {
            var response = await _preproductionSegmentService.SendMailReminderAsync(remindRequest);
            return Ok(response);
        }
    }
}
