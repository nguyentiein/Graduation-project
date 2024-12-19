using AutoMapper;
using FPM.Resourses.DTOs.Segment.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Mapping.PreproductionSegment
{
    public sealed class ResourseToModelProfile: Profile
    {
        public ResourseToModelProfile() 
        {
            CreateMap<CreateSegmentRequest, Core.Entities.PreproductionSegment>()
                .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(x => x.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(x => x.IsDeleted, opt => opt.MapFrom(src => false))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateSegmentRequest, Core.Entities.PreproductionSegment>()
               .ForMember(x => x.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
               .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
