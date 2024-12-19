using FPM.Repositories.Infrastructure;
using FPM.Resourses;
using FPM.Resourses.DTOs.Estimate.Request;
using FPM.Resourses.DTOs.PreproductionPlaning.Request;
using FPM.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FPM.API.Controllers
{
    [Route("api/v1/estimate")]
    [ApiController]
    public class EtimateController : ParentController
    {
        public readonly IEtimateServices _etimateServices;

        public EtimateController(IEtimateServices etimateServices, IOptionsMonitor<ResponseMessage> responseMessage, IMapper mapper) : base(responseMessage, mapper)
        {
            _etimateServices = etimateServices;

        }
        [HttpGet("by-id/{id}")]
        public async Task<IActionResult> GetEstimateAsyncByid(int id)
        {
            var response = await _etimateServices.GetEstimateAsyncByid(id);
            return Ok(response);
        }

        [HttpGet("by-segid/{segId}")]
        public async Task<IActionResult> GetEstimateAsyncBySegid(int segId)
        {
            var response = await _etimateServices.GetEstimateAsyncBySegid(segId);
            return Ok(response);
        }

        [HttpGet("by-preid/{preId}")]
        public async Task<IActionResult> GetEstimateAsyncByPreproductionid(int preId)
        {
            var response = await _etimateServices.GetEstimateAsyncByPreproductionid(preId);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEstimateAsync(CreateEstimateRequest request)
        {
            var reponse = await _etimateServices.CreateEstimateAsync(request);
            return Ok(reponse);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateEstimateAsync(int id, UpdateEstimateRequest request)
        {
            request.Id = id;
            var reponse = await _etimateServices.UpdateEstimateAsync(request);
            return Ok(reponse);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstimateAsync(int id)
        {
            var response = await _etimateServices.DeleteEstimateAsync(id);
            return Ok(response);
        }
    }

}