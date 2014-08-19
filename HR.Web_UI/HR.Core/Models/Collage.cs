﻿using HR.Core.BasicContract;
using HR.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR.Core.Models
{
    /// <summary>
    /// Uczelnia na jakie skonczyla osoba zatrudnuona
    /// </summary>
    public class College:BaseEntity<long>
    {
        /// <summary>
        /// Nazwa uczelni. Bedzie pobierrana z slownika DIC.Colleges
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Kierunek na ktorym studiowal pracownik
        /// </summary>
        public string FieldOfStudy { get; set; }

        /// <summary>
        /// Specializacja
        /// </summary>
        public string Specialization { get; set; }

        /// <summary>
        /// Tytul akademicki jaki zostal zdobyty
        /// </summary>
        public AcademicTitleType AcademicTitle { get; set; }

        /// <summary>
        /// Tytul pracy dyplomowej
        /// </summary>
        public string TitleOfResearch { get; set; }

        /// <summary>
        /// Czy studiowanie zostalo zakonczone czy jest w trakcie
        /// </summary>
        public CollageProgressType Progres { get; set; }

        /// <summary>
        /// Data rozpoczecia
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Data ukonczenia
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Id osoby studiujacej
        /// </summary>
        public long PersonId { get; set; }

        /// <summary>
        /// Osoba studiujaca
        /// </summary>
        public virtual Person Person { get; set; }
    }
}
