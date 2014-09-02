//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HR.DataAccess.EF.ModelFirstMapping
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contract
    {
        public Contract()
        {
            this.Employments = new HashSet<Employment>();
        }
    
        public long Id { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public int ContractType { get; set; }
        public int ContractDimension { get; set; }
        public Nullable<double> MonthBenefit { get; set; }
        public Nullable<double> BenefitPerHour { get; set; }
        public byte DataState { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<System.DateTime> EditDate { get; set; }
    
        public virtual ICollection<Employment> Employments { get; set; }
    }
}
