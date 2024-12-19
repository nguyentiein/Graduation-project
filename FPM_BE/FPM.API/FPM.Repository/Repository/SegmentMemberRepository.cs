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
    public class SegmentMemberRepository : GenericRepository<PreproductionsegmentMember>, ISegmentMemberRepository
    {
        public SegmentMemberRepository(FPMContext db) : base(db)
        {
        }

        public async Task<(bool HasData, PreproductionsegmentMember Data)> GetByIdAsync(int id)
        {
            var result = await _db.PreproductionsegmentMembers.Include(x => x.PreProductionSegment).FirstOrDefaultAsync(x => x.Id == id);

            return (result != null, result);
        }
    }
}
