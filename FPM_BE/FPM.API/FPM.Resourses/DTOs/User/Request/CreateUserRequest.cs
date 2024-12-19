using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.User.Request
{
    public class CreateUserRequest
    {
        [Required(ErrorMessage = "Username là bắt buộc")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Email là bắt buộc")]
        [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}(?:\\.[a-zA-Z]{2,})*$",ErrorMessage ="Email không đúng định dạng")]
        public string Email { get; set; }
        public List<int>? RoleId { get; set; }
    }
}
