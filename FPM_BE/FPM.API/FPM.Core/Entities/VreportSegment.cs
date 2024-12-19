using System;
using System.Collections.Generic;

namespace FPM.Core.Entities
{
    public class VreportSegment
    {
        public int Id { get; set; }
        public string? Scenario { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? ProvinceId { get; set; }
        public string? DistrictId { get; set; }
        public string? CommuneId { get; set; }
        public DateTime? EstimatedStartDateSegment { get; set; }
        public DateTime? EstimatedEndDateSegment { get; set; }
        public decimal? BudgetSegment { get; set; }
        public decimal? ExpenseProgress { get; set; }
        public int? SegmentStatus { get; set; }
        public decimal? SegmentProgress { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? StatusProgress { get; set; }
        public string? Note { get; set; }
    }
}
