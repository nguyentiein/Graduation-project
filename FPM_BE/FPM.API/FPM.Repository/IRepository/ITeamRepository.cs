using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using FPM.Repositories.Repository;
using FPM.Resourses.DTOs.Team.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Repositories.IRepository
{
    public interface ITeamRespository:IGenericRepository<Team>
    {
        Task <(bool HasData,IEnumerable<Team> Data)> GetAllTeamDetailByIdAsync(int id);
        Task<(bool HasData, IEnumerable<Team> Data)> GetAllTeamAsync();
        Task<(bool HasData, IEnumerable<Team> Data)> CreateTeamAsync(Team newTeam);
        Task<(bool HasData, IEnumerable<Team> Data)> UpdateTeamAsync(Team updateRequest);




    }
}
