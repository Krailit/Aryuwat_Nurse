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
    public class ReportAccount
    {
        public DataSet SelectReportAccount(Entity.Report info)
        {
            try
            {
                return Data.ReportAccount.SelectReportAccount(info);
            }
            catch (AppException)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw new AppException("An error occurred while executing the Bussiness.SelectMedicalOrderPaging", ex);
            }
        }
    }
}
