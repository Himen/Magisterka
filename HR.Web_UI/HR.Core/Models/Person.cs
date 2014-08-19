using HR.Core.BasicContract;
using HR.Core.Enums;
using System;
using System.Collections.Generic;

namespace HR.Core.Models
{
    /// <summary>
    /// To moze byc pracownik jak i rowniez kandydat
    /// </summary>
    public class Person : BaseEntity<long>
    {
        /// <summary>
        /// Imie pracownika
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Nazwisko pracownika
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Data urodznia
        /// </summary>
        public DateTime DateOfBirth { get; set; }

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

        /// <summary>
        /// NIP
        /// </summary>
        public long NIP { get; set; }

        /// <summary>
        /// Numer dowodu
        /// </summary>
        public string IDCard { get; set; }

        /// <summary>
        /// Numer pesel
        /// </summary>
        public string PESEL { get; set; }

        /// <summary>
        /// Id managera tej osoby
        /// </summary>
        public long? ManagerId { get; set; }

        /// <summary>
        /// Manager tej osoby
        /// </summary>
        public virtual Person Manager { get; set; }

        /// <summary>
        /// Id osoby kontaktowej
        /// </summary>
        public long ContactPersonId { get; set; }

        /// <summary>
        /// Osoba kontaktowa
        /// </summary>
        public virtual ContactPerson ContactPerson { get; set; }
    }
}
