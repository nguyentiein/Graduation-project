using FPM.Resourses.DTOs.Video.Request;
using FPM.Resourses.DTOs.Video.Response;
using FPM.Resourses.Enums;
using FPM.Resourses.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.IServices
{
    public interface IVideoService
    {
        Task<BaseResult<VideoResponse>> AddVideoAsync(CreateVideoRequest request,string webRootPath);

        Task<BaseResult<IEnumerable<VideoResponse>>> GetListVideoAsync(int objectId, VideoTypeEnum objectType);
        Task<BaseResult<object>> RemoveVideoAsync(int videoId,string webRootPath);
    }
}
