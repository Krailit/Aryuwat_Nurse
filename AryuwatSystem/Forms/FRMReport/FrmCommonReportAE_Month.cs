using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Excel = Microsoft.Office.Interop.Excel;

using System.IO;
using System.Web;
using System.Diagnostics;
using AryuwatSystem.Forms.PrintGridView;
using AryuwatSystem.Forms.FRMReport;
using AryuwatSystem.DerClass;

namespace AryuwatSystem.Forms
{
    public partial class FrmCommonReportAE_Month : DockContent
    {
        bool bind = true;
        private string MedStatus_Code = "";
        private string MedStatus_CodeNew = "";
        private string MedStatus_CodePending = "";
        private string MedStatus_CodeClosed = "";
        DataSet dsData;
        DataTable dataDetail;
        DataTable dataMaster;
        public FrmCommonReportAE_Month()
        {
            InitializeComponent();
            
        }
        private void SetColumns()
        {
            try
            {
                DerUtility.SetPropertyDgv(dgvData);

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
      
        private void SelectDate(TextBox txt)
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
        private void Find()
        {
            try
            {
                if (bind)
                {
                   BindReportAE_report(1);
                }

                else
                {
                    bind = true;
                }
                if (dsData.Tables.Count > 0)
                {
                    ucPivotTable1.dt = dsData.Tables[0];
                    ucPivotTable1.ReloadColumn();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void buttonFind_BtnClick()
        {
            Find();
        }
        public void BindReportAE_report(int pIntseq)
        {
            try
            {
                DerUtility.MouseOn(this);
                var info = new Entity.Report() { PageNumber = pIntseq };
                //table.Rows.Add("สรุปใช้คอร์สรายปี(Not S)", "ReportAE_Year_MORef");
                //table.Rows.Add("สรุปยอดขายรายปี (SO)", "ReportAE_Year_SOnotS");
                //table.Rows.Add("สรุปเคสรายปี (CN)", "ReportAE_Year_CN");
                if ((comboBoxReport.SelectedValue+"").ToLower().Contains("year"))
                {
                    txtStartdate.Text = DateTimeUtil.FirstDayOfMonth(Convert.ToInt16(comboBoxYears.Text), 1).ToString("yyyy/MM/dd");
                    txtEnddate.Text = DateTimeUtil.LastDayOfMonth(Convert.ToInt16(comboBoxYears.Text), 12).ToString("yyyy/MM/dd");
                }
                else
                {
                    int m = 0;
                    if (!dicMonth.ContainsKey(comboBoxPeriod.Text)) return;

                    m = dicMonth[comboBoxPeriod.Text];
                    txtStartdate.Text = DateTimeUtil.FirstDayOfMonth(Convert.ToInt16(comboBoxYears.Text), m).ToString("yyyy/MM/dd");
                    txtEnddate.Text = DateTimeUtil.LastDayOfMonth(Convert.ToInt16(comboBoxYears.Text), m).ToString("yyyy/MM/dd");
                }


                if (!string.IsNullOrEmpty(txtStartdate.Text.Trim()))
                {
                    info.StartDate = txtStartdate.Text;
                }
                if (!string.IsNullOrEmpty(txtEnddate.Text.Trim()))
                {
                    info.EndDate = txtEnddate.Text;// Convert.ToDateTime(txtEnddate.Text).AddDays(1) + "";
                }

                MedStatus_CodeNew = checkBoxNew.Checked ? "0" : null;
                MedStatus_CodePending = checkBoxPending.Checked ? "1" : null;
                MedStatus_CodeClosed = checkBoxClose.Checked ? "2" : null;
                info.MedStatus_CodeNew = MedStatus_CodeNew;
                info.MedStatus_CodePending = MedStatus_CodePending;
                info.MedStatus_CodeClosed = MedStatus_CodeClosed;

                info.BranchId = uBranch1.BranchId;

                //if (radioGroupAE_countMORef.Checked)
                //    info.QueryType = "ReportAE_Month_MORef";
                //else if (radioGroupAE_countMORef_S.Checked)
                //    info.QueryType = "ReportAE_Month_MORef_S";
                //else if (radioGroupAE_countMORef_ALL.Checked)
                //    info.QueryType = "ReportAE_Month_MORef_ALL";
                //else if (radioGroupAEJobcost.Checked)
                //    info.QueryType = "ReportAE_Month_SOnotS";
                //else if (radioGroupAE_countMORef_Year.Checked)
                //    info.QueryType = "ReportAE_Year_MORef";
                //else if (radioGroupORJobCostYear.Checked)
                //    info.QueryType = "ReportAE_Year_SOnotS";
                //else if (radioGroupAE_CNCase.Checked)
                //    info.QueryType = "ReportAE_Month_CN";
                //else if (radioGroupORJobCostCaseYear.Checked)
                //    info.QueryType = "ReportAE_Year_CN";
                //else if (radioButtonPriceS.Checked)
                //    info.QueryType = "ReportAE_Month_Price_S";

                info.QueryType = comboBoxReport.SelectedValue+"";
                


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
                    DerUtility.MouseOff(this);
                    // Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "ไม่พบข้อมูลในระบบ");
                    return;
                }

                dgvData.AutoGenerateColumns = true;
                dgvData.DataSource = null;
                dgvData.Columns.Clear();

                //dgvData.DataSource = GenerateTransposedTable(dsData.Tables[0]);//===============
                dataMaster = dsData.Tables[0];

                dataMaster = PivotTable.GenerateTransposedTable(dataMaster);
                dataMaster = ExportFile.CleanZeroText(dataMaster);
                foreach (DataColumn item in dataMaster.Columns)
                {
                    dgvData.Columns.Add(item.ColumnName, item.ColumnName);
                }
                if (dsData.Tables.Count > 1)
                {
                    //DataGridViewImageColumn BtnDetail = new DataGridViewImageColumn();
                    //BtnDetail.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    //BtnDetail.CellTemplate = new DataGridViewImageCell();
                    //BtnDetail.Name = "BtnDetail";
                    //BtnDetail.HeaderText = "";
                    //dgvData.Columns.Insert(0, BtnDetail);
                    dataDetail = dsData.Tables[1];
                }
                int r = 0;
                foreach (DataRow row in dataMaster.Rows)
                {

                    var index = dgvData.Rows.Add();
                    //dgvData.Rows[index].Cells["BtnDetail"].Value = new Bitmap(1, 1);
                    //if (r <= dataMaster.Rows.Count - 2)
                    //{
                    //    dgvData.Rows[index].Cells["BtnDetail"].Value = imageList1.Images[0];
                    //}

                    foreach (DataColumn c in dataMaster.Columns)
                    {

                        if (c.ColumnName.ToLower() == "month" || c.ColumnName.ToLower() == "date" )
                            dgvData.Rows[index].Cells[c.ColumnName].Value = row[c.ColumnName] + "";
                        else
                        {
                            DataGridViewLinkCell lc = new DataGridViewLinkCell();
                            lc.Value = row[c.ColumnName] + "";
                            dgvData.Rows[index].Cells[c.ColumnName] = lc;
                        }
                    }
                    r++;

                }


                //for (int i = 0; i < dgvData.Columns.Count - 1; i++)
                //{
                //    dgvData.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //}
                ////dgvData.Columns[dgvData.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //this.dgvData.AlternatingRowsDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                //dgvData.RowsDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                //for (int i = 0; i < dgvData.Columns.Count; i++)
                //{
                //    int colw = dgvData.Columns[i].Width;
                //    dgvData.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //    dgvData.Columns[i].Width = colw;
                //}
                this.dgvData.AlternatingRowsDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
                dgvData.RowsDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
                System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStylex = new System.Windows.Forms.DataGridViewCellStyle();
                dataGridViewCellStylex.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
                dataGridViewCellStylex.Font = new System.Drawing.Font("Tahoma", 7.5F);
                this.dgvData.DefaultCellStyle = dataGridViewCellStylex;
                for (int i = 0; i < dgvData.Columns.Count - 1; i++)
                {
                    dgvData.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                //dataGridView1.Columns[dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                for (int i = 0; i < dgvData.Columns.Count; i++)
                {
                    int colw = dgvData.Columns[i].Width;
                    dgvData.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvData.Columns[i].Width = colw;
                    dgvData.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }


                dgvData.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
                dgvData.Columns[0].Width = 120;
                
                dgvData.Columns[0].Frozen = true;

                //dgvData.DataBindings;
                ngbMain.CurrentPage = pIntseq;
                ngbMain.TotalPage = lngTotalPage;
                ngbMain.TotalRecord = lngTotalRecord;
                ngbMain.Updates();
                DerUtility.MouseOff(this);
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
        }

      
        //public void BindReportAE_report(int pIntseq)
        //{
        //    try
        //    {
        //        Utility.MouseOn(this);
        //        var info = new Entity.Report() { PageNumber = pIntseq };
        //        //Entity.Report custInfo = new Customer();


        //        if (radioGroupAE_countMORef_Year.Checked || radioGroupORJobCostYear.Checked || radioGroupORJobCostCaseYear.Checked)
        //        {
        //            txtStartdate.Text = FirstDayOfMonth(1).ToString("yyyy/MM/dd");
        //            txtEnddate.Text = LastDayOfMonth(12).ToString("yyyy/MM/dd"); 
        //        }
        //        else
        //        {
        //            int m = 0;
        //            if (!dicMonth.ContainsKey(comboBoxPeriod.Text)) return;

        //            m = dicMonth[comboBoxPeriod.Text];
        //            txtStartdate.Text = FirstDayOfMonth(m).ToString("yyyy/MM/dd"); 
        //            txtEnddate.Text = LastDayOfMonth(m).ToString("yyyy/MM/dd"); 
        //        }


        //        if (!string.IsNullOrEmpty(txtStartdate.Text.Trim()))
        //        {
        //            info.StartDate = txtStartdate.Text;
        //        }
        //        if (!string.IsNullOrEmpty(txtEnddate.Text.Trim()))
        //        {
        //            info.EndDate = txtEnddate.Text;// Convert.ToDateTime(txtEnddate.Text).AddDays(1) + "";
        //        }

        //        MedStatus_CodeNew = checkBoxNew.Checked ? "0" : null;
        //        MedStatus_CodePending = checkBoxPending.Checked ? "1" : null;
        //        MedStatus_CodeClosed = checkBoxClose.Checked ? "2" : null;
        //        info.MedStatus_CodeNew = MedStatus_CodeNew;
        //        info.MedStatus_CodePending = MedStatus_CodePending;
        //        info.MedStatus_CodeClosed = MedStatus_CodeClosed;
        //        if(radioGroupAE_countMORef.Checked)
        //            info.QueryType = "ReportAE_Month_MORef";
        //        else if(radioGroupAE_countMORef_S.Checked)
        //            info.QueryType = "ReportAE_Month_MORef_S";
        //        else if (radioGroupAE_countMORef_ALL.Checked)
        //            info.QueryType = "ReportAE_Month_MORef_ALL";
        //        else if (radioGroupAEJobcost.Checked)
        //            info.QueryType = "ReportAE_Month_SOnotS";
        //        else if (radioGroupAE_countMORef_Year.Checked)
        //            info.QueryType = "ReportAE_Year_MORef";
        //        else if (radioGroupORJobCostYear.Checked)
        //            info.QueryType = "ReportAE_Year_SOnotS";
        //        else if (radioGroupAE_CNCase.Checked)
        //            info.QueryType = "ReportAE_Month_CN";
        //        else if (radioGroupORJobCostCaseYear.Checked)
        //            info.QueryType = "ReportAE_Year_CN";
                
                
                
                
                
                
        //         dsData = new Business.Report().SelectReportPaging(info);
        //        decimal SalePrice = 0;
        //        decimal MS_Price = 0;
        //        decimal Amount = 0;
        //        decimal SpecialPrice = 0;
        //        decimal PriceAfterDis = 0;
        //        decimal DiscountBathByItem = 0;
                
        //        long lngTotalPage = 0;
        //        long lngTotalRecord = 0;
        //        if (dsData.Tables[0].Rows.Count <= 0)
        //        {
        //            ngbMain.CurrentPage = 0;
        //            ngbMain.TotalPage = 0;
        //            ngbMain.TotalRecord = 0;
        //            ngbMain.Updates();
        //            Utility.MouseOff(this);
        //            // Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "ไม่พบข้อมูลในระบบ");
        //            return;
        //        }
        //        dgvData.AutoGenerateColumns = true;
        //        dgvData.DataSource =null;
        //        dgvData.Columns.Clear();
        //        dgvData.DataSource = dsData.Tables[0];
        //        //dgvData.DataBindings;
        //        ngbMain.CurrentPage = pIntseq;
        //        ngbMain.TotalPage = lngTotalPage;
        //        ngbMain.TotalRecord = lngTotalRecord;
        //        ngbMain.Updates();

        //        if (dsData.Tables.Count > 1)
        //        {
        //           DataGridViewImageColumn BtnDetail = new DataGridViewImageColumn();
        //            BtnDetail.AutoSizeMode =DataGridViewAutoSizeColumnMode.DisplayedCells;
        //            BtnDetail.CellTemplate = new DataGridViewImageCell();
        //            BtnDetail.Name = "BtnDetail";
        //            BtnDetail.HeaderText = "";
        //            dgvData.Columns.Insert(0, BtnDetail);
        //            dataDetail = dsData.Tables[1];
        //        }

        //        Utility.MouseOff(this);
        //    }
        //    catch (Exception ex)
        //    {
        //        Utility.PopMsg(Utility.EnuMsgType.MsgTypeError, ex.Message);
        //        Utility.MouseOff(this);
        //        return;
        //    }
        //}
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
                dicMonth.Add("June(6)",6);
                dicMonth.Add("July(7)", 7);
                dicMonth.Add("August(8)",8);
                dicMonth.Add("September(9)",9);
                dicMonth.Add("October(10)",10);
                dicMonth.Add("November(11)",11);
                dicMonth.Add("December(12)",12);
                string thisy = "All Months";
                dicMonth.Add(thisy, 0);
                comboBoxPeriod.Items.Clear();
                foreach (KeyValuePair<string, int> entry in dicMonth)
                {
                    comboBoxPeriod.Items.Add(entry.Key);
                }
                comboBoxPeriod.Visible = true;
                labelMonth.Visible = true;
                //labelMonth.Text = "Select Month";
                //comboBoxPeriod.DataSource = nu;
                //comboBoxPeriod.Items.AddRange(dicMonth);
                comboBoxPeriod.SelectedIndex = DateTime.Now.Month - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void BindReportORJobCost(int pIntseq)
        {
            try
            {
                DerUtility.MouseOn(this);
                var info = new Entity.Report() { PageNumber = pIntseq };
                //Entity.Report custInfo = new Customer();

                if (!string.IsNullOrEmpty(txtStartdate.Text.Trim()))
                {
                    info.StartDate = txtStartdate.Text;
                }
                if (!string.IsNullOrEmpty(txtEnddate.Text.Trim()))
                {
                    info.EndDate = Convert.ToDateTime(txtEnddate.Text).AddDays(1) + "";
                }

                MedStatus_CodeNew = checkBoxNew.Checked ? "0" : null;
                MedStatus_CodePending = checkBoxPending.Checked ? "1" : null;
                MedStatus_CodeClosed = checkBoxClose.Checked ? "2" : null;
                info.MedStatus_CodeNew = MedStatus_CodeNew;
                info.MedStatus_CodePending = MedStatus_CodePending;
                info.MedStatus_CodeClosed = MedStatus_CodeClosed;
                info.QueryType = "ReportOR_Jobcost";
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
                    DerUtility.MouseOff(this);
                    // Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "ไม่พบข้อมูลในระบบ");
                    return;
                }
                dgvData.AutoGenerateColumns = true;
                dgvData.DataSource = null;
                dgvData.Columns.Clear();
                dgvData.DataSource = dsData.Tables[0];
                //dgvData.DataBindings;
                ngbMain.CurrentPage = pIntseq;
                ngbMain.TotalPage = lngTotalPage;
                ngbMain.TotalRecord = lngTotalRecord;
                ngbMain.Updates();
                DerUtility.MouseOff(this);
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
        }
        public void BindReportORJobCostProfit(int pIntseq)
        {
            try
            {
                DerUtility.MouseOn(this);
                var info = new Entity.Report() { PageNumber = pIntseq };
                //Entity.Report custInfo = new Customer();

                if (!string.IsNullOrEmpty(txtStartdate.Text.Trim()))
                {
                    info.StartDate = txtStartdate.Text;
                }
                if (!string.IsNullOrEmpty(txtEnddate.Text.Trim()))
                {
                    info.EndDate = Convert.ToDateTime(txtEnddate.Text).AddDays(1) + "";
                }

                MedStatus_CodeNew = checkBoxNew.Checked ? "0" : null;
                MedStatus_CodePending = checkBoxPending.Checked ? "1" : null;
                MedStatus_CodeClosed = checkBoxClose.Checked ? "2" : null;
                info.MedStatus_CodeNew = MedStatus_CodeNew;
                info.MedStatus_CodePending = MedStatus_CodePending;
                info.MedStatus_CodeClosed = MedStatus_CodeClosed;
                info.QueryType = "ReportOR_JobcostProfit";
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
                    DerUtility.MouseOff(this);
                    // Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "ไม่พบข้อมูลในระบบ");
                    return;
                }
                dgvData.AutoGenerateColumns = true;
                dgvData.DataSource = null;
                dgvData.Columns.Clear();
                dgvData.DataSource = dsData.Tables[0];

                //foreach (DataGridViewRow dataRow in dgvData.Rows)
                //{
                //    MedStatus_Code = dataRow.Cells["MedStatus_Code"].Value.ToString();

                //    if (MedStatus_Code == "0" || MedStatus_Code == "" || MedStatus_Code == "6")
                //        dataRow.DefaultCellStyle.BackColor = Color.DarkGray;
                //    if (MedStatus_Code == "1" || MedStatus_Code == "7")
                //        dataRow.DefaultCellStyle.BackColor = Color.Khaki;
                //    if (MedStatus_Code == "2" || MedStatus_Code == "8")
                //        dataRow.DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                //    if (MedStatus_Code == "3")
                //        dataRow.DefaultCellStyle.BackColor = Color.LightBlue;
                //}
                dgvData.Rows[dgvData.RowCount - 1].DefaultCellStyle.BackColor = Color.LightBlue;
                //dgvData.DataBindings;
                ngbMain.CurrentPage = pIntseq;
                ngbMain.TotalPage = lngTotalPage;
                ngbMain.TotalRecord = lngTotalRecord;
                ngbMain.Updates();
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

        private void FrmCommonReportAE_Month_Load(object sender, EventArgs e)
        {

            try
            {
                dgvData.AutoGenerateColumns = false;
                dgvData.Columns.Clear();
                DateTime date =DateTime.Now;
                var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
                txtStartdate.Text = firstDayOfMonth.ToString("yyyy/MM/dd");
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                txtEnddate.Text = lastDayOfMonth.ToString("yyyy/MM/dd");
                setForYears();
                setForMonth();
                
                //tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Remove(tabPage3);

                SetReportType();
                
               

            }
            catch (Exception ex)
            {
               
            }
        }
        private void SetReportType()
        {
            DataTable table = new DataTable();
            try
            {
                table.Columns.Add("Rpt_Name", typeof(string));
                table.Columns.Add("Rpt_Code", typeof(string));

                // Here we add five DataRows.
                table.Rows.Add("การใช้เครื่องมือแพทย์ (Mo.Ref)", "ReportAE_Month_MORef_ALL");
                table.Rows.Add("การใช้คอร์ส (Mo.Ref ไม่รวม S)", "ReportAE_Month_MORef");
                table.Rows.Add("การใช้คอร์ส (Mo.Ref S อย่างเดียว)", "ReportAE_Month_MORef_S");
                table.Rows.Add("จำนวนเคสของการขาย(CN)", "ReportAE_Month_CN");
                table.Rows.Add("จำนวนเงินของการขาย", "ReportAE_Month_SOnotS");
                table.Rows.Add("จำนวนเงิน ( S อย่างเดียว)", "ReportAE_Month_Price_S");
                table.Rows.Add("สรุปใช้เครื่องมือแพทย์ รายปี", "ReportAE_Year_MORef_ALL");
                table.Rows.Add("สรุปใช้คอร์สรายปี(Not S)", "ReportAE_Year_MORef");
                table.Rows.Add("สรุปยอดขายรายปี (SO)", "ReportAE_Year_SOnotS");
                table.Rows.Add("สรุปเคสรายปี (CN)", "ReportAE_Year_CN");
                //table.Rows.Add("xxx", "ReportAE_Month_MORef_S_CNM");

                comboBoxReport.DataSource = table;
                comboBoxReport.DisplayMember = "Rpt_Name";
                comboBoxReport.ValueMember = "Rpt_Code";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        //private DataTable GenerateTransposedTable(DataTable inputTable)
        //{
        //    DataTable outputTable = new DataTable();

        //    // Add columns by looping rows

        //    // Header row's first column is same as in inputTable
        //    outputTable.Columns.Add(inputTable.Columns[0].ColumnName.ToString());

        //    // Header row's second column onwards, 'inputTable's first column taken
        //    foreach (DataRow inRow in inputTable.Rows)
        //    {
        //        string newColName = inRow[0].ToString();
        //        outputTable.Columns.Add(newColName);
        //    }

        //    // Add rows by looping columns        
        //    for (int rCount = 1; rCount <= inputTable.Columns.Count - 1; rCount++)
        //    {
        //        DataRow newRow = outputTable.NewRow();

        //        // First column is inputTable's Header row's second column
        //        newRow[0] = inputTable.Columns[rCount].ColumnName.ToString();
        //        for (int cCount = 0; cCount <= inputTable.Rows.Count - 1; cCount++)
        //        {
        //            string colValue = inputTable.Rows[cCount][rCount].ToString();
        //            newRow[cCount + 1] = colValue;
        //        }
        //        outputTable.Rows.Add(newRow);
        //    }

        //    return outputTable;
        //}
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
                        wb.Worksheets.Add(ExportFile.CleanZeroText(dsData.Tables[0]));
                        if(ucPivotTable1.newDt.Rows.Count>0)
                            wb.Worksheets.Add(ExportFile.CleanZeroText(ucPivotTable1.newDt));
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

        private void FrmCommonReportAE_Month_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics.frmCommonReportAE_Month = null;
        }
      
        private void dgvData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void OnCellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //if (e.RowIndex < 1 || e.ColumnIndex < 0 )
            //    return;

            //e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
        
            //if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex) )
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
                //if (e.RowIndex == 0)
                //    return;
                if (e.Value+"" == "0") e.Value = "";
                //if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex) )
                //{
                //    e.Value = "";
                //    e.FormattingApplied = true;
                //}
                ////if (e.RowIndex > 0 && e.ColumnIndex == 0)
                ////{
                ////    if (dgvData["SONo", e.RowIndex - 1].Value == e.Value)
                ////        e.Value = "";
                ////    else if (e.RowIndex < dgvData.Rows.Count - 1)
                ////        dgvData.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                ////}
            }
            catch (Exception ex)
            {


            }
        }

        private void txtStartdate_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelectDate(txtStartdate);
        }

        private void txtEnddate_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                Bitmap bm = new Bitmap(this.dgvData.Width, this.dgvData.Height);
                dgvData.DrawToBitmap(bm, new Rectangle(0, 0, this.dgvData.Width, this.dgvData.Height));
                e.Graphics.DrawImage(bm, 0, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtStartdate_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            Find();
        }

        private void txtEnddate_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            Find();
        }

        private void radioGroupAE_countMORef_Year_Click(object sender, EventArgs e)
        {
            try
            {
                radioGroupAE_countMORef_Year.Checked = true;
                comboBoxPeriod.SelectedIndex = comboBoxPeriod.Items.Count - 1;
                Find();
            }
            catch (Exception)
            {
            }
        }

        private void radioGroupAE_countMORef_Year_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioGroupAE_countMORef_Year.Checked)
                {
                    comboBoxPeriod.SelectedIndex = comboBoxPeriod.Items.Count - 1;
                    comboBoxPeriod.Enabled = false;
                }
                else
                {
                    comboBoxPeriod.SelectedIndex = DateTime.Now.Month-1;
                    
                    comboBoxPeriod.Enabled = true;
                }

            }
            catch (Exception)
            {
            }
        }
        private void radioGroupORJobCostYear_Click(object sender, EventArgs e)
        {
            try
            {
                radioGroupORJobCostYear.Checked = true;
                comboBoxPeriod.SelectedIndex = comboBoxPeriod.Items.Count - 1;
                Find();
            }
            catch (Exception)
            {


            }
        }
        private void radioGroupORJobCostYear_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioGroupORJobCostYear.Checked)
                {
                    comboBoxPeriod.SelectedIndex = comboBoxPeriod.Items.Count - 1;
                    comboBoxPeriod.Enabled = false;
                }
                else
                {
                    comboBoxPeriod.SelectedIndex = DateTime.Now.Month-1;

                    comboBoxPeriod.Enabled = true;
                }

            }
            catch (Exception)
            {
            }
        }
        private void radioGroupORJobCostCaseYear_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioGroupORJobCostCaseYear.Checked)
                {
                    comboBoxPeriod.SelectedIndex = comboBoxPeriod.Items.Count - 1;
                    comboBoxPeriod.Enabled = false;
                }
                else
                {
                    comboBoxPeriod.SelectedIndex = DateTime.Now.Month - 1;

                    comboBoxPeriod.Enabled = true;
                }

            }
            catch (Exception)
            {
            }
        }
        private void comboBoxPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if ((comboBoxReport.SelectedValue + "").ToLower().Contains("year") )
                {
                    comboBoxPeriod.SelectedIndex = comboBoxPeriod.Items.Count - 1;
                }
                else if (!(comboBoxReport.SelectedValue + "").ToLower().Contains("year") && comboBoxPeriod.SelectedIndex == comboBoxPeriod.Items.Count - 1)
                {
                    comboBoxPeriod.SelectedIndex = DateTime.Now.Month-1;
                }


            }
            catch (Exception)
            {
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDGV.Print_DataGridView(dgvData);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void radioGroupAE_countMORef_ALL_Click(object sender, EventArgs e)
        {
            Find();
        }

        private void radioGroupAE_countMORef_Click(object sender, EventArgs e)
        {
            Find();
        }

        private void radioGroupAE_countMORef_S_Click(object sender, EventArgs e)
        {
            Find();
        }

        private void radioGroupAEJobcost_Click(object sender, EventArgs e)
        {
            Find();
        }

        private void radioGroupAEJobcostCase_Click(object sender, EventArgs e)
        {
            Find();
        }

        private void radioGroupORJobCostCaseYear_Click(object sender, EventArgs e)
        {
            Find();
        }

     

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PopGridDetail pop = new PopGridDetail();
            pop.PopUpDetail(dgvData, e.ColumnIndex, e.RowIndex,dataDetail);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDGV.Print_DataGridViewA3(dgvData);
            }
            catch (Exception)
            {

            }
        }

        private void comboBoxReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if ((comboBoxReport.SelectedValue + "").ToLower().Contains("year"))
                {
                    comboBoxPeriod.SelectedIndex = comboBoxPeriod.Items.Count - 1;
                }
                else if (!(comboBoxReport.SelectedValue + "").ToLower().Contains("year") && comboBoxPeriod.SelectedIndex == comboBoxPeriod.Items.Count - 1)
                {
                    comboBoxPeriod.SelectedIndex = DateTime.Now.Month - 1;
                }


            }
            catch (Exception)
            {
            }
        }

        private void buttonPrint1_BtnClick()
        {
            try
            {
                PrintDGV.Print_DataGridViewA3(dgvData);
            }
            catch (Exception)
            {

            }
        }
        


       

      

      

     
    
    }
}
