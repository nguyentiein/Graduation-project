
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace FPM.Resourses.DTOs.Team.Response
{
     
        public class TeamResponse
        {
            [JsonPropertyName("Id")]
            public int Id { get; set; }

            [JsonPropertyName("Name")]
            public string? Name { get; set; }

            [JsonPropertyName("Description")]
            public string? Description { get; set; }

            [JsonPropertyName("LeaderId")]
            public int? LeaderId { get; set; }

            [JsonPropertyName("Leader")]
            public virtual TeamUserDto? Leader { get; set; }

            [JsonPropertyName("TeamMembers")]
            public virtual ICollection<TeamMemmerDto>? TeamMembers { get; set; }
        }

        public class TeamUserDto
        {
            [JsonPropertyName("Id")]
            public int Id { get; set; }

            [JsonPropertyName("FirstName")]
            public string ?FirstName { get; set; }

            [JsonPropertyName("LastName")]
            public string ?LastName { get; set; }

            [JsonPropertyName("FullName")] 
            public string? FullName => $"{FirstName} {LastName}".Trim();

           [JsonPropertyName("Email")]
            public string ?Email { get; set; }
        }

        public class TeamMemmerDto
        {
            [JsonPropertyName("Id")]
            public int Id { get; set; }

            [JsonPropertyName("UserId")]
            public int? UserId { get; set; }

            [JsonPropertyName("TeamId")]
            public int? TeamId { get; set; }

            [JsonPropertyName("Role")]
            public string ?Role { get; set; }
        }

    }


