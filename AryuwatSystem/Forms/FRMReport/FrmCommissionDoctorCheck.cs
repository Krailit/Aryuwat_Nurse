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

namespace AryuwatSystem.Forms
{
    public partial class FrmCommissionDoctorCheck : DockContent
    {
        DataTable dtListAll = new DataTable();
        private string EMPName
        {
            get { return lblEmployeeName.Text; }
            set { lblEmployeeName.Text = value; }
        }
        private string EMPID
        {
            get { return lblEN.Text; }
            set { lblEN.Text = value; }
        }
        string DoctorName = "";
        DataSet dsSurgeryFee;
        private Dictionary<double, double> DicComRate;
        double Sales = 0;
        double Commission = 0;
        private string EMPTypID = "";
        private string CNTypID = "";
        public bool SurgiFeeTYP = true;
        DataTable dtSurgicalFee_Position = new DataTable();
        Dictionary<string,string>dicPosition=new Dictionary<string,string> ();
        public bool OpenFee = true;
        DataTable dtReport = new DataTable();
        Dictionary<string, string> dicReportRang = new Dictionary<string, string>();
        Dictionary<string, string> dicReporQueryType = new Dictionary<string, string>();
        string QueryType = "";
        public FrmCommissionDoctorCheck()
        {
            InitializeComponent();
            ngbMain.MoveFirst += ngbMain_MoveFirst;
            ngbMain.MoveNext += ngbMain_MoveNext;
            ngbMain.MoveLast += ngbMain_MoveLast;
            ngbMain.MovePrevious += ngbMain_MovePrevious;
            txtEnddate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            txtStartdate.Text = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");
            //cboSurgicalFeeTyp.ItemHeight = 500;
            cboSurgicalFeeTyp.DropDownHeight = 800;
            
        }
   
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
        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindDataCommission(1);
        }
        private void setColumn()
        {
           //// if (EMPTypID == "17")//Sale Comission
           // if(radioButtonSale.Checked)
           // {
               
           //     foreach (DataGridViewColumn item in dgvData.Columns)
           //     {
           //         item.Visible = false;
           //     }
           //     dgvData.Columns["SO"].Visible = true;
           //     dgvData.Columns["CN"].Visible = true;
           //     dgvData.Columns["CustomerName"].Visible = true;
           //     dgvData.Columns["ProcedureDate"].Visible = true;
           //     dgvData.Columns["Money"].Visible = true;
             
           // }
           // else//Surgical Fee
           // {
            //foreach (DataGridViewColumn item in dgvData.Columns)
            //{
            //    item.Visible = true;
            //}
                // lblMoney1.Text = "รายได้ :";
              
           // }
            //dataGridViewSummary.ClearSelection();
            //dataGridViewSummary.Rows[0].Selected = true;
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
            }
            foreach (DataGridViewColumn c in dgvData.Columns)
            {
                if (c.Name.ToLower().Contains("ค่า") || c.Name.ToLower().Contains("date") || c.Name.ToLower().Contains("com") || c.Name.ToLower().Contains("bath") || c.Name.ToLower().Contains("ขาย") || c.Name.ToLower().Contains("amount") || c.Name.ToLower().Contains("จำนวน"))
                        dgvData.Columns[c.Name].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                if( c.Name.ToLower().Contains("en") )
                  dgvData.Columns["EN"].Visible = false;
            }
            foreach (DataGridViewColumn c in dataGridViewSummary.Columns)
            {
                if (c.Name.ToLower().Contains("ค่า") || c.Name.ToLower().Contains("date") || c.Name.ToLower().Contains("com") || c.Name.ToLower().Contains("bath") || c.Name.ToLower().Contains("ขาย") || c.Name.ToLower().Contains("amount"))
                    dataGridViewSummary.Columns[c.Name].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                if (c.Name.ToLower().Contains("en"))
                    dataGridViewSummary.Columns["EN"].Visible = false;
            }

        }
        public void BindDataCommission(int _pIntseq)
        {
            try
            {

           

                Sales = 0;
                int count=0;
                decimal Amount = 0;
                decimal AmountUsed = 0;
                decimal PriceAfterDis = 0;
                //setColumn();
                if (dgvData.Rows.Count>0)dgvData.Rows.RemoveAt(0);
                //dgvData.Rows.Clear();
                dgvData.DataSource = null;
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
                 info.Position_Type = "'"+cboSurgicalFeeTyp.Text + "'";
                 if (!string.IsNullOrEmpty(txtStartdate.Text.Trim()))
                 {
                     info.StartDate =  txtStartdate.Text;
                 }
                 if (!string.IsNullOrEmpty(txtEnddate.Text.Trim()))
                 {
                     //info.EndDate = "'" + Convert.ToDateTime(txtEnddate.Text).AddDays(1).ToString("yyyy/MM/dd") + "'";
                     info.EndDate =  Convert.ToDateTime(txtEnddate.Text).ToString("yyyy/MM/dd") ;
                 }
                 info.whereDate = string.Format(" and (Sur.DateUpdate between '{0}' and '{1}' )", info.StartDate, info.EndDate);

                 //if (string.IsNullOrEmpty(lblEN.Text.Trim()))
                 //{
                 //    MessageBox.Show("Please Select Doctor.");
                 //    return;
                 //}
                 //else info.EN = string.Format(" and MStuff.[EmployeeId]='{0}'", lblEN.Text);
                //if (!dtpDateStart.Checked && !dtpDateEnd.Checked)
                //{
                //    info.whereDate = " 1=1 ";
                //}
                string[] positionx;
                string wherein="";
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
                info.Position_ID = "";
                //info.QueryType = EMPTypID == "17" ? "SELECTCOMMISSIONSALE" : "SELECTCOMMISSIONFEE";

                //info.QueryType = radioFee.Checked ? "SELECTDOCTORCHECK" : "SELECTCom_DOCTOR";
                
                if(radioFee.Checked)
                     info.QueryType= "SELECTDOCTORCHECK";
                else if(radioCom.Checked)
                      info.QueryType= "SELECTCom_DOCTOR";
                else if (radioDayList.Checked)
                {
                    info.QueryType = "RptSurgicalFeeDoctorCheck";
                }
                else if (radioButtonCover.Checked)
                {
                    info.QueryType = "RptAllCoverCheck";
                }
                else if (radioUsedCouseDaily.Checked)
                {
                    info.QueryType = "RptUsedCouseDaily";
                }
                else if (radioFeeTerapist.Checked)
                {
                    info.QueryType = "RptUsedCouseDailyTP";
                } 
                

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
            
                    //foreach (DataRowView item in dsSurgeryFee.Tables[0].DefaultView)
                    //{
                    //    decimal Pricex18 = 0;
                    //    decimal PricexAgency = 0;
                    //    decimal PriceAfterDisPerAmount = 0;
                    //    decimal MS_Number_C = 1;
                    //    if (item["CN"] + "" != "")
                    //        CNTypID = (item["CN"] + "").Substring(0, 3);
                    //    Amount = string.IsNullOrEmpty(item["Amount"] + "") ? 1 : Convert.ToDecimal(item["Amount"] + "");
                    //    MS_Number_C = string.IsNullOrEmpty(item["Amount"] + "") ? 1 : Convert.ToDecimal(item["MS_Number_C"] + "");
                    //    AmountUsed = string.IsNullOrEmpty(item["AmountOfUse"] + "") ? 1 : Convert.ToDecimal(item["AmountOfUse"] + "");
                    //    PriceAfterDis = string.IsNullOrEmpty(item["PriceAfterDis"] + "") ? 1 : Convert.ToDecimal(item["PriceAfterDis"] + "");
                    //    //PriceAfterDis = (PriceAfterDis / Amount) * AmountUsed;
                    //    PriceAfterDisPerAmount = ((PriceAfterDis / MS_Number_C) / Amount) * AmountUsed;
                    //    if (Userinfo.PriceAgency.Contains(CNTypID) && item["SurgicalFeeTyp"] + "" != "SURGERY")
                    //    {
                    //        PricexAgency = PriceAfterDis * (decimal)Userinfo.AGENCY_RATE;
                    //        Pricex18 =PriceAfterDis-( PriceAfterDis * (decimal)Userinfo.AGENCY_RATE);
                    //    }
                    //    double m = string.IsNullOrEmpty(item["Com_Bath"] + "") ? 0 : Convert.ToDouble(item["Com_Bath"] + "");
                    //    var myItems = new IComparable[]
                    //                  {
                    //                      item["VN"] + "",
                    //                      item["RefMO"] + "",
                    //                      item["sono"] + "",
                    //                      item["CN"] + "",
                    //                      item["CustFullNameThai"] + "",
                    //                      item["FullNameThai"] + "",
                    //                      item["MS_Name"] + "",
                    //                      "",//item["Position_Name"] + "",
                    //                      item["ProcedureDate"] + ""==""?"":item["ProcedureDate"] + "",//Convert.ToDateTime(item["ProcedureDate"] + "").ToString("dd/MM/yyyy"),
                    //                      "",//item["StartProcedure"] + ""==""?"":Convert.ToDateTime(item["StartProcedure"] + "").ToString("HH:mm:00"),
                    //                      "",//item["EndProcedure"] + ""==""?"":Convert.ToDateTime(item["EndProcedure"] + "").ToString("HH:mm:00"),
                    //                      PriceAfterDis.ToString("###,###,###.##"),
                    //                      PricexAgency.ToString("###,###,###.##"),//ราคาต่อหน่วยหรือ ราคาหลังหัก agency 18%
                    //                      Pricex18!=0?Pricex18.ToString("###,###,###.##"):PriceAfterDisPerAmount.ToString("###,###,###.##"),//ราคาถ้ามีหัก 18%
                                          
                    //                      m.ToString("###,###,###.##"),//ค่ามือ
                    //                       item["Complimentary"]+""== "Y"?true:false ,
                    //                       item["MarketingBudget"]+""== "Y"?true:false,
                    //                       item["Gift"]+""== "Y"?true:false,
                    //                       item["Subject"]+""== "Y"?true:false
                    //                  };
                    //    dgvData.Rows.Add(myItems);
                    //    Sales += m;
                    //    count++;
                    
                    //}
                    
                //CalCommission();
             

                dgvData.Columns.Clear();
                dgvData.DataSource = null;

                //=====for total Row===
                DataRow dr = dsSurgeryFee.Tables[0].NewRow();
                //dr[0] = "Total";
                //dsSurgeryFee.Tables[0].Rows.Add(dr);

                if (dsSurgeryFee.Tables[0].Columns.Contains("_RowString"))
                    dr["_RowString"] = "Total";


                dsSurgeryFee.Tables[0].Rows.Add(dr);

                //=====for total Row===

                //if (radioButtonCover.Checked)
                //{
                //    dgvData.DataSource = GroupEmployee(dsSurgeryFee.Tables[0]);
                //}
                //else
                    dgvData.DataSource = dsSurgeryFee.Tables[0];

                dgvData.Columns["_RowString"].Visible = false;

                dataGridViewSummary.DataSource = null;

                 //=====for summary total Row===
                 dr = dsSurgeryFee.Tables[1].NewRow();
                dr[0] = "Total";
                dsSurgeryFee.Tables[1].Rows.Add(dr);

                dataGridViewSummary.DataSource = dsSurgeryFee.Tables[1];
                string en = "xx" ;
                dsSurgeryFee.Tables[0].DefaultView.RowFilter = string.Format("[EN] LIKE '%{0}%' ", en);
                count = dsSurgeryFee.Tables[0].DefaultView.Count;
                //LoopSumByColumn(dataGridViewSummary);
                //LoopSumByColumn(dgvData);
                DataGridViewUtil.LoopSumByColumn(dataGridViewSummary,false);
                DataGridViewUtil.LoopSumByColumn(dgvData, false);
                setColumn();
                DerUtility.FindTotalPage(count, ref lngTotalPage);
                lngTotalRecord = count;

                DerUtility.SetPropertyDgv(dataGridViewSummary);
                DerUtility.SetPropertyDgv(dgvData);


                if (OpenFee==false)
                {
                    if (dataGridViewSummary.Columns.Contains("ยอด"))
                        dataGridViewSummary.Columns.RemoveAt(dataGridViewSummary.Columns["ยอด"].Index); //= OpenFee;
                    if (dgvData.Columns.Contains("ค่าแพทย์"))
                        dgvData.Columns.RemoveAt(dgvData.Columns["ค่าแพทย์"].Index);
                    //dgvData.Columns["ค่าแพทย์"].Visible = OpenFee;

                    if (dataGridViewSummary.Columns.Contains("ค่าคอม"))
                        dataGridViewSummary.Columns.RemoveAt(dataGridViewSummary.Columns["ค่าคอม"].Index);
                    //dataGridViewSummary.Columns["ค่าคอม"].Visible = OpenFee;
                    if (dgvData.Columns.Contains("ค่าคอม"))
                        dgvData.Columns.RemoveAt(dgvData.Columns["ค่าคอม"].Index);
                    //dgvData.Columns["ค่าคอม"].Visible = OpenFee;
                }

            
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
        private DataTable GroupEmployee(DataTable dt)
        {
            List<DataRow> lsRow = new List<DataRow>();
            DataTable dttemp = new DataTable();
            dttemp = dt.Clone();
            try
            {
                //DataTable distinctValues = dt.DefaultView.ToTable(true,"MO","SO","ใบยา","Date","CN","Customer","Treatment","ราคาขาย","EN","แพทย์",พนักงานอื่นๆ,"Consult1","Consult2");
                DataTable distinctValues = dt.DefaultView.ToTable(true, "MO", "SO", "ใบยา", "Date", "CN", "Customer", "Treatment", "ราคาขาย");
                foreach (DataRow item in distinctValues.Rows)
                {
                      lsRow.Add(item);
                }
                foreach (DataRow item in dt.Rows)
                {
                    DataRow toInsert = dttemp.NewRow();
                    //ประเภท	MO	SO	ใบยา	Date	CN	Customer	Treatment	ราคาขาย	ค่าแพทย์	EN	ตำแหน่ง	Position_ID	แพทย์	พนักงานอื่นๆ	Consult1	Consult2	สาขา	ListOrder	_RowString
                    lsRow.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dttemp;
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
        private DataTable CalCommission(DataTable dt)
        {
            int level = 0;
            double salePrice = 0;
            double rate = 0;
            foreach (DataRow item in dt.Rows)
            {
                level = 0;
                salePrice = Convert.ToDouble(item["ยอดหลังหักส่วนแบ่ง"] + "");
                foreach (KeyValuePair<double, double> valuePair in DicComRate)
                {

                    if (salePrice > valuePair.Key && level < DicComRate.Count - 1)
                    {
                        level++;
                        continue;
                    }
                    Commission = salePrice * valuePair.Value;
                    rate = valuePair.Value;
                    //lblComRate.Text = "Com : " + (valuePair.Value * 100).ToString() + " %";
                    level++;
                    break;

                }
                item["Rate"] = rate * 100;
                item["Commission"] = Commission.ToString("###,###,###,###");
                //txtCommoney.Text = Commission.ToString("##,###,###.##");
            }
            return dt;

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


                    if (!string.IsNullOrEmpty(obj.StaffsName))
                        EMPName = obj.StaffsName.Replace(',', ' ').Trim();
                    if (!string.IsNullOrEmpty(obj.EmployeeId))
                        EMPID = obj.EmployeeId.Replace(',', ' ').Trim();
                    EMPTypID = obj.EmployeeTypeId;

                    //BindDataCommission(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmCommissionDoctorCheck_Load(object sender, EventArgs e)
        {
            
            BindCommissionRate();
            BindSurgicalFeeType_Position();
            lblEN.Text = "";
            lblEmployeeName.Text = "";
            dgvData.Columns.Clear();
            //PopEMP();
           // BindDataCommission(1);

            //dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            //dgvData.AllowUserToOrderColumns = true;
            //dgvData.AllowUserToResizeColumns = true;
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
                    DataView view = new DataView(dtSurgicalFee_Position);
                    //DataTable distinctValues = view.ToTable(true, "Position_Type", "Column2");
                    DataTable distinctValues = view.ToTable(true, "Position_Type");
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
                   if (dtSurgicalFee_Position.Select(@where).Any())
                       {
                       distinctValues=dtSurgicalFee_Position.Select(@where).CopyToDataTable();
                       foreach (DataRow item in distinctValues.Rows)
	                    {
		                     if(!dicPosition.ContainsKey(item["Position_ID"]+""))
                            {
                                dicPosition.Add(item["ID"] + "", item["Position_Name"].ToString().Replace(",", ""));
                               
                                cboPosition.Items.Add(item["Position_Name"]);  
                            }
	                    }
                           
                       }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void FrmCommissionDoctorCheck_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics.frmCommissionDoctorCheck = null;
          }

        private void cboSurgicalFeeTyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindPosition(cboSurgicalFeeTyp.Text);
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
                    pp.SelecttDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));// DateTime.TryParse(txt.Text, out d) ? d : DateTime.Now;
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

        private void btnFindEMP_Click_1(object sender, EventArgs e)
        {
            PopEMP();
        }
        private DataSet DGVTODatable()
        {
            DataTable dt = new DataTable();
            DataSet ds=new DataSet();
        try 
	        {	        
		    
            for (int i = 0; i < dgvData.Columns.Count; i++)
                {
                    dt.Columns.Add(dgvData.Columns[i].Name);
                }
            foreach (DataGridViewRow  row in dgvData.Rows)
                {
                    DataRow dr = dt.NewRow();
                    for(int j = 0;j<dgvData.Columns.Count;j++)
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
                //BindingSource bs = (BindingSource)dgvData.DataSource; // Se convierte el DataSource 
                //DataTable tCxC = (DataTable)bs.DataSource;

               

                saveFileDialog1.InitialDirectory = Convert.ToString(Environment.SpecialFolder.MyDocuments);
                saveFileDialog1.Filter = "Excel file(*.xlsx)|*.xlsx";
                saveFileDialog1.FilterIndex = 1;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {


                    //ExcelHelper.ExportToExcel(dsData, saveFileDialog1.FileName, "");


                    // dt = city.GetAllCity();//your datatable
                    using (ClosedXML.Excel.XLWorkbook wb = new ClosedXML.Excel.XLWorkbook())
                    {
                        //wb.Worksheets.Add(dsSurgeryFee.Tables[0]);//DGVTODatable
                        ExportFile exp = new ExportFile();
                        wb.Worksheets.Add(exp.GetDataTableFromDGV(dataGridViewSummary, "Summary"));
                        wb.Worksheets.Add(exp.GetDataTableFromDGV(dgvData, "Result"));
                        
                        //wb.Worksheets.Add(DGVTODatable());
                    
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

        private void dataGridViewSummary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
                string en = dataGridViewSummary["EN", e.RowIndex].Value + "";
                //string en = dataGridViewSummary["EN", e.RowIndex].Value + "";
                //string en = dataGridViewSummary["EN", e.RowIndex].Value + "";
                DoctorName = dataGridViewSummary["ชื่อ", e.RowIndex].Value + "";
                if (en.ToLower().Contains("total"))
                    dsSurgeryFee.Tables[0].DefaultView.RowFilter = string.Empty;
                else
                    dsSurgeryFee.Tables[0].DefaultView.RowFilter = string.Format("[EN] LIKE '%{0}%' or [_RowString]='Total'", en);


                dtListAll = dsSurgeryFee.Tables[0].DefaultView.ToTable();
                //string.Format("[_RowString] LIKE '%{0}%' or [_RowString]='Total'", txtFilter.Text);
                //LoopSumByColumn(dgvData);
                DataGridViewUtil.LoopSumByColumn(dgvData,false);
                setColumn();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //private void LoopSumByColumn(DataGridView dgv)
        //{
        //    try
        //    {
        //        int columnTotalText = 0;
        //        if (dgv.RowCount <= 0) return;
        //        foreach (DataGridViewColumn column in dgv.Columns)
        //        {
        //            if (column.Visible)
        //            {
        //                if (column.Name.ToLower().Contains("ค่า") || column.Name.ToLower().Contains("bath") || column.Name.ToLower().Contains("fee") || column.Name.ToLower().Contains("price") || column.Name.ToLower().Contains("ราคา") || column.Name.ToLower().Contains("cash")
        //                    || column.Name.ToLower().Contains("credit") || column.Name.ToLower().Contains("net") || column.Name.ToLower().Contains("total") || column.Name.ToLower().Contains("amount") || column.Name.ToLower().Contains("มูลค่า"))
        //                {
        //                    TotalRow(dgv,column.Index);
        //                    if (columnTotalText == 0)
        //                        columnTotalText = column.Index - 1;
        //                }

        //            }
        //        }
        //        for (int i = columnTotalText; i > 0; i--)
        //        {
        //            if (dgv.Columns[columnTotalText].Visible)
        //                dgv[columnTotalText, dgv.RowCount - 1].Value = "Total";
        //            else columnTotalText--;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        //private void TotalRow(DataGridView dgv,int cindex)
        //{
        //    try
        //    {
        //        double sum = 0;
        //        if (dgv.RowCount <= 0) return;
        //        dgv[cindex, dgv.RowCount - 1].Value = sum.ToString("###,###,###.##");
        //        //dgvData[0, dgvData.RowCount - 1].Value = "Total";

        //        foreach (DataGridViewRow item in dgv.Rows)
        //        {
        //            sum += item.Cells[cindex].Value + "" == "" ? 0 : Convert.ToDouble(item.Cells[cindex].Value);
        //        }

        //        //DataRow dr = dtAll.NewRow();
        //        //dgvData.Rows.Add(dr);
        //        dgv[cindex, dgv.RowCount - 1].Value = sum.ToString("###,###,###.##");
        //        //dgvData[1, dgvData.RowCount - 1].Value = "Total";

        //        DataGridViewCellStyle style = new DataGridViewCellStyle();
        //        style.Font = new Font(dgv.Font, FontStyle.Bold);
        //        dgv.Rows[dgv.Rows.Count - 1].DefaultCellStyle = style;
        //        dgv.Rows[dgv.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Yellow;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
   
        private void dataGridViewSummary_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        private void dgvData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        private void btnPrint_Click(object sender, EventArgs e)
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
                if (radioButtonCover.Checked)
                {
                    obj.PrintType = "RptDayListCheck";
                    obj.FormName = "RptDayListCheck";
                }
                else if (radioUsedCouseDaily.Checked)
                {
                    obj.PrintType = "RptUsedCouseDaily";
                    obj.FormName = "RptUsedCouseDaily";
                }
                else if (radioFeeTerapist.Checked)
                {
                    obj.PrintType = "RptUsedCouseDailyTP";
                    obj.FormName = "RptUsedCouseDailyTP";
                } 
                else
                {
                    obj.PrintType = "RptFeeDayListCheck";
                    obj.FormName = "RptFeeDayListCheck";
                }
               
                if (txtStartdate.Text == txtEnddate.Text)
                    obj.ForDate = string.Format(" {0} วันที่ {1} {2}",DoctorName.Replace("Total",""), txtStartdate.Text, uBranch1.BranchId.Length < 2 ? "" : uBranch1.BranchName);
                else
                    obj.ForDate = string.Format(" {0} วันที่ {1} - {2} {3}", DoctorName.Replace("Total", ""), txtStartdate.Text, txtEnddate.Text, uBranch1.BranchId.Length < 2 ? "" : uBranch1.BranchName);
                   
                

                    DataTable temp = dtListAll.Copy();
                    temp.Rows.RemoveAt(dtListAll.Rows.Count - 1);
                    obj.dt = temp;
                    obj.MaximizeBox = true;
                    obj.TopMost = true;
                    obj.Show();
               // }
               //else
               //{
               //    RptFeeDayListCheck
               //     //string typ = "";
               //     //if (radioCom.Checked) typ = "ค่าคอมมิชชั่น";
               //     //else if (radioFee.Checked) typ = "ค่ามือ";
               //     //else if (radioDayList.Checked) typ = "ตรวจสอบรายวัน";

               //     //dgvData.Tag = string.Format("{0} {1} {2} วันที่ {3} - {4}", DoctorName, uBranch1.BranchId == "" ? "" : uBranch1.BranchName, typ, Convert.ToDateTime(txtStartdate.Text).ToString("dd/MM/yyyy") + "", Convert.ToDateTime(txtEnddate.Text).ToString("dd/MM/yyyy"));
               //     //PrintDGV.Print_DataGridView(dgvData);
               //}
                
            }
            catch (Exception)
            {

            }
        }

        private void radioFee_Click(object sender, EventArgs e)
        {
            BindDataCommission(1);
        }

        private void radioCom_Click(object sender, EventArgs e)
        {
            BindDataCommission(1);
        }
        private void radioButtonCover_Click(object sender, EventArgs e)
        {
            //txtStartdate.Text = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");
            //txtEnddate.Text = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");
            BindDataCommission(1);
        }
        private void radioUsedCouseDaily_Click(object sender, EventArgs e)
        {
            BindDataCommission(1);
        }
        private void radioDayList_Click(object sender, EventArgs e)
        {
            //txtStartdate.Text = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");
            //txtEnddate.Text = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");
            BindDataCommission(1);
        }

        private void txtStartdate_MouseClick(object sender, MouseEventArgs e)
        {
            DerUtility.GetSetInputKeyBorad("english");
        }

        private void txtEnddate_MouseClick(object sender, MouseEventArgs e)
        {
            DerUtility.GetSetInputKeyBorad("english");
        }

        private void btnExport_Click(object sender, EventArgs e)
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
                        //wb.Worksheets.Add(dsSurgeryFee.Tables[0]);//DGVTODatable
                        ExportFile exp = new ExportFile();
                        wb.Worksheets.Add(exp.GetDataTableFromDGV(dataGridViewSummary, "Summary"));
                        wb.Worksheets.Add(exp.GetDataTableFromDGV(dgvData, "Result"));
                        
                        //wb.Worksheets.Add(DGVTODatable());
                    
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

        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            //if (e.RowIndex < 1 || e.ColumnIndex < 0)
            //    return;
            //if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            //{
            //    e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            //}
            //else
            //{
            //    e.AdvancedBorderStyle.Top = dgvData.AdvancedCellBorderStyle.All;
            //}  
        }

        private void dgvData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (e.RowIndex == 0)
            //    return;
            //if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            //{
            //    e.Value = "";
            //    e.FormattingApplied = true;
            //}
        }

        private void btnPrintForm_Click(object sender, EventArgs e)
        {
            try
            {
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radioFeeTerapist_Click(object sender, EventArgs e)
        {
            BindDataCommission(1);
        }

    

      

       
    }
}
