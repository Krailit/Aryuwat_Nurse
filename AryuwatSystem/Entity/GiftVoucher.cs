using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Entity
{
    public class GiftVoucher_Barter
    {
        public string QueryType { get; set; }
        public string GiftCode { get; set; }
        public string GiftType { get; set; }
        public string BarterCode { get; set; }
 
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public string GiftDetail { get; set; }
        public string Gift_Active { get; set; }
        public string BarterDetail { get; set; }
        public string Barter_Active { get; set; }
        public decimal PriceCredit { get; set; }

        public string CN { get; set; }
        public string EN { get; set; }
        public string ENApp { get; set; }
        public string Remark { get; set; }
        public string MS_Code { get; set; }
        public string ListOrder { get; set; }
        public string Sono { get; set; }
        public string MS_CodeFIX { get; set; }

       
        public int PageNumber { get; set; }
        
    }
}
