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
        public virtual string FirstName { get; set; }

        /// <summary>
        /// Nazwisko osoby kontaktowej
        /// </summary>
        public virtual string Surname { get; set; }

        /// <summary>
        /// Miasto
        /// </summary>
        public virtual string City { get; set; }

        /// <summary>
        /// Kod pocztowy
        /// </summary>
        public virtual string PostalCode { get; set; }

        /// <summary>
        /// Ulica
        /// </summary>
        public virtual string Street { get; set; }

        /// <summary>
        /// Numer budynku
        /// </summary>
        public virtual int BuildingNumber { get; set; }

        /// <summary>
        /// Numer mieszkania
        /// </summary>
        public virtual int ApartmentNumber { get; set; }

        /// <summary>
        /// Telefon
        /// </summary>
        public virtual long Phone { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public virtual string Email { get; set; }

        public virtual Person Person { get; set; }
    }
}
