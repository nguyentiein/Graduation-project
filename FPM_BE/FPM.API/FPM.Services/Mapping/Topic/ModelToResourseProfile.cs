using AutoMapper;
using FPM.Core.Entities;
using FPM.Resourses.DTOs.CommonCategory.Response;
using FPM.Resourses.DTOs.Topic.Reponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Mapping.Topics
{
    public sealed class ModelToResourseProfile:Profile
    {
        public ModelToResourseProfile()           
        {
            CreateMap<TopicMember, TopicMemberDto>()
           .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Member.FirstName))
           .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Member.LastName))
           .ForMember(dest => dest.AvatarUrl, opt => opt.MapFrom(src => src.Member.AvatarUrl))
           .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.Member.FirstName} {src.Member.LastName}".Trim()));

            // Map CommonCategory to CommonCategoryDto
            CreateMap<Commoncategory, CommonCategoryDto>();

            // Map Topic to TopicResponse
            CreateMap<Topic, TopicResponse>()
                .ForMember(dest => dest.TopicMembers, opt => opt.MapFrom(src => src.TopicMembers))
                .ForMember(dest => dest.category, opt => opt.MapFrom(src => src.Category));
        }
    }
}
