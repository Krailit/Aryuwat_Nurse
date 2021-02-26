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
    public class MenuPermission
    {
        public DataSet GetMenuPermission()
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                var intReturnData = Data.MenuPermission.GetMenuPermission(trn);

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

        public DataSet GetMenuPermissiongByGroupId(int groupId)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            try
            {
                var intReturnData = Data.MenuPermission.GetMenuPermissiongByGroupId(groupId,trn);

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
                throw new AppException("An error occurred while executing the Bussiness.GetMenuPermissiongByGroupId", ex);
            }
        }

        public int? InsertMenuPermission(Entity.MenuPermission[] info)
        {
            var conn = new SqlConnection(DataObject.ConnectionString);
            conn.Open();
            var trn = conn.BeginTransaction();
            int? intStatus = 0;
            try
            {
                intStatus = Data.MenuPermission.DeleteMenuPermission(info[0].GroupId,trn);
                intStatus = Data.MenuPermission.InsertMenuPermission(
                    info,
                     trn);

                if (intStatus == -1)
                {
                    trn.Rollback();
                    conn.Close();
                    return intStatus;
                }
                trn.Commit();
                conn.Close();
                return intStatus;
            }
            catch (Exception ex)
            {
                trn.Rollback();
                conn.Close();
                throw new AppException("An error occurred while executing the Bussiness.MenuPermission.InsertMenuPermission", ex);
            }
        }

    }
}
