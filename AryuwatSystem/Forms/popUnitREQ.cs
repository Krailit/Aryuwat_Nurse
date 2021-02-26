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
    public partial class popUnitREQ : Form
    {
        public string MainUnitCode { get; set; }
        public string SubUnitCode { get; set; }
        public string MainUnitName { get; set; }
        public string SubUnitName { get; set; }

        public string SelectValues { get; set; }
        public string SelectText { get; set; }
        DataSet dataSet;
        public popUnitREQ()
        {
            InitializeComponent();
     
        }
     
       

        private void btnYes_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
                MessageBox.Show("กรุณาเลือกหน่วย");
                return;
            }

            SelectValues = radioButton1.Checked ? MainUnitCode : SubUnitCode;
            SelectText = radioButton1.Checked ? MainUnitName : SubUnitName;
            this.DialogResult = DialogResult.OK;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void popUnitREQ_Load(object sender, EventArgs e)
        {
            try
            {
                radioButton1.Text = MainUnitName;
                radioButton2.Text = SubUnitName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 

        }
    }

}
