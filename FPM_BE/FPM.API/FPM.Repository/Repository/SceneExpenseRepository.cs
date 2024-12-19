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
    public class SceneExpenseRepository : GenericRepository<SceneExpense>, ISceneExpenseRepository
    {
        public SceneExpenseRepository(FPMContext db) : base(db)
        {
        }

        public async Task<(bool HasData, IEnumerable<SceneExpense> Data)> GetAllSceneExpenseBySceneIdAsync(int sceneId)
        {
            var result = await _db.SceneExpenses.Include(x => x.ExpenseType).Where(x => x.SceneId == sceneId).ToListAsync();
            return (result.Count > 0, result);
        }
    }
}
