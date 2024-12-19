using AutoMapper;
using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using FPM.Repositories.IRepository;
using FPM.Repositories.Repository;
using FPM.Resourses;
using FPM.Resourses.DTOs.PreproductionPlaning.Reponse;
using FPM.Resourses.DTOs.PreproductionPlaning.Request;
using FPM.Resourses.DTOs.Team.Response;
using FPM.Resourses.DTOs.TeamMember.Reponse;
using FPM.Resourses.DTOs.TeamMember.Request;
using FPM.Resourses.Enums;
using FPM.Resourses.Results;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Services
{
    public class PreproductionPlaningServices : BaseService, IPreproductionPlaningServices
    {
        #region Property
        private readonly IPreproductionPlaningReponsitory _preproductionplaningcRepository;
        private readonly IPreproductionMemberRepository _preproductionmemberRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Contructor
        public PreproductionPlaningServices(IPreproductionPlaningReponsitory preproductionplaningcRepository,
                                            IPreproductionMemberRepository preproductionMemberRepository,
                                            IUserRepository userRepository,
                                            IUnitOfWork unitOfWork, IMapper mapper, IOptionsMonitor<ResponseMessage> responseMessage) : base(mapper, responseMessage)
        {
            _preproductionplaningcRepository = preproductionplaningcRepository;
            _preproductionmemberRepository = preproductionMemberRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResult<PreproductionMemberResponse>> AddMemberInPreproductionPlan(CreatePreproductionMemberRequest request)
        {
            var member = Mapper.Map<PreproductionMember>(request);
            await _preproductionmemberRepository.InsertAsync(member);
            await _unitOfWork.SaveChangeAsync();

            return GetBaseResult(CodeMessage._200, Mapper.Map<PreproductionMemberResponse>(member));
        }

        #endregion

        #region Method

        public async Task<BaseResult<PreproductionPlaningReponse>> CreatePreproductionPlaningAsync(CreatePreproductionPlaningRequest request)
        {
            try
            {
                var model = Mapper.Map<PreproductionPlaning>(request);
                await _preproductionplaningcRepository.InsertAsync(model);
                _unitOfWork.SaveChange();


                return GetBaseResult(CodeMessage._200, Mapper.Map<PreproductionPlaningReponse>(model));
            }
            catch (Exception ex)
            {
                return GetBaseResult<PreproductionPlaningReponse>(CodeMessage._209, status: StatusEnum.Failed);
            }
        }

        public async Task<BaseResult<PreproductionPlaningReponse>> DeleteAsync(int id)
        {
            //validate data
            var testModel = await _preproductionplaningcRepository.FindAsync(id);
            if (!testModel.HasData)
            {
                return GetBaseResult<PreproductionPlaningReponse>(CodeMessage._212, status: StatusEnum.Failed);
            }
             testModel.Data.IsDeleted = true;

            _preproductionplaningcRepository.Update(testModel.Data);
            await _unitOfWork.SaveChangeAsync();

            return GetBaseResult<PreproductionPlaningReponse>(CodeMessage._200, status: StatusEnum.Success);
        }

        //public async Task<BaseResult<IEnumerable<PreproductionMemberResponse>>> GetListPreproductionMembersAsync()
        //{
        //    var result = await _preproductionmemberRepository.getListMember();
        //    if (!result.HasData)
        //        return GetBaseResult<IEnumerable<PreproductionMemberResponse>>(CodeMessage._211, status: StatusEnum.Failed);
        //    return GetBaseResult(CodeMessage._200, Mapper.Map<IEnumerable<PreproductionMemberResponse>>(result.Data));
        //}


        public async Task<BaseResult<IEnumerable<PreproductionMemberResponse>>> GetPreproductionMemberByIdAsync(int preproductionId)
        {
            var result = await _preproductionmemberRepository.GetAllMemberInPreproductionAsync(preproductionId);

            if(!result.HasData) return GetBaseResult<IEnumerable<PreproductionMemberResponse>>(CodeMessage._211, status: StatusEnum.Failed);

            return GetBaseResult(CodeMessage._200, Mapper.Map<IEnumerable<PreproductionMemberResponse>>(result.Data));
        }

        public async Task<BaseResult<IEnumerable<PreproductionPlaningReponse>>> GetPreproductionPlaning()
        {
            var result = await _preproductionplaningcRepository.GetPreproductionPlaning();

            if (!result.HasData) return GetBaseResult<IEnumerable<PreproductionPlaningReponse>>(CodeMessage._211, status: Resourses.Enums.StatusEnum.Failed);

            return GetBaseResult(CodeMessage._200, Mapper.Map<IEnumerable<PreproductionPlaningReponse>>(result.Data));
        }

        public async Task<BaseResult<PreproductionPlaningReponse>> GetPreproductionPlaningAsyncByid(int id)
        {
            var result = await _preproductionplaningcRepository.GetPreproductionPlaningAsyncByid(id);
            if (!result.HasData)
            {
                return GetBaseResult<PreproductionPlaningReponse>(CodeMessage._212, status: StatusEnum.Failed);
            }

            return GetBaseResult(CodeMessage._200, Mapper.Map<PreproductionPlaningReponse>(result.Data));
        }

        public async Task<BaseResult<List<ViewReport>>> GetReportFeeAsync()
        {
            var reports = await _preproductionplaningcRepository.GetReportInfoAsync();

            foreach(var item in reports)
            {
                if(item.CreateBy != null)
                {
                    var user = await _userRepository.FindAsync((int)item.CreateBy);

                    await Task.CompletedTask;
                    item.Director = string.Concat(user.Data.LastName, " ", user.Data.FirstName);
                }
            }
           

            return GetBaseResult(CodeMessage._200, reports);

        }

        public async Task<BaseResult<object>> RemoveMemberAsync(int memberId)
        {
            var member = await _preproductionmemberRepository.FindAsync(memberId);

            if(!member.HasData) return GetBaseResult<object>(CodeMessage._211, status: StatusEnum.Failed);

            _preproductionmemberRepository.Delete(member.Data);
            _unitOfWork.SaveChange();
            return GetBaseResult<object>(CodeMessage._200,status: StatusEnum.Success);
        }

        public async Task<BaseResult<PreproductionMemberResponse>> UpdateMemberInfoAsync(UpdatePreproductionMemberRequest request)
        {
            var member = await _preproductionmemberRepository.FindAsync(request.Id);

            if (!member.HasData) GetBaseResult<PreproductionMemberResponse>(CodeMessage._211, status: StatusEnum.Failed);

            Mapper.Map<UpdatePreproductionMemberRequest, PreproductionMember>(request, member.Data);

            try
            {
                _preproductionmemberRepository.Update(member.Data);
                _unitOfWork.SaveChange();
                return GetBaseResult<PreproductionMemberResponse>(CodeMessage._200, Mapper.Map<PreproductionMemberResponse>(member.Data));
            }
            catch (Exception ex)
            {
                return GetBaseResult<PreproductionMemberResponse>(CodeMessage._99, Mapper.Map<PreproductionMemberResponse>(member.Data));
            }
            

        }

        public async Task<BaseResult<PreproductionMemberResponse>> UpdateMemberWorkingHourAsync(int memberId, decimal workingHour)
        {
            var memberInfo = await _preproductionmemberRepository.FindAsync(memberId);

            if(!memberInfo.HasData) return GetBaseResult<PreproductionMemberResponse>(CodeMessage._211,status: StatusEnum.Failed);

            memberInfo.Data.TotalWorkingHour = workingHour;

            memberInfo.Data.TotalSalary = GetSumSalary(memberInfo.Data.Salary,memberInfo.Data.SalaryType,workingHour);

            _preproductionmemberRepository.Update(memberInfo.Data);
            _unitOfWork.SaveChange();

            return GetBaseResult(CodeMessage._200, Mapper.Map<PreproductionMemberResponse>(memberInfo.Data));

        }

        public async Task<BaseResult<PreproductionPlaningReponse>> UpdatePreproductionPlaningAsync(UpdatePreproductionPlaningRequest request)
        {
            try
            {
                //validate data
                var testModel = await _preproductionplaningcRepository.FindAsync(request.Id);
                if (!testModel.HasData)
                {
                    return GetBaseResult<PreproductionPlaningReponse>(CodeMessage._212, status: StatusEnum.Failed);
                }
                Mapper.Map<UpdatePreproductionPlaningRequest, PreproductionPlaning>(request, testModel.Data);

                _preproductionplaningcRepository.Update(testModel.Data);
                await _unitOfWork.SaveChangeAsync();
                return GetBaseResult(CodeMessage._200, Mapper.Map<PreproductionPlaningReponse>(testModel.Data));

            }
            catch
            {
                return GetBaseResult<PreproductionPlaningReponse>(CodeMessage._239, status: StatusEnum.Failed);
            }
        }

        #endregion


        #region PrivateWork
        private decimal GetSumSalary(decimal salary, SalaryTypeEnum type, decimal workingHour)
        {
            decimal sumSalary = 0;

            switch (type)
            {
                case SalaryTypeEnum.Hour:
                    sumSalary = salary * workingHour;
                    break;

                case SalaryTypeEnum.Day:
                    sumSalary = (salary / 24) * workingHour;
                    break;

                case SalaryTypeEnum.Month:
                    sumSalary = (salary / (24 * 30)) * workingHour;
                    break;

                case SalaryTypeEnum.Week:
                    sumSalary = (salary / (24 * 7)) * workingHour;
                    break;
            }
            return sumSalary;
        }

        private decimal GetSceneFee(List<SceneExpense> listSceneExpense)
        {
            decimal total = 0;
            foreach (var expense in listSceneExpense)
            {
                total += expense.Amount.GetValueOrDefault();
            }
            return total;
        }

        private decimal GetHumanFee(IEnumerable<PreproductionMember> listMember)
        {
            decimal total = 0;

            foreach (var member in listMember)
            {
                total += member.TotalSalary;
            }

            return total;
        }
        #endregion
    }
}
