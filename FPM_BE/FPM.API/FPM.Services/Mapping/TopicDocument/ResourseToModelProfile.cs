using AutoMapper;
using FPM.Resourses.DTOs.TopicDocument.Request;
using FPM.Resourses.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Mapping.TopicDocument
{
    public sealed class ResourseToModelProfile : Profile
    {
        public ResourseToModelProfile()
        {
            CreateMap<CreateTopicDocumentRequest, Core.Entities.TopicDocument>()
                
                .ForMember(x => x.Status, opt => opt.MapFrom(src => DocumentStatusEnum.Checking));
        }
    }
}
