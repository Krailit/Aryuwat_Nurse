using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using AryuwatSystem.Baselibary;


namespace AryuwatSystem.Data
{
    public class HairCenter
    {
        public static int? InsertHairCenter(Entity.HairCenter info, SqlTransaction trn)
        {
            //StringBuilder sb = new StringBuilder();
            //sb.Append(" INSERT INTO HairCenter \n");
            //sb.Append("            (CN \n");
            //sb.Append("            ,HairTransplantation \n");
            //sb.Append("            ,HairReform \n");
            //sb.Append("            ,HairOther \n");
            //sb.Append("            ,CreateBy \n");
            //sb.Append("            ,CreateDate \n");
            //sb.Append("            ,UpdateBy \n");
            //sb.Append("            ,UpdateDate) \n");
            //sb.Append("      VALUES \n");
            //sb.Append("            (@CN \n");
            //sb.Append("            ,@HairTransplantation \n");
            //sb.Append("            ,@HairReform \n");
            //sb.Append("            ,@HairOther \n");
            //sb.Append("            ,@CreateBy \n");
            //sb.Append("            ,getdate() \n");
            //sb.Append("            ,@UpdateBy \n");
            //sb.Append("            ,getdate()) \n");
            SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType", "INSERT"),
                                                new SqlParameter("@CN", info.CN),
                                                new SqlParameter("@HairTransplantation", info.HairTransplantation),
                                                new SqlParameter("@HairReform", info.HairReform),
                                                new SqlParameter("@HairOther", info.HairOther),
                                                new SqlParameter("@CreateBy", info.CreateBy),
                                                new SqlParameter("@UpdateBy", info.UpdateBy)
                                            };
           int intStatus =
               SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_HairCenter", msSqlParameter);
           return intStatus;
       }

        public static int? DeleteHairCenterById(string CN, SqlTransaction trn)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" delete HairCenter where CN = @CN \n");

            try
            {
                SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@CN", CN)
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

        public static int? UpdateHairCenter(Entity.HairCenter info, SqlTransaction trn)
        {
            //StringBuilder sb = new StringBuilder();
            //sb.Append(" UPDATE HairCenter \n");
            //sb.Append("    SET HairTransplantation = @HairTransplantation \n");
            //sb.Append("       ,HairReform = @HairReform \n");
            //sb.Append("       ,HairOther = @HairOther \n");
            //sb.Append("       ,UpdateBy = @UpdateBy \n");
            //sb.Append("       ,UpdateDate = getdate() \n");
            //sb.Append("  WHERE CN = @CN \n");
            SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType", "UPDATE"),
                                                new SqlParameter("@CN", info.CN),
                                                new SqlParameter("@HairTransplantation", info.HairTransplantation),
                                                new SqlParameter("@HairReform", info.HairReform),
                                                new SqlParameter("@HairOther", info.HairOther),
                                                new SqlParameter("@UpdateBy", info.UpdateBy)
                                            };
            int intStatus =
                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_HairCenter", msSqlParameter);
            return intStatus;
        }
    }
}
