using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Repositories.IRepository
{
    public  interface ITopicMemberReponsitory: IGenericRepository<TopicMember>
    {
        Task<(bool HasData, IEnumerable<TopicMember> Data)> GetTopicMemberById(int id);
    }
}
