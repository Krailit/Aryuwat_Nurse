using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class SupplieTrans
    {
        public string QueryType { get; set; }
        public string VN { get; set; }
        public string SONo { get; set; }
        public string SORef { get; set; }//โอนมาจาก SO นี้
        public string RefVN { get; set; }//เลขใบยา

        public string MS_Name { get; set; }
        public string MS_CodeRef { get; set; }//โอนมาจาก MO_Code นี้
        public string MS_Code { get; set; }
        public string MS_CodeM { get; set; }
        public string MS_CodeS { get; set; }
        public string ListOrderS { get; set; }
        public decimal Amount { get; set; }
        public decimal NumOfUse { get; set; }
        public string FlagUse { get; set; }//ใช้เก็บสถานะว่า ซื้อแล้วใช้เลยหรือเปล่า 1 = ใช้เลย 0 ยังไม่ใช้
        public decimal? FreeAmount { get; set; }//จำนวนฟรี เช่น กรณีปลูกผมว่าปลูกให้ฟรีกี่ กราฟ
        public decimal DiscountPercen { get; set; }
        public decimal DiscountBath { get; set; }
        public decimal PriceAfterDis { get; set; }
        public decimal UpPrice { get; set; }
        public decimal DiscountB { get; set; }
        
        public decimal PayByItem { get; set; }
        
        public string Complimentary { get; set; }
        public string MarketingBudget { get; set; }
        public string Subject { get; set; }
        public string Gift { get; set; }
        public string GiftNumber { get; set; }
        
        public string MergStatus { get; set; }//ใช้เก็บว่า รหัสโค้ดที่รวมกัน
        public double FeeRate { get; set; }
        public double FeeRate2 { get; set; }
        public double SpecialPrice { get; set; }
        public double Discount { get; set; }
        public double MS_Price { get; set; }
        
        public string BeforeAfter { get; set; }
        public string Extras_sale { get; set; }
        public string VIP { get; set; }
        public string ExpireDate { get; set; }
        public DateTime RenewStartDate { get; set; }

        public string Note { get; set; }
        public string PRO_MDiscount { get; set; }
        public string ListOrder { get; set; }
        public string ListOrderM { get; set; }
        public string ListOrderRef { get; set; }//โอนมาจาก ListOrder นี้
        public string ListMS_Code { get; set; }
        public string BranchID { get; set; }
        public string SaleCom { get; set; }
        public string ByDr { get; set; }
        public string Canceled { get; set; }
        public string FreeType { get; set; }
        public FreeTrans freeTrans { get; set; }
        public string PRO_Dept { get; set; }
        public string PRO_Code { get; set; }
        public string EN { get; set; }
        public string AmountPro { get; set; }
        public string PricePerPro { get; set; }
        public string MOType { get; set; }
        public int RenewAddMonth { get; set; }





    }
    public class SupplieTransPro
    {
        public string QueryType { get; set; }
        public string VN { get; set; }
        public string SONo { get; set; }
        public string Pro_Code { get; set; }
        public decimal Amount { get; set; }
        public decimal NumOfUse { get; set; }
        public string FlagUse { get; set; }//ใช้เก็บสถานะว่า ซื้อแล้วใช้เลยหรือเปล่า 1 = ใช้เลย 0 ยังไม่ใช้
        public decimal? FreeAmount { get; set; }//จำนวนฟรี เช่น กรณีปลูกผมว่าปลูกให้ฟรีกี่ กราฟ
        public string DiscountBathByItem { get; set; }
        public string DiscountBath { get; set; }
        public decimal PriceAfterDis { get; set; }
        public decimal PayByItem { get; set; }

        public string Complimentary { get; set; }
        public string MarketingBudget { get; set; }
        public string Subject { get; set; }
        public string Gift { get; set; }
        public string GiftNumber { get; set; }

        public string MergStatus { get; set; }//ใช้เก็บว่า รหัสโค้ดที่รวมกัน
        public double FeeRate { get; set; }
        public double FeeRate2 { get; set; }
        public double SpecialPrice { get; set; }
        public double Pro_Price { get; set; }

        public string BeforeAfter { get; set; }
        public string Extras_sale { get; set; }
        public string VIP { get; set; }
        public string ExpireDate { get; set; }

        public string Note { get; set; }
        public string PRO_MDiscount { get; set; }
        public string ListOrder { get; set; }
        public string ListMS_Code { get; set; }

    }
}
