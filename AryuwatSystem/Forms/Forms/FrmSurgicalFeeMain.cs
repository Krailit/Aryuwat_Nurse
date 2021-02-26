using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DermasterSystem.Class;
using WeifenLuo.WinFormsUI.Docking;

namespace DermasterSystem.Forms
{
    public partial class FrmSurgicalFeeMain : DockContent
    {
        public string VN { get; set; }
        public string SONo { get; set; }
        public FrmSurgicalFeeMain()
        {
            InitializeComponent();
            
        }
        private void FrmSurgicalFeeMain_Load(object sender, EventArgs e)
        {
            try
            {

          
            //UcSurgicalFee ucSurgicalFee = new UcSurgicalFee();
            TabPage tab1;
            DataSet dsSurgeryFee = new Business.MedicalOrder().SelectMedicalOrderById(VN, SONo);
            DataTable dtSurgeryFee = dsSurgeryFee.Tables[1];//.Select("SurgicalFeeNewTab='Y'").CopyToDataTable();
            var distinctTable = dtSurgeryFee.DefaultView.ToTable(true, "MergStatus");
            foreach (DataRow row in distinctTable.Rows)
            {
                string where = "MergStatus='" + row["MergStatus"] + "'";
                foreach (DataRow dr in dtSurgeryFee.Select(where))
                {
                    if (dr["SurgicalFeeTyp"] + ""=="")continue;
                    tab1 = new TabPage();
                    tab1.Text = dr["MS_Name"] + "";
                    tab1.Name = dr["MergStatus"] + "";

                    UcSurgicalFee surgical = new UcSurgicalFee();
                    surgical.DsSurgicalFee = dsSurgeryFee;
                    surgical.MS_Code = dr["MergStatus"] + "";
                    surgical.VN = VN;
                    //surgical.CN = c;
                    surgical.TypeCashier = dr["SurgicalFeeTyp"] + "";
                    surgical.Dock = DockStyle.Fill;
                    surgical.BackColor = Color.FromArgb(170, 232, 229);
                    tab1.Controls.Add(surgical);
                    tabControl.Controls.Add(tab1);
                    break;
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        
        }

    }
}
