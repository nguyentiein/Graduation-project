using AutoMapper;
using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using FPM.Repositories.IRepository;
using FPM.Resourses;
using FPM.Resourses.DTOs.Video.Request;
using FPM.Resourses.DTOs.Video.Response;
using FPM.Resourses.Enums;
using FPM.Resourses.Results;
using FPM.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Services
{
    public class VideoService : BaseService, IVideoService
    {
        #region Property
        private readonly IVideoRepository _videoRepository;
        private readonly IFileService _fileService;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Contructor
        public VideoService(IVideoRepository videoRepository,
                            IUnitOfWork unitOfWork,
                            IFileService fileService,
                            IMapper mapper, IOptionsMonitor<ResponseMessage> responseMessage) : base(mapper, responseMessage)
        {
            this._videoRepository = videoRepository;
            this._fileService = fileService;
            this._unitOfWork = unitOfWork;
        }
        #endregion


        #region Method
        public async Task<BaseResult<VideoResponse>> AddVideoAsync(CreateVideoRequest request, string webRootPath)
        {
            var urlInfo = await _fileService.SaveVideoAsync(request.File,webRootPath);
            if (urlInfo.Data == null) return GetBaseResult<VideoResponse>(CodeMessage._99,status: StatusEnum.Failed,message: urlInfo.Message);

            var video = Mapper.Map<Video>(request);
            if(request.ObjectType == VideoTypeEnum.Scene)
            {
                var listVideo = await _videoRepository.SearchVideoAsync(request.ObjectId, request.ObjectType);
                video.No = listVideo.Data.Count() + 1;

            }


            video.VideoUrl = urlInfo.Data.FileUrl;
            video.VideoLength = GetVideoDuration(string.Concat(webRootPath,urlInfo.Data.FileLocation));
            video.VideoSize = request.File.Length / 1024m;
            video.UploadPart = urlInfo.Data;
            try
            {
                await _videoRepository.InsertAsync(video);
                await _unitOfWork.SaveChangeAsync();

                return GetBaseResult(CodeMessage._200, Mapper.Map<VideoResponse>(video));
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message, ex);
            }


            
        }

        public async Task<BaseResult<IEnumerable<VideoResponse>>> GetListVideoAsync(int objectId, VideoTypeEnum objectType)
        {
            var result = await _videoRepository.SearchVideoAsync(objectId, objectType);
            return GetBaseResult(CodeMessage._200, Mapper.Map<IEnumerable<VideoResponse>>(result.Data));
        }

        public async Task<BaseResult<object>> RemoveVideoAsync(int videoId,string webRootPath)
        {
            var video = await _videoRepository.GetByIdAsync(videoId);
            if (!video.HasData) return GetBaseResult<object>(CodeMessage._211, status: StatusEnum.Failed);
            try
            {
                var checkRemoveFile = _fileService.RemoveFile(video.Data.UploadPart, webRootPath);
                webRootPath = webRootPath.Substring(0, webRootPath.Length - 2)
                if (!checkRemoveFile.IsSuccess) return GetBaseResult<object>(CodeMessage._99, status: StatusEnum.Failed, message: checkRemoveFile.Message);

                _videoRepository.Delete(video.Data);
                await _unitOfWork.SaveChangeAsync();
                return GetBaseResult<object>(CodeMessage._200, status: StatusEnum.Success);
            }
            catch (Exception ex)
            {
                return GetBaseResult<object>(CodeMessage._99, status: StatusEnum.Failed);
            }


        }

        #endregion

        #region PrivateWork
        private decimal GetVideoDuration(string videoUrl)
        {
            var ffProbe = new NReco.VideoInfo.FFProbe();

            var videoInfo = ffProbe.GetMediaInfo(videoUrl);
            return (decimal)videoInfo.Duration.TotalSeconds;
        }
        #endregion
    }
}
