using FPM.Core.Database;
using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using FPM.Repositories.IRepository;
using FPM.Resourses.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Repositories.Repository
{
    public class ApporvedReponsitory : GenericRepository<Approved>, IApporvedReponsitory
    {
        public ApporvedReponsitory(FPMContext db) : base(db)
        {
        }

        public async Task<(bool HasData, IEnumerable<Approved> Data)> GetApprovedByObjectId(int id)
        {
            var result = await _db.Approveds.Where(p => p.ObjectId == id)
          .ToListAsync();
            return (result.Count > 0, result);
        }

        public async Task<(bool HasData, IEnumerable<Approved> Data)> GetApprovedByObjectType(ApproveObjectTypeEnum id)
        {
            var result = await _db.Approveds.Where(p => p.ObjectType == id)
            .ToListAsync();
            return (result.Count > 0, result);
        }

        public async Task<(bool HasData, IEnumerable<Approved> Data)> GetApprovedByObjectTypeAndObjectId(ApproveObjectTypeEnum typeId, int objectId)
        {
            var result = await _db.Approveds.Where(p => p.ObjectType == typeId&&p.ObjectId==objectId)
            .ToListAsync();
            return (result.Count > 0, result);
        }
    }
}
