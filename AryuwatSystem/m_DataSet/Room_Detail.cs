//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AryuwatSystem.m_DataSet
{
    using System;
    using System.Collections.Generic;
    
    public partial class Room_Detail
    {
        public int ID { get; set; }
        public Nullable<int> FK_Room_ID { get; set; }
        public Nullable<int> FK_MO_ID { get; set; }
        public Nullable<int> Qty_Date { get; set; }
        public Nullable<System.DateTime> Start_Date { get; set; }
        public Nullable<System.DateTime> End_Date { get; set; }
        public Nullable<bool> Is_Active { get; set; }
        public string Create_By { get; set; }
        public Nullable<System.DateTime> Create_Date { get; set; }
        public string Update_By { get; set; }
        public Nullable<System.DateTime> Update_Date { get; set; }
    }
}
