using System;
using System.Collections.Generic;

namespace FPM.Core.Entities
{
    public class DocumentFile
    {
        public int Id { get; set; }
        public int? DocumentId { get; set; }
        public int? UploadPartId { get; set; }

        public virtual Document? Document { get; set; }
        public virtual UploadPart? UploadPart { get; set; }
    }
}
