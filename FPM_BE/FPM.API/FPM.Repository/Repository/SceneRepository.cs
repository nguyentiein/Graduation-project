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
    public class SceneRepository : GenericRepository<Scene>, ISceneRepository
    {
        public SceneRepository(FPMContext db) : base(db)
        {
        }

        public async Task<IEnumerable<Scene>> GetAllSceneInPreproductionAsync(int preproductionId)
        {
            var result = await _db.Scenes.Where(x => x.PreproductionId == preproductionId).Include(x => x.SceneExpenses).ToListAsync();
            return result;
        }

        public async Task<(bool HasData, IEnumerable<Scene> Data)> GetAllSceneInSegmentAsync(int segmentId)
        {
            var result = await _db.Scenes.Where(x => x.PreproductionSegmentId == segmentId).ToListAsync();

            return (result.Count > 0,result);
        }
    }
}
