using AutoMapper;
using FPM.Resourses.DTOs.TopicDocument.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace FPM.Services.Mapping.TopicDocument
{
    public sealed class ModelToResourseProfile : Profile
    {
        public ModelToResourseProfile()
        {
            CreateMap<Core.Entities.TopicDocument, TopicDocumentResponse>()
                .ForMember(x => x.Status,opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(x => x.CreatedDate,opt => opt.MapFrom(src => src.UploadPart.CreatedAt))
                .ForMember(x => x.FileName,opt => opt.MapFrom(src => src.UploadPart.FileName));
        }
    }
}
