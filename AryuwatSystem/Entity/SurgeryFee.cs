using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class SurgeryFee
    {
       public string QueryType { get; set; }
       public int? ID { get; set; }

        public string SUR_ID { get; set; }
        public string CN { get; set; }
        public string VN { get; set; }
        public string Sono { get; set; }
        
        public string MS_Code { get; set; }
        public string ListOrder { get; set; }
        public string Anesthesia { get; set; }
        public DateTime? ProcedureDate { get; set; }
        public DateTime? Com_Date { get; set; }
        public double? Com_Bath { get; set; }
        public decimal? NetIncome { get; set; }
        public decimal? Charges { get; set; }
        public int? Admit { get; set; }
        
        public DateTime? StartAnesth { get; set; }
        public DateTime? EndAnesth { get; set; }
        public DateTime? StartProcedure { get; set; }
        public DateTime? EndProcedure { get; set; }
        public string Remark { get; set; }
        public string Tablename { get; set; }
        public string EN_Save { get; set; }
        public string UseTransId { get; set; }
        public string whereDate { get; set; }
        public int? ExtraMoney { get; set; }
        public string EN { get; set; }
        //public string Position_IDCheck { get; set; }
        public string Position_IDSave { get; set; }
        public string Position_ID { get; set; }
        public string Position_Type { get; set; }

        public string SubSurgical { get; set; }
        
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string BranchId { get; set; }
        public double? ActuallyAmount { get; set; }

        public Entity.MedicalStuff[] MedicalStuffInfo { get; set; }

        public int PageNumber { get; set; }

    }
}
