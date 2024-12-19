using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.Video.Response
{
    public class VideoResponse
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("No")]
        public int? No { get; set; }
        [JsonPropertyName("VideoName")]
        public string? VideoName { get; set; }
        [JsonPropertyName("Url")]
        public string? VideoUrl { get; set; }
        [JsonPropertyName("VideoLength")]
        public decimal? VideoLength { get; set; }
        [JsonPropertyName("VideoSize")]
        public decimal? VideoSize { get; set; }
        [JsonPropertyName("CreatedDate")]
        public DateTime? CreatedDate { get; set; }
    }
}
