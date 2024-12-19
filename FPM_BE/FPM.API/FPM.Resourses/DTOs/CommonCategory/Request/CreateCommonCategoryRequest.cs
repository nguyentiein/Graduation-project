using FPM.Resourses.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.CommonCategory.Request
{
    public class CreateCommonCategoryRequest
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }

        [Required]
        public CommonCategoryEnum Type { get; set; }

        public int? ParentId { get; set; }
    }
}
