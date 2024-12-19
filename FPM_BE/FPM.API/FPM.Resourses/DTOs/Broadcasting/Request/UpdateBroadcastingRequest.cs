using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.Broadcasting.Request
{
    public class UpdateBroadcastingRequest
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int? PostProductionPlaningId { get; set; }
        public int? ChannelId { get; set; }
        public DateTime? BroadcastingTime { get; set; }
        public long? Duration { get; set; }
        public DateTime? SubmissionTime { get; set; }
        public string? Reciever { get; set; }
    }
}
