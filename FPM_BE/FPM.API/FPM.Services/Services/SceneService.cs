using AutoMapper;
using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using FPM.Repositories.IRepository;
using FPM.Resourses;
using FPM.Resourses.DTOs.Scene.Request;
using FPM.Resourses.DTOs.Scene.Response;
using FPM.Resourses.DTOs.SceneExpense.Request;
using FPM.Resourses.DTOs.SceneExpense.Response;
using FPM.Resourses.DTOs.Video.Response;
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
    public class SceneService : BaseService, ISceneService
    {
        #region Property
        private readonly ISceneRepository _sceneRepository;
        private readonly ISceneExpenseRepository _sceneExpenseRepository;
        private readonly IVideoRepository _videoRepository;
        private readonly IPreproducitonSegmentRepository _preproducitonSegmentRepository;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Contructor
        public SceneService(ISceneRepository sceneRepository,
                            ISceneExpenseRepository sceneExpenseRepository,
                            IVideoRepository videoRepository,
                            IPreproducitonSegmentRepository preproducitonSegmentRepository,
                            IUnitOfWork unitOfWork,
                            IMapper mapper, IOptionsMonitor<ResponseMessage> responseMessage) : base(mapper, responseMessage)
        {
            this._sceneRepository = sceneRepository;
            this._sceneExpenseRepository = sceneExpenseRepository;
            this._videoRepository = videoRepository;
            this._preproducitonSegmentRepository = preproducitonSegmentRepository;
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Method
        public async Task<BaseResult<SceneResponse>> CreateAsync(AddSceneRequest request)
        {
            var segmentInfo = await _preproducitonSegmentRepository.FindAsync(request.PreproductionSegmentId);
            if(!segmentInfo.HasData) return GetBaseResult<SceneResponse>(CodeMessage._223,status: Resourses.Enums.StatusEnum.Failed);

            var scene = Mapper.Map<Scene>(request);

            scene.PreproductionId = segmentInfo.Data.PreProductionId;

            try
            {
                await _sceneRepository.InsertAsync(scene);
                await _unitOfWork.SaveChangeAsync();

                return GetBaseResult(CodeMessage._200, Mapper.Map<SceneResponse>(scene));
            }
            catch (Exception ex)
            {
                return GetBaseResult<SceneResponse>(CodeMessage._99, status: Resourses.Enums.StatusEnum.Failed);
            }
            
        }

        public async Task<BaseResult<SceneExpenseResponse>> CreateSceneExpenseAsync(CreateSceneExpenseRequest request)
        {
            var sceneInfo = await _sceneRepository.FindAsync(request.SceneId);
            if (!sceneInfo.HasData) return GetBaseResult<SceneExpenseResponse>(CodeMessage._211,status: StatusEnum.Failed);

            var sceneExpense = Mapper.Map<SceneExpense>(request);

            await _sceneExpenseRepository.InsertAsync(sceneExpense);
            await _unitOfWork.SaveChangeAsync();

            return GetBaseResult(CodeMessage._200, Mapper.Map<SceneExpenseResponse>(sceneExpense));
        }

        public async Task<BaseResult<IEnumerable<SceneExpenseResponse>>> GetAllSceneExpenseBySceneIdAsync(int sceneId)
        {
            var result = await _sceneExpenseRepository.GetAllSceneExpenseBySceneIdAsync(sceneId);

            return GetBaseResult(CodeMessage._200, Mapper.Map<IEnumerable<SceneExpenseResponse>>(result.Data));
        }

        public async Task<BaseResult<IEnumerable<SceneResponse>>> GetAllSceneInSegmentAsync(int segmentId)
        {
            var result = await _sceneRepository.GetAllSceneInSegmentAsync(segmentId);

            return GetBaseResult(CodeMessage._200,Mapper.Map<IEnumerable<SceneResponse>>(result.Data));
        }

        public async Task<BaseResult<SceneResponse>> GetByIdAsync(int sceneId, VideoTypeEnum videoType)
        {
            var sceneInfo = await _sceneRepository.FindAsync(sceneId);
            
            if(!sceneInfo.HasData) return GetBaseResult<SceneResponse>(CodeMessage._211,status: StatusEnum.Failed);

            var result = Mapper.Map<SceneResponse>(sceneInfo.Data);

            var listVideo = await _videoRepository.SearchVideoAsync(sceneId, videoType);

            result.VideoResponses = Mapper.Map<IEnumerable<VideoResponse>>(listVideo.Data);

            return GetBaseResult(CodeMessage._200, result);

        }

        public async Task<BaseResult<SceneExpenseResponse>> RemoveSceneExpenseAsync(int sceneExpenseId)
        {
            var sceneExpenseInfo = await _sceneExpenseRepository.FindAsync(sceneExpenseId);
            if (!sceneExpenseInfo.HasData) return GetBaseResult<SceneExpenseResponse>(CodeMessage._211, status: StatusEnum.Failed);
            _sceneExpenseRepository.Delete(sceneExpenseInfo.Data);
            await _unitOfWork.SaveChangeAsync();

            return GetBaseResult<SceneExpenseResponse>(CodeMessage._200, status: StatusEnum.Success);
        }

        public async Task<BaseResult<SceneResponse>> UpdateSceneAsync(UpdateSceneRequest request)
        {
            var sceneInfo = await _sceneRepository.FindAsync(request.Id);
            if (!sceneInfo.HasData) return GetBaseResult<SceneResponse>(CodeMessage._211, status: StatusEnum.Failed);

            Mapper.Map<UpdateSceneRequest, Scene>(request, sceneInfo.Data);

            _sceneRepository.Update(sceneInfo.Data);
            await _unitOfWork.SaveChangeAsync();

            return GetBaseResult(CodeMessage._200, Mapper.Map<SceneResponse>(sceneInfo.Data));
            

        }

        public async Task<BaseResult<SceneExpenseResponse>> UpdateSceneExpenseAsync(UpdateSceneExpenseRequest request)
        {
            var sceneExpenseInfo = await _sceneExpenseRepository.FindAsync(request.Id);
            
            if (!sceneExpenseInfo.HasData) return GetBaseResult<SceneExpenseResponse>(CodeMessage._211, status: StatusEnum.Failed);

            Mapper.Map<UpdateSceneExpenseRequest,SceneExpense>(request, sceneExpenseInfo.Data);

            _sceneExpenseRepository.Update(sceneExpenseInfo.Data);
            _unitOfWork.SaveChange();

            return GetBaseResult(CodeMessage._200, Mapper.Map<SceneExpenseResponse>(sceneExpenseInfo.Data));


        }


        #endregion
    }
}
