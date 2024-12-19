using System;
using System.Collections.Generic;

namespace FPM.Core.Entities
{
    public class MovieapprovalDetail
    {
        public int Id { get; set; }
        public int? MovieApprovalId { get; set; }
        public int? UserId { get; set; }
        public string? Comment { get; set; }
        public string? Suggested { get; set; }
        public int? Status { get; set; }
        public string? Role { get; set; }

        public virtual Movieapproval? MovieApproval { get; set; }
        public virtual User? User { get; set; }
    }
}
