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
    
    public partial class CourseMaterial
    {
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public int CourseType { get; set; }
        public string DocumentName { get; set; }
        public byte[] Document { get; set; }
        public string Description { get; set; }
        public Nullable<long> PersonId { get; set; }
        public byte DataState { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<System.DateTime> EditDate { get; set; }
    
        public virtual Person Person { get; set; }
    }
}
