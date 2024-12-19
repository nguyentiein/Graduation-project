using FPM.Resourses.Enums;
using System;
using System.Collections.Generic;

namespace FPM.Core.Entities
{
    public class TopicDocument
    {
        public int Id { get; set; }
        public int? TopicId { get; set; }
        public string? Description { get; set; }       
        public int? CreateBy { get; set; }
        public int? ApproveBy { get; set; }
        public string? FileUrl { get; set; }
        public DocumentStatusEnum Status { get; set; }
        public int? UploadPartId { get; set; }
        public string? Comment { get; set; }

        public virtual Topic? Topic { get; set; }
        public virtual UploadPart? UploadPart { get; set; }
    }
}
