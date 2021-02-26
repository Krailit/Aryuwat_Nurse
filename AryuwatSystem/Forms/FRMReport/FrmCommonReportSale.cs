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

namespace AryuwatSystem.Forms
{
    public partial class FrmCommonReportSale : DockContent, IForm
    {
        bool bind = true;
        private string MedStatus_Code = "";
        private string MedStatus_CodeNew = "";
        private string MedStatus_CodePending = "";
        private string MedStatus_CodeClosed = "";
        DataSet dsData;
        public FrmCommonReportSale()
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
        private void PrintReport()
        {
            try
            {
                FrmPreviewRpt obj = new FrmPreviewRpt();
                DataRow dr;

                DataTable dt;
                dt = dsData.Tables[0];
                

                string strTypeofPay = "";

                if (radioGroupBirthdate.Checked)
                {
                    obj.FormName = "RptBrithdate";

                }
                else if (radioGroupExpire.Checked)
                {
                    obj.FormName = "RptCycleDate";
                }
                else if (radioButtonPending.Checked)
                {
                    obj.FormName = "RptCoursePending";
                }

                double dblCredit = 0.00;
                double dblCash = 0.00;
                string strBankName = "";

                obj.TypeOfPayment = strTypeofPay;
                obj.dt = dt;
                obj.MaximizeBox = true;
                obj.TopMost = true;
                obj.Show();
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

        private void buttonFind_BtnClick()
        {
            try
            {
                lbCount.Text = "";
                if (bind)
                {
                    if (radioGroupExpire.Checked)
                        BindReportExpire(1);
                    if (radioGroupBirthdate.Checked)
                        BindReportBirthdate(1);
                    if (radioButtonPending.Checked)
                        BindReportPending(1);
                    if (radioButtonExpireMonth.Checked)
                        BindReportExpiredMonth(1);
                }
                //if (radioButtonReciept.Checked)
                //    BindReportReciept(1);
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
        public void BindReportExpire(int pIntseq)
        {
            try
            {
                DerUtility.MouseOn(this);
                var info = new Entity.Report() { PageNumber = pIntseq };
                //Entity.Report custInfo = new Customer();

                //if (!string.IsNullOrEmpty(txtStartdate.Text.Trim()))
                //{
                //    info.StartDate = txtStartdate.Text;
                //}
                //if (!string.IsNullOrEmpty(txtEnddate.Text.Trim()))
                //{
                //    info.EndDate =Convert.ToDateTime(txtEnddate.Text).AddDays(1)+"";
                //}
                //if (!string.IsNullOrEmpty(txtCN.Text.Trim()))
                //{
                //    info.CN = "%" + txtCN.Text + "%";
                //}
                //if (!string.IsNullOrEmpty(txtSO.Text.Trim()))
                //{
                //    info.SONo = "%" + txtSO.Text + "%";
                //}
                //if (radioGroupSO.Checked)
                //{
                //    info.SONo = "%" + txtSO.Text + "%";
                //}
                //if (radioGroupCN.Checked)
                //{
                //    info.SONo = "%" + txtSO.Text + "%";
                //}

                MedStatus_CodeNew = checkBoxNew.Checked ? "0" : null;
                MedStatus_CodePending = checkBoxPending.Checked ? "1" : null;
                MedStatus_CodeClosed = checkBoxClose.Checked ? "2" : null;
                info.MedStatus_CodeNew = MedStatus_CodeNew;
                info.MedStatus_CodePending = MedStatus_CodePending;
                info.MedStatus_CodeClosed = MedStatus_CodeClosed;
                string v = ((KeyValuePair<string, int>)comboBoxPeriod.SelectedItem).Value.ToString();
                info.Peroid = Convert.ToInt16(v);
                info.QueryType = "SEARCH_Cycle";
                dsData = new Business.Report().SelectReportPaging(info);
                //====================For  filter========= start===================
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
                //====================For  filter=====end=======================
                dgvData.Columns.Clear();
                dgvData.AutoGenerateColumns = true;
                dgvData.DataSource = null;
                dgvData.DataSource = dsData.Tables[0];
                if (dgvData.Columns.Contains("_RowString")) dgvData.Columns["_RowString"].Visible = false;
                if (dgvData.Columns.Contains("MO"))
                    dgvData.Columns["MO"].Visible = false;
                if (dgvData.Columns.Contains("SONo"))
                    dgvData.Columns["SONo"].Visible = false;
                //MO,SONo
                SetColumns();
                //ngbMain.CurrentPage = pIntseq;
                //ngbMain.TotalPage = lngTotalPage;
                //ngbMain.TotalRecord = lngTotalRecord;
                //ngbMain.Updates();
                DerUtility.MouseOff(this);
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
        }
        public void BindReportBirthdate(int pIntseq)
        {
            try
            {
                DerUtility.MouseOn(this);
                
                var info = new Entity.Report() { PageNumber = pIntseq };
                
                MedStatus_CodeNew = checkBoxNew.Checked ? "0" : null;
                MedStatus_CodePending = checkBoxPending.Checked ? "1" : null;
                MedStatus_CodeClosed = checkBoxClose.Checked ? "2" : null;
                info.MedStatus_CodeNew = MedStatus_CodeNew;
                info.MedStatus_CodePending = MedStatus_CodePending;
                info.MedStatus_CodeClosed = MedStatus_CodeClosed;
                info.BirthMonth = comboBoxPeriod.Text;
                info.QueryType = "SEARCHBirthDate";
                dsData = new Business.Report().SelectReportPaging(info);
                //====================For  filter========= start===================
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
                //====================For  filter=====end=======================
                dgvData.Columns.Clear();
                dgvData.AutoGenerateColumns = true;
                dgvData.DataSource = null;
                dgvData.DataSource = dsData.Tables[0];
                if (dgvData.Columns.Contains("_RowString")) dgvData.Columns["_RowString"].Visible = false;
                //SetColumns();
                //ngbMain.CurrentPage = pIntseq;
                //ngbMain.TotalPage = lngTotalPage;
                //ngbMain.TotalRecord = lngTotalRecord;
                //ngbMain.Updates();
                DerUtility.MouseOff(this);
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
        }
        public void BindReportPending(int pIntseq)
        {
            try
            {
                DerUtility.MouseOn(this);

                var info = new Entity.Report() { PageNumber = pIntseq };
                
                MedStatus_CodeNew = checkBoxNew.Checked ? "0" : null;
                MedStatus_CodePending = checkBoxPending.Checked ? "1" : null;
                MedStatus_CodeClosed = checkBoxClose.Checked ? "2" : null;
                info.MedStatus_CodeNew = MedStatus_CodeNew;
                info.MedStatus_CodePending = MedStatus_CodePending;
                info.MedStatus_CodeClosed = MedStatus_CodeClosed;
                info.BirthMonth = comboBoxPeriod.Text;
                info.QueryType = "SEARCH_Pending";
                dsData = new Business.Report().SelectReportPaging(info);
                //====================For  filter========= start===================
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
                //====================For  filter=====end=======================
                dgvData.Columns.Clear();
                dgvData.AutoGenerateColumns = true;
                dgvData.DataSource = null;
                dgvData.DataSource = dsData.Tables[0];
                if (dgvData.Columns.Contains("_RowString")) dgvData.Columns["_RowString"].Visible = false;
                SetColumns();
                //ngbMain.CurrentPage = pIntseq;
                //ngbMain.TotalPage = lngTotalPage;
                //ngbMain.TotalRecord = lngTotalRecord;
                //ngbMain.Updates();
                DerUtility.MouseOff(this);
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
        }
        public void BindReportExpiredMonth(int pIntseq)
        {
            try
            {
                DerUtility.MouseOn(this);

                var info = new Entity.Report() { PageNumber = pIntseq };

                MedStatus_CodeNew = checkBoxNew.Checked ? "0" : null;
                MedStatus_CodePending = checkBoxPending.Checked ? "1" : null;
                MedStatus_CodeClosed = checkBoxClose.Checked ? "2" : null;
                info.MedStatus_CodeNew = MedStatus_CodeNew;
                info.MedStatus_CodePending = MedStatus_CodePending;
                info.MedStatus_CodeClosed = MedStatus_CodeClosed;
                info.Peroid =Convert.ToInt16(comboBoxPeriod.SelectedValue);
                info.QueryType = "SEARCH_ExpiredMonth";
                dsData = new Business.Report().SelectReportPaging(info);
                //====================For  filter========= start===================
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
                //====================For  filter=====end=======================
                dgvData.Columns.Clear();
                dgvData.AutoGenerateColumns = true;
                dgvData.DataSource = null;
                dgvData.DataSource = dsData.Tables[0];
                if (dgvData.Columns.Contains("_RowString")) dgvData.Columns["_RowString"].Visible = false;
                SetColumns();
                //ngbMain.CurrentPage = pIntseq;
                //ngbMain.TotalPage = lngTotalPage;
                //ngbMain.TotalRecord = lngTotalRecord;
                //ngbMain.Updates();
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
    
        private void FrmCommonReportSale_Load(object sender, EventArgs e)
        {

            try
            {
                dgvData.AutoGenerateColumns = true;
                setForBirthDate();
                comboBoxPeriod.SelectedIndex = 0;

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
                        wb.Worksheets.Add(ep.GetDataTableFromDGV(dgvData,"Result"));
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

        private void FrmCommonReportSale_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics.frmCommonReportSale = null;
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
        private void setForBirthDate()
        {
            try
            {
                comboBoxPeriod.Visible = true;
                labelx.Visible = true;
                labelx.Text = "Select Month";
                comboBoxPeriod.DataSource = null;
                comboBoxPeriod.Items.AddRange(monthList.ToArray());
                comboBoxPeriod.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        Dictionary<string, int> DicPeroid = new Dictionary<string, int>();
        private void setForExpireDate()
        {
            try
            {
                Dictionary<string, int> DicPeroid = new Dictionary<string, int>();
                DicPeroid.Add("1 Week", -7);
                DicPeroid.Add("2 Weeks", -14);
                DicPeroid.Add("1 Month", -30);
                DicPeroid.Add("3 Months", -90);
                DicPeroid.Add("6 Months", -180);
                DicPeroid.Add("12 Months", -365);

                comboBoxPeriod.Visible = true;
                labelx.Visible = true;
                labelx.Text = "Period";
                comboBoxPeriod.DataSource = null;
                comboBoxPeriod.DataSource = new BindingSource(ExpireList, null);
                comboBoxPeriod.DisplayMember = "Key";
                comboBoxPeriod.ValueMember = "Value";
                comboBoxPeriod.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void setForExpiredMonth()
        {
            try
            {
                Dictionary<string, int> DicPeroid = new Dictionary<string, int>();
                DicPeroid.Add("1 Month", 1);
                DicPeroid.Add("3 Months", 3);
                DicPeroid.Add("6 Months", 6);
                DicPeroid.Add("12 Months", 12);

                comboBoxPeriod.Visible = true;
                labelx.Visible = true;
                labelx.Text = "Period";
                comboBoxPeriod.DataSource = null;
                comboBoxPeriod.DataSource = new BindingSource(DicPeroid, null);
                comboBoxPeriod.DisplayMember = "Key";
                comboBoxPeriod.ValueMember = "Value";
                comboBoxPeriod.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void setForPending()
        {
            try
            {
                comboBoxPeriod.Visible = false;
                labelx.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void radioGroupBirthdate_Click(object sender, EventArgs e)
        {
            if(radioGroupBirthdate.Checked)
            setForBirthDate();
        }

        private void radioGroupExpire_Click(object sender, EventArgs e)
        {
            if (radioGroupExpire.Checked)
            setForExpireDate();
        }

        private void radioButtonPending_Click(object sender, EventArgs e)
        {
            if (radioButtonPending.Checked)
                setForPending();
        }

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
            }
        }

        private void radioButtonCourseUsed_Click(object sender, EventArgs e)
        {

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

        private void radioButtonExpireMonth_Click(object sender, EventArgs e)
        {
            setForExpiredMonth();
        }

        //private void radioButton1_Click(object sender, EventArgs e)
        //{
        //    setForExpiredMonth();
        //}
    
    }
}
