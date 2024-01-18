namespace Domain
{
    public class Table
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        public Guid FillialId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SeatsNumber { get; set; }

        //настройка связей
        public ICollection<Reservation> Reservations { get; set; }
    }
}
