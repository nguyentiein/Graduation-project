using AutoMapper;
using FPM.Resourses.DTOs.Reminder;
using FPM.Resourses.DTOs.User.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Mapping.Reminders
{
    public class ModelToResourseProfile:Profile
    {
        public ModelToResourseProfile()
        {
            CreateMap<Core.Entities.PreproductionSegment,ReminderReponse>();
            CreateMap<Core.Entities.PreproductionsegmentMember, PreproductionsegmentMembersReponse>();
            CreateMap<Core.Entities.User, UserReponse>();
            CreateMap<Core.Entities.PreproductionPlaning, PreProductionReponse>();
        }
    }
}
