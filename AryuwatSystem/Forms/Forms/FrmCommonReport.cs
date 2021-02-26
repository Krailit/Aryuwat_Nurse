using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using DermasterSystem.Class;
using Excel = Microsoft.Office.Interop.Excel;

using System.IO;
using System.Web;
using System.Diagnostics; 
namespace DermasterSystem.Forms
{
    public partial class FrmCommonReport : DockContent
    {
        bool bind = true;
        private string MedStatus_Code = "";
        private string MedStatus_CodeNew = "";
        private string MedStatus_CodePending = "";
        private string MedStatus_CodeClosed = "";
        DataSet dsData;
        public FrmCommonReport()
        {
            InitializeComponent();
        }
        private void SetColumns()
        {
            try
            {
                Utility.SetPropertyDgv(dgvData);

                dgvData.Columns.Add("MedStatus_Code", "MedStatus_Code");
                dgvData.Columns.Add("MedStatus_Name", "สถานะ");
                //var columnSpec = new DataGridViewColumn
                //    {

                //        CellType = typeof(DateTime), // This is of type System.Type
                //        ColumnName = "UpdateDate" ,
                //        Caption="วันที่"
                //    };
                //dgvData.Columns.Add(columnSpec);
                dgvData.Columns.Add("UpdateDate", "วันที่");
                dgvData.Columns.Add("SO", "SO");
                dgvData.Columns.Add("VN", "MO");
                dgvData.Columns.Add("CN", "CN");
                dgvData.Columns.Add("FullNameThai", "ชื่อ-นามสกุล");
                dgvData.Columns.Add("Mobile", "Mobile (มือถือ)");
                dgvData.Columns.Add("SalePrice", "จำนวนเงิน");


                dgvData.Columns["VN"].Width = 100;
                dgvData.Columns["SO"].Width = 100;
                dgvData.Columns["CN"].Width = 100;
                dgvData.Columns["FullNameThai"].Width = 150;
                dgvData.Columns["Mobile"].Width = 200;
                dgvData.Columns["UpdateDate"].Width = 80;
                dgvData.Columns["MedStatus_Code"].Visible = false;
                dgvData.Columns["MedStatus_Name"].Width = 80;
                dgvData.Columns["SalePrice"].Width = 80;
                dgvData.Columns["SalePrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void txtStartdate_Click(object sender, EventArgs e)
        {
            SelectDate(txtStartdate);
        }

        private void txtEnddate_Click(object sender, EventArgs e)
        {
            SelectDate(txtEnddate);
        }
        private void SelectDate(TextBox txt)
        {
            try
            {
                    PopDateTime pp = new PopDateTime();
                    DateTime d;
                    pp.SelecttDate = DateTime.TryParse(txt.Text, out d) ? d : DateTime.Now;
                    //pp.SelecttDate =Convert.ToDateTime(pp.SelecttDate.ToString("dd/MM/yyyy"));
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
                if (bind)
                    BindReport(1);
            else
            {
                bind = true;
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void BindReport(int pIntseq)
        {
            try
            {
                Utility.MouseOn(this);
                dgvData.Rows.Clear();
                var info = new Entity.Report() { PageNumber = pIntseq };
                //Entity.Report custInfo = new Customer();

                if (!string.IsNullOrEmpty(txtStartdate.Text.Trim()))
                {
                    info.StartDate = txtStartdate.Text;
                }
                if (!string.IsNullOrEmpty(txtEnddate.Text.Trim()))
                {
                    info.EndDate = txtEnddate.Text;
                }
                if (!string.IsNullOrEmpty(txtCN.Text.Trim()))
                {
                    info.CN = "%" + txtCN.Text + "%";
                }
                if (!string.IsNullOrEmpty(txtSO.Text.Trim()))
                {
                    info.SONo = "%" + txtSO.Text + "%";
                }


                MedStatus_CodeNew = checkBoxNew.Checked ? "0" : null;
                MedStatus_CodePending = checkBoxPending.Checked ? "1" : null;
                MedStatus_CodeClosed = checkBoxClose.Checked ? "2" : null;
                info.MedStatus_CodeNew = MedStatus_CodeNew;
                info.MedStatus_CodePending = MedStatus_CodePending;
                info.MedStatus_CodeClosed = MedStatus_CodeClosed;
                 dsData = new Business.Report().SelectReportPaging(info);
                decimal SalePrice = 0;
                decimal MS_Price = 0;
                decimal Amount = 0;
                decimal SpecialPrice = 0;
                decimal PriceAfterDis = 0;
                decimal DiscountBathByItem = 0;
                
                long lngTotalPage = 0;
                long lngTotalRecord = 0;
                if (dsData.Tables[0].Rows.Count <= 0)
                {
                    ngbMain.CurrentPage = 0;
                    ngbMain.TotalPage = 0;
                    ngbMain.TotalRecord = 0;
                    ngbMain.Updates();
                    Utility.MouseOff(this);
                    // Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "ไม่พบข้อมูลในระบบ");
                    return;
                }
                foreach (DataRowView item in dsData.Tables[0].DefaultView)
                {
                    if (item["SONo"] + "" == "") continue;
                    else
                    {
                        //if (item["VN"] + "" != "") continue;
                    }

                   // SalePrice = item["SalePrice"] + "" == "" ? 0 : Convert.ToDecimal(item["SalePrice"] + "");
                    MS_Price = item["MS_Price"] + "" == "" ? 0 : Convert.ToDecimal(item["MS_Price"] + "");
                    Amount = item["Amount"] + "" == "" ? 0 : Convert.ToDecimal(item["Amount"] + "");
                    SpecialPrice = item["SpecialPrice"] + "" == "" ? 0 : Convert.ToDecimal(item["SpecialPrice"] + "");
                    PriceAfterDis = item["PriceAfterDis"] + "" == "" ? 0 : Convert.ToDecimal(item["PriceAfterDis"] + "");
                    DiscountBathByItem = item["DiscountBathByItem"] + "" == "" ? 0 : Convert.ToDecimal(item["DiscountBathByItem"] + "");
                    var myItems = new[]
                                      {
                                          String.Format("{0:dd/MM/yyyy}",DateTime.Parse( item["UpdateDate"]+"")),
                                          item["SONo"] + "",
                                          item["CN"]+"",
                                          item["FullNameThai"] + ""!=""?item["FullNameThai"] + "":item["FullNameEng"] + "",
                                          item["Section_Code"] + "",
                                          item["MedicalTab"] + "",
                                          item["MS_Name"] + "",
                                          MS_Price.ToString("###,###,###.##"),
                                          Amount.ToString("###,###,###.##"),
                                          (SpecialPrice+DiscountBathByItem).ToString("###,###,###.##"),
                                          PriceAfterDis.ToString("###,###,###.##"),
                                          
                                          item["MedStatus_Name"] + "",
                                          item["MedStatus_Code"] + "",
                                          
                                      };
                    dgvData.Rows.Add(myItems);
                    //if (lngTotalPage != 0) continue;
                    //Utility.FindTotalPage(Convert.ToInt32(item["rowTotal"].ToString()), ref lngTotalPage);
                    //lngTotalRecord = Convert.ToInt32(item["rowTotal"].ToString());
                }
                foreach (DataGridViewRow dataRow in dgvData.Rows)
                {
                    MedStatus_Code = dataRow.Cells["MedStatusCode"].Value+"";

                    if (MedStatus_Code == "0" || MedStatus_Code == "" || MedStatus_Code == "6")
                        dataRow.DefaultCellStyle.BackColor = Color.DarkGray;
                    if (MedStatus_Code == "1" || MedStatus_Code == "7")
                        dataRow.DefaultCellStyle.BackColor = Color.Khaki;
                    if (MedStatus_Code == "2" || MedStatus_Code == "8")
                        dataRow.DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                    if (MedStatus_Code == "3")
                        dataRow.DefaultCellStyle.BackColor = Color.LightBlue;
                }
                dgvData.ClearSelection();
                foreach (DataGridViewColumn column in dgvData.Columns)
                {

                    dgvData.Columns[column.Name].SortMode = DataGridViewColumnSortMode.Automatic;
                }
                ngbMain.CurrentPage = pIntseq;
                ngbMain.TotalPage = lngTotalPage;
                ngbMain.TotalRecord = lngTotalRecord;
                ngbMain.Updates();
                Utility.MouseOff(this);
            }
            catch (Exception ex)
            {
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeError, ex.Message);
                Utility.MouseOff(this);
                return;
            }
        }

        private void FrmCommonReport_Load(object sender, EventArgs e)
        {
            try
            {
                txtEnddate.Text=DateTime.Now.ToString("yyyy/MM/dd");
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
                                      e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
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
                        wb.Worksheets.Add(dsData.Tables[0]);
                        //HttpResponse Response = new HttpResponse(;
                        //Response.Clear();
                        //Response.Buffer = true;
                        //Response.Charset = "";
                        //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        //Response.AddHeader("content-disposition",string.Format("attachment;filename={0}",saveFileDialog1.FileName));
                        //using (MemoryStream MyMemoryStream = new MemoryStream())
                        //{
                            //wb.SaveAs(MyMemoryStream);
                            //MyMemoryStream.WriteTo(Response.OutputStream);
                            //Response.Flush();
                            //Response.End();
                        //}
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
    }
}
