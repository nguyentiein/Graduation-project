using AutoMapper;
using FPM.Core.Entities;
using FPM.Resourses.DTOs.Team.Response;


namespace FPM.Services.Mapping.Teams
{
    public sealed class ModelToResourseProfile : Profile
    {
        public ModelToResourseProfile()
        {
            CreateMap<Team,TeamResponse>();

            CreateMap<Core.Entities.User,TeamUserDto>();

            CreateMap<TeamMember, TeamMemmerDto>();
          
        
        }
    }
}
