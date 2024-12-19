using FPM.Resourses.DTOs.PostproductionPlanning.Request;
using FPM.Resourses.DTOs.PostproductionPlanning.Response;
using FPM.Resourses.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.IServices
{
    public interface IPostproductionPlanService
    {
        Task<BaseResult<IEnumerable<PostproductionPlanResponse>>> GetAllPostproductionPlanAsync();

        Task<BaseResult<PostproductionPlanDetailResponse>> GetByIdAsync(int id);

        Task<BaseResult<PostproductionPlanDetailResponse>> UpdateAsync(UpdatePostproductionPlanRequest request);

        Task<BaseResult<IEnumerable<PostproductionPlanResponse>>> GetAllPostProductionAndBroadcastingAsync();
    }
}
