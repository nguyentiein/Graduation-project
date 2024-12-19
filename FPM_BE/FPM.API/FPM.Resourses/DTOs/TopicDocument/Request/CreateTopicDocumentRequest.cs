using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.TopicDocument.Request
{
    public class CreateTopicDocumentRequest
    {
        [Required]
        public int TopicId { get; set; }
        [Required]
        public string Description { get; set; }

        [NotMapped]
        public IFormFile? File { get; set; }

    }
}
