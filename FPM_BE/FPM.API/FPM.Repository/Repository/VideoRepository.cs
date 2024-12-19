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
    public class VideoRepository : GenericRepository<Video>, IVideoRepository
    {
        public VideoRepository(FPMContext db) : base(db)
        {
        }

        public async Task<(bool HasData, Video Data)> GetByIdAsync(int videoId)
        {
            var result = await _db.Videos.Include(x => x.UploadPart).FirstOrDefaultAsync(x => x.Id == videoId);
            return (result != null, result);
        }

        public async Task<(bool HasData, IEnumerable<Video> Data)> SearchVideoAsync(int objectId, VideoTypeEnum objectType)
        {
            var result = await _db.Videos.Where(x => x.ObjectId == objectId && x.ObjectType == objectType).ToListAsync();

            return (result.Count > 0,result);
        }
    }
}
