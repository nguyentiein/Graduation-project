using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.Segment.Request
{
    public class UpdateSegmentMemberRequest
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string? Role { get; set; }
        public string? Description { get; set; }
        public decimal? WorkingHour { get; set; }
    }


    public class SendRemindRequest
    {
      
        public int SegId { get; set; }
        public string? Note  { get; set; }
        public int planId { get; set; }
        public DateTime  Time { get; set; }
    }
}
