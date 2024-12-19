using AutoMapper;
using FPM.Core.Entities;
using FPM.Resourses.DTOs.CommonCategory.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Mapping.Role
{
    public sealed class ResourseToModelProfile : Profile
    {
        public ResourseToModelProfile()
        {
            CreateMap<CreateCommonCategoryRequest, Commoncategory>();

            CreateMap<UpdateCommonCategoryRequest, Commoncategory>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
