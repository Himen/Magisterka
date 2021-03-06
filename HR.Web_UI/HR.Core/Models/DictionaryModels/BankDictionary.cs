﻿using HR.Core.BasicContract;
using System;

namespace HR.Core.Models.DictionaryModels
{
    /// <summary>
    /// Slownik przechowujacy dane najpopularniejszych bankow
    /// </summary>
    public class BankDictionary : BaseEntity<long>
    {
        /// <summary>
        /// Nazwa banku
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Adres banku
        /// </summary>
        public virtual string Address { get; set; }
    }
}
