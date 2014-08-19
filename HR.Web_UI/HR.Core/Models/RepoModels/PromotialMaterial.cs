using HR.Core.BasicContract;
using System;

namespace HR.Core.Models.RepoModels
{
    /// <summary>
    /// Materialy promocyjne. Jakies akcje na facebooku itd. Mozna rozszezyc o automatyczne dodawanie do facebooka
    /// </summary>
    public class PromotialMaterial : BaseEntity<long>
    {
        /// <summary>
        /// Tytul informacji
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Informacja
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Id osoby ktora dodala post
        /// </summary>
        public long PersonId { get; set; }

        /// <summary>
        /// Osoba ktora dodala post
        /// </summary>
        public virtual Person Person { get; set; }
    }
}
