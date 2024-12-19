#nullable disable
using AutoMapper;
using FPM.Core.Entities;
using FPM.Resourses.DTOs.CommonCategory.Response;
using FPM.Resourses.DTOs.User.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Mapping.Role
{
    public sealed class ModelToResourseProfile : Profile
    {
        public ModelToResourseProfile()
        {
            CreateMap<Core.Entities.Role, RoleResponse>()
                .ForMember(x => x.Type, opt => opt.MapFrom(src => src.Type.ToString()));

            CreateMap<Commoncategory, CommonCategoryResponse>()
                .ForMember(x => x.Parent,opt => opt.MapFrom(src => src.Parent))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }

       
    }
}
