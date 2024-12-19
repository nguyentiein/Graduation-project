using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FPM.Core.Entities;
using FPM.Repositories.Infrastructure;
using FPM.Repositories.IRepository;
using FPM.Resourses;
using FPM.Resourses.DTOs.Notification.Request;
using FPM.Resourses.DTOs.Notification.Response;
using FPM.Resourses.Results;
using FPM.Services.IServices;
using Microsoft.Extensions.Options;

namespace FPM.Services.Services
{
    public class NotificationService : BaseService, INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public NotificationService(
            INotificationRepository notificationRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IOptionsMonitor<ResponseMessage> responseMessage) : base(mapper, responseMessage)
        {
            _notificationRepository = notificationRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<BaseResult<IEnumerable<NotificationResponse>>> GetUserNotificationsAsync(int userId)
        {
            var (hasData, notifications) = await _notificationRepository.GetNotificationsByUserAsync(userId);

            if (!hasData || notifications == null || !notifications.Any())
            {
                return GetBaseResult(CodeMessage._98, Enumerable.Empty<NotificationResponse>()); 
            }

            var notificationResponses = Mapper.Map<IEnumerable<NotificationResponse>>(notifications);

            return GetBaseResult(CodeMessage._200, notificationResponses); 
        }

        public async Task<BaseResult<NotificationResponse>> CreateAsync(NotificationRequest request)
        {
            var notification = Mapper.Map<Notify>(request);
            notification.CreatedAt = DateTime.UtcNow;
            await _notificationRepository.InsertAsync(notification);
            await _unitOfWork.SaveChangeAsync();
            var response = Mapper.Map<NotificationResponse>(notification);
            return GetBaseResult(CodeMessage._200, response);
        }
        public async Task<BaseResult<NotificationResponse>> UpdateAsync(int notificationId, NotificationRequest request)
        {
            var notification = await _notificationRepository.GetByIdAsync(notificationId);

            if (notification == null)
            {
                return GetBaseResult<NotificationResponse>(CodeMessage._98, null);
            }
            if (notification.Status != request.Status)
            {
                notification.Status = request.Status;
            }

            notification = Mapper.Map(request, notification);
            notification.CreatedAt = DateTime.UtcNow;

            _notificationRepository.Update(notification);
            await _unitOfWork.SaveChangeAsync();

            var response = Mapper.Map<NotificationResponse>(notification);
            return GetBaseResult(CodeMessage._200, response);
        }

        public async Task<BaseResult<NotificationResponse>> GetNotificationByIdAsync(int id)
        {
            var notification = await _notificationRepository.GetByIdAsync(id);
            if (notification == null)
            {
                return GetBaseResult<NotificationResponse>(CodeMessage._98, null);
            }
            var response = Mapper.Map<NotificationResponse>(notification);
            return GetBaseResult(CodeMessage._200, response);
        }
    }
}
