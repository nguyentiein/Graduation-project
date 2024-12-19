using AutoMapper;
using FPM.Core.Entities;
using FPM.Resourses.DTOs.PreproductionPlaning.Reponse;
using FPM.Resourses.DTOs.PreproductionPlaning.Request;
using FPM.Resourses.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Mapping.PreproductionMember
{
    public sealed class ModelToResourseProfile : Profile
    {
        public ModelToResourseProfile() 
        {
            CreateMap<Core.Entities.PreproductionMember, PreproductionMemberResponse>()
                .ForMember(x => x.FullName, opt => opt.MapFrom(src => string.Concat(src.Member.LastName, " ", src.Member.FirstName)));
                //.ForMember(x => x.TotalSalary,opt => opt.MapFrom(src => GetSumSalary(src.Salary, src.SalaryType,src.TotalWorkingHour)));
        }

        private static decimal GetSumSalary(decimal salary, SalaryTypeEnum type,decimal workingHour)
        {
            decimal sumSalary = 0;

            switch (type)
            {
                case SalaryTypeEnum.Hour:
                    sumSalary = salary*workingHour;
                break;

                case SalaryTypeEnum.Day: 
                    sumSalary = (salary/24)*workingHour ;
                break;

                case SalaryTypeEnum.Month:
                    sumSalary = (salary/(24*30))*workingHour;
                break;

                case SalaryTypeEnum.Week:
                    sumSalary = (salary/(24*7))*workingHour;
                break;
            }
            return sumSalary;
        }
    }
}
