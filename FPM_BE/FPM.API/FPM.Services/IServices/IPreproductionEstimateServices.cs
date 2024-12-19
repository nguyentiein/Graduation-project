using FPM.Core.Entities;
using FPM.Resourses.DTOs.PreproductionExpense.Reponse;
using FPM.Resourses.DTOs.PreproductionExpense.Request;
using FPM.Resourses.DTOs.PreproductionPlaning.Reponse;
using FPM.Resourses.DTOs.PreproductionPlaning.Request;
using FPM.Resourses.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.IServices
{
    public  interface IPreproductionEstimateServices
    {
        Task<BaseResult<IEnumerable<PreproductionEstimateResponse>>> GetAllPreproductionExpenseBySegIdAsync(int segId);

        Task<BaseResult<PreproductionEstimateResponse>> CreatePreproductionExpenseAsync(CreatePreproductionEstimateRequest request);
        Task<BaseResult<PreproductionEstimateResponse>> UpdatePreproductionExpenseAsync(UpdatePreproductionEstimateRequest request);
        Task<BaseResult<PreproductionEstimateResponse>> DeleteAsync(int id);
        //   Task<(bool HasData, IEnumerable<PreproductionExpense> Data)> GetAllPreproductionExpenseBySegIdAsync(int id);
        // Task<(bool HasData, IEnumerable<PreproductionExpense> Data)> GetAllTeamAsync();
    }
}
