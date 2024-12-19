using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.Topic.Request
{
    public class UpdateTopicRequest
    {
        public int Id { get; set; }
        public int? Type { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Scenario { get; set; }
        public int? Status { get; set; }
        public DateTime? EstimatedBegin { get; set; }
        public DateTime? EstimatedEnd { get; set; }
        public DateTime? EstimatedBroadcasting { get; set; }
        public decimal? EstimatedBudget { get; set; }

    }
}
