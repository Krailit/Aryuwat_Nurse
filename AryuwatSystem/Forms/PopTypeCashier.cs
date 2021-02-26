using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AryuwatSystem.DerClass;

namespace AryuwatSystem.Forms
{
    public partial class PopTypeCashier : Form
    {
        public PopTypeCashier()
        {
            InitializeComponent();
        }

        /// <summary>
        /// CNT = ลูกค้า Walk-in (คนไทย)-AC
        /// CNF = Foreign Customer/Web-IC
        /// CNA = Agency's Customer-IC
        /// CNM = Mgt.  Customer-IC
        /// 
        /// </summary>
        public string TypeCashier { get; set; }

        private void btnNormalUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (Statics.frmSumOfTreatment == null)
                {
                    Statics.frmSurgicalFeeList = new FrmSurgicalFeeList();
                    Statics.frmSurgicalFeeList.BackColor = Color.FromArgb(255, 230, 217);
                    Statics.frmSurgicalFeeList.Text = "Summary of Treatment List";
                    Statics.frmSurgicalFeeList.TypeCashier = "CN";
                    Statics.frmSurgicalFeeList.Show(Statics.frmMain.dockPanel1);
                }
                else
                {
                    Statics.frmSurgicalFeeList.BringToFront();
                }
                Close();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

   
        private void btnSurgicalFee_Click(object sender, EventArgs e)
        {
            if (Statics.frmSurgicalFeeList == null)
            {
                Statics.frmSurgicalFeeList = new FrmSurgicalFeeList();
                Statics.frmSurgicalFeeList.BackColor = Color.FromArgb(255, 230, 217);
                Statics.frmSurgicalFeeList.Text = "Surgical Fee List";
                Statics.frmSurgicalFeeList.TypeCashier = "EN";
                Statics.frmSurgicalFeeList.Show(Statics.frmMain.dockPanel1);
            }
            else
            {
                Statics.frmSurgicalFeeList.BringToFront();
            }
            Close();
        }

    }
}
