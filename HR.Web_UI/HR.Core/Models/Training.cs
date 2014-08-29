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
        public virtual string Name { get; set; }

        /// <summary>
        /// Typ szkolenia. Np. certyfikat
        /// </summary>
        public virtual TrainingType Type { get; set; }

        /// <summary>
        /// Data zdania lub odbycia szkolenia
        /// </summary>
        public virtual DateTime DateOfPass { get; set; }

        /// <summary>
        /// Opis szkolenia/certyfikatu
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Id osoby odbywajacej szkolenie
        /// </summary>
        public virtual long PersonId { get; set; }

        /// <summary>
        /// Osoba odbywajaca szkolenie
        /// </summary>
        public virtual Person Person { get; set; }
    }
}
