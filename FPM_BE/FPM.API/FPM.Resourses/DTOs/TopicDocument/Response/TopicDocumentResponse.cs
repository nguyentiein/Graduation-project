using FPM.Resourses.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.TopicDocument.Response
{
    public class TopicDocumentResponse
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Description")]
        public string? Description { get; set; }

        [JsonPropertyName("CreateBy")]
        public int? CreateBy { get; set; }

        [JsonPropertyName("Status")]
        public string Status { get; set; }

        [JsonPropertyName("FileUrl")]
        public string? FileUrl { get; set; }

        [JsonPropertyName("FileName")]
        public string? FileName { get; set; }
        [JsonPropertyName("CreatedDate")]
        public DateTime? CreatedDate { get; set; }
    }
}
