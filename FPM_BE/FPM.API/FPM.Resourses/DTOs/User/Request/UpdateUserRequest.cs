using FPM.Resourses.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.User.Request
{
    public class UpdateUserProfileRequest
    {
        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; }
        [JsonPropertyName("lastName")]
        public string? LastName { get; set; }

        [JsonPropertyName("phoneNumber")]
        public string? Tel { get; set; }

    }

    public class UpdateAccountRequest
    {
        [JsonIgnore]
        public int UserId { get; set; }
        public List<int>? RoleId { get; set; }
        public UserEnum? Status { get; set; }
    }

}
