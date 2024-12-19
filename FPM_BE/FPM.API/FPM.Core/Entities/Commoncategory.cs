using FPM.Resourses.Enums;
using System;
using System.Collections.Generic;

namespace FPM.Core.Entities
{
    public class Commoncategory
    {
        public Commoncategory()
        {
            Broadcastings = new HashSet<Broadcasting>();
            Documents = new HashSet<Document>();
            PostproductionProgresses = new HashSet<PostproductionProgress>();
            PreproductionPlanings = new HashSet<PreproductionPlaning>();
            PreproductionProgresses = new HashSet<PreproductionProgress>();
            RoleRightRights = new HashSet<RoleRight>();
            RoleRightRoles = new HashSet<RoleRight>();
            Topics = new HashSet<Topic>();    
            Users = new HashSet<User>();
            PreproductionEstimates = new HashSet<PreproductionEstimate>();

        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public CommonCategoryEnum? Type { get; set; }
        public string? Description { get; set; }
        public int? ParentId { get; set; }

        public bool? IsDeleted { get; set; }

        public virtual Commoncategory? Parent { get; set; }
        public virtual ICollection<Commoncategory> Children { get; set; }
        public virtual ICollection<PreproductionEstimate> PreproductionEstimates { get; set; }
        public virtual ICollection<Broadcasting> Broadcastings { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<PostproductionProgress> PostproductionProgresses { get; set; }
        public virtual ICollection<PreproductionPlaning> PreproductionPlanings { get; set; }
        public virtual ICollection<PreproductionProgress> PreproductionProgresses { get; set; }
        public virtual ICollection<RoleRight> RoleRightRights { get; set; }
        public virtual ICollection<RoleRight> RoleRightRoles { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
    }
}
