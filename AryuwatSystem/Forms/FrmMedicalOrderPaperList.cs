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
using WeifenLuo.WinFormsUI.Docking;
        using System.Runtime.InteropServices;



namespace AryuwatSystem.Forms
{
    public partial class FrmMedicalOrderPaperList : DockContent, IForm
    {
        [DllImport("user32.dll")]
        private static extern int GetSystemMetrics(int nIndex);
// System metric constant for Windows XP Tablet PC Edition
private const int SM_TABLETPC = 86;
private readonly bool tabletEnabled;
        DataTable dtList = new DataTable();
        DataTable dtListOrg = new DataTable();
        protected bool IsRunningOnTablet()
        {
            return (GetSystemMetrics(SM_TABLETPC) != 0);
        }
        public FrmMedicalOrderPaperList()
        {
            InitializeComponent();

            //KeyPress += MainForm_KeyPress;
            //KeyUp += MainForm_KeyUp;
            //MouseDown += MainForm_MouseDown;
        }
        //private void MainForm_MouseDown(object sender, MouseEventArgs e)
        //{
        //    label1.Text = "MainForm_MouseDown";
        //}
        //private void MainForm_KeyUp(object sender, KeyEventArgs e)
        //{
        //    label1.Text = "MainForm_KeyUp";
        //}
        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show( "MainForm_KeyUp");
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
            BindDataMedicalOrder(1);
        }

        void IForm.IsEdit()
        {
            CallForm(Statics.CallMode.Update);
        }

        void IForm.IsPrint()
        {
        }

        void IForm.IsNew()
        {
            NewMedicalOrder();
        }

        void IForm.IsExit()
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        #endregion
        #region Enum CallMode

        //private enum CallMode
        //{
        //    Insert,
        //    Update,
        //    Preview,
        //    Ref
        //}
        #endregion
        #region Private Member
        /// <summary>
        /// CNL (Local) CNA (Agency) และ CNM (Manager)  
        /// </summary>
        public string TypeCustomer { get; set; }
        private int rowIndex = 0;
        private bool firstload = true;
        private string MedStatus_CodeNew = "";
        private string MedStatus_CodePending = "";
        private string MedStatus_CodeClosed = "";
        private string MedStatus_Code = "";
        #endregion

        private void NewMedicalOrder()
        {
            //Statics.frmMedicalOrderSetting = new FrmMedicalOrderSetting();
            //Statics.frmMedicalOrderSetting.BackColor = Color.FromArgb(255, 230, 217);
            //Statics.frmMedicalOrderSetting.Text = Text + Statics.StrAdd;
            //Statics.frmMedicalOrderSetting.Show(Statics.frmMain.dockPanel1);

            Statics.frmMedicalOrderSettingPro = new FrmMedicalOrderSettingPro();
            Statics.frmMedicalOrderSettingPro.BackColor = Color.FromArgb(255, 230, 217);
            //Statics.frmMedicalOrderSettingPro.Text = Text + Statics.StrAdd;
            Statics.frmMedicalOrderSettingPro.Show(Statics.frmMain.dockPanel1);
        }

        private void FrmMedicalOrderPaperList_Load(object sender, EventArgs e)
        {
            timer1.Interval = Entity.Userinfo.RefreshData;
            InitialControls();
            firstload = false;
            txtEnddate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            txtStartdate.Text = DateTime.Now.AddYears(-5).ToString("yyyy/MM/dd");
            //BindDataMedicalOrder(1);
            //timer1.Start();

            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;
           // uBranch1.setBranchValue(Entity.Userinfo.BranchId);

        }

      

        private void InitialControls()
        {
            SetColumns();
            AddEvent();
        }


//protected bool IsRunningOnTablet()
//{
//    return (GetSystemMetrics(SM_TABLETPC) != 0);
//}
        private void SetColumns()
        {
            try
            {
                DerUtility.SetPropertyDgv(dgvData);

                dgvData.Columns.Add("DateRefVN", "วันที่/Date");
                dgvData.Columns.Add("RefVN", "ใบยา");
                
                dgvData.Columns.Add("CN", "CN");
                dgvData.Columns.Add("FullNameThai", "ชื่อ-นามสกุล/Name");
                dgvData.Columns.Add("SalePrice", "จำนวนเงิน/Total");
                dgvData.Columns.Add("Consult", "Consult");
                dgvData.Columns.Add("BranchName", "สาขา");

                dgvData.Columns["RefVN"].Width = 200;
                dgvData.Columns["CN"].Width = 100;
                dgvData.Columns["FullNameThai"].Width = 150;
                dgvData.Columns["DateRefVN"].Width = 80;
                dgvData.Columns["SalePrice"].Width = 80;
                dgvData.Columns["SalePrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //dgvData.Columns["SORef"].Visible = false;
                //dgvData.Columns["PriceCreditRef"].Visible = false;
                if (IsRunningOnTablet())
                {
                    dgvData.RowTemplate.Height = 50;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void AddEvent()
        {
            ngbMain.MoveFirst += ngbMain_MoveFirst;
            ngbMain.MoveNext += ngbMain_MoveNext;
            ngbMain.MoveLast += ngbMain_MoveLast;
            ngbMain.MovePrevious += ngbMain_MovePrevious;

            dgvData.RowPostPaint += dgvData_RowPostPaint;
            dgvData.CellMouseClick += dgvData_CellMouseClick;
            buttonFind.BtnClick += buttonFind_BtnClick;
            //btnRefresh.BtnClick += btnRefresh_BtnClick;
            this.KeyPreview = true;
            //this.KeyPress += new KeyPressEventHandler(FrmMedicalOrderPaperList_KeyPress);
            menuEdit.Click += new EventHandler(menuEdit_Click);
            menuPreview.Click += new EventHandler(menuPreview_Click);
            menuDel.Click += new EventHandler(menuDel_Click);
        }


        #region Event
        private void ngbMain_MoveFirst()
        {
            BindDataMedicalOrder(1);
        }

        private void ngbMain_MoveLast()
        {
            BindDataMedicalOrder(Convert.ToInt32(ngbMain.TotalPage));
        }

        private void ngbMain_MoveNext()
        {
            BindDataMedicalOrder(Convert.ToInt32(Convert.ToInt32(ngbMain.CurrentPage) + 1));
        }

        private void ngbMain_MovePrevious()
        {
            BindDataMedicalOrder(Convert.ToInt32(Convert.ToInt32(ngbMain.CurrentPage) - 1));
        }

        private void dgvData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        private void buttonFind_BtnClick()
        {
            BindDataMedicalOrder(1);
        }

        void btnRefresh_BtnClick()
        {
            txtVN.Text = "";
            txtName.Text = "";
            txtProduct.Text = "";
            txtCN.Text = "";
        }

        void FrmMedicalOrderPaperList_KeyPress(object sender, KeyPressEventArgs e)
        {
            DerUtility.SendKey(e.KeyChar);
        }

        private void dgvData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                if (e.Button == MouseButtons.Right)
                {
                    //dgvData.ClearSelection();
                    //dgvData.Rows[rowIndex].Selected = false;
                    dgvData.Rows[e.RowIndex].Selected = true;
                    rowIndex = e.RowIndex;
                    if (dgvData.Rows[e.RowIndex].Cells["VN"].Value.ToString().ToLower() == "")
                    {
                        menuUse.Visible = false;
                        menuDoctorEstimate.Visible = false;
                        menucustomerSign.Visible = false;
                        
                        //ToolStripMenuItemChangCouse.Visible = false;
                    }
                    else
                    {
                        menuUse.Visible = true;
                        menuDoctorEstimate.Visible=true;
                        menucustomerSign.Visible = true;
                        //ToolStripMenuItemChangCouse.Visible = true;
                    }
                    contextMenuStrip1.Show(MousePosition);
                }
            }
            catch
            {
                return;
            }
        }

        private void menuEdit_Click(object sender, EventArgs e)
        {
            CallForm(Statics.CallMode.Update);
        }

        private void menuPreview_Click(object sender, EventArgs e)
        {
            CallForm(Statics.CallMode.Preview);
        }

        private void menuDel_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        #endregion
        private void SelectDate(TextBox txt)
        {
            try
            {
                PopDateTime pp = new PopDateTime();
                DateTime d;
                if (txt.Text.Trim() != "")
                    pp.SelecttDate = Convert.ToDateTime(txt.Text.Trim());// DateTime.TryParse(txt.Text, out d) ? d : DateTime.Now;
                else
                    pp.SelecttDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));// DateTime.TryParse(txt.Text, out d) ? d : DateTime.Now;
                //pp.SelecttDate =Convert.ToDateTime(pp.SelecttDate);
                if (pp.ShowDialog() == DialogResult.OK)
                {
                    //txt.Text = pp.SelecttDate.Date.ToString("dd/MM/yyyy");
                    txt.Text = pp.SelecttDate.Date.ToString("yyyy/MM/dd");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void BindDataMedicalOrder(int pIntseq)
        {
            try
            {
                bind = false;
                DerUtility.MouseOn(this);
                dgvData.Rows.Clear();
                var info = new Entity.MedicalOrder() { PageNumber = pIntseq };
                Entity.Customer custInfo = new Customer();

                if (!string.IsNullOrEmpty(txtCN.Text.Trim()))
                {
                    custInfo.CN = "%" + txtCN.Text.Trim() + "%";
                }
                if (!string.IsNullOrEmpty(txtName.Text.Trim()))
                {
                    custInfo.TName = "%" + txtName.Text.Trim() + "%";
                }
                if (!string.IsNullOrEmpty(txtSurName.Text.Trim()))
                {
                    custInfo.TSurname = "%" + txtSurName.Text.Trim() + "%";
                }
                
                if (!string.IsNullOrEmpty(txtProduct.Text.Trim()))
                {
                    info.Product = "%" + txtProduct.Text.Trim() + "%";
                }
                if (!string.IsNullOrEmpty(txtVN.Text.Trim()))
                {
                    info.VN = "%" + txtVN.Text.Trim() + "%";
                }
                //if (!string.IsNullOrEmpty(this.txtCo.Text.Trim()))
                //{
                //    info.CO = "%" + this.txtCo.Text.Trim() + "%";
                //}
                if (!string.IsNullOrEmpty(this.txtSo.Text.Trim()))
                {
                    info.SONo = "%" + this.txtSo.Text.Trim() + "%";
                }
                if (checkBoxOld.Checked)
                {
                    info.OldKey = "%Y%";
                }

                if (!string.IsNullOrEmpty(txtStartdate.Text.Trim()))
                {
                    info.StartDate = txtStartdate.Text;
                }
                if (!string.IsNullOrEmpty(txtEnddate.Text.Trim()))
                {
                    info.EndDate = Convert.ToDateTime(txtEnddate.Text).AddDays(1) + "";
                }
                if (!string.IsNullOrEmpty(txtRefMo.Text.Trim()))
                {
                    info.RefMO = "%" + txtRefMo.Text.Trim() + "%";
                }

                info.CustomerInfo = custInfo;
                MedStatus_CodeNew = checkBoxNew.Checked ? "0" : null;
                MedStatus_CodePending = checkBoxPending.Checked ? "1" : null;
                MedStatus_CodeClosed = checkBoxClose.Checked ? "2" : null;
                //info.MedStatus_Code = string.Format("''{0}'',''{1}'',''{2}''", MedStatus_CodeNew, MedStatus_CodePending, MedStatus_CodeClosed);
                info.MedStatus_CodeNew = MedStatus_CodeNew;
                info.MedStatus_CodePending = MedStatus_CodePending;
                info.MedStatus_CodeClosed = MedStatus_CodeClosed;
                info.MedStatus_Unpaid = checkBoxUnpaid.Checked ? "6" : null;
                info.MedStatus_Deposit = checkBoxDeposit.Checked ? "7" : null;
                info.MedStatus_Paid = checkBoxPaid.Checked ? "8" : null;
                info.BranchId = uBranch1.BranchId;

                info.QueryType = "SEARCH_RefVN";
                DataSet ds = new Business.MedicalOrder().SelectMedicalOrderPaging(info);
                dtList = ds.Tables[0];
                dtListOrg = ds.Tables[1];
                decimal SalePrice = 0;
                long lngTotalPage = 0;
                long lngTotalRecord = 0;
                if (dtList.Rows.Count <= 0)
                {
                    ngbMain.CurrentPage = 0;
                    ngbMain.TotalPage = 0;
                    ngbMain.TotalRecord = 0;
                    ngbMain.Updates();
                    DerUtility.MouseOff(this);
                    // Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "ไม่พบข้อมูลในระบบ");
                    return;
                }
                decimal PriceCreditRef = 0;
                foreach (DataRowView item in dtList.DefaultView)
                {
                    SalePrice = item["PriceAfterDis"] + "" == "" ? 0 : Convert.ToDecimal(item["PriceAfterDis"] + "");
                    //PriceCreditRef = item["PriceCreditRef"] + "" == "" ? 0 : Convert.ToDecimal(item["PriceCreditRef"] + "");
                    object[] myItems = {
                                           item["DateRefVN"]+""!=""?String.Format("{0:dd/MM/yyyy}",DateTime.Parse( item["DateRefVN"]+"")):"",
                                          item["RefVN"] + "",
                                          item["CN"]+"",
                                          item["FullNameThai"] + ""!=""?item["FullNameThai"] + "":item["FullNameEng"] + "",
                                          SalePrice.ToString("###,###,###.##"),
                                           item["Consult"] + "",
                                           item["BranchName"] + "",
                                      };
                    dgvData.Rows.Add(myItems);
                    //dgvData.Columns.Clear();
                    //dgvData.DataSource=null;
                    //dgvData.DataSource = dtList;

                    if (lngTotalPage != 0) continue;
                    DerUtility.FindTotalPage(Convert.ToInt32(item["rowTotal"].ToString()), ref lngTotalPage);
                    lngTotalRecord = Convert.ToInt32(item["rowTotal"].ToString());
                }

               // FilterSOMO(checkBoxSO.Checked, checkBoxMO.Checked);
                //dgvData.Columns.Clear();
                //dgvData.DataSource = null;
                //dgvData.DataSource = dtList;
                //foreach (DataGridViewRow dataRow in dgvData.Rows)
                //{
                //    MedStatus_Code = dataRow.Cells["MedStatus_Code"].Value.ToString();

                //    if (MedStatus_Code == "0" || MedStatus_Code == "" || MedStatus_Code == "6")
                //        dataRow.DefaultCellStyle.BackColor = Color.DarkGray;
                //    else if (MedStatus_Code == "1" || MedStatus_Code == "7")
                //        dataRow.DefaultCellStyle.BackColor = Color.Khaki;
                //    else if (MedStatus_Code == "2" || MedStatus_Code == "8")
                //        dataRow.DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                //    else if (MedStatus_Code == "3")
                //        dataRow.DefaultCellStyle.BackColor = Color.LightBlue;
                //    else if (MedStatus_Code == "99")
                //    {
                //        dataRow.DefaultCellStyle.BackColor = Color.AntiqueWhite;
                //        dataRow.DefaultCellStyle.Font = new Font(dgvData.DefaultCellStyle.Font, FontStyle.Strikeout);
                //    }
                //}

                dgvData.RowsDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
                for (int i = 0; i < dgvData.Columns.Count - 1; i++)
                {
                    dgvData.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                //dgvData.Columns[dgvData.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                for (int i = 0; i < dgvData.Columns.Count; i++)
                {
                    int colw = dgvData.Columns[i].Width;
                    dgvData.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvData.Columns[i].Width = colw;
                }
                
                dgvData.ClearSelection();
                ngbMain.CurrentPage = pIntseq;
                ngbMain.TotalPage = lngTotalPage;
                ngbMain.TotalRecord = lngTotalRecord;
                ngbMain.Updates();
                DerUtility.MouseOff(this);
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
        }

        private void CallForm(Statics.CallMode cMode)
        {
            try
            {

            //    if (!(Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN)  && dgvData.Rows[rowIndex].Cells["MedStatus_Code"].Value + ""=="99")
            //    {
            //        //Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "ไม่สามารถลบรายการนี้ได้เนื่องจาก มีการใช้หรือชำระเงินไปแล้ว\"Cannot delete.\"");
            //        DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "Is not admin");
            //        return;
            //    }
            //if (dgvData.Rows[rowIndex].Cells["SORef"].Value + ""!="")// เปิด med procredit
            //{
            //    if (dgvData.Rows[rowIndex].Cells["SORef"].Value + "" != "")
            //    {
            //        Statics.frmMedicalOrderSettingPro = new FrmMedicalOrderSettingPro();

            //        Statics.frmMedicalOrderSettingPro.FormType = DerUtility.AccessType.Update;
            //        Statics.frmMedicalOrderSettingPro.Text = Text + Statics.StrEdit;
            //        Statics.frmMedicalOrderSettingPro.VN = dgvData.Rows[rowIndex].Cells["VN"].Value + "";
            //        Statics.frmMedicalOrderSettingPro.SO = dgvData.Rows[rowIndex].Cells["SONo"].Value + "";
            //        Statics.frmMedicalOrderSettingPro.MedStatus_Code = dgvData.Rows[rowIndex].Cells["MedStatus_Code"].Value + "";
            //        Statics.frmMedicalOrderSettingPro.SORef = dgvData.Rows[rowIndex].Cells["SORef"].Value + "";
            //        Statics.frmMedicalOrderSettingPro.ProCreditRemain = dgvData.Rows[rowIndex].Cells["PriceCreditRef"].Value + "" == "" ? 0 : Convert.ToDecimal(dgvData.Rows[rowIndex].Cells["PriceCreditRef"].Value + "");
            //        Statics.frmMedicalOrderSettingPro.BackColor = Color.FromArgb(255, 230, 217);
            //        Statics.frmMedicalOrderSettingPro.Show(Statics.frmMain.dockPanel1);
            //    }

            //}
            //else//เปิด med ธรรมดา
            //{
                //Statics.frmMedicalOrderSettingPro = new FrmMedicalOrderSettingPro();
                //if (cMode == Statics.CallMode.Preview)
                //{
                //    Statics.frmMedicalOrderSettingPro.FormType = DerUtility.AccessType.DisplayOnly;
                //    Statics.frmMedicalOrderSettingPro.Text = Text + Statics.StrPreview;
                //}
                //else if (cMode == Statics.CallMode.Update)
                //{
                //    Statics.frmMedicalOrderSettingPro.FormType = DerUtility.AccessType.Update;
                //    Statics.frmMedicalOrderSettingPro.Text = Text + Statics.StrEdit;
                //}
                Statics.frmMedicalOrderSettingPaper = new FrmMedicalOrderSettingPaper();
                Statics.frmMedicalOrderSettingPaper.RefVN = dgvData.Rows[rowIndex].Cells["RefVN"].Value + "";
                Statics.frmMedicalOrderSettingPaper.FormType = DerUtility.AccessType.Update;
                //if(dgvData.Rows[rowIndex].Cells["VN"].Value + ""=="")
                //Statics.frmMedicalOrderSettingPaper.SO = dgvData.Rows[rowIndex].Cells["SONo"].Value + "";
                //Statics.frmMedicalOrderSettingPaper.MedStatus_Code = dgvData.Rows[rowIndex].Cells["MedStatus_Code"].Value + "";

                Statics.frmMedicalOrderSettingPaper.BackColor = Color.FromArgb(255, 230, 217);
                Statics.frmMedicalOrderSettingPaper.Show(Statics.frmMain.dockPanel1);

                //================================================================
                //Statics.frmMedicalOrderSetting = new FrmMedicalOrderSetting();
                //if (cMode == Statics.CallMode.Preview)
                //{
                //    Statics.frmMedicalOrderSetting.FormType = Utility.AccessType.DisplayOnly;
                //    Statics.frmMedicalOrderSetting.Text = Text + Statics.StrPreview;
                //}
                //else if (cMode == Statics.CallMode.Update)
                //{
                //    Statics.frmMedicalOrderSetting.FormType = Utility.AccessType.Update;
                //    Statics.frmMedicalOrderSetting.Text = Text + Statics.StrEdit;
                //}

                //Statics.frmMedicalOrderSetting.VN = dgvData.Rows[rowIndex].Cells["VN"].Value + "";
                ////if(dgvData.Rows[rowIndex].Cells["VN"].Value + ""=="")
                //Statics.frmMedicalOrderSetting.SO = dgvData.Rows[rowIndex].Cells["SONo"].Value + "";
                //Statics.frmMedicalOrderSetting.MedStatus_Code = dgvData.Rows[rowIndex].Cells["MedStatus_Code"].Value + "";

                //Statics.frmMedicalOrderSetting.BackColor = Color.FromArgb(255, 230, 217);
                //Statics.frmMedicalOrderSetting.Show(Statics.frmMain.dockPanel1);
            //}
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

         
            if (dgvData.CurrentRow.Index == -1) return;
            //if (dgvData.CurrentRow.Cells["MedStatus_Code"].Value + "" != "0" && dgvData.CurrentRow.Cells["MedStatus_Code"].Value + "" != "6")
            if (!(Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN))
            {
                //Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "ไม่สามารถลบรายการนี้ได้เนื่องจาก มีการใช้หรือชำระเงินไปแล้ว\"Cannot delete.\"");
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "Is not admin");
                return;
            }
            if (
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirmYesNo,
                               Statics.StrConfirmDelete + dgvData.CurrentRow.Cells["VN"].Value + "") ==
                DialogResult.Yes)
            {
                try
                {
                    if (
                        new Business.MedicalOrder().DeleteMedicalOrderById(dgvData.CurrentRow.Cells["VN"].Value + ""    ,dgvData.CurrentRow.Cells["SoNo"].Value + "") ==
                        1)
                    {
                        DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, Statics.StrMsgDeleteComplete);
                        BindDataMedicalOrder(1);
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

        private void FrmMedicalOrderPaperList_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics.frmMedicalOrderPaperList = null;
        }

        private void FrmMedicalOrderPaperList_Activated(object sender, EventArgs e)
        {
            Statics.SetToolbar(true, true, true, true, true);
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;

            CallForm(Statics.CallMode.Update);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //BindDataMedicalOrder(1);
        }

        private void menuUse_Click(object sender, EventArgs e)
        {
            try
            {
                   FrmMedicalUseList obj = new FrmMedicalUseList();
            obj.VN = dgvData.Rows[rowIndex].Cells["VN"].Value + "";
            obj.SONo = dgvData.Rows[rowIndex].Cells["SONo"].Value + "";
            obj.BranchName = dgvData.Rows[rowIndex].Cells["SONo"].Value + "";
            string SODate =dgvData.Rows[rowIndex].Cells["UpdateDate"].Value + "";

            string[] txt = SODate.Split('/');//19/03/2019
            if (Convert.ToInt16(txt[1]) > 12 || Convert.ToInt16(txt[2]) < 2000)
            {
                //string c = DateTime.Now.ToString("dd/MM/yyyy");
                MessageBox.Show("Date format incorrect");
            }
            else
            {
                SODate = string.Format("{0}/{1}/{2}", txt[2], txt[1], txt[0]);
                obj.SODate = Convert.ToDateTime(SODate);
            }

            obj.BackColor = Color.FromArgb(255, 230, 217);
            obj.Show(Statics.frmMain.dockPanel1);
            //obj.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
         

        private void checkBoxNew_CheckedChanged(object sender, EventArgs e)
        {
            if (firstload == false)
                BindDataMedicalOrder(1);
        }

        private void checkBoxPending_CheckedChanged(object sender, EventArgs e)
        {
            if (firstload == false)
                BindDataMedicalOrder(1);
        }

        private void checkBoxClose_CheckedChanged(object sender, EventArgs e)
        {
            if (firstload == false)
                BindDataMedicalOrder(1);
        }
        private void checkBoxOld_CheckedChanged(object sender, EventArgs e)
        {
            if (firstload == false)
                BindDataMedicalOrder(1);
        }
        private void ToolStripMenuItemChangCouse_Click(object sender, EventArgs e)
        {
             new FrmMedicalUseChangCouse { VN = this.dgvData.Rows[this.rowIndex].Cells["VN"].Value+"", BackColor = Color.FromArgb(170, 0xe8, 0xe5) }.Show(Statics.frmMain.dockPanel1);
        }

        bool bind = true;

        private void FrmMedicalOrderPaperList_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void txtSo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            BindDataMedicalOrder(1);
        }

        private void txtCo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            BindDataMedicalOrder(1);
        }

        private void txtVN_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            BindDataMedicalOrder(1);
        }

        private void txtCN_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            BindDataMedicalOrder(1);
        }

        private void txtName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            BindDataMedicalOrder(1);
        }

        private void txtSurname_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            BindDataMedicalOrder(1);
        }

       

        private void txtStartdate_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelectDate(txtStartdate);
        }

        private void txtEnddate_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelectDate(txtEnddate);
        }

        private void txtStartdate_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                BindDataMedicalOrder(1);
        }

        private void txtEnddate_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                BindDataMedicalOrder(1);
        }

        private void txtRefMo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                BindDataMedicalOrder(1);
        }

        private void checkBoxSO_Click(object sender, EventArgs e)
        {
            FilterSOMO(checkBoxSO.Checked, checkBoxMO.Checked);
        }

        private void checkBoxMO_Click(object sender, EventArgs e)
        {
            FilterSOMO(checkBoxSO.Checked,checkBoxMO.Checked);
        }

        private void FilterSOMO(bool so,bool mo)
        {
            try
            {
                if(so==false && mo==false)
                  return;
                else if(so==true && mo==false)//SO only
                    dtList.DefaultView.RowFilter = string.Format("[Sono] <>'' and [VN]='' ");
                else if (so == false && mo == true)//MO only
                      dtList.DefaultView.RowFilter = string.Format("[VN]<>'' ");
               // if (so && mo) dtList = dtListOrg.Copy();


                foreach (DataGridViewRow dataRow in dgvData.Rows)
                {
                    MedStatus_Code = dataRow.Cells["MedStatus_Code"].Value.ToString();

                    if (MedStatus_Code == "0" || MedStatus_Code == "" || MedStatus_Code == "6")
                        dataRow.DefaultCellStyle.BackColor = Color.DarkGray;
                    if (MedStatus_Code == "1" || MedStatus_Code == "7")
                        dataRow.DefaultCellStyle.BackColor = Color.Khaki;
                    if (MedStatus_Code == "2" || MedStatus_Code == "8")
                        dataRow.DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                    if (MedStatus_Code == "3")
                        dataRow.DefaultCellStyle.BackColor = Color.LightBlue;
                }
                dgvData.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

      

        private void dgvData_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex < 0 || e.RowIndex < 0 || (dgvData.Columns[e.ColumnIndex].Name.ToLower() != "sono" && dgvData.Columns[e.ColumnIndex].Name.ToLower() != "vn"))
                {
                    //panelTootip.Visible = false;
                    toolTip1.Hide(this);
                    return;
                }
                string tt = "";
                //toolTip1.Show(dgvData[e.ColumnIndex,e.RowIndex].Value.ToString(),);
                  //toolTip1.Show(dgvData[e.ColumnIndex,e.RowIndex].Value.ToString(), (Control)sender);
                //lbTooltip.Text = dgvData["VN", e.RowIndex].Value.ToString() + Environment.NewLine + dgvData["Sono", e.RowIndex].Value.ToString();
             tt=   SelectProductPopup(dgvData["Sono", e.RowIndex].Value.ToString(),dgvData["VN", e.RowIndex].Value.ToString());
             dgvData.CurrentCell = dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex];
             Point p = new Point(MousePosition.X - 100, MousePosition.Y-120);
             // Point p = new Point(MousePosition.X , MousePosition.Y );-120
                  Point p2 = this.PointToScreen(p);
               //   panelTootip.Location = p2;
                  //panelTootip.Visible = true;

                  //toolTip1.SetToolTip(this,tt);
                  toolTip1.Show(tt, this, p2.X, p2.Y);
                  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private string SelectProductPopup(string so,string mo)
        {
            string product = "";

            try
            {
                string sql = string.Format("VN ='{0}' and Sono ='{1}'", mo,so);
                var filter = dtListOrg.Select(sql);
                if (filter.Any())
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (DataRow dr in filter)
                    {
                        sb.Append(" "+dr["MS_Name"]);
                        sb.Append(Environment.NewLine);
                    }
                    product = sb.ToString();
                }
            }
            catch (Exception ex)
            {
                          }
            return product;
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex < 0 || e.RowIndex < 0 || dgvData.Rows[e.RowIndex].Cells["VN"].Value + ""=="") return;
                //string ms_code = dgvData.Rows[e.RowIndex].Cells["Code"].Value + "";
                //string ListOrder = dgvData.Rows[e.RowIndex].Cells["ListOrder"].Value + "";
                if (dgvData.Columns[e.ColumnIndex].Name == "CourseUsed")
                {
                    FrmMedicalUseList obj = new FrmMedicalUseList();
                    obj.VN = dgvData.Rows[e.RowIndex].Cells["VN"].Value + "";
                    obj.SONo = dgvData.Rows[e.RowIndex].Cells["SONo"].Value + "";
                    obj.BranchName = dgvData.Rows[e.RowIndex].Cells["SONo"].Value + "";
                    obj.BackColor = Color.FromArgb(255, 230, 217);
                    obj.Show(Statics.frmMain.dockPanel1);
                }

              //================For Tablet=======================
                if (IsRunningOnTablet())
                {
                    //dgvData.RowTemplate.Height = 50;

                    dgvData.Rows[e.RowIndex].Selected = true;
                    rowIndex = e.RowIndex;
                    if (dgvData.Rows[e.RowIndex].Cells["VN"].Value.ToString().ToLower() == "")
                    {
                        menuUse.Visible = false;
                        menuDoctorEstimate.Visible = false;
                        menucustomerSign.Visible = false;

                        //ToolStripMenuItemChangCouse.Visible = false;
                    }
                    else
                    {
                        menuUse.Visible = true;
                        menuDoctorEstimate.Visible = true;
                        menucustomerSign.Visible = true;
                        //ToolStripMenuItemChangCouse.Visible = true;
                    }
                    contextMenuStrip1.Show(MousePosition);
                }
                //================For Tablet=======================

            }
            catch (Exception ex)
            {

            }
        }

        private void menuDoctorEstimate_Click(object sender, EventArgs e)
        {
            try
            {
                FrmMedicalDoctorEstimate obj = new FrmMedicalDoctorEstimate();
                obj.VN = dgvData.Rows[rowIndex].Cells["VN"].Value + "";
                obj.SONo = dgvData.Rows[rowIndex].Cells["SONo"].Value + "";
                obj.CN = dgvData.Rows[rowIndex].Cells["CN"].Value + "";
                obj.FrmTypeDoctor = true;
                obj.Custname = dgvData.Rows[rowIndex].Cells["FullNameThai"].Value + "";
                obj.BackColor = Color.FromArgb(255, 230, 217);
                obj.Show(Statics.frmMain.dockPanel1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
  
           
        }

        private void menucustomerSign_Click(object sender, EventArgs e)
        {
            try
            {
                FrmMedicalDoctorEstimate obj = new FrmMedicalDoctorEstimate();
                obj.VN = dgvData.Rows[rowIndex].Cells["VN"].Value + "";
                obj.SONo = dgvData.Rows[rowIndex].Cells["SONo"].Value + "";
                obj.CN = dgvData.Rows[rowIndex].Cells["CN"].Value + "";
                obj.FrmTypeDoctor = false;
                obj.Custname = dgvData.Rows[rowIndex].Cells["FullNameThai"].Value + "";
                obj.BackColor = Color.FromArgb(255, 230, 217);
                obj.Show(Statics.frmMain.dockPanel1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
  
        }

        private void txtVN_MouseClick(object sender, MouseEventArgs e)
        {
            DerUtility.GetSetInputKeyBorad("english");
        }

        private void txtRefMo_MouseClick(object sender, MouseEventArgs e)
        {
            DerUtility.GetSetInputKeyBorad("english");
        }

        private void txtCN_MouseClick(object sender, MouseEventArgs e)
        {
            DerUtility.GetSetInputKeyBorad("english");
        }

        private void txtStartdate_MouseClick(object sender, MouseEventArgs e)
        {
            DerUtility.GetSetInputKeyBorad("english");
        }

        private void txtEnddate_MouseClick(object sender, MouseEventArgs e)
        {
            DerUtility.GetSetInputKeyBorad("english");
        }

        private void txtSo_MouseClick(object sender, MouseEventArgs e)
        {
            DerUtility.GetSetInputKeyBorad("english");
        }

        private void txtCo_MouseClick(object sender, MouseEventArgs e)
        {
            DerUtility.GetSetInputKeyBorad("english");
        }

        private void txtProduct_MouseClick(object sender, MouseEventArgs e)
        {
            DerUtility.GetSetInputKeyBorad("english");
        }

        private void txtName_MouseClick(object sender, MouseEventArgs e)
        {
            DerUtility.GetSetInputKeyBorad("thai");
        }

        private void txtSurName_MouseClick(object sender, MouseEventArgs e)
        {
            DerUtility.GetSetInputKeyBorad("thai");
        }

        private void txtSurName_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                BindDataMedicalOrder(1);
        }

        private void picNew_Click(object sender, EventArgs e)
        {
            Statics.frmMedicalOrderSettingPaper = new FrmMedicalOrderSettingPaper();
            Statics.frmMedicalOrderSettingPaper.BackColor = Color.FromArgb(255, 230, 217);
            //Statics.frmMedicalOrderSettingPaper.Text = Text + Statics.StrAdd;
            Statics.frmMedicalOrderSettingPaper.Show(Statics.frmMain.dockPanel1);
        }
        //private void txtSo_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        if (bind)
        //            BindDataMedicalOrder(1);
        //        else
        //        {
        //            bind = true;
        //        }
        //    }
        //}


        }

    }

    
