using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using AryuwatSystem.Properties;
using AryuwatSystem.UserControls;
using AryuwatSystem.Forms;
using System.Reflection;

namespace AryuwatSystem.DerClass
{
    public class DerUtility
    {
        public const long ROW_PER_PAGE = 120;
        public static byte[] sBarrImg;
        public static long sImageFileLength;
        public int iSeconds = 10;
        public int iTimerCount;
     
        #region Enum

        #region AccessType enum

        /// <summary>
        /// ใช้สำหรับตรวจสอบการแก้ไขข้อมูล 
        /// </summary>
        public enum AccessType
        {
            [StringValue("เพิ่มข้อมูล")]
            Insert,
            [StringValue("แก้ไขข้อมูล")]
            Update,
            [StringValue("แสดงข้อมูลอย่างเดียว")]
            DisplayOnly
        }
        public enum StockTyp
        {
            [StringValue("เบิกสาขา")]
            REQBranch,
            [StringValue("ตอบกลับสาขา")]
            ReplyBranch,
            [StringValue("เบิกแผนก")]
            REQDept,
            [StringValue("ตอบกลับแผนก")]
            ReplyDept,

        }
        #endregion

        #region EnuMsgType enum

        public enum EnuMsgType
        {
            MsgTypeConfirm,
            MsgTypeError,
            MsgTypeInformation,
            MsgTypeConfirmYesNo
        }

        #endregion

        #endregion

        #region Cryptography

        public static string GetEncrypData(string keycode, string strEncryp)
        {
            MemoryStream ms;
            DESCryptoServiceProvider desCrypt;
            CryptoStream cs;
            var CurrentIV = new byte[] { 51, 52, 53, 54, 55, 56, 57, 58 };
            byte[] CurrentKey;
            if (keycode.Length == 8)
            {
                CurrentKey = Encoding.ASCII.GetBytes(keycode);
            }
            else if (keycode.Length > 8)
            {
                CurrentKey = Encoding.ASCII.GetBytes(keycode.Substring(0, 8));
            }
            else
            {
                string AddString = keycode.Substring(0, 1);
                int TotalLoop = 8 - Convert.ToInt32(keycode.Length);
                string tmpKey = keycode;

                for (int i = 1; i <= TotalLoop; i++)
                {
                    tmpKey = tmpKey + AddString;
                }
                CurrentKey = Encoding.ASCII.GetBytes(tmpKey);
            }

            desCrypt = new DESCryptoServiceProvider();
            desCrypt.IV = CurrentIV;
            desCrypt.Key = CurrentKey;

            ms = new MemoryStream();
            ms.Position = 0;

            ICryptoTransform ce = desCrypt.CreateEncryptor();
            cs = new CryptoStream(ms, ce, CryptoStreamMode.Write);
            byte[] arrByte = Encoding.ASCII.GetBytes(strEncryp);
            cs.Write(arrByte, 0, arrByte.Length);
            cs.FlushFinalBlock();
            cs.Close();

            return Convert.ToBase64String(ms.ToArray());
        }

        #endregion

        /// <summary>
        /// ตรวจสอบการกด Enter เพื่อที่จะให้เลื่อน TabIndex
        /// </summary>
        /// <param name="CurrentChar">e  KeyPress</param>
        public static void SendKey(char keys)
        {
            if (keys == 13)
            {
                SendKeys.Send("{tab}");
            }
        }


        /// <summary>
        /// ตรวจและSet keyBorad Auto
        /// </summary>

        public static void GetSetInputKeyBorad(string langName)
        {
                foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
                {
                    if (lang.Culture.EnglishName.ToLower().StartsWith(langName))
                    {
                        InputLanguage.CurrentInputLanguage = lang;
                    }
                }
        }


        /// <summary>
        /// ตรวจรูปแบบวันที่
        /// </summary>
        /// <param name="CurrentChar">DD/MM/YYYY</param>
        public static bool CheckDate(string pStrDate)
        {
            //** Purpose :
            //** Accept  :
            //** Return  :
            string strDate = "";
            string strDay = "";
            string strMonth = "";
            string strYear = "";
            int intLen = 0;
            if (IsBlank(pStrDate) == false)
            {
                pStrDate = pStrDate.Trim().Replace("/", "");


                intLen = pStrDate.Length;
                if (intLen != 8)
                {
                    return false;
                }

                strDay = pStrDate.Trim().Substring(0, 2);
                strMonth = pStrDate.Trim().Substring(2, 2);
                strYear = pStrDate.Trim().Substring(4, 4);

                if (int.Parse(strMonth) < 1 || int.Parse(strMonth) > 12)
                {
                    return false;
                }

                if (Convert.ToInt16(strYear) < 2400)
                {
                    return false;
                }

                strDate = strYear + "/" + strMonth + "/" + strDay;
                return (IsDate(strDate) ? true : false);
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// ตรวจค่าว่าง
        /// </summary>
        /// <param name="CurrentChar"></param>
        public static bool IsBlank(string pStr)
        {
            if (IsNull(pStr) || pStr.Trim() == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsNull(object obj)
        {
            if (obj == null || Convert.IsDBNull(obj) || string.IsNullOrEmpty(obj.ToString()))
                return true;
            return false;
        }

        public static bool IsDate(Object obj)
        {
            string strDate = obj.ToString();
            try
            {
                DateTime dt = DateTime.Parse(strDate);
                if (dt != DateTime.MinValue && dt != DateTime.MaxValue)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsNumeric(string anyString)
        {
            if (anyString == null)
            {
                anyString = "";
            }
            if (anyString.Length > 0)
            {
                var dummyOut = new double();
                var cultureInfo = new CultureInfo("en-US", true);
                return Double.TryParse(anyString, NumberStyles.Any, cultureInfo.NumberFormat, out dummyOut);
            }

            else
            {
                return false;
            }
        }
        public static string IsMonthNameThai(int mon)
        {
            string monthname = "";
            if(mon==1)monthname="มกราคม";
            else if(mon==2)monthname="กุมภาพันธ์";
            else if(mon==3)monthname="มีนาคม";
            else if(mon==4)monthname="เมษายน";
            else if(mon==5)monthname="พฤษภาคม";
            else if(mon==6)monthname="มิถุนายน";
            else if(mon==7)monthname="กรกฎาคม";
            else if(mon==8)monthname="สิงหาคม";
            else if(mon==9)monthname="กันยายน";
            else if(mon==10)monthname="ตุลาคม";
            else if(mon==11)monthname="พฤศจิกายน";
            else if(mon==12)monthname="ธันวาคม";

            return monthname;
        }

        public static DialogResult PopMsg(EnuMsgType pMsgType, string pStrError)
        {
            DialogResult result = DialogResult.None;
            switch (pMsgType)
            {
                case EnuMsgType.MsgTypeConfirm:
                    result = MessageBox.Show(pStrError, "Aryuwat System", MessageBoxButtons.OKCancel,
                                             MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    break;
                case EnuMsgType.MsgTypeConfirmYesNo:
                    result = MessageBox.Show(pStrError, "Aryuwat System", MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    break;
                case EnuMsgType.MsgTypeError:
                    result = MessageBox.Show(pStrError, "Aryuwat System", MessageBoxButtons.OK, MessageBoxIcon.Error,
                                             MessageBoxDefaultButton.Button2);
                    break;
                case EnuMsgType.MsgTypeInformation:
                    result = MessageBox.Show(pStrError, "Aryuwat System", MessageBoxButtons.OK,
                                             MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    break;
            }
            return result;
        }

        public static DialogResult PopMsg(EnuMsgType pMsgType, string pStrError, string pStrCaptionHeard)
        {
            DialogResult result = DialogResult.None;
            switch (pMsgType)
            {
                case EnuMsgType.MsgTypeConfirm:
                    result = MessageBox.Show(pStrError, pStrCaptionHeard, MessageBoxButtons.OKCancel,
                                             MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    break;
                case EnuMsgType.MsgTypeConfirmYesNo:
                    result = MessageBox.Show(pStrError, pStrCaptionHeard, MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    break;
                case EnuMsgType.MsgTypeError:
                    result = MessageBox.Show(pStrError, pStrCaptionHeard, MessageBoxButtons.OKCancel,
                                             MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                    break;
                case EnuMsgType.MsgTypeInformation:
                    result = MessageBox.Show(pStrError, pStrCaptionHeard, MessageBoxButtons.OK,
                                             MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    break;
            }
            return result;
        }


        public static void MouseOn(Form pfrm)
        {
            pfrm.Cursor = Cursors.WaitCursor;
        }

        public static void MouseOff(Form pfrm)
        {
            pfrm.Cursor = Cursors.Default;
        }


        public static void FindRangeRow(long pPageNum, ref long pStartRow, ref long pEndRow)
        {
            pStartRow = (ROW_PER_PAGE * (pPageNum - 1)) + 1;
            pEndRow = ROW_PER_PAGE * pPageNum;
        }

        public static void FindTotalPage(long pRowall, ref long pPageCount)
        {
            if (pRowall < ROW_PER_PAGE)
            {
                pPageCount = 1;
            }
            else if ((pRowall % ROW_PER_PAGE) == 0)
            {
                pPageCount = pRowall / ROW_PER_PAGE;
                if (pPageCount < 1)
                {
                    pPageCount = 1;
                }
            }
            else
            {
                pPageCount = (pRowall / ROW_PER_PAGE) + 1;
            }
        }

        public static string ClearFormatNumber(object obj)
        {
            return Convert.ToString(obj).Replace(",", "");
        }

        /// <summary>
        /// Convert to Save date in database
        /// </summary>
        /// <param name="CurrentChar">Accept  : Date in format : DD/MM/YYYY or DDMMYYYYY Return  : Date in format : YYYYMMDD</param>
        public static string ToSystemDate(string pStrDate)
        {
            string strDate;
            string strYear;
            string strMonth;
            string strDay;
            strDate = pStrDate.Trim();
            if (IsBlank(pStrDate.Trim()))
            {
                return "";
            }
            switch (strDate.Length)
            {
                case 8:
                    strDay = strDate.Substring(0, 2);
                    strMonth = strDate.Substring(2, 2);
                    strYear = strDate.Substring(4, 4);

                    strDate = strYear + strMonth + strDay;
                    break;
                case 10:
                    strDay = strDate.Substring(0, 2);
                    strMonth = strDate.Substring(3, 2);
                    strYear = strDate.Substring(6, 4);
                    strDate = strYear + strMonth + strDay;
                    break;
                default:
                    string[] arr = strDate.Split(' ');
                    strDate = arr[0];

                    strDay = strDate.Substring(0, 2);
                    strMonth = strDate.Substring(3, 2);
                    strYear = strDate.Substring(6, 4);
                    strDate = strYear + strMonth + strDay;

                    string strtime = Convert.ToString(arr[1]).Replace(":", "");

                    strDate = strDate + strtime;
                    break;
            }
            return strDate;
        }

        /// <summary>
        /// Convert to Save date in database
        /// </summary>
        /// <param name="CurrentChar">Accept  : Date in format : DDMMYYYYY Return  : Date in format : DD/MM/YYYYY</param>
        public static string ToFormatDate(string pStrDate)
        {
            string strDate;
            strDate = pStrDate.Trim();
            switch (strDate.Length)
            {
                case 8:
                    string strDay = strDate.Substring(6, 2);
                    string strMonth = strDate.Substring(4, 2);
                    string strYear = strDate.Substring(0, 4);
                    strDate = strDay + "/" + strMonth + "/" + strYear;
                    break;
            }
            return strDate;
        }
        public static string ToFormatDateyyyyMMdd(string pStrDate)
        {
            string strDate;
            strDate = pStrDate.Trim().Replace("/","");
            switch (strDate.Length)
            {
                case 8:
                    string strDay = strDate.Substring(0, 2);
                    string strMonth = strDate.Substring(2, 2);
                    string strYear = strDate.Substring(4, 4);
                    strDate = strYear + "/" + strMonth + "/" + strDay;
                    break;
            }
            return strDate;
        }

        public static void SetUpListView(ListView plsv)
        {
            plsv.View = View.Details;
            plsv.GridLines = true;
            plsv.FullRowSelect = true;
        }

        //Sort Columns Listview
        public static void SetSortListView(ListView plsv, ColumnClickEventArgs e, ref ColumnHeader m_SortingColumn)
        {
            ColumnHeader new_sorting_column = plsv.Columns[e.Column];

            // Figure out the new sorting order.
            SortOrder sort_order = default(SortOrder);
            if (m_SortingColumn == null)
            {
                // New column. Sort ascending.
                sort_order = SortOrder.Ascending;
            }
            else
            {
                // See if this is the same column.
                if (new_sorting_column.Equals(m_SortingColumn))
                {
                    // Same column. Switch the sort order.
                    if (m_SortingColumn.Text.StartsWith(">> "))
                    {
                        sort_order = SortOrder.Descending;
                    }
                    else
                    {
                        sort_order = SortOrder.Ascending;
                    }
                }
                else
                {
                    // New column. Sort ascending.
                    sort_order = SortOrder.Ascending;
                }

                // Remove the old sort indicator.
                m_SortingColumn.Text = m_SortingColumn.Text.Substring(3);
            }

            // Display the new sort order.
            m_SortingColumn = new_sorting_column;
            if (sort_order == SortOrder.Ascending)
            {
                m_SortingColumn.Text = ">> " + m_SortingColumn.Text;
            }
            else
            {
                m_SortingColumn.Text = "<< " + m_SortingColumn.Text;
            }

            // Create a comparer.
            plsv.ListViewItemSorter = new Statics.ListViewComparer(e.Column, sort_order);

            // Sort.
            plsv.Sort();
        }

        public static void SetPropertyDgv(DataGridView sender)
        {
            sender.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(219, 241, 252);

            sender.DefaultCellStyle.BackColor = Color.FromArgb(245, 250, 253);
            sender.AllowUserToAddRows = false;
            sender.DefaultCellStyle.Font = new System.Drawing.Font("tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            sender.RowHeadersDefaultCellStyle.Font = new System.Drawing.Font("tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            //((DataGridView)sender).Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            //| System.Windows.Forms.AnchorStyles.Right) | System.Windows.Forms.AnchorStyles.Bottom));
            sender.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
        }

        public static void SetRowsColor(ListView plsv)
        {
            foreach (ListViewItem lvi in plsv.Items)
            {
                if (lvi.Index % 2 == 0)
                    lvi.BackColor = Color.White;
                else
                    //lvi.BackColor = Statics.ColorTo;
                    lvi.BackColor = Color.FromArgb(219, 241, 252);
            }
        }


        public static void ClearFields(Form pObj, object[] pParamNotClear)
        {
            foreach (Control ctrlFrm in pObj.Controls)
            {
                bool blnFlag = false;
                if (ctrlFrm is GroupBox || ctrlFrm is TabControl || ctrlFrm is TabPage)
                {
                    SetControlChildGroupBox(ctrlFrm, pParamNotClear);
                }


                foreach (Control ctrlParam in pParamNotClear)
                {
                    if (ctrlFrm.Name.ToUpper() == ctrlParam.Name.ToUpper())
                    {
                        blnFlag = true;
                        break;
                    }
                }

                if (!blnFlag)
                {
                    if (ctrlFrm is TextBox)
                    {
                        ctrlFrm.Text = "";
                    }
                    else if (ctrlFrm is Label)
                    {
                        if (ctrlFrm.Name.Substring(0, 6).ToUpper() == "LblTxt".ToUpper())
                        {
                            ctrlFrm.Text = "";
                        }
                    }
                    else if (ctrlFrm is ComboBox)
                    {
                        if (((ComboBox)ctrlFrm).SelectedIndex < 0)
                        {
                            ((ComboBox)ctrlFrm).SelectedIndex = -1;
                        }
                        else
                        {
                            ((ComboBox)ctrlFrm).SelectedIndex = 0;
                        }
                    }
                    else if (ctrlFrm is CheckBox)
                    {
                        ((CheckBox)ctrlFrm).Checked = false;
                    }
                    else if (ctrlFrm is RadioButton)
                    {
                        ((RadioButton)ctrlFrm).Checked = false;
                    }
                    else if (ctrlFrm is MaskedTextBox)
                    {
                        ctrlFrm.Text = "";
                    }
                    else if (ctrlFrm is TextboxFormatDouble)
                    {
                        ctrlFrm.Text = "0.00";
                    }
                    else if (ctrlFrm is TextboxFormatInteger)
                    {
                        ctrlFrm.Text = "0";
                    }
                }
            }
        }

        private static void SetControlChildGroupBox(Control ctrl, object[] obj)
        {
            bool blnFlag = false;
            foreach (Control ctrlIn in ctrl.Controls)
            {
                if (ctrlIn is GroupBox || ctrlIn is TabControl || ctrlIn is TabPage)
                {
                    SetControlChildGroupBox(ctrlIn, obj);
                }


                foreach (Control ctrlParam in obj)
                {
                    if (ctrlIn.Name.ToUpper() == ctrlParam.Name.ToUpper())
                    {
                        blnFlag = true;
                        break;
                    }
                }


                if (!blnFlag)
                {
                    if (ctrlIn is TextBox)
                    {
                        ctrlIn.Text = "";
                    }
                    else if (ctrlIn is Label)
                    {
                        if (ctrlIn.Name.Substring(0, 6).ToUpper() == "LblTxt".ToUpper())
                        {
                            ctrlIn.Text = "";
                        }
                    }
                    else if (ctrlIn is ComboBox)
                    {
                        if (((ComboBox)ctrlIn).SelectedIndex < 0)
                        {
                            ((ComboBox)ctrlIn).SelectedIndex = -1;
                        }
                        else
                        {
                            ((ComboBox)ctrlIn).SelectedIndex = 0;
                        }
                    }
                    else if (ctrlIn is CheckBox)
                    {
                        ((CheckBox)ctrlIn).Checked = false;
                    }
                    else if (ctrlIn is RadioButton)
                    {
                        ((RadioButton)ctrlIn).Checked = false;
                    }
                    else if (ctrlIn is MaskedTextBox)
                    {
                        ctrlIn.Text = "";
                    }
                    else if (ctrlIn is TextboxFormatDouble)
                    {
                        ctrlIn.Text = "0.00";
                    }
                    else if (ctrlIn is TextboxFormatInteger)
                    {
                        ctrlIn.Text = "0";
                    }
                }
            }
        }

        public static void SearchFocus(string pStrKey, ListView pLsv)
        {
            if (!string.IsNullOrEmpty(pStrKey))
            {
                ListViewItem irow;
                irow = pLsv.FindItemWithText(pStrKey);
                irow.EnsureVisible();
                irow.Selected = true;
                pLsv.Focus();
            }
        }

        public static string FormatSysDate(DateTime dtmInput)
        {
            string m_strDateTime;
            DateTimeFormatInfo dtfInfo;
            string strDateStyle = "dd/MM/yyyy";

            dtfInfo = DateTimeFormatInfo.CurrentInfo;
            dtfInfo = DateTimeFormatInfo.InvariantInfo; //กำหนดรูปแบบจัดวันที่เป็นแบบสากล

            //DateTimeFormatInfo myDTFI = new CultureInfo("en-US", false).DateTimeFormat;
            m_strDateTime = dtmInput.ToString(strDateStyle, dtfInfo);

            ////m_strDateTime = string.Format(strDateTime.ToString("yyyyMMdd")); แบบนี้ก็ใช้ได้
            //m_strDateTime = string.Format("{0:yyyyMMdd}", strDateTime);
            return m_strDateTime;
        }

        public static void DownLoadPicture(string fileName, PictureBox sender)
        {
            try
            {
                var _ftp = new FtpClient(Settings.Default.FtpServer,
                                         Settings.Default.FtpUserName,
                                         Settings.Default.FtpPassword);
                _ftp.Login();
                _ftp.Download(fileName, Settings.Default.LocalFilePath + "\\" + fileName);
                _ftp.Close();
                //_ftp = null;
                (sender).ImageLocation = Settings.Default.LocalFilePath + "\\" + fileName;
            }

            catch (Exception exception)
            {
                PopMsg(EnuMsgType.MsgTypeError, "ไม่พบไฟล์รูปภาพ");
            }
        }

        public static string WeeklyName(string strWeekly)
        {
            string strWeeklyName = "";
            switch (strWeekly)
            {
                case "Monday":
                    strWeeklyName = "จันทร์";
                    break;
                case "Tuesday":
                    strWeeklyName = "อังคาร";
                    break;
                case "Wednesday":
                    strWeeklyName = "พุทธ";
                    break;
                case "Thursday":
                    strWeeklyName = "พฤหัสบดี";
                    break;
                case "Friday":
                    strWeeklyName = "ศุกร์";
                    break;
                case "Saturday":
                    strWeeklyName = "เสาร์";
                    break;
                case "Sunday":
                    strWeeklyName = "อาทิตย์";
                    break;
            }
            return strWeeklyName;
        }

        public static bool DownLoadImage(string LocalFullPath, string remotePath, string filenameWithExtension)
        {
            try
            {
                
                string Remote_imagetPath = remotePath + filenameWithExtension;
                //DermasterFtp ftp = new DermasterFtp("61.91.14.121", "AryuwatSystem", "Dermaster1234567890");

                // ftp.upload(Remote_imagetPath,imagepath);
                /* Create Object Instance */
                DermasterFtp ftpClient = new DermasterFtp(Entity.Userinfo.Server, Entity.Userinfo.ServerUser, Entity.Userinfo.ServerPass);
                if (ftpClient.directoryListSimple(remotePath)[0].ToString() == "")
                    ftpClient.createDirectory(remotePath);
                /* Upload a File */
                //FileInfo f = new FileInfo(_imagetPath);
                //if (!f.Exists)
                /* Download a File */
                if (ftpClient.download(Remote_imagetPath, LocalFullPath))
                {
                    ftpClient = null;
                    return true;
                }
                else return false;

                /* Delete a File */
                //  ftpClient.delete("etc/test.txt");

                /* Rename a File */
                //  ftpClient.rename("etc/test.txt", "test2.txt");

                /* Create a New Directory */
                // ftpClient.createDirectory("etc/test");

                ///* Get the Date/Time a File was Created */
                //string fileDateTime = ftpClient.getFileCreatedDateTime("etc/test.txt");
                //Console.WriteLine(fileDateTime);

                ///* Get the Size of a File */
                //string fileSize = ftpClient.getFileSize("etc/test.txt");
                //Console.WriteLine(fileSize);

                ///* Get Contents of a Directory (Names Only) */
                //string[] simpleDirectoryListing = ftpClient.directoryListDetailed("/etc");
                //for (int i = 0; i < simpleDirectoryListing.C; i++) { Console.WriteLine(simpleDirectoryListing[i]); }

                ///* Get Contents of a Directory with Detailed File/Directory Info */
                //string[] detailDirectoryListing = ftpClient.directoryListDetailed("/etc");
                //for (int i = 0; i < detailDirectoryListing.Count(); i++) { Console.WriteLine(detailDirectoryListing[i]); }
                /* Release Resources */
             
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public static bool SaveImage(string LocalFullPath, string remotePath, string filenameWithExtension)
        {
            try
            {
                if (LocalFullPath == "") return false;
                string Remote_imagetPath = "";
                Remote_imagetPath = remotePath + filenameWithExtension;

                /* Create Object Instance */
                DermasterFtp ftpClient = new DermasterFtp(Entity.Userinfo.Server, Entity.Userinfo.ServerUser, Entity.Userinfo.ServerPass);
                if (ftpClient.directoryListSimple(remotePath)[0].ToString()=="")
                    ftpClient.createDirectory(remotePath);
                /* Upload a File */
                ftpClient.upload(Remote_imagetPath, LocalFullPath);
                //FileInfo f = new FileInfo(LocalFullPath);
                
                //if (!f.Exists)
                /* Download a File */
                //ftpClient.download(Remote_imagetPath, LocalFullPath);

                /* Delete a File */
                //  ftpClient.delete("etc/test.txt");

                /* Rename a File */
                //  ftpClient.rename("etc/test.txt", "test2.txt");

                /* Create a New Directory */
                // ftpClient.createDirectory("etc/test");

                ///* Get the Date/Time a File was Created */
                //string fileDateTime = ftpClient.getFileCreatedDateTime("etc/test.txt");
                //Console.WriteLine(fileDateTime);

                ///* Get the Size of a File */
                //string fileSize = ftpClient.getFileSize("etc/test.txt");
                //Console.WriteLine(fileSize);

                ///* Get Contents of a Directory (Names Only) */
                //string[] simpleDirectoryListing = ftpClient.directoryListDetailed("/etc");
                //for (int i = 0; i < simpleDirectoryListing.C; i++) { Console.WriteLine(simpleDirectoryListing[i]); }

                ///* Get Contents of a Directory with Detailed File/Directory Info */
                //string[] detailDirectoryListing = ftpClient.directoryListDetailed("/etc");
                //for (int i = 0; i < detailDirectoryListing.Count(); i++) { Console.WriteLine(detailDirectoryListing[i]); }
                /* Release Resources */
                ftpClient = null;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
       
    }
          public enum DateInterval
    {
        Year,
        Month,
        Weekday,
        Day,
        Hour,
        Minute,
        Second
    }
        
    public class DateTimeUtil
          {
        public static void SelectDate(TextBox txt)
            {
                try
                {
                    PopDateTime pp = new PopDateTime();
                    DateTime d;
                    if (txt.Text.Trim() != "")
                        pp.SelecttDate = Convert.ToDateTime(txt.Text.Trim());// DateTime.TryParse(txt.Text, out d) ? d : DateTime.Now;
                    else
                        pp.SelecttDate = Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yyyy"));// DateTime.TryParse(txt.Text, out d) ? d : DateTime.Now;
                    //pp.SelecttDate =Convert.ToDateTime(pp.SelecttDate);
                    if (pp.ShowDialog() == DialogResult.OK)
                    {
                        //txt.Text = pp.SelecttDate.Date.ToString("dd/MM/yyyy");
                        txt.Text = pp.SelecttDate.Date.ToString("dd-MM-yyyy");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
              public static long DateDiff(DateInterval interval, DateTime date1, DateTime date2)
              {
                  TimeSpan ts = date2 - date1;

                  switch (interval)
                  {
                      case DateInterval.Year:
                          return date2.Year - date1.Year;
                      case DateInterval.Month:
                          return (date2.Month - date1.Month) + (12 * (date2.Year - date1.Year));
                      case DateInterval.Weekday:
                          return Fix(ts.TotalDays) / 7;
                      case DateInterval.Day:
                          return Fix(ts.TotalDays);
                      case DateInterval.Hour:
                          return Fix(ts.TotalHours);
                      case DateInterval.Minute:
                          return Fix(ts.TotalMinutes);
                      default:
                          return Fix(ts.TotalSeconds);
                  }
              }

              private static long Fix(double Number)
              {
                  if (Number >= 0)
                  {
                      return (long)Math.Floor(Number);
                  }
                  return (long)Math.Ceiling(Number);
              }

              public static DateTime FirstDayOfMonth( int year,int m)
              {
                  return new DateTime(year, m, 1);
              }

              public static  DateTime LastDayOfMonth(int year,int m)
              {
                  return new DateTime(year, m, 1).AddMonths(1).AddDays(-1);
              }
              
          }

    public class ExportFile
    {
              private static void SetColumnFormatting(Microsoft.Office.Interop.Excel.Worksheet excelSheet, System.Data.DataTable dt)
                {
                    foreach (DataColumn col in dt.Columns)
                    {
                        if (col.DataType == typeof(System.DateTime))
                        {
                            ((Microsoft.Office.Interop.Excel.Range)excelSheet.Cells[1, dt.Columns.IndexOf(col) + 1]).EntireColumn.NumberFormat = "dd/MM/yyyy HH:mm";
                        }
                    }
                }
        public static void ExportToExcel(DataSet dataSet)
        {
           // ExportStatusDialog expStatus = new ExportStatusDialog();
            string outputPath = string.Format(@"{0}\{1}\{2}\{3}\", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), System.Windows.Forms.Application.CompanyName, System.Windows.Forms.Application.ProductName, "ExportXLSX");
            outputPath += string.Format("{0}_{1}.xlsx", "exportXLSX", Guid.NewGuid().ToString("N"));
            try
            {
                // Create the Excel Application object
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

                Microsoft.Office.Interop.Excel.Workbook excelWorkbook = null;

                // Create a new Excel Workbook
               
                    excelWorkbook = excelApp.Workbooks.Add(Type.Missing);

                int sheetIndex = 0;

                 //Copy each DataTable
                ///Splite Datatable=======================
                foreach (System.Data.DataTable dt in dataSet.Tables)
                {
                    Microsoft.Office.Interop.Excel.Worksheet excelSheet = null;
                 
                        // Create a new Sheet
                        excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelWorkbook.Sheets.Add(excelWorkbook.Sheets.get_Item(++sheetIndex),Type.Missing, 1, Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet);
                        excelSheet.Name = dt.TableName;
                   
                    excelSheet.Application.ActiveWindow.DisplayGridlines = false;

                    // Copy the DataTable to an object array
                    string[,] rawData = new string[dt.Rows.Count + 1, dt.Columns.Count];

                    // Copy the column names to the first row of the object array
                    for (int col = 0; col < dt.Columns.Count; col++)
                    {
                        rawData[0, col] = dt.Columns[col].ColumnName;
                    }

                    // Copy the values to the object array
                    for (int col = 0; col < dt.Columns.Count; col++)
                    {
                        for (int row = 0; row < dt.Rows.Count; row++)
                        {
                           // rawData[row + 1, col] = dt.Rows[row].ItemArray[col];
                            int c = 0;
                            foreach (var item in dt.Rows[row].ItemArray)
                            {
                                rawData[row + 1, c] = item+"";
                                c++;
                            }
                            //var cell = (Range)excelSheet.Cells[row+1, col+1];
                            //cell.Value2 = dt.Rows[row].ItemArray[col];
                        }
                    }

                    // Calculate the final column letter
                    string finalColLetter = string.Empty;
                    string colCharset = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    int colCharsetLen = colCharset.Length;

                    if (dt.Columns.Count > 0)
                    {
                        if (dt.Columns.Count > colCharsetLen)
                        {
                            finalColLetter = colCharset.Substring(
                                (dt.Columns.Count - 1) / colCharsetLen - 1, 1);
                        }

                        finalColLetter += colCharset.Substring((dt.Columns.Count - 1) % colCharsetLen, 1);
                    }

                    //Fill data to worksheet
                    if (dt.Columns.Count > 0)
                    {
                        // Fast data export to Excel
                        string excelRange = string.Format("A1:{0}{1}",
                            finalColLetter, dt.Rows.Count + 1);
                        //excelSheet.get_Range((Range)(excelSheet.Cells[2, 1]), (Range)(excelSheet.Cells[dt.Rows.Count + 1, dt.Columns.Count])).Value = rawData;
                        

                      excelSheet.get_Range(excelRange, Type.Missing).Value2 = rawData;

                        // Do formatting worksheet if no template file
                    
                            // Mark the first row as BOLD
                            ((Microsoft.Office.Interop.Excel.Range)excelSheet.Rows[1, Type.Missing]).Font.Bold = true;
                            excelSheet.get_Range(string.Format("A1:{0}1", finalColLetter), Type.Missing).Interior.Color = System.Drawing.Color.Gainsboro.ToArgb();

                            excelSheet.get_Range(excelRange, Type.Missing).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            excelSheet.get_Range(excelRange, Type.Missing).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            excelSheet.get_Range(excelRange, Type.Missing).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            excelSheet.get_Range(excelRange, Type.Missing).Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            excelSheet.get_Range(excelRange, Type.Missing).Borders.Color = System.Drawing.Color.Black.ToArgb();
                            excelSheet.get_Range(excelRange, Type.Missing).Columns.AutoFit();

                            SetColumnFormatting(excelSheet, dt);
                      
                    }

                    // Thread sleep
                    System.Threading.Thread.Sleep(100);
                }

                //Delete default worksheet after out of create worksheet by datatable loop
              
                    ((Microsoft.Office.Interop.Excel.Worksheet)excelWorkbook.Worksheets["Sheet1"]).Delete();

                // Save and Close the Workbook
                excelWorkbook.SaveAs(outputPath, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                excelWorkbook.Close(true, Type.Missing, Type.Missing);
                excelWorkbook = null;

              
                // Release the Application object
                excelApp.Quit();
                excelApp = null;

                if (File.Exists(outputPath))
                {
                    Process.Start(outputPath);
                }

                // Collect the unreferenced objects
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            catch (Exception ex)
            {
                //System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
               
            }
        }
        public void ExportMultipleGridToOneExcel(DataTable dt)
        {
             DataSet ds=new DataSet();
            try
            {    
               
                ds.Tables.Add(dt);
               // string tempfileName =string.Format(@"{0}\{1}\{2}\{3}\", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), System.Windows.Forms.Application.CompanyName, System.Windows.Forms.Application.ProductName, "ExportXLSX");

                //if (!Directory.Exists(Path.GetDirectoryName(tempfileName)))
                //    Directory.CreateDirectory(Path.GetDirectoryName(tempfileName));

                if (ds != null)
                {
                       // tempfileName += string.Format("{0}_{1}.xlsx", "exportXLSX", Guid.NewGuid().ToString("N"));
                        ExportToExcel(ds);
                    //if (File.Exists(tempfileName))
                    //{
                    //    Process.Start(tempfileName);
                    //}
                }
            }
            catch (Exception ex)
            {
                //System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    ds.Clear();
                    ds.Dispose();
                    ds = null;
                }
            }
        }
        private string getHeaderBegin()
        {
            string sContent = "<?xml version='1.0' encoding='utf-8' standalone='yes'?>\r\n";
            sContent += "<?mso-application progid='Excel.Sheet'?>\r\n";
            sContent += "<s:Workbook xmlns:x=\"urn:schemas-microsoft-com:office:excel\" xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:s=\"urn:schemas-microsoft-com:office:spreadsheet\">";
            return sContent;
        }
        private string getHeaderEnd()
        {
            string sContent = "</s:Workbook>";
            return sContent;
        }

        private string getSheetBegin(string sheetName)
        {
            string sContent = "<s:Worksheet s:Name=\"{0}\">\r\n<s:Table>";
            sContent = string.Format(sContent, sheetName);
            return sContent;
        }

        private string getSheetEnd()
        {
            string sContent = "</s:Table></s:Worksheet>";
            return sContent;
        }

        private string getRow(List<string> data)
        {
            StringBuilder sbContent = new StringBuilder();
            sbContent.Append("<s:Row>");
            foreach (string sColVal in data)
            {
                string sContent = string.Format("<s:Cell><s:Data s:Type=\"String\">{0}</s:Data></s:Cell>", sColVal);
                sbContent.Append(sContent);
            }
            sbContent.Append("</s:Row>");
            return sbContent.ToString();
        }
        public void Export(DataSet dataSet, string fileName)
        {
            int pg = -1;
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.Read);
            StreamWriter wt = new StreamWriter(fs);

            wt.WriteLine(getHeaderBegin());

            foreach (DataTable dtb in dataSet.Tables)
            {
                pg = 0;
                int iRowCount = dtb.Rows.Count;
                wt.WriteLine(getSheetBegin(dtb.TableName));
                int iCurRow = 0;

                //Header columns
                List<string> lstHeader = new List<string>();
                foreach (DataColumn dc in dtb.Columns)
                {
                    lstHeader.Add(dc.ColumnName);
                }
                wt.WriteLine(getRow(lstHeader));

                //Data
                foreach (DataRow dr in dtb.Rows)
                {
                    List<string> lstRow = new List<string>();
                    foreach (DataColumn dc in dtb.Columns)
                    {
                        lstRow.Add(System.Security.SecurityElement.Escape(dr[dc].ToString()));
                    }

                    wt.WriteLine(getRow(lstRow));

                    int pgNew = Convert.ToInt32((iCurRow * 100) / iRowCount);

                    if (pg != pgNew)
                    {
                        pg = pgNew;
                      //  string sMsg = "Exporting table " + dtb.TableName + "." + Environment.NewLine + pg + "%";
                       // fireEvent(sMsg, pg);
                    }

                    wt.Flush();
                    iCurRow++;
                }

                wt.WriteLine(getSheetEnd());
                GC.Collect();

            }


            wt.WriteLine(getHeaderEnd());

            wt.Close();
            fs.Close();

            if (File.Exists(fileName))
            {
                Process.Start(fileName);
            }
        }

        public DataTable GetDataTableFromDGV(DataGridView dgv ,string sheetname)
        {
            var dt = new DataTable(sheetname);
            try
            {

            foreach (DataGridViewColumn column in dgv.Columns)
            {
               if (column.Visible)
               {
                    // You could potentially name the column based on the DGV column name (beware of dupes)
                    // or assign a type based on the data type of the data bound to this DGV column.
                   //if (column.Name.ToLower().Contains("bath") || column.Name.ToLower().Contains("fee") || column.Name.ToLower().Contains("price") || column.Name.ToLower().Contains("ราคา") || column.Name.ToLower().Contains("cash") || column.Name.ToLower().Contains("credit") || column.Name.ToLower().Contains("net") || column.Name.ToLower().Contains("total") || column.Name.ToLower().Contains("amount") || column.Name.ToLower().Contains("มูลค่า"))
                   if (column.Name.ToLower().Contains("จ่าย") || column.Name.ToLower().Contains("ลด") || column.Name.ToLower().Contains("pay") || column.Name.ToLower().Contains("bath") || column.Name.ToLower().Contains("fee") || column.Name.ToLower().Contains("price")
                              || column.Name.ToLower().Contains("ราคา") || column.Name.ToLower().Contains("cash") || column.Name.ToLower().Contains("รับ") || column.Name.ToLower().Contains("credit") || column.Name.ToLower().Contains("net") || column.Name.ToLower().Contains("total")
                              || column.Name.ToLower().Contains("ค่า") || column.Name.ToLower().Contains("amount") || column.Name.ToLower().Contains("มูลค่า") || column.Name.ToLower().Contains("เงิน") || column.Name.ToLower().Contains("ลำดับ"))
                   {
                       dt.Columns.Add(column.HeaderText, typeof(double));
                   }
                   //else if (column.Name.ToLower().Contains("date") || column.Name.ToLower().Contains("วัน"))
                   //    dt.Columns.Add(column.HeaderText, typeof(DateTime));
                   else
                       dt.Columns.Add(column.HeaderText, typeof(string));
                }
            }

            object[] cellValues = new object[dt.Columns.Count];
            foreach (DataGridViewRow row in dgv.Rows)
            {
                //for (int i = 0; i < row.Cells.Count; i++)
                DataRow dr = dt.NewRow();
                foreach (DataColumn c in dt.Columns)
                {
                    //if (dgv.Columns[c.ColumnName].Visible && (dt.Columns.Count - 1) >= i)
//                    {
                        if (dgv.Columns[c.ColumnName].Name.ToLower().Contains("bath") | dgv.Columns[c.ColumnName].Name.ToLower().Contains("fee") | dgv.Columns[c.ColumnName].Name.ToLower().Contains("price") | dgv.Columns[c.ColumnName].Name.ToLower().Contains("ราคา") | dgv.Columns[c.ColumnName].Name.ToLower().Contains("cash") 
                            | dgv.Columns[c.ColumnName].Name.ToLower().Contains("net") | dgv.Columns[c.ColumnName].Name.ToLower().Contains("total") | dgv.Columns[c.ColumnName].Name.ToLower().Contains("credit")
                            | dgv.Columns[c.ColumnName].Name.ToLower().Contains("amount") | dgv.Columns[c.ColumnName].Name.ToLower().Contains("มูลค่า")|
                            dgv.Columns[c.ColumnName].Name.ToLower().Contains("จ่าย") || dgv.Columns[c.ColumnName].Name.ToLower().Contains("ลด") || dgv.Columns[c.ColumnName].Name.ToLower().Contains("pay") || dgv.Columns[c.ColumnName].Name.ToLower().Contains("bath") || dgv.Columns[c.ColumnName].Name.ToLower().Contains("fee") || dgv.Columns[c.ColumnName].Name.ToLower().Contains("price")
                                || dgv.Columns[c.ColumnName].Name.ToLower().Contains("ราคา") || dgv.Columns[c.ColumnName].Name.ToLower().Contains("cash") || dgv.Columns[c.ColumnName].Name.ToLower().Contains("รับ") || dgv.Columns[c.ColumnName].Name.ToLower().Contains("credit") || dgv.Columns[c.ColumnName].Name.ToLower().Contains("net") || dgv.Columns[c.ColumnName].Name.ToLower().Contains("total")
                                || dgv.Columns[c.ColumnName].Name.ToLower().Contains("ค่า") || dgv.Columns[c.ColumnName].Name.ToLower().Contains("amount") || dgv.Columns[c.ColumnName].Name.ToLower().Contains("มูลค่า") || dgv.Columns[c.ColumnName].Name.ToLower().Contains("เงิน") || dgv.Columns[c.ColumnName].Name.ToLower().Contains("ลำดับ"))
                            try 
	                        {
                                dr[c.ColumnName] = (row.Cells[c.ColumnName].Value + "" == "" || row.Cells[c.ColumnName].Value + "" == "0" || row.Cells[c.ColumnName].Value + "" == "0.00") ? "0" : Convert.ToDecimal(row.Cells[c.ColumnName].Value).ToString("###,###,###,###.##");//row.Cells[i].Value+""==""?"0":
	                        }
	                        catch (Exception)
	                        {
                                dr[c.ColumnName] = row.Cells[c.ColumnName].Value + "";
	                        }
                            
                        //else if (dgv.Columns[c.ColumnName].Name.ToLower().Contains("date") || dgv.Columns[c.ColumnName].Name.ToLower().Contains("วัน"))
                        //    dr[c.ColumnName] = Convert.ToDateTime(row.Cells[c.ColumnName].Value + "");
                        else
                            dr[c.ColumnName] = row.Cells[c.ColumnName].Value + "";
                    //}
                }
                dt.Rows.Add(dr);
            }
            }
            catch (Exception)
            {

                
            }
            return dt;
        }
        public static DataTable CleanZeroText(DataTable dt)
        {
            foreach (DataRow item in dt.Rows)
            {
                foreach (DataColumn c in dt.Columns)
                {
                    if (item[c] + "" == "0") 
                        item[c] = DBNull.Value;
                }
            }
            return dt;
        }
        public void ExportUseCloseXML(DataSet dataSet, string fileName)
        {
            try
            {
                ClosedXML.Excel.XLWorkbook workbook = new ClosedXML.Excel.XLWorkbook();
                DataTable table = dataSet.Tables[0];
                workbook.Worksheets.Add(table);

                if (File.Exists(fileName))
                {
                    Process.Start(fileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
    
      
    
    
    
    }

    public class DataGridViewUtil
    {
        //static DataGridView dgvReturn;
        public static void LoopSumByColumn(DataGridView dgvData, bool excVat)
            {
                try
                {
                    if (dgvData.RowCount <= 1) return;
                   // dgvReturn = dgvData;
                    int columnTotalText = -1;
                    foreach (DataGridViewColumn column in dgvData.Columns)
                    {
                        if (column.Visible)
                        {
                            if (column.Name.ToLower().Contains("จ่าย") || column.Name.ToLower().Contains("ลด") || column.Name.ToLower().Contains("pay") || column.Name.ToLower().Contains("bath") || column.Name.ToLower().Contains("fee") || column.Name.ToLower().Contains("price") 
                                || column.Name.ToLower().Contains("ราคา") || column.Name.ToLower().Contains("cash")|| column.Name.ToLower().Contains("รับ") || column.Name.ToLower().Contains("credit") || column.Name.ToLower().Contains("net") || column.Name.ToLower().Contains("total")
                                || column.Name.ToLower().Contains("หัก") || column.Name.ToLower().Contains("ค่า") || column.Name.ToLower().Contains("amount") || column.Name.ToLower().Contains("มูลค่า") || column.Name.ToLower().Contains("เงิน") || column.Name.ToLower().Contains("ยอด")
                                || column.Name.ToLower().Contains("ชำระ") || column.Name.ToLower().Contains("จำนวน"))
                            {
                                TotalRow(column.Index, dgvData, excVat);
                                if (columnTotalText < 0)
                                    columnTotalText = column.Index - 1;
                            }

                        }
                    }
                    for (int i = columnTotalText; i >= 0; i--)
                    {
                        if (dgvData.Columns[columnTotalText].Visible)
                        {
                            if (excVat)
                            {
                                dgvData[columnTotalText, dgvData.RowCount - 2].Value = "Total";
                                dgvData[columnTotalText, dgvData.RowCount - 1].Value = "Exc.VAT";
                            }
                            else
                                dgvData[columnTotalText, dgvData.RowCount - 1].Value = "Total";
                        }
                        else columnTotalText--;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               // return dgvData;
            }
           static void TotalRow(int cindex, DataGridView dgvData,bool excVat)
            {
                try
                {
                    decimal sum = 0;

                    if (excVat)
                    {
                        if (dgvData.RowCount <= 2) return;
                    }
                    else
                    {
                        if (dgvData.RowCount <= 1) return;
                    }

                    //if (dgvData[cindex, dgvData.RowCount - 1].ValueType.Name== "Decimal")
                        //dgvData[cindex, dgvData.RowCount - 1].Value = 0;//sum.ToString("###,###,###.##");
                    //dgvData[0, dgvData.RowCount - 1].Value = "Total";
                    if (excVat)
                    {
                        dgvData[cindex, dgvData.RowCount - 1].Value = 0;
                        dgvData[cindex, dgvData.RowCount - 2].Value = 0;
                    }
                    else
                    {
                        dgvData[cindex, dgvData.RowCount - 1].Value = 0;
                    }

                    foreach (DataGridViewRow item in dgvData.Rows)
                    {
                        sum += item.Cells[cindex].Value + "" == "" ? 0 : Convert.ToDecimal(item.Cells[cindex].Value);
                    }

                    //DataRow dr = dtAll.NewRow();
                    //dgvData.Rows.Add(dr);

                    if (excVat)
                    {
                        if (dgvData.Columns[cindex].ValueType.ToString().ToLower().Contains("string"))
                        {
                            dgvData[cindex, dgvData.RowCount - 1].Value = "0";
                            dgvData[cindex, dgvData.RowCount - 2].Value = "0";
                            dgvData[cindex, dgvData.RowCount - 1].Value = ((sum * 100) / 107).ToString("###,###,###.##");
                            dgvData[cindex, dgvData.RowCount - 2].Value = sum.ToString("###,###,###,###.00");
                        }
                        else
                        {
                            dgvData[cindex, dgvData.RowCount - 1].Value = 0;
                            dgvData[cindex, dgvData.RowCount - 2].Value = 0;
                            dgvData[cindex, dgvData.RowCount - 1].Value = ((sum * 100) / 107);
                            dgvData[cindex, dgvData.RowCount - 2].Value = sum;
                        }
                    }
                    else
                    {
                        if (dgvData.Columns[cindex].ValueType.ToString().ToLower().Contains("string"))
                        {
                            dgvData[cindex, dgvData.RowCount - 1].Value = "0";
                            dgvData[cindex, dgvData.RowCount - 1].Value = sum.ToString("###,###,###,###.00");
                        }
                        else
                        {
                            dgvData[cindex, dgvData.RowCount - 1].Value = 0;
                            dgvData[cindex, dgvData.RowCount - 1].Value = sum;
                        }
                    }

                    //dgvData[1, dgvData.RowCount - 1].Value = "Total";

                    DataGridViewCellStyle style = new DataGridViewCellStyle();
                    style.Font = new Font(dgvData.Font, FontStyle.Bold);
                    dgvData.Rows[dgvData.Rows.Count - 1].DefaultCellStyle = style;
                    dgvData.Rows[dgvData.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Yellow;

                    if (excVat)
                    {
                        dgvData.Rows[dgvData.Rows.Count - 2].DefaultCellStyle = style;
                        dgvData.Rows[dgvData.Rows.Count - 2].DefaultCellStyle.BackColor = Color.Yellow;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
    }


    public class MyLabel : Label
    {
        public static Label Set(string Text = "", Font Font = null, Color ForeColor = new Color(), Color BackColor = new Color())
        {
            Label l = new Label();
            l.Text = Text;
            l.Font = (Font == null) ? new Font("Calibri", 12) : Font;
            l.ForeColor = (ForeColor == new Color()) ? Color.Black : ForeColor;
            l.BackColor = (BackColor == new Color()) ? SystemColors.Control : BackColor;
            l.AutoSize = true;
            return l;
        }
    }
    public class MyButton : Button
    {
        public static Button Set(string Text = "", int Width = 102, int Height = 30, Font Font = null, Color ForeColor = new Color(), Color BackColor = new Color())
        {
            Button b = new Button();
            b.Text = Text;
            b.Width = Width;
            b.Height = Height;
            b.Font = (Font == null) ? new Font("Calibri", 12) : Font;
            b.ForeColor = (ForeColor == new Color()) ? Color.Black : ForeColor;
            b.BackColor = (BackColor == new Color()) ? SystemColors.Control : BackColor;
            b.UseVisualStyleBackColor = (b.BackColor == SystemColors.Control);
            return b;
        }
    }
    public class MyImage : PictureBox
    {
        public static PictureBox Set(string ImagePath = null, int Width = 60, int Height = 60)
        {
            PictureBox i = new PictureBox();
            if (ImagePath != null)
            {
                i.BackgroundImageLayout = ImageLayout.Zoom;
                i.Location = new Point(9, 9);
                i.Margin = new Padding(3, 3, 2, 3);
                i.Size = new Size(Width, Height);
                i.TabStop = false;
                i.Visible = true;
                i.BackgroundImage = Image.FromFile(ImagePath);
            }
            else
            {
                i.Visible = true;
                i.Size = new Size(0, 0);
            }
            return i;
        }
    }
    public partial class MyMessageBox : Form
    {
        private MyMessageBox()
        {
            this.panText = new FlowLayoutPanel();
            this.panButtons = new FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // panText
            // 
            this.panText.Parent = this;
            this.panText.AutoScroll = true;
            this.panText.AutoSize = true;
            this.panText.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            //this.panText.Location = new Point(90, 90);
            this.panText.Margin = new Padding(0);
            this.panText.MaximumSize = new Size(500, 300);
            this.panText.MinimumSize = new Size(108, 50);
            this.panText.Size = new Size(108, 50);
            // 
            // panButtons
            // 
            this.panButtons.AutoSize = true;
            this.panButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.panButtons.FlowDirection = FlowDirection.RightToLeft;
            this.panButtons.Location = new Point(89, 89);
            this.panButtons.Margin = new Padding(0);
            this.panButtons.MaximumSize = new Size(580, 150);
            this.panButtons.MinimumSize = new Size(108, 0);
            this.panButtons.Size = new Size(108, 35);
            // 
            // MyMessageBox
            // 
            this.AutoScaleDimensions = new SizeF(8F, 19F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(206, 133);
            this.Controls.Add(this.panButtons);
            this.Controls.Add(this.panText);
            this.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Margin = new Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new Size(168, 132);
            this.Name = "MyMessageBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        public static string Show(Label Label, string Title = "", List<Button> Buttons = null, PictureBox Image = null)
        {
            List<Label> Labels = new List<Label>();
            Labels.Add(Label);
            return Show(Labels, Title, Buttons, Image);
        }
        public static string Show(string Label, string Title = "", List<Button> Buttons = null, PictureBox Image = null)
        {
            List<Label> Labels = new List<Label>();
            Labels.Add(MyLabel.Set(Label));
            return Show(Labels, Title, Buttons, Image);
        }
        public static string Show(List<Label> Labels = null, string Title = "", List<Button> Buttons = null, PictureBox Image = null)
        {
            if (Labels == null) Labels = new List<Label>();
            if (Labels.Count == 0) Labels.Add(MyLabel.Set(""));
            if (Buttons == null) Buttons = new List<Button>();
            if (Buttons.Count == 0) Buttons.Add(MyButton.Set("OK"));
            List<Button> buttons = new List<Button>(Buttons);
            buttons.Reverse();

            int ImageWidth = 0;
            int ImageHeight = 0;
            int LabelWidth = 0;
            int LabelHeight = 0;
            int ButtonWidth = 0;
            int ButtonHeight = 0;
            int TotalWidth = 0;
            int TotalHeight = 0;

            MyMessageBox mb = new MyMessageBox();

            mb.Text = Title;

            //Image
            if (Image != null)
            {
                mb.Controls.Add(Image);
                Image.MaximumSize = new Size(150, 300);
                ImageWidth = Image.Width + Image.Margin.Horizontal;
                ImageHeight = Image.Height + Image.Margin.Vertical;
            }

            //Labels
            List<int> il = new List<int>();
            mb.panText.Location = new Point(9 + ImageWidth, 9);
            foreach (Label l in Labels)
            {
                mb.panText.Controls.Add(l);
                l.Location = new Point(200, 50);
                l.MaximumSize = new Size(480, 2000);
                il.Add(l.Width);
            }
            int mw = Labels.Max(x => x.Width);
            il.ToString();
            Labels.ForEach(l => l.MinimumSize = new Size(Labels.Max(x => x.Width), 1));
            mb.panText.Height = Labels.Sum(l => l.Height);
            mb.panText.MinimumSize = new Size(Labels.Max(x => x.Width) + mb.ScrollBarWidth(Labels), ImageHeight);
            mb.panText.MaximumSize = new Size(Labels.Max(x => x.Width) + mb.ScrollBarWidth(Labels), 300);
            LabelWidth = mb.panText.Width;
            LabelHeight = mb.panText.Height;

            //Buttons
            foreach (Button b in buttons)
            {
                mb.panButtons.Controls.Add(b);
                b.Location = new Point(3, 3);
                b.TabIndex = Buttons.FindIndex(i => i.Text == b.Text);
                b.Click += new EventHandler(mb.Button_Click);
            }
            ButtonWidth = mb.panButtons.Width;
            ButtonHeight = mb.panButtons.Height;

            //Set Widths
            if (ButtonWidth > ImageWidth + LabelWidth)
            {
                Labels.ForEach(l => l.MinimumSize = new Size(ButtonWidth - ImageWidth - mb.ScrollBarWidth(Labels), 1));
                mb.panText.Height = Labels.Sum(l => l.Height);
                mb.panText.MinimumSize = new Size(Labels.Max(x => x.Width) + mb.ScrollBarWidth(Labels), ImageHeight);
                mb.panText.MaximumSize = new Size(Labels.Max(x => x.Width) + mb.ScrollBarWidth(Labels), 300);
                LabelWidth = mb.panText.Width;
                LabelHeight = mb.panText.Height;
            }
            TotalWidth = ImageWidth + LabelWidth;

            //Set Height
            TotalHeight = LabelHeight + ButtonHeight;

            mb.panButtons.Location = new Point(TotalWidth - ButtonWidth + 9, mb.panText.Location.Y + mb.panText.Height);

            mb.Size = new Size(TotalWidth + 25, TotalHeight + 47);
            mb.ShowDialog();
            return mb.Result;
        }

        private FlowLayoutPanel panText;
        private FlowLayoutPanel panButtons;
        private int ScrollBarWidth(List<Label> Labels)
        {
            return (Labels.Sum(l => l.Height) > 300) ? 23 : 6;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Result = ((Button)sender).Text;
            Close();
        }

        private string Result = "";
    }
    public class CustomSearcherFolder
    {
        static List<string> lsDirectory = new List<string>();
        public static List<string> GetDirectories(string path, string searchPattern = "*",
            SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            if (searchOption == SearchOption.TopDirectoryOnly)
                return Directory.GetDirectories(path, searchPattern).ToList();

            var directories = new List<string>(GetDirectories(path, searchPattern));

            for (var i = 0; i < directories.Count; i++)
                directories.AddRange(GetDirectories(directories[i], searchPattern));

            return directories;
        }

        private static List<string> GetDirectories(string path, string searchPattern)
        {
            try
            {
                return Directory.GetDirectories(path, searchPattern).ToList();
            }
            catch (UnauthorizedAccessException)
            {
                return new List<string>();
            }
        }

        public static List<string> ListDirec(string path, int start, int end)
        {
            var dirInfo = new DirectoryInfo(path);
            var folders = dirInfo.GetDirectories().ToList();

            foreach (var item in folders)
            {
                //Console.WriteLine("".PadLeft(start * 4, ' ') + item.Name);
                lsDirectory.Add(item.FullName);
                if (start < end)
                    ListDirec(item.FullName, start + 1, end);
            }
            return lsDirectory;
        }
    }
   
}   
