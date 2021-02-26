using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DermasterSystem.Class;
using Entity;
using WeifenLuo.WinFormsUI.Docking;

namespace DermasterSystem.Forms
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

        private Dictionary<double, double> DicComRate;
        double Sales = 0;
        double Commission = 0;
        private string EMPTypID = "";
        public bool SurgiFeeTYP = true;
        
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
        public void BindDataCommission(int _pIntseq)
        {
            try
            {
                Sales = 0;
                setColumn();
                if (dgvData.Rows.Count>0)dgvData.Rows.RemoveAt(0);
                dgvData.Rows.Clear();
                dgvData.DataSource = null;
                //int pIntseq = _pIntseq;
                 SurgeryFee info = new SurgeryFee(); 
                if (!string.IsNullOrEmpty(lblEN.Text.Trim()))
                {
                    info.CN =  lblEN.Text ;
                }
                //string wdate = EMPTypID == "17" ? "Com_Date" : "ProcedureDate";
                string wdate = radioButtonSale.Checked ? "Com_Date" : "ProcedureDate";
                
                if (dtpDateStart.Checked)
                {
                    info.whereDate = wdate+" >='" + dtpDateStart.Value.ToString("yyyy-MM-dd 00:00:00") + "'";
                    //mydate between ('3/01/2013 12:00:00') and ('3/30/2013 12:00:00')
                }
                if (dtpDateEnd.Checked)
                {
                    info.whereDate = wdate + " <='" + dtpDateStart.Value.ToString("yyyy-MM-dd 23:59:59") + "'";
                    //mydate between ('3/01/2013 12:00:00') and ('3/30/2013 12:00:00')
                }
                if (dtpDateStart.Checked && dtpDateEnd.Checked)
                {
                    info.whereDate = wdate + " between ('" + dtpDateStart.Value.ToString("yyyy-MM-dd 00:00:00") + "') and ('" + dtpDateEnd.Value.ToString("yyyy-MM-dd 23:59:59") + "')";
                }
                if (!dtpDateStart.Checked && !dtpDateEnd.Checked)
                {
                    info.whereDate = " 1=1 ";
                }
                //info.QueryType = EMPTypID == "17" ? "SELECTCOMMISSIONSALE" : "SELECTCOMMISSIONFEE";
                info.QueryType = radioButtonSale.Checked ? "SELECTCOMMISSIONSALE" : "SELECTCOMMISSIONFEE";
                DataSet dsSurgeryFee = new Business.StuffCommission().SelectSurgeryFee(info);

                long lngTotalPage = 0;
                long lngTotalRecord = 0;
                if (dsSurgeryFee.Tables.Count <= 0)
                {
                    if (dsSurgeryFee.Tables[0].Rows.Count <= 0)
                    {
                        Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "ไม่พบข้อมูลในระบบ");
                        return;
                    }
                }
               
                if(dsSurgeryFee.Tables[0].Columns.Count<2)return;
                if (radioButtonFee.Checked)
                {
                    foreach (DataRowView item in dsSurgeryFee.Tables[0].DefaultView)
                    {
                        //this.VN,this.MS_Name,this.CourseUse,this.ProcedureDate,this.StartTime,this.EndTime,this.Money});
                        double m = string.IsNullOrEmpty(item["Com_Bath"] + "") ? 0 : Convert.ToDouble(item["Com_Bath"] + "");
                        var myItems = new IComparable[]
                                      {
                                          item["VN"] + "",
                                          item["sono"] + "",
                                          item["CN"] + "",
                                          item["CustFullNameThai"] + "",
                                          item["FullNameThai"] + "",
                                          item["MS_Name"] + "",
                                          item["Position_Name"] + "",
                                          Convert.ToDateTime(item["ProcedureDate"] + "").ToString("dd/MM/yyyy"),
                                          Convert.ToDateTime(item["StartProcedure"] + "").ToString("HH:mm:00"),
                                          Convert.ToDateTime(item["EndProcedure"] + "").ToString("HH:mm:00"),
                                          m.ToString("#,###,###.##"),
                                           item["Complimentary"]+""== "Y"?true:false ,
                                           item["MarketingBudget"]+""== "Y"?true:false,
                                           item["Gift"]+""== "Y"?true:false,
                                           item["Subject"]+""== "Y"?true:false
                                      };
                        dgvData.Rows.Add(myItems);
                        Sales += m;
                    }
                }
                else
                {
                    foreach (DataRowView item in dsSurgeryFee.Tables[0].DefaultView)
                    {
                        double m = string.IsNullOrEmpty(item["Com_Bath"] + "") ? 0 : Convert.ToDouble(item["Com_Bath"] + "");
                        var myItems = new IComparable[]
                                      {"",
                                          item["SO"] + "",
                                          item["CN"] + "",
                                          item["CustFullNameThai"] + "",
                                          "dddd",
                                          "xxxx",
                                          "yyyyy",
                                         
                                          String.Format("{0:yyyy/MM/dd}",item["ProcedureDate"] + ""),
                                           "zzzz",
                                              "zaaazzz",
                                          m.ToString("#,###,###.##")
                                      };
                        dgvData.Rows.Add(myItems);
                        Sales += m;
                    }
                }
                //dgvData.Columns[0].Visible = false;
                txtMoney.Text = Sales.ToString("###,###,###.##");
                CalCommission();
            }
            catch (Exception ex)
            {
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeError, ex.Message);
                
                return;
            }
            finally
            {
            }
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
                lblComRate.Text = "Com : " + (valuePair.Value*100).ToString() + " %";
                level++;
                break;
               
            }
            txtCommoney.Text = Commission.ToString("##,###,###.##");

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
                    obj.BackColor = Color.FromArgb(170, 232, 229);
                    obj.multiSelect = false;
                    obj._queryType = "LISTNAMECOMMISSION";
                    obj.ShowDialog();

                    if (!string.IsNullOrEmpty(obj.StaffsName))
                        EMPName = obj.StaffsName.Replace(',',' ').Trim();
                    if (!string.IsNullOrEmpty(obj.EmployeeId))
                        EMPID = obj.EmployeeId.Replace(',', ' ').Trim();
                    EMPTypID=obj.EmployeeTypeId;
                    BindDataCommission(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmCommissionCheck_Load(object sender, EventArgs e)
        {
            lblEN.Text = "";
            lblEmployeeName.Text = "";
            txtMoney.Text = "";
            txtCommoney.Text = "";
            BindCommissionRate();

            PopEMP();
           // BindDataCommission(1);
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

      
    }
}
