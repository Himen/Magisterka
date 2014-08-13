using HR.Core.BasicContract;
using HR.Core.Enums;
using System;

namespace HR.Core.Models
{
    /// <summary>
    /// Opisuje dni wolne pracownika. Musi byc porownywane z WorkRegistry
    /// </summary>
    public class Vacation : BaseEntity<long>
    {
        public long IdPerson { get; set; }
        /// <summary>
        /// Pracodawca musi zatwierdzic urlop pracownika
        /// </summary>
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Opisuje powod: urlop, zwolnienie
        /// </summary>
        public VacationType MyProperty { get; set; }
        public string Description { get; set; }
        public virtual CourseDocuments_REPO Document { get; set; }
    }
}
