using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using AryuwatSystem.Baselibary;
using Entity.Validation;

namespace AryuwatSystem.Data
{
    public class SurgeryFee
    {
        public static DataSet SelectStuffCommission(SqlTransaction trn, string typ)
        {
            try
            {
                SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType",typ)
                                            };
                DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_StuffCommission", msSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectdStuffCommission", ex);
            }
        }

        public static DataSet SelectSurgeryFee(SqlTransaction trn, Entity.SurgeryFee info)
        {
            try
            {
                SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType",info.QueryType),
                                               new SqlParameter("@EN",info.EN),
                                               new SqlParameter("@VN",info.VN),
                                               new SqlParameter("@MS_Code",info.MS_Code),
                                               new SqlParameter("@ListOrder",info.ListOrder),
                                               new SqlParameter("@UseTransId",info.UseTransId),
                                               new SqlParameter("@BranchId",info.BranchId),
                                               new SqlParameter("@Position_ID",info.Position_ID),
                                               new SqlParameter("@Position_Type",info.Position_Type),
                                               new SqlParameter("@StartDate",info.StartDate),
                                               new SqlParameter("@EndDate",info.EndDate),
                                               new SqlParameter("@SubSurgical",info.SubSurgical)
 
                                            };
                DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_SurgeryFee", msSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectdStuffCommission", ex);
            }
        }

        public static int? InsertSurgeryFee(Entity.MedicalOrder info, SqlTransaction trn, string VN)
        {
            int intStatus = 0;
            try
            {
                    var idMax = UtilityBackEnd.GenMaxSeqnoValues("SUR");
                    //foreach (string ms in info.ListMS_Code)
                    //{
                        //info.MS_Code = ms;
                        SqlParameter[] msSqlParameter = {
                                                            new SqlParameter("@QueryType", "INSERT"),
                                                            new SqlParameter("@SUR_ID", idMax),
                                                            new SqlParameter("@VN", VN),
                                                            new SqlParameter("@CN", info.CN),
                                                            new SqlParameter("@MS_Code", info.MS_Code),
                                                            new SqlParameter("@UseTransId", info.UseTransId),
                                                            new SqlParameter("@EN_Save", info.UpdateBy),
                                                            
                                                        };

                        intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_SurgeryFee",
                                                              msSqlParameter);
                   // }

                return intStatus;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.InsertSurgeryFee", ex);
            }
        }
        public static int? DeleteSurgeryFee(SqlTransaction trn, string VN, string MS_Code, string UseTransId, string UpdateBy)
        {
            int intStatus = 0;
            try
            {
                SqlParameter[] msSqlParameter = {
                                                            new SqlParameter("@QueryType", "DELETE"),
                                                            new SqlParameter("@VN", VN),
                                                            new SqlParameter("@MS_Code", MS_Code),
                                                            new SqlParameter("@UseTransId", UseTransId),
                                                            new SqlParameter("@EN_Save", UpdateBy),
                                                            
                                                        };

                intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_SurgeryFee",
                                                      msSqlParameter);
                // }

                return intStatus;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.InsertSurgeryFee", ex);
            }
        }

        public static int? SaveSurgeryFee(Entity.SurgeryFee info, SqlTransaction trn)
        {
            try
            {
               
                SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","SAVE"),
                                               new SqlParameter("@Tablename",info.Tablename),
                                               new SqlParameter("@SUR_ID",info.SUR_ID ),
                                               new SqlParameter("@CN",info.CN),
                                               new SqlParameter("@VN",info.VN),
                                               new SqlParameter("@SONo",info.Sono),
                                               new SqlParameter("@MS_Code",info.MS_Code),
                                               new SqlParameter("@ListOrder",info.ListOrder),
                                               new SqlParameter("@Anesthesia",info.Anesthesia),
                                               new SqlParameter("@ProcedureDate",info.ProcedureDate),
                                               new SqlParameter("@StartAnesth",info.StartAnesth),
                                               new SqlParameter("@EndAnesth",info.EndAnesth),
                                               new SqlParameter("@StartProcedure",info.StartProcedure),
                                               new SqlParameter("@EndProcedure",info.EndProcedure),
                                               new SqlParameter("@Remark",info.Remark),
                                               new SqlParameter("@NetIncome",info.NetIncome),
                                               new SqlParameter("@Charges",info.Charges),
                                               new SqlParameter("@Admit",info.Admit),
                                               new SqlParameter("@EN_Save",info.EN_Save),
                                               new SqlParameter("@DateUpdate",DateTime.Now),
                                               new SqlParameter("@UseTransId",info.UseTransId),
                                               new SqlParameter("@ExtraMoney",info.ExtraMoney),
                                               new SqlParameter("@Position_IDSave",info.Position_IDSave),
                                               new SqlParameter("@ActuallyAmount",info.ActuallyAmount)
                                               
                                               
                                               
                                            };
                int intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_SurgeryFee", msSqlParameter);
                return intStatus;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectdStuffCommission", ex);
            }
        }
        public static int? UpdateMedicalStuff(Entity.SurgeryFee info, SqlTransaction trn)
        {
            try
            {
                int intStatus = -1;
                foreach (Entity.MedicalStuff c in info.MedicalStuffInfo)
                {
                    SqlParameter[] msSqlParameter = {
                                                        new SqlParameter("@QueryType", "SAVE"),
                                                        new SqlParameter("@Tablename", "MEDICALSTUFF"),
                                                        new SqlParameter("@SUR_ID", info.SUR_ID),
                                                        new SqlParameter("@VN", info.VN),
                                                        new SqlParameter("@EN", c.EmployeeId),
                                                        new SqlParameter("@MS_Code", c.MS_Code),
                                                        new SqlParameter("@Com_Date", c.Com_Date),
                                                        new SqlParameter("@Com_Bath", c.Com_Bath),
                                                        new SqlParameter("@EN_Save", info.EN_Save),
                                                        new SqlParameter("@Position_ID", c.Position_ID),
                                                        new SqlParameter("@UseTransId", info.UseTransId)
                                                        
                                                    };
                     intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_SurgeryFee",
                                                              msSqlParameter);
                }
                return intStatus;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectdStuffCommission", ex);
            }
        }
        /// <summary>
        /// Add By tu_cs
        /// ไว้แสดงหน้า Medical Order ตำแหน่งสตาฟ
        /// </summary>
        /// <param name="trn"></param>
        /// <param name="typ"></param>
        /// <returns></returns>
        public static DataSet SelectStuffCommissionByType(SqlTransaction trn, string typ)
        {
            try
            {
                SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","SELECTBYTYPE"),
                                               new SqlParameter("@Position_Type",typ)
                                            };
                DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_StuffCommission", msSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectdStuffCommission", ex);
            }
        }

        public static DataSet SelectCommissionRate(SqlTransaction trn)
        {
            try
            {
                SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","SELECTCOMRATE"),
                                            };
                DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_StuffCommission", msSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectdStuffCommission", ex);
            }
        }
        public static DataSet SurgicalFeeType_Position(SqlTransaction trn)
        {
            try
            {
                SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","SurgicalFeeType_Position"),
                                            };
                DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_StuffCommission", msSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectdStuffCommission", ex);
            }
        }
    }
}
