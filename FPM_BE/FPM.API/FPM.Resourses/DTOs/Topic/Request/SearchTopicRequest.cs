using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.Topic.Request
{
    public class SearchTopicRequest
    {

        [Required]
        public int Type { get; set; }

        public int? ParentId { get; set; }
    }
}
