using AutoMapper;
using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using FPM.Repositories.IRepository;
using FPM.Repositories.Repository;
using FPM.Resourses;
using FPM.Resourses.DTOs.Estimate.Reponse;
using FPM.Resourses.DTOs.Estimate.Request;
using FPM.Resourses.DTOs.PreproductionPlaning.Reponse;
using FPM.Resourses.DTOs.PreproductionPlaning.Request;
using FPM.Resourses.Enums;
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
    public class EstimateService : BaseService, IEtimateServices
    {
        public readonly IEstimateReponsitory _estimateReponsitory;
        public readonly IUnitOfWork _unitOfWork;
        public EstimateService(IEstimateReponsitory estimateReponsitory,IUnitOfWork unitOfWork, IMapper mapper, IOptionsMonitor<ResponseMessage> responseMessage) : base(mapper, responseMessage)
        {
            _estimateReponsitory = estimateReponsitory;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResult<EstimateResponse>> CreateEstimateAsync(CreateEstimateRequest request)
        {
            try
            {
                var model = Mapper.Map<Estimate>(request);
                await _estimateReponsitory.InsertAsync(model);
                _unitOfWork.SaveChange();


                return GetBaseResult(CodeMessage._200, Mapper.Map<EstimateResponse>(model));
            }
            catch (Exception ex)
            {
                return GetBaseResult<EstimateResponse>(CodeMessage._209, status: StatusEnum.Failed);
            }
        }

        public async Task<BaseResult<EstimateResponse>> DeleteEstimateAsync(int id)
        {
            //validate data
            var testModel = await _estimateReponsitory.FindAsync(id);
            if (!testModel.HasData)
            {
                return GetBaseResult<EstimateResponse>(CodeMessage._212, status: StatusEnum.Failed);
            }
          //  testModel.Data.IsDeleted = true;

            _estimateReponsitory.Update(testModel.Data);
            await _unitOfWork.SaveChangeAsync();

            return GetBaseResult<EstimateResponse>(CodeMessage._200, status: StatusEnum.Success);
        }

        public async Task<BaseResult<IEnumerable<EstimateResponse>>> GetEstimateAsync()
        {
            var result = await _estimateReponsitory.GetEstimate();

            if (!result.HasData) return GetBaseResult<IEnumerable<EstimateResponse>>(CodeMessage._211, status: Resourses.Enums.StatusEnum.Failed);

            return GetBaseResult(CodeMessage._200, Mapper.Map<IEnumerable<EstimateResponse>>(result.Data));
        }

        public async Task<BaseResult<IEnumerable<EstimateResponse>>> GetEstimateAsyncByid(int id)
        {
            var result = await _estimateReponsitory.GetEstimateAsyncByid(id);
            if (!result.HasData)
            {
                return GetBaseResult<IEnumerable<EstimateResponse>>(CodeMessage._212, status: StatusEnum.Failed);
            }

            return GetBaseResult(CodeMessage._200, Mapper.Map<IEnumerable<EstimateResponse>>(result.Data));
        }

        public async Task<BaseResult<IEnumerable<EstimateResponse>>> GetEstimateAsyncByPreproductionid(int preId)
        {
            var result = await _estimateReponsitory.GetEstimateAsyncByPreproductionid(preId);
            if (!result.HasData)
            {
                return GetBaseResult<IEnumerable<EstimateResponse>>(CodeMessage._212, status: StatusEnum.Failed);
            }

            return GetBaseResult(CodeMessage._200, Mapper.Map<IEnumerable<EstimateResponse>>(result.Data));

        }

        public async Task<BaseResult<IEnumerable<EstimateResponse>>> GetEstimateAsyncBySegid(int preId)
        {
            var result = await _estimateReponsitory.GetEstimateAsyncBySegidasync(preId);
            if (!result.HasData)
            {
                return GetBaseResult<IEnumerable<EstimateResponse>>(CodeMessage._212, status: StatusEnum.Failed);
            }

            return GetBaseResult(CodeMessage._200, Mapper.Map<IEnumerable<EstimateResponse>>(result.Data));
        }

        public async Task<BaseResult<EstimateResponse>> UpdateEstimateAsync(UpdateEstimateRequest request)
        {
            try
            {
                //validate data
                var testModel = await _estimateReponsitory.FindAsync(request.Id);
                if (!testModel.HasData)
                {
                    return GetBaseResult<EstimateResponse>(CodeMessage._212, status: StatusEnum.Failed);
                }
                Mapper.Map<UpdateEstimateRequest, Estimate>(request, testModel.Data);

                _estimateReponsitory.Update(testModel.Data);
                await _unitOfWork.SaveChangeAsync();
                return GetBaseResult(CodeMessage._200, Mapper.Map<EstimateResponse>(testModel.Data));

            }
            catch
            {
                return GetBaseResult<EstimateResponse>(CodeMessage._239, status: StatusEnum.Failed);
            }
        }
    }
}
