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
  public  class SumOfTreatment
    {
        public static int? InsertSumOfTreatment(Entity.MedicalOrder info, SqlTransaction trn, string VN)
        {
            int intStatus = 0;
            try
            {
                string idMax = UtilityBackEnd.GenMaxSeqnoValues("SOT");
                //var receiptNo = "RCN"+idMax.Substring(3,8) ;
                //var InvNo = "INV" + idMax.Substring(3, 8);
                SqlParameter[] msSqlParameter = {
                                                        new SqlParameter("@QueryType", "INSERT"),
                                                        new SqlParameter("@SOT_Code", idMax),
                                                        new SqlParameter("@VN", VN),
                                                        new SqlParameter("@SO", info.SONo),
                                                        new SqlParameter("@CN", info.CN),
                                                        //new SqlParameter("@ReceiptNo",receiptNo),
                                                        //new SqlParameter("@InvNo",InvNo),
                                                        new SqlParameter("@SORefAccount",info.SORefAccount)
                                                        
                                                    };

                intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_SumOfTreatment",
                                                      msSqlParameter);


                return intStatus;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.InsertSumOfTreatment", ex);
            }
        }
        public static int? UpdateMedicalStatus(Entity.SumOfTreatment info, SqlTransaction trn)
        {
            int intStatus = 0;
            try
            {
                SqlParameter[] msSqlParameter = {
                                                    new SqlParameter("@QueryType",info.QueryType),
                                                    new SqlParameter("@VN",info.VN),
                                                    new SqlParameter("@SO",info.SO),
                                                    new SqlParameter("@MedStatus_Code",info.MedStatus_Code)
                                                    };

                intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_SumOfTreatment",
                                                      msSqlParameter);


                return intStatus;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.UpdateMedicalStatus", ex);
            }
        }
        public static int? SOClose(Entity.SumOfTreatment info, SqlTransaction trn)
        {
            int intStatus = 0;
            try
            {
                SqlParameter[] msSqlParameter = {
                                                    new SqlParameter("@QueryType",info.QueryType),
                                                    new SqlParameter("@SO",info.SO),
                                                    new SqlParameter("@Refund",info.Refund),
                                                    new SqlParameter("@RefundDate",info.RefundDate),
                                                    new SqlParameter("@RefundType",info.RefundType),
                                                    new SqlParameter("@RefundRemark",info.RefundRemark),
                                                    new SqlParameter("@EN_Save",info.EN_Save),
                                                    
                                                    
                                                    };
                intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_SumOfTreatment",
                                                      msSqlParameter);


                return intStatus;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.UpdateMedicalStatus", ex);
            }
        }
        public static DataSet SelectCreditCard()
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            //var trn = conn.BeginTransaction();
            try
            {
                SqlParameter[] msSqlParameter = {
                                                    new SqlParameter("@QueryType","CREDITCARD")
                                                };
                DataSet ds = SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_SumOfTreatment", msSqlParameter);
                return ds;
            }
            catch (AppException)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw new AppException(
                    "An error occurred while executing the Bussiness.SelectCreditCard", ex);
            }
        }

        public static DataSet GetRefund(SqlTransaction trn, string typ, string SO)
        {
            try
            {
                SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType",typ),
                                               new SqlParameter("@SO",SO),
                                               
                                            };
                DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_SumOfTreatment", msSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectSumOfTreatment", ex);
            }
        }
        public static DataSet SelectSumOfTreatment(SqlTransaction trn, string typ, string SO, string VN)
        {
            try
            {
                SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType",typ),
                                               new SqlParameter("@SO",SO),
                                               new SqlParameter("@VN",VN)
                                               
                                            };
                DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_SumOfTreatment", msSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectSumOfTreatment", ex);
            }
        }
        public static DataSet SelectSumOfTreatment(SqlTransaction trn, string typ, string SO, string VN, DateTime ReceiptDate)
        {
            try
            {
                SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType",typ),
                                               new SqlParameter("@SO",SO),
                                               new SqlParameter("@VN",VN),
                                               new SqlParameter("@ReceiptDate",ReceiptDate)
                                               
                                            };
                DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_SumOfTreatment", msSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectSumOfTreatment", ex);
            }
        }
        public static DataSet SelectReportSumOfTreatment(SqlTransaction trn, string typ, DateTime StartDate, DateTime EndDate)
        {
            try
            {
                SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType",typ),
                                               new SqlParameter("@StartDate",StartDate),
                                               new SqlParameter("@EndDate",EndDate)
                                            };
                DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_SumOfTreatment", msSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.SelectSumOfTreatment", ex);
            }
        }
      public static int UpdateSumOfTreatment(Entity.SumOfTreatment info, SqlTransaction trn)
      {
          int intStatus = 0;
          int all = 0;
          try
          {
              SqlParameter[] msSqlParameter = {
                                                    new SqlParameter("@QueryType",info.QueryType),
                                                    new SqlParameter("@VN",info.VN),
                                                    new SqlParameter("@SO",info.SO),
                                                    new SqlParameter("@CN",info.CN),
                                                    new SqlParameter("@SOT_Code",info.SOT_Code),
                                                    new SqlParameter("@DateSave",info.DateSave),
                                                    new SqlParameter("@DateUpdate",info.DateUpdate),
                                                    new SqlParameter("@SalePrice",info.SalePrice),
                                                    new SqlParameter("@Discount",info.Discount),
                                                    new SqlParameter("@NetAmount",info.NetAmount),
                                                    new SqlParameter("@EarnestMoney",info.EarnestMoney),
                                                    new SqlParameter("@Unpaid",info.Unpaid),
                                                    new SqlParameter("@DiscountPercen",info.DiscountAllItemBath),
                                                    new SqlParameter("@DiscountBath",info.DiscountBath),
                                                    new SqlParameter("@Remark",info.Remark),
                                                    new SqlParameter("@EN",info.EN_Save),
                                                    new SqlParameter("@MedStatus_Code",info.MedStatus_Code),
                                                    new SqlParameter("@BillTo",info.BillTo),
                                                    new SqlParameter("@ReceiptBath",info.ReceiptBath),
                                                    new SqlParameter("@ReceiptDate",info.ReceiptDate),
                                                    new SqlParameter("@INVBath",info.Unpaid),
                                                    new SqlParameter("@Vat",info.Vat),
                                                    new SqlParameter("@NonVat",info.NonVat),
                                                    new SqlParameter("@SORef",info.SORef)
                                                    
                                                    
                                                    };

              intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_SumOfTreatment", msSqlParameter);//[SumOfTreatment]
              if(intStatus > 0)
              {
                  all = intStatus;
              }

              foreach (Entity.SupplieTrans item in info.SupplieTranInfo)
              {
                  SqlParameter[] msSqlParametersup = {
                                                    new SqlParameter("@QueryType",item.QueryType),
                                                    new SqlParameter("@VN",item.VN),
                                                    new SqlParameter("@SO",item.SONo),
                                                    new SqlParameter("@MS_Code",item.MS_Code),
                                                    new SqlParameter("@DateUpdate",DateTime.Now),
                                                    //new SqlParameter("@DiscountPercen",item.DiscountPercen.Replace(",","")),
                                                    //new SqlParameter("@DiscountBathByItem",item.DiscountBath.Replace(",","")),
                                                    new SqlParameter("@DiscountPercen",item.DiscountPercen),
                                                    new SqlParameter("@DiscountBathByItem",item.DiscountBath),
                                                    new SqlParameter("@EN",info.EN_Save),
                                                    new SqlParameter("@PriceAfterDis",item.PriceAfterDis),
                                                    new SqlParameter("@PayByItem",item.PayByItem),
                                                    new SqlParameter("@ListOrder",item.ListOrder)
                                                    
                                                    
                                                    };

                  intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_SumOfTreatment", msSqlParametersup);//[SupplieTrans]
                  if (intStatus > 0)
                  {
                      all = intStatus;
                  }
              }

              //===============CommissionFee ของหมอ ลบก่อน แล้ว insert ใหม่ทั้งหมดชชชชชชชชชชชชชช
            
                  SqlParameter[] msSqlParameterComDocDel = {
                                                    new SqlParameter("@QueryType","DeleteCommissionFee"),
                                                    new SqlParameter("@SO",info.SO)
                                                    };
                  intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_SumOfTreatment", msSqlParameterComDocDel);

                  foreach (Entity.SupplieTrans com in info.SupplieTranInfo)
                  {
                      if ((com.ByDr + "").ToUpper() == "Y")// && com.PayByItem>0
                      {
                          
                          SqlParameter[] msSqlParameterComDoc = {
                                                        new SqlParameter("@QueryType","InsertCommissionFee"),
                                                        new SqlParameter("@SO",com.SONo),
                                                        new SqlParameter("@MS_Code",com.MS_Code),
                                                        new SqlParameter("@ListOrder",com.ListOrder),
                                                        new SqlParameter("@EN_COMS",info.EN_COMSDoctor),
                                                        new SqlParameter("@PayByItem",com.PayByItem),
                                                        new SqlParameter("@SORef",com.SORef),
                                                        new SqlParameter("@PRO_Code",com.PRO_Code),
                                                        
                                                        };
                          intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_SumOfTreatment", msSqlParameterComDoc);//[SupplieTrans]
                      }
                  }
              //=======================End CommissionFee===================================
              //===========================ค่าคอมของ sale===================
              SqlParameter[] msSqlParameterSAVESALECOMS = {
                                                    new SqlParameter("@QueryType","SAVESALECOMS"),
                                                    new SqlParameter("@VN",info.VN),
                                                    new SqlParameter("@SO",info.SO),
                                                    new SqlParameter("@SOT_Code",info.SOT_Code),
                                                    new SqlParameter("@EN_COMS",info.EN_COMS),
                                                    new SqlParameter("@EN_COMS2",info.EN_COMS2),
                                                    new SqlParameter("@Com_Bath",info.Com_Bath),
                                                    new SqlParameter("@Com_Bath2",info.Com_Bath2),
                                                    new SqlParameter("@PriceAfterDis",info.PriceAfterDis),
                                                    new SqlParameter("@DateUpdate",DateTime.Now),

                                                    new SqlParameter("@EN_Save",info.EN_Save)
                                                    
                                                    };

              intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_SumOfTreatment", msSqlParameterSAVESALECOMS);//SAVESALECOMS

              //======================delete RCN no date===============
              //if (info.dicRCN.Any())
              //{
              //    SqlParameter[] msSqlParameterDDD = {
              //                                      new SqlParameter("@QueryType","DeleteReceiptTrans"),
              //                                      new SqlParameter("@SO",info.SO),
              //                                      new SqlParameter("@WhereDelRCN",info.DateNotIn),
              //                                      };

              //    intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_SumOfTreatment", msSqlParameterDDD);//[SumOfTreatment]
              //    //DataSet ds = SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_SumOfTreatment", msSqlParameterDDD);
                 
              //    if (intStatus > 0)
              //    {
              //        all = intStatus;
              //    }

              //    //======================delete RCN no date===============
              //    //======================insert RCN no date===============
              //    foreach (KeyValuePair<string, double> pair in info.dicRCN)
              //    {
              //        SqlParameter[] msSqlParametersup = {
              //                                      new SqlParameter("@QueryType","SAVEReceiptTrans"),
              //                                      new SqlParameter("@SO",info.SO),
              //                                      new SqlParameter("@ReceiptDate",pair.Key),
              //                                      new SqlParameter("@EN",info.EN_Save),
              //                                      new SqlParameter("@ReceiptBath",pair.Value)
              //                                      };

              //        intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_SumOfTreatment", msSqlParametersup);//[SupplieTrans]
              //    }
              //}
              //======================insert RCN no date===============

              if (intStatus > 0)
              {
                  all = intStatus;
              }

              return all;
          }
          catch (Exception ex)
          {
              throw new Exception("An error occurred while executing the Data.UpdateSumOfTreatment", ex);
          }
      }
      public static DataSet SAVERCNo(string RCNo, string SO, DateTime ReceiptDate, string EN_Save, decimal ReceiptBath, SqlTransaction trn)
      {

          DataSet dsRetun ;
          try
          {

                SqlParameter[] msSqlParametersup = {
                                                    new SqlParameter("@QueryType","SAVERCNo"),
                                                    new SqlParameter("@RCNo",RCNo),
                                                    new SqlParameter("@SO",SO),
                                                    new SqlParameter("@ReceiptDate",ReceiptDate),
                                                    new SqlParameter("@EN",EN_Save),
                                                    new SqlParameter("@ReceiptBath",ReceiptBath)
                                                    };

                dsRetun = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_SumOfTreatment", msSqlParametersup);//[SupplieTrans]

                return dsRetun;
          }
          catch (Exception ex)
          {
              throw new Exception("An error occurred while executing the Data.SAVEReceiptTrans", ex);
          }
      }
      public static int DeleteRCNo(string RCNo, SqlTransaction trn)
      {
          int intStatus = 0;
          try
          {
              SqlParameter[] msSqlParameter = {
                                                    new SqlParameter("@QueryType","DELETERCNo"),
                                                    new SqlParameter("@RCNo",RCNo)
                                                    };

              intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_SumOfTreatment", msSqlParameter);
              return intStatus;
          }
          catch (Exception ex)
          {
              throw new Exception("An error occurred while executing the Data.UpdateSumOfTreatment", ex);
          }
      }
      public static int DeleteCashCredit(string ID, SqlTransaction trn)
      {
          int intStatus = 0;
          try
          {
              SqlParameter[] msSqlParameter = {
                                                    new SqlParameter("@QueryType","DELETECREDITCARD"),
                                                    new SqlParameter("@Pay_Code",ID)
                                                    };

              intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_SumOfTreatment", msSqlParameter);
              return intStatus;
          }
          catch (Exception ex)
          {
              throw new Exception("An error occurred while executing the Data.UpdateSumOfTreatment", ex);
          }
      }
      public static int DeletePayByItem(string so,string ms_code,string ListOrder, SqlTransaction trn)
      {
          int intStatus = 0;
          try
          {
              SqlParameter[] msSqlParameter = {
                                                    new SqlParameter("@QueryType","DELETEPayByItem"),
                                                    new SqlParameter("@SO",so),
                                                    new SqlParameter("@MS_Code",ms_code),
                                                    new SqlParameter("@ListOrder",ListOrder)
                                                                                                        
                                                    };

              intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_SumOfTreatment", msSqlParameter);
              return intStatus;
          }
          catch (Exception ex)
          {
              throw new Exception("An error occurred while executing the Data.UpdateSumOfTreatment", ex);
          }
      }

      public static int InsertPayByItem(List<Entity.CreditCardSOT> info, SqlTransaction trn)
      {
          int intStatus = 0;
          int all = 0;
          try
          {

              foreach (Entity.CreditCardSOT item in info)
              {
                  if (item.CashMoney == 0 && item.MoneyCredit==0) continue;
                  SqlParameter[] msSqlParametersup = {
                                                    new SqlParameter("@QueryType","InsertPayByItem"),
                                                    new SqlParameter("@SO",item.SO),
                                                    new SqlParameter("@MS_Code",item.MS_Code),
                                                    new SqlParameter("@ListOrder",item.ListOrder),
                                                    new SqlParameter("@PayByItem",item.CashMoney),
                                                    new SqlParameter("@MoneyCredit",item.MoneyCredit),
                                                    new SqlParameter("@DateUpdate",item.DateUpdate),
                                                    new SqlParameter("@PayRefID",item.PayRefID)
                                                    };

                  intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_SumOfTreatment", msSqlParametersup);//[SupplieTrans]
                  if (intStatus > 0)
                  {
                      all = intStatus;
                  }
              }

         

              return all;
          }
          catch (Exception ex)
          {
              throw new Exception("An error occurred while executing the Data.UpdateSumOfTreatment", ex);
          }
      }

      public static DataSet SelectPayByItem(string so, string ms_code, string ListOrder)
      {
          var conn = new SqlConnection(DataObject.ConnectionString);
          conn.Open();
          //var trn = conn.BeginTransaction();
          try
          {
              SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType","SelectPayByItem"),
                                                new SqlParameter("@SO",so),
                                                new SqlParameter("@MS_Code",ms_code),
                                                new SqlParameter("@ListOrder",ListOrder)
                                                };
              DataSet ds = SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_SumOfTreatment", msSqlParameter);
              return ds;
          }
          catch (AppException)
          {
              return null;
          }
          catch (Exception ex)
          {
              throw new AppException(
                  "An error occurred while executing the Bussiness.SelectCreditCard", ex);
          }
      }
    }
}
