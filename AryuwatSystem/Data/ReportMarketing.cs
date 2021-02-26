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
    public class ReportMarketing
    {
      
       public static DataSet SelectReportMarketing(Entity.Report info)
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
                                               new SqlParameter("@BirthMonth",info.BirthMonth),
                                               new SqlParameter("@SalePrice",info.SalePrice),
                                               
                                               
                                            };
               DataSet ds =
                   SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_Marketing", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectReportPaging", ex);
           }
       }
      
    }


}
