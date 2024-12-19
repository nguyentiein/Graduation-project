using FPM.Core.Entities;
using FPM.Resourses.DTOs.Scene.Request;
using FPM.Resourses.DTOs.Scene.Response;
using FPM.Resourses.DTOs.SceneExpense.Request;
using FPM.Resourses.DTOs.SceneExpense.Response;
using FPM.Resourses.Enums;
using FPM.Resourses.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.IServices
{
    public interface ISceneService
    {
        Task<BaseResult<SceneResponse>> CreateAsync(AddSceneRequest request);

        Task<BaseResult<IEnumerable<SceneResponse>>> GetAllSceneInSegmentAsync(int SegmentId);

        Task<BaseResult<SceneResponse>> GetByIdAsync(int sceneId, VideoTypeEnum videoType);

        Task<BaseResult<SceneResponse>> UpdateSceneAsync(UpdateSceneRequest request);

        Task<BaseResult<IEnumerable<SceneExpenseResponse>>> GetAllSceneExpenseBySceneIdAsync(int sceneId);

        Task<BaseResult<SceneExpenseResponse>> CreateSceneExpenseAsync(CreateSceneExpenseRequest request);

        Task<BaseResult<SceneExpenseResponse>> UpdateSceneExpenseAsync(UpdateSceneExpenseRequest request);

        Task<BaseResult<SceneExpenseResponse>> RemoveSceneExpenseAsync(int sceneExpenseId);
    }
}
