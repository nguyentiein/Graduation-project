using FPM.Core.Database;
using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using FPM.Repositories.IRepository;
using FPM.Resourses.DTOs.Team.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace FPM.Repositories.Repository
{
    public sealed class TeamRepository : GenericRepository<Team> ,ITeamRespository
    {
        public TeamRepository(FPMContext db) : base(db)
        {
        }

        public  async Task<(bool HasData, IEnumerable<Team> Data)> CreateTeamAsync(Team createRequest)
        {       
            var newTeam = new Team
            {
                Name = createRequest.Name,
                Description = createRequest.Description,
                LeaderId = createRequest.LeaderId,
           
            };

            await _db.Teams.AddAsync(newTeam);
            var result = await _db.Teams.ToListAsync();

            return (result.Count > 0, result);
        }

        public async Task<(bool HasData, IEnumerable<Team> Data)> GetAllTeamAsync()
        {
            var result = await _db.Teams
            .ToListAsync();
            return (result.Count > 0, result);
        }

        public async Task<(bool HasData, IEnumerable<Team> Data)> GetAllTeamDetailAsync()
        {
          var result = await _db.Teams
         .Include(t => t.Leader)
         .Include(t => t.TeamMembers) 
         .ThenInclude(tm => tm.User) 
         .ToListAsync();
          return (result.Count > 0, result);        
        }

        public  async Task<(bool HasData, IEnumerable<Team> Data)> GetAllTeamDetailByIdAsync(int id)
        {
            var result = await _db.Teams.Include(m => m.TeamMembers)
                .Where(p => p.Id == id)     
           .ToListAsync();
            return (result.Count > 0, result);
        }

        public async Task<(bool HasData, IEnumerable<Team> Data)> UpdateTeamAsync(Team updateRequest)
        {
            var existingTeam = await _db.Teams.FindAsync(updateRequest.Id);
          
            if (existingTeam != null)
            {
                var team = new Team()
                {
                    Id = existingTeam.Id,
                    Name = existingTeam.Name,
                    Description = existingTeam.Description,
                    Leader = existingTeam.Leader,
                    TeamMembers = existingTeam.TeamMembers,

                };
                _db.Teams.Update(team);
            }        
            
            var result = await _db.Teams
                .Include(t => t.Leader)
                .Include(t => t.TeamMembers)
                    .ThenInclude(tm => tm.User)
                .ToListAsync();

            return (result.Count > 0, result);
        }
    }
}
