using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AryuwatSystem.DerClass;

namespace AryuwatSystem.Forms
{
    public partial class PopEmpSearch : Form
    {
        public PopEmpSearch()
        {
            InitializeComponent();
        }

        private void InitialControls()
        {
            SetColumns();
            AddEvent();
            dgvData.ScrollBars = ScrollBars.Both;
        }

        public string EmployeeId { get; set; }
        public string StaffsName { get; set; }
        public string _queryType = "";
        public bool multiSelect = true;
        public bool FrmLoad = false;
        public bool ForSale = false;
        public string EmployeeTypeId { get; set; }
        private int pIntseq = 1;
        private void PopEmpSearch_Load(object sender, EventArgs e)
        {
            InitialControls();
            BindCboPersonnelType();
            BindDataCustomer(1);
            FrmLoad = true;
        }

        private void BindCboPersonnelType()
        {
            try
            {
                DataSet dsPersonnelType =new DataSet();
                DataTable dt = new DataTable();
                if (ForSale)
                {
                    dsPersonnelType = new Business.Personnel().SelectPersonnelTypeWhereCause("SELECTPERSONNELTYPE_Sale_CS");
                    dt = dsPersonnelType.Tables[0];
                }
                else
                {
                    dsPersonnelType = new Business.Personnel().SelectPersonnelTypeWhereCause("SELECTPERSONNELTYPE");
                    dt = dsPersonnelType.Tables[0];
                    DataRow drPersonnelType = dt.NewRow();
                    drPersonnelType["PersonnelType_code"] = "99";
                    drPersonnelType["PersonnelType_name"] = Statics.StrNewRow;
                    dt.Rows.InsertAt(drPersonnelType, 0);
                }
                cboPersonnelType.DataSource = null;
                cboPersonnelType.BeginUpdate();
                cboPersonnelType.DataSource = dt;
                cboPersonnelType.ValueMember = "PersonnelType_code";
                cboPersonnelType.DisplayMember = "PersonnelType_name";

                cboPersonnelType.EndUpdate();

            }
            catch (Exception ex)
            {
               // Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }
        }

        private void AddEvent()
        {
            ngbMain.MoveFirst += ngbMain_MoveFirst;
            ngbMain.MoveNext += ngbMain_MoveNext;
            ngbMain.MoveLast += ngbMain_MoveLast;
            ngbMain.MovePrevious += ngbMain_MovePrevious;

            //dgvData.RowPostPaint += dgvData_RowPostPaint;
            buttonFind.BtnClick += buttonFind_BtnClick;
            btnRefresh.BtnClick += btnRefresh_BtnClick;
            this.KeyPreview = true;
            this.KeyPress += PopEmpSearch_KeyPress;
           
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

        //private void dgvData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        //{
        //    var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
        //    e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
        //                          e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        //}

        private void buttonFind_BtnClick()
        {
            BindDataCustomer(1);
        }

        private void btnRefresh_BtnClick()
        {
            txtName.Text = "";
            txtSurName.Text = "";
        }

        private void PopEmpSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            DerUtility.SendKey(e.KeyChar);
        }
 
        #endregion

        private void SetColumns()
        {
            DerUtility.SetPropertyDgv(dgvData);
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            {
                //column.HeaderText = "Selected";
                //column.Name = "Selected";
                column.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                column.FlatStyle = FlatStyle.Standard;
                column.ThreeState = false;
                column.CellTemplate = new DataGridViewCheckBoxCell();
                column.CellTemplate.Style.BackColor = Color.Beige;
            }
            dgvData.Columns.Add(column);
            dgvData.Columns.Add("ID", "ID");
            dgvData.Columns.Add("EN", "EN");
            dgvData.Columns.Add("FullNameThai", "ชื่อ-นามสกุล");
            dgvData.Columns.Add("FullNameEng", "Name-Surname");
            dgvData.Columns.Add("PersonnelType", "Codeตำแหน่ง");
            dgvData.Columns.Add("Gender", "Gender (เพศ)");
            dgvData.Columns.Add("Mobile", "Mobile (มือถือ)");
            dgvData.Columns.Add("Telephone", "Telephone (เบอร์บ้าน)/เบอร์ต่างประเทศ");
            dgvData.Columns.Add("Address", "Address (ที่อยู่)");
            dgvData.Columns.Add("Active", "Active");

            dgvData.Columns["ID"].Visible = false;
            dgvData.Columns["PersonnelType"].Visible = false;

            dgvData.Columns["EN"].Width = 100;
            dgvData.Columns["FullNameThai"].Width = 150;
            dgvData.Columns["FullNameEng"].Width = 150;
            dgvData.Columns["Gender"].Width = 80;
            dgvData.Columns["Mobile"].Width = 200;
            dgvData.Columns["Telephone"].Width = 200;
            dgvData.Columns["Address"].Width = 320;

           }

        public void BindDataCustomer(int _pIntseq)
        {
            try
            {
                DerUtility.MouseOn(this);
                dgvData.Rows.Clear();
                pIntseq = _pIntseq;
                var info = new Entity.Personnel() { PageNumber = _pIntseq };
                
                if (!string.IsNullOrEmpty(txtName.Text))
                {
                    info.TName = "%" + txtName.Text + "%";
                }
                if (!string.IsNullOrEmpty(txtSurName.Text.Trim()))
                {
                    info.TSurname = "%" + txtSurName.Text + "%";
                }
                if(cboPersonnelType.SelectedIndex > 0 )
                {
                    info.PersonnelType = cboPersonnelType.SelectedValue + "";
                }
                info.QueryType = _queryType=="" ? "SEARCHEMP" : _queryType;
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
                    //Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "ไม่พบข้อมูลในระบบ");
                    return;
                }
                foreach (DataRowView item in dt.DefaultView)
                {
                    object[] myItems = { false,
                                          item["ID"] + "",
                                          item["EN"] + "",
                                          item["FullNameThai"] + "",
                                          item["FullNameEng"] + "",
                                          item["PersonnelType"] + "",
                                          item["gender"] + "",
                                          item["Mobile"] + "",
                                          item["Tel"] + "",
                                          item["Address"] + "",
                                          item["Active"] + ""
                                      };
                    dgvData.Rows.Add(myItems);
                    if (lngTotalPage != 0) continue;
                    DerUtility.FindTotalPage(Convert.ToInt32(item["rowTotal"].ToString()), ref lngTotalPage);
                    lngTotalRecord = Convert.ToInt32(item["rowTotal"].ToString());
                }

                ngbMain.CurrentPage = _pIntseq;
                ngbMain.TotalPage = lngTotalPage;
                ngbMain.TotalRecord = lngTotalRecord;
                ngbMain.Updates();
                DerUtility.MouseOff(this);
                //menuDel.Enabled = dgvData.RowCount != 1;
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

        private void SetNumberAllRows()
        {
            long rowStart = (DerUtility.ROW_PER_PAGE * (pIntseq - 1));
            for (int i = 0; i < dgvData.Rows.Count; i++)
            {
                rowStart += 1;
                dgvData.Rows[i].HeaderCell.Value = rowStart.ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();

            if (!multiSelect)
            {
                foreach (DataGridViewRow dr in dgvData.Rows)
                {
                    ch1 = (DataGridViewCheckBoxCell) dr.Cells[0];
                    ch1.Value = false;
                }
            }
            ch1 = (DataGridViewCheckBoxCell)dgvData.Rows[dgvData.CurrentRow.Index].Cells[0];
            if (ch1.Value == null)
                ch1.Value = false;
            switch (ch1.Value.ToString())
            {
                case "True":
                    ch1.Value = false;
                    break;
                case "False":
                    ch1.Value = true;
                    break;
            }
            if (dgvData.CurrentRow.Cells["Active"].Value + ""!="Y")
            { ch1.Value = false; }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            EmployeeId = "";
            StaffsName = "";
            foreach (DataGridViewRow dr in dgvData.Rows)
            {
                
                if((bool)dr.Cells[0].Value )
                {
                    if (EmployeeId != "") EmployeeId += ",";
                    EmployeeId += dr.Cells["EN"].Value + "";

                    if (StaffsName != "") StaffsName += ",";
                    StaffsName += dr.Cells["FullNameThai"].Value + "" == "" ? dr.Cells["FullNameEng"].Value + "" : dr.Cells["FullNameThai"].Value + "";
                    EmployeeTypeId = dr.Cells["PersonnelType"].Value + "";
                }
            }
            this.Hide();
        }

        private void dgvData_Sorted(object sender, EventArgs e)
        {
            SetNumberAllRows();
        }

        private void cboPersonnelType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FrmLoad)
            BindDataCustomer(1);
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BindDataCustomer(1);
            }
        }

        private void txtSurName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BindDataCustomer(1);
            }
        }

        private void dgvData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            //e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
            //                      e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
            if (dgvData.Rows[e.RowIndex].Cells["Active"].Value + "" != "Y")
            {
                dgvData.Rows[e.RowIndex].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
            }
        }

        private void txtName_MouseClick(object sender, MouseEventArgs e)
        {
            DerUtility.GetSetInputKeyBorad("thai");
        }

        private void txtSurName_MouseClick(object sender, MouseEventArgs e)
        {
            DerUtility.GetSetInputKeyBorad("thai");
        }

        private void txtName_MouseLeave(object sender, EventArgs e)
        {
            DerUtility.GetSetInputKeyBorad("english");
        }

        

       
    }
}
