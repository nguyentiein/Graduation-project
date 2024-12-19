using System;
using System.Collections.Generic;

namespace FPM.Core.Entities
{
    public class PreproductionEstimate
    {
        public int Id { get; set; }
        public int? PreProductionId { get; set; }
        public int? SegmentId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? ExpenseTypeId { get; set; }
        public decimal? Amount { get; set; }
        public string? Reason { get; set; }
        public string? Note { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Commoncategory?  ExpenseType { get; set; }

        public virtual PreproductionPlaning? PreProduction { get; set; }
        public virtual PreproductionSegment? Segment { get; set; }
    }
}
