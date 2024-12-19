using AutoMapper;
using FPM.Resourses.DTOs.Scene.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Mapping.Scene
{
    public sealed class ResourseToModelProfile : Profile
    {
        public ResourseToModelProfile() 
        {
            CreateMap<AddSceneRequest, Core.Entities.Scene>()
                .ForMember(des => des.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(des => des.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateSceneRequest, Core.Entities.Scene>()
                .ForMember(des => des.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
