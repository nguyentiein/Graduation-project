using AutoMapper;
using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using FPM.Repositories.IRepository;
using FPM.Repositories.Repository;
using FPM.Resourses;
using FPM.Resourses.DTOs.Broadcasting.Request;
using FPM.Resourses.DTOs.Broadcasting.Response;
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
    public class BroadCastingService : BaseService, IBroadcastingService
    {
        private readonly IBroadcastingRepository _broadcastingRepository;
        private readonly IPostproductionPlanRepository _postproductionPlanRepository;
        private readonly IBroadcastingDocumentRepository _broadcastingDocumentRepository;
        private readonly IFileService _fileService;
        private readonly IUnitOfWork _unitOfWork;
        public BroadCastingService(IBroadcastingRepository broadcastingRepository,
                                   IPostproductionPlanRepository postproductionPlanRepository,
                                   IFileService fileService,
                                   IBroadcastingDocumentRepository broadcastingDocumentRepository,
                                   IUnitOfWork unitOfWork,
                                   IMapper mapper, IOptionsMonitor<ResponseMessage> responseMessage) : base(mapper, responseMessage)
        {
            _broadcastingRepository = broadcastingRepository;
            _postproductionPlanRepository = postproductionPlanRepository;
            _broadcastingDocumentRepository = broadcastingDocumentRepository;
            _fileService = fileService;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResult<BroadcastingResponse>> CreateAsync(CreateBroadcastingRequest request)
        {
            var postproductionInfo = await _postproductionPlanRepository.FindAsync(request.PostProductionPlaningId);

            if (postproductionInfo.HasData == false) return GetBaseResult<BroadcastingResponse>(CodeMessage._211, status: Resourses.Enums.StatusEnum.Failed);

            var broadcasting = Mapper.Map<Broadcasting>(request);

            try
            {
                await _broadcastingRepository.InsertAsync(broadcasting);
                await _unitOfWork.SaveChangeAsync();
                return GetBaseResult(CodeMessage._200, Mapper.Map<BroadcastingResponse>(broadcasting));
            }

            catch (Exception ex)
            {
                return GetBaseResult<BroadcastingResponse>(CodeMessage._99, status: Resourses.Enums.StatusEnum.Failed, message: ex.Message);
            }
        }

        

        public Task<BaseResult<BroadcastingResponse>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResult<BroadcastingResponse>> UpdateAsync(UpdateBroadcastingRequest request)
        {
            var broadcastingInfo = await _broadcastingRepository.FindAsync(request.Id);
            if (!broadcastingInfo.HasData) return GetBaseResult<BroadcastingResponse>(CodeMessage._211, status: Resourses.Enums.StatusEnum.Failed);

            Mapper.Map<UpdateBroadcastingRequest, Broadcasting>(request, broadcastingInfo.Data);

            try
            {
                _broadcastingRepository.Update(broadcastingInfo.Data);
                await _unitOfWork.SaveChangeAsync();
                return GetBaseResult(CodeMessage._200, Mapper.Map<BroadcastingResponse>(broadcastingInfo.Data));
            }
            catch (Exception ex)
            {
                return GetBaseResult<BroadcastingResponse>(CodeMessage._99, status: Resourses.Enums.StatusEnum.Failed, message: ex.Message);
            }

        }
        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var broadcastingInfo = await _broadcastingRepository.FindAsync(id);
            if (!broadcastingInfo.HasData) return GetBaseResult<object>(CodeMessage._211, status: Resourses.Enums.StatusEnum.Failed);

            try
            {
                broadcastingInfo.Data.IsDelete = true;
                _broadcastingRepository.Update(broadcastingInfo.Data);
                await _unitOfWork.SaveChangeAsync();
                return GetBaseResult<object>(CodeMessage._200,status: Resourses.Enums.StatusEnum.Success);
            }
            catch (Exception ex)
            {
                return GetBaseResult<object>(CodeMessage._99, status: Resourses.Enums.StatusEnum.Failed, message: ex.Message);
            }
        }

        public async Task<BaseResult<BroadcastingDocumentResponse>> UploadDocumentAsync(int userId, UploadBroadcastingDocumentRequest request,string webRootPath)
        {
            var broadcastingInfo = await _broadcastingRepository.FindAsync(request.BroadcastingId);
            if (!broadcastingInfo.HasData) return GetBaseResult<BroadcastingDocumentResponse>(CodeMessage._211, status: Resourses.Enums.StatusEnum.Failed);

            var file = await _fileService.UploadDocAsync(userId,request.File,webRootPath);

            if (file == null) return GetBaseResult<BroadcastingDocumentResponse>(CodeMessage._228, status: Resourses.Enums.StatusEnum.Failed);

            file.FileName = request.FileName;
            file.Description = request.Description;
            var broadcastingDocument = new Broadcastingdocument
            {
                BroadcastingId = broadcastingInfo.Data.Id,
                UploadPart = file
            };
            try
            {
                await _broadcastingDocumentRepository.InsertAsync(broadcastingDocument);
                await _unitOfWork.SaveChangeAsync();
                return GetBaseResult(CodeMessage._200, Mapper.Map<BroadcastingDocumentResponse>(broadcastingDocument));
            }
            catch (Exception ex)
            {
                return GetBaseResult<BroadcastingDocumentResponse>(CodeMessage._99, status: Resourses.Enums.StatusEnum.Failed);
            }
        }

        public async Task<BaseResult<IEnumerable<BroadcastingDocumentResponse>>> GetAllDocumentAsync(int broadcastingId)
        {
            var listDocument = await _broadcastingDocumentRepository.GetDocumentByBroadcastingIdAsync(broadcastingId);

            return GetBaseResult(CodeMessage._200,Mapper.Map<IEnumerable<BroadcastingDocumentResponse>>(listDocument.Data));

        }
    }
}
