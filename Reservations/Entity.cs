namespace Reservations
{
    public abstract class Entity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        public Guid TableId { get; set; }
        public DateTimeOffset StartedAt { get; set; }
        public DateTimeOffset FinishedAt { get; set; }
        public Guid WhoBookedId { get; set; }
        public Guid WhoConfirmedId { get; set; }
        public Guid WhoCancelledId { get; set; }
    }
}
