using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DermasterSystem.Class;

namespace DermasterSystem.Forms
{
    public partial class PopTypeCustomer : Form
    {
        public PopTypeCustomer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// CNT = ลูกค้า Walk-in (คนไทย)-AC
        /// CNF = Foreign Customer/Web-IC
        /// CNA = Agency's Customer-IC
        /// CNM = Mgt.  Customer-IC
        /// CNE = Employee.  Customer-IC
        /// </summary>
        public string TypeCustomer { get; set; }

   
        private void OpenCustomer(string typ)
        {
            try
            {
                 Statics.frmCustormerSetting = new FrmCustomerSetting();
            Statics.frmCustormerSetting.BackColor = Color.FromArgb(170, 232, 229);
            Statics.frmCustormerSetting.Text = "ข้อมูลลูกค้า" + Statics.StrAdd;
            Statics.frmCustormerSetting.TypeCustomer = typ;
            Statics.frmCustormerSetting.Show(Statics.frmMain.dockPanel1);
            Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnNormalUser_Click(object sender, EventArgs e)
        {
            OpenCustomer("T");
        }
        private void btnForeignCust_Click(object sender, EventArgs e)
        {
            OpenCustomer("F");
        }
        private void btnArubCust_Click(object sender, EventArgs e)
        {
            OpenCustomer("A");
        }
        private void btnChineseCust_Click(object sender, EventArgs e)
        {
            OpenCustomer("C");
        }

        private void btnEnglistCust_Click(object sender, EventArgs e)
        {
            OpenCustomer("E");
        }
        private void btnEmployeeCust_Click(object sender, EventArgs e)
        {
            OpenCustomer("S");
        }

        private void btnVIPCust_Click(object sender, EventArgs e)
        {
            OpenCustomer("M");
        }
       

    }
}
