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
    public class GiftVoucher_Barter
    {

        public static int? InsertGiftVoucher(ref Entity.GiftVoucher_Barter info, SqlTransaction trn)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { 
                new SqlParameter("@QueryType", "InsertGiftVoucher"), 
                new SqlParameter("@DateStart", info.DateStart), 
                new SqlParameter("@DateEnd", info.DateEnd), 
                new SqlParameter("@GiftDetail", info.GiftDetail), 
                new SqlParameter("@PriceCredit", info.PriceCredit), 
                new SqlParameter("@Gift_Active", info.Gift_Active), 
                new SqlParameter("@GiftCode", info.GiftCode),
                new SqlParameter("@CN", info.CN),
                new SqlParameter("@EN", info.EN),
                new SqlParameter("@ENApp", info.ENApp),
                new SqlParameter("@Remark", info.Remark),
                new SqlParameter("@MS_Code", info.MS_Code),
                new SqlParameter("@ListOrder", info.ListOrder),
                new SqlParameter("@Sono", info.Sono),
                new SqlParameter("@MS_CodeFIX", info.MS_CodeFIX),
                new SqlParameter("@GiftType", info.GiftType),
                
                
            };

            return new int?(SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_GiftVoucher_Barter", commandParameters));
        }
        public static int? InsertBarter(ref Entity.GiftVoucher_Barter info, SqlTransaction trn)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { 
                new SqlParameter("@QueryType", "InsertBarter"), 
                new SqlParameter("@DateStart", info.DateStart), 
                new SqlParameter("@DateEnd", info.DateEnd), 
                new SqlParameter("@GiftDetail", info.GiftDetail), 
                new SqlParameter("@PriceCredit", info.PriceCredit), 
                new SqlParameter("@Gift_Active", info.Gift_Active), 
                new SqlParameter("@GiftCode", info.GiftCode)
                
            };
            return new int?(SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_GiftVoucher_Barter", commandParameters));
        }
        public static int ImportGiftVoucher(SqlTransaction trn, string sql)
        {
            int intStatus = 0;
            string queryType;

            SqlParameter[] msSqlParameter = {
                                                       new SqlParameter("@QueryType", "ImportGiftVoucher"),
                                                       new SqlParameter("@sql", sql),
                                                };

            intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_GiftVoucher_Barter", msSqlParameter);
            return intStatus;
        }
        public static int ImportBarter(SqlTransaction trn, string sql)
        {
            int intStatus = 0;
            string queryType;

            SqlParameter[] msSqlParameter = {
                                                       new SqlParameter("@QueryType", "ImportBarter"),
                                                       new SqlParameter("@sql", sql),
                                                };

            intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_GiftVoucher_Barter", msSqlParameter);
            return intStatus;
        }
        public static int? DeleteGiftVoucher(SqlTransaction trn, Entity.GiftVoucher_Barter info)
        {
            int? intStatus = 0;
            string queryType;
          
                SqlParameter[] msSqlParameter = {
                                                       new SqlParameter("@QueryType",info.QueryType),
                                                       new SqlParameter("@GiftCode", info.GiftCode),
                                                };

                intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_GiftVoucher_Barter", msSqlParameter);
            return intStatus;
        }
        public static int? DeleteBarter(SqlTransaction trn, Entity.GiftVoucher_Barter info)
        {
            int? intStatus = 0;
            string queryType;

            SqlParameter[] msSqlParameter = {
                                                       new SqlParameter("@QueryType", "DeleteBarter"),
                                                       new SqlParameter("@BarterCode", info.BarterCode),
                                                };

            intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_GiftVoucher_Barter", msSqlParameter);
            return intStatus;
        }

        public static DataSet SelectGiftVoucherByID(Entity.GiftVoucher_Barter info)
        {
            try
            {
                long iRowStart = 0;
                long iRowEnd = 0;
                DerUtility.FindRangeRow(info.PageNumber, ref iRowStart, ref iRowEnd);
                SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType",info.QueryType),
                                               new SqlParameter("@GiftCode",info.GiftCode),
                                            };
                DataSet ds =
                    SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_GiftVoucher_Barter", msSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectMedicalSuppliesPaging", ex);
            }
        }
           public static DataSet SelectGiftVoucher_Barter(Entity.GiftVoucher_Barter info)
        {
            try
            {
                long iRowStart = 0;
                long iRowEnd = 0;
                DerUtility.FindRangeRow(info.PageNumber, ref iRowStart, ref iRowEnd);
                SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType",info.QueryType),
                                               new SqlParameter("@GiftCode",info.GiftCode),
                                               new SqlParameter("@GiftDetail",info.GiftDetail),
                                               new SqlParameter("@row_start", iRowStart),
                                               new SqlParameter("@row_end", iRowEnd)
                                            };
                DataSet ds =
                    SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_GiftVoucher_Barter", msSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectMedicalSuppliesPaging", ex);
            }
        }

    }


}
