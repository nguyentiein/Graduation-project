using FPM.Resourses.DTOs.User.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.Segment.Response
{
    public class PreproductionSegmentResponse
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("Preproduction")]
        public int? PreProductionId { get; set; }
        [JsonPropertyName("Address")]
        public string? Address { get; set; }
        [JsonPropertyName("FromDate")]
        public DateTime? FromDate { get; set; }
        [JsonPropertyName("ToDate")]
        public DateTime? ToDate { get; set; }
        [JsonPropertyName("Budget")]
        public decimal? Budget { get; set; }
        [JsonPropertyName("EstimateFee")]
        public decimal? EstimateFee { get; set; }
        [JsonPropertyName("factFee")]
        public decimal? factFee { get; set; }
        [JsonPropertyName("Status")]
        public int? Status { get; set; }
        [JsonPropertyName("Scenario")]
        public string? Scenario { get; set; }
        [JsonPropertyName("Description")]
        public string? Description { get; set; }
        [JsonPropertyName("CreatedDate")]
        public DateTime? CreatedDate { get; set; }
        [JsonPropertyName("UpdatedDate")]
        public DateTime? UpdatedDate { get; set; }
        [JsonPropertyName("PreproductionSegmentMembers")]
        public IEnumerable<PreproductionSegmentMemberResponse>? SegmentMembers {  get; set; }
    }
    
    public class PreproductionSegmentMemberResponse
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("FullName")]
        public string? FullName { get; set; }
        [JsonPropertyName("Role")]
        public string? Role { get; set; }
        [JsonPropertyName("Description")]
        public string? Description { get; set; }
        [JsonPropertyName("WorkingHour")]
        public decimal? WorkingHour { get; set; }
        [JsonPropertyName("UserId")]
        public int? UserId { get; set; }
    }

}
