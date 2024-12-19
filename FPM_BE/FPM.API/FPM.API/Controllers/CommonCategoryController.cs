using FPM.Resourses;
using FPM.Resourses.DTOs.CommonCategory.Request;
using FPM.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FPM.API.Controllers
{
    [Route("api/v1/commonCategory")]
    [ApiController]
    public class CommonCategoryController : ParentController
    {
        private readonly ICommonCategoryService _commonCategoryService;
        public CommonCategoryController(ICommonCategoryService commonCategoryService,
            IOptionsMonitor<ResponseMessage> responseMessage, IMapper mapper) : base(responseMessage, mapper)
        {
            _commonCategoryService = commonCategoryService;
        }

        [HttpGet("GetCommonCateByType")]
        public async Task<IActionResult> GetCommonCateByTypeAsync(int type, int? parentId) {
            var request = new SearchCommonCategoryModel { Type = type, ParentId = parentId };
            var result = await _commonCategoryService.GetCommonCateByType(request);
            return Ok(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> PostAsync(CreateCommonCategoryRequest request)
        {
            var result = await _commonCategoryService.CreateCommonCategoryAsync(request);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id,UpdateCommonCategoryRequest request)
        {
            request.Id = id;
            var result = await _commonCategoryService.UpdateCommonCateAsync(request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _commonCategoryService.DeleteCommonCateAsync(id);

            return Ok(result);
        }

    }
}
