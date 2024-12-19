using AutoMapper;
using FPM.Core.Entities;
using FPM.Resourses.DTOs.Scene.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Mapping.Scene
{
    public sealed class ModelToResourseProfile : Profile
    {
        public ModelToResourseProfile() {
            CreateMap<Core.Entities.Scene, SceneResponse>();
        }
    }
}
