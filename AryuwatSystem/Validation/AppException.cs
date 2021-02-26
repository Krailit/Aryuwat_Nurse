using System;
using System.Data;
using System.Configuration;
using System.Diagnostics;
using System.Web;
using System.Windows.Forms;

/// <summary>
/// Summary description for AppException
/// </summary>
namespace Entity.Validation
{
    /// <summary>
    /// Default exception to be thrown by the website, it will
    /// automatically log the contents of the exception to the
    /// Windows NT/2000 Application Event Log.
    /// </summary>
    public class AppException : System.ApplicationException 
    {
        public AppException()
        {
            //LogEvent("An unexpected error occurred.");
            LogError("An unexpected error occurred.");
        }

        public AppException(string message)
        {
            //LogEvent(message);
            LogError(message);
        }

        public AppException(string message, Exception innerException)
        {
            LogError(message);
            if (innerException != null)
            {
                //LogEvent(innerException.Message);
                LogError(innerException.Message);
                LogError(innerException.StackTrace);
            }
        }

        private void LogEvent(string message)
        {
            if (!EventLog.SourceExists("Dummy"))
            {
                EventLog.CreateEventSource("Dummy", "Application");
            }
            EventLog.WriteEntry("Dummy", message, EventLogEntryType.Error);
        }

        public static void LogError(string message)
        {
            //string filePath = context.Server.MapPath(System.Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["ErrorLogFile"]));
            //string filePath = context.Server.MapPath(ConfigurationManager.AppSettings["ErrorLogFile"]);
            //string filePath = ConfigurationManager.AppSettings["ErrorLogFile"];
            string filePath;
            //if (ConfigurationManager.AppSettings != null)
                //filePath = filePath.Replace("\\bin\\Debug","") + ConfigurationManager.AppSettings["ErrorLogFile"];
                filePath = string.Format("{0}\\{1}",Application.StartupPath,ConfigurationManager.AppSettings["ErrorLogFile"]) ;

            int gmtOffset = DateTime.Compare(DateTime.Now, DateTime.UtcNow);
            string gmtPrefix;
            if (gmtOffset > 0)
            {
                gmtPrefix = "+";
            }
            else
            {
                gmtPrefix = "";
            }
            string errorDateTime = DateTime.Now.Year + "." + DateTime.Now.Month + "." + DateTime.Now.Day + " @ " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + " (GMT " + gmtPrefix + gmtOffset + ")";
            try
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath, true);
                sw.WriteLine("## " + errorDateTime + " ## " + message + " ##");
                sw.Close();
            }
            catch
            {
            }
        }

        #region IServiceProvider Members

        public object GetService(Type serviceType)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        //#region IServiceProvider Members

        ////object IServiceProvider.GetService(Type serviceType)
        ////{
        ////    throw new Exception("The method or operation is not implemented.");
        ////}

        //#endregion
    }
}
