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
    
    public partial class MedicalSection
    {
        public int ID { get; set; }
        public string Section_Code { get; set; }
        public string Section_Name { get; set; }
        public Nullable<decimal> DoctorFee { get; set; }
        public string SurgicalFeeTyp { get; set; }
        public string MedicalTab { get; set; }
        public string SurgicalFeeNewTab { get; set; }
        public string SubSurgicalFee { get; set; }
        public string IncomeTyp { get; set; }
        public string Dept { get; set; }
        public string Centers { get; set; }
    }
}
