//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AlphatoolServices.BO
{
    using System;
    using System.Collections.Generic;
    
    public partial class MMaintenanceCard
    {
        public MMaintenanceCard()
        {
            this.ProductPage = new HashSet<ProductPage>();
            this.TechnicalLibrary = new HashSet<TechnicalLibrary>();
        }
    
        public decimal MaintenanceCardID { get; set; }
        public string MaintenanceCardDescription { get; set; }
        public string MaintenanceCardLink { get; set; }
    
        public virtual ICollection<ProductPage> ProductPage { get; set; }
        public virtual ICollection<TechnicalLibrary> TechnicalLibrary { get; set; }
    }
}
