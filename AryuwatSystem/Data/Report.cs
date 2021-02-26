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
    public class Report
    {
      
       public static DataSet SelectReportPaging(Entity.Report info)
       {
           try
           {
               long iRowStart = 0;
               long iRowEnd = 0;
               DerUtility.FindRangeRow(info.PageNumber, ref iRowStart, ref iRowEnd);
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType",info.QueryType),
                                               new SqlParameter("@StartDate",info.StartDate),
                                               new SqlParameter("@EndDate",info.EndDate),
                                               new SqlParameter("@SONo",info.SONo),
                                               new SqlParameter("@CN",info.CN),
                                               new SqlParameter("@VN",info.VN),
                                               new SqlParameter("@MedStatus_CodeNew", info.MedStatus_CodeNew),
                                               new SqlParameter("@MedStatus_CodePending", info.MedStatus_CodePending),
                                               new SqlParameter("@MedStatus_CodeClosed", info.MedStatus_CodeClosed),
                                               new SqlParameter("@BirthMonth", info.BirthMonth),
                                               new SqlParameter("@Peroid", info.Peroid),
                                               new SqlParameter("@BranchId", info.BranchId),
                                               new SqlParameter("@TodayOnly", info.TodayOnly),
                                               new SqlParameter("@EN_Save", Userinfo.EN),
                                               
                                               
                                            };
               DataSet ds =
                   SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_Report", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectReportPaging", ex);
           }
       }
       public static DataSet SelectReportWE(Entity.Report info)
       {
           try
           {
               long iRowStart = 0;
               long iRowEnd = 0;
               DerUtility.FindRangeRow(info.PageNumber, ref iRowStart, ref iRowEnd);
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType",info.QueryType),
                                               new SqlParameter("@StartDate",info.StartDate),
                                               new SqlParameter("@EndDate",info.EndDate),
                                               new SqlParameter("@SONo",info.SONo),
                                               new SqlParameter("@CN",info.CN),
                                               new SqlParameter("@VN",info.VN),
                                               new SqlParameter("@MedStatus_CodeNew", info.MedStatus_CodeNew),
                                               new SqlParameter("@MedStatus_CodePending", info.MedStatus_CodePending),
                                               new SqlParameter("@MedStatus_CodeClosed", info.MedStatus_CodeClosed),
                                               new SqlParameter("@BirthMonth", info.BirthMonth),
                                               new SqlParameter("@Peroid", info.Peroid)
                                               
                                            };
               DataSet ds =
                   SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_Report_WE", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectReportPaging", ex);
           }
       }
       public static DataSet SelectReportList(Entity.Report info)
       {
           try
           {
               
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType",info.QueryType),
                                               
                                            };
               DataSet ds =
                   SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_GetReportList", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectReportPaging", ex);
           }
       }
      
    }


}
