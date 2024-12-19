using FPM.Core.Entities;
using FPM.Resourses;
using FPM.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using FPM.Resourses.DTOs.Test.Request;

namespace FPM.API.Controllers
{
    [Route("api/v1/test")]
    [ApiController]
    public class TestController : ParentController
    {
        #region Property
        private readonly ITestService _testService;
        #endregion

        #region Constructor
        public TestController(ITestService testService, IOptionsMonitor<ResponseMessage> responseMessage, IMapper mapper) : base(responseMessage, mapper)
        {
            this._testService = testService;
        }
        #endregion

        #region Method

        [HttpPost("Create")]
        public async Task<IActionResult> CreateTestAsync(CreateTestRequest request)
        {
            var response = await _testService.CreateNewTestAsync(request);
            return Ok(response);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _testService.GetAlltestAsync();
            return Ok(response);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateTestAsync(int id,UpdateTestRequest request)
        {
            request.Id = id;
            var response = await _testService.UpdateTestAsync(request);
            return Ok(response);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteTestAsync(int id)
        {
            var response = await _testService.DeleteAsync(id);
            return Ok(response);
        }

        #endregion
    }
}
