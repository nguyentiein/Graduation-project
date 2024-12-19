using AutoMapper;
using FPM.Core.Entities;
using FPM.Resourses.DTOs.Segment.Response;
using FPM.Resourses.DTOs.User.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Mapping.PreproductionSegment
{
    public sealed class ModelToResourseProfile : Profile
    {
        public ModelToResourseProfile()
        {
            CreateMap<Core.Entities.PreproductionSegment, PreproductionSegmentResponse>()
                .ForMember(x => x.SegmentMembers,opt => opt.MapFrom(src => src.PreproductionsegmentMembers))
                .ForMember(x => x.EstimateFee,opt => opt.MapFrom(src => GetEstimateFee(src.PreproductionEstimates)))
                .ForMember(x => x.factFee,opt => opt.MapFrom(src => GetFactFee(src.Scenes.SelectMany(s => s.SceneExpenses))));

            CreateMap<Core.Entities.PreproductionsegmentMember, PreproductionSegmentMemberResponse>()
                .ForMember(x => x.FullName,opt => opt.MapFrom(src => string.Concat(src.User.LastName," ",src.User.FirstName)))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }

        #region PrivateWork
        private decimal GetEstimateFee(IEnumerable<PreproductionEstimate>? segmentEstimate)
        {
            decimal total = 0;
            total += segmentEstimate.Select(x => x.Amount).Sum().GetValueOrDefault();

            return total;

        }

        private decimal GetFactFee(IEnumerable<Core.Entities.SceneExpense>? sceneExpenses)
        {
            decimal total = 0;
            return total += sceneExpenses.Select(x => x.Amount).Sum().GetValueOrDefault();
        }
        #endregion
    }
}
