using FPM.Resourses.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.Video.Request
{
    public class CreateVideoRequest
    {
        [Required]
        public int ObjectId {  get; set; }
        [Required]
        public VideoTypeEnum ObjectType { get; set; }
        [Required]
        public string VideoName { get; set; }

        public string? Description {  get; set; }

        [NotMapped]
        public IFormFile File { get; set; }

    }
}
