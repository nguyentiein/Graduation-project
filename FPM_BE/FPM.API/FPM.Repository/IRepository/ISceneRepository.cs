using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Repositories.IRepository
{
    public interface ISceneRepository :IGenericRepository<Scene>
    {
        Task<(bool HasData, IEnumerable<Scene> Data)> GetAllSceneInSegmentAsync(int segmentId);

        Task<IEnumerable<Scene>> GetAllSceneInPreproductionAsync(int preproductionId);
    }
}
