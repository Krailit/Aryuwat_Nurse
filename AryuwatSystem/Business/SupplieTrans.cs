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
    public class SupplieTrans
    {
        public DataSet GetListOrder(string SONo, string MS_Code, string ListOrder)
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               DataSet ds = Data.SupplieTrans.GetListOrder(trn, SONo, MS_Code, ListOrder);

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
                   "An error occurred while executing the Bussiness.SelectMedicalSuppliesBySection", ex);
           }
       }
        
    }
}
