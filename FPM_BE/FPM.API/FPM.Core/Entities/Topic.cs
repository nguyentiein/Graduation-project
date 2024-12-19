using FPM.Resourses.Enums;
using System;
using System.Collections.Generic;

namespace FPM.Core.Entities
{
    public class Topic
    {
        public Topic()
        {
            PreproductionPlanings = new HashSet<PreproductionPlaning>();
            TopicDocuments = new HashSet<TopicDocument>();
            TopicMembers = new HashSet<TopicMember>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Scenario { get; set; }
        public DateTime? EstimatedBegin { get; set; }
        public DateTime? EstimatedEnd { get; set; }
        public DateTime? EstimatedBroadcasting { get; set; }
        public decimal? EstimatedBudget { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? Status { get; set; }
        public CommonTypeTopicEnum? Type { get; set; }
        public int? ParentId { get; set; }
        public decimal? Budget { get; set; }
        public bool IsDeleted { get; set; }
        public int? CategoryId { get; set; }

        public virtual Commoncategory? Category { get; set; }
        public virtual User ? User { get;set; }
        public virtual ICollection<PreproductionPlaning> PreproductionPlanings { get; set; }
        public virtual ICollection<TopicDocument> TopicDocuments { get; set; }
        public virtual ICollection<TopicMember> TopicMembers { get; set; }
    }
}
