using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class CreditCardSOT
    {
       public string QueryType { get; set; }
       public string Pay_Code { get; set; }
        public string CD_Code { get; set; }
        public string MS_Code { get; set; }
        public string ListOrder { get; set; }
        public string VN { get; set; }
        public string SO { get; set; }
        public string EN { get; set; }
        public string CN { get; set; }
        public string CardNumber { get; set; }
        public string BankName { get; set; }
        public decimal? CashMoney { get; set; }
        public decimal? MoneyCredit { get; set; }
        public int? PayInID { get; set; }
        public string StatusDel { get; set; }
        public string CardType { get; set; }
        public DateTime DateUpdate { get; set; }
        public string PayRefID { get; set; }
        public string RCNo { get; set; }
        
    }
}
