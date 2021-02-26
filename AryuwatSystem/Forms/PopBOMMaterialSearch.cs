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
    public partial class PopBOMMaterialSearch : Form
    {
        public PopBOMMaterialSearch()
        {
            InitializeComponent();
            if (dgvData.Columns.Count > 0) dgvData.Columns.RemoveAt(0);

            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            {
                column.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                column.FlatStyle = FlatStyle.Standard;
                column.ThreeState = false;
                column.Name = "ChkMove";
                column.HeaderText = "";
                column.CellTemplate = new DataGridViewCheckBoxCell();
                column.CellTemplate.Style.BackColor = Color.LemonChiffon;
            }
            dgvData.Columns.Add(column); //0
            BindBOMMaterial(1);
            FrmLoad = true;
        }

        public PopBOMMaterialSearch(string _BranchID)
        {
            // TODO: Complete member initialization
            this.BranchID = _BranchID;
            InitializeComponent();
            if (dgvData.Columns.Count > 0) dgvData.Columns.RemoveAt(0);

            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            {
                column.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                column.FlatStyle = FlatStyle.Standard;
                column.ThreeState = false;
                column.Name = "ChkMove";
                column.HeaderText = "";
                column.CellTemplate = new DataGridViewCheckBoxCell();
                column.CellTemplate.Style.BackColor = Color.LemonChiffon;
            }
            dgvData.Columns.Add(column); //0
            BindBOMMaterial(1);
            FrmLoad = true;
        }

        private void InitialControls()
        {
           
            dgvData.ScrollBars = ScrollBars.Both;
        }
        DataTable dtMaterial = new DataTable();
        public string EmployeeId { get; set; }
        public string StaffsName { get; set; }
        public string _queryType = "";
        public bool multiSelect = true;
        public bool FrmLoad = false;
        public bool ForSale = false;
        public string EmployeeTypeId { get; set; }
        public string BranchID { get; set; }
        public List<DataGridViewRow> lsMaterial { get; set; }
        private int pIntseq = 1;
        private string p;

        private void PopBOMMaterialSearch_Load(object sender, EventArgs e)
        {
            InitialControls();
            //BindCboPersonnelType();
           
        }


        //private void AddEvent()
        //{
        
        //    this.KeyPreview = true;
        //    this.KeyPress += PopBOMMaterialSearch_KeyPress;
           
        //}

        #region Event



        private void PopBOMMaterialSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            DerUtility.SendKey(e.KeyChar);
        }
 
        #endregion

        public void BindBOMMaterial(int _pIntseq)
        {
            try
            {
               
                dgvData.DataSource = null;
                pIntseq = _pIntseq;
                var info = new Entity.MedicalSupplies() { PageNumber = _pIntseq };

                info.QueryType = "BOMMaterialSearch";
               info.BranchID= BranchID;
                DataSet ds = new Business.MedicalSupplies().SelectMedicalSuppliesPaging(info);

                if (ds.Tables.Count < 0) return;

                    dtMaterial = ds.Tables[0];
                    dgvData.DataSource = dtMaterial;
               
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
            try
            {
                if(e.ColumnIndex!=0 || e.RowIndex<0)return;
         
            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();

            if (!multiSelect)
            {
                foreach (DataGridViewRow dr in dgvData.Rows)
                {
                    ch1 = (DataGridViewCheckBoxCell) dr.Cells[0];
                    ch1.Value = false;
                }
            }
            ch1 = (DataGridViewCheckBoxCell)dgvData.Rows[e.RowIndex].Cells[0];
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
            //if (dgvData.CurrentRow.Cells["Active"].Value + ""!="Y")
            //{ ch1.Value = false; }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                lsMaterial = new List<DataGridViewRow>();
                foreach (DataGridViewRow dr in dgvData.Rows)
                {

                    DataGridViewCheckBoxCell chk = dr.Cells[0] as DataGridViewCheckBoxCell;
                    if (Convert.ToBoolean(chk.Value) == true)
                    {
                        lsMaterial.Add(dr);
                    }
                }

                this.Hide();
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


        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BindBOMMaterial(1);
            }
        }


        //private void dgvData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        //{
        //    //var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
        //    //e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
        //    //                      e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        //    //if (dgvData.Rows[e.RowIndex].Cells["Active"].Value + "" != "Y")
        //    //{
        //    //    dgvData.Rows[e.RowIndex].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
        //    //}
        //}

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dtMaterial.DefaultView.RowFilter = string.Format("[ชื่อ] LIKE '%{0}%'", txtName.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PopBOMMaterialSearch_Shown(object sender, EventArgs e)
        {
            lsMaterial = new List<DataGridViewRow>();
        }

        

       
    }
}
