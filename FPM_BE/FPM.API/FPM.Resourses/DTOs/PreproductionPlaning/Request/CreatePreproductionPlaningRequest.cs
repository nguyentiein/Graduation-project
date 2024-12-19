using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.PreproductionPlaning.Request
{
    public class CreatePreproductionPlaningRequest
    {
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

    }
}
