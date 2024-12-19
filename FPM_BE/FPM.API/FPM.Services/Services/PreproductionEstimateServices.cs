using AutoMapper;
using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using FPM.Repositories.IRepository;
using FPM.Repositories.Repository;
using FPM.Resourses;
using FPM.Resourses.DTOs.PreproductionExpense.Reponse;
using FPM.Resourses.DTOs.PreproductionExpense.Request;
using FPM.Resourses.DTOs.PreproductionPlaning.Reponse;
using FPM.Resourses.DTOs.Segment.Request;
using FPM.Resourses.DTOs.Segment.Response;
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
    public class PreproductionEstimateServices : BaseService, IPreproductionEstimateServices
    {
        private readonly IPreproductionEstimateReponsitory _preproductionEstimateReponsitory;
        private readonly ICommonCategoryRepository _commonCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PreproductionEstimateServices( IUnitOfWork unitOfWork,IPreproductionEstimateReponsitory preproductionEstimateReponsitory,
            ICommonCategoryRepository commonCategoryRepository, IMapper mapper, IOptionsMonitor<ResponseMessage> responseMessage) : base(mapper, responseMessage)
        {
            this._unitOfWork = unitOfWork;
            this._commonCategoryRepository = commonCategoryRepository;
            this._preproductionEstimateReponsitory = preproductionEstimateReponsitory;

        }

        public async Task<BaseResult<PreproductionEstimateResponse>> CreatePreproductionExpenseAsync(CreatePreproductionEstimateRequest request)
        {
            try
            {
                var model = Mapper.Map<PreproductionEstimate>(request);
                await _preproductionEstimateReponsitory.InsertAsync(model);
                await _unitOfWork.SaveChangeAsync();
                return GetBaseResult(CodeMessage._200, Mapper.Map<PreproductionEstimateResponse>(model));
            }
            catch (Exception ex)
            {
                return GetBaseResult<PreproductionEstimateResponse>(CodeMessage._209, status: StatusEnum.Failed,message:ex.Message);
            }
        }

        public async Task<BaseResult<PreproductionEstimateResponse>> DeleteAsync(int id)
        {
            var segment = await _preproductionEstimateReponsitory.FindAsync(id);
            if (!segment.HasData) return GetBaseResult<PreproductionEstimateResponse>(CodeMessage._212, status: Resourses.Enums.StatusEnum.Failed);

         //   segment.Data.IsDeleted = true;
            try
            {
                _preproductionEstimateReponsitory.Update(segment.Data);

                _unitOfWork.SaveChange();

                return GetBaseResult<PreproductionEstimateResponse>(CodeMessage._200, status: Resourses.Enums.StatusEnum.Success);
            }
            catch (Exception ex)
            {
                return GetBaseResult<PreproductionEstimateResponse>(CodeMessage._99, status: Resourses.Enums.StatusEnum.Failed);
            }
        }

        public async Task<BaseResult<IEnumerable<PreproductionEstimateResponse>>> GetAllPreproductionExpenseBySegIdAsync(int segId)
        {
            var result = await _preproductionEstimateReponsitory.GetAllPreproductionExpenseBySegIdAsync(segId);

            if (!result.HasData) return GetBaseResult<IEnumerable<PreproductionEstimateResponse>>(CodeMessage._211, status: StatusEnum.Failed);

            
            var response = Mapper.Map<IEnumerable<PreproductionEstimateResponse>>(result.Data);
            

            return GetBaseResult(CodeMessage._200, response);

        }

        public async Task<BaseResult<PreproductionEstimateResponse>> UpdatePreproductionExpenseAsync(UpdatePreproductionEstimateRequest request)
        {
            var segment = await _preproductionEstimateReponsitory.FindAsync(request.Id);
            if (!segment.HasData) return GetBaseResult<PreproductionEstimateResponse>(CodeMessage._212, status: Resourses.Enums.StatusEnum.Failed);

            Mapper.Map<UpdatePreproductionEstimateRequest, PreproductionEstimate>(request, segment.Data);

            try
            {
                _preproductionEstimateReponsitory.Update(segment.Data);

                _unitOfWork.SaveChange();

                return GetBaseResult(CodeMessage._200, Mapper.Map<PreproductionEstimateResponse>(segment.Data));
            }
            catch (Exception ex)
            {
                return GetBaseResult<PreproductionEstimateResponse>(CodeMessage._99, status: Resourses.Enums.StatusEnum.Failed);
            }
        }
    }
}
