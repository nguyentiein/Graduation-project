using System;
using System.Collections.Generic;

namespace FPM.Core.Entities
{
    public class Movieapproval
    {
        public Movieapproval()
        {
            MovieapprovalDetails = new HashSet<MovieapprovalDetail>();
        }

        public int Id { get; set; }
        public int? PostProductionPlaningId { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string? Content { get; set; }
        public string? Comment { get; set; }
        public string? Suggested { get; set; }
        public int? Status { get; set; }
        public int? No { get; set; }
        public DateTime? StartAt { get; set; }
        public DateTime? EndAt { get; set; }

        public virtual PostproductionPlaning? PostProductionPlaning { get; set; }
        public virtual ICollection<MovieapprovalDetail> MovieapprovalDetails { get; set; }
    }
}
