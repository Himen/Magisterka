using HR.Core.BasicContract;
using System;


namespace HR.Core.Models
{
    /// <summary>
    /// Osoba kontaktowa w razie wystapienia przypadku losowego
    /// </summary>
    public class ContactPerson : BaseEntity<long>
    {
        /// <summary>
        /// Imie osoby kontaktowej
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Nazwisko osoby kontaktowej
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Miasto
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Kod pocztowy
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Ulica
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Numer budynku
        /// </summary>
        public int BuildingNumber { get; set; }

        /// <summary>
        /// Numer mieszkania
        /// </summary>
        public int ApartmentNumber { get; set; }

        /// <summary>
        /// Telefon
        /// </summary>
        public long Phone { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
    }
}
