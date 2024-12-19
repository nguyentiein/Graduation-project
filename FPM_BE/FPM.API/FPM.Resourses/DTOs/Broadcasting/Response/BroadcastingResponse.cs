using FPM.Resourses.DTOs.CommonCategory.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.Broadcasting.Response
{
    public class BroadcastingResponse
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("PostProductionPlaningId")]
        public int? PostProductionPlaningId { get; set; }
        [JsonPropertyName("FilmName")]
        public string? FilmName { get; set; }
        [JsonPropertyName("BroadcastingTime")]
        public DateTime? BroadcastingTime { get; set; }
        [JsonPropertyName("Duration")]
        public long? Duration { get; set; }
        [JsonPropertyName("SubmissionTime")]
        public DateTime? SubmissionTime { get; set; }
        [JsonPropertyName("Reciever")]
        public string? Reciever { get; set; }
        [JsonPropertyName("ChannelId")]
        public int? ChannelId { get; set; }
        [JsonPropertyName("Channel")]
        public virtual CommonCategoryResponse? Channel { get; set; }
    }
}
