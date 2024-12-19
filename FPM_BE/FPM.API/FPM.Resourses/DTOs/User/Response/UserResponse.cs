using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.User.Response
{
    public class UserResponse
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("FirstName")]
        public string? FirstName { get; set; }
        [JsonPropertyName("LastName")]
        public string? LastName { get; set; }
        [JsonPropertyName("UserName")]
        public string? UserName { get; set; }


        [JsonPropertyName("FullName")]
        public string? FullName => $"{FirstName} {LastName}".Trim();
        [JsonPropertyName("Email")]
        public string? Email { get; set; }

        [JsonPropertyName("Avatar")]
        public string? AvatarUrl { get; set; }

        [JsonPropertyName("PhoneNumber")]
        public string? Tel { get; set; }
        [JsonPropertyName("Status")]
        public string? Status { get; set; }
        [JsonPropertyName("Department")]
        public DepartmentResponse? Department { get; set; }
        [JsonPropertyName("Roles")]
        public List<RoleResponse>? Roles { get; set; }
        
    }

    public class DepartmentResponse
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("Name")]
        public string? Name { get; set; }
    }

    public class RoleResponse
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string? Name { get; set; }
        [JsonPropertyName("Type")]
        public string? Type { get; set; }
        [JsonPropertyName("Description")]
        public string? Description {  get; set; }
    }
}
