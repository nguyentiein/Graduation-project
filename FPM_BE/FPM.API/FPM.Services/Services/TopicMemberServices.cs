using AutoMapper;
using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using FPM.Repositories.IRepository;
using FPM.Repositories.Repository;
using FPM.Resourses;
using FPM.Resourses.DTOs.TeamMember.Reponse;
using FPM.Resourses.DTOs.TeamMember.Request;
using FPM.Resourses.DTOs.TopicMember.Reponse;
using FPM.Resourses.DTOs.TopicMember.Request;
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
    public class TopicMemberServices : BaseService, ITopicMemberService
    {
        private readonly ITopicMemberReponsitory _topicMemberRespository;
        private readonly IUnitOfWork _unitOfWork;
        public TopicMemberServices(IUnitOfWork unitOfWork, ITopicMemberReponsitory topicMemberRespository,IMapper mapper, IOptionsMonitor<ResponseMessage> responseMessage) : base(mapper, responseMessage)
        {
            _topicMemberRespository = topicMemberRespository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResult<TopicMemberResponse>> CreateNewTopicMemberAsync(CreateTopicMemberRequest request)
        {
            try
            {
                var model = Mapper.Map<TopicMember>(request);
                await _topicMemberRespository.InsertAsync(model);
                _unitOfWork.SaveChange();


                return GetBaseResult(CodeMessage._200, Mapper.Map<TopicMemberResponse>(model));
            }
            catch (Exception ex)
            {
                return GetBaseResult<TopicMemberResponse>(CodeMessage._209, status: StatusEnum.Failed);
            }
        }

        public async Task<BaseResult<TopicMemberResponse>> DeleteAsync(int id)
        {
            //validate data
            var testModel = await _topicMemberRespository.FindAsync(id);
            if (!testModel.HasData)
            {
                return GetBaseResult<TopicMemberResponse>(CodeMessage._212, status: StatusEnum.Failed);
            }
            //   testModel.Data.IsDeleted = true;

            _topicMemberRespository.Update(testModel.Data);
            await _unitOfWork.SaveChangeAsync();

            return GetBaseResult<TopicMemberResponse>(CodeMessage._200, status: StatusEnum.Success);
        }

        public async Task<BaseResult<IEnumerable<TopicMemberResponse>>> GetTopicMemberByTopicId(int id)
        {
            var result = await _topicMemberRespository.GetTopicMemberById(id);

            if (!result.HasData) return GetBaseResult<IEnumerable<TopicMemberResponse>>(CodeMessage._211, status: Resourses.Enums.StatusEnum.Failed);

            return GetBaseResult(CodeMessage._200, Mapper.Map<IEnumerable<TopicMemberResponse>>(result.Data));
        }
    }
}
