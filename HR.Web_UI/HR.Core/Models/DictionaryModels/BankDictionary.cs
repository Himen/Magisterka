using System;

namespace HR.Core.Models.DictionaryModels
{
    /// <summary>
    /// Slownik przechowujacy dane najpopularniejszych bankow
    /// </summary>
    public class BankDictionary
    {
        /// <summary>
        /// Nazwa banku
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Adres banku
        /// </summary>
        public string Address { get; set; }
    }
}
