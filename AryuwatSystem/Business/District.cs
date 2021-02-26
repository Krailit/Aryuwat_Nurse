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
   public class District
    {
       public DataSet SelectDistrictAll()
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               DataSet ds = Data.District.SelectDistrictAll(trn);

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
                   "An error occurred while executing the Bussiness.SelectDistrictAll", ex);
           }
       }

       public DataSet SelectDistrictById(int provinceId)
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               DataSet ds = Data.District.SelectDistrictById(trn,provinceId);

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
                   "An error occurred while executing the Bussiness.SelectDistrictById", ex);
           }
       }

    }
}
