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
    
    public partial class CashTransactions
    {
        public int CashTransactionId { get; set; }
        public string Month { get; set; }
        public Nullable<decimal> TotalCash { get; set; }
    }
}
