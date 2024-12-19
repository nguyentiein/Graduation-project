using AutoMapper;
using FPM.Resourses.DTOs.SceneExpense.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Mapping.SceneExpense
{
    public sealed class ResourseToModelProfile : Profile
    {
        public ResourseToModelProfile()
        {
            CreateMap<CreateSceneExpenseRequest, Core.Entities.SceneExpense>();
            CreateMap<UpdateSceneExpenseRequest, Core.Entities.SceneExpense>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        }
    }
}
