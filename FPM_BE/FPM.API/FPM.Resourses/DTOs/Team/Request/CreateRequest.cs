using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.Team.Request
{

    public class CreateTeamRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? LeaderId { get; set; }
    }
    public class CreateRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public virtual TeamUserDto? Leader { get; set; }
        public virtual ICollection<TeamMemmerDto>? TeamMembers { get; set; }
    }
    public class TeamUserDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }

    public class TeamMemmerDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }

}

