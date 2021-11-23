using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AryuwatSystem.DerClass;
using AryuwatSystem.Properties;
using Entity;
using System.Net;
using System.Net.Sockets;

namespace AryuwatSystem.Forms
{
    public partial class PopAlertMedicalSuppliesStock : Form
    {   
        public PopAlertMedicalSuppliesStock()
        {
            InitializeComponent();
            //SELECTMINSTOCK
            var ds = new Business.MedicalSupplies().SelectMinStock();

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count != 0)
                {
                    gv_MinimumStock.DataSource = ds;
                }
                else
                {
                    gv_MinimumStock.DataSource = null;
                }
            }

        }

        private void PopAlertMedicalSuppliesStock_Load(object sender, EventArgs e)
        {
            var ds = new Business.MedicalSupplies().SelectMinStock();

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count != 0)
                {
                    gv_MinimumStock.DataSource = ds.Tables[0];
                }
                else
                {
                    gv_MinimumStock.DataSource = null;
                }
            }
        }

        private void chkNotiMinimumStock_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkNotiMinimumStock.Checked)
            {
                Entity.Userinfo.notiminimum = true;
            }
            else
            {
                var s = MessageBox.Show("ยืนยันการปิดการแจ้งเตือนสินค้า/เวชภัณฑ์ [Yes/No]", "แจ้งเตือน", MessageBoxButtons.YesNo);
                if (s == DialogResult.Yes)
                {
                    chkNotiMinimumStock.Checked = true;
                    Entity.Userinfo.notiminimum = false;
                }
                else
                {
                    chkNotiMinimumStock.Checked = false;
                    Entity.Userinfo.notiminimum = true;
                }
            }
        }
    }
}
