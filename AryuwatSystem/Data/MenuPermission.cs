using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using AryuwatSystem.Baselibary;
using AryuwatSystem.DerClass;
using Entity.Validation;


namespace AryuwatSystem.Data
{
    public class MenuPermission
    {
       public static DataSet GetMenuPermission(SqlTransaction trn)
       {
           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","SELECT"),
                                            };
               DataSet dataReader =
                   SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_menupermission", msSqlParameter);
               return dataReader;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.GetPersonnelByUserName", ex);
           }
       }

       public static DataSet GetMenuPermissiongByGroupId(int groupId,SqlTransaction trn)
       {
           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","SELECTBYID"),
                                               new SqlParameter("@GroupId",groupId)
                                            };
               DataSet dataReader =
                   SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_menupermission", msSqlParameter);
               return dataReader;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.GetMenuPermissiongByGroupId", ex);
           }
       }

       public static int? DeleteMenuPermission(int? groupId,SqlTransaction trn)
        {

            try
            {
                SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType", "DELETE"),
                                               new SqlParameter("@GroupId", groupId)
                                           };
                int intStatus =
                    SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_menupermission", msSqlParameter);
                return intStatus;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       public static int InsertMenuPermission(Entity.MenuPermission[] info, SqlTransaction trn)
       {
           int i = -1;
           //StringBuilder sb = new StringBuilder();
           //sb.Remove(0, sb.Length);
           //sb.Append("INSERT INTO MenuPermission  \n");
           //sb.Append("           ( MenuId  \n");
           //sb.Append("           , GroupId ) \n");
           //sb.Append("     VALUES \n");
           //sb.Append("           (@MenuId \n");
           //sb.Append("           ,@GroupId) \n");
           try
           {
               foreach (Entity.MenuPermission item in info)
               {
                   SqlParameter[] msSqlParameter = {
                                                       new SqlParameter("QueryType", "INSERT"),
                                                       new SqlParameter("@MenuId", item.MenuId),
                                                       new SqlParameter("@GroupId", item.GroupId)
                                                   };

                   i = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_menupermission", msSqlParameter);

               }
               return i;
           }
           catch (Exception ex)
           {
               throw new AppException("An error occurred while executing the Data.InsertMenuPermission", ex);
           }
       }      
     
    }


}
