﻿using System;
using System.Collections.Generic;

namespace FPM.Core.Entities
{
    public class UserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public User? User { get; set; }
        public Role? Role { get; set; }

    }
}
