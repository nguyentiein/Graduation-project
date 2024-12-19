using AutoMapper;
using FPM.Core.Entities;
using FPM.Resourses.DTOs.TeamMember.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Mapping.TeamMembers
{
    public sealed class ResourseToModelProfile:Profile
    {
        public ResourseToModelProfile()
        {
            CreateMap<CreateTeamMerberRequest, TeamMember>();
            CreateMap<UpdateTeamMerberRequest,TeamMember>();
        }
    }
}
