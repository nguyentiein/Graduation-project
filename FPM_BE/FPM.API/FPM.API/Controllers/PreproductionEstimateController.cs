using FPM.Resourses;
using FPM.Resourses.DTOs.Estimate.Request;
using FPM.Resourses.DTOs.PreproductionExpense.Request;
using FPM.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FPM.API.Controllers
{

    [Route("api/v1/preproductionestimate")]
    [ApiController]
    public class PreproductionEstimateController : ParentController
    {
        public readonly IPreproductionEstimateServices _preproductionEstimateServices;

        public PreproductionEstimateController(IPreproductionEstimateServices preproductionEstimateServices, IOptionsMonitor<ResponseMessage> responseMessage, IMapper mapper) : base(responseMessage, mapper)
        {
            _preproductionEstimateServices = preproductionEstimateServices;
        }
        [HttpGet("{segId}")]
        public async Task<IActionResult>  GetPreproductionExpenseBySegId(int segId) {

            var reponse = await _preproductionEstimateServices.GetAllPreproductionExpenseBySegIdAsync(segId);
            return Ok(reponse);
        
        }

        [HttpPost]
        public async Task<IActionResult> CreateEstimateAsync(CreatePreproductionEstimateRequest request)
        {
            var reponse = await _preproductionEstimateServices.CreatePreproductionExpenseAsync(request);
            return Ok(reponse);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateEstimateAsync(int id, UpdatePreproductionEstimateRequest request)
        {
            request.Id = id;
            var reponse = await _preproductionEstimateServices.UpdatePreproductionExpenseAsync(request);
            return Ok(reponse);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstimateAsync(int id)
        {
            var response = await _preproductionEstimateServices.DeleteAsync(id);
            return Ok(response);
        }
    }
}
