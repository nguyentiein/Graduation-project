using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.Segment.Request
{
    public class UpdateSegmentRequest
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string? Address { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public decimal? Budget { get; set; }
        public int? Status { get; set; }
        public string? Scenario { get; set; }
        public string? Description { get; set; }
    }
}
