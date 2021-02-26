using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Entity
{
    public class Customer
    {
        public string QueryType { get; set; }
        public string VN { get; set; }
        public string CN { get; set; }
        public string BranchId { get; set; }
        public string ProviderTypID { get; set; }  
        public DateTime? DateRegister { get; set; }
        public string PrefixCode { get; set; }
        public string TName { get; set; }
        public string TSurname { get; set; }
        public string TNickname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Surname { get; set; }
        public string NickName { get; set; }
        public DateTime? DateBirth { get; set; }
        public string DateBirthOther { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public int? Height { get; set; }
        public int? Weights { get; set; }
        public string BloodPressure { get; set; }
        public string Nationality { get; set; }
        public string Race { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public string Telephone { get; set; }
        public string E_mail { get; set; }
        public string AddressId { get; set; }
        public string Building { get; set; }
        public string Soi { get; set; }
        public string Road { get; set; }
        public string Country { get; set; }
        public string Sub_district { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
        public string PostCode { get; set; }
        public string PassportNo { get; set; }
        public string IdCard { get; set; }
        public string VipFlag { get; set; }
        public string Remark { get; set; }
        public string AllergyHistory { get; set; }
        public string UnderlyingDisease { get; set; }
        public string WhereGotTreatment { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string TypeCustomer { get; set; } //ประเภทของลูกค้า เช่น CNT,CNA เป็นต้น



        public string SaleConsult { get; set; }
        public string Celeb { get; set; }

        public string EN { get; set; }
        public string MemID { get; set; }
        public Int32 CFID { get; set; }
        
        

        public string MedStatus_Code { get; set; } 
        public Entity.AestheticCenter AestheticCenterInfo { get; set; }
        public Entity.BodyCenter BodyCenterInfo { get; set; }
        public Entity.CosmeticSurgery CosmeticSurgeryCenterInfo { get; set; }
        public Entity.HairCenter HairCenterInfo { get; set; }
        public Entity.ContactCustomer ContactCustomerInfo { get; set; }
        public Entity.HowYouhear HowYouhearInfo { get; set; }
        public Entity.MedicalOrder MedicalOrder { get; set; }

        public int PageNumber { get; set; }
        public string Image { get; set; }
        public string ImagePath { get; set; }
        public string DocPrefix { get; set; }
        public string CustomerType { get; set; }

        public string AgenMemId { get; set; }
        public int Credit_Bath { get; set; }
        public int Credit_Day { get; set; }
        public List<Entity.MembersGroup> MembersGroupInfo { get; set; }

        public string MainOfficeCust { get; set; }
        public string BranchCust { get; set; }
        public string BranchAuth { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        // Customer Connect
          public string ContactName { get; set; }
          public string ContactFrom { get; set; }
          public string ContactFB_IN_LineID { get; set; }
          public string Interest { get; set; }
          public DateTime? DateConnect { get; set; }
          public DateTime? DateBooking { get; set; }
            public decimal CloseBal { get; set; }
     
                 
    }
    public class SmardCard_FIELD
    {
        public string NID_Number { get; set; }   //1234567890123#

        public string TITLE_T { get; set; }    //Thai title#
        public string NAME_T { get; set; }     //Thai name#
        public string  MIDNAME_T { get; set; }  //Thai mid name#
        public string SURNAME_T { get; set; }  //Thai surname#

        public string TITLE_E { get; set; }    //Eng title#
        public string NAME_E { get; set; }     //Eng name#
        public string MIDNAME_E { get; set; }  //Eng mid name#
        public string SURNAME_E { get; set; }  //Eng surname#

        public string HOME_NO { get; set; }    //12/34#
        public string MOO { get; set; }        //10#
        public string TROK { get; set; }       //ตรอกxxx#
        public string SOI { get; set; }        //ซอยxxx#
        public string ROAD { get; set; }       //ถนนxxx#
        public string TUMBON { get; set; }     //ตำบลxxx#
        public string AMPHOE { get; set; }     //อำเภอxxx#
        public string PROVINCE { get; set; }   //จังหวัดxxx#

        public string GENDER { get; set; }     //1#			//1=male,2=female

        public string BIRTH_DATE { get; set; } //25200131#	    //YYYYMMDD 
        public string ISSUE_PLACE { get; set; }//xxxxxxx#      //
        public string ISSUE_DATE { get; set; } //25580131#     //YYYYMMDD 
        public string EXPIRY_DATE { get; set; }//25680130      //YYYYMMDD 
        public string ISSUE_NUM { get; set; }  //12345678901234 //14-Char
        public Image MyImage { get; set; }  //12345678901234 //14-Char


        
    };
}
