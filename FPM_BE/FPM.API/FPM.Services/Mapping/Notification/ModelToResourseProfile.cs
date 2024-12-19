using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FPM.Core.Entities;
using FPM.Resourses.DTOs.Notification.Response;
using FPM.Resourses.DTOs.Topic.Reponse;

namespace FPM.Services.Mapping.Notification
{
    public class ModelToResourseProfile : Profile
    {
        public ModelToResourseProfile()
        {
            CreateMap<Notify, NotificationResponse>()
                .ForMember(dest => dest.SenderName, opt => opt.MapFrom(src => src.Sender != null ? src.Sender.UserName : "Unknown"))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt ?? DateTime.MinValue))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status ?? 0));
        }
    }
}
