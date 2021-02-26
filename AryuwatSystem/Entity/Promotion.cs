using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Promotion
    {
        public string QueryType { get; set; }
        public string PRO_Code { get; set; }
        public string PRO_Name { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public string PRO_Active { get; set; }
        public decimal ProPrice { get; set; }
        public decimal ProPriceCredit { get; set; }
        public string Remark { get; set; }
        public string Tabwhere { get; set; }
        public string Tab { get; set; }
        public string PRO_Type { get; set; }
        public string ProductGroup { get; set; }
        public string PRO_Dept { get; set; }
        public decimal Fix_Amount { get; set; }
        public string PRO_CalType { get; set; }
        public string MoneyWallet { get; set; }
        public string FixByItem { get; set; }
        
        
        
       
        public int PageNumber { get; set; }
        public List<Entity.MedicalSupplies> ProSupplieInfo { get; set; }
    }
}
