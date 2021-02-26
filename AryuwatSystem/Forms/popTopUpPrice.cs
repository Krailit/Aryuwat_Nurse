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
    public partial class popTopUpPrice : Form
    {
        
        public string MS_Name { get; set; }
        public string ListOrder { get; set; }
        public decimal MS_Price { get; set; }
        public decimal MS_PriceTopup { get; set; }
        public decimal PriceAfterDis { get; set; }
        public popTopUpPrice()
        {
            InitializeComponent();
        }

        private void popTopUpPrice_Load(object sender, EventArgs e)
        {
            try
            {
                PriceAfterDis = MS_Price;
                label1Name.Text = MS_Name;
                MS_PriceTopup = MS_Price - (MS_Price * Entity.Userinfo.FIX_COUPON_TOPUP);
                //txtPrice.Text = MS_Price.ToString("###,###,###.##");
                //txtPriceTopUp.Text = MS_PriceTopup.ToString("###,###,###.##");
                radioButtonPrice.Text = string.Format("ราคาเต็ม {0}",  MS_Price.ToString("###,###,###.##"));
                radioButtonPriceTopup.Text = string.Format("ราคาลด {0}% {1} ", (Entity.Userinfo.FIX_COUPON_TOPUP * 100).ToString("###,###,###.##"), MS_PriceTopup.ToString("###,###,###.##"));
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radioButtonPrice_Click(object sender, EventArgs e)
        {
            PriceAfterDis = MS_Price;
        }

        private void radioButtonPriceTopup_Click(object sender, EventArgs e)
        {
            PriceAfterDis = MS_Price - (MS_Price * Entity.Userinfo.FIX_COUPON_TOPUP);
        }
    }
}
