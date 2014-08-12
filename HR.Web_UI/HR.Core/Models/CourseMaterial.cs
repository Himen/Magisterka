﻿
using HR.Core.Enums;
namespace HR.Core.Models
{
    public class CourseMaterial
    {
        public long Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Mozna potem na enuma zmienic
        /// </summary>
        public CourseType TypeOfCourse { get; set; } //np. Programowanie C#
        public string Description { get; set; }
        public CourseDocuments_REPO Document { get; set; }
    }
}