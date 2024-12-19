using AutoMapper;
using FPM.Core.Entities;
using FPM.Resourses.DTOs.Log.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Mapping.Log
{
    public sealed class ResourseToModelProfile : Profile
    {
        public ResourseToModelProfile()
        {
            CreateMap<RequestResponseLogModel,Core.Entities.Log>()
                .ForMember(des => des.Id, opt => opt.MapFrom(src => src.LogId))
                .ForMember(des => des.HasException, opt => opt.MapFrom(src => src.IsExceptionActionLevel))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
