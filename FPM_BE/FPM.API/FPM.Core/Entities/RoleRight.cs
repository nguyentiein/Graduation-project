using System;
using System.Collections.Generic;

namespace FPM.Core.Entities
{
    public class RoleRight
    {
        public int Id { get; set; }
        public int? RoleId { get; set; }
        public int? RightId { get; set; }

        public virtual Commoncategory? Right { get; set; }
        public virtual Commoncategory? Role { get; set; }
    }
}
