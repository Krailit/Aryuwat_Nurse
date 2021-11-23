using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class MedicalSupplies
    {
        public string QueryType { get; set; }
        public int? ID { get; set; }
        public string MS_Code { get; set; }
        public string SellToCN { get; set; }
        public string MS_Section { get; set; }
        public string MS_Name { get; set; }
        public string MS_Detail { get; set; }
        public string MS_Unit { get; set; }
        public string MS_SubUnit { get; set; }
        public string REQUnitCode { get; set; }


        public string MS_CourseDuration { get; set; }
        public string Tab { get; set; }
        public string Tabwhere { get; set; }
        public int? Number_C { get; set; }
        public string MS_Type { get; set; }

        public double? MS_CLPrice { get; set; }
        public double? MS_CAPrice { get; set; }
        public double? MS_CMPrice { get; set; }
        public double? MS_PROPrice { get; set; }
        public int? MS_Order { get; set; }
        public double? MS_Instock { get; set; }
        public double? MS_MinimumStock { get; set; }
        public int PageNumber { get; set; }
        public string MS_Code_Ref { get; set; }
        public double? FeeRate { get; set; }
        public double? FeeRate2 { get; set; }
        public double? MaxDiscount { get; set; }
        public string Vat { get; set; }
        public string BranchID { get; set; }
        public string OperationID { get; set; }
        public string PurchaseID { get; set; }
        public decimal Amount { get; set; }
        public double Discount { get; set; }
        public string Active { get; set; }
        public string BOM { get; set; }
        public string COMS { get; set; }

        public double? AnountPerMainUnit { get; set; }
        public double? Receive_Cost { get; set; }
        public double? MS_CostAVG { get; set; }
        public double? ReceiveQuantity { get; set; }
        public double? Sell_Cost { get; set; }
        public double? SellQuantity { get; set; }
        public string DocNo { get; set; }
        public string ActiveType { get; set; }
        public string ByID { get; set; }
        public DateTime SaveDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string SStartDate { get; set; }
        public string SEndDate { get; set; }
        public string FixSearch { get; set; }

        public string ENSave { get; set; }
        public string Remark { get; set; }
        public List<MedicalSupplies> LisItemStock { get; set; }
        public string LocationID { get; set; }
        //REQ Stock
        public string REQNo { get; set; }
        public DateTime? REQDate { get; set; }
        public double? QuantityReceive { get; set; }
        public double? Quantity { get; set; }
        public double? QuantityReply { get; set; }
        public string EN_Req { get; set; }
        public string EN_ReqTo { get; set; }
        public string Req_BranchId { get; set; }
        public string ReqTo_BranchId { get; set; }
        public string RemarkReply { get; set; }
        public string Approved { get; set; }
        public string WHCode { get; set; }
        public string Dept { get; set; }

        public string ReturnsFlag { get; set; }
        public string UrgentFlag { get; set; }
        public string Fortype { get; set; }
        public string SOno { get; set; }
        public DateTime? Replydate { get; set; }

        public string EatAmount { get; set; }
        public string EatPerday { get; set; }
        public string BeforeMeals { get; set; }
        public string AfterMeals { get; set; }

        public string Morning { get; set; }
        public string Lunch { get; set; }
        public string Evening { get; set; }
        public string BeforeBed { get; set; }
        public string Everyhours { get; set; }
        public string eat { get; set; }
        public string coat { get; set; }
        public string coatArea { get; set; }

        public string VN { get; set; }

        public bool? Type_Doctor { get; set; }




        //       private DateTime replydate = DateTime.Now;   แบบใส่ค่า default
        //       public DateTime Replydate 

        //{
        //    get 
        //    {
        //        return replydate;
        //    }
        //    set
        //    {
        //        replydate = value;
        //    }
        //}
        //public DateTime Replydate { get; set; }





    }
}
