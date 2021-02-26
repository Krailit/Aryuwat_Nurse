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
    public class ReportMarketing
    {
        public DataSet SelectReportMarketing(Entity.Report info)
        {
            try
            {
                return Data.ReportMarketing.SelectReportMarketing(info);
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
