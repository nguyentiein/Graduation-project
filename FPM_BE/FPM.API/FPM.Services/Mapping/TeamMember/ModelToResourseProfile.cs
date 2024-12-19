using AutoMapper;
using FPM.Core.Entities;
using FPM.Resourses.DTOs.TeamMember.Reponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Mapping.TeamMembers
{
    public sealed class ModelToResourseProfile:Profile
    {
        public ModelToResourseProfile()
        {
            CreateMap<TeamMember, TeamMemberReponse>();
        }
    }
}
