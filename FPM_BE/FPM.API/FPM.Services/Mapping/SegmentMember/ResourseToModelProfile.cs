using AutoMapper;
using FPM.Core.Entities;
using FPM.Resourses.DTOs.Segment.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Mapping.SegmentMember
{
    public sealed class ResourseToModelProfile : Profile
    {
        public ResourseToModelProfile() {
            CreateMap<CreateSegmentMemberRequest, PreproductionsegmentMember>()
                .ForMember(x => x.PlanMemberId,opt => opt.MapFrom(src => src.PreproductionPlanMemberId));

            CreateMap<UpdateSegmentMemberRequest, PreproductionsegmentMember>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
