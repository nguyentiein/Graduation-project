using System;
using System.Collections.Generic;

namespace FPM.Core.Entities
{
    public class PostproductionprogressMember
    {
        public int Id { get; set; }
        public int? PostProductionProgressId { get; set; }
        public int? UserId { get; set; }
        public string? Role { get; set; }
        public string? Comment { get; set; }
        public int? Status { get; set; }
        public decimal? PercentCompleted { get; set; }

        public virtual PostproductionProgress? PostProductionProgress { get; set; }
        public virtual User? User { get; set; }
    }
}
