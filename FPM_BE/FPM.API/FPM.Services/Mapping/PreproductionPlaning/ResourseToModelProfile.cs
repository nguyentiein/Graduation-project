using AutoMapper;
using FPM.Core.Entities;
using FPM.Resourses.DTOs.PreproductionPlaning.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Mapping.PreproductionPlanings
{
    public  class ResourseToModelProfile:Profile
    {
        public ResourseToModelProfile()
        {
            CreateMap<CreatePreproductionPlaningRequest, PreproductionPlaning>();
            CreateMap<UpdatePreproductionPlaningRequest,PreproductionPlaning>();

        }
    }
}
