using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Resourses.DTOs.Notification.Request
{
    public class NotificationRequest
    {
        public int? id {  get; set; }
        public int? SenderId { get; set; }
        public int? UserId { get; set; }
        public int ActionType { get; set; }
        public int ObjectType { get; set; }
        public int ObjectId { get; set; }
        public string? Title { get; set; }
        public string? Detail { get; set; }
        public int Status { get; set; }
    }
}
