using FPM.Core.Database;
using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using FPM.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Repositories.Repository
{
    public class PostproductionPlanRepository : GenericRepository<PostproductionPlaning>, IPostproductionPlanRepository
    {
        public PostproductionPlanRepository(FPMContext db) : base(db)
        {
        }

        

        public async Task<(bool HasData, IEnumerable<PostproductionPlaning> Data)> GetAllPostProductionPlanAsync()
        {
            var result = await _db.PostproductionPlanings
                .Include(x => x.PreProduction).ThenInclude(p => p.PreproductionSegments).ToListAsync();

            return (result.Count > 0, result);
        }

        public async Task<(bool HasData, PostproductionPlaning Data)> GetByIdAsync(int id)
        {

            var result = await _db.PostproductionPlanings
                                .Include(x => x.PreProduction).ThenInclude(p => p.PreproductionMembers)
                                .Include(x => x.PostproductionExpenses)
                                .FirstOrDefaultAsync(x => x.Id == id);

            return (result != null, result);
        }
        public async Task<(bool HasData, IEnumerable<PostproductionPlaning> Data)> GetAllPostproductionPlanAndBroadcastingAsync()
        {
            var result = await _db.PostproductionPlanings.Include(x => x.PreProduction)
                                                   .Include(x => x.Broadcastings).ThenInclude(x => x.Channel).ThenInclude(c => c.Parent)
                                                   .ToListAsync();
            return (result.Count > 0, result);
        }
    }
}
