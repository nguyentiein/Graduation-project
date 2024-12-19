using FPM.Resourses.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.PreproductionPlaning.Request
{
    public class CreatePreproductionMemberRequest
    {
        [Required]
        public int PreProductionId { get; set; }
        [Required]
        public int MemberId { get; set; }
        [Required]
        public decimal Salary { get; set; }
        [Required]
        public SalaryTypeEnum SalaryType { get; set; }

        public string? Description { get; set; }
    }
}
