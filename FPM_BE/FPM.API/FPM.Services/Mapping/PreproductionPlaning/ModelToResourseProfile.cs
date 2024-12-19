using AutoMapper;
using FPM.Core.Entities;
using FPM.Resourses.DTOs.PreproductionPlaning.Reponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Mapping.PreproductionPlanings
{
    public sealed class ModelToResourseProfile:Profile
    {
        public ModelToResourseProfile() {
            CreateMap<PreproductionPlaning, PreproductionPlaningReponse>()
                .ForMember(x => x.Process, opt => opt.MapFrom(src => GetPlanProcess(src)));
            CreateMap<Topic, TopicDto>();
            CreateMap<Commoncategory, CategoryDtto>();
            CreateMap<Team, TeamDto>();
         

        }

        private float? GetPlanProcess(PreproductionPlaning plan)
        {
            var NumberSegment = plan.PreproductionSegments.Count();
            var numberComplete = plan.PreproductionSegments.Where(x => x.Status > 0).Count();
            return NumberSegment > 0 ? ((float) numberComplete/(float)NumberSegment) : 0;
        }
    }

    
}
