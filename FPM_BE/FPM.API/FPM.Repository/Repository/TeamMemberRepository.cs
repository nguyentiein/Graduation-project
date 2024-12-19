using FPM.Core.Database;
using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Repositories.Repository
{
    public sealed class TeamMemberRepository : GenericRepository<TeamMember>, ITeamMemberRespository
    {
        public TeamMemberRepository(FPMContext db) : base(db)
        {
        }

        public async Task<(bool HasData, IEnumerable<TeamMember> Data)> GetTeamMemberByTeamId(int id)
        {
            var result = await _db.TeamMembers.Include(t => t.Team).Where(p => p.TeamId == id).ToListAsync();         
            return (result.Count > 0, result);
        }
    }
}
