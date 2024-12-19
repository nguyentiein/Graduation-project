using AutoMapper;
using FPM.Resourses.DTOs.PostproductionPlanning.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Mapping.PostproductionPlanning
{
    public sealed class ResourseToModelProfile : Profile
    {
        public ResourseToModelProfile()
        {
            CreateMap<UpdatePostproductionPlanRequest, Core.Entities.PostproductionPlaning>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
