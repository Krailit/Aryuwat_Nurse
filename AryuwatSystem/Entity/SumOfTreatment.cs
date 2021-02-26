using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class SumOfTreatment
    {
       public string QueryType { get; set; }

        public int MedStatus_Code { get; set; }
        public string CN { get; set; }
        public string VN { get; set; }
        public string SO { get; set; }
        public string SORef { get; set; }
        public string PRO_Code { get; set; }
        public string EN_COMS { get; set; }
        public string EN_COMS2 { get; set; }
        public string EN_COMSDoctor { get; set; }
        public double? Com_Bath { get; set; }
        public double? Com_Bath2 { get; set; }

        public string EN_Save { get; set; }
        public string SOT_Code { get; set; }

        public DateTime? DateSave { get; set; }
        public DateTime? DateUpdate { get; set; }
        public double? PettyCash { get; set; }
        public double? Debtor { get; set; }
        public double? AbroadMoney { get; set; }
        public double? DomesticMoney { get; set; }
        public double? ChecksMoney { get; set; }
        public double? DebitMoney { get; set; }
        public double? SalePrice { get; set; }
        public double? Discount { get; set; }
        public double? NetAmount { get; set; }
        public double? EarnestMoney { get; set; }
        public double? Unpaid { get; set; }
        public double? DiscountAllItemBath { get; set; }
        public double? DiscountBath { get; set; }
        public double? DiscountPercen { get; set; }
        
        public double? PriceAfterDis { get; set; }
        
        public string Remark { get; set; }
        public string BillTo { get; set; }
        public string ReCeiptNo { get; set; }
        public double? ReceiptBath { get; set; }
        public DateTime? ReceiptDate { get; set; }

        public string NonVat { get; set; }
        public string Vat { get; set; }

        public double Refund { get; set; }
        public DateTime RefundDate { get; set; }
        public string RefundType { get; set; }
        public string RefundRemark { get; set; }
        
        
        public int PageNumber { get; set; }
        public Dictionary<string, double> dicRCN { get; set; }
        public string DateNotIn { get; set; }

        public Entity.CreditCardSOT[] CreditCardSotInfo { get; set; }
        public Entity.SupplieTrans[] SupplieTranInfo { get; set; }
    }
}
