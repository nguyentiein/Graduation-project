using FPM.Resourses;
using FPM.Resourses.DTOs.Approved.Request;
using FPM.Resourses.DTOs.TeamMember.Request;
using FPM.Resourses.Enums;
using FPM.Services.IServices;
using FPM.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FPM.API.Controllers
{

    [Route("api/v1")]
    [ApiController]
    public class ApprovedController : ParentController
    {
        private readonly IApprovedServices _approvedServices;
        public ApprovedController(IApprovedServices approvedServices,IOptionsMonitor<ResponseMessage> responseMessage, IMapper mapper) : base(responseMessage, mapper)
        {
            _approvedServices = approvedServices;
        }
        [HttpGet("by-object-type-and-object-id/{typeId}/{objectId}")]
        public async Task<IActionResult> GetApprovedByObjectTypeAndObjectIdAsync(ApproveObjectTypeEnum typeId, int objectId)
        {
            var response = await _approvedServices.GetApprovedByObjectTypeAndObjectIdAsync(typeId, objectId);
            return Ok(response);
        }


        [HttpGet("by-object-id/{id}")]

        public async Task<IActionResult> GetApprovedByObjectIdAsync(int id)
        {
            var reponse = await _approvedServices.GetApprovedByObjectIdAsync(id);
            return Ok(reponse);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateApprovedAsync(CreateApprovedRequest request)
        {
            var response = await _approvedServices.CreateApprovedAsync(request);
            return Ok(response);
        }
    }
}
