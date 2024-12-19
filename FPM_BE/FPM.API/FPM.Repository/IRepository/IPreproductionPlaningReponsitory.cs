using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Repositories.IRepository
{
    public  interface IPreproductionPlaningReponsitory:IGenericRepository<PreproductionPlaning>
    {
        Task<(bool HasData, IEnumerable<PreproductionPlaning> Data)> GetPreproductionPlaning();
        Task<(bool HasData, PreproductionPlaning Data)> GetPreproductionPlaningAsyncByid(int id);

        Task<List<ViewReport>> GetReportInfoAsync();
    }
}
