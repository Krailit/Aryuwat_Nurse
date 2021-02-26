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
    public class MedicalStuff
    {
        public DataSet SelectMedicalStuffById(Entity.MedicalStuff info)
        {
            try
            {
                return Data.MedicalStuff.SelectMedicalStuffById(info);
            }
            catch (AppException)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw new AppException("An error occurred while executing the Bussiness.SelectMedicalStuffById", ex);
            }
        }
    }
}
