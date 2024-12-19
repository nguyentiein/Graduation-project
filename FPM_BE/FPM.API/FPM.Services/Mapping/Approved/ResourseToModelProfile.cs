using AutoMapper;
using FPM.Resourses.DTOs.Approved.Request;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Mapping.Approveds
{
    public class ResourseToModelProfile:Profile
    {
        public ResourseToModelProfile()
        { 
            CreateMap<CreateApprovedRequest, Core.Entities.Approved>();
        }
    }
}
