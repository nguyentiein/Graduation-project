using FPM.Resourses.DTOs.Email.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.IServices
{
    public interface IMailService
    {
        Task  SendEmailAsync(SendEmailRequest request);
        Task SendEmailReminderAsync(SendEmailRequest request);
        Task SendEmailsAsync(string toEmail, string subject, string body);
    }
}
