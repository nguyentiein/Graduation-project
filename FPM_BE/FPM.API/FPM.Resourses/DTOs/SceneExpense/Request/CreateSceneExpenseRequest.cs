using FPM.Resourses.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.SceneExpense.Request
{
    public class CreateSceneExpenseRequest
    {
        [Required]
        public int SceneId { get; set; }
        [Required]
        public int? ExpenseTypeId { get; set; }
        [Required]
        public decimal? Amount { get; set; }
        public SceneExpenseTypeEnum Type { get; set; }
        public string? Reason { get; set; }
        public string? Note { get; set; }
    }
}
