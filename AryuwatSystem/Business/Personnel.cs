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
   public class Personnel
    {
       public int? InsertPersonnel(ref Entity.Personnel info)
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               var intReturnData = Data.Personnel.InsertPersonnel(ref info, trn);
               
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
                   "An error occurred while executing the Bussiness.ClsCustomer.InsertCustomer", ex);
           }
       }


       public int? UpdateCustomer(Entity.Customer info)
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               var intReturnData = Data.Customer.UpdateCustomer( info, trn);

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
                   "An error occurred while executing the Bussiness.ClsCustomer.InsertCustomer", ex);
           }
       }


       public DataSet SelectCustomerPaging(Entity.Personnel info)
       {
           try
           {
               return Data.Personnel.SelectCustomerPaging(info);
           }
           catch (AppException)
           {
               return null;
           }
           catch (Exception ex)
           {
               throw new AppException("An error occurred while executing the Bussiness.SelectCustomerPaging", ex);
           }
       }

       public DataSet GetPersonnelByUserName(Entity.Personnel info)
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               string strPersonID;
               //Data.Person.InsertPerson(info.PersonInfo, trn, out strPersonID);
               //info.PersonID = strPersonID;
               var intReturnData = Data.Personnel.GetPersonnelByUserName(info, trn);

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
               throw new AppException("An error occurred while executing the Bussiness.GetPersonnelByUserName", ex);
           }
       }


       public DataSet SearchPersonnel(ref Entity.Personnel info)
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               string strPersonID;
               //Data.Person.InsertPerson(info.PersonInfo, trn, out strPersonID);
               //info.PersonID = strPersonID;
               var intReturnData = Data.Personnel.SearchPersonnel(ref info, trn);

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
                   "An error occurred while executing the Bussiness.ClsCustomer.InsertCustomer", ex);
           }
       }
       public DataSet SearchPersonnelByID(ref Entity.Personnel info)
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               string strPersonID;
               //Data.Person.InsertPerson(info.PersonInfo, trn, out strPersonID);
               //info.PersonID = strPersonID;
               var intReturnData = Data.Personnel.SearchPersonnelByID(ref info, trn);

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
                   "An error occurred while executing the Bussiness.ClsCustomer.InsertCustomer", ex);
           }
       }
       public DataSet SearchPersonnelByType(string typ)
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               string strPersonID;
               var intReturnData = Data.Personnel.SearchPersonnelByType(typ, trn);

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
                   "An error occurred while executing the Bussiness.ClsCustomer.InsertCustomer", ex);
           }
       }
       
       public DataSet SelectPersonnelGroup()
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               string strPersonID;
               //Data.Person.InsertPerson(info.PersonInfo, trn, out strPersonID);
               //info.PersonID = strPersonID;
               var intReturnData = Data.Personnel.SelectPersonnelGroup(trn);

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
                   "An error occurred while executing the Bussiness.ClsCustomer.InsertCustomer", ex);
           }
       }
       public DataSet SelectBranch_PersonnelType()
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               string strPersonID;
               //Data.Person.InsertPerson(info.PersonInfo, trn, out strPersonID);
               //info.PersonID = strPersonID;
               var intReturnData = Data.Personnel.SelectBranch_PersonnelType(trn);

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
                   "An error occurred while executing the Bussiness.Personnel.SelectPersonnelType", ex);
           }
       }

       public DataSet SelectPersonnelTypeWhereCause(string QueryType)
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               string strPersonID;
               //Data.Person.InsertPerson(info.PersonInfo, trn, out strPersonID);
               //info.PersonID = strPersonID;
               DataSet intReturnData = Data.Personnel.SelectPersonnelTypeWhereCause(trn, QueryType);

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
                   "An error occurred while executing the Bussiness.Personnel.SelectPersonnelTypeWhereCause", ex);
           }
       }

       public DataSet CheckUserPassId(string username)
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               string strPersonID;
               //Data.Person.InsertPerson(info.PersonInfo, trn, out strPersonID);
               //info.PersonID = strPersonID;
               var intReturnData = Data.Personnel.CheckUserPassId(username,trn);

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
                   "An error occurred while executing the Bussiness.Personnel.SelectPersonnelType", ex);
           }
       }

       
       public int? DeletePersonnelById(string EN)
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               var intReturnData = Data.Personnel.DeletePersonnelById(EN, trn);
              
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
           catch (Exception ex)
           {
               trn.Rollback();
               conn.Close();
               throw new AppException(
                   "An error occurred while executing the Bussiness.Personnel.DeletePersonnelById", ex);
           }
       }

       public DataTable getMoConfig()
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               var intReturnData = Data.Personnel.getMoConfig(trn);

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
                   "An error occurred while executing the Bussiness.Personnel.SelectPersonnelType", ex);
           }
       }
       public DataTable getUnit()
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               var intReturnData = Data.Personnel.getUnit(trn);

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
                   "An error occurred while executing the Bussiness.Personnel.SelectPersonnelType", ex);
           }
       }
       public DataTable getConfig()
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               var intReturnData = Data.Personnel.getConfig(trn);

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
                   "An error occurred while executing the Bussiness.Personnel.SelectPersonnelType", ex);
           }
       }
       public DataTable getNoti()
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               var intReturnData = Data.Personnel.getNoti(trn);

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
                   "An error occurred while executing the Bussiness.Personnel.SelectPersonnelType", ex);
           }
       }
      
    }
}
