using System.Diagnostics;

namespace Base.Objects
{
    [DebuggerDisplay("Id={Id} Deleted={IsDeleted}")]
    public class BaseEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Дата создания сущности
        /// </summary>
        public DateTime Created { get; set; }
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