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
    public interface IVideoRepository : IGenericRepository<Video>
    {
        Task<(bool HasData, IEnumerable<Video> Data)> SearchVideoAsync(int objectId, VideoTypeEnum objectType);
        Task<(bool HasData, Video Data)> GetByIdAsync(int videoId);
    }
}
