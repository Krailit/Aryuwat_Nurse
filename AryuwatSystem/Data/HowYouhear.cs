using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using AryuwatSystem.Baselibary;


namespace AryuwatSystem.Data
{
    public class HowYouhear
    {

        public static int? InsertHowYouhear(Entity.HowYouhear info, SqlTransaction trn)
        {
            //StringBuilder sb = new StringBuilder();
            //sb.Append(" INSERT INTO HowYouhear \n");
            //sb.Append("            (CN \n");
            //sb.Append("            ,Newspaper \n");
            //sb.Append("            ,Magazine \n");
            //sb.Append("            ,Internet \n");
            //sb.Append("            ,Friend \n");
            //sb.Append("            ,Travelthrough \n");
            //sb.Append("            ,HowYouhearOther) \n");
            //sb.Append("      VALUES \n");
            //sb.Append("            (@CN \n");
            //sb.Append("            ,@Newspaper \n");
            //sb.Append("            ,@Magazine \n");
            //sb.Append("            ,@Internet \n");
            //sb.Append("            ,@Friend \n");
            //sb.Append("            ,@Travelthrough \n");
            //sb.Append("            ,@HowYouhearOther \n");
            //sb.Append(" 	   ) \n");
            SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType",info.QueryType ),//info.QueryType
                                                new SqlParameter("@CN", info.CN),
                                                new SqlParameter("@SOno", info.SOno),
                                                new SqlParameter("@Newspaper", info.Newspaper),
                                                new SqlParameter("@Magazine", info.Magazine),
                                                new SqlParameter("@Internet", info.Internet),
                                                new SqlParameter("@Friend", info.Friend),
                                                new SqlParameter("@Travelthrough", info.Travelthrough),
                                                new SqlParameter("@HowYouhearOther", info.HowYouhearOther),
                                                new SqlParameter("@Facebook", info.Facebook),
                                                new SqlParameter("@Instagram", info.Instagram),
                                                new SqlParameter("@Sms", info.Sms),
                                                new SqlParameter("@LineAt", info.LineAt),
                                                new SqlParameter("@Line", info.Line),
                                                new SqlParameter("@Taxi", info.Taxi),
                                                new SqlParameter("@CallIn", info.CallIn),
                                                new SqlParameter("@Agency", info.Agency),
                                                new SqlParameter("@AgencyOPD", info.AgencyOPD)
                                            };
           int intStatus =
               SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_HowYouhear", msSqlParameter);
           return intStatus;
       }

        public static int? DeleteHowYouhearById(string CN, SqlTransaction trn)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" delete HowYouhear where CN = @CN \n");

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

        public static int? UpdateHowYouhear(Entity.HowYouhear info, SqlTransaction trn)
        {
            //StringBuilder sb = new StringBuilder();
            //sb.Append(" UPDATE HowYouhear \n");
            //sb.Append("    SET Newspaper = @Newspaper \n");
            //sb.Append("       ,Magazine = @Magazine \n");
            //sb.Append("       ,Internet = @Internet \n");
            //sb.Append("       ,Friend = @Friend \n");
            //sb.Append("       ,Travelthrough = @Travelthrough \n");
            //sb.Append("       ,HowYouhearOther = @HowYouhearOther \n");
            //sb.Append("  WHERE CN = @CN \n");
            SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType",info.QueryType ),//info.QueryType
                                                new SqlParameter("@CN", info.CN),
                                                new SqlParameter("@SOno", info.SOno),
                                                new SqlParameter("@Newspaper", info.Newspaper),
                                                new SqlParameter("@Magazine", info.Magazine),
                                                new SqlParameter("@Internet", info.Internet),
                                                new SqlParameter("@Friend", info.Friend),
                                                new SqlParameter("@Travelthrough", info.Travelthrough),
                                                new SqlParameter("@HowYouhearOther", info.HowYouhearOther),
                                                new SqlParameter("@Facebook", info.Facebook),
                                                new SqlParameter("@Instagram", info.Instagram),
                                                new SqlParameter("@Sms", info.Sms),
                                                new SqlParameter("@LineAt", info.LineAt),
                                                new SqlParameter("@Line", info.Line),
                                                new SqlParameter("@Taxi", info.Taxi),
                                                new SqlParameter("@TV", info.TV),
                                                new SqlParameter("@CallIn", info.CallIn),
                                                new SqlParameter("@Agency", info.Agency)
                                            };
            int intStatus =
                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_HowYouhear", msSqlParameter);
            return intStatus;
            return intStatus;
        }
      
    }
}
