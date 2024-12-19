using AutoMapper;
using FPM.Core.Entities;
using FPM.Resourses.DTOs.Estimate.Request;
using FPM.Resourses.DTOs.PreproductionPlaning.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Mapping.Estimates
{
    public class ResourseToModelProfile:Profile
    {
        public ResourseToModelProfile()
        {
            CreateMap<CreateEstimateRequest, Estimate>();
            CreateMap<UpdateEstimateRequest, Estimate>();
        }
    }
}
