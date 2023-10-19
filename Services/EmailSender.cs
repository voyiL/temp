using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.Net;
using System.Net.Mail;

namespace Primary_HealthCare_System.Services
{
    public class EmailSender: IEmailSender
    {
        public EmailSender() 
        { 
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            string from = "mosenakoketso2018@gmail.com";
            string Paassword = "hnctgkowchyhupzl";
            string SenderName = "Admin";
            MailMessage message = new MailMessage();
            message.From = new MailAddress(from);
            message.Subject = subject;
            message.Body = "<html><body>" + htmlMessage + "</body></html>";
            message.To.Add(new MailAddress(email));
            message.IsBodyHtml = true;

            var stmpclient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(from, Paassword),
                EnableSsl = true,
            };
            stmpclient.Send(message);
        }
    }
}
