using HR.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HR.Web_UI.Models.ViewModels
{
    public class CollegesViewModel
    {

        public long Id { get; set; }

        /// <summary>
        /// Nazwa uczelni. Bedzie pobierrana z slownika DIC.Colleges
        /// </summary>
        [Display(Name="Nazwa")]
        public string Name { get; set; }

        /// <summary>
        /// Kierunek na ktorym studiowal pracownik
        /// </summary>
        [Display(Name = "Kierunek studiów")]
        public string FieldOfStudy { get; set; }

        /// <summary>
        /// Specializacja
        /// </summary>
        [Display(Name = "Specializacja")]
        public string Specialization { get; set; }

        /// <summary>
        /// Tytul akademicki jaki zostal zdobyty
        /// </summary>
        [Display(Name = "Tytuł akademicki")]
        public AcademicTitleType AcademicTitle { get; set; }

        /// <summary>
        /// Tytul pracy dyplomowej
        /// </summary>
        [Display(Name = "Tytuł pracy dyplomowej")]
        public string TitleOfResearch { get; set; }

        /// <summary>
        /// Czy studiowanie zostalo zakonczone czy jest w trakcie
        /// </summary>
        [Display(Name = "Postęp")]
        public CollageProgressType Progres { get; set; }

        /// <summary>
        /// Data rozpoczecia
        /// </summary>
        [Display(Name = "Data rozpoczęcia studiów")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Data ukonczenia
        /// </summary>
        [Display(Name = "Data zakończenia studiów")]
        public DateTime? EndDate { get; set; }
    }
}