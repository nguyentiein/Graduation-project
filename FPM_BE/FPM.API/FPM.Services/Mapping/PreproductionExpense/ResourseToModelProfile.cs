using AutoMapper;
using FPM.Core.Entities;
using FPM.Resourses.DTOs.Estimate.Request;
using FPM.Resourses.DTOs.PreproductionExpense.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Mapping.PreproductionExpenses
{
    public sealed class ResourseToModelProfile : Profile
    {
        public ResourseToModelProfile()
        {
            CreateMap<CreatePreproductionEstimateRequest,PreproductionEstimate>()
                .ForMember(x => x.ExpenseTypeId,opt => opt.MapFrom(src => src.ExpenseTypeId));


            CreateMap<UpdatePreproductionEstimateRequest, PreproductionEstimate>()
                .ForMember(x => x.ExpenseTypeId, opt => opt.MapFrom(src => src.ExpenseType));
        }
    }
}
