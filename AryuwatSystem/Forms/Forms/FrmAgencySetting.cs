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
    public partial class FrmAgencySetting : Form
    {
        public string AgencyMemID = "";
        public string AgencyID = "";
        public string AgencyTyp = "";
        private DataSet dsagency = null;
        private DataSet dsagencyMember = null;
        public bool Next = false;
        private int membercmn = 0;
        private int memberEditcmn = 0;
        private bool savwNew = true;
        public FrmAgencySetting()
        {
            InitializeComponent();
        }

        private void FrmAgencySetting_Load(object sender, EventArgs e)
        {
            try
            {

                tabControl1.Appearance = TabAppearance.FlatButtons;
                tabControl1.ItemSize = new Size(0, 1);
                tabControl1.SizeMode = TabSizeMode.Fixed;
                BindDataAgency();
                membercmn = dataGridViewAgency.Columns.Count - 1;
                memberEditcmn = dataGridViewMember.Columns.Count - 1;
                BindDataAgencyTyp();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void BindDataAgencyTyp()
        {
            try
            {
                cboAgenType.Items.Clear();
                if (dsagency.Tables[2].Rows.Count == 0) return;
                cboAgenType.DataSource = dsagency.Tables[2];
                cboAgenType.ValueMember = "AgenTypID";
                cboAgenType.DisplayMember = "AgenTypName";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void BindDataAgency()
        {
            try
            {
                dsagency = new Business.Agency().SelectAgency();
                dataGridViewAgency.Rows.Clear();
                
                
                long lngTotalPage = 0;
                long lngTotalRecord = 0;
                if (dsagency.Tables.Count == 0) return;
                foreach (DataRowView item in dsagency.Tables[0].DefaultView)
                {
                    object[] myItems = {
                                          item["AgenID"] + "",
                                          item["AgenTypID"] + "",
                                          item["AgenName"] + "",
                                          item["AgenTypName"] + "",
                                          item["AgenTel"] + "",
                                          imageList1.Images[0]
                                        };
                    dataGridViewAgency.Rows.Add(myItems);
                    if (lngTotalPage != 0) continue;
                    
                   // lngTotalRecord = Convert.ToInt32(item["rowTotal"].ToString());
                }
                dataGridViewAgency.ClearSelection();
            }
            catch (Exception ex)
            {
            
                return;
            }
            finally
            {
              
            }
        }
        public void BindDataAgencyMember()
        {
            try
            {
                dataGridViewMember.Rows.Clear();
                dsagencyMember = new Business.Agency().SelectAgencyMember("",new Agency());
                //if (ds.Tables[1].Rows.Count == 0) return;
                string sql = string.Format("AgenID='{0}'",txtAgenID2.Text.Trim());
                foreach (DataRow item in dsagencyMember.Tables[0].Select(sql))
                {
                    object[] myItems = {  item["AgenMemID"] + "",
                                          item["AgenMemName"] + "",
                                          item["AgenMemSurName"] + "",
                                          item["AgenMemTel"] + "",
                                          item["AgenMemIDCard"] + "",
                                          imageList1.Images[1]
                                        };
                    dataGridViewMember.Rows.Add(myItems);
                }
                dataGridViewMember.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Next = true;
            Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Next = false;
            Close();
        }

        private void btnNewAgency_Click(object sender, EventArgs e)
        {
            Setnew();
        }
        private void Setnew()
        {
            savwNew = true;
            txtID.Text = "";
            txtAgenAddress.Text = "";
            txtAgenName.Text = "";
            txtAgenTel.Text = "";
            cboAgenType.SelectedIndex = 0;
            txtDetail.Text = "";
            txtSupportName.Text = "";
            txtSupportTel.Text = "";
            AgencyID = "";
            btnDel.Enabled = false;
        }
        private void btnSaveAgency_Click(object sender, EventArgs e)
        {
            try
            {
                var info = new Entity.Agency();
                info.AgenID = txtID.Text.Trim();
                info.AgenTyp = cboAgenType.SelectedValue + "";
                info.AgenName = txtAgenName.Text;
                info.AgenAddress = txtAgenAddress.Text;
                info.AgenDescript = txtDetail.Text;
                info.AgenTel = txtAgenTel.Text;
                info.ENSave = Entity.Userinfo.EN;
                info.saveNew = savwNew ;
                info.SaveTyp = "AGENCY";
                info.SupportName = txtSupportName.Text;
                info.SupportTel = txtSupportTel.Text;
                
                int? intStatus = new Business.Agency().SaveAgency(info);
                if (intStatus > 0)
                {
                    BindDataAgency();
                    Setnew();
                    Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, Statics.SaveComplete);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewAgency_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
               
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNewMem_Click(object sender, EventArgs e)
        {
            setNewMember();
        }
        private void setNewMember()
        {
            txtMemName.Text = "";
            txtMemPrefix.Text = "";
            txtMemSurname.Text = "";
            txtMemTel.Text = "";
            txtMemIDCard.Text = "";
            AgencyMemID = "";
            savwNew = true;
            btnDelMem.Enabled = false;
        }
        private void btnSaveMem_Click(object sender, EventArgs e)
        {
            try
            {
                var info = new Entity.Agency();

                info.AgenID = txtAgenID2.Text.Trim();
                info.AgenTyp = AgencyTyp;
                info.AgenMemPrefix = txtMemPrefix.Text;
                info.AgenMemName = txtMemName.Text;
                info.AgenMemSurName = txtMemSurname.Text;
                info.AgenMemAddress = ""; //txtMemAddress.Text;
                info.AgenMemIDCard = txtMemIDCard.Text;
                info.AgenMemRate = 100;
                info.AgenMemTel = txtMemTel.Text.Trim();
                info.ENSave = Entity.Userinfo.EN;
                info.SaveTyp = "MEMBER";
                info.saveNew = savwNew;
                info.AgenMemID = AgencyMemID;
                int? intStatus = new Business.Agency().SaveAgency(info);
                if (intStatus > 0)
                {
                    savwNew = false;
                    BindDataAgencyMember();
                    setNewMember();
                    MessageBox.Show("Save");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmAgencySetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics.frmAgencySetting = null;
        }

        private void dataGridViewAgency_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Cursor = e.ColumnIndex == membercmn ? Cursors.Hand : Cursors.Arrow;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewAgency_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                savwNew = false;

                AgencyID = dataGridViewAgency.Rows[e.RowIndex].Cells["AgenID"].Value + "";
                AgencyTyp = dataGridViewAgency.Rows[e.RowIndex].Cells["AgenTypID"].Value + "";
                string sql = string.Format("AgenID='{0}'", AgencyID);

                if (e.ColumnIndex == membercmn)//คลิกดูสมาชิก
                {
                    //MessageBox.Show("Add Member");
                    tabControl1.SelectTab("tabPage2");
                    foreach (DataRow item in dsagency.Tables[0].Select(sql))
                    {
                        txtAgenID2.Text = item["AgenID"] + "";
                        txtAgenName2.Text = item["AgenName"] + "";
                        txtAgenTypeOf2.Text = item["AgenTypName"] + "";
                        savwNew = true;
                    }
                    BindDataAgencyMember();
                    return;
                }


                foreach (DataRow item in dsagency.Tables[0].Select(sql))//แก้ไข agency
                {
                    txtID.Text = item["AgenID"] + "";
                    txtAgenName.Text = item["AgenName"] + "";
                    txtAgenTel.Text = item["AgenTel"] + "";
                    cboAgenType.SelectedValue = item["AgenTypID"] + "";
                    txtDetail.Text = item["AgenDescript"] + "";
                    txtAgenAddress.Text = item["AgenAddress"] + "";
                    txtSupportName.Text = item["SupportName"] + "";
                    txtSupportTel.Text = item["SupportTel"] + "";
                    btnDel.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Will you really remove the item?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int? intStatus = new Business.Agency().DeleteAgencyById(txtID.Text.Trim());
                    if (intStatus > 0)
                    {
                        BindDataAgency();
                        Setnew();
                    }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   
        }

        private void dataGridViewMember_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                savwNew = false;

                AgencyMemID = dataGridViewMember.Rows[e.RowIndex].Cells["AgenMemID"].Value + "";
                //AgencyTyp = dataGridViewAgency.Rows[e.RowIndex].Cells["AgenTypID"].Value + "";
                string sql = string.Format("AgenMemID='{0}'", AgencyMemID);

                if (e.ColumnIndex == memberEditcmn)
                {
                    foreach (DataRow item in dsagencyMember.Tables[0].Select(sql))
                    {
                        txtMemPrefix.Text = item["AgenMemPrefix"] + "";
                        txtMemName.Text = item["AgenMemName"] + "";
                        txtMemSurname.Text = item["AgenMemSurName"] + "";
                        txtMemTel.Text = item["AgenMemTel"] + "";
                        txtMemIDCard.Text = item["AgenMemIDCard"] + "";
                        AgencyMemID = item["AgenMemID"] + "";
                        savwNew = false;
                        btnDelMem.Enabled = true;
                    }
               }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewMember_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Cursor = e.ColumnIndex == memberEditcmn ? Cursors.Hand : Cursors.Arrow;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewMember_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void dataGridViewAgency_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void btnDelMem_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Will you really remove the item?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int? intStatus = new Business.Agency().DeleteAgencyMemById(AgencyMemID);
                    if (intStatus > 0)
                    {
                        BindDataAgencyMember();
                        setNewMember();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }

        private void btnBackAgency_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }
    }
}
