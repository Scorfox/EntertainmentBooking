namespace Notification.Objects
{
    public interface IMailService
    {
        Task SendEmailNotificationAsync(string to, string from, string subject, string body);
    }
}
