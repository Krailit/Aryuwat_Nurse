using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using AryuwatSystem.Baselibary;
using Entity.Validation;

namespace AryuwatSystem.Data
{
    public class CreditCardSOT
    {
        public static int? InsertCreditCardSOT(Entity.CreditCardSOT[] info, SqlTransaction trn)
        {
            int intStatus = 0;
            string strMaxId = "";
            string strPrefix = "";//DOC56120001
            double runNo = 0;
            try
            {
                //strMaxId = UtilityBackEnd.GenMaxSeqnoValues("CDC");
                //strPrefix = strMaxId.Substring(0, 7);
                //runNo = double.Parse(strMaxId.Substring(7, 4));
                foreach (Entity.CreditCardSOT item in info)
                {
                    if (item.StatusDel !="DEL")
                    {
                        // item.CD_Code = strPrefix + runNo.ToString("0000");
                        SqlParameter[] msSqlParameter = {
                                                            //new SqlParameter("@QueryType", "INSERTCREDITCARD"),
                                                            new SqlParameter("@CreditCashQueryType", item.QueryType),
                                                            new SqlParameter("@Pay_Code", item.Pay_Code),
                                                            new SqlParameter("@VN", item.VN),
                                                            new SqlParameter("@SO", item.SO),
                                                            new SqlParameter("@CD_Code", item.CD_Code),
                                                            new SqlParameter("@CardNumber", item.CardNumber),
                                                            new SqlParameter("@CN", item.CN),
                                                            new SqlParameter("@DateUpdate", item.DateUpdate),
                                                            new SqlParameter("@CashMoney", item.CashMoney),
                                                            new SqlParameter("@PayInID", item.PayInID),
                                                            new SqlParameter("@EN", item.EN),
                                                            new SqlParameter("@CardType", item.CardType),
                                                            new SqlParameter("@RCNo", item.RCNo),
                                                            
                                                        };

                        intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_SumOfTreatment",
                                                              msSqlParameter);
                        if (intStatus == 1) runNo += 1;
                    }
                    else
                    {
                        intStatus = DeleteCashCredit(item.Pay_Code, trn);
                    }
                }
                return intStatus;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.InsertSumOfTreatment", ex);
            }
        }

        public static int DeleteCashCredit(string ID, SqlTransaction trn)
        {
            int intStatus = 0;
            try
            {
                SqlParameter[] msSqlParameter = {
                                                    new SqlParameter("@QueryType","DELETECREDITCARD"),
                                                    new SqlParameter("@Pay_Code",ID)
                                                    };

                intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_SumOfTreatment", msSqlParameter);
                return intStatus;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.UpdateSumOfTreatment", ex);
            }
        }
      
    }
}
