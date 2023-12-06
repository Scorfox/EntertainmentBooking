using System.Net.Mail;

namespace Notification.Objects
{
    public class SmtpEmailService : IMailService
    {
       // private readonly ILogger<SmtpEmailService> _logger;

        //public SmtpEmailService(ILogger<SmtpEmailService> logger)
        //{
        //    _logger = logger;
        //}


        public async Task SendEmailNotificationAsync(string to, string from, string subject, string body)
        {
            var emailClient = new SmtpClient("localhost");
            var message = new MailMessage
            {
                From = new MailAddress(from),
                Subject = subject,
                Body = body
            };
            message.To.Add(new MailAddress(to));
            await emailClient.SendMailAsync(message);
            //_logger.LogWarning("Sending email to {to} from {from} with subject {subject}.", to, from, subject);
        }
    }
}