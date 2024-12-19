using FPM.Resourses;
using FPM.Resourses.DTOs.PreproductionPlaning.Request;
using FPM.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FPM.API.Controllers
{
    [Route("api/v1/preproductionplaning")]
    [ApiController]
    public class PreproductionPlaning : ParentController
    {
        #region Property
        private readonly IPreproductionPlaningServices _preproductionPlaningServices;
        #endregion

        #region Contructor
        public PreproductionPlaning(IPreproductionPlaningServices preproductionPlaningServices,IOptionsMonitor<ResponseMessage> responseMessage, IMapper mapper) : base(responseMessage, mapper)
        {
            _preproductionPlaningServices= preproductionPlaningServices;
        }
        #endregion

        #region Method

        [HttpGet]
        public async Task<IActionResult> GetPreproductionPlaningAsync()
        {
            var reponse = await _preproductionPlaningServices.GetPreproductionPlaning();
            return Ok(reponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPreproductionPlaningAsyncByid(int id)
        {
            var reponse = await _preproductionPlaningServices.GetPreproductionPlaningAsyncByid(id);
            return Ok(reponse);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePreproductionPlaningAsync(CreatePreproductionPlaningRequest request )
        {
            var reponse = await _preproductionPlaningServices.CreatePreproductionPlaningAsync(request);
            return Ok(reponse);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePreproductionPlaningAsync( int id,UpdatePreproductionPlaningRequest request)
        {
            request.Id = id;
            var reponse = await _preproductionPlaningServices.UpdatePreproductionPlaningAsync(request);
            return Ok(reponse);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePreproductionPlaningAsync(int id)
        {
            var response = await _preproductionPlaningServices.DeleteAsync(id);
            return Ok(response);
        }

        [HttpGet("GetAllMember/{preproductionPlanId}")]
        public async Task<ActionResult> GetAllMemberAsync(int preproductionPlanId)
        {
            var response = await _preproductionPlaningServices.GetPreproductionMemberByIdAsync(preproductionPlanId);
            return Ok(response);
        }

        //[HttpGet("GetListMember")]
        //public async Task<ActionResult> GetListMemberAsync()
        //{
        //    var response = await _preproductionPlaningServices.GetListPreproductionMembersAsync();
        //    return Ok(response);
        //}

        [HttpPost("AddMember")]
        public async Task<IActionResult> AddMemberAsync(CreatePreproductionMemberRequest request)
        {
            var response = await _preproductionPlaningServices.AddMemberInPreproductionPlan(request);
            return Ok(response);
        }

        [HttpPut("UpdateMemberInfo/{memberId}")]
        public async Task<IActionResult> UpdateMemberInfoAsync(int memberId,UpdatePreproductionMemberRequest request)
        {
            request.Id=memberId;
            var response = await _preproductionPlaningServices.UpdateMemberInfoAsync(request);
            return Ok(response);
        }
        
        

        [HttpDelete("RemoveMember/{memberId}")]
        public async Task<IActionResult> RemoveMemberAsync(int memberId) 
        {
            var response =await _preproductionPlaningServices.RemoveMemberAsync(memberId);
            return Ok(response);
        }

        [HttpGet("getReport")]
        public async Task<IActionResult> GetReportFeeAsync()
        {
            var response = await _preproductionPlaningServices.GetReportFeeAsync();
            return Ok(response);
        }
        #endregion
    }
}
