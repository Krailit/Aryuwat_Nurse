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
    
    public partial class PatientData
    {
        public int ID { get; set; }
        public Nullable<int> FK_Customer_ID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Time { get; set; }
        public string T { get; set; }
        public string R { get; set; }
        public string BP { get; set; }
        public string O2 { get; set; }
        public string PulseSBP { get; set; }
        public string PulseDBP { get; set; }
        public string In_Oral { get; set; }
        public string In_Parenteral { get; set; }
        public string Out_Stools { get; set; }
        public string Out_Urine { get; set; }
        public Nullable<bool> Is_Active { get; set; }
        public string Create_By { get; set; }
        public Nullable<System.DateTime> Create_Date { get; set; }
        public string Update_By { get; set; }
        public Nullable<System.DateTime> Update_Date { get; set; }
    }
}
