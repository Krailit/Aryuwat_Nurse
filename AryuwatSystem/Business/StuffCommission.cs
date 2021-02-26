using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using AryuwatSystem.Baselibary;
using Entity;
using Entity.Validation;

namespace AryuwatSystem.Business
{
    public class StuffCommission
    {
        public DataSet SelectStuffCommission(string typ)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                DataSet ds = Data.SurgeryFee.SelectStuffCommission(trn, typ);

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
                    "An error occurred while executing the Bussiness.SelectSubDistrictAll", ex);
            }
        }
        public DataSet SelectSurgeryFee(SurgeryFee info)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                DataSet ds = Data.SurgeryFee.SelectSurgeryFee(trn, info);

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
                    "An error occurred while executing the Bussiness.SelectSubDistrictAll", ex);
            }
        }
        public int? SaveSurgeryFee(Entity.SurgeryFee info)
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               var intReturnData = Data.SurgeryFee.SaveSurgeryFee( info, trn);

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
        public int? UpdateMedicalStuff(Entity.SurgeryFee info)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                var intReturnData = Data.SurgeryFee.UpdateMedicalStuff(info, trn);

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
        public DataSet SelectStuffCommissionByType(string positionType)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                DataSet ds = Data.SurgeryFee.SelectStuffCommissionByType(trn, positionType);

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
                    "An error occurred while executing the Bussiness.SelectStuffCommissionByType", ex);
            }
        }

        public DataSet SelectCommissionRate()
        {
            try
            {
                var conn = new SqlConnection(DataObject.ConnectionString);
                conn.Open();
                var trn = conn.BeginTransaction();
                DataSet ds = Data.SurgeryFee.SelectCommissionRate(trn);

                conn.Close();
                return ds;
            }
            catch (AppException)
            {
                return null;
            }
           
        }
        public DataSet SurgicalFeeType_Position()
        {
            try
            {
                var conn = new SqlConnection(DataObject.ConnectionString);
                conn.Open();
                var trn = conn.BeginTransaction();
                DataSet ds = Data.SurgeryFee.SurgicalFeeType_Position(trn);

                conn.Close();
                return ds;
            }
            catch (AppException)
            {
                return null;
            }
           
        }
        
    }
}
