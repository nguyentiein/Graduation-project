using FPM.Core.Entities;
using System;
using System.Collections.Generic;

namespace FPM.Core.Entities
{
    public class PreproductionsegmentMember
    {
        public int Id { get; set; }
        public int? PreProductionSegmentId { get; set; }
        public int? UserId { get; set; }
        public string? Role { get; set; }
        public string? Description { get; set; }
        public decimal? WorkingHour { get; set; }
        public int? PlanMemberId { get; set; }
        public virtual PreproductionMember? PreproductionMember { get; set; }
        public virtual PreproductionSegment? PreProductionSegment { get; set; }
        public virtual User? User { get; set; }
    }
}
