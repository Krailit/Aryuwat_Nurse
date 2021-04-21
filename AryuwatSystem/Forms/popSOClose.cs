using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entity;

namespace AryuwatSystem.Forms
{
    public partial class popSOClose : Form
    {
        public double Refund { get; set; }
        public DateTime RefundDate { get; set; }
        public string SO { get; set; }
        public string RefundType { get; set; }
        public string RefundRemark { get; set; }
        public bool OpenCourse = false;
        
        public popSOClose()
        {
            InitializeComponent();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                Refund = textboxFormatDoubleRefund.Text == "" ? 0 : Convert.ToDouble(textboxFormatDoubleRefund.Text);
                //RefundDate = Convert.ToDateTime(AryuwatSystem.DerClass.DerUtility.ToFormatDateyyyyMMdd(txtRefundDate.Text));
                string dateFormat = "yyyy/MM/dd";
                string resultdt = dtpDateSave.Value.ToString(dateFormat);
                RefundDate = Convert.ToDateTime(resultdt);// dtpDateSave.Value;
                RefundType = comboBoxType.SelectedValue.ToString();
                RefundRemark = txtRemark.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
        private void GetRefundType()
        {
            try
            {
                Entity.Report info = new Entity.Report() { PageNumber = 1 };
                info.QueryType = "GetRefundType";

                info.StartDate = DateTime.Now.ToString();
                info.EndDate = DateTime.Now.ToString();
                DataSet ds = new Business.ReportAccount().SelectReportAccount(info);
                comboBoxType.DataSource = ds.Tables[0];
                comboBoxType.DisplayMember = "RefundText";
                comboBoxType.ValueMember = "RefundID";
                //foreach (DataRow item in ds.Tables[0].Rows)
                //{
                //    if (!dicReportRang.ContainsKey(item["Rpt_Code"] + "")) dicReportRang.Add(item["Rpt_Code"] + "", item["DateRang"] + "");
                //    if (!dicReporQueryType.ContainsKey(item["Rpt_Code"] + "")) dicReporQueryType.Add(item["Rpt_Code"] + "", item["QueryType"] + "");
                //}
                //QueryType = dicReporQueryType[comboBoxReport.SelectedValue.ToString()];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GetRefund()
        {
            try
            {
                Entity.Report info = new Entity.Report() { PageNumber = 1 };
                info.QueryType = "GetRefund";


                DataSet ds = new Business.SumOfTreatment().GetRefund("GetRefund", SO);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    textboxFormatDoubleRefund.Text = ds.Tables[0].Rows[0]["Refund"] + ""; //ds.Tables[0].Rows[0]["Refund"] + "" == "" ? "0" : Convert.ToDecimal(ds.Tables[0].Rows[0]["Refund"] + "" == "").ToString("###,###,###.##");
                    //comboBoxType.SelectedText = ds.Tables[0].Rows[0]["RefundText"] + "";
                    comboBoxType.SelectedValue = ds.Tables[0].Rows[0]["RefundType"] + "";
                    txtRemark.Text = ds.Tables[0].Rows[0]["RefundRemark"] + "";
                    //txtRefundDate.Text = ds.Tables[0].Rows[0]["RefundDate"] + "";
                    string dateFormat = "yyyy/MM/dd";
                    string resultdt = Convert.ToDateTime(ds.Tables[0].Rows[0]["RefundDate"] + "" == "" ? DateTime.Now.ToString() : ds.Tables[0].Rows[0]["RefundDate"] + "").ToString(dateFormat);

                    dtpDateSave.Value = string.IsNullOrEmpty(ds.Tables[0].Rows[0]["RefundDate"] + "") ? DateTime.Now : Convert.ToDateTime(resultdt);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void popSOClose_Load(object sender, EventArgs e)
        {
            try 
	        {
                btnReOpen.Visible = (Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN);

                dtpDateSave.Value = DateTime.Now;
                GetRefundType();
                GetRefund();
	        }
	        catch (Exception ex)
	        {
		        MessageBox.Show(ex.Message);
	        }
           
        }

        private void btnReOpen_Click(object sender, EventArgs e)
        {
            OpenCourse = true;
            string dateFormat = "yyyy/MM/dd";
            string resultdt = dtpDateSave.Value.ToString(dateFormat);
            RefundDate = Convert.ToDateTime(resultdt);// dtpDateSave.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //          PopDateTime pp = new PopDateTime();
        //            DateTime d;
        //            pp.SelecttDate =DateTime.TryParse(dataGridViewSelectList.Rows[e.RowIndex].Cells["ExpireDate"].Value+"",out d)?d:DateTime.Now;
                
        //            if (pp.ShowDialog() == DialogResult.OK)
        //            {
        //                dataGridViewSelectList.Rows[e.RowIndex].Cells["ExpireDate"].Value = pp.SelecttDate.Date.ToString("yyyy/MM/dd");
        //                dataGridViewSelectList.EndEdit();
        //            }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
    }
}
