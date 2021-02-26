using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using AryuwatSystem.Baselibary;


namespace AryuwatSystem.Data
{
    public class CosmeticSurgeryCenter
    {
       

        public static int? InsertCosmeticSurgery(Entity.CosmeticSurgery info, SqlTransaction trn)
        {
            try
            {
                //var sb = new StringBuilder();
                //sb.Append(" INSERT INTO CosmeticSurgery \n");
                //sb.Append("            (CN \n");
                //sb.Append("            ,Eye \n");
                //sb.Append("            ,Nose \n");
                //sb.Append("            ,Chest \n");
                //sb.Append("            ,Other \n");
                //sb.Append("            ,CreateBy \n");
                //sb.Append("            ,CreateDate \n");
                //sb.Append("            ,UpdateBy \n");
                //sb.Append("            ,UpdateDate) \n");
                //sb.Append("      VALUES \n");
                //sb.Append("            (@CN \n");
                //sb.Append("            ,@Eye \n");
                //sb.Append("            ,@Nose \n");
                //sb.Append("            ,@Chest \n");
                //sb.Append("            ,@Other \n");
                //sb.Append("            ,@CreateBy \n");
                //sb.Append("            ,getdate() \n");
                //sb.Append("            ,@UpdateBy \n");
                //sb.Append("            ,getdate()) \n");

                SqlParameter[] msSqlParameter = {
                                                    new SqlParameter("@QueryType", "INSERT"),
                                                    new SqlParameter("@CN", info.CN),
                                                    new SqlParameter("@Eye", info.Eye),
                                                    new SqlParameter("@Nose", info.Nose),
                                                    new SqlParameter("@Chest", info.Chest),
                                                    new SqlParameter("@Other", info.Other),
                                                    new SqlParameter("@CreateBy", info.CreateBy),
                                                    new SqlParameter("@UpdateBy", info.UpdateBy), 
                                                };
                int intStatus =
                    SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_CosmeticSurgery",
                                              msSqlParameter);
                return intStatus;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static int? DeleteCosmeticSurgeryById(string CN, SqlTransaction trn)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" delete CosmeticSurgery where CN = @CN \n");

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

        public static int? UpdateCosmeticSurgery(Entity.CosmeticSurgery info, SqlTransaction trn)
        {
            try
            {
                //var sb = new StringBuilder();
                //sb.Append(" UPDATE CosmeticSurgery \n");
                //sb.Append("    SET Eye = @Eye \n");
                //sb.Append("       ,Nose = @Nose \n");
                //sb.Append("       ,Chest = @Chest \n");
                //sb.Append("       ,Other = @Other       \n");
                //sb.Append("       ,UpdateBy = @UpdateBy \n");
                //sb.Append("       ,UpdateDate = getdate() \n");
                //sb.Append("  WHERE CN = @CN \n");

                SqlParameter[] msSqlParameter = {
                                                    new SqlParameter("@QueryType", "UPDATE"),
                                                    new SqlParameter("@CN", info.CN),
                                                    new SqlParameter("@Eye", info.Eye),
                                                    new SqlParameter("@Nose", info.Nose),
                                                    new SqlParameter("@Chest", info.Chest),
                                                    new SqlParameter("@Other", info.Other),
                                                    new SqlParameter("@UpdateBy", info.UpdateBy), 
                                                };
                int intStatus =
                    SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_CosmeticSurgery",
                                              msSqlParameter);
                return intStatus;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
