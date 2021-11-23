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
    public class MedicalSupplies
    {
        public int? InsertMedicalSupplies(ref Entity.MedicalSupplies info)
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               var intReturnData = Data.MedicalSupplies.InsertMedicalSupplies(ref info, trn);
               
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
        public int? InsertMedicalPA(List<Entity.MedicalSupplies> info)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                var intReturnData = Data.MedicalSupplies.InsertMedicalPA(info, trn);

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

        public int? InsertMedicalStockSuppliesREQ(ref Entity.MedicalSupplies info)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                var intReturnData = Data.MedicalSupplies.InsertMedicalStockSuppliesREQ(ref info, trn);

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
        public int? DeleteStockSuppliesTranREQ(string REQNo)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                var intReturnData = Data.MedicalSupplies.DeleteStockSuppliesTranREQ(REQNo, trn);

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
        public int? DeleteStockSuppliesREQ(string REQNo)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                var intReturnData = Data.MedicalSupplies.DeleteStockSuppliesREQ(REQNo, trn);

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
        public int? DeleteStockSuppliesTranSPQ(string REQNo)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                var intReturnData = Data.MedicalSupplies.DeleteStockSuppliesTranSPQ(REQNo, trn);

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
        public int? DeleteStockSuppliesSPQ(string REQNo)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                var intReturnData = Data.MedicalSupplies.DeleteStockSuppliesSPQ(REQNo, trn);

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
        public int? InsertMedicalStockSupplies(ref Entity.MedicalSupplies info)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                var intReturnData = Data.MedicalSupplies.InsertMedicalStockSupplies(ref info, trn);

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
        public DataSet SelectMedicalSuppliesPaging(Entity.MedicalSupplies info)
       {
           try
           {
               return Data.MedicalSupplies.SelectMedicalSuppliesPaging(info);
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

        
        public DataSet SelectMedicalSuppliesBySection(Entity.MedicalSupplies info)
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               DataSet ds = Data.MedicalSupplies.SelectMedicalSuppliesBySection(trn, info);

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
                   "An error occurred while executing the Bussiness.SelectMedicalSuppliesBySection", ex);
           }
       }
        public DataSet GetPendingBySO(string sono)
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               DataSet ds = Data.MedicalSupplies.GetPendingBySO(trn, sono);

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
                   "An error occurred while executing the Bussiness.SelectMedicalSuppliesBySection", ex);
           }
       }
      
        
        public DataSet SelectStock(Entity.MedicalSupplies info)
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               DataSet ds = Data.MedicalSupplies.SelectStock(trn, info);

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
                   "An error occurred while executing the Bussiness.SelectMedicalSuppliesBySection", ex);
           }
       }
        public DataSet SelectDept(Entity.MedicalSupplies info)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                DataSet ds = Data.MedicalSupplies.SelectDept(trn, info);

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
                    "An error occurred while executing the Bussiness.SelectMedicalSuppliesBySection", ex);
            }
        }
       public DataSet GetPersonnelByUserName(Entity.Personnel info)
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               string strPersonID;
               //Data.Person.InsertPerson(info.PersonInfo, trn, out strPersonID);
               //info.PersonID = strPersonID;
               var intReturnData = Data.Personnel.GetPersonnelByUserName(info, trn);

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
               throw new AppException("An error occurred while executing the Bussiness.GetPersonnelByUserName", ex);
           }
       }

       public DataSet SearchPersonnel(ref Entity.Personnel info)
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               string strPersonID;
               //Data.Person.InsertPerson(info.PersonInfo, trn, out strPersonID);
               //info.PersonID = strPersonID;
               var intReturnData = Data.Personnel.SearchPersonnel(ref info, trn);

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
       public DataSet SearchPersonnelByID(ref Entity.Personnel info)
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               string strPersonID;
               //Data.Person.InsertPerson(info.PersonInfo, trn, out strPersonID);
               //info.PersonID = strPersonID;
               var intReturnData = Data.Personnel.SearchPersonnelByID(ref info, trn);

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
       public DataSet SelectPersonnelGroup()
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               string strPersonID;
               //Data.Person.InsertPerson(info.PersonInfo, trn, out strPersonID);
               //info.PersonID = strPersonID;
               var intReturnData = Data.Personnel.SelectPersonnelGroup(trn);

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
       public DataSet SelectMedicalSection()
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               string strPersonID;
               //Data.Person.InsertPerson(info.PersonInfo, trn, out strPersonID);
               //info.PersonID = strPersonID;
               var intReturnData = Data.MedicalSupplies.SelectMedicalSection(trn);

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
                   "An error occurred while executing the Bussiness.Personnel.SelectPersonnelType", ex);
           }
       }
       public DataSet SelectMedicalSectionStock()
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               string strPersonID;
               //Data.Person.InsertPerson(info.PersonInfo, trn, out strPersonID);
               //info.PersonID = strPersonID;
               var intReturnData = Data.MedicalSupplies.SelectMedicalSectionStock(trn);

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
                   "An error occurred while executing the Bussiness.Personnel.SelectPersonnelType", ex);
           }
       }
        
       public DataSet SelectPurChase()
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               string strPersonID;
               //Data.Person.InsertPerson(info.PersonInfo, trn, out strPersonID);
               //info.PersonID = strPersonID;
               var intReturnData = Data.MedicalSupplies.SelectPurChase(trn);

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
                   "An error occurred while executing the Bussiness.Personnel.SelectPersonnelType", ex);
           }
       }

       public DataSet SelectOperation()
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               string strPersonID;
               //Data.Person.InsertPerson(info.PersonInfo, trn, out strPersonID);
               //info.PersonID = strPersonID;
               var intReturnData = Data.MedicalSupplies.SelectOperation(trn);

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
                   "An error occurred while executing the Bussiness.Personnel.SelectPersonnelType", ex);
           }
       }
        /// <summary>
        /// Add By tu
        /// </summary>
        /// <param name="msCode"></param>
        /// <returns></returns>
       public DataSet GetMedicalSuppliesByMsCodeRef(string msCode)
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               var intReturnData = Data.MedicalSupplies.GetMedicalSuppliesByMsCodeRef(msCode,trn);

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
                   "An error occurred while executing the Bussiness.MedicalSupplies.GetMedicalSuppliesByMsCodeRef", ex);
           }
       }

       public DataSet SelectCourseDuration()
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               string strPersonID;
               //Data.Person.InsertPerson(info.PersonInfo, trn, out strPersonID);
               //info.PersonID = strPersonID;
               var intReturnData = Data.MedicalSupplies.SelectCourseDuration(trn);

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
                   "An error occurred while executing the Bussiness.Personnel.SelectPersonnelType", ex);
           }
       }
       public DataSet SelectUnit()
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               string strPersonID;
               //Data.Person.InsertPerson(info.PersonInfo, trn, out strPersonID);
               //info.PersonID = strPersonID;
               var intReturnData = Data.MedicalSupplies.SelectUnit(trn);

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
                   "An error occurred while executing the Bussiness.Personnel.SelectPersonnelType", ex);
           }
       }
       public DataSet CheckCode(string code)
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               string strPersonID;
               //Data.Person.InsertPerson(info.PersonInfo, trn, out strPersonID);
               //info.PersonID = strPersonID;
               var intReturnData = Data.MedicalSupplies.CheckCode(code, trn);

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
                   "An error occurred while executing the Bussiness.Personnel.SelectPersonnelType", ex);
           }
       }
       public DataSet CheckCodeStock(string code ,string BranchID)
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               string strPersonID;
               //Data.Person.InsertPerson(info.PersonInfo, trn, out strPersonID);
               //info.PersonID = strPersonID;
               var intReturnData = Data.MedicalSupplies.CheckCodeStock(code, BranchID, trn);

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
                   "An error occurred while executing the Bussiness.Personnel.SelectPersonnelType", ex);
           }
       }
       public DataSet CheckProCode(string code)
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               string strPersonID;
               //Data.Person.InsertPerson(info.PersonInfo, trn, out strPersonID);
               //info.PersonID = strPersonID;
               var intReturnData = Data.MedicalSupplies.CheckProCode(code, trn);

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
                   "An error occurred while executing the Bussiness.Personnel.SelectPersonnelType", ex);
           }
       }
       public DataSet CheckMOCode(string code,bool CheckMO)
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               string strPersonID;
               //Data.Person.InsertPerson(info.PersonInfo, trn, out strPersonID);
               //info.PersonID = strPersonID;
               var intReturnData = Data.MedicalSupplies.CheckMOCode(code, CheckMO, trn);

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
                   "An error occurred while executing the Bussiness.Personnel.SelectPersonnelType", ex);
           }
       }
       public int? DeleteSupplies(string code)
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               var intReturnData = Data.MedicalSupplies.DeleteSupplies(code, trn);
              
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
       public int? DeleteSuppliesStock(string code)
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               var intReturnData = Data.MedicalSupplies.DeleteSuppliesStock(code, trn);

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

       public int? DeleteSupplies(Entity.SupplieTrans[] info)
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               var intReturnData = Data.SupplieTrans.DeleteSuppliesByID(info, trn);

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
                   "An error occurred while executing the Bussiness.SupplieTrans.DeleteSupplies", ex);
           }
       }
        //================BOM=================
       public int? InsertBOMMaterial(ref Entity.MedicalSupplies info)
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               int? intReturnData=0;
               if (info.LisItemStock.Any())
               {
                   //intReturnData = intReturnData + Data.MedicalSupplies.DELETEBOMMaterial(info.LisItemStock[0].MS_Code, info.LisItemStock[0].BranchID, trn);
                   intReturnData =intReturnData+ Data.MedicalSupplies.InsertBOMMaterial(ref info, trn);

                   if (intReturnData == -1)
                   {
                       trn.Rollback();
                       conn.Close();
                       return intReturnData;
                   }
                   trn.Commit();
                   conn.Close();
               }
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
       public int? DeleteBOMMaterial(string ms_code, string BranchId)
       {
           var conn = new SqlConnection(DataObject.ConnectionString);
           conn.Open();
           var trn = conn.BeginTransaction();
           try
           {
               var intReturnData = Data.MedicalSupplies.DELETEBOMMaterial(ms_code, BranchId, trn);

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
                   "An error occurred while executing the Bussiness.SupplieTrans.DeleteSupplies", ex);
           }
       }

        public DataSet CheckMinStock()
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                Entity.MedicalSupplies info = new Entity.MedicalSupplies();
                if(Entity.Userinfo.UserGroup != "1")
                    info.BranchID = Entity.Userinfo.BranchAuth.Substring(0, Entity.Userinfo.BranchAuth.Length - 1);
                DataSet ds = Data.MedicalSupplies.CheckMinStock(info ,trn);
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
                    "An error occurred while executing the Bussiness.SelectMedicalSuppliesBySection", ex);
            }
        }

        public DataSet SelectMinStock()
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                Entity.MedicalSupplies info = new Entity.MedicalSupplies();
                if(Entity.Userinfo.UserGroup != "1")
                    info.BranchID = Entity.Userinfo.BranchAuth.Substring(0, Entity.Userinfo.BranchAuth.Length - 1);
                DataSet ds = Data.MedicalSupplies.SelectMinStock(info, trn);
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
                    "An error occurred while executing the Bussiness.SelectMedicalSuppliesBySection", ex);
            }
        }
    }
}
