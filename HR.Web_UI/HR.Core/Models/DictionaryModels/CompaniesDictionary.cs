using System;

namespace HR.Core.Models.DictionaryModels
{
    /// <summary>
    /// Slownik zawierajacy nazwy firm
    /// </summary>
    public class CompaniesDictionary
    {
        /// <summary>
        /// Nazwa firmy
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Panstwo w ktorej sie znajduje
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Adress firmy
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Krotki opis o niej
        /// </summary>
        public string About { get; set; }
    }
}
