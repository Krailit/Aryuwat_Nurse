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
    public partial class PopSurgery : Form
    {
        public PopSurgery()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PopEmpSearch obj = new PopEmpSearch();
            obj.StartPosition = FormStartPosition.CenterParent;
            obj.BackColor = Color.FromArgb(255, 230, 217);
            obj.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
