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
    public class MedicalSuppliesSilicone
    {
        public DataSet SelectMedicalSuppliesSiliconeById(string msCode)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                DataSet ds = Data.MedicalSuppliesSilicone.SelectMedicalSuppliesSiliconeById(trn, msCode);

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
                throw new Exception("An error occurred while executing the Bussiness.SelectMedicalSuppliesSiliconeById", ex);
            }
        }
    }
}
