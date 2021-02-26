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
using DermasterSystem.Class;
using DermasterSystem.Properties;
using System.Diagnostics;

namespace DermasterSystem.Forms
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
            btnPrint.Image = Resources.FIFA_World_Cup_040sss;
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
            if (MdiChildren.Length > 0)
            {
                if (ActiveMdiChild != null)
                    if (ActiveMdiChild.GetType().GetInterface("IForm") != null)
                    {
                        ((IForm)(ActiveMdiChild)).IsEdit();
                    }
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
            bsiVersionInfo.Visible = true;

            string conStr = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];

            System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();

            builder.ConnectionString = conStr;

            string server = builder.DataSource;
            string database = builder.InitialCatalog;
            this.bsiVersionInfo.Text = string.Format("Version: {0}|Server:{1}", version, server.Substring(server.LastIndexOf(".")));
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
            lblUserName.Text ="ชื่อผู้ใช้งาน : "+ Entity.Userinfo.TName + " " + Entity.Userinfo.TSurname;
        
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
            FrmLogin objLogout = new FrmLogin();
            objLogout.ShowInTaskbar = false;
            objLogout.StartPosition = FormStartPosition.CenterScreen;
            objLogout.ShowDialog();
            SetButton();
            lblUserName.Text = "ชื่อผู้ใช้งาน :" + Entity.Userinfo.TName + " " + Entity.Userinfo.TSurname;
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.SetVersionInfo();
            Login();
            SetMenuPermission();
            SetPermissionServerPath();
   
            timer1.Start();
        }
        public void SetPermissionServerPath()
        {
            Application.DoEvents();
            using (UNCAccessWithCredentials unc = new UNCAccessWithCredentials())
            {
                string tbUNCPath = Properties.Settings.Default.ImagePathServer;
                string tbUserName = Properties.Settings.Default.UserImagePathServer;
                string tbDomain = "";// Properties.Settings.Default.PassImagePathServer;
                string tbPassword = Properties.Settings.Default.PassImagePathServer;
                if (unc.NetUseWithCredentials(tbUNCPath,tbUserName,tbDomain,tbPassword))
                {
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
            
            Dictionary<int,Point> dicLocation=new Dictionary<int,Point>();
            dicLocation.Add(0,new Point(59, 6));
            dicLocation.Add(1,new Point(174, 6));
            dicLocation.Add(2,new Point(289, 6));
            dicLocation.Add(3,new Point(404, 6));
            dicLocation.Add(4,new Point(519, 6));
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
                _dtFunction = new Business.MenuPermission().GetMenuPermissiongByGroupId(int.Parse(Statics.StrGroupId)).Tables[0];
                //listUserAccess = new List<UserAccessInfo>(Statics.service.GetUserAccessMenu(Statics.groupID));
                //ตรงนี้เฉพาะ Menu ที่เป็น Head
                foreach (ToolStripMenuItem headMenu in menuBar1.menuStriptSystem.Items)
                {
                    headMenu.Enabled = FindeStatusMenu(headMenu.Tag);
                    //วนเข้าไปใน Submenu ของ Head
                    SetStatusChildMenu(headMenu);
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

                        ((ToolStripMenuItem)childmenu).Enabled = FindeStatusMenu(((ToolStripMenuItem)childmenu).Tag);
                        if (((ToolStripMenuItem)childmenu).Tag + "" == "Menu3Sub1")
                        {
                            btnCustHist.Enabled = ((ToolStripMenuItem)childmenu).Enabled;
                        }
                        if (((ToolStripMenuItem)childmenu).Tag + "" == "Menu3Sub6")
                        {
                            btnMedicalOrder.Enabled = ((ToolStripMenuItem)childmenu).Enabled;
                        }
                        if (((ToolStripMenuItem)childmenu).Tag + "" == "Menu3Sub7")
                        {
                           // btnMedicalOrder.Enabled = ((ToolStripMenuItem)childmenu).Enabled;
                        }
                        if (((ToolStripMenuItem)childmenu).Tag + "" == "Menu6Sub1")
                        {
                            btnCashier.Enabled = ((ToolStripMenuItem)childmenu).Enabled;//SOF
                        }
                        if (((ToolStripMenuItem)childmenu).Tag + "" == "Menu6Sub2")
                        {
                            btnSurgicalFee.Enabled = ((ToolStripMenuItem)childmenu).Enabled;
                        }
                        //if (((ToolStripMenuItem)childmenu).Tag + "" == "Menu3Sub1")
                        //{
                        //    btnCashier.Enabled = ((ToolStripMenuItem)childmenu).Enabled;
                        //}
                        if (((ToolStripMenuItem)childmenu).Tag + "" == "Menu4Sub1")
                        {
                            btnAppointment.Enabled = ((ToolStripMenuItem)childmenu).Enabled;
                        }
                        //if (((ToolStripMenuItem)childmenu).Tag + "" == "Menu4Sub2")
                        //{
                        //    btnAppointment.Enabled = ((ToolStripMenuItem)childmenu).Enabled;
                        //}
                        
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
                Statics.frmCustomerList.BackColor = Color.FromArgb(170, 232, 229);
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
                case "Menu2Sub1":
                    //PopUserGroup popUserGroup = new PopUserGroup();
                    //popUserGroup.ShowDialog();
                     if (Statics.frmUserGroupList == null)
                    {
                        Statics.frmUserGroupList = new FrmUserGroupList();
                        {
                            Statics.frmUserGroupList.BackColor = Color.FromArgb(170, 232, 229);
                        };
                        Statics.frmUserGroupList.Show(dockPanel1);
                    }
                    else
                    {
                        Statics.frmUserGroupList.BringToFront();
                    }
                    break;
                
                case "Menu3Sub1":
                    if (Statics.frmCustomerList == null)
                    {
                        Statics.frmCustomerList = new FrmCustomerList();
                        {
                            Statics.frmCustomerList.BackColor = Color.FromArgb(170, 232, 229);
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
                            Statics.frmPersonnelList.BackColor = Color.FromArgb(170, 232, 229);
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
                            Statics.frmMedicalSupplies.BackColor = Color.FromArgb(170, 232, 229);
                        };
                        Statics.frmMedicalSupplies.Show(dockPanel1);
                    }
                    else
                    {
                        Statics.frmMedicalSupplies.BringToFront();
                    }
                    break;
                case "Menu3Sub5":
                    if (Statics.frmCommissionCheck == null)
                    {
                        Statics.frmCommissionCheck = new FrmCommissionCheck();
                        {
                            Statics.frmCommissionCheck.BackColor = Color.FromArgb(170, 232, 229);
                        };
                        Statics.frmCommissionCheck.Show(dockPanel1);
                    }
                    else
                    {
                        Statics.frmCommissionCheck.BringToFront();
                    }
                    break;

                case "Menu3Sub6":
                    if (Statics.frmMedicalOrderList == null)
                    {
                        Statics.frmMedicalOrderList = new FrmMedicalOrderList();
                        {
                            Statics.frmMedicalOrderList.BackColor = Color.FromArgb(170, 232, 229);
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
                            Statics.frmAgencySetting.BackColor = Color.FromArgb(170, 232, 229);
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
                            Statics.frmPromotionList.BackColor = Color.FromArgb(170, 232, 229);
                        };
                        Statics.frmPromotionList.Show(dockPanel1);
                    }
                    else
                    {
                        Statics.frmPromotionSetting.BringToFront();
                    }
                    break;
                case "Menu3Sub9":
                    if (Statics.frmPromotionList == null)
                    {
                        Statics.frmPromotionList = new FrmPromotionList();
                        {
                            Statics.frmPromotionList.BackColor = Color.FromArgb(170, 232, 229);
                        };
                        Statics.frmPromotionList.Show(dockPanel1);
                    }
                    else
                    {
                        Statics.frmPromotionSetting.BringToFront();
                    }
                    break;
                case "47":
                    PopBaseAdministrative popBaseAdministrative=new PopBaseAdministrative();
                    popBaseAdministrative.ShowDialog();
                    break;
                case "48":
                    if (Statics.frmMedicalOrderList == null)
                    {
                        Statics.frmMedicalOrderList = new FrmMedicalOrderList();
                        {
                            Statics.frmMedicalOrderList.BackColor = Color.FromArgb(170, 232, 229);
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
                            Statics.bookingroom.BackColor = Color.FromArgb(170, 232, 229);
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
                            Statics.frmDoctorSchedule.BackColor = Color.FromArgb(170, 232, 229);
                        };
                        Statics.frmDoctorSchedule.Show(dockPanel1);
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
                            Statics.frmSetPermission.BackColor = Color.FromArgb(170, 232, 229);
                        };
                        Statics.frmSetPermission.Show(dockPanel1);
                    }
                    else
                    {
                        Statics.frmSetPermission.BringToFront();
                    }
                    break;
                case "Menu6Sub1":
                    if (Statics.frmSOFList == null)
                    {
                        Statics.frmSOFList = new FrmSOTList(); // These forms inherit from DockContent 
                        Statics.frmSOFList.BackColor = Color.FromArgb(170, 232, 229);
                        Statics.frmSOFList.Show(dockPanel1);
                    }
                    else
                    {
                        Statics.frmSOFList.BringToFront();
                    }
                    break;
                case "Menu6Sub2":
                    if (Statics.frmSurgicalFeeList == null)
                    {
                        Statics.frmSurgicalFeeList = new FrmSurgicalFeeList(); // These forms inherit from DockContent 
                        Statics.frmSurgicalFeeList.BackColor = Color.FromArgb(170, 232, 229);
                        Statics.frmSurgicalFeeList.Show(dockPanel1);
                    }
                    else
                    {
                        Statics.frmSurgicalFeeList.BringToFront();
                    }
                    break;
                case "Menu5Sub1I2":
                FrmPreviewRpt obj = new FrmPreviewRpt();
                obj.FormName = "RptRevenueByMonth";
                obj.MaximizeBox = true;
                obj.ShowDialog();
                    break;
                case "Menu5Sub1I3":
                    FrmPreviewRpt obj1 = new FrmPreviewRpt();
                    obj1.FormName = "RptRevenueByDept";
                    obj1.MaximizeBox = true;
                    obj1.ShowDialog();
                    break;
                    break;
                case "Menu5Sub1I4":
                    FrmPreviewRpt obj2 = new FrmPreviewRpt();
                    obj2.FormName = "RptAestheticSummary";
                    obj2.MaximizeBox = true;
                    obj2.ShowDialog();
                    break;
                case "Menu5Sub1I5":
                    FrmPreviewRpt obj3 = new FrmPreviewRpt();
                    obj3.FormName = "RptSalesVolumeByDept";
                    obj3.MaximizeBox = true;
                    obj3.ShowDialog();
                    break;
                case "Menu5Sub1I6":
                    FrmPreviewRpt obj4 = new FrmPreviewRpt();
                    obj4.FormName = "RptSalesVolumeByMonth";
                    obj4.MaximizeBox = true;
                    obj4.ShowDialog();
                    break;
                case "Menu5Sub1I1":
                    FrmPreviewRpt obj5 = new FrmPreviewRpt();
                    obj5.FormName = "RptRevenueDistGroup";
                    obj5.MaximizeBox = true;
                    obj5.ShowDialog();
                    break;
                case "Menu5Sub3I1":
                    FrmPreviewRpt obj6 = new FrmPreviewRpt();
                    obj6.FormName = "RptSummaryBodyByMonth";
                    obj6.MaximizeBox = true;
                    obj6.ShowDialog();
                    break;
                case "Menu5Sub3I2":
                    FrmPreviewRpt obj7 = new FrmPreviewRpt();
                    obj7.FormName = "RptSummaryFaceByMonth";
                    obj7.MaximizeBox = true;
                    obj7.ShowDialog();
                    break;
                case "Menu5Sub3I3":
                    FrmPreviewRpt obj8 = new FrmPreviewRpt();
                    obj8.FormName = "RptSummaryBodyFaceByMonth";
                    obj8.MaximizeBox = true;
                    obj8.ShowDialog();
                    break;
                case "Menu5Sub3I4":
                    FrmPreviewRpt obj9 = new FrmPreviewRpt();
                    obj9.FormName = "RptSummaryTherapist";
                    obj9.MaximizeBox = true;
                    obj9.ShowDialog();
                    break;
                case "Menu5Sub2I3":
                    FrmPreviewRpt obj10 = new FrmPreviewRpt();
                    obj10.FormName = "RptPaymentSumByDept";
                    obj10.MaximizeBox = true;
                    obj10.ShowDialog();
                    break;
                case "Menu5Sub2I1":
                    FrmPreviewRpt obj11 = new FrmPreviewRpt();
                    obj11.FormName = "RptPaymentMarketingHear";
                    obj11.MaximizeBox = true;
                    obj11.ShowDialog();
                    break;
                case "Menu5Sub2I2":
                    //FrmPreviewRpt obj12 = new FrmPreviewRpt();
                    //obj12.FormName = "RptPaymentMarketingList";
                    //obj12.MaximizeBox = true;
                    //obj12.ShowDialog();
                     if (Statics.frmCommonReport == null)
                    {
                        Statics.frmCommonReport = new FrmCommonReport(); // These forms inherit from DockContent 
                        Statics.frmCommonReport.BackColor = Color.FromArgb(170, 232, 229);
                        Statics.frmCommonReport.Show(dockPanel1);
                    }
                    else
                    {
                        Statics.frmCommonReport.BringToFront();
                    }
                    break;
                case "Menu5Sub4I3":
                    FrmPreviewRpt obj13 = new FrmPreviewRpt();
                    obj13.FormName = "RptPaymentMarketing";
                    obj13.MaximizeBox = true;
                    obj13.ShowDialog();
                    break;
                case "Menu5Sub4I2":
                    FrmPreviewRpt obj14 = new FrmPreviewRpt();
                    obj14.FormName = "RptPaymentByGroup";
                    obj14.MaximizeBox = true;
                    obj14.ShowDialog();
                    break;
                case "Menu5Sub4I1":
                    FrmPreviewRpt obj15 = new FrmPreviewRpt();
                    obj15.FormName = "RptPaymentSummary";
                    obj15.MaximizeBox = true;
                    obj15.ShowDialog();
                    break;
            }
        }

        private void btnMedicalOrder_Click(object sender, EventArgs e)
        {
            //if (!Entity.MenuPermission.DicMenu[btnMedicalOrder.Tag + ""].Contains(Entity.Userinfo.EN))
            //{
            //    MessageBox.Show("Not Permission");
            //    return;
            //}
            if (Statics.frmMedicalOrderList == null)
            {
                Statics.frmMedicalOrderList = new FrmMedicalOrderList(); // These forms inherit from DockContent 
                Statics.frmMedicalOrderList.BackColor = Color.FromArgb(170, 232, 229);
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
            if (Statics.frmSOFList == null)
            {
                Statics.frmSOFList = new FrmSOTList(); // These forms inherit from DockContent 
                Statics.frmSOFList.BackColor = Color.FromArgb(170, 232, 229);
                Statics.frmSOFList.Show(dockPanel1);
            }
            else
            {
                Statics.frmSOFList.BringToFront();
            }
        }
        private void btnSurgicalFee_Click(object sender, EventArgs e)
        {
            if (Statics.frmSurgicalFeeList == null)
            {
                Statics.frmSurgicalFeeList = new FrmSurgicalFeeList(); // These forms inherit from DockContent 
                Statics.frmSurgicalFeeList.BackColor = Color.FromArgb(170, 232, 229);
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
                
                Statics.bookingroom.BackColor = Color.FromArgb(170, 232, 229);
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
                lbDatetime.Text = string.Format("{0} {1} {2}", DateTime.Now.DayOfWeek + "", DateTime.Now.ToLongDateString() , DateTime.Now.ToLongTimeString());
            }
            catch (Exception)
            {
            }
           
        }

       

    }
}
