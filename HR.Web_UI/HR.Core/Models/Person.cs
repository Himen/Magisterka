using HR.Core.BasicContract;
using HR.Core.Enums;
using System;
using System.Collections.Generic;

namespace HR.Core.Models
{
    /// <summary>
    /// To moze byc pracownik jak i rowniez kandydat
    /// </summary>
    public class Person : BaseEntity<long>
    {
        public long? ManagerId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public int BuildingNumber { get; set; }
        public int ApartmentNumber { get; set; }
        public long NIP { get; set; }
        public string IDCard { get; set; }
        public string PESEL { get; set; }

        /// <summary>
        /// Tytuł naukowy
        /// </summary>
        //public string Education { get; set; }

        /// <summary>
        /// Specializacja - np. Programista ASP. NET
        /// </summary>
        public ProfesionType Profession { get; set; }

        //jeszcze relacje z innymi tabelami 

        public virtual ICollection<College> Colleges { get; set; }

        public virtual Delegation Delegation { get; set; }

        public virtual Person Manager { get; set; }
    }
}
