using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.Segment.Request
{
    public class CreateSegmentRequest
    {
        [Required]
        public int? PreProductionId { get; set; }
        public string? Address { get; set; }
        [Required]
        public DateTime? FromDate { get; set; }
        [Required]
        public DateTime? ToDate { get; set; }
        public decimal? Budget { get; set; }
        public int? Status { get; set; }
        public string? Scenario { get; set; }
        public string? Description { get; set; }
    }
}
