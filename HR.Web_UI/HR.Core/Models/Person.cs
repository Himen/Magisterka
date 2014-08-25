using HR.Core.BasicContract;
using HR.Core.Enums;
using System;
using System.Collections.Generic;
using HR.Core.Models.RepoModels;

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
        public Person Manager { get; set; }

        /// <summary>
        /// Id osoby kontaktowej
        /// </summary>
        //public long? ContactPersonId { get; set; }

        /// <summary>
        /// Osoba kontaktowa
        /// </summary>
        public virtual ContactPerson ContactPerson { get; set; }

        /// <summary>
        /// Lista dokumentow pracownika
        /// </summary>
        public virtual List<Document> Documents { get; set; }

        /// <summary>
        /// Id konta
        /// </summary>
        /*public long AccountId { get; set; }
        */
        /// <summary>
        /// EF: Konto
        /// </summary>
        public virtual Account Account { get; set; }

        public virtual AdditionalInformation AdditionalInformation { get; set; }

        public virtual List<BenefitsProfit> BenefitsProfits { get; set; }

        //public long BankAccountId { get; set; }

        public virtual List<College> Colleges { get; set; }

        public virtual List<CourseMaterial> CourseMaterials { get; set; }

        public virtual Delegation Delegation { get; set; }

        public virtual Employment Employment { get; set; }

        public virtual List<Job> Jobs { get; set; }

        public virtual OrganiziationalUnit OrganiziationalUnit { get; set; }

        public virtual List<PromotialMaterial> PromotialMaterials { get; set; }

        public virtual List<Training> Trainings { get; set; }

        public virtual List<Vacation> Vacations { get; set; }

        public virtual List<WorkRegistry> WorkRegistrys { get; set; }

    }
}
