using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using AryuwatSystem.Baselibary;
using AryuwatSystem.DerClass;
using Newtonsoft.Json;
using Entity;

namespace AryuwatSystem.Data
{
    public class MedicalSupplies
    {

        public static int? InsertMedicalStockSuppliesREQ(ref Entity.MedicalSupplies info, SqlTransaction trn)
       {
           int intStatus = 0;
           foreach (Entity.MedicalSupplies item in info.LisItemStock)
           {


               SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType",item.QueryType),
                                                new SqlParameter("@REQNo",item.REQNo),
                                                new SqlParameter("@MS_Code",item.MS_Code),
                                                new SqlParameter("@Quantity",item.Quantity),
                                                new SqlParameter("@QuantityReply",item.QuantityReply),
                                                new SqlParameter("@QuantityReceive",item.QuantityReceive),
                                                new SqlParameter("@REQDate",item.REQDate+""==""?DateTime.Now:item.REQDate),
                                                new SqlParameter("@EN_Req",item.EN_Req),
                                                new SqlParameter("@EN_ReqTo",item.EN_ReqTo),
                                                new SqlParameter("@Req_BranchId",item.Req_BranchId),
                                                new SqlParameter("@ReqTo_BranchId",item.ReqTo_BranchId),
                                                new SqlParameter("@Remark",item.Remark),
                                                new SqlParameter("@RemarkReply",item.RemarkReply),
                                                new SqlParameter("@Approved",item.Approved),
                                                new SqlParameter("@WHCode",item.WHCode),
                                                new SqlParameter("@Dept",item.Dept),
                                                new SqlParameter("@Replydate",item.Replydate+""==""?DateTime.Now:item.Replydate),
                                                new SqlParameter("@ReturnsFlag",item.ReturnsFlag),
                                                new SqlParameter("@UrgentFlag",item.UrgentFlag),
                                                new SqlParameter("@Fortype",item.Fortype),
                                                new SqlParameter("@REQUnitCode",item.REQUnitCode),
                                                new SqlParameter("@SONo",item.SOno),
                                                
                                                
                                            };

                intStatus += SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_MedicalSupplies", msSqlParameter);
           }
           return intStatus;
       }
        public static int? DeleteStockSuppliesTranREQ(string REQNo, SqlTransaction trn)
       {
           int intStatus = 0;
               SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType","DEL_REQ_STOCKTRAN"),
                                                new SqlParameter("@REQNo",REQNo),
                                                new SqlParameter("@EN_Req",Entity.Userinfo.EN),
                                                
                                            };

                intStatus += SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_MedicalSupplies", msSqlParameter);
           return intStatus;
       }
        public static int? DeleteStockSuppliesTranSPQ(string REQNo, SqlTransaction trn)
        {
            int intStatus = 0;
            SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType","DEL_SPQ_STOCKTRAN"),
                                                new SqlParameter("@REQNo",REQNo),
                                                new SqlParameter("@EN_Req",Entity.Userinfo.EN),
                                            };

            intStatus += SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_MedicalSupplies", msSqlParameter);
            return intStatus;
        }
        public static int? DeleteStockSuppliesREQ(string REQNo, SqlTransaction trn)
        {
            int intStatus = 0;
            SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType","DEL_REQ_STOCK"),
                                                new SqlParameter("@REQNo",REQNo),
                                                new SqlParameter("@EN_Req",Entity.Userinfo.EN),

                                            };

            intStatus += SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_MedicalSupplies", msSqlParameter);
            return intStatus;
        }
        public static int? DeleteStockSuppliesSPQ(string REQNo, SqlTransaction trn)
        {
            int intStatus = 0;
            SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType","DEL_SPQ_STOCK"),
                                                new SqlParameter("@REQNo",REQNo),
                                                new SqlParameter("@EN_Req",Entity.Userinfo.EN),
                                            };

            intStatus += SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_MedicalSupplies", msSqlParameter);
            return intStatus;
        }
        public static int? InsertMedicalStockSupplies(ref Entity.MedicalSupplies info, SqlTransaction trn)
        {
            int intStatus = 0;
            foreach (Entity.MedicalSupplies item in info.LisItemStock)
            {


                SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType",info.QueryType),
                                                new SqlParameter("@MS_Code",item.MS_Code),
                                                new SqlParameter("@MS_Instock",item.MS_Instock),
                                                new SqlParameter("@Receive_Cost",item.Receive_Cost),
                                                new SqlParameter("@ReceiveQuantity",item.ReceiveQuantity),
                                                new SqlParameter("@Sell_Cost",item.Sell_Cost),
                                                new SqlParameter("@SellQuantity",item.SellQuantity),
                                                new SqlParameter("@MS_CostAVG",item.MS_CostAVG == null || item.MS_CostAVG.ToString() == "NaN" ? null : item.MS_CostAVG),
                                                //new SqlParameter("@MS_CostAVG",item.MS_CostAVG),
                                                new SqlParameter("@MS_Discount",item.Discount),
                                                new SqlParameter("@DocNo",item.DocNo),
                                                new SqlParameter("@ActiveType",item.ActiveType),
                                                new SqlParameter("@ByID",item.ByID),
                                                new SqlParameter("@SaveDate",item.SaveDate),
                                                new SqlParameter("@ENSave",item.ENSave),
                                                new SqlParameter("@Remark",item.Remark),
                                                new SqlParameter("@SellToCN",item.SellToCN),
                                                new SqlParameter("@BranchID",item.BranchID),
                                                new SqlParameter("@ExpireDate",item.ExpireDate)
                                                
                                                
                                                
                                                
                                                
                                            };

                intStatus += SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_MedicalSupplies", msSqlParameter);
            }
            return intStatus;
        }
        public static int? InsertMedicalSupplies(ref Entity.MedicalSupplies info, SqlTransaction trn)
        {
            
            //var idMax = UtilityBackEnd.GenMaxSeqnoValues(info.EN);
            
            SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType",info.QueryType),
                                                new SqlParameter("@ID",info.ID),
                                                new SqlParameter("@MS_Code",info.MS_Code),
                                                new SqlParameter("@MS_Code_Ref",info.MS_Code_Ref),
                                                new SqlParameter("@MS_Name",info.MS_Name),
                                                new SqlParameter("@MS_Detail",info.MS_Detail),
                                                new SqlParameter("@MS_Unit",info.MS_Unit),
                                                new SqlParameter("@MS_CourseDuration",info.MS_CourseDuration),
                                                new SqlParameter("@MS_Type",info.MS_Type),
                                                new SqlParameter("@MS_Cost",info.MS_CLPrice),
                                                new SqlParameter("@MS_CLPrice",info.MS_CLPrice),
                                                new SqlParameter("@MS_CAPrice",info.MS_CAPrice),
                                                new SqlParameter("@MS_CMPrice",info.MS_CMPrice),
                                                new SqlParameter("@MS_Order",info.MS_Order),
                                                new SqlParameter("@MS_Instock",info.MS_Instock),
                                                new SqlParameter("@MS_MinimumStock",info.MS_MinimumStock),
                                                new SqlParameter("@row_end",info.PageNumber),
                                                new SqlParameter("@MS_Section",info.MS_Section),
                                                new SqlParameter("@MS_Number_C",info.Number_C),
                                                new SqlParameter("@FeeRate",info.FeeRate),
                                                new SqlParameter("@FeeRate2",info.FeeRate2),
                                                new SqlParameter("@MaxDiscount",info.MaxDiscount),
                                                new SqlParameter("@Vat",info.Vat),
                                                new SqlParameter("@BranchID",info.BranchID),
                                                new SqlParameter("@PurchaseID",info.PurchaseID),
                                                new SqlParameter("@OperationID",info.OperationID),
                                                new SqlParameter("@LocationID",info.LocationID),
                                                new SqlParameter("@Active",info.Active),
                                                new SqlParameter("@BOM",info.BOM),
                                                new SqlParameter("@Type_Doctor",info.Type_Doctor),
                                                new SqlParameter("@ExpireDate",info.ExpireDate == null ? Convert.ToDateTime(null) : Convert.ToDateTime(info.ExpireDate)),
                                                new SqlParameter("@MS_SubUnit",info.MS_SubUnit),
                                                new SqlParameter("@AnountPerMainUnit",info.AnountPerMainUnit)
            };
            //string txt = "";
            //foreach (var p in msSqlParameter.ToList())
            //{
            //    txt += p.ToString() + ":";
            //    txt += p.Value == null ? "'';" : p.Value.ToString() + ";";
            //}
          int intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_MedicalSupplies", msSqlParameter);
           //var test = JsonConvert.SerializeObject(msSqlParameter);
           return intStatus;
       }
        public static int? InsertMedicalPA(List<Entity.MedicalSupplies> info, SqlTransaction trn)
          {
              int? intStatus=0;
              foreach (Entity.MedicalSupplies c in info)
              {
                  SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType","InsertMedicalPA"),
                                                new SqlParameter("@MS_Code",c.MS_Code),
                                                new SqlParameter("@EatAmount",c.EatAmount),
                                                new SqlParameter("@EatPerday",c.EatPerday),
                                                new SqlParameter("@BeforeMeals",c.BeforeMeals),
                                                new SqlParameter("@AfterMeals",c.AfterMeals),
                                                new SqlParameter("@Morning",c.Morning),
                                                new SqlParameter("@Lunch",c.Lunch),
                                                new SqlParameter("@Evening",c.Evening),
                                                new SqlParameter("@BeforeBed",c.BeforeBed),
                                                new SqlParameter("@Everyhours",c.Everyhours),
                                                new SqlParameter("@ENSave",c.ENSave),
                                                new SqlParameter("@eat",c.eat),
                                                new SqlParameter("@coat",c.coat),
                                                new SqlParameter("@coatArea",c.coatArea),
                                                
                                            };

                   intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_MedicalSupplies", msSqlParameter);
              }
              return intStatus;
          }
        public static DataSet SelectMedicalSuppliesPaging(Entity.MedicalSupplies info)
        {
            try
            {
                long iRowStart = 0;
                long iRowEnd = 0;
                DerUtility.FindRangeRow(info.PageNumber, ref iRowStart, ref iRowEnd);
                SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType",info.QueryType),
                                               new SqlParameter("@MS_Code",info.MS_Code),
                                               new SqlParameter("@MS_Name",info.MS_Name),
                                               new SqlParameter("@row_start", iRowStart),
                                               new SqlParameter("@row_end", iRowEnd),
                                               new SqlParameter("@StartDate", info.SStartDate),
                                               new SqlParameter("@EndDate", info.SEndDate),
                                               new SqlParameter("@BranchID", info.BranchID),
                                               new SqlParameter("@FixSearch", info.FixSearch),
                                               new SqlParameter("@VN", info.VN),
                                               
                                               
                                            };
                DataSet ds =
                    SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_MedicalSupplies", msSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectMedicalSuppliesPaging", ex);
            }
        }


        public static DataSet SelectMedicalSuppliesBySection(SqlTransaction trn, Entity.MedicalSupplies info)
        {
            try
            {
               SqlParameter[] msSqlParameter = {
                                                 new SqlParameter("@QueryType", Userinfo.PersonnelType == "1" ? "SELECTTABDC" : "SELECTTAB"),
                                               new SqlParameter("@Tab",info.Tab),
                                                new SqlParameter("@Tabwhere",info.Tabwhere)
                                            };
                    DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_MedicalOrder", msSqlParameter);
                    return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectMedicalSuppliesBySection", ex);
            }
        }
        public static DataSet GetPendingBySO(SqlTransaction trn, string @SONo)
        {
            try
            {
               SqlParameter[] msSqlParameter = {
                                                 new SqlParameter("@QueryType","GetPendingBySO"),
                                                 new SqlParameter("@SONo",SONo)
                                            };
               DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_Report", msSqlParameter);
                    return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectMedicalSuppliesBySection", ex);
            }
        }
   
        public static DataSet SelectStock(SqlTransaction trn, Entity.MedicalSupplies info)
        {
            try
            {
                SqlParameter[] msSqlParameter = {
                                                 new SqlParameter("@QueryType",info.QueryType),
                                                 new SqlParameter("@StartDate", info.StartDate == DateTime.MinValue ? DateTime.Now : info.StartDate),
                                                 new SqlParameter("@EndDate", info.EndDate == DateTime.MinValue ? DateTime.Now : info.EndDate),
                                                 new SqlParameter("@REQNo", info.REQNo),
                                                 new SqlParameter("@Fortype", info.Fortype),
                                                 new SqlParameter("@BranchID", info.BranchID),
                                                 new SqlParameter("@ReturnsFlag", info.ReturnsFlag),
                                                 
                                            };
                DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_MedicalSupplies", msSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectMedicalSuppliesBySection", ex);
            }
        }
        public static DataSet SelectDept(SqlTransaction trn, Entity.MedicalSupplies info)
        {
            try
            {
                SqlParameter[] msSqlParameter = {
                                                 new SqlParameter("@QueryType","SelectDept"),
                                            };
                DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_MedicalSupplies", msSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectMedicalSuppliesBySection", ex);
            }
        }
        public static DataSet SearchPersonnel(ref Entity.Personnel info, SqlTransaction trn)
       {
           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","SELECT"),
                                               new SqlParameter("@EN",info.EN),
                                               new SqlParameter("@Tname",info.TName),
                                               new SqlParameter("@TsurName",info.TSurname),
                                               new SqlParameter("@EFirstname",info.TName),
                                               new SqlParameter("@ELastname",info.ELastname),
                                            };
               DataSet dataReader =
                   SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_personnel", msSqlParameter);
               return dataReader;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SearchPersonnel", ex);
           }
       }

        /// <summary>
        /// Add By tu
        /// </summary>
        /// <param name="info"></param>
        /// <param name="trn"></param>
        /// <returns></returns>
        public static DataSet GetMedicalSuppliesByMsCodeRef(string msCode, SqlTransaction trn)
       {
           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","SELECTBYREFCODE"),
                                               new SqlParameter("@MS_Code",msCode)
                                            };
               DataSet dataReader =
                   SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_MedicalOrder", msSqlParameter);
               return dataReader;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.GetMedicalSuppliesByMsCodeRef", ex);
           }
       }

        public static DataSet GetPersonnelByUserName( Entity.Personnel info, SqlTransaction trn)
       {
           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType",info.QueryType ),
                                               new SqlParameter("@Username",info.Username),
                                               new SqlParameter("@Passwords",info.Passwords)
                                            };
               DataSet dataReader =
                   SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_personnel", msSqlParameter);
               return dataReader;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.GetPersonnelByUserName", ex);
           }
       }

        

        public static DataSet SearchPersonnelByID(ref Entity.Personnel info, SqlTransaction trn)
       {
           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType",info.QueryType),
                                               new SqlParameter("@EN",info.EN),
                                            };
               DataSet dataReader =
                   SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_personnel", msSqlParameter);
               return dataReader;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SearchPersonnel", ex);
           }
       }
        public static DataSet SelectPersonnelGroup(SqlTransaction trn)
       {
           try
           {
               DataSet dataReader = SqlHelper.ExecuteDataset(trn, CommandType.Text, "select * from UserGroup", null);
               return dataReader;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectPersonnelGroup", ex);
           }
       }
        public static DataSet SelectMedicalSection(SqlTransaction trn)
       {
           try
           {
               DataSet dataReader = SqlHelper.ExecuteDataset(trn, CommandType.Text, "SELECT * FROM [MedicalSection] where Section_Name = 'New PHARMACY' order by Section_Name", null);
               return dataReader;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectCustomerAll", ex);
           }
       }
        public static DataSet SelectMedicalSectionStock(SqlTransaction trn)
       {
           try
           {
               DataSet dataReader = SqlHelper.ExecuteDataset(trn, CommandType.Text, "select distinct [MS_Section] FROM [dbo].[MedicalSuppliesStock] order by MS_Section", null);
               return dataReader;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectCustomerAll", ex);
           }
       }
        public static DataSet SelectOperation(SqlTransaction trn)
       {
           try
           {
               DataSet dataReader = SqlHelper.ExecuteDataset(trn, CommandType.Text, "SELECT * FROM [MedicalSetting] where Setting_Type='Oๅๅๅ' order by Setting_Name", null);
               return dataReader;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectCustomerAll", ex);
           }
       }
        public static DataSet SelectPurChase(SqlTransaction trn)
       {
           try
           {
               DataSet dataReader = SqlHelper.ExecuteDataset(trn, CommandType.Text, "SELECT * FROM [MedicalSetting]  where Setting_Type='P' order by Setting_Name", null);
               return dataReader;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectCustomerAll", ex);
           }
       }
        public static DataSet SelectCourseDuration(SqlTransaction trn)
       {
           try
           {
               DataSet dataReader = SqlHelper.ExecuteDataset(trn, CommandType.Text, "SELECT * FROM [CourseDuration]", null);
               return dataReader;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectCustomerAll", ex);
           }
       }
        public static DataSet SelectUnit(SqlTransaction trn)
       {
           try
           {
               DataSet dataReader = SqlHelper.ExecuteDataset(trn, CommandType.Text, "SELECT * FROM [Unit] order by UnitName", null);
               return dataReader;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectCustomerAll", ex);
           }
       }
        public static int? DeleteSupplies(string code, SqlTransaction trn)
       {
           StringBuilder sb = new StringBuilder();
           sb.Append(" delete from [MedicalSupplies] where MS_Code = @MS_Code \n");

           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@MS_Code", code)
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
        public static int? DeleteSuppliesStock(string code, SqlTransaction trn)
       {
           StringBuilder sb = new StringBuilder();
           sb.Append(" delete from [MedicalSuppliesStock] where id = @id \n");

           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@id", code)
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
         //=============BOM=====================
        public static int? DELETEBOMMaterial(string code,string BranchID, SqlTransaction trn)
       {
         
           try
           {
               SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType","DELETEBOMMaterial"),
                                                new SqlParameter("@MS_Code",code),
                                                    new SqlParameter("@BranchID",BranchID),
       
                                            };

               int intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_MedicalSupplies", msSqlParameter);
               return intStatus;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

     // =======================BOM=====================
        public static DataSet CheckCode(string code, SqlTransaction trn)
       {
           StringBuilder sb = new StringBuilder();
           sb.Append(" select [MS_Code] FROM [MedicalSupplies] where MS_Code = @code \n");

           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@code", code)
                                           };
               DataSet dataReader =SqlHelper.ExecuteDataset(trn, CommandType.Text,sb.ToString(), msSqlParameter);
               return dataReader;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
        public static DataSet CheckCodeStock(string code, string BranchID, SqlTransaction trn)
       {
           StringBuilder sb = new StringBuilder();
           //sb.Append(" select [MS_Code] FROM [MedicalSuppliesStock] where MS_Code = @code and BranchID=@BranchID \n");
           sb.Append(" select [MS_Code] FROM [MedicalSuppliesStock] where MS_Code_Ref = @code \n");

           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@code", code),
                                               new SqlParameter("@BranchID", BranchID)
                                           };
               DataSet dataReader = SqlHelper.ExecuteDataset(trn, CommandType.Text, sb.ToString(), msSqlParameter);
               return dataReader;
           }
           catch (Exception ex)
           {
               throw ex;
           }

       }
        public static DataSet CheckProCode(string code, SqlTransaction trn)
       {
           StringBuilder sb = new StringBuilder();
           sb.Append(" select Pro_Code FROM [Promotion] where Pro_Code = @code \n");

           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@code", code)
                                           };
               DataSet dataReader = SqlHelper.ExecuteDataset(trn, CommandType.Text, sb.ToString(), msSqlParameter);
               return dataReader;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
        public static DataSet CheckMOCode(string code,bool checkMO, SqlTransaction trn)
       {
           StringBuilder sb = new StringBuilder();
           if (checkMO)
           {
               sb.Append(" select VN FROM [MedicalOrder] where VN = @code \n");
           }
           else
           {
               sb.Append(" select VN FROM [MedicalOrder] where VN='' and Sono = @code \n");
           }

           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@code", code)
                                           };
               DataSet dataReader = SqlHelper.ExecuteDataset(trn, CommandType.Text, sb.ToString(), msSqlParameter);
               return dataReader;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
         
        internal static int? InsertBOMMaterial(ref Entity.MedicalSupplies info, SqlTransaction trn)
       {
           try
           {
                 int? intStatus=0;
               foreach (Entity.MedicalSupplies item in info.LisItemStock)
	            {
		             SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType","InsertBOMMaterial"),
                                                new SqlParameter("@MS_Code",item.MS_Code),
                                                new SqlParameter("@Stock_Code",item.MS_Code_Ref),
                                                new SqlParameter("@BranchID",item.BranchID),
                                                new SqlParameter("@UsedAmount",item.Amount),
                                                new SqlParameter("@CostPerUnit",item.MS_CostAVG),
                                                new SqlParameter("@ENSave",item.ENSave)
                                            };

                intStatus =intStatus+ SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_MedicalSupplies", msSqlParameter);
	            }

              
               return intStatus;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

        public static DataSet CheckMinStock(Entity.MedicalSupplies info, SqlTransaction trn)
        {
           try
           {
               SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType", "CHECKMINSTOCK"),
                                                new SqlParameter("@BranchID", info.BranchID)
               };
               DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_MedicalSupplies", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.sp_MedicalSupplies.CheckMinStock", ex);
           }
        }

        public static DataSet SelectMinStock(Entity.MedicalSupplies info, SqlTransaction trn)
        {
           try
           {
               SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType", "SELECTMINSTOCK"),
                                                new SqlParameter("@BranchID", info.BranchID)
               };
                DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_MedicalSupplies", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.sp_MedicalSupplies.CheckMinStock", ex);
           }
        }
    }
}
