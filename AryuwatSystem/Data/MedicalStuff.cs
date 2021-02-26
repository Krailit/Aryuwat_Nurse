using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using AryuwatSystem.Baselibary;
using AryuwatSystem.DerClass;
using Entity;


namespace AryuwatSystem.Data
{
    public class MedicalStuff
    {

       // public static int? InsertMedicalStuff(Entity.MedicalStuff[] info, SqlTransaction trn, string VN, string useTransId, string MS_Code)
        //public static int? InsertMedicalStuff(Entity.MedicalStuff[] info, SqlTransaction trn, string VN, Dictionary<string, string> DicId)
        //{
        //    int intStatus = 0;
        //    try
        //    {
        //        string idMax = "";
        //        string idMax0 = "";
        //        foreach (Entity.MedicalStuff c in info)
        //        {
        //           // if (MS_Code != c.MS_Code) continue;
        //            if (!DicId.ContainsKey(c.MS_Code)) continue;
                        
        //            idMax = DicId[c.MS_Code];

        //            string[] arrCode = c.MS_Code.Split(':');
        //            for (int i = 0; i < arrCode.Length; i++)
        //            {
        //                SqlParameter[] msSqlParameter = {
        //                                                    new SqlParameter("@QueryType", "Insert"),
        //                                                    new SqlParameter("@VN", VN),
        //                                                    new SqlParameter("@MS_Code", arrCode[i]),
        //                                                    new SqlParameter("@Position_ID", c.Position_ID),
        //                                                    new SqlParameter("@EmployeeId", c.EmployeeId),
        //                                                    new SqlParameter("@SectionStuff", c.SectionStuff),
        //                                                    new SqlParameter("@MergStatus", c.MS_Code),
        //                                                    //new SqlParameter("@UseTransId",c.UseTransId)
        //                                                    new SqlParameter("@UseTransId",idMax)
        //                                                };

        //                intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_MedicalStuff",
        //                                                      msSqlParameter);
        //            }

        //            // string frefix = DicId[c.MS_Code].Substring(0, DicId[c.MS_Code].Length - 1);
        //            //    string sufix = (Convert.ToInt16(DicId[c.MS_Code].Substring(DicId[c.MS_Code].Length - 1, 1)) + 1).ToString();
        //            //    idMax = frefix + sufix;
        //            //DicId[c.MS_Code] = idMax;
        //        }
        //        return intStatus;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("An error occurred while executing the Data.InsertMedicalStuff", ex);
        //    }
        //}

        public static DataSet SelectMedicalStuffById(Entity.MedicalStuff info)
        {
            try
            {
                SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","SELECTBYID"),
                                               new SqlParameter("@VN",info.VN), 
                                               new SqlParameter("@MS_Code",info.MS_Code),
                                               new SqlParameter("@UseTransId",info.UseTransId)

                                            };
                DataSet ds = SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_MedicalStuff", msSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectMedicalStuffById", ex);
            }
        }

        public static int? InsertMedicalStuff(Entity.MedicalStuff[] info, SqlTransaction trn, string VN, string maxId, string ListOrder)
        {
            int intStatus = 0;
            try
            {
                foreach (Entity.MedicalStuff c in info)
                {
                    //string[] arrCode = c.MS_Code.Split(':');
                    //for (int i = 0; i < arrCode.Length; i++)
                    //{
                        SqlParameter[] msSqlParameter = {
                                                            new SqlParameter("@QueryType", "INSERT"),
                                                            new SqlParameter("@VN", VN),
                                                            new SqlParameter("@MS_Code", c.MS_Code),
                                                            new SqlParameter("@Position_ID", c.Position_ID),
                                                            new SqlParameter("@EmployeeId", c.EmployeeId),
                                                            new SqlParameter("@SectionStuff", c.SectionStuff),
                                                            new SqlParameter("@MergStatus", c.MergStatus),
                                                            new SqlParameter("@ListOrder",ListOrder),
                                                            new SqlParameter("@UseTransId",maxId)
                                                        };

                        intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_MedicalStuff",
                                                              msSqlParameter);
                    //}

                    // string frefix = DicId[c.MS_Code].Substring(0, DicId[c.MS_Code].Length - 1);
                    //    string sufix = (Convert.ToInt16(DicId[c.MS_Code].Substring(DicId[c.MS_Code].Length - 1, 1)) + 1).ToString();
                    //    idMax = frefix + sufix;
                    //DicId[c.MS_Code] = idMax;
                }
                return intStatus;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.InsertMedicalStuff", ex);
            }
        }

        public static int? DeleteMedicalStuff(SqlTransaction trn, string vn, string so)
        {
            int intStatus = 0;

            SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType", "DELETE"),
                                               new SqlParameter("@VN", vn),
                                               new SqlParameter("@EN", Userinfo.EN)
                                             
                                           };

            intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_MedicalStuff", msSqlParameter);

            return intStatus;
        }

        public static int? DeleteMedicalStuff(SqlTransaction trn, string vn, string msCode, string useTransId, string ListOrder, string updateBy)
        {
            int intStatus = 0;

            SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType", "DELETEBYUSEID"),
                                               new SqlParameter("@VN", vn),
                                               new SqlParameter("@MS_Code",msCode),
                                               new SqlParameter("@UseTransId",useTransId),
                                               new SqlParameter("@ListOrder",ListOrder),
                                               new SqlParameter("@EN", updateBy)
                                           };

            intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_MedicalStuff", msSqlParameter);

            return intStatus;
        }

    }
}
