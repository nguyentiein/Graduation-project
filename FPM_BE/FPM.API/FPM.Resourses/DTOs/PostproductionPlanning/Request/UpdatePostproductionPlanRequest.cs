using FPM.Resourses.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.PostproductionPlanning.Request
{
    public class UpdatePostproductionPlanRequest
    {
        [JsonIgnore]
        public int Id { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? WorkContent { get; set; }
        public decimal? Budget { get; set; }
        public PostproductionStatusEnum? Status { get; set; }// 0:not yet, 1: processing, 2: finish
        public DateTime? CloseDate { get; set; }
        public string? CloseReason { get; set; }
        public string? CloseNote { get; set; }
        public decimal? OtherFee { get; set; }
    }
}
