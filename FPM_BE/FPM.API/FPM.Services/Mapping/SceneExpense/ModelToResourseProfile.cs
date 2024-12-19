using AutoMapper;
using FPM.Resourses.DTOs.SceneExpense.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Mapping.SceneExpense
{
    public sealed class ModelToResourseProfile : Profile
    {
        public ModelToResourseProfile()
        {
            CreateMap<Core.Entities.SceneExpense, SceneExpenseResponse>()
                .ForMember(x => x.ExpenseType, opt => opt.MapFrom(src => src.ExpenseType));
        }
    }
}
