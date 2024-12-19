using FPM.Core.Database;
using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using FPM.Repositories.IRepository;
using FPM.Resourses.DTOs.CommonCategory.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Repositories.Repository
{
    public class CommonCategoryRepository : GenericRepository<Commoncategory>, ICommonCategoryRepository
    {
        public CommonCategoryRepository(FPMContext db) : base(db)
        {
        }

        public async Task<(bool hasData, IEnumerable<Commoncategory> data)> GetCommoncategoriesByTypeAsync(SearchCommonCategoryModel request)
        {
            var query = _db.Commoncategories.AsNoTracking().AsQueryable();

            

            if(request.ParentId != null)
            {
                query = query.Where(c => c.ParentId == request.ParentId);
                
            }

            var data = await query.Include(e => e.Parent).Where(c => (int)c.Type == request.Type).ToListAsync();

            return (data.Count != 0,data);

        }
    }
}
