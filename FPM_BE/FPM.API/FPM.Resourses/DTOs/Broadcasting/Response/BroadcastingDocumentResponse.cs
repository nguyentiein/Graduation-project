using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.Broadcasting.Response
{
    public class BroadcastingDocumentResponse
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("BroadcastingId")]
        public int BroadcastingId { get; set; }

        [JsonPropertyName("FileName")]
        public string? FileName { get; set; }

        [JsonPropertyName("FileType")]
        public string? FileType { get; set; }

        [JsonPropertyName("FileUrl")]
        public string? FileUrl { get; set; }

        [JsonPropertyName("Description")]
        public string? Description { get; set; }

        [JsonPropertyName("UploadPartId")]
        public int? UploadPartId { get; set; }
        [JsonPropertyName("CreateDate")]
        public DateTime? CreateDate { get; set; }
    }
}
