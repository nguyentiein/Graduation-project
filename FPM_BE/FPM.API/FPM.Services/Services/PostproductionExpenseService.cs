using AutoMapper;
using FPM.Resourses;
using FPM.Resourses.DTOs.PostproductionExpense.Request;
using FPM.Resourses.DTOs.PostproductionExpense.Response;
using FPM.Resourses.Results;
using FPM.Services.IServices;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Services
{
    public class PostproductionExpenseService : BaseService, IPostproductionExpenseService
    {
        public PostproductionExpenseService(IMapper mapper, IOptionsMonitor<ResponseMessage> responseMessage) : base(mapper, responseMessage)
        {
        }

        public Task<BaseResult<PostproductionExpenseResponse>> CreateAsync(CreatePostproductionExpenseRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult<object>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult<PostproductionExpenseResponse>> UpdateAsync(UpdatePostproductionExpenseRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
