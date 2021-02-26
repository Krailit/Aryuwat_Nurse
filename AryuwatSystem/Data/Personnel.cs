using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using AryuwatSystem.Baselibary;
using AryuwatSystem.DerClass;


namespace AryuwatSystem.Data
{
    public class Personnel
    {

        public static int? InsertPersonnel(ref Entity.Personnel info, SqlTransaction trn)
       {
           //var idMax = UtilityBackEnd.GenMaxSeqnoValues(info.EN);
           SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType",info.QueryType),
                                                new SqlParameter("@AddressId",info.AddressId),
                                                new SqlParameter("@Building",info.Building),
                                                new SqlParameter("@CreateBy",info.CreateBy),
                                                new SqlParameter("@CreateDate",info.CreateDate),
                                                new SqlParameter("@DateBirth",info.DateBirth),
                                                new SqlParameter("@DateEndW",info.DateEndW),
                                                new SqlParameter("@DateRegister",info.DateRegister),
                                                new SqlParameter("@DateStartW",info.DateStartW),
                                                new SqlParameter("@District",info.District),
                                                new SqlParameter("@EFirstname",info.EFirstname),
                                                new SqlParameter("@ELastname",info.ELastname),
                                                new SqlParameter("@EMiddlename",info.EMiddlename),
                                                new SqlParameter("@EN",info.EN),
                                                new SqlParameter("@ENickname",info.ENickname),
                                                new SqlParameter("@E_mail",info.E_mail),
                                                new SqlParameter("@Gender",info.Gender),
                                                new SqlParameter("@Height",info.Height),
                                                new SqlParameter("@IdCard",info.IdCard),
                                                new SqlParameter("@Mobile1",info.Mobile1),
                                                new SqlParameter("@Mobile2",info.Mobile2),
                                                new SqlParameter("@Nationality",info.Nationality),
                                                new SqlParameter("@PassportId",info.PassportId),
                                                new SqlParameter("@Passwords",info.Passwords),
                                                new SqlParameter("@PersonnelType",info.PersonnelType),
                                                new SqlParameter("@PostCode",info.PostCode),
                                                new SqlParameter("@PrefixCode",info.PrefixCode),
                                                new SqlParameter("@Province",info.Province),
                                                new SqlParameter("@Race",info.Race),
                                                new SqlParameter("@Road",info.Road),
                                                new SqlParameter("@Soi",info.Soi),
                                                new SqlParameter("@Sub_district",info.Sub_district),
                                                new SqlParameter("@TName",info.TName),
                                                new SqlParameter("@TNickname",info.TNickname),
                                                new SqlParameter("@TSurname",info.TSurname),
                                                new SqlParameter("@Telephone1",info.Telephone1),
                                                new SqlParameter("@Telephone2",info.Telephone2),
                                                new SqlParameter("@UpdateBy",info.UpdateBy),
                                                new SqlParameter("@UserGroup",info.UserGroup),
                                                new SqlParameter("@Weights",info.Weights),
                                                new SqlParameter("@Username",info.Username),
                                                new SqlParameter("@ImageFilename",info.ImageFilename),
                                                new SqlParameter("@BranchID",info.BranchID),
                                                new SqlParameter("@BranchAuth",info.BranchAuth),
                                                new SqlParameter("@Active",info.Active)
                                                
                                            };

          int intStatus =SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "sp_personnel", msSqlParameter);
           return intStatus;
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

       public static DataSet SelectCustomerPaging(Entity.Personnel info)
       {
           try
           {
               long iRowStart = 0;
               long iRowEnd = 0;
               DerUtility.FindRangeRow(info.PageNumber, ref iRowStart, ref iRowEnd);
               SqlParameter[] msSqlParameter = {
                                                new SqlParameter("@QueryType",info.QueryType),
                                               new SqlParameter("@EN",info.EN),
                                               new SqlParameter("@TName",info.TName),
                                               new SqlParameter("@TSurName",info.TSurname),
                                               new SqlParameter("@Mobile1",info.Mobile1),
                                               new SqlParameter("@row_start", iRowStart),
                                               new SqlParameter("@row_end", iRowEnd),
                                               new SqlParameter("@PersonnelType",info.PersonnelType),
                                               new SqlParameter("@BranchID",info.BranchID)
                                               
                                               
                                            };
               DataSet ds =
                   SqlHelper.ExecuteDataset(DataObject.ConnectionString, CommandType.StoredProcedure, "sp_personnel", msSqlParameter);
               return ds;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectCustomerPaging", ex);
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
       public static DataSet SearchPersonnelByType( string typ, SqlTransaction trn)
       {
           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType",typ),
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
       public static DataSet SearchPersonnelByTypeDoctor(string typ, SqlTransaction trn)
       {
           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType",typ),
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
               DataSet dataReader = SqlHelper.ExecuteDataset(trn, CommandType.Text, "select * from UserGroup order by groupname", null);
               return dataReader;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectPersonnelGroup", ex);
           }
       }
       public static DataSet SelectBranch_PersonnelType(SqlTransaction trn)
       {
           try
           {
               DataSet dataReader = SqlHelper.ExecuteDataset(trn, CommandType.Text, "select * from PersonnelType order by PersonnelType_Order;select * from Branch order by ShowOrder", null);
               return dataReader;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectCustomerAll", ex);
           }
       }
       public static DataSet SelectPersonnelTypeWhereCause(SqlTransaction trn, string QueryType)
       {
           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@QueryType",QueryType),
                                            };
               DataSet dataReader =
                   SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "sp_personnel", msSqlParameter);
               return dataReader;
           }
           catch (Exception ex)
           {
               throw new Exception("An error occurred while executing the Data.SelectPersonnelTypeWhereCause", ex);
           }
       }

       public static int? DeletePersonnelById(string EN, SqlTransaction trn)
       {
           StringBuilder sb = new StringBuilder();
           sb.Append(" delete Personnels where EN = @EN \n");

           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@EN", EN)
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
       public static DataSet CheckUserPassId(string username, SqlTransaction trn)
       {
           StringBuilder sb = new StringBuilder();
           sb.Append(" select Username FROM Personnels where Username = @username \n");

           try
           {
               SqlParameter[] msSqlParameter = {
                                               new SqlParameter("@username", username)
                                           };
               DataSet dataReader =SqlHelper.ExecuteDataset(trn, CommandType.Text,sb.ToString(), msSqlParameter);
               return dataReader;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }



       public static DataTable getConfig(SqlTransaction trn)
       {
           string sql = "select * from conF";

           try
           {
               DataSet dataReader = SqlHelper.ExecuteDataset(trn, CommandType.Text, sql);
               return dataReader.Tables[0];
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public static DataTable getNoti(SqlTransaction trn)
       {
           string sql = "select * from conF";

           try
           {
               DataSet dataReader = SqlHelper.ExecuteDataset(trn, CommandType.Text, sql);
               return dataReader.Tables[0];
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public static DataTable getMoConfig(SqlTransaction trn)
       {
           string sql = "select * from MoConfig  order by [values]";

           try
           {
               DataSet dataReader = SqlHelper.ExecuteDataset(trn, CommandType.Text, sql);
               return dataReader.Tables[0];
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public static DataTable getUnit(SqlTransaction trn)
       {
           string sql = "select * from Unit order by ord";

           try
           {
               DataSet dataReader = SqlHelper.ExecuteDataset(trn, CommandType.Text, sql);
               return dataReader.Tables[0];
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
    }


}
