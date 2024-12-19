using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using FPM.Resourses.DTOs.Approved.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Repositories.IRepository
{
    public interface IPostproductionExpenseRepository : IGenericRepository<PostproductionExpense>
    {
        Task<(bool Hasdata, IEnumerable<PostproductionExpense>)> GetAllInPostproductionExpenseAsync(int postproductionId);
    }
}
