using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using AryuwatSystem.Baselibary;
using AryuwatSystem.DerClass;


namespace AryuwatSystem.Data
{
    public class MedicalOrderDoc
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="trn"></param>
        /// <param name="VN"></param>
        /// <returns></returns>
        public static int? InsertMedicalOrderDoc(Entity.MedicalOrderDoc[] info, SqlTransaction trn, string VN, string Sono)
        {
            int intStatus = 0;
            string idMax = "";
            string strPrefix = "";//DOC56120001
            double  runNo = 0;
            try
            {
                 //idMax = UtilityBackEnd.GenMaxSeqnoValues("FIL");
                 //strPrefix = idMax.Substring(0, 7);
                 //runNo = double.Parse(idMax.Substring(7, 4));
                foreach (Entity.MedicalOrderDoc item in info)
                {
                    //item.Id = strPrefix + runNo.ToString("0000") + "_" + Sono + "_" + VN;
                    //item.FileName = string.IsNullOrEmpty(item.FileName) ? null : item.Id + Path.GetExtension(item.FileName);
                      SqlParameter[] msSqlParameter = {
                                                   new SqlParameter("@QueryType","INSERT"),
                                                   new SqlParameter("@Id",item.Id), 
                                                   new SqlParameter("@VN", VN),
                                                   new SqlParameter("@Sono", Sono),
                                                   new SqlParameter("@FileName", item.FileName),
                                                   new SqlParameter("@Detail",item.Detail)

                                               };
                 intStatus =
                    SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure,"sp_MedicalOrderDoc", msSqlParameter);
                 if (intStatus == 1)
                 {
                     runNo += 1;
                     
                 }
                }
              
                return intStatus;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int? InsertFileScan(List<Entity.MedicalOrderDoc> info, SqlTransaction trn)
        {
            int intStatus = 0;
            string idMax = "";
            string strPrefix = "";
            double  runNo = 0;
            try
            {
                foreach (Entity.MedicalOrderDoc item in info)
                {
                    if (item.Detail == "UPDATE") continue;
                      SqlParameter[] msSqlParameter = {
                                                   new SqlParameter("@QueryType",item.QueryType),
                                                   new SqlParameter("@UseTransId",item.UseTransId), 
                                                   new SqlParameter("@FileName", item.FileName),
                                                   new SqlParameter("@Detail",item.Detail),
                                                   new SqlParameter("@DateScan",item.DateScan),
                                                   new SqlParameter("@Sono",item.Sono),
                                                   new SqlParameter("@VN",item.VN),
                                                   new SqlParameter("@CN",item.CN),
                                                   new SqlParameter("@ENDoctor",item.ENDoctor),
                                                   new SqlParameter("@ENSave",item.ENSave)
                                               };
                 intStatus =SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure,"sp_MedicalOrderDoc", msSqlParameter);
                 if (intStatus == 1)
                 {
                     runNo += 1;
                     
                 }
                }
              
                return intStatus;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        internal static int DeleteFileName(SqlTransaction trn, string Id, string QueryType)
        {
             SqlParameter[] msSqlParameter = {
                                                   new SqlParameter("@QueryType",QueryType),
                                                   new SqlParameter("@Id",Id)

                                               };
                 var intStatus =SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure,"sp_MedicalOrderDoc", msSqlParameter);
            return intStatus;
        }
        internal static int DeleteFileScan(SqlTransaction trn, string Id, string QueryType)
        {
            SqlParameter[] msSqlParameter = {
                                                   new SqlParameter("@QueryType",QueryType),
                                                   new SqlParameter("@UseTransId",Id)

                                               };
            var intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_MedicalOrderDoc", msSqlParameter);
            return intStatus;
        }
    }
}
