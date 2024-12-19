using FPM.Resourses.DTOs.TopicDocument.Request;
using FPM.Resourses.DTOs.TopicDocument.Response;
using FPM.Resourses.Enums;
using FPM.Resourses.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.IServices
{
    public interface ITopicDocumentService
    {
        Task<BaseResult<TopicDocumentResponse>> CreateTopicDocumentAsync(int userId,CreateTopicDocumentRequest request,string webRootPath);

        Task<BaseResult<TopicDocumentResponse>> ApproveDocumentAsync(int topicDocumentId, DocumentStatusEnum documentStatus, int userId,string? comment);

        Task<BaseResult<IEnumerable<TopicDocumentResponse>>> SearchDocumentAsync(SearchDocumentModel request);

        Task<BaseResult<TopicDocumentResponse>> UpdateDocumentAsync(int userId,int topicDocumentId, UpdateDocumentRequest request,string webRootPath);

        Task<BaseResult<TopicDocumentResponse>> DeleteDocumentAsync(int topicDocumentId, string webRootPath);
    }
}
