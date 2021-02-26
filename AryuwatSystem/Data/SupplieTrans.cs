using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using AryuwatSystem.Baselibary;
using AryuwatSystem.DerClass;


namespace AryuwatSystem.Data
{
    public class SupplieTrans
    {
        public static DataSet GetListOrder(SqlTransaction trn, string SONo, string MS_Code, string ListOrder)
        {
            try
            {
                SqlParameter[] msSqlParameter = {
                                                 new SqlParameter("@QueryType","GetListOrder"),
                                               new SqlParameter("@SONo",SONo),
                                               new SqlParameter("@MS_Code",MS_Code),
                                               new SqlParameter("@ListOrder",ListOrder)
                                            };
                DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_SupplieTrans", msSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectMedicalSuppliesBySection", ex);
            }
        }
        public static int? InsertSupplieTransRenewal(List<Entity.SupplieTrans> info,int RenewAddMonth, SqlTransaction trn)
        {
            int? intStatus = 0;
            foreach (Entity.SupplieTrans c in info)
            {

                SqlParameter[] msSqlParameter = {
                                                       new SqlParameter("@QueryType",c.QueryType),
                                                       new SqlParameter("@SONo",c.SONo),
                                                       new SqlParameter("@VN", c.VN),
                                                       new SqlParameter("@MS_Code", c.MS_Code),
                                                       new SqlParameter("@ListOrder",c.ListOrder), 
                                                       new SqlParameter("@ExpireDate",c.ExpireDate),
                                                       new SqlParameter("@Note",c.Note),
                                                       new SqlParameter("@EN", c.EN), 
                                                       new SqlParameter("@RenewAddMonth", RenewAddMonth),
                                                       new SqlParameter("@RenewStartDate", c.RenewStartDate)
                                                       
                                                       
                          };

                intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_SupplieTrans", msSqlParameter);

            }
            return intStatus;
        }
        public static int? InsertSupplieTrans(Entity.SupplieTrans[] info, SqlTransaction trn, Entity.MedicalOrder infoM)
       {
           int? intStatus = 0;
           string queryType;
           foreach (Entity.SupplieTrans c in info)
           {

                   SqlParameter[] msSqlParameter = {
                                                       new SqlParameter("@QueryType", "INSERT"),
                                                       new SqlParameter("@VN", infoM.VN),
                                                       new SqlParameter("@MS_Code", c.MS_Code),
                                                       new SqlParameter("@Amount", c.Amount),
                                                       new SqlParameter("@NumOfUse", c.NumOfUse),
                                                       new SqlParameter("@FlagUse", c.FlagUse),
                                                       new SqlParameter("@FreeAmount", c.FreeAmount),
                                                       new SqlParameter("@Complimentary",c.Complimentary),
                                                       new SqlParameter("@MarketingBudget",c.MarketingBudget),
                                                       new SqlParameter("@Subject",c.Subject),
                                                       new SqlParameter("@Gift",c.Gift),
                                                       new SqlParameter("@GiftNumber",c.GiftNumber),
                                                       new SqlParameter("MergStatus",c.MergStatus), 
                                                       new SqlParameter("FeeRate",c.FeeRate),
                                                       new SqlParameter("FeeRate2",c.FeeRate2),
                                                        new SqlParameter("@BeforeAfter",c.BeforeAfter),
                                                        new SqlParameter("@Extras_sale",c.Extras_sale),
                                                        new SqlParameter("@VIP",c.VIP),
                                                        new SqlParameter("@ExpireDate",c.ExpireDate),
                                                        new SqlParameter("@Note",c.Note),
                                                        new SqlParameter("@SONo",infoM.SONo),
                                                        new SqlParameter("@SpecialPrice",c.SpecialPrice),
                                                        new SqlParameter("@MS_Price",c.MS_Price),
                                                        new SqlParameter("@PriceAfterDis",c.PriceAfterDis),
                                                        new SqlParameter("@PRO_MDiscount",c.PRO_MDiscount),
                                                        new SqlParameter("@ListOrder",c.ListOrder),
                                                        new SqlParameter("@BranchId",infoM.BranchId),
                                                        new SqlParameter("@SaleCom",c.SaleCom),
                                                        new SqlParameter("@ByDr",c.ByDr),
                                                        new SqlParameter("@Canceled",c.Canceled),
                                                        new SqlParameter("@FreeType",c.FreeType),
                                                        new SqlParameter("@PRO_Dept",c.PRO_Dept),
                                                        new SqlParameter("@PRO_Code",c.PRO_Code),
                                                        new SqlParameter("@SORef",c.SORef),
                                                        new SqlParameter("@MS_CodeRef",c.MS_CodeRef),
                                                        new SqlParameter("@ListOrderRef",c.ListOrderRef),
                                                        new SqlParameter("@AmountPro",c.AmountPro),
                                                        new SqlParameter("@PricePerPro",c.PricePerPro)
                                                        
                          };

                   intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_SupplieTrans", msSqlParameter);

           }
           return intStatus;
       }
        public static int? InsertSupplieTransRefVN(Entity.SupplieTrans[] info, SqlTransaction trn, Entity.MedicalOrder infoM)
        {
            int? intStatus = 0;

            foreach (Entity.SupplieTrans c in info)
            {

                SqlParameter[] msSqlParameter = {
                                                    new SqlParameter("@QueryType", "DELETE_RefVNTrans"),
                                                    new SqlParameter("@RefVN",c.RefVN),
                          };

                intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_SupplieTrans", msSqlParameter);
                break;
            }

            foreach (Entity.SupplieTrans c in info)
            {

                SqlParameter[] msSqlParameter = {
                                                    new SqlParameter("@QueryType", "INSERT_RefVNTrans"),
                                                    new SqlParameter("@RefVN",c.RefVN),
                                                    new SqlParameter("@MS_Code", c.MS_Code),
                                                    new SqlParameter("@ListOrder",c.ListOrder),
                                                    new SqlParameter("@Amount", c.Amount),
                                                    new SqlParameter("@MS_Price",c.MS_Price),
                                                    new SqlParameter("@Discount",c.Discount),
                                                    new SqlParameter("@SpecialPrice",c.SpecialPrice),
                                                    new SqlParameter("@PriceAfterDis",c.PriceAfterDis),
                                                    new SqlParameter("@Note",c.Note),
                                                    new SqlParameter("@Canceled",c.Canceled),
                                                    new SqlParameter("@MOType",c.MOType),
                                                    new SqlParameter("@FreeType",c.FreeType),
                                                        
                          };

                intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_SupplieTrans", msSqlParameter);

            }
            return intStatus;
        }
        public static int? InsertSupplieTransPro(Entity.SupplieTransPro[] info, SqlTransaction trn, Entity.MedicalOrder infoM)
        {
            int? intStatus = 0;
            foreach (Entity.SupplieTransPro c in info)
            {

                SqlParameter[] msSqlParameter = {
                                                       new SqlParameter("@QueryType", "INSERT"),
                                                       new SqlParameter("@VN", infoM.VN),
                                                       new SqlParameter("@Pro_Code", c.Pro_Code),
                                                       new SqlParameter("@Amount", c.Amount),
                                                       //new SqlParameter("@NumOfUse", c.NumOfUse),
                                                       //new SqlParameter("@FlagUse", c.FlagUse),
                                                       //new SqlParameter("@FreeAmount", c.FreeAmount),
                                                       //new SqlParameter("@Complimentary",c.Complimentary),
                                                       //new SqlParameter("@MarketingBudget",c.MarketingBudget),
                                                       //new SqlParameter("@Subject",c.Subject),
                                                       //new SqlParameter("@Gift",c.Gift),
                                                       //new SqlParameter("@GiftNumber",c.GiftNumber),
                                                       //new SqlParameter("MergStatus",c.MergStatus), 
                                                       //new SqlParameter("FeeRate",c.FeeRate),
                                                       //new SqlParameter("FeeRate2",c.FeeRate2),
                                                       // new SqlParameter("@BeforeAfter",c.BeforeAfter),
                                                       // new SqlParameter("@Extras_sale",c.Extras_sale),
                                                       // new SqlParameter("@VIP",c.VIP),
                                                       // new SqlParameter("@ExpireDate",c.ExpireDate),
                                                        new SqlParameter("@Note",c.Note),
                                                        new SqlParameter("@SONo",infoM.SONo),
                                                        new SqlParameter("@SpecialPrice",c.SpecialPrice),
                                                        new SqlParameter("@Pro_Price",c.Pro_Price),
                                                        new SqlParameter("@PriceAfterDis",c.PriceAfterDis),
                                                        //new SqlParameter("@PRO_MDiscount",c.PRO_MDiscount),
                                                        new SqlParameter("@ListOrder",c.ListOrder),
                                                        new SqlParameter("@ListMS_Code",c.ListMS_Code)
                                                        
                                                        
                                                        
                          };

                intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_PromotionTrans", msSqlParameter);

            }
            return intStatus;
        }
        public static int? InsertFreeTrans(Entity.MedicalOrder info, SqlTransaction trn)
        {
            int? intStatus = 0;
            //=========================================
            foreach (Entity.FreeTrans c in info.FreeTransDel)
            {

                SqlParameter[] msSqlParameter = {
                                                           new SqlParameter("@QueryType", "DeleteFreeTrans"),
                                                           new SqlParameter("@SONo",c.SONo),
                                                           new SqlParameter("@VN", c.VN),
                                                           new SqlParameter("@MS_Code", c.MS_Code),
                                                            new SqlParameter("@ListOrder",c.ListOrder),
                                                            new SqlParameter("@FreeType",c.FreeType),
                                                            new SqlParameter("@GiftCodeOther",c.GiftCodeOther),
                                                            new SqlParameter("@Approve",c.Approve),
                                                            new SqlParameter("@Approve2",c.Approve2),
                                                            new SqlParameter("@Remark",c.Remark)

                              };

                intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_SupplieTrans", msSqlParameter);
            }

            foreach (Entity.FreeTrans c in info.FreeTrans)
            {

                SqlParameter[] msSqlParameter = {
                                                       new SqlParameter("@QueryType", "INSERTFreeTrans"),
                                                       new SqlParameter("@SONo",c.SONo),
                                                       new SqlParameter("@VN", c.VN),
                                                       new SqlParameter("@MS_Code", c.MS_Code),
                                                        new SqlParameter("@ListOrder",c.ListOrder),
                                                        new SqlParameter("@FreeType",c.FreeType),
                                                        new SqlParameter("@GiftCodeOther",c.GiftCodeOther),
                                                        new SqlParameter("@Approve",c.Approve),
                                                        new SqlParameter("@Approve2",c.Approve2),
                                                        new SqlParameter("@Remark",c.Remark)
                                                        
                          };

                intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_SupplieTrans", msSqlParameter);

            }
            return intStatus;
        }
       public static int? UpdateSupplieTrans(Entity.SupplieTrans[] info, SqlTransaction trn, string VN)
       {
           int intStatus = 0;
           foreach (Entity.SupplieTrans c in info)
           {
               SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType","Update"),
                                                new SqlParameter("@VN",VN),
                                                new SqlParameter("@MS_Code",c.MS_Code),
                                                new SqlParameter("@Amount",c.Amount),
                                                new SqlParameter("@NumOfUse",c.NumOfUse),
                                                new SqlParameter("@FlagUse",c.FlagUse),
                                                new SqlParameter("@FreeAmount",c.FreeAmount),
                                                new SqlParameter("@Complimentary",c.Complimentary),
                                                new SqlParameter("@MarketingBudget",c.MarketingBudget),
                                                new SqlParameter("@Subject",c.Subject),
                                                new SqlParameter("@Gift",c.Gift),
                                                new SqlParameter("@GiftNumber",c.GiftNumber),
                                                new SqlParameter("@FeeRate",c.FeeRate),
                                                new SqlParameter("@FeeRate2",c.FeeRate2),
                                                new SqlParameter("@BeforeAfter",c.BeforeAfter),
                                                new SqlParameter("@Extras_sale",c.Extras_sale),
                                                new SqlParameter("@VIP",c.VIP),
                                                new SqlParameter("@ExpireDate",c.ExpireDate),
                                                new SqlParameter("@Note",c.Note),
                                                new SqlParameter("@SpecialPrice",c.SpecialPrice),
                                                new SqlParameter("@PriceAfterDis",c.PriceAfterDis)
                                            };

               intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_SupplieTrans", msSqlParameter);

           }
           return intStatus;
       }

       public static DataSet GetIdSupplieTrans(SqlTransaction trn, string VN, string ms_code)
       {
           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","SELECTBYID"),
                                               new SqlParameter("@VN",VN), 
                                               new SqlParameter("MS_Code",ms_code)

                                            };
               DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_SupplieTrans", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.GetIdSupplieTrans", ex);
           }
       }

       public static int? DeleteSupplieTrans(SqlTransaction trn, string VN, string so)
       {
           int intStatus = 0;

           SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType", "DELETE"),
                                               new SqlParameter("@VN", VN),
                                               new SqlParameter("@SONo", so)
                                           };

           intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_SupplieTrans", msSqlParameter);

           return intStatus;
       }

       public static int? DeleteSupplies(Entity.SupplieTrans[] info, SqlTransaction trn)
       {
           StringBuilder sb = new StringBuilder();
           int intStatus = 0;
           sb.Append(" delete [SupplieTrans] where VN = @VN AND SONo=@SONo AND MS_Code = @MS_Code and ListOrder=@ListOrder  ; delete [PromotionTrans] where VN = @VN AND SONo=@SONo AND Pro_Code = @MS_Code and ListOrder=@ListOrder \n");

           try
           {
               foreach (Entity.SupplieTrans supplieTranse in info)
               {


                   SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@VN", supplieTranse.VN),
                                               new SqlParameter("@SONo", supplieTranse.SONo),
                                               new SqlParameter("@MS_Code", supplieTranse.MS_Code),
                                               new SqlParameter("@ListOrder", supplieTranse.ListOrder)
                                           };
                   intStatus =
                       SqlHelper.ExecuteNonQuery(trn, CommandType.Text, sb.ToString(), msSqlParameter);

               }
               return intStatus;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public static int? DeleteSuppliesByID(Entity.SupplieTrans[] info, SqlTransaction trn)
       {
            int intStatus = 0;
           try
           {
               foreach (Entity.SupplieTrans supplieTranse in info)
               {
                   SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType", "DELETEBYID"),
                                               new SqlParameter("@VN", supplieTranse.VN),
                                               new SqlParameter("@SONo", supplieTranse.SONo),
                                               new SqlParameter("@MS_Code", supplieTranse.MS_Code),
                                               new SqlParameter("@ListOrder", supplieTranse.ListOrder),
                                               new SqlParameter("@BranchID", supplieTranse.BranchID),
                                               new SqlParameter("@PRO_Dept",supplieTranse.PRO_Dept),
                                               new SqlParameter("@PRO_Code",supplieTranse.PRO_Code),
                                               new SqlParameter("@SORef",supplieTranse.SORef),
                                               new SqlParameter("@MS_CodeRef",supplieTranse.MS_CodeRef),
                                               new SqlParameter("@ListOrderRef",supplieTranse.ListOrderRef)
                                               
                                           };
                   intStatus =
                       SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_SupplieTrans", msSqlParameter);

               }
           
           }
           catch (Exception ex)
           {
               throw ex;
           }
            return intStatus;
       }
     


    }


}
