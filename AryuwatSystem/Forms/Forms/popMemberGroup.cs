using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DermasterSystem.Class;
using Entity;

namespace DermasterSystem.Forms
{
    public partial class popMemberGroup : Form
    {
        public string CN { get; set; }
        public string VN { get; set; }
        public string MS_Code { get; set; }
        public Dictionary<string, List<MembersTrans>> dicMemberTran = new Dictionary<string, List<MembersTrans>>();
        public bool UsedForm = false;
        static popMemberGroup _objMe = null;
        public List<MembersTrans> member = new List<MembersTrans>();
        DataSet ds = null;
        public popMemberGroup()
        {
            InitializeComponent();
        }

      
        private void SetColumnDgvMembers()
        {
            dgvMember.Columns.Clear();
            dgvMember.Rows.Clear();
            Utility.SetPropertyDgv(dgvMember);
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            {
                column.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                column.FlatStyle = FlatStyle.Standard;
                column.ThreeState = false;
                column.Name = "CHKSELECT";
                column.HeaderText = "";
                column.CellTemplate = new DataGridViewCheckBoxCell();
                column.CellTemplate.Style.BackColor = Color.Beige;
            }

            dgvMember.Columns.Add(column);
            dgvMember.Columns.Add("CN", "CN");
            dgvMember.Columns.Add("CustomerName", "Customer Name");
            dgvMember.Columns.Add("CustomerType", "CustomerType");

            dgvMember.Columns["CN"].Width = 100;
            dgvMember.Columns["CustomerName"].Width = 150;
            dgvMember.Columns["CustomerType"].Width = 150;
        }
        public static popMemberGroup GetInstance()
        {
            if (_objMe == null)
            {
                _objMe = new popMemberGroup();
            }
            return _objMe;
        }
        private void popMemberGroup_Load(object sender, EventArgs e)
        {
            try
            {
                member = new List<MembersTrans>();
                SetColumnDgvMembers();
                
                if(ds==null)  ds = new Business.Customer().SelectCustomerMemberById(CN);
                if (ds.Tables.Count <= 0) return;
              
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    object[] myItems = {
                                                     false,//chk
                                                     item["CN_Sub"],
                                                     item["FullNameThai"]!=""?item["FullNameThai"]:item["FullNameEng"],
                                                    item["CustomerType"],
                                           };
                    dgvMember.Rows.Add(myItems);
                }
                setCheckMemberTrans();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        private void setCheckMemberTrans()
        {
            try 
	        {
                if (!dicMemberTran.Any()) return;
                if (dicMemberTran.ContainsKey(MS_Code))
                {
                    List<Entity.MembersTrans> ls=dicMemberTran[MS_Code];
                   
                    foreach (Entity.MembersTrans item in ls)
                    {
                        foreach (DataGridViewRow row in dgvMember.Rows)
                        {
                            string c = row.Cells["CN"].Value + "";
                            DataGridViewCheckBoxCell chk = row.Cells[0] as DataGridViewCheckBoxCell;
                            if (item.CN.ToLower() == c.ToLower())
                            {
                                chk.Value = true;
                            }
                        }
                    }
                }

	        }
	        catch (Exception ex)
	        {
		        MessageBox.Show(ex.Message);
	        }
        }
        private void dgvMember_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        private void dgvMember_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            { 
                DataGridViewCheckBoxCell chCom = new DataGridViewCheckBoxCell();
                if (UsedForm)
                {
                    foreach (DataGridViewRow row in dgvMember.Rows)
                    {
                        DataGridViewCheckBoxCell chk = row.Cells[0] as DataGridViewCheckBoxCell;
                        chk.Value = false;
                    }
                    
                }
                    chCom = (DataGridViewCheckBoxCell)dgvMember.Rows[dgvMember.CurrentRow.Index].Cells["CHKSELECT"];
                    if (e.ColumnIndex == chCom.ColumnIndex)
                    {
                        //if ((bool)chCom.Value)
                        chCom.Value = !(bool)chCom.Value;
                    }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                //  group member
                Entity.Customer info = new Customer();
                info.MembersGroupInfo = new List<MembersGroup>();
                foreach (DataGridViewRow row in dgvMember.Rows)
                {
                    MembersGroup m = new MembersGroup();
                    m.CN_MAIN = CN;
                    m.CN_SUB = row.Cells["CN"].Value + "";
                    info.MembersGroupInfo.Add(m);
                }
                var intmember =  new Business.Customer().InsertMembersGroup(info);

                member = new List<MembersTrans>();
                 foreach (DataGridViewRow row in dgvMember.Rows)
                    {
                        DataGridViewCheckBoxCell chk = row.Cells[0] as DataGridViewCheckBoxCell;
                        if (Convert.ToBoolean(chk.Value) == true)
                        {
                            MembersTrans m = new MembersTrans();
                            m.VN = VN;
                            m.CN = row.Cells["CN"].Value + "";
                            m.MS_Code = MS_Code;
                            m.CN_NAME = row.Cells["CustomerName"].Value + "";
                            member.Add(m);
                        }
                    }
                 this.DialogResult = System.Windows.Forms.DialogResult.OK;
           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void buttonAdd_BtnClick()
        {
            try
            {
                PopCustSearch obj = new PopCustSearch();
                obj.StartPosition = FormStartPosition.CenterScreen;
                obj.WindowState = FormWindowState.Normal;
                obj.BackColor = Color.FromArgb(170, 232, 229);
                obj.ShowDialog();

                if (!string.IsNullOrEmpty(obj.CN))
                {
                    object[] myItems = {
                                                     false,//chk
                                                     obj.CN,
                                                     obj.CustomerName,
                                                     obj.CustomerType,
                                           };
                    dgvMember.Rows.Add(myItems);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonDelete_BtnClick()
        {
            try
            {
                List<DataGridViewRow> rowsToDelete = new List<DataGridViewRow>();
                foreach (DataGridViewRow row in dgvMember.Rows)
                {
                    DataGridViewCheckBoxCell chk = row.Cells[0] as DataGridViewCheckBoxCell;
                    if (Convert.ToBoolean(chk.Value) == true)
                    {
                        rowsToDelete.Add(row);
                    }
                }

                foreach (DataGridViewRow row in rowsToDelete)
                    dgvMember.Rows.Remove(row);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
