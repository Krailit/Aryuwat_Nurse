using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AryuwatSystem.DerClass;
using AryuwatSystem.Properties;
using System.Diagnostics;
using Microsoft.Win32;
using WeifenLuo.WinFormsUI.Docking;
using System.Runtime.InteropServices;
using AryuwatSystem.Forms.FRMReport;
using System.Configuration;

namespace AryuwatSystem.Forms
{
    public partial class FrmMain : Form
    {


        public FrmMain()
        {
            InitializeComponent();
            #region Add Event MenuItems

            menuBar1.cmdMaximize.MouseLeave += CmdMaximizeMouseLeave;
            menuBar1.cmdMaximize.MouseMove += CmdMaximizeMouseMove;
            menuBar1.cmdMinimize.Click += CmdMinimizeClick;
            menuBar1.cmdClose.Click += CmdCloseClick;
            menuBar1.cmdMaximize.Click += CmdMaximizeClick;
            btnNew.MouseMove += BtnNewMouseMove;
            btnNew.MouseLeave += BtnNewMouseLeave;
            btnEdit.MouseMove += BtnEditMouseMove;
            btnDelete.MouseMove += BtnDeleteMouseMove;
            btnDelete.MouseLeave += BtnDeleteMouseLeave;
            btnRefresh.MouseMove += BtnRefreshMouseMove;
            btnRefresh.MouseLeave += BtnRefreshMouseLeave;
            btnPrint.MouseMove += BtnPrintMouseMove;
            btnPrint.MouseLeave += BtnPrintMouseLeave;
            btnPrint.MouseMove += BtnPrintMouseMove;
            btnCustHist.MouseMove += BtnCustHistMouseMove;
            btnCustHist.MouseLeave += BtnCustHistMouseLeave;
            btnMedicalOrder.MouseMove += BtnMedicalOrderMouseMove;
            btnMedicalOrder.MouseLeave += BtnMedicalOrderMouseLeave;
            btnCashier.MouseMove += BtnCashierMouseMove;
            btnCashier.MouseLeave += BtnCashierMouseLeave;
            btnAppointment.MouseMove += BtnAppointmentMouseMove;
            btnAppointment.MouseLeave += BtnAppointmentMouseLeave;
            btnSurgicalFee.MouseMove += btnSurgicalFeeMouseMove;
            btnSurgicalFee.MouseLeave += btnSurgicalFeeMouseLeave;
            #endregion
        }
        #region MethodEvent
        private void BtnNewMouseLeave(object sender, EventArgs e)
        {
            btnNew.Image = Resources.reminders_and_recalls_128__2_ss;
        }

        private void BtnNewMouseMove(object sender, MouseEventArgs e)
        {
            btnNew.Image = Resources.reminders_and_recalls_128__2_ss_Red;
        }

        private void BtnEditMouseLeave(object sender, EventArgs e)
        {
            btnEdit.Image = Resources.history_256ss;
        }

        private void BtnEditMouseMove(object sender, MouseEventArgs e)
        {
            btnEdit.Image = Resources.history_256ss_Red;
        }

        private void BtnPrintMouseMove(object sender, MouseEventArgs e)
        {
            btnPrint.Image = Resources.FIFA_World_Cup_040sss_Red;
        }

        private void BtnPrintMouseLeave(object sender, EventArgs e)
        {
            //btnPrint.Image = Resources.FIFA_World_Cup_040sss;
        }

        private void BtnRefreshMouseLeave(object sender, EventArgs e)
        {
            btnRefresh.Image = Resources.reload_256ssss;
        }

        private void BtnRefreshMouseMove(object sender, MouseEventArgs e)
        {
            btnRefresh.Image = Resources.reload_256ssss_Red;
        }

        private void BtnDeleteMouseLeave(object sender, EventArgs e)
        {
            btnDelete.Image = Resources.FIFA_World_Cup_097ssss;
        }

        private void BtnDeleteMouseMove(object sender, MouseEventArgs e)
        {
            btnDelete.Image = Resources.FIFA_World_Cup_097ssss_Red;
        }

        private void BtnCustHistMouseLeave(object sender, EventArgs e)
        {
            btnCustHist.Image = Resources.medical_history_128;
        }

        private void BtnCustHistMouseMove(object sender, MouseEventArgs e)
        {
            btnCustHist.Image = Resources.medical_history_128_Red;
        }

        private void BtnMedicalOrderMouseLeave(object sender, EventArgs e)
        {
            btnMedicalOrder.Image = Resources.Stethoscope_Blackssss;
        }

        private void BtnMedicalOrderMouseMove(object sender, MouseEventArgs e)
        {
            btnMedicalOrder.Image = Resources.Stethoscope_Blackssss_Red;
        }

        private void BtnCashierMouseLeave(object sender, EventArgs e)
        {
            btnCashier.Image = Resources.payment_256;
        }

        private void BtnCashierMouseMove(object sender, MouseEventArgs e)
        {
            btnCashier.Image = Resources.payment_256_Red;
        }

        private void BtnAppointmentMouseLeave(object sender, EventArgs e)
        {
            btnAppointment.Image = Resources.calendar_year_256;
        }

        private void BtnAppointmentMouseMove(object sender, MouseEventArgs e)
        {
            btnAppointment.Image = Resources.calendar_year_256_Red;
        }

        private void btnSurgicalFeeMouseLeave(object sender, EventArgs e)
        {
            btnSurgicalFee.Image = Resources.MoneyBagC;
        }

        private void btnSurgicalFeeMouseMove(object sender, MouseEventArgs e)
        {
            btnSurgicalFee.Image = Resources.MoneyBagB;
        }

        private void CmdCloseClick(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }

        private void CmdMaximizeClick(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                menuBar1.cmdMaximize.Image = Resources.Minimizebox;
            }
            else
            {
                menuBar1.cmdMaximize.Image = Resources.NormalStat;
                WindowState = FormWindowState.Maximized;
            }
        }

        private void CmdMinimizeClick(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void CmdMaximizeMouseMove(object sender, MouseEventArgs e)
        {
            menuBar1.cmdMaximize.Image = WindowState == FormWindowState.Maximized
                                                   ? Resources.NormalStat_Drak
                                                   : Resources.Minimizebox_Drak;
        }

        private void CmdMaximizeMouseLeave(object sender, EventArgs e)
        {
            menuBar1.cmdMaximize.Image = WindowState == FormWindowState.Maximized
                                                   ? Resources.NormalStat
                                                   : Resources.Minimizebox;
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            SetNew();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SetSave();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            SetEdit();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            SetDelete();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            SetRefresh();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            SetPrint();
        }
        #endregion
        #region Interface Function

        private void SetNew()
        {
            if (MdiChildren.Length > 0)
            {
                if (ActiveMdiChild != null)
                    if (ActiveMdiChild.GetType().GetInterface("IForm") != null)
                    {
                        ((IForm)(ActiveMdiChild)).IsNew();
                    }
            }
        }

        private void SetSave()
        {
            if (MdiChildren.Length > 0)
            {
                if (ActiveMdiChild != null)
                    if (ActiveMdiChild.GetType().GetInterface("IForm") != null)
                    {
                        //MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว");
                        ((IForm)(ActiveMdiChild)).IsSave();
                        //trvMenu.SelectedNode = trvMenu.Nodes[0];
                    }
            }
        }

        private void SetEdit()
        {
            //if (MdiChildren.Length > 0)
            //{
            //    if (ActiveMdiChild != null)
            //        if (ActiveMdiChild.GetType().GetInterface("IForm") != null)
            //        {
            //            ((IForm)(ActiveMdiChild)).IsEdit();
            //        }
            //}
            NewMedicalOrder();

        }
        private void NewMedicalOrder()
        {
            if (Statics.frmMedicalOrderPaperList == null)
            {
                Statics.frmMedicalOrderPaperList = new FrmMedicalOrderPaperList(); // These forms inherit from DockContent 
                Statics.frmMedicalOrderPaperList.BackColor = Color.FromArgb(255, 230, 217);
                Statics.frmMedicalOrderPaperList.Show(dockPanel1);
            }
            else
            {
                Statics.frmMedicalOrderPaperList.BringToFront();
            }

        }
        private void SetDelete()
        {
            if (MdiChildren.Length > 0)
            {
                if (ActiveMdiChild != null)
                    if (ActiveMdiChild.GetType().GetInterface("IForm") != null)
                    {
                        ((IForm)(ActiveMdiChild)).IsDelete();
                    }
            }
        }

        private void SetRefresh()
        {
            if (MdiChildren.Length > 0)
            {
                if (ActiveMdiChild != null)
                    if (ActiveMdiChild.GetType().GetInterface("IForm") != null)
                    {
                        ((IForm)(ActiveMdiChild)).IsRefresh();
                    }
            }
        }

        private void SetPrint()
        {
            if (MdiChildren.Length > 0)
            {
                if (ActiveMdiChild != null)
                    if (ActiveMdiChild.GetType().GetInterface("IForm") != null)
                    {
                        ((IForm)(ActiveMdiChild)).IsPrint();
                    }
            }
        }

        #endregion
        #region Private Member
        private DataTable _dtFunction;
        #endregion

        private void SetVersionInfo()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.ProductVersion;

            string conStr = ConfigurationManager.ConnectionStrings["OPD_SystemContext"].ConnectionString;
            //string conStr = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
            string Encrytp = EncryptDecrypText.encryptPassword(conStr);
            conStr = /*EncryptDecrypText.decryptPassword(*/conStr/*)*/;
            //if (conStr == decrytp) MessageBox.Show("OK");

            System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();

            builder.ConnectionString = conStr;

            string server = builder.DataSource;
            string database = builder.InitialCatalog;

            //bsiVersionInfo.Text = string.Format("Version: {0}|Server:{1}:{2}", version, server.Substring(server.LastIndexOf(".")), builder.InitialCatalog);
            bsiVersionInfo.Text = string.Format("Version: {0}|Server:{1}:{2}", version, server.Substring(server.LastIndexOf(".")), "Aryuwat");
            //bsiVersionInfo.AutoSize = false;
            bsiVersionInfo.TextAlign = ContentAlignment.MiddleRight;

        }
        private void Login()
        {
            try
            {


                if (Entity.Userinfo.Login) return;

                FrmLogin objLogin = new FrmLogin();
                objLogin.ShowInTaskbar = false;
                objLogin.StartPosition = FormStartPosition.CenterScreen;
                objLogin.ShowDialog();
                lblUserName.Text = Entity.Userinfo.TName + " " + Entity.Userinfo.TSurname + " (" + Entity.Userinfo.EN + ")";
                SetMenuPermission();
                SetPermissionServerPath();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LogOut()
        {
            Entity.Userinfo.Login = false;
            lblUserName.Text = "";
            Entity.Userinfo.TName = "";
            Entity.Userinfo.TSurname = "";
            Entity.Userinfo.EN = "";
            Entity.Userinfo.NotiCount = 0;
            ClearAllTab();
            FrmLogin objLogout = new FrmLogin();
            objLogout.ShowInTaskbar = false;
            objLogout.StartPosition = FormStartPosition.CenterScreen;

            objLogout.ShowDialog();

            SetMenuPermission();
            SetPermissionServerPath();
            lblUserName.Text = "ชื่อผู้ใช้งาน :" + Entity.Userinfo.TName + " " + Entity.Userinfo.TSurname;
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            //this.BackColor = Color.FromArgb(53, 177, 170);
            this.SetVersionInfo();
            Login();
            //CleanTemp();


            timer1.Start();
        }
        private void CleanTemp()
        {
            try
            {
                //=========Temp PDF  ใบเสร็จ
                string pathTemp = string.Format(@"{0}\TempPDF\", Application.StartupPath);
                if (Directory.Exists(pathTemp))
                {
                    Directory.Delete(pathTemp, true);
                    Directory.CreateDirectory(pathTemp);
                }
                else Directory.CreateDirectory(pathTemp);
            }
            catch (Exception ex)
            {

            }
        }
        public void SetPermissionServerPath()
        {
            Application.DoEvents();
            using (UNCAccessWithCredentials unc = new UNCAccessWithCredentials())
            {
                string tbUNCPath = Properties.Settings.Default.ImagePathServer;
                tbUNCPath = EncryptDecrypText.decryptPassword(tbUNCPath);
                string tbUserName = Properties.Settings.Default.UserImagePathServer;
                tbUserName = EncryptDecrypText.decryptPassword(tbUserName);
                string tbDomain = "";// Properties.Settings.Default.PassImagePathServer;
                string tbPassword = Properties.Settings.Default.PassImagePathServer;
                tbPassword = EncryptDecrypText.decryptPassword(tbPassword);
                //string EncrytptbtbUNCPath = EncryptDecrypText.encryptPassword(tbUNCPath);
                //string EncrytptbUserName = EncryptDecrypText.encryptPassword(tbUserName);
                //string EncrytptbPassword = EncryptDecrypText.encryptPassword(tbPassword);
                Entity.Userinfo.Server = tbUNCPath;
                Entity.Userinfo.ServerUser = tbUserName;
                Entity.Userinfo.ServerPass = tbPassword;
                if (unc.NetUseWithCredentials(tbUNCPath, tbUserName, tbDomain, tbPassword))
                {
                    Entity.Userinfo.ImagePath = tbUNCPath;

                }
            }
            this.Cursor = Cursors.Default;
        }
        public static IList<Control> GetAllControlsRecusrvive<T>(Control control)
        {
            var rtn = new List<Control>();
            foreach (Control item in control.Controls)
            {
                var ctr = item as Control;
                if (ctr != null)
                {
                    rtn.Add(ctr);
                }
                else
                {
                    rtn.AddRange(GetAllControlsRecusrvive<T>(item));
                }

            }
            return rtn;
        }
        public void SetButton()
        {
            //btnCustHist.Visible = Statics.GroupPermission.ToLower().Contains("opd");
            //labelOPD.Visible = Statics.GroupPermission.ToLower().Contains("opd");

            //btnMedicalOrder.Visible = Statics.GroupPermission.ToLower().Contains("sale");
            //labelSale.Visible = Statics.GroupPermission.ToLower().Contains("sale");

            //btnCashier.Visible = Statics.GroupPermission.ToLower().Contains("cashier");
            //labelCashier.Visible = Statics.GroupPermission.ToLower().Contains("cashier");

            //btnSurgicalFee.Visible = Statics.GroupPermission.ToLower().Contains("jobcost");
            //labelSurgicalFee.Visible = Statics.GroupPermission.ToLower().Contains("jobcost");

            //btnAppointment.Visible = Statics.GroupPermission.ToLower().Contains("appointment");
            //labelAppointment.Visible = Statics.GroupPermission.ToLower().Contains("appointment");

            panelOPD.Visible = Statics.GroupPermission.ToLower().Contains("opd");

            panelSale.Visible = Statics.GroupPermission.ToLower().Contains("sale");

            panelCashier.Visible = Statics.GroupPermission.ToLower().Contains("cashier");

            panelJobCost.Visible = Statics.GroupPermission.ToLower().Contains("jobcost");

            panelAppoint.Visible = Statics.GroupPermission.ToLower().Contains("appointment");

            Dictionary<int, Point> dicLocation = new Dictionary<int, Point>();
            dicLocation.Add(0, new Point(59, 6));
            dicLocation.Add(1, new Point(174, 6));
            dicLocation.Add(2, new Point(289, 6));
            dicLocation.Add(3, new Point(404, 6));
            dicLocation.Add(4, new Point(519, 6));
            int i = 0;
            if (panelOPD.Visible)
            {
                panelOPD.Tag = i++;
                panelOPD.Location = panelOPD.Tag + "" != "" ? dicLocation[(int)panelOPD.Tag] : new Point(0, 0);
            }
            if (panelSale.Visible)
            {
                panelSale.Tag = i++;
                panelSale.Location = panelOPD.Tag + "" != "" ? dicLocation[(int)panelSale.Tag] : new Point(0, 0);
            }
            if (panelCashier.Visible)
            {
                panelCashier.Tag = i++;
                panelCashier.Location = panelOPD.Tag + "" != "" ? dicLocation[(int)panelCashier.Tag] : new Point(0, 0);
            }
            if (panelJobCost.Visible)
            {
                panelJobCost.Tag = i++;
                panelJobCost.Location = panelOPD.Tag + "" != "" ? dicLocation[(int)panelJobCost.Tag] : new Point(0, 0);
            }
            if (panelAppoint.Visible)
            {
                panelAppoint.Tag = i++;
                panelAppoint.Location = panelOPD.Tag + "" != "" ? dicLocation[(int)panelAppoint.Tag] : new Point(0, 0);
            }







            //            59, 6
            //panelSale	174, 6
            //panelCashier	289, 6
            //panelJobcost	404, 6
            //panelAppoint	519, 6

            //SALE	btnMedicalOrder
            //            labelSale
            //Cashier labelCashier
            //    btnCashier
            //JOBCOST	btnSurgicalFee
            //            labelSurgicalFee
            //Appointment labelAppointment
            //    labelAppointment
        }
        public void SetMenuPermission()
        {
            try
            {
                _dtFunction = new Business.MenuPermission().GetMenuPermissiongByGroupId(int.Parse(String.IsNullOrEmpty(Statics.StrGroupId) ? "0" : Statics.StrGroupId)).Tables[0];
                //listUserAccess = new List<UserAccessInfo>(Statics.service.GetUserAccessMenu(Statics.groupID));
                //ตรงนี้เฉพาะ Menu ที่เป็น Head
                foreach (ToolStripMenuItem headMenu in menuBar1.menuStriptSystem.Items)
                {
                    if (headMenu.Text != "นัดหมาย")
                    {
                        //headMenu.Enabled = FindeStatusMenu(headMenu.Tag);
                        headMenu.Visible = FindeStatusMenu(headMenu.Tag);

                        //วนเข้าไปใน Submenu ของ Head
                        SetStatusChildMenu(headMenu);
                    }
                }
                List<string> lsTag = new List<string>();
                Control.ControlCollection coll = this.Controls;
                foreach (Control c in coll)
                {
                    if (c != null)
                        if (!lsTag.Contains(c.Tag + "")) lsTag.Add(c.Tag + "");
                    //Console.WriteLine(c.Text, "Index numb: " + coll.GetChildIndex(c, false));
                }


                SetButton();


                //DataTable dt = new Business.MenuPermission().GetMenuPermission().Tables[0];

                //if (dt != null && dt.Rows.Count > 0)
                //{
                //    Entity.MenuPermission.DicMenu = new Dictionary<string, string>();
                //    foreach (DataRow dr in dt.Rows)
                //    {
                //        Entity.MenuPermission.EN = dr["EN"].ToString();
                //        Entity.MenuPermission.MenuCode = dr["Menu_Code"].ToString();
                //        if (!Entity.MenuPermission.DicMenu.ContainsKey(Entity.MenuPermission.MenuCode))
                //        {
                //            Entity.MenuPermission.DicMenu.Add(Entity.MenuPermission.MenuCode, Entity.MenuPermission.EN);
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการกำหนดค่าเมนู เนื่องจาก " + ex.Message, "ผลการตรวจสอบ",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void SetStatusChildMenu(ToolStripDropDownItem headmenu)
        {
            try
            {
                //Menu ลูกจะเป็น Head.DropDownItems ซะส่วนใหญ่ 
                foreach (Object childmenu in headmenu.DropDownItems)
                {
                    //if (Childmenu.GetType()) 
                    //{
                    // }
                    //string aa = Childmenu.GetType();
                    if (childmenu == null) return;
                    if (childmenu is ToolStripMenuItem)
                    {
                        //if (string.IsNullOrEmpty(((ToolStripMenuItem)childmenu).Tag + "")) return;

                        ((ToolStripMenuItem)childmenu).Visible = FindeStatusMenu(((ToolStripMenuItem)childmenu).Tag);
                        if (((ToolStripMenuItem)childmenu).Tag + "" == "Menu3Sub1")
                        {
                            btnCustHist.Visible = ((ToolStripMenuItem)childmenu).Enabled;
                        }
                        if (((ToolStripMenuItem)childmenu).Tag + "" == "Menu3Sub6")
                        {
                            btnMedicalOrder.Visible = ((ToolStripMenuItem)childmenu).Enabled;
                        }
                        if (((ToolStripMenuItem)childmenu).Tag + "" == "Menu3Sub7")
                        {
                            // btnMedicalOrder.Enabled = ((ToolStripMenuItem)childmenu).Enabled;
                        }
                        if (((ToolStripMenuItem)childmenu).Tag + "" == "Menu6Sub1")
                        {
                            btnCashier.Visible = ((ToolStripMenuItem)childmenu).Enabled;//SOF
                        }
                        if (((ToolStripMenuItem)childmenu).Tag + "" == "Menu6Sub2")
                        {
                            btnSurgicalFee.Visible = ((ToolStripMenuItem)childmenu).Enabled;
                        }

                        //if (((ToolStripMenuItem)childmenu).Tag + "" == "Menu3Sub1")
                        //{
                        //    btnCashier.Enabled = ((ToolStripMenuItem)childmenu).Enabled;
                        //}
                        if (((ToolStripMenuItem)childmenu).Tag + "" == "Menu4Sub1")
                        {
                            //btnAppointment.Visible = ((ToolStripMenuItem)childmenu).Enabled;
                        }
                        //if (((ToolStripMenuItem)childmenu).Tag + "" == "Menu4Sub2")
                        //{
                        //    btnAppointment.Enabled = ((ToolStripMenuItem)childmenu).Enabled;
                        //}
                        if (((ToolStripMenuItem)childmenu).Tag + "" == "Menu5Sub2")
                        {
                            ((ToolStripMenuItem)childmenu).Visible = false;
                        }
                        if (((ToolStripMenuItem)childmenu).Tag + "" == "Menu5Sub3")
                        {
                            ((ToolStripMenuItem)childmenu).Visible = false;
                        }
                        if (((ToolStripMenuItem)childmenu).Tag + "" == "Menu5Sub4")
                        {
                            ((ToolStripMenuItem)childmenu).Visible = false;
                        }
                        if (((ToolStripMenuItem)childmenu).Tag + "" == "Menu5Sub5")
                        {
                            ((ToolStripMenuItem)childmenu).Visible = false;
                        }
                        if (((ToolStripMenuItem)childmenu).Tag + "" == "Menu3Sub7")
                        {
                            ((ToolStripMenuItem)childmenu).Visible = false;
                        }
                        if (((ToolStripMenuItem)childmenu).Tag + "" == "Menu3Sub10")
                        {
                            ((ToolStripMenuItem)childmenu).Visible = false;
                        }
                        if (((ToolStripMenuItem)childmenu).Tag + "" == "Menu3Sub11")
                        {
                            ((ToolStripMenuItem)childmenu).Visible = false;
                        }
                        if (((ToolStripMenuItem)childmenu).Tag + "" == "Menu3Sub12")
                        {
                            ((ToolStripMenuItem)childmenu).Visible = false;
                        }
                        if (((ToolStripMenuItem)childmenu).Tag + "" == "Menu3Sub13")
                        {
                            ((ToolStripMenuItem)childmenu).Visible = false;
                        }

                        ((ToolStripMenuItem)childmenu).Click += ChildMenuClick;

                        //Recursive กรณีเมนูลูกซ้อนลูก

                        SetStatusChildMenu((ToolStripMenuItem)childmenu);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        private bool FindeStatusMenu(object strTag)
        {
            bool status = false;
            try
            {
                foreach (DataRow row in _dtFunction.Rows)
                {
                    if (Convert.ToString(strTag).Equals(Convert.ToString(row["MenuId"])))
                    {
                        status = true;
                    }

                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return status;
        }

        private void btnCustHist_Click(object sender, EventArgs e)
        {
            if (Statics.frmCustomerList == null)
            {
                Statics.frmCustomerList = new FrmCustomerList(); // These forms inherit from DockContent 
                Statics.frmCustomerList.BackColor = Color.FromArgb(255, 230, 217);
                Statics.frmCustomerList.Show(dockPanel1);
            }
            else
            {
                Statics.frmCustomerList.BringToFront();
            }
        }

        private void menuBar1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            //menubarPetCare.Capture = false;
            const int wmNclbuttondown = 161;
            const int htcaption = 2;
            var msg = Message.Create(Handle, wmNclbuttondown, new IntPtr(htcaption), IntPtr.Zero);
            DefWndProc(ref msg);
        }

        private void menuBar1_Click(object sender, EventArgs e)
        {
            //if (e.ToString() != MouseButtons.Left) return;
            ////menubarPetCare.Capture = false;
            //const int wmNclbuttondown = 161;
            //const int htcaption = 2;
            //var msg = Message.Create(Handle, wmNclbuttondown, new IntPtr(htcaption), IntPtr.Zero);
            //MessageBox.Show("sss");
            //DefWndProc(ref msg);
        }
        private void ChildMenuClick(object sender, EventArgs e)
        {
            try
            {


                var sourceMenuItem = (ToolStripMenuItem)sender;
                switch (sourceMenuItem.Tag + "")
                {
                    case "Menu1Sub1"://Login
                        Login();
                        SetMenuPermission();
                        //SetButton();
                        break;
                    case "Menu1Sub2"://Log out
                        LogOut();
                        break;
                    case "Menu1Sub3":
                        if (
                   DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirmYesNo, "Do you really want to exit ?") == DialogResult.Yes)
                        {
                            this.Close();
                        }
                        break;

                    case "Menu2Sub1":
                        //PopUserGroup popUserGroup = new PopUserGroup();
                        //popUserGroup.ShowDialog();
                        if (Statics.frmUserGroupList == null)
                        {
                            Statics.frmUserGroupList = new FrmUserGroupList();
                            {
                                Statics.frmUserGroupList.BackColor = Color.FromArgb(255, 230, 217);
                            };
                            Statics.frmUserGroupList.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmUserGroupList.BringToFront();
                        }
                        break;
                    case "Menu2Sub3":
                        try
                        {
                            if (Statics.frmPersonnelSetting == null)
                            {
                                Statics.frmPersonnelSetting = new FrmPersonnelSetting();
                                Statics.frmPersonnelSetting.FormType = DerUtility.AccessType.Update;
                                Statics.frmPersonnelSetting.en = Entity.Userinfo.EN;
                                Statics.frmPersonnelSetting.Text += Statics.StrEdit;
                                Statics.frmPersonnelSetting.BackColor = Color.FromArgb(255, 230, 217);
                                Statics.frmPersonnelSetting.Show(Statics.frmMain.dockPanel1);
                            }
                            else
                            {
                                Statics.frmPersonnelSetting.BringToFront();
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;

                    case "Menu2Sub4":

                        if (Statics.frmSystemLog == null)
                        {
                            Statics.frmSystemLog = new FrmSystemLog();
                            {
                                Statics.frmSystemLog.BackColor = Color.FromArgb(255, 230, 217);
                            };
                            Statics.frmSystemLog.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmSystemLog.BringToFront();
                        }
                        break;
                    case "Menu2Sub5":

                        if (Statics.frmEnAndDeCode == null)
                        {
                            Statics.frmEnAndDeCode = new FrmEnAndDeCode();
                            {
                                Statics.frmEnAndDeCode.BackColor = Color.FromArgb(255, 230, 217);
                            };
                            Statics.frmEnAndDeCode.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmEnAndDeCode.BringToFront();
                        }
                        break;

                    case "Menu3Sub1":
                        if (Statics.frmCustomerList == null)
                        {
                            Statics.frmCustomerList = new FrmCustomerList();
                            {
                                Statics.frmCustomerList.BackColor = Color.FromArgb(255, 230, 217);
                            };
                            Statics.frmCustomerList.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmCustomerList.BringToFront();
                        }
                        break;
                    case "Menu3Sub2":
                        if (Statics.frmPersonnelList == null)
                        {
                            Statics.frmPersonnelList = new FrmPersonnelList();
                            {
                                Statics.frmPersonnelList.BackColor = Color.FromArgb(255, 230, 217);
                            };
                            Statics.frmPersonnelList.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmPersonnelList.BringToFront();
                        }
                        break;
                    case "Menu3Sub3":
                        popPersonnelType popPersonnelType = new popPersonnelType();
                        popPersonnelType.ShowDialog();
                        break;
                    case "Menu3Sub4":
                        if (Statics.frmMedicalSupplies == null)
                        {
                            Statics.frmMedicalSupplies = new FrmMedicalSupplies();
                            {
                                Statics.frmMedicalSupplies.BackColor = Color.FromArgb(255, 230, 217);
                            };
                            Statics.frmMedicalSupplies.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmMedicalSupplies.BringToFront();
                        }
                        break;
                    case "Menu3Sub5":
                        //if (Statics.frmCommissionHeadCheck == null)
                        //{
                        //    Statics.frmCommissionHeadCheck = new FrmCommissionHeadCheck();
                        //    {
                        //        Statics.frmCommissionHeadCheck.BackColor = Color.FromArgb(255, 230, 217);
                        //    };
                        //    Statics.frmCommissionHeadCheck.Show(dockPanel1);
                        //}
                        //else
                        //{
                        //    Statics.frmCommissionHeadCheck.BringToFront();
                        //}
                        break;

                    case "Menu3Sub6":
                        if (Statics.frmMedicalOrderList == null)
                        {
                            Statics.frmMedicalOrderList = new FrmMedicalOrderList();
                            {
                                Statics.frmMedicalOrderList.BackColor = Color.FromArgb(255, 230, 217);
                            };
                            Statics.frmMedicalOrderList.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmMedicalOrderList.BringToFront();
                        }
                        break;
                    case "Menu3Sub7":
                        if (Statics.frmAgencySetting == null)
                        {
                            Statics.frmAgencySetting = new FrmAgencySetting();
                            {
                                Statics.frmAgencySetting.BackColor = Color.FromArgb(255, 230, 217);
                            };
                            Statics.frmAgencySetting.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmAgencySetting.BringToFront();
                        }
                        break;
                    case "Menu3Sub8":
                        if (Statics.frmPromotionList == null)
                        {
                            Statics.frmPromotionList = new FrmPromotionList();
                            {
                                Statics.frmPromotionList.BackColor = Color.FromArgb(255, 230, 217);
                            };
                            Statics.frmPromotionList.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmPromotionList.BringToFront();
                        }
                        break;
                    case "Menu3Sub11":
                        //if (Statics.frmFreeGiftVoucher == null)
                        //{
                        Statics.frmFreeGiftVoucher = new FrmFreeGiftVoucher();
                        {
                            Statics.frmFreeGiftVoucher.BackColor = Color.FromArgb(255, 230, 217);
                        };
                        Statics.frmFreeGiftVoucher.Show(dockPanel1);
                        //}
                        //else
                        //{
                        //    Statics.frmFreeGiftVoucher.BringToFront();
                        //}
                        break;
                    case "Menu3Sub12":
                        //if (Statics.frmFreeGiftVoucher == null)
                        //{
                        Statics.frmFreeBarterVat = new FrmFreeBarterVat();
                        {
                            Statics.frmFreeBarterVat.BackColor = Color.FromArgb(255, 230, 217);
                        };
                        Statics.frmFreeBarterVat.Show(dockPanel1);
                        //}
                        //else
                        //{
                        //    Statics.frmFreeGiftVoucher.BringToFront();
                        //}
                        break;
                    case "Menu3Sub13":
                        if (Statics.frmCustomerConnectList == null)
                        {
                            Statics.frmCustomerConnectList = new FrmCustomerConnectList();
                            {
                                Statics.frmCustomerConnectList.BackColor = Color.FromArgb(255, 230, 217);
                            };
                            Statics.frmCustomerConnectList.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmCustomerConnectList.BringToFront();
                        }
                        break;
                    case "Menu3Sub14":
                        if (Statics.frmRoomList == null)
                        {
                            Statics.frmRoomList = new FrmRoomList();
                            {
                                Statics.frmRoomList.BackColor = Color.FromArgb(255, 230, 217);
                            };
                            Statics.frmRoomList.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmRoomList.BringToFront();
                        }
                        break;
                    case "47":
                        PopBaseAdministrative popBaseAdministrative = new PopBaseAdministrative();
                        popBaseAdministrative.ShowDialog();
                        break;
                    case "48":
                        if (Statics.frmMedicalOrderList == null)
                        {
                            Statics.frmMedicalOrderList = new FrmMedicalOrderList();
                            {
                                Statics.frmMedicalOrderList.BackColor = Color.FromArgb(255, 230, 217);
                            };
                            Statics.frmMedicalOrderList.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmMedicalOrderList.BringToFront();
                        }
                        break;

                    case "Menu4Sub1"://Booking
                        if (Statics.bookingroom == null)
                        {
                            Statics.bookingroom = new FrmBookingRoom();
                            {
                                Statics.bookingroom.BackColor = Color.FromArgb(255, 230, 217);
                            };
                            Statics.bookingroom.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.bookingroom.BringToFront();
                        }
                        break;
                    case "Menu4Sub2"://Doctor schedule
                        if (Statics.frmDoctorSchedule == null)
                        {
                            Statics.frmDoctorSchedule = new FrmDoctorSchedule();
                            {
                                Statics.frmDoctorSchedule.BackColor = Color.FromArgb(255, 230, 217);
                            };
                            Statics.frmDoctorSchedule.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmDoctorSchedule.BringToFront();
                        }
                        break;
                    case "Menu4Sub3"://Doctor schedule
                        if (Statics.bookingDoctor == null)
                        {
                            Statics.bookingDoctor = new FrmBookingDoctor();
                            {
                                Statics.bookingDoctor.BackColor = Color.FromArgb(255, 230, 217);
                            };
                            Statics.bookingDoctor.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmDoctorSchedule.BringToFront();
                        }
                        break;
                    case "Menu2Sub2":
                        if (Statics.frmSetPermission == null)
                        {
                            Statics.frmSetPermission = new FrmSetPermission();
                            {
                                Statics.frmSetPermission.BackColor = Color.FromArgb(255, 230, 217);
                            };
                            Statics.frmSetPermission.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmSetPermission.BringToFront();
                        }
                        break;
                    case "Menu6Sub1":
                        //if (Statics.frmSOFList == null)
                        //{
                        //    Statics.frmSOFList = new FrmSOTList(); // These forms inherit from DockContent 
                        //    Statics.frmSOFList.BackColor = Color.FromArgb(255, 230, 217);
                        //    Statics.frmSOFList.Show(dockPanel1);
                        //}
                        //else
                        //{
                        //    Statics.frmSOFList.BringToFront();
                        //}
                        bool flagopen = false;
                        var dockcontents = dockPanel1.Contents;
                        foreach (var items in dockcontents)
                        {
                            flagopen = (items.ToString().ToLower()).Contains("frmsotbyperson");
                            if (flagopen)
                            {
                                return;
                                break;
                            }
                        }
                        if (Statics.frmSOTByPerson == null || !flagopen)
                        {
                            Statics.frmSOTByPerson = new FrmSOTByPerson(); // These forms inherit from DockContent 
                            Statics.frmSOTByPerson.BackColor = Color.FromArgb(255, 230, 217);
                            Statics.frmSOTByPerson.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmSOTByPerson.BringToFront();
                        }
                        break;
                    case "Menu6Sub2":
                        if (Statics.frmSurgicalFeeList == null)
                        {
                            Statics.frmSurgicalFeeList = new FrmSurgicalFeeList(); // These forms inherit from DockContent 
                            Statics.frmSurgicalFeeList.BackColor = Color.FromArgb(255, 230, 217);
                            Statics.frmSurgicalFeeList.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmSurgicalFeeList.BringToFront();
                        }
                        break;
                    case "Menu6Sub3":
                        if (Statics.poprfdList == null)
                        {
                            Statics.poprfdList = new popRFDList(); // These forms inherit from DockContent 
                            Statics.poprfdList.BackColor = Color.FromArgb(255, 230, 217);
                            Statics.poprfdList.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.poprfdList.BringToFront();
                        }
                        break;
                    case "Menu5Sub1I2":

                        //FrmPreviewRpt obj = new FrmPreviewRpt();
                        //obj.FormName = "RptRevenueByMonth";
                        //obj.MaximizeBox = true;
                        //obj.ShowDialog();
                        break;
                    case "Menu5Sub1I3":
                        if (Statics.frmCommonReportSaleOutStanding == null)
                        {
                            Statics.frmCommonReportSaleOutStanding = new FrmCommonReportSaleOutStanding(); // These forms inherit from DockContent 
                            Statics.frmCommonReportSaleOutStanding.BackColor = Color.FromArgb(255, 230, 217);
                            Statics.frmCommonReportSaleOutStanding.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmCommonReportSaleOutStanding.BringToFront();
                        }
                        break;
                    case "Menu5Sub1I4":
                        if (Statics.frmCommonReport == null)
                        {
                            Statics.frmCommonReport = new FrmCommonReport(); // These forms inherit from DockContent 
                            Statics.frmCommonReport.BackColor = Color.FromArgb(255, 230, 217);
                            Statics.frmCommonReport.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmCommonReport.BringToFront();
                        }
                        break;
                    case "Menu5Sub1I5":

                        if (Statics.frmCommonReportSaleResult == null)
                        {
                            Statics.frmCommonReportSaleResult = new FrmCommonReportSaleResult(); // These forms inherit from DockContent 
                            Statics.frmCommonReportSaleResult.BackColor = Color.FromArgb(255, 230, 217);
                            Statics.frmCommonReportSaleResult.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmCommonReportSaleResult.BringToFront();
                        }
                        break;

                    case "Menu5Sub1I6":
                        if (Statics.frmCommonReportSaleFollow == null)
                        {
                            Statics.frmCommonReportSaleFollow = new FrmCommonReportSaleFollow(); // These forms inherit from DockContent 
                            Statics.frmCommonReportSaleFollow.BackColor = Color.FromArgb(255, 230, 217);
                            Statics.frmCommonReportSaleFollow.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmCommonReportSaleFollow.BringToFront();
                        }
                        break;
                    case "Menu5Sub1I1":
                        if (Statics.frmReportSaleList == null)
                        {
                            Statics.frmReportSaleList = new FrmReportSaleList(); // These forms inherit from DockContent 
                            Statics.frmReportSaleList.BackColor = Color.FromArgb(255, 230, 217);
                            Statics.frmReportSaleList.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmReportSaleList.BringToFront();
                        }
                        break;
                    case "Menu5Sub3I1":
                        FrmPreviewRpt obj6 = new FrmPreviewRpt();
                        obj6.FormName = "RptSummaryBodyByMonth";
                        obj6.MaximizeBox = true;
                        obj6.ShowDialog();
                        break;
                    case "Menu5Sub3I2":
                        if (Statics.frmReportAE_Fee_Year == null)
                        {
                            Statics.frmReportAE_Fee_Year = new FrmReportAE_Fee_Year(); // These forms inherit from DockContent 
                            Statics.frmReportAE_Fee_Year.BackColor = Color.FromArgb(255, 230, 217);
                            Statics.frmReportAE_Fee_Year.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmReportAE_Fee_Year.BringToFront();
                        }
                        break;
                    case "Menu5Sub7I1":
                        if (Statics.frmReportAE_Fee_Year == null)
                        {
                            Statics.frmReportAE_Fee_Year = new FrmReportAE_Fee_Year(); // These forms inherit from DockContent 
                            Statics.frmReportAE_Fee_Year.BackColor = Color.FromArgb(255, 230, 217);
                            Statics.frmReportAE_Fee_Year.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmReportAE_Fee_Year.BringToFront();
                        }
                        break;
                    case "Menu5Sub7I2":
                        if (Statics.frmHRCommissionCheck == null)
                        {
                            Statics.frmHRCommissionCheck = new FrmHRCommissionCheck(); // These forms inherit from DockContent 
                            Statics.frmHRCommissionCheck.BackColor = Color.FromArgb(255, 230, 217);
                            Statics.frmHRCommissionCheck.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmHRCommissionCheck.BringToFront();
                        }
                        break;

                    case "Menu5Sub3I3":
                        if (Statics.frmCommonReportAE_Month == null)
                        {
                            Statics.frmCommonReportAE_Month = new FrmCommonReportAE_Month(); // These forms inherit from DockContent 
                            Statics.frmCommonReportAE_Month.BackColor = Color.FromArgb(255, 230, 217);
                            Statics.frmCommonReportAE_Month.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmCommonReportAE_Month.BringToFront();
                        }
                        break;
                    case "Menu5Sub3I4":
                        //FrmPreviewRpt obj9 = new FrmPreviewRpt();
                        //obj9.FormName = "RptSummaryTherapist";
                        //obj9.MaximizeBox = true;
                        //obj9.ShowDialog();
                        if (Statics.frmCommonReportAEWE == null)
                        {
                            Statics.frmCommonReportAEWE = new FrmCommonReportAEWE(); // These forms inherit from DockContent 
                            Statics.frmCommonReportAEWE.BackColor = Color.FromArgb(255, 230, 217);
                            Statics.frmCommonReportAEWE.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmCommonReportAEWE.BringToFront();
                        }
                        break;
                    case "Menu5Sub3I5":
                        if (Statics.frmSetGroupReportSEO == null)
                        {
                            Statics.frmSetGroupReportSEO = new FrmSetGroupReportSEO(); // These forms inherit from DockContent 
                            Statics.frmSetGroupReportSEO.BackColor = Color.FromArgb(255, 230, 217);
                            Statics.frmSetGroupReportSEO.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmSetGroupReportSEO.BringToFront();
                        }
                        break;

                    case "Menu5Sub2I3":
                        FrmPreviewRpt obj10 = new FrmPreviewRpt();
                        obj10.FormName = "RptPaymentSumByDept";
                        obj10.MaximizeBox = true;
                        obj10.ShowDialog();
                        break;
                    case "Menu5Sub2I1":
                        if (Statics.frmReportMarketing == null)
                        {
                            Statics.frmReportMarketing = new FrmReportMarketing(); // These forms inherit from DockContent 
                            Statics.frmReportMarketing.BackColor = Color.FromArgb(255, 230, 217);
                            Statics.frmReportMarketing.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmReportMarketing.BringToFront();
                        }
                        break;
                    case "Menu5Sub2I2":
                        if (Statics.frmCommonReportMK_SumByDepart == null)
                        {
                            Statics.frmCommonReportMK_SumByDepart = new FrmCommonReportMK_SumByDepart(); // These forms inherit from DockContent 
                            Statics.frmCommonReportMK_SumByDepart.BackColor = Color.FromArgb(255, 230, 217);
                            Statics.frmCommonReportMK_SumByDepart.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmCommonReportMK_SumByDepart.BringToFront();
                        }
                        break;
                    case "Menu5Sub4I3":
                        FrmPreviewRpt obj13 = new FrmPreviewRpt();
                        obj13.FormName = "RptPaymentMarketing";
                        obj13.MaximizeBox = true;
                        obj13.ShowDialog();
                        break;
                    case "Menu5Sub4I2":
                        if (Statics.frmCommonReportAEWE == null)
                        {
                            Statics.frmCommonReportAEWE = new FrmCommonReportAEWE(); // These forms inherit from DockContent 
                            Statics.frmCommonReportAEWE.BackColor = Color.FromArgb(255, 230, 217);
                            Statics.frmCommonReportAEWE.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmCommonReportAEWE.BringToFront();
                        }

                        break;
                    case "Menu5Sub4I1":
                        if (Statics.frmCommonReportWE_Month == null)
                        {
                            Statics.frmCommonReportWE_Month = new FrmCommonReportWE_Month(); // These forms inherit from DockContent 
                            Statics.frmCommonReportWE_Month.BackColor = Color.FromArgb(255, 230, 217);
                            Statics.frmCommonReportWE_Month.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmCommonReportWE_Month.BringToFront();
                        }
                        //FrmPreviewRpt obj15 = new FrmPreviewRpt();
                        //obj15.FormName = "RptPaymentSummary";
                        //obj15.MaximizeBox = true;
                        //obj15.ShowDialog();
                        break;
                    case "Menu5Sub5I1":
                        if (Statics.frmCommonReportOR == null)
                        {
                            Statics.frmCommonReportOR = new FrmCommonReportOR(); // These forms inherit from DockContent 
                            Statics.frmCommonReportOR.BackColor = Color.FromArgb(255, 230, 217);
                            Statics.frmCommonReportOR.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmCommonReportOR.BringToFront();
                        }
                        break;
                    case "Menu5Sub5I2":
                        if (Statics.frmCommonReportAEWE == null)
                        {
                            Statics.frmCommonReportAEWE = new FrmCommonReportAEWE(); // These forms inherit from DockContent 
                            Statics.frmCommonReportAEWE.BackColor = Color.FromArgb(255, 230, 217);
                            Statics.frmCommonReportAEWE.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmCommonReportAEWE.BringToFront();
                        }
                        break;
                    case "Menu3Sub5I1":
                        if (Statics.frmCommissionDoctorCheck == null)
                        {
                            Statics.frmCommissionDoctorCheck = new FrmCommissionDoctorCheck(); // These forms inherit from DockContent 
                            Statics.frmCommissionDoctorCheck.BackColor = Color.FromArgb(255, 230, 217);
                            Statics.frmCommissionDoctorCheck.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmCommissionDoctorCheck.BringToFront();
                        }
                        break;
                    case "Menu3Sub5I2":
                        if (Statics.frmCommissionCheck == null)
                        {
                            Statics.frmCommissionCheck = new FrmCommissionCheck(); // These forms inherit from DockContent 
                            Statics.frmCommissionCheck.BackColor = Color.FromArgb(255, 230, 217);
                            Statics.frmCommissionCheck.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmCommissionCheck.BringToFront();
                        }
                        break;
                    case "Menu3Sub5I3":
                        if (Statics.frmCommissionDoctorCheck == null)
                        {
                            Statics.frmCommissionDoctorCheck = new FrmCommissionDoctorCheck(); // These forms inherit from DockContent 
                            Statics.frmCommissionDoctorCheck.OpenFee = false;
                            Statics.frmCommissionDoctorCheck.BackColor = Color.FromArgb(255, 230, 217);
                            Statics.frmCommissionDoctorCheck.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmCommissionDoctorCheck.BringToFront();
                        }
                        break;

                    case "Menu5Sub1I7":
                        if (Statics.frmCommonReportSale == null)
                        {
                            Statics.frmCommonReportSale = new FrmCommonReportSale(); // These forms inherit from DockContent 
                            Statics.frmCommonReportSale.BackColor = Color.FromArgb(255, 230, 217);
                            Statics.frmCommonReportSale.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmCommonReportSale.BringToFront();
                        }
                        break;

                    case "Menu5Sub1I8":
                        if (Statics.frmCommonReportSaleResultByCN == null)
                        {
                            Statics.frmCommonReportSaleResultByCN = new FrmCommonReportSaleResultByCN(); // These forms inherit from DockContent 
                            Statics.frmCommonReportSaleResultByCN.BackColor = Color.FromArgb(255, 230, 217);
                            Statics.frmCommonReportSaleResultByCN.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmCommonReportSaleResultByCN.BringToFront();
                        }
                        break;
                    case "Menu5Sub1I9":
                        if (Statics.frmFollowCust == null)
                        {
                            Statics.frmFollowCust = new FrmFollowCust(); // These forms inherit from DockContent 
                            Statics.frmFollowCust.BackColor = Color.FromArgb(255, 230, 217);
                            Statics.frmFollowCust.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmFollowCust.BringToFront();
                        }
                        break;
                    case "Menu5Sub6I1":
                        if (Statics.frmReportStockIn_Out == null)
                        {
                            Statics.frmReportStockIn_Out = new FrmReportStockIn_Out(); // These forms inherit from DockContent 
                            Statics.frmReportStockIn_Out.BackColor = Color.FromArgb(255, 230, 217);
                            Statics.frmReportStockIn_Out.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmReportStockIn_Out.BringToFront();
                        }
                        break;
                    case "Menu5Sub6I2":
                        if (Statics.frmReportAcc == null)
                        {
                            Statics.frmReportAcc = new FrmReportAcc(); // These forms inherit from DockContent 
                            Statics.frmReportAcc.BackColor = Color.FromArgb(255, 230, 217);
                            Statics.frmReportAcc.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmReportAcc.BringToFront();
                        }
                        break;
                    case "Menu5Sub6I3":

                        PopDateTime pp = new PopDateTime();
                        pp.SelecttDate = DateTime.Now;
                        if (pp.ShowDialog() != DialogResult.OK)
                        {
                            break;
                        }
                        FrmPreviewRpt2Page obj2 = new FrmPreviewRpt2Page();
                        obj2.Text = "Hair Female Formula";
                        obj2.FormName = "rtpLabelHairF";
                        obj2.PayToday = pp.SelecttDate.ToString("dd/MM/yyyy");
                        obj2.MaximizeBox = true;
                        obj2.TopMost = false;
                        obj2.Show();
                        break;

                    case "Menu3Sub9I1":
                        if (Statics._popGetInventory == null)
                        {
                            Statics._popGetInventory = new popGetInventory(); // These forms inherit from DockContent 
                            Statics._popGetInventory.BackColor = Color.FromArgb(255, 230, 217);
                            Statics._popGetInventory.Show(dockPanel1);
                        }
                        else
                        {
                            Statics._popGetInventory.BringToFront();
                        }
                        break;
                    case "Menu3Sub9I2":
                        if (Statics._popSellInventory == null)
                        {
                            Statics._popSellInventory = new popSellInventory(); // These forms inherit from DockContent 
                            Statics._popSellInventory.BackColor = Color.FromArgb(255, 230, 217);
                            Statics._popSellInventory.Show(dockPanel1);
                        }
                        else
                        {
                            Statics._popSellInventory.BringToFront();
                        }
                        break;
                    case "Menu3Sub9I3":
                        if (Statics.frmStockHistory == null)
                        {
                            Statics.frmStockHistory = new FrmStockHistory(); // These forms inherit from DockContent 
                            Statics.frmStockHistory.BackColor = Color.FromArgb(255, 230, 217);
                            Statics.frmStockHistory.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmStockHistory.BringToFront();
                        }
                        break;
                    case "Menu3Sub9I4":
                        if (Statics.frmMedicalSuppliesStock == null)
                        {
                            Statics.frmMedicalSuppliesStock = new FrmMedicalSuppliesStock(); // These forms inherit from DockContent 
                            Statics.frmMedicalSuppliesStock.BackColor = Color.FromArgb(255, 230, 217);
                            Statics.frmMedicalSuppliesStock.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmMedicalSuppliesStock.BringToFront();
                        }
                        break;
                    case "Menu3Sub9I5"://REQ สาขา
                        Statics.popREQInventory = null;
                        if (Statics.popREQInventory == null)
                        {
                            Statics.popREQInventory = new popREQInventory(); // These forms inherit from DockContent 
                            Statics.popREQInventory.BackColor = Color.FromArgb(255, 230, 217);
                            Statics.popREQInventory.Text = "REQ สาขา";
                            Statics.popREQInventory.StockTyp = DerUtility.StockTyp.REQBranch;
                            Statics.popREQInventory.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.popREQInventory.BringToFront();
                        }
                        break;
                    case "Menu3Sub9I6"://Reply สาขา
                        Statics.popReplyInventory = null;
                        if (Statics.popReplyInventory == null)
                        {
                            Statics.popReplyInventory = new popReplyInventory(); // These forms inherit from DockContent 
                            Statics.popReplyInventory.BackColor = Color.FromArgb(255, 230, 217);
                            Statics.popReplyInventory.Text = "Reply สาขา";
                            Statics.popReplyInventory.StockTyp = DerUtility.StockTyp.ReplyBranch;
                            Statics.popReplyInventory.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.popReplyInventory.BringToFront();
                        }
                        break;
                    case "Menu3Sub9I7"://REQ แผนก
                        Statics.popREQInventory = null;
                        if (Statics.popREQInventory == null)
                        {
                            Statics.popREQInventory = new popREQInventory(); // These forms inherit from DockContent 
                            Statics.popREQInventory.BackColor = Color.FromArgb(255, 230, 217);
                            Statics.popREQInventory.Text = "REQ แผนก";
                            Statics.popREQInventory.StockTyp = DerUtility.StockTyp.REQDept;
                            Statics.popREQInventory.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.popREQInventory.BringToFront();
                        }
                        break;
                    case "Menu3Sub9I8"://Reply แผนก
                        Statics.popReplyInventory = null;
                        if (Statics.popReplyInventory == null)
                        {
                            Statics.popReplyInventory = new popReplyInventory(); // These forms inherit from DockContent 
                            Statics.popReplyInventory.BackColor = Color.FromArgb(255, 230, 217);
                            Statics.popReplyInventory.Text = "Reply แผนก";
                            Statics.popReplyInventory.StockTyp = DerUtility.StockTyp.ReplyDept;
                            Statics.popReplyInventory.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.popReplyInventory.BringToFront();
                        }
                        break;
                    case "Menu3Sub9I12"://REQ Supplies
                        Statics.popreqSupplies = null;
                        if (Statics.popreqSupplies == null)
                        {
                            Statics.popreqSupplies = new popREQSupplies(); // These forms inherit from DockContent 
                            Statics.popreqSupplies.BackColor = Color.FromArgb(255, 230, 217);
                            Statics.popreqSupplies.Text = "REQ วัสดุสิ้นเปลือง";
                            Statics.popreqSupplies.StockTyp = DerUtility.StockTyp.REQDept;
                            Statics.popreqSupplies.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.popreqSupplies.BringToFront();
                        }
                        break;
                    case "Menu3Sub9I13"://Reply Supplies
                        Statics.popreplySupplies = null;
                        if (Statics.popreplySupplies == null)
                        {
                            Statics.popreplySupplies = new popReplySupplies(); // These forms inherit from DockContent 
                            Statics.popreplySupplies.BackColor = Color.FromArgb(255, 230, 217);
                            Statics.popreplySupplies.Text = "Reply วัสดุสิ้นเปลือง";
                            Statics.popreplySupplies.StockTyp = DerUtility.StockTyp.ReplyDept;
                            Statics.popreplySupplies.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.popreplySupplies.BringToFront();
                        }
                        break;
                    case "Menu3Sub9I14"://Report Stock
                        Statics.frmCommonStock = null;
                        if (Statics.frmCommonStock == null)
                        {
                            Statics.frmCommonStock = new FrmCommonStock(); // These forms inherit from DockContent 
                            Statics.frmCommonStock.BackColor = Color.FromArgb(255, 230, 217);
                            Statics.frmCommonStock.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmCommonStock.BringToFront();
                        }
                        break;

                    case "Menu3Sub10I1":
                        if (Statics.frmBOMList == null)
                        {
                            Statics.frmBOMList = new FrmBOMList();
                            {
                                Statics.frmBOMList.BackColor = Color.FromArgb(255, 230, 217);
                            };
                            Statics.frmBOMList.Show(dockPanel1);
                        }
                        else
                        {
                            Statics.frmBOMList.BringToFront();
                        }
                        break;



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ClearAllTab()
        {

            foreach (IDockContent item in dockPanel1.Contents.ToList())
            {
                item.DockHandler.Close();
                item.DockHandler.Dispose();
            }
        }

        private void btnMedicalOrder_Click(object sender, EventArgs e)
        {
            if (Statics.frmMedicalOrderList == null)
            {
                Statics.frmMedicalOrderList = new FrmMedicalOrderList(); // These forms inherit from DockContent 
                Statics.frmMedicalOrderList.BackColor = Color.FromArgb(255, 230, 217);
                Statics.frmMedicalOrderList.Show(dockPanel1);
            }
            else
            {
                Statics.frmMedicalOrderList.BringToFront();
            }
        }

        private void btnCashier_Click(object sender, EventArgs e)
        {
            //if (!Entity.MenuPermission.DicMenu[btnCashier.Tag + ""].Contains(Entity.Userinfo.EN))
            //{
            //    MessageBox.Show("Not Permission");
            //    return;
            //}
            //if (Statics.frmSOFList == null)
            //{
            //    Statics.frmSOFList = new FrmSOTList(); // These forms inherit from DockContent 
            //    Statics.frmSOFList.BackColor = Color.FromArgb(255, 230, 217);
            //    Statics.frmSOFList.Show(dockPanel1);
            //}
            //else
            //{
            //    Statics.frmSOFList.BringToFront();
            //}
            bool flagopen = false;
            var dockcontents = dockPanel1.Contents;
            foreach (var items in dockcontents)
            {
                flagopen = (items.ToString().ToLower()).Contains("frmsotbyperson");
                if (flagopen)
                {
                    return;
                    break;
                }
            }
            if (Statics.frmSOTByPerson == null || !flagopen)
            {
                Statics.frmSOTByPerson = new FrmSOTByPerson(); // These forms inherit from DockContent 
                Statics.frmSOTByPerson.BackColor = Color.FromArgb(255, 230, 217);
                Statics.frmSOTByPerson.Show(dockPanel1);
            }
            else
            {
                Statics.frmSOTByPerson.BringToFront();
            }
        }
        private void btnSurgicalFee_Click(object sender, EventArgs e)
        {
            if (Statics.frmSurgicalFeeList == null)
            {
                Statics.frmSurgicalFeeList = new FrmSurgicalFeeList(); // These forms inherit from DockContent 
                Statics.frmSurgicalFeeList.BackColor = Color.FromArgb(255, 230, 217);
                Statics.frmSurgicalFeeList.Show(dockPanel1);
            }
            else
            {
                Statics.frmSurgicalFeeList.BringToFront();
            }
        }
        private void btnAppointment_Click(object sender, EventArgs e)
        {
            //if (!Entity.MenuPermission.DicMenu[btnAppointment.Tag + ""].Contains(Entity.Userinfo.EN))
            //{
            //    MessageBox.Show("Not Permission");
            //    return;
            //}
            if (Statics.bookingroom == null)
            {
                Statics.bookingroom = new FrmBookingRoom(); // These forms inherit from DockContent 

                Statics.bookingroom.BackColor = Color.FromArgb(255, 230, 217);
                Statics.bookingroom.Show(dockPanel1);

            }
            else
            {
                Statics.bookingroom.BringToFront();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                lbDatetime.Text = string.Format("{0} {1} {2}", DateTime.Now.DayOfWeek + "", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString());
            }
            catch (Exception)
            {
            }

        }



    }
}
