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
    public class SumOfTreatment
    {

        public DataSet GetRefund(string typ, string SO)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                DataSet ds = Data.SumOfTreatment.GetRefund(trn, typ, SO);

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
                    "An error occurred while executing the Bussiness.SelectSumOfTreatment", ex);
            }
        }
        public DataSet SelectSumOfTreatment(string typ, string SO, string VN)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                DataSet ds = Data.SumOfTreatment.SelectSumOfTreatment(trn, typ, SO,VN);

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
                    "An error occurred while executing the Bussiness.SelectSumOfTreatment", ex);
            }
        }
        public DataSet SelectSumOfTreatment(string typ, string SO, string VN, DateTime ReceiptDate)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                DataSet ds = Data.SumOfTreatment.SelectSumOfTreatment(trn, typ, SO, VN, ReceiptDate);

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
                    "An error occurred while executing the Bussiness.SelectSumOfTreatment", ex);
            }
        }
        public DataSet SelectReportSumOfTreatment(string typ, DateTime StartDate, DateTime EndDate)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                DataSet ds = Data.SumOfTreatment.SelectReportSumOfTreatment(trn, typ, StartDate, EndDate);

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
                    "An error occurred while executing the Bussiness.SelectSumOfTreatment", ex);
            }
        }
        public int? UpdateMedicalStatus(Entity.SumOfTreatment info)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                var intReturnData = Data.SumOfTreatment.UpdateMedicalStatus(info, trn);

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
                    "An error occurred while executing the Bussiness.SumOfTreatment.UpdateMedicalStatus", ex);
            }
        }
        public int? SOClose(Entity.SumOfTreatment info)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                var intReturnData = Data.SumOfTreatment.SOClose(info, trn);

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
                    "An error occurred while executing the Bussiness.SumOfTreatment.UpdateMedicalStatus", ex);
            }
        }
       
        public DataSet SelectCreditCard()
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            //var trn = conn.BeginTransaction();
            try
            {
                DataSet ds = Data.SumOfTreatment.SelectCreditCard();

                //trn.Commit();
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
                    "An error occurred while executing the Bussiness.SelectCreditCard", ex);
            }
        }
        public int? SaveRCNoSUBList(Entity.SumOfTreatment info)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                var intRetunCard = Data.CreditCardSOT.InsertCreditCardSOT(info.CreditCardSotInfo, trn);
                if (intRetunCard == -1)
                {
                    trn.Rollback();
                    conn.Close();
                    return intRetunCard;
                }
                trn.Commit();
                conn.Close();
                return intRetunCard;
            }
            catch (AppException)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw new AppException(
                    "An error occurred while executing the Bussiness.SumOfTreatment.UpdateSumOfTreatment", ex);
            }
        }
        public int? UpdateSumOfTreatment(Entity.SumOfTreatment info)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                var intReturnData = Data.SumOfTreatment.UpdateSumOfTreatment(info, trn);
                //var intRetunCard = Data.CreditCardSOT.InsertCreditCardSOT(info.CreditCardSotInfo, trn);
                if (intReturnData == -1 )
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
                    "An error occurred while executing the Bussiness.SumOfTreatment.UpdateSumOfTreatment", ex);
            }
        }
        public DataSet SAVERCNo(string RCNo, string SO, DateTime ReceiptDate, string EN_Save, decimal ReceiptBath)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {

                DataSet dsRetun = Data.SumOfTreatment.SAVERCNo(RCNo, SO, ReceiptDate, EN_Save, ReceiptBath, trn);
               
                trn.Commit();
                conn.Close();
                return dsRetun;
            }
            catch (AppException)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw new AppException(
                    "An error occurred while executing the Bussiness.SumOfTreatment.UpdateSumOfTreatment", ex);
            }
        }
        public int? DeleteRCNo(string RCNo)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                var intReturnData = Data.SumOfTreatment.DeleteRCNo(RCNo, trn);

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
                    "An error occurred while executing the Bussiness.SumOfTreatment.DeleteCashCredit", ex);
            }
        }
        public int? DeleteCashCredit(string ID)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                var intReturnData = Data.SumOfTreatment.DeleteCashCredit(ID, trn);

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
                    "An error occurred while executing the Bussiness.SumOfTreatment.DeleteCashCredit", ex);
            }
        }
        public int? InsertPayByItem(List<Entity.CreditCardSOT> info)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                int intRetunCardx = Data.SumOfTreatment.DeletePayByItem(info[0].SO, info[0].MS_Code, info[0].ListOrder, trn);
                var intRetunCard=0;
                //if (info[0].CashMoney != 0)
                //{
                     intRetunCard = Data.SumOfTreatment.InsertPayByItem(info, trn);
               // }
                //if (intReturnData == -1 || intRetunCard == -1)
                //{
                //    trn.Rollback();
                //    conn.Close();
                //    return intReturnData;
                //}
                trn.Commit();
                conn.Close();
                return intRetunCard;
            }
            catch (AppException)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw new AppException(
                    "An error occurred while executing the Bussiness.SumOfTreatment.UpdateSumOfTreatment", ex);
            }
        }
        public DataSet SelectPayByItem(string so, string ms_code, string ListOrder)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            //var trn = conn.BeginTransaction();
            try
            {
                DataSet ds = Data.SumOfTreatment.SelectPayByItem(so, ms_code, ListOrder);

                //trn.Commit();
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
                    "An error occurred while executing the Bussiness.SelectCreditCard", ex);
            }
        }
    }
}
