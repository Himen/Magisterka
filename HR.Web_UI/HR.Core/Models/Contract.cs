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
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Data zakonczenia kontraktu
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Rodzaj kontraktu
        /// </summary>
        public ContractType ContractType { get; set; }

        /// <summary>
        /// Wymiar kontraktu
        /// </summary>
        public ContractDimensionType ContractDimension { get; set; }

        /// <summary>
        /// Wynagrodzenie miesieczne
        /// </summary>
        public double? MonthBenefit { get; set; }

        /// <summary>
        /// Wynagrodzenie na godzine, jezeli nie wystepuje wynagrodzenie miesieczne
        /// </summary>
        public double? BenefitPerHour { get; set; }

        public virtual Employment Employment { get; set; }
    }
}
