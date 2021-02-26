using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AryuwatSystem.DerClass;
using WeifenLuo.WinFormsUI.Docking;

namespace AryuwatSystem.Forms
{
    public partial class FrmSurgicalFeeMain : DockContent
    {
        public string VN { get; set; }
        public string SONo { get; set; }
        public string CN { get; set; }
        public string MS_Code { get; set; }
        public string ListOrder { get; set; }
        public string UseTransID { get; set; }
        
        public DataSet dsSurgeryFee;
        public DataTable dtSurgeryFee;
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
            //DataSet dsSurgeryFee = new Business.MedicalOrder().SelectMedicalOrderById(VN, SONo);
            //DataTable dtSurgeryFee = dsSurgeryFee.Tables[1];//.Select("SurgicalFeeNewTab='Y'").CopyToDataTable();
            //var distinctTable = dtSurgeryFee.DefaultView.ToTable(true, "MergStatus");
            //int PHAMACYCount = 0;
            //int MSCount = 0;
            //foreach (DataRow row in distinctTable.Rows)
            //{
                //string where = "MergStatus='" + row["MergStatus"] + "'";
            string CustomerName = dsSurgeryFee.Tables[0].Rows[0]["FullNameThai"]+"";
                foreach (DataRow dr in dtSurgeryFee.Rows)
                {
                    if ((MS_Code+"").Length > 3)//=============เปิดแบบทางลัด=========================
                    {
                        if (MS_Code == dr["MergStatus"] + "" && ListOrder == dr["ListOrder"] + "")
                        {
                            if (dr["SurgicalFeeTyp"] + "" == "" || dr["SurgicalFeeTyp"] + "" == "PHARMACY")
                           // if (dr["SurgicalFeeTyp"] + "" == "")
                            {
                                continue;
                            }
                            string ms_code = dr["MergStatus"] + "";
                            string section = ms_code.Substring(0, 3);
                            if (section.ToLower() == "cae" || section.ToLower() == "cwe" || section.ToLower() == "csu")
                            {
                                continue;
                            }
                            tab1 = new TabPage();
                            tab1.Text = dr["MS_Name"] + "";
                            tab1.Name = dr["MergStatus"] + "";
                            if (dr["SurgicalFeeTyp"] + "" == "SURGERY" || dr["SurgicalFeeTyp"] + "" == "HAIR")
                            {
                                UcSurgicalFeeOR surgical = new UcSurgicalFeeOR();
                                surgical.DsSurgicalFee = dsSurgeryFee;
                                surgical.MS_Code = dr["MergStatus"] + "";
                                surgical.ListOrder = dr["ListOrder"] + "";
                                surgical.Sono = dr["Sono"] + "";
                                surgical.VN = VN;
                                surgical.CN = CN;// dr["CN"] + ""; 
                                surgical.CustomerName = CustomerName;
                                surgical.UseTransID = UseTransID;
                                surgical.TypeCashier = dr["SurgicalFeeTyp"] + "";
                                surgical.Dock = DockStyle.Fill;
                                surgical.BackColor = Color.FromArgb(255, 230, 217);
                                tab1.Controls.Add(surgical);
                                tabControl.Controls.Add(tab1);
                            }
                            else
                            {
                                UcSurgicalFeeNotOR surgical = new UcSurgicalFeeNotOR();
                                surgical.DsSurgicalFee = dsSurgeryFee;
                                surgical.MS_Code = dr["MergStatus"] + "";
                                surgical.ListOrder = dr["ListOrder"] + "";
                                surgical.Sono = dr["Sono"] + "";
                                surgical.VN = VN;
                                surgical.CN = CN;// dr["CN"] + ""; 
                                surgical.CustomerName = CustomerName;
                                surgical.UseTransID = UseTransID;
                                surgical.TypeCashier = dr["SurgicalFeeTyp"] + "";
                                surgical.Dock = DockStyle.Fill;
                                surgical.BackColor = Color.FromArgb(255, 230, 217);
                                tab1.Controls.Add(surgical);
                                tabControl.Controls.Add(tab1);
                            }
                            break;
                        }
                    }
                    else//=============เปิดแบบธรรมดา=========================
                    {
                        if (dr["SurgicalFeeTyp"] + "" == "" || dr["SurgicalFeeTyp"] + "" == "PHARMACY")
                        {
                            continue;
                        }
                        string ms_code = dr["MergStatus"] + "";
                        string section = ms_code.Substring(0, 3);
                        if (section.ToLower() == "cae" || section.ToLower() == "cwe" || section.ToLower() == "csu")
                        {
                            continue;
                        }
                        tab1 = new TabPage();
                        tab1.Text = dr["MS_Name"] + "";
                        tab1.Name = dr["MergStatus"] + "";
                        if (dr["SurgicalFeeTyp"] + "" == "SURGERY" || dr["SurgicalFeeTyp"] + "" == "HAIR")
                        {
                            UcSurgicalFeeOR surgical = new UcSurgicalFeeOR();
                            surgical.DsSurgicalFee = dsSurgeryFee;
                            surgical.MS_Code = dr["MergStatus"] + "";
                            surgical.ListOrder = dr["ListOrder"] + "";
                            surgical.Sono = dr["Sono"] + "";
                            surgical.VN = VN;
                            surgical.CN = CN;// dr["CN"] + ""; 
                            surgical.CustomerName = CustomerName;
                            surgical.TypeCashier = dr["SurgicalFeeTyp"] + "";
                            surgical.Dock = DockStyle.Fill;
                            surgical.BackColor = Color.FromArgb(255, 230, 217);
                            tab1.Controls.Add(surgical);
                            tabControl.Controls.Add(tab1);
                        }
                        else
                        {
                            UcSurgicalFeeNotOR surgical = new UcSurgicalFeeNotOR();
                            surgical.DsSurgicalFee = dsSurgeryFee;
                            surgical.MS_Code = dr["MergStatus"] + "";
                            surgical.ListOrder = dr["ListOrder"] + "";
                            surgical.Sono = dr["Sono"] + "";
                            surgical.VN = VN;
                            surgical.CN = CN;// dr["CN"] + ""; 
                            surgical.CustomerName = CustomerName;
                            surgical.TypeCashier = dr["SurgicalFeeTyp"] + "";
                            surgical.Dock = DockStyle.Fill;
                            surgical.BackColor = Color.FromArgb(255, 230, 217);
                            tab1.Controls.Add(surgical);
                            tabControl.Controls.Add(tab1);
                        }
                    }
                    
                    
                    
                    //break;
                }
              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        
        }

    }
}
