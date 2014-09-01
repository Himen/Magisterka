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
        public virtual string Title { get; set; }

        /// <summary>
        /// Informacja
        /// </summary>
        public virtual string Content { get; set; }

        /// <summary>
        /// Id osoby ktora dodala post
        /// </summary>
        public virtual long PersonId { get; set; }

        /// <summary>
        /// Zdjecie 
        /// </summary>
        public virtual byte[] Photo { get; set; }

        /// <summary>
        /// Opis zdjecia
        /// </summary>
        public virtual string PhotoTitle { get; set; }

        /// <summary>
        /// Osoba ktora dodala post
        /// </summary>
        public virtual Person Person { get; set; }
    }
}
