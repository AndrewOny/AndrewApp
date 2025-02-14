using AndrewCore.DTOs;
using AndrewCore.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using AndrewCore.RepositoriesInterfaces;

namespace AndrewCore.Services
{
    public class EmailService : IVisitorMessageService
    {
        private readonly IVisitorMessageRepository _emailRepository;
        private readonly IConfiguration _configuration;

        public EmailService(IVisitorMessageRepository emailRepository, IConfiguration configuration)
        {
            _emailRepository = emailRepository;
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string name, string email, string title, string message)
        {
            var senderEmail = _configuration["MailSettings:FromEmail"];
            var senderName = _configuration["MailSettings:FromName"];
            var smtpServer = _configuration["MailSettings:SmtpServer"];
            var smtpPort = int.Parse(_configuration["MailSettings:SmtpPort"]!);
            var smtpUser = _configuration["MailSettings:SmtpUser"];
            var smtpPass = _configuration["MailSettings:SmtpPass"];
            var emailAdmin = _configuration["MailSettings:AdminEmail"];

            var adminMessage = new MimeMessage();
            adminMessage.From.Add(new MailboxAddress(senderName, senderEmail));
            adminMessage.To.Add(new MailboxAddress("", emailAdmin));
            adminMessage.Subject = $"New Contact: {name}";
            adminMessage.Body = new TextPart("plain") { Text = $"New Contact from {name} with email {email}:\n {message}" }; 

            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress(senderName, senderEmail));
            mimeMessage.To.Add(new MailboxAddress("", email));
            mimeMessage.Subject = $"Thank You for Reaching Out";
            mimeMessage.Body = new TextPart("plain") { Text = $"Dear {name},\n" +
                                                              $"Thank you for contacting us. I will get back to you soon.\n" +
                                                              $"Best regards, Andrew" };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(smtpServer, smtpPort, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(smtpUser, smtpPass);
                await client.SendAsync(adminMessage);
                await client.SendAsync(mimeMessage);
                await client.DisconnectAsync(true);
            }

            await _emailRepository.SendEmailAsync(new VisitorMessageDto
            {
                Name = name,
                Title = title,
                Email = email,
                Message = message,
            });
        }
    }
}
