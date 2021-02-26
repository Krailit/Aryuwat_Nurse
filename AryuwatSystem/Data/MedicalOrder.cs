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
    public class MedicalOrder
    {
        public static int? InsertMembersMoveTrans(Entity.MedicalOrderUseTrans info, SqlTransaction trn)
        {
            int num = 0;
            string sql = string.Format("delete from [dbo].[MedicalOrderMoveTran] WHERE SOClose='{0}' and SONew='{1}';delete from [dbo].[MedicalOrderMoveTran] WHERE SOClose='{2}' and SONew='{3}';", info.SOClose, info.SONewOld, info.SOClose, info.SONew);
            num = SqlHelper.ExecuteNonQuery(trn, CommandType.Text, sql);

            foreach (Entity.MedicalOrderUseTrans trans in info.ListMs)
            {
                SqlParameter[] commandParameters = new SqlParameter[] { 
                    new SqlParameter("@SO_Old", info.SONewOld)
                    , new SqlParameter("@SOClose", info.SOClose)
                    , new SqlParameter("@SONew", info.SONew)
                    , new SqlParameter("@CN", info.CN)
                    , new SqlParameter("@PriceTotal"
                    , info.PriceTotal)
                    , new SqlParameter("@PriceNewVN", info.PriceNewVN)
                    , new SqlParameter("@PriceNewBalance"
                    , info.PriceNewBalance)
                    , new SqlParameter("@Remark", info.Remark)
                    , new SqlParameter("@CreateDate", info.CreateDate)
                    , new SqlParameter("@CreateBy", info.CreateBy)
                    , new SqlParameter("@UpdateDate", info.UpdateDate)
                    , new SqlParameter("@UpdateBy", info.UpdateBy)
                    , new SqlParameter("@PayCash", info.PayCash)
                    , new SqlParameter("@PayUse", info.PayUse)
                    , new SqlParameter("@MS_Code", trans.MS_Code)
                    , new SqlParameter("@Price", trans.MSPrice) 
                    , new SqlParameter("@IsCancel", trans.IsCancel) 
                };
                num = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_MedicalOrderMoveTran", commandParameters);
                if (num == -1)
                {
                    break;
                }
            }
            return new int?(num);
        }
        public static int? DeleteMedicalMoveTrans(Entity.MedicalOrderUseTrans info, SqlTransaction trn)
        {
            int num = 0;
            string sql = string.Format("delete from [dbo].[MedicalOrderMoveTran] WHERE SOClose='{0}';delete from [MedicalOrderMove] WHERE SOClose='{0}';", info.SOClose);
            num = SqlHelper.ExecuteNonQuery(trn, CommandType.Text, sql);

            return new int?(num);
        }

        public static int? InsertMedicalOrder(ref Entity.MedicalOrder info, SqlTransaction trn)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { 
                new SqlParameter("@QueryType", "Insert"), 
                new SqlParameter("@VN", info.VN), 
                new SqlParameter("@CN", info.CN), 
                new SqlParameter("@AgenMemId", info.AgenMemId), 
                new SqlParameter("@Remark", info.Remark), 
                new SqlParameter("@CreateBy", info.CreateBy), 
                new SqlParameter("@SalePrice", info.SalePrice), 
                new SqlParameter("@PriceCreditRef", info.PriceTotalRef),
                new SqlParameter("@MedStatus_Code", info.MedStatus_Code),
                new SqlParameter("@UpdateBy", info.UpdateBy), 
                new SqlParameter("@CreateDate", info.CreateDate), 
                new SqlParameter("@SONo", info.SONo), 
                new SqlParameter("@EN_COMS1", info.EN_COMS1), 
                new SqlParameter("@EN_COMS2", info.EN_COMS2), 
                new SqlParameter("@DR_COM", info.DR_COM), 
                new SqlParameter("@VNClose", info.VNRef),
                new SqlParameter("@UpdateDate", info.UpdateDate) ,
                new SqlParameter("@MOType", info.MOType) ,
                new SqlParameter("@PRO_Code", info.PRO_Code) ,
                new SqlParameter("@SORef", info.SORef) ,
                new SqlParameter("@OldKey", info.OldKey) ,
                new SqlParameter("@BranchId", info.BranchId),
                new SqlParameter("@ProCreditRemain", info.ProCreditRemain)
                
                
                
                
            };
            return new int?(SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_MedicalOrder", commandParameters));
        }
        public static int? InsertMedicalOrderRefVN(ref Entity.MedicalOrder info, SqlTransaction trn)
        {
            SqlParameter[] commandParameters = new SqlParameter[] { 
                new SqlParameter("@QueryType", "InsertRefVN"), 
                new SqlParameter("@RefVN", info.RefVN), 
                new SqlParameter("@CN", info.CN), 
                new SqlParameter("@EN_Save",info.EN_Save), 
                new SqlParameter("@Remark", info.Remark), 
                new SqlParameter("@CreateDate", info.CreateDate), 
                new SqlParameter("@EN_COMS1", info.EN_COMS1), 
                new SqlParameter("@EN_COMS2", info.EN_COMS2), 
                new SqlParameter("@DR_COM", info.DR_COM), 
                new SqlParameter("@MOType", info.MOType) ,
                new SqlParameter("@BranchId", info.BranchId),
            };
            return new int?(SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_MedicalOrder", commandParameters));
        }
        public static int? InsertMedicalOrderFollow(ref List<Entity.MedicalOrder> info, SqlTransaction trn)
        {
            int? ok=0;
            foreach (Entity.MedicalOrder item in info)
            {
                SqlParameter[] commandParameters = new SqlParameter[] { 
                new SqlParameter("@QueryType", "UPDATEContractResultID"), 
                new SqlParameter("@VN", item.VN), 
                new SqlParameter("@SONo", item.SONo), 
                new SqlParameter("@MS_Code", item.MS_Code), 
                new SqlParameter("@ListOrder", item.ListOrder), 
                new SqlParameter("@ContractResultID", item.ContrackID), 
                };
                ok += SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_SupplieTrans", commandParameters);
        }
              return ok;
        }

 
     
       public static int? UpdateMedicalOrder(ref Entity.MedicalOrder info, SqlTransaction trn)
       {
           SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType","UPDATE"),
                                                new SqlParameter("@VN",info.VN),
                                                new SqlParameter("@CN",info.CN),
                                                new SqlParameter("@AgenMemId", info.AgenMemId),
                                                new SqlParameter("@Remark",info.Remark),
                                                new SqlParameter("@CreateBy",info.CreateBy),
                                                new SqlParameter("@SalePrice",info.SalePrice),
                                                new SqlParameter("@MedStatus_Code", info.MedStatus_Code),
                                                new SqlParameter("@UpdateBy", info.UpdateBy),
                                                new SqlParameter("@SONo", info.SONo),
                                                new SqlParameter("@EN_COMS1", info.EN_COMS1),
                                                new SqlParameter("@EN_COMS2", info.EN_COMS2),
                                                new SqlParameter("@PriceTotalRef", info.PriceTotalRef),
                                                new SqlParameter("@VNClose", info.VNRef)
                                                
                                            };
         
           int intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_MedicalOrder", msSqlParameter);

           return intStatus;
       }

       public static int? UpdateMedicalOrderStatus(string vn ,string empId,string medStatus, SqlTransaction trn)
       {
           SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType","UPDATEMEDSTATUS"),
                                                new SqlParameter("@VN",vn),
                                                new SqlParameter("@UpdateBy",empId),
                                                new SqlParameter("@MedStatus_Code",medStatus)
                                            };

           int intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_MedicalOrder", msSqlParameter);
           return intStatus;
       }

       public static DataSet SelectMedicalStatus()
       {
           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","SELECTMEDICALSTATUS")
                                            };
               DataSet ds =
                   SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_MedicalOrder", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectMedicalOrderPaging", ex);
           }
       }
       public static DataSet SelectMedicalOrderPaging(Entity.MedicalOrder info)
       {
           try
           {
               long iRowStart = 0;
               long iRowEnd = 0;
               DerUtility.FindRangeRow(info.PageNumber, ref iRowStart, ref iRowEnd);
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType",info.QueryType),
                                               new SqlParameter("@VN",info.VN),
                                               new SqlParameter("@CO",info.CO),
                                               new SqlParameter("@CN",info.CustomerInfo.CN),
                                               new SqlParameter("@SONo",info.SONo),
                                               new SqlParameter("@Tname",info.CustomerInfo.TName),
                                               new SqlParameter("@TsurName",info.CustomerInfo.TSurname),
                                               new SqlParameter("@row_start", iRowStart),
                                               new SqlParameter("@row_end", iRowEnd),
                                               //new SqlParameter("@MedStatus_Code", info.MedStatus_Code),
                                               new SqlParameter("@MedStatus_CodeNew", info.MedStatus_CodeNew),
                                               new SqlParameter("@MedStatus_CodePending", info.MedStatus_CodePending),
                                               new SqlParameter("@MedStatus_CodeClosed", info.MedStatus_CodeClosed),
                                               new SqlParameter("@OldKey", info.OldKey),
                                               new SqlParameter("@Product", info.Product),
                                               new SqlParameter("@StartDate",info.StartDate),
                                               new SqlParameter("@EndDate",info.EndDate),
                                               new SqlParameter("@RefMO",info.RefMO),
                                               new SqlParameter("@BranchId",info.BranchId)
                                               
                                            };
               DataSet ds =
                   SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_MedicalOrder", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectMedicalOrderPaging", ex);
           }
       }
       public static DataSet SelectMedicalOrderSOTPaging(Entity.MedicalOrder info)
       {
           try
           {
               long iRowStart = 0;
               long iRowEnd = 0;
               DerUtility.FindRangeRow(info.PageNumber, ref iRowStart, ref iRowEnd);
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","SEARCHSOT"),
                                               new SqlParameter("@SONo",info.SONo),
                                               new SqlParameter("@CO",info.CO),
                                               new SqlParameter("@CN",info.CustomerInfo.CN),
                                               new SqlParameter("@Tname",info.CustomerInfo.TName),
                                               new SqlParameter("@TsurName",info.CustomerInfo.TSurname),
                                               new SqlParameter("@row_start", iRowStart),
                                               new SqlParameter("@row_end", iRowEnd),
                                               //new SqlParameter("@MedStatus_Code", info.MedStatus_Code),
                                               new SqlParameter("@MedStatus_CodeNew", info.MedStatus_CodeNew),
                                               new SqlParameter("@MedStatus_CodePending", info.MedStatus_CodePending),
                                               new SqlParameter("@MedStatus_CodeClosed", info.MedStatus_CodeClosed),
                                               new SqlParameter("@OldKey", info.OldKey),
                                               new SqlParameter("@Product", info.Product),
                                               new SqlParameter("@StartDate",info.StartDate),
                                               new SqlParameter("@EndDate",info.EndDate),
                                               new SqlParameter("@RefMO",info.RefMO),
                                               new SqlParameter("@MoneyCheckComplete",info.MoneyCheckComplete),
                                               new SqlParameter("@BranchId",info.BranchId)
                                               
                                            };
               DataSet ds =
                   SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_MedicalOrder", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectMedicalOrderPaging", ex);
           }
       }
       public static DataSet SelectMedicalOrderById(string vn)
       {
           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","SELECTBYID"),
                                               new SqlParameter("@VN",vn)
                                            };
               DataSet ds =
                   SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_MedicalOrder", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectMedicalOrderById", ex);
           }
       }
       public static DataSet SelectMedicalOrderRefVNById(string RefVN)
       {
           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","SELECTBYID_RefVN"),
                                               new SqlParameter("@RefVN",RefVN)
                                            };
               DataSet ds =
                   SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_MedicalOrder", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectMedicalOrderById", ex);
           }
       }
       public static DataSet SelectMedicalOrderById(string vn,string so)
       {
           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","SELECTBYID"),
                                               new SqlParameter("@VN",vn),
                                               new SqlParameter("@SONo",so)
                                            };
               DataSet ds =
                   SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_MedicalOrder", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectMedicalOrderById", ex);
           }
       }
       public static DataSet SelectMedicalOrderByIdSubitem(string vn, string so)
       {
           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","SELECTBYID_SUBITEM"),
                                               new SqlParameter("@VN",vn),
                                               new SqlParameter("@SONo",so)
                                            };
               DataSet ds =
                   SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_MedicalOrder", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectMedicalOrderById", ex);
           }
       }
       public static DataSet CheckMoCreated(string so)
       {
           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","CheckMoCreated"),
                                               new SqlParameter("@SONo",so)
                                            };
               DataSet ds =
                   SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_MedicalOrder", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectMedicalOrderById", ex);
           }
       }
       public static DataSet SelectFileScan(string UseTransId)
       {
           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","SelectFileScanDoctor"),
                                               new SqlParameter("@UseTransId",UseTransId),
                                            };
               DataSet ds =
                   SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_MedicalOrderDoc", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectMedicalOrderById", ex);
           }
       }
       public static DataSet SelectFileScan(string so,string mo,string cn,string QueryType)
       {
           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType",QueryType),
                                               new SqlParameter("@Sono",so),
                                               new SqlParameter("@VN",mo),
                                               new SqlParameter("@CN",cn),
                                            };
               DataSet ds =
                   SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_MedicalOrderDoc", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectMedicalOrderById", ex);
           }
       }
        
       public static int? DeleteMedicalOrderById(SqlTransaction trn, string VN, string so)
       {

           try
           {
               SqlParameter[] msSqlParameter = {
                                                   new SqlParameter("@QueryType", "DELETE"),
                                                   new SqlParameter("@VN", VN),
                                                   new SqlParameter("@SONo", so),
                                                   new SqlParameter("@EN_Save", Userinfo.EN)
                                               };
               int intStatus =
                   SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_MedicalOrder", msSqlParameter);
               return intStatus;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public static int? InsertSubItemOther(List<Entity.SupplieTrans> info, List<Entity.SupplieTrans> listSupOtherDel, SqlTransaction trn)
        {
            int intStatus =0;

           //=============Delete UsedTran===========================
            foreach (Entity.SupplieTrans c in listSupOtherDel)
                {
                    SqlParameter[] commandParameters = new SqlParameter[] { 
                    new SqlParameter("@QueryType", "DeleteSubListItemUsedTran"), 
                    new SqlParameter("@VN", c.VN), 
                    new SqlParameter("@MS_CodeS", c.MS_CodeS), 
                    new SqlParameter("@ListOrderS", c.ListOrderS), 
                };
                    intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_SupplieTrans", commandParameters);
                }
            //=============Delete UsedTran===========================
            if (info.Any())
            {
                SqlParameter[] msSqlParameter = {
                                                    new SqlParameter("@QueryType", "DELETESubListItem"),
                                                    new SqlParameter("@VN", info[0].VN), 
                                                    new SqlParameter("@SOno", info[0].SONo), 
                                                    new SqlParameter("@MS_CodeM",info[0].MS_CodeM), 
                                                    new SqlParameter("@ListOrderM", info[0].ListOrderM), 
                                               };
                intStatus =
                   SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_SupplieTrans", msSqlParameter);

                foreach (Entity.SupplieTrans c in info)
                {
                    SqlParameter[] commandParameters = new SqlParameter[] { 
                    new SqlParameter("@QueryType", "InsertSubListItem"), 
                    new SqlParameter("@VN", c.VN), 
                    new SqlParameter("@SOno", c.SONo), 
                    new SqlParameter("@MS_CodeM",c.MS_CodeM), 
                    new SqlParameter("@ListOrderM", c.ListOrderM), 
                    new SqlParameter("@MS_CodeS", c.MS_CodeS), 
                    new SqlParameter("@ListOrderS", c.ListOrderS), 
                    
                    new SqlParameter("@Amount", c.Amount), 
                    new SqlParameter("@PriceAfterDis", c.PriceAfterDis), 
                    new SqlParameter("@SaleCom", c.SaleCom), 
                    new SqlParameter("@ByDr", c.ByDr), 
                    new SqlParameter("@UpPrice", c.UpPrice), 
                    new SqlParameter("@Discount", c.DiscountB), 

                };
                    intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_SupplieTrans", commandParameters);
                }
                return intStatus;
            }
            else
                return intStatus;
        }
       public static DataSet SelectSubItemOther(Entity.SupplieTrans info)
       {
           try
           {
               long iRowStart = 0;
               long iRowEnd = 0;
               //DerUtility.FindRangeRow(info.PageNumber, ref iRowStart, ref iRowEnd);
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType",info.QueryType),
                                               new SqlParameter("@VN",info.VN),
                                               new SqlParameter("@SONo",info.SONo),
                                               new SqlParameter("@MS_CodeM",info.MS_CodeM),
                                               new SqlParameter("@ListOrderM",info.ListOrderM),
                                             
                                               
                                            };
               DataSet ds =
                   SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_SupplieTrans", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectMedicalOrderPaging", ex);
           }
       }
        
    }


}
