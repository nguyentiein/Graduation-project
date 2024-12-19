using FPM.Resourses.DTOs.PostproductionPlanning.Response;
using FPM.Resourses.DTOs.User.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.PostproductionExpense.Response
{
    public class PostproductionExpenseResponse
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; } //
        [JsonPropertyName("TaskName")]
        public string? TaskName { get; set; } //
        [JsonPropertyName("Description")]
        public string? Description { get; set; } //
        [JsonPropertyName("TimeEstimate")]
        public decimal? TimeEstimate { get; set; } //
        [JsonPropertyName("HumanResourceEstimate")]
        public decimal? HumanResourceEstimate { get; set; } //
        [JsonPropertyName("OtherResourceEstimate")]
        public decimal? OtherResourceEstimate { get; set; } //
        [JsonPropertyName("Phase")]
        public int? Phase { get; set; } //
        [JsonPropertyName("TypeFilm")]
        public string? TypeFilm { get; set; } //

        // Thời lượng
        [JsonPropertyName("Duration")]
        public TimeSpan Duration { get; set; } 

        [JsonPropertyName("CreatedDate")]
        public DateTime? CreatedDate { get; set; }
        [JsonPropertyName("UpdatedDate")]
        public DateTime? UpdatedDate { get; set; }
        [JsonPropertyName("CreatedBy")]
        public virtual UserResponse? CreatedByNavigation { get; set; }
    }
}
