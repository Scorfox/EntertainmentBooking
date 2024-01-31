namespace Base.Contracts.RabbitMq
{
    public interface IReservationRequest
    {
        public Guid UserId { get; set; }
    }
}
