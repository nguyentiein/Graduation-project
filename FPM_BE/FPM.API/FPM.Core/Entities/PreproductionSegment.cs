using System;
using System.Collections.Generic;

namespace FPM.Core.Entities
{
    public class PreproductionSegment
    {
        public PreproductionSegment()
        {
            PreproductionEstimates = new HashSet<PreproductionEstimate>();
            PreproductionProgresses = new HashSet<PreproductionProgress>();
            PreproductionsegmentMembers = new HashSet<PreproductionsegmentMember>();
            Scenes = new HashSet<Scene>();
        }

        public int Id { get; set; }
        public int? PreProductionId { get; set; }
        public string? Address { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public decimal? Budget { get; set; }
        public int? Status { get; set; }
        public string? Scenario { get; set; }
        public string? Description { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public virtual PreproductionPlaning? PreProduction { get; set; }
        public virtual ICollection<PreproductionEstimate> PreproductionEstimates { get; set; }
        public virtual ICollection<PreproductionProgress> PreproductionProgresses { get; set; }
        public virtual ICollection<PreproductionsegmentMember> PreproductionsegmentMembers { get; set; }
        public virtual ICollection<Scene> Scenes { get; set; }
    }
}
