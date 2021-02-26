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
    public class MedicalOrderUseTrans
    {
        public DataSet SelectMedicalOrderUseTransById(Entity.MedicalOrderUseTrans info)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                DataSet ds = Data.MedicalOrderUseTrans.SelectMedicalOrderUseTransById(trn, info);

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
                    "An error occurred while executing the Bussiness.SelectMedicalOrderUseTransById", ex);
            }
        }


        public DataSet SelectMedicalOrderUseTransByCN(Entity.MedicalOrderUseTrans info)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                DataSet ds = Data.MedicalOrderUseTrans.SelectMedicalOrderUseTransByCN(trn, info);

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
                    "An error occurred while executing the Bussiness.SelectMedicalOrderUseTransById", ex);
            }
        }
        public DataSet SelectMedicalOrderUseTransByCN_CheckCouse(Entity.MedicalOrderUseTrans info)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                DataSet ds = Data.MedicalOrderUseTrans.SelectMedicalOrderUseTransByCN_CheckCouse(trn, info);

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
                    "An error occurred while executing the Bussiness.SelectMedicalOrderUseTransById", ex);
            }
        }
        public DataSet SelectMedicalOrderUseTrans_CheckCouseSOPro(Entity.MedicalOrderUseTrans info)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                DataSet ds = Data.MedicalOrderUseTrans.SelectMedicalOrderUseTrans_CheckCouseSOPro(trn, info);

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
                    "An error occurred while executing the Bussiness.SelectMedicalOrderUseTransById", ex);
            }
        }
        
        public DataSet SelectSavedJobCostById(string typ, string VN, string MS_Code, string ListOrder, string Id)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                DataSet ds = Data.MedicalOrderUseTrans.SelectSavedJobCostById(trn, typ, VN, MS_Code, ListOrder, Id);

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
                    "An error occurred while executing the Bussiness.SelectMedicalOrderUseTransById", ex);
            }
        }
        public DataSet SELECTSAVEDJOBCOST_COM(string VN, string SO,string MS_Code,string ListOrder)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                DataSet ds = Data.MedicalOrderUseTrans.SELECTSAVEDJOBCOST_COM(trn, VN, SO,MS_Code,ListOrder);

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
                    "An error occurred while executing the Bussiness.SelectMedicalOrderUseTransById", ex);
            }
        }
        public DataSet CheckUsedCourse(string VN, string SO, string MS_Code, string ListOrder)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                DataSet ds = Data.MedicalOrderUseTrans.CheckUsedCourse(trn, VN, SO, MS_Code, ListOrder);

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
                    "An error occurred while executing the Bussiness.SelectMedicalOrderUseTransById", ex);
            }
        }
        public DataSet CheckUsedCoursePro(string VN, string SO, string MS_Code, string ListOrder)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                DataSet ds = Data.MedicalOrderUseTrans.CheckUsedCoursePro(trn, VN, SO, MS_Code, ListOrder);

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
                    "An error occurred while executing the Bussiness.SelectMedicalOrderUseTransById", ex);
            }
        }
        
        public DataSet CheckExpireSO(string VN, string SO, string MS_Code, string ListOrder)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                DataSet ds = Data.MedicalOrderUseTrans.CheckExpireSO(trn, VN, SO, MS_Code, ListOrder);

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
                    "An error occurred while executing the Bussiness.SelectMedicalOrderUseTransById", ex);
            }
        }
        public DataSet CheckCourseCardCreated(string Sono, string VN, string MS_Code, string ListOrder)
        {
            try
            {

                return Data.MedicalOrderUseTrans.CheckCourseCardCreated(Sono,VN,MS_Code,ListOrder);
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
        public int? DeleteCourseCard(Entity.MedicalOrderUseTrans info)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            int? intMedUse = 0;
            try
            {

                intMedUse = Data.MedicalOrderUseTrans.DeleteCourseCard(info, trn);
                if (intMedUse == -1)
                {
                    trn.Rollback();
                    conn.Close();
                    return intMedUse;
                }
                trn.Commit();
                conn.Close();
                return intMedUse;
            }
            catch (Exception ex)
            {
                trn.Rollback();
                conn.Close();
                throw new AppException("An error occurred while executing the Bussiness.ClsMedicalOrder.InsertMedicalUseTrans", ex);
            }
        }
        public int? UpdateSlipCourseCard(Entity.MedicalOrderUseTrans info)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            int? intMedUse = 0;
            try
            {

                intMedUse = Data.MedicalOrderUseTrans.UpdateSlipCourseCard(info, trn);
                if ( intMedUse == -1)
                {
                    trn.Rollback();
                    conn.Close();
                    return intMedUse;
                }
                trn.Commit();
                conn.Close();
                return intMedUse;
            }
            catch (Exception ex)
            {
                trn.Rollback();
                conn.Close();
                throw new AppException("An error occurred while executing the Bussiness.ClsMedicalOrder.InsertMedicalUseTrans", ex);
            }
        }
        public int? InsertMedicalCourseCard(Entity.MedicalOrderUseTrans info)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            int? intMedUse = 0;
            try
            {

                intMedUse = Data.MedicalOrderUseTrans.InsertMedicalCourseCard(info, trn);
                if (intMedUse == -1)
                {
                    trn.Rollback();
                    conn.Close();
                    return intMedUse;
                }
                trn.Commit();
                conn.Close();
                return intMedUse;
            }
            catch (Exception ex)
            {
                trn.Rollback();
                conn.Close();
                throw new AppException("An error occurred while executing the Bussiness.ClsMedicalOrder.InsertMedicalUseTrans", ex);
            }
        }
        public int? UpdateExpireCourseCard(Entity.MedicalOrderUseTrans info)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            int? intMedUse = 0;
            try
            {

                intMedUse = Data.MedicalOrderUseTrans.UpdateExpireCourseCard(info, trn);
                if (intMedUse == -1)
                {
                    trn.Rollback();
                    conn.Close();
                    return intMedUse;
                }
                trn.Commit();
                conn.Close();
                return intMedUse;
            }
            catch (Exception ex)
            {
                trn.Rollback();
                conn.Close();
                throw new AppException("An error occurred while executing the Bussiness.ClsMedicalOrder.InsertMedicalUseTrans", ex);
            }
        }

        
        public int? InsertMedicalUseTrans(Entity.MedicalOrderUseTrans[] info)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            int? intMedUse = 0;
            try
            {

                intMedUse = Data.MedicalOrderUseTrans.InsertMedicalOrderUseTrans(
                    info,
                     trn);
                if (info[0].MedicalStuffInfo.Any())
                {
                    //intMedUse = Data.MedicalOrder.UpdateMedicalOrderStatus(info[0].VN, info[0].MedicalStuffInfo[0].EmployeeId, info[0].MedicalOrderStatus,trn);
                }
                if (intMedUse == -1)
                {
                    trn.Rollback();
                    conn.Close();
                    return intMedUse;
                }
                trn.Commit();
                conn.Close();
                return intMedUse;
            }
            catch (Exception ex)
            {
                trn.Rollback();
                conn.Close();
                throw new AppException("An error occurred while executing the Bussiness.ClsMedicalOrder.InsertMedicalUseTrans", ex);
            }
        }

        public int? UpdateMedicalCheckCouse(Entity.MedicalOrderUseTrans[] info)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            int? intMedUse = 0;
            try
            {
                intMedUse = Data.MedicalOrderUseTrans.UpdateMedicalCheckCouse(info, trn);
               
                if (intMedUse == -1)
                {
                    trn.Rollback();
                    conn.Close();
                    return intMedUse;
                }
                trn.Commit();
                conn.Close();
                return intMedUse;
            }
            catch (Exception ex)
            {
                trn.Rollback();
                conn.Close();
                throw new AppException(
                    "An error occurred while executing the Bussiness.ClsMedicalOrder.UpdateMedicalUseTrans", ex);
            }
        }
        public int? UpdateMedicalUseTrans(Entity.MedicalOrderUseTrans[] info)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            int? intMedUse = 0;
            try
            {
                intMedUse = Data.MedicalOrderUseTrans.UpdateMedicalOrderUseTrans(
                    info,
                     trn);
                if (info[0].MedicalStuffInfo.Any())
                {
                    //int del = Data.MedicalStuff.DeleteMedicalStuff(trn, info[0].VN, info[0].MS_Code, c.Id, c.ListOrder);
                    //intMedUse = Data.MedicalOrder.UpdateMedicalOrderStatus(
                    //    info[0].VN, info[0].MedicalStuffInfo[0].EmployeeId, info[0].MedicalOrderStatus,
                    //     trn);
                }
                if (intMedUse == -1)
                {
                    trn.Rollback();
                    conn.Close();
                    return intMedUse;
                }
                trn.Commit();
                conn.Close();
                return intMedUse;
            }
            catch (Exception ex)
            {
                trn.Rollback();
                conn.Close();
                throw new AppException(
                    "An error occurred while executing the Bussiness.ClsMedicalOrder.UpdateMedicalUseTrans", ex);
            }
        }

        public int? DeleteMedicalOrderUseTransById(string useId, string VN, string CN, string MS_Code, string ListOrder, string updateBy, string BranchId)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            int? intMedUse = 0;
            try
            {
                intMedUse = Data.MedicalOrderUseTrans.DeleteMedicalOrderUseTransById(useId, VN, CN, MS_Code, ListOrder, updateBy, BranchId, trn);
                intMedUse = Data.MedicalStuff.DeleteMedicalStuff(trn, VN, MS_Code, useId, ListOrder, updateBy);
                intMedUse = Data.SurgeryFee.DeleteSurgeryFee(trn, VN, MS_Code, useId, updateBy);
                if (intMedUse == -1)
                {
                    trn.Rollback();
                    conn.Close();
                    return intMedUse;
                }
                trn.Commit();
                conn.Close();
                return intMedUse;
            }
            catch (Exception ex)
            {
                trn.Rollback();
                conn.Close();
                throw new AppException(
                    "An error occurred while executing the Bussiness.ClsMedicalOrder.DeleteMedicalOrderUseTransById", ex);
            }
        }

    }
}
