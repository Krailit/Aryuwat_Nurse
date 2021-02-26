using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using AryuwatSystem.Baselibary;


namespace AryuwatSystem.Data
{
    public class CustProvider
    {

        public static DataSet SelectCustProviderAll(SqlTransaction trn, string TypeCustomer)
        {
            try
            {
                SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","SELECT"),
                                               new SqlParameter("@TypeCustomer",TypeCustomer)
                                            };
                DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_CustProvider", msSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectCustProviderAll", ex);
            }
        }
    }
}
