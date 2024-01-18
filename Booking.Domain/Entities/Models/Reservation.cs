using Booking.Donmain;

namespace Booking.Domain
{
    public class Reservation : BaseEntity
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

        //настройка связей
        public Table Table { get; set; }
    }
}
