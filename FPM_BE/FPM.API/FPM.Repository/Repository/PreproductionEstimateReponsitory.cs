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
    public class PreproductionEstimateReponsitory : GenericRepository<PreproductionEstimate>, IPreproductionEstimateReponsitory
    {
        public PreproductionEstimateReponsitory(FPMContext db) : base(db)
        {
        }

        public async  Task<(bool HasData, IEnumerable<PreproductionEstimate> Data)> GetAllPreproductionExpenseBySegIdAsync(int id)
        {
            var result = await _db.PreproductionEstimates.Include(x => x.ExpenseType)
               .Where(seg => seg.SegmentId == id).ToListAsync();
            return (result.Count > 0, result);
        }

        public async Task<(bool HasData, IEnumerable<PreproductionEstimate> Data)> GetAllTeamAsync()
        {
            throw new NotImplementedException();
        }
    }
}
