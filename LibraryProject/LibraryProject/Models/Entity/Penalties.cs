//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryProject.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Penalties
    {
        public int PenaltyId { get; set; }
        public Nullable<int> Member { get; set; }
        public Nullable<System.DateTime> PenaltyStart { get; set; }
        public Nullable<System.DateTime> PenaltyEnd { get; set; }
        public Nullable<decimal> PenaltyAmount { get; set; }
        public Nullable<int> PenaltyReason { get; set; }
    
        public virtual Members Members { get; set; }
        public virtual Rents Rents { get; set; }
    }
}