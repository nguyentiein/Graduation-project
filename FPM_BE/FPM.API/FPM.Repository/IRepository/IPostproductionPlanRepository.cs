using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Repositories.IRepository
{
    public interface IPostproductionPlanRepository: IGenericRepository<PostproductionPlaning>
    {
        Task<(bool HasData, IEnumerable<PostproductionPlaning> Data)> GetAllPostProductionPlanAsync();

        Task<(bool HasData, PostproductionPlaning Data)> GetByIdAsync(int id);

        Task<(bool HasData, IEnumerable<PostproductionPlaning> Data)> GetAllPostproductionPlanAndBroadcastingAsync();
    }
}
