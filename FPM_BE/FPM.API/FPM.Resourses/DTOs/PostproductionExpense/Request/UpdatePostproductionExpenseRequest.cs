using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.PostproductionExpense.Request
{
    public class UpdatePostproductionExpenseRequest
    {
        public string? TaskName { get; set; } //

        public string? Description { get; set; } //

        public decimal? TimeEstimate { get; set; } //

        public decimal? OtherResourceEstimate { get; set; } //

        public int? Phase { get; set; } //

        public string? TypeFilm { get; set; } //

        public TimeSpan? Duration { get; set; } //
    }
}
