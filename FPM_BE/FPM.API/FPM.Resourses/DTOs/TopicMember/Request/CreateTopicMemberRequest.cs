using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.TopicMember.Request
{
    public  class CreateTopicMemberRequest
    {

        public int? TopicId { get; set; }
        public int? MemberId { get; set; }
        public string? Role { get; set; }
        public string? Description { get; set; }

    }
}
