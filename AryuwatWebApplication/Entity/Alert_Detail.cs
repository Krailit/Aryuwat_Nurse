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
    
    public partial class Alert_Detail
    {
        public int ID { get; set; }
        public Nullable<int> FK_Customer_ID { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> Alert_Date { get; set; }
        public Nullable<int> Period { get; set; }
        public Nullable<bool> Publish { get; set; }
        public Nullable<bool> Is_Active { get; set; }
        public string Create_By { get; set; }
        public Nullable<System.DateTime> Create_Date { get; set; }
        public string Update_By { get; set; }
        public Nullable<System.DateTime> Update_Date { get; set; }
    }
}
