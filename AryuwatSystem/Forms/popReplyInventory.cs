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
    public partial class popReplyInventory : DockContent
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
        public DerUtility.StockTyp StockTyp { get; set; }
        public double MS_Instock = 0;
        private bool Isloaded=false;
        public popReplyInventory()
        {
            InitializeComponent();
            BindCboBranch();
            
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
            SaveREQStock("Y");
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
            BindCboLocation();
            BindDept();
            ResetItem();
            SearchREQ();
            if (StockTyp == DerUtility.StockTyp.ReplyDept) cboInDept.Checked = true;
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
                column.Name = "CheckItem";
                column.Width=20;
            }
            dgvData.Columns.Add(column);
            //dgvData.Columns["CheckItem"].Visible = false;

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

                info.QueryType = "SEARCHREQSTOCK";
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
                    for (int i = 0; i < dataTable.Columns.Count - 1; i++)
                    {
                        sb.Append(dataRow[i].ToString());
                        sb.Append("\t");
                    }
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
        private void SaveREQStock(string App)//ไม่ reset ก่อน
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
              
                
              
                if (REQNoCurrent == "")
                {
                    REQNoCurrent = AryuwatSystem.Data.UtilityBackEnd.GenMaxSeqnoValues("REQ", cboReqBranch.SelectedValue + "");
                    txtREQNo.Text = REQNoCurrent;
                }
                REQNoPrint = REQNoCurrent;
                    MedicalSupplies info = new MedicalSupplies();
                    info.LisItemStock = new List<MedicalSupplies>();
                foreach (DataGridViewRow item in dataGridViewSelectList.Rows)
                {
                    MedicalSupplies aa = new MedicalSupplies();
                    aa.QueryType="UPDATE_REPLY_STOCK";//INSER_REQ_STOCK
                    aa.MS_Code = item.Cells["_MS_Code"].Value + "";
                    aa.Quantity = item.Cells["_Quantity"].Value + "" == "" || item.Cells["_Quantity"].Value + "" == "0" ? 0 : Convert.ToDouble(item.Cells["_Quantity"].Value + "");
                    aa.QuantityReply = item.Cells["_QuantityReply"].Value + "" == "" || item.Cells["_QuantityReply"].Value + "" == "0" ? 0 : Convert.ToDouble(item.Cells["_QuantityReply"].Value + "");
                    aa.REQDate = dtpDate.Value;
                    //aa.EN_Req = Userinfo.EN;
                    aa.EN_ReqTo = Userinfo.EN;//ผู้บันทึก หรือผู้ตอบกลับ
                    aa.Remark = txtRemark.Text;
                    aa.RemarkReply = txtRemarkReply.Text;
                    aa.REQNo = txtREQNo.Text.Trim();
                    aa.Req_BranchId = cboReqBranch.SelectedValue + "";
                    aa.ReqTo_BranchId = cboReqToBranch.SelectedValue + "";
                    aa.Approved = App;
                    aa.Replydate = dtpDateReply.Value;
                    aa.Fortype = cboInDept.Checked ? "D" : "B";
                    aa.UrgentFlag = cboUrgentFlag.Checked ? "Y" : "N";
                    aa.ReturnsFlag = cboReturns.Checked ? "Y" : "N";
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

                //int? intStatusx = new Business.MedicalSupplies().DeleteStockSuppliesTranREQ(REQNoCurrent);
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
                if (REQNoCurrent != "") panelFind.Visible = true;
                foreach (DataGridViewRow item in dgvData.Rows)
                {
                    DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                    ch1 = (DataGridViewCheckBoxCell)dgvData.Rows[item.Index].Cells[0];

                    if (ch1.Value != null && ch1.Value.ToString().ToLower() == "true")
                    {
                        ms_code = item.Cells["รหัส"].Value + "";
                        if (LsMS_Code.Contains(ms_code)) continue;

                        object[] myItems = {
                                             false,//chk
                                           item.Cells["รหัส"].Value,
                                           item.Cells["ชื่อ"].Value,
                                           "0",//Quantity
                                           "0",//QuantityReply
                                           item.Cells["หน่วย"].Value,
                                           item.Cells["จำนวน"].Value,//Instock จำนวนในคลัง
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
           
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            SaveREQStock("Y");
          
            
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void popGetInventory_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics.popReplyInventory = null;
          
        }

        private void cboToBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cboReqBranch.SelectedIndex != 1)
            //BindMedicalSupplies(1);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxNew_Click(object sender, EventArgs e)
        {
            ResetItem();
            panelFind.Visible = true;
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
                txtRemarkReply.Text = "";
                cboReqBranch.SelectedValue = "";
                cboWH.SelectedValue = "";
                cboDept.SelectedValue = "";
                cboReqToBranch.SelectedValue = "";
                dtpDate.Value = DateTime.Now;
                txtREQNo.Text = "Auto Generate";
                REQNoCurrent = "";
                panelFind.Visible = false;
                LsMS_Code = new List<string>();
                panelAdd.Visible = false;
                
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
                info.QueryType = "Search_REQ_STOCKTRAN";

                info.StartDate = dateTimePickerSt.Value.AddDays(-1);
                info.EndDate = dateTimePickerEnd.Value.AddDays(1);


                DataSet ds = new Business.MedicalSupplies().SelectStock(info);
                if (ds.Tables.Count <= 0) return;

                dtReq = ds.Tables[0];
                List<string> LSREQ = new List<string>();
                foreach (DataRowView item in dtReq.DefaultView)
                {
                    if (StockTyp == DerUtility.StockTyp.ReplyDept)
                    {
                        if (item["Fortype"] + "" == "D")
                        {
                            if (LSREQ.Contains(item["REQNo"] + "") || item["REQNo"] + "" == "") continue;
                            object[] myItems = 
                                                    {
                                                     Convert.ToDateTime(item["REQDate"]+"").ToString("dd/MM/yyyy"),
                                                    item["REQNo"] + "",
                                                    (item["Approved"] + "").ToUpper()=="Y"?imageList1.Images[3]:new Bitmap(1, 1),
                                                    (item["UrgentFlag"] + "").ToUpper()=="Y"?imageList1.Images[4]:new Bitmap(1, 1),
                                                     item["EN_Req_Name"] + "",
                                                      item["EN_ReqTo_Name"] + "",
                                              };
                            dataGridViewREQItem.Rows.Add(myItems);
                            LSREQ.Add(item["REQNo"] + "");
                        }
                    }
                    else if (StockTyp == DerUtility.StockTyp.ReplyBranch)
                    {
                        if (item["Fortype"] + "" == "B")
                        {
                            if (LSREQ.Contains(item["REQNo"] + "") || item["REQNo"] + "" == "") continue;
                            object[] myItems = 
                                                    {
                                                        Convert.ToDateTime(item["REQDate"]+"").ToString("dd/MM/yyyy"),
                                                    item["REQNo"] + "",
                                                    (item["Approved"] + "").ToUpper()=="Y"?imageList1.Images[3]:new Bitmap(1, 1),
                                                    (item["UrgentFlag"] + "").ToUpper()=="Y"?imageList1.Images[4]:new Bitmap(1, 1),
                                                      item["EN_Req_Name"] + "",
                                                      item["EN_ReqTo_Name"] + "",
                                              };
                            dataGridViewREQItem.Rows.Add(myItems);
                            LSREQ.Add(item["REQNo"] + "");
                        }
                    }
                }
                //dataGridViewREQItem.ClearSelection();
                if (dataGridViewREQItem.RowCount > 0) dataGridViewREQItem.Rows[0].Selected = true;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AddItemReq(string FixREQNo)
        {
            btnUnApp.Visible = false;
            string REQNo = "";
            LsMS_Code = new List<string>();
            string EN_ReqTo = "";
            try
            {
                if (dataGridViewSelectList.Rows.Count > 0)
                    dataGridViewSelectList.Rows.Clear();

                //List<string> LSREQ = new List<string>();
                foreach (DataRow item in dtReq.Rows)
                {
                    REQNo = item["REQNo"] + "";//ทั้งหมด
                    
                    FixREQNo=FixREQNo!=""?FixREQNo:dataGridViewREQItem.Rows[dataGridViewREQItem.CurrentRow.Index].Cells["REQNo"].Value + "";

                    if (FixREQNo == REQNo)//เทียบกับตัวที่เลือก
                    {
                        EN_ReqTo = item["EN_ReqTo"] + "";
                        if( LsMS_Code.Contains(item["MS_Code"] + ""))continue;
                        object[] myItems = 
                                            {
                                           false,//chk
                                           item["MS_Code"]+"",
                                           item["MS_Name"]+"",
                                           item["Quantity"]+"",
                                           item["QuantityReply"]+"",
                                           item["REQUnitName"]+"",
                                           ""
                                      };

                        dataGridViewSelectList.Rows.Add(myItems);
                        LsMS_Code.Add(item["MS_Code"] + "");
                        txtRemark.Text = item["Remark"] + "";
                        txtRemarkReply.Text = item["RemarkReply"] + "";
                        cboReqBranch.SelectedValue = item["Req_BranchId"] + "";
                        cboReqToBranch.SelectedValue = item["ReqTo_BranchId"] + "";
                        dtpDate.Value = Convert.ToDateTime(item["REQDate"] + "");
                        txtREQNo.Text =REQNoCurrent= item["REQNo"] + "";
                        cboWH.SelectedValue = item["WHCode"] + "";
                        cboDept.SelectedValue = item["Dept"] + "";
                        dtpDateReply.Value=item["Replydate"] + ""==""?DateTime.Now.Date:Convert.ToDateTime(item["Replydate"] + "");
                        txtREPNo.Text= item["REPNo"] + "";
                        cboReturns.Checked = (item["ReturnsFlag"] + "").ToUpper() == "Y" ? true : false;
                        cboUrgentFlag.Checked = (item["UrgentFlag"] + "").ToUpper() == "Y" ? true : false;
                        //cboReqBranch.Enabled = false;
                        //this.cboReqBranch.UseBackColor = true;
                        //cboReqBranch.BackColor = Color.Red;
                        //cboReqBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                    }
                }

                if (Userinfo.EN == EN_ReqTo || Userinfo.IsAdmin.Contains(Userinfo.EN)) //approve=N  และ ไม่ใช่เข้าของ ไม่ใช่ admin ReadOnly=true
                {
                    btnUnApp.Visible = true;
                }
             
                dataGridViewSelectList.Columns[0].Visible = false;
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
                SaveREQStock("Y");
                AddItemReq(REQNoPrint);
                dataGridViewREQItem.ClearSelection();
                foreach (DataGridViewRow row in dataGridViewREQItem.Rows)
                {
                    if (row.Cells["REQNo"].Value + "" == REQNoPrint)
                        dataGridViewREQItem.Rows[row.Index].Selected = true;
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
                FrmPreviewRpt obj = new FrmPreviewRpt();
                DataRow dr;
                obj.PrintType = "";
                string strTypeofPay = "";
                obj.FormName = "RtpReplyInventory";

                double dblCredit = 0.00;
                double dblCash = 0.00;
                string strBankName = "";

                dblCredit += dblCash;
                obj.TypeOfPayment = strTypeofPay;
                obj.PayToday = dblCredit.ToString("###,###,##0.00");

                DataView datavw = new DataView();
                datavw = dtReq.DefaultView;
                datavw.RowFilter = string.Format("[REQNo]='{0}'", REQNoPrint);
               
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
            try
            {
                if (e.ColumnIndex == dataGridViewREQItem.Columns["Ststus"].Index)
                {
                    //string id = dataGridViewREQItem.Rows[e.RowIndex].Cells["REQNo"].Value + "";
                    ////DataSet dsSurgeryFee = new Business.MedicalOrderUseTrans().SelectSavedJobCostById("SELECTSAVEDJOBCOSTForEdit", VN, MS_Code, ListOrder, id);
                    ////if (dsSurgeryFee.Tables[0].Rows.Count > 0 && !Userinfo.IsAdmin.Contains(Userinfo.EN) && !Userinfo.IS_ADMIN_JOBCOST.Contains(Userinfo.EN))
                    ////{
                    ////    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, "ไม่สามารถแก้ไขข้อมูลได้เนื่องจาก ได้บันทึกค่ามือและค่าแพทย์ไปแล้ว" + Environment.NewLine + "กรุณาติดต่อผู้ดูแลระบบ");
                    ////    return;
                    ////}
                    //string REQNo = dataGridViewREQItem.Rows[e.RowIndex].Cells["REQNo"].Value + "";
                    //if (DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirmYesNo, Statics.StrConfirmDelete + " "+REQNo) == DialogResult.Yes)
                    //{

                    //    int? intStatusx = new Business.MedicalSupplies().DeleteStockSuppliesREQ(REQNo);

                    //    if (intStatusx != -1)
                    //    {
                    //        DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "ลบข้อมูลเรียบร้อยแล้ว");
                    //        SearchREQ();

                    //    }

                    //}

                }
                else
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

        private void btnUnApp_Click(object sender, EventArgs e)
        {
            SaveREQStock("N");
        }

        private void dataGridViewREQItem_SelectionChanged(object sender, EventArgs e)
        {
            panelFind.Visible = false;
            AddItemReq("");
        }

        private void dataGridViewREQItem_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        private void dataGridViewSelectList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
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
                    if ((row.Cells["REQNo"].Value + "").ToUpper().Contains(textBoxFind2.Text.ToUpper()) || (row.Cells["ReqBy"].Value + "").ToUpper().Contains(textBoxFind2.Text.ToUpper()) || (row.Cells["Reply"].Value + "").ToUpper().Contains(textBoxFind2.Text.ToUpper()))
                    {
                        row.Visible = true;
                    }
                }

            }
            catch (Exception)
            {

            }
        }



      
        }

        
}
