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
    public class LogRepository : GenericRepository<Log>, ILogRepository
    {
        public LogRepository(FPMContext db) : base(db)
        {
        }
    }
}
