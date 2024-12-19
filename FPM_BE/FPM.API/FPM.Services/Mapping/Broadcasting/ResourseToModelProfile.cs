using AutoMapper;
using FPM.Resourses.DTOs.Broadcasting.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Mapping.Broadcasting
{
    public sealed class ResourseToModelProfile : Profile
    {
        public ResourseToModelProfile()
        {
            CreateMap<CreateBroadcastingRequest, Core.Entities.Broadcasting>();

            CreateMap<UpdateBroadcastingRequest, Core.Entities.Broadcasting>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
