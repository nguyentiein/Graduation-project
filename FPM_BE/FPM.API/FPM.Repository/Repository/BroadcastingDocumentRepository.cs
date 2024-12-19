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
    public class BroadcastingDocumentRepository : GenericRepository<Broadcastingdocument>, IBroadcastingDocumentRepository
    {
        public BroadcastingDocumentRepository(FPMContext db) : base(db)
        {
        }

        public async Task<(bool HasData, IEnumerable<Broadcastingdocument> Data)> GetDocumentByBroadcastingIdAsync(int broadcastingId)
        {
            var result = await _db.Broadcastingdocuments.Include(x => x.UploadPart).Where(x => x.BroadcastingId == broadcastingId).ToListAsync();
            return (result.Count > 0, result);
        }
    }
}
