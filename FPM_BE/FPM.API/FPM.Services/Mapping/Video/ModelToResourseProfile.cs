using AutoMapper;
using FPM.Resourses.DTOs.Video.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Mapping.Video
{
    public sealed class ModelToResourseProfile : Profile
    {
        public ModelToResourseProfile()
        {
            CreateMap<Core.Entities.Video, VideoResponse>();
        }
    }
}
