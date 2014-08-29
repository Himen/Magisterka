using HR.Core.BasicContract;
using HR.Core.Enums;
using System;

namespace HR.Core.Models.RepoModels
{
    /// <summary>
    /// Kursy przygotowane przez kierownika albo cos takiego
    /// </summary>
    public class CourseMaterial : BaseEntity<Guid>
    {
        /// <summary>
        /// Nazwa szkolenia 
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Typ szkolenia //np. Programowanie C#
        /// </summary>
        public virtual CourseType CourseType { get; set; } 

        /// <summary>
        /// Nazwa dokumentu dodanego do szkolenia
        /// </summary>
        public virtual string DocumentName { get; set; }

        /// <summary>
        /// Dokument
        /// </summary>
        public virtual byte[] Document { get; set; }

        /// <summary>
        /// Opis szkolenia, co i jak
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Id osoby dodajacej material szkoleniowy
        /// </summary>
        public virtual long PersonId { get; set; }

        /// <summary>
        /// Osoba dodajaca material szkoleniowy
        /// </summary>
        public virtual Person Person { get; set; }
    }
}
