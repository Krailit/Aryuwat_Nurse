using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AryuwatSystem.DerClass;
using AryuwatSystem.Properties;
using Entity;
using System.Net;
using System.Net.Sockets;

namespace AryuwatSystem.Forms
{
    public partial class FrmLogin : Form
    {   
        public FrmLogin()
        {
            InitializeComponent();
            //txtUsername.Text = "admin";
            //txtPassWord.Text = "1234";
        }

        private void cmdLogin_MouseLeave(object sender, EventArgs e)
        {
            cmdLogin.Image = Resources.ok_256;
        }

        private void cmdLogin_MouseMove(object sender, MouseEventArgs e)
        {
            cmdLogin.Image = Resources.ok_256_Black;
        }

        private void cmdExit_MouseLeave(object sender, EventArgs e)
        {
            cmdExit.Image = Resources.x_256;
        }

        private void cmdExit_MouseMove(object sender, MouseEventArgs e)
        {
            cmdExit.Image = Resources.x_256_Black;
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            login();

        }
        private void getConfig()
        {
            try
            {
                DataTable dt = new Business.Personnel().getConfig();
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["ConFName"] + "".ToUpper() == "REFRESHDATA")
                        Entity.Userinfo.RefreshData = dr["ConFName"] + "" == "" ? 1000 : Convert.ToInt32(dr["values"] + "");
                    if (dr["ConFName"] + "".ToUpper() == "PRICE_AGENCY")
                        Entity.Userinfo.PriceAgency = dr["values"] + "";
                    if (dr["ConFName"] + "".ToUpper() == "PRICE_NORMAL")
                        Entity.Userinfo.PriceNormal = dr["values"] + "";
                    if (dr["ConFName"] + "".ToUpper() == "IS_ADMIN")
                        Entity.Userinfo.IsAdmin = dr["values"] + "";
                    if (dr["ConFName"] + "".ToUpper() == "AGENCY_RATE")
                        Entity.Userinfo.AGENCY_RATE =Convert.ToDouble(dr["values"] + "");
                    if (dr["ConFName"] + "".ToUpper() == "IS_ADMIN_BOOKING")
                        Entity.Userinfo.IS_ADMIN_BOOKING =dr["values"] + "";
                    if (dr["ConFName"] + "".ToUpper() == "IS_ADMIN_JOBCOST")
                        Entity.Userinfo.IS_ADMIN_JOBCOST = dr["values"] + "";
                    if (dr["ConFName"] + "".ToUpper() == "VATRATE")
                        Entity.Userinfo.VatRate = Convert.ToDouble(dr["values"] + "");
                    if (dr["ConFName"] + "".ToUpper() == "COM_PRODUCT_RATE")
                        Entity.Userinfo.COM_PRODUCT_RATE = Convert.ToDouble(dr["values"] + "");
                    if (dr["ConFName"] + "".ToUpper() == "COM_REFERRAL_RATE")
                        Entity.Userinfo.COM_REFERRAL_RATE = Convert.ToDouble(dr["values"] + "");
                    if (dr["ConFName"] + "".ToUpper() == "IS_ADMIN_DISCOUNT")
                        Entity.Userinfo.IS_ADMIN_DISCOUNT = dr["values"] + "";
                    if (dr["ConFName"] + "".ToUpper() == "IS_ADMIN_COURSECARD")
                        Entity.Userinfo.IS_ADMIN_COURSECARD = dr["values"] + "";
                    if (dr["ConFName"] + "".ToUpper() == "MK_DISCOUNT_JOBCOST")
                        Entity.Userinfo.MK_DISCOUNT_JOBCOST = Convert.ToDouble(dr["values"] + "");
                    if (dr["ConFName"] + "".ToUpper() == "DIS_FOREING_RATE")
                        Entity.Userinfo.DIS_FOREING_RATE = Convert.ToDouble(dr["values"] + "");
                    if (dr["ConFName"] + "".ToUpper() == "FIX_COOL")
                        Entity.Userinfo.FIX_COOL = (dr["values"] + "").ToUpper();
                    if (dr["ConFName"] + "".ToUpper() == "FIX_OTHER_SUB")
                        Entity.Userinfo.FIX_OTHER_SUB = (dr["values"] + "").ToUpper();
                    if (dr["ConFName"] + "".ToUpper() == "FIX_COUPON_Wallet")
                        Entity.Userinfo.FIX_COUPON_Wallet = (dr["values"] + "").ToUpper();
                    if (dr["ConFName"] + "".ToUpper() == "FIX_COUPON_TOPUP")
                        Entity.Userinfo.FIX_COUPON_TOPUP = Convert.ToDecimal(dr["values"] + "");
                    if (dr["ConFName"] + "".ToUpper() == "FIX_DR_ROOM_CODE")
                        Entity.Userinfo.FIX_DR_ROOM_CODE = (dr["values"] + "").ToUpper();
                    if (dr["ConFName"] + "".ToUpper() == "FIX_DR_ROOM_CODE1")
                        Entity.Userinfo.FIX_DR_ROOM_CODE1 = (dr["values"] + "").ToUpper();
                    if (dr["ConFName"] + "".ToUpper() == "FIX_DR_ROOM_RATE")
                        Entity.Userinfo.FIX_DR_ROOM_RATE = Convert.ToDecimal(dr["values"] + "");
                    if (dr["ConFName"] + "".ToUpper() == "FIX_DR_ROOM_RATE1")
                        Entity.Userinfo.FIX_DR_ROOM_RATE1 = Convert.ToDecimal(dr["values"] + "");
                    if (dr["ConFName"] + "".ToUpper() == "FIX_PRO_TOPUP5")
                        Entity.Userinfo.FIX_PRO_TOPUP5 = (dr["values"] + "").ToUpper();
                    if (dr["ConFName"] + "".ToUpper() == "FIX_Contains_BUFFET")
                        Entity.Userinfo.FIX_Contains_BUFFET = (dr["values"] + "").ToUpper();
                    if (dr["ConFName"] + "".ToUpper() == "RFD_APPROVED")
                        Entity.Userinfo.RFD_APPROVED = (dr["values"] + "").ToUpper();
                    if (dr["ConFName"] + "".ToUpper() == "FIX_BENEFITS")
                        Entity.Userinfo.FIX_BENEFITS = (dr["values"] + "").ToUpper();
                    if (dr["ConFName"] + "".ToUpper() == "FIX_VOUCHEROK")
                        Entity.Userinfo.FIX_VOUCHEROK = (dr["values"] + "").ToUpper();
                    if (dr["ConFName"] + "".ToUpper() == "IS_ADMIN_EDIT")
                        Entity.Userinfo.IS_ADMIN_EDIT = (dr["values"] + "").ToUpper();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void getUnit()
        {
            try
            {
                Entity.Userinfo.UnitName = new Business.Personnel().getUnit();
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void getMoConfig()
        {
            try
            {
                Entity.Userinfo.MoConfig = new Business.Personnel().getMoConfig();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void login()
        {
            try
            {
                Entity.Personnel info = new Personnel();
                info.Username = txtUsername.Text.Trim();
                info.QueryType = "SELECTBYUSERNAME";
                info.Passwords = txtPassWord.Text.Trim();// EncryptDecrypText.encryptPassword(txtPassWord.Text.Trim());
               
                
                DataTable dt = new Business.Personnel().GetPersonnelByUserName(info).Tables[0];
                
                if (dt != null && dt.Rows.Count > 0)
                {
                    Statics.StrGroupId = dt.Rows[0]["UserGroup"] + "";
                    Statics.GroupPermission = dt.Rows[0]["Menu"] + "";

                    //Statics.StrEmployeeID = txtUsername.Text; // "EM52070001";
                    Statics.StrFullName = dt.Rows[0]["TName"] + " " + dt.Rows[0]["TSurname"];
                    foreach (DataRow dr in dt.Rows)
                    {
                        Entity.Userinfo.EN = dr["EN"].ToString();
                        Entity.Userinfo.TName = dr["Tname"].ToString();
                        Entity.Userinfo.TSurname = dr["TSurname"].ToString();
                        Entity.Userinfo.UserGroup = dr["UserGroup"].ToString();
                        Entity.Userinfo.Username = dr["Username"].ToString();
                        Entity.Userinfo.BranchId = dr["BranchId"].ToString().Trim();
                        Entity.Userinfo.BranchAuth = dr["BranchAuth"].ToString();
                        Entity.Userinfo.PersonnelType = dr["PersonnelType"].ToString();
                    }
                    getConfig();
                    getUnit();
                    getMoConfig();
                    Entity.Userinfo.Login = true;
                    //GetLocalIPAddress();
                    if (Entity.Userinfo.notiminimum)
                    {
                        //CHECKMINSTOCK
                        var ds = new Business.MedicalSupplies().CheckMinStock();
                        int countcheckminstock = 0;
                        try
                        {
                            countcheckminstock = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                        }
                        catch
                        {

                        }
                        if (countcheckminstock > 0)
                        {
                            PopAlertMedicalSuppliesStock popAlertMedicalSuppliesStock = new PopAlertMedicalSuppliesStock();
                            popAlertMedicalSuppliesStock.ShowDialog();
                        }
                    }
                    Close();

                }
                else
                {
                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "- ชื่อผู้ใช้หรือรหัสผ่านไม่ถูกต้อง"+Environment.NewLine+"- ชื่อผู้ใช้ อาจจะถูกระงับ"+Environment.NewLine + "กรุณาตรวจสอบอีกครั้ง" );
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //Close();
            }
        }
        //public static IPAddress GetLocalIPAddress()
        //{
        //    var host = Dns.GetHostEntry(Dns.GetHostName());
        //    var ipAddress = host.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
        //    return ipAddress;
        //}
        private void FrmLogin_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                login();
            else DerUtility.SendKey(e.KeyChar);
          
        }

        private void FrmLogin_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
          
        }
    }
}
