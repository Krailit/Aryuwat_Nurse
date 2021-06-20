using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AryuwatSystem.Forms;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32;
using System.Data;
using AryuwatSystem.Forms.FRMReport;

namespace AryuwatSystem.DerClass
{
    public static class Statics
    {
        public static Color ColorForm = Color.FromArgb(240, 240, 240);
        public static Color ColorTo = Color.FromArgb(240, 240, 240);
        #region Variable Form
        public static FrmMain frmMain = null;


        public static FrmCustomerConnectList frmCustomerConnectList = null;
        public static FrmCustomerList frmCustomerList  = null;
        public static FrmCustomerSetting frmCustormerSetting = null;
        public static FrmPersonnelSetting frmPersonnelSetting = null;
        public static FrmPersonnelList frmPersonnelList = null;
        public static FrmWebCapture frmWebCapture = null;
        public static FrmMedicalOrderList frmMedicalOrderList = null;
        public static FrmMedicalOrderSetting frmMedicalOrderSetting = null;
        public static FrmMedicalOrderSettingPaper frmMedicalOrderSettingPaper = null;
        
        public static FrmMedicalOrderSettingPro frmMedicalOrderSettingPro = null;
        public static FrmDoctorMedicalOrder frmDoctorMedicalOrder = null;
        public static FrmMedicalOrderPaperList frmMedicalOrderPaperList = null;
        
        
        public static FrmMedicalOrderSettingProCredit frmMedicalOrderSettingProCredit = null;
        public static FrmMedicalSupplies frmMedicalSupplies = null;
        public static FrmMedicalSuppliesStock frmMedicalSuppliesStock = null;

        public static FrmEditREQ frmEditREQ = null; 
        public static FrmSurgicalFeeList frmSurgicalFeeList = null;
        public static popRFDList poprfdList = null;
        public static PopDateTime popDateTime = null;
        public static FrmSOTList frmSOFList = null;
        public static FrmSOTByPerson frmSOTByPerson = null;

        public static FrmSurgicalFee frmSurgicalFee = null;
        public static UcSurgicalFee ucSurgicalFee = null;
        public static FrmSumOfTreatment frmSumOfTreatment = null;
        public static FrmSurgicalFeeMain frmSurgicalFeeMain = null;
        public static FrmPaidSelectSOT frmPaidSelectSOT = null;

        public static FrmBookingRoom bookingroom = null;
        public static FrmDoctorSchedule frmDoctorSchedule = null;
        public static FrmBookingDoctor bookingDoctor = null;
        public static PopBookingAdd popbookingAdd = null;
        public static PopBookingDoctorAdd popBookingDoctorAdd = null;
        
        public static FrmSetPermission frmSetPermission = null;
        public static FrmUserGroupList frmUserGroupList = null;
        public static FrmAgencySetting frmAgencySetting = null;
        public static PopAgencySearch popAgencySearch = null;
        public static FrmPromotionSetting frmPromotionSetting = null;
        public static FrmPromotionMMSetting frmPromotionMMSetting = null;
        public static FrmPromotionList frmPromotionList = null;
        public static FrmRoomList frmRoomList = null;
        public static FrmRoomSetting frmRoomSetting = null;
        public static FrmCommonReport frmCommonReport = null;
        public static FrmCommonReportOR frmCommonReportOR = null;
        public static FrmCommonReportAE_Month frmCommonReportAE_Month = null;
        public static FrmCommonReportWE_Month frmCommonReportWE_Month = null;
        
        public static FrmCommissionHeadCheck frmCommissionHeadCheck = null;
        public static FrmCommissionDoctorCheck frmCommissionDoctorCheck = null;
        public static FrmFollowCust frmFollowCust = null;
        public static FrmVoucher frmVoucher = null;

        public static FrmCommonStock frmCommonStock = null;
        
        
        public static FrmCommissionCheck frmCommissionCheck = null;
        
        
        public static FrmCommonReportSale frmCommonReportSale = null;
        public static FrmCommonReportAEWE frmCommonReportAEWE = null;
        public static FrmCommonReportSaleFollow frmCommonReportSaleFollow = null;
        public static FrmCommonReportSaleOutStanding frmCommonReportSaleOutStanding = null;
        
        public static FrmCommonReportSaleResult frmCommonReportSaleResult = null;
        public static FrmCommonReportMK_SumByDepart frmCommonReportMK_SumByDepart = null;
        public static FrmSystemLog frmSystemLog = null;
        public static FrmEnAndDeCode frmEnAndDeCode = null;
        public static FrmSetGroupReportSEO frmSetGroupReportSEO = null;

        public static FrmReportStockIn_Out frmReportStockIn_Out = null;
        public static FrmReportAE_Fee_Year frmReportAE_Fee_Year = null;

        public static popGetInventory _popGetInventory = null;
        public static popSellInventory _popSellInventory = null;
        public static popREQInventory popREQInventory = null;
        public static popReplyInventory popReplyInventory = null;
        public static popREQSupplies popreqSupplies = null;
        public static popReplySupplies popreplySupplies = null;
        

        public static FrmStockHistory frmStockHistory = null;
        public static FrmReportAcc frmReportAcc = null;
        public static FrmReportMarketing frmReportMarketing = null;
        public static FrmReportHR_Fee_Month_Year frmReportHR_Fee_Month_Year = null;
        public static FrmReportSaleList frmReportSaleList = null;
        public static FrmCommonReportSaleResultByCN frmCommonReportSaleResultByCN = null;
        public static FrmBOMList frmBOMList = null;
        public static PopBOMMaterialSearch popBOMMaterialSearch = null;
        public static FrmHRCommissionCheck frmHRCommissionCheck = null;

        public static FrmFreeGiftVoucher frmFreeGiftVoucher = null;
        
        public static FrmFreeComplication frmFreeComplication = null;
        public static FrmFreeMarketing frmFreeMarketing = null;

        public static FrmSubjectTraining frmSubjectTraining = null;
        public static FrmFreeBarterVat frmFreeBarterVat = null;
        public static FrmFreeBenefits frmFreeBenefits = null;

        public static FrmCheckCourseList frmCheckCourseList = null;

        public static FrmServiceReq frmServiceReq = null;

        
        

        
        
        
        

        
        
        
        

        

        
        
        
        
        

        
        
        
        
        
        
        
        
        public static FrmMain fmain = null;
        //public static FrmInventoryPricing frmInventoryPricing = null;
        //public static FrmOrganizedMedicine frmOrganizedMedicine = null;
        //public static FrmProgramPackageHealCheckDetail  frmProgramPackageHealCheckDetail = null;
        //public static FrmProgramPackageVaccineDetail frmProgramPackageVaccineDetail = null;
        //public static FrmInventorySettingGroup frmInventorySettingGroup = null;


        #endregion


        public static string EN  = "";
        #region  Toolbar Displaying
        /// <summary>
        /// กำหนดการใช้งานปุ่มต่างๆ ให้ Enable เป็น true, false
        /// </summary>
        /// <param name="btnNew">ปุ่ม New</param>
        /// <param name="btnEdit">ปุ่ม Edit</param>
        /// <param name="btnDelete">ปุ่ม Delete</param>
        /// <param name="btnPrint">ปุ่ม Print</param>
        /// <param name="btnRefresh">ปุ่ม Refresh</param>
        ///  
        public static void SetToolbar(bool blNew, bool blEdit, bool blDelete, bool blPrint, bool blRefresh)
        {
            frmMain.btnNew.Enabled = blNew;
            //if (blNew)
            //{
            //    frmMain.btnNew.Image = global::AryuwatSystem.Properties.Resources.reminders_and_recalls_128__2_ss_Red;
            //}
            //else frmMain.btnNew.Image = global::AryuwatSystem.Properties.Resources.reminders_and_recalls_128__2_ss;
            frmMain.btnEdit.Enabled = blEdit;
            frmMain.btnDelete.Enabled = blDelete;
            frmMain.btnPrint.Enabled = blPrint;
            frmMain.btnRefresh.Enabled = blRefresh;
            //FrmMain.Instance.btnExit.Enabled = blExit;
            //FrmMain.Instance.btnHelp.Enabled = blHelp;
        }



        #endregion

        public const string StrNewRow = "=== แสดงทั้งหมด ===";
        public const string StrValidate = "===โปรดระบุ ===";
        //public const string StrPlease = "===โปรดระบุ===";
        public const string StrEmpty = "===ไม่ระบุ===";
        public const string StrPleaseOk = "===ระบุ===";
        public const string StrShowRow = "===แสดงข้อมูลทั้งหมด===";
        public const string StrMsgInsertComplete = "บันทึกข้อมูลเรียบร้อยแล้ว \"Saved\"";
        public const string StrMsgUpdateComplete = "แก้ไขข้อมูลเรียบร้อยแล้ว \"Saved\"";
        public const string StrMsgDeleteComplete = "ลบข้อมูลเรียบร้อยแล้ว \"Deleted.\"";
        public const string StrConfirmDelete = "ยืนยันการลบข้อมูล \"Confirm Delete ?\"";
        public const string StrConfirm = "ยืนยันการบันทึกข้อมูล \"Confirm Save ?\"";
        public const string StrMsgDeleteError = "เกิดข้อผิดพลาดในการลบข้อมูล เนื่องจาก \"Delete Error\"";
        public const string StrMsgCannotSave = "ไม่สามารถบันทึกข้อมูลได้ เนื่องจาก \"Cannot Save\"";
        //public const string StrMsgConnotInsert = "เกิดข้อผิดพลาดในการบันทึกข้อมูล ";
        public const string StrMsgInput = "กรุณาระบุ  ";
        public const string StrMsgPleaseSelect = "---กรุณาเลือก---";
        public const string StrMsgOther = "=== อื่น ๆ===";
        public const string StrEdit = "สถานะ [แก้ไข]";
        public const string StrAdd = "สถานะ [เพิ่ม]";
        public const string StrPreview = "สถานะ [แสดงข้อมูล]";
        public const string strConfirmCloseForm = "ยังไม่มีการบันทึกข้อมูล ต้องการกลับไปบันทึกข้อมูลหรือไม่ ? \"No record\"";
        //public const string StrEmployeeID="";
        public static string StrEmployeeID = "";
        public static string StrGroupId = "";
        public static string GroupPermission = "";
        public static string StrRoomID = "";
        public static string StrRoomName = "";
        public const string StrPersonID = "PS52070001";
        public const string StrFullNameID="";
        public static string StrFullName = "";
        public static string EncryptDecrypt_key = "&%#@?,:*";//EncryptText//DecryptText
        //public static Entity.TBLCMPConfig InfoConfig;
        public static string SaveComplete= "บันทึกข้อมูลเรียบร้อยแล้ว\nSave Complete";
        public static string OverProCredit = "เกินวงเงินโปรโมชั่น ต้องการเลือกรายการนี้หรือไม่\nOver Credit,Confirm Add.";
        public static void Application_AcquireRequestState()
        {

            string culture = "en-US";
            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo(culture);
            System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;
            System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;

        } 

        #region DataDic
        public class EmployeeSearchCondition
        {
            

        }

        #endregion
        public enum CallMode
        {
            Insert,
            Update,
            Preview,
            Ref
        }
        public class clsWebCamArgs : EventArgs
        {
            private System.Drawing.Image m_Image;
            private ulong m_FrameNumber = 0;

            public clsWebCamArgs() { }

            public System.Drawing.Image WebCamImage
            {
                get { return m_Image; }
                set { m_Image = value; }
            }

            public ulong FrameNumber
            {
                get { return m_FrameNumber; }
                set { m_FrameNumber = value; }
            }
        }
     public   class ListViewComparer : IComparer
        {

            private int m_ColumnNumber;
            private SortOrder m_SortOrder;

            public ListViewComparer(int column_number, SortOrder sort_order)
            {
                m_ColumnNumber = column_number;
                m_SortOrder = sort_order;
            }
 
            // Compare the items in the appropriate column
            // for objects x and y.
            public int Compare(object x, object y)
            {
                ListViewItem item_x = (ListViewItem)x;
                ListViewItem item_y = (ListViewItem)y;

                // Get the sub-item values.
                string string_x = null;
                if (item_x.SubItems.Count <= m_ColumnNumber)
                {
                    string_x = "";
                }
                else
                {
                    string_x = item_x.SubItems[m_ColumnNumber].Text;
                }

                string string_y = null;
                if (item_y.SubItems.Count <= m_ColumnNumber)
                {
                    string_y = "";
                }
                else
                {
                    string_y = item_y.SubItems[m_ColumnNumber].Text;
                }

                // Compare them.
                if (m_SortOrder == SortOrder.Ascending)
                {
                    if (DerUtility.IsNumeric(string_x) && DerUtility.IsNumeric(string_y))
                    {
                        return Convert.ToDouble(string_x).CompareTo(Convert.ToDouble(string_y));
                    }
                    else if (DerUtility.IsDate(string_x) && DerUtility.IsDate(string_y))
                    {
                        return DateTime.Parse(string_x).CompareTo(DateTime.Parse(string_y));
                    }
                    else
                    {
                        return string.Compare(string_x, string_y);
                    }
                }
                else
                {
                    if (DerUtility.IsNumeric(string_x) && DerUtility.IsNumeric(string_y))
                    {
                        return Convert.ToDouble(string_y).CompareTo(Convert.ToDouble(string_x));
                    }
                    else if (DerUtility.IsDate(string_x) && DerUtility.IsDate(string_y))
                    {
                        return DateTime.Parse(string_y).CompareTo(DateTime.Parse(string_x));
                    }
                    else
                    {
                        return string.Compare(string_y, string_x);
                    }
                }

            }

            
        }
     public static string GetDateRegoin()
     {
         string re = "";
         try
         {
             
               using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\International"))
                {
                    if (key != null)
                    {
                        Object o = key.GetValue("iCalendarType");
                        if (o != null)
                        {
                            re = o.ToString();
                        }
                    }
                }
         }
         catch (Exception ex)
         {
             
         }
         return re;
     }
        public static void setPicture(PictureBox sPictureBox, string sLocation)
        {
            try
            {
                sPictureBox.Image = Image.FromFile(sLocation);
                FileInfo fiImage = new FileInfo(sLocation);
                DerUtility.sImageFileLength = fiImage.Length;
                FileStream fs = new FileStream(sLocation, FileMode.Open, FileAccess.Read, FileShare.Read);
                DerUtility.sBarrImg = new byte[Convert.ToInt32(DerUtility.sImageFileLength)];
                int iBytesRead = fs.Read(DerUtility.sBarrImg, 0, Convert.ToInt32(DerUtility.sImageFileLength));
                fs.Close();
            }
            catch (Exception ex) { }
        }
        public static void setCreateFile(PictureBox sPictureBox, string sFile, string sLocation)
        {
            try { if (File.Exists(sLocation + sFile) == false) { sPictureBox.Image.Save(sLocation + "\\" + sFile); } }
            catch (Exception ex) { }
        }

        public static void setRemoveFile(string sFile, string sLocation)
        {
            try { if (File.Exists(sLocation + sFile) == true) { File.Delete(sLocation + sFile); } }
            catch (Exception ex) { }
        }

        public static Dictionary<string, string> DistinctColumn(DataTable dt,string column)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            return dic;
        }
  
    }
}