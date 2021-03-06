﻿using HR.Core.BasicContract;
using HR.Core.Enums;
using System;
using System.Collections.Generic;

namespace HR.Core.Models
{
    /// <summary>
    /// Loguje operacje wykonywane na koncie uzytkownika
    /// </summary>
    public class AccountLog:BaseEntity<long>
    {
        /// <summary>
        /// Nazwa konkretnej akcji jaka zostala wykonana
        /// </summary>
        public virtual string Action { get; set; }

        /// <summary>
        /// Typ akcji jaka została wykonana. Usuniecie konta, edycja..
        /// </summary>
        public virtual ActionType ActionType { get; set; }

        /// <summary>
        /// Szczegolowy opis akcji jaka zostala wykonana
        /// </summary>
        public virtual string ActionDescription { get; set; }

        /// <summary>
        /// Data operacji
        /// </summary>
        public virtual DateTime StartDate { get; set; }

        /// <summary>
        /// Opcjonalna data zakonczenia operacji
        /// </summary>
        public virtual DateTime? EndDate { get; set; }

        /// <summary>
        /// Id konta z ktorego zostało wykonane
        /// </summary>
        public virtual long AccountId { get; set; }

        /// <summary>
        /// Konto z ktorego zostalo wykonane. Narazie rowno znaczne z kontem ktore edytujemy
        /// </summary>
        public virtual Account Account { get; set; }

    }
}
