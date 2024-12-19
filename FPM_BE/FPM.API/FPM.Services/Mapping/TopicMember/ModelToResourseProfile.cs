using AutoMapper;
using FPM.Core.Entities;
using FPM.Resourses.DTOs.TopicMember.Reponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Mapping.TopicMembers
{
    public class ModelToResourseProfile:Profile
    {
        public ModelToResourseProfile()
        {
            CreateMap<TopicMember, TopicMemberResponse>();
        }
    }
}
