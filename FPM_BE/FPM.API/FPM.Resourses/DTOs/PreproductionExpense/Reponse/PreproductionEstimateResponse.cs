using FPM.Resourses.DTOs.CommonCategory.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.PreproductionExpense.Reponse
{
    public class PreproductionEstimateResponse
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }


        [JsonPropertyName("PreProductionId")]
        public int? PreProductionId { get; set; }


        [JsonPropertyName("SegmentId")]
        public int? SegmentId { get; set; }


        [JsonPropertyName("CreatedAt")]
        public DateTime? CreatedAt { get; set; }


        [JsonPropertyName("CreatedBy")]
        public int? CreatedBy { get; set; }


        [JsonPropertyName("ExpenseType")]
        public CommonCategoryResponse? ExpenseType { get; set; }


        [JsonPropertyName("Amount")]
        public decimal? Amount { get; set; }


        [JsonPropertyName("Reason")]
        public string? Reason { get; set; }



        [JsonPropertyName("Note")]
        public string? Note { get; set; }

        //public virtual PreproductionPlaning? PreProduction { get; set; }
        //public virtual PreproductionSegment? Segment { get; set; }

        
    }

    
}
