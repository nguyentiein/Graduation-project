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
    public class PreproductionSegmentRepository : GenericRepository<PreproductionSegment>, IPreproducitonSegmentRepository
    {
        public PreproductionSegmentRepository(FPMContext db) : base(db)
        {
        }

        public async Task<(bool HasData, IEnumerable<PreproductionSegment> Data)> GetAllSegmentAsync(int preproductionId)
        {
            var segments = await _db.PreproductionSegments
                                    .Include(x => x.PreproductionEstimates)
                                    .Include(x => x.Scenes).ThenInclude(se => se.SceneExpenses)
                                    .Include(x => x.PreproductionsegmentMembers).ThenInclude(pm => pm.User)
                                    .Where(x => x.PreProductionId == preproductionId)
                                    .ToListAsync();
            return (segments.Count > 0,segments);
        }

        public async Task<(bool HasData, PreproductionSegment Data)> GetByIdAync(int id)
        {
            var segment = await _db.PreproductionSegments.Include(segmember => segmember.PreproductionsegmentMembers).ThenInclude(u => u.User)
                                    .FirstOrDefaultAsync(x => x.Id == id);
            return (segment != null, segment);
        }

        public async Task<(bool HasData, IEnumerable<PreproductionSegment> Data)> GetAllSegmentRemindAsync(int segid)
        {
            var users = await _db.PreproductionSegments.Include(u => u.PreproductionsegmentMembers).ThenInclude(ur => ur.User).Include(pl => pl.PreProduction).Where(seg=>seg.Id == segid).
                
                ToListAsync();
            return (users.Count > 0, users);
        }
    }
}
