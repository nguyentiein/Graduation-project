using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.Teams.Request
{
    //public class UpdateTeamRequest
    //{

    //    public int Id { get; set; }
    //    public string? Name { get; set; }
    //    public string? Description { get; set; }
    //    public  UpdateTeamUserDto? Leader { get; set; }
    //    public  ICollection<UpdateTeamMemmerDto>? TeamMembers { get; set; }
    //}

    public class UpdateTeamRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? LeaderId { get; set; }
    }
    public class UpdateTeamUserDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }

    public class UpdateTeamMemmerDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
