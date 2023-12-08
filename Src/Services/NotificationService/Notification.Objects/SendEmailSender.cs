using Microsoft.Extensions.Logging;
using System.Net.Mail;

namespace Notification.Objects;

public class SmtpEmailSender : IEmailSender
{
    private readonly ILogger<SmtpEmailSender> _logger;

    public SmtpEmailSender(ILogger<SmtpEmailSender> logger)
    {
        _logger = logger;
    }

    public async Task SendEmailAsync(string to, string from, string subject, string body)
    {
        try
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
            _logger.LogWarning($"Отправка электронной почты {to} -> {from} с темой {subject}.", to, from, subject);
        }
        catch (Exception ex) 
        {
            _logger.LogError(ex, "Error sending email");
            throw;
        }
        
    }
}