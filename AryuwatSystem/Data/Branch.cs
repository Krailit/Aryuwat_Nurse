using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using AryuwatSystem.Baselibary;


namespace AryuwatSystem.Data
{
    public class Branch
    {

        public static DataSet SelectBranchAll(SqlTransaction trn)
        {
            try
            {
                SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","SELECT")
                                            };
                DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_Branch", msSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectBranchAll", ex);
            }
        }
    }
}
