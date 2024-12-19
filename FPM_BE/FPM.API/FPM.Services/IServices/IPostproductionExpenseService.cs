using FPM.Resourses.DTOs.PostproductionExpense.Request;
using FPM.Resourses.DTOs.PostproductionExpense.Response;
using FPM.Resourses.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.IServices
{
    public interface IPostproductionExpenseService
    {
        Task<BaseResult<PostproductionExpenseResponse>> CreateAsync(CreatePostproductionExpenseRequest request);

        Task<BaseResult<PostproductionExpenseResponse>> UpdateAsync(UpdatePostproductionExpenseRequest request);
        Task<BaseResult<object>> DeleteAsync(int id);
    }
}
