using System;
using System.Collections.Generic;

namespace FPM.Core.Entities
{
    public class PreproductionPlaning
    {
        public PreproductionPlaning()
        {
           
            //PostproductionPlanings = new HashSet<PostproductionPlaning>();
            PreproductionEstimates = new HashSet<PreproductionEstimate>();
            PreproductionMembers = new HashSet<PreproductionMember>();
            //PreproductionProgresses = new HashSet<PreproductionProgress>();
            PreproductionSegments = new HashSet<PreproductionSegment>();
        }

        public int Id { get; set; }
        public int? TopicId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public decimal? Budget { get; set; }
        public int? ApprovedMember { get; set; }
        public int? Status { get; set; }
        public DateTime? CloseDate { get; set; }
        public decimal? CloseExpense { get; set; }
        public string? CloseNote { get; set; }
        public string? CloseReason { get; set; }
        public int? TeamId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Scenario { get; set; }
        public int? CategoryId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual User? ApprovedMemberNavigation { get; set; }
        public virtual Commoncategory? Category { get; set; }
        public virtual Team? Team { get; set; }
        public virtual Topic? Topic { get; set; }
        public virtual Estimate? Estimate { get; set; }
        public virtual PostproductionPlaning? PostproductionPlaning { get; set; }
        public virtual ICollection<PreproductionEstimate> PreproductionEstimates { get; set; }
        public virtual ICollection<PreproductionMember> PreproductionMembers { get; set; }
        public virtual PreproductionProgress? PreproductionProgress { get; set; }
        public virtual ICollection<PreproductionSegment> PreproductionSegments { get; set; }
    }
}
