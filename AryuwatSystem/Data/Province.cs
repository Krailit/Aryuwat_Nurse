using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using AryuwatSystem.Baselibary;

namespace AryuwatSystem.Data
{
   public class Province
    {
       public static DataSet SelectProvinceAll(SqlTransaction trn)
       {
           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","PROVINCE_CODE")
                                            };

               
               DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_Administrative", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectProvinceAll", ex);
           }
       }
    }
}
