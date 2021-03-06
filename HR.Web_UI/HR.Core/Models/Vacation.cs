﻿using HR.Core.BasicContract;
using HR.Core.Enums;
using HR.Core.Models.RepoModels;
using System;

namespace HR.Core.Models
{
    /// <summary>
    /// Opisuje dni wolne pracownika. Musi byc porownywane z WorkRegistry
    /// Pracodawca musi zatwierdzic urlop pracownika. Zmieniajac data state na 1;
    /// </summary>
    public class Vacation : BaseEntity<long>
    {
        /// <summary>
        /// Początek urlopu
        /// </summary>
        public virtual DateTime StartDate { get; set; }

        /// <summary>
        /// Koniec urlopu
        /// </summary>
        public virtual DateTime? EndDate { get; set; }

        /// <summary>
        /// Opisuje powod: urlop, zwolnienie
        /// </summary>
        public virtual VacationType VacationType { get; set; }

        /// <summary>
        /// Pracodawca musi zatwierdzic urlop pracownika
        /// </summary>
        public virtual byte VacationAcceptation { get; set; }

        
        /// <summary>
        /// Krotki opis 
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Id Osoby ktora poszla na urlop
        /// </summary>
        public virtual long PersonId { get; set; }

        /// <summary>
        /// Osoba ktora poszla na urlop
        /// </summary>
        public virtual Person Person { get; set; }

        /// <summary>
        /// Id dokumentu powiazanego z urlopem
        /// </summary>
        //public Guid VacationDocumentId { get; set; }

        /// <summary>
        /// Dokument powiazany z urlopem
        /// </summary>
        public virtual VacationDocument VacationDocument { get; set; }
    }
}
