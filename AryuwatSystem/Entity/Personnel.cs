using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Entity
{
   public class Personnel
    {
        public string EN { get; set; }
        public DateTime? DateRegister { get; set; }
        public string PersonnelType { get; set; }
        public string PrefixCode { get; set; }
        public string TName { get; set; }
        public string TSurname { get; set; }
        public string TNickname { get; set; }
        public string EFirstname { get; set; }
        public string EMiddlename { get; set; }
        public string ELastname { get; set; }
        public string ENickname { get; set; }
        public DateTime? DateBirth { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public int? Height { get; set; }
        public int? Weights { get; set; }
        public string Nationality { get; set; }
        public string Race { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string E_mail { get; set; }
        public string AddressId { get; set; }
        public string Building { get; set; }
        public string Soi { get; set; }
        public string Road { get; set; }
        public string Sub_district { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
        public string PostCode { get; set; }
        public string IdCard { get; set; }
        public string PassportId { get; set; }
        public DateTime? DateStartW { get; set; }
        public DateTime? DateEndW { get; set; }
        public string Username { get; set; }
        public string Passwords { get; set; }
        public string UserGroup { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string QueryType { get; set; }
        public string ImagePath { get; set; }
        public string ImageFilename { get; set; }
       public string BranchID { get; set; }
       public string Active { get; set; }
       public string BranchAuth { get; set; }
       
       
      
        public int PageNumber { get; set; }
    }

     
   public static class Userinfo
   {
       public static bool Login { get; set; }
       public static string EN { get; set; }
       public static DateTime? DateRegister { get; set; }
       public static string PersonnelType { get; set; }
       public static string PrefixCode { get; set; }
       public static string TName { get; set; }

       public static string TSurname { get; set; }
       public static string TNickname { get; set; }
       public static string EFirstname { get; set; }
       public static string EMiddlename { get; set; }
       public static string ELastname { get; set; }
       public static string ENickname { get; set; }
       public static DateTime? DateBirth { get; set; }
       public static int? Age { get; set; }
       public static string Gender { get; set; }
       public static int? Height { get; set; }
       public static int? Weights { get; set; }
       public static int NotiCount { get; set; }
       
       public static string Nationality { get; set; }
       public static string Race { get; set; }
       public static string Mobile1 { get; set; }
       public static string Mobile2 { get; set; }
       public static string Telephone1 { get; set; }
       public static string Telephone2 { get; set; }
       public static string E_mail { get; set; }
       public static string AddressId { get; set; }
       public static string Building { get; set; }
       public static string Soi { get; set; }
       public static string Road { get; set; }
       public static string Sub_district { get; set; }
       public static string District { get; set; }
       public static string Province { get; set; }
       public static string PostCode { get; set; }
       public static string IdCard { get; set; }
       public static string PassportId { get; set; }
       public static DateTime? DateStartW { get; set; }
       public static DateTime? DateEndW { get; set; }
       public static string Username { get; set; }
       public static string Passwords { get; set; }
       public static string UserGroup { get; set; }
       public static string CreateBy { get; set; }
       public static DateTime? CreateDate { get; set; }
       public static string UpdateBy { get; set; }
       public static DateTime? UpdateDate { get; set; }
       public static string QueryType { get; set; }
       public static string ImagePath { get; set; }
       public static string ImageFilename { get; set; }

       public static int PageNumber { get; set; }

       public static int RefreshData { get; set; }
       public static string PriceAgency { get; set; }
       public static string PriceNormal { get; set; }

       public static string IsAdmin { get; set; }
       public static string IS_ADMIN_JOBCOST { get; set; }
       public static string IS_ADMIN_BOOKING { get; set; }
       public static string IS_ADMIN_COURSECARD { get; set; }
       public static double VatRate { get; set; }
       public static double COM_PRODUCT_RATE { get; set; }
       public static double COM_REFERRAL_RATE { get; set; }
       public static string IS_ADMIN_DISCOUNT { get; set; }
       public static double MK_DISCOUNT_JOBCOST { get; set; }
       public static double DIS_FOREING_RATE { get; set; }
       public static string FIX_COOL { get; set; }
       public static string FIX_OTHER_SUB { get; set; }
       public static string FIX_COUPON_Wallet { get; set; }
       public static decimal FIX_COUPON_TOPUP { get; set; }
       public static string FIX_PRO_TOPUP5 { get; set; }
       public static decimal FIX_DR_ROOM_RATE { get; set; }
       public static decimal FIX_DR_ROOM_RATE1 { get; set; }
       public static string FIX_DR_ROOM_CODE { get; set; }
       public static string FIX_DR_ROOM_CODE1 { get; set; }
       public static string FIX_Contains_BUFFET { get; set; }
       public static string RFD_APPROVED { get; set; }
       public static string FIX_BENEFITS { get; set; }
       public static string FIX_VOUCHEROK { get; set; }
       public static string IS_ADMIN_EDIT { get; set; }
       
       
       public static string BranchId { get; set; }
       public static string BranchAuth { get; set; }
       public static string BranchName { get; set; }

       public static double AGENCY_RATE { get; set; }

       public static DataTable UnitName { get; set; }

       public static DataTable MoConfig { get; set; }

       public static string Server { get; set; }
       public static string ServerUser { get; set; }
       public static string ServerPass { get; set; }
       public static bool notiminimum { get; set; }
    }
}
