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
    
    public partial class MedicalSuppliesStock_org
    {
        public int ID { get; set; }
        public string MS_Code { get; set; }
        public string MS_Section { get; set; }
        public string MS_Name { get; set; }
        public string MS_Detail { get; set; }
        public Nullable<int> MS_CLPrice { get; set; }
        public Nullable<int> MS_CAPrice { get; set; }
        public Nullable<int> MS_CMPrice { get; set; }
        public string MS_Unit { get; set; }
        public string MS_CourseDuration { get; set; }
        public Nullable<int> MS_Order { get; set; }
        public string MS_Type { get; set; }
        public Nullable<decimal> MS_Instock { get; set; }
        public Nullable<int> MS_Number_C { get; set; }
        public string MS_Code_Ref { get; set; }
        public Nullable<decimal> FeeRate { get; set; }
        public Nullable<decimal> FeeRate2 { get; set; }
        public Nullable<decimal> MaxDiscount { get; set; }
        public string Vat { get; set; }
        public string BranchID { get; set; }
        public string OperationID { get; set; }
        public string PurchaseID { get; set; }
        public string Active { get; set; }
        public Nullable<decimal> MS_Cost { get; set; }
        public string LocationID { get; set; }
        public string SupplierID { get; set; }
    }
}
