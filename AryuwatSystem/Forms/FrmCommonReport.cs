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
namespace AryuwatSystem.Forms
{
    public partial class FrmCommonReport : DockContent
    {
        bool bind = true;
        private string MedStatus_Code = "";
        private string MedStatus_CodeNew = "";
        private string MedStatus_CodePending = "";
        private string MedStatus_CodeClosed = "";
        DataSet dsData;
        DataTable dtAll = new DataTable();
        DataTable dtTemp = new DataTable();
        public FrmCommonReport()
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
        private void SetColumnAndSize()
        {
            try
            {

                for (int i = 0; i < dgvData.Columns.Count - 1; i++)
                {
                    dgvData.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                //dgvData.Columns[dgvData.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                for (int i = 0; i < dgvData.Columns.Count; i++)
                {
                    int colw = dgvData.Columns[i].Width;
                    dgvData.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvData.Columns[i].Width = colw;
                }
            }
            catch (Exception)
            {
                
               
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

        private void buttonFind_BtnClick()
        {
            try
            {
                lbCount.Text = "";
                BindReport(1);
                //if (bind)
                //    if(radioGroupSO.Checked)
                //    BindReportSO(1);
                //if (radioGroupMO.Checked)
                //    BindReportMO(1);
                //if (radioGroupCN.Checked)
                //    BindReport_RecieptProduct(1);
                //if (radioButtonNewOPD.Checked)
                //    BindReportNewOPD(1);
                //if (radioButtonReciept.Checked)
                //    BindReportReciept(1);
                //if (radioButtonTopCNBuy.Checked)
                //    BindReportOutStanding(1);
                //else
                //{
                //    bind = true;
                //}
                //if (dsData.Tables.Count > 0)
                //{
                //    ucPivotTable1.dt = dsData.Tables[0];
                //    ucPivotTable1.ReloadColumn();
                //}
                //lbCount.Text = string.Format("Count {0}", dgvData.RowCount.ToString("###,###,###"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //public void BindReportSO(int pIntseq)
        //{
        //    try
        //    {
        //        DerUtility.MouseOn(this);
        //        try
        //        {
        //            if (dgvData.Rows.Count > 0)
        //            {
        //                dgvData.DataSource = null;
        //                dgvData.Rows.Clear();
        //            }
        //        }
        //        catch (Exception)
        //        {
                   
        //        }
               
        //        var info = new Entity.Report() { PageNumber = pIntseq };
        //        //Entity.Report custInfo = new Customer();

        //        if (!string.IsNullOrEmpty(txtStartdate.Text.Trim()))
        //        {
        //            info.StartDate = txtStartdate.Text;
        //        }
        //        if (!string.IsNullOrEmpty(txtEnddate.Text.Trim()))
        //        {
        //            info.EndDate =Convert.ToDateTime(txtEnddate.Text)+"";//.AddDays(1)+"";
        //        }
        //        if (!string.IsNullOrEmpty(txtCN.Text.Trim()))
        //        {
        //            info.CN = "%" + txtCN.Text + "%";
        //        }
        //        if (!string.IsNullOrEmpty(txtSO.Text.Trim()))
        //        {
        //            info.SONo = "%" + txtSO.Text + "%";
        //        }
        //        //if (radioGroupSO.Checked)
        //        //{
        //        //    info.SONo = "%" + txtSO.Text + "%";
        //        //}
        //        //if (radioGroupCN.Checked)
        //        //{
        //        //    info.SONo = "%" + txtSO.Text + "%";
        //        //}

        //        MedStatus_CodeNew = checkBoxNew.Checked ? "0" : null;
        //        MedStatus_CodePending = checkBoxPending.Checked ? "1" : null;
        //        MedStatus_CodeClosed = checkBoxClose.Checked ? "2" : null;
        //        info.MedStatus_CodeNew = MedStatus_CodeNew;
        //        info.MedStatus_CodePending = MedStatus_CodePending;
        //        info.MedStatus_CodeClosed = MedStatus_CodeClosed;
        //        info.QueryType = "SEARCHSO";
        //         dsData = new Business.Report().SelectReportPaging(info);
        //        decimal SalePrice = 0;
        //        decimal MS_Price = 0;
        //        decimal Amount = 0;
        //        decimal SpecialPrice = 0;
        //        decimal PriceAfterDis = 0;
        //        decimal DiscountBathByItem = 0;
                
        //        long lngTotalPage = 0;
        //        long lngTotalRecord = 0;
        //        //if (dsData.Tables[0].Rows.Count <= 0)
        //        //{
        //        //    ngbMain.CurrentPage = 0;
        //        //    ngbMain.TotalPage = 0;
        //        //    ngbMain.TotalRecord = 0;
        //        //    ngbMain.Updates();
        //        //    Utility.MouseOff(this);
        //        //    // Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "ไม่พบข้อมูลในระบบ");
        //        //    return;
        //        //}
        //        //DataRow dtotal = dsData.Tables[0].NewRow();
        //        //dtotal["SO"] = "Total";
        //        //dtotal["ราคาขาย"] = dsData.Tables[0].Compute("Sum(ราคาขาย)", "");
        //        //dsData.Tables[0].Rows.Add(dtotal);
        //        //foreach (DataRowView item in dsData.Tables[0].DefaultView)
        //        //{
        //        //    if (item["SONo"] + "" == "") 
        //        //        continue;
        //        //    else
        //        //    {
        //        //        if (item["VN"] + "" != "") 
        //        //            continue;
        //        //    }

        //        //   // SalePrice = item["SalePrice"] + "" == "" ? 0 : Convert.ToDecimal(item["SalePrice"] + "");
        //        //    MS_Price = item["MS_Price"] + "" == "" ? 0 : Convert.ToDecimal(item["MS_Price"] + "");
        //        //    Amount = item["Amount"] + "" == "" ? 0 : Convert.ToDecimal(item["Amount"] + "");
        //        //    SpecialPrice = item["SpecialPrice"] + "" == "" ? 0 : Convert.ToDecimal(item["SpecialPrice"] + "");
        //        //    PriceAfterDis = item["PriceAfterDis"] + "" == "" ? 0 : Convert.ToDecimal(item["PriceAfterDis"] + "");
        //        //    DiscountBathByItem = item["DiscountBathByItem"] + "" == "" ? 0 : Convert.ToDecimal(item["DiscountBathByItem"] + "");
        //        //    var myItems = new[]
        //        //                      {
        //        //                          item["CreateDate"]+""==""?"":String.Format("{0:dd/MM/yyyy}",DateTime.Parse( item["CreateDate"]+"")),
        //        //                          item["SONo"] + "",
        //        //                          "",
        //        //                          item["CN"]+"",
        //        //                           item["HowYouhear"]+"",//HowYouhear
        //        //                          item["FullNameThai"] + ""!=""?item["FullNameThai"] + "":item["FullNameEng"] + "",
        //        //                          item["Age"] + "",
        //        //                          item["Section_Code"] + "",
        //        //                          item["MedicalTab"] + "",
        //        //                          item["MS_Name"] + "",
        //        //                          MS_Price.ToString("###,###,###.##"),
        //        //                          Amount.ToString("###,###,###.##"),
        //        //                          (SpecialPrice).ToString("###,###,###.##"),
        //        //                              (DiscountBathByItem).ToString("###,###,###.##"),
        //        //                          PriceAfterDis.ToString("###,###,###.##"),
        //        //                                  "",
        //        //                          "",
        //        //                          "",
        //        //                          item["MedStatus_Name"] + "",
        //        //                          item["MedStatus_Code"] + "",
        //        //                      item["Consult1"] + "",
        //        //                      item["Consult2"] + ""
        //        //                          //item["KeyMan"] + "",
        //        //                      };
        //        //    dgvData.Rows.Add(myItems);
        //        //    //if (lngTotalPage != 0) continue;
        //        //    //Utility.FindTotalPage(Convert.ToInt32(item["rowTotal"].ToString()), ref lngTotalPage);
        //        //    //lngTotalRecord = Convert.ToInt32(item["rowTotal"].ToString());
        //        //}
        //        dgvData.AutoGenerateColumns = true;
        //        dgvData.DataSource = null;
        //        dgvData.Columns.Clear();
        //        dgvData.DataSource = dsData.Tables[0];
        //        foreach (DataGridViewRow dataRow in dgvData.Rows)
        //        {
        //            MedStatus_Code = dataRow.Cells["MedStatus_Code"].Value+"";

        //            if (MedStatus_Code == "0" || MedStatus_Code == "" || MedStatus_Code == "6")
        //                dataRow.DefaultCellStyle.BackColor = Color.DarkGray;
        //            if (MedStatus_Code == "1" || MedStatus_Code == "7")
        //                dataRow.DefaultCellStyle.BackColor = Color.Khaki;
        //            if (MedStatus_Code == "2" || MedStatus_Code == "8")
        //                dataRow.DefaultCellStyle.BackColor = Color.DarkSeaGreen;
        //            if (MedStatus_Code == "3")
        //                dataRow.DefaultCellStyle.BackColor = Color.LightBlue;
        //        }
        //        //dgvData.Columns["MO"].Visible = false;
        //        //dgvData.Columns["SONo"].Visible = true;
        //        //dgvData.Columns["PayCash"].Visible = false;
        //        //dgvData.Columns["PayCredit"].Visible = false;
        //        //dgvData.Columns["DiscountBathByItem"].Visible = true;

        //        //dgvData.Columns["PayCash"].Visible = false;
        //        //dgvData.Columns["PayCredit"].Visible = false;
                
        //        //dgvData.Columns["HowYouhear"].Visible = true;
        //        //dgvData.Columns["Age"].Visible = true;
        //        //dgvData.Columns["Section_Code"].Visible = false;
        //        //dgvData.Columns["MedicalTab"].Visible = true;
        //        //dgvData.Columns["MS_Name"].Visible = true;
        //        //dgvData.Columns["Amount"].Visible = true;
        //        //dgvData.Columns["SpecialPrice"].Visible = true;
        //        //dgvData.Columns["MS_Price"].Visible = true;
        //        //dgvData.Columns["Balance"].Visible = false;
        //        dgvData.ClearSelection();
        //        foreach (DataGridViewColumn column in dgvData.Columns)
        //        {

        //            dgvData.Columns[column.Name].SortMode = DataGridViewColumnSortMode.Automatic;
        //        }
        //        //ngbMain.CurrentPage = pIntseq;
        //        //ngbMain.TotalPage = lngTotalPage;
        //        //ngbMain.TotalRecord = lngTotalRecord;
        //        //ngbMain.Updates();
        //        DerUtility.MouseOff(this);
        //        SetColumnAndSize();
        //    }
        //    catch (Exception ex)
        //    {
        //        DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
        //        DerUtility.MouseOff(this);
        //        return;
        //    }
        //}

        //private void LoopSumByColumn()
        //{
        //    try 
        //    {
        //        int columnTotalText = 0;
        //        foreach (DataGridViewColumn column in dgvData.Columns)
        //        {
        //            if (column.Visible)
        //            {
        //                if (column.Name.ToLower().Contains("bath") || column.Name.ToLower().Contains("fee") || column.Name.ToLower().Contains("price") || column.Name.ToLower().Contains("ราคา") || column.Name.ToLower().Contains("cash")
        //                    || column.Name.ToLower().Contains("credit") || column.Name.ToLower().Contains("net") || column.Name.ToLower().Contains("total") || column.Name.ToLower().Contains("amount") || column.Name.ToLower().Contains("มูลค่า"))
        //                {
        //                    TotalRow(column.Index);
        //                    if (columnTotalText == 0)
        //                        columnTotalText = column.Index - 1;
        //                }
                       
        //            }
        //        }
        //        for (int i = columnTotalText; i > 0; i--)
        //        {
        //            if (dgvData.Columns[columnTotalText].Visible)
        //                dgvData[columnTotalText, dgvData.RowCount - 1].Value = "Total";
        //            else  columnTotalText--;
        //        }
                
        //    }
        //    catch (Exception ex)
        //    {
        //    MessageBox.Show(ex.Message);
        //    }
        //}
        //private void TotalRow(int cindex)
        //{
        //    try
        //    {
        //        double sum = 0;

        //        dgvData[cindex, dgvData.RowCount - 1].Value = sum.ToString("###,###,###.##");
        //        //dgvData[0, dgvData.RowCount - 1].Value = "Total";

        //        foreach (DataGridViewRow item in dgvData.Rows)
        //        {
        //            sum += item.Cells[cindex].Value + "" == "" ? 0 : Convert.ToDouble(item.Cells[cindex].Value);
        //        }

        //        //DataRow dr = dtAll.NewRow();
        //        //dgvData.Rows.Add(dr);
        //        dgvData[cindex, dgvData.RowCount - 1].Value = sum.ToString("###,###,###.##");
        //        //dgvData[1, dgvData.RowCount - 1].Value = "Total";

        //        DataGridViewCellStyle style = new DataGridViewCellStyle();
        //        style.Font = new Font(dgvData.Font, FontStyle.Bold);
        //        dgvData.Rows[dgvData.Rows.Count - 1].DefaultCellStyle = style;
        //        dgvData.Rows[dgvData.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Yellow;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        public void BindReport(int pIntseq)
        {
            try
            {
                DerUtility.MouseOn(this);
                dgvData.Columns.Clear();
                dgvData.AutoGenerateColumns = true;
                //dataGridViewGrouperControl1.Grouper.ResetGrouping();
                try
                {
                    if (dgvData.Rows.Count > 0)
                    {
                        dgvData.DataSource = null;
                        dgvData.Rows.Clear();
                    }
                }
                catch (Exception)
                {

                }
               
                var info = new Entity.Report() { PageNumber = pIntseq };
                //Entity.Report custInfo = new Customer();

                if (!string.IsNullOrEmpty(txtStartdate.Text.Trim()))
                {
                    info.StartDate = txtStartdate.Text;
                }
                if (!string.IsNullOrEmpty(txtEnddate.Text.Trim()))
                {
                    info.EndDate = Convert.ToDateTime(txtEnddate.Text) + "";//.AddDays(1)+"";
                }
                if (!string.IsNullOrEmpty(txtCN.Text.Trim()))
                {
                    info.CN = "%" + txtCN.Text + "%";
                }
                if (!string.IsNullOrEmpty(txtSO.Text.Trim()))
                {
                    info.SONo = "%" + txtSO.Text + "%";
                }
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
                info.BranchId = uBranch1.BranchId;

                lbCount.Text = "";
                if (bind)
                {
                    if (radioGroupSO.Checked)
                        info.QueryType = "SEARCHSO";
                    else if (radioGroupMO.Checked)
                        info.QueryType = "SEARCHMO";
                    else if (radioGroupCN.Checked)
                        info.QueryType = "SEARCHRECIEPT_Product";
                    else if (radioButtonNewOPD.Checked)
                        info.QueryType = "SEARCHNEWOPD";
                    else if (radioButtonReciept.Checked)
                        info.QueryType = "SEARCHRECIEPT";
                    else if (radioButtonTopCNBuy.Checked)
                        info.QueryType = "SEARCH_TopCNBuy";
                }
                else
                {
                    bind = true;
                }

                dsData = new Business.Report().SelectReportPaging(info);
                 dtAll = dsData.Tables[0];
                 DataRow dr = dtAll.NewRow();
                 //dgvData[dgvData.Columns["NetAmount"].Index, dgvData.RowCount].Value = sum.ToString("###,###,###.##");
                 //dr["CustomerNameEng"] = "Total";
                 if (dtAll.Columns.Contains("_RowString"))
                 dr["_RowString"] = "Total";
                
                 dtAll.Rows.Add(dr);
                 dgvData.DataSource = dtAll;
             
                //DataColumn dcRowString = dtAll.Columns.Add("_RowString", typeof(string));
                //foreach (DataRow dataRow in dtAll.Rows)
                //{
                //    StringBuilder sb = new StringBuilder();
                //    for (int i = 0; i < dtAll.Columns.Count - 1; i++)
                //    {
                //        //if (dtAll.Columns[i].ColumnName == ("SONo") || dtAll.Columns[i].ColumnName == ("Status") || dtAll.Columns[i].ColumnName == ("CN")
                //        //    || dtAll.Columns[i].ColumnName == ("CustomerName") || dtAll.Columns[i].ColumnName == ("CustomerNameEng") || dtAll.Columns[i].ColumnName == ("gender")
                //        //    || dtAll.Columns[i].ColumnName == ("Mobile") || dtAll.Columns[i].ColumnName == ("MS_Name") || dtAll.Columns[i].ColumnName == ("HowYouhear") || dtAll.Columns[i].ColumnName == ("Consult"))
                //        if (dtAll.Columns[i].ColumnName == ("SONo") || dtAll.Columns[i].ColumnName == ("VN") || dtAll.Columns[i].ColumnName == ("CN")
                //           || dtAll.Columns[i].ColumnName == ("CustomerName") || dtAll.Columns[i].ColumnName == ("CustomerNameEng") 
                //           || dtAll.Columns[i].ColumnName == ("MS_Name") || dtAll.Columns[i].ColumnName == ("HowYouhear") || dtAll.Columns[i].ColumnName == ("Consult"))
                //        {
                //            sb.Append(dataRow[i].ToString());
                //            sb.Append("\t");
                //        }
                //    }
                //    dataRow[dcRowString] = sb.ToString();
                //}

                if (dsData.Tables.Count > 0)
                {
                    ucPivotTable1.dt = dsData.Tables[0];
                    ucPivotTable1.ReloadColumn();
                }
                lbCount.Text = string.Format("Count {0}", dgvData.RowCount.ToString("###,###,###"));


                if (dgvData.Columns.Contains("MedStatus_Code"))
                {
                    foreach (DataGridViewRow dataRow in dgvData.Rows)
                    {
                        
                        MedStatus_Code = dataRow.Cells["MedStatus_Code"].Value + "";

                        if (MedStatus_Code == "0" || MedStatus_Code == "" || MedStatus_Code == "6")
                            dataRow.DefaultCellStyle.BackColor = Color.DarkGray;
                        if (MedStatus_Code == "1" || MedStatus_Code == "7")
                            dataRow.DefaultCellStyle.BackColor = Color.Khaki;
                        if (MedStatus_Code == "2" || MedStatus_Code == "8")
                            dataRow.DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                        if (MedStatus_Code == "3")
                            dataRow.DefaultCellStyle.BackColor = Color.LightBlue;
                    }
                    dgvData.Columns["MedStatus_Code"].Visible = false;
                }

                ////LoopSumByColumn();
                DataGridViewUtil.LoopSumByColumn(dgvData,false);
                

                if (dgvData.Columns.Contains("_RowString"))
                {
                    dgvData.Columns["_RowString"].Visible = false;
                }
                
                        dgvData.ClearSelection();
                foreach (DataGridViewColumn column in dgvData.Columns)
                {

                    dgvData.Columns[column.Name].SortMode = DataGridViewColumnSortMode.Automatic;
                }
                for (int i = 0; i < dgvData.Columns.Count; i++)
                {
                    if (dgvData.Columns[i].Name.ToLower().Contains("price") || dgvData.Columns[i].Name.ToLower().Contains("จำนวน") || dgvData.Columns[i].Name.ToLower().Contains("ราคา") || dgvData.Columns[i].Name.ToLower().Contains("เฉลี่ย") || dgvData.Columns[i].Name.ToLower().Contains("quan") || dgvData.Columns[i].Name.ToLower().Contains("ค่า")
                        || dgvData.Columns[i].Name.ToLower().Contains("เงิน") || dgvData.Columns[i].Name.ToLower().Contains("ยอด") || dgvData.Columns[i].Name.ToLower().Contains("มูลค่า") || dgvData.Columns[i].Name.ToLower().Contains("amount"))
                        dgvData.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                //ngbMain.CurrentPage = pIntseq;
                //ngbMain.TotalPage = lngTotalPage;
                //ngbMain.TotalRecord = lngTotalRecord;
                //ngbMain.Updates();
             
                DerUtility.MouseOff(this);
                SetColumnAndSize();
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
        }
        public void BindReportSO(int pIntseq)
        {
            try
            {
                DerUtility.MouseOn(this);
                try
                {
                    if (dgvData.Rows.Count > 0)
                    {
                        dgvData.DataSource = null;
                        dgvData.Rows.Clear();
                    }
                }
                catch (Exception)
                {

                }

                var info = new Entity.Report() { PageNumber = pIntseq };
                //Entity.Report custInfo = new Customer();

                if (!string.IsNullOrEmpty(txtStartdate.Text.Trim()))
                {
                    info.StartDate = txtStartdate.Text;
                }
                if (!string.IsNullOrEmpty(txtEnddate.Text.Trim()))
                {
                    info.EndDate = Convert.ToDateTime(txtEnddate.Text) + "";//.AddDays(1)+"";
                }
                if (!string.IsNullOrEmpty(txtCN.Text.Trim()))
                {
                    info.CN = "%" + txtCN.Text + "%";
                }
                if (!string.IsNullOrEmpty(txtSO.Text.Trim()))
                {
                    info.SONo = "%" + txtSO.Text + "%";
                }
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
                info.QueryType = "SEARCHSO";
                dsData = new Business.Report().SelectReportPaging(info);
                decimal SalePrice = 0;
                decimal MS_Price = 0;
                decimal Amount = 0;
                decimal SpecialPrice = 0;
                decimal PriceAfterDis = 0;
                decimal DiscountBathByItem = 0;

                long lngTotalPage = 0;
                long lngTotalRecord = 0;
                //if (dsData.Tables[0].Rows.Count <= 0)
                //{
                //    ngbMain.CurrentPage = 0;
                //    ngbMain.TotalPage = 0;
                //    ngbMain.TotalRecord = 0;
                //    ngbMain.Updates();
                //    Utility.MouseOff(this);
                //    // Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "ไม่พบข้อมูลในระบบ");
                //    return;
                //}
                DataRow dtotal = dsData.Tables[0].NewRow();
                dtotal["SONo"] = "Total";
                dtotal["PriceAfterDis"] = dsData.Tables[0].Compute("Sum(PriceAfterDis)", "");
                dsData.Tables[0].Rows.Add(dtotal);
                foreach (DataRowView item in dsData.Tables[0].DefaultView)
                {
                    if (item["SONo"] + "" == "")
                        continue;
                    else
                    {
                        if (item["VN"] + "" != "")
                            continue;
                    }

                    // SalePrice = item["SalePrice"] + "" == "" ? 0 : Convert.ToDecimal(item["SalePrice"] + "");
                    MS_Price = item["MS_Price"] + "" == "" ? 0 : Convert.ToDecimal(item["MS_Price"] + "");
                    Amount = item["Amount"] + "" == "" ? 0 : Convert.ToDecimal(item["Amount"] + "");
                    SpecialPrice = item["SpecialPrice"] + "" == "" ? 0 : Convert.ToDecimal(item["SpecialPrice"] + "");
                    PriceAfterDis = item["PriceAfterDis"] + "" == "" ? 0 : Convert.ToDecimal(item["PriceAfterDis"] + "");
                    DiscountBathByItem = item["DiscountBathByItem"] + "" == "" ? 0 : Convert.ToDecimal(item["DiscountBathByItem"] + "");
                    var myItems = new[]
                                      {
                                          item["CreateDate"]+""==""?"":String.Format("{0:dd/MM/yyyy}",DateTime.Parse( item["CreateDate"]+"")),
                                          item["SONo"] + "",
                                          "",
                                          item["CN"]+"",
                                           item["HowYouhear"]+"",//HowYouhear
                                          item["FullNameThai"] + ""!=""?item["FullNameThai"] + "":item["FullNameEng"] + "",
                                          item["Age"] + "",
                                          item["Section_Code"] + "",
                                          item["MedicalTab"] + "",
                                          item["MS_Name"] + "",
                                          MS_Price.ToString("###,###,###.##"),
                                          Amount.ToString("###,###,###.##"),
                                          (SpecialPrice).ToString("###,###,###.##"),
                                              (DiscountBathByItem).ToString("###,###,###.##"),
                                          PriceAfterDis.ToString("###,###,###.##"),
                                                  "",
                                          "",
                                          "",
                                          item["MedStatus_Name"] + "",
                                          item["MedStatus_Code"] + "",
                                    
                                          item["KeyMan"] + ""
                                      };
                    dgvData.Rows.Add(myItems);
                    //if (lngTotalPage != 0) continue;
                    //Utility.FindTotalPage(Convert.ToInt32(item["rowTotal"].ToString()), ref lngTotalPage);
                    //lngTotalRecord = Convert.ToInt32(item["rowTotal"].ToString());
                }

                foreach (DataGridViewRow dataRow in dgvData.Rows)
                {
                    MedStatus_Code = dataRow.Cells["MedStatusCode"].Value + "";

                    if (MedStatus_Code == "0" || MedStatus_Code == "" || MedStatus_Code == "6")
                        dataRow.DefaultCellStyle.BackColor = Color.DarkGray;
                    if (MedStatus_Code == "1" || MedStatus_Code == "7")
                        dataRow.DefaultCellStyle.BackColor = Color.Khaki;
                    if (MedStatus_Code == "2" || MedStatus_Code == "8")
                        dataRow.DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                    if (MedStatus_Code == "3")
                        dataRow.DefaultCellStyle.BackColor = Color.LightBlue;
                }
                dgvData.Columns["MO"].Visible = false;
                dgvData.Columns["SONo"].Visible = true;
                dgvData.Columns["PayCash"].Visible = false;
                dgvData.Columns["PayCredit"].Visible = false;
                dgvData.Columns["DiscountBathByItem"].Visible = true;

                dgvData.Columns["PayCash"].Visible = false;
                dgvData.Columns["PayCredit"].Visible = false;

                dgvData.Columns["HowYouhear"].Visible = true;
                dgvData.Columns["Age"].Visible = true;
                dgvData.Columns["Section_Code"].Visible = false;
                dgvData.Columns["MedicalTab"].Visible = true;
                dgvData.Columns["MS_Name"].Visible = true;
                dgvData.Columns["Amount"].Visible = true;
                dgvData.Columns["SpecialPrice"].Visible = true;
                dgvData.Columns["MS_Price"].Visible = true;
                dgvData.Columns["Balance"].Visible = false;
                dgvData.ClearSelection();
                foreach (DataGridViewColumn column in dgvData.Columns)
                {

                    dgvData.Columns[column.Name].SortMode = DataGridViewColumnSortMode.Automatic;
                }
                //ngbMain.CurrentPage = pIntseq;
                //ngbMain.TotalPage = lngTotalPage;
                //ngbMain.TotalRecord = lngTotalRecord;
                //ngbMain.Updates();
                DerUtility.MouseOff(this);
                SetColumnAndSize();
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
        }
        public void BindReportMO(int pIntseq)
        {
            try
            {
                DerUtility.MouseOn(this);
                try
                {
                    if (dgvData.Rows.Count > 0)
                    {
                        dgvData.DataSource = null;
                        dgvData.Rows.Clear();
                    }
                }
                catch (Exception)
                {

                }
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
                if (!string.IsNullOrEmpty(txtCN.Text.Trim()))
                {
                    info.CN = "%" + txtCN.Text + "%";
                }
                if (!string.IsNullOrEmpty(txtSO.Text.Trim()))
                {
                    info.SONo = "%" + txtSO.Text + "%";
                }
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
                info.QueryType = "SEARCHMO";
                dsData = new Business.Report().SelectReportPaging(info);
                decimal SalePrice = 0;
                decimal MS_Price = 0;
                decimal Amount = 0;
                decimal SpecialPrice = 0;
                decimal PriceAfterDis = 0;
                decimal DiscountBathByItem = 0;

                long lngTotalPage = 0;
                long lngTotalRecord = 0;
                //if (dsData.Tables[0].Rows.Count <= 0)
                //{
                //    ngbMain.CurrentPage = 0;
                //    ngbMain.TotalPage = 0;
                //    ngbMain.TotalRecord = 0;
                //    ngbMain.Updates();
                //    Utility.MouseOff(this);
                //    // Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "ไม่พบข้อมูลในระบบ");
                //    return;
                //}

                DataRow dtotal = dsData.Tables[0].NewRow();
                dtotal["SONo"] = "Total";
                dtotal["PriceAfterDis"] = dsData.Tables[0].Compute("Sum(PriceAfterDis)", "");
                dsData.Tables[0].Rows.Add(dtotal);
                foreach (DataRowView item in dsData.Tables[0].DefaultView)
                {
                    if (item["SONo"] + "" == "" )
                        continue;
                    else
                    {
                        if (item["VN"] + "" == "")
                            continue;
                    }

                    // SalePrice = item["SalePrice"] + "" == "" ? 0 : Convert.ToDecimal(item["SalePrice"] + "");
                    MS_Price = item["MS_Price"] + "" == "" ? 0 : Convert.ToDecimal(item["MS_Price"] + "");
                    Amount = item["Amount"] + "" == "" ? 0 : Convert.ToDecimal(item["Amount"] + "");
                    SpecialPrice = item["SpecialPrice"] + "" == "" ? 0 : Convert.ToDecimal(item["SpecialPrice"] + "");
                    PriceAfterDis = item["PriceAfterDis"] + "" == "" ? 0 : Convert.ToDecimal(item["PriceAfterDis"] + "");
                    DiscountBathByItem = item["DiscountBathByItem"] + "" == "" ? 0 : Convert.ToDecimal(item["DiscountBathByItem"] + "");
                    var myItems = new[]
                                      {
                                         item["CreateDate"]+""==""?"": String.Format("{0:dd/MM/yyyy}",DateTime.Parse( item["CreateDate"]+"")),
                                          item["SONo"] + "",
                                          item["VN"] + "",
                                          item["CN"]+"",
                                           item["HowYouhear"]+"",//HowYouhear
                                          item["FullNameThai"] + ""!=""?item["FullNameThai"] + "":item["FullNameEng"] + "",
                                          item["Age"] + "",
                                          item["Section_Code"] + "",
                                          item["MedicalTab"] + "",
                                          item["MS_Name"] + "",
                                          MS_Price.ToString("###,###,###.##"),
                                          Amount.ToString("###,###,###.##"),
                                          (SpecialPrice).ToString("###,###,###.##"),
                                              (DiscountBathByItem).ToString("###,###,###.##"),
                                          PriceAfterDis.ToString("###,###,###.##"),
                                            "",
                                          "",
                                          "",
                                          item["MedStatus_Name"] + "",
                                          item["MedStatus_Code"] + "",

                                          item["KeyMan"] + "",
                                      };
                    dgvData.Rows.Add(myItems);
                    //if (lngTotalPage != 0) continue;
                    //Utility.FindTotalPage(Convert.ToInt32(item["rowTotal"].ToString()), ref lngTotalPage);
                    //lngTotalRecord = Convert.ToInt32(item["rowTotal"].ToString());
                }
                foreach (DataGridViewRow dataRow in dgvData.Rows)
                {
                    MedStatus_Code = dataRow.Cells["MedStatusCode"].Value + "";

                    if (MedStatus_Code == "0" || MedStatus_Code == "" || MedStatus_Code == "6")
                        dataRow.DefaultCellStyle.BackColor = Color.DarkGray;
                    if (MedStatus_Code == "1" || MedStatus_Code == "7")
                        dataRow.DefaultCellStyle.BackColor = Color.Khaki;
                    if (MedStatus_Code == "2" || MedStatus_Code == "8")
                        dataRow.DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                    if (MedStatus_Code == "3")
                        dataRow.DefaultCellStyle.BackColor = Color.LightBlue;
                }
                dgvData.Columns["SONo"].Visible = true;
                dgvData.Columns["MO"].Visible = true;
                dgvData.Columns["PayCash"].Visible = false;
                dgvData.Columns["PayCredit"].Visible = false;
                dgvData.Columns["DiscountBathByItem"].Visible = false;

                dgvData.Columns["PayCash"].Visible = false;
                dgvData.Columns["PayCredit"].Visible = false;
                dgvData.Columns["DiscountBathByItem"].Visible = false;
                dgvData.Columns["HowYouhear"].Visible = true;
                dgvData.Columns["Age"].Visible = true;
                dgvData.Columns["Section_Code"].Visible = false;
                dgvData.Columns["MedicalTab"].Visible = true;
                dgvData.Columns["MS_Name"].Visible = true;
                dgvData.Columns["Amount"].Visible = true;
                dgvData.Columns["SpecialPrice"].Visible = true;
                dgvData.Columns["MS_Price"].Visible = true;
                dgvData.Columns["Balance"].Visible = false;
                dgvData.ClearSelection();
                foreach (DataGridViewColumn column in dgvData.Columns)
                {

                    dgvData.Columns[column.Name].SortMode = DataGridViewColumnSortMode.Automatic;
                }
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
            SetColumnAndSize();
        }
        public void BindReportReciept(int pIntseq)
        {
            try
            {
                DerUtility.MouseOn(this);
                try
                {
                    dgvData.Columns.Clear();
                    if (dgvData.Rows.Count > 0)
                    {
                        dgvData.DataSource = null;
                        dgvData.Rows.Clear();
                    }
                }
                catch (Exception)
                {

                }
                var info = new Entity.Report() { PageNumber = pIntseq };
                //Entity.Report custInfo = new Customer();

                if (!string.IsNullOrEmpty(txtStartdate.Text.Trim()))
                {
                    info.StartDate = txtStartdate.Text;
                }
                if (!string.IsNullOrEmpty(txtEnddate.Text.Trim()))
                {
                    info.EndDate = Convert.ToDateTime(txtEnddate.Text)+"";//.AddDays(1) + "";
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
                info.QueryType = "SEARCHRECIEPT";
                dsData = new Business.Report().SelectReportPaging(info);
                decimal SalePrice = 0;
                decimal MS_Price = 0;
                decimal Amount = 0;
                decimal SpecialPrice = 0;
                decimal PriceAfterDis = 0;
                decimal DiscountBathByItem = 0;

                //this.olvColumn41.ImageGetter = delegate(object row) { return "user"; };
                //this.olvDataTree.RootKeyValue = 0u;
                //this.olvDataTree.DataMember = "Table";
                //this.olvDataTree.DataSource = new DataViewManager(dsData);
                
                // This does a better job of auto sizing the columns
                //DataSet ds = LoadDatasetFromXml(@"E:\Clinic\CodeBase\ObjectListViewFull-2.9.1\ObjectListViewDemo\Demo\Data\FamilyTree.xml");


                //this.olvDataTree.DataMember = "Person";
                //this.olvDataTree.DataSource = new DataViewManager(ds);

                //this.olvDataTree.AutoResizeColumns();

                long lngTotalPage = 0;
                long lngTotalRecord = 0;
                //if (dsData.Tables[0].Rows.Count <= 0)
                //{
                //    ngbMain.CurrentPage = 0;
                //    ngbMain.TotalPage = 0;
                //    ngbMain.TotalRecord = 0;
                //    ngbMain.Updates();
                //    Utility.MouseOff(this);
                //    // Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "ไม่พบข้อมูลในระบบ");
                //    return;
                //}
                DataRow dtotal = dsData.Tables[0].NewRow();
                dtotal["SONo"] = "Total";
                dtotal["PriceAfterDis"] = dsData.Tables[0].Compute("Sum(PriceAfterDis)", "");
                dtotal["PayCash"] = dsData.Tables[0].Compute("Sum(PayCash)", "");
                dtotal["PayCredit"] = dsData.Tables[0].Compute("Sum(PayCredit)", "");
                dtotal["TotalReciept"] = dsData.Tables[0].Compute("Sum(TotalReciept)", "");
                dsData.Tables[0].Rows.Add(dtotal);
                //foreach (DataRowView item in dsData.Tables[0].DefaultView)
                //{
                //    if (item["SONo"] + "" == "")
                //        continue;
                //    else
                //    {
                //      //  if (item["VN"] + "" == "")
                //           // continue;
                //    }
                //    decimal PayCash = 0;
                //    decimal PayCredit = 0;
                //    decimal Balance = 0;
                //    // SalePrice = item["SalePrice"] + "" == "" ? 0 : Convert.ToDecimal(item["SalePrice"] + "");
                //    //MS_Price = item["MS_Price"] + "" == "" ? 0 : Convert.ToDecimal(item["MS_Price"] + "");
                //    //Amount = item["Amount"] + "" == "" ? 0 : Convert.ToDecimal(item["Amount"] + "");
                //    //SpecialPrice = item["SpecialPrice"] + "" == "" ? 0 : Convert.ToDecimal(item["SpecialPrice"] + "");
                //    PriceAfterDis = item["PriceAfterDis"] + "" == "" ? 0 : Convert.ToDecimal(item["PriceAfterDis"] + "");
                //    PayCash = item["PayCash"] + "" == "" ? 0 : Convert.ToDecimal(item["PayCash"] + "");
                //    PayCredit = item["PayCredit"] + "" == "" ? 0 : Convert.ToDecimal(item["PayCredit"] + "");
                //    Balance = item["TotalReciept"] + "" == "" ? 0 : Convert.ToDecimal(item["TotalReciept"] + ""); // PriceAfterDis - (PayCash + PayCredit);
                //    //DiscountBathByItem = item["DiscountBathByItem"] + "" == "" ? 0 : Convert.ToDecimal(item["DiscountBathByItem"] + "");
                //    var myItems = new[]
                //                      {
                //                          item["UpdateDate"]+""==""?"": String.Format("{0:dd/MM/yyyy}",DateTime.Parse( item["UpdateDate"]+"")),
                //                          item["SONo"] + "",
                //                          item["CN"]+"",
                //                          item["FullNameThai"] + ""!=""?item["FullNameThai"] + "":item["FullNameEng"] + "",
                //                          PriceAfterDis.ToString("###,###,###.##"),//PriceAfterDis
                //                          PayCash.ToString("###,###,###.##"),
                //                          PayCredit.ToString("###,###,###.##"),
                //                          Balance==0?"0":Balance.ToString("###,###,###.##"),
                //                          item["MedStatus_Name"] + "",
                //                          item["MedStatus_Code"] + "",
                //                          item["KeyMan"] + "",
                //                      };
                //    dgvData.Rows.Add(myItems);
                //    //if (lngTotalPage != 0) continue;
                //    //Utility.FindTotalPage(Convert.ToInt32(item["rowTotal"].ToString()), ref lngTotalPage);
                //    //lngTotalRecord = Convert.ToInt32(item["rowTotal"].ToString());
                //}
                dgvData.AutoGenerateColumns = true;
                dgvData.DataSource = dsData.Tables[0];
            
                foreach (DataGridViewRow dataRow in dgvData.Rows)
                {
                    MedStatus_Code = dataRow.Cells["MedStatus_Code"].Value + "";

                    if (MedStatus_Code == "0" || MedStatus_Code == "" || MedStatus_Code == "6")
                        dataRow.DefaultCellStyle.BackColor = Color.DarkGray;
                    if (MedStatus_Code == "1" || MedStatus_Code == "7")
                        dataRow.DefaultCellStyle.BackColor = Color.Khaki;
                    if (MedStatus_Code == "2" || MedStatus_Code == "8")
                        dataRow.DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                    if (MedStatus_Code == "3")
                        dataRow.DefaultCellStyle.BackColor = Color.LightBlue;
                }



                //dgvData.Columns["SONo"].Visible = true;
                //dgvData.Columns["PayCash"].Visible = true;
                //dgvData.Columns["PayCredit"].Visible = true;

                //dgvData.Columns["DiscountBathByItem"].Visible = false;
                //dgvData.Columns["HowYouhear"].Visible = false;
         
                //dgvData.Columns["Age"].Visible = false;
                //dgvData.Columns["Section_Code"].Visible = false;
                //dgvData.Columns["MedicalTab"].Visible = false;
                //dgvData.Columns["MS_Name"].Visible = false;
                //dgvData.Columns["Amount"].Visible = false;
                //dgvData.Columns["SpecialPrice"].Visible = false;
                //dgvData.Columns["MS_Price"].Visible = false;
                //dgvData.Columns["MO"].Visible = false;

                //dgvData.Columns["TotalReciept"].Visible = true;
                //dgvData.Columns["TotalReciept"].HeaderText = "TotalReciept";
                
                

                dgvData.ClearSelection();
                foreach (DataGridViewColumn column in dgvData.Columns)
                {

                    dgvData.Columns[column.Name].SortMode = DataGridViewColumnSortMode.Automatic;
                }
                //ngbMain.CurrentPage = pIntseq;
                //ngbMain.TotalPage = lngTotalPage;
                //ngbMain.TotalRecord = lngTotalRecord;
                //ngbMain.Updates();
                DerUtility.MouseOff(this);
                SetColumnAndSize();
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
        }
        public void BindReportNewOPD(int pIntseq)
        {
            try
            {
                DerUtility.MouseOn(this);
                try
                {
                    if (dgvData.Rows.Count > 0)
                    {
                        dgvData.DataSource = null;
                        dgvData.Rows.Clear();
                    }
                }
                catch (Exception)
                {

                }
                var info = new Entity.Report() { PageNumber = pIntseq };
                //Entity.Report custInfo = new Customer();

                if (!string.IsNullOrEmpty(txtStartdate.Text.Trim()))
                {
                    info.StartDate = txtStartdate.Text;
                }
                if (!string.IsNullOrEmpty(txtEnddate.Text.Trim()))
                {
                    info.EndDate = Convert.ToDateTime(txtEnddate.Text)+"";//.AddDays(1) + "";
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
                info.QueryType = "SEARCHNEWOPD";
                dsData = new Business.Report().SelectReportPaging(info);
                decimal SalePrice = 0;
                decimal MS_Price = 0;
                decimal Amount = 0;
                decimal SpecialPrice = 0;
                decimal PriceAfterDis = 0;
                decimal DiscountBathByItem = 0;

                //this.olvColumn41.ImageGetter = delegate(object row) { return "user"; };
                //this.olvDataTree.RootKeyValue = 0u;
                //this.olvDataTree.DataMember = "Table";
                //this.olvDataTree.DataSource = new DataViewManager(dsData);

                // This does a better job of auto sizing the columns
                //DataSet ds = LoadDatasetFromXml(@"E:\Clinic\CodeBase\ObjectListViewFull-2.9.1\ObjectListViewDemo\Demo\Data\FamilyTree.xml");


                //this.olvDataTree.DataMember = "Person";
                //this.olvDataTree.DataSource = new DataViewManager(ds);

                //this.olvDataTree.AutoResizeColumns();

                long lngTotalPage = 0;
                long lngTotalRecord = 0;
                if (dsData.Tables[0].Rows.Count <= 0)
                {
                    //ngbMain.CurrentPage = 0;
                    //ngbMain.TotalPage = 0;
                    //ngbMain.TotalRecord = 0;
                    //ngbMain.Updates();
                    DerUtility.MouseOff(this);
                    // Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "ไม่พบข้อมูลในระบบ");
                    return;
                }
                DataRow dtotal = dsData.Tables[0].NewRow();
                try
                {
                    dtotal["SONo"] = "Total";
                    object oo= dsData.Tables[0].Compute("Sum(PriceAfterDis)", "");
                    dtotal["PriceAfterDis"] = dsData.Tables[0].Compute("Sum(PriceAfterDis)", "");
                }
                catch (Exception)
                {

                    dtotal["PriceAfterDis"] = 0;
                }
                dsData.Tables[0].Rows.Add(dtotal);

                foreach (DataRowView item in dsData.Tables[0].DefaultView)
                {
                    if (item["SONo"] + "" == "")
                        continue;
                    else
                    {
                        if (item["VN"] + "" == "")
                            continue;
                    }

                    // SalePrice = item["SalePrice"] + "" == "" ? 0 : Convert.ToDecimal(item["SalePrice"] + "");
                    MS_Price = item["MS_Price"] + "" == "" ? 0 : Convert.ToDecimal(item["MS_Price"] + "");
                    Amount = item["Amount"] + "" == "" ? 0 : Convert.ToDecimal(item["Amount"] + "");
                    SpecialPrice = item["SpecialPrice"] + "" == "" ? 0 : Convert.ToDecimal(item["SpecialPrice"] + "");
                    PriceAfterDis = item["PriceAfterDis"] + "" == "" ? 0 : Convert.ToDecimal(item["PriceAfterDis"] + "");
                    DiscountBathByItem = item["DiscountBathByItem"] + "" == "" ? 0 : Convert.ToDecimal(item["DiscountBathByItem"] + "");
                    var myItems = new[]
                                      {
                                          item["UpdateDate"]+""==""?"": String.Format("{0:dd/MM/yyyy}",DateTime.Parse( item["UpdateDate"]+"")),
                                          item["SONo"] + "",
                                          item["VN"] + "",
                                          item["CN"]+"",
                                          item["HowYouhear"]+"",//HowYouhear
                                          item["FullNameThai"] + ""!=""?item["FullNameThai"] + "":item["FullNameEng"] + "",
                                          item["Age"] + "",
                                          item["Section_Code"] + "",
                                          item["MedicalTab"] + "",
                                          item["MS_Name"] + "",
                                          MS_Price.ToString("###,###,###.##"),
                                          Amount.ToString("###,###,###.##"),
                                          (SpecialPrice).ToString("###,###,###.##"),
                                              (DiscountBathByItem).ToString("###,###,###.##"),
                                          PriceAfterDis.ToString("###,###,###.##"),
                                                  "",
                                          "",
                                          "",
                                          item["MedStatus_Name"] + "",
                                          item["MedStatus_Code"] + "",
                                      
                                          item["KeyMan"] + "",
                                      };
                    dgvData.Rows.Add(myItems);
                    //if (lngTotalPage != 0) continue;
                    //Utility.FindTotalPage(Convert.ToInt32(item["rowTotal"].ToString()), ref lngTotalPage);
                    //lngTotalRecord = Convert.ToInt32(item["rowTotal"].ToString());
                }
                foreach (DataGridViewRow dataRow in dgvData.Rows)
                {
                    MedStatus_Code = dataRow.Cells["MedStatusCode"].Value + "";

                    if (MedStatus_Code == "0" || MedStatus_Code == "" || MedStatus_Code == "6")
                        dataRow.DefaultCellStyle.BackColor = Color.DarkGray;
                    if (MedStatus_Code == "1" || MedStatus_Code == "7")
                        dataRow.DefaultCellStyle.BackColor = Color.Khaki;
                    if (MedStatus_Code == "2" || MedStatus_Code == "8")
                        dataRow.DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                    if (MedStatus_Code == "3")
                        dataRow.DefaultCellStyle.BackColor = Color.LightBlue;
                }
                dgvData.Columns["SONo"].Visible = true;
                dgvData.Columns["MO"].Visible = true;
                dgvData.Columns["PayCash"].Visible = false;
                dgvData.Columns["PayCredit"].Visible = false;
                dgvData.Columns["DiscountBathByItem"].Visible = false;
                dgvData.Columns["HowYouhear"].Visible = true;

    
          
      
                dgvData.Columns["Age"].Visible = true;
                dgvData.Columns["Section_Code"].Visible = false;
                dgvData.Columns["MedicalTab"].Visible = true;
                dgvData.Columns["MS_Name"].Visible = true;
                dgvData.Columns["Amount"].Visible = true;
                dgvData.Columns["SpecialPrice"].Visible = true;
                dgvData.Columns["MS_Price"].Visible = true;
                dgvData.Columns["Balance"].Visible = false;
                dgvData.ClearSelection();
                foreach (DataGridViewColumn column in dgvData.Columns)
                {

                    dgvData.Columns[column.Name].SortMode = DataGridViewColumnSortMode.Automatic;
                }
                //ngbMain.CurrentPage = pIntseq;
                //ngbMain.TotalPage = lngTotalPage;
                //ngbMain.TotalRecord = lngTotalRecord;
                //ngbMain.Updates();
                DerUtility.MouseOff(this);
                SetColumnAndSize();
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
        }
        public void BindReport_RecieptProduct(int pIntseq)
        {
            try
            {
                DerUtility.MouseOn(this);
                try
                {
                    if (dgvData.Rows.Count > 0)
                    {
                        dgvData.DataSource = null;
                        dgvData.Rows.Clear();
                    }
                }
                catch (Exception)
                {

                }
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
                info.QueryType = "SEARCHRECIEPT_Product";
                dsData = new Business.Report().SelectReportPaging(info);
                decimal SalePrice = 0;
                decimal MS_Price = 0;
                decimal Amount = 0;
                decimal SpecialPrice = 0;
                decimal PriceAfterDis = 0;
                decimal DiscountBathByItem = 0;

                //this.olvColumn41.ImageGetter = delegate(object row) { return "user"; };
                //this.olvDataTree.RootKeyValue = 0u;
                //this.olvDataTree.DataMember = "Table";
                //this.olvDataTree.DataSource = new DataViewManager(dsData);

                // This does a better job of auto sizing the columns
                //DataSet ds = LoadDatasetFromXml(@"E:\Clinic\CodeBase\ObjectListViewFull-2.9.1\ObjectListViewDemo\Demo\Data\FamilyTree.xml");


                //this.olvDataTree.DataMember = "Person";
                //this.olvDataTree.DataSource = new DataViewManager(ds);

                //this.olvDataTree.AutoResizeColumns();

                long lngTotalPage = 0;
                long lngTotalRecord = 0;
                if (dsData.Tables[0].Rows.Count <= 0)
                {
                    //ngbMain.CurrentPage = 0;
                    //ngbMain.TotalPage = 0;
                    //ngbMain.TotalRecord = 0;
                    //ngbMain.Updates();
                    DerUtility.MouseOff(this);
                    // Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "ไม่พบข้อมูลในระบบ");
                    return;
                }
                DataRow dtotal = dsData.Tables[0].NewRow();
                dtotal["SONo"] = "Total";
                dtotal["PriceAfterDis"] = dsData.Tables[0].Compute("Sum(PriceAfterDis)", "");
                dsData.Tables[0].Rows.Add(dtotal);
                foreach (DataRowView item in dsData.Tables[0].DefaultView)
                {
                    if (item["SONo"] + "" == "")
                        continue;
                    else
                    {
                        if (item["VN"] + "" == "")
                            continue;
                    }

                    // SalePrice = item["SalePrice"] + "" == "" ? 0 : Convert.ToDecimal(item["SalePrice"] + "");
                    MS_Price = item["MS_Price"] + "" == "" ? 0 : Convert.ToDecimal(item["MS_Price"] + "");
                    Amount = item["Amount"] + "" == "" ? 0 : Convert.ToDecimal(item["Amount"] + "");
                    SpecialPrice = item["SpecialPrice"] + "" == "" ? 0 : Convert.ToDecimal(item["SpecialPrice"] + "");
                    PriceAfterDis = item["PriceAfterDis"] + "" == "" ? 0 : Convert.ToDecimal(item["PriceAfterDis"] + "");
                    DiscountBathByItem = item["DiscountBathByItem"] + "" == "" ? 0 : Convert.ToDecimal(item["DiscountBathByItem"] + "");
                    var myItems = new[]
                                      {
                                          item["UpdateDate"]+""==""?"":String.Format("{0:dd/MM/yyyy}",DateTime.Parse( item["UpdateDate"]+"")),
                                          item["SONo"] + "",
                                          item["VN"] + "",
                                          item["CN"]+"",
                                          item["HowYouhear"]+"",//HowYouhear
                                          item["FullNameThai"] + ""!=""?item["FullNameThai"] + "":item["FullNameEng"] + "",
                                          item["Age"] + "",
                                          item["Section_Code"] + "",
                                          item["MedicalTab"] + "",
                                          item["MS_Name"] + "",
                                          MS_Price.ToString("###,###,###.##"),
                                          Amount.ToString("###,###,###.##"),
                                          (SpecialPrice).ToString("###,###,###.##"),
                                              (DiscountBathByItem).ToString("###,###,###.##"),
                                          PriceAfterDis.ToString("###,###,###.##"),
                                          "",
                                          "",
                                          "",
                                          item["MedStatus_Name"] + "",
                                          item["MedStatus_Code"] + "",
                                     
                                          item["KeyMan"] + "",
                                      };
                    dgvData.Rows.Add(myItems);
                    //if (lngTotalPage != 0) continue;
                    //Utility.FindTotalPage(Convert.ToInt32(item["rowTotal"].ToString()), ref lngTotalPage);
                    //lngTotalRecord = Convert.ToInt32(item["rowTotal"].ToString());
                }
                foreach (DataGridViewRow dataRow in dgvData.Rows)
                {
                    MedStatus_Code = dataRow.Cells["MedStatusCode"].Value + "";

                    if (MedStatus_Code == "0" || MedStatus_Code == "" || MedStatus_Code == "6")
                        dataRow.DefaultCellStyle.BackColor = Color.DarkGray;
                    if (MedStatus_Code == "1" || MedStatus_Code == "7")
                        dataRow.DefaultCellStyle.BackColor = Color.Khaki;
                    if (MedStatus_Code == "2" || MedStatus_Code == "8")
                        dataRow.DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                    if (MedStatus_Code == "3")
                        dataRow.DefaultCellStyle.BackColor = Color.LightBlue;
                }
                dgvData.Columns["SONo"].Visible = true;
                dgvData.Columns["PayCash"].Visible = false;
                dgvData.Columns["PayCredit"].Visible = false;
                dgvData.Columns["MO"].Visible = true;
                dgvData.Columns["DiscountBathByItem"].Visible = false;
                
                dgvData.Columns["PayCash"].Visible = false;
                dgvData.Columns["PayCredit"].Visible = false;
                dgvData.Columns["DiscountBathByItem"].Visible = false;
                dgvData.Columns["HowYouhear"].Visible = true;
                dgvData.Columns["Age"].Visible = true;
                dgvData.Columns["Section_Code"].Visible = false;
                dgvData.Columns["MedicalTab"].Visible = true;
                dgvData.Columns["MS_Name"].Visible = true;
                dgvData.Columns["Amount"].Visible = true;
                dgvData.Columns["SpecialPrice"].Visible = true;
                dgvData.Columns["MS_Price"].Visible = true;
                dgvData.Columns["Balance"].Visible = false;
                dgvData.ClearSelection();
                foreach (DataGridViewColumn column in dgvData.Columns)
                {

                    dgvData.Columns[column.Name].SortMode = DataGridViewColumnSortMode.Automatic;
                }
                //ngbMain.CurrentPage = pIntseq;
                //ngbMain.TotalPage = lngTotalPage;
                //ngbMain.TotalRecord = lngTotalRecord;
                //ngbMain.Updates();
               
                SetColumnAndSize();
                DerUtility.MouseOff(this);
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
        }
        public void BindReportOutStanding(int pIntseq)
        {
            try
            {
                DerUtility.MouseOn(this);
                try
                {
                    if (dgvData.Rows.Count > 0)
                    {
                        dgvData.DataSource = null;
                        dgvData.Rows.Clear();
                    }
                }
                catch (Exception)
                {

                }
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
                if (!string.IsNullOrEmpty(txtCN.Text.Trim()))
                {
                    info.CN = "%" + txtCN.Text + "%";
                }
                if (!string.IsNullOrEmpty(txtSO.Text.Trim()))
                {
                    info.SONo = "%" + txtSO.Text + "%";
                }
                //if (radioGroupSO.Checked)
                //{
                //    info.SONo = "%" + txtSO.Text + "%";
                //}
                //if (radioGroupCN.Checked)
                //{
                //    info.SONo = "%" + txtSO.Text + "%";
                //}


                info.QueryType = "SEARCH_TopCNBuy";
                dsData = new Business.Report().SelectReportPaging(info);
                MedStatus_CodeNew = checkBoxNew.Checked ? "0" : null;
                MedStatus_CodePending = checkBoxPending.Checked ? "1" : null;
                MedStatus_CodeClosed = checkBoxClose.Checked ? "2" : null;
                info.MedStatus_CodeNew = MedStatus_CodeNew;
                info.MedStatus_CodePending = MedStatus_CodePending;
                info.MedStatus_CodeClosed = MedStatus_CodeClosed;
                //string v = ((KeyValuePair<string, int>)comboBoxPeriod.SelectedItem).Value.ToString();
                //info.Peroid = Convert.ToInt16(v);
                dsData = new Business.Report().SelectReportPaging(info);
                //dgvData.Columns.Clear();
                foreach (DataGridViewColumn c in dgvData.Columns)
                {
                    c.Visible = false;
                }
                dgvData.AutoGenerateColumns = true;
                dgvData.DataSource = null;
                dgvData.DataSource = dsData.Tables[0];
                //SetColumns();
                DerUtility.MouseOff(this);

            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
           SetColumnAndSize();
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
    
        private void FrmCommonReport_Load(object sender, EventArgs e)
        {

            try
            {
                dgvData.AutoGenerateColumns = false;
                txtEnddate.Text=DateTime.Now.ToString("yyyy/MM/dd");
                txtStartdate.Text = DateTime.Now.AddMonths(-1).ToString("yyyy/MM/dd");
                var grouper = this.dataGridViewGrouperControl1.Grouper;
                uBranch1.setBranchValue(Entity.Userinfo.BranchId);
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
                        ExportFile exp = new ExportFile();
                        wb.Worksheets.Add(exp.GetDataTableFromDGV(dgvData, "Result"));
                        //wb.Worksheets.Add(dsData.Tables[0]);
                        if(ucPivotTable1.newDt.Rows.Count>0)
                        wb.Worksheets.Add(ucPivotTable1.newDt);
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

        private void FrmCommonReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics.frmCommonReport = null;
        }
      
        private void dgvData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void OnCellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //if (e.RowIndex < 1 || e.ColumnIndex < 0 )
            //    return;

            //e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;

            //if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex) && e.ColumnIndex < 8 && radioButtonTopCNBuy.Checked == false)
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

            string cellKey1 = dgvData["CN", row].Value+"";
            string cellKey2 = dgvData["CN", row - 1].Value+"";
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return ((cell1.Value.ToString() == cell2.Value.ToString()) &&( cellKey1 == cellKey2));
        }

        private void dgvData_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                //dgvData.Rows.Add(1);
                //LoopSumByColumn();
               // DataGridViewUtil.LoopSumByColumn(dgvData);
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }

        private void dgvData_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                //if (e.RowIndex == 0)
                //    return;
                ////if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex) && e.ColumnIndex < 8 && radioButtonOutStanding.Checked==false)
                //if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex) && e.ColumnIndex < 8)
                //{
                //    e.Value = "";
                //    e.FormattingApplied = true;
                //}

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
            SelectDate(txtEnddate);
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

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
          
            try
            {
                dtAll.DefaultView.RowFilter = string.Format("[_RowString] LIKE '%{0}%' or [_RowString]='Total'", txtFilter.Text);
                //DataRow dr = dtAll.NewRow();
                //dtAll.Rows.Add(dr);
                DataGridViewUtil.LoopSumByColumn(dgvData,false);
            }
            catch (Exception)
            {
             
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

        private void txtSO_MouseClick(object sender, MouseEventArgs e)
        {
            DerUtility.GetSetInputKeyBorad("english");
        }

        private void txtCN_MouseClick(object sender, MouseEventArgs e)
        {
            DerUtility.GetSetInputKeyBorad("english");
        }

    
    }
}
