using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using FPM.Resourses.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Repositories.IRepository
{
    public interface IApporvedReponsitory:IGenericRepository<Approved>
    {
        Task<(bool HasData, IEnumerable<Approved> Data)> GetApprovedByObjectId(int id);
        Task<(bool HasData, IEnumerable<Approved> Data)> GetApprovedByObjectType(ApproveObjectTypeEnum id);
        Task<(bool HasData, IEnumerable<Approved> Data)> GetApprovedByObjectTypeAndObjectId(ApproveObjectTypeEnum typeId, int objectId);
      
    }
}
