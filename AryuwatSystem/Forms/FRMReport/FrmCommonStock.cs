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
using Entity;

namespace AryuwatSystem.Forms
{
    public partial class FrmCommonStock : DockContent, IForm
    {
        bool bind = true;
        private string MedStatus_Code = "";
        private string MedStatus_CodeNew = "";
        private string MedStatus_CodePending = "";
        private string MedStatus_CodeClosed = "";
        DataSet dsData = new DataSet();
        DataTable dtReq = new DataTable();
        public FrmCommonStock()
        {
            InitializeComponent();
        }
        #region IForm Members

        void IForm.IsSave()
        {
        }

        void IForm.IsDelete()
        {
            //DeleteData();
        }

        void IForm.IsRefresh()
        {
            //BindDataCustomer(1);
        }

        void IForm.IsEdit()
        {
            //UpdateDataCustomer();
        }

        void IForm.IsPrint()
        {
            PrintReport();
        }

        void IForm.IsNew()
        {
            //NewCustomer();
        }

        void IForm.IsExit()
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    
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

                //for (int i = 0; i < dgvData.Columns.Count - 1; i++)
                //{
                //    dgvData.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //}
                //dgvData.Columns[dgvData.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                //for (int i = 0; i < dgvData.Columns.Count; i++)
                //{
                //    int colw = dgvData.Columns[i].Width;
                //    dgvData.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //    dgvData.Columns[i].Width = colw;
                //}
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
    
        private void FrmCommonStock_Load(object sender, EventArgs e)
        {

            try
            {
                dgvData.AutoGenerateColumns = true;

                dateTimePickerSt.Value = DateTime.Now.AddMonths(-1);
                dateTimePickerEnd.Value = DateTime.Now;

                //txtEnddate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                //txtStartdate.Text = DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd");
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
        public DataSet DGVTODatable()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            try
            {

                for (int i = 0; i < dgvData.Columns.Count; i++)
                {
                    dt.Columns.Add(dgvData.Columns[i].Name);
                }
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < dgvData.Columns.Count; j++)
                    {
                        dr[dgvData.Columns[j].Name] = row.Cells[j].Value + "";
                    }

                    dt.Rows.Add(dr);
                }
                ds.Tables.Add(dt);
            }
            catch (Exception ex)
            {

            }
            return ds;
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
                        ExportFile ep = new ExportFile();
                        wb.Worksheets.Add(dtReq,"Result");
                        //if(ucPivotTable1.newDt.Rows.Count>0)
                        //wb.Worksheets.Add(ucPivotTable1.newDt);
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

        private void FrmCommonStock_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics.frmCommonStock = null;
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
      

        Dictionary<string, int> DicPeroid = new Dictionary<string, int>();
    
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ////dsData.Tables[0].DefaultView.RowFilter = string.Format("[_RowString] LIKE '%{0}%'", txtFilter.Text);
                //if (txtFilter.TextLength == 0)
                //{
                //    foreach (DataGridViewRow row in dataGridViewREQItem.Rows)
                //    {
                //        row.Visible = true;
                //    }
                //}
                foreach (DataGridViewRow row in dataGridViewREQItem.Rows)
                {
                    row.Visible = false;
                    //REQNo ReqBy Reply
                    if ((row.Cells["stringFind"].Value + "").ToUpper().Contains(txtFilter.Text.ToUpper()))
                    {
                        row.Visible = true;
                    }
                }

            }
            catch (Exception)
            {

            }
        }

        private void buttonFind_BtnClick()
        {
            try
            {
                SearchREQ();
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
//        private void SearchSPQ()
//        {
//            try
//            {

////                ResetItem();
//                if (dataGridViewREQItem.RowCount > 0) dataGridViewREQItem.Rows.Clear();
//                lbCount.Text = "";
//                int c = 0;
//                Entity.MedicalSupplies info = new MedicalSupplies();


//                info.QueryType = "Search_SPQ_STOCKTRAN_REPORT";

//                info.StartDate = dateTimePickerSt.Value.AddDays(-1);
//                info.EndDate = dateTimePickerEnd.Value.AddDays(1);
//                info.Fortype = radioButtonBranch.Checked ? "B" : "D";
//                info.BranchID = uBranch1.BranchId;

//                DataSet ds = new Business.MedicalSupplies().SelectStock(info);
//                if (ds.Tables.Count <= 0) return;

//                dtReq = ds.Tables[0];
//                List<string> LSREQ = new List<string>();
//                foreach (DataRowView item in dtReq.DefaultView)
//                {
      
//                    //if (LSREQ.Contains(item["SPQNo"] + "") || item["SPQNo"] + "" == "") continue;
//                    object[] myItems = 
//                                                    {
//                                                    String.Format("{0:dd/MM/yyyy}",DateTime.Parse(item["REQDate"]+"")),
//                                                    item["SPQNo"] + "",//ใบเบิก
//                                                    item["MS_Code"] + "",//รหัสสต๊อค
//                                                    item["MS_Name"] + "",//รายการ
//                                                    item["SPQNo"] + "",//จำนวนเบิก
//                                                    item["SPQNo"] + "",//จำนวนจ่าย
//                                                     item["EN_Req_Name"] + "",//เบิกโดย
//                                                      item["EN_ReqTo_Name"] + "",//อนุมัติ
//                                                      (item["Approved"] + "").ToUpper()=="Y"?imageList1.Images[3]:new Bitmap(1, 1),
//                                                      (item["UrgentFlag"] + "").ToUpper()=="Y"?imageList1.Images[4]:new Bitmap(1, 1),
//                                              };
//                    dataGridViewREQItem.Rows.Add(myItems);
//                    LSREQ.Add(item["SPQNo"] + "");
//                    c++;
               
//                }
//                //dataGridViewREQItem.ClearSelection();
//                lbCount.Text = string.Format("Count {0}", dtReq.Rows.Count.ToString("###,###,###.##"));
//                if (dataGridViewREQItem.RowCount > 0) dataGridViewREQItem.Rows[0].Selected = true;

//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message);
//            }
//        }
        private void SearchREQ()
        {
            try
            {
                if (dataGridViewREQItem.RowCount > 0) dataGridViewREQItem.Rows.Clear();
                lbCount.Text = "";
                int c = 0;
                
                Entity.MedicalSupplies info = new MedicalSupplies();
               
                   if (uBranch1.BranchId == "")
                    {
                        MessageBox.Show("กรุณา เลือกสาขา", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                if (radioButtonBranch.Checked || radioButtonDept.Checked)
                {
                 
                    info.QueryType = "Search_REQ_STOCKTRAN_REPORT";
                }
                else if (radioButtonSP.Checked)
                    info.QueryType = "Search_SPQ_STOCKTRAN_REPORT";

                info.StartDate = dateTimePickerSt.Value.AddDays(-1);
                info.EndDate = dateTimePickerEnd.Value.AddDays(1);
                info.Fortype=radioButtonBranch.Checked ? "B" : "D";
                info.BranchID = uBranch1.BranchId;
                info.ReturnsFlag = checkBoxReturn.Checked ? "Y" : "";
                DataSet ds = new Business.MedicalSupplies().SelectStock(info);
                if (ds.Tables.Count <= 0) return;
                
                dtReq = ds.Tables[0];
              
                List<string> LSREQ = new List<string>();
                foreach (DataRowView item in dtReq.DefaultView)
                {
                            object[] myItems = 
                                                    {
                                                    String.Format("{0:dd/MM/yyyy}",DateTime.Parse(item["REQDate"]+"")),
                                                    item["ID"] + "",
                                                    item["MS_Code"] + "",
                                                    item["MS_Name"] + "",
                                                    item["Quantity"] + "",
                                                    item["QuantityReply"] + "",
                                                      item["EN_Req_Name"] + "",
                                                      item["EN_ReqTo_Name"] + "",
                                                      item["Req_BranchName"] + "",
                                                      item["DeptName"] + "",
                                                      
                                                            (item["Approved"] + "").ToUpper()=="Y"?imageList1.Images[4]:new Bitmap(1, 1),
                                                      (item["UrgentFlag"] + "").ToUpper()=="Y"?imageList1.Images[5]:new Bitmap(1, 1),
                                                      item["stringFind"] + "",
                                                      
                                              };
                            dataGridViewREQItem.Rows.Add(myItems);
                            LSREQ.Add(item["ID"] + "");
                            c++;
                 
                }
                lbCount.Text = string.Format("Count {0}", dtReq.Rows.Count.ToString("###,###,###.##"));
                //dataGridViewREQItem.ClearSelection();
                if (dataGridViewREQItem.Rows.Count > 0)
                    dataGridViewREQItem.Rows[0].Selected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonPrintReprt_BtnClick()
        {
        
                PrintReport();
        }
        private void PrintReport()
        {
            try
            {
                string GroupString = "";
                if(radioButtonSP.Checked) GroupString = "วัสดุสิ้นเปลือง";
                else if (radioButtonDept.Checked) GroupString ="แผนก";
                else if (radioButtonBranch.Checked) GroupString = "สาขา";


                DataTable newDt = new DataTable();
                DataView dv=new DataView();
                if (radioGroupID.Checked)
                {

                    dv = dtReq.DefaultView;
                    dv.Sort = "ID";
                }
                else
                {
                     newDt = dtReq.AsEnumerable()
                  .GroupBy(r => r.Field<string>("MS_Code"))
                  .Select(g =>
                  {
                      var row = dtReq.NewRow();

                      row["MS_Code"] = g.Key;
                      row["MS_Name"] = g.Select(r => r.Field<string>("MS_Name")).FirstOrDefault();// g.ToString(r => r.Field<string>("MS_Name"));
                      row["Quantity"] = g.Sum(r => r.Field<decimal?>("Quantity"));
                      row["QuantityReply"] = g.Sum(r => r.Field<decimal?>("QuantityReply"));
                      row["Req_BranchName"] = g.Select(r => r.Field<string>("Req_BranchName")).FirstOrDefault();

                      return row;
                  }).CopyToDataTable();

                      dv = newDt.DefaultView;
                     dv.Sort = "MS_Name";
                }
         
                DataTable sortedDT = dv.ToTable();

                FrmPreviewRpt obj = new FrmPreviewRpt();
                obj.ForDate = string.Format("{2} วันที่ {0} - {1}", String.Format("{0:dd/MM/yyyy}", DateTime.Parse(dateTimePickerSt.Value + "")), String.Format("{0:dd/MM/yyyy}", DateTime.Parse(dateTimePickerEnd.Value + "")), GroupString);

                obj.FormName = radioGroupID.Checked ? "RptREQREPInventoryGroupByDocNumber" : "RptREQREPInventory";

                obj.dt = sortedDT;
                obj.MaximizeBox = true;
                obj.TopMost = true;
                obj.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radioButtonBranch_Click(object sender, EventArgs e)
        {
            SearchREQ();
        }

        private void radioButtonDept_Click(object sender, EventArgs e)
        {
            SearchREQ();
        }

        private void radioButtonSP_Click(object sender, EventArgs e)
        {
            SearchREQ();
        }

        private void uBranch1_SelectedChanged(object sender, EventArgs e)
        {
            SearchREQ();
        }
    
    }
}
