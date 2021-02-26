using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using AryuwatSystem.DerClass;
using Excel = Microsoft.Office.Interop.Excel;

using System.IO;
using System.Web;
using System.Diagnostics;
using System.Web.UI.WebControls;
using AryuwatSystem.Forms.FRMReport;
using AryuwatSystem.Forms.PrintGridView; 
namespace AryuwatSystem.Forms
{
    public partial class FrmCommonReportSaleOutStanding : DockContent
    {
        bool bind = true;
        private string MedStatus_Code = "";
        private string MedStatus_CodeNew = "";
        private string MedStatus_CodePending = "";
        private string MedStatus_CodeClosed = "";
        DataSet dsData;
        public FrmCommonReportSaleOutStanding()
        {
            InitializeComponent();
            //dgvData.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dgvData_EditingControlShowing);
        }
        private void SetColumns()
        {
            try
            {
                //DerUtility.SetPropertyDgv(dgvData);
                for (int i = 0; i < dgvData.Columns.Count - 1; i++)
                {
                    dgvData.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                for (int i = 0; i < dgvData.Columns.Count; i++)
                {
                    int colw = dgvData.Columns[i].Width;
                    dgvData.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvData.Columns[i].Width = colw;
                    dgvData.Columns[i].ReadOnly = true;
                }


                if (dgvData.Columns.Contains("SalePrice"))
                    dgvData.Columns["SalePrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                if (dgvData.Columns.Contains("Amount"))
                    dgvData.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                if (dgvData.Columns.Contains("AmountOfUse"))
                    dgvData.Columns["AmountOfUse"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                if (dgvData.Columns.Contains("Balances"))
                    dgvData.Columns["Balances"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                if (dgvData.Columns.Contains("[Balances(Baht)]"))
                    dgvData.Columns["Balances"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                if (dgvData.Columns.Contains("ContractResultID"))
                    dgvData.Columns["ContractResultID"].Visible = false;

                if (!dgvData.Columns.Contains("ContractResultID"))
                    return;
                

                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("ID");
                dataTable.Columns.Add("TextShow");
                dataTable.Rows.Add("", "");
                dataTable.Rows.Add("1", "ติดต่อไม่ได้");
                dataTable.Rows.Add("2", "ติดต่อได้ มาใช้");
                dataTable.Rows.Add("3", "ติดต่อได้ ไม่มาใช้");
                DataGridViewComboBoxColumn c = new DataGridViewComboBoxColumn();
                c.Name = "Contract";
                c.HeaderText = "Contract";
                c.DataSource = dataTable;
                c.ValueMember = "ID";
                c.DisplayMember = "TextShow";
                c.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                c.FlatStyle = FlatStyle.Flat;
            
                c.Width = 130;
                dgvData.Columns.Insert(0, c);
                
               
             
         
                //if (dgvData.Columns.Contains("SOno"))
                //    dgvData.Columns["SOno"].Visible = false;

                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    DataGridViewComboBoxCell cell = row.Cells[0] as DataGridViewComboBoxCell;
                    if (cell != null)
                    {
                        cell.Value = row.Cells["ContractResultID"].Value+"";
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
      
        private void SelectDate(System.Windows.Forms.TextBox txt)
        {
            try
            {
                    PopDateTime pp = new PopDateTime();
                    DateTime d;
                if(txt.Text.Trim()!="")
                    pp.SelecttDate = Convert.ToDateTime(txt.Text.Trim());// DateTime.TryParse(txt.Text, out d) ? d : DateTime.Now;
                else
                    pp.SelecttDate =Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));// DateTime.TryParse(txt.Text, out d) ? d : DateTime.Now;
                    //pp.SelecttDate =Convert.ToDateTime(pp.SelecttDate);
                    if (pp.ShowDialog() == DialogResult.OK)
                    {
                        //txt.Text = pp.SelecttDate.Date.ToString("dd/MM/yyyy");
                        txt.Text = pp.SelecttDate.Date.ToString("yyyy/MM/dd");
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonFind_BtnClick()
        {
            try
            {
                lbCount.Text = "";
                if (bind)
                    BindReportOutStanding(1);
                else
                {
                    bind = true;
                }
                //if (dsData.Tables.Count > 0)
                //{
                //    ucPivotTable1.dt = dsData.Tables[0];
                //    ucPivotTable1.ReloadColumn();
                //}
                lbCount.Text = string.Format("Count {0}", dgvData.RowCount.ToString("###,###,###"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        public void BindReportOutStanding(int pIntseq)
        {
            try
            {
                //DerUtility.MouseOn(this);

                var info = new Entity.Report() { PageNumber = pIntseq };
                
                MedStatus_CodeNew = checkBoxConnotContact.Checked ? "0" : null;
                MedStatus_CodePending = checkBoxCanContactYes.Checked ? "1" : null;
                MedStatus_CodeClosed = checkBoxCanContactNo.Checked ? "2" : null;
                info.MedStatus_CodeNew = MedStatus_CodeNew;
                info.MedStatus_CodePending = MedStatus_CodePending;
                info.MedStatus_CodeClosed = MedStatus_CodeClosed;
                //info.BirthMonth = comboBoxPeriod.Text;
                info.BranchId = uBranch1.BranchId;
                 if(radioButtonNormal.Checked)
                    info.QueryType = "SEARCH_OutStanding";
                 if (radioButtonNormal.Checked && checkBoxToday.Checked)
                     info.QueryType = "SEARCH_OutStandingToday";
                 if (radioButtonNormal.Checked && checkBoxSumAll.Checked)
                    info.QueryType = "SEARCH_OutStandingNoWhere";
                 if (radioButtonSummary.Checked)
                     info.QueryType = "SEARCH_OutStandingSummary";
                 if (radioButtonPro.Checked)
                    info.QueryType = "SEARCH_OutStandingProPacket";
                 if (radioButtonPro.Checked && checkBoxToday.Checked)
                     info.QueryType = "SEARCH_OutStandingProPacketToday";
                 if (radioButtonPro.Checked && checkBoxSumAll.Checked)
                    info.QueryType = "SEARCH_OutStandingProPacketNoWhere";

                //if(checkBoxToday.Checked)
                //    info.TodayOnly = "Y";


                if (!string.IsNullOrEmpty(txtStartdate.Text.Trim()))
                {
                    info.StartDate = txtStartdate.Text;
                }
                if (!string.IsNullOrEmpty(txtEnddate.Text.Trim()))
                {
                    info.EndDate = txtEnddate.Text;
                }
                dsData = new Business.Report().SelectReportPaging(info);
                //decimal SalePrice = 0;
                //decimal MS_Price = 0;
                //decimal Amount = 0;
                //decimal SpecialPrice = 0;
                //decimal PriceAfterDis = 0;
                //decimal DiscountBathByItem = 0;

                //long lngTotalPage = 0;
                //long lngTotalRecord = 0;
                //if (dsData.Tables[0].Rows.Count <= 0)
                //{
                //    //ngbMain.CurrentPage = 0;
                //    //ngbMain.TotalPage = 0;
                //    //ngbMain.TotalRecord = 0;
                //    //ngbMain.Updates();
                //    Utility.MouseOff(this);
                //    // Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "ไม่พบข้อมูลในระบบ");
                //    return;
                //}
                //dgvData.Columns.Clear();
                //dgvData.AutoGenerateColumns = true;
                //dgvData.DataSource = null;
                //dgvData.DataSource = dsData.Tables[0];


                dgvData.Columns.Clear();
                dgvData.AutoGenerateColumns = true;
                dgvData.DataSource = null;

                dgvDataSum.Columns.Clear();
                dgvDataSum.AutoGenerateColumns = true;
                dgvDataSum.DataSource = null;

                //DerUtility.MouseOff(this);
                if (dsData.Tables[0].Rows.Count <= 0) return;
                DataColumn dcRowString = dsData.Tables[0].Columns.Add("_RowString", typeof(string));
                foreach (DataRow dataRow in dsData.Tables[0].Rows)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < dsData.Tables[0].Columns.Count - 1; i++)
                    {
                        sb.Append(dataRow[i].ToString());
                        sb.Append("\t");
                    }
                    dataRow[dcRowString] = sb.ToString();
                }

                dgvData.DataSource = dsData.Tables[0];
                dgvDataSum.DataSource = dsData.Tables[1];
                dgvData.Columns["_RowString"].Visible = false;
                //SetColumns();
                lbCount.Text = string.Format("Count {0}", dgvData.RowCount.ToString("###,###,###"));
                //ngbMain.CurrentPage = pIntseq;
                //ngbMain.TotalPage = lngTotalPage;
                //ngbMain.TotalRecord = lngTotalRecord;
                //ngbMain.Updates();
                //DerUtility.MouseOff(this);
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                //DerUtility.MouseOff(this);
                return;
            }
           
        }
     
      
        public DataSet LoadDatasetFromXml(string fileName)
        {
            DataSet ds = new DataSet();
            FileStream fs = null;

            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                using (StreamReader reader = new StreamReader(fs))
                {
                    ds.ReadXml(reader);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }

            return ds;
        }
    
        private void FrmCommonReportSaleOutStanding_Load(object sender, EventArgs e)
        {

            try
            {
              //  dgvData.AutoGenerateColumns = true;

                txtEnddate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txtStartdate.Text = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");
            }
            catch (Exception ex)
            {
               
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

                    // dt = city.GetAllCity();//your datatable
                    using (ClosedXML.Excel.XLWorkbook wb = new ClosedXML.Excel.XLWorkbook())
                    {
                        //wb.Worksheets.Add(dsSurgeryFee.Tables[0]);//DGVTODatable
                        ExportFile exp = new ExportFile();
                        wb.Worksheets.Add(exp.GetDataTableFromDGV(dgvDataSum, "Summary"));
                        wb.Worksheets.Add(exp.GetDataTableFromDGV(dgvData, "Result"));

                        //wb.Worksheets.Add(DGVTODatable());

                        wb.SaveAs(saveFileDialog1.FileName);
                        if (File.Exists(saveFileDialog1.FileName))
                        {
                            Process.Start(saveFileDialog1.FileName);
                        }
                    }
                 


                 
                    //using (ClosedXML.Excel.XLWorkbook wb = new ClosedXML.Excel.XLWorkbook())
                    //{
                    //    ExportFile ep = new ExportFile();
                    //    wb.Worksheets.Add(ep.GetDataTableFromDGV(dgvData, "Result"));
                    //    wb.Worksheets.Add(ep.GetDataTableFromDGV(dgvDataSum, "Summary"));
                       
                    //    wb.SaveAs(saveFileDialog1.FileName);
                    //    if (File.Exists(saveFileDialog1.FileName))
                    //    {
                    //        Process.Start(saveFileDialog1.FileName);
                    //    }
                    //}
                }
               
            }
            catch (Exception ex)
            {
               
            }
        }


        private void ExportData(string filename)
        {

            Excel.Application xlApp;

            Excel.Workbook xlWorkBook;

            Excel.Worksheet xlWorkSheet;

            object misValue = System.Reflection.Missing.Value;



            xlApp = new Excel.Application();

            xlWorkBook = xlApp.Workbooks.Add(misValue);

            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            int i = 0;

            int j = 0;



            for (i = 0; i <= dgvData.RowCount - 1; i++)
            {

                for (j = 0; j <= dgvData.ColumnCount - 1; j++)
                {

                    DataGridViewCell cell = dgvData[j, i];

                    xlWorkSheet.Cells[i + 1, j + 1] = cell.Value;

                }

            }



            xlWorkBook.SaveAs(filename, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

            xlWorkBook.Close(true, misValue, misValue);

            xlApp.Quit();



            releaseObject(xlWorkSheet);

            releaseObject(xlWorkBook);

            releaseObject(xlApp);



            MessageBox.Show("Excel file created , you can find the file c:\\csharp.net-informations.xls");

        }



        private void releaseObject(object obj)
        {

            try
            {

                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);

                obj = null;

            }

            catch (Exception ex)
            {

                obj = null;

                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());

            }

            finally
            {

                GC.Collect();

            }

        }

        private void FrmCommonReportSaleOutStanding_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics.frmCommonReportSaleOutStanding = null;
        }
      
      
        private void OnCellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 1 || e.ColumnIndex < 0 )
                return;

            //e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
        
            //if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex) && e.ColumnIndex < 8)
            //{
            //    e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            //}
            //else
            //{
            //    e.AdvancedBorderStyle.Top = dgvData.AdvancedCellBorderStyle.All;
            //}  
           
        }
        //bool IsTheSameCellValue(int column, int row)
        //{
        //    //DataGridViewCell cell1 = dgvData[column, row];
        //    //DataGridViewCell cell2 = dgvData[column, row - 1];
        //    //if (cell1.Value == null || cell2.Value == null)
        //    //{
        //    //    return false;
        //    //}
        //    return cell1.Value.ToString() == cell2.Value.ToString();
        //}

      

       

     

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bm, 0, 0);
        }
        Bitmap bm;
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                int height = dgvData.Height;
                dgvData.Height = dgvData.RowCount * dgvData.RowTemplate.Height * 2;
                bm = new Bitmap(this.dgvData.Width, this.dgvData.Height);
                dgvData.DrawToBitmap(bm, new Rectangle(0, 0, this.dgvData.Width, this.dgvData.Height));
                 dgvData.Height = height;
                printPreviewDialog1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        static List<ListItem> monthList = new List<ListItem>
                  {
                   new ListItem("January", "1"),
                   new ListItem("February", "2"),
                   new ListItem("March", "3"),
                   new ListItem("April", "4"),
                   new ListItem("May", "5"),
                   new ListItem("June", "6"),
                   new ListItem("July", "7"),
                   new ListItem("August", "8"),
                   new ListItem("September", "9"),
                   new ListItem("October", "10"),
                   new ListItem("November", "11"),
                   new ListItem("December", "12")
                  };
        static List<ListItem> ExpireList = new List<ListItem>
                  {
                   new ListItem("1 Month", "1"),
                   new ListItem("2 Month", "2"),
                   new ListItem("3 Month", "3"),
                   new ListItem("6 Month", "4"),
                   new ListItem("9 Month", "9"),
                   new ListItem("12 Month", "12"),
                  };


        private void txtStartdate_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                BindReportOutStanding(1);
        }

        private void txtEnddate_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                BindReportOutStanding(1);
        }

      

        //private void dgvData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        //{
        //    try
        //    {
        //        var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
        //        e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
        //                              e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
        //    }
        //    catch (Exception)
        //    {


        //    }
        //}

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
                if (e.ColumnIndex == 0)
                {
                    ////dgvData.BeginEdit(true);
                    ////DataGridViewComboBoxCell ComboBoxCell = new DataGridViewComboBoxCell();
                    ////ComboBoxCell.Items.AddRange("XYZ", "ABC", "PQR");
                    ////ComboBoxCell.Value = "XYZ";
                    ////dgvData[e.ColumnIndex, e.RowIndex] = ComboBoxCell;
                    //dgvData.BeginEdit(true);
                    ////ComboBox comboBox = (ComboBox)dgvData.EditingControl;
                    ////comboBox.DroppedDown = true;
                }
                else
                {
                    int rowIndex = e.RowIndex;
                    string mo = dgvData.Rows[rowIndex].Cells["MO"].Value + "";
                    string so = dgvData.Rows[rowIndex].Cells["SONo"].Value + "";
                    if (rowIndex < 0 || (mo == "" && so == "")) return;
                    PopGridDetail pd = new PopGridDetail();
                    pd.CallForm(so, mo);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSave1_BtnClick()
        {
            try
            {
                List<Entity.MedicalOrder> LSinfo = new List<Entity.MedicalOrder>();
               
                  foreach (DataGridViewRow row in dgvData.Rows)
                    {
                        Entity.MedicalOrder info = new Entity.MedicalOrder();
                        //info.CN = row.Cells["CN"].Value+"";
                        info.VN = row.Cells["MO"].Value + "";
                        info.SONo = row.Cells["SONo"].Value + "";
                        info.MS_Code = row.Cells["MS_Code"].Value + "";
                        info.ListOrder = row.Cells["ListOrder"].Value + "";
                      
                        DataGridViewComboBoxCell cell = row.Cells[0] as DataGridViewComboBoxCell;
                        if (cell != null)
                        {
                            info.ContrackID = cell.Value + "";
                        }
                        LSinfo.Add(info);
                      
                    }
                  int? intStatus = new Business.MedicalOrder().InsertMedicalOrderFollow(LSinfo);
                  if (intStatus>0) DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, Statics.SaveComplete);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);   
            }
        }

        private void dgvData_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvData_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0) dgvData.EndEdit();
            }
            catch (Exception)
            {

            }
        }

        private void dgvData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0) dgvData.BeginEdit(true);
            }
            catch (Exception)
            {

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void checkBoxConnotContact_CheckedChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void checkBoxCanContactYes_CheckedChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void checkBoxCanContactNo_CheckedChanged(object sender, EventArgs e)
        {
            FilterData();
        }
        private void FilterData()
        {
            try
            {
                List<string> ls = new List<string>();

                string ContractResultID = "";
                if (checkBox1.Checked)
                    ls.Add("");
                if (checkBoxConnotContact.Checked)
                    ls.Add("1");
                if (checkBoxCanContactYes.Checked)
                    ls.Add("2");
                if (checkBoxCanContactNo.Checked)
                    ls.Add("3");

                for (int i = 0; i < ls.Count; i++)
                {
                    if(i < ls.Count-1)
                        ContractResultID += string.Format("[ContractResultID] ='{0}' or ", ls[i]);
                    else
                        ContractResultID += string.Format("[ContractResultID] ='{0}'  ", ls[i]);
                }
                if (ContractResultID.Trim() == "") ContractResultID = string.Format("[ContractResultID] ='{0}'  ","99"); ;
                dsData.Tables[0].DefaultView.RowFilter = ContractResultID;
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    DataGridViewComboBoxCell cell = row.Cells[0] as DataGridViewComboBoxCell;
                    if (cell != null)
                    {
                        cell.Value = row.Cells["ContractResultID"].Value + "";
                    }
                }
                lbCount.Text = string.Format("Count {0}", dgvData.RowCount.ToString("###,###,###"));
            }
            catch (Exception)
            {

            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {

            try
            {
                dsData.Tables[0].DefaultView.RowFilter = string.Format("[_RowString] LIKE '%{0}%'", txtFilter.Text);
            }
            catch (Exception)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDGV.Print_DataGridView(dgvData);
            }
            catch (Exception)
            {

            }
        }

        private void radioButtonSummary_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
             //   PrintDGV.Print_DataGridView(dgvData);
                PrintRPT();
            }
            catch (Exception)
            {

            }
        }
        private void PrintRPT()
        {
             try
            {
             FrmPreviewRpt obj = new FrmPreviewRpt();
                DataRow dr;
                obj.PrintType = "";
          

                string strTypeofPay = "";
                
                obj.ForDate =" "+Convert.ToDateTime(txtEnddate.Text).ToString("dd/MM/yyyy");
                obj.BranchName =uBranch1.BranchId==""?"ทุกสาขา": uBranch1.BranchName;

                double dblCredit = 0.00;
                double dblCash = 0.00;
                
                    obj.Today = checkBoxToday.Checked ? "Y" : "N";
                    obj.PRO = radioButtonPro.Checked ? "Y" : "N";


                if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage1"])//your specific tabname
                {
                    obj.FormName = "RptAccPendingNormal";
                    obj.dt = dsData.Tables[0];
                }
                else
                {
                    obj.FormName = "RptAccPendingNormalSummary";
                    obj.dt = dsData.Tables[1];
                }
                 
             

                obj.MaximizeBox = true;
                obj.TopMost = true;
                obj.Show();
            }
            catch (Exception)
            {

            }
        }

        private void dgvData_RowPostPaint_1(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
                e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                      e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
            catch (Exception)
            {


            }
        }

        private void dgvDataSum_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
                e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                      e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
            catch (Exception)
            {


            }
        }

        private void checkBoxToday_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                checkBoxSumAll.Checked = !checkBoxToday.Checked;
            }
            catch (Exception)
            {


            }
        }

        private void checkBoxSumAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                checkBoxToday.Checked = !checkBoxSumAll.Checked;
            }
            catch (Exception)
            {


            }
        }
       

      
      
    
    }
}
