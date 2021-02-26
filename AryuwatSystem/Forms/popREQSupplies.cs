using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entity;
using AryuwatSystem.DerClass;
using WeifenLuo.WinFormsUI.Docking;


namespace AryuwatSystem.Forms
{
    public partial class popREQSupplies : DockContent
    {
        public string MS_Name = "";
        public string MS_Code = "";
        public double MS_Cost = 0;
        string REQNoSelect = "";
        string REQNoCurrent = ""; 
        string REQNoPrint = "";
        DataTable dataTable = new DataTable();
        DataTable dtReq = new DataTable();
        List<string> LsMS_Code = new List<string>();
        public double MS_Instock = 0;
        private bool Isloaded=false;
        public DerUtility.StockTyp StockTyp { get; set; }
        public popREQSupplies()
        {
            InitializeComponent();
            BindCboBranch();
            
        }
        private void BindCboBranch()
        {
            try
            {
                var ds3 = new Business.Branch().SelectBranchAll();
                var dr3 = ds3.Tables[0].NewRow();
                dr3["BranchID"] = "";
                dr3["BranchName"] = Statics.StrValidate;
                ds3.Tables[0].Rows.InsertAt(dr3, 0);
                // cboPurchase.Items.Clear();

                cboReqBranch.BeginUpdate();
                cboReqBranch.DataSource = ds3.Tables[0];
                cboReqBranch.ValueMember = "BranchID";
                cboReqBranch.DisplayMember = "BranchName";
                cboReqBranch.EndUpdate();
                cboReqBranch.SelectedIndex = 1;

                cboReqToBranch.BeginUpdate();
                cboReqToBranch.DataSource = ds3.Tables[0].Copy();
                cboReqToBranch.ValueMember = "BranchID";
                cboReqToBranch.DisplayMember = "BranchName";
                cboReqToBranch.EndUpdate();
                cboReqToBranch.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                //DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveREQStock();
           this.DialogResult= DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void popGetInventory_Load(object sender, EventArgs e)
        {
            dtpDate.Value = DateTime.Now;
            dateTimePickerSt.Value = DateTime.Now.AddMonths(-1);
            //lbMS_Name.Text = MS_Name;
            //txtAmount.Focus();
            //txtMS_Instock.Text = MS_Instock.ToString("###,###,###");
            //txtaveragecost.Text = MS_Cost.ToString("###,###,###.###");
            //BindCboSupplier();
            SetColumns();
            BindMedicalSupplies(1);
            BindDept();
            BindCboLocation();
            ResetItem();
            SearchREQ();

            if (StockTyp == DerUtility.StockTyp.REQDept)
            {
                cboInDept.Checked = true;
              //  cboReqToBranch.Enabled = false;
                cboReturns.Visible = false;
               // cboInDept.Visible = true;
                dataGridViewSelectList.Columns["_QuantityReply"].Visible = false;
            }
        }
        private void SetColumns()
        {
            DerUtility.SetPropertyDgv(dgvData);
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            {
                column.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                column.FlatStyle = FlatStyle.Standard;
                column.ThreeState = false;
                column.CellTemplate = new DataGridViewCheckBoxCell();
                column.CellTemplate.Style.BackColor = Color.Beige;
                //column.Name = "CheckItem";
                column.Width=20;
            }
            dgvData.Columns.Add(column);
            

            Entity.MedicalSupplies info = new MedicalSupplies();
            info.QueryType = "LOCATION";
            info.StartDate =DateTime.Now;
            info.EndDate = DateTime.Now;

            DataTable dtLocation = new Business.MedicalSupplies().SelectStock(info).Tables[0];

            var dr = dtLocation.NewRow();
            dr["LocationID"] = "";
            dr["Location_Detail"] = "";
            dtLocation.Rows.InsertAt(dr, 0);
            //cboSupplier.Items.Clear();
            //cboSupplier.BeginUpdate();
            //cboSupplier.DataSource = dtLocation;
            //cboSupplier.ValueMember = "CutByID";
            //cboSupplier.DisplayMember = "Cut_Detail";

            DataGridViewComboBoxColumn comboBoxColumn1;
            comboBoxColumn1 = new DataGridViewComboBoxColumn();

            comboBoxColumn1.DataSource = dtLocation;
            comboBoxColumn1.ValueMember = "LocationID";
            comboBoxColumn1.DisplayMember = "Location_Detail";
            comboBoxColumn1.HeaderText = "คลัง";
            comboBoxColumn1.Name = "Location";
            comboBoxColumn1.Width = 150;
            comboBoxColumn1.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            comboBoxColumn1.ReadOnly = true;
            //dataGridViewSelectList.Columns.Insert(3, comboBoxColumn1);
               
                
       
            //dgvData.Columns.Add("MS_code", "Code");
            //dgvData.Columns.Add("MS_Name", "Name");
            //dgvData.Columns.Add("MS_Detail", "Detail");
            //dgvData.Columns.Add("MS_CLPrice", "CL Price");
            //dgvData.Columns.Add("MS_CAPrice", "CA Price");
            //dgvData.Columns.Add("MS_CMPrice", "CM Price");
            //dgvData.Columns.Add("MS_Type", "Type");
            //dgvData.Columns.Add("MS_Number_C", "Course Number");
            //dgvData.Columns.Add("MS_Instock", "Instock");
            //dgvData.Columns.Add("MS_Cost", "Average Cost");
            //dgvData.Columns.Add("MS_CourseDuration", "Cycle day");

            //dgvData.Columns.Add("UnitName", "Unit");
            //dgvData.Columns.Add("FeeRate", "Fee Rate");
            //dgvData.Columns.Add("FeeRate2", "Fee Rate 2");
            //dgvData.Columns.Add("MaxDiscount", "Max Discount %");
            //dgvData.Columns.Add("Operation_Name", "Operation");
            //dgvData.Columns.Add("Purchase_Name", "Purchase");
            //dgvData.Columns.Add("BranchName", "Branch");

            ////dgvData.Columns["MS_code"].Visible = false;
            //dgvData.Columns["MS_code"].Width = 100;
            //dgvData.Columns["MS_Name"].Width = 150;
            //dgvData.Columns["MS_Detail"].Width = 150;
            //dgvData.Columns["MS_CLPrice"].Width = 80;
            //dgvData.Columns["MS_CAPrice"].Width = 200;
            //dgvData.Columns["MS_CMPrice"].Width = 200;
            //dgvData.Columns["MS_Type"].Width = 50;
            //dgvData.Columns["MS_Number_C"].Width = 50;
            //dgvData.Columns["MS_CourseDuration"].Width = 50;
            //dgvData.Columns["MaxDiscount"].Width = 50;

        }
        public void BindMedicalSupplies(int _pIntseq)
        {
            try
            {
                DerUtility.MouseOn(this);
                //dgvData.Rows.Clear();
                //pIntseq = _pIntseq;
                Entity.MedicalSupplies info = new Entity.MedicalSupplies() { PageNumber = _pIntseq };
                //if (!string.IsNullOrEmpty(txtFindCode.Text.Trim()))
                //{
                //    info.MS_Code = "%" + txtFindCode.Text + "%";
                //}
                //if (!string.IsNullOrEmpty(txtFindName.Text))
                //{
                //    info.MS_Name = "%" + txtFindName.Text + "%";
                //}

                dgvData.DataSource = null;

                info.QueryType = "SEARCHREQSupplies";
                info.StartDate = DateTime.Now;
                info.EndDate = DateTime.Now;
                info.BranchID = cboReqBranch.SelectedValue + "";
                dataTable = new Business.MedicalSupplies().SelectMedicalSuppliesPaging(info).Tables[0];

                long lngTotalPage = 0;
                long lngTotalRecord = 0;
                if (dataTable.Rows.Count <= 0)
                {
                    //ngbMain.CurrentPage = 0;
                    //ngbMain.TotalPage = 0;
                    //ngbMain.TotalRecord = 0;
                    //ngbMain.Updates();
                    DerUtility.MouseOff(this);
                    //Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "ไม่พบข้อมูลในระบบ");
                    return;
                }
                DataColumn dcRowString = dataTable.Columns.Add("_RowString", typeof(string));
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    StringBuilder sb = new StringBuilder();
                    //for (int i = 0; i < dataTable.Columns.Count - 1; i++)
                    //{
                        sb.Append(dataRow[1].ToString());
                        sb.Append("\t");
                        sb.Append(dataRow[3].ToString());
                   // }
                    dataRow[dcRowString] = sb.ToString();
                }
                //====================For  filter=====end=======================
                //foreach (DataRowView item in dataTable.DefaultView)
                //{
                //    var myItems = new[]
                //                      {
                //                          item["MS_code"] + "",
                //                          item["MS_Name"]+"",
                //                          item["MS_Detail"] + "",
                //                          string.IsNullOrEmpty(item["MS_CLPrice"] + "") ? "0" : Convert.ToDouble(item["MS_CLPrice"] + "").ToString("###,###.##"),
                //                          string.IsNullOrEmpty(item["MS_CAPrice"] + "") ? "0" : Convert.ToDouble(item["MS_CAPrice"] + "").ToString("###,###.##"),
                //                          string.IsNullOrEmpty(item["MS_CMPrice"] + "") ? "0" : Convert.ToDouble(item["MS_CMPrice"] + "").ToString("###,###.##"),
                //                          item["MS_Type"] + "" ,
                //                          item["MS_Number_C"] + "" ,
                //                          item["MS_Instock"] + "" ,
                //                          item["MS_Cost"] + "" ,
                //                          item["MS_CourseDuration"] + "" ,
                                          
                //                          item["UnitName"] + "" ,
                //                          string.IsNullOrEmpty(item["FeeRate"] + "") ? "0" : Convert.ToDouble(item["FeeRate"] + "").ToString("###,###.##"),
                //                          string.IsNullOrEmpty(item["FeeRate2"] + "") ? "0" : Convert.ToDouble(item["FeeRate2"] + "").ToString("###,###.##"),
                //                          string.IsNullOrEmpty(item["MaxDiscount"] + "") ? "" : Convert.ToDouble(item["MaxDiscount"] + "").ToString("###,###.##"),
                //                          item["Operation_Name"] + "" ,
                //                          item["Purchase_Name"] + "" ,
                //                          item["BranchName"] + "" 
                //                      };
                //    dgvData.Rows.Add(myItems);
                //    if (lngTotalPage != 0) continue;
                //    DerUtility.FindTotalPage(Convert.ToInt32(item["rowTotal"].ToString()), ref lngTotalPage);
                //    lngTotalRecord = Convert.ToInt32(item["rowTotal"].ToString());

                //}
                dgvData.DataSource = null;
                dgvData.DataSource = dataTable;
                //dgvData.Columns["MS_CMPrice"].Visible = false;
                //dgvData.Columns["MS_CLPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                //dgvData.Columns["MS_CAPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                //dgvData.Columns["MS_Type"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                //dgvData.Columns["MS_Number_C"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                //dgvData.Columns["FeeRate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                //dgvData.Columns["FeeRate2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                //dgvData.Columns["MaxDiscount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                dgvData.Columns["_RowString"].Visible = false;
                dgvData.Columns["รายละเอียด"].Visible = false;
                dgvData.Columns["id"].Visible = false;
                //for (int i = 0; i < dgvData.Columns.Count; i++)
                //{
                //    if (dgvData.Columns[i].Name.ToLower().Contains("จำนวน") || dgvData.Columns[i].Name.ToLower().Contains("ราคา") || dgvData.Columns[i].Name.ToLower().Contains("เฉลี่ย") || dgvData.Columns[i].Name.ToLower().Contains("quan") || dgvData.Columns[i].Name.ToLower().Contains("ค่า"))
                //        dgvData.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //}
                //dgvData.RowsDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
                //for (int i = 0; i < dgvData.Columns.Count - 1; i++)
                //{
                //    dgvData.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                //}
                //dataGridView1.Columns[dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                //for (int i = 0; i < dgvData.Columns.Count; i++)
                //{
                //    int colw = dgvData.Columns[i].Width;
                //    dgvData.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //    dgvData.Columns[i].Width = colw;
                //}
                if (dgvData.Columns.Contains("รหัส")) dgvData.Columns["รหัส"].Visible = false;
                DerUtility.MouseOff(this);
                //  RefreshText();

            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
            finally
            {
            }
        }
        private void BindCboSupplier()
        {
            try
            {
                Entity.MedicalSupplies info = new MedicalSupplies();
                info.QueryType = "SUPPLIER";

                DataTable dtSUPPLIER = new Business.MedicalSupplies().SelectStock(info).Tables[0];
                
                var dr = dtSUPPLIER.NewRow();
                dr["GetByID"] = "";
                dr["Get_Detail"] = "";
                dtSUPPLIER.Rows.InsertAt(dr, 0);
                cboReqBranch.Items.Clear();
                cboReqBranch.BeginUpdate();
                cboReqBranch.DataSource = dtSUPPLIER;
                cboReqBranch.ValueMember = "GetByID";
                cboReqBranch.DisplayMember = "Get_Detail";

                cboReqBranch.EndUpdate();
                AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                foreach (DataRow row in dtSUPPLIER.Rows)
                {
                    if (row["GetByID"] + "" == "") continue;
                    data.Add(row["Get_Detail"] + "");
                }
                cboReqBranch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboReqBranch.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cboReqBranch.AutoCompleteCustomSource = data;
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }
        }
        private void BindCboLocation()
        {
            try
            {
                Entity.MedicalSupplies info = new MedicalSupplies();
                info.QueryType = "SUPPLIER";
                info.StartDate = DateTime.Now;
                info.EndDate = DateTime.Now;

                DataTable dtSUPPLIER = new Business.MedicalSupplies().SelectStock(info).Tables[1];

                var dr = dtSUPPLIER.NewRow();
                dr["LocationID"] = "";
                dr["Location_Detail"] = "";
                dtSUPPLIER.Rows.InsertAt(dr, 0);
                cboWH.Items.Clear();
                cboWH.BeginUpdate();
                cboWH.DataSource = dtSUPPLIER;
                cboWH.ValueMember = "LocationID";
                cboWH.DisplayMember = "Location_Detail";

                cboWH.EndUpdate();
                //AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                //foreach (DataRow row in dtSUPPLIER.Rows)
                //{
                //    if (row["LocationID"] + "" == "") continue;
                //    data.Add(row["Location_Detail"] + "");
                //}
                //cboLocation.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //cboLocation.AutoCompleteSource = AutoCompleteSource.CustomSource;
                //cboLocation.AutoCompleteCustomSource = data;
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }
        }
        private void BindDept()
        {
            try
            {
                Entity.MedicalSupplies info = new MedicalSupplies();
                //info.QueryType = "SUPPLIER";
                //info.StartDate = DateTime.Now;
                //info.EndDate = DateTime.Now;

                DataTable dtSUPPLIER = new Business.MedicalSupplies().SelectDept(info).Tables[0];

                var dr = dtSUPPLIER.NewRow();
                dr["DeptCode"] = "";
                dr["DeptName"] = "";
                dtSUPPLIER.Rows.InsertAt(dr, 0);
                cboDept.Items.Clear();
                
                cboDept.DataSource = dtSUPPLIER;

                cboDept.ValueMember = "DeptCode";
                cboDept.DisplayMember = "DeptName";

                //comboBoxDept.EndUpdate();
                //AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                //foreach (DataRow row in dtSUPPLIER.Rows)
                //{
                //    if (row["LocationID"] + "" == "") continue;
                //    data.Add(row["Location_Detail"] + "");
                //}
                //cboLocation.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //cboLocation.AutoCompleteSource = AutoCompleteSource.CustomSource;
                //cboLocation.AutoCompleteCustomSource = data;
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }
        }
        double CallAverageCost(double NewItem, double newCost, double oldCost,double oldItem)
        {
            if (NewItem == 0 || newCost == 0) return 0;
            //double oldCost = 0;
            //double newCost = 0;
            double avrage = 0;
            //double NewItem = txtAmount.Text == "" ? 0 : Convert.ToDouble(txtAmount.Text);
            //newCost = txtPrice.Text == "" ? 0 : Convert.ToDouble(txtPrice.Text);

            //oldCost = MS_Cost * MS_Instock;
            if (oldCost == 0)
            {
                avrage = ((oldItem + NewItem) * newCost) / (oldItem + NewItem);
            }
            else
            {
                avrage = ((oldCost * oldItem) + (newCost * NewItem)) / (oldItem + NewItem);   /// (MS_Cost + newCost) / (MS_Instock + NewItem);
            }                                                                                                 
            return avrage;
        }
        private void SaveREQStock()//ไม่ reset ก่อน
        {
            try
            {
                //if (string.IsNullOrEmpty(txtREQNo.Text))
                //{
                //    MessageBox.Show("โปรดระบุเลขที่เอกสาร");
                //    return;
                //}
                //if (dataGridViewSelectList.RowCount == 0)
                //{
                //    MessageBox.Show("โปรดเลือกรายการ");
                //    return;
                //}
                if (cboReqBranch.SelectedValue + "" == "" || cboReqToBranch.SelectedValue + "" == "")
                {
                    MessageBox.Show("โปรดเลือกสาขา");
                    return;
                }
                //if (cboWH.SelectedValue + "" == "")
                //{
                //    MessageBox.Show("โปรดเลือก W/H");
                //    return;
                //}
                //if (cboDept.SelectedValue + "" == "")
                //{
                //    MessageBox.Show("โปรดเลือก แผนก");
                //    return;
                //}
                
              
                if (REQNoCurrent == "")
                {
                    REQNoCurrent = AryuwatSystem.Data.UtilityBackEnd.GenMaxSeqnoValues("SPQ", cboReqBranch.SelectedValue + "");
                    txtREQNo.Text = REQNoCurrent;
                }
                REQNoPrint = REQNoCurrent;
                    MedicalSupplies info = new MedicalSupplies();
                    info.LisItemStock = new List<MedicalSupplies>();
                foreach (DataGridViewRow item in dataGridViewSelectList.Rows)
                {
                    MedicalSupplies aa = new MedicalSupplies();
                    aa.QueryType = "INSER_SPQ_STOCK";//INSER_REQ_STOCK
                    aa.MS_Code = item.Cells["_MS_Code"].Value + "";
                    aa.Quantity = item.Cells["_Quantity"].Value + "" == "" || item.Cells["_Quantity"].Value + "" == "0" ? 0 : Convert.ToDouble(item.Cells["_Quantity"].Value + "");
                    aa.REQDate = dtpDate.Value;
                    aa.EN_Req = Userinfo.EN;
                    aa.Remark = txtRemark.Text;
                    aa.REQNo = txtREQNo.Text.Trim();
                    aa.Req_BranchId = cboReqBranch.SelectedValue + "";
                    aa.ReqTo_BranchId = cboReqToBranch.SelectedValue + "";
                    aa.WHCode = cboWH.SelectedValue + "";
                    aa.Dept = cboDept.SelectedValue + "";
                    aa.ReturnsFlag = cboReturns.Checked ? "Y" : "N";
                    aa.UrgentFlag = cboUrgentFlag.Checked ? "Y" : "N";
                    aa.Fortype = cboInDept.Checked ? "D" : "B";
                    aa.REQUnitCode = item.Cells["REQUnitCode"].Value + "";
                    
                    //if (item.Cells["_ExpireDate"].Value + "" == "")
                    //{
                    //    MessageBox.Show("Input Expire Date", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    //    return;
                    //}
                    //else
                    //{
                    //    aa.ExpireDate = Convert.ToDateTime(item.Cells["_ExpireDate"].Value + "");
                    //}

                    info.LisItemStock.Add(aa);
                }

                int? intStatusx = new Business.MedicalSupplies().DeleteStockSuppliesTranSPQ(REQNoCurrent);
                int? intStatus = new Business.MedicalSupplies().InsertMedicalStockSuppliesREQ(ref info);
                            if (intStatus > 0)
                            {
                                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, Statics.StrMsgInsertComplete);
                              
                                SearchREQ();
                             
                            }
                            else
                            {
                                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation,
                                               Statics.StrMsgCannotSave + " ข้อมูลผิดพลาด");
                            }
                          
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnSuppiler_Click(object sender, EventArgs e)
        {

        }

        private void txtFindAes_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dataTable.DefaultView.RowFilter = string.Format("[_RowString] LIKE '%{0}%'", txtFind.Text);
                //BindingSource bs = new BindingSource();
                //bs.DataSource = dgvData.DataSource;
                //bs.Filter = string.Format("CONVERT(" + dgvData.Columns["_RowString"].DataPropertyName + ", System.String) like '%" + txtFilter.Text.Replace("'", "''") + "%'");
                //dgvData.DataSource = bs;
            }
            catch (Exception)
            {

            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                if (dgvData.Rows.Count < 0 || dgvData.CurrentRow == null) return;
            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
            ch1 = (DataGridViewCheckBoxCell)dgvData.Rows[dgvData.CurrentRow.Index].Cells[0];
            if (dgvData.CurrentCell.ColumnIndex != 0) return;
            if (ch1.Value == null)
                ch1.Value = false;
            switch (ch1.Value.ToString().ToLower())
            {
                case "true":
                    ch1.Value = false;
                    break;
                case "false":
                    ch1.Value = true;
                    break;
            }
            }
            catch (Exception)
            {

               
            }
        }

        private void dgvData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView) sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView) sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        private void buttonAddDown_BtnClick()
        {
            string ms_code = "";
            try
            {
                if(REQNoCurrent!="")panelFind.Visible = true;
                    foreach (DataGridViewRow item in dgvData.Rows)
                    {
                        DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                        ch1 = (DataGridViewCheckBoxCell)dgvData.Rows[item.Index].Cells[0];

                        if (ch1.Value!=null && ch1.Value.ToString().ToLower() == "true")
                        {
                            ms_code = item.Cells["รหัสเก่า"].Value + "";
                            if (LsMS_Code.Contains(ms_code)) continue;
                        
                            object[] myItems = {
                                             false,//chk
                                           item.Cells["รหัสเก่า"].Value,
                                           item.Cells["ชื่อ"].Value,
                                           "0",//Quantity
                                           "0",//QuantityReply
                                           item.Cells["MainUnitCode"].Value,
                                           item.Cells["MainUnitName"].Value,
                                           item.Cells["MainUnitCode"].Value,
                                           item.Cells["MainUnitName"].Value,
                                           item.Cells["SubUnitCode"].Value,
                                           item.Cells["SubUnitName"].Value,
                                       };
                            //item.Cells[0].Value = false;

                            dataGridViewSelectList.Rows.Add(myItems);
                            LsMS_Code.Add(ms_code);
                            ch1.Value = "false";
                        }
                    }
                dataGridViewSelectList.ClearSelection();
            }
            catch (Exception ex)
            {
                if (LsMS_Code.Contains(ms_code))
                    LsMS_Code.Remove(ms_code);
                MessageBox.Show(ex.Message);
            }
        }
        private void buttonDeleteUp_BtnClick()
        {
            try
            {
                List<DataGridViewRow> rowsToDelete = new List<DataGridViewRow>();
                foreach (DataGridViewRow item in dataGridViewSelectList.Rows)
                {
                    DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                    ch1 = (DataGridViewCheckBoxCell)dataGridViewSelectList.Rows[item.Index].Cells[0];

                    if (ch1.Value != null && ch1.Value.ToString().ToLower() == "true")
                    {
                        if (LsMS_Code.Contains(item.Cells["_MS_Code"].Value + "")) LsMS_Code.Remove(item.Cells["_MS_Code"].Value + "");
                        rowsToDelete.Add(item);
                    }
                }
                foreach (DataGridViewRow row in rowsToDelete)
                    dataGridViewSelectList.Rows.Remove(row);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dataGridViewSelectList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewSelectList.EndEdit();
            try
            {
                if (e.ColumnIndex == 0) return;
                 foreach (DataGridViewRow item in dataGridViewSelectList.Rows)
                {
                    if (e.RowIndex == item.Index)
                    {
                        //if (LsMS_Code.Contains(item.Cells["_Quantity"].Value + "")) LsMS_Code.Remove(item.Cells["_MS_Code"].Value + "");
                        double newIten = 0;
                        double oldIten = 0;
                        double NewCost = 0;
                        double OldCost = 0;

                        if (AryuwatSystem.DerClass.DerUtility.IsNumeric(item.Cells["_Quantity"].Value + ""))
                            newIten = item.Cells["_Quantity"].Value + "" == "" || item.Cells["_Quantity"].Value + "" == "0" ? 0 : Convert.ToDouble(item.Cells["_Quantity"].Value + "");
                        else
                        {
                            item.Cells["_Quantity"].Value = 0;
                            newIten = 0;
                        }
                        if (AryuwatSystem.DerClass.DerUtility.IsNumeric(item.Cells["_MS_Cost"].Value + ""))
                            NewCost = item.Cells["_MS_Cost"].Value + "" == "" || item.Cells["_MS_Cost"].Value + "" == "0" ? 0 : Convert.ToDouble(item.Cells["_MS_Cost"].Value + "");
                        else
                        {
                            item.Cells["_MS_Cost"].Value = 0;
                            NewCost = 0;
                        }

                        //newIten = item.Cells["_Quantity"].Value + "" == "" || item.Cells["_Quantity"].Value + "" == "0" ? 0 : Convert.ToDouble(item.Cells["_Quantity"].Value + "");
                        //NewCost = item.Cells["_MS_Cost"].Value + "" == "" || item.Cells["_MS_Cost"].Value + "" == "0" ? 0 : Convert.ToDouble(item.Cells["_MS_Cost"].Value + "");
                        OldCost = item.Cells["_AverageCost"].Value + "" == "" || item.Cells["_AverageCost"].Value + "" == "0" ? 0 : Convert.ToDouble(item.Cells["_AverageCost"].Value + "");
                        oldIten = item.Cells["InStock"].Value + "" == "" || item.Cells["InStock"].Value + "" == "0" ? 0 : Convert.ToDouble(item.Cells["InStock"].Value + "");
                        if (newIten == 0 || NewCost == 0) continue;

                        item.Cells["_SumCost"].Value = (newIten * NewCost).ToString("###,###,###,###.00");
                        item.Cells["SumInStock"].Value = (newIten + oldIten).ToString("###,###,###,###.00");

                        item.Cells["_AverageCost"].Value = CallAverageCost(newIten, NewCost, OldCost, oldIten).ToString("###,###,###,###.00");
                    }

                }
            }
            catch (Exception)
            {
               
            }
        }

        private void dataGridViewSelectList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
                if (e.ColumnIndex == dataGridViewSelectList.Rows[e.RowIndex].Cells["REQUnitName"].ColumnIndex)
                    {
                        popUnitREQ pc = new popUnitREQ();
                        pc.Text = dataGridViewSelectList.Rows[e.RowIndex].Cells["_MS_Name"].Value + "";
                        pc.MainUnitCode = dataGridViewSelectList.Rows[e.RowIndex].Cells["MainUnitCode"].Value + "";
                        pc.MainUnitName = dataGridViewSelectList.Rows[e.RowIndex].Cells["MainUnitName"].Value + "";
                        pc.SubUnitCode = dataGridViewSelectList.Rows[e.RowIndex].Cells["SubUnitCode"].Value + "";
                        pc.SubUnitName = dataGridViewSelectList.Rows[e.RowIndex].Cells["SubUnitName"].Value + "";
                        if (pc.ShowDialog() == DialogResult.OK)
                        {
                            dataGridViewSelectList.Rows[e.RowIndex].Cells["REQUnitCode"].Value = pc.SelectValues;
                            dataGridViewSelectList.Rows[e.RowIndex].Cells["REQUnitName"].Value = pc.SelectText;
                        }
                    }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            SaveREQStock();
          
            
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void popGetInventory_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics.popreqSupplies = null;
          
        }

        private void cboToBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StockTyp == DerUtility.StockTyp.REQDept)
            {
                //cboReqToBranch.SelectedValue = cboReqBranch.SelectedValue;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxNew_Click(object sender, EventArgs e)
        {
            ResetItem();
            panelFind.Visible = true;
            panelAdd.Visible = true;
        }

        private void buttonFind_BtnClick()
        {
            SearchREQ();
        }

        private void ResetItem()
        {
            try
            {
                if (dataGridViewREQItem.Rows.Count > 0)
                    dataGridViewREQItem.Rows.Clear();
                if (dataGridViewSelectList.Rows.Count > 0)
                    dataGridViewSelectList.Rows.Clear();
                txtRemark.Text = "";
                txtRemark.ReadOnly = false;

                cboReqBranch.SelectedValue = "";
                cboWH.SelectedValue = "";
                cboDept.SelectedValue = "";
                cboReqToBranch.SelectedValue = "";

                cboReqBranch.Enabled = true;
                cboWH.Enabled = true;
                cboDept.Enabled = true;
                cboReqToBranch.Enabled = true;

                dtpDate.Enabled = true;
                dtpDate.Value = DateTime.Now;
                txtREQNo.Text = "Auto Generate";
                REQNoCurrent = "";
                REQNoPrint = "";
                panelFind.Visible = false;
                 LsMS_Code = new List<string>();
                _QuantityReply.Visible = false;
                panelAdd.Visible = false;
                cboReturns.Enabled = true;
                cboReturns.Checked = false;
                cboUrgentFlag.Enabled = true;
                cboUrgentFlag.Checked = false;

                btnSave.Visible = true;
                picPrint.Visible = true;
                btnSaveGet.Visible = !btnSave.Visible;
                if (StockTyp == DerUtility.StockTyp.REQDept)
                {
                  //  cboReqToBranch.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ReadOnlyItem(bool ReadOnlyTrue)
        {
            try
            {
                txtRemark.ReadOnly = ReadOnlyTrue;
                //cboReqBranch.Enabled = !ReadOnlyTrue;
                //cboReqToBranch.Enabled = !ReadOnlyTrue;
                cboWH.Enabled = !ReadOnlyTrue;
                cboDept.Enabled = !ReadOnlyTrue;
                dtpDate.Enabled = !ReadOnlyTrue;
                txtREQNo.ReadOnly = ReadOnlyTrue;
                panelFind.Visible = !ReadOnlyTrue;
                panelAdd.Visible = !ReadOnlyTrue;
                btnSave.Visible = !ReadOnlyTrue;
                btnSaveGet.Visible = !btnSave.Visible;
                dataGridViewSelectList.Columns["_QuantityReceive"].Visible = btnSaveGet.Visible;
                dataGridViewSelectList.Columns["_QuantityReceive"].ReadOnly = !btnSaveGet.Visible;
                //picPrint.Visible = !ReadOnlyTrue;
                if (StockTyp != DerUtility.StockTyp.REQDept)
                {
                    dataGridViewSelectList.Columns["_QuantityReply"].Visible = ReadOnlyTrue;
                }
                //else cboReqToBranch.Enabled = false;
                //dataGridViewSelectList.Columns["Select"].Visible = !ReadOnlyTrue;
                cboUrgentFlag.Enabled = !ReadOnlyTrue;
                cboReturns.Enabled = !ReadOnlyTrue;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SearchREQ()
        {
            try
            {

                ResetItem();

                Entity.MedicalSupplies info = new MedicalSupplies();
                info.QueryType = "Search_SPQ_STOCKTRAN";

                info.StartDate = dateTimePickerSt.Value.AddDays(-1);
                info.EndDate = dateTimePickerEnd.Value.AddDays(1);


                DataSet ds = new Business.MedicalSupplies().SelectStock(info);
                if (ds.Tables.Count <= 0) return;

                dtReq = ds.Tables[0];
                List<string> LSREQ = new List<string>();
                foreach (DataRowView item in dtReq.DefaultView)
                {
                    //if (StockTyp == DerUtility.StockTyp.REQDept)
                    //{
                    //    if (item["Fortype"] + "" == "D")
                    //    {
                            if (LSREQ.Contains(item["SPQNo"] + "") || item["SPQNo"] + "" == "") continue;

                            object[] myItems = 
                                                    {
                                                    String.Format("{0:dd/MM/yyyy}",DateTime.Parse(item["REQDate"]+"")),
                                                    item["SPQNo"] + "",
                                                    (item["Approved"] + "").ToUpper()=="Y"?new Bitmap(1, 1):imageList1.Images[3],
                                                    (item["Approved"] + "").ToUpper()=="Y"?imageList1.Images[4]:new Bitmap(1, 1),
                                                      (item["UrgentFlag"] + "").ToUpper()=="Y"?imageList1.Images[5]:new Bitmap(1, 1),
                                                      item["EN_Req_Name"] + "",
                                                      item["EN_ReqTo_Name"] + "",
                                              };
                            dataGridViewREQItem.Rows.Add(myItems);
                            LSREQ.Add(item["SPQNo"] + "");
                    //    }
                    //}
                    //else if (StockTyp == DerUtility.StockTyp.REQBranch)
                    //{
                    //    if (item["Fortype"] + "" == "B")
                    //    {
                    //        if (LSREQ.Contains(item["SPQNo"] + "") || item["SPQNo"] + "" == "") continue;

                    //        object[] myItems = 
                    //                                {
                    //                                String.Format("{0:dd/MM/yyyy}",DateTime.Parse(item["REQDate"]+"")),
                    //                                item["SPQNo"] + "",
                    //                                (item["Approved"] + "").ToUpper()=="Y"?new Bitmap(1, 1):imageList1.Images[3],
                    //                                (item["Approved"] + "").ToUpper()=="Y"?imageList1.Images[4]:new Bitmap(1, 1),
                    //                                  (item["UrgentFlag"] + "").ToUpper()=="Y"?imageList1.Images[5]:new Bitmap(1, 1),
                    //                                  item["EN_Req_Name"] + "",
                    //                                  item["EN_ReqTo_Name"] + "",
                    //                          };
                    //        dataGridViewREQItem.Rows.Add(myItems);
                    //        LSREQ.Add(item["SPQNo"] + "");
                    //    }
                    //}
                }
                //dataGridViewREQItem.ClearSelection();
                if(dataGridViewREQItem.Rows.Count>0)
                    dataGridViewREQItem.Rows[0].Selected=true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        bool ReadOnlyx = true;
        private void AddItemReq(string FixREQNo)
        {
            string REQNo = "";
           
            bool Approved = false;
            LsMS_Code = new List<string>();
            string EN_Req = "";
            try
            {
                if (dataGridViewSelectList.Rows.Count > 0)
                    dataGridViewSelectList.Rows.Clear();

                //List<string> LSREQ = new List<string>();
                foreach (DataRow item in dtReq.Rows)
                {
                    REQNo = item["SPQNo"] + "";//ทั้งหมด
                    
                    FixREQNo=FixREQNo!=""?FixREQNo:dataGridViewREQItem.Rows[dataGridViewREQItem.CurrentRow.Index].Cells["SPQNo"].Value + "";

                    if (FixREQNo == REQNo)//เทียบกับตัวที่เลือก
                    {
                         EN_Req = item["EN_Req"] + "";
                        if (LsMS_Code.Contains(item["MS_Code"] + "")) continue;
                        LsMS_Code.Add(item["MS_Code"] + "");

                        object[] myItems = 
                                            {
                                           false,//chk
                                           item["MS_Code"]+"",
                                           item["MS_Name"]+"",
                                           item["Quantity"]+"",
                                           item["QuantityReply"]+"",
                                           item["REQUnitCode"]+"",
                                           item["REQUnitName"]+"",
                                           item["MainUnitCode"]+"",
                                           item["MainUnitName"]+"",
                                           item["SubUnitCode"]+"",
                                           item["SubUnitName"]+"",
                                           item["QuantityReceive"]+"",
                                      };

                        dataGridViewSelectList.Rows.Add(myItems);
                
                        txtRemark.Text = item["Remark"] + "";
                        cboReqBranch.SelectedValue = item["Req_BranchId"] + "";
                        cboReqToBranch.SelectedValue = item["ReqTo_BranchId"] + "";
                        cboReturns.Checked=(item["ReturnsFlag"] + "").ToUpper()=="Y"?true:false;
                        cboUrgentFlag.Checked = (item["UrgentFlag"] + "").ToUpper() == "Y" ? true : false;
                        
                        dtpDate.Value = item["REQDate"] + ""==""?DateTime.Now.Date:Convert.ToDateTime(item["REQDate"] + "");
                        txtREQNo.Text =REQNoCurrent= item["SPQNo"] + "";
                        ReadOnlyx = Approved=(item["Approved"] + "").ToUpper() == "Y" ? true : false;
                        cboWH.SelectedValue = item["WHCode"] + "";
                        cboDept.SelectedValue = item["Dept"] + "";
                        cboInDept.Checked = (item["Fortype"] + "").ToUpper() == "D" ? true : false;
                        
                    }
                }
                if (Approved == false && Userinfo.EN != EN_Req && !Userinfo.IsAdmin.Contains(Userinfo.EN)) //approve=N  และ ไม่ใช่เข้าของ ไม่ใช่ admin ReadOnly=true
                {
                    ReadOnlyx = false;
                }
                ReadOnlyItem(ReadOnlyx);//Approved=Y ให้ read only ทันที แม้ว่าจะเป็นเจ้าของหรือไม่
                dataGridViewSelectList.ClearSelection();
            }
            catch (Exception ex)
            {
                if (LsMS_Code.Contains(REQNo))
                    LsMS_Code.Remove(REQNo);
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewSelectList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dataGridViewSelectList.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void picPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //if (ReadOnlyx)//approve=N  และ ไม่ใช่เข้าของ ไม่ใช่ admin ReadOnly=true  ไม้ต้อง save   ReadOnlyx = false;
                //    SaveREQStock();
              
                dataGridViewREQItem.ClearSelection();

                foreach (DataGridViewRow row in dataGridViewREQItem.Rows)
                {
                    if (row.Cells["SPQNo"].Value + "" == REQNoPrint)
                    {
                        dataGridViewREQItem.Rows[row.Index].Selected = true;
                        AddItemReq(REQNoPrint);
                    }
                }
                PrintREQ();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void PrintREQ()
        {
            try
            {
                if (REQNoPrint == "") MessageBox.Show("เลือกใบเบิก");

                FrmPreviewRpt obj = new FrmPreviewRpt();
                DataRow dr;
                obj.PrintType = "";
                string strTypeofPay = "";
                obj.FormName = "RtpSPQInventory";

                double dblCredit = 0.00;
                double dblCash = 0.00;
                string strBankName = "";

                dblCredit += dblCash;
                obj.TypeOfPayment = strTypeofPay;
                obj.PayToday = dblCredit.ToString("###,###,##0.00");

                DataView datavw = new DataView();
                datavw = dtReq.DefaultView;
                datavw.RowFilter = string.Format("[SPQNo]='{0}'", REQNoPrint);
               
                if (datavw.Count > 0)
                {
                    obj.dt = datavw.ToTable().Copy();
                    obj.MaximizeBox = true;
                    obj.TopMost = true;
                    obj.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewREQItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridViewREQItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex<0) return;
                string REQNo = dataGridViewREQItem.Rows[e.RowIndex].Cells["SPQNo"].Value + "";
                if (e.ColumnIndex == dataGridViewREQItem.Columns["DelReq"].Index)
                {
                    
                    string id = dataGridViewREQItem.Rows[e.RowIndex].Cells["SPQNo"].Value + "";
                    //DataSet dsSurgeryFee = new Business.MedicalOrderUseTrans().SelectSavedJobCostById("SELECTSAVEDJOBCOSTForEdit", VN, MS_Code, ListOrder, id);
                    //if (dsSurgeryFee.Tables[0].Rows.Count > 0 && !Userinfo.IsAdmin.Contains(Userinfo.EN) && !Userinfo.IS_ADMIN_JOBCOST.Contains(Userinfo.EN))
                    //{
                    //    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, "ไม่สามารถแก้ไขข้อมูลได้เนื่องจาก ได้บันทึกค่ามือและค่าแพทย์ไปแล้ว" + Environment.NewLine + "กรุณาติดต่อผู้ดูแลระบบ");
                    //    return;
                    //}
                  
                    if (DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirmYesNo, Statics.StrConfirmDelete + " " + REQNo) == DialogResult.Yes)
                    {

                        int? intStatusx = new Business.MedicalSupplies().DeleteStockSuppliesREQ(REQNo);

                        if (intStatusx != -1)
                        {
                            DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "ลบข้อมูลเรียบร้อยแล้ว");
                            SearchREQ();

                        }

                    }

                }
                else
                {
                   
                    REQNoPrint = REQNo;
                    //panelFind.Visible = false;
                    //AddItemReq("");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewREQItem_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 2, e.RowBounds.Location.Y + 4);
        }

        private void dataGridViewSelectList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        private void dataGridViewREQItem_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewREQItem.SelectedRows.Count > 0)
                {
                    panelFind.Visible = false;
                    AddItemReq("");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxFind2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //dataTable.DefaultView.RowFilter = string.Format("[_RowString] LIKE '%{0}%'", txtFind.Text);

                foreach (DataGridViewRow row in dataGridViewREQItem.Rows)
                {
                    row.Visible = false;
                    //REQNo ReqBy Reply
                    if ((row.Cells["SPQNo"].Value + "").ToUpper().Contains(textBoxFind2.Text.ToUpper()) || (row.Cells["ReqBy"].Value + "").ToUpper().Contains(textBoxFind2.Text.ToUpper()) || (row.Cells["Reply"].Value + "").ToUpper().Contains(textBoxFind2.Text.ToUpper()))
                    {
                        row.Visible = true;
                    }
                }
   
            }
            catch (Exception)
            {

            }
        }

        private void dataGridViewSelectList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                 e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
                 if (dataGridViewSelectList.CurrentCell.ColumnIndex == 3 || dataGridViewSelectList.CurrentCell.ColumnIndex == 4 || dataGridViewSelectList.CurrentCell.ColumnIndex == 11) //Desired Column
                {
                    TextBox tb = e.Control as TextBox;
                    if (tb != null)
                    {
                        tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            try
            {
            // allowed numeric and one dot  ex. 10.23
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
                 && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveGet_Click(object sender, EventArgs e)
        {
            try
            {
                MedicalSupplies info = new MedicalSupplies();
                info.LisItemStock = new List<MedicalSupplies>();
                foreach (DataGridViewRow item in dataGridViewSelectList.Rows)
                {
                    MedicalSupplies aa = new MedicalSupplies();
                    aa.QueryType = "UPDATE_SPQ_STOCK";//INSER_REQ_STOCK
                    aa.MS_Code = item.Cells["_MS_Code"].Value + "";
                    aa.QuantityReceive = item.Cells["_QuantityReceive"].Value + "" == "" || item.Cells["_QuantityReceive"].Value + "" == "0" ? 0 : Convert.ToDouble(item.Cells["_QuantityReceive"].Value + "");
                    aa.REQNo = REQNoCurrent;
                    //if(aa.QuantityReceive>0)
                   info.LisItemStock.Add(aa);
                }
                
                int? intStatus = new Business.MedicalSupplies().InsertMedicalStockSuppliesREQ(ref info);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



      
        }

        
}
