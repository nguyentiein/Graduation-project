using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FPM.Core.Entities;
using FPM.Resourses.DTOs.Notification.Request;
using FPM.Resourses.DTOs.Notification.Response;
using FPM.Resourses.DTOs.User.Request;
using FPM.Resourses.DTOs.User.Response;
using FPM.Resourses.Results;

namespace FPM.Services.IServices
{
    public interface INotificationService
    {
        Task<BaseResult<IEnumerable<NotificationResponse>>> GetUserNotificationsAsync(int userId);
        Task<BaseResult<NotificationResponse>> CreateAsync(NotificationRequest request);
        Task<BaseResult<NotificationResponse>> GetNotificationByIdAsync(int id);
        Task<BaseResult<NotificationResponse>> UpdateAsync(int notificationId, NotificationRequest request);
    }
}
