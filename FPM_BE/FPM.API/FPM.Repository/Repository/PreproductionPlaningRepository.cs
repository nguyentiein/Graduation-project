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
    public class PreproductionPlaningRepository : GenericRepository<PreproductionPlaning>, IPreproductionPlaningReponsitory
    {
        public PreproductionPlaningRepository(FPMContext db) : base(db)
        {
        }

        public async Task<(bool HasData, IEnumerable<Core.Entities.PreproductionPlaning> Data)> GetPreproductionPlaning()
        {
            var result = await _db.PreproductionPlanings.Include(x => x.PreproductionSegments).Include(t => t.Topic).Include(u => u.Team).Include(ci => ci.Category).ToListAsync();
            return (result.Count > 0, result);

        }

        public async Task<(bool HasData, PreproductionPlaning Data)> GetPreproductionPlaningAsyncByid(int id)
        {
            var result = await _db.PreproductionPlanings.Include(t => t.Topic)
                                                        .Include(u => u.Team)
                                                        .Include(c => c.Category)
                                                        .Include(x => x.PreproductionSegments)
                                                        .Where(p => p.Id == id).FirstOrDefaultAsync();
            return (result != null, result);
        }

        public async Task<List<ViewReport>> GetReportInfoAsync()
        {
            
    
            var result = await _db.PreproductionPlanings
                                .Include(t => t.Topic)
                                .Include(m => m.PreproductionMembers)
                                .Include(x => x.PreproductionSegments).ThenInclude(x => x.Scenes).ThenInclude(x => x.SceneExpenses)
                                .Where(x => x.Status != 0).Select(x => new ViewReport
            {
                Name = x.Name,
                FromDate = x.CreatedAt,
                CreateBy = x.CreatedBy,
                ToDate = x.PostproductionPlaning.ToDate,
                EstimateFee = x.Estimate.HumanResourceEstimate.GetValueOrDefault() + x.Estimate.OtherResourceEstimate.GetValueOrDefault() + x.Estimate.EditorFee + x.Estimate.CameramanFee + x.Estimate.ScriptFee,
                FactFee = x.PreproductionMembers.Select(x => x.TotalSalary).Sum() + (x.PreproductionSegments.SelectMany(x => x.Scenes).SelectMany(x => x.SceneExpenses).Select(x => x.Amount).Sum().GetValueOrDefault()) + (x.Topic.Budget.GetValueOrDefault())
            }).ToListAsync();

            return result;
        }

        #region PrivateWork

        #endregion
    }
}
