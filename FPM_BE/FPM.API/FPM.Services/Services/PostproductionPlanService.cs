using AutoMapper;
using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using FPM.Repositories.IRepository;
using FPM.Resourses;
using FPM.Resourses.DTOs.PostproductionPlanning.Request;
using FPM.Resourses.DTOs.PostproductionPlanning.Response;
using FPM.Resourses.Results;
using FPM.Services.IServices;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Services
{
    public class PostproductionPlanService : BaseService, IPostproductionPlanService
    {
        private readonly IPostproductionPlanRepository _postproductionPlanRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISceneRepository _sceneRepository;
        private readonly ITopicRepository _topicRepository;
        private readonly IUnitOfWork _unitOfWork;
        public PostproductionPlanService(IPostproductionPlanRepository postproductionPlanRepository,
                                         IUserRepository userRepository,
                                         ITopicRepository topicRepository,
                                         ISceneRepository sceneRepository,
                                         IUnitOfWork unitOfWork, 
                                         IMapper mapper, IOptionsMonitor<ResponseMessage> responseMessage) : base(mapper, responseMessage)
        {
            this._postproductionPlanRepository = postproductionPlanRepository;
            this._userRepository = userRepository;
            this._sceneRepository = sceneRepository;
            this._topicRepository = topicRepository;
            this._unitOfWork = unitOfWork;
        }

        

        public async Task<BaseResult<IEnumerable<PostproductionPlanResponse>>> GetAllPostproductionPlanAsync()
        {
            var result = await _postproductionPlanRepository.GetAllPostProductionPlanAsync();

            var response = Mapper.Map<IEnumerable<PostproductionPlanResponse>>(result.Data);
            foreach(var item in response)
            {
                var userInfo = await _userRepository.FindAsync(item.CreateBy);
                Task.CompletedTask.Wait();
                if (userInfo.HasData)
                {
                    item.DirectorName = string.Concat(userInfo.Data.LastName, " ", userInfo.Data.FirstName);
                }
            }



            return GetBaseResult(CodeMessage._200, response);
        }

        public async Task<BaseResult<PostproductionPlanDetailResponse>> GetByIdAsync(int id)
        {
            var result = await _postproductionPlanRepository.GetByIdAsync(id);

            if (!result.HasData) return GetBaseResult<PostproductionPlanDetailResponse>(CodeMessage._211, status: Resourses.Enums.StatusEnum.Failed);

           

            var response = Mapper.Map<PostproductionPlanDetailResponse>(result.Data);

            //lấy chi phí script
            int topicId = result.Data.PreProduction.TopicId == null ? 0 : result.Data.PreProduction.TopicId.GetValueOrDefault();

            var topic = await _topicRepository.FindAsync(topicId);
            if (topic.HasData)
            {
                response.ScriptFee = topic.Data.Budget;
            }
            

            //lấy chi phi nhân lực
            response.HumanFee = GetHumanFee(result.Data.PreProduction.PreproductionMembers);

            var listScene = await _sceneRepository.GetAllSceneInPreproductionAsync((int)result.Data.PreProductionId);
            var listExpense = listScene.SelectMany(x => x.SceneExpenses).ToList();
            if(listScene.Count() > 0)
            {
                
                //chi phí edit
                response.EditorFee = GetSceneFee(listExpense.Where(x => x.Type == Resourses.Enums.SceneExpenseTypeEnum.Postproduction).ToList());

                //chi phí quay phim
                response.CameramanFee = GetSceneFee(listExpense.Where(x => x.Type == Resourses.Enums.SceneExpenseTypeEnum.Preproduction).ToList());
            }

            return GetBaseResult(CodeMessage._200, response);
        }

        public async Task<BaseResult<PostproductionPlanDetailResponse>> UpdateAsync(UpdatePostproductionPlanRequest request)
        {
            var postproductionPlanInfo = await _postproductionPlanRepository.FindAsync(request.Id);

            if (!postproductionPlanInfo.HasData) return GetBaseResult<PostproductionPlanDetailResponse>(CodeMessage._211, status: Resourses.Enums.StatusEnum.Failed);

            Mapper.Map<UpdatePostproductionPlanRequest, PostproductionPlaning>(request, postproductionPlanInfo.Data);
            _postproductionPlanRepository.Update(postproductionPlanInfo.Data);
            await _unitOfWork.SaveChangeAsync();
            return GetBaseResult(CodeMessage._200, Mapper.Map<PostproductionPlanDetailResponse>(postproductionPlanInfo.Data));

        }

        public async Task<BaseResult<IEnumerable<PostproductionPlanResponse>>> GetAllPostProductionAndBroadcastingAsync()
        {
            var listPostproduction = await _postproductionPlanRepository.GetAllPostproductionPlanAndBroadcastingAsync();
            return GetBaseResult(CodeMessage._200, Mapper.Map<IEnumerable<PostproductionPlanResponse>>(listPostproduction.Data));
        }

        #region PrivateWork
        private decimal GetHumanFee(IEnumerable<PreproductionMember>? listMember)
        {
            decimal total = 0;

            foreach (var member in listMember) 
            {
                total += member.TotalSalary;
            }

            return total;
        }

        

        private decimal GetSceneFee(List<SceneExpense>? listSceneExpense)
        {
            decimal total = 0;
            foreach (var expense in listSceneExpense)
            {
                total += expense.Amount.GetValueOrDefault();
            }
            return total;
        }

        #endregion
    }
}
