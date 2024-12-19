using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.TeamMember.Request
{
    public  class CreateTeamMerberRequest
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? TeamId { get; set; }
        public string? Role { get; set; }
    }
}
