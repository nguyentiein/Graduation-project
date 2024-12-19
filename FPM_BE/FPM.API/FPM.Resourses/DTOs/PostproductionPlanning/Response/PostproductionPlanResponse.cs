using FPM.Resourses.DTOs.Broadcasting.Response;
using FPM.Resourses.DTOs.PostproductionExpense.Response;
using FPM.Resourses.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.PostproductionPlanning.Response
{
    public class PostproductionPlanResponse
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("PreProductionId")]
        public int? PreProductionId { get; set; }

        [JsonPropertyName("DirectorId")]
        public int CreateBy { get; set; }
        [JsonPropertyName("DirectorName")]
        public string? DirectorName { get; set; }
        [JsonPropertyName("FromDate")]
        public DateTime? FromDate { get; set; }
        [JsonPropertyName("ToDate")]
        public DateTime? ToDate { get; set; }
        [JsonPropertyName("WorkContent")]
        public string? WorkContent { get; set; }
        [JsonPropertyName("Budget")]
        public decimal? Budget { get; set; }
        [JsonPropertyName("Status")]
        public PostproductionStatusEnum? Status { get; set; }// 0:not yet, 1: processing, 2: finish
        [JsonPropertyName("CloseDate")]
        public DateTime? CloseDate { get; set; }
        [JsonPropertyName("CloseReason")]
        public string? CloseReason { get; set; }
        [JsonPropertyName("CloseNote")]
        public string? CloseNote { get; set; }

        [JsonPropertyName("Process")]
        public float Process {  get; set; }
        [JsonPropertyName("Broadcastings")]
        public IEnumerable<BroadcastingResponse>? Broadcastings { get; set; }
    }

    public class PostproductionPlanDetailResponse
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("PreProductionId")]
        public int? PreProductionId { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("FromDate")]
        public DateTime? FromDate { get; set; }
        [JsonPropertyName("ToDate")]
        public DateTime? ToDate { get; set; }
        [JsonPropertyName("WorkContent")]
        public string? WorkContent { get; set; }
        [JsonPropertyName("Budget")]
        public decimal? Budget { get; set; }
        [JsonPropertyName("Status")]
        public string Status { get; set; }// 0:not yet, 1: processing, 2: finish
        public DateTime? CloseDate { get; set; }
        [JsonPropertyName("CloseReason")]
        public string? CloseReason { get; set; }
        [JsonPropertyName("CloseNote")]
        public string? CloseNote { get; set; }
        //chi phí kịch bản
        [JsonPropertyName("ScriptFee")]
        public decimal? ScriptFee { get; set; }

        //chi  phí cảnh quay
        [JsonPropertyName("CameramanFee")]
        public decimal CameramanFee { get; set; }

        //chi phí chỉnh sửa cảnh quay
        [JsonPropertyName("EditorFee")]
        public decimal EditorFee { get; set; }
        //chi phí nhân sự
        [JsonPropertyName("HumanFee")]
        public decimal HumanFee { get; set; }
        
        //postProductionExpense
        [JsonPropertyName("OtherFee")]
        public decimal? OtherFee { get; set; }
    }


}
