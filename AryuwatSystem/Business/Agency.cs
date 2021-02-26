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
   public class Agency
    {
       public DataSet SelectAgency()
       {
           try
           {

               return Data.Agency.SelectAgency();
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

       public DataSet SelectAgencyMember(string type, Entity.Agency info)
       {
           
           try
           {
               DataSet ds=new DataSet();
               ds = type.ToUpper() == "SEARCHMEMBER" ? Data.Agency.SelectAgencyMemberPaging(info) : Data.Agency.SelectAgencyMember();
               return ds;
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

       public int? DeleteAgencyById(string ID)
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               var intReturnData = Data.Agency.DeleteAgencyById(ID, trn);
              
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
       public int? DeleteAgencyMemById(string ID)
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               var intReturnData = Data.Agency.DeleteAgencyMemById(ID, trn);

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

       public int? SaveAgency(Entity.Agency info)
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               var intReturnData=0;
               if(info.SaveTyp=="MEMBER")
                   intReturnData = Data.Agency.SaveAgencyMember(info, trn);
               else intReturnData = Data.Agency.SaveAgency(info, trn);

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
    }
}
