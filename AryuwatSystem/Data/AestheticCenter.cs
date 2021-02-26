using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using AryuwatSystem.Baselibary;


namespace AryuwatSystem.Data
{
    public class AestheticCenter
    {

       public static int? InsertAestheticCenter( Entity.AestheticCenter info, SqlTransaction trn)
       {
           //StringBuilder sb = new StringBuilder();
           //sb.Append(" INSERT INTO AestheticCenter \n");
           //sb.Append("            (CN \n");
           //sb.Append("            ,FacialDesign \n");
           //sb.Append("            ,FacialTreatment \n");
           //sb.Append("            ,Laser \n");
           //sb.Append("            ,AestheticOther \n");
           //sb.Append("            ,CreateBy \n");
           //sb.Append("            ,CreateDate \n");
           //sb.Append("            ,UpdateBy \n");
           //sb.Append("            ,UpdateDate) \n");
           //sb.Append("      VALUES \n");
           //sb.Append("            (@CN \n");
           //sb.Append("            ,@FacialDesign \n");
           //sb.Append("            ,@FacialTreatment \n");
           //sb.Append("            ,@Laser \n");
           //sb.Append("            ,@AestheticOther \n");
           //sb.Append("            ,@CreateBy \n");
           //sb.Append("            ,getdate() \n");
           //sb.Append("            ,@UpdateBy  \n");
           //sb.Append("            ,getdate() \n");
           //sb.Append("            ) \n");
           SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType", "INSERT"),
                                                new SqlParameter("@CN", info.CN),
                                                new SqlParameter("@FacialDesign", info.FacialDesign),
                                                new SqlParameter("@FacialTreatment", info.FacialTreatment),
                                                new SqlParameter("@Laser", info.Laser),
                                                new SqlParameter("@AestheticOther", info.AestheticOther),
                                                new SqlParameter("@CreateBy", info.CreateBy),
                                                new SqlParameter("@UpdateBy", info.UpdateBy)
                                            };
           int intStatus =
               SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_AestheticCenter", msSqlParameter);
           return intStatus;
       }

       public static int? DeleteAestheticCenterById(string CN, SqlTransaction trn)
       {
           StringBuilder sb = new StringBuilder();
           sb.Append(" delete AestheticCenter where CN = @CN \n");

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

       public static int? UpdateAestheticCenter(Entity.AestheticCenter info, SqlTransaction trn)
       {
           try
           {
          
           //StringBuilder sb = new StringBuilder();
           //sb.Append(" UPDATE AestheticCenter \n");
           //sb.Append("    SET FacialDesign = @FacialDesign \n");
           //sb.Append("       ,FacialTreatment = @FacialTreatment \n");
           //sb.Append("       ,Laser = @Laser \n");
           //sb.Append("       ,AestheticOther = @AestheticOther \n");
           //sb.Append("       ,UpdateBy = @UpdateBy \n");
           //sb.Append("       ,UpdateDate = getdate() \n");
           //sb.Append("  WHERE CN = @CN \n");
               SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType", "UPDATE"),
                                                new SqlParameter("@CN", info.CN),
                                                new SqlParameter("@FacialDesign", info.FacialDesign),
                                                new SqlParameter("@FacialTreatment", info.FacialTreatment),
                                                new SqlParameter("@Laser", info.Laser),
                                                new SqlParameter("@AestheticOther", info.AestheticOther),
                                                new SqlParameter("@UpdateBy", info.UpdateBy)
                                            };
           int intStatus =
               SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_AestheticCenter", msSqlParameter);
           return intStatus;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
    }
}
