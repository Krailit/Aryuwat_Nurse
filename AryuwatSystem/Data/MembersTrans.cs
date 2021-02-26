using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using AryuwatSystem.Baselibary;


namespace AryuwatSystem.Data
{
    public class MembersTrans
    {
        public static int? InsertMembersTrans(Dictionary<string,Entity.MembersTrans> info, SqlTransaction trn)
        {
            int intStatus = 0;
            string sql = "";
            if (info.Any())
            {
                foreach (var item in info)
                {
                    sql = string.Format("Delete from MemberTrans where VN='{0}' and MS_Code='{1}';", item.Value.VN, item.Value.MS_Code);
                    sql += string.Format("Insert into MemberTrans values('{0}','{1}','{2}');", item.Value.VN, item.Value.MS_Code, item.Value.CN);
                }
                //SqlParameter[] msSqlParameter = {
                //                                    new SqlParameter("@QueryType", "INSERT"),
                //                                    new SqlParameter("@CN_MAIN)", info.CN_MAIN),
                //                                };
                intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.Text, sql);
            }
            return intStatus;
        }
       // public static int? InsertMembersTrans(List<Entity.MembersTrans> info, SqlTransaction trn)
       // {
       //     SqlParameter[] msSqlParameter = {
       //                                         new SqlParameter("@QueryType", "INSERT"),
       //                                         new SqlParameter("@VN", info.VN),
       //                                         new SqlParameter("@CN", info.CN),
       //                                         new SqlParameter("@MS_Code", info.MS_Code )
       //                                     };
       //    int intStatus =
       //        SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_MembersTrans", msSqlParameter);
       //    return intStatus;
       //}

        //public static int? DeleteMembersTransById(Entity.MembersTrans info, SqlTransaction trn)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    try
        //    {
        //        SqlParameter[] msSqlParameter = {
        //                                       new SqlParameter("@QueryType", "DELETE"),
        //                                        new SqlParameter("@VN", info.VN),
        //                                        new SqlParameter("@CN", info.CN)
        //                                   };
        //        int intStatus =
        //      SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_MembersTrans", msSqlParameter);
        //        return intStatus;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}



        internal static int InsertMembersTrans(Dictionary<string, List<Entity.MembersTrans>> info, SqlTransaction trn)
        {
            int intStatus = 0;
            string sql = "";
            if (info.Any())
            {
                foreach (KeyValuePair<string, List<Entity.MembersTrans>> item in info)
                {
                    sql += string.Format("Delete from MemberTrans where VN='{0}' and MS_Code='{1}';", item.Value[0].VN, item.Value[0].MS_Code);
                    foreach (Entity.MembersTrans m in item.Value)
                    {
                         sql += string.Format("Insert into MemberTrans values('{0}','{1}','{2}');", m.VN, m.MS_Code, m.CN);
                    }

                }
                //SqlParameter[] msSqlParameter = {
                //                                    new SqlParameter("@QueryType", "INSERT"),
                //                                    new SqlParameter("@CN_MAIN)", info.CN_MAIN),
                //                                };
                intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.Text, sql);
            }
            return intStatus;
        }
    }
}
