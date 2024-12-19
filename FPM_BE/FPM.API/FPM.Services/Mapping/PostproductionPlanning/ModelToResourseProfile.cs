using AutoMapper;
using FPM.Resourses.DTOs.PostproductionPlanning.Response;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Mapping.PostproductionPlanning
{
    public sealed class ModelToResourseProfile : Profile
    {
        public ModelToResourseProfile()
        {
            CreateMap<Core.Entities.PostproductionPlaning, PostproductionPlanResponse>()
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.PreProduction.Name))
                .ForMember(x => x.CreateBy, opt => opt.MapFrom(src => src.PreProduction.CreatedBy))
                .ForMember(x => x.Process, opt => opt.MapFrom(src => GetProcess(src.PreProduction)))
                .ForMember(x => x.Broadcastings, opt => opt.MapFrom(src => src.Broadcastings));

            CreateMap<Core.Entities.PostproductionPlaning, PostproductionPlanDetailResponse>()
                //.ForMember(x => x.PostproductionExpenses, opt => opt.MapFrom(src => src.PostproductionExpenses))
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.PreProduction.Name))
                .ForMember(x => x.Status, opt => opt.MapFrom(src => src.Status.ToString()));
        }


        private float GetProcess(Core.Entities.PreproductionPlaning preproduciton)
        {
            var sumSegment = preproduciton.PreproductionSegments.Count();
            var sumOfComplete = preproduciton.PreproductionSegments.Where(x => x.Status == 2).Count();

            return sumSegment > 0 ? (float)sumOfComplete/(float)sumSegment : 0;
        }
    }
}
