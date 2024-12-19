using FPM.Resourses.Enums;
using System;
using System.Collections.Generic;

namespace FPM.Core.Entities
{
    public class PreproductionMember
    {
        public PreproductionMember()
        {
            SegmentMembers = new HashSet<PreproductionsegmentMember>();
        }

        public int Id { get; set; }
        public int? PreProductionId { get; set; }
        public int? MemberId { get; set; }
        public decimal Salary { get; set; }
        public SalaryTypeEnum SalaryType { get; set; }
        public decimal TotalWorkingHour { get; set; }
        public decimal TotalSalary { get; set; }
        public string? Description { get; set; }
        public virtual User? Member { get; set; }

        public virtual PreproductionPlaning? PreProduction { get; set; }
        public virtual ICollection<PreproductionsegmentMember> SegmentMembers { get; set; }
    }
}
