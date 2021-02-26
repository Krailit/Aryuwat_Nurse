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
namespace AryuwatSystem.Forms
{
    public partial class FrmCommonReportSaleResult : DockContent
    {
        bool bind = true;
        private string MedStatus_Code = "";
        private string MedStatus_CodeNew = "";
        private string MedStatus_CodePending = "";
        private string MedStatus_CodeClosed = "";
        DataTable dtAllTotal = new DataTable();
        DataSet dsData;
        public FrmCommonReportSaleResult()
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
                float varFontSize = Single.Parse("8");
                for (int i = 0; i < dgvData.Columns.Count; i++)
                {
                    if (dgvData.Columns[i].Name.ToLower() != "ms_name" && dgvData.Columns[i].Name.ToLower() != "ms_code")
                        dgvData.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                dgvData.Columns[dgvData.Columns.Count - 1].DefaultCellStyle.Font = new Font("Tahoma", varFontSize, FontStyle.Bold);
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
                dgvData.Columns[0].Frozen = true;
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

                var info = new Entity.Report() { PageNumber = pIntseq };


                MedStatus_CodeNew = checkBoxNew.Checked ? "0" : null;
                MedStatus_CodePending = checkBoxPending.Checked ? "1" : null;
                MedStatus_CodeClosed = checkBoxClose.Checked ? "2" : null;
                info.MedStatus_CodeNew = MedStatus_CodeNew;
                info.MedStatus_CodePending = MedStatus_CodePending;
                info.MedStatus_CodeClosed = MedStatus_CodeClosed;
                info.BranchId = uBranch1.BranchId;

                //info.BirthMonth = comboBoxPeriod.Text;
                string Sale_cashier = "";

                if (comboBoxMonth.SelectedIndex<12)
                {
                    if (cboSurgicalFeeTyp.Text == "AESTHETIC")
                        info.QueryType = "ReportSaleResultAE_Month_SO";
                    else if (cboSurgicalFeeTyp.Text == "WELLNESS")
                        info.QueryType = "ReportSaleResultWE_Month_SO";
                    else if (cboSurgicalFeeTyp.Text == "SURGERY")
                        info.QueryType = "ReportSaleResultSU_Month_SO";
                    else if (cboSurgicalFeeTyp.Text == "PHARMACY")
                        info.QueryType = "ReportSaleResultPA_Month_SO";
                    else if (cboSurgicalFeeTyp.Text == "HAIR")
                        info.QueryType = "ReportSaleResultHA_Month_SO";
                    else if (cboSurgicalFeeTyp.Text == "Pro Credit")
                        info.QueryType = "ReportSaleResultPROCREDIT_Month_SO";
                    
                }
                else
                {
                    if (cboSurgicalFeeTyp.Text == "AESTHETIC")
                        info.QueryType = "ReportSaleResultAE_Year_SO";
                    else if (cboSurgicalFeeTyp.Text == "WELLNESS")
                        info.QueryType = "ReportSaleResultWE_Year_SO";
                    else if (cboSurgicalFeeTyp.Text == "SURGERY")
                        info.QueryType = "ReportSaleResultSU_Year_SO";
                    else if (cboSurgicalFeeTyp.Text == "PHARMACY")
                        info.QueryType = "ReportSaleResultPA_Year_SO";
                    else if (cboSurgicalFeeTyp.Text == "HAIR")
                        info.QueryType = "ReportSaleResultHA_Year_SO";
                    else if (cboSurgicalFeeTyp.Text == "Pro Credit")
                        info.QueryType = "ReportSaleResultPROCREDIT_Year_SO";
                }

                int m = 0;
               // if (!dicMonth.ContainsKey(comboBoxPeriod.Text)) return;

              if (comboBoxMonth.SelectedIndex==12)
                {
                    txtStartdate.Text = DateTimeUtil.FirstDayOfMonth(Convert.ToInt16(comboBoxYears.Text), 1).ToString("yyyy/MM/dd");
                    txtEnddate.Text = DateTimeUtil.LastDayOfMonth(Convert.ToInt16(comboBoxYears.Text), 12).ToString("yyyy/MM/dd");
                }
                else
                {
                    if (!dicMonth.ContainsKey(comboBoxMonth.Text)) return;

                    m = dicMonth[comboBoxMonth.Text];
                    txtStartdate.Text = DateTimeUtil.FirstDayOfMonth(Convert.ToInt16(comboBoxYears.Text), m).ToString("yyyy/MM/dd");
                    txtEnddate.Text = DateTimeUtil.LastDayOfMonth(Convert.ToInt16(comboBoxYears.Text), m).ToString("yyyy/MM/dd");
                }

                if (!string.IsNullOrEmpty(txtStartdate.Text.Trim()))
                {
                    info.StartDate = txtStartdate.Text;
                }
                if (!string.IsNullOrEmpty(txtEnddate.Text.Trim()))
                {
                    info.EndDate = txtEnddate.Text;
                }
                
                    DataRow dr;
                if (cboSurgicalFeeTyp.Text.ToUpper() == "TOTAL" )
                {
                    if (comboBoxMonth.SelectedIndex == 12)
                    {
                        info.QueryType = "ReportSaleResultAE_Year_SO";
                        dsData = new Business.Report().SelectReportPaging(info);
                        
                        dtAllTotal = dsData.Tables[0].Clone();
                        if (dsData.Tables[0].Rows.Count > 0)
                            dr = dsData.Tables[0].Rows[dsData.Tables[0].Rows.Count - 1];
                        else
                        {
                            dr = dsData.Tables[0].NewRow();
                            dsData.Tables[0].Rows.Add(dr);
                            dr = dsData.Tables[0].Rows[dsData.Tables[0].Rows.Count - 1];
                        }
                        dr[0] = "AESTHETIC";
                        dtAllTotal.ImportRow(dr);
                        info.QueryType = "ReportSaleResultWE_Year_SO";
                        dsData = new Business.Report().SelectReportPaging(info);
                        if (dsData.Tables[0].Rows.Count > 0)
                            dr = dsData.Tables[0].Rows[dsData.Tables[0].Rows.Count - 1];
                        else
                        {
                            dr = dsData.Tables[0].NewRow();
                            dsData.Tables[0].Rows.Add(dr);
                            dr = dsData.Tables[0].Rows[dsData.Tables[0].Rows.Count - 1];
                        }
                        dr[0] = "WELLNESS";
                        dtAllTotal.ImportRow(dr);
                        info.QueryType = "ReportSaleResultSU_Year_SO";
                        dsData = new Business.Report().SelectReportPaging(info);
                        if (dsData.Tables[0].Rows.Count > 0)
                            dr = dsData.Tables[0].Rows[dsData.Tables[0].Rows.Count - 1];
                        else
                        {
                            dr = dsData.Tables[0].NewRow();
                            dsData.Tables[0].Rows.Add(dr);
                            dr = dsData.Tables[0].Rows[dsData.Tables[0].Rows.Count - 1];
                        }
                        dr[0] = "SURGERY";
                        dtAllTotal.ImportRow(dr);
                        info.QueryType = "ReportSaleResultPA_Year_SO";
                        dsData = new Business.Report().SelectReportPaging(info);
                        if (dsData.Tables[0].Rows.Count > 0)
                            dr = dsData.Tables[0].Rows[dsData.Tables[0].Rows.Count - 1];
                        else
                        {
                            dr = dsData.Tables[0].NewRow();
                            dsData.Tables[0].Rows.Add(dr);
                            dr = dsData.Tables[0].Rows[dsData.Tables[0].Rows.Count - 1];
                        }
                        dr[0] = "PHARMACY";
                        dtAllTotal.ImportRow(dr);
                        info.QueryType = "ReportSaleResultHA_Year_SO";
                        dsData = new Business.Report().SelectReportPaging(info);
                        if (dsData.Tables[0].Rows.Count > 0)
                            dr = dsData.Tables[0].Rows[dsData.Tables[0].Rows.Count - 1];
                        else
                        {
                            dr = dsData.Tables[0].NewRow();
                            dsData.Tables[0].Rows.Add(dr);
                            dr = dsData.Tables[0].Rows[dsData.Tables[0].Rows.Count - 1];
                        }
                        dr[0] = "HAIR";
                        dtAllTotal.ImportRow(dr);

                        info.QueryType = "ReportSaleResultPROCREDIT_Year_SO";
                        dsData = new Business.Report().SelectReportPaging(info);
                        if (dsData.Tables[0].Rows.Count > 0)
                            dr = dsData.Tables[0].Rows[dsData.Tables[0].Rows.Count - 1];
                        else
                        {
                            dr = dsData.Tables[0].NewRow();
                            dsData.Tables[0].Rows.Add(dr);
                            dr = dsData.Tables[0].Rows[dsData.Tables[0].Rows.Count - 1];
                        }
                        dr[0] = "Pro Credit";
                        dtAllTotal.ImportRow(dr);
                    }
                    else
                    {
                        info.QueryType = "ReportSaleResultAE_Month_SO";
                        dsData = new Business.Report().SelectReportPaging(info);
                        dtAllTotal = dsData.Tables[0].Clone();
                        if (dsData.Tables[0].Rows.Count > 0)
                            dr = dsData.Tables[0].Rows[dsData.Tables[0].Rows.Count - 1];
                        else
                        {
                            dr = dsData.Tables[0].NewRow();
                            dsData.Tables[0].Rows.Add(dr);
                            dr = dsData.Tables[0].Rows[dsData.Tables[0].Rows.Count - 1];
                        }
                        dr[0] = "AESTHETIC";
                        dtAllTotal.ImportRow(dr);
                        info.QueryType = "ReportSaleResultWE_Month_SO";
                        dsData = new Business.Report().SelectReportPaging(info);
                        if (dsData.Tables[0].Rows.Count > 0)
                            dr = dsData.Tables[0].Rows[dsData.Tables[0].Rows.Count - 1];
                        else
                        {
                            dr = dsData.Tables[0].NewRow();
                            dsData.Tables[0].Rows.Add(dr);
                            dr = dsData.Tables[0].Rows[dsData.Tables[0].Rows.Count - 1];
                        }
                        dr[0] = "WELLNESS";
                        dtAllTotal.ImportRow(dr);
                        info.QueryType = "ReportSaleResultSU_Month_SO";
                        dsData = new Business.Report().SelectReportPaging(info);
                        if (dsData.Tables[0].Rows.Count > 0)
                            dr = dsData.Tables[0].Rows[dsData.Tables[0].Rows.Count - 1];
                        else
                        {
                            dr = dsData.Tables[0].NewRow();
                            dsData.Tables[0].Rows.Add(dr);
                            dr = dsData.Tables[0].Rows[dsData.Tables[0].Rows.Count - 1];
                        }
                        dr[0] = "SURGERY";
                        dtAllTotal.ImportRow(dr);
                        info.QueryType = "ReportSaleResultPA_Month_SO";
                        dsData = new Business.Report().SelectReportPaging(info);
                        if (dsData.Tables[0].Rows.Count > 0)
                            dr = dsData.Tables[0].Rows[dsData.Tables[0].Rows.Count - 1];
                        else
                        {
                            dr = dsData.Tables[0].NewRow();
                            dsData.Tables[0].Rows.Add(dr);
                            dr = dsData.Tables[0].Rows[dsData.Tables[0].Rows.Count - 1];
                        }
                        dr[0] = "PHARMACY";
                        dtAllTotal.ImportRow(dr);
                        info.QueryType = "ReportSaleResultHA_Month_SO";
                        dsData = new Business.Report().SelectReportPaging(info);
                        if (dsData.Tables[0].Rows.Count > 0)
                            dr = dsData.Tables[0].Rows[dsData.Tables[0].Rows.Count - 1];
                        else
                        {
                            dr = dsData.Tables[0].NewRow();
                            dsData.Tables[0].Rows.Add(dr);
                            dr = dsData.Tables[0].Rows[dsData.Tables[0].Rows.Count - 1];
                        }
                        dr[0] = "HAIR";
                        dtAllTotal.ImportRow(dr);

                        info.QueryType = "ReportSaleResultPROCREDIT_Month_SO";
                        dsData = new Business.Report().SelectReportPaging(info);
                        if (dsData.Tables[0].Rows.Count > 0)
                            dr = dsData.Tables[0].Rows[dsData.Tables[0].Rows.Count - 1];
                        else
                        {
                            dr = dsData.Tables[0].NewRow();
                            dsData.Tables[0].Rows.Add(dr);
                            dr = dsData.Tables[0].Rows[dsData.Tables[0].Rows.Count - 1];
                        }
                        dr[0] = "Pro Credit";
                        dtAllTotal.ImportRow(dr);
                    }

                DataRow totalsRow = dtAllTotal.NewRow();
                foreach (DataColumn col in dtAllTotal.Columns)
                {

                    if (col.Ordinal == 0)
                    {
                        totalsRow[col.ColumnName] = "Total";
                        continue;
                    }
                    Double colTotal = 0;
                     Double colTotalxx = 0;
                    foreach (DataRow row in col.Table.Rows)
                    {
                        try
                        {
                            colTotalxx = row[col].ToString()==""?0:Double.Parse(row[col].ToString().Replace(",", ""));//.Replace(",", "").Replace(",", "").Replace(",", "").Replace(",", ""));
                            colTotal += colTotalxx;
                        }
                        catch (Exception)
                        {
                            
                            
                        }
                      
                    }
                    totalsRow[col.ColumnName] =colTotal==0?"0.0": colTotal.ToString("###,###,###,###,###"); 
                }
                dtAllTotal.Rows.Add(totalsRow);
                }
                else
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
                dgvData.DataSource = null;
                if (cboSurgicalFeeTyp.Text.ToUpper() == "TOTAL")
                {
                    dgvData.DataSource = dtAllTotal;
                }
                else
                {
                    dgvData.DataSource = dsData.Tables[0];
                }

                SetColumns();
                //ngbMain.CurrentPage = pIntseq;
                //ngbMain.TotalPage = lngTotalPage;
                //ngbMain.TotalRecord = lngTotalRecord;
                //ngbMain.Updates();
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
    
        private void FrmCommonReportSaleResult_Load(object sender, EventArgs e)
        {

            try
            {
                //dgvData.AutoGenerateColumns = true;
                //setForMonth();
                setForYears();
                txtEnddate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txtStartdate.Text = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");
                setForMonth();
                BindSurgicalFeeType_Position();
                uBranch1.setBranchValue(Entity.Userinfo.BranchId);
            }
            catch (Exception ex)
            {
               
            }
        }
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
                string thisy = "All Months";
                dicMonth.Add(thisy, 0);
                comboBoxMonth.Items.Clear();
                foreach (KeyValuePair<string, int> entry in dicMonth)
                {
                    comboBoxMonth.Items.Add(entry.Key);
                }
                comboBoxMonth.Visible = true;
                //labelMonth.Visible = true;
                //labelMonth.Text = "Select Month";
                //comboBoxPeriod.DataSource = nu;
                //comboBoxPeriod.Items.AddRange(dicMonth);
                comboBoxMonth.SelectedIndex = comboBoxMonth.Items.Count - 1;
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
                   DataTable dtSubSurgicalFee = dsComRate.Tables[1];
                   DataView view = new DataView(dtSubSurgicalFee);
                    //DataTable distinctValues = view.ToTable(true, "Position_Type", "Column2");
                    DataTable distinctValues = view.ToTable(true, "SurgicalFeeTyp");
                    cboSurgicalFeeTyp.Items.Clear();

                    foreach (DataRow item in distinctValues.Rows)
                    {
                        cboSurgicalFeeTyp.Items.Add(item["SurgicalFeeTyp"]);
                    }
                    
                    cboSurgicalFeeTyp.Items.Add("Pro Credit");
                    cboSurgicalFeeTyp.Items.Add("Total");
                    cboSurgicalFeeTyp.SelectedIndex = 0;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        Dictionary<string, int> dicMonth = new Dictionary<string, int>();
        //private void setForMonth()
        //{
        //    try
        //    {
        //        dicMonth = new Dictionary<string, int>();
        //        dicMonth.Add("January(1)", 1);
        //        dicMonth.Add("February(2)", 2);
        //        dicMonth.Add("March(3)", 3);
        //        dicMonth.Add("April(4)", 4);
        //        dicMonth.Add("May(5)", 5);
        //        dicMonth.Add("June(6)", 6);
        //        dicMonth.Add("July(7)", 7);
        //        dicMonth.Add("August(8)", 8);
        //        dicMonth.Add("September(9)", 9);
        //        dicMonth.Add("October(10)", 10);
        //        dicMonth.Add("November(11)", 11);
        //        dicMonth.Add("December(12)", 12);
        //        string thisy = string.Format("This Year({0})", DateTime.Now.Year + "");
        //        dicMonth.Add(thisy, 0);
        //        comboBoxPeriod.Items.Clear();
        //        foreach (KeyValuePair<string, int> entry in dicMonth)
        //        {
        //            comboBoxPeriod.Items.Add(entry.Key);
        //        }
        //        comboBoxPeriod.Visible = true;
        //        labelMonth.Visible = true;
        //        //labelMonth.Text = "Select Month";
        //        //comboBoxPeriod.DataSource = nu;
        //        //comboBoxPeriod.Items.AddRange(dicMonth);
        //        comboBoxPeriod.SelectedIndex = DateTime.Now.Month - 1;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
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
                        titlereport = string.Format("{0}/{1}", cboSurgicalFeeTyp.Text,comboBoxMonth.Text);
                        if (cboSurgicalFeeTyp.Text.ToUpper() == "TOTAL")
                            ExportDataWithClosedXml_Method(dtAllTotal, "Result", titlereport);
                        else
                        {
                            ExportDataWithClosedXml_Method(dsData, "Result", titlereport);
                          
                                //ExportFile exp = new ExportFile();
                                //wb.Worksheets.Add(dsData.Tables[0]);
                                //wb.Worksheets.Worksheet(1).Column("J").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                                //wb.Worksheets.Add(dsData.Tables[1]);
                                //wb.Worksheets.Worksheet(2).Column("B").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                                //wb.SaveAs(saveFileDialog1.FileName);
                                //if (File.Exists(saveFileDialog1.FileName))
                                //{
                                //    Process.Start(saveFileDialog1.FileName);
                                //}
                        }


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
        public void ExportDataWithClosedXml_Method(DataSet ds, string tabName, string ReportTitle)
        {
            var workbook = new XLWorkbook();
            foreach (DataTable table in ds.Tables)
            {
                var ws = workbook.Worksheets.Add(table, table.TableName);
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
            }
            workbook.SaveAs(saveFileDialog1.FileName);

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

        private void FrmCommonReportSaleResult_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics.frmCommonReportSaleResult = null;
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
            if (bind)
                BindReportResult(1);
            else
            {
                bind = true;
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
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
                lbCount.Text = string.Format("Count {0}", dgvData.RowCount.ToString("###,###,###"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDGV.Print_DataGridView(dgvData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void buttonExport1_BtnClick(object sender, EventArgs e)
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
                        titlereport = string.Format("Summary of {0}", cboSurgicalFeeTyp.Text);
                        if (cboSurgicalFeeTyp.Text.ToUpper() == "TOTAL")
                            ExportDataWithClosedXml_Method(dtAllTotal, "Result", titlereport);
                        else
                        {
                            //ExportDataWithClosedXml_Method(dsData.Tables[0], "Result", titlereport);

                            ExportFile exp = new ExportFile();
                            wb.Worksheets.Add(dsData.Tables[0]);
                            wb.Worksheets.Worksheet(1).Column("J").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                            wb.Worksheets.Add(dsData.Tables[1]);
                            wb.Worksheets.Worksheet(2).Column("B").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                            wb.SaveAs(saveFileDialog1.FileName);
                            if (File.Exists(saveFileDialog1.FileName))
                            {
                                Process.Start(saveFileDialog1.FileName);
                            }
                        }


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
      
      
    
    }
}
