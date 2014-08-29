using System;
using HR.Core.BasicContract;
using HR.Core.Enums;

namespace HR.Core.Models
{
    /// <summary>
    /// Kontrakt na jaki jest zatrudniony pracownik
    /// </summary>
    public class Contract:BaseEntity<long>
    {
        /// <summary>
        /// Data rozpoczecia kontraktu
        /// </summary>
        public virtual DateTime StartDate { get; set; }

        /// <summary>
        /// Data zakonczenia kontraktu
        /// </summary>
        public virtual DateTime? EndDate { get; set; }

        /// <summary>
        /// Rodzaj kontraktu
        /// </summary>
        public virtual ContractType ContractType { get; set; }

        /// <summary>
        /// Wymiar kontraktu
        /// </summary>
        public virtual ContractDimensionType ContractDimension { get; set; }

        /// <summary>
        /// Wynagrodzenie miesieczne
        /// </summary>
        public virtual double? MonthBenefit { get; set; }

        /// <summary>
        /// Wynagrodzenie na godzine, jezeli nie wystepuje wynagrodzenie miesieczne
        /// </summary>
        public virtual double? BenefitPerHour { get; set; }

        public virtual Employment Employment { get; set; }
    }
}
