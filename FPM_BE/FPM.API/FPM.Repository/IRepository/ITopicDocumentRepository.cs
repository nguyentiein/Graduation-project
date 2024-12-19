using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using FPM.Resourses.DTOs.TopicDocument.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Repositories.IRepository
{
    public interface ITopicDocumentRepository : IGenericRepository<TopicDocument>
    {
        Task<(bool HasData,IEnumerable<TopicDocument> Data)> SearchDocumentAsync(SearchDocumentModel request);
        Task<(bool HasData,TopicDocument Data)> GetTopicDocumentByIdAsync(int id);
    }
}
