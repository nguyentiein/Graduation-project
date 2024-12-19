using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.Broadcasting.Request
{
    public class CreateBroadcastingRequest
    {
        [Required]
        public int PostProductionPlaningId { get; set; }
        [Required]
        public int ChannelId { get; set; }

        public DateTime? BroadcastingTime { get; set; }
        public long? Duration { get; set; }
        public DateTime? SubmissionTime { get; set; }
        public string? Reciever { get; set; }
    }
}
