using System.Net;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace Notification.API
{
    public class SmtpService
    {
        private readonly string _fromEmail;
        private readonly string _fromName;
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _sender;
        private readonly string _senderPassword;

        public SmtpService(string fromEmail, string fromName, string smtpServer, int smtpPort, string sender, string senderPassword)
        {
            _fromEmail = fromEmail;
            _fromName = fromName;
            _smtpServer = smtpServer;
            _smtpPort = smtpPort;
            _sender = sender;
            _senderPassword = senderPassword;
        }

        public async Task SendEmailAsync(string recipient, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_fromName, _fromEmail));
            message.To.Add(new MailboxAddress("", recipient));
            message.Subject = subject;
            message.Body = new TextPart("plain") { Text = body };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_smtpServer, _smtpPort, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_sender, _senderPassword);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}
