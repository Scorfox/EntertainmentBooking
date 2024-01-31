namespace Base.Contracts.RabbitMq.Events
{
    public interface ITableSelected
    {
        public Guid TableId { get; set; }
        public Guid UserId { get; set; }
    }
}
