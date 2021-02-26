using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using AryuwatSystem.Baselibary;
using AryuwatSystem.DerClass;
using Entity.Validation;


namespace AryuwatSystem.Data
{
    public class Agency
    {

       public static DataSet SelectAgency()
       {
           try
           {
            
               SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType","AGENCYSELECT"),
                                               };
               DataSet ds = SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_agency", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectAgency", ex);
           }
       }
       public static DataSet SelectAgencyMember()
       {
           try
           {

               SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType","MEMBERSELECT"),
                                               };
               DataSet ds = SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_agency", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectAgency", ex);
           }
       }
       public static DataSet SelectAgencyMemberPaging(Entity.Agency info)
       {
           try
           {
               long iRowStart = 0;
               long iRowEnd = 0;
               DerUtility.FindRangeRow(info.PageNumber, ref iRowStart, ref iRowEnd);
               SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType","SEARCHMEMBER"),
                                               //new SqlParameter("@AgenMemID",info.AgenMemID),
                                                //new SqlParameter("@AgenMemPrefix",info.AgenMemPrefix),
                                                new SqlParameter("@AgenMemName",info.AgenMemName),
                                                new SqlParameter("@AgenMemSurName",info.AgenMemSurName),
                                                //new SqlParameter("@AgenMemAddress",info.AgenMemAddress),
                                                //new SqlParameter("@AgenMemTel",info.AgenMemTel),
                                                new SqlParameter("@AgenMemIDCard",info.AgenMemIDCard),
                                               new SqlParameter("@row_start", iRowStart),
                                               new SqlParameter("@row_end", iRowEnd)
                                               
                                            };
               DataSet ds =
                   SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_agency", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectAgencyMemberPaging", ex);
           }
       }
       public static int? DeleteAgencyById(string ID, SqlTransaction trn)
       {
           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("AgenID", ID),
                                                new SqlParameter("@QueryType","AGENCYDELETE")
                                           };
               int intStatus =
                   SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_agency", msSqlParameter);
               return intStatus;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public static int? DeleteAgencyMemById(string ID, SqlTransaction trn)
       {
           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("AgenMemID", ID),
                                                new SqlParameter("@QueryType","MEMBERDELETE")
                                           };
               int intStatus =
                   SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_agency", msSqlParameter);
               return intStatus;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

        public static int SaveAgency(Entity.Agency info, SqlTransaction trn)
        {
            string idMax = "";
            idMax = info.saveNew ? UtilityBackEnd.GenMaxSeqnoValues("AGC") : info.AgenID;
            SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType","AGENCYSAVE"),
                                                new SqlParameter("@AgenID",idMax),
                                                new SqlParameter("@AgenTyp",info.AgenTyp),
                                                new SqlParameter("@AgenName",info.AgenName),
                                                new SqlParameter("@AgenAddress",info.AgenAddress),
                                                new SqlParameter("@AgenTel",info.AgenTel),
                                                new SqlParameter("@AgenDescript",info.AgenDescript),
                                                new SqlParameter("@UpdateDate",DateTime.Now),
                                                new SqlParameter("@ENSave",info.ENSave),
                                                new SqlParameter("@SupportName",info.SupportName),
                                                new SqlParameter("@SupportTel",info.SupportTel)
                                            };

            int intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_agency", msSqlParameter);
            return intStatus;
        }

        public static int SaveAgencyMember(Entity.Agency info, SqlTransaction trn)
        {
            string idMax = "";
            idMax = info.saveNew ? UtilityBackEnd.GenMaxSeqnoValues(info.AgenTyp) : info.AgenMemID;
            SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType","MEMBERSAVE"),
                                                new SqlParameter("@AgenID",info.AgenID),
                                                new SqlParameter("@AgenMemID",idMax),
                                                new SqlParameter("@AgenMemPrefix",info.AgenMemPrefix),
                                                new SqlParameter("@AgenMemName",info.AgenMemName),
                                                new SqlParameter("@AgenMemSurName",info.AgenMemSurName),
                                                new SqlParameter("@AgenMemAddress",info.AgenMemAddress),
                                                new SqlParameter("@AgenMemTel",info.AgenMemTel),
                                                new SqlParameter("@AgenMemIDCard",info.AgenMemIDCard),
                                                new SqlParameter("@AgenMemRate",info.AgenMemRate),
                                                new SqlParameter("@UpdateDate",DateTime.Now),
                                                new SqlParameter("@ENSave",info.ENSave),
                                                new SqlParameter("@BeUnder",info.BeUnder)
                                                
                                            };

            int intStatus = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_agency", msSqlParameter);

            //SqlParameter[] msSqlParameter = {
            //                                    new SqlParameter("@QueryType","MEMBERSAVE"),
            //                                   };
            //DataSet ds = SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_agency", msSqlParameter);

            return intStatus;
        }
    }


}
