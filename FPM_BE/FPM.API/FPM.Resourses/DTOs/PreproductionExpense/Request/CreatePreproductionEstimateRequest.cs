using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.PreproductionExpense.Request
{
    public class CreatePreproductionEstimateRequest
    {
        public int? PreProductionId { get; set; }
        public int? SegmentId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? ExpenseTypeId { get; set; }
        public decimal? Amount { get; set; }
        public string? Reason { get; set; }
        public string? Note { get; set; }
    }
}
