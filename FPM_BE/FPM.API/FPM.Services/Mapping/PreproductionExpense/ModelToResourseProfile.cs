using AutoMapper;
using FPM.Resourses.DTOs.Estimate.Reponse;
using FPM.Resourses.DTOs.PreproductionExpense.Reponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Mapping.PreproductionExpenses
{
    public  class ModelToResourseProfile:Profile
    {
        public ModelToResourseProfile() {
            CreateMap<Core.Entities.PreproductionEstimate, PreproductionEstimateResponse>()
                .ForMember(x => x.ExpenseType,opt => opt.MapFrom(src => src.ExpenseType));
        }

    }
}
