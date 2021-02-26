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
using WeifenLuo.WinFormsUI.Docking;

namespace DermasterSystem.Forms
{
    public partial class FrmMedicalOrderList : DockContent, IForm
    {
        public FrmMedicalOrderList()
        {
            InitializeComponent();
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
            CallForm(CallMode.Update);
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
        private int rowIndex = 0;
        private bool firstload = true;
        private string MedStatus_CodeNew = "";
        private string MedStatus_CodePending = "";
        private string MedStatus_CodeClosed = "";
        private string MedStatus_Code = "";
        #endregion

        private void NewMedicalOrder()
        {
            Statics.frmMedicalOrderSetting = new FrmMedicalOrderSetting();
            Statics.frmMedicalOrderSetting.BackColor = Color.FromArgb(170, 232, 229);
            Statics.frmMedicalOrderSetting.Text = Text + Statics.StrAdd;
            Statics.frmMedicalOrderSetting.Show(Statics.frmMain.dockPanel1);
        }

        private void FrmMedicalOrderList_Load(object sender, EventArgs e)
        {
            timer1.Interval = Entity.Userinfo.RefreshData;
            InitialControls();
            firstload = false;
            BindDataMedicalOrder(1);
            timer1.Start();
            this.ActiveControl = btnAccept;

        }

      

        private void InitialControls()
        {
            SetColumns();
            AddEvent();
        }

        private void SetColumns()
        {
            try
            {
                Utility.SetPropertyDgv(dgvData);

                dgvData.Columns.Add("MedStatus_Code", "MedStatus_Code");
                dgvData.Columns.Add("MedStatus_Name", "สถานะ/Status");
                dgvData.Columns.Add("UpdateDate", "วันที่/Date");
                dgvData.Columns.Add("VN", "MO");
                dgvData.Columns.Add("SONo", "SO");
                dgvData.Columns.Add("CN", "CN");
                dgvData.Columns.Add("FullNameThai", "ชื่อ-นามสกุล/Name");
                dgvData.Columns.Add("Mobile", "Mobile(มือถือ)");
                dgvData.Columns.Add("SalePrice", "จำนวนเงิน/Total");
                dgvData.Columns.Add("MedStatus_NameUse", "ใช้คอร์ส/Use");


                dgvData.Columns["VN"].Width = 100;
                dgvData.Columns["SONo"].Width = 100;
                dgvData.Columns["CN"].Width = 100;
                dgvData.Columns["FullNameThai"].Width = 150;
                dgvData.Columns["Mobile"].Width = 200;
                dgvData.Columns["UpdateDate"].Width = 80;
                dgvData.Columns["MedStatus_Code"].Visible = false;
                dgvData.Columns["MedStatus_Name"].Width = 80;
                dgvData.Columns["SalePrice"].Width = 80;
                dgvData.Columns["SalePrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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
            btnRefresh.BtnClick += btnRefresh_BtnClick;
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(FrmMedicalOrderList_KeyPress);
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
            txtSurname.Text = "";
            txtCN.Text = "";
        }

        void FrmMedicalOrderList_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.SendKey(e.KeyChar);
        }

        private void dgvData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                if (e.Button == MouseButtons.Right)
                {
                    dgvData.ClearSelection();
                    //dgvData.Rows[rowIndex].Selected = false;
                    dgvData.Rows[e.RowIndex].Selected = true;
                    rowIndex = e.RowIndex;
                    if (dgvData.Rows[e.RowIndex].Cells["VN"].Value.ToString().ToLower() == "")
                    {
                        menuUse.Visible = false;
                        ToolStripMenuItemChangCouse.Visible = false;
                    }
                    else
                    {
                        menuUse.Visible = true;
                        ToolStripMenuItemChangCouse.Visible = true;
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
            CallForm(CallMode.Update);
        }

        private void menuPreview_Click(object sender, EventArgs e)
        {
            CallForm(CallMode.Preview);
        }

        private void menuDel_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        #endregion

        public void BindDataMedicalOrder(int pIntseq)
        {
            try
            {
                bind = false;
                Utility.MouseOn(this);
                dgvData.Rows.Clear();
                var info = new Entity.MedicalOrder() { PageNumber = pIntseq };
                Entity.Customer custInfo = new Customer();

                if (!string.IsNullOrEmpty(txtCN.Text.Trim()))
                {
                    custInfo.CN = "%" + txtCN.Text + "%";
                }
                if (!string.IsNullOrEmpty(txtName.Text))
                {
                    custInfo.TName = "%" + txtName.Text + "%";
                }
                if (!string.IsNullOrEmpty(txtSurname.Text.Trim()))
                {
                    custInfo.TSurname = "%" + txtSurname.Text + "%";
                }
                if (!string.IsNullOrEmpty(txtVN.Text.Trim()))
                {
                    info.VN = "%" + txtVN.Text + "%";
                }
                if (!string.IsNullOrEmpty(this.txtCo.Text.Trim()))
                {
                    info.CO = "%" + this.txtCo.Text + "%";
                }
                if (!string.IsNullOrEmpty(this.txtSo.Text.Trim()))
                {
                    info.SONo = "%" + this.txtSo.Text + "%";
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
                DataTable dt = new Business.MedicalOrder().SelectMedicalOrderPaging(info).Tables[0];
                decimal SalePrice = 0;
                long lngTotalPage = 0;
                long lngTotalRecord = 0;
                if (dt.Rows.Count <= 0)
                {
                    ngbMain.CurrentPage = 0;
                    ngbMain.TotalPage = 0;
                    ngbMain.TotalRecord = 0;
                    ngbMain.Updates();
                    Utility.MouseOff(this);
                    // Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "ไม่พบข้อมูลในระบบ");
                    return;
                }
                foreach (DataRowView item in dt.DefaultView)
                {
                    SalePrice = item["SalePrice"] + "" == "" ? 0 : Convert.ToDecimal(item["SalePrice"] + "");
                    var myItems = new[]
                                      {
                                          item["MedStatus_Code"] + "",
                                          item["MedStatus_Name"] + "",
                                           item["UpdateDate"]+""!=""?String.Format("{0:dd/MM/yyyy}",DateTime.Parse( item["UpdateDate"]+"")):"",
                                          item["VN"] + "",
                                          item["SONo"] + "",
                                          item["CN"]+"",
                                          item["FullNameThai"] + ""!=""?item["FullNameThai"] + "":item["FullNameEng"] + "",
                                          //item["FullNameEng"] + "",
                                          //item["gender"] + "" ,
                                          item["Mobile"] + "",
                                          SalePrice.ToString("###,###,###.##"),
                                         item["MedStatus_NameUse"]+"",
                                         
                                      };
                    dgvData.Rows.Add(myItems);
                    if (lngTotalPage != 0) continue;
                    Utility.FindTotalPage(Convert.ToInt32(item["rowTotal"].ToString()), ref lngTotalPage);
                    lngTotalRecord = Convert.ToInt32(item["rowTotal"].ToString());
                }
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
                dgvData.ClearSelection();
                ngbMain.CurrentPage = pIntseq;
                ngbMain.TotalPage = lngTotalPage;
                ngbMain.TotalRecord = lngTotalRecord;
                ngbMain.Updates();
                Utility.MouseOff(this);
            }
            catch (Exception ex)
            {
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeError, ex.Message);
                Utility.MouseOff(this);
                return;
            }
        }

        private void CallForm(CallMode cMode)
        {
            Statics.frmMedicalOrderSetting = new FrmMedicalOrderSetting();
            if (cMode == CallMode.Preview)
            {
                Statics.frmMedicalOrderSetting.FormType = Utility.AccessType.DisplayOnly;
                Statics.frmMedicalOrderSetting.Text = Text + Statics.StrPreview;
            }
            else if (cMode == CallMode.Update)
            {
                Statics.frmMedicalOrderSetting.FormType = Utility.AccessType.Update;
                Statics.frmMedicalOrderSetting.Text = Text + Statics.StrEdit;
            }

            Statics.frmMedicalOrderSetting.VN = dgvData.Rows[rowIndex].Cells["VN"].Value + "";
            //if(dgvData.Rows[rowIndex].Cells["VN"].Value + ""=="")
                Statics.frmMedicalOrderSetting.SO = dgvData.Rows[rowIndex].Cells["SONo"].Value + "";
                Statics.frmMedicalOrderSetting.MedStatus_Code = dgvData.Rows[rowIndex].Cells["MedStatus_Code"].Value + "";

            Statics.frmMedicalOrderSetting.BackColor = Color.FromArgb(170, 232, 229);
            Statics.frmMedicalOrderSetting.Show(Statics.frmMain.dockPanel1);
        }

        private void DeleteData()
        {
            if (dgvData.CurrentRow.Index == -1) return;
            //if (dgvData.CurrentRow.Cells["MedStatus_Code"].Value + "" != "0")
            //{
            //    Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "ไม่สามารถลบรายการนี้ได้เนื่องจาก มีการใช้หรือชำระเงินไปแล้ว");
            //    return;
            //}
            if (
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeConfirmYesNo,
                               Statics.StrConfirmDelete + dgvData.CurrentRow.Cells["VN"].Value + "") ==
                DialogResult.Yes)
            {
                try
                {
                    if (
                        new Business.MedicalOrder().DeleteMedicalOrderById(dgvData.CurrentRow.Cells["VN"].Value + ""    ,dgvData.CurrentRow.Cells["SoNo"].Value + "") ==
                        1)
                    {
                        Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, Statics.StrMsgDeleteComplete);
                        BindDataMedicalOrder(1);
                    }
                }
                catch (Exception ex)
                {
                    Utility.PopMsg(Utility.EnuMsgType.MsgTypeError, Statics.StrMsgDeleteError + ex);
                }
            }
        }

        private void FrmMedicalOrderList_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics.frmMedicalOrderList = null;
        }

        private void FrmMedicalOrderList_Activated(object sender, EventArgs e)
        {
            Statics.SetToolbar(true, true, true, true, true);
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
            CallForm(CallMode.Update);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BindDataMedicalOrder(1);
        }

        private void menuUse_Click(object sender, EventArgs e)
        {
            FrmMedicalUseList obj = new FrmMedicalUseList();
            obj.VN = dgvData.Rows[rowIndex].Cells["VN"].Value + "";
            obj.SONo = dgvData.Rows[rowIndex].Cells["SONo"].Value + "";
            obj.BackColor = Color.FromArgb(170, 232, 229);
            obj.Show(Statics.frmMain.dockPanel1);
            //obj.ShowDialog();
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

        private void ToolStripMenuItemChangCouse_Click(object sender, EventArgs e)
        {
             new FrmMedicalUseChangCouse { VN = this.dgvData.Rows[this.rowIndex].Cells["VN"].Value+"", BackColor = Color.FromArgb(170, 0xe8, 0xe5) }.Show(Statics.frmMain.dockPanel1);
        }

        bool bind = true;

        private void FrmMedicalOrderList_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

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

    
