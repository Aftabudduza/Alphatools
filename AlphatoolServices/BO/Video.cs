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
    
    public partial class Video
    {
        public Video()
        {
            this.ProductVideo = new HashSet<ProductVideo>();
        }
    
        public int VideoID { get; set; }
        public Nullable<decimal> WebSection { get; set; }
        public Nullable<bool> VCurrentYN { get; set; }
        public string Video720x480 { get; set; }
        public string VideoMP4 { get; set; }
        public string VideoName { get; set; }
        public string VideoDescription { get; set; }
        public string VideoLink2 { get; set; }
        public Nullable<System.DateTime> VUploadDate { get; set; }
        public Nullable<System.DateTime> VStopDate { get; set; }
        public string VideoText { get; set; }
        public string Vimage { get; set; }
        public string Filename { get; set; }
        public string Updated { get; set; }
        public string Industry { get; set; }
        public string Status { get; set; }
        public string VideoLink { get; set; }
    
        public virtual ICollection<ProductVideo> ProductVideo { get; set; }
    }
}
