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
using ClosedXML.Excel;

namespace AryuwatSystem.Forms
{
    public partial class FrmCommissionCheck : DockContent
    {
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
        Dictionary<string, int> dicMonth = new Dictionary<string, int>();
        private Dictionary<double, double> DicComRate;
        double Sales = 0;
        double Commission = 0;
        private string EMPTypID = "";
        public bool SurgiFeeTYP = true;
        public bool OpenFee = true;
        public FrmCommissionCheck()
        {
            InitializeComponent();
        }

        private void buttonFind_BtnClick()
        {
            BindDataCommission(1);
        }
        private void setColumn()
        {
           // if (EMPTypID == "17")//Sale Comission
            if(radioButtonSale.Checked)
            {
               
                foreach (DataGridViewColumn item in dgvData.Columns)
                {
                    item.Visible = false;
                }
                dgvData.Columns["SO"].Visible = true;
                dgvData.Columns["CN"].Visible = true;
                dgvData.Columns["CustomerName"].Visible = true;
                dgvData.Columns["ProcedureDate"].Visible = true;
                dgvData.Columns["Money"].Visible = true;
                
                //lblMoney1.Text = "ยอดขาย :";
                lblCom1.Visible = true;
                
                txtCommoney.Visible = true;
                lblComRate.Visible = true;
                lblComRate.Visible = true;
                labelbathtext.Visible = true;
                //lblPercen.Visible = true;
            }
            else//Surgical Fee
            {
                foreach (DataGridViewColumn item in dgvData.Columns)
                {
                    item.Visible = true;
                }
                // lblMoney1.Text = "รายได้ :";
                lblCom1.Visible = false;
                //txtMoney.Visible = false;
                txtCommoney.Visible = false;
                lblComRate.Visible = false;
                lblComRate.Visible = false;
                labelbathtext.Visible = false;
                //lblPercen.Visible = false;
            }
        }
        DataSet dsSurgeryFee;
        public void BindDataCommission(int _pIntseq)
        {
            try
            {
                Sales = 0;
                //setColumn();
                if (dgvData.Rows.Count>0)dgvData.Rows.RemoveAt(0);
                //dgvData.Rows.Clear();
                dgvData.DataSource = null;
                //int pIntseq = _pIntseq;
                 SurgeryFee info = new SurgeryFee(); 
                if (!string.IsNullOrEmpty(lblEN.Text.Trim()))
                {
                    info.CN =  lblEN.Text ;
                    info.EN = lblEN.Text;
                }
                //string wdate = EMPTypID == "17" ? "Com_Date" : "ProcedureDate";
                string wdate = radioButtonSale.Checked ? "Com_Date" : "ProcedureDate";
                
                //if (dtpDateStart.Checked)
                //{
                //    info.whereDate = wdate+" >='" + dtpDateStart.Value.ToString("yyyy-MM-dd 00:00:00") + "'";
                //    //mydate between ('3/01/2013 12:00:00') and ('3/30/2013 12:00:00')
                //}
                //if (dtpDateEnd.Checked)
                //{
                //    info.whereDate = wdate + " <='" + dtpDateEnd.Value.ToString("yyyy-MM-dd 23:59:59") + "'";
                //    //mydate between ('3/01/2013 12:00:00') and ('3/30/2013 12:00:00')
                //}
                //if (dtpDateStart.Checked && dtpDateEnd.Checked)
                //{
                //    info.whereDate = wdate + " between ('" + dtpDateStart.Value.ToString("yyyy-MM-dd 00:00:00") + "') and ('" + dtpDateEnd.Value.ToString("yyyy-MM-dd 23:59:59") + "')";
                //     info.StartDate=dtpDateStart.Value.ToString("yyyy-MM-dd 00:00:00") ;
                //     info.EndDate = dtpDateEnd.Value.ToString("yyyy-MM-dd 23:59:59") ;
                //}

                int m = 0;
                if (!dicMonth.ContainsKey(comboBoxPeriod.Text)) return;
                m = dicMonth[comboBoxPeriod.Text];
                if (m==0)
                {
                    txtStartdate.Text = DateTimeUtil.FirstDayOfMonth(Convert.ToInt16(comboBoxYears.Text), 1).ToString("yyyy/MM/dd");
                    txtEnddate.Text = DateTimeUtil.LastDayOfMonth(Convert.ToInt16(comboBoxYears.Text), 12).ToString("yyyy/MM/dd");
                }
                else
                {
                    txtStartdate.Text = DateTimeUtil.FirstDayOfMonth(Convert.ToInt16(comboBoxYears.Text), m).ToString("yyyy/MM/dd");
                    txtEnddate.Text = DateTimeUtil.LastDayOfMonth(Convert.ToInt16(comboBoxYears.Text), m).ToString("yyyy/MM/dd");
                }

                info.whereDate = wdate + " between ('" + Convert.ToDateTime(txtStartdate.Text).ToString("yyyy-MM-dd 00:00:00") + "') and ('" + Convert.ToDateTime(txtEnddate.Text).ToString("yyyy-MM-dd 23:59:59") + "')";
                info.StartDate =Convert.ToDateTime(txtStartdate.Text).ToString("yyyy-MM-dd 00:00:00");
                info.EndDate = Convert.ToDateTime(txtEnddate.Text).ToString("yyyy-MM-dd 23:59:59");
                
                //if (!dtpDateStart.Checked && !dtpDateEnd.Checked)
                //{
                //    info.whereDate = " 1=1 ";
                //}
                //info.QueryType = EMPTypID == "17" ? "SELECTCOMMISSIONSALE" : "SELECTCOMMISSIONFEE";
                info.QueryType = radioButtonSale.Checked ? "SELECTCOMMISSIONSALE" : "SELECTCOMMISSIONFEE";
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
                if (radioButtonFee.Checked)
                {
                    //foreach (DataRowView item in dsSurgeryFee.Tables[0].DefaultView)
                    //{
                    //    //this.VN,this.MS_Name,this.CourseUse,this.ProcedureDate,this.StartTime,this.EndTime,this.Money});
                    //    double m = string.IsNullOrEmpty(item["Com_Bath"] + "") ? 0 : Convert.ToDouble(item["Com_Bath"] + "");
                    //    var myItems = new IComparable[]
                    //                  {
                    //                      item["VN"] + "",
                    //                      item["sono"] + "",
                    //                      item["CN"] + "",
                    //                      item["CustFullNameThai"] + "",
                    //                      item["FullNameThai"] + "",
                    //                      item["MS_Name"] + "",
                    //                      item["Position_Name"] + "",
                    //                      Convert.ToDateTime(item["ProcedureDate"] + "").ToString("dd/MM/yyyy"),
                    //                      Convert.ToDateTime(item["StartProcedure"] + "").ToString("HH:mm:00"),
                    //                      Convert.ToDateTime(item["EndProcedure"] + "").ToString("HH:mm:00"),
                    //                      m.ToString("#,###,###.##"),
                    //                       item["Complimentary"]+""== "Y"?true:false ,
                    //                       item["MarketingBudget"]+""== "Y"?true:false,
                    //                       item["Gift"]+""== "Y"?true:false,
                    //                       item["Subject"]+""== "Y"?true:false
                    //                  };
                    //    dgvData.Rows.Add(myItems);
                    //    Sales += m;
                    //}
                }
                else
                {
                    //foreach (DataRowView item in dsSurgeryFee.Tables[0].DefaultView)
                    //{
                    //    double m = string.IsNullOrEmpty(item["Com_Bath"] + "") ? 0 : Convert.ToDouble(item["Com_Bath"] + "");
                    //    var myItems = new IComparable[]
                    //                  {"",
                    //                      item["SO"] + "",
                    //                      item["CN"] + "",
                    //                      item["CustFullNameThai"] + "",
                    //                      "dddd",
                    //                      "xxxx",
                    //                      "yyyyy",
                                         
                    //                      String.Format("{0:yyyy/MM/dd}",item["ProcedureDate"] + ""),
                    //                       "zzzz",
                    //                          "zaaazzz",
                    //                      m.ToString("#,###,###.##")
                    //                  };
                    //    //dgvData.Rows.Add(myItems);
                    //    Sales += m;
                    //}
                }


                dgvData.Columns.Clear();
                dgvData.DataSource = null;
                dgvData.DataSource = dsSurgeryFee.Tables[0];// CalCommission(dsSurgeryFee.Tables[0]);
                
                //object sumObject;
                //sumObject = dsSurgeryFee.Tables[0].Compute("Sum(ยอดรับเงิน)", "");
                  //DataTable ddd=  CalTotalLastRow(dsSurgeryFee.Tables[1]);
                   dataGridViewSummary.DataSource = null;
                   dataGridViewSummary.DataSource = CalCommission(CalTotalLastRow(dsSurgeryFee.Tables[1]));

                   dgvData.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                   dataGridViewSummary.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                //dgvData.Columns[0].Visible = false;



                   dataGridViewSummary.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                   dgvData.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                   dataGridViewSummary.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                   dataGridViewSummary.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                   dgvData.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                   dgvData.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                   dgvData.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                   dgvData.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                   dgvData.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                   dgvData.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


                   dataGridViewSummary.Columns[1].Frozen = true;
                   dgvData.Columns[1].Frozen = true;
                   dgvData.Columns[2].Frozen = true;


                   DataGridViewCellStyle s1 = dataGridViewSummary.DefaultCellStyle.Clone();
                   s1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
                   s1.ForeColor = Color.Black;
                   DataGridViewCellStyle s2 = dataGridViewSummary.DefaultCellStyle.Clone();
                   s2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
                   s2.ForeColor = Color.BlueViolet;
                   DataGridViewCellStyle s3 = dataGridViewSummary.DefaultCellStyle.Clone();
                   s3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
                   s3.ForeColor = Color.Chocolate;
                   DataGridViewCellStyle Default = dataGridViewSummary.DefaultCellStyle.Clone();
                   Default.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Regular);

                   dataGridViewSummary.DefaultCellStyle = Default;
                   dgvData.DefaultCellStyle = Default;
                //======================Set Color================================
                   dataGridViewSummary.Columns[9].DefaultCellStyle = s1;
                   dataGridViewSummary.Columns[9].HeaderCell.Style = s1;
                   dataGridViewSummary.Columns[10].DefaultCellStyle = s1;
                   dataGridViewSummary.Columns[10].HeaderCell.Style = s1;
                   dataGridViewSummary.Columns[11].DefaultCellStyle = s1;
                   dataGridViewSummary.Columns[11].HeaderCell.Style = s1;
                   dataGridViewSummary.Columns[12].DefaultCellStyle = s1;
                   dataGridViewSummary.Columns[12].HeaderCell.Style = s1;
                   dataGridViewSummary.Columns[13].DefaultCellStyle = s1;
                   dataGridViewSummary.Columns[13].HeaderCell.Style = s1;

                   dataGridViewSummary.Columns[14].DefaultCellStyle = s2;
                   dataGridViewSummary.Columns[14].HeaderCell.Style = s2;
                   dataGridViewSummary.Columns[15].DefaultCellStyle = s2;
                   dataGridViewSummary.Columns[15].HeaderCell.Style = s2;
                   dataGridViewSummary.Columns[16].DefaultCellStyle = s2;
                   dataGridViewSummary.Columns[16].HeaderCell.Style = s2;
                   dataGridViewSummary.Columns[17].DefaultCellStyle = s2;
                   dataGridViewSummary.Columns[17].HeaderCell.Style = s2;
                   dataGridViewSummary.Columns[18].DefaultCellStyle = s2;
                   dataGridViewSummary.Columns[18].HeaderCell.Style = s2;

                   dataGridViewSummary.Columns[19].DefaultCellStyle = s3;
                   dataGridViewSummary.Columns[19].HeaderCell.Style = s3;
                   dataGridViewSummary.Columns[20].DefaultCellStyle = s3;
                   dataGridViewSummary.Columns[20].HeaderCell.Style = s3;
                   //dataGridViewSummary.Columns[21].DefaultCellStyle = s3;
                   //dataGridViewSummary.Columns[21].HeaderCell.Style = s3;
                   //dataGridViewSummary.Columns[22].DefaultCellStyle = s3;
                   //dataGridViewSummary.Columns[22].HeaderCell.Style = s3;
                   //dataGridViewSummary.Columns[23].DefaultCellStyle = s3;
                   //dataGridViewSummary.Columns[23].HeaderCell.Style = s3;
                   dataGridViewSummary.Rows[dataGridViewSummary.Rows.Count- 1].DefaultCellStyle = s1;
                //======================Set Color================================



                   //dataGridViewSummary.Columns[i].DefaultCellStyle = boldStyle;
                   //dataGridViewSummary.Columns[i].HeaderCell.Style = oldDefault;
                //       dataGridViewSummary.Columns[i].HeaderCell.Style = oldDefault;
                   //for (int i = 0; i <= dataGridViewSummary.Columns.Count - 1; i++)
                   //{
                   //    dataGridViewSummary.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                   //    if (i >= dataGridViewSummary.Columns.Count - 5)
                   //    {
                   //        System.Windows.Forms.DataGridViewCellStyle boldStyle = new System.Windows.Forms.DataGridViewCellStyle();
                   //        boldStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
                   //        dataGridViewSummary.Columns[i].DefaultCellStyle = boldStyle;
                   //        dataGridViewSummary.Columns[i].HeaderCell.Style = oldDefault;
                   //    }
                   //}
                   
                //dgvData.Columns[dgvData.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                   this.dataGridViewSummary.AlternatingRowsDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
                   dataGridViewSummary.RowsDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
                   for (int i = 0; i < dataGridViewSummary.Columns.Count; i++)
                   {
                       int colw = dataGridViewSummary.Columns[i].Width;
                       dataGridViewSummary.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                       dataGridViewSummary.Columns[i].Width = colw;
                   }
                   this.dgvData.AlternatingRowsDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
                   dgvData.RowsDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
                   for (int i = 0; i < dgvData.Columns.Count; i++)
                   {
                       int colw = dgvData.Columns[i].Width;
                       dgvData.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                       dgvData.Columns[i].Width = colw;
                   }

                if(dataGridViewSummary.Columns.Contains("ยอด"))
                    dataGridViewSummary.Columns["ยอด"].Visible=OpenFee;
                if (dgvData.Columns.Contains("ค่าแพทย์"))
                    dgvData.Columns["ค่าแพทย์"].Visible = OpenFee;

                if (dataGridViewSummary.Columns.Contains("ค่าคอม"))
                    dataGridViewSummary.Columns["ค่าคอม"].Visible = OpenFee;
                if (dgvData.Columns.Contains("ค่าคอม"))
                    dgvData.Columns["ค่าคอม"].Visible = OpenFee;
                  
                
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                txtEnddate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                txtStartdate.Text = DateTime.Now.AddMonths(-1).ToString("dd-MM-yyyy");
                return;
            }
            finally
            {
            }
        }
        private DataTable CalTotalLastRow(DataTable dt)
        {

            try
            {
                double PriceAfterDis = 0;
                double PriceAfterDisShare = 0;
                double AESTHETIC = 0;
                double SURGERY = 0;
                double HAIR = 0;
                double WELLNESS = 0;
                double PHAMACY = 0;
                double Referral = 0;
                double PRO_CREDIT = 0;
                double TOTAL = 0;
                double TOTALVat = 0;
                double TOTALDisVat = 0;
                foreach (DataRow item in dt.Rows)
                {
                    PriceAfterDis += item["PriceAfterDis"].ToString().Replace(",", "") == "" ? 0 : Convert.ToDouble(item["PriceAfterDis"].ToString().Replace(",", ""));
                    PriceAfterDisShare += item["PriceAfterDisShare"].ToString().Replace(",", "") == "" ? 0 : Convert.ToDouble(item["PriceAfterDisShare"].ToString().Replace(",", ""));
                    AESTHETIC += item["AESTHETIC"].ToString().Replace(",", "") == "" ? 0 : Convert.ToDouble(item["AESTHETIC"].ToString().Replace(",", ""));
                    SURGERY += item["SURGERY"].ToString().Replace(",", "") == "" ? 0 : Convert.ToDouble(item["SURGERY"].ToString().Replace(",", ""));
                    HAIR += item["HAIR"].ToString().Replace(",", "") == "" ? 0 : Convert.ToDouble(item["HAIR"].ToString().Replace(",", ""));
                    WELLNESS += item["WELLNESS"].ToString().Replace(",", "") == "" ? 0 : Convert.ToDouble(item["WELLNESS"].ToString().Replace(",", ""));
                    PHAMACY += item["PHAMACY"].ToString().Replace(",", "") == "" ? 0 : Convert.ToDouble(item["PHAMACY"].ToString().Replace(",", ""));
                    //Referral += item["Referral"].ToString().Replace(",", "") == "" ? 0 : Convert.ToDouble(item["Referral"].ToString().Replace(",", ""));
                    PRO_CREDIT += item["PRO_CREDIT"].ToString().Replace(",", "") == "" ? 0 : Convert.ToDouble(item["PRO_CREDIT"].ToString().Replace(",", ""));
                    TOTAL += item["ยอดรวม"].ToString().Replace(",", "") == "" ? 0 : Convert.ToDouble(item["ยอดรวม"].ToString().Replace(",", ""));
                    //TOTALVat += item["ภาษี"].ToString().Replace(",", "") == "" ? 0 : Convert.ToDouble(item["ภาษี"].ToString().Replace(",", ""));
                    //TOTALDisVat += item["ยอดหลังหักภาษี"].ToString().Replace(",", "") == "" ? 0 : Convert.ToDouble(item["ยอดหลังหักภาษี"].ToString().Replace(",", ""));
                }
                DataRow totalsRow = dt.NewRow();
                totalsRow["Name"] = "ยอดรวม";
                totalsRow["PriceAfterDis"] = PriceAfterDis.ToString("###,###,###,###");
                totalsRow["PriceAfterDisShare"] = PriceAfterDisShare.ToString("###,###,###,###");
                totalsRow["AESTHETIC"] = AESTHETIC.ToString("###,###,###,###");
                totalsRow["SURGERY"] = SURGERY.ToString("###,###,###,###");
                totalsRow["HAIR"] = HAIR.ToString("###,###,###,###");
                totalsRow["WELLNESS"] = WELLNESS.ToString("###,###,###,###");
                totalsRow["PHAMACY"] = PHAMACY.ToString("###,###,###,###");
                //totalsRow["Referral"] = Referral.ToString("###,###,###,###");
                totalsRow["PRO_CREDIT"] = PRO_CREDIT.ToString("###,###,###,###");
                totalsRow["ยอดรวม"] = TOTAL.ToString("###,###,###,###");
                //totalsRow["ภาษี"] = TOTALVat.ToString("###,###,###,###");
                //totalsRow["ยอดหลังหักภาษี"] = TOTALDisVat.ToString("###,###,###,###");
                //dt.Rows.Add(totalsRow);
                //totalsRow = dt.NewRow();
                //totalsRow["Name"] = "ภาษี " + (Entity.Userinfo.VatRate * 100) + " %";
                //totalsRow["PriceAfterDis"] = ((PriceAfterDis * Entity.Userinfo.VatRate)).ToString("###,###,###,###");
                //totalsRow["PriceAfterDisShare"] = ((PriceAfterDisShare * Entity.Userinfo.VatRate)).ToString("###,###,###,###");
                //totalsRow["AESTHETIC"] = ((AESTHETIC * Entity.Userinfo.VatRate)).ToString("###,###,###,###");
                //totalsRow["SURGERY"] = ((SURGERY * Entity.Userinfo.VatRate)).ToString("###,###,###,###");
                //totalsRow["HAIR"] = ((HAIR * Entity.Userinfo.VatRate)).ToString("###,###,###,###");
                //totalsRow["WELLNESS"] = ((WELLNESS * Entity.Userinfo.VatRate)).ToString("###,###,###,###");
                //totalsRow["PHAMACY"] = ((PHAMACY * Entity.Userinfo.VatRate)).ToString("###,###,###,###");
                //totalsRow["Referral"] = ((Referral * Entity.Userinfo.VatRate)).ToString("###,###,###,###");
                //totalsRow["PRO_CREDIT"] =(( PRO_CREDIT * Entity.Userinfo.VatRate)).ToString("###,###,###,###");
                //totalsRow["ยอดรวม"] = ((TOTAL * Entity.Userinfo.VatRate)).ToString("###,###,###,###");
                ////totalsRow["ภาษี"] = ((TOTALVat * Entity.Userinfo.VatRate)).ToString("###,###,###,###");
                ////totalsRow["ยอดหลังหักภาษี"] = ((TOTALDisVat * Entity.Userinfo.VatRate)).ToString("###,###,###,###");
                //dt.Rows.Add(totalsRow);
                //totalsRow = dt.NewRow();
                //totalsRow["Name"] = "ยอดหลังหักภาษี";
                //totalsRow["PriceAfterDis"] = (PriceAfterDis - (PriceAfterDis * Entity.Userinfo.VatRate)).ToString("###,###,###,###");
                //totalsRow["PriceAfterDisShare"] = (PriceAfterDisShare - (PriceAfterDisShare * Entity.Userinfo.VatRate)).ToString("###,###,###,###");
                //totalsRow["AESTHETIC"] = (AESTHETIC - (AESTHETIC * Entity.Userinfo.VatRate)).ToString("###,###,###,###");
                //totalsRow["SURGERY"] = (SURGERY - (SURGERY * Entity.Userinfo.VatRate)).ToString("###,###,###,###");
                //totalsRow["HAIR"] = (HAIR - (HAIR * Entity.Userinfo.VatRate)).ToString("###,###,###,###");
                //totalsRow["WELLNESS"] = (WELLNESS - (WELLNESS * Entity.Userinfo.VatRate)).ToString("###,###,###,###");
                //totalsRow["PHAMACY"] = (PHAMACY - (PHAMACY * Entity.Userinfo.VatRate)).ToString("###,###,###,###");
                //totalsRow["Referral"] = (Referral - (Referral * Entity.Userinfo.VatRate)).ToString("###,###,###,###");
                //totalsRow["PRO_CREDIT"] = (PRO_CREDIT - (PRO_CREDIT * Entity.Userinfo.VatRate)).ToString("###,###,###,###");
                //totalsRow["ยอดรวม"] = (TOTAL - (TOTAL * Entity.Userinfo.VatRate)).ToString("###,###,###,###");
                ////totalsRow["ภาษี"] = (TOTALVat - (TOTALVat * Entity.Userinfo.VatRate)).ToString("###,###,###,###");
                ////totalsRow["ยอดหลังหักภาษี"] = (TOTALDisVat - (TOTALDisVat * Entity.Userinfo.VatRate)).ToString("###,###,###,###");
                dt.Rows.Add(totalsRow);

            }
            catch (Exception)
            {
               
            }
            return dt;
        }
        private DataTable CalCommission(DataTable dt)
        {
            int level=0;
            double salePrice = 0;
            double salePrice1 = 0;
            double salePrice2 = 0;
            double rate = 0;
            foreach (DataRow item in dt.Rows)
            {
                
                level = 0;
                salePrice = item["ยอดหลังหักภาษี"] + ""==""?0:Convert.ToDouble(item["ยอดหลังหักภาษี"] + "");
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
                item["Rate"] = salePrice == 0 ? 0 : rate * 100;
                item["Commission"] = Commission.ToString("###,###,###,###");

                salePrice1 = item["ยอดหลังหักภาษี1"] + "" == "" ? 0 : Convert.ToDouble(item["ยอดหลังหักภาษี1"] + "");
                salePrice = item["ยอดหลังหักภาษี1"] + "" == "" ? 0 : Convert.ToDouble(item["ยอดหลังหักภาษี1"] + "");
                item["Rate1"] = salePrice == 0 ? 0 : Entity.Userinfo.COM_PRODUCT_RATE * 100;
                item["Commission1"] = (salePrice * Entity.Userinfo.COM_PRODUCT_RATE).ToString("###,###,###,###");

                //salePrice2 = item["ยอดหลังหักภาษี2"] + "" == "" ? 0 : Convert.ToDouble(item["ยอดหลังหักภาษี2"] + "");
                //salePrice = item["ยอดหลังหักภาษี2"] + "" == "" ? 0 : Convert.ToDouble(item["ยอดหลังหักภาษี2"] + "");
                //item["Rate2"] = salePrice == 0 ? 0 : Entity.Userinfo.COM_REFERRAL_RATE * 100;
                //item["Commission2"] = (salePrice * Entity.Userinfo.COM_REFERRAL_RATE).ToString("###,###,###,###");
                
            }
            //foreach (DataRow item in dt.Rows)
            //{
            //    salePrice = item["ยอดหลังหักภาษี1"] + "" == "" ? 0 : Convert.ToDouble(item["ยอดหลังหักภาษี1"] + "");
            //    item["Rate1"] = salePrice == 0 ? 0 : Entity.Userinfo.COM_PRODUCT_RATE * 100;
            //    item["Commission1"] = (salePrice * Entity.Userinfo.COM_PRODUCT_RATE).ToString("###,###,###,###");
            //}
            //foreach (DataRow item in dt.Rows)
            //{

            //    level = 0;
            //    salePrice = item["ยอดหลังหักภาษี2"] + "" == "" ? 0 : Convert.ToDouble(item["ยอดหลังหักภาษี2"] + "");
            //    foreach (KeyValuePair<double, double> valuePair in DicComRate)
            //    {
            //        if (salePrice > valuePair.Key && level < DicComRate.Count - 1)
            //        {
            //            level++;
            //            continue;
            //        }
            //        Commission = salePrice * valuePair.Value;
            //        rate = valuePair.Value;
            //        //lblComRate.Text = "Com : " + (valuePair.Value * 100).ToString() + " %";
            //        level++;
            //        break;

            //    }
            //    item["Rate2"] =salePrice==0?0: rate * 100;
            //    item["Commission2"] = Commission.ToString("###,###,###,###");
            //}
            return dt;

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
                        EMPName = obj.StaffsName.Replace(',',' ').Trim();
                    if (!string.IsNullOrEmpty(obj.EmployeeId))
                        EMPID = obj.EmployeeId.Replace(',', ' ').Trim();
                    EMPTypID=obj.EmployeeTypeId;
                    BindDataCommission(1);
                    dgvData.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                    dataGridViewSummary.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmCommissionCheck_Load(object sender, EventArgs e)
        {
            try
            {
                lblEN.Text = "";
                lblEmployeeName.Text = "";
                txtMoney.Text = "";
                txtCommoney.Text = "";
                txtEnddate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                txtStartdate.Text = DateTime.Now.AddMonths(-1).ToString("dd-MM-yyyy");
                BindCommissionRate();
                setForYears();
                setForMonth();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        

           // PopEMP();
           // BindDataCommission(1);
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
        private void FrmCommissionCheck_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics.frmCommissionCheck = null;
          }

        private void dgvData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        private void dataGridViewSummary_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        private void dataGridViewSummary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
                string en = dataGridViewSummary["EN", e.RowIndex].Value + "";
                dsSurgeryFee.Tables[0].DefaultView.RowFilter = string.Format("[EN_COMS1] LIKE '%{0}%' or [EN_COMS2] LIKE '%{1}%' ", en,en);
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

        private void txtStartdate_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DateTimeUtil.SelectDate(txtStartdate);
            //SelectDate(txtStartdate);
        }

        private void txtEnddate_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                BindDataCommission(1);
        }

        private void txtEnddate_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DateTimeUtil.SelectDate(txtEnddate);
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
                    using (ClosedXML.Excel.XLWorkbook wb = new ClosedXML.Excel.XLWorkbook())
                    {
                        
                        ExportFile exp = new ExportFile();
                        wb.Worksheets.Add(exp.GetDataTableFromDGV(dgvData, "Result"));
                        //wb.Worksheets.Worksheet(0).Cells[rowIndex, 22].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        wb.Worksheets.Worksheet(1).Column("J").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        //wb.Worksheets.Add(dsSurgeryFee.Tables[0],"Data");
                        //if (dsSurgeryFee.Tables.Count > 2)
                        wb.Worksheets.Add(exp.GetDataTableFromDGV(dataGridViewSummary, "Summary"));
                        wb.Worksheets.Worksheet(2).Column("B").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        //wb.Worksheets.Add(dsSurgeryFee.Tables[1],"Summary");
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

        private void dataGridViewSummary_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.Value.ToString() == "0") e.Value = "";
                //if(e.ColumnIndex>1)
                //    dataGridViewSummary.Columns[e.ColumnIndex].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
               
            }
            catch (Exception)
            {
               
            }
        }

        private void dgvData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.Value.ToString() == "0") e.Value = "";
            }
            catch (Exception)
            {

            }
        }

      
    }
}
