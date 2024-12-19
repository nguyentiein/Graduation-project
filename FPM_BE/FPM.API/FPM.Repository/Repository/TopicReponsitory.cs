using FPM.Core.Database;
using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using FPM.Repositories.IRepository;
using FPM.Resourses.DTOs.Topic.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Repositories.Repository
{
    public class TopicReponsitory : GenericRepository<Topic>, ITopicRepository
    {
        public TopicReponsitory(FPMContext db) : base(db)
        {
        }

        public async Task<(bool HasData, IEnumerable<Topic> Data)> GetTopicByIdAsync(int id)
        {
            var result = await _db.Topics.Where(p => p.Id == id)
              .ToListAsync();
            return (result.Count > 0, result);
        }

        public async Task<(bool hasData, IEnumerable<Topic> data)> GetTopicByTypeAsync(SearchTopicRequest request)
        {
            var query = _db.Topics.AsNoTracking().AsQueryable();
            if (request.ParentId != null)
            {
                query = query.Where(c => c.ParentId == request.ParentId);

            }

            var data = await query.Include(e => e.Category).Include(m=>m.TopicMembers).ThenInclude(u => u.Member)

               .Where(c => (int)c.Type == request.Type).ToListAsync();

            return (data.Count != 0, data);
        }
    }
}
