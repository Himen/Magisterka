using HR.Core.BasicContract;
using System;

namespace HR.Core.Models
{
    /// <summary>
    /// Praca w jakiej pracownik zostal zatrudniony
    /// Domyslnie nazwy firm beda pobierane z slownika.
    /// </summary>
    public class Job : BaseEntity<long>
    {
        /// <summary>
        /// Nazwa firmy w ktorej pracuje pracownik
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Pozycja ktora zajmuje/mowal pracownik
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Data rozpoczecia wspolpracy z dana firma
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Data zakonczenia wspolpracy z dana firma
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Opis stanowiska na ktorym sie bylo
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Id osoby 
        /// </summary>
        public long PersonId { get; set; }

        /// <summary>
        /// Osoba
        /// </summary>
        public virtual Person Person { get; set; }

    }
}
