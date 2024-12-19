using FPM.Resourses.DTOs.Video.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.Scene.Response
{
    public class SceneResponse
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("Name")]
        public string? Name { get; set; }
        [JsonPropertyName("Description")]
        public string? Description { get; set; }
        [JsonPropertyName("Budget")]
        public decimal? Budget { get; set; }
        [JsonPropertyName("CreatedDate")]
        public DateTime? CreatedDate { get; set; }
        [JsonPropertyName("UpdatedDate")]
        public DateTime? UpdatedDate { get; set; }
        [JsonPropertyName("Video")]
        public IEnumerable<VideoResponse>? VideoResponses { get; set; }
    }

    
}
