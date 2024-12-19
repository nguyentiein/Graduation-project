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
    public class PostproductionExpenseRepository : GenericRepository<PostproductionExpense>, IPostproductionExpenseRepository
    {
        public PostproductionExpenseRepository(FPMContext db) : base(db)
        {
        }

        public async Task<(bool Hasdata, IEnumerable<PostproductionExpense>)> GetAllInPostproductionExpenseAsync(int postproductionId)
        {
            throw new NotImplementedException();
        }
    }
}
