using System;

namespace Notification.Objects
{
    public class MailPresenter
    {
        private readonly IMailService _mailService;

        public MailPresenter(IMailService mailService)
        {
            this._mailService = mailService;
        }

        public void SendNotificationByEmail(string emailto, string subject, string messegebody)
        {
            _mailService.SendNotificationAsync(emailto, subject, messegebody);
        }
    }
}
