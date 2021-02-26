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
    public class GiftVoucher_Barter
    {
        public int? InsertGiftVoucher(Entity.GiftVoucher_Barter info)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            //int? intMedUse = 0;
            //int? intMedDoc = 0;
            //int? intSur = 0;
            //int? intSumOfT = 0;
            //int? intStuff = 0;
      
            string vnTmp;
            try
            {
                int? intReturnData = Data.GiftVoucher_Barter.InsertGiftVoucher(ref info, trn);
              

                if (intReturnData<0  )
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
                    "An error occurred while executing the Bussiness.ClsMedicalOrder.InsertMedicalOrder", ex);
            }
        }
        public DataSet SelectGiftVoucherByID(Entity.GiftVoucher_Barter info)
        {
            try
            {
                return Data.GiftVoucher_Barter.SelectGiftVoucher_Barter(info);
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
        public DataSet SelectGiftVoucher_Barter(Entity.GiftVoucher_Barter info)
        {
            try
            {
                return Data.GiftVoucher_Barter.SelectGiftVoucher_Barter(info);
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
        public int? DeleteGiftVoucher(Entity.GiftVoucher_Barter info)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                var intReturnData = Data.GiftVoucher_Barter.DeleteGiftVoucher(trn,info);

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
        public int ImportGiftVoucher(String sql)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                var intReturnData = Data.GiftVoucher_Barter.ImportGiftVoucher(trn, sql);

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

        public int? DeleteBarter(Entity.GiftVoucher_Barter info)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                var intReturnData = Data.GiftVoucher_Barter.DeleteGiftVoucher(trn, info);

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
        public int ImportBarter(String sql)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                var intReturnData = Data.GiftVoucher_Barter.ImportBarter(trn, sql);

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
        public int? InsertBarter(Entity.GiftVoucher_Barter info)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            int? intMedUse = 0;
            int? intMedDoc = 0;
            int? intSur = 0;
            int? intSumOfT = 0;
            int? intStuff = 0;

            string vnTmp;
            try
            {
                var intReturnData = Data.GiftVoucher_Barter.InsertBarter(ref info, trn);


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
                    "An error occurred while executing the Bussiness.ClsMedicalOrder.InsertMedicalOrder", ex);
            }
        }
    }
}
