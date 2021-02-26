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
using Entity; 
namespace AryuwatSystem.Forms
{
    public partial class FrmHRCommissionCheck : DockContent
    {
        bool bind = true;
        private string MedStatus_Code = "";
        private string MedStatus_CodeNew = "";
        private string MedStatus_CodePending = "";
        private string MedStatus_CodeClosed = "";
        DataTable dtAllTotal = new DataTable();
        DataTable dtAllSum = new DataTable();
        DataTable dtReport = new DataTable();
        Dictionary<string, string> dicReportRang = new Dictionary<string, string>();
        Dictionary<string, string> dicReporQueryType = new Dictionary<string, string>();
        public string QueryType = "";
        bool excVat = false;
        string titlereport = "";
        DataSet dsSurgeryFee;
        DataTable dtSurgicalFee = new DataTable();
        string TPName = "";
        private Dictionary<double, double> DicComRate;
        double Commission = 0;
         double     Sales=0;
         int count=0;
        //DataSet dsData;
        public FrmHRCommissionCheck()
        {
            InitializeComponent();
       
        }
     
        private void GetReportName()
        {
            try
            {
                Entity.Report info = new Entity.Report() { PageNumber = 1 };
                    info.QueryType = "GetReportNameHR";

                  
                DataSet ds = new Business.Report().SelectReportList(info);
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
               
               
                //DerUtility.MouseOn(this);
                dgvData.DataSource = null;
                dataGridViewSum.DataSource = null;
                //pIntseq = _pIntseq;
                SurgeryFee info = new SurgeryFee(); 
             
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
                dsSurgeryFee = new Business.StuffCommission().SelectSurgeryFee(info);
                dtAllTotal = dsSurgeryFee.Tables[0];
                dtAllSum = dsSurgeryFee.Tables[1];

                long lngTotalPage = 0;
                long lngTotalRecord = 0;
                if (dsSurgeryFee.Tables.Count <= 0)
                {
                    if (dsSurgeryFee.Tables[0].Rows.Count <= 0)
                    {
                        DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "ไม่พบข้อมูลในระบบ");
                        return;
                    }
                }

                if (dsSurgeryFee.Tables[0].Columns.Count < 2) return;
                //====================For  filter========= start===================
                DataColumn dcRowString = dsSurgeryFee.Tables[0].Columns.Add("_RowString", typeof(string));
                foreach (DataRow dataRow in dsSurgeryFee.Tables[0].Rows)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < dsSurgeryFee.Tables[0].Columns.Count - 1; i++)
                    {
                        sb.Append(dataRow[i].ToString());
                        sb.Append("\t");
                    }
                    dataRow[dcRowString] = sb.ToString() + "Total";
                }
                //====================For  filter=====end=======================
                dtSurgicalFee = dsSurgeryFee.Tables[0].Clone();
                Dictionary<string, double> dicSum = new Dictionary<string, double>();
                Dictionary<string, double> dicSumSection = new Dictionary<string, double>();
                foreach (DataRow item in dsSurgeryFee.Tables[0].Rows)
                {
                    //if (SubSection.Text == "")
                    //{
                    //this.VN,this.MS_Name,this.CourseUse,this.ProcedureDate,this.StartTime,this.EndTime,this.Money});
                    //double m = string.IsNullOrEmpty(item["Com_Bath"] + "") ? 0 : Convert.ToDouble(item["Com_Bath"] + "");
                    //if (dicSum.ContainsKey(item["พนักงาน"] + ""))
                    //{
                    //    dicSum[item["พนักงาน"] + ""] += m;
                    //}
                    //else
                    //{
                    //    dicSum.Add(item["พนักงาน"] + "", m);
                    //}

                    dtSurgicalFee.ImportRow(item);
                    //Sales += m;
                    //count++;

                    //if (dicSum.ContainsKey(item["พนักงาน"] + ""))
                    //{
                    //    dicSum[item["พนักงาน"] + ""] += m;
                    //}
                    //else
                    //{
                    //    dicSum.Add(item["พนักงาน"] + "", m);
                    //}



                }


                ////=====for total Row===
                //DataRow dr = dtSurgicalFee.NewRow();
                //if (dtSurgicalFee.Columns.Contains("_RowString"))
                //    dr["_RowString"] = "Total";

                //dtSurgicalFee.Rows.Add(dr);
                ////=====for total Row===

                dgvData.DataSource = dtSurgicalFee;// dsSurgeryFee.Tables[0];



                if (dgvData.Columns.Contains("_RowString"))
                    dgvData.Columns["_RowString"].Visible = false;
                //DataTable dtSum = new DataTable();
                //dtSum = dsSurgeryFee.Tables[0].Clone();
                //if (lsToSum.Any())
                //{
                //    foreach (DataRowView item in lsToSum)
                //    {
                //        dtSum.ImportRow((DataRow)item);
                //    }
                //}


                //double sm = 0;
                //foreach (KeyValuePair<string, double> entry in dicSum)
                //{
                //    sm += entry.Value;
                //}

                // Order by Key.
                // ... Use LINQ to specify sorting by value.
                //var items = from pair in dicSum
                //            orderby pair.Key ascending
                //            select pair;
                //Dictionary<string, double> dicSumx = dicSum;
                //dicSum = new Dictionary<string, double>();
                //foreach (var item in dicSumx.OrderBy(i => i.Key))
                //{
                //    dicSum.Add(item.Key, item.Value);
                //}

                //var sortedDict = from entry in dicSum orderby entry.Key ascending select entry;

       //         Dictionary <string, string> ShareUserNewCopy = 
       //ShareUserCopy.OrderBy(x => x.Value).ToDictionary(pair => pair.Key,
       //                                                 pair => pair.Value);   

                //dicSum = dicSum.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
                //dicSum.Add("    ยอดรวม ", sm);
                dataGridViewSum.AutoGenerateColumns = true;
                dataGridViewSum.DataSource = null;
                dataGridViewSum.Columns.Clear();
                dataGridViewSum.DataSource = dtAllSum;// ToDataTable(dicSum);// dsSurgeryFee.Tables[1];
                if (dataGridViewSum.Columns.Contains("Fee"))
                    dataGridViewSum.Columns["Fee"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                CalCommission();

                DerUtility.FindTotalPage(count, ref lngTotalPage);
                lngTotalRecord = count;

                //if (dsSurgeryFee.Tables[0].Rows.Count <= 0)
                //{
                //    ngbMain.CurrentPage = 0;
                //    ngbMain.TotalPage = 0;
                //    ngbMain.TotalRecord = 0;
                //    ngbMain.Updates();
                //    DerUtility.MouseOff(this);
                //    // Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "ไม่พบข้อมูลในระบบ");
                //    return;
                //}
                //else
                //{
                //    ngbMain.CurrentPage = _pIntseq;
                //    ngbMain.TotalPage = lngTotalPage;
                //    ngbMain.TotalRecord = lngTotalRecord;
                //    ngbMain.Updates();
                //}
                setColumn();
               // DataGridViewUtil.LoopSumByColumn(dgvData, false);
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);

                return;
            }
            finally
            {
            }
        }
        private void setColumn()
        {

            try
            {
                //for (int i = 0; i < dgvData.Columns.Count - 1; i++)
                //{
                //    dgvData.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //}
                //dgvData.Columns[dgvData.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                for (int i = 0; i < dgvData.Columns.Count; i++)
                {
                    int colw = dgvData.Columns[i].Width;
                    dgvData.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvData.Columns[i].Width = colw;
                    if (dgvData.Columns[i].Name.ToLower() == "com_bath" | dgvData.Columns[i].Name.ToLower().Contains("date") | dgvData.Columns[i].Name.ToLower().Contains("fee"))
                    {
                        dgvData.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                    if (dgvData.Columns[i].Name.ToLower() == "com_bath" | dgvData.Columns[i].Name.ToLower().Contains("fee"))
                    {
                        dgvData.Columns[i].DefaultCellStyle.Format = "N2";
                    }

                }

                //for (int i = 0; i < dataGridViewSum.Columns.Count - 1; i++)
                //{
                //    dataGridViewSum.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //}
                //dataGridViewSum.Columns[dataGridViewSum.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                for (int i = 0; i < dataGridViewSum.Columns.Count; i++)
                {
                    //int colw = dataGridViewSum.Columns[i].Width;
                    //dataGridViewSum.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    //dataGridViewSum.Columns[i].Width = colw;
                   // if (dataGridViewSum.Columns[i].Name.ToLower().Contains("bath") | dataGridViewSum.Columns[i].Name.ToLower().Contains("date") | dataGridViewSum.Columns[i].Name.ToLower().Contains("fee"))
                    if(i>1 && i<dataGridViewSum.Columns.Count)
                        dataGridViewSum.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


                }
                System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
                dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
                dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
                dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F);
                dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
                dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
                dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
                dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                this.dgvData.DefaultCellStyle = dataGridViewCellStyle2;
                dgvData.RowsDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;

                //dgvData.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
                dgvData.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
                dgvData.EnableHeadersVisualStyles = false;

                //dataGridViewSum.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
                dataGridViewSum.EnableHeadersVisualStyles = false;
                dataGridViewSum.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
                dataGridViewSum.Rows[dataGridViewSum.RowCount-1].DefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);

            }
            catch (Exception)
            {

            }

        }
        private DataTable ToDataTable(Dictionary<string, double> dic)
        {
            DataTable result = new DataTable();
            result.Columns.Add("Name", typeof(string));
            result.Columns.Add("Fee", typeof(string));
            foreach (KeyValuePair<string, double> entry in dic)
            {
                result.Rows.Add(entry.Key, entry.Value == 0 ? "0" : entry.Value.ToString("###,###,###.00"));
            }

            return result;
        }
        private void CalCommission()
        {
            int level = 0;
            foreach (KeyValuePair<double, double> valuePair in DicComRate)
            {

                if (Sales > valuePair.Key && level < DicComRate.Count - 1)
                {
                    level++;
                    continue;
                }
                Commission = Sales * valuePair.Value;
                level++;
                break;

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
    
        private void FrmHRCommissionCheck_Load(object sender, EventArgs e)
        {

            try
            {
                //dgvData.AutoGenerateColumns = true;
                //setForMonth();
                setForYears();
                GetReportName();
                txtEnddate.Text =DateTime.Now.ToString("dd/MM/yyyy");
                txtStartdate.Text =DateTime.Now.ToString("dd/MM/yyyy");
                BindCommissionRate();
                var grouper = this.dataGridViewGrouperControl1.Grouper;
                //grouper.SetGroupOn("AString");
            }
            catch (Exception ex)
            {
               
            }
        }
        private void BindCommissionRate()
        {
            try
            {
                DicComRate = new Dictionary<double, double>();
                DataSet dsComRate = new Business.StuffCommission().SelectCommissionRate();
                if (dsComRate.Tables.Count > 0)
                {
                    foreach (DataRow dr in from DataRow dr in dsComRate.Tables[0].Rows where dr["Sales"] + "" != "" where !DicComRate.ContainsKey(Convert.ToDouble(dr["Sales"] + "")) select dr)
                    {
                        DicComRate.Add(Convert.ToDouble(dr["Sales"] + ""), Convert.ToDouble(dr["Com_Rate"] + ""));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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


                    // dt = city.GetAllCity();//your datatable
                    using (ClosedXML.Excel.XLWorkbook wb = new ClosedXML.Excel.XLWorkbook())
                    {
                        ExportFile exp = new ExportFile();
                        wb.Worksheets.Add(exp.GetDataTableFromDGV(dgvData, "Result"));
                        //wb.Worksheets.Worksheet(0).Cells[rowIndex, 22].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        wb.Worksheets.Worksheet(1).Column("J").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        //wb.Worksheets.Add(dsSurgeryFee.Tables[0],"Data");
                        //if (dsSurgeryFee.Tables.Count > 2)
                        wb.Worksheets.Add(exp.GetDataTableFromDGV(dataGridViewSum, "Summary"));
                        wb.Worksheets.Worksheet(2).Column("B").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
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

        private void FrmHRCommissionCheck_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics.frmHRCommissionCheck = null;
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
                dtSurgicalFee.DefaultView.RowFilter = string.Format("[_RowString] LIKE '%{0}%' or [_RowString]='Total' or [_RowString]='Total NoVat'", txtFilter.Text);
                //SumTotal();
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
                foreach (DataRow dr in dtSurgicalFee.DefaultView.ToTable().Rows)
                {
                    //if (!lsSO.Contains(dr["SO"] + ""))
                    //{
                        //lsSO.Add(dr["SO"] + "");
                        //consult2 = dr["Consult2"] + "";
                        //if ((dr["จำนวน"] + "").ToLower().Contains("total") || (dr["จำนวน"] + "").ToLower().Contains("exc")) 
                        //    continue;

                        //if (consult2 != "")
                        //{
                        //    sum += dr["ยอดรับเงิน"] + "" == "" ? 0 : Convert.ToDouble(dr["ยอดรับเงิน"] + "") / 2;
                        //}
                        //else
                        //{
                        //    sum += dr["ยอดรับเงิน"] + "" == "" ? 0 : Convert.ToDouble(dr["ยอดรับเงิน"] + "");
                        //}
                        sumReciept += dr["Com_Bath"] + "" == "" ? 0 : Convert.ToDouble(dr["Com_Bath"] + "");
                    //}

                }
                lbTotal.Text = string.Format("Total Fee : {0} ", sumReciept.ToString("###,###,###,###"));
                DataGridViewUtil.LoopSumByColumn(dgvData,excVat);
            }
            catch (Exception)
            {
             
            }
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
            try
            {
                PrintDGV.Print_DataGridView(dataGridViewSum);
                PrintDGV.Print_DataGridViewA3(dgvData);
            }
            catch (Exception)
            {

            }
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
                if (!dicReportRang.ContainsKey(comboBoxReport.SelectedValue.ToString())) return;

                QueryType = dicReporQueryType[comboBoxReport.SelectedValue.ToString()];
                //BindReport(1);
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

        private void btnPrintForm_Click(object sender, EventArgs e)
        {
            try
            {
                FrmPreviewRpt obj = new FrmPreviewRpt();
                DataRow dr;

                string strTypeofPay = "";

                obj.PrintType = "";
                double dblCredit = 0.00;
                double dblCash = 0.00;
                string strBankName = "";


                if (QueryType == "RptHRSurgicalFeeType2")
                {
                    obj.PrintType = "RptHRSurgicalFeeType2";
                    obj.ForDate = string.Format("วันที่ {0} - {1}", txtStartdate.Text, txtEnddate.Text);
                    //obj.DataSetReport = string.Format("วันที่ {0} - {1}", txtStartdate.Text, txtEnddate.Text);
                }

                //else if (QueryType == "RptAccBenefitTREATMENT")
                //{
                //    obj.PrintType = "TREATMENT";
                //    obj.ForDate = string.Format("วันที่ {0} - {1}", txtStartdate.Text, txtEnddate.Text);
                //}
                //else if (QueryType == "RptAccBenefitANGTI-AGING")
                //{
                //    obj.PrintType = "ANGTI-AGING";
                //    obj.ForDate = string.Format("วันที่ {0} - {1}", txtStartdate.Text, txtEnddate.Text);
                //}
                //else if (QueryType == "RptAccBenefitSURGERY")
                //{
                //    obj.PrintType = "SURGERY";
                //    obj.ForDate = string.Format("วันที่ {0} - {1}", txtStartdate.Text, txtEnddate.Text);
                //}
                //else if (QueryType == "RptAccBenefitHAIR")
                //{
                //    obj.PrintType = "HAIR";
                //    obj.ForDate = string.Format("วันที่ {0} - {1}", txtStartdate.Text, txtEnddate.Text);
                //}
                //else if (QueryType == "RptAccOutstanding")
                //{
                //    obj.PrintType = string.Format(" วันที่ {0} - {1}", txtStartdate.Text, txtEnddate.Text);
                //}
                //else
                //{
                //    obj.PrintType = string.Format(" วันที่ {0} - {1}", txtStartdate.Text, txtEnddate.Text);
                //}



                obj.FormName = QueryType;

                DataTable temp = dtAllSum.Copy();
                temp.Rows.RemoveAt(dtAllSum.Rows.Count-1);
                obj.dt = temp;
                obj.MaximizeBox = true;
                obj.TopMost = true;
                obj.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewSum_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right && e.ColumnIndex==0)
                {
                    //dataGridViewSum.ClearSelection();
                    //dgvData.Rows[rowIndex].Selected = false;
                    dataGridViewSum.CurrentCell = dataGridViewSum.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    TPName = dataGridViewSum.Rows[e.RowIndex].Cells[e.ColumnIndex].Value + "";
                    dataGridViewSum.Rows[e.RowIndex].Selected = true;
                    menuPaybyItem.Visible = true;
                    contextMenuStrip1.Show(MousePosition);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewSum_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    dataGridViewSum.ClearSelection();
                    //dgvData.Rows[rowIndex].Selected = false;
                    dataGridViewSum.CurrentCell = dataGridViewSum.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    //dataGridViewSum.Rows[e.RowIndex].Selected = true;
                    //menuPaybyItem.Visible = true;
                    //contextMenuStrip1.Show(MousePosition);
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void menuPaybyItem_Click(object sender, EventArgs e)
        {
            try
            {

                //if (radioButtonCover.Checked)
                // {

                FrmPreviewRpt obj = new FrmPreviewRpt();
                DataRow dr;

                string strTypeofPay = "";

                obj.PrintType = "";
                double dblCredit = 0.00;
                double dblCash = 0.00;
                string strBankName = "";

                obj.PrintType = "RptFeeDayListCheckTP";
                    obj.FormName = "RptFeeDayListCheckTP";

                if(txtStartdate.Text==txtEnddate.Text)
                    obj.ForDate = string.Format(" {0} วันที่ {1} {2}", TPName, txtStartdate.Text, uBranch1.BranchId.Length < 2 ? "" : uBranch1.BranchName);
                else
                    obj.ForDate = string.Format(" {0} วันที่ {1} - {2} {3}", TPName, txtStartdate.Text, txtEnddate.Text, uBranch1.BranchId.Length < 2 ? "" : uBranch1.BranchName);
                   
                dsSurgeryFee.Tables[0].DefaultView.RowFilter = string.Format("[พนักงาน] LIKE '%{0}%' or [_RowString]='Total'", TPName);


                DataTable dtListAll = dtAllTotal.DefaultView.ToTable();

                //DataTable temp = dtListAll.Copy();
                //temp.Rows.RemoveAt(dtListAll.Rows.Count - 1);
                obj.dt = dtListAll;
                obj.MaximizeBox = true;
                obj.TopMost = true;
                obj.Show();
               
            }
            catch (Exception)
            {

            }
        }

        private void buttonPrint1_BtnClick()
        {
            try
            {
                PrintDGV.Print_DataGridView(dataGridViewSum);
                PrintDGV.Print_DataGridViewA3(dgvData);
            }
            catch (Exception)
            {

            }
        }
      
      
    
    }
}
