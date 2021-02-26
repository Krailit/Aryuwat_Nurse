using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class MedicalOrderUseTrans
    {
        // Properties
        public decimal AmountTotal { get; set; }
        public decimal AmountOfUse { get; set; }
        public decimal AmountBalance { get; set; }
        public decimal Shot { get; set; }
        
        public string CN { get; set; }
        public string CN_USED { get; set; }
        public string CO { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? DateOfUse { get; set; }
        public string Id { get; set; }
        public List<MedicalOrderUseTrans> ListMs { get; set; }
        public List<MedicalOrderUseTrans> ListMsCancel { get; set; }
        public string MedicalOrderStatus { get; set; }
        public MedicalStuff[] MedicalStuffInfo { get; set; }
        public string MS_Code { get; set; }
        public string ListOrder { get; set; }
        public decimal? MSPrice { get; set; }
        public bool PayCash { get; set; }
        public bool PayUse { get; set; }
        public decimal? PriceNewBalance { get; set; }
        public decimal? PriceNewVN { get; set; }
        public decimal? PriceTotal { get; set; }
        public string Remark { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string VN { get; set; }
        public string SOClose { get; set; }
        public string Sono { get; set; }
        public string SONew { get; set; }
        public string SONewOld { get; set; }
        public string RefMO { get; set; }
        public string IsCancel { get; set; }
        public decimal? FeeRate { get; set; }
        public decimal? FeeRate2 { get; set; }
        public decimal? PriceAfterDis { get; set; }
        
        public string swap { get; set; }
        public string BranchId { get; set; }
        public string FlagUse { get; set; }
        public string EN_REQ { get; set; }
        public string EN_Helper { get; set; }
        public string CourseCardID { get; set; }
        public string IsUpdated { get; set; }
        public string PrintSlip { get; set; }
        public decimal? PrintLineOrder { get; set; }
        public string GiftCode { get; set; }
        
       

        
        
        

    }
}
