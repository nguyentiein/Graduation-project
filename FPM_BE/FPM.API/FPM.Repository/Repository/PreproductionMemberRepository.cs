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
    public class PreproductionMemberRepository : GenericRepository<PreproductionMember>, IPreproductionMemberRepository
    {
        public PreproductionMemberRepository(FPMContext db) : base(db)
        {
        }

        public async Task<(bool HasData, IEnumerable<PreproductionMember> Data)> GetAllMemberInPreproductionAsync(int PreproductionId)
        {
            var data = await _db.PreproductionMembers.AsNoTracking()
                                                     .Include(x => x.Member)
                                                     .Where(x => x.PreProductionId == PreproductionId)
                                                     .ToListAsync();

            return(data.Count > 0,data);
        }

        public async Task<(bool HasData, PreproductionMember Data)> GetMemberByIdAsync(int Id)
        {
            var result = await _db.PreproductionMembers.Include(x => x.Member).Include(x => x.SegmentMembers).FirstOrDefaultAsync(x => x.Id == Id);

            return(result != null,result);
        }

        public async Task<(bool HasData, PreproductionMember Data)> SearchMemberAsync(int userId, int preproductionId)
        {
            var result = await _db.PreproductionMembers.Include(x => x.SegmentMembers).Where(x => x.MemberId == userId && x.PreProductionId == preproductionId).FirstOrDefaultAsync();
            return(result != null, result);
        }
    }
}
