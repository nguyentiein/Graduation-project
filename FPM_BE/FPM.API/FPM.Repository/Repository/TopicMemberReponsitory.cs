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
    public class TopicMemberReponsitory : GenericRepository<TopicMember>, ITopicMemberReponsitory
    {
        public TopicMemberReponsitory(FPMContext db) : base(db)
        {
        }

        public async Task<(bool HasData, IEnumerable<TopicMember> Data)> GetTopicMemberById(int id)
        {
            var result = await _db.TopicMembers.Where(p => p.TopicId == id)
           .ToListAsync();
            return (result.Count > 0, result);
        }
    }
}
