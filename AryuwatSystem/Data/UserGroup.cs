using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using AryuwatSystem.Baselibary;


namespace AryuwatSystem.Data
{
    public class UserGroup
    {

        public static DataSet SelectUserGroupAll(SqlTransaction trn)
        {
            try
            {
                SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","SELECT")
                                            };
                DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_UserGroup", msSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectUserGroupAll", ex);
            }
        }

        public static int? InsertUserGroup(Entity.UserGroup info, SqlTransaction trn)
        {
            var idMax = UtilityBackEnd.GenNewIdTypeInteger("Select Max(ID) From UserGroup;");
            SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType","INSERT"),
                                                new SqlParameter("@ID", idMax),
                                                new SqlParameter("@GroupCode", idMax+""),
                                                new SqlParameter("@GroupName", info.GroupName)
                                            };
            int intStatus =
                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_UserGroup", msSqlParameter);
            return intStatus;
        }

        public static int? DeleteUserGroup(int id, SqlTransaction trn)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" delete UserGroup where ID = @ID \n");

            try
            {
                SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@ID", id)
                                           };
                int intStatus =
                    SqlHelper.ExecuteNonQuery(trn, CommandType.Text, sb.ToString(), msSqlParameter);
                return intStatus;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int? UpdateUserGroup(Entity.UserGroup info, SqlTransaction trn)
        {
              SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType", "UPDATE"),
                                                new SqlParameter("@ID", info.ID),
                                                new SqlParameter("@GroupCode", info.GroupCode),
                                                new SqlParameter("@GroupName", info.GroupName)
                                            };
            int intStatus =
                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_UserGroup", msSqlParameter);
            return intStatus;
        }

    }
}
