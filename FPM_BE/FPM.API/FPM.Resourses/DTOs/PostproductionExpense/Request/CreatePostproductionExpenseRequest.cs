using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.PostproductionExpense.Request
{
    public class CreatePostproductionExpenseRequest
    {
        [Required]
        public int? PostProductPlaningId { get; set; }
        [Required]
        public string? TaskName { get; set; } //
        public string? Description { get; set; } //
        public decimal? TimeEstimate { get; set; } //
        public decimal? HumanResourceEstimate { get; set; } //
        public decimal? OtherResourceEstimate { get; set; } //
        public int? Phase { get; set; } //
        public string? TypeFilm { get; set; } //

    }
}
