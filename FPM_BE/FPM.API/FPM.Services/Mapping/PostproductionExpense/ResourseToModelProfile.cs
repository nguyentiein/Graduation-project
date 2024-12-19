using AutoMapper;
using FPM.Resourses.DTOs.PostproductionExpense.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Mapping.PostproductionExpense
{
    public sealed class ResourseToModelProfile : Profile
    {
        public ResourseToModelProfile()
        {
            CreateMap<CreatePostproductionExpenseRequest, Core.Entities.PostproductionExpense>();
            
        }
    }
}
