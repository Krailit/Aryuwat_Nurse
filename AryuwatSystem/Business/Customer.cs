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
    public class Customer
    {

        public int? INSERTCustomerConnect(Entity.Customer info)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();


            string vnTmp;
            try
            {

                var intSup = Data.Customer.INSERTCustomerConnect(info, trn);

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
        public int? InsertMembersID(Entity.Customer info)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                var intmember = Data.Customer.InsertMembersID(ref info, trn);
                if (intmember == -1)
                {
                    trn.Rollback();
                    conn.Close();
                    return intmember;
                }
                trn.Commit();
                conn.Close();
                return intmember;
            }
            catch (Exception ex)
            {
                trn.Rollback();
                conn.Close();
                throw new AppException(
                    "An error occurred while executing the Bussiness.ClsCustomer.InsertCustomer", ex);
            }
        }

        public int? InsertCustomer(Entity.Customer info)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                var intReturnData = Data.Customer.InsertCustomer(ref info, trn);
                info.ContactCustomerInfo.CN = info.CN;
                info.AestheticCenterInfo.CN = info.CN;
                info.BodyCenterInfo.CN = info.CN;
                info.CosmeticSurgeryCenterInfo.CN = info.CN;
                info.HairCenterInfo.CN = info.CN;
                info.HowYouhearInfo.CN = info.CN;
                var intCont = Data.ContactCustomer.InsertContactCustomer(info.ContactCustomerInfo, trn);
                var intA = Data.AestheticCenter.InsertAestheticCenter(info.AestheticCenterInfo, trn);
                var intB = Data.BodyCenter.InsertBodyCenter(info.BodyCenterInfo, trn);
                var intC = Data.CosmeticSurgeryCenter.InsertCosmeticSurgery(info.CosmeticSurgeryCenterInfo, trn);
                var intH = Data.HairCenter.InsertHairCenter(info.HairCenterInfo, trn);
                var intHow = Data.HowYouhear.InsertHowYouhear(info.HowYouhearInfo, trn);
                var intmember = Data.MembersGroup.InsertMembersGroup(info.MembersGroupInfo, trn);
                if (intReturnData == -1 || intA == -1 || intB == -1 || intC == -1 || intH == -1 || intHow == -1 || intCont == -1)
                {
                    trn.Rollback();
                    conn.Close();
                 
                    return -1;
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
                    "An error occurred while executing the Bussiness.ClsCustomer.InsertCustomer", ex);
            }
        }
        public int? InsertMembersGroup(Entity.Customer info)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                var intmember = Data.MembersGroup.InsertMembersGroup(info.MembersGroupInfo, trn);
                if (intmember == -1)
                {
                    trn.Rollback();
                    conn.Close();
                    return intmember;
                }
                trn.Commit();
                conn.Close();
                return intmember;
            }
            catch (Exception ex)
            {
                trn.Rollback();
                conn.Close();
                throw new AppException(
                    "An error occurred while executing the Bussiness.ClsCustomer.InsertCustomer", ex);
            }
        }

        public int? DeleteContactById(Entity.Customer info)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                var intReturnData = Data.Customer.DeleteContactById(info, trn);
         
                if (intReturnData == -1)//|| intA == -1 || intB == -1 || intC == -1 || intH == -1 || intHow == -1
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
                //AryuwatSystem.Class.LogWriter(ex.StackTrace);
                throw new AppException(
                    "An error occurred while executing the Bussiness.ClsCustomer.InsertCustomer", ex);
            }
        }
        public int? DeleteCustomerById(Entity.Customer info)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                var intReturnData = Data.Customer.DeleteCustomerById(info, trn);
                //var intA = Data.AestheticCenter.DeleteAestheticCenterById(CN, trn);
                //var intB = Data.BodyCenter.DeleteBodyCenterById(CN, trn);
                //var intC = Data.CosmeticSurgeryCenter.DeleteCosmeticSurgeryById(CN, trn);
                //var intH = Data.HairCenter.DeleteHairCenterById(CN, trn);
                //var intHow = Data.HowYouhear.DeleteHowYouhearById(CN, trn);
                if (intReturnData == -1 )//|| intA == -1 || intB == -1 || intC == -1 || intH == -1 || intHow == -1
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
                //AryuwatSystem.Class.LogWriter(ex.StackTrace);
                throw new AppException(
                    "An error occurred while executing the Bussiness.ClsCustomer.InsertCustomer", ex);
            }
        }


        public string GetCnNumber(string docPrefix,string BranchID)
        {
            try
            {
                return Data.Customer.GetCnNumber(docPrefix, BranchID);
            }
            catch (AppException)
            {
                return null;
            }
            catch (System.Exception ex)
            {
                throw new AppException("An error occurred while executing the Bussiness.GetCnNumber", ex);

            }
            finally
            {
                //Some action
            }

        }

        /// <summary>
        /// CN = CN
        /// </summary>
        /// <param name="cn"></param>
        /// <returns>True คือ Duplicate Key</returns>
        public bool CheckDupCustomer(string cn)
        {
            try
            {
                DataSet ds = Data.Customer.CheckDupCustomer(cn);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else return false;
            }
            catch (AppException)
            {
                return false;
            }
            catch (System.Exception ex)
            {
                throw new AppException("An error occurred while executing the Bussiness.CheckDupCustomer", ex);

            }
            finally
            {
                //Some action
            }

        }

        public int? UpdateCustomer(Entity.Customer info)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                var intReturnData = Data.Customer.UpdateCustomer(info, trn);
                info.AestheticCenterInfo.CN = info.CN;
                info.BodyCenterInfo.CN = info.CN;
                info.CosmeticSurgeryCenterInfo.CN = info.CN;
                info.HairCenterInfo.CN = info.CN;
                info.HowYouhearInfo.CN = info.CN;
                var intCont = Data.ContactCustomer.UpdateContactCustomer(info.ContactCustomerInfo, trn);
                var intA = Data.AestheticCenter.UpdateAestheticCenter(info.AestheticCenterInfo, trn);
                var intB = Data.BodyCenter.UpdateBodyCenter(info.BodyCenterInfo, trn);
                var intC = Data.CosmeticSurgeryCenter.UpdateCosmeticSurgery(info.CosmeticSurgeryCenterInfo, trn);
                var intH = Data.HairCenter.UpdateHairCenter(info.HairCenterInfo, trn);
                var intHow = Data.HowYouhear.UpdateHowYouhear(info.HowYouhearInfo, trn);
                var intmember = Data.MembersGroup.InsertMembersGroup(info.MembersGroupInfo, trn);
                if (intReturnData == -1 || intA == -1 || intB == -1 || intC == -1 || intH == -1 || intHow == -1)
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
                    "An error occurred while executing the Bussiness.ClsCustomer.InsertCustomer", ex);
            }
        }

        public DataSet SelectCustomerPaging(Entity.Customer info)
        {
            try
            {
                return Data.Customer.SelectCustomerPaging(info);
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
        public DataSet SelectCustomerConnect(Entity.Customer info)
        {
            try
            {
                return Data.Customer.SelectCustomerConnect(info);
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
        
        public DataSet SelectCustomerPOP(Entity.Customer info)
        {
            try
            {
                return Data.Customer.SelectCustomerPOP(info);
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

        public DataSet SelectCustomerWhereCause(Entity.Customer info)
        {
            try
            {
                return Data.Customer.SelectCustomerWhereCause(info);
            }
            catch (AppException)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw new AppException("An error occurred while executing the Bussiness.SelectCustomerWhereCause", ex);
            }
        }

        public DataSet SelectCustomerById(string CN)
        {
            try
            {
                return Data.Customer.SelectCustomerById(CN);
            }
            catch (AppException)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw new AppException("An error occurred while executing the Bussiness.Customer.SelectCustomerById", ex);
            }
        }
        public DataSet SelectCustomerOpdScan(string CN)
        {
            try
            {
                return Data.Customer.SelectCustomerOpdScan(CN);
            }
            catch (AppException)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw new AppException("An error occurred while executing the Bussiness.Customer.SelectCustomerOpdScan", ex);
            }
        }
        public DataSet SelectCustomerMemberById(string CN)
        {
            try
            {
                return Data.Customer.SelectCustomerMemberById(CN);
            }
            catch (AppException)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw new AppException("An error occurred while executing the Bussiness.Customer.SelectCustomerById", ex);
            }
        }
        public DataSet SelectRptCustomerById(string CN)
        {
            try
            {
                return Data.Customer.SelectRptCustomerById(CN);
            }
            catch (AppException)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw new AppException("An error occurred while executing the Bussiness.Customer.SelectRptCustomerById", ex);
            }
        }

        public DataSet SelectCustomerByCN(string cn, string IdCard, string cname)
        {
            try
            {
                return Data.Customer.SelectCustomerByCN(cn, IdCard, cname);
            }
            catch (AppException)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw new AppException("An error occurred while executing the Bussiness.Customer.SelectCustomerByCN", ex);
            }
        }
        public DataSet SelectDistinctCN()
        {
            try
            {
                return Data.Customer.SelectDistinctCN();
            }
            catch (AppException)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw new AppException("An error occurred while executing the Bussiness.Customer.SelectCustomerByCN", ex);
            }
        }
    }
}
