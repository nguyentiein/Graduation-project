using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.Email.Request
{
    public class SendEmailRequest
    {
        public string ToMail { get; set; }
        public string Name { get; set; } 
        public string Project { get; set; }
        public string Address { get; set; }

      
        public DateTime Date { get; set; }

        public List<string> ToMailRendMind { get; set; } = new List<string>();

        public List<string> Team  { get; set; } = new List<string>();
        public string Subject { get; set; }

        public string Content { get; set; }

    
    }
}
