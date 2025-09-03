using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using MyApp.Model;

namespace MyApp.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string subject, string body);
    }
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _settings;

        public EmailService(IOptions<EmailSettings> settings)
        {
            _settings = settings.Value;
        }
        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            using (var client = new SmtpClient(_settings.SmtpServer, _settings.Port))
            {
                client.Credentials = new NetworkCredential(_settings.Username, _settings.Password);
                client.EnableSsl = true;

                var mail = new MailMessage()
                {
                    From = new MailAddress(_settings.SenderEmail, _settings.SenderName),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true,
                };
                mail.To.Add(toEmail);
                await client.SendMailAsync(mail);

            }
        }
    }
}