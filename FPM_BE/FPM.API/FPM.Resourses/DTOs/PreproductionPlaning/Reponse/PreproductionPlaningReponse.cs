using FPM.Resourses.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.PreproductionPlaning.Reponse
{
    public class PreproductionPlaningReponse
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("TopicId")]
        public int? TopicId { get; set; }

        [JsonPropertyName("CreatedBy")]
        public int? CreatedBy { get; set; }

        [JsonPropertyName("CreatedAt")]
        public DateTime? CreatedAt { get; set; }

        [JsonPropertyName("Budget")]
        public decimal? Budget { get; set; }

        [JsonPropertyName("ApprovedMember")]
        public int? ApprovedMember { get; set; }

        [JsonPropertyName("Status")]
        public int? Status { get; set; }

        [JsonPropertyName("CloseDate")]
        public DateTime? CloseDate { get; set; }

        [JsonPropertyName("CloseExpense")]
        public decimal? CloseExpense { get; set; }

        [JsonPropertyName("CloseNote")]
        public string? CloseNote { get; set; }

        [JsonPropertyName("CloseReason")]
        public string? CloseReason { get; set; }

        [JsonPropertyName("TeamId")]
        public int? TeamId { get; set; }

        [JsonPropertyName("Name")]
        public string? Name { get; set; }

        [JsonPropertyName("Description")]
        public string? Description { get; set; }

        [JsonPropertyName("Scenario")]
        public string? Scenario { get; set; }

        [JsonPropertyName("CategoryId")]
        public int? CategoryId { get; set; }
        [JsonPropertyName("Process")]
        public float Process { get; set; }

        [JsonPropertyName("Topic")]
        public virtual TopicDto? Topic { get; set; }

        [JsonPropertyName("Category")]
        public virtual CategoryDtto? Category { get; set; }

        [JsonPropertyName("Team")]
        public virtual TeamDto? Team { get; set; }

       


    }

    public class TopicDto
    {
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

    }


    public class TeamDto
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string? Name { get; set; }

        [JsonPropertyName("Description")]
        public string? Description { get; set; }

        [JsonPropertyName("LeaderId")]
        public int? LeaderId { get; set; }

        [JsonPropertyName("IsDeleted")]
        public bool IsDeleted { get; set; }
    }

    public class CategoryDtto
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

        [JsonPropertyName("IsDeleted")]
        public bool? IsDeleted { get; set; }



    }

}
