using FPM.Resourses.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.Approved.Request
{
    public class CreateApprovedRequest
    {
      
        
        public int? ObjectId { get; set; } // id of topic or outline


        public DateTime? ProcessedAt { get; set; }


        public int? ProcessedBy { get; set; }


        public string? Comment { get; set; } // leader's comment

      
        public ApproveResultEnum? Result { get; set; } // 0 = pending, 1 = approved, 2 = rejected

        public ApproveObjectTypeEnum? ObjectType { get; set; } // 0 = topic, 1 = outline, 2 = plan
    }
}
