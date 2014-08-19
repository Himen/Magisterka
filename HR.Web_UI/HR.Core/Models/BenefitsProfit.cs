using HR.Core.BasicContract;
using HR.Core.Enums;
using System;

namespace HR.Core.Models
{
    /// <summary>
    /// Pensja jaka jest wyplacana pracownikowi
    /// </summary>
    public class BenefitsProfit : BaseEntity<long>
    {
        /// <summary>
        /// Za jaki miesiac zostala przyznana pewnsja pracownikowi. Poczatek miesiaca
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Za jaki miesiac zostala przyznana pewnsja pracownikowi. Koniec miesiaca
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Wyplata w brutto
        /// </summary>
        public decimal BenefitBrutto { get; set; }

        /// <summary>
        /// Wyplata w netto
        /// </summary>
        public decimal BenefitNetto { get; set; }

        /// <summary>
        /// Rodzaj wynagrodzenia np.: Pensja, dodatek, wynagrodzenie.
        /// </summary>
        public BenefitType BenefitType { get; set; }

        /// <summary>
        /// Skladka emerytalna
        /// </summary>
        public decimal Retirement { get; set; }

        /// <summary>
        /// Skladka rentowa
        /// </summary>
        public decimal Disability { get; set; }

        /// <summary>
        /// Skladka chorobowa
        /// </summary>
        public decimal Sikness { get; set; }

        /// <summary>
        /// Skladka zdrowotna
        /// </summary>
        public decimal Health { get; set; }

        /// <summary>
        /// Podstawa opodatkowania
        /// </summary>
        public decimal Taxable { get; set; }

        /// <summary>
        /// Zaliczka na PIT
        /// </summary>
        public decimal AdvanceAt_PIT { get; set; }

        /// <summary>
        /// Id Osoby do ktorej nalezy wynagrodzenie
        /// </summary>
        public long PersonId { get; set; }

        /// <summary>
        /// Osoba do ktorej nalezy wynagrodzenie
        /// </summary>
        public virtual Person Person { get; set; }

    }
}
