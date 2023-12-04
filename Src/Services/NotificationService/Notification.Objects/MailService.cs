using System.Net;
using System.Net.Mail;

namespace Notification.Objects
{
    public class MailService : IMailService
    {
        public Task SendNotificationAsync(string emailto, string subject, string messege)
        {
            var emailfrom = "Fangarh.666@yandex.com";
            var pass = "r4e3w2q1AZ";

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                //Выглядит как-то не очень, позже переделаю
                Credentials = new NetworkCredential(emailfrom, pass)
            };

            return client.SendMailAsync
                (new MailMessage(from: emailfrom,
                                 to: emailto,
                                 subject,
                                 messege));
        }
    }
}