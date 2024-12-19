using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.TeamMember.Reponse
{
    public class TeamMemberReponse
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("UserId")]
        public int? UserId { get; set; }

        [JsonPropertyName("TeamId")]
        public int? TeamId { get; set; }

        [JsonPropertyName("Role")]
        public string? Role { get; set; }
    }
}
