using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.User.Request
{
    public class ForgotPasswordRequest
    {
        public string? Email { get; set; }
        public string? VerificationCode { get; set; }
        public string? NewPassword { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
