using AutoMapper;
using FPM.Resourses.DTOs.PreproductionPlaning.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Mapping.PreproductionMember
{
    public sealed class ResourseToModelProfile : Profile
    {
        public ResourseToModelProfile()
        {
            CreateMap<CreatePreproductionMemberRequest, Core.Entities.PreproductionMember>();
            CreateMap<UpdatePreproductionMemberRequest, Core.Entities.PreproductionMember>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
