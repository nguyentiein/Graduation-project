using FPM.Core.Database;
using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using FPM.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Repositories.Repository
{
    public class BroadcastingRepository : GenericRepository<Broadcasting>, IBroadcastingRepository
    {
        public BroadcastingRepository(FPMContext db) : base(db)
        {
        }
    }
}
