using System.Diagnostics;

namespace Base.Objects
{
    /// <summary>
    /// Базовый класс для всех объектов системы
    /// </summary>
    [DebuggerDisplay("Id={Id} Deleted={IsDeleted}")]
    public abstract class BookingEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Создвтель объекта
        /// </summary>
        public string CreatedUser { get; set; }
        /// <summary>
        /// Дата создания сущности
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Пользователь сделавший последнее обновление
        /// </summary>
        public string UpdatedUser { get; set; }
        /// <summary>
        /// Дата изменения сущности
        /// </summary>
        public DateTime Updated { get; set; }
        /// <summary>
        /// Флаг удалено
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}