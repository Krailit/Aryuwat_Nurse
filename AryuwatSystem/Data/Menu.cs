using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using AryuwatSystem.Baselibary;


namespace AryuwatSystem.Data
{
    public class Menu
    {

        public static DataSet SelectMenuAll(SqlTransaction trn)
        {
            try
            {
                SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","SELECT")
                                            };
                DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_Menu", msSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectMenuAll", ex);
            }
        }
    }
}
