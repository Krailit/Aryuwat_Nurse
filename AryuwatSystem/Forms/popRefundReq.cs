using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AryuwatSystem.Data;
using Entity;
using AryuwatSystem.DerClass;

namespace AryuwatSystem.Forms
{
    public partial class popRefundReq : Form
    {
        public double Refund { get; set; }
        public DateTime RefundDate { get; set; }
        public DateTime LastUsed { get; set; }
        public string RFD { get; set; }
        public string RefundType { get; set; }
        public string RefundRemark { get; set; }
        
        public string CN { get; set; }
        public string CustName { get; set; }
        public string ConsultName { get; set; }
        public string DrName { get; set; }
        public string CourseName { get; set; }
        public string PriceTotal { get; set; }
        public DateTime BuyDate { get; set; }
        public List<string> ItemRefund { get; set; }
        public string SONo { get; set; }
        public string VN { get; set; }
        public string RefVN { get; set; }
        public string BranchID { get; set; }
        DataTable dtRFD = new DataTable();
        public  List<Entity.SupplieTrans> listSuppleTrans { get; set; }
        
        public popRefundReq()
        {
            InitializeComponent();
            comboBoxMoneyType.MouseWheel += new MouseEventHandler(comboBoxMoneyType_MouseWheel);
            comboBoxBank.MouseWheel += new MouseEventHandler(comboBoxBank_MouseWheel);
            comboBoxType.MouseWheel += new MouseEventHandler(comboBoxType_MouseWheel);
        }

        void comboBoxType_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        void comboBoxBank_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        void comboBoxMoneyType_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
           
            SaveRFD(false);
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
        private void GetRefundMoneyType()
        {
            try
            {
               
                Entity.Refund info = new Entity.Refund() { };
                info.QueryType = "GetRefundMoneyType";

                info.StartDate = DateTime.Now;
                info.EndDate = DateTime.Now;
                DataSet ds = new Business.Refund().SelectRefund(info);
                DataRow dr = ds.Tables[0].NewRow();
                dr["MoneyID"] = "";
                dr["MoneyText"] = "--โปรดระบุ--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                comboBoxMoneyType.DataSource = ds.Tables[0];
                comboBoxMoneyType.DisplayMember = "MoneyText";
                comboBoxMoneyType.ValueMember = "MoneyID";
                //foreach (DataRow item in ds.Tables[0].Rows)
                //{
                //    if (!dicReportRang.ContainsKey(item["Rpt_Code"] + "")) dicReportRang.Add(item["Rpt_Code"] + "", item["DateRang"] + "");
                //    if (!dicReporQueryType.ContainsKey(item["Rpt_Code"] + "")) dicReporQueryType.Add(item["Rpt_Code"] + "", item["QueryType"] + "");
                //}
                //QueryType = dicReporQueryType[comboBoxReport.SelectedValue.ToString()];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SaveRFD(bool PrintOnly)
        {
            try
            {
                Entity.Refund info = new Entity.Refund();
                if(txtRefundDate.Text.Length<8)
                   MessageBox.Show("วันที่ไม่ถูกต้อง", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //List<Entity.SupplieTrans> listSuppleTrans = new List<Entity.SupplieTrans>();

                info.RFD = RFD + "";
                if (info.RFD + "" == "")
                    info.RFD =RFD= UtilityBackEnd.GenMaxSeqnoValues("RFD", BranchID);


                info.PayBankID = comboBoxBank.SelectedValue + "";
                info.PayCustName = txtPayCustName.Text.Trim();
                info.PayBankNumber = txtPayBankNumber.Text.Trim();
                
                info.PayType = comboBoxMoneyType.SelectedValue + "";
                info.RefundBath = textboxFormatDoubleRefund.Text == "" ? 0 : Convert.ToDecimal(textboxFormatDoubleRefund.Text);
                info.RefundDate = Convert.ToDateTime(AryuwatSystem.DerClass.DerUtility.ToFormatDateyyyyMMdd(txtRefundDate.Text));
                info.LastUsed = LastUsed ==DateTime.MinValue ?DateTime.Now.Date : LastUsed;
                info.RefundRemark = txtRemark.Text;
                info.RefundSince = txtRefundSince.Text;
                info.RefundType = comboBoxType.SelectedValue + "";
                info.SONo = SONo;
                info.VN = VN;
                info.RefVN = RefVN;
                info.Dr = comboBoxByDr.SelectedValue + "";
                info.Approved = checkBoxApproved.Checked?"Y":"";
                info.listSuppleTrans = listSuppleTrans;

                int? intStatus = new Business.Refund().InsertRefund(info);

                if (PrintOnly)
                {
                    GetRefund();
                    PrintRFD();
                }
                else
                {
                    if (intStatus >= 0) MessageBox.Show("Save Complete.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
         private void GetDr()
        {
            try
            {
                var infoDr = new Entity.Personnel();
                //infoDr.PersonnelType = "11";
                infoDr.QueryType = "LISTDOCTOR";
                DataTable dtDr = new Business.Personnel().SelectCustomerPaging(infoDr).Tables[0];
                DataRow drx = dtDr.NewRow();
                drx["EN"] = "";
                drx["FullNameThai"] = "--ไม่ระบุ--";
                dtDr.Rows.InsertAt(drx, 0);
                AutoCompleteStringCollection colValuesdr = new AutoCompleteStringCollection();
                foreach (DataRow row in dtDr.Rows)
                {
                    colValuesdr.Add(row["FullNameThai"].ToString());
                }


                comboBoxByDr.Items.Clear();
                comboBoxByDr.DataSource = dtDr;
                comboBoxByDr.ValueMember = "EN";
                comboBoxByDr.DisplayMember = "FullNameThai";
                comboBoxByDr.SelectedValue = "";// Entity.Userinfo.EN;
                comboBoxByDr.AutoCompleteCustomSource = colValuesdr;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void GetRefundType()
        {
            try
            {
                Entity.Refund info = new Entity.Refund() {  };
                info.QueryType = "GetRefundType";

                info.StartDate = DateTime.Now;
                info.EndDate = DateTime.Now;
                DataSet ds = new Business.Refund().SelectRefund(info);
                DataRow dr = ds.Tables[0].NewRow();
                dr["RefundID"] = "";
                dr["RefundText"] = "--โปรดระบุ--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                comboBoxType.DataSource = ds.Tables[0];
                comboBoxType.DisplayMember = "RefundText";
                comboBoxType.ValueMember = "RefundID";
                //foreach (DataRow item in ds.Tables[0].Rows)
                //{
                //    if (!dicReportRang.ContainsKey(item["Rpt_Code"] + "")) dicReportRang.Add(item["Rpt_Code"] + "", item["DateRang"] + "");
                //    if (!dicReporQueryType.ContainsKey(item["Rpt_Code"] + "")) dicReporQueryType.Add(item["Rpt_Code"] + "", item["QueryType"] + "");
                //}
                //QueryType = dicReporQueryType[comboBoxReport.SelectedValue.ToString()];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GetBank()
        {
            try
            {
                Entity.Refund info = new Entity.Refund() {  };
                info.QueryType = "GetRefundBank";

                info.StartDate = DateTime.Now;
                info.EndDate = DateTime.Now;
                DataSet ds = new Business.Refund().SelectRefund(info);
                DataRow dr = ds.Tables[0].NewRow();
                dr["CD_Code"] = "";
                dr["BankName"] = "--โปรดระบุ--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                comboBoxBank.DataSource = ds.Tables[0];
                comboBoxBank.DisplayMember = "BankName";
                comboBoxBank.ValueMember = "CD_Code";
                //foreach (DataRow item in ds.Tables[0].Rows)
                //{
                //    if (!dicReportRang.ContainsKey(item["Rpt_Code"] + "")) dicReportRang.Add(item["Rpt_Code"] + "", item["DateRang"] + "");
                //    if (!dicReporQueryType.ContainsKey(item["Rpt_Code"] + "")) dicReporQueryType.Add(item["Rpt_Code"] + "", item["QueryType"] + "");
                //}
                //QueryType = dicReporQueryType[comboBoxReport.SelectedValue.ToString()];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GetRefund()
        {
            try
            {
                Entity.Refund info = new Entity.Refund() {  };
                info.QueryType = "SelectRefundByRFD";
                info.RFD = RFD + "";
                info.StartDate = DateTime.Now;
                info.EndDate = DateTime.Now;
                DataSet ds = new Business.Refund().SelectRefund(info);
                if (ds.Tables.Count > 0)
                {
                    dtRFD = ds.Tables[0];
                    txtRFD.Text = ds.Tables[0].Rows[0]["RFD"] + "";
                    textboxFormatDoubleRefund.Text = ds.Tables[0].Rows[0]["Refund"] + "" == "" ? "0" : Convert.ToDecimal(ds.Tables[0].Rows[0]["Refund"] + "").ToString("###,###,###.##");
                    txtRemark.Text = ds.Tables[0].Rows[0]["RefundRemark"] + "";
                    txtRefundDate.Text = Convert.ToDateTime(AryuwatSystem.DerClass.DerUtility.ToFormatDateyyyyMMdd(ds.Tables[0].Rows[0]["RefundDate"] + "")).ToString("dd/MM/yyyy");
                                       
                    txtCustname.Text = "(" + ds.Tables[0].Rows[0]["CN"] + "" +")" + ds.Tables[0].Rows[0]["RFDCust"] + "";
                    txtBuy.Text = Convert.ToDateTime(AryuwatSystem.DerClass.DerUtility.ToFormatDateyyyyMMdd(ds.Tables[0].Rows[0]["CreateDate"] + "")).ToString("dd/MM/yyyy") +" เป็นเงิน " + ((ds.Tables[0].Rows[0]["NetAmount"] + ""== "") ? "0" : Convert.ToDecimal(ds.Tables[0].Rows[0]["NetAmount"] + "").ToString("###,###,###.##"));
                    //txtBuy.Text = txtBuy.Text + " เป็นเงิน " + ds.Tables[0].Rows[0]["NetAmount"] + "" == "" ? "0" : Convert.ToDecimal(ds.Tables[0].Rows[0]["NetAmount"] + "").ToString("###,###,###.##");
                    txtConsult.Text = ds.Tables[0].Rows[0]["Consult1"] + "/" + ds.Tables[0].Rows[0]["Consult2"] + "";
                    labelSO.Text = ds.Tables[0].Rows[0]["SONo"] + "," + ds.Tables[0].Rows[0]["VN"] + ",ใบยา " + ds.Tables[0].Rows[0]["RefVN"] + (ds.Tables[0].Rows[0]["LastUsed"] + "" == "" ? "" : " ใช้ล่าสุด " + Convert.ToDateTime(ds.Tables[0].Rows[0]["LastUsed"] + "").ToString("dd/MM/yyyy"));
                    LastUsed = (ds.Tables[0].Rows[0]["LastUsed"] + "" == "" ?DateTime.Now.Date :  Convert.ToDateTime(ds.Tables[0].Rows[0]["LastUsed"] + ""));
                    comboBoxByDr.SelectedValue = ds.Tables[0].Rows[0]["Dr"] + "";
                    comboBoxType.SelectedValue = ds.Tables[0].Rows[0]["RefundType"] + "";

                    checkBoxApproved.Checked = ds.Tables[0].Rows[0]["Approved"] + ""=="Y";
                    txtRefundSince.Text = ds.Tables[0].Rows[0]["RefundSince"] + "";
                    comboBoxMoneyType.SelectedValue = ds.Tables[0].Rows[0]["PayType"] + "";
                    comboBoxBank.SelectedValue=ds.Tables[0].Rows[0]["PayBankID"] + "";
                    txtPayBankNumber.Text = ds.Tables[0].Rows[0]["PayBankNumber"] + "";
                    txtPayCustName.Text = ds.Tables[0].Rows[0]["PayCustName"] + "";
                    if (dataGridViewSelectList.RowCount > 0) dataGridViewSelectList.Rows.Clear();

                    foreach (DataRow item in ds.Tables[1].Rows)
                    {
                        object[] myItems = {
                                      item["MS_Code"]+"",
                                      item["MS_Name"]+"",
                                      item["ListOrder"]+"",
                                     item["PriceAfterDis"]+""==""?"0":Convert.ToDecimal(item["PriceAfterDis"]).ToString("###,###,###.##")
                                       };
                        dataGridViewSelectList.Rows.Add(myItems);
                    }
                    dataGridViewSelectList.ClearSelection();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void popRefundReq_Load(object sender, EventArgs e)
        {
            try
            {
                if (Userinfo.IsAdmin.Contains(Userinfo.EN) || Entity.Userinfo.RFD_APPROVED.Contains(Userinfo.EN))
                {
                    checkBoxApproved.Enabled = true;
                    btnDel.Visible = true;
                }
                
              
            GetRefundType();
            GetRefundMoneyType();
            GetBank();
            GetDr();
            panelBankDetail.Visible = false;
            if (RFD + "" != "")//Load RFD
                GetRefund();
            else //new RFD
            {
                txtRFD.Text = "";
                txtCustname.Text = "(" + CN + ")" + CustName;
                txtBuy.Text = BuyDate.ToString("dd-MM-yyyy") + "/" + CourseName + " " + PriceTotal;
                txtConsult.Text = ConsultName;
                labelSO.Text = SONo + "," + VN + ",ใบยา " + RefVN + (LastUsed ==DateTime.MinValue? "" : " ใช้ล่าสุด "+LastUsed.ToString("dd/MM/yyyy"));
                txtRefundDate.Text = txtRefundDate.Text = Convert.ToDateTime(AryuwatSystem.DerClass.DerUtility.ToFormatDateyyyyMMdd(DateTime.Now.Date+"")).ToString("dd/MM/yyyy");
                foreach (Entity.SupplieTrans item in listSuppleTrans)
                {
                    object[] myItems = {
                                      item.MS_Code,
                                      item.MS_Name,
                                      item.ListOrder,
                                      item.PriceAfterDis.ToString("###,###,###.##")
                                       };
                    dataGridViewSelectList.Rows.Add(myItems);
                }
                dataGridViewSelectList.ClearSelection();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void comboBoxMoneyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxMoneyType.SelectedValue + "" == "4" || comboBoxMoneyType.SelectedValue + "" == "" || comboBoxMoneyType.Text + "" == "")
                {
                    txtPayBankNumber.Text = "";
                    txtPayCustName.Text = "";
                    comboBoxBank.SelectedValue = "";
                    //panelBankDetail.Visible = false;
                }
                else
                    panelBankDetail.Visible = true;

            }
            catch (Exception)
            {


            }
        }

        private void dataGridViewSelectList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        private void textboxFormatDoubleRefund_Leave(object sender, EventArgs e)
        {
            try
            {
                textboxFormatDoubleRefund.Text = textboxFormatDoubleRefund.Text == "" ? "0" : Convert.ToDecimal(textboxFormatDoubleRefund.Text).ToString("###,###,###.##");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                SaveRFD(true);
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void PrintRFD()
        {
            try
            {
                FrmPreviewRpt obj = new FrmPreviewRpt();
                DataRow dr;
            
                obj.FormName = "RptRFDReq";
        
                obj.ENPrint = Entity.Userinfo.TName + " " + Entity.Userinfo.TSurname;

                    obj.dt = dtRFD;
                    obj.MaximizeBox = true;
                    obj.TopMost = true;
                    obj.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (RFD + "" == "") return;

                if (DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirmYesNo,Statics.StrConfirmDelete +" เลขที่"+ RFD + "") == DialogResult.Yes)
            {
                try
                {
                   int? intStatus = new Business.Refund().DeleteRefundByRFD(RFD);
                   if (intStatus > 0)
                    {
                        DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, Statics.StrMsgDeleteComplete);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, Statics.StrMsgDeleteError + ex);
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void popRefundReq_FormClosing(object sender, FormClosingEventArgs e)
        {
            //try
            //{
            //       Statics.poprfdList = null;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

    }
}
