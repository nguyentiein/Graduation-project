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
    public class EtimateReponsitory : GenericRepository<Estimate>, IEstimateReponsitory
    {
        public EtimateReponsitory(FPMContext db) : base(db)
        {
        }

        public async Task<(bool HasData, IEnumerable<Estimate> Data)> GetEstimate()
        {
            var result = await _db.Estimates.ToListAsync();
            return (result.Count > 0, result);
        }

        public async Task<(bool HasData, IEnumerable<Estimate> Data)> GetEstimateAsyncByid(int id)
        {
            var result = await _db.Estimates.Where(es=>es.Id==id).ToListAsync();
            return (result.Count > 0, result);
        }

        public async Task<(bool HasData, IEnumerable<Estimate> Data)> GetEstimateAsyncByPreproductionid(int preId)
        {
            var result = await _db.Estimates.Include(pre=>pre.PreProductPlaning).
                Where(pre => pre.PreProductPlaningId == preId).ToListAsync();
            return (result.Count > 0, result);
        }

        public  async Task<(bool HasData, IEnumerable<Estimate> Data)> GetEstimateAsyncBySegidasync(int segId)
        {
            var result = await _db.Estimates
        .Include(pre => pre.PreProductPlaning)
        .ThenInclude(plan => plan.PreproductionSegments)
        .Where(est => est.PreProductPlaning.PreproductionSegments.Any(seg => seg.Id == segId))
        .ToListAsync();
            return (result.Count > 0, result);
        }
    }
}
