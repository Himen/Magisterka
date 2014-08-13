using HR.Core.BasicContract;
using System;

namespace HR.Core.Models
{
    /// <summary>
    /// Umożliwić wielokrotne wychodzenie i wchodzenie.
    /// Przemyslec nadgodziny. Uwzględnic wolne, swieta, urlopy. Kalendarz pracy.
    /// </summary>
    public class WorkRegistry : BaseEntity<long>
    {
        public long IdPerson { get; set; }
        public DateTime Date { get; set; }
        public DateTime? DateIn { get; set; }
        public DateTime? DateOut { get; set; }
    }
}
