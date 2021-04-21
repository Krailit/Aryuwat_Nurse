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
using WeifenLuo.WinFormsUI.Docking;
using Entity;
using AryuwatSystem.Forms.PrintGridView;

namespace AryuwatSystem.Forms
{
    public partial class FrmCustomerConnectList : DockContent, IForm
    {
        DataTable dtCust = new DataTable();
        public FrmCustomerConnectList()
        {
            InitializeComponent();
            comboBoxCommission1.MouseWheel += new MouseEventHandler(comboBoxCommission1_MouseWheel);
        }

        void comboBoxCommission1_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        public void BindCommission()
        {
            try
            {
                AutoCompleteStringCollection colValues = new AutoCompleteStringCollection();
                var info = new Entity.Personnel();
                info.PersonnelType = "11";
                info.QueryType = "SEARCHCOM";
                DataTable dt = new Business.Personnel().SelectCustomerPaging(info).Tables[0];
                DataRow dr = dt.NewRow();
                dr["EN"] = "";
                dr["FullNameThai"] = "--ไม่ระบุ--";
                dt.Rows.InsertAt(dr, 0);

                foreach (DataRow row in dt.Rows)
                {
                    colValues.Add(row["FullNameThai"].ToString());
                }

                comboBoxCommission1.Items.Clear();
                comboBoxCommission1.DataSource = dt;
                comboBoxCommission1.ValueMember = "EN";
                comboBoxCommission1.DisplayMember = "FullNameThai";
                comboBoxCommission1.SelectedValue = Entity.Userinfo.EN;
                comboBoxCommission1.AutoCompleteCustomSource = colValues;
             
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
        }
        #region IForm Members

        void IForm.IsSave()
        {
        }

        void IForm.IsDelete()
        {
            DeleteData();
        }

        void IForm.IsRefresh()
        {
            BindDataPersonel(1);
        }

        void IForm.IsEdit()
        {
            //UpdateDataCustomer();
        }

        void IForm.IsPrint()
        {
        }

        void IForm.IsNew()
        {
           // NewCustomer();
        }

        void IForm.IsExit()
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region Enum CallMode

        private enum CallMode
        {
            Insert,
            Update,
            Preview
        }

        #endregion

        #region Private Member

        /// <summary>
        /// CNL (Local) CNA (Agency) และ CNM (Manager)  
        /// </summary>
        public string TypeCustomer { get; set; }
        private int pIntseq = 1;
        private int rowIndex = 0;

        #endregion

        //private void NewCustomer()
        //{
        //    Statics.frmPersonnelSetting = new FrmPersonnelSetting();
        //    Statics.frmPersonnelSetting.BackColor = Color.FromArgb(255, 230, 217);
        //    Statics.frmPersonnelSetting.Text = Text + Statics.StrAdd;
        //    Statics.frmPersonnelSetting.Show(Statics.frmMain.dockPanel1);
        //}

        private void FrmCustomerConnectList_Load(object sender, EventArgs e)
        {
            InitialControls();

            //BindDataPersonel(1);
            menuDel.Enabled = dgvData.RowCount != 1;
        }
        private void BindCboBranch()
        {
            try
            {
                var ds3 = new Business.Branch().SelectBranchAll();
                DataTable dt = ds3.Tables[0].Clone();
                string strcheck = (Entity.Userinfo.BranchAuth + "," + Entity.Userinfo.BranchId).ToUpper();
                foreach (DataRow dr in ds3.Tables[0].Rows)
                {
                    //if (ISSecurity)
                    //{
                    //if (strcheck.Contains(dr["BranchID"].ToString().ToUpper()))
                    dt.ImportRow(dr);
                    //}
                    //else 
                    //    dt.ImportRow(dr);
                }

                var dr3 = dt.NewRow();
                dr3["BranchID"] = "";
                dr3["BranchName"] = Statics.StrValidate;
                dt.Rows.InsertAt(dr3, 0);
                // cboPurchase.Items.Clear();

                cboBranch.BeginUpdate();
                cboBranch.DataSource = dt;
                cboBranch.ValueMember = "BranchID";
                cboBranch.DisplayMember = "BranchName";
                cboBranch.EndUpdate();
                cboBranch.SelectedIndex = 0;
      
            }
            catch (Exception ex)
            {
                //DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }
        }
        private void InitialControls()
        {
           // SetColumns();
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);
            dateTimePickerStart.Value = startDate;
            dateTimePickerEnd.Value = endDate;
            //dpDateBooking.Format = DateTimePickerFormat.Time;
            dpDateBooking.ShowUpDown = true;
            BindCboBranch();

            BindCommission();
            ResetText();
            BindCboFrom(1);
            AddEvent();
            dgvData.ScrollBars = ScrollBars.Both;
        }

        private void SetColumns()
        {
            DerUtility.SetPropertyDgv(dgvData);
            dgvData.Columns.Add("username", "username");
            dgvData.Columns.Add("ID", "ID");
            dgvData.Columns.Add("EN", "EN");
            dgvData.Columns.Add("FullNameThai", "ชื่อ-นามสกุล");
            dgvData.Columns.Add("FullNameEng", "Name-Surname");
            dgvData.Columns.Add("Nickname", "ชื่อเล่น");
            dgvData.Columns.Add("PersonnelType", "PersonnelType");
            dgvData.Columns.Add("Gender", "Gender (เพศ)");
            dgvData.Columns.Add("Mobile", "Mobile (มือถือ)");
            //dgvData.Columns.Add("Telephone", "Telephone (เบอร์บ้าน)");
            //dgvData.Columns.Add("Address", "Address (ที่อยู่)");
            dgvData.Columns.Add("Active", "Active");


            dgvData.Columns["username"].Visible = false;
            dgvData.Columns["ID"].Visible = false;

            dgvData.Columns["EN"].Width = 100;
            dgvData.Columns["FullNameThai"].Width = 150;
            dgvData.Columns["FullNameEng"].Width = 150;
            dgvData.Columns["Gender"].Width = 80;
            dgvData.Columns["Mobile"].Width = 200;
            //dgvData.Columns["Telephone"].Width = 200;
            //dgvData.Columns["Address"].Width = 320;

        }

        private void AddEvent()
        {
            ngbMain.MoveFirst += ngbMain_MoveFirst;
            ngbMain.MoveNext += ngbMain_MoveNext;
            ngbMain.MoveLast += ngbMain_MoveLast;
            ngbMain.MovePrevious += ngbMain_MovePrevious;

            //dgvData.RowPostPaint += dgvData_RowPostPaint;
            dgvData.CellMouseClick += dgvData_CellMouseClick;
            buttonFind.BtnClick += buttonFind_BtnClick;
            
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(FrmCustomerConnectList_KeyPress);
            menuEdit.Click += new EventHandler(menuEdit_Click);
            menuPreview.Click += new EventHandler(menuPreview_Click);
            menuDel.Click += new EventHandler(menuDel_Click);

             //if (Entity.Userinfo.UserGroup == "1" || Entity.Userinfo.Username=="")
             //{
             //    menuEdit.Visible = false;
             //    menuPreview.Visible = false;
             //    menuDel.Visible = false;
             //}
        }


        #region Event

        private void ngbMain_MoveFirst()
        {
            BindDataPersonel(1);
        }

        private void ngbMain_MoveLast()
        {
            BindDataPersonel(Convert.ToInt32(ngbMain.TotalPage));
        }

        private void ngbMain_MoveNext()
        {
            BindDataPersonel(Convert.ToInt32(Convert.ToInt32(ngbMain.CurrentPage) + 1));
        }

        private void ngbMain_MovePrevious()
        {
            BindDataPersonel(Convert.ToInt32(Convert.ToInt32(ngbMain.CurrentPage) - 1));
        }

        //private void dgvData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        //{
            //var b = new SolidBrush(((DataGridView) sender).RowHeadersDefaultCellStyle.ForeColor);
            //e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView) sender).DefaultCellStyle.Font, b,
            //                      e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        //}

        private void buttonFind_BtnClick()
        {
            BindDataPersonel(1);
        }

        private void btnRefresh_BtnClick()
        {

            txtName.Text = "";
            //txtSurname.Text = "";
            txtMobile.Text = "";
        }

        private void FrmCustomerConnectList_KeyPress(object sender, KeyPressEventArgs e)
        {
            DerUtility.SendKey(e.KeyChar);
        }

        private void dgvData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                if (e.Button == MouseButtons.Right)
                {
                    dgvData.ClearSelection();
                    dgvData.Rows[e.RowIndex].Selected = false;
                    dgvData.Rows[e.RowIndex].Selected = true;
                    rowIndex = e.RowIndex;
                   // contextMenuStrip1.Show(MousePosition); ปิดไว้ก่อน ไม่ใช้เมนู ชั่วคราว
                }
            }
            catch
            {
                return;
            }
        }

        private void menuEdit_Click(object sender, EventArgs e)
        {
            string username = dgvData.Rows[rowIndex].Cells["username"].Value + "";
            if (Entity.Userinfo.UserGroup == "1" || Entity.Userinfo.Username == username)
            CallForm(CallMode.Update);
            else
            {
                MessageBox.Show("No Permission");
            }
        }

        private void menuPreview_Click(object sender, EventArgs e)
        {
            string username = dgvData.Rows[rowIndex].Cells["username"].Value + "";
            if (Entity.Userinfo.UserGroup == "1" || Entity.Userinfo.Username == username)
            CallForm(CallMode.Preview);
            else
            {
                MessageBox.Show("No Permission");
            }
        }

        private void menuDel_Click(object sender, EventArgs e)
        {
            string username = dgvData.Rows[rowIndex].Cells["username"].Value + "";
            if (Entity.Userinfo.UserGroup == "1")
            {
                DeleteData();
            }
            else
            {
                MessageBox.Show("No Permission");
            }
        }

        #endregion
        private void BindCboFrom(int _pIntseq)
        {
            try
            {
                var info = new Entity.Customer { PageNumber = _pIntseq };

                info.QueryType = "ContactFromType";
                DataTable dtFrom = new Business.Customer().SelectCustomerConnect(info).Tables[0];
                DataRow newCustomersRow = dtFrom.NewRow();

                newCustomersRow["CFCode"] = "";
                newCustomersRow["CFText"] = "-";
                dtFrom.Rows.Add(newCustomersRow);
                comboBoxFrom.DataSource = dtFrom;
                comboBoxFrom.ValueMember = "CFCode";
                comboBoxFrom.DisplayMember = "CFText";
                comboBoxFrom.SelectedValue = "";
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation,
                               "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }
        }
        public void BindDataPersonel(int _pIntseq)
        {
            try
            {
                DerUtility.MouseOn(this);
            //    dgvData.Rows.Clear();
                pIntseq = _pIntseq;
                var info = new Entity.Customer {PageNumber = _pIntseq};

                info.QueryType = "SELECTCustomerConnect";
                info.StartDate = dateTimePickerStart.Value;
                info.EndDate = dateTimePickerEnd.Value;

                //info.BranchID = uBranch1.BranchId;
               
                dtCust = new Business.Customer().SelectCustomerConnect(info).Tables[0];

                long lngTotalPage = 0;
                long lngTotalRecord = 0;
                if (dtCust.Rows.Count <= 0)
                {
                    ngbMain.CurrentPage = 0;
                    ngbMain.TotalPage = 0;
                    ngbMain.TotalRecord = 0;
                    ngbMain.Updates();
                    DerUtility.MouseOff(this);
                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "ไม่พบข้อมูลในระบบ");
                    return;
                }
                dgvData.DataSource = null;

                dgvData.DataSource = dtCust;

                    //if (lngTotalPage != 0) continue;
                    DerUtility.FindTotalPage(Convert.ToInt32(dgvData.RowCount), ref lngTotalPage);
                    lngTotalRecord = dgvData.RowCount;
                //SetColumns();
                //ngbMain.CurrentPage = pIntseq;
                //ngbMain.TotalPage = lngTotalPage;
                //ngbMain.TotalRecord = lngTotalRecord;
                //ngbMain.Updates();
               // lbCount.Text = string.Format("{0} Item", (dgvData.RowCount - 1).ToString());

                //dgvData.Columns[0].Visible = false;
                ngbMain.CurrentPage = _pIntseq;
                ngbMain.TotalPage = lngTotalPage;
                ngbMain.TotalRecord = lngTotalRecord;
                ngbMain.Updates();
                DerUtility.MouseOff(this);
             //   menuDel.Enabled = dgvData.RowCount != 1;
                
                 dgvData.Columns["CFCode"].Visible=false;
                 dgvData.Columns["ID"].Visible = false;
                 dgvData.Columns["EN_Consult"].Visible = false;
                 
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
            finally
            {
                SetNumberAllRows();
            }
        }

        private void CallForm(CallMode cMode)
        {
            try
            {
                
                Statics.frmPersonnelSetting = new FrmPersonnelSetting();
                //Statics.frmCustormerSetting.StartPosition = FormStartPosition.CenterScreen;
                //Statics.frmCustormerSetting.WindowState = FormWindowState.Maximized;
                //Statics.frmCustormerSetting.MdiParent = ActiveForm;
                if (cMode == CallMode.Preview)
                {
                    Statics.frmPersonnelSetting.FormType = DerUtility.AccessType.DisplayOnly;
                }
                else if (cMode == CallMode.Update)
                {
                    Statics.frmPersonnelSetting.FormType = DerUtility.AccessType.Update;
                }

                Statics.frmPersonnelSetting.en = dgvData.Rows[rowIndex].Cells["EN"].Value + "";
                Statics.frmPersonnelSetting.Text += Statics.StrEdit;
                Statics.frmPersonnelSetting.BackColor = Color.FromArgb(255, 230, 217);
                Statics.frmPersonnelSetting.Show(Statics.frmMain.dockPanel1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void DeleteData()
        {
        
            try
            {
                try
                {

                    if (txtID.Text=="") return;

                    if (!(Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN))
                    {
                        DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "Is not admin");
                        return;
                    }

                    if (
                        DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirmYesNo,
                                       Statics.StrConfirmDelete + txtName.Text + "") ==
                        DialogResult.Yes)
                    {
                        try
                        {
                            var info = new Entity.Customer();
                            info.CFID =Convert.ToInt32(txtID.Text);
                            info.EN = Userinfo.EN;
                            if (new Business.Customer().DeleteContactById(info) > 0)
                            {
                                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, Statics.StrMsgDeleteComplete);
                                ResetText();
                                BindDataPersonel(1);
                            }
                        }
                        catch (Exception ex)
                        {
                            DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, Statics.StrMsgDeleteError + ex);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, Statics.StrMsgDeleteError + ex);
            }
            //}
        }

        private void FrmCustomerConnectList_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics.frmCustomerConnectList = null;
        }

        private void FrmCustomerConnectList_Activated(object sender, EventArgs e)
        {
            Statics.SetToolbar(true, true, true, true, true);
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            rowIndex = e.RowIndex;
            BindEdit(rowIndex);
        }
        private void ResetText()
        {
            try
            {
                txtID.Text = "";
                txtName.Text = "";
                comboBoxFrom.SelectedValue = "";
                txtMobile.Text = "";
                txtContactFB_IN_LineID.Text = "";
                txtInterest.Text = "";
                dpDateConnect.Value = DateTime.Now;
                dpDateBooking.Value= DateTime.Now;
                
                //DateTime myDate = dpDateBooking.Value.Date + dpDateBooking.Value.TimeOfDay;

                //dpDateBooking.Value = myDate.Date;
                //dateTimePickerTime.Value = myDate.TimeOfDay; 
                cboBranch.SelectedIndex = 0;

                checkBoxDateBooking.Checked = false;
                dpDateBooking.Enabled = false;

                txtCloseBal.Text = "";
                txtRemark.Text = "";
           
                comboBoxCommission1.SelectedValue = Entity.Userinfo.EN;
          
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BindEdit(int ind)
        {
            try
            {
                 //,c.[ContactName]
                 // ,c.[ContactFrom]
                 // ,c.[Mobile]
                 // ,c.[ContactFB_IN_LineID]
                 // ,c.[Interest]
                 // ,c.[DateConnect]
                 // ,c.[DateBooking]
                 // ,c.[CloseBal]
                 // ,c.[Remark]
                 // ,c.[EN_Consult]
                 // ,c.[DateSave]
                 // ,(p.PrefixCode + p.[TName] +' '+ p.[TSurname] + case when p.TNickname<>'' then '('+p.TNickname+')' else '' end) as Consult
                ResetText();

                txtID.Text=dgvData.Rows[ind].Cells["ID"].Value+"";
                txtName.Text = dgvData.Rows[ind].Cells["ContactName"].Value + "";
                comboBoxFrom.SelectedValue = dgvData.Rows[ind].Cells["CFCode"].Value + "";
                txtMobile.Text = dgvData.Rows[ind].Cells["Mobile"].Value + "";
                txtContactFB_IN_LineID.Text = dgvData.Rows[ind].Cells["LineID"].Value + "";
                txtInterest.Text = dgvData.Rows[ind].Cells["Interest"].Value + "";
                dpDateConnect.Value = Convert.ToDateTime(dgvData.Rows[ind].Cells["DateConnect"].Value + "");

                checkBoxDateBooking.Checked = false;
                dpDateBooking.Enabled = false;
                checkBoxDateBooking.Checked = dgvData.Rows[ind].Cells["DateBooking"].Value + "" != "";
                dpDateBooking.Enabled = dgvData.Rows[ind].Cells["DateBooking"].Value + "" != "";
                dpDateBooking.Value = dgvData.Rows[ind].Cells["DateBooking"].Value + ""==""?DateTime.Now:Convert.ToDateTime(dgvData.Rows[ind].Cells["DateBooking"].Value + "");
                txtCloseBal.Text = Convert.ToDecimal(dgvData.Rows[ind].Cells["Price"].Value + "").ToString("###,###,###.##");
                txtRemark.Text = dgvData.Rows[ind].Cells["Remark"].Value + "";
                //lbConsult.Text = dgvData.Rows[ind].Cells["Consult"].Value + "";
                comboBoxCommission1.SelectedValue = dgvData.Rows[ind].Cells["EN_Consult"].Value + "";
                buttonDelete21.Visible = dgvData.Rows[ind].Cells["EN_Save"].Value + "" == Userinfo.EN;
                buttonDelete21.Visible = (Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN);

                cboBranch.SelectedValue = dgvData.Rows[ind].Cells["BookBranchId"].Value + "";
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
        }

        private void dgvData_Sorted(object sender, EventArgs e)
        {
            SetNumberAllRows();
        }


        private void SetNumberAllRows()
        {
            long rowStart = (DerUtility.ROW_PER_PAGE * (pIntseq - 1));
            for (int i = 0; i < dgvData.Rows.Count; i++)
            {
                rowStart += 1;
                dgvData.Rows[i].HeaderCell.Value = rowStart.ToString();
            }
        }

     

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            //Graphics gfx = e.Graphics;
            //Pen p = new Pen(Color.Black, 3);
            ////gfx.DrawLine(p, 0, 5, 0, e.ClipRectangle.Height - 2);
            ////gfx.DrawLine(p, 0, 5, 10, 5);
            ////gfx.DrawLine(p, 62, 5, e.ClipRectangle.Width - 2, 5);
            //gfx.DrawLine(p, e.ClipRectangle.Width - 2, 5, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2);
            //gfx.DrawLine(p, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2, 0, e.ClipRectangle.Height - 2);  
        }

        private void groupBox3_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            Pen p = new Pen(Color.Black, 1);
            gfx.DrawLine(p, 0, 5, 0, e.ClipRectangle.Height - 2);
            //gfx.DrawLine(p, 0, 5, 10, 5);
            gfx.DrawLine(p, 74, 5, e.ClipRectangle.Width - 2, 5);//เส้นนอนกรอบบน ส่วนหลังตัวหนังสือ
            gfx.DrawLine(p, 0, 5, 10, 5);//เส้นนอนกรอบบน ส่วนหน้า
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, 5, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2, 0, e.ClipRectangle.Height - 2);  
        }

        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            Pen p = new Pen(Color.Black, 1);
            gfx.DrawLine(p, 0, 5, 0, e.ClipRectangle.Height - 2);
            //gfx.DrawLine(p, 0, 5, 10, 5);
            gfx.DrawLine(p, 38, 5, e.ClipRectangle.Width - 2, 5);//เส้นนอนกรอบบน ส่วนหลังตัวหนังสือ
            gfx.DrawLine(p, 0, 5, 10, 5);//เส้นนอนกรอบบน ส่วนหน้า
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, 5, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2, 0, e.ClipRectangle.Height - 2);  
        }

        private void buttonSave1_BtnClick()
        {
            SaveCF();
        }
        private void SaveCF()
        {
            try
            {
                if (txtName.Text.Length < 5) { MessageBox.Show("ระบุชื่อลูกค้า"); return; }
                if (comboBoxFrom.SelectedValue + "" == "") { MessageBox.Show("เลือกแหล่งที่มา"); return; }
                int? intStatus = 0;
                Entity.Customer info;

                info = new Entity.Customer();


                info.ContactName = txtName.Text;
                info.ContactFrom = comboBoxFrom.SelectedValue + "";
                info.ContactFB_IN_LineID = txtContactFB_IN_LineID.Text;
                info.Mobile1=txtMobile.Text;
                info.Interest =txtInterest.Text;
                string dateFormat = "yyyy/MM/dd HH:mm";
                string resultdt = dpDateConnect.Value.ToString(dateFormat);
                
                info.DateConnect= Convert.ToDateTime(resultdt);

                
                info.DateBooking = checkBoxDateBooking.Checked ? Convert.ToDateTime(dpDateBooking.Value.ToString(dateFormat)) : (DateTime?)null;
                info.CloseBal = txtCloseBal.Text==""?0:Convert.ToDecimal(txtCloseBal.Text);
                info.EN = Userinfo.EN;
                info.CFID = txtID.Text==""?0:Convert.ToInt32(txtID.Text);
                info.Remark = txtRemark.Text;
                info.SaleConsult = comboBoxCommission1.SelectedValue + "";
                info.BranchId = cboBranch.SelectedValue+"";

                intStatus = new Business.Customer().INSERTCustomerConnect(info);
               
                if (intStatus > 0)
                {

                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, Statics.SaveComplete);
                    ResetText();
                    BindDataPersonel(1);

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBoxDateBooking_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dpDateBooking.Enabled = checkBoxDateBooking.Checked;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonDelete21_BtnClick()
        {
            DeleteData();
        }

        private void btnRefresh_BtnClick_1()
        {
            ResetText();
        }

        private void txtCloseBal_Leave(object sender, EventArgs e)
        {
            try
            {
                txtCloseBal.Text =txtCloseBal.Text==""?"0.00":Convert.ToDecimal(txtCloseBal.Text).ToString("###,###,###.##");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void buttonPrint1_BtnClick()
        {
            try
            {
                //PrintDGV.Print_DataGridView(dgvData);
                PrintList();
                
            }
            catch (Exception)
            {

            }
        }
        private void PrintList()
        {
            try
            {
                FrmPreviewRpt obj = new FrmPreviewRpt();
                DataRow dr;
                obj.PrintType = "";


                obj.FormName = "RptCustomerConnect";
     

                //obj.SumUnpaid = Convert.ToDouble(dtTmp.Rows[0]["Unpaid"]);//.Compute("Sum(Unpaid)", ""));
                obj.dt = dtCust.DefaultView.ToTable(); 
                obj.MaximizeBox = true;
                obj.TopMost = true;
                obj.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dtCust.DefaultView.RowFilter = string.Format("[_RowString] LIKE '%{0}%'", txtFilter.Text);
            }
            catch (Exception)
            {

            }
        }

    }
}
