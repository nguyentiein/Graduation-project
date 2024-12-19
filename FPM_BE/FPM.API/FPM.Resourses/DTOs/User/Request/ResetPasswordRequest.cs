using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.User.Request
{
    public class ResetPasswordRequest
    {
        public int userId { get; set; }
        public string? currentPassword { get; set; }
        public string? newPassword { get; set; }
        public string? cfPassword { get; set; }
    }
}
