using HR.Core.BasicContract;
using System;

namespace HR.Core.Models.RepoModels
{
    public class VacationDocument:BaseEntity<Guid>
    {
        /// <summary>
        /// Nazwa dokumentu powiazanego z danym urlopem
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Typ np: Zwolnienie lekarskie, L4
        /// </summary>
        public virtual string Type { get; set; }

        /// <summary>
        /// Plik 
        /// </summary>
        public virtual byte[] Content { get; set; }

        /// <summary>
        /// Krotki opis
        /// </summary>
        public virtual string Description { get; set; }

        public virtual Vacation Vacation { get; set; }
    }
}
