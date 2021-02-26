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
using ClosedXML.Excel;
using AryuwatSystem.Forms.PrintGridView;
using System.Globalization; 
namespace AryuwatSystem.Forms
{
    public partial class FrmReportSaleList : DockContent
    {
        bool bind = true;
        private string MedStatus_Code = "";
        private string MedStatus_CodeNew = "";
        private string MedStatus_CodePending = "";
        private string MedStatus_CodeClosed = "";
        DataTable dtAllTotal = new DataTable();
        DataTable dtReport = new DataTable();
        Dictionary<string, string> dicReportRang = new Dictionary<string, string>();
        Dictionary<string, string> dicReporQueryType = new Dictionary<string, string>();
        public string QueryType = "";
        bool excVat = false;
        DataSet dsAll;
        string titlereport = "";
        //DataSet dsData;
        public FrmReportSaleList()
        {
            InitializeComponent();
       
        }
     
        private void GetReportName()
        {
            try
            {
                Entity.Report info = new Entity.Report() { PageNumber = 1 };
                    info.QueryType = "GetReportNameCS";

                    info.StartDate = DateTime.Now.ToString();
                    info.EndDate = DateTime.Now.ToString();
                DataSet ds = new Business.ReportAccount().SelectReportAccount(info);
                comboBoxReport.DataSource =dtReport= ds.Tables[0];
                comboBoxReport.DisplayMember = "Rpt_Name";
                comboBoxReport.ValueMember = "Rpt_Code";
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    if (!dicReportRang.ContainsKey(item["Rpt_Code"] + ""))dicReportRang.Add(item["Rpt_Code"] + "",item["DateRang"] + "");
                    if (!dicReporQueryType.ContainsKey(item["Rpt_Code"] + "")) dicReporQueryType.Add(item["Rpt_Code"] + "", item["QueryType"] + "");
                }
                QueryType = dicReporQueryType[comboBoxReport.SelectedValue.ToString()];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void SetColumns()
        {
            try
            {
                DerUtility.SetPropertyDgv(dgvData);

                //dgvData.Columns.Add("MedStatus_Code", "MedStatus_Code");
                //dgvData.Columns.Add("MedStatus_Name", "สถานะ");
                ////var columnSpec = new DataGridViewColumn
                ////    {

                ////        CellType = typeof(DateTime), // This is of type System.Type
                ////        ColumnName = "UpdateDate" ,
                ////        Caption="วันที่"
                ////    };
                ////dgvData.Columns.Add(columnSpec);
                //dgvData.Columns.Add("UpdateDate", "วันที่");
                //dgvData.Columns.Add("SO", "SO");
                //dgvData.Columns.Add("VN", "MO");
                //dgvData.Columns.Add("CN", "CN");
                //dgvData.Columns.Add("FullNameThai", "ชื่อ-นามสกุล");
                //dgvData.Columns.Add("Mobile", "Mobile (มือถือ)");
                //dgvData.Columns.Add("SalePrice", "จำนวนเงิน");


                //dgvData.Columns["VN"].Width = 100;
                //dgvData.Columns["SO"].Width = 100;
                //dgvData.Columns["CN"].Width = 100;
                //dgvData.Columns["FullNameThai"].Width = 150;
                //dgvData.Columns["Mobile"].Width = 200;
                //dgvData.Columns["UpdateDate"].Width = 80;
                //dgvData.Columns["MedStatus_Code"].Visible = false;
                //dgvData.Columns["MedStatus_Name"].Width = 80;
                //dgvData.Columns["SalePrice"].Width = 80;
                //dgvData.Columns["SalePrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

               // for (int i = 0; i < dgvData.Columns.Count - 1; i++)
               // {
               //     dgvData.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
               // }
               //// dgvData.Columns[dgvData.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

               // for (int i = 0; i < dgvData.Columns.Count; i++)
               // {
               //     int colw = dgvData.Columns[i].Width;
               //     dgvData.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
               //     dgvData.Columns[i].Width = colw;
               // }
                float varFontSize = Single.Parse("9");
                for (int i = 0; i < dgvData.Columns.Count; i++)
                {
                    if (dgvData.Columns[i].Name.ToLower() != "ms_name" && dgvData.Columns[i].Name.ToLower() != "ms_code")
                        dgvData.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                }
                dgvData.Columns[dgvData.Columns.Count - 1].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont.Name, varFontSize, FontStyle.Bold);
                dgvData.Rows[dgvData.RowCount - 1].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont.Name, varFontSize, FontStyle.Bold);
                dgvData.Rows[dgvData.RowCount - 1].Height = dgvData.Rows[dgvData.RowCount - 1].Height+2;
                //if (dgvData.Columns.Contains("SalePrice"))
                //    dgvData.Columns["SalePrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //if (dgvData.Columns.Contains("Amount"))
                //    dgvData.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //if (dgvData.Columns.Contains("AmountOfUse"))
                //    dgvData.Columns["AmountOfUse"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //if (dgvData.Columns.Contains("Balances"))
                //    dgvData.Columns["Balances"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //if (dgvData.Columns.Contains("MO"))
                //    dgvData.Columns["MO"].Visible = false;
                //if (dgvData.Columns.Contains("SOno"))
                //    dgvData.Columns["SOno"].Visible = false;
                
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
                    BindReport(1);
                    
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
  
        public void BindReport(int _pIntseq)
        {
            try
            {
                lbCount.Text = "";
               
               
                DerUtility.MouseOn(this);
                dgvData.DataSource = null;
                //pIntseq = _pIntseq;
                Entity.Report info = new Entity.Report() { PageNumber = _pIntseq };
             
                // if (radioButtonSellVatDay.Checked)
                //{
                //    info.QueryType = "ReportSellVatDay";
                //}
                //else if (radioButtonSellByProductAll.Checked)
                //    info.QueryType = "ReportSellByProductAll";
                //else if(radioButtonSellByProductVat.Checked)
                //     info.QueryType = "ReportSellByProductVat";
                //else if (radioButtonSellByProductNoVat.Checked)
                info.QueryType = QueryType;

                //DateTime time1 = DateTime.ParseExact(txtStartdate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                //DateTime StartDate =Convert.ToDateTime(txtStartdate.Text).ToString("yyyy-MM-dd");// DateTime.ParseExact("2017/03/17", "yyyy/MM/dd", CultureInfo.InvariantCulture); //Convert.ToDateTime(txtStartdate.Text);
                //DateTime EndDate = Convert.ToDateTime(txtEnddate.Text).ToString("yyyy-MM-dd"); //DateTime.ParseExact("2017/03/17", "yyyy/MM/dd", CultureInfo.InvariantCulture); //Convert.ToDateTime(txtEnddate.Text);
                info.StartDate =AryuwatSystem.DerClass.DerUtility.ToFormatDateyyyyMMdd(txtStartdate.Text);// Convert.ToDateTime(txtStartdate.Text).ToString("yyyy-MM-dd");// StartDate.ToString();
                info.EndDate = AryuwatSystem.DerClass.DerUtility.ToFormatDateyyyyMMdd(txtEnddate.Text); //Convert.ToDateTime(txtStartdate.Text).ToString("yyyy-MM-dd");// EndDate.ToString();
                info.BranchId = uBranch1.BranchId;
                 dsAll = new Business.ReportAccount().SelectReportAccount(info);
                dtAllTotal = dsAll.Tables[0];
                long lngTotalPage = 0;
                long lngTotalRecord = 0;
                if (dtAllTotal.Rows.Count <= 0)
                {
                    //ngbMain.CurrentPage = 0;
                    //ngbMain.TotalPage = 0;
                    //ngbMain.TotalRecord = 0;
                    //ngbMain.Updates();
                    DerUtility.MouseOff(this);
                    //Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "ไม่พบข้อมูลในระบบ");
                    return;
                }
                DataColumn dcRowString = dtAllTotal.Columns.Add("_RowString", typeof(string));
                foreach (DataRow dataRow in dtAllTotal.Rows)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < dtAllTotal.Columns.Count - 1; i++)
                    {
                        sb.Append(dataRow[i].ToString());
                        sb.Append("\t");
                    }
                    dataRow[dcRowString] = sb.ToString();
                }

                DataRow dr = dtAllTotal.NewRow();
                //dgvData[dgvData.Columns["NetAmount"].Index, dgvData.RowCount].Value = sum.ToString("###,###,###.##");
                //dr["CustomerNameEng"] = "Total";
                if (dtAllTotal.Columns.Contains("_RowString"))
                    dr["_RowString"] = "Total";

                dtAllTotal.Rows.Add(dr);
                excVat = false;
                if (QueryType == "RptAccReceiptByProductAllDetail_SaleCom")
                {
                    excVat = true;
                    dr = dtAllTotal.NewRow();
                    //dgvData[dgvData.Columns["NetAmount"].Index, dgvData.RowCount].Value = sum.ToString("###,###,###.##");
                    //dr["CustomerNameEng"] = "Total";
                    if (dtAllTotal.Columns.Contains("_RowString"))
                        dr["_RowString"] = "Total NoVat";

                    dtAllTotal.Rows.Add(dr);
                }
                else if (QueryType == "RptPayInMoneyNoDate")
                    lbTotal.Visible = false;
                else
                    lbTotal.Visible = true;

                dgvData.DataSource = dtAllTotal;

               

                //dgvData.Columns["MS_CAPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                //dgvData.Columns["MS_Type"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                //dgvData.Columns["MS_Number_C"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                //dgvData.Columns["FeeRate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                //dgvData.Columns["FeeRate2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                //dgvData.Columns["MaxDiscount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                dgvData.Columns["_RowString"].Visible = false;

                //dgvData.Columns[0].Width = 80;
       
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
                DerUtility.MouseOff(this);
                //  RefreshText();
                lbCount.Text = string.Format("Count {0}", dgvData.RowCount.ToString("###,###,###"));
         
                for (int i = 0; i < dgvData.Columns.Count; i++)
                {
                    if (dgvData.Columns[i].Name.ToLower().Contains("จำนวน") || dgvData.Columns[i].Name.ToLower().Contains("ราคา") || dgvData.Columns[i].Name.ToLower().Contains("เฉลี่ย") || dgvData.Columns[i].Name.ToLower().Contains("quan") || dgvData.Columns[i].Name.ToLower().Contains("ค่า")
                        || dgvData.Columns[i].Name.ToLower().Contains("เงิน") || dgvData.Columns[i].Name.ToLower().Contains("จำนวน") || dgvData.Columns[i].Name.ToLower().Contains("ยอด")
                        || dgvData.Columns[i].Name.ToLower().Contains("จ่าย") || dgvData.Columns[i].Name.ToLower().Contains("ลด") || dgvData.Columns[i].Name.ToLower().Contains("pay") || dgvData.Columns[i].Name.ToLower().Contains("bath") || dgvData.Columns[i].Name.ToLower().Contains("fee") || dgvData.Columns[i].Name.ToLower().Contains("price") 
                                || dgvData.Columns[i].Name.ToLower().Contains("ราคา") || dgvData.Columns[i].Name.ToLower().Contains("cash")|| dgvData.Columns[i].Name.ToLower().Contains("รับ") || dgvData.Columns[i].Name.ToLower().Contains("credit") || dgvData.Columns[i].Name.ToLower().Contains("net") || dgvData.Columns[i].Name.ToLower().Contains("total")
                                || dgvData.Columns[i].Name.ToLower().Contains("หัก") || dgvData.Columns[i].Name.ToLower().Contains("ค่า") || dgvData.Columns[i].Name.ToLower().Contains("amount") || dgvData.Columns[i].Name.ToLower().Contains("มูลค่า") || dgvData.Columns[i].Name.ToLower().Contains("เงิน") || dgvData.Columns[i].Name.ToLower().Contains("ยอด")
                                || dgvData.Columns[i].Name.ToLower().Contains("ชำระ") || dgvData.Columns[i].Name.ToLower().Contains("จำนวน")
                        )
                    {
                        dgvData.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgvData.Columns[i].DefaultCellStyle.Format = "N2";
                    }
                }
                SumTotal();
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
    
        private void FrmReportSaleList_Load(object sender, EventArgs e)
        {

            try
            {
                //dgvData.AutoGenerateColumns = true;
                //setForMonth();
                setForYears();
                GetReportName();
                txtEnddate.Text =DateTime.Now.ToString("dd/MM/yyyy");
                txtStartdate.Text =DateTime.Now.ToString("dd/MM/yyyy");
                //BindSurgicalFeeType_Position();
                var grouper = this.dataGridViewGrouperControl1.Grouper;
                //grouper.SetGroupOn("AString");
            }
            catch (Exception ex)
            {
               
            }
        }
        Dictionary<string, int> dicMonth = new Dictionary<string, int>();
        private void setForMonth()
        {
            try
            {
                dicMonth = new Dictionary<string, int>();
                dicMonth.Add("January(1)", 1);
                dicMonth.Add("February(2)", 2);
                dicMonth.Add("March(3)", 3);
                dicMonth.Add("April(4)", 4);
                dicMonth.Add("May(5)", 5);
                dicMonth.Add("June(6)", 6);
                dicMonth.Add("July(7)", 7);
                dicMonth.Add("August(8)", 8);
                dicMonth.Add("September(9)", 9);
                dicMonth.Add("October(10)", 10);
                dicMonth.Add("November(11)", 11);
                dicMonth.Add("December(12)", 12);
                string thisy = string.Format("This Year({0})", DateTime.Now.Year + "");
                dicMonth.Add(thisy, 0);
                //comboBoxPeriod.Items.Clear();
                //foreach (KeyValuePair<string, int> entry in dicMonth)
                //{
                //    comboBoxPeriod.Items.Add(entry.Key);
                //}
                //comboBoxPeriod.Visible = true;
                //labelMonth.Visible = true;
                ////labelMonth.Text = "Select Month";
                ////comboBoxPeriod.DataSource = nu;
                ////comboBoxPeriod.Items.AddRange(dicMonth);
                //comboBoxPeriod.SelectedIndex = DateTime.Now.Month - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void setForYears()
        {
            try
            {
                int year = 0;
                int yearNow = DateTime.Now.Year;
                if (yearNow < 2500)
                    year = 2015;
                else
                    year = 2558;
                comboBoxYears.Items.Clear();
                for (int i = year; i <= yearNow; i++)
                {
                    comboBoxYears.Items.Add(i);
                }
                comboBoxYears.SelectedIndex = comboBoxYears.Items.Count - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dgvData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

                    if (dsAll.Tables.Count > 5)
                    {
                        // dt = city.GetAllCity();//your datatable
                        using (ClosedXML.Excel.XLWorkbook wb = new ClosedXML.Excel.XLWorkbook())
                        {

                            //wb.Worksheets.Add(dsData.Tables[0]);
                            //wb.SaveAs(saveFileDialog1.FileName);

                            // titlereport = string.Format("{0}", cboSurgicalFeeTyp.Text);
                            ExportFile exp = new ExportFile();
                            int c=0;
                            foreach (DataTable item in dsAll.Tables)
                            {
                                if (item.Columns.Contains("sheetname"))
                                {
                                    wb.Worksheets.Add(item, item.Rows[0]["sheetname"] + "");//sheetname=ชื่อ table
                                }
                            }
                            wb.SaveAs(saveFileDialog1.FileName);

                            if (File.Exists(saveFileDialog1.FileName))
                            {
                                Process.Start(saveFileDialog1.FileName);
                            }
                        }
                        return;
                    }
                   
                    
                    // dt = city.GetAllCity();//your datatable
                    using (ClosedXML.Excel.XLWorkbook wb = new ClosedXML.Excel.XLWorkbook())
                    {
                       
                        //wb.Worksheets.Add(dsData.Tables[0]);
                        //wb.SaveAs(saveFileDialog1.FileName);
                        
                       // titlereport = string.Format("{0}", cboSurgicalFeeTyp.Text);
                        ExportFile exp = new ExportFile();
                        wb.Worksheets.Add(exp.GetDataTableFromDGV(dgvData, "Result"));
                        //ExportDataWithClosedXml_Method(dtAllTotal, "Result", titlereport);
                        wb.SaveAs(saveFileDialog1.FileName);

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

        public void ExportDataWithClosedXml_Method(DataTable table, string tabName, string ReportTitle)
        {
            var workbook = new XLWorkbook();
            var ws = workbook.Worksheets.Add(table, tabName);
            int row = 2 + table.Rows.Count;
            int col = table.Columns.Count;
            var redRow = ws.Row(1);
            //redRow.Style.Fill.BackgroundColor = XLColor.Red;
            redRow.InsertRowsAbove(1);
            ws.Cell(1, 1).Value = ReportTitle;
            ws.Cell(1, 1).Style.Font.Bold = true;
            ws.Cell(row, col).Style.Font.Bold = true;
         
            ws.Range(2, 2, row, col).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right; //ชิดขวา
            ws.Range(2, col, row, col).Style.Font.Bold = true;// ตัวหนาผลรวมคอลัมสุดท้าย
            ws.Range(row, 1, row, col).Style.Font.Bold = true;// ตัวหนาผลรวมแถวสุดท้าย
            ws.Table(0).ShowAutoFilter = false;
            //ws.Row(2).Style.Fill.BackgroundColor = XLColor.Red;
            ws.Range(2, 1, 2, col).Style.Fill.BackgroundColor = XLColor.Green;
            ws.Range(2, 1, 2, col).Style.Font.Bold = true;
            //ws.Range(3, 1, row, col).Style.Font.Italic = true;

            workbook.SaveAs(saveFileDialog1.FileName);

            //HttpContext.Current.Response.Clear();
            //using (MemoryStream memoryStream = new MemoryStream())
            //{
            //    workbook.SaveAs(memoryStream);
            //    memoryStream.WriteTo(HttpContext.Current.Response.OutputStream);
            //    memoryStream.Close();
            //}
            //if (fileType == "xlsx")
            //{
            //    HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //    HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=\"Samplefile.xlsx\"");
            //}
            //else
            //{
            //    HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            //    HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=\"Samplefile.xls\"");
            //}
            //HttpContext.Current.Response.End();
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

        private void FrmReportSaleList_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics.frmReportSaleList = null;
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
        bool IsTheSameCellValue(int column, int row)
        {
            DataGridViewCell cell1 = dgvData[column, row];
            DataGridViewCell cell2 = dgvData[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }

        private void dgvData_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
          
        }

  

     

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

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
                int rowIndex = e.RowIndex;
                string mo = dgvData.Columns.Contains("MO")? dgvData.Rows[rowIndex].Cells["MO"].Value + "":"";
                string so = dgvData.Rows[rowIndex].Cells["SO"].Value + "";
                if (rowIndex < 0 || (mo == "" && so == "")) return;
                PopGridDetail pd = new PopGridDetail();
                pd.CallForm(so, mo);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtStartdate_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                BindReport(1);
        }

        private void txtEnddate_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                BindReport(1);
        }

        private void cboSurgicalFeeTyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bind)
                BindReport(1);
            else
            {
                bind = true;
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
                
         try
            {
                dtAllTotal.DefaultView.RowFilter = string.Format("[_RowString] LIKE '%{0}%' or [_RowString]='Total' or [_RowString]='Total NoVat'", txtFilter.Text);
                SumTotal();
            }
            catch (Exception)
            {
             
            }
        }
        public void SumTotal()
        { 
          try
            {
              //  dtAllTotal.DefaultView.RowFilter = string.Format("[_RowString] LIKE '%{0}%'", txtFilter.Text);
                //object sumObject;
                //sumObject = dtAllTotal.Compute("Sum(PayThisTime)", "");
                if (dgvData.RowCount <= 1)
                {
                    lbTotal.Text = "";
                    //dgvData.Rows.Clear();
                    return;
                }
                double sum = 0;
                double sumReciept = 0;
                List<string> lsSO = new List<string>();
                string consult2 = "";
                foreach (DataRow dr in dtAllTotal.DefaultView.ToTable().Rows)
                {
                    //if (!lsSO.Contains(dr["SO"] + ""))
                    //{
                        //lsSO.Add(dr["SO"] + "");
                        consult2 = dr["Consult2"] + "";
                        if ((dr["จำนวน"] + "").ToLower().Contains("total") || (dr["จำนวน"] + "").ToLower().Contains("exc")) 
                            continue;

                        if (consult2 != "")
                        {
                            sum += dr["ยอดรับเงิน"] + "" == "" ? 0 : Convert.ToDouble(dr["ยอดรับเงิน"] + "") / 2;
                        }
                        else
                        {
                            sum += dr["ยอดรับเงิน"] + "" == "" ? 0 : Convert.ToDouble(dr["ยอดรับเงิน"] + "");
                        }
                        sumReciept += dr["ยอดรับเงิน"] + "" == "" ? 0 : Convert.ToDouble(dr["ยอดรับเงิน"] + "");
                    //}

                }
                lbTotal.Text = string.Format("Total Consult : {0} / Total Reciept : {1}   ", sum.ToString("###,###,###,###"), sumReciept.ToString("###,###,###,###"));
               
            }
            catch (Exception)
            {
                lbTotal.Text = "";
            }
          DataGridViewUtil.LoopSumByColumn(dgvData, excVat);
        }
        private void radioButtonBalance_Click(object sender, EventArgs e)
        {
            //labelStart.Enabled = false;
            //labelEnd.Enabled = false;
            //txtStartdate.Enabled = false;
            //txtEnddate.Enabled = false;
            //titlereport = radioButtonSellByProductVat.Text;
            BindReport(1);
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
           
               
        }

        private void radioButtonRecieptDay_Click_1(object sender, EventArgs e)
        {
            //labelStart.Enabled = true;
            //labelEnd.Enabled = true;
            //txtStartdate.Enabled = true;
            //txtEnddate.Enabled = true;
            //titlereport = radioButtonSellVatDay.Text;
            //txtEnddate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            //txtStartdate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            BindReport(1);
        }

    

        private void dgvData_CellFormatting_2(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value + "" == "0.00") e.Value = "";
        }

        private void radioSumRecieptAll_Click(object sender, EventArgs e)
        {
            //labelStart.Enabled = true;
            //labelEnd.Enabled = true;
            //txtStartdate.Enabled = true;
            //txtEnddate.Enabled = true;
            //titlereport = radioButtonSellByProductAll.Text;

            txtStartdate.Text = DateTimeUtil.FirstDayOfMonth(Convert.ToInt16(DateTime.Now.Year), 1).ToString("yyyy/MM/dd");
            txtEnddate.Text = DateTimeUtil.LastDayOfMonth(Convert.ToInt16(DateTime.Now.Year), 12).ToString("yyyy/MM/dd");
        }

        private void comboBoxReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(!dicReportRang.ContainsKey(comboBoxReport.SelectedValue.ToString()))return;
                //if (dicReportRang[comboBoxReport.SelectedValue.ToString()].ToUpper() == "Y")//year
                //{
                //    txtStartdate.Text = DateTimeUtil.FirstDayOfMonth(Convert.ToInt16(DateTime.Now.Year), 1).ToString("yyyy/MM/dd");
                //    txtEnddate.Text = DateTimeUtil.LastDayOfMonth(Convert.ToInt16(DateTime.Now.Year), 12).ToString("yyyy/MM/dd");
                //    txtStartdate.ReadOnly = true;
                //    txtEnddate.ReadOnly = true;
                //}
                //else
                //{
                //    txtStartdate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                //    txtEnddate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                //    txtStartdate.ReadOnly = false;
                //    txtEnddate.ReadOnly = false;
                //}
             QueryType=  dicReporQueryType[comboBoxReport.SelectedValue.ToString()];
                BindReport(1);
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
            if (QueryType == "RptAccReceiptByProductAllDetail_SaleCom")
            {
                PrintDGV.Print_DataGridViewA3(dgvData);
                return;
            }

            try
            {
                FrmPreviewRpt obj = new FrmPreviewRpt();
                DataRow dr;

                //DataTable dtTmp;
                //dtSumOfTreatPay
                //string sql = string.Format("Vat='{0}'", "Y");
                //if (dtSumOfTreat.Select(sql).Any())
                //    dtTmp = dtSumOfTreat.Select(sql).CopyToDataTable();
                //else
                //    return;

                string strTypeofPay = "";

                obj.PrintType = "";
                double dblCredit = 0.00;
                double dblCash = 0.00;
                string strBankName = "";


                if (QueryType == "RptAccReceiptByProductAllDetail_SaleCheck")
                {
                    if (txtStartdate.Text == txtEnddate.Text)
                    {
                        obj.PrintType = string.Format(" วันที่ {0} - {1}", txtStartdate.Text, txtEnddate.Text);
                        obj.ForDate = string.Format(" วันที่ {0} - {1} {2}", txtStartdate.Text, txtEnddate.Text, uBranch1.BranchId.Length < 2 ? "" : uBranch1.BranchName);
                    }
                    else
                    {
                        obj.PrintType = string.Format(" วันที่ {0} - {1}", txtStartdate.Text, txtEnddate.Text);
                        obj.ForDate = string.Format(" วันที่ {0} - {1} {2}", txtStartdate.Text, txtEnddate.Text, uBranch1.BranchId.Length < 2 ? "" : uBranch1.BranchName);
                    }
                }
                else
                {
                    if (txtStartdate.Text == txtEnddate.Text)
                    {
                        obj.PrintType = string.Format(" วันที่ {0}", txtStartdate.Text, txtEnddate.Text);
                        obj.ForDate = string.Format(" วันที่ {0} {1}", txtStartdate.Text, uBranch1.BranchId.Length < 2 ? "" : uBranch1.BranchName);
                    }
                    else
                    {
                        obj.PrintType = string.Format(" วันที่ {0} - {1}", txtStartdate.Text, txtEnddate.Text);
                        obj.ForDate = string.Format(" วันที่ {0} - {1} {2}", txtStartdate.Text, txtEnddate.Text, uBranch1.BranchId.Length < 2 ? "" : uBranch1.BranchName);
                    }
                }



                obj.FormName = QueryType;
                DataTable dx = dtAllTotal.Copy();
                DataRow drL = dx.Rows[dtAllTotal.Rows.Count - 1];
                drL.Delete();
                obj.dt = dx;
                obj.MaximizeBox = true;
                obj.TopMost = true;
                obj.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
      
      
    
    }
}
