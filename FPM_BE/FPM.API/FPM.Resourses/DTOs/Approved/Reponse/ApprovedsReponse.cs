using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.Approved.Reponse
{
    public  class ApprovedsReponse
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("ObjectId")]
        public int? ObjectId { get; set; } // id of topic or outline

        [JsonPropertyName("ProcessedAt")]
        public DateTime? ProcessedAt { get; set; }

        [JsonPropertyName("ProcessedBy")]
        public int? ProcessedBy { get; set; }

        [JsonPropertyName("Comment")]
        public string? Comment { get; set; } // leader's comment

        [JsonPropertyName("Result")]
        public int? Result { get; set; } // 0 = pending, 1 = approved, 2 = rejected

        [JsonPropertyName("ObjectType")]
        public int? ObjectType { get; set; } // 1 = topic, 2 = outline
    }
}
