using AutoMapper;
using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using FPM.Repositories.IRepository;
using FPM.Resourses;
using FPM.Resourses.Enums;
using FPM.IServices;
using FPM.Resourses.Results;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FPM.Resourses.DTOs.Test.Request;
using FPM.Resourses.DTOs.Test.Response;

namespace FPM.Services
{
    public sealed class TestService : BaseService, ITestService
    {
        #region Property
        private readonly ITestRepository _testRepository;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public TestService(IUnitOfWork unitOfWork,
                           ITestRepository testRepository,
                           IMapper mapper,
                           IOptionsMonitor<ResponseMessage> responseMessage) : base(mapper, responseMessage)
        {
            this._testRepository = testRepository;
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Method
        public async Task<BaseResult<TestResponse>> CreateNewTestAsync(CreateTestRequest request)
        {
            try
            {
                var model = Mapper.Map<Test>(request);
                await _testRepository.InsertAsync(model);
                _unitOfWork.SaveChange();
                

                return GetBaseResult(CodeMessage._200, Mapper.Map<TestResponse>(model));
            }
            catch (Exception ex)
            {
                return GetBaseResult<TestResponse>(CodeMessage._209,status: StatusEnum.Failed);
            }
            
        }

        

        public async Task<BaseResult<IEnumerable<TestResponse>>> GetAlltestAsync()
        {
            var result = await _testRepository.GetAllAsync();
            if(result.Count == 0)
            {
                return GetBaseResult<IEnumerable<TestResponse>>(CodeMessage._212, status: StatusEnum.Failed);
            }

            return GetBaseResult(CodeMessage._200,Mapper.Map<IEnumerable<TestResponse>>(result));
        }

        public async Task<BaseResult<TestResponse>> UpdateTestAsync(UpdateTestRequest request)
        {
            try
            {
                //validate data
                var testModel = await _testRepository.FindAsync(request.Id);
                if (!testModel.HasData)
                {
                    return GetBaseResult<TestResponse>(CodeMessage._212, status: StatusEnum.Failed);
                }
                Mapper.Map<UpdateTestRequest, Test>(request, testModel.Data);

                _testRepository.Update(testModel.Data);
                await _unitOfWork.SaveChangeAsync();
                return GetBaseResult(CodeMessage._200,Mapper.Map<TestResponse>(testModel.Data));

            }
            catch
            {
                return GetBaseResult<TestResponse>(CodeMessage._239, status: StatusEnum.Failed);
            }
        }

        public async Task<BaseResult<TestResponse>> DeleteAsync(int id)
        {
            //validate data
            var testModel = await _testRepository.FindAsync(id);
            if (!testModel.HasData)
            {
                return GetBaseResult<TestResponse>(CodeMessage._212, status: StatusEnum.Failed);
            }
            testModel.Data.IsDeleted = true;

            _testRepository.Update(testModel.Data);
            await _unitOfWork.SaveChangeAsync();

            return GetBaseResult<TestResponse>(CodeMessage._200, status: StatusEnum.Success);
        }
        #endregion
    }
}
