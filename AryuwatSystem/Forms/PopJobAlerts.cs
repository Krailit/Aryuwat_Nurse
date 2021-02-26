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
    public partial class PopJobAlerts : Form
    {
        public PopJobAlerts()
        {
            InitializeComponent();
        }

        private void InitialControls()
        {
            //SetColumns();
            AddEvent();
            dgvData.ScrollBars = ScrollBars.Both;
        }

        public string CustomerName { get; set; }
        public string CN { get; set; }
        public string Mobile { get; set; }
        public string CustomerType { get; set; }

        private void PopJobAlerts_Load(object sender, EventArgs e)
        {
            InitialControls();
            BindDataCustomer(1);
        }

        private void AddEvent()
        {
            ngbMain.MoveFirst += ngbMain_MoveFirst;
            ngbMain.MoveNext += ngbMain_MoveNext;
            ngbMain.MoveLast += ngbMain_MoveLast;
            ngbMain.MovePrevious += ngbMain_MovePrevious;

            dgvData.RowPostPaint += dgvData_RowPostPaint;
            buttonFind.BtnClick += buttonFind_BtnClick;
            btnRefresh.BtnClick += btnRefresh_BtnClick;
            this.KeyPreview = true;
            this.KeyPress += PopJobAlerts_KeyPress;
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
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        private void buttonFind_BtnClick()
        {
            BindDataCustomer(1);
        }

        private void btnRefresh_BtnClick()
        {
            txtCN.Text = "";
            txtName.Text = "";
        }

        private void PopJobAlerts_KeyPress(object sender, KeyPressEventArgs e)
        {
            DerUtility.SendKey(e.KeyChar);
        }
 
        #endregion

        private void SetColumns()
        {

            DerUtility.SetPropertyDgv(dgvData);
            dgvData.Columns.Add("CN", "CN");
            dgvData.Columns.Add("CN", "CN");
            dgvData.Columns.Add("FullNameThai", "ชื่อ-นามสกุล");
            dgvData.Columns.Add("FullNameEng", "Name-Surname");
            dgvData.Columns.Add("Gender", "Gender (เพศ)");
            dgvData.Columns.Add("Mobile", "Mobile (มือถือ)");
            //dgvData.Columns.Add("Telephone", "Telephone (เบอร์บ้าน)/เบอร์ต่างประเทศ");
            //dgvData.Columns.Add("Address", "Address (ที่อยู่)");
            dgvData.Columns.Add("Branch", "สาขา");
            dgvData.Columns.Add("CustomerType", "CustomerType");
            
            dgvData.Columns["CN"].Visible = false;
            dgvData.Columns["CustomerType"].Visible = false;

            dgvData.Columns["CN"].Width = 100;
            dgvData.Columns["FullNameThai"].Width = 150;
            dgvData.Columns["FullNameEng"].Width = 150;
            dgvData.Columns["Gender"].Width = 80;
            dgvData.Columns["Mobile"].Width = 200;
            //dgvData.Columns["Telephone"].Width = 200;
            //dgvData.Columns["Address"].Width = 300;
        }

        public void BindDataCustomer(int pIntseq)
        {
            try
            {

           
                DerUtility.MouseOn(this);
                dgvData.Columns.Clear();
                dgvData.DataSource = null;
                //dgvData.Rows.Clear();
                var info = new Entity.Customer {PageNumber = pIntseq};
                if (!string.IsNullOrEmpty(txtCN.Text.Trim()))
                {
                    info.CN = "%" + txtCN.Text + "%";
                }
                if (!string.IsNullOrEmpty(txtName.Text))
                {
                    info.TName = "%" + txtName.Text + "%";}
                
                DataTable dt = new Business.Customer().SelectCustomerPOP(info).Tables[0];

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
                //foreach (DataRowView item in dt.DefaultView)
                //{
                //    object[] myItems = {
                //                          item["CN"] + "",
                //                          item["CN"] + "",
                //                          item["FullNameThai"] + "",
                //                          item["FullNameEng"] + "",
                //                          item["gender"] + "",
                //                          item["Mobile"] + "",
                //                          item["BranchName"] + "",
                //                          //item["Tel"] + "",
                //                          //item["Address"] + "",
                //                          item["CustomerType"]+""
                //                      };
                //    dgvData.Rows.Add(myItems);
             
                    //if (lngTotalPage != 0) continue;
                    //DerUtility.FindTotalPage(Convert.ToInt32(item["rowTotal"].ToString()), ref lngTotalPage);
                    //lngTotalRecord = Convert.ToInt32(item["rowTotal"].ToString());
                //}
                dgvData.DataSource = dt;
                dgvData.RowsDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
                for (int i = 0; i < dgvData.Columns.Count - 1; i++)
                {
                    dgvData.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }
                //dataGridView1.Columns[dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                for (int i = 0; i < dgvData.Columns.Count; i++)
                {
                    int colw = dgvData.Columns[i].Width;
                    dgvData.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvData.Columns[i].Width = colw;
                }
                //dgvData.Columns["Branch"].Width = 300;

                ngbMain.CurrentPage = pIntseq;
                ngbMain.TotalPage = lngTotalPage;
                ngbMain.TotalRecord = lngTotalRecord;
                ngbMain.Updates();
                DerUtility.MouseOff(this);
            }
            catch (Exception ex)
            {
                
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CN = dgvData.Rows[e.RowIndex].Cells["CN"].Value+"";
            CustomerName = dgvData.Rows[e.RowIndex].Cells["ชื่อ"].Value + "";
            CustomerType = dgvData.Rows[e.RowIndex].Cells["CustomerType"].Value + "";
            Mobile = dgvData.Rows[e.RowIndex].Cells["Mobile"].Value + "";
            this.Close();
        }

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    CN = dgvData.Rows[rowindex].Cells["CN"].Value + "";
        //    CustomerName = dgvData.Rows[rowindex].Cells["FullNameThai"].Value + "" == "" ? dgvData.Rows[rowindex].Cells["FullNameEng"].Value + "" : dgvData.Rows[rowindex].Cells["FullNameThai"].Value + "";
        //    CustomerType = dgvData.Rows[rowindex].Cells["CustomerType"].Value + "";
        //    this.Close();
        //}

        private int rowindex = -1;

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowindex = e.RowIndex;
        }

        private void txtCN_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void txtName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void txtCN_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BindDataCustomer(1);
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BindDataCustomer(1);
            }
        }

        private void txtCN_MouseClick(object sender, MouseEventArgs e)
        {
            DerUtility.GetSetInputKeyBorad("english");
        }

        private void txtName_MouseClick(object sender, MouseEventArgs e)
        {
            DerUtility.GetSetInputKeyBorad("thai");
        }
        //private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    rowindex = e.RowIndex;
        //}
      
    
    }
}
