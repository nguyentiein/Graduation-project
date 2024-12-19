using FPM.Resourses;
using FPM.Resourses.DTOs.Notification.Request;
using FPM.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FPM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ParentController
    {
        private readonly INotificationService _notificationService;
        public NotificationController(IOptionsMonitor<ResponseMessage> responseMessage, IMapper mapper, INotificationService notificationService)
            : base(responseMessage, mapper)
        {
            _notificationService = notificationService;
        }
        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetUserNotifications(int id)
        {
            var result = await _notificationService.GetUserNotificationsAsync(id);
            return Ok(result); 
        }
        [HttpPatch("/update/{id}")]
        public async Task<IActionResult> UpdateNotification(int id, [FromBody] NotificationRequest request)
        {
            if (id <= 0 || request == null)
            {
                return BadRequest("Invalid request.");
            }
            request.id = id;
            var result = await _notificationService.UpdateAsync(id, request);
            return Ok(result);
        }

    }
}

