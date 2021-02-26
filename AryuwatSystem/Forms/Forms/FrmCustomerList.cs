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
using WeifenLuo.WinFormsUI.Docking;

namespace DermasterSystem.Forms
{
    public partial class FrmCustomerList : DockContent, IForm
    {
        public FrmCustomerList()
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
            BindDataCustomer(1);
        }

        void IForm.IsEdit()
        {
            CallForm(CallMode.Update);
        }

        void IForm.IsPrint()
        {

            PrintReport();
          
        }

        void IForm.IsNew()
        {
            NewCustomer();
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
        private int pIntseq = 1;
        //private string customerID;
        #endregion
        #region Propertie
        //public string CustomerID
        //{
        //    get { return customerID(); }
        //    set { customerID = value; }

        //}
        #endregion

        private void NewCustomer()
        {
            //Statics.frmCustormerSetting = new FrmCustomerSetting();
            //Statics.frmCustormerSetting.BackColor = Color.FromArgb(170, 232, 229);
            //Statics.frmCustormerSetting.Text = Text + Statics.StrAdd;
            //Statics.frmCustormerSetting.Show(Statics.frmMain.dockPanel1);
            PopTypeCustomer obj = new PopTypeCustomer();
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.BackColor = Color.FromArgb(170, 232, 229);
            obj.ShowDialog();
        }

        private void FrmCustomerList_Load(object sender, EventArgs e)
        {
            InitialControls();
            BindDataCustomer(1);
        }

        private void InitialControls()
        {
            SetColumns();
            AddEvent();
        }


        private void PrintReport()
        {
            var info = new Entity.Customer();
            if (!string.IsNullOrEmpty(txtCN.Text.Trim()))
            {
                info.CN = "%" + txtCN.Text + "%";
            }
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                info.TName = "%" + txtName.Text + "%";
            }
            if (!string.IsNullOrEmpty(txtSurname.Text.Trim()))
            {
                info.TSurname = "%" + txtSurname.Text + "%";
            }
            if (!string.IsNullOrEmpty(txtMobile.Text.Trim()))
            {
                info.Mobile1 = "%" + txtMobile.Text + "%";
            }
            DataSet ds = new Business.Customer().SelectCustomerWhereCause(info);

            FrmPreviewRpt obj = new FrmPreviewRpt();
            obj.FormName = "RptCustomerList";
            obj.DataSetReport = ds;
            obj.MaximizeBox = true;
            obj.ShowDialog();
        }

        private void SetColumns()
        {
            Utility.SetPropertyDgv(dgvData);
            //dgvData.Columns.Add("CN", "CN");
            dgvData.Columns.Add("CN", "CN");
            dgvData.Columns.Add("FullNameThai", "ชื่อ-นามสกุล");
            dgvData.Columns.Add("FullNameEng", "Name-Surname");
            dgvData.Columns.Add("Gender", "Gender (เพศ)");
            dgvData.Columns.Add("Mobile", "Mobile (มือถือ)");
            dgvData.Columns.Add("Telephone", "Telephone (เบอร์บ้าน)/เบอร์ต่างประเทศ");
            dgvData.Columns.Add("Address", "Address (ที่อยู่)");

            //dgvData.Columns["CN"].Visible = false;

            dgvData.Columns["CN"].Width = 100;
            dgvData.Columns["FullNameThai"].Width = 150;
            dgvData.Columns["FullNameEng"].Width = 150;
            dgvData.Columns["Gender"].Width = 80;
            dgvData.Columns["Mobile"].Width = 200;
            dgvData.Columns["Telephone"].Width = 200;
            dgvData.Columns["Address"].Width = 300;

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
            this.KeyPress += new KeyPressEventHandler(FrmCustomerList_KeyPress);
            menuEdit.Click += new EventHandler(menuEdit_Click);
            menuPreview.Click += new EventHandler(menuPreview_Click);
            menuDel.Click += new EventHandler(menuDel_Click);
        }


        #region Event
        private void ngbMain_MoveFirst()
        {
            BindDataCustomer(1);
        }

        private void ngbMain_MoveLast()
        {
            BindDataCustomer(Convert.ToInt32(ngbMain.TotalPage));
        }

        private void ngbMain_MoveNext()
        {
            BindDataCustomer(Convert.ToInt32(Convert.ToInt32(ngbMain.CurrentPage) + 1));
        }

        private void ngbMain_MovePrevious()
        {
            BindDataCustomer(Convert.ToInt32(Convert.ToInt32(ngbMain.CurrentPage) - 1));
        }

        private void dgvData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            //e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
            //                      e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        private void SetNumberAllRows()
        {
            long rowStart = (Utility.ROW_PER_PAGE * (pIntseq - 1));
            for (int i = 0; i < dgvData.Rows.Count; i++)
            {
                rowStart += 1;
                dgvData.Rows[i].HeaderCell.Value = rowStart.ToString();
            }
        }

        private void buttonFind_BtnClick()
        {
            BindDataCustomer(1);
        }

        void btnRefresh_BtnClick()
        {
            txtCN.Text = "";
            txtName.Text = "";
            txtSurname.Text = "";
            txtMobile.Text = "";
        }

        void FrmCustomerList_KeyPress(object sender, KeyPressEventArgs e)
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
                    dgvData.Rows[rowIndex].Selected = false;
                    dgvData.Rows[e.RowIndex].Selected = true;
                    rowIndex = e.RowIndex;
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

        public void BindDataCustomer(int _pIntseq)
        {
            try
            {
                Utility.MouseOn(this);
                dgvData.Rows.Clear();
                pIntseq = _pIntseq;
                var info = new Entity.Customer { PageNumber = _pIntseq };
                if (!string.IsNullOrEmpty(txtCN.Text.Trim()))
                {
                    info.CN = "%" + txtCN.Text + "%";
                }
                if (!string.IsNullOrEmpty(txtName.Text))
                {
                    info.TName = "%" + txtName.Text + "%";
                }
                if (!string.IsNullOrEmpty(txtSurname.Text.Trim()))
                {
                    info.TSurname = "%" + txtSurname.Text + "%";
                }
                if (!string.IsNullOrEmpty(txtMobile.Text.Trim()))
                {
                    info.Mobile1 = "%" + txtMobile.Text + "%";
                }
                DataTable dt = new Business.Customer().SelectCustomerPaging(info).Tables[0];

                long lngTotalPage = 0;
                long lngTotalRecord = 0;
                if (dt.Rows.Count <= 0)
                {
                    ngbMain.CurrentPage = 0;
                    ngbMain.TotalPage = 0;
                    ngbMain.TotalRecord = 0;
                    ngbMain.Updates();
                    Utility.MouseOff(this);
                    Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "ไม่พบข้อมูลในระบบ");
                    return;
                }
                foreach (DataRowView item in dt.DefaultView)
                {
                    var myItems = new[]
                                      {
                                          //item["CN"] + "",
                                          item["CN"]+"",
                                          item["FullNameThai"] + "",
                                          item["FullNameEng"] + "",
                                          item["gender"] + "" ,
                                          item["Mobile"] + "",
                                          item["Tel"] + "",
                                          item["Address"] + ""
                                      };
                    dgvData.Rows.Add(myItems);
                    if (lngTotalPage != 0) continue;
                    Utility.FindTotalPage(Convert.ToInt32(item["rowTotal"].ToString()), ref lngTotalPage);
                    lngTotalRecord = Convert.ToInt32(item["rowTotal"].ToString());
                }

                ngbMain.CurrentPage = _pIntseq;
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
            finally
            {
                SetNumberAllRows();
            }
        }

        private void CallForm(CallMode cMode)
        {
            Statics.frmCustormerSetting = new FrmCustomerSetting();
            //Statics.frmCustormerSetting.StartPosition = FormStartPosition.CenterScreen;
            //Statics.frmCustormerSetting.WindowState = FormWindowState.Maximized;
            //Statics.frmCustormerSetting.MdiParent = ActiveForm;
            if (cMode == CallMode.Preview)
            {
                Statics.frmCustormerSetting.FormType = Utility.AccessType.DisplayOnly;
                Statics.frmCustormerSetting.Text = Text+ Statics.StrPreview ;
            }
            else if (cMode == CallMode.Update)
            {
                Statics.frmCustormerSetting.FormType = Utility.AccessType.Update;
                Statics.frmCustormerSetting.Text = Text + Statics.StrEdit;
            }

            Statics.frmCustormerSetting.CN = dgvData.Rows[rowIndex].Cells["CN"].Value + "";
           
            Statics.frmCustormerSetting.BackColor = Color.FromArgb(170, 232, 229);
            Statics.frmCustormerSetting.Show(Statics.frmMain.dockPanel1);
        }

        private void DeleteData()
        {
            //if (Utility.PopMsg(Utility.EnuMsgType.MsgTypeConfirmYesNo, "ยืนยันการลบข้อมูล", "ลบข้อมูล") == DialogResult.Yes)
            //{
            if (dgvData.CurrentRow.Index == -1) return;
            if (
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeConfirmYesNo,
                               Statics.StrConfirmDelete +  dgvData.CurrentRow.Cells["CN"].Value + "") ==
                DialogResult.Yes)
            {
                try
                {
                    if (new Business.Customer().DeleteCustomerById(dgvData.CurrentRow.Cells["CN"].Value + "") == 1)
                    {
                        Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, Statics.StrMsgDeleteComplete);
                        BindDataCustomer(1);
                    }
                }
                catch (Exception ex)
                {
                    Utility.PopMsg(Utility.EnuMsgType.MsgTypeError, Statics.StrMsgDeleteError + ex);
                }
            }
            //}
        }

        private void FrmCustomerList_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics.frmCustomerList = null;
        }

        private void FrmCustomerList_Activated(object sender, EventArgs e)
        {
            Statics.SetToolbar(true, true, true, true, true);
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
            CallForm(CallMode.Update);
        }

        private void dgvData_Sorted(object sender, EventArgs e)
        {
            SetNumberAllRows();
        }

    }
}
