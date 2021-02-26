using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using AryuwatSystem.Baselibary;
using Entity.Validation;

namespace AryuwatSystem.Business
{
   public class UserGroup
    {
       public DataSet SelectUserGroupAll()
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               DataSet ds = Data.UserGroup.SelectUserGroupAll(trn);

               trn.Commit();
               conn.Close();
               return ds;
           }
           catch (AppException)
           {
               return null;
           }
           catch (Exception ex)
           {
               throw new AppException(
                   "An error occurred while executing the Bussiness.SelectUserGroupAll", ex);
           }
       }

       public int? InsertUserGroup(Entity.UserGroup info)
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               var intReturnData = Data.UserGroup.InsertUserGroup(info, trn);

               if (intReturnData == -1)
               {
                   trn.Rollback();
                   conn.Close();
                   return intReturnData;
               }
               trn.Commit();
               conn.Close();
               return intReturnData;
           }
           catch (AppException)
           {
               return null;
           }
           catch (Exception ex)
           {
               throw new AppException(
                   "An error occurred while executing the Bussiness.InsertUserGroup", ex);
           }
       }

       public int? UpdateUserGroup(Entity.UserGroup info)
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               var intReturnData = Data.UserGroup.UpdateUserGroup(info, trn);

               if (intReturnData == -1)
               {
                   trn.Rollback();
                   conn.Close();
                   return intReturnData;
               }
               trn.Commit();
               conn.Close();
               return intReturnData;
           }
           catch (AppException)
           {
               return null;
           }
           catch (Exception ex)
           {
               throw new AppException(
                   "An error occurred while executing the Bussiness.ClsUserGroup.UpdateUserGroup", ex);
           }
       }

       public int? DeleteUserGroup(int id)
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               var intReturnData = Data.UserGroup.DeleteUserGroup(id, trn);

               if (intReturnData == -1)
               {
                   trn.Rollback();
                   conn.Close();
                   return intReturnData;
               }
               trn.Commit();
               conn.Close();
               return intReturnData;
           }
           catch (AppException)
           {
               return null;
           }
           catch (Exception ex)
           {
               throw new AppException(
                   "An error occurred while executing the Bussiness.ClsUserGroup.UpdateUserGroup", ex);
           }
       }

    }
}
