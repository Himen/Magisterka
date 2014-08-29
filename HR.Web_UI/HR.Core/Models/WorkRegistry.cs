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
        /// <summary>
        /// Data przyjscia do pracy. Jest po to zeby wykluczyc jedno wejscie i wyjscie w innych dniach
        /// </summary>
        public virtual DateTime Date { get; set; }

        /// <summary>
        /// Data wejscia do firmy
        /// </summary>
        public virtual TimeSpan? DateIn { get; set; }

        /// <summary>
        /// Data wyjscia z firmy
        /// </summary>
        public virtual TimeSpan? DateOut { get; set; }

        /// <summary>
        /// Id osoby ktora wszedla do firmy
        /// </summary>
        public virtual long PersonId { get; set; }

        /// <summary>
        /// Osoba ktora weszla do firmy
        /// </summary>
        public virtual Person Person { get; set; }
    }
}
