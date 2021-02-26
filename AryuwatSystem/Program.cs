using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using AryuwatSystem.DerClass;
using AryuwatSystem.Forms;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Security.AccessControl;
using System.Net;
using System.Text;

namespace AryuwatSystem
{
    static class Program
    {
        static string UrlCheckUpdateVersion = "";
        static string UrlDownLoadUpdateVersion = "";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
  
        static void Main()
        {

            #region SetCulture


            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("en-US");//th-TH
            // Creating the DateTime Information specific to our application.
            System.Globalization.DateTimeFormatInfo dateTimeInfo = new System.Globalization.DateTimeFormatInfo();
            // Defining various date and time formats.
            dateTimeInfo.DateSeparator = "/";
            dateTimeInfo.LongDatePattern = "dd MMMM,yyyy";
            dateTimeInfo.ShortDatePattern = "yyyy-MM-dd";
            dateTimeInfo.LongTimePattern = "HH:mm:ss tt";
            dateTimeInfo.ShortTimePattern = "H:mm tt";
            dateTimeInfo.FullDateTimePattern = "yyyy-MM-dd H:mm:ss tt";


            // Setting application wide date time format.
            cultureInfo.DateTimeFormat = dateTimeInfo;

            // Assigning our custom Culture to the application.
            Application.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            #endregion

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //List<int> test = new List<int>();
            //test.Add(1);
            //test.Add(2);
            //test.Add(9);
            //test.Add(4);
            //test.Add(7);
            //test.Add(8);

            //  test.Sort();
            //string t=",";
            //foreach (int item in test)
            //{
            //    t+=item;
            //}
            //int ok=0;
            //for (int i = 0; i < test.Count()-1; i++)
            //{
            //    if (test[i] + 1 != test[i + 1])
            //    {
            //        ok = test[i] + 1;
            //        break;
            //    }

            //}
            //MessageBox.Show(t);
            //MessageBox.Show(ok+"");

            try
            {
                 //UrlCheckUpdateVersion= ConfigurationManager.AppSettings["UrlCheckUpdateVersion"];
                 //UrlDownLoadUpdateVersion = ConfigurationManager.AppSettings["UrlDownLoadUpdateVersion"];

               // if (CheckUpdateVersion())
               ////if (false)
               // {
               //     try
               //     {
               //         SetPermissions(Application.StartupPath);
               //     }
               //     catch (Exception ex)
               //     {
               //     }
               //     string tbUNCPath = Properties.Settings.Default.ImagePathServer;
               //     tbUNCPath = EncryptDecrypText.decryptPassword(tbUNCPath);
               //     string tbUserName = Properties.Settings.Default.UserImagePathServer;
               //     tbUserName = EncryptDecrypText.decryptPassword(tbUserName);
               //     //string tbDomain = "";// Properties.Settings.Default.PassImagePathServer;
               //     string tbPassword = Properties.Settings.Default.PassImagePathServer;
               //     tbPassword = EncryptDecrypText.decryptPassword(tbPassword);
               //     //string EncrytptbtbUNCPath = EncryptDecrypText.encryptPassword(tbUNCPath);
               //     //string EncrytptbUserName = EncryptDecrypText.encryptPassword(tbUserName);
               //     //string EncrytptbPassword = EncryptDecrypText.encryptPassword(tbPassword);
               //     //Entity.Userinfo.Server = tbUNCPath;
               //     //Entity.Userinfo.ServerUser = tbUserName;
               //     //Entity.Userinfo.ServerPass = tbPassword;

               //     string FtpServer = tbUNCPath;// Entity.Userinfo.Server;//Properties.Settings.Default.ImagePathServer;
               //     string FtpUser = tbUserName;// Entity.Userinfo.ServerUser;// Properties.Settings.Default.UserImagePathServer;
               //     string FtpPass = tbPassword;// Entity.Userinfo.ServerPass;//Properties.Settings.Default.PassImagePathServer;

               //     Process.Start(Application.StartupPath + @"\Clients.AutoUpdate.exe", string.Format("{0}|{1}|{2}", FtpServer, FtpUser, FtpPass));
               //     Application.Exit();
               //     //Statics.frmMain = new FrmMain();
               //     //Application.Run(Statics.frmMain); 
               // }
               // else
               // {
                    Statics.frmMain = new FrmMain();
                    Application.Run(Statics.frmMain); 
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private static void SetPermissions(string dirPath)
        {
            try
            {
                DirectoryInfo info = new DirectoryInfo(dirPath);
                System.Security.Principal.WindowsIdentity self = System.Security.Principal.WindowsIdentity.GetCurrent();
                DirectorySecurity ds = info.GetAccessControl();
                ds.AddAccessRule(new FileSystemAccessRule(self.Name,
                FileSystemRights.FullControl,
                InheritanceFlags.None |
                InheritanceFlags.ContainerInherit,
                PropagationFlags.None,
                AccessControlType.Allow));
                info.SetAccessControl(ds);
                //  ClearReadOnly(dirPath);

            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.Message);
            }
        }
        public static bool CheckUpdateVersion()
        {
            bool chk = false;
            try
            {

                FileStream fs = new FileStream(Application.StartupPath + "/ErrorLog.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter m_streamWriter = new StreamWriter(fs);

                m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                m_streamWriter.WriteLine(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + " " + "Start Check");
                m_streamWriter.Flush();
                m_streamWriter.Close();

                string _updatVersion = "";
                string _currentVersion = Application.ProductVersion;
                WebClient client = new WebClient();

                string tbUNCPath = Properties.Settings.Default.ImagePathServer;
                tbUNCPath = EncryptDecrypText.decryptPassword(tbUNCPath);
                string tbUserName = Properties.Settings.Default.UserImagePathServer;
                tbUserName = EncryptDecrypText.decryptPassword(tbUserName);
                //string tbDomain = "";// Properties.Settings.Default.PassImagePathServer;
                string tbPassword = Properties.Settings.Default.PassImagePathServer;
                tbPassword = EncryptDecrypText.decryptPassword(tbPassword);
                //string EncrytptbtbUNCPath = EncryptDecrypText.encryptPassword(tbUNCPath);
                //string EncrytptbUserName = EncryptDecrypText.encryptPassword(tbUserName);
                //string EncrytptbPassword = EncryptDecrypText.encryptPassword(tbPassword);
                //Entity.Userinfo.Server = tbUNCPath;
                //Entity.Userinfo.ServerUser = tbUserName;
                //Entity.Userinfo.ServerPass = tbPassword;

                string FtpServer = tbUNCPath;// Entity.Userinfo.Server;//Properties.Settings.Default.ImagePathServer;
                string FtpUser = tbUserName;// Entity.Userinfo.ServerUser;// Properties.Settings.Default.UserImagePathServer;
                string FtpPass = tbPassword;// Entity.Userinfo.ServerPass;//Properties.Settings.Default.PassImagePathServer;
                //WebClient request = new WebClient();ftp://61.91.14.121/
                string url = FtpServer + "NewVersion.txt";
                client.Credentials = new NetworkCredential(FtpUser, FtpPass);

                //==============แบบ DermasterFtp======================
            

                    string Remote_FileName = "NewVersion.txt"; ;
                    DermasterFtp ftpClient = new DermasterFtp(FtpServer, FtpUser, FtpPass);
                    //if (ftpClient.directoryListSimple(remotePath)[0].ToString() == "")
                    //    ftpClient.createDirectory(remotePath);
                    /* Upload a File */
                    //FileInfo f = new FileInfo(_imagetPath);
                    //if (!f.Exists)
                    /* Download a File */
                    string LocalFullPath = string.Format(@"{0}\version\{1}", Application.StartupPath, "NewVersion.txt");

                    if (ftpClient.download(Remote_FileName, LocalFullPath))
                    {
                        _updatVersion = File.ReadAllText(LocalFullPath, Encoding.UTF8);
                        ftpClient = null;
                    }
                    

                  

                //=================================




                //_updatVersion = client.DownloadString(url);
             
                string version = "";
                if (_updatVersion.Length > 0 && _updatVersion.LastIndexOf("\r") > 0)
                    version = _updatVersion.Substring(0, _updatVersion.IndexOf("\r"));
                else version = _updatVersion;

                if (Version.Parse(version) <= Version.Parse(_currentVersion))
                {
                    if (client != null)
                        client.Dispose();
                }
                else
                {
                    if (MessageBox.Show("New version: " + version + " found, do you want to update now?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        chk = true;
                    }
                }
            }
            catch (Exception ex)
            {
                //XtraMessageBox.Show(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                FileStream fs = new FileStream(Application.StartupPath+"/ErrorLog.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter m_streamWriter = new StreamWriter(fs);

                m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                m_streamWriter.WriteLine(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + " " + ex.StackTrace);
                m_streamWriter.Flush();
                m_streamWriter.Close();
            }
            return chk;
        }
    }
}
