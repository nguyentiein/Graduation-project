using FPM.Core.Database;
using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using FPM.Repositories.IRepository;
using Microsoft.EntityFrameworkCore.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Repositories.Repository
{
    public class UploadPartRepository : GenericRepository<UploadPart>, IUploadPartRepository
    {
        public UploadPartRepository(FPMContext db) : base(db)
        {
        }
    }
}
