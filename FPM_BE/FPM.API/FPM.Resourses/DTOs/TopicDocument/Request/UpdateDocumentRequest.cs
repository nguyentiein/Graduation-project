using FPM.Resourses.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.TopicDocument.Request
{
    public class UpdateDocumentRequest
    {
        public string? Description { get; set; }

        [NotMapped]
        
        public IFormFile? File { get; set; }
    }

    public class ApproveDocumentRequest
    {
        [JsonIgnore]
        public int Id { get; set; }

        public DocumentStatusEnum Status { get; set; }

        public string? Comment { get; set; }
    }
}
