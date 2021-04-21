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
    public partial class FrmVoucher : DockContent
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
        public FrmVoucher()
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

            
            }
            catch (Exception ex)
            {
                //DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveVoucher();
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
         
            ResetItem();
            SearchREQ();

        
        }
        private void SetColumns()
        {
        
            

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
        private void SaveVoucher()//ไม่ reset ก่อน
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
                if (cboReqBranch.SelectedValue + "" == "" )
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
               

                int? intStatusx = new Business.MedicalSupplies().DeleteStockSuppliesTranREQ(REQNoCurrent);
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



     

        private void dgvData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView) sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView) sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

   

       

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            SaveVoucher();
          
            
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void popGetInventory_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics.frmVoucher = null;
          
        }

     
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxNew_Click(object sender, EventArgs e)
        {
            ResetItem();
           
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
               
                txtRemark.Text = "";
                txtRemark.ReadOnly = false;

                cboReqBranch.SelectedValue = "";
              
                cboReqBranch.Enabled = true;
              

                dtpDate.Enabled = true;
                dtpDate.Value = DateTime.Now;
                txtREQNo.Text = "Auto Generate";
                REQNoCurrent = "";
                
                 LsMS_Code = new List<string>();
              

                btnSave.Visible = true;
                picPrint.Visible = true;

             
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
                cboReqBranch.Enabled = !ReadOnlyTrue;
            
                dtpDate.Enabled = !ReadOnlyTrue;
                txtREQNo.ReadOnly = ReadOnlyTrue;
            
                btnSave.Visible = !ReadOnlyTrue;
                picPrint.Visible = !ReadOnlyTrue;
        
                
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
                    if (StockTyp == DerUtility.StockTyp.REQDept)
                    {
                        if (item["Fortype"] + "" == "D")
                        {
                            if (LSREQ.Contains(item["REQNo"] + "") || item["REQNo"] + "" == "") continue;

                            object[] myItems = 
                                                    {
                                                    String.Format("{0:dd/MM/yyyy}",DateTime.Parse(item["REQDate"]+"")),
                                                    item["REQNo"] + "",
                                                    (item["Approved"] + "").ToUpper()=="Y"?new Bitmap(1, 1):imageList1.Images[3],
                                                    (item["Approved"] + "").ToUpper()=="Y"?imageList1.Images[4]:new Bitmap(1, 1),
                                                      (item["UrgentFlag"] + "").ToUpper()=="Y"?imageList1.Images[5]:new Bitmap(1, 1),
                                                      item["EN_Req_Name"] + "",
                                                      item["EN_ReqTo_Name"] + "",
                                              };
                            dataGridViewREQItem.Rows.Add(myItems);
                            LSREQ.Add(item["REQNo"] + "");
                        }
                    }
                    else if (StockTyp == DerUtility.StockTyp.REQBranch)
                    {
                        if (item["Fortype"] + "" == "B")
                        {
                            if (LSREQ.Contains(item["REQNo"] + "") || item["REQNo"] + "" == "") continue;

                            object[] myItems = 
                                                    {
                                                    String.Format("{0:dd/MM/yyyy}",DateTime.Parse(item["REQDate"]+"")),
                                                    item["REQNo"] + "",
                                                    (item["Approved"] + "").ToUpper()=="Y"?new Bitmap(1, 1):imageList1.Images[3],
                                                    (item["Approved"] + "").ToUpper()=="Y"?imageList1.Images[4]:new Bitmap(1, 1),
                                                      (item["UrgentFlag"] + "").ToUpper()=="Y"?imageList1.Images[5]:new Bitmap(1, 1),
                                                      item["EN_Req_Name"] + "",
                                                      item["EN_ReqTo_Name"] + "",
                                              };
                            dataGridViewREQItem.Rows.Add(myItems);
                            LSREQ.Add(item["REQNo"] + "");
                        }
                    }
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
      


        private void picPrint_Click(object sender, EventArgs e)
        {
            try
            {
                SaveVoucher();
              
                dataGridViewREQItem.ClearSelection();

                foreach (DataGridViewRow row in dataGridViewREQItem.Rows)
                {
                    if (row.Cells["REQNo"].Value + "" == REQNoPrint)
                    {
                        dataGridViewREQItem.Rows[row.Index].Selected = true;
                      
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
                FrmPreviewRpt obj = new FrmPreviewRpt();
                DataRow dr;
                obj.PrintType = "";
                string strTypeofPay = "";
                obj.FormName = "RtpREQInventory";

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
           
        }

        private void dataGridViewREQItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dataGridViewREQItem.Columns["DelReq"].Index)
                {
                    if (e.RowIndex < 0) return;
                    string id = dataGridViewREQItem.Rows[e.RowIndex].Cells["REQNo"].Value + "";
                    //DataSet dsSurgeryFee = new Business.MedicalOrderUseTrans().SelectSavedJobCostById("SELECTSAVEDJOBCOSTForEdit", VN, MS_Code, ListOrder, id);
                    //if (dsSurgeryFee.Tables[0].Rows.Count > 0 && !(Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN) && !Userinfo.IS_ADMIN_JOBCOST.Contains(Userinfo.EN))
                    //{
                    //    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, "ไม่สามารถแก้ไขข้อมูลได้เนื่องจาก ได้บันทึกค่ามือและค่าแพทย์ไปแล้ว" + Environment.NewLine + "กรุณาติดต่อผู้ดูแลระบบ");
                    //    return;
                    //}
                    string REQNo = dataGridViewREQItem.Rows[e.RowIndex].Cells["REQNo"].Value + "";
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
                 
                 //   AddItemReq("");
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
