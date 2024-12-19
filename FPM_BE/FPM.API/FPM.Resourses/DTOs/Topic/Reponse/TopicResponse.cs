using FPM.Resourses.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.Topic.Reponse
{
    public  class TopicResponse
    {
        
        [JsonPropertyName("category")]
        public CommonCategoryDto? category {  get; set; }

        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string? Name { get; set; }

        [JsonPropertyName("Description")]
        public string? Description { get; set; }

        [JsonPropertyName("Scenario")]
        public string? Scenario { get; set; }

        [JsonPropertyName("EstimatedBegin")]
        public DateTime? EstimatedBegin { get; set; }

        [JsonPropertyName("EstimatedEnd")]
        public DateTime? EstimatedEnd { get; set; }

        [JsonPropertyName("EstimatedBroadcasting")]
        public DateTime? EstimatedBroadcasting { get; set; }

        [JsonPropertyName("EstimatedBudget")]
        public decimal? EstimatedBudget { get; set; }

        [JsonPropertyName("CreatedAt")]
        public DateTime? CreatedAt { get; set; }

        [JsonPropertyName("CreatedBy")]
        public int? CreatedBy { get; set; }

        [JsonPropertyName("Status")]
        public int? Status { get; set; }

        [JsonPropertyName("Type")]
        public int? Type { get; set; }

        [JsonPropertyName("ParentId")]
        public int? ParentId { get; set; }

        [JsonPropertyName("Budget")]
        public decimal? Budget { get; set; }

        [JsonPropertyName("CategoryId")]
        public int? CategoryId { get; set; }

        [JsonPropertyName("TopicMembers")]
        public virtual ICollection<TopicMemberDto> TopicMembers { get; set; }

    }

    public class TopicMemberDto
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("TopicId")]
        public int? TopicId { get; set; }
        [JsonPropertyName("MemberId")]
        public int? MemberId { get; set; }
        [JsonPropertyName("Role")]
        public string? Role { get; set; }
        [JsonPropertyName("Description")]
        public string? Description { get; set; }
   
        [JsonPropertyName("FirstName")]
        public string? FirstName { get; set; }

        [JsonPropertyName("LastName")]
        public string? LastName { get; set; }

        [JsonPropertyName("AvatarUrl")]
        public string? AvatarUrl { get; set; }

        [JsonPropertyName("FullName")]
        public string? FullName { get; set; }



    }
    public class UserDto
    {
        [JsonPropertyName("FirstName")]
        public string? FirstName { get; set; }
        [JsonPropertyName("LastName")]
        public string? LastName { get; set; }
        [JsonPropertyName("AvatarUrl")]
        public string? AvatarUrl { get; set; }

        [JsonPropertyName("FullName")]
        
        public string? FullName
        {
            get => $"{FirstName} {LastName}".Trim();
        }


    }




    public class CommonCategoryDto
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string? Name { get; set; }

        [JsonPropertyName("Type")]
        public CommonCategoryEnum? Type { get; set; }

        [JsonPropertyName("Description")]
        public string? Description { get; set; }

        [JsonPropertyName("ParentId")]
        public int? ParentId { get; set; }

    }
}
