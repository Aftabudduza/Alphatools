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
    
    public partial class Catalogs
    {
        public int ID { get; set; }
        public string CatalogName { get; set; }
        public Nullable<System.DateTime> DateListed { get; set; }
        public Nullable<double> Sort { get; set; }
        public string Filename { get; set; }
        public string PDFSize { get; set; }
        public string ZipSize { get; set; }
        public string FileZipped { get; set; }
    }
}
