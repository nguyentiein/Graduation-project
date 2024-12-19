using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FPM.Core.Database;
using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using FPM.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace FPM.Repositories.Repository
{
    public class NotificationRepository : GenericRepository<Notify>, INotificationRepository
    {
        public NotificationRepository(FPMContext db) : base(db)
        {
        }

        public async Task<Notify?> GetByIdAsync(int id)
        {
            return await _db.Set<Notify>().FirstOrDefaultAsync(n => n.Id == id);
        }


        public async Task<(bool HasData, IEnumerable<Notify> Data)> GetNotificationsByUserAsync(int id)
        {
            var notifications = await _db.Set<Notify>()
                .Where(n => n.UserId == id)
                .OrderByDescending(n => n.CreatedAt) 
                .ToListAsync();
            return (notifications.Any(), notifications);
        }
    }
}
