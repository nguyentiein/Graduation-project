using AutoMapper;
using FPM.Core.Entities;
using FPM.Resourses.DTOs.Estimate.Reponse;
using FPM.Resourses.DTOs.PreproductionPlaning.Reponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Mapping.Estimates
{
    public  class ModelToResourseProfile:Profile
    {
        public ModelToResourseProfile()
        {
            CreateMap<Core.Entities.Estimate, EstimateResponse>();

        }
    }

}
