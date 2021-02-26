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
using PresentationControls; 
namespace AryuwatSystem.Forms
{
    public partial class FrmReportAE_Fee_Year : DockContent
    {
        bool bind = true;
        private string MedStatus_Code = "";
        private string MedStatus_CodeNew = "";
        private string MedStatus_CodePending = "";
        private string MedStatus_CodeClosed = "";
        Dictionary<string, string> dicPosition = new Dictionary<string, string>();
        DataTable dtAllTotal = new DataTable();
        DataTable dtSurgicalFee_Position = new DataTable();
        DataTable dtSubSurgicalFee =  new DataTable();
        Dictionary<string, string> dicSubSection = new Dictionary<string, string>();
        DataSet dsData;
        public FrmReportAE_Fee_Year()
        {
            InitializeComponent();
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

                if (dgvData.RowCount <= 0) return;
                float varFontSize = Single.Parse("9");
                for (int i = 0; i < dgvData.Columns.Count; i++)
                {
                    if (dgvData.Columns[i].Name.ToLower() != "ms_name" && dgvData.Columns[i].Name.ToLower() != "ms_code" && dgvData.Columns[i].Name.ToLower() != "พนักงาน")
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
                    BindReportResult(1);
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

        public void BindReportResult(int pIntseq)
        {
            try
            {
                DerUtility.MouseOn(this);

                var info = new Entity.SurgeryFee() { PageNumber = pIntseq };


             
                //info.MedStatus_CodeNew = MedStatus_CodeNew;
                //info.MedStatus_CodePending = MedStatus_CodePending;
                //info.MedStatus_CodeClosed = MedStatus_CodeClosed;
                //info.BirthMonth = comboBoxPeriod.Text;
                string Sale_cashier = "";
                
                info.QueryType = "SELECT_AESTHETIC_ALL_CHECK_YEAR";

                int m = 0;
             
                txtStartdate.Text = DateTimeUtil.FirstDayOfMonth(Convert.ToInt16(comboBoxYears.Text), 1).ToString("yyyy/MM/dd");
                txtEnddate.Text = DateTimeUtil.LastDayOfMonth(Convert.ToInt16(comboBoxYears.Text), 12).ToString("yyyy/MM/dd");

                if (!string.IsNullOrEmpty(txtStartdate.Text.Trim()))
                {
                    info.StartDate = txtStartdate.Text;
                }
                if (!string.IsNullOrEmpty(txtEnddate.Text.Trim()))
                {
                    info.EndDate = txtEnddate.Text;
                }
                //info.Position_Type = cboSurgicalFeeTyp.Text ;
                info.BranchId = uBranch1.BranchId;
                if (cboSurgicalFeeTyp.Text == "ALL")
                {
                    foreach (var item in cboSurgicalFeeTyp.Items)
                    {
                        info.Position_Type = info.Position_Type + "'" + item.ToString() + "',";
                    }
                    info.Position_Type += "''";
                }
                else
                {
                    info.Position_Type = "'" + cboSurgicalFeeTyp.Text + "'";
                }


                if (!string.IsNullOrEmpty(txtStartdate.Text.Trim()))
                {
                    info.StartDate = "'" + txtStartdate.Text + "'";
                }
                if (!string.IsNullOrEmpty(txtEnddate.Text.Trim()))
                {
                    info.EndDate = "'" + Convert.ToDateTime(txtEnddate.Text).ToString("yyyy/MM/dd") + "'";
                }
                //   info.whereDate = string.Format(" and (Sur.DateUpdate between '{0}' and '{1}' )", info.StartDate, info.EndDate);
                //if (!dtpDateStart.Checked && !dtpDateEnd.Checked)
                //{
                //    info.whereDate = " 1=1 ";
                //}
                info.EN = "";
                string[] positionx;
                string wherein = "";
                info.Position_ID = "";
                if (!string.IsNullOrEmpty(cboPosition.Text))
                {
                    positionx = cboPosition.Text.Split(',');
                    if (positionx.Any())
                    {
                        foreach (string item in positionx)
                        {
                            string key = dicPosition.FirstOrDefault(x => x.Value == item.Trim().Replace(",", "")).Key;
                            wherein += string.Format("'{0}',", key);
                        }


                        //info.Position_ID = wherein.Remove(wherein.Length-1);
                        info.Position_ID = string.Format(" and MStuff.Position_ID in({0}) ", wherein.Remove(wherein.Length - 1));
                    }
                }

                if (!string.IsNullOrEmpty(SubSection.Text))
                {
                    info.SubSurgical = string.Format(" and MS_Section in('{0}') ", dicSubSection[SubSection.Text]);
                }
                else info.SubSurgical = "";
               // info.SubSurgical = string.Format(" and MS_Section in({0}) ", dicSubSection[SubSection.Text]);
                //info.Position_ID.Replace("Select All","");
                


                dsData = new Business.StuffCommission().SelectSurgeryFee(info);


                //foreach (DataRow item in dsData.Tables[0].Rows)
                //{
                //        string SubSurgical = dicSubSection[SubSection.Text];
                //        if (!SubSurgical.Contains((item["MS_Section"] + "").Trim()))
                //        {
                //            dsData.Tables[0].Rows.Remove(item);
                //        }
                // }


               
                dgvData.DataSource = null;
                dgvData.DataSource = dsData.Tables[0];

                SetColumns();
                
                lbCount.Text = string.Format("{0} Item", (dgvData.RowCount-1).ToString());
                DerUtility.MouseOff(this);
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
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
    
        private void FrmReportAE_Fee_Year_Load(object sender, EventArgs e)
        {

            try
            {
                //dgvData.AutoGenerateColumns = true;
                //setForMonth();
                setForYears();
                txtEnddate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txtStartdate.Text = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");
                BindSurgicalFeeType_Position();
            }
            catch (Exception ex)
            {
               
            }
        }
        Dictionary<string, int> dicMonth = new Dictionary<string, int>();
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


                   // dt = city.GetAllCity();//your datatable
                    using (ClosedXML.Excel.XLWorkbook wb = new ClosedXML.Excel.XLWorkbook())
                    {
                       
                        //wb.Worksheets.Add(dsData.Tables[0]);
                        //wb.SaveAs(saveFileDialog1.FileName);
                        string titlereport = "";
                        titlereport = string.Format("Summary of {0}", "Fee");
                
                            ExportDataWithClosedXml_Method(dsData.Tables[0], "Result", titlereport);


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

        private void FrmReportAE_Fee_Year_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics.frmReportAE_Fee_Year = null;
        }
      
        private void dgvData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

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

        private void dgvData_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex == 0)
                    return;
                //if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex) && e.ColumnIndex < 8)
                //{
                //    e.Value = "";
                //    e.FormattingApplied = true;
                //}
                //if (e.RowIndex > 0 && e.ColumnIndex == 0)
                //{
                //    if (dgvData["SONo", e.RowIndex - 1].Value == e.Value)
                //        e.Value = "";
                //    else if (e.RowIndex < dgvData.Rows.Count - 1)
                //        dgvData.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                //}
            }
            catch (Exception ex)
            {


            }
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
                int rowIndex = e.RowIndex;
                string mo = dgvData.Rows[rowIndex].Cells["MO"].Value + "";
                string so = dgvData.Rows[rowIndex].Cells["SONo"].Value + "";
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
                BindReportResult(1);
        }

        private void txtEnddate_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                BindReportResult(1);
        }

        private void cboSurgicalFeeTyp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void BindPosition(string typ)
        {
            try
            {
                DataView view = new DataView(dtSurgicalFee_Position);
                //DataTable distinctValues = view.ToTable(true, "Position_Type", "Column2");
                string @where = string.Format("Position_Type='{0}'", typ);
                DataTable distinctValues = new DataTable();
                cboPosition.Items.Clear();

                //cboPosition.Items.Add("Select All");
                dicPosition = new Dictionary<string, string>();
                if (typ == "ALL")
                {
                    foreach (DataRow item in dtSurgicalFee_Position.Rows)
                    {
                        if (!dicPosition.ContainsKey(item["Position_ID"] + ""))
                        {
                            dicPosition.Add(item["Position_ID"] + "", "(" + item["Position_Type"] + ")" + item["Position_Name"].ToString().Replace(",", ""));

                            cboPosition.Items.Add("(" + item["Position_Type"] + ")" + item["Position_Name"]);
                        }
                    }
                }
                else
                {
                    if (dtSurgicalFee_Position.Select(@where).Any())
                    {
                        distinctValues = dtSurgicalFee_Position.Select(@where).CopyToDataTable();
                        foreach (DataRow item in distinctValues.Rows)
                        {
                            if (!dicPosition.ContainsKey(item["Position_ID"] + ""))
                            {
                                dicPosition.Add(item["Position_ID"] + "", item["Position_Name"].ToString().Replace(",", ""));

                                cboPosition.Items.Add(item["Position_Name"]);
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
        private void BindSubSurgicalFee(string typ)
        {
            try
            {
                DataView view = new DataView(dtSubSurgicalFee);
                //DataTable distinctValues = view.ToTable(true, "SubSurgicalFee");
                string @where = string.Format("SurgicalFeeTyp='{0}'", typ);
                DataTable distinctValues = new DataTable();
                SubSection.Items.Clear();
                dicSubSection = new Dictionary<string, string>();
                if (dtSubSurgicalFee.Select(@where).Any())
                {
                    distinctValues = dtSubSurgicalFee.Select(@where).CopyToDataTable();
                    foreach (DataRow item in distinctValues.Rows)
                    {
                        if (!dicSubSection.ContainsKey(item["SubSurgicalFee"] + ""))
                        {
                            dicSubSection.Add(item["SubSurgicalFee"] + "", item["Section_Code"] + "");
                            SubSection.Items.Add(item["SubSurgicalFee"]);
                        }
                        else
                        {
                            dicSubSection[item["SubSurgicalFee"] + ""] += "," + item["Section_Code"];
                        }
                    }
                    SubSection.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void BindSurgicalFeeType_Position()
        {
            try
            {
                DataSet dsComRate = new Business.StuffCommission().SurgicalFeeType_Position();

                if (dsComRate.Tables.Count > 0)
                {
                    dtSurgicalFee_Position = dsComRate.Tables[0];
                    dtSubSurgicalFee = dsComRate.Tables[1];
                    //DataRow dr= dtSurgicalFee_Position.NewRow();
                    //dr["Position_Type"] = "Total";
                    //dtSurgicalFee_Position.Rows.Add(dr);
                    DataView view = new DataView(dtSurgicalFee_Position);
                    //DataTable distinctValues = view.ToTable(true, "Position_Type", "Column2");
                    DataTable distinctValues = view.ToTable(true, "Position_Type");
                    DataRow dr = distinctValues.NewRow();
                    dr["Position_Type"] = "ALL";
                    distinctValues.Rows.Add(dr);
                    cboPosition.Items.Clear();

                    foreach (DataRow item in distinctValues.Rows)
                    {
                        cboSurgicalFeeTyp.Items.Add(item["Position_Type"]);
                    }
                    cboSurgicalFeeTyp.SelectedIndex = 0;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void cboSurgicalFeeTyp_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            BindPosition(cboSurgicalFeeTyp.Text);
            BindSubSurgicalFee(cboSurgicalFeeTyp.Text);
        }

        private void cboPosition_Click(object sender, EventArgs e)
        {
            
            //if (cboPosition.CheckBoxItems["Select All"].Checked)
            //    CheckedAll(cboPosition);
            //else
            //    UncheckedAll(cboPosition);


        }



        public void CheckedAll(CheckBoxComboBox objCombo)
        {
            try
            {



                for (int i = 0; i < objCombo.CheckBoxItems.Count; i++)
                {
                    if (i != objCombo.SelectedIndex)
                    {
                        objCombo.CheckBoxItems[i].CheckState = CheckState.Checked;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UncheckedAll(CheckBoxComboBox objCombo)
        {
            try
            {
                for (int i = 0; i < objCombo.CheckBoxItems.Count; i++)
                {
                    if (i != objCombo.SelectedIndex)
                    {
                        objCombo.CheckBoxItems[i].CheckState = CheckState.Unchecked;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboPosition_CheckBoxCheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //if (cboPosition.SelectedItem.ToString().Contains("Select All") && cboPosition.CheckBoxItems["Select All"].Checked)
                //    CheckedAll(cboPosition);
                ////else if (!cboPosition.SelectedItem.ToString().Contains("Select All") )
                //else if (!cboPosition.CheckBoxItems["Select All"].Checked && cboPosition.SelectedItem.ToString()=="")
                //    UncheckedAll(cboPosition);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void buttonPrint1_BtnClick()
        {

            try
            {
                PrintDGV.Print_DataGridView(dgvData);
            }
            catch (Exception)
            {

            }
        }

       

      

    
    }
}
