using System;
using System.Collections.Generic;

namespace FPM.Core.Entities
{
    public class Document
    {
        public Document()
        {
            DocumentFiles = new HashSet<DocumentFile>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? DocName { get; set; }
        public string? Description { get; set; }
        public int? DocType { get; set; }

        public virtual Commoncategory? DocTypeNavigation { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<DocumentFile> DocumentFiles { get; set; }
    }
}
