using AutoMapper;
using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using FPM.Repositories.IRepository;
using FPM.Repositories.Repository;
using FPM.Resourses;
using FPM.Resourses.DTOs.Approved.Reponse;
using FPM.Resourses.DTOs.Approved.Request;
using FPM.Resourses.DTOs.Team.Response;
using FPM.Resourses.DTOs.TeamMember.Reponse;
using FPM.Resourses.DTOs.Topic.Reponse;
using FPM.Resourses.DTOs.TopicMember.Reponse;
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
    public class ApprovedServices : BaseService, IApprovedServices
    {
        private readonly IApporvedReponsitory _IapprovedRespository;
        private readonly IPostproductionPlanRepository _postproductionPlanRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ApprovedServices(IApporvedReponsitory IapprovedRespository,IPostproductionPlanRepository postproductionPlanRepository, IUnitOfWork unitOfWork, IMapper mapper, IOptionsMonitor<ResponseMessage> responseMessage) : base(mapper, responseMessage)
        {
            _IapprovedRespository = IapprovedRespository;
            _postproductionPlanRepository = postproductionPlanRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResult<ApprovedsReponse>> CreateApprovedAsync(CreateApprovedRequest request)
        {
            try
            {
                var model = Mapper.Map<Approved>(request);
                if(request.ObjectType == ApproveObjectTypeEnum.preproductionPlan && request.Result == ApproveResultEnum.Accept)
                {
                    await _postproductionPlanRepository.InsertAsync(new PostproductionPlaning
                    {
                        PreProductionId = request.ObjectId,
                        Status = PostproductionStatusEnum.NotYet,
                    });
                }
                
                await _IapprovedRespository.InsertAsync(model);
                _unitOfWork.SaveChange();


                return GetBaseResult(CodeMessage._200, Mapper.Map<ApprovedsReponse>(model));
            }
            catch (Exception ex)
            {
                return GetBaseResult<ApprovedsReponse>(CodeMessage._209, status: StatusEnum.Failed);
            }
        }

        public async Task<BaseResult<IEnumerable<ApprovedsReponse>>> GetApprovedByObjectIdAsync(int id)
        {
            var result = await _IapprovedRespository.GetApprovedByObjectId(id);

            if (!result.HasData) return GetBaseResult<IEnumerable<ApprovedsReponse>>(CodeMessage._211, status: Resourses.Enums.StatusEnum.Failed);

            return GetBaseResult(CodeMessage._200, Mapper.Map<IEnumerable<ApprovedsReponse>>(result.Data));

        }

        public async  Task<BaseResult<IEnumerable<ApprovedsReponse>>> GetApprovedByObjectTypeAndObjectIdAsync(ApproveObjectTypeEnum typeId, int objectId)
        {
            var result = await _IapprovedRespository.GetApprovedByObjectTypeAndObjectId(typeId, objectId);

            if (!result.HasData) return GetBaseResult<IEnumerable<ApprovedsReponse>>(CodeMessage._211, status: Resourses.Enums.StatusEnum.Failed);

            return GetBaseResult(CodeMessage._200, Mapper.Map<IEnumerable<ApprovedsReponse>>(result.Data));
        }

        public  async Task<BaseResult<IEnumerable<ApprovedsReponse>>> GetApprovedByObjectTypeAsync(ApproveObjectTypeEnum id)
        {
            var result = await _IapprovedRespository.GetApprovedByObjectType(id);

            if (!result.HasData) return GetBaseResult<IEnumerable<ApprovedsReponse>>(CodeMessage._211, status: Resourses.Enums.StatusEnum.Failed);

            return GetBaseResult(CodeMessage._200, Mapper.Map<IEnumerable<ApprovedsReponse>>(result.Data));
        }

       
    }
}
