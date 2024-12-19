using FPM.Resourses.Enums;
using System;
using System.Collections.Generic;

namespace FPM.Core.Entities
{
    public class PostproductionPlaning
    {
        public PostproductionPlaning()
        {
            Broadcastings = new HashSet<Broadcasting>();
            Movieapprovals = new HashSet<Movieapproval>();
            PostproductionProgresses = new HashSet<PostproductionProgress>();
            PostproductionExpenses = new HashSet<PostproductionExpense>();
        }

        public int Id { get; set; }
        public int? PreProductionId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? WorkContent { get; set; }
        public decimal? Budget { get; set; }
        public PostproductionStatusEnum? Status { get; set; }// 0:not yet, 1: processing, 2: finish
        public DateTime? CloseDate { get; set; }
        public string? CloseReason { get; set; }
        public string? CloseNote { get; set; }

        public decimal? OtherFee { get; set; }
        public virtual PreproductionPlaning? PreProduction { get; set; }
        public virtual ICollection<PostproductionExpense> PostproductionExpenses { get; set; }
        public virtual ICollection<Broadcasting> Broadcastings { get; set; }
        public virtual ICollection<Movieapproval> Movieapprovals { get; set; }
        public virtual ICollection<PostproductionProgress> PostproductionProgresses { get; set; }
    }
}
