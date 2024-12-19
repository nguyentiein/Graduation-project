using AutoMapper;
using FPM.Core.Entities;
using FPM.Resourses.DTOs.Topic.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Mapping.Topics
{
    public class ResourseToModelProfile : Profile
    {
        public ResourseToModelProfile()
        {
            CreateMap<CreateTopicRequest, Topic>();
            CreateMap<UpdateTopicRequest, Topic>();
        }
    }
}
