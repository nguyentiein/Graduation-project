using System;
using System.Collections.Generic;

namespace FPM.Core.Entities
{
    public class ReportProgress
    {
        public int Id { get; set; }
        public string? TopicName { get; set; }
        public int? Type { get; set; }
        public string? OutlineName { get; set; }
        public string? UserName { get; set; }
        public int? TopicStatus { get; set; }
        public int? OutlineStatus { get; set; }
        public int? PlanStatus { get; set; }
        public string? PreProductionPlanName { get; set; }
        public DateTime? MinEstimatedBegin { get; set; }
        public DateTime? EstimatedEnd { get; set; }
        public decimal? EstimatedBudget { get; set; }
        public DateTime? PostProductionFromDate { get; set; }
        public DateTime? PostProductionToDate { get; set; }
        public decimal? TotalProgress { get; set; }
        public bool? IsStatus { get; set; }
        public string? CombinedStatus { get; set; }
    }
}
