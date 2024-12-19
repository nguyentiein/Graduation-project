using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.User.Response
{
    public class LoginResponse : UserResponse
    {
        [JsonPropertyName("ExpireTimeUTC")]
        public DateTime ExpireTimeUTC { get; set; }

        [JsonPropertyName("AccessToken")]
        public string AccessToken { get; set; }
    }
}
