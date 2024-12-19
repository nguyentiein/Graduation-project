using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.SceneExpense.Request
{
    public class UpdateSceneExpenseRequest
    {
        [JsonIgnore]
        public int Id { get; set; }
        
        public int? ExpenseTypeId { get; set; }
        public decimal? Amount { get; set; }
        public string? Reason { get; set; }
        public string? Note { get; set; }
    }
}
