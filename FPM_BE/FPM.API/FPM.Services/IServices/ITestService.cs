using FPM.Core.Entities;
using FPM.Resourses.DTOs.Test.Request;
using FPM.Resourses.DTOs.Test.Response;
using FPM.Resourses.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.IServices
{
    public interface ITestService
    {
        Task<BaseResult<TestResponse>> CreateNewTestAsync(CreateTestRequest request);
        Task<BaseResult<IEnumerable<TestResponse>>> GetAlltestAsync();
        Task<BaseResult<TestResponse>> UpdateTestAsync(UpdateTestRequest request);

        Task<BaseResult<TestResponse>> DeleteAsync(int id);

    }
}
