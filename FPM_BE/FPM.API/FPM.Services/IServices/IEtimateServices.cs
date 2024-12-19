using FPM.Repositories.Repository;
using FPM.Resourses.DTOs.Estimate.Reponse;
using FPM.Resourses.DTOs.Estimate.Request;
using FPM.Resourses.DTOs.PreproductionPlaning.Reponse;
using FPM.Resourses.DTOs.Team.Response;
using FPM.Resourses.Results;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.IServices
{
    public interface IEtimateServices
    {
        Task<BaseResult<EstimateResponse>> CreateEstimateAsync(CreateEstimateRequest request);
        Task<BaseResult<EstimateResponse>>  DeleteEstimateAsync(int id);
        Task<BaseResult<IEnumerable<EstimateResponse>>> GetEstimateAsync();
        Task<BaseResult<IEnumerable<EstimateResponse>>> GetEstimateAsyncByid(int id);
        Task<BaseResult<IEnumerable<EstimateResponse>>> GetEstimateAsyncByPreproductionid(int preId);
        Task<BaseResult<IEnumerable<EstimateResponse>>> GetEstimateAsyncBySegid(int id);
        Task<BaseResult<EstimateResponse>> UpdateEstimateAsync(UpdateEstimateRequest request);
    }
}
