using FPM.Resourses.DTOs.CommonCategory.Response;
using FPM.Resourses.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.SceneExpense.Response
{
    public class SceneExpenseResponse
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("CreatedAt")]
        public DateTime? CreatedAt { get; set; }

        [JsonPropertyName("Type")]
        public SceneExpenseTypeEnum Type { get; set; }

        [JsonPropertyName("CreatedBy")]
        public int? CreatedBy { get; set; }


        [JsonPropertyName("ExpenseType")]
        public CommonCategoryResponse? ExpenseType { get; set; }


        [JsonPropertyName("Amount")]
        public decimal? Amount { get; set; }


        [JsonPropertyName("Reason")]
        public string? Reason { get; set; }

        [JsonPropertyName("Note")]
        public string? Note { get; set; }
    }
}
