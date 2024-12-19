using FPM.Resourses.DTOs.Topic.Reponse;
using FPM.Resourses.DTOs.Topic.Request;
using FPM.Resourses.Results;


namespace FPM.Services.IServices
{
    public interface ITopicServices
    {
        public Task<BaseResult<IEnumerable<TopicResponse>>> GetTopicByTypeAsync(SearchTopicRequest request);
        Task<BaseResult<TopicResponse>> CreateNewTopicAsync(int userId, CreateTopicRequest request);
        Task<BaseResult<TopicResponse>> DeleteAsync(int id);
        Task<BaseResult<TopicResponse>> UpdateTopicAsync(UpdateTopicRequest request);
        Task<BaseResult<IEnumerable<TopicResponse>>> GetTopicByIdAsync(int id);
    }
}
