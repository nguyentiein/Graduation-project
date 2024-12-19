using AutoMapper;
using FPM.Core.Entities;
using FPM.Resourses.DTOs.Test.Response;

namespace FPM.Services.Mapping;

public sealed class ModelToResourseProfile : Profile
{
    public ModelToResourseProfile() {
        CreateMap<Test, TestResponse>();
    
    }
}
