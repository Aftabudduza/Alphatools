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
    
    public partial class NewProducts
    {
        public string PartNo { get; set; }
        public decimal ProductPageCode { get; set; }
        public System.DateTime DatePosted { get; set; }
        public string NewProductDescription { get; set; }
        public string NewProductTitle { get; set; }
        public string NewProductSummary { get; set; }
        public string NewProductPhoto { get; set; }
        public string NewProductPDF { get; set; }
        public bool CurrentYN { get; set; }
        public Nullable<System.DateTime> DateListed { get; set; }
    
        public virtual ProductPage ProductPage { get; set; }
    }
}
