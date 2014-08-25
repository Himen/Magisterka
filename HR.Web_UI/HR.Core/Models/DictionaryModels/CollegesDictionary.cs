using HR.Core.BasicContract;
using System;

namespace HR.Core.Models.DictionaryModels
{
    /// <summary>
    /// Slownik przechowujacy najpopularniejsze uczelnie
    /// </summary>
    public class CollegesDictionary : BaseEntity<long>
    {
        /// <summary>
        /// Nazwa uczelni
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Panstwo w ktorej sie znajduje
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Miasto
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Adress tej uczelni
        /// </summary>
        public string Address { get; set; }
    }
}
