using FPM.Core.Entities;
using FPM.Resourses.DTOs.PreproductionPlaning.Reponse;
using FPM.Resourses.DTOs.PreproductionPlaning.Request;
using FPM.Resourses.DTOs.Team.Response;
using FPM.Resourses.DTOs.TeamMember.Reponse;
using FPM.Resourses.DTOs.TeamMember.Request;
using FPM.Resourses.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services
{
    public interface IPreproductionPlaningServices
    {
       
        Task<BaseResult<IEnumerable<PreproductionPlaningReponse>>> GetPreproductionPlaning();
        Task<BaseResult<PreproductionPlaningReponse>> CreatePreproductionPlaningAsync(CreatePreproductionPlaningRequest request);
        Task<BaseResult<PreproductionPlaningReponse>> UpdatePreproductionPlaningAsync(UpdatePreproductionPlaningRequest request);
        Task<BaseResult<PreproductionPlaningReponse>> DeleteAsync(int id);
        Task<BaseResult<PreproductionPlaningReponse>> GetPreproductionPlaningAsyncByid(int id);

        Task<BaseResult<List<ViewReport>>> GetReportFeeAsync();

        Task<BaseResult<IEnumerable<PreproductionMemberResponse>>> GetPreproductionMemberByIdAsync(int preproductionId);

        Task<BaseResult<PreproductionMemberResponse>> AddMemberInPreproductionPlan(CreatePreproductionMemberRequest request);

        Task<BaseResult<PreproductionMemberResponse>> UpdateMemberInfoAsync(UpdatePreproductionMemberRequest request);
        Task<BaseResult<PreproductionMemberResponse>> UpdateMemberWorkingHourAsync(int memberId, decimal workingHour);

        Task<BaseResult<object>> RemoveMemberAsync(int memberId);

    }

}
