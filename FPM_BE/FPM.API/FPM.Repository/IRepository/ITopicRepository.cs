using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using FPM.Resourses.DTOs.CommonCategory.Request;
using FPM.Resourses.DTOs.Topic.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Repositories.IRepository
{
    public interface ITopicRepository:IGenericRepository<Topic>
    {
        Task<(bool hasData, IEnumerable<Topic> data)> GetTopicByTypeAsync(SearchTopicRequest request);
        Task<(bool HasData, IEnumerable<Topic> Data)> GetTopicByIdAsync(int id);
    }
}
