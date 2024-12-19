using System;
using System.Collections.Generic;

namespace FPM.Core.Entities
{
    public class ReportCost
    {
        public int Id { get; set; }
        public string? TopicName { get; set; }
        public int? Type { get; set; }
        public string? OutName { get; set; }
        public string? UserName { get; set; }
        public string? PreProductionPlanName { get; set; }
        public DateTime? MinEstimatedBegin { get; set; }
        public DateTime? EstimatedEnd { get; set; }
        public decimal? EstimatedBudget { get; set; }
        public DateTime? PostProductionFromDate { get; set; }
        public DateTime? PostProductionToDate { get; set; }
        public decimal? SumExpense { get; set; }
        public decimal? ExpenseDifference { get; set; }
        public decimal? PercentageDifference { get; set; }
    }
}
