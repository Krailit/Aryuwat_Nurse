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
    public class Report
    {
        public DataSet SelectReportPaging(Entity.Report info)
        {
            try
            {
                return Data.Report.SelectReportPaging(info);
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
        public DataSet SelectReportWE(Entity.Report info)
        {
            try
            {
                return Data.Report.SelectReportWE(info);
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
        public DataSet SelectReportList(Entity.Report info)
        {
            try
            {
                return Data.Report.SelectReportList(info);
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
