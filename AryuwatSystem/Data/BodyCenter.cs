using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using AryuwatSystem.Baselibary;


namespace AryuwatSystem.Data
{
    public class BodyCenter
    {

        public static int? InsertBodyCenter(Entity.BodyCenter info, SqlTransaction trn)
        {
            //StringBuilder sb = new StringBuilder();
            //sb.Append(" INSERT INTO BodyCenter \n");
            //sb.Append("            (CN \n");
            //sb.Append("            ,BodyVaserTite \n");
            //sb.Append("            ,BodyTreatment \n");
            //sb.Append("            ,BodyOther \n");
            //sb.Append("            ,CreateBy \n");
            //sb.Append("            ,CreateDate \n");
            //sb.Append("            ,UpdateBy \n");
            //sb.Append("            ,UpdateDate) \n");
            //sb.Append("      VALUES \n");
            //sb.Append("            (@CN \n");
            //sb.Append("            ,@BodyVaserTite \n");
            //sb.Append("            ,@BodyTreatment \n");
            //sb.Append("            ,@BodyOther \n");
            //sb.Append("            ,@CreateBy \n");
            //sb.Append("            ,getdate() \n");
            //sb.Append("            ,@UpdateBy \n");
            //sb.Append("            ,getdate() \n");
            //sb.Append("            ) \n");
           SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","INSERT"),
                                                new SqlParameter("@CN", info.CN),
                                                new SqlParameter("@BodyVaserTite", info.BodyVaserTite),
                                                new SqlParameter("@BodyTreatment", info.BodyTreatment),
                                                new SqlParameter("@BodyOther", info.BodyOther),
                                                new SqlParameter("@CreateBy", info.CreateBy),
                                                new SqlParameter("@UpdateBy", info.UpdateBy)
                                            };
           int intStatus =
               SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_BodyCenter", msSqlParameter);
           return intStatus;
       }

        public static int? DeleteBodyCenterById(string CN, SqlTransaction trn)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" delete BodyCenter where CN = @CN \n");

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

        public static int? UpdateBodyCenter(Entity.BodyCenter info, SqlTransaction trn)
        {
            //StringBuilder sb = new StringBuilder();
            //sb.Append(" UPDATE BodyCenter \n");
            //sb.Append("    SET BodyVaserTite = @BodyVaserTite \n");
            //sb.Append("       ,BodyTreatment = @BodyTreatment \n");
            //sb.Append("       ,BodyOther = @BodyOther      \n");
            //sb.Append("       ,UpdateBy = @UpdateBy \n");
            //sb.Append("       ,UpdateDate = getdate() \n");
            //sb.Append("  WHERE CN = @CN \n");
            SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType", "UPDATE"),
                                                new SqlParameter("@CN", info.CN),
                                                new SqlParameter("@BodyVaserTite", info.BodyVaserTite),
                                                new SqlParameter("@BodyTreatment", info.BodyTreatment),
                                                new SqlParameter("@BodyOther", info.BodyOther),
                                                new SqlParameter("@UpdateBy", info.UpdateBy)
                                            };
            int intStatus =
                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_BodyCenter", msSqlParameter);
            return intStatus;
        }
    }
}
