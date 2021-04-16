using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Entity
{
    public class MedicalOrder
    {
        public string QueryType { get; set; }
        public string VN { get; set; }
        public string CO { get; set; }
        public string SONo { get; set; }
        public string EN_COMS1 { get; set; }
        public string EN_COMS2 { get; set; }
        public string Notes { get; set; }

        public decimal PriceTotalRef { get; set; }

        public string VNRef { get; set; }
        public string SORef { get; set; }
        public string RefMO { get; set; }
        public string RefVN { get; set; }
        
        public string ContrackID { get; set; }
        public string ListOrder { get; set; }
        public string BranchId { get; set; }
        public decimal ProCreditRemain { get; set; }

        public DateTime? Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        public int? Room_Status { get; set; }


        public string MS_Code { get; set; }
        public List<string> ListMS_Code { get; set; }
        public string CN { get; set; }
        public string EN_Save { get; set; }
        
        public string Remark { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateBy { get; set; }
        public int PageNumber { get; set; }
        public string MedStatus_Code { get; set; }
        public Entity.Customer CustomerInfo { get; set; }
        public Entity.SupplieTrans[] SupplieTransInfo { get; set; }
        public Entity.FreeTrans[] FreeTrans { get; set; }
        public Entity.FreeTrans[] FreeTransDel { get; set; }
        public Entity.SupplieTransPro[] SupplieTransProInfo { get; set; }
        public Entity.HowYouhear HowYouhearInfo { get; set; }
        
        
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
        public string MoneyCheckComplete { get; set; }
        
        public string UseTransId
        {
            get; set; 
        }

        public string AgenMemId { get; set; }
        public string AgenMemIdOPD { get; set; }
        public string EM_COM1 { get; set; }
        public string EM_COM2 { get; set; }
        public string DR_COM { get; set; }
        public string MOType { get; set; }
        public string PRO_Code { get; set; }
        public string OldKey { get; set; }
        public string Product { get; set; }

        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string SORefAccount { get; set; }
        
        public Dictionary<string, List<Entity.MembersTrans>> dicMembersTran { get; set; }
        public Dictionary<string, List<Entity.MembersTrans>> dicMembersTranDel { get; set; }
    }
}
