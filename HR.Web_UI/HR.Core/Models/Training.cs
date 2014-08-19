using HR.Core.BasicContract;
using HR.Core.Enums;
using System;

namespace HR.Core.Models
{
    /// <summary>
    /// Certyfikaty, szkolenia itp ktore odbyl pracownik
    /// </summary>
    public class Training : BaseEntity<long>
    {
        /// <summary>
        /// Nazwa szkolenia lub certyfikatu
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Typ szkolenia. Np. certyfikat
        /// </summary>
        public TrainingType Type { get; set; }

        /// <summary>
        /// Data zdania lub odbycia szkolenia
        /// </summary>
        public DateTime DateOfPass { get; set; }

        /// <summary>
        /// Opis szkolenia/certyfikatu
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Id osoby odbywajacej szkolenie
        /// </summary>
        public long PersonId { get; set; }

        /// <summary>
        /// Osoba odbywajaca szkolenie
        /// </summary>
        public virtual Person Person { get; set; }
    }
}
