using HR.Core.BasicContract;
using System;

namespace HR.Core.Models.RepoModels
{
    public class VacationDocument:BaseEntity<Guid>
    {
        /// <summary>
        /// Nazwa dokumentu powiazanego z danym urlopem
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Typ np: Zwolnienie lekarskie, L4
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Plik 
        /// </summary>
        public byte[] Content { get; set; }

        /// <summary>
        /// Krotki opis
        /// </summary>
        public string Description { get; set; }

        public virtual Vacation Vacation { get; set; }
    }
}
