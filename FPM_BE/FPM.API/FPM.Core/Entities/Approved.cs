using FPM.Resourses.Enums;
using System;
using System.Collections.Generic;

namespace FPM.Core.Entities
{
    public class Approved
    {
        public int Id { get; set; }
        public int? ObjectId { get; set; }//id 0 topic 1 outline 2 preproductionPlan
        public DateTime? ProcessedAt { get; set; }
        public int? ProcessedBy { get; set; }//
        public string? Comment { get; set; }//comment lanh dao
        public ApproveResultEnum? Result { get; set; }//-1 update,0 cho duyet,1 dong y, 2 tu choi
        public ApproveObjectTypeEnum? ObjectType { get; set; }//1 topic 2 outline 3 preproductionPlan
    }
}
