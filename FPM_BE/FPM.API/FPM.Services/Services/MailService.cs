using FPM.Resourses;
using FPM.Resourses.DTOs.Email.Request;
using FPM.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Services.Services
{
    public class MailService : IMailService
    {
        #region Property
        private readonly SmtpClient _smtpClient;
        #endregion

        #region Contructor
        public MailService()
        {
            _smtpClient = GetClient();
        }
        #endregion

        #region Method
        public async Task SendEmailAsync(SendEmailRequest request)
        {
            try
            {
                MailMessage message = new MailMessage(SmtpConfig.Email, request.ToMail);
                message.Subject = request.Subject;
                message.Body = request.Content;
                message.IsBodyHtml = true;
                await _smtpClient.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                throw new SmtpException(ex.Message,ex);
            }
            
            
            

        }


        public async Task SendEmailReminderAsync(SendEmailRequest request)
        {
            try
            {
                MailMessage message = new MailMessage
                {
                    From = new MailAddress(SmtpConfig.Email),
                    Subject = request.Subject,
                    Body = request.Content,
                    IsBodyHtml = true
                };

                foreach (var email in request.ToMailRendMind)
                {
                    if (!string.IsNullOrEmpty(email))
                    {
                        message.To.Add(new MailAddress(email));
                    }
                }

                await _smtpClient.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                throw new SmtpException(ex.Message, ex);
            }
        }

        public async Task SendEmailsAsync(string toEmail, string subject, string body)
        {
            try
            {
                MailMessage message = new MailMessage
                {
                    From = new MailAddress(SmtpConfig.Email), 
                    Subject = subject,                     
                    Body = body,                   
                    IsBodyHtml = true              
                };
                message.To.Add(toEmail);
                await _smtpClient.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                throw new SmtpException($"Lỗi khi gửi email đến {toEmail}: {ex.Message}", ex);
            }
        }

        #endregion

        #region PrivateWork
        private SmtpClient GetClient()
        {
            var client = new SmtpClient();
            client.Host = SmtpConfig.Host;
            client.Port = SmtpConfig.Port;
            client.Credentials = new NetworkCredential(SmtpConfig.Email, SmtpConfig.Password); 
            client.EnableSsl = true;
            
            return client;
        }
        #endregion
    }
}
