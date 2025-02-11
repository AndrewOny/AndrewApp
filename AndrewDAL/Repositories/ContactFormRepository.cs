using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using AndrewCore.RepositoriesInterfaces;
using AndrewCore.DTOs;

namespace AndrewDAL.Repositories
{
    public class ContactFormRepository : IContactFormRepository  // Made public
    {
        public async Task SendContactFormEmailAsync(ContactFormDto model)
        {
            // SMTP client configuration
            using (var client = new SmtpClient("smtp.yourserver.com"))
            {
                // Sender email address
                var from = new MailAddress("support@yourdomain.com", "Support Team", Encoding.UTF8);

                // Recipient email address
                var to = new MailAddress("admin@yourdomain.com");

                // Create the email message
                var message = new MailMessage(from, to)
                {
                    Subject = $"New Contact Form Submission: {model.TitleLabel}",
                    Body = $"Name: {model.NameLabel}\nEmail: {model.EmailLabel}\nMessage: {model.MessageLabel}",
                    BodyEncoding = Encoding.UTF8,
                    SubjectEncoding = Encoding.UTF8
                };

                // Send email asynchronously
                await client.SendMailAsync(message);
            }
        }

    }

}
