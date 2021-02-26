using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AryuwatSystem.DerClass;
using Entity;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;
using System.Diagnostics;
using AryuwatSystem.Forms.PrintGridView;
using ClosedXML.Excel;

namespace AryuwatSystem.Forms
{
    public partial class FrmCommonReportAEWE : DockContent
    {

        DataSet dsSurgeryFee;
        private Dictionary<double, double> DicComRate;
        double Sales = 0;
        double Commission = 0;
        string Sono = "";
        string MO = "";
        private string EMPTypID = "";
        public bool SurgiFeeTYP = true;
        DataTable dtSurgicalFee_Position = new DataTable();
        DataTable dtSubSurgicalFee = new DataTable();
        DataTable dtSurgicalFee = new DataTable();
        Dictionary<string,string>dicPosition=new Dictionary<string,string> ();
        Dictionary<string, string> dicSubSection = new Dictionary<string, string>();
        public FrmCommonReportAEWE()
        {
            InitializeComponent();
            ngbMain.MoveFirst += ngbMain_MoveFirst;
            ngbMain.MoveNext += ngbMain_MoveNext;
            ngbMain.MoveLast += ngbMain_MoveLast;
            ngbMain.MovePrevious += ngbMain_MovePrevious;
         
            //cboSurgicalFeeTyp.ItemHeight = 500;
            cboSurgicalFeeTyp.DropDownHeight = 800;
            
        }
        //private void setForYears()
        //{
        //    try
        //    {
        //        int year = 0;
        //        int yearNow = DateTime.Now.Year;
        //        if (yearNow < 2500)
        //            year = 2015;
        //        else
        //            year = 2558;
        //        comboBoxYears.Items.Clear();
        //        for (int i = year; i <= yearNow; i++)
        //        {
        //            comboBoxYears.Items.Add(i);
        //        }
        //        comboBoxYears.SelectedIndex = comboBoxYears.Items.Count - 1;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        private void ngbMain_MoveFirst()
        {
            BindDataCommission(1);
        }

        private void ngbMain_MoveLast()
        {
            BindDataCommission(Convert.ToInt32(ngbMain.TotalPage));
        }

        private void ngbMain_MoveNext()
        {
            BindDataCommission(Convert.ToInt32(Convert.ToInt32(ngbMain.CurrentPage) + 1));
        }

        private void ngbMain_MovePrevious()
        {
            BindDataCommission(Convert.ToInt32(Convert.ToInt32(ngbMain.CurrentPage) - 1));
        }

        private void buttonFind_BtnClick()
        {
            BindDataCommission(1);
        }
        private void setColumn()
        {

            try
            {
                for (int i = 0; i < dgvData.Columns.Count - 1; i++)
                {
                    dgvData.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                dgvData.Columns[dgvData.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

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
                    int colw = dataGridViewSum.Columns[i].Width;
                    dataGridViewSum.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dataGridViewSum.Columns[i].Width = colw;
                    if (dataGridViewSum.Columns[i].Name.ToLower().Contains("bath") | dataGridViewSum.Columns[i].Name.ToLower().Contains("date") | dataGridViewSum.Columns[i].Name.ToLower().Contains("fee"))
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

              


            }
            catch (Exception)
            {
                
            }
           
        }
        public void BindDataCommission(int _pIntseq)
        {
            try
            {
                txtFilter.Text = "";
                Sales = 0;
                int count=0;
                setColumn();
                if (dgvData.Rows.Count>0)dgvData.Rows.RemoveAt(0);
                
                try
                {
                    dgvData.Columns.Clear();
                    dgvData.Rows.Clear();
                }
                catch (Exception)
                {
                    
                
                }
              
                dgvData.DataSource = null;
                dataGridViewSum.DataSource = null;
               
                //int pIntseq = _pIntseq;
                 SurgeryFee info = new SurgeryFee(); 
              
                
                //if (dtpDateStart.Checked)
                //{
                //    info.whereDate = wdate+" >='" + dtpDateStart.Value.ToString("yyyy-MM-dd 00:00:00") + "'";
                //    //mydate between ('3/01/2013 12:00:00') and ('3/30/2013 12:00:00')
                //}
                //if (dtpDateEnd.Checked)
                //{
                //    info.whereDate = wdate + " <='" + dtpDateStart.Value.ToString("yyyy-MM-dd 23:59:59") + "'";
                //    //mydate between ('3/01/2013 12:00:00') and ('3/30/2013 12:00:00')
                //}
                //if (dtpDateStart.Checked && dtpDateEnd.Checked)
                //{
                //    info.whereDate = wdate + " between ('" + dtpDateStart.Value.ToString("yyyy-MM-dd 00:00:00") + "') and ('" + dtpDateEnd.Value.ToString("yyyy-MM-dd 23:59:59") + "')";
                //}

                 if (cboSurgicalFeeTyp.Text == "ALL")
                 {
                     foreach (var item in cboSurgicalFeeTyp.Items)
                     {
                          info.Position_Type =info.Position_Type+ "'" + item.ToString() + "',";
                     }
                     info.Position_Type += "''";
                 }
                 else
                 {
                     info.Position_Type = "'" + cboSurgicalFeeTyp.Text + "'";
                 }
                     

                 if (!string.IsNullOrEmpty(txtStartdate.Text.Trim()))
                 {
                     info.StartDate =  "'"+txtStartdate.Text+"'";
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
                string wherein="";
                info.Position_ID = "";
                if (!string.IsNullOrEmpty(cboPosition.Text))
                {
                    positionx = cboPosition.Text.Split(',');
                    if (positionx.Any())
                    {
                        foreach (string item in positionx)
	                    {
                            string key = dicPosition.FirstOrDefault(x => x.Value == item.Trim().Replace(",","")).Key;
                            wherein += string.Format("'{0}',", key);
	                    }


                        //info.Position_ID = wherein.Remove(wherein.Length-1);
                        info.Position_ID = string.Format(" and MStuff.Position_ID in({0}) ", wherein.Remove(wherein.Length - 1));
                    }
                }
                if (!string.IsNullOrEmpty(SubSection.Text))
                {
                    info.SubSurgical = string.Format(" and MS_Section in({0}) ", dicSubSection[SubSection.Text]);
                }
                else info.SubSurgical = "";
                //info.QueryType = EMPTypID == "17" ? "SELECTCOMMISSIONSALE" : "SELECTCOMMISSIONFEE";
                info.QueryType = "SELECT_AESTHETIC_ALL_CHECK";// radioButtonSale.Checked ? "SELECTCOMMISSIONSALE" : "SELECTCOMMISSIONFEE";
                info.BranchId = uBranch1.BranchId;
                 dsSurgeryFee = new Business.StuffCommission().SelectSurgeryFee(info);

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
               
                if(dsSurgeryFee.Tables[0].Columns.Count<2)return;
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
                    dataRow[dcRowString] = sb.ToString()+"Total";
                }
                //====================For  filter=====end=======================
                dtSurgicalFee = dsSurgeryFee.Tables[0].Clone();
                Dictionary<string, double> dicSum = new Dictionary<string, double>();
                    foreach (DataRow item in dsSurgeryFee.Tables[0].Rows)
                    {
                        if (SubSection.Text == "")
                        {
                            //this.VN,this.MS_Name,this.CourseUse,this.ProcedureDate,this.StartTime,this.EndTime,this.Money});
                            double m = string.IsNullOrEmpty(item["Com_Bath"] + "") ? 0 : Convert.ToDouble(item["Com_Bath"] + "");
                            if (dicSum.ContainsKey(item["พนักงาน"] + ""))
                            {
                                dicSum[item["พนักงาน"] + ""] += m;
                            }
                            else
                            {
                                dicSum.Add(item["พนักงาน"] + "", m);
                            }
                            //var myItems = new IComparable[]
                            //          {
                            //              item["VN"] + "",
                            //              item["RefMO"] + "",
                            //              item["sono"] + "",
                            //              item["CN"] + "",
                            //              item["CustFullNameThai"] + "",
                            //              item["FullNameThai"] + "",
                            //              item["MS_Name"] + "",
                            //              item["Position_Name"] + "",
                            //              item["ProcedureDate"] + ""==""?"":Convert.ToDateTime(item["ProcedureDate"] + "").ToString("dd/MM/yyyy"),
                            //              item["StartProcedure"] + ""==""?"":Convert.ToDateTime(item["StartProcedure"] + "").ToString("HH:mm:00"),
                            //              item["EndProcedure"] + ""==""?"":Convert.ToDateTime(item["EndProcedure"] + "").ToString("HH:mm:00"),
                            //              m.ToString("#,###,###.##"),
                            //               item["Complimentary"]+""== "Y"?true:false ,
                            //               item["MarketingBudget"]+""== "Y"?true:false,
                            //               item["Gift"]+""== "Y"?true:false,
                            //               item["Subject"]+""== "Y"?true:false,
                            //               item["_RowString"] + "",
                            //          };
                          //  dgvData.Rows.Add(myItems);
                            dtSurgicalFee.ImportRow(item);
                            Sales += m;
                            count++;
                        }
                        else
                        {
                            string SubSurgical = dicSubSection[SubSection.Text];

                            if (SubSurgical.Contains((item["MS_Section"] + "").Trim()))
                            {
                                double m = string.IsNullOrEmpty(item["Com_Bath"] + "") ? 0 : Convert.ToDouble(item["Com_Bath"] + "");
                                if (dicSum.ContainsKey(item["พนักงาน"] + ""))
                                {
                                    dicSum[item["พนักงาน"] + ""] += m;
                                }
                                else
                                {
                                    dicSum.Add(item["พนักงาน"] + "", m);
                                }
                                //var myItems = new IComparable[]
                                //      {
                                //          item["VN"] + "",
                                //          item["RefMO"] + "",
                                //          item["sono"] + "",
                                //          item["CN"] + "",
                                //          item["CustFullNameThai"] + "",
                                //          item["FullNameThai"] + "",
                                //          item["MS_Name"] + "",
                                //          item["Position_Name"] + "",
                                //          item["ProcedureDate"] + ""==""?"":Convert.ToDateTime(item["ProcedureDate"] + "").ToString("dd/MM/yyyy"),
                                //          item["StartProcedure"] + ""==""?"":Convert.ToDateTime(item["StartProcedure"] + "").ToString("HH:mm:00"),
                                //          item["EndProcedure"] + ""==""?"":Convert.ToDateTime(item["EndProcedure"] + "").ToString("HH:mm:00"),
                                //          m.ToString("#,###,###.##"),
                                //           item["Complimentary"]+""== "Y"?true:false ,
                                //           item["MarketingBudget"]+""== "Y"?true:false,
                                //           item["Gift"]+""== "Y"?true:false,
                                //           item["Subject"]+""== "Y"?true:false,
                                //           item["_RowString"] + ""
                                //      };
                              //  dgvData.Rows.Add(myItems);
                                dtSurgicalFee.ImportRow(item);
                                Sales += m;
                                count++;
                            }
                        }
                    
                    }


                    //=====for total Row===
                    DataRow dr = dtSurgicalFee.NewRow();
                    if (dtSurgicalFee.Columns.Contains("_RowString"))
                        dr["_RowString"] = "Total";

                    dtSurgicalFee.Rows.Add(dr);
                    //=====for total Row===

                dgvData.DataSource = dtSurgicalFee;// dsSurgeryFee.Tables[0];




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

                   //==================แบบ เก่าชชชชชชชชชชชชช
                    //double sm = 0;
                    //foreach (KeyValuePair<string, double> entry in dicSum)
                    //{
                    //    sm+= entry.Value;
                    //}
                    //dicSum.Add("    ยอดรวม ", sm);
                    //dataGridViewSum.AutoGenerateColumns = true;
                    //dataGridViewSum.DataSource = null;
                    //dataGridViewSum.Columns.Clear();
                    //dataGridViewSum.DataSource = ToDataTable(dicSum);// dsSurgeryFee.Tables[1];
                //==================แบบ เก่าชชชชชชชชชชชชช
                  dataGridViewSum.DataSource = null;
                    dataGridViewSum.Columns.Clear();
                    dataGridViewSum.DataSource = dsSurgeryFee.Tables[1];
                

                    if (dataGridViewSum.Columns.Contains("Fee"))
                        dataGridViewSum.Columns["Fee"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                CalCommission();

                DerUtility.FindTotalPage(count, ref lngTotalPage);
                lngTotalRecord = count;

                if (dsSurgeryFee.Tables[0].Rows.Count <= 0)
                {
                    ngbMain.CurrentPage = 0;
                    ngbMain.TotalPage = 0;
                    ngbMain.TotalRecord = 0;
                    ngbMain.Updates();
                    DerUtility.MouseOff(this);
                    // Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "ไม่พบข้อมูลในระบบ");
                    return;
                }
                else
                {
                    ngbMain.CurrentPage = _pIntseq;
                    ngbMain.TotalPage = lngTotalPage;
                    ngbMain.TotalRecord = lngTotalRecord;
                    ngbMain.Updates();
                }
             
                //dataGridViewSum.Rows[dataGridViewSum.RowCount - 1].Frozen = true;
                DataGridViewUtil.LoopSumByColumn(dgvData,false);
                setColumn();

                if (dgvData.RowCount > 1)
                {
                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                    col.HeaderText = "ลำดับ";
                    col.Name = "ลำดับ";
                    dgvData.Columns.Insert(0, col);

                    col = new DataGridViewTextBoxColumn();
                    col.HeaderText = "ลำดับ";
                    col.Name = "ลำดับ";
                    if (dataGridViewSum.Columns.Contains("ลำดับ")) return;
                    dataGridViewSum.Columns.Insert(0, col);

                    dataGridViewSum.Columns["ลำดับ"].Width = 10;
                    dgvData.Columns["ลำดับ"].Width = 10;
                    for (int i = 0; i < dgvData.RowCount-1; i++)
                    {
                        dgvData["ลำดับ", i].Value = (i + 1).ToString("###,###");
                    }
                    for (int i = 0; i < dataGridViewSum.RowCount - 1; i++)
                    {
                        dataGridViewSum["ลำดับ", i].Value = (i + 1).ToString("###,###");
                    }
                   

                }
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
        private DataTable ToDataTable(Dictionary<string, double> dic)
        {
            DataTable result = new DataTable();
            result.Columns.Add("Name", typeof(string));
            result.Columns.Add("Fee", typeof(string));
            foreach (KeyValuePair<string, double> entry in dic)
            {
                result.Rows.Add(entry.Key,entry.Value==0?"0": entry.Value.ToString("###,###,###.00"));
            }
            //if (list.Count == 0)
            //    return result;

            //var columnNames = list.SelectMany(dict => dict.Keys).Distinct();
            //result.Columns.AddRange(columnNames.Select(c => new DataColumn(c)).ToArray());
            //foreach (Dictionary<string, double> item in list)
            //{
            //    var row = result.NewRow();
            //    foreach (var key in item.Keys)
            //    {
            //        row[key] = item[key];
            //    }

            //    result.Rows.Add(row);
            //}

            return result;
        }
        private void CalCommission()
        {
            int level=0;
            foreach (KeyValuePair<double,double> valuePair in DicComRate)
            {

                if (Sales > valuePair.Key && level < DicComRate.Count-1)
                {
                    level++;
                    continue;
                }
                Commission = Sales*valuePair.Value;
                level++;
                break;
               
            }

        }
        private void btnFindEMP_Click(object sender, EventArgs e)
        {
            PopEMP();
        }
        private void PopEMP()
        {
            try
            {
                    PopEmpSearch obj = new PopEmpSearch();
                    obj.StartPosition = FormStartPosition.CenterScreen;
                    obj.WindowState = FormWindowState.Normal;
                    obj.BackColor = Color.FromArgb(255, 230, 217);
                    obj.multiSelect = false;
                    obj._queryType = "LISTNAMECOMMISSION";
                    obj.ShowDialog();

             
                    EMPTypID=obj.EmployeeTypeId;
                    BindDataCommission(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmCommonReportAEWE_Load(object sender, EventArgs e)
        {
            
            BindCommissionRate();
            BindSurgicalFeeType_Position();
            ///setForYears();
            txtEnddate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            txtStartdate.Text = DateTimeUtil.FirstDayOfMonth(Convert.ToInt16(DateTime.Now.Year), DateTime.Now.Month).ToString("yyyy/MM/dd");// DateTime.Now.AddMonths(-1).ToString("yyyy/MM/dd");
        }
      
        private void BindCommissionRate()
        {
            try
            {
                DicComRate=new Dictionary<double, double>();
                DataSet dsComRate = new Business.StuffCommission().SelectCommissionRate();
                if(dsComRate.Tables.Count>0)
                {
                    foreach (DataRow dr in from DataRow dr in dsComRate.Tables[0].Rows where dr["Sales"] + "" != "" where !DicComRate.ContainsKey(Convert.ToDouble(dr["Sales"]+"")) select dr)
                    {
                        DicComRate.Add(Convert.ToDouble(dr["Sales"]+""),Convert.ToDouble(dr["Com_Rate"]+""));
                    }
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
                    dtSurgicalFee_Position=dsComRate.Tables[0];
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
        private void BindPosition(string typ)
        {
            try
            {
                    DataView view = new DataView(dtSurgicalFee_Position);
                    //DataTable distinctValues = view.ToTable(true, "Position_Type", "Column2");
                    string @where=string.Format("Position_Type='{0}'",typ);
                DataTable distinctValues =new DataTable();
                cboPosition.Items.Clear();
                dicPosition = new Dictionary<string, string>();
                if (typ=="ALL")
                {
                    foreach (DataRow item in dtSurgicalFee_Position.Rows)
	                    {
		                     if(!dicPosition.ContainsKey(item["Position_ID"]+""))
                            {
                                dicPosition.Add(item["Position_ID"] + "", "(" + item["Position_Type"] + ")" + item["Position_Name"].ToString().Replace(",", ""));
                               
                                cboPosition.Items.Add("("+item["Position_Type"]+")"+item["Position_Name"]);  
                            }
	                    }
                }
                else
                {
                    if (dtSurgicalFee_Position.Select(@where).Any())
                       {
                       distinctValues=dtSurgicalFee_Position.Select(@where).CopyToDataTable();
                       foreach (DataRow item in distinctValues.Rows)
	                    {
		                     if(!dicPosition.ContainsKey(item["Position_ID"]+""))
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
                            dicSubSection.Add(item["SubSurgicalFee"] + "", "'"+item["Section_Code"]+"'");
                            SubSection.Items.Add(item["SubSurgicalFee"]);
                        }
                        else
                        {
                            dicSubSection[item["SubSurgicalFee"] + ""] += ",'"+item["Section_Code"]+"'";
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
        private void FrmCommonReportAEWE_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics.frmCommonReportAEWE = null;
          }

        private void cboSurgicalFeeTyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindPosition(cboSurgicalFeeTyp.Text);
            BindSubSurgicalFee(cboSurgicalFeeTyp.Text);

        }

        private void txtStartdate_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelectDate(txtStartdate);
        }

        private void txtEnddate_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelectDate(txtEnddate);
        }
        private void SelectDate(TextBox txt)
        {
            try
            {
                PopDateTime pp = new PopDateTime();
                DateTime d;
                if (txt.Text.Trim() != "")
                    pp.SelecttDate = Convert.ToDateTime(txt.Text.Trim());// DateTime.TryParse(txt.Text, out d) ? d : DateTime.Now;
                else
                    pp.SelecttDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));// DateTime.TryParse(txt.Text, out d) ? d : DateTime.Now;
                //pp.SelecttDate =Convert.ToDateTime(pp.SelecttDate);
                if (pp.ShowDialog() == DialogResult.OK)
                {
                    //txt.Text = pp.SelecttDate.Date.ToString("dd/MM/yyyy");
                    txt.Text = pp.SelecttDate.Date.ToString("yyyy-MM-dd");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtStartdate_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
              if (e.KeyCode == Keys.Return)
                  BindDataCommission(1);
        }

        private void txtEnddate_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
              if (e.KeyCode == Keys.Return)
                  BindDataCommission(1);
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
                        wb.Worksheets.Add(exp.GetDataTableFromDGV(dgvData,"Result"));
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

        private void dgvData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            //e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
            //                      e.RowBounds.Location.X + 5, e.RowBounds.Location.Y );
            
            //if(dgvData.RowCount>1)
            //    dgvData["ลำดับ", e.RowIndex].Value = (e.RowIndex + 1).ToString("###,###");
            

        }

        private void dataGridViewSum_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            //e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
            //                      e.RowBounds.Location.X + 5, e.RowBounds.Location.Y + 4);
            //if (dataGridViewSum.RowCount > 1)
            //    dataGridViewSum["ลำดับ", e.RowIndex].Value = (e.RowIndex + 1).ToString("###,###");
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dtSurgicalFee.DefaultView.RowFilter = string.Format("[_RowString] LIKE '%{0}%' or [_RowString]='Total' ", txtFilter.Text);
                //BindingSource bs = new BindingSource();
                //bs.DataSource = dgvData.DataSource;
                //bs.Filter = string.Format("CONVERT(" + dgvData.Columns["_RowString"].DataPropertyName + ", System.String) like '%" + txtFilter.Text.Replace("'", "''") + "%'");
                //dgvData.DataSource = bs;
                DataGridViewUtil.LoopSumByColumn(dgvData,false);


                if (dgvData.RowCount > 1)
                {
                    for (int i = 0; i < dgvData.RowCount-1; i++)
                    {
                        dgvData["ลำดับ", i].Value = (i + 1).ToString("###,###");
                    }

                }
            }
            catch (Exception)
            {
             
            }
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


        private void dgvData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex < 0 || e.RowIndex < 0 || dgvData.Rows[e.RowIndex].Cells["MO"].Value + "" == "") return;
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                     dgvData.Rows[e.RowIndex].Selected = true;
                    //rowIndex = e.RowIndex;
                     dgvData.ClearSelection();
                     for (int c = 0; c < dgvData.ColumnCount-1; c++)
                         dgvData[c, e.RowIndex].Selected = true;

                     if (dgvData.Rows[e.RowIndex].Cells["MO"].Value.ToString().ToLower() != "")
                     {
                         contextMenuStrip1.Show(MousePosition);
                     }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void menuEditJobCost_Click(object sender, EventArgs e)
        {
            try
            {

                MO = dgvData.Rows[dgvData.CurrentRow.Index].Cells["MO"].Value + "";
                Sono = dgvData.Rows[dgvData.CurrentRow.Index].Cells["Sono"].Value + "";
                string MS_Code = dgvData.Rows[dgvData.CurrentRow.Index].Cells["MS_Code"].Value + "";
                string ListOrder = dgvData.Rows[dgvData.CurrentRow.Index].Cells["ListOrder"].Value + "";
                string CN = dgvData.Rows[dgvData.CurrentRow.Index].Cells["CN"].Value + "";
                //string SONo=dgvData.Rows[rowindex].Cells["SONo"].Value + "";
                DataSet dsSurgeryFee = new Business.MedicalOrder().SelectMedicalOrderById(MO, Sono);
                DataTable dtSurgeryFee = dsSurgeryFee.Tables[1];//.Select("SurgicalFeeNewTab='Y'").CopyToDataTable();
                //var distinctTable = dtSurgeryFee.DefaultView.ToTable(true, "MergStatus");
                int PHAMACYCount = 0;
                int MSCount = 0;
                int consult = 0;
                //foreach (DataRow row in distinctTable.Rows)
                //{
                //string where = "MergStatus='" + row["MergStatus"] + "'";
                foreach (DataRow dr in dtSurgeryFee.Rows)
                {
                    MSCount++;
                    if (dr["SurgicalFeeTyp"] + "" == "" || dr["SurgicalFeeTyp"] + "" == "PHAMACY")
                    {
                        PHAMACYCount++;
                        continue;
                    }
                    string ms_code = dr["MergStatus"] + "";
                    string section = ms_code.Substring(0, 3);
                    if (section.ToLower() == "cae" || section.ToLower() == "cwe" || section.ToLower() == "csu")
                    {
                        consult++;
                        continue;
                    }
                }
                //}
                if (MSCount == PHAMACYCount || consult == MSCount || (consult + PHAMACYCount) == MSCount)
                {
                    MessageBox.Show("PHAMACY OR Consult", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Statics.frmSurgicalFeeMain = new FrmSurgicalFeeMain();
                Statics.frmSurgicalFeeMain.dsSurgeryFee = dsSurgeryFee;
                Statics.frmSurgicalFeeMain.dtSurgeryFee = dtSurgeryFee;
                Statics.frmSurgicalFeeMain.VN = MO;
                Statics.frmSurgicalFeeMain.CN = CN;
                Statics.frmSurgicalFeeMain.SONo = Sono;

                Statics.frmSurgicalFeeMain.MS_Code = MS_Code;
                Statics.frmSurgicalFeeMain.ListOrder = ListOrder;

                Statics.frmSurgicalFeeMain.BackColor = Color.FromArgb(255, 230, 217);
                Statics.frmSurgicalFeeMain.Show(Statics.frmMain.dockPanel1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

     
        private void menuMOUse_Click(object sender, EventArgs e)
        {
            try
            {
                FrmMedicalUseList obj = new FrmMedicalUseList();
                obj.VN = dgvData.Rows[dgvData.CurrentRow.Index].Cells["MO"].Value + "";
                obj.SONo = dgvData.Rows[dgvData.CurrentRow.Index].Cells["SONo"].Value + "";
                //obj.BranchName = dgvData.Rows[dgvData.CurrentRow.Index].Cells["SONo"].Value + "";
                obj.BackColor = Color.FromArgb(255, 230, 217);
                obj.Show(Statics.frmMain.dockPanel1);
                //obj.ShowDialog();
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

        private void dgvData_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //if (dgvData.RowCount > 1)
            //{
            //    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            //    col.HeaderText = "ลำดับ";
            //    col.Name = "ลำดับ";
            //    dgvData.Columns.Insert(0, col);

            //    col = new DataGridViewTextBoxColumn();
            //    col.HeaderText = "ลำดับ";
            //    col.Name = "ลำดับ";
            //    if (dataGridViewSum.Columns.Contains("ลำดับ")) return;
            //    dataGridViewSum.Columns.Insert(0, col);

            //    dataGridViewSum.Columns["ลำดับ"].Width = 10;
            //    dgvData.Columns["ลำดับ"].Width = 10;
            //    for (int i = 0; i < dgvData.RowCount; i++)
            //    {
            //        dgvData["ลำดับ", i].Value = (i + 1).ToString("###,###"); 
            //    }
                
            //}
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

        private void dataGridViewSum_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
                string en = dataGridViewSum["พนักงาน", e.RowIndex].Value + "";
                //string en = dataGridViewSummary["EN", e.RowIndex].Value + "";
               // string en = dataGridViewSummary["EN", e.RowIndex].Value + "";
               // DoctorName = dataGridViewSum["ชื่อ", e.RowIndex].Value + "";
                if (en.ToLower().Contains("รวม"))
                    dtSurgicalFee.DefaultView.RowFilter = string.Empty;
                else
                    dtSurgicalFee.DefaultView.RowFilter = string.Format("[พนักงาน] LIKE '%{0}%' or [_RowString]='Total'", en);


                //dtListAll = dsSurgeryFee.Tables[0].DefaultView.ToTable();
                //string.Format("[_RowString] LIKE '%{0}%' or [_RowString]='Total'", txtFilter.Text);
                //LoopSumByColumn(dgvData);
                DataGridViewUtil.LoopSumByColumn(dgvData, false);
                setColumn();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
      
    }
}
