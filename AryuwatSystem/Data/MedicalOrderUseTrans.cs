using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using AryuwatSystem.Baselibary;
using AryuwatSystem.DerClass;
using Entity.Validation;

namespace AryuwatSystem.Data
{
   public class MedicalOrderUseTrans
    {
       //Insert Yai
       //public static int? InsertMedicalOrderUseTrans( Entity.MedicalOrder info, SqlTransaction trn, string VN)
       //{
       //    int intStatus = 0;
       //    Dictionary<string,string>DicidMax=new Dictionary<string, string>();
       //    try
       //    { 
       //        var idMax = UtilityBackEnd.GenMaxSeqnoValues("MUT");
               
       //        foreach (Entity.MedicalOrderUseTrans c in info.MedicalOrderUseTransesInfo)
       //        {
       //            c.Id = idMax;
       //            if (c.DicId==null)c.DicId=new Dictionary<string, string>();
       //            c.DicId.Add(c.MS_Code,idMax);
       //            DicidMax.Add(c.MS_Code, idMax);
       //            SqlParameter[] msSqlParameter = {
       //                                                     new SqlParameter("@QueryType", "INSERT"),
       //                                                     new SqlParameter("@Id", idMax),
       //                                                     new SqlParameter("@VN", VN),
       //                                                     new SqlParameter("@CN", c.CN),
       //                                                     new SqlParameter("@MS_Code", c.MS_Code),
       //                                                     new SqlParameter("@AmountOfUse", c.AmountOfUse)
       //                                                 };

       //            intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_MedicalOrderUseTrans",msSqlParameter);
       //            string frefix = idMax.Substring(0, idMax.Length - 1);
       //            string sufix =(Convert.ToInt16(idMax.Substring(idMax.Length - 1,1))+1).ToString();
       //            idMax = frefix + sufix;
                   
       //        }
                   
       //        intStatus = (int)Data.MedicalStuff.InsertMedicalStuff(info.MedicalStuffInfo, trn, VN, DicidMax);
       //        return intStatus;
       //    }
       //    catch (Exception ex)
       //    {
       //        throw new Exception("An error occurred while executing the Data.InsertMedicalOrderUseTrans", ex);
       //    }
       //}
       public static DataSet CheckCourseCardCreated(string Sono, string VN, string MS_Code, string ListOrder)
       {
           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","SELECT_COURSECARD"),
                                                new SqlParameter("@Sono", Sono),
                                                            new SqlParameter("@VN", VN),
                                                            new SqlParameter("@MS_Code", MS_Code),
                                                            new SqlParameter("@ListOrder", ListOrder),
                                                            //new SqlParameter("@BranchId", c.BranchId),
                                            };
               DataSet ds =
                   SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_MedicalOrderUseTrans", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectMedicalOrderById", ex);
           }
       }

       public static int? DeleteCourseCard(Entity.MedicalOrderUseTrans c, SqlTransaction trn)
       {
           int intStatus = 0;
           //Dictionary<string, string> DicidMax = new Dictionary<string, string>();
           try
           {
               SqlParameter[] msSqlParameter = {
                                                            new SqlParameter("@QueryType", "DELETE_COURSECARD"),
                                                            new SqlParameter("@Sono", c.Sono),
                                                            new SqlParameter("@VN", c.VN),
                                                            new SqlParameter("@MS_Code", c.MS_Code),
                                                            new SqlParameter("@ListOrder", c.ListOrder),
                                                            new SqlParameter("@CreateBy", c.CreateBy),
                                                        };

               intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_MedicalOrderUseTrans", msSqlParameter);

               return intStatus;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.InsertMedicalOrderUseTrans", ex);
           }
       }
       public static int? UpdateSlipCourseCard(Entity.MedicalOrderUseTrans c, SqlTransaction trn)
       {
           int intStatus = 0;
           //Dictionary<string, string> DicidMax = new Dictionary<string, string>();
           try
           {
               SqlParameter[] msSqlParameter = {
                                                            new SqlParameter("@QueryType", "UPDATE_SLIPCOURSE"),
                                                            new SqlParameter("@CO", c.CO),
                                                             new SqlParameter("@PrintSlip",c.PrintSlip),
                                                             new SqlParameter("@PrintLineOrder",c.PrintLineOrder)
                                                        };

               intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_MedicalOrderUseTrans", msSqlParameter);

               return intStatus;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.InsertMedicalOrderUseTrans", ex);
           }
       }
           public static int? InsertMedicalCourseCard(Entity.MedicalOrderUseTrans c, SqlTransaction trn)
       {
           int intStatus = 0;
           //Dictionary<string, string> DicidMax = new Dictionary<string, string>();
           try
           {
                                  SqlParameter[] msSqlParameter = {
                                                            new SqlParameter("@QueryType", "INSERT_COURSECARD"),
                                                            new SqlParameter("@Sono", c.Sono),
                                                            new SqlParameter("@VN", c.VN),
                                                            new SqlParameter("@MS_Code", c.MS_Code),
                                                            new SqlParameter("@ListOrder", c.ListOrder),
                                                            new SqlParameter("@CreateBy", c.CreateBy),
                                                            new SqlParameter("@CreateDate", c.CreateDate),
                                                            new SqlParameter("@BranchId", c.BranchId),
                                                             new SqlParameter("@CourseCardID",c.CourseCardID),
                                                             new SqlParameter("@IsUpdated",c.IsUpdated)
                                                             
                                                            
                                                        };

                   intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_MedicalOrderUseTrans", msSqlParameter);

               return intStatus;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.InsertMedicalOrderUseTrans", ex);
           }
       }
           public static int? UpdateExpireCourseCard(Entity.MedicalOrderUseTrans c, SqlTransaction trn)
           {
               int intStatus = 0;
               //Dictionary<string, string> DicidMax = new Dictionary<string, string>();
               try
               {
                   SqlParameter[] msSqlParameter = {
                                                            new SqlParameter("@QueryType", "UPDATEEXPIRE_COURSECARD"),
                                                            new SqlParameter("@Sono", c.Sono),
                                                            new SqlParameter("@VN", c.VN),
                                                            new SqlParameter("@MS_Code", c.MS_Code),
                                                            new SqlParameter("@ListOrder", c.ListOrder),
                                                            new SqlParameter("@CreateBy", c.CreateBy),
                                                            new SqlParameter("@CreateDate", c.CreateDate),
                                                            new SqlParameter("@BranchId", c.BranchId),
                                                             new SqlParameter("@CourseCardID",c.CourseCardID),
                                                             new SqlParameter("@DateOfUse",c.DateOfUse),
                                                             
                                                            
                                                        };

                   intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_MedicalOrderUseTrans", msSqlParameter);

                   return intStatus;
               }
               catch (Exception ex)
               {
                   throw new Exception("An error occurred while executing the Data.InsertMedicalOrderUseTrans", ex);
               }
           }
       public static int? InsertMedicalOrderUseTrans(Entity.MedicalOrderUseTrans[] info, SqlTransaction trn)
       {
           int intStatus = 0;
           //Dictionary<string, string> DicidMax = new Dictionary<string, string>();
           try
           {
               var idMax = UtilityBackEnd.GenMaxSeqnoValues("MUT");
               int? intStatusx = Data.MedicalStuff.DeleteMedicalStuff(trn, info[0].VN, info[0].MS_Code, info[0].Id, info[0].ListOrder, info[0].CreateBy);
               foreach (Entity.MedicalOrderUseTrans c in info)
               {
                   c.Id = idMax;
                   //if (c.DicId == null) c.DicId = new Dictionary<string, string>();
                   //c.DicId.Add(c.MS_Code, idMax);
                   //DicidMax.Add(c.MS_Code, idMax);
                   SqlParameter[] msSqlParameter = {
                                                            new SqlParameter("@QueryType", "INSERT"),
                                                            new SqlParameter("@Id", idMax),
                                                            new SqlParameter("@VN", c.VN),
                                                            new SqlParameter("@CN", c.CN),
                                                            new SqlParameter("@MS_Code", c.MS_Code),
                                                            new SqlParameter("@AmountOfUse", c.AmountOfUse),
                                                            new SqlParameter("@AmountTotal", c.AmountTotal),
                                                            new SqlParameter("@AmountBalance", c.AmountBalance),
                                                            
                                                            new SqlParameter("@DateOfUse", c.DateOfUse), 
                                                            new SqlParameter("@CO", c.CO), 
                                                           // new SqlParameter("@SO", c.SONew), 
                                                            new SqlParameter("@CN_USED", c.CN_USED),
                                                            new SqlParameter("@RefMO", c.RefMO),
                                                            new SqlParameter("@UpdateBy", c.CreateBy),
                                                            new SqlParameter("@ListOrder", c.ListOrder),
                                                            new SqlParameter("@Remark", c.Remark),
                                                            new SqlParameter("@FeeRate", c.FeeRate),
                                                            new SqlParameter("@FeeRate2", c.FeeRate2),
                                                            new SqlParameter("@swap", c.swap),
                                                            new SqlParameter("@BranchId", c.BranchId),
                                                             new SqlParameter("@SO", c.Sono),
                                                             new SqlParameter("@PriceAfterDis", c.PriceAfterDis),
                                                             new SqlParameter("@UsedID",c.Id),
                                                             new SqlParameter("@EN_REQ",c.EN_REQ),
                                                             new SqlParameter("@EN_Helper",c.EN_Helper),
                                                             new SqlParameter("@CourseCardID",c.CourseCardID),
                                                             new SqlParameter("@Shot",c.Shot),
                                                             new SqlParameter("@GiftCode",c.GiftCode),
                                                             
                                                             
                                                            
                                                        };

                   intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_MedicalOrderUseTrans", msSqlParameter);
                   //if (intStatus >= 0)
                   //{
                   //    trn.Commit();
                   //}

                   //var conn = new SqlConnection(DataObject.ConnectionString);
                   //conn.Open();
                   //trn = conn.BeginTransaction();

                   intStatus = (int)Data.MedicalStuff.InsertMedicalStuff(c.MedicalStuffInfo, trn, c.VN, idMax, c.ListOrder);

                   Entity.MedicalOrder infosur = new Entity.MedicalOrder();
                   infosur.CN = c.CN;
                   infosur.VN = c.VN;
                   infosur.MS_Code = c.MS_Code;
                   infosur.UseTransId = idMax;
                   infosur.UpdateBy = c.CreateBy;
                   intStatus = (int)Data.SurgeryFee.InsertSurgeryFee(infosur, trn, c.VN);

                   string frefix = idMax.Substring(0, idMax.Length - 1);
                   string sufix = (Convert.ToInt16(idMax.Substring(idMax.Length - 1, 1)) + 1).ToString();
                   idMax = frefix + sufix;

               }

               return intStatus;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.InsertMedicalOrderUseTrans", ex);
           }
       }


       public static int? UpdateMedicalCheckCouse(Entity.MedicalOrderUseTrans[] info, SqlTransaction trn)
       {
           int? intStatus = 0;
           try
           {
               foreach (Entity.MedicalOrderUseTrans c in info)
               {
                   SqlParameter[] msSqlParameter = {
                                                            new SqlParameter("@QueryType", "UPDATECheckCouse"),
                                                            new SqlParameter("@VN", c.VN),
                                                            new SqlParameter("@MS_Code", c.MS_Code),
                                                            new SqlParameter("@ListOrder", c.ListOrder),
                                                            new SqlParameter("@FlagUse", c.FlagUse)
                                                            
                                                        };

                   intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_MedicalOrderUseTrans", msSqlParameter);

               }

               return intStatus;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.InsertMedicalOrderUseTrans", ex);
           }
       }
       public static int? UpdateMedicalOrderUseTrans(Entity.MedicalOrderUseTrans[] info, SqlTransaction trn)
       {
           int? intStatus = 0;
           //Dictionary<string, string> DicidMax = new Dictionary<string, string>();
           try
           {
               //var idMax = UtilityBackEnd.GenMaxSeqnoValues("MUT");

               foreach (Entity.MedicalOrderUseTrans c in info)
               {
                   //c.Id = idMax;
                   //if (c.DicId == null) c.DicId = new Dictionary<string, string>();
                   //c.DicId.Add(c.MS_Code, idMax);
                   //DicidMax.Add(c.MS_Code, idMax);
                   SqlParameter[] msSqlParameter = {
                                                            new SqlParameter("@QueryType", "UPDATE"),
                                                            new SqlParameter("@Id", c.Id),
                                                            new SqlParameter("@VN", c.VN),
                                                            new SqlParameter("@CN", c.CN),
                                                            new SqlParameter("@MS_Code", c.MS_Code),
                                                            new SqlParameter("@AmountOfUse", c.AmountOfUse),
                                                            new SqlParameter("@AmountTotal", c.AmountTotal),
                                                            new SqlParameter("@AmountBalance", c.AmountBalance),
                                                            
                                                            new SqlParameter("@DateOfUse", c.DateOfUse),
                                                            new SqlParameter("@CO", c.CO), 
                                                            new SqlParameter("@CN_USED", c.CN_USED),
                                                            new SqlParameter("@RefMO", c.RefMO),
                                                            new SqlParameter("@UpdateBy", c.CreateBy),
                                                            new SqlParameter("@ListOrder", c.ListOrder),
                                                            new SqlParameter("@Remark", c.Remark),
                                                            new SqlParameter("@FeeRate", c.FeeRate),
                                                            new SqlParameter("@FeeRate2", c.FeeRate2),
                                                            new SqlParameter("@swap", c.swap),
                                                            new SqlParameter("@BranchId", c.BranchId),
                                                            new SqlParameter("@SO", c.Sono),
                                                            new SqlParameter("@PriceAfterDis", c.PriceAfterDis),
                                                            new SqlParameter("@UsedID",c.Id),
                                                            new SqlParameter("@EN_REQ",c.EN_REQ),
                                                            new SqlParameter("@EN_Helper",c.EN_Helper),
                                                            new SqlParameter("@CourseCardID",c.CourseCardID),
                                                            new SqlParameter("@GiftCode",c.GiftCode),
                                                            new SqlParameter("@Shot",c.Shot),
                                                            
                                                        };

                   intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_MedicalOrderUseTrans", msSqlParameter);

                   intStatus = Data.MedicalStuff.DeleteMedicalStuff(trn, c.VN, c.MS_Code, c.Id, c.ListOrder, c.CreateBy);
                   intStatus = Data.MedicalStuff.InsertMedicalStuff(c.MedicalStuffInfo, trn, c.VN, c.Id, c.ListOrder);

                   //string frefix = idMax.Substring(0, idMax.Length - 1);
                   //string sufix = (Convert.ToInt16(idMax.Substring(idMax.Length - 1, 1)) + 1).ToString();
                   //idMax = frefix + sufix;

               }

               return intStatus;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.InsertMedicalOrderUseTrans", ex);
           }
       }

       public static DataSet SelectMedicalOrderUseTransById(SqlTransaction trn, Entity.MedicalOrderUseTrans info)
       {
           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","SELECTBYID"),
                                               new SqlParameter("@VN",info.VN),
                                               new SqlParameter("@ListOrder",info.ListOrder),
                                               new SqlParameter("MS_Code",info.MS_Code)
                                            };
               DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_MedicalOrderUseTrans", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectMedicalOrderUseTransById", ex);
           }
       }
       public static DataSet SelectMedicalOrderUseTransByCN(SqlTransaction trn, Entity.MedicalOrderUseTrans info)
       {
           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","SELECTBYCN"),
                                               new SqlParameter("@CN",info.CN),
                                               new SqlParameter("@ListOrder",info.ListOrder),
                                               new SqlParameter("MS_Code",info.MS_Code)
                                            };
               DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_MedicalOrderUseTrans", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectMedicalOrderUseTransById", ex);
           }
       }
       public static DataSet SelectMedicalOrderUseTransByCN_CheckCouse(SqlTransaction trn, Entity.MedicalOrderUseTrans info)
       {
           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","SELECTBYCN_CheckCouse"),
                                               new SqlParameter("@CN",info.CN),
                                           
                                            };
               DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_MedicalOrderUseTrans", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectMedicalOrderUseTransById", ex);
           }
       }
       public static DataSet SelectMedicalOrderUseTrans_CheckCouseSOPro(SqlTransaction trn, Entity.MedicalOrderUseTrans info)
       {
           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","SELECTBYCN_CheckCouseSOPro"),
                                               new SqlParameter("@Sono",info.Sono),
                                               new SqlParameter("@VN",info.VN),
                                           
                                            };
               DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_MedicalOrderUseTrans", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectMedicalOrderUseTransById", ex);
           }
       }
       public static DataSet SelectSavedJobCostById(SqlTransaction trn, string typ, string VN, string MS_Code, string ListOrder, string Id)
       {
           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType",typ),
                                               new SqlParameter("@VN",VN),
                                               new SqlParameter("@MS_Code",MS_Code),
                                               new SqlParameter("@ListOrder",ListOrder),
                                               new SqlParameter("@Id",Id),
                                            };
               DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_MedicalOrderUseTrans", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectMedicalOrderUseTransById", ex);
           }
       }
       public static DataSet SELECTSAVEDJOBCOST_COM(SqlTransaction trn, string VN, string SO, string MS_Code, string ListOrder)
       {
           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","SELECTSAVEDJOBCOST_COM"),
                                               new SqlParameter("@VN",VN),
                                               new SqlParameter("@SO",SO),
                                               new SqlParameter("@MS_Code",MS_Code),
                                               new SqlParameter("@ListOrder",ListOrder),
                                            };
               DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_MedicalOrderUseTrans", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectMedicalOrderUseTransById", ex);
           }
       }
       public static DataSet CheckUsedCourse(SqlTransaction trn, string VN, string SO, string MS_Code, string ListOrder)
       {
           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","CheckUsedCourse"),
                                               new SqlParameter("@VN",VN),
                                               new SqlParameter("@SO",SO),
                                               new SqlParameter("@MS_Code",MS_Code),
                                               new SqlParameter("@ListOrder",ListOrder),
                                            };
               DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_MedicalOrderUseTrans", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectMedicalOrderUseTransById", ex);
           }
       }
         public static DataSet CheckUsedCoursePro(SqlTransaction trn, string VN, string SO, string MS_Code, string ListOrder)
       {
           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","CheckUsedCoursePro"),
                                               new SqlParameter("@VN",VN),
                                               new SqlParameter("@SO",SO),
                                               new SqlParameter("@MS_Code",MS_Code),
                                               new SqlParameter("@ListOrder",ListOrder),
                                            };
               DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_MedicalOrderUseTrans", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectMedicalOrderUseTransById", ex);
           }
       }
       
       public static DataSet CheckExpireSO(SqlTransaction trn, string VN, string SO, string MS_Code, string ListOrder)
       {
           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType","CheckExpireSO"),
                                               new SqlParameter("@VN",VN),
                                               new SqlParameter("@SO",SO),
                                               new SqlParameter("@MS_Code",MS_Code),
                                               new SqlParameter("@ListOrder",ListOrder),
                                            };
               DataSet ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_MedicalOrderUseTrans", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectMedicalOrderUseTransById", ex);
           }
       }
       
       public static int? DeleteMedicalUseTrans(SqlTransaction trn, string VN, string so)
       {
           int intStatus = 0;

           SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType", "DELETE"),
                                               new SqlParameter("@VN", VN),
                                               new SqlParameter("@SO", so)
                                           };

           intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_MedicalOrderUseTrans", msSqlParameter);

           return intStatus;
       }

       public static int? DeleteMedicalOrderUseTransById(string useId, string VN, string CN, string MS_Code, string ListOrder, string updateBy, string BranchId, SqlTransaction trn)
       {
           int intStatus = 0;

           SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType", "DELETEBYID"),
                                               new SqlParameter("@Id", useId),
                                               new SqlParameter("@VN", VN),
                                               new SqlParameter("@CN", CN),
                                               new SqlParameter("@MS_Code", MS_Code),
                                               new SqlParameter("@ListOrder", ListOrder),
                                               new SqlParameter("@UpdateBy", updateBy),
                                               new SqlParameter("@BranchId", BranchId)
                                           };

           intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_MedicalOrderUseTrans", msSqlParameter);

           return intStatus;
       }

    }
}
