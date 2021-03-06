﻿
using HR.Core.BasicContract;
namespace HR.Core.Models
{
    /// <summary>
    /// Nazwa jednostki organizacyjnej
    /// </summary>
    public class OrganiziationalUnit : BaseEntity<string>
    {
        /// <summary>
        /// Nazwa jednostki organizayjnej
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Id szefa jednostki organizacyjnej
        /// </summary>
       // public long ManagerId { get; set; }

        /// <summary>
        /// Szef jednostki organizacyjnej
        /// </summary>
        public virtual Person Manager { get; set; }
    }
}
