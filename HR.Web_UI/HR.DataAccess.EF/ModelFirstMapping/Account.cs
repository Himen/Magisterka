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
    
    public partial class Account
    {
        public Account()
        {
            this.AccountLogs = new HashSet<AccountLog>();
        }
    
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public byte[] Photo { get; set; }
        public int AccountType { get; set; }
        public byte DataState { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<System.DateTime> EditDate { get; set; }
        public long PersonId { get; set; }
    
        public virtual Person Person { get; set; }
        public virtual ICollection<AccountLog> AccountLogs { get; set; }
    }
}
