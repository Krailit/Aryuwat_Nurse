using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AryuwatSystem.Forms
{
    public partial class popRecieptSelectAdd : Form
    {
        public decimal ReceiptBath { get; set; }
        public DateTime Lastdate { get; set; }

        public decimal UnpaidBath { get; set; }
        public decimal ReceiptSum { get; set; }
        public decimal NetTotal { get; set; }
        public decimal? MaxPay { get; set; }

        public DateTime ReceiptDate { get; set; }
        public string RCNo { get; set; }
        public string SO { get; set; }
        public List<string> itemselect { get; set; }

        public popRecieptSelectAdd()
        {
            InitializeComponent();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            try
            {


                //ReceiptBath = txtMoney.Text == "" ? 0 : Convert.ToDecimal(txtMoney.Text);
                //if (ReceiptSum - ReceiptBath + (txtMoney.Text == "" ? 0 : Convert.ToDecimal(txtMoney.Text)) > NetTotal)
                //{
                //    MessageBox.Show("จำนวนเงินไม่ถูกต้อง", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                //if (Convert.ToDecimal(txtMoney.Text == "" ? "0" : txtMoney.Text) > UnpaidBath || Convert.ToDecimal(txtMoney.Text == "" ? "0" : txtMoney.Text) <= 0)
                //{
                //    MessageBox.Show("จำนวนเงินไม่ถูกต้อง", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                SO = cbbListItem.Text;
                ReceiptBath = Convert.ToDecimal(txtMoney.Text);
                ReceiptDate = Convert.ToDateTime(AryuwatSystem.DerClass.DerUtility.ToFormatDateyyyyMMdd(txtStartdate.Text));

                if (ReceiptDate < Lastdate)
                {
                    MessageBox.Show("วันที่ซ้ำ หรือ ไม่สามารถเลือกวันที่ย้อนหลังได้", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                //RefundType = comboBoxType.SelectedValue.ToString();
                //RefundRemark = txtRemark.Text;

                //DataSet ds = new Business.SumOfTreatment().SAVERCNo(RCNo, SO, ReceiptDate, Entity.Userinfo.EN, ReceiptBath);
                //RCNo = ds.Tables[0].Rows[0][0]+"";
                this.DialogResult = DialogResult.OK;

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void popSOClose_Load(object sender, EventArgs e)
        {
            try
            {
                cbbListItem.DataSource = itemselect;
                //txtMoney.Text = ReceiptBath.ToString("###,###,###,###.##"); ;
                txtStartdate.Text = ReceiptDate.ToString("dd/MM/yyyy");
                this.Text += " " + RCNo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtMoney_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (Convert.ToDecimal(txtMoney.Text == "" ? "0" : txtMoney.Text) > ReceiptBath || Convert.ToDecimal(txtMoney.Text == "" ? "0" : txtMoney.Text) <= 0)
            //    {
            //            btnYes.Enabled=false;
            //            MessageBox.Show("จำนวนเงินไม่ถูกต้อง", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    } 
            //    else btnYes.Enabled=true;

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("จำนวนเงินไม่ถูกต้อง", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        private void cbbListItem_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                using (var context = new m_DataSet.EntitiesOPD_System())
                {
                    var dataSupplieTrans = context.SupplieTrans.Where(x => x.SONo == cbbListItem.Text).ToList();

                    decimal? sumsup = 0;

                    foreach (var item in dataSupplieTrans)
                    {
                        sumsup += item.PriceAfterDis;
                    }

                    decimal? creditpay = 0;

                    //var dataSumOfTreatment = context.SumOfTreatments.Where(x => x.SO == cbbListItem.Text).FirstOrDefault();

                    //if (dataSumOfTreatment != null)
                    //{
                    //    sumsup = sumsup - dataSumOfTreatment.EarnestMoney;
                    //}

                    var dataCashCreditCardSOTs = context.CashCreditCardSOTs.Where(x => x.SO == cbbListItem.Text).ToList();

                    foreach (var item in dataCashCreditCardSOTs)
                    {
                        creditpay += item.CashMoney;
                    }

                    MaxPay = sumsup - creditpay;

                    lblMax.Text = (MaxPay ?? 0).ToString("###,###,###,###.##");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"แจ้งเตือน");
            }
        }
    }
}
