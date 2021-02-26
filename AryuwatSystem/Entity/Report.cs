using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Report
    {
        public string QueryType { get; set; }
        public string VN { get; set; }
        public string CO { get; set; }
        public string SONo { get; set; }
        public string EN_COMS1 { get; set; }
        public string EN_COMS2 { get; set; }

        public string BirthMonth { get; set; }

        public decimal PriceTotalRef { get; set; }

        public string VNRef { get; set; }
 

        
        public string MS_Code { get; set; }
        public List<string> ListMS_Code { get; set; }
        public string CN { get; set; }
        public string Remark { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateBy { get; set; }
        public int PageNumber { get; set; }
        public string MedStatus_Code { get; set; }
        public Entity.Customer CustomerInfo { get; set; }
        public Entity.SupplieTrans[] SupplieTransInfo { get; set; }
        //public Entity.MedicalStuff[] MedicalStuffInfo { get; set; }
        public Entity.MedicalOrderDoc[] MedicalOrderDocInfo { get; set; }
        public Entity.MedicalOrderUseTrans[] MedicalOrderUseTransesInfo { get; set; }
        public decimal SalePrice { get; set; }
        public string MedStatus_CodeNew { get; set; }
        public string MedStatus_CodePending { get; set; }
        public string MedStatus_CodeClosed { get; set; }
        public string MedStatus_Unpaid { get; set; }
        public string MedStatus_Deposit { get; set; }
        public string MedStatus_Paid { get; set; }
        public string UseTransId
        {
            get; set; 
        }

        public string AgenMemId { get; set; }
        public string EM_COM1 { get; set; }
        public string EM_COM2 { get; set; }
        public string MOType { get; set; }
        public string PRO_Code { get; set; }

        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int Peroid { get; set; }
        public string BranchId { get; set; }
        public string ShowAll { get; set; }
        public string TodayOnly { get; set; }
        public string FixSearch { get; set; }
        
        
        
        public Dictionary<string, List<Entity.MembersTrans>> dicMembersTran { get; set; }
    }
}
