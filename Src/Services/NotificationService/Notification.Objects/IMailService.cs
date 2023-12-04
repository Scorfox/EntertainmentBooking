namespace Notification.Objects
{
    public interface IMailService
    {
        Task SendNotificationAsync(string emailto, string subject, string messegebody);
    }
}
