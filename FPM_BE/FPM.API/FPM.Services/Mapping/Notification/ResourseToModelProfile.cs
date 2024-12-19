using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FPM.Core.Entities;
using FPM.Resourses.DTOs.Notification.Request;
using FPM.Resourses.DTOs.Topic.Request;

namespace FPM.Services.Mapping.Notification
{
    public class ResourseToModelProfile : Profile
    {
        public ResourseToModelProfile()
        {
            CreateMap<NotificationRequest, Notify>()
                 .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now))
                 //.ForMember(dest => dest.Status, opt => opt.MapFrom(src => 0))
                 .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));
        }
    }
}
