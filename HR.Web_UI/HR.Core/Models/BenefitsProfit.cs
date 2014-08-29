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
        public virtual DateTime StartDate { get; set; }

        /// <summary>
        /// Za jaki miesiac zostala przyznana pewnsja pracownikowi. Koniec miesiaca
        /// </summary>
        public virtual DateTime? EndDate { get; set; }

        /// <summary>
        /// Wyplata w brutto
        /// </summary>
        public virtual double BenefitBrutto { get; set; }

        /// <summary>
        /// Wyplata w netto
        /// </summary>
        public virtual double BenefitNetto { get; set; }

        /// <summary>
        /// Rodzaj wynagrodzenia np.: Pensja, dodatek, wynagrodzenie.
        /// </summary>
        public virtual BenefitType BenefitType { get; set; }

        /// <summary>
        /// Skladka emerytalna
        /// </summary>
        public virtual double Retirement { get; set; }

        /// <summary>
        /// Skladka rentowa
        /// </summary>
        public virtual double Disability { get; set; }

        /// <summary>
        /// Skladka chorobowa
        /// </summary>
        public virtual double Sikness { get; set; }

        /// <summary>
        /// Skladka zdrowotna
        /// </summary>
        public virtual double Health { get; set; }

        /// <summary>
        /// Podstawa opodatkowania
        /// </summary>
        public virtual double Taxable { get; set; }

        /// <summary>
        /// Zaliczka na PIT
        /// </summary>
        public virtual double AdvanceAt_PIT { get; set; }

        /// <summary>
        /// Id Osoby do ktorej nalezy wynagrodzenie
        /// </summary>
        public virtual long PersonId { get; set; }

        /// <summary>
        /// Osoba do ktorej nalezy wynagrodzenie
        /// </summary>
        public virtual Person Person { get; set; }

    }
}
