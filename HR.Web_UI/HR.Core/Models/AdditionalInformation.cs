using HR.Core.BasicContract;
using System;

namespace HR.Core.Models
{
    /// <summary>
    /// Dodatkowe informacje o pracowniku. Ktore moga zostac wykorzystane do dataminingu
    /// </summary>
    public class AdditionalInformation: BaseEntity<long>
    {
        /// <summary>
        /// Link do konta na facebook
        /// </summary>
        public string FacebookAccount { get; set; }

        /// <summary>
        /// Link do konta na google plus
        /// </summary>
        public string GoogleAccount { get; set; }

        /// <summary>
        /// link do tweetera
        /// </summary>
        public string TwitterAccount { get; set; }

        /// <summary>
        /// Link do profilu na goldenline
        /// </summary>
        public string GoldenLineAccount { get; set; }

        /// <summary>
        /// Link do Linkin
        /// </summary>
        public string LinkInAccount { get; set; }

        /// <summary>
        /// Id osoby
        /// </summary>
        public long PersonId { get; set; }

        /// <summary>
        /// Osoba
        /// </summary>
        public virtual Person  Person { get; set; }
    }
}
