using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using FPM.Resourses.DTOs.CommonCategory.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Repositories.IRepository
{
    public interface ICommonCategoryRepository : IGenericRepository<Commoncategory>
    {
        Task<(bool hasData,IEnumerable<Commoncategory> data)> GetCommoncategoriesByTypeAsync(SearchCommonCategoryModel request);
    }
}
