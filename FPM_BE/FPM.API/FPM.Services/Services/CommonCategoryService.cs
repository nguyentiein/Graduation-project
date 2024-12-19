using AutoMapper;
using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using FPM.Repositories.IRepository;
using FPM.Resourses;
using FPM.Resourses.DTOs.CommonCategory.Request;
using FPM.Resourses.DTOs.CommonCategory.Response;
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
    public class CommonCategoryService : BaseService, ICommonCategoryService
    {
        #region Property
        private readonly ICommonCategoryRepository _commonCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        #endregion
        public CommonCategoryService(ICommonCategoryRepository commonCategoryRepository,
                                     IUnitOfWork unitOfWork,
                                     IMapper mapper, IOptionsMonitor<ResponseMessage> responseMessage) : base(mapper, responseMessage)
        {
            _commonCategoryRepository = commonCategoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResult<CommonCategoryResponse>> CreateCommonCategoryAsync(CreateCommonCategoryRequest request)
        {
            var commonCategory = Mapper.Map<Commoncategory>(request);
            try
            {
                await _commonCategoryRepository.InsertAsync(commonCategory);
                await _unitOfWork.SaveChangeAsync();

                return GetBaseResult(CodeMessage._200, Mapper.Map<CommonCategoryResponse>(commonCategory));

            }
            catch (Exception ex) {
                return GetBaseResult<CommonCategoryResponse>(CodeMessage._99, status: Resourses.Enums.StatusEnum.Failed);
            }


        }

        public async Task<BaseResult<CommonCategoryResponse>> DeleteCommonCateAsync(int id)
        {
            var commonCate = await _commonCategoryRepository.FindAsync(id);

            if(!commonCate.HasData) return GetBaseResult<CommonCategoryResponse>(CodeMessage._212, status: StatusEnum.Failed);

            commonCate.Data.IsDeleted = true;

            _commonCategoryRepository.Update(commonCate.Data);
            await _unitOfWork.SaveChangeAsync();

            return GetBaseResult<CommonCategoryResponse>(CodeMessage._200, status: StatusEnum.Success);
        }

        public async Task<BaseResult<IEnumerable<CommonCategoryResponse>>> GetCommonCateByType(SearchCommonCategoryModel request)
        {
            var result = await _commonCategoryRepository.GetCommoncategoriesByTypeAsync(request);
            if (result.hasData)
            {
                return GetBaseResult(CodeMessage._200, Mapper.Map<IEnumerable<CommonCategoryResponse>>(result.data));
            }
            else
                return GetBaseResult<IEnumerable<CommonCategoryResponse>>(CodeMessage._211, status: Resourses.Enums.StatusEnum.Failed); 
        }

        public async Task<BaseResult<CommonCategoryResponse>> UpdateCommonCateAsync(UpdateCommonCategoryRequest request)
        {
            var commoncate = await _commonCategoryRepository.FindAsync(request.Id);

            if(!commoncate.HasData) return GetBaseResult<CommonCategoryResponse>(CodeMessage._212, status: StatusEnum.Failed);

            Mapper.Map<UpdateCommonCategoryRequest, Commoncategory>(request, commoncate.Data);

            _commonCategoryRepository.Update(commoncate.Data);
            await _unitOfWork.SaveChangeAsync();

            return GetBaseResult(CodeMessage._200, Mapper.Map<CommonCategoryResponse>(commoncate.Data));

        }
    }
}
