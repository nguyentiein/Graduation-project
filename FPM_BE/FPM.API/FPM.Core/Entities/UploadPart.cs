using System;
using System.Collections.Generic;

namespace FPM.Core.Entities
{
    public class UploadPart
    {
        public UploadPart()
        {
            Broadcastingdocuments = new HashSet<Broadcastingdocument>();
            DocumentFiles = new HashSet<DocumentFile>();
            TopicDocuments = new HashSet<TopicDocument>();
            VideoCompresses = new HashSet<VideoCompress>();
            Videos = new HashSet<Video>();
        }

        public int Id { get; set; }
        public string? FileName { get; set; }
        public long? FileSize { get; set; }
        public string? TokenId { get; set; }
        public string? FileLocation { get; set; }
        public string? FileUrl { get; set; }
        public DateTime? TimeBeginUpload { get; set; }
        public DateTime? TimeFinishUpload { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? NumberOfChunks { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? FileType { get; set; } //0:document, 1: video
        public string? Snapshot { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Broadcastingdocument> Broadcastingdocuments { get; set; }
        public virtual ICollection<DocumentFile> DocumentFiles { get; set; }
        public virtual ICollection<TopicDocument> TopicDocuments { get; set; }
        public virtual ICollection<VideoCompress> VideoCompresses { get; set; }
        public virtual ICollection<Video> Videos { get; set; }
    }
}
