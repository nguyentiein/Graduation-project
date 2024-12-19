using AutoMapper;
using FPM.Core.Entities;
using FPM.Resourses.DTOs.TeamMember.Request;
using FPM.Resourses.DTOs.TopicMember.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Mapping.TopicMembers
{
    public class ResourseToModelProfile:Profile
    {
        public ResourseToModelProfile()
        {
            CreateMap<CreateTopicMemberRequest, TopicMember>();
        }
    }
}
