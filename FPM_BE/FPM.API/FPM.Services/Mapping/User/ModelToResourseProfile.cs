using AutoMapper;
using FPM.Core.Entities;
using FPM.Resourses.DTOs.User.Response;
using FPM.Services.IServices;
using FPM.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Mapping.Users;

public sealed class ModelToResourseProfile : Profile
{
    public ModelToResourseProfile() 
    {
        CreateMap<Core.Entities.User, UserResponse>()
            .ForMember(x => x.Department, opt => opt.MapFrom(src => src.Depart))
            .ForMember(x => x.Roles, opt => opt.MapFrom(src => src.Roles))
            .ForMember(x => x.Status, opt => opt.MapFrom(src => src.Status.ToString()))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<Commoncategory, DepartmentResponse>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<Core.Entities.User, LoginResponse>()
            .ForMember(x => x.Department, opt => opt.MapFrom(src => src.Depart))
            .ForMember(x => x.Roles, opt => opt.MapFrom(src => src.Roles))
            .ForMember(x => x.Status, opt => opt.MapFrom(src => src.Status.ToString()))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }

}
