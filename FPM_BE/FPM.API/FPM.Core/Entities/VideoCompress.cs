using System;
using System.Collections.Generic;

namespace FPM.Core.Entities
{
    public class VideoCompress
    {
        public int Id { get; set; }
        public int? UploadPartId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedById { get; set; }
        public string? FileName { get; set; }
        public long? FileSize { get; set; }
        public string? FileLocation { get; set; }
        public string? Url { get; set; }
        public int? VideoSize { get; set; }

        public virtual UploadPart? UploadPart { get; set; }
    }
}
