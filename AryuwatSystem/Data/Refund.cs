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
    public class Refund
    {

        public static DataSet SelectRefund(Entity.Refund info)
       {
           try
           {
              
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType",info.QueryType),
                                               new SqlParameter("@RFD",info.RFD),
                                               new SqlParameter("@StartDate",info.StartDate),
                                               new SqlParameter("@EndDate",info.EndDate),
                                               new SqlParameter("@SONo",info.SONo),
                                               new SqlParameter("@CN",info.CN),
                                               new SqlParameter("@VN",info.VN),
                                               new SqlParameter("@BranchId",info.BranchId)
                                               
                                            };
               DataSet ds =
                   SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_Refund", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectReportPaging", ex);
           }
       }
        public static int DeleteRefundByRFD(string RFD, SqlTransaction trn)
        {
            int intStatus;
           try
           {
              
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","DeleteRefundByRFD"),
                                               new SqlParameter("@RFD",RFD),
                                               
                                            };
               intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_Refund", msSqlParameter);
               return intStatus;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectReportPaging", ex);
           }
       }
        
        public static int InsertRefund(Entity.Refund info, SqlTransaction trn)
        {
            int intStatus;
            try
            {
                            
                SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","InsertRefund"),
                                               new SqlParameter("@RFD",info.RFD),
                                               new SqlParameter("@VN",info.VN),
                                               new SqlParameter("@SONo",info.SONo),
                                               new SqlParameter("@RefVN",info.RefVN),
                                               new SqlParameter("@Refund",info.RefundBath),
                                               new SqlParameter("@RefundDate",info.RefundDate),
                                               new SqlParameter("@RefundType",info.RefundType),
                                               new SqlParameter("@RefundRemark",info.RefundRemark),
                                               new SqlParameter("@PayType",info.PayType),
                                               new SqlParameter("@PayBankID",info.PayBankID),
                                               new SqlParameter("@PayCustName",info.PayCustName),
                                               
                                               new SqlParameter("@PayBankNumber",info.PayBankNumber),
                                               new SqlParameter("@RefundSince",info.RefundSince),
                                               //new SqlParameter("@BranchId",info.BranchId),
                                               new SqlParameter("@Approved",info.Approved),
                                               new SqlParameter("@LastUsed",info.LastUsed),
                                               
                                               new SqlParameter("@Dr",info.Dr),
                                            };
                 intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_Refund", msSqlParameter);
                 if (info.listSuppleTrans != null)
                 {
                     foreach (Entity.SupplieTrans c in info.listSuppleTrans)
                     {

                         SqlParameter[] msSqlParameterx = {
                                                    new SqlParameter("@QueryType", "InsertRefundTran"),
                                                    new SqlParameter("@RFD", info.RFD),
                                                    new SqlParameter("@SOno", info.SONo),
                                                    new SqlParameter("@VN", info.VN),
                                                    new SqlParameter("@MS_Code", c.MS_Code),
                                                    new SqlParameter("@ListOrder",c.ListOrder),
                                                    new SqlParameter("@RefVN",info.RefVN),
                          };

                         intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_Refund", msSqlParameterx);

                     }
                 }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectReportPaging", ex);
            }
            return intStatus;
        }
      
    }


}
