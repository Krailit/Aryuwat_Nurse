using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using AryuwatSystem.Baselibary;

namespace AryuwatSystem.Data
{
   public class District
    {
       public static DataSet SelectDistrictAll(SqlTransaction trn)
       {
           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","DISTRICT_CODE")
                                            };
               DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_Administrative", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectDistrictAll", ex);
           }
       }

       public static DataSet SelectDistrictById(SqlTransaction trn,int provinceId)
       {
           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@PROVINCE_ID",provinceId)
                                               ,new SqlParameter("@QueryType","SELECT")
                                            };
               DataSet ds =SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_Administrative", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectDistrictById", ex);
           }
       }

    }
}
