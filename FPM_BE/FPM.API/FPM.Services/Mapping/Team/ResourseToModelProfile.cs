using AutoMapper;
using AutoMapper.Configuration.Conventions;
using FPM.Core.Entities;
using FPM.Resourses.DTOs.Team.Request;
using FPM.Resourses.DTOs.Teams.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Mapping.Teams
{
    public sealed  class ResourseToModelProfile:Profile
    {
       public ResourseToModelProfile()
        {
            CreateMap<CreateTeamRequest, Team>();

            CreateMap<CreateRequest, Team>();

            CreateMap<TeamUserDto,Core.Entities.User>();

            CreateMap<TeamMemmerDto, TeamMember>()
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => new Core.Entities.User
            {
                FirstName = src.FirstName,
                LastName = src.LastName
            }));

            CreateMap<UpdateTeamRequest, Team>();
            CreateMap<UpdateTeamUserDto, Core.Entities.User>();

            CreateMap<UpdateTeamMemmerDto, TeamMember>()
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => new Core.Entities.User
            {
                FirstName = src.FirstName,
                LastName = src.LastName
            }));

        }

    }
}
