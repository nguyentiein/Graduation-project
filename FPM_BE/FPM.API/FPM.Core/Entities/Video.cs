using FPM.Resourses.Enums;
using System;
using System.Collections.Generic;

namespace FPM.Core.Entities
{
    public class Video
    {
        public int Id { get; set; }
        public int? No { get; set; }
        public int? ObjectId { get; set; } //Id của 
        public VideoTypeEnum? ObjectType { get; set; }
        public string? VideoName { get; set; }
        public string? VideoUrl { get; set; }
        public decimal? VideoLength { get; set; }
        public decimal? VideoSize { get; set; }
        public string? Note { get; set; }
        public int? UploadPartId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual UploadPart? UploadPart { get; set; }
    }
}
