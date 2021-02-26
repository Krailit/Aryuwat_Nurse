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
    public partial class PopEditOrUpdateSOT : Form
    {
        public PopEditOrUpdateSOT()
        {
            InitializeComponent();
        }

        /// <summary>
        /// CNT = ลูกค้า Walk-in (คนไทย)-AC
        /// CNF = Foreign Customer/Web-IC
        /// CNA = Agency's Customer-IC
        /// CNM = Mgt.  Customer-IC
        /// </summary>
        public string TypeCustomer { get; set; }

       private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Statics.frmSumOfTreatment.SaveType = "SAVECREDITCARDUPDATE";
                Close();
            }
            catch (Exception ex)
            {
               
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Statics.frmSumOfTreatment.SaveType = "SAVECREDITCARDINSERT";
            Close();
        }

    }
}
