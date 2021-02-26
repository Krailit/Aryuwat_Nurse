using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AryuwatWebApplication.Models
{
    public class Customers
    {
        public string CN { get; set; }
        public DateTime? Dateregister { get; set; }
        public string PrefixCode { get; set; }
        public string Tname { get; set; }
        public string TsurName { get; set; }
        public string Tnickname { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public string NickName { get; set; }
        public DateTime? DateBirth { get; set; }
        public string DateBirthOther { get; set; }
        public int? Age { get; set; }
        public char Gender { get; set; }
        public int? Height { get; set; }
        public int? Weights { get; set; }
        public string Nationality { get; set; }
        public string Race { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public string E_mail { get; set; }
        public string AddressId { get; set; }
        public string Building { get; set; }
        public string Soi { get; set; }
        public string Road { get; set; }
        public string Sub_districtCode { get; set; }
        public string DistrictCode { get; set; }
        public string ProvinceCode { get; set; }
        public string Postcode { get; set; }
        public string PassportNo { get; set; }
        public string IdCard { get; set; }
        public char VipFlag { get; set; }
        public string Remark { get; set; }
        public string AllergyHistory { get; set; }
        public string UnderlyingDisease { get; set; }
        public string WhereGotTreatment { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string Image { get; set; }
        public char CustomerType { get; set; }
        public string CN_old { get; set; }
        public string BranchID { get; set; }
        public string AgenMemID { get; set; }
        public string BloodPressure { get; set; }
        public string ProviderTypID { get; set; }
        public int? Credit_Bath { get; set; }
        public int? Credit_Day { get; set; }
        public string Country_ID { get; set; }
        public string SaleConsult { get; set; }
        public string MainOfficeCust { get; set; }
        public string BranchCust { get; set; }
        public char Celeb { get; set; }
        public string BranchAuth { get; set; }
    }
}