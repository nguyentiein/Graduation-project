using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Repositories.IRepository
{
    public interface ISceneExpenseRepository : IGenericRepository<SceneExpense>
    {
        Task<(bool HasData, IEnumerable<SceneExpense> Data)> GetAllSceneExpenseBySceneIdAsync(int sceneId);
    }
}
