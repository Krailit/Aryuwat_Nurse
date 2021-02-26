using System.Configuration;
using AryuwatSystem.DerClass;
namespace AryuwatSystem.Baselibary
{
    public abstract class DataObject
    {
        public static string ConnectionString
        {
            get
            {
                //return ConfigurationManager.AppSettings["ConnectionString"];
                //return EncryptDecrypText.decryptPassword(ConfigurationManager.AppSettings["ConnectionString"]);
                var connection = ConfigurationManager.ConnectionStrings["OPD_SystemContext"].ConnectionString;
                //return ConfigurationManager.AppSettings["ConnectionString"];
                return connection;
            }
        }
    }
}