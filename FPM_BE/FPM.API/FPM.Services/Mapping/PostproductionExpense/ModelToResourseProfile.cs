using AutoMapper;
using FPM.Resourses.DTOs.PostproductionExpense.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Mapping.PostproductionExpense
{
    public sealed class ModelToResourseProfile : Profile
    {
        public ModelToResourseProfile()
        {
            CreateMap<Core.Entities.PostproductionExpense, PostproductionExpenseResponse>();
        }
    }
}
