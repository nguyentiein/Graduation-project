using System;
using System.Collections.Generic;

namespace FPM.Core.Entities
{
    public class Broadcastingdocument
    {
        public int Id { get; set; }
        public int BroadcastingId { get; set; }
        //public string? FileName { get; set; }
        //public string? FileType { get; set; }
        //public string? FileUrl { get; set; }
        //public string? Description { get; set; }
        public int? UploadPartId { get; set; }

        public virtual Broadcasting Broadcasting { get; set; } = null!;
        public virtual UploadPart? UploadPart { get; set; }
    }
}
