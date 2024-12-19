using FPM.Resourses.DTOs.TeamMember.Reponse;
using FPM.Resourses.DTOs.TeamMember.Request;
using FPM.Resourses.DTOs.Topic.Reponse;
using FPM.Resourses.DTOs.TopicMember.Reponse;
using FPM.Resourses.DTOs.TopicMember.Request;
using FPM.Resourses.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.IServices
{
    public  interface ITopicMemberService
    {
        Task<BaseResult<TopicMemberResponse>> CreateNewTopicMemberAsync(CreateTopicMemberRequest request);
        Task<BaseResult<TopicMemberResponse>> DeleteAsync(int id);
        Task<BaseResult<IEnumerable<TopicMemberResponse>>> GetTopicMemberByTopicId(int id);
    }
}
