using FPM.Resourses.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.PreproductionPlaning.Request
{
    public class UpdatePreproductionMemberRequest
    {
        [JsonIgnore]
        public int Id { get; set; }
        public double? Salary { get; set; }
        public SalaryTypeEnum? SalaryType { get; set; }
        public string? Description { get; set; }
    }
}
