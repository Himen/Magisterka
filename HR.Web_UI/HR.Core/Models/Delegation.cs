using HR.Core.BasicContract;
using System;

namespace HR.Core.Models
{
    /// <summary>
    /// Pamietac jak sie doda delegacje to tez trzeba dodac wolne(usprawiedliwienie).
    /// Narazie jest tak, ze jak sie ma delegacje to jest usprawiedliwione z automatu
    /// </summary>
    public class Delegation:BaseEntity<long>
    {
        /// <summary>
        /// Nazwa delegacji, konrefencji na ktorej byl pracownik
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Szczegolowy opis delegacji
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Data rozpoczecia delegacji
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Data zakonczenia delegacji
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Id osoby ktora jest w delegacji
        /// </summary>
        //public long IdPerson { get; set; }

        /// <summary>
        /// Osoba ktora jest w delegacji
        /// </summary>
        public virtual Person Person { get; set; }
    }
}
