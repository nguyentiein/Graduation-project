using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Repositories.IRepository
{
    public interface IPreproducitonSegmentRepository : IGenericRepository<PreproductionSegment>
    {
        Task<(bool HasData, IEnumerable<PreproductionSegment> Data)> GetAllSegmentAsync(int preproductionId);
        Task<(bool HasData, PreproductionSegment Data)> GetByIdAync(int id);
        Task<(bool HasData, IEnumerable<PreproductionSegment> Data)> GetAllSegmentRemindAsync(int segid);
       // Task GetAllUserRemindAsync();
    }
}
