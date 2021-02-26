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
    public partial class popAlert : Form
    {
        public string txtShow="";
        public string txtTitle="";
        public popAlert()
        {
            InitializeComponent();
        }

        private void popAlert_Load(object sender, EventArgs e)
        {
            labelShow.Text = txtShow;
            this.Text = txtTitle;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
          this.DialogResult=  DialogResult.Yes;
            
          
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
    }
}
