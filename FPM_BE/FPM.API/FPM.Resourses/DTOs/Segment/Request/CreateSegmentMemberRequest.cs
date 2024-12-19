using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.Segment.Request
{
    public class CreateSegmentMemberRequest
    {
        [Required]
        public int PreProductionSegmentId { get; set; }
        [Required]
        public int PreproductionPlanMemberId { get; set; }
        [Required]
        public string? Role { get; set; }
        public string? Description { get; set; }
    }
}
