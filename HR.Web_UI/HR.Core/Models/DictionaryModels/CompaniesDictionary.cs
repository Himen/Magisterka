using HR.Core.BasicContract;
using System;

namespace HR.Core.Models.DictionaryModels
{
    /// <summary>
    /// Slownik zawierajacy nazwy firm
    /// </summary>
    public class CompaniesDictionary : BaseEntity<long>
    {
        /// <summary>
        /// Nazwa firmy
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Panstwo w ktorej sie znajduje
        /// </summary>
        public virtual string Country { get; set; }

        /// <summary>
        /// Adress firmy
        /// </summary>
        public virtual string Address { get; set; }

        /// <summary>
        /// Krotki opis o niej
        /// </summary>
        public virtual string About { get; set; }
    }
}
