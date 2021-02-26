using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Refund
    {
        public string QueryType { get; set; }
        public string RFD { get; set; }
        public string VN { get; set; }
        public string SONo { get; set; }
        public string RefVN { get; set; }//เลขใบยา

        public string MS_Code { get; set; }
        public string ListOrder { get; set; }

        public decimal RefundBath { get; set; }

        public DateTime RefundDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime LastUsed { get; set; }
        
        public string RefundType { get; set; }
        public string RefundRemark { get; set; }
        public string PayType { get; set; }

        public string PayCustName { get; set; }
        public string PayBankID { get; set; }
        public string PayBankNumber { get; set; }

        public string RefundSince { get; set; }
        public string BranchId { get; set; }
        public string CN { get; set; }
        public string Dr { get; set; }
        public string Approved { get; set; }

        public List<SupplieTrans> listSuppleTrans { get; set; }
        
    }
   
}
