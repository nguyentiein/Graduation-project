using FPM.Resourses.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.Video.Request
{
    public class SearchVideoRequest
    {
        [Required]
        public int ObjectId { get; set; }
        [Required]
        public VideoTypeEnum ObjectType { get; set; }
    }
}
