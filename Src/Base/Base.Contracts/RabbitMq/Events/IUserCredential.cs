namespace Base.Contracts.RabbitMq.Events;

public interface IUserCredential
{
    public Guid UserId { get; set; }
}