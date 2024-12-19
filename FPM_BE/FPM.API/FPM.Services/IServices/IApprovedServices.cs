using FPM.Resourses.DTOs.Approved.Reponse;
using FPM.Resourses.DTOs.Approved.Request;
using FPM.Resourses.DTOs.CommonCategory.Response;
using FPM.Resourses.DTOs.Topic.Reponse;
using FPM.Resourses.DTOs.TopicMember.Reponse;
using FPM.Resourses.DTOs.TopicMember.Request;
using FPM.Resourses.Enums;
using FPM.Resourses.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.IServices
{
    public  interface IApprovedServices
    {
        Task<BaseResult<IEnumerable<ApprovedsReponse>>> GetApprovedByObjectIdAsync(int id);
        Task<BaseResult<IEnumerable<ApprovedsReponse>>> GetApprovedByObjectTypeAndObjectIdAsync(ApproveObjectTypeEnum typeId, int objectId);
        Task<BaseResult<ApprovedsReponse>> CreateApprovedAsync(CreateApprovedRequest request);

        Task<BaseResult<IEnumerable<ApprovedsReponse>>> GetApprovedByObjectTypeAsync(ApproveObjectTypeEnum id);


    }
}
