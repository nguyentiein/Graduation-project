using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.TopicMember.Reponse
{
    public class TopicMemberResponse
    {
     

        [JsonPropertyName("TopicId")]
        public int? TopicId { get; set; }

        [JsonPropertyName("MemberId")]
        public int? MemberId { get; set; }

        [JsonPropertyName("Role")]
        public string? Role { get; set; }

        [JsonPropertyName("Description")]
        public string? Description { get; set; }
    }
}
