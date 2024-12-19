using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Repositories.IRepository
{
    public interface IEstimateReponsitory : IGenericRepository<Estimate>
    {
        Task<(bool HasData, IEnumerable<Estimate> Data)> GetEstimate();
        Task<(bool HasData, IEnumerable<Estimate> Data)> GetEstimateAsyncByid(int id);
        Task<(bool HasData, IEnumerable<Estimate> Data)> GetEstimateAsyncByPreproductionid(int preId);
        Task<(bool HasData, IEnumerable<Estimate> Data)> GetEstimateAsyncBySegidasync(int segId);
    }
}
