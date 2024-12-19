using FPM.Core.Database;
using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using FPM.Repositories.IRepository;
using FPM.Resourses.DTOs.TopicDocument.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Repositories.Repository
{
    public class TopicDocumentRepository : GenericRepository<TopicDocument>, ITopicDocumentRepository
    {
        public TopicDocumentRepository(FPMContext db) : base(db)
        {
        }

        public async Task<(bool HasData, TopicDocument Data)> GetTopicDocumentByIdAsync(int id)
        {
            var topicDocument = await _db.TopicDocuments.Include(x => x.UploadPart).FirstOrDefaultAsync(x => x.Id == id);

            return (topicDocument != null, topicDocument);
        }

        public async Task<(bool HasData, IEnumerable<TopicDocument> Data)> SearchDocumentAsync(SearchDocumentModel request)
        {
            var query = _db.TopicDocuments.AsNoTracking().AsQueryable();

            if(request.TopicId != null)
            {
                query = query.Where(x => x.TopicId == request.TopicId);
            }
            if(request.Status != null)
            {
                query = query.Where(x => x.Status == request.Status);
            }


            var data = await query.Include(x => x.UploadPart)
                                   //.Where(x => x.CreateBy == request.userId || x.ApproveBy == request.userId)
                                   .ToListAsync();

            return (data.Count > 0, data);
        }

        

    }
}
