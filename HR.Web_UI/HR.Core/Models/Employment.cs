using HR.Core.BasicContract;
using HR.Core.Enums;
using System;

namespace HR.Core.Models
{
    /// <summary>
    /// Zatrudnienie
    /// </summary>
    public class Employment : BaseEntity<long>
    {
       /* public virtual long PersonId { get; set; }
        public virtual long ContractId { get; set; }
        public virtual long BankAccountId { get; set; }*/
        /// <summary>
        /// Id pozycji ktora się obejmuje
        /// </summary>
        public virtual string PositionCode { get; set; }

        /// <summary>
        /// Id jednostki organizacyjnej do ktorej jest sie przypisanym
        /// </summary>
        public virtual string OrganiziationalUnitCode { get; set; }

        /// <summary>
        /// Rodzaj zatrudnienia. Np. kandydat, zwolniony
        /// </summary>
        public virtual EmploymentType EmploymentType { get; set; }

        /// <summary>
        /// Data zatrudnienia
        /// </summary>
        public virtual DateTime StartDate { get; set; }

        /// <summary>
        /// Data zwolnienia
        /// </summary>
        public virtual DateTime? EndDate { get; set; }

        /// <summary>
        /// Id pracownika
        /// </summary>
        //public long PersonId { get; set; }

        /// <summary>
        /// Pracownik
        /// </summary>
        public virtual Person Person { get; set; }

        /// <summary>
        /// Id umowy
        /// </summary>
        //public long ContractId { get; set; }

        /// <summary>
        /// Umowa
        /// </summary>
        public virtual Contract Contract { get; set; }

        /// <summary>
        /// Id konta bankowego
        /// </summary>
        //public long BankAccountId { get; set; }

        /// <summary>
        /// Konto bankowe
        /// </summary>
        public virtual BankAccount BankAccount { get; set; }


    }
}
