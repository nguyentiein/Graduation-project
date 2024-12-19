using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Repositories.Repository
{
    public interface ITeamMemberRespository:IGenericRepository<TeamMember>
    {
        Task<(bool HasData, IEnumerable<TeamMember> Data)> GetTeamMemberByTeamId(int id);
    }
}
