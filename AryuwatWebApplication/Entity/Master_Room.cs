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
    
    public partial class Master_Room
    {
        public int ID { get; set; }
        public string Room_Code { get; set; }
        public string Room_Name { get; set; }
        public Nullable<int> Amount_Day { get; set; }
        public Nullable<decimal> Room_Price { get; set; }
        public Nullable<decimal> Room_PriceCredit { get; set; }
        public string Remark { get; set; }
        public Nullable<bool> Is_Active { get; set; }
        public string Create_By { get; set; }
        public Nullable<System.DateTime> Create_Date { get; set; }
        public string Update_By { get; set; }
        public Nullable<System.DateTime> Update_Date { get; set; }
    }
}
