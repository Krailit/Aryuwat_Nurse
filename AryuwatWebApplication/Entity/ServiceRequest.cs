//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AryuwatWebApplication.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class ServiceRequest
    {
        public string ID { get; set; }
        public string SONo { get; set; }
        public string VN { get; set; }
        public string MS_Code { get; set; }
        public string ListOrder { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> NumOfUse { get; set; }
        public Nullable<decimal> BalQty { get; set; }
        public Nullable<decimal> BalBath { get; set; }
        public string ENPrint { get; set; }
        public Nullable<System.DateTime> DatePrint { get; set; }
        public string Change { get; set; }
        public string ChangeToMS_Code { get; set; }
        public string Cancel { get; set; }
        public string Note { get; set; }
        public string Pro_Code { get; set; }
    }
}
