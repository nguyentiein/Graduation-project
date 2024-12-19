using FPM.Resourses.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.CommonCategory.Request
{
    public class UpdateCommonCategoryRequest
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string? Name { get; set; }
        public CommonCategoryEnum? Type { get; set; }
        public string? Description { get; set; }
        public int? ParentId { get; set; }
    }
}
