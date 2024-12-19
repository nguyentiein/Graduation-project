using FPM.Resourses.DTOs.CommonCategory.Request;
using FPM.Resourses.DTOs.CommonCategory.Response;
using FPM.Resourses.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.IServices
{
    public interface ICommonCategoryService
    {
        public Task<BaseResult<IEnumerable<CommonCategoryResponse>>> GetCommonCateByType(SearchCommonCategoryModel request);

        public Task<BaseResult<CommonCategoryResponse>> CreateCommonCategoryAsync(CreateCommonCategoryRequest request);

        public Task<BaseResult<CommonCategoryResponse>> UpdateCommonCateAsync(UpdateCommonCategoryRequest request);

        public Task<BaseResult<CommonCategoryResponse>> DeleteCommonCateAsync(int id);
    }
}
