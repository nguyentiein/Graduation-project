using AutoMapper;
using FPM.Core.Entities;
using FPM.Resourses.DTOs.Topic.Request;
using FPM.Resourses.DTOs.User.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Mapping.Users
{
    public class ResourseToModelProfile :Profile
    {
        public ResourseToModelProfile()
        {
            CreateMap<CreateUserRequest, User>();

            CreateMap<UpdateUserProfileRequest, Core.Entities.User>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
