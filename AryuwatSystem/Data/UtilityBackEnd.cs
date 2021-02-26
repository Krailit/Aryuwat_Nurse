using System;
using System.Data;
using System.Diagnostics;
using AryuwatSystem.Baselibary;
using AryuwatSystem.Baselibary;
using AryuwatSystem.DerClass;

namespace AryuwatSystem.Data
{
    public class UtilityBackEnd : DataObject
    {
        /// <summary>
        /// รับ Query เพื่อนำมาสร้างตัวเลขลำดับใหม่ในรูปแบบตัวเลขล้วน
        /// </summary>
        /// <param name="strSQL">Query ค่าสูงสุดเช่น Select Max(ID) from MyTable</param>
        /// <returns>String เลขลำดับใหม่</returns>
        public static string GenNewID(string queryMaxID, Int16 lengthColumn)
        {
            DataSet ds;
            string strNewID = null;
            string strNumberFormat = null;
            //int intIDLength = 0;

            if (!string.IsNullOrEmpty(queryMaxID))
            {
                try
                {
                    ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, queryMaxID);
                    strNewID = ds.Tables[0].Rows[0][0].ToString();
                    if (string.IsNullOrEmpty(strNewID)) strNewID = "0";


                    for (int i = 1; i <= lengthColumn; i++) strNumberFormat += "0";
                    strNewID = (int.Parse(strNewID) + 1).ToString(strNumberFormat);

                    //if (strNewID.Length != intIDLength) strNewID = null;
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred while executing the Data.Utils.GenNewID", ex);
                }
            }

            return strNewID;
        }
        /// <summary>
        /// Method นี้ทำหน้าที่ในการ Gen Id ที่เป็น Interger
        /// </summary>
        /// <param name="strSql">Query ที่ต้องการ เช่น Select Max(...) From ... </param>
        /// <returns>Integer</returns>
        public static int GenNewIdTypeInteger(string strSql)
        {
           DataSet ds;
            int maxID;
            try
            {                

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strSql);

                if (string.IsNullOrEmpty(ds.Tables[0].Rows[0][0].ToString()))
                {
                    maxID = 1;
                }
                else maxID = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString()) + 1;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.Utils.GenNewIdTypeInteger", ex);
            }
            return maxID;
        }


        public static string GenMaxSeqnoValues(string pStrType)
        {
            DataTable msDataT;

            var strGenMax = "";


            System.Data.SqlClient.SqlParameter[] msSqlParameter = {                
                new System.Data.SqlClient.SqlParameter( "@DocPrefix", pStrType),
                new System.Data.SqlClient.SqlParameter( "@DocNoOut", "")
					};
            try
            {
                // Fill the Dataset object with records

                msDataT = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sp_gendocno", msSqlParameter).Tables[0];
                if (msDataT.Rows.Count > 0)
                {
                    strGenMax = msDataT.Rows[0]["DocNo"].ToString();
                }
                //MsDataSet = SqlHelper.ExecuteDataset(ConnectionString, System.Data.CommandType.StoredProcedure, "ProcShowUsers_Tb", MsSqlParameter);
                return strGenMax;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.Utils.GenMaxSeqnoValues", ex);

            }
        }
        public static string GenMaxSeqnoValues(string pStrType, string BranchID)
        {
            DataTable msDataT;

            var strGenMax = "";


            System.Data.SqlClient.SqlParameter[] msSqlParameter = {                
                new System.Data.SqlClient.SqlParameter( "@DocPrefix", pStrType),
                new System.Data.SqlClient.SqlParameter( "@BranchID", BranchID),
                new System.Data.SqlClient.SqlParameter( "@DocNoOut", "")
					};
            try
            {
                // Fill the Dataset object with records

                msDataT = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sp_gendocno", msSqlParameter).Tables[0];
                if (msDataT.Rows.Count > 0)
                {
                    strGenMax = msDataT.Rows[0]["DocNo"].ToString();
                }
                //MsDataSet = SqlHelper.ExecuteDataset(ConnectionString, System.Data.CommandType.StoredProcedure, "ProcShowUsers_Tb", MsSqlParameter);
                return strGenMax;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.Utils.GenMaxSeqnoValues", ex);

            }
        }
        public static string GenMaxSeqnoValuesFileScan(string pStrType,string Sono,string VN,string CN)
        {
            DataTable msDataT;

            var strGenMax = "";


            System.Data.SqlClient.SqlParameter[] msSqlParameter = {                
                new System.Data.SqlClient.SqlParameter( "@DocPrefix", pStrType),
                new System.Data.SqlClient.SqlParameter( "@DocNoOut", ""),
                new System.Data.SqlClient.SqlParameter( "@Sono",Sono),
                new System.Data.SqlClient.SqlParameter( "@VN",VN),
                new System.Data.SqlClient.SqlParameter( "@CN",CN)
                
					};


            try
            {
                // Fill the Dataset object with records

                msDataT = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sp_gendocno", msSqlParameter).Tables[0];
                if (msDataT.Rows.Count > 0)
                {
                    strGenMax = msDataT.Rows[0]["DocNo"].ToString();
                }
                //MsDataSet = SqlHelper.ExecuteDataset(ConnectionString, System.Data.CommandType.StoredProcedure, "ProcShowUsers_Tb", MsSqlParameter);
                return strGenMax;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.Utils.GenMaxSeqnoValues", ex);

            }
        }
        public static bool SendImageToServer(string fullPath, string fileNameNew)
        {
            try
            {
                FtpClient _ftp = new FtpClient(Properties.Settings.Default.FtpServer,
                                              Properties.Settings.Default.FtpUserName,
                                              Properties.Settings.Default.FtpPassword);
                _ftp.Login();
                _ftp.Upload(fullPath, fileNameNew);
                _ftp.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }   
        //private static FtpClient _ftp = null;

        //public static bool SendImageToServer(string fullPath, string fileNameNew)
        //{
        //    try
        //    {
        //        AsyncCallback callback = new AsyncCallback(CloseConnection);

        //        _ftp = new FtpClient(Properties.Settings.Default.FtpServer,
        //                                      Properties.Settings.Default.FtpUserName,
        //                                      Properties.Settings.Default.FtpPassword);
        //        _ftp.Login();
        //        _ftp.BeginUpload(fullPath, fileNameNew, callback);
        //        _ftp.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        //private static void CloseConnection(IAsyncResult result)
        //{
        //    Debug.WriteLine(result.IsCompleted.ToString());

        //    if (_ftp != null) _ftp.Close();
        //    _ftp = null;
        //} 
        public static DateTime GetTodate()
        {
            DateTime dtToDate = DateTime.Now;
            DataTable msDataT;

            try
            {
                // Fill the Dataset object with records
                string sql = "Select getdate() as Todate";
                msDataT =
                    SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql).Tables[0];
                if (msDataT.Rows.Count > 0)
                {
                    dtToDate = Convert.ToDateTime(msDataT.Rows[0]["Todate"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing the Data.UtilsBackEnd.GetTodate", ex);
            }
            return dtToDate;
        }
    }
}
