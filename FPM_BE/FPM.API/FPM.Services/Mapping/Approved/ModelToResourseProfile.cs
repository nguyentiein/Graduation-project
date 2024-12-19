using AutoMapper;
using FPM.Resourses.DTOs.Approved.Reponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Mapping.Approveds
{
    public class ModelToResourseProfile:Profile
    {
        public ModelToResourseProfile() { 
           CreateMap<Core.Entities.Approved
            ,ApprovedsReponse>();
        }
    }
}
