﻿using System;
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
namespace AryuwatSystem.Forms
{
    public partial class FrmSetGroupReportSEO : DockContent
    {
        bool bind = true;
        private string MedStatus_Code = "";
        private string MedStatus_CodeNew = "";
        private string MedStatus_CodePending = "";
        private string MedStatus_CodeClosed = "";
        DataTable dtAll = new DataTable();
        public FrmSetGroupReportSEO()
        {
            InitializeComponent();
        }
        private void SetColumns()
        {
            try
            {
                //DerUtility.SetPropertyDgv(dgvData);

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
                //float varFontSize = Single.Parse("9");
                //for (int i = 0; i < dgvData.Columns.Count; i++)
                //{
                //    if (dgvData.Columns[i].Name.ToLower() != "ms_name" && dgvData.Columns[i].Name.ToLower() != "ms_code")
                //        dgvData.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                //}
                //dgvData.Columns[dgvData.Columns.Count - 1].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont.Name, varFontSize, FontStyle.Bold);
                //dgvData.Rows[dgvData.RowCount - 1].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont.Name, varFontSize, FontStyle.Bold);
                //dgvData.Rows[dgvData.RowCount - 1].Height = dgvData.Rows[dgvData.RowCount - 1].Height+2;
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
    
        private void FrmSetGroupReportSEO_Load(object sender, EventArgs e)
        {

            try
            {
                //dgvData.AutoGenerateColumns = true;
                ////setForMonth();
                //txtEnddate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                //txtStartdate.Text = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");
            }
            catch (Exception ex)
            {
               
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

                        ExportDataWithClosedXml_Method(dtAll, "Result", titlereport);


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

        private void FrmSetGroupReportSEO_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Statics.FrmSetGroupReportSEO = null;
        }
      
        private void dgvData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

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
            //try
            //{
            //    int height = dgvData.Height;
            //    dgvData.Height = dgvData.RowCount * dgvData.RowTemplate.Height * 2;
            //     bm = new Bitmap(this.dgvData.Width, this.dgvData.Height);
            //    dgvData.DrawToBitmap(bm, new Rectangle(0, 0, this.dgvData.Width, this.dgvData.Height));
            //    dgvData.Height = height;
            //    printPreviewDialog1.Show();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
           
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

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dtAll.DefaultView.RowFilter = string.Format("[_RowString] LIKE '%{0}%'", txtFilter.Text);
            }
            catch (Exception)
            {

            }
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            Pen p = new Pen(Color.Black, 1);
            gfx.DrawLine(p, 0, 5, 0, e.ClipRectangle.Height - 2);
            gfx.DrawLine(p, 0, 5, 10, 5);
            gfx.DrawLine(p, 50, 5, e.ClipRectangle.Width - 2, 5);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, 5, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2, 0, e.ClipRectangle.Height - 2);  
        }

        private void buttonExport1_Load(object sender, EventArgs e)
        {

        }
      
      
    
    }
}
