using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AryuwatSystem.DerClass;
using ClosedXML.Excel;
using System.IO;
using System.Diagnostics;
using WeifenLuo.WinFormsUI.Docking;
using AryuwatSystem.Forms.PrintGridView;

namespace AryuwatSystem.Forms.FRMReport
{
    public partial class FrmStockHistory : DockContent
    {
        private DataTable dataTable = null;
        private DataTable dataTableORG = null;
        public FrmStockHistory()
        {
            InitializeComponent();
        }
        public FrmStockHistory(DataGridView dgv1)
        {
            InitializeComponent();
          
        }
        //private void SetColumns()
        //{
        //    DerUtility.SetPropertyDgv(dgvData);
        //    dgvData.Columns.Add("MS_code", "Code");
        //    dgvData.Columns.Add("MS_Name", "Name");
        //    dgvData.Columns.Add("MS_Detail", "Detail");
        //    dgvData.Columns.Add("MS_CLPrice", "CL Price");
        //    dgvData.Columns.Add("MS_CAPrice", "CA Price");
        //    dgvData.Columns.Add("MS_CMPrice", "CM Price");
        //    dgvData.Columns.Add("MS_Type", "Type");
        //    dgvData.Columns.Add("MS_Number_C", "Course Number");
        //    dgvData.Columns.Add("MS_Instock", "Instock");
        //    dgvData.Columns.Add("MS_Cost", "Average Cost");
        //    dgvData.Columns.Add("MS_CourseDuration", "Cycle day");

        //    dgvData.Columns.Add("UnitName", "Unit");
        //    dgvData.Columns.Add("FeeRate", "Fee Rate");
        //    dgvData.Columns.Add("FeeRate2", "Fee Rate 2");
        //    dgvData.Columns.Add("MaxDiscount", "Max Discount %");
        //    dgvData.Columns.Add("Operation_Name", "Operation");
        //    dgvData.Columns.Add("Purchase_Name", "Purchase");
        //    dgvData.Columns.Add("BranchName", "Branch");

        //    //dgvData.Columns["MS_code"].Visible = false;
        //    dgvData.Columns["MS_code"].Width = 100;
        //    dgvData.Columns["MS_Name"].Width = 150;
        //    dgvData.Columns["MS_Detail"].Width = 150;
        //    dgvData.Columns["MS_CLPrice"].Width = 80;
        //    dgvData.Columns["MS_CAPrice"].Width = 200;
        //    dgvData.Columns["MS_CMPrice"].Width = 200;
        //    dgvData.Columns["MS_Type"].Width = 50;
        //    dgvData.Columns["MS_Number_C"].Width = 50;
        //    dgvData.Columns["MS_CourseDuration"].Width = 50;
        //    dgvData.Columns["MaxDiscount"].Width = 50;

        //}
        private void frmStockHistory_Load(object sender, EventArgs e)
        {
            //SetColumns();
            //BindMedicalSupplies(1);
            txtEnddate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtStartdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            BindCboPurChase_Operation();
        }
        public void BindMedicalSupplies(int _pIntseq)
        {
            try
            {
                
                DerUtility.MouseOn(this);
                //dgvData.Rows.Clear();
                //pIntseq = _pIntseq;
                Entity.MedicalSupplies info = new Entity.MedicalSupplies() { PageNumber = _pIntseq };

                if (!string.IsNullOrEmpty(txtFindCode.Text.Trim()))
                {
                    info.MS_Code = "%" + txtFindCode.Text + "%";
                }
                //if (!string.IsNullOrEmpty(txtFindName.Text))
                //{
                //    info.MS_Name = "%" + txtFindName.Text + "%";
                //}
              
                info.QueryType = "SEARCHSTOCK";
                info.SStartDate = AryuwatSystem.DerClass.DerUtility.ToFormatDateyyyyMMdd(txtStartdate.Text);// Convert.ToDateTime(txtStartdate.Text).ToString("yyyy-MM-dd");// StartDate.ToString();
                info.SEndDate = AryuwatSystem.DerClass.DerUtility.ToFormatDateyyyyMMdd(txtEnddate.Text); //Convert.ToDateTime(txtStartdate.Text).ToString("yyyy-MM-dd");// EndDate.ToString();
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
              
                //dgvData.DataSource = null;
                //dgvData.DataSource = dataTable;

                ////dgvData.Columns["_RowString"].Visible = false;
                //dgvData.Columns["รายละเอียด"].Visible = false;
                //dgvData.Columns["id"].Visible = false;

                //for (int i = 0; i < dgvData.Columns.Count; i++)
                //{
                //    if (dgvData.Columns[i].Name.ToLower().Contains("จำนวน") || dgvData.Columns[i].Name.ToLower().Contains("ราคา") || dgvData.Columns[i].Name.ToLower().Contains("เฉลี่ย") || dgvData.Columns[i].Name.ToLower().Contains("ค่า"))
                //        dgvData.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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
        private void BindCboPurChase_Operation()
        {
            try
            {


               // var ds2 = new Business.MedicalSupplies().SelectOperation();
                //var dr2 = ds2.Tables[0].NewRow();
                //dr2["Setting_Code"] = 0;
                //dr2["Setting_Name"] = Statics.StrValidate;
                //dr2["Setting_Type"] = Statics.StrValidate;
                //ds2.Tables[0].Rows.InsertAt(dr2, 0);
                //// cboOperating.Items.Clear();

                //cboOperating.BeginUpdate();
                //cboOperating.DataSource = ds2.Tables[0];
                //cboOperating.ValueMember = "Setting_Code";
                //cboOperating.DisplayMember = "Setting_Name";
                //cboOperating.EndUpdate();

                //var ds = new Business.MedicalSupplies().SelectPurChase();
                //var dr = ds.Tables[0].NewRow();
                //dr["Setting_Code"] = 0;
                //dr["Setting_Name"] = Statics.StrValidate;
                //dr["Setting_Type"] = Statics.StrValidate;
                //ds.Tables[0].Rows.InsertAt(dr, 0);
                //// cboPurchase.Items.Clear();

                //cboPurchase.BeginUpdate();
                //cboPurchase.DataSource = ds.Tables[0];
                //cboPurchase.ValueMember = "Setting_Code";
                //cboPurchase.DisplayMember = "Setting_Name";
                //cboPurchase.EndUpdate();

                var ds3 = new Business.Branch().SelectBranchAll();
                var dr3 = ds3.Tables[0].NewRow();
                dr3["BranchID"] = "";
                dr3["BranchName"] = Statics.StrValidate;
                ds3.Tables[0].Rows.InsertAt(dr3, 0);
                // cboPurchase.Items.Clear();

                cboBranch.BeginUpdate();
                cboBranch.DataSource = ds3.Tables[0];
                cboBranch.ValueMember = "BranchID";
                cboBranch.DisplayMember = "BranchName";
                cboBranch.EndUpdate();
                cboBranch.SelectedValue = Entity.Userinfo.BranchId;
            }
            catch (Exception ex)
            {
                //DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }
        }
        public void BindHistorySupplies()
        {
            try
            {
               
                  Entity.MedicalSupplies info = new Entity.MedicalSupplies() { PageNumber = 1 };
                 // info.MS_Code = dgvData["รหัส", dgvData.CurrentRow.Index].Value + "";

                info.QueryType = "SEARCH_STOCK_HISTORY";
                info.SStartDate = AryuwatSystem.DerClass.DerUtility.ToFormatDateyyyyMMdd(txtStartdate.Text);// Convert.ToDateTime(txtStartdate.Text).ToString("yyyy-MM-dd");// StartDate.ToString();
                info.SEndDate = AryuwatSystem.DerClass.DerUtility.ToFormatDateyyyyMMdd(txtEnddate.Text); //Convert.ToDateTime(txtStartdate.Text).ToString("yyyy-MM-dd");// EndDate.ToString();
                info.BranchID = cboBranch.SelectedValue+"";
                info.FixSearch = checkBoxFix.Checked ? "Y" : "N";
                dataTable = new Business.MedicalSupplies().SelectMedicalSuppliesPaging(info).Tables[0];
               
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

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dataTable;
                dataGridView1.Columns["_RowString"].Visible = false;
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    if (dataGridView1.Columns[i].Name.ToLower().Contains("จำนวน") || dataGridView1.Columns[i].Name.ToLower().Contains("ราคา") || dataGridView1.Columns[i].Name.ToLower().Contains("เฉลี่ย") || dataGridView1.Columns[i].Name.ToLower().Contains("quan") || dataGridView1.Columns[i].Name.ToLower().Contains("ค่า"))
                        dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                FilterType();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        private void txtFindCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dataTable.DefaultView.RowFilter = string.Format("[_RowString] LIKE '%{0}%'", txtFindCode.Text);
            }
            catch (Exception)
            {

            }
        }

        private void txtFindName_TextChanged(object sender, EventArgs e)
        {
            BindMedicalSupplies(1);
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BindHistorySupplies();
        }

        private void radioButtonAll_Click(object sender, EventArgs e)
        {
            FilterType();
        }

        private void radioButtonReceive_Click(object sender, EventArgs e)
        {
            FilterType();
        }

        private void radioButtonSell_Click(object sender, EventArgs e)
        {
            FilterType();
        }
        private void FilterType()
        {
            try
            {
                if (dataTable == null) return;
                if (radioButtonSell.Checked)
                {
                    dataTable.DefaultView.RowFilter = "[ActiveType] = 'จ่าย'";
                    dataGridView1.Columns["ราคารับ"].Visible = false;
                    dataGridView1.Columns["จำนวนรับ"].Visible=false;
                    dataGridView1.Columns["Receive Detail"].Visible=false;
                    dataGridView1.Columns["ราคาจ่าย"].Visible = true;
                    dataGridView1.Columns["จำนวนจ่าย"].Visible = true;
                    dataGridView1.Columns["CN"].Visible = true;
                    dataGridView1.Columns["Sell Detail"].Visible=true;
                    
                }
                else if (radioButtonReceive.Checked)
                {
                    dataTable.DefaultView.RowFilter = "[ActiveType] = 'รับ'";
                    dataGridView1.Columns["ราคารับ"].Visible = true;
                    dataGridView1.Columns["จำนวนรับ"].Visible = true;
                    dataGridView1.Columns["Receive Detail"].Visible = true;
                    dataGridView1.Columns["ราคาจ่าย"].Visible = false;
                    dataGridView1.Columns["จำนวนจ่าย"].Visible = false;
                    dataGridView1.Columns["CN"].Visible = false;
                    dataGridView1.Columns["Sell Detail"].Visible = false;
                }
                else if (radioButtonAll.Checked)
                {
                    dataTable.DefaultView.RowFilter = "[ActiveType] <>''";
                    dataGridView1.Columns["ราคารับ"].Visible = true;
                    dataGridView1.Columns["จำนวนรับ"].Visible = true;
                    dataGridView1.Columns["Receive Detail"].Visible = true;
                    dataGridView1.Columns["ราคาจ่าย"].Visible = true;
                    dataGridView1.Columns["จำนวนจ่าย"].Visible = true;
                    dataGridView1.Columns["CN"].Visible = true;
                    dataGridView1.Columns["Sell Detail"].Visible = true;
                }
                    //dataTable= dataTableORG.Copy();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonExport1_BtnClick()
        {
            try
            {
                saveFileDialog1.InitialDirectory = Convert.ToString(Environment.SpecialFolder.MyDocuments);
                saveFileDialog1.Filter = "Excel file(*.xlsx)|*.xlsx";
                saveFileDialog1.FilterIndex = 1;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {


                    //ExcelHelper.ExportToExcel(dsData, saveFileDialog1.FileName, "");


                    // dt = city.GetAllCity();//your datatable
                    using (ClosedXML.Excel.XLWorkbook wb = new ClosedXML.Excel.XLWorkbook())
                    {
                        ExportFile exp = new ExportFile();
                        wb.Worksheets.Add(exp.GetDataTableFromDGV(dataGridView1, "Item"));
                        //wb.Worksheets.Worksheet(0).Cells[rowIndex, 22].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        //wb.Worksheets.Worksheet(1).Column("J").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        //wb.Worksheets.Add(dsSurgeryFee.Tables[0],"Data");
                        //if (dsSurgeryFee.Tables.Count > 2)
                        wb.Worksheets.Add(exp.GetDataTableFromDGV(dataGridView1, "History"));
                        //wb.Worksheets.Worksheet(2).Column("B").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        //wb.Worksheets.Add(dsSurgeryFee.Tables[1],"Summary");
                        wb.SaveAs(saveFileDialog1.FileName);
                        //DataSet dataSet = new DataSet();
                        //dataSet.Tables.Add(exp.GetDataTableFromDGV(dgvData));
                        //exp.Export(dataSet, saveDlg.FileName);
                        //exp.ExportUseCloseXML(dataSet, saveDlg.FileName);
                        //exp.ExportMultipleGridToOneExcel(exp.GetDataTableFromDGV(dgvData));
                        //AryuwatSystem.Forms.ExcelHelper.ExportToExcel(dataSet, saveFileDialog1.FileName, "");
                        if (File.Exists(saveFileDialog1.FileName))
                        {
                            Process.Start(saveFileDialog1.FileName);
                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            BindHistorySupplies();
        }

        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            BindHistorySupplies();
        }

        private void FrmStockHistory_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics.frmStockHistory = null;
        }

        private void buttonFind2_BtnClick()
        {
            BindHistorySupplies();
        }

        private void txtStartdate_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                BindHistorySupplies();
        }

        private void txtEnddate_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                BindHistorySupplies();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDGV.Print_DataGridView(dataGridView1);
            }
            catch (Exception)
            {

            }
        }

        private void txtStartdate_MouseClick(object sender, MouseEventArgs e)
        {
            DerUtility.GetSetInputKeyBorad("english");
        }

        private void txtEnddate_MouseClick(object sender, MouseEventArgs e)
        {
            DerUtility.GetSetInputKeyBorad("english");
        }

        private void buttonPrint1_BtnClick()
        {
            try
            {
                PrintDGV.Print_DataGridView(dataGridView1);
            }
            catch (Exception)
            {

            }
        }

       
    }
}
