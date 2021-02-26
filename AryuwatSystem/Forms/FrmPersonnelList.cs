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

namespace AryuwatSystem.Forms
{
    public partial class FrmPersonnelList : DockContent, IForm
    {
        public FrmPersonnelList()
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
        private int pIntseq = 1;
        private int rowIndex = 0;

        #endregion

        private void NewCustomer()
        {
            Statics.frmPersonnelSetting = new FrmPersonnelSetting();
            Statics.frmPersonnelSetting.BackColor = Color.FromArgb(255, 230, 217);
            Statics.frmPersonnelSetting.Text = Text + Statics.StrAdd;
            Statics.frmPersonnelSetting.Show(Statics.frmMain.dockPanel1);
        }

        private void FrmPersonnelList_Load(object sender, EventArgs e)
        {
            InitialControls();
            BindDataPersonel(1);
            menuDel.Enabled = dgvData.RowCount != 1;
        }

        private void InitialControls()
        {
            SetColumns();
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
            btnRefresh.BtnClick += btnRefresh_BtnClick;
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(FrmPersonnelList_KeyPress);
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
            txtCN.Text = "";
            txtName.Text = "";
            txtSurname.Text = "";
            txtMobile.Text = "";
        }

        private void FrmPersonnelList_KeyPress(object sender, KeyPressEventArgs e)
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

        public void BindDataPersonel(int _pIntseq)
        {
            try
            {
                DerUtility.MouseOn(this);
                dgvData.Rows.Clear();
                pIntseq = _pIntseq;
                var info = new Entity.Personnel() {PageNumber = _pIntseq};
                if (!string.IsNullOrEmpty(txtCN.Text.Trim()))
                {
                    info.EN = "%" + txtCN.Text + "%";
                }
                if (!string.IsNullOrEmpty(txtName.Text))
                {
                    info.TName = "%" + txtName.Text + "%";
                }
                if (!string.IsNullOrEmpty(txtSurname.Text.Trim()))
                {
                    info.TSurname = "%" + txtSurname.Text + "%";
                }
                //if (!string.IsNullOrEmpty(txtEFirstname.Text.Trim()))
                //{
                //    info.EFirstname = "%" + txtEFirstname.Text + "%";
                //}
                //if (!string.IsNullOrEmpty(txtELastname.Text.Trim()))
                //{
                //    info.ELastname = "%" + txtELastname.Text + "%";
                //}

                if (!string.IsNullOrEmpty(txtMobile.Text.Trim()))
                {
                    info.Mobile1 = "%" + txtMobile.Text + "%";
                }
                info.BranchID = uBranch1.BranchId;
                info.QueryType = "SEARCH";
                DataTable dt = new Business.Personnel().SelectCustomerPaging(info).Tables[0];

                long lngTotalPage = 0;
                long lngTotalRecord = 0;
                if (dt.Rows.Count <= 0)
                {
                    ngbMain.CurrentPage = 0;
                    ngbMain.TotalPage = 0;
                    ngbMain.TotalRecord = 0;
                    ngbMain.Updates();
                    DerUtility.MouseOff(this);
                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "ไม่พบข้อมูลในระบบ");
                    return;
                }
                foreach (DataRowView item in dt.DefaultView)
                {
                    var myItems = new[]
                                      {
                                          item["username"] + "",
                                          item["ID"] + "",
                                          item["EN"] + "",
                                          item["FullNameThai"] + "",
                                          item["FullNameEng"] + "",
                                          item["Nickname"] + "",
                                          item["PersonnelType_name"] + "",
                                          item["gender"] + "",
                                          item["Mobile"] + "",
                                          //item["Tel"] + "",
                                          //item["Address"] + "",
                                          item["Active"] + ""

                                      };
                    dgvData.Rows.Add(myItems);
                    if (lngTotalPage != 0) continue;
                    DerUtility.FindTotalPage(Convert.ToInt32(item["rowTotal"].ToString()), ref lngTotalPage);
                    lngTotalRecord = Convert.ToInt32(item["rowTotal"].ToString());
                }
                dgvData.Columns[0].Visible = false;
                ngbMain.CurrentPage = _pIntseq;
                ngbMain.TotalPage = lngTotalPage;
                ngbMain.TotalRecord = lngTotalRecord;
                ngbMain.Updates();
                DerUtility.MouseOff(this);
                menuDel.Enabled = dgvData.RowCount != 1;
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
            //finally
            //{
            //    SetNumberAllRows();
            //}
        }

        private void CallForm(CallMode cMode)
        {
            try
            {
                //if (Statics.frmPersonnelSetting == null)
                //{
                //    Statics.frmPersonnelSetting = new FrmPersonnelSetting();
                //    {
                //        Statics.frmPersonnelSetting.BackColor = Color.FromArgb(255, 230, 217);
                //    };
                //    Statics.frmPersonnelSetting.Show(Statics.frmMain.dockPanel1);
                //}
                //else
                //{
                //    Statics.frmPersonnelSetting.BringToFront();
                //}
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
            //if (Utility.PopMsg(Utility.EnuMsgType.MsgTypeConfirmYesNo, "ยืนยันการลบข้อมูล", "ลบข้อมูล") == DialogResult.Yes)
            //{
            if (dgvData.CurrentRow.Index == -1) return;
            if (DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirmYesNo,
                               Statics.StrConfirmDelete + dgvData.CurrentRow.Cells["EN"].Value + "") != DialogResult.Yes)
                return;
            try
            {
                if (new Business.Personnel().DeletePersonnelById(dgvData.CurrentRow.Cells["EN"].Value + "") ==1)
                {
                    
                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, Statics.StrMsgDeleteComplete);
                    BrowseFile.Deletefile("personnels", dgvData.CurrentRow.Cells["EN"].Value.ToString());
                    BindDataPersonel(1);
                }
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, Statics.StrMsgDeleteError + ex);
            }
            //}
        }

        private void FrmPersonnelList_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics.frmPersonnelList = null;
        }

        private void FrmPersonnelList_Activated(object sender, EventArgs e)
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


        private void SetNumberAllRows()
        {
            long rowStart = (DerUtility.ROW_PER_PAGE * (pIntseq - 1));
            for (int i = 0; i < dgvData.Rows.Count; i++)
            {
                rowStart += 1;
                dgvData.Rows[i].HeaderCell.Value = rowStart.ToString();
            }
        }

        private void txtCN_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                BindDataPersonel(1);
        }

        private void txtName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                BindDataPersonel(1);
        }

        private void txtEFirstname_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                BindDataPersonel(1);
        }

        private void txtMobile_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                BindDataPersonel(1);
        }

        private void txtSurname_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                BindDataPersonel(1);
        }

        private void txtELastname_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                BindDataPersonel(1);
        }

        private void dgvData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
            if (dgvData.Rows[e.RowIndex].Cells["Active"].Value + ""!="Y")
            {
                dgvData.Rows[e.RowIndex].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
            }
        }

    }
}
