using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using AryuwatSystem.Baselibary;


namespace AryuwatSystem.Data
{
    public class ContactCustomer
    {

        public static int? InsertContactCustomer(Entity.ContactCustomer info, SqlTransaction trn)
        {
            //StringBuilder sb = new StringBuilder();
            //sb.Append(" INSERT INTO ContactCustomer \n");
            //sb.Append("            (CN \n");
            //sb.Append("            ,PrefixCode \n");
            //sb.Append("            ,Tname \n");
            //sb.Append("            ,TsurName \n");
            //sb.Append("            ,TNickname \n");
            //sb.Append("            ,FirstName \n");
            //sb.Append("            ,MiddleName \n");
            //sb.Append("            ,SurName \n");
            //sb.Append("            ,NickName \n");
            //sb.Append("            ,Gender \n");
            //sb.Append("            ,Mobile1 \n");
            //sb.Append("            ,Mobile2 \n");
            //sb.Append("            ,Tel1 \n");
            //sb.Append("            ,Tel2 \n");
            //sb.Append("            ,RelationFlag \n");
            //sb.Append("            ,RelationOther) \n");
            //sb.Append("      VALUES \n");
            //sb.Append("            (@CN \n");
            //sb.Append("            ,@PrefixCode \n");
            //sb.Append("            ,@Tname \n");
            //sb.Append("            ,@TsurName \n");
            //sb.Append("            ,@TNickname \n");
            //sb.Append("            ,@FirstName \n");
            //sb.Append("            ,@MiddleName \n");
            //sb.Append("            ,@SurName \n");
            //sb.Append("            ,@NickName \n");
            //sb.Append("            ,@Gender \n");
            //sb.Append("            ,@Mobile1 \n");
            //sb.Append("            ,@Mobile2 \n");
            //sb.Append("            ,@Tel1 \n");
            //sb.Append("            ,@Tel2 \n");
            //sb.Append("            ,@RelationFlag \n");
            //sb.Append("            ,@RelationOther) \n");
   
            try
            {
                SqlParameter[] msSqlParameter = {
                                                    new SqlParameter("@QueryType", "INSERT"),
                                                    new SqlParameter("@CN", info.CN),
                                                    new SqlParameter("@PrefixCode", info.PrefixCode),
                                                    new SqlParameter("@Tname", info.Tname),
                                                    new SqlParameter("@TsurName", info.TsurName),
                                                    new SqlParameter("@TNickname", info.TNickname),
                                                    new SqlParameter("@FirstName", info.FirstName),
                                                    new SqlParameter("@MiddleName", info.MiddleName),
                                                    new SqlParameter("@SurName", info.SurName),
                                                    new SqlParameter("@NickName", info.NickName),
                                                    new SqlParameter("@Gender", info.Gender),
                                                    new SqlParameter("@Mobile1", info.Mobile1),
                                                    new SqlParameter("@Mobile2", info.Mobile2),
                                                    new SqlParameter("@Tel1", info.Tel1),
                                                    new SqlParameter("@Tel2", info.Tel2),
                                                    new SqlParameter("@RelationFlag", info.RelationFlag),
                                                    new SqlParameter("@RelationOther", info.RelationOther),
                                                    
                                                    
                                            
                                                };
                int intStatus =
                    SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_ContactCustomer", msSqlParameter);
                return intStatus;
            }
            catch (Exception ex)
            {
                throw ex;
               
            }
        }


        public static int? DeleteContactCustomerById(string CN, SqlTransaction trn)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" delete ContactCustomer where CN = @CN \n");

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

        public static int? UpdateContactCustomer(Entity.ContactCustomer info, SqlTransaction trn)
        {
            StringBuilder sb = new StringBuilder();
            //sb.Append(" UPDATE ContactCustomer \n");
            //sb.Append("    SET PrefixCode = @PrefixCode \n");
            //sb.Append("       ,Tname = @Tname \n");
            //sb.Append("       ,TsurName = @TsurName \n");
            //sb.Append("       ,TNickname = @TNickname \n");
            //sb.Append("       ,FirstName = @FirstName \n");
            //sb.Append("       ,MiddleName = @MiddleName \n");
            //sb.Append("       ,SurName = @SurName \n");
            //sb.Append("       ,NickName = @NickName \n");
            //sb.Append("       ,Gender = @Gender \n");
            //sb.Append("       ,Mobile1 = @Mobile1 \n");
            //sb.Append("       ,Mobile2 = @Mobile2 \n");
            //sb.Append("       ,Tel1 = @Tel1 \n");
            //sb.Append("       ,Tel2 = @Tel2 \n");
            //sb.Append("       ,RelationFlag = @RelationFlag \n");
            //sb.Append("       ,RelationOther = @RelationOther \n");

            //sb.Append("  WHERE CN = @CN \n");
            try
            {
                SqlParameter[] msSqlParameter = {
                                                    new SqlParameter("@QueryType", "UPDATE"),
                                                    new SqlParameter("@CN", info.CN),
                                                    new SqlParameter("@PrefixCode", info.PrefixCode),
                                                    new SqlParameter("@Tname", info.Tname),
                                                    new SqlParameter("@TsurName", info.TsurName),
                                                    new SqlParameter("@TNickname", info.TNickname),
                                                    new SqlParameter("@FirstName", info.FirstName),
                                                    new SqlParameter("@MiddleName", info.MiddleName),
                                                    new SqlParameter("@SurName", info.SurName),
                                                    new SqlParameter("@NickName", info.NickName),
                                                    new SqlParameter("@Gender", info.Gender),
                                                    new SqlParameter("@Mobile1", info.Mobile1),
                                                    new SqlParameter("@Mobile2", info.Mobile2),
                                                    new SqlParameter("@Tel1", info.Tel1),
                                                    new SqlParameter("@Tel2", info.Tel2),
                                                    new SqlParameter("@RelationFlag", info.RelationFlag),
                                                    new SqlParameter("@RelationOther", info.RelationOther),
                                              
                                                };
                int intStatus =
                    SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_ContactCustomer", msSqlParameter);
                return intStatus;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
