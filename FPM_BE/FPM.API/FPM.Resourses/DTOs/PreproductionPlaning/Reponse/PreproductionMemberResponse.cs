using FPM.Resourses.DTOs.User.Response;
using FPM.Resourses.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.PreproductionPlaning.Reponse
{
    public class PreproductionMemberResponse
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("FullName")]
        public string FullName { get; set; }

        [JsonPropertyName("Salary")]
        public double? Salary { get; set; }
        [JsonPropertyName("SalaryType")]
        public SalaryTypeEnum SalaryType { get; set; }

        [JsonPropertyName("WorkingHour")]
        public decimal? WorkingHour { get; set; }

        [JsonPropertyName("SumSalary")]
        public decimal? TotalSalary { get; set; }

        [JsonPropertyName("Description")]
        public string? Description { get; set; }
        [JsonPropertyName("MemberId")]
        public int? MemberId { get; set; }

    }
}
