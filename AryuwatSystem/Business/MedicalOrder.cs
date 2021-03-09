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
    public class MedicalOrder
    {
        public int? InsertMedicalOrderMove(Entity.MedicalOrderUseTrans info)
        {
            int? nullable2;
            SqlConnection connection = new SqlConnection(DataObject.ConnectionString);
            connection.Open();
            SqlTransaction trn = connection.BeginTransaction();
            int? nullable = 0;
            try
            {
                nullable = Data.MedicalOrder.InsertMembersMoveTrans(info, trn);
                if (nullable == -1)
                {
                    trn.Rollback();
                    connection.Close();
                    return nullable;
                }
                trn.Commit();
                connection.Close();
                nullable2 = nullable;
            }
            catch (Exception exception)
            {
                trn.Rollback();
                connection.Close();
                throw new AppException("An error occurred while executing the Bussiness.ClsMedicalOrder.InsertMedicalOrderMove", exception);
            }
            return nullable2;
        }
        public int? DeleteMedicalOrderMove(Entity.MedicalOrderUseTrans info)
        {
            int? nullable2;
            SqlConnection connection = new SqlConnection(DataObject.ConnectionString);
            connection.Open();
            SqlTransaction trn = connection.BeginTransaction();
            int? nullable = 0;
            try
            {
                nullable = Data.MedicalOrder.DeleteMedicalMoveTrans(info, trn);
                if (nullable == -1)
                {
                    trn.Rollback();
                    connection.Close();
                    return nullable;
                }
                trn.Commit();
                connection.Close();
                nullable2 = nullable;
            }
            catch (Exception exception)
            {
                trn.Rollback();
                connection.Close();
                throw new AppException("An error occurred while executing the Bussiness.ClsMedicalOrder.InsertMedicalOrderMove", exception);
            }
            return nullable2;
        }

        public int? InsertMedicalOrderRefVN(Entity.MedicalOrder info)
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
                vnTmp = info.VN;
                var intReturnData = Data.MedicalOrder.InsertMedicalOrderRefVN(ref info, trn);
                var intSup = Data.SupplieTrans.InsertSupplieTransRefVN(info.SupplieTransInfo, trn, info);

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

      
        public int? InsertMedicalOrder(Entity.MedicalOrder info)
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
                vnTmp = info.VN;
                var intReturnData = Data.MedicalOrder.InsertMedicalOrder(ref info, trn);
                var intSup = Data.SupplieTrans.InsertSupplieTrans(info.SupplieTransInfo, trn, info);
                var intFree = Data.SupplieTrans.InsertFreeTrans(info, trn);
                var intSupPro = Data.SupplieTrans.InsertSupplieTransPro(info.SupplieTransProInfo, trn, info);
                //var intHow=Data.HowYouhear.InsertHowYouhear(info.HowYouhearInfo, trn);
              

                //if (string.IsNullOrEmpty(vnTmp))
                //{
                 
                        //intSur = Data.SurgeryFee.InsertSurgeryFee(info, trn, info.VN);
                        intSumOfT = Data.SumOfTreatment.InsertSumOfTreatment(info, trn, info.VN);
                //}
                if (info.MedicalOrderDocInfo.Length > 0)
                {
                    intMedDoc = Data.MedicalOrderDoc.InsertMedicalOrderDoc(info.MedicalOrderDocInfo,
                       trn, info.VN, info.SONo);
                }
                int intMedMembersTran = 0;
                    intMedMembersTran = Data.MembersTrans.InsertMembersTrans(info.dicMembersTran,trn);

                    if (intReturnData == -1 || intSup == -1 || intStuff == -1 || intSur == -1 || intSumOfT == -1 || intMedUse == -1 || intMedDoc == -1 )
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
        public int? InsertSupplieTransRenewal(List<Entity.SupplieTrans> info, int RenewAddMonth)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
    

            string vnTmp;
            try
            {

                var intSup = Data.SupplieTrans.InsertSupplieTransRenewal(info, RenewAddMonth, trn);
                
                trn.Commit();
                conn.Close();
                return intSup;
            }
            catch (Exception ex)
            {
                trn.Rollback();
                conn.Close();
                throw new AppException(
                    "An error occurred while executing the Bussiness.ClsMedicalOrder.InsertMedicalOrder", ex);
            }
        }
        public int? InsertFileScan(List<Entity.MedicalOrderDoc> info)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
           
            int? intMedDoc = 0;
          
            string vnTmp;
            try
            {
               
                if (info.Any())
                {
                    intMedDoc = Data.MedicalOrderDoc.InsertFileScan(info,trn);
                }
               

                if ( intMedDoc == -1)
                {
                    trn.Rollback();
                    conn.Close();
                    return intMedDoc;
                }
                trn.Commit();
                conn.Close();
                return intMedDoc;
            }
            catch (Exception ex)
            {
                trn.Rollback();
                conn.Close();
                throw new AppException(
                    "An error occurred while executing the Bussiness.ClsMedicalOrder.InsertMedicalOrder", ex);
            }
        }
        public int? InsertMedicalOrderFollow(List<Entity.MedicalOrder> info)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();

            string vnTmp;
            try
            {

                var intReturnData = Data.MedicalOrder.InsertMedicalOrderFollow(ref info, trn);
           
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
            catch (Exception ex)
            {
                trn.Rollback();
                conn.Close();
                throw new AppException(
                    "An error occurred while executing the Bussiness.ClsMedicalOrder.InsertMedicalOrder", ex);
            }
        }
        //public int? UpdateMedicalOrder(Entity.MedicalOrder info)
        //{
        //    var conn = new SqlConnection(DataObject.ConnectionString);
        //    conn.Open();
        //    var trn = conn.BeginTransaction();
        //    try
        //    {
        //        var intReturnData = Data.MedicalOrder.UpdateMedicalOrder(ref info, trn);
        //        //var intDelSup = Data.SupplieTrans.DeleteSupplieTrans(trn, info.VN);
        //        var intSup = Data.SupplieTrans.InsertSupplieTrans(info.SupplieTransInfo, trn, info.VN);
        //        //var intDelStuff = Data.MedicalStuff.DeleteMedicalStuff(trn, info.VN);
        //        var intStuff = Data.MedicalStuff.InsertMedicalStuff(info.MedicalStuffInfo, trn, info.VN);
        //        int? intMedUse=0;
        //        int? intMedDoc = 0;
        //        if (info.MedicalOrderDocInfo.Length > 0)
        //        {
        //             intMedUse = Data.MedicalOrderDoc.InsertMedicalOrderDoc(info.MedicalOrderDocInfo,trn, info.VN);
        //        }
        //        if (info.MedicalOrderDocInfo.Length > 0)
        //        {
        //            intMedDoc = Data.MedicalOrderDoc.InsertMedicalOrderDoc(info.MedicalOrderDocInfo,
        //               trn, info.VN);
        //        }
        //        if (intReturnData == -1 || intSup == -1 || intStuff == -1 || intMedUse == -1 || intMedDoc==-1)
        //        {
        //            trn.Rollback();
        //            conn.Close();
        //            return -1;
        //        }
        //        trn.Commit();
        //        conn.Close();
        //        return 1;
        //    }
        //    catch (Exception ex)
        //    {
        //        trn.Rollback();
        //        conn.Close();
        //        throw new AppException(
        //            "An error occurred while executing the Bussiness.ClsMedicalOrder.UpdateMedicalOrder", ex);
        //    }
        //}


        public int? DeleteMedicalOrderById(string VN, string SO)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                var intDelStuff = Data.MedicalStuff.DeleteMedicalStuff(trn, VN,SO);
                var intDelSup = Data.SupplieTrans.DeleteSupplieTrans(trn, VN, SO);
                var intDelMed = Data.MedicalOrder.DeleteMedicalOrderById(trn, VN, SO);
                var intDelUseTran = Data.MedicalOrderUseTrans.DeleteMedicalUseTrans(trn, VN, SO);
                if (intDelStuff == -1 || intDelSup == -1 || intDelMed == -1 || intDelUseTran == -1)
                {
                    trn.Rollback();
                    conn.Close();
                    return -1;
                }
                trn.Commit();
                conn.Close();
                return 1;
            }
            catch (Exception ex)
            {
                trn.Rollback();
                conn.Close();
                throw new AppException(
                    "An error occurred while executing the Bussiness.MedicalOrder.DeleteMedicalOrderById", ex);
            }
        }

        public DataSet SelectMedicalOrderPaging(Entity.MedicalOrder info)
        {
            try
            {
                return Data.MedicalOrder.SelectMedicalOrderPaging(info);
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
        public DataSet SelectMedicalOrderSOTPaging(Entity.MedicalOrder info)
        {
            try
            {
                return Data.MedicalOrder.SelectMedicalOrderSOTPaging(info);
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
        public DataSet SelectMedicalStatus()
        {
            try
            {
                return Data.MedicalOrder.SelectMedicalStatus();
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

        public DataSet SelectMedicalOrderById(string vn)
        {
            try
            {
                return Data.MedicalOrder.SelectMedicalOrderById(vn);
            }
            catch (AppException)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw new AppException("An error occurred while executing the Bussiness.SelectMedicalOrderById", ex);
            }
        }
          public DataSet SelectMedicalOrderById(string vn, string so)
        {
            try
            {
                return Data.MedicalOrder.SelectMedicalOrderById(vn, so);
            }
            catch (AppException)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw new AppException("An error occurred while executing the Bussiness.SelectMedicalOrderById", ex);
            }
        }
          public DataSet SelectMedicalOrderByIdSubitem(string vn, string so)
        {
            try
            {
                return Data.MedicalOrder.SelectMedicalOrderByIdSubitem(vn, so);
            }
            catch (AppException)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw new AppException("An error occurred while executing the Bussiness.SelectMedicalOrderById", ex);
            }
        }
        
          public DataSet SelectMedicalOrderRefVNById(string RefVN)
        {
            try
            {
                return Data.MedicalOrder.SelectMedicalOrderRefVNById(RefVN);
            }
            catch (AppException)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw new AppException("An error occurred while executing the Bussiness.SelectMedicalOrderById", ex);
            }
        }
        
        public DataSet CheckMoCreated(string so)
        {
            try
            {
                
                return Data.MedicalOrder.CheckMoCreated(so);
            }
            catch (AppException)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw new AppException("An error occurred while executing the Bussiness.SelectMedicalOrderById", ex);
            }
        }
        public DataSet SelectFileScan(string UseTransId)
        {
            try
            {
                return Data.MedicalOrder.SelectFileScan(UseTransId);
            }
            catch (AppException)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw new AppException("An error occurred while executing the Bussiness.SelectMedicalOrderById", ex);
            }
        }
        public DataSet SelectFileScan(string so,string mo,string cn,string QueryType)
        {
            try
            {
                return Data.MedicalOrder.SelectFileScan(so, mo, cn, QueryType);
            }
            catch (AppException)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw new AppException("An error occurred while executing the Bussiness.SelectMedicalOrderById", ex);
            }
        }

        internal object DeleteFileName(string Id, string QueryType)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                int? intDelDoc = Data.MedicalOrderDoc.DeleteFileName(trn, Id, QueryType);
                if (intDelDoc == -1)
                {
                    trn.Rollback();
                    conn.Close();
                    return -1;
                }
                trn.Commit();
                conn.Close();
                return 1;
            }
            catch (Exception ex)
            {
                trn.Rollback();
                conn.Close();
                throw new AppException(
                    "An error occurred while executing the Bussiness.MedicalOrder.DeleteFileName", ex);
            }
        }
        internal object DeleteFileScan(string Id, string QuryType)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                int? intDelDoc = Data.MedicalOrderDoc.DeleteFileScan(trn, Id, QuryType);
                if (intDelDoc == -1)
                {
                    trn.Rollback();
                    conn.Close();
                    return -1;
                }
                trn.Commit();
                conn.Close();
                return 1;
            }
            catch (Exception ex)
            {
                trn.Rollback();
                conn.Close();
                throw new AppException(
                    "An error occurred while executing the Bussiness.MedicalOrder.DeleteFileName", ex);
            }
        }

        public int? InsertSubItemOther(List<Entity.SupplieTrans> info, List<Entity.SupplieTrans> listSupOtherDel)
        {
            int? nullable2;
            SqlConnection connection = new SqlConnection(DataObject.ConnectionString);
            connection.Open();
            SqlTransaction trn = connection.BeginTransaction();
            int? nullable = 0;
            try
            {
                nullable = Data.MedicalOrder.InsertSubItemOther(info, listSupOtherDel, trn);
                if (nullable == -1)
                {
                    trn.Rollback();
                    connection.Close();
                    return nullable;
                }
                trn.Commit();
                connection.Close();
                nullable2 = nullable;
            }
            catch (Exception exception)
            {
                trn.Rollback();
                connection.Close();
                throw new AppException("An error occurred while executing the Bussiness.ClsMedicalOrder.InsertMedicalOrderMove", exception);
            }
            return nullable2;
        }
        public DataSet SelectSubItemOther(Entity.SupplieTrans info)
        {
            try
            {
                return Data.MedicalOrder.SelectSubItemOther(info);
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
