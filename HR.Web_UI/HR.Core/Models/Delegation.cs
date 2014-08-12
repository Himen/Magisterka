using System;

namespace HR.Core.Models
{
    /// <summary>
    /// Pamietac jak sie doda delegacje to tez trzeba dodac wolne(usprawiedliwienie).
    /// </summary>
    public class Delegation
    {
        public long Id { get; set; }
        public long IdPerson { get; set; }
        public int DataState { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
