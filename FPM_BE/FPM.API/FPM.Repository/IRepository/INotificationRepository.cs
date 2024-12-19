using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;

namespace FPM.Repositories.IRepository
{
    public interface INotificationRepository : IGenericRepository<Notify>
    {
        Task<(bool HasData, IEnumerable<Notify> Data)> GetNotificationsByUserAsync(int id);
        Task<Notify?> GetByIdAsync(int id);
    }
}
