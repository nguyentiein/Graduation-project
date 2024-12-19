using System;
using System.Collections.Generic;

namespace FPM.Core.Entities
{
    public class PreproductionProgress
    {
        public PreproductionProgress()
        {
            PreproductionprogressMembers = new HashSet<PreproductionprogressMember>();
        }

        public int Id { get; set; }
        public int? PreProductionId { get; set; }
        public int? SegmentId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? FromDate { get; set; }
        public string? Note { get; set; }
        public decimal? SegmentProgress { get; set; }
        public decimal? TotalProgress { get; set; }
        public DateTime? ToDate { get; set; }
        public decimal? Expense { get; set; }
        /// <summary>
        /// 0: New; 1 : Duyet; -1: Tu choi
        /// </summary>
        public int? Status { get; set; }
        public int? ExpenseType { get; set; }

        public virtual Commoncategory? ExpenseTypeNavigation { get; set; }
        public virtual PreproductionPlaning? PreProduction { get; set; }
        public virtual PreproductionSegment? Segment { get; set; }
        public virtual ICollection<PreproductionprogressMember> PreproductionprogressMembers { get; set; }
    }
}
