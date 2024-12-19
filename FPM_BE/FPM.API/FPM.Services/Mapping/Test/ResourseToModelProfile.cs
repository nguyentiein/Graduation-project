using AutoMapper;
using FPM.Core.Entities;
using FPM.Resourses.DTOs.Test.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Mapping.Tests
{
    public sealed class ResourseToModelProfile : Profile
    {
        public ResourseToModelProfile()
        {
            CreateMap<CreateTestRequest, Test>()
                .ForMember(des => des.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(des => des.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateTestRequest, Test>()
                .ForMember(des => des.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
