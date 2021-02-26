using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using AryuwatSystem.Baselibary;


namespace AryuwatSystem.Data
{
    public class MembersGroup
    {

        public static int? InsertMembersGroup(List<Entity.MembersGroup>  info, SqlTransaction trn)
        {
            int intStatus=0;
          
                string sql=string.Format("Delete from MemberGroup where CN_Main='{0}';",info[0].CN_MAIN);
                foreach (Entity.MembersGroup item in info)
	            {
		            sql+=string.Format("Insert into MemberGroup values('{0}','{1}');",item.CN_MAIN,item.CN_SUB);
	            }
                //SqlParameter[] msSqlParameter = {
                //                                    new SqlParameter("@QueryType", "INSERT"),
                //                                    new SqlParameter("@CN_MAIN)", info.CN_MAIN),
                //                                };
                intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.Text, sql);
           return intStatus;
       }

        public static int? DeleteMembersGroupById(Entity.MembersGroup info, SqlTransaction trn)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType", "DELETE"),
                                                new SqlParameter("@CN_MAIN", info.CN_MAIN)
                                           };
                int intStatus =
                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_MembersTrans", msSqlParameter);
                return intStatus;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
    }
}
