using FPM.Resourses.DTOs.Team.Request;
using FPM.Resourses.DTOs.Team.Response;
using FPM.Resourses.DTOs.TeamMember.Reponse;
using FPM.Resourses.DTOs.TeamMember.Request;
using FPM.Resourses.DTOs.Teams.Request;
using FPM.Resourses.DTOs.Test.Response;
using FPM.Resourses.DTOs.User.Response;
using FPM.Resourses.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.IServices
{
    public interface ITeamMemeberService
    {
        Task<BaseResult<TeamMemberReponse>> CreateNewTeamMemberAsync(CreateTeamMerberRequest request);
        Task<BaseResult<TeamMemberReponse>> DeleteAsync(int id);
        Task<BaseResult<IEnumerable<TeamMemberReponse>>> GetTeamMemberByTeamId(int id);
        Task<BaseResult<TeamMemberReponse>> UpdateTeamMemberAsync(UpdateTeamMerberRequest request);
    }
}
