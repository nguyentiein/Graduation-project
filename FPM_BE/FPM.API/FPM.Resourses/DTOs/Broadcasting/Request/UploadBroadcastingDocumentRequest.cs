using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.Broadcasting.Request
{
    public class UploadBroadcastingDocumentRequest
    {
        [Required]
        public int BroadcastingId { get; set; }
        [Required]
        public string FileName { get; set; }
        public string? Description { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }
    }
}
