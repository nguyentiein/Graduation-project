using AutoMapper;
using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using FPM.Repositories.IRepository;
using FPM.Repositories.Repository;
using FPM.Resourses;
using FPM.Resourses.DTOs.Team.Response;
using FPM.Resourses.DTOs.TeamMember.Reponse;
using FPM.Resourses.DTOs.TeamMember.Request;
using FPM.Resourses.DTOs.Teams.Request;
using FPM.Resourses.DTOs.Test.Response;
using FPM.Resourses.DTOs.User.Response;
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
    public class TeamMemeberService : BaseService, ITeamMemeberService
    {
        private readonly ITeamMemberRespository _teamMemberRespository;
        private readonly IUnitOfWork _unitOfWork;
        public TeamMemeberService(ITeamMemberRespository teamMemberRespository, IUnitOfWork unitOfWork,IMapper mapper, IOptionsMonitor<ResponseMessage> responseMessage) : base(mapper, responseMessage)
        {
            this._teamMemberRespository = teamMemberRespository;    
            this._unitOfWork =unitOfWork;
        }

        public async Task<BaseResult<TeamMemberReponse>> CreateNewTeamMemberAsync(CreateTeamMerberRequest request)
        {
            try
            {
                var model = Mapper.Map<TeamMember>(request);
                await _teamMemberRespository.InsertAsync(model);
                _unitOfWork.SaveChange();


                return GetBaseResult(CodeMessage._200, Mapper.Map<TeamMemberReponse>(model));
            }
            catch (Exception ex)
            {
                return GetBaseResult<TeamMemberReponse>(CodeMessage._209, status: StatusEnum.Failed);
            }
        }

        public async Task<BaseResult<TeamMemberReponse>> DeleteAsync(int id)
        {
            //validate data
            var testModel = await _teamMemberRespository.FindAsync(id);
            if (!testModel.HasData)
            {
                return GetBaseResult<TeamMemberReponse>(CodeMessage._212, status: StatusEnum.Failed);
            }
             testModel.Data.IsDeleted = true;

            _teamMemberRespository.Update(testModel.Data);
            await _unitOfWork.SaveChangeAsync();

            return GetBaseResult<TeamMemberReponse>(CodeMessage._200, status: StatusEnum.Success);
        }

        public async Task<BaseResult<IEnumerable<TeamMemberReponse>>> GetTeamMemberByTeamId(int id)
        {
            var result = await _teamMemberRespository.GetTeamMemberByTeamId(id);

            if (!result.HasData) return GetBaseResult<IEnumerable<TeamMemberReponse>>(CodeMessage._211, status: Resourses.Enums.StatusEnum.Failed);

            return GetBaseResult(CodeMessage._200, Mapper.Map<IEnumerable<TeamMemberReponse>>(result.Data));

        }

        public async Task<BaseResult<TeamMemberReponse>> UpdateTeamMemberAsync(UpdateTeamMerberRequest request)
        {
            try
            {
                //validate data
                var testModel = await _teamMemberRespository.FindAsync(request.Id);
                if (!testModel.HasData)
                {
                    return GetBaseResult<TeamMemberReponse>(CodeMessage._212, status: StatusEnum.Failed);
                }
                Mapper.Map<UpdateTeamMerberRequest, TeamMember>(request, testModel.Data);

                _teamMemberRespository.Update(testModel.Data);
                await _unitOfWork.SaveChangeAsync();
                return GetBaseResult(CodeMessage._200, Mapper.Map<TeamMemberReponse>(testModel.Data));

            }
            catch
            {
                return GetBaseResult<TeamMemberReponse>(CodeMessage._239, status: StatusEnum.Failed);
            }
        }
    }
}
