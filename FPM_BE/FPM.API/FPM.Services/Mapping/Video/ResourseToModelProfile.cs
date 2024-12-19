using AutoMapper;
using FPM.Resourses.DTOs.Video.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Mapping.Video
{
    public sealed class ResourseToModelProfile : Profile
    {
        public ResourseToModelProfile()
        {
            CreateMap<CreateVideoRequest, Core.Entities.Video>()
                .ForMember(x => x.CreatedDate,opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(x => x.UpdatedDate,opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}
