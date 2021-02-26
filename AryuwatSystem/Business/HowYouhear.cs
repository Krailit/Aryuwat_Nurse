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
    public class HowYouhear
    {
        public int? InsertHowYouhear(Entity.HowYouhear info)
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               var intReturnData = Data.HowYouhear.InsertHowYouhear(info, trn);
               
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
                   "An error occurred while executing the Bussiness.HowYouhear.InsertHowYouhear", ex);
           }
       }

       //public int? UpdateCustomer(Entity.Customer info)
       //{
       //    var conn = new SqlConnection(DataObject.ConnectionString);
       //    conn.Open();
       //    var trn = conn.BeginTransaction();
       //    try
       //    {
       //        var intReturnData = Data.Customer.UpdateCustomer( info, trn);

       //        if (intReturnData == -1)
       //        {
       //            trn.Rollback();
       //            conn.Close();
       //            return intReturnData;
       //        }
       //        trn.Commit();
       //        conn.Close();
       //        return intReturnData;
       //    }
       //    catch (AppException)
       //    {
       //        return null;
       //    }
       //    catch (Exception ex)
       //    {
       //        throw new AppException(
       //            "An error occurred while executing the Bussiness.ClsCustomer.InsertCustomer", ex);
       //    }
       //}

       //public DataSet SelectCustomerAll()
       //{
       //    var conn = new SqlConnection(DataObject.ConnectionString);
       //    conn.Open();
       //    var trn = conn.BeginTransaction();
       //    try
       //    {
       //        string strPersonID;
       //        //Data.Person.InsertPerson(info.PersonInfo, trn, out strPersonID);
       //        //info.PersonID = strPersonID;
       //        var intReturnData = Data.Customer.SelectCustomerAll( trn);

       //        trn.Commit();
       //        conn.Close();
       //        return null;
       //    }
       //    catch (AppException)
       //    {
       //        return null;
       //    }
       //    catch (Exception ex)
       //    {
       //        throw new AppException(
       //            "An error occurred while executing the Bussiness.ClsCustomer.InsertCustomer", ex);
       //    }
       //}

       //public DataSet SearchCustomer(ref Entity.Customer info)
       //{
       //    var conn = new SqlConnection(DataObject.ConnectionString);
       //    conn.Open();
       //    var trn = conn.BeginTransaction();
       //    try
       //    {
       //        string strPersonID;
       //        //Data.Person.InsertPerson(info.PersonInfo, trn, out strPersonID);
       //        //info.PersonID = strPersonID;
       //        var intReturnData = Data.Customer.SearchCustomer(ref info,trn);

       //        trn.Commit();
       //        conn.Close();
       //        return intReturnData;
       //    }
       //    catch (AppException)
       //    {
       //        return null;
       //    }
       //    catch (Exception ex)
       //    {
       //        throw new AppException(
       //            "An error occurred while executing the Bussiness.ClsCustomer.InsertCustomer", ex);
       //    }
       //}

    }
}
