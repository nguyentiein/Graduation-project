using AutoMapper;
using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using FPM.Repositories.IRepository;
using FPM.Repositories.Repository;
using FPM.Resourses;
using FPM.Resourses.DTOs.Team.Request;
using FPM.Resourses.DTOs.Team.Response;
using FPM.Resourses.DTOs.Teams.Request;
using FPM.Resourses.DTOs.Test.Request;
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
    public class TeamService : BaseService, ITeamService
    {
        #region Property
        private readonly ITeamRespository _teamRepository;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public TeamService(IUnitOfWork unitOfWork,
                               ITeamRespository testRepository,
                               IMapper mapper,
                               IOptionsMonitor<ResponseMessage> responseMessage) : base(mapper, responseMessage)
        {
            this._teamRepository = testRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<BaseResult<TeamResponse>> CreateNewTeamAsync(CreateTeamRequest request)
        {
            try
            {
                var model = Mapper.Map<Team>(request);
                await _teamRepository.InsertAsync(model);
                _unitOfWork.SaveChange();


                return GetBaseResult(CodeMessage._200, Mapper.Map<TeamResponse>(model));
            }
            catch (Exception ex)
            {
                return GetBaseResult<TeamResponse>(CodeMessage._209, status: StatusEnum.Failed);
            }
        }


        public async Task<BaseResult<TeamResponse>> DeleteAsync(int id)
        {
            var testModel = await _teamRepository.FindAsync(id);
        
            if (!testModel.HasData)
            {
                return GetBaseResult<TeamResponse>(CodeMessage._212, status: StatusEnum.Failed);
            }
            testModel.Data.IsDeleted = true;
            _teamRepository.Update(testModel.Data);
            await _unitOfWork.SaveChangeAsync();

            return GetBaseResult<TeamResponse>(CodeMessage._200, status: StatusEnum.Success);
        }

        public async Task<BaseResult<IEnumerable<TeamResponse>>> GetAllTeamDetailByIdAsync(int id)
        {
            var result = await _teamRepository.GetAllTeamDetailByIdAsync(id);
            if (!result.HasData)
            {
                return GetBaseResult<IEnumerable<TeamResponse>>(CodeMessage._212, status: StatusEnum.Failed);
            }

            return GetBaseResult(CodeMessage._200, Mapper.Map<IEnumerable<TeamResponse>>(result.Data));

        }


        #endregion
        #region method
        public async Task<BaseResult<IEnumerable<TeamResponse>>> GetAllTeamUserAsync()
        {
            var result = await _teamRepository.GetAllTeamAsync();
            if (!result.HasData)
            {
                return GetBaseResult<IEnumerable<TeamResponse>>(CodeMessage._212, status: StatusEnum.Failed);
            }

            return GetBaseResult(CodeMessage._200, Mapper.Map<IEnumerable<TeamResponse>>(result.Data));
        }
        #endregion
        public async Task<BaseResult<TeamResponse>> UpdateTeamAsync(UpdateTeamRequest request)
        {
            try
            {
                //validate data
                var testModel = await _teamRepository.FindAsync(request.Id);
                if (!testModel.HasData)
                {
                    return GetBaseResult<TeamResponse>(CodeMessage._212, status: StatusEnum.Failed);
                }
                Mapper.Map<UpdateTeamRequest, Team>(request, testModel.Data);

                _teamRepository.Update(testModel.Data);
                await _unitOfWork.SaveChangeAsync();
                return GetBaseResult(CodeMessage._200, Mapper.Map<TeamResponse>(testModel.Data));

            }
            catch
            {
                return GetBaseResult<TeamResponse>(CodeMessage._239, status: StatusEnum.Failed);
            }
        }

    }
}

