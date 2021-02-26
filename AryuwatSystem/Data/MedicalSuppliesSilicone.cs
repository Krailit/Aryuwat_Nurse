using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using AryuwatSystem.Baselibary;
using AryuwatSystem.DerClass;
using Entity.Validation;

namespace AryuwatSystem.Data
{
    public class MedicalSuppliesSilicone
    {


        public static DataSet SelectMedicalSuppliesSiliconeById(SqlTransaction trn, string msCode)
       {
           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","SELECTBYID"),
                                               new SqlParameter("MS_Code",msCode)
                                            };
               DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_MedicalSuppliesSilicone", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectMedicalSuppliesSiliconeById", ex);
           }
       }



    }
}
