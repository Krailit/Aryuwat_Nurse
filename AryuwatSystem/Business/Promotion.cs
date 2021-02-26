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
    public class Promotion
    {
        public int? InsertPromotion(Entity.Promotion info)
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
                var intReturnData = Data.Promotion.InsertPromotion(ref info, trn);
                var intSup = Data.Promotion.InsertPromotionSupplie(trn, info);
              

                if (intReturnData == -1 || intSup == -1 )
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
        public DataSet SelectPromotionPaging(Entity.Promotion info)
        {
            try
            {
                return Data.Promotion.SelectPromotionPaging(info);
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
        public int? DeletePromotion(Entity.Promotion info)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                var intReturnData = Data.Promotion.DeletePromotion(trn,info);

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
    }
}
