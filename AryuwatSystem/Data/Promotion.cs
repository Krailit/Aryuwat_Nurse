using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using AryuwatSystem.Baselibary;
using AryuwatSystem.DerClass;
using Entity;

namespace AryuwatSystem.Data
{
    public class Promotion
    {

        public static int? InsertPromotion(ref Entity.Promotion info, SqlTransaction trn)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { 
                new SqlParameter("@QueryType", "InsertPromotion"), 
                new SqlParameter("@PRO_Code", info.PRO_Code), 
                new SqlParameter("@PRO_Name", info.PRO_Name), 
                new SqlParameter("@DateStart", info.DateStart), 
                new SqlParameter("@DateEnd", info.DateEnd), 
                new SqlParameter("@CreateDate", info.CreateDate), 
                new SqlParameter("@CreateBy", info.CreateBy), 
                new SqlParameter("@UpdateDate", info.UpdateDate), 
                new SqlParameter("@UpdateBy", info.UpdateBy), 
                new SqlParameter("@ProPrice", info.ProPrice), 
                new SqlParameter("@ProPriceCredit", info.ProPriceCredit), 
                new SqlParameter("@PRO_Active", info.PRO_Active), 
                new SqlParameter("@PRO_Type", info.PRO_Type), 
                new SqlParameter("@ProductGroup", info.ProductGroup), 
                new SqlParameter("@Remark", info.Remark), 
                new SqlParameter("@PRO_Dept", info.PRO_Dept),
                new SqlParameter("@Fix_Amount", info.Fix_Amount),
                new SqlParameter("@PRO_CalType", info.PRO_CalType),
                new SqlParameter("@MoneyWallet", info.MoneyWallet),
                new SqlParameter("@FixByItem", info.FixByItem)
                
            };
            return new int?(SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_Promotion", commandParameters));
        }
        public static int? InsertPromotionSupplie(SqlTransaction trn, Entity.Promotion info)
        {
            int? intStatus = 0;
            string queryType;
            foreach (Entity.MedicalSupplies c in info.ProSupplieInfo)
            {
                SqlParameter[] msSqlParameter = {
                                                       new SqlParameter("@QueryType", "InsertPromotionSupplie"),
                                                       new SqlParameter("@PRO_Code", info.PRO_Code),
                                                       new SqlParameter("@MS_Code", c.MS_Code),
                                                       new SqlParameter("@Amount", c.Amount),
                                                       new SqlParameter("@ProPrice", c.MS_PROPrice),
                                                };

                intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_Promotion", msSqlParameter);

                //}
            }
            return intStatus;
        }
        public static int? DeletePromotion(SqlTransaction trn, Entity.Promotion info)
        {
            int? intStatus = 0;
            string queryType;
          
                SqlParameter[] msSqlParameter = {
                                                       new SqlParameter("@QueryType", "DeletePromotion"),
                                                       new SqlParameter("@PRO_Code", info.PRO_Code),
                                                };

                intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_Promotion", msSqlParameter);
            return intStatus;
        }
        public static DataSet SelectPromotionPaging(Entity.Promotion info)
        {
            try
            {
                long iRowStart = 0;
                long iRowEnd = 0;
                DerUtility.FindRangeRow(info.PageNumber, ref iRowStart, ref iRowEnd);
                SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType",info.QueryType),
                                               new SqlParameter("@PRO_Code",info.PRO_Code),
                                               new SqlParameter("@PRO_Name",info.PRO_Name),
                                               new SqlParameter("@row_start", iRowStart),
                                               new SqlParameter("@row_end", iRowEnd)
                                            };
                DataSet ds =
                    SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_Promotion", msSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectMedicalSuppliesPaging", ex);
            }
        }

     
       public static int? UpdateMedicalOrder(ref Entity.MedicalOrder info, SqlTransaction trn)
       {
           SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType","UPDATE"),
                                                new SqlParameter("@VN",info.VN),
                                                new SqlParameter("@CN",info.CN),
                                                new SqlParameter("@AgenMemId", info.AgenMemId),
                                                new SqlParameter("@Remark",info.Remark),
                                                new SqlParameter("@CreateBy",info.CreateBy),
                                                new SqlParameter("@SalePrice",info.SalePrice),
                                                new SqlParameter("@MedStatus_Code", info.MedStatus_Code),
                                                new SqlParameter("@UpdateBy", info.UpdateBy),
                                                new SqlParameter("@SONo", info.SONo),
                                                new SqlParameter("@EN_COMS1", info.EN_COMS1),
                                                new SqlParameter("@EN_COMS2", info.EN_COMS2),
                                                new SqlParameter("@PriceTotalRef", info.PriceTotalRef),
                                                new SqlParameter("@VNClose", info.VNRef)
                                            };
         
           int intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_MedicalOrder", msSqlParameter);

           return intStatus;
       }

       public static int? UpdateMedicalOrderStatus(string vn ,string empId,string medStatus, SqlTransaction trn)
       {
           SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType","UPDATEMEDSTATUS"),
                                                new SqlParameter("@VN",vn),
                                                new SqlParameter("@UpdateBy",empId),
                                                new SqlParameter("@MedStatus_Code",medStatus)
                                            };

           int intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_MedicalOrder", msSqlParameter);
           return intStatus;
       }

       public static DataSet SelectMedicalStatus()
       {
           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","SELECTMEDICALSTATUS")
                                            };
               DataSet ds =
                   SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_MedicalOrder", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectMedicalOrderPaging", ex);
           }
       }
       public static DataSet SelectMedicalOrderPaging(Entity.MedicalOrder info)
       {
           try
           {
               long iRowStart = 0;
               long iRowEnd = 0;
               DerUtility.FindRangeRow(info.PageNumber, ref iRowStart, ref iRowEnd);
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","SEARCH"),
                                               new SqlParameter("@VN",info.CustomerInfo.VN),
                                               new SqlParameter("@CO",info.CO),
                                               new SqlParameter("@CN",info.CustomerInfo.CN),
                                               new SqlParameter("@SONo",info.SONo),
                                               new SqlParameter("@Tname",info.CustomerInfo.TName),
                                               new SqlParameter("@TsurName",info.CustomerInfo.TSurname),
                                               new SqlParameter("@row_start", iRowStart),
                                               new SqlParameter("@row_end", iRowEnd),
                                               //new SqlParameter("@MedStatus_Code", info.MedStatus_Code),
                                               new SqlParameter("@MedStatus_CodeNew", info.MedStatus_CodeNew),
                                               new SqlParameter("@MedStatus_CodePending", info.MedStatus_CodePending),
                                               new SqlParameter("@MedStatus_CodeClosed", info.MedStatus_CodeClosed)
                                            };
               DataSet ds =
                   SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_MedicalOrder", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectMedicalOrderPaging", ex);
           }
       }
       public static DataSet SelectMedicalOrderSOTPaging(Entity.MedicalOrder info)
       {
           try
           {
               long iRowStart = 0;
               long iRowEnd = 0;
               DerUtility.FindRangeRow(info.PageNumber, ref iRowStart, ref iRowEnd);
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","SEARCHSOT"),
                                               new SqlParameter("@VN",info.VN),
                                               new SqlParameter("@CO",info.CO),
                                               new SqlParameter("@CN",info.CustomerInfo.CN),
                                               new SqlParameter("@Tname",info.CustomerInfo.TName),
                                               new SqlParameter("@TsurName",info.CustomerInfo.TSurname),
                                               new SqlParameter("@row_start", iRowStart),
                                               new SqlParameter("@row_end", iRowEnd),
                                               //new SqlParameter("@MedStatus_Code", info.MedStatus_Code),
                                               new SqlParameter("@MedStatus_CodeNew", info.MedStatus_CodeNew),
                                               new SqlParameter("@MedStatus_CodePending", info.MedStatus_CodePending),
                                               new SqlParameter("@MedStatus_CodeClosed", info.MedStatus_CodeClosed)
                                            };
               DataSet ds =
                   SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_MedicalOrder", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectMedicalOrderPaging", ex);
           }
       }
       public static DataSet SelectMedicalOrderById(string vn)
       {
           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","SELECTBYID"),
                                               new SqlParameter("@VN",vn)
                                            };
               DataSet ds =
                   SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_MedicalOrder", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectMedicalOrderById", ex);
           }
       }
       public static DataSet SelectMedicalOrderById(string vn,string so)
       {
           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","SELECTBYID"),
                                               new SqlParameter("@VN",vn),
                                               new SqlParameter("@SONo",so)
                                            };
               DataSet ds =
                   SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_MedicalOrder", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectMedicalOrderById", ex);
           }
       }

       public static int? DeleteMedicalOrderById(SqlTransaction trn, string VN, string so)
       {

           try
           {
               SqlParameter[] msSqlParameter = {
                                                   new SqlParameter("@QueryType", "DELETE"),
                                                   new SqlParameter("@VN", VN),
                                                   new SqlParameter("@SONo", so)
                                               };
               int intStatus =
                   SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_MedicalOrder", msSqlParameter);
               return intStatus;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
      
    }


}
