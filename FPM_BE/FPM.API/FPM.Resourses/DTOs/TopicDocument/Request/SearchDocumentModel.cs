using FPM.Resourses.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.TopicDocument.Request
{
    public class SearchDocumentModel
    {
        public int? TopicId { get; set; }
        public DocumentStatusEnum? Status { get; set; }

    }
}
