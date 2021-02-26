using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DermasterSystem.Class;
using DermasterSystem.Properties;
using Entity;

namespace DermasterSystem.Forms
{
    public partial class FrmLogin : Form
    {   
        public FrmLogin()
        {
            InitializeComponent();
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
                       
                    }
                    getConfig();
                    getUnit();
                    getMoConfig();
                    Entity.Userinfo.Login = true;
                    Close();

                }
                else
                {
                    Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "\"ชื่อผู้ใช้หรือรหัสผ่านไม่ถูกต้อง\" กรุณาตรวจสอบอีกครั้ง" );
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //Close();
            }
        }
        private void FrmLogin_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                login();
            else Utility.SendKey(e.KeyChar);
          
        }

        private void FrmLogin_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
          
        }
    }
}
