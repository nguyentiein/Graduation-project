using FPM.Resourses.DTOs.User.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace FPM.Resourses.DTOs.Reminder
{
    public class ReminderReponse
    {

        [JsonPropertyName("PreproductionsegmentMembers")]
        public virtual ICollection<PreproductionsegmentMembersReponse> PreproductionsegmentMembers { get; set; }
        [JsonPropertyName("PreProduction")]
        public PreProductionReponse? PreProduction { get; set; }

        [JsonPropertyName("Address")]
        public string? Address { get; set; }


        [JsonPropertyName("FromDate")]
        public DateTime? FromDate { get; set; }
    }
    public class PreproductionsegmentMembersReponse
    {
        [JsonPropertyName("User")]
        public virtual UserReponse? User { get; set; }

    }



    public class UserReponse
    {
        [JsonPropertyName("Email")]
        public string? Email { get; set; }
        [JsonPropertyName("FirstName")]
        public string? FirstName { get; set; }
        [JsonPropertyName("LastName")]
        public string? LastName { get; set; }

        [JsonPropertyName("Tel")]
        public string? Tel { get; set; }
    }

    public class PreProductionReponse
    {
        [JsonPropertyName("Name")]
        public string? Name { get; set; }
 

    }


}
