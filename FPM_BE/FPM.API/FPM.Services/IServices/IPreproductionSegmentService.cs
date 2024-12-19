using FPM.Resourses.DTOs.Reminder;
using FPM.Resourses.DTOs.Segment.Request;
using FPM.Resourses.DTOs.Segment.Response;
using FPM.Resourses.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.IServices
{
    public interface IPreproductionSegmentService
    {
        Task<BaseResult<IEnumerable<PreproductionSegmentResponse>>> GetAllAsync(int preproductionSegment);

        Task<BaseResult<PreproductionSegmentResponse>> CreateAsync(CreateSegmentRequest request);

        Task<BaseResult<PreproductionSegmentResponse>> DeleteAsync(int segmentId);

        Task<BaseResult<PreproductionSegmentResponse>> UpdateAsync(UpdateSegmentRequest request);

        Task<BaseResult<PreproductionSegmentMemberResponse>> AddMemberAsync(CreateSegmentMemberRequest request);

        Task<BaseResult<PreproductionSegmentMemberResponse>> UpdateMemberAsync(UpdateSegmentMemberRequest request);

        Task<BaseResult<PreproductionSegmentMemberResponse>> RemoveMemberAsync(int segmentMemberId);
        Task<BaseResult<PreproductionSegmentResponse>> GetAllSegmentInPreproductionByIdSeg(int id);
        Task<BaseResult<IEnumerable<ReminderReponse>>> SendMailReminderAsync(SendRemindRequest remindRequest);
    }
}
