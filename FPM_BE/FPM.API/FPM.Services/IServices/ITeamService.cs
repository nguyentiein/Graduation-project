using FPM.Resourses.DTOs.Team.Request;
using FPM.Resourses.DTOs.Team.Response;
using FPM.Resourses.DTOs.Teams.Request;
using FPM.Resourses.DTOs.Test.Request;
using FPM.Resourses.DTOs.Test.Response;
using FPM.Resourses.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.IServices
{
    public  interface ITeamService
   {

        Task<BaseResult<IEnumerable<TeamResponse>>> GetAllTeamUserAsync(); 
        Task<BaseResult<TeamResponse>> CreateNewTeamAsync(CreateTeamRequest request);
        Task<BaseResult<TeamResponse>> UpdateTeamAsync(UpdateTeamRequest request);
        Task<BaseResult<TeamResponse>>   DeleteAsync(int id);
        Task<BaseResult<IEnumerable<TeamResponse>>> GetAllTeamDetailByIdAsync(int id);
        

    }
}
