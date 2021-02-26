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
    public partial class popGetInventory : DockContent
    {
        public string MS_Name = "";
        public string MS_Code = "";
        public double MS_Cost = 0;
        DataTable dataTable = new DataTable();
        List<string> LsMS_Code = new List<string>();
        public double MS_Instock = 0;
        private bool Isloaded=false;
        public popGetInventory()
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

                cboToBranch.BeginUpdate();
                cboToBranch.DataSource = ds3.Tables[0];
                cboToBranch.ValueMember = "BranchID";
                cboToBranch.DisplayMember = "BranchName";
                cboToBranch.EndUpdate();
                cboToBranch.SelectedIndex = 1;
                //BranchId = cboToBranch.SelectedValue + "";
                //BranchName = cboToBranch.Text + "";
            }
            catch (Exception ex)
            {
                //DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveStockGet();
           this.DialogResult= DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void popGetInventory_Load(object sender, EventArgs e)
        {
            dtpDate.Value = DateTime.Now;
            //lbMS_Name.Text = MS_Name;
            //txtAmount.Focus();
            //txtMS_Instock.Text = MS_Instock.ToString("###,###,###");
            //txtaveragecost.Text = MS_Cost.ToString("###,###,###.###");
            //BindCboSupplier();
            SetColumns();
            BindMedicalSupplies(1);
            Isloaded = true;
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
            }
            dgvData.Columns.Add(column);


            Entity.MedicalSupplies info = new MedicalSupplies();
            info.QueryType = "LOCATION";

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
            dataGridViewSelectList.Columns.Insert(3, comboBoxColumn1);
               
                
       
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

                info.QueryType = "SEARCHSTOCK";
                info.StartDate = DateTime.Now;
                info.EndDate = DateTime.Now;
                info.BranchID = cboToBranch.SelectedValue + "";
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

                for (int i = 0; i < dgvData.Columns.Count; i++)
                {
                    int colw = dgvData.Columns[i].Width;
                    dgvData.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvData.Columns[i].Width = colw;
                }
             
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
                cboToBranch.Items.Clear();
                cboToBranch.BeginUpdate();
                cboToBranch.DataSource = dtSUPPLIER;
                cboToBranch.ValueMember = "GetByID";
                cboToBranch.DisplayMember = "Get_Detail";

                cboToBranch.EndUpdate();
                AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                foreach (DataRow row in dtSUPPLIER.Rows)
                {
                    if (row["GetByID"] + "" == "") continue;
                    data.Add(row["Get_Detail"] + "");
                }
                cboToBranch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboToBranch.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cboToBranch.AutoCompleteCustomSource = data;
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
        private void SaveStockGet()
        {
            try
            {
                if (string.IsNullOrEmpty(txtInvID.Text))
                {
                    MessageBox.Show("โปรดระบุเลขที่เอกสาร");
                    return;
                }
                if (dataGridViewSelectList.RowCount == 0)
                {
                    MessageBox.Show("โปรดเลือกรายการ");
                    return;
                }
                
                    MedicalSupplies info = new MedicalSupplies();
                    info.LisItemStock = new List<MedicalSupplies>();
                foreach (DataGridViewRow item in dataGridViewSelectList.Rows)
                {
                    MedicalSupplies aa = new MedicalSupplies();
                    aa.MS_Code = item.Cells["_MS_Code"].Value + "";
                    aa.Receive_Cost = item.Cells["_MS_Cost"].Value + "" == "" || item.Cells["_MS_Cost"].Value + "" == "0" ? 0 : Convert.ToDouble(item.Cells["_MS_Cost"].Value + "");
                    aa.MS_CostAVG = item.Cells["_AverageCost"].Value + "" == "" || item.Cells["_AverageCost"].Value + "" == "0" ? 0 : Convert.ToDouble(item.Cells["_AverageCost"].Value + "");
                    aa.ReceiveQuantity = item.Cells["_Quantity"].Value + "" == "" || item.Cells["_Quantity"].Value + "" == "0" ? 0 : Convert.ToDouble(item.Cells["_Quantity"].Value + "");
                    aa.DocNo = txtInvID.Text.Trim() + "";
                    aa.ActiveType = "1";
                    //aa.ByID = cboToBranch.SelectedValue + "";
                    aa.SaveDate = dtpDate.Value;
                    aa.ENSave = Userinfo.EN;
                    aa.Remark = txtRemark.Text;
                    aa.BranchID = cboToBranch.SelectedValue + "";
                    if (item.Cells["_ExpireDate"].Value + "" == "")
                    {
                        MessageBox.Show("Input Expire Date", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        return;
                    }
                    else
                    {
                        aa.ExpireDate = Convert.ToDateTime(item.Cells["_ExpireDate"].Value + "");
                    }

                    info.LisItemStock.Add(aa);
                }
                
                info.QueryType = "SaveRecieptStock";
                          int?  intStatus = new Business.MedicalSupplies().InsertMedicalStockSupplies(ref info);
                            if (intStatus > 0)
                            {
                                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, Statics.StrMsgInsertComplete);
                                //this.Close();
                                if (dataGridViewSelectList.RowCount > 0) dataGridViewSelectList.Rows.Clear();
                                BindMedicalSupplies(1);
                             
                                txtInvID.Text = "";
                                txtRemark.Text = "";
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
            switch (ch1.Value.ToString())
            {
                case "True":
                    ch1.Value = false;
                    break;
                case "False":
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
            
                    foreach (DataGridViewRow item in dgvData.Rows)
                    {
                        DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                        ch1 = (DataGridViewCheckBoxCell)dgvData.Rows[item.Index].Cells[0];

                        if (ch1.Value!=null && ch1.Value.ToString() == "True")
                        {
                            ms_code = item.Cells["รหัส"].Value + "";
                            //if (LsMS_Code.Contains(ms_code)) continue;
                            LsMS_Code.Add(ms_code);
                            object[] myItems = {
                                             false,//chk
                                           item.Cells["รหัส"].Value,
                                           item.Cells["ชื่อ"].Value,
                                           item.Cells["LocationID"].Value,
                                           "0",//Quantity
                                           "0",//Price
                                           "0",//SumPrice
                                           item.Cells["จำนวน"].Value,//Instock
                                           item.Cells["จำนวน"].Value,//Instock
                                           item.Cells["ราคาเฉลี่ย"].Value,//PriceAverage
                                       };
                            //item.Cells[0].Value = false;

                            dataGridViewSelectList.Rows.Add(myItems);
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

                    if (ch1.Value != null && ch1.Value.ToString() == "True")
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


                if (dataGridViewSelectList.Rows.Count < 0 || dataGridViewSelectList.CurrentRow == null) return;

                if (e.ColumnIndex == dataGridViewSelectList.Columns["_ExpireDate"].Index)
                {
                    //if (IsExpireDate(dataGridViewSelectList.Rows[e.RowIndex].Cells["ExpireDate"].Value + "") && !Userinfo.IsAdmin.Contains(Userinfo.EN))
                    //{
                    //    MessageBox.Show("This Item Expired", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return;
                    //}

                    PopDateTime pp = new PopDateTime();
                    DateTime d;
                    pp.SelecttDate = DateTime.TryParse(dataGridViewSelectList.Rows[e.RowIndex].Cells["_ExpireDate"].Value + "", out d) ? d : DateTime.Now;
                    //pp.SelecttDate =Convert.ToDateTime(pp.SelecttDate.ToString("dd/MM/yyyy"));
                    if (pp.ShowDialog() == DialogResult.OK)
                    {
                        dataGridViewSelectList.Rows[e.RowIndex].Cells["_ExpireDate"].Value = pp.SelecttDate.Date.ToString("yyyy/MM/dd");
                    }

                }

                DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                ch1 = (DataGridViewCheckBoxCell)dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells[0];
                if (dataGridViewSelectList.CurrentCell.ColumnIndex != 0) return;
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
            }
            catch (Exception)
            {


            }
           
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            SaveStockGet();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void popGetInventory_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics._popGetInventory = null;
          
        }

        private void cboToBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Isloaded)
            BindMedicalSupplies(1);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

      
        }

        
}
