using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AryuwatSystem.DerClass;
using AryuwatSystem.Reports;

namespace AryuwatSystem.Forms.FRMReport
{
    public partial class FrmLabelPA : Form
    {
        DataTable dt;
        public FrmLabelPA()
        {
            InitializeComponent();
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            BindDataCustomer(1);
        }
        public void BindDataCustomer(int pIntseq)
        {
            try
            {


                DerUtility.MouseOn(this);
                dgvData.Rows.Clear();
                var info = new Entity.Customer { PageNumber = pIntseq };
                //if (!string.IsNullOrEmpty(txtCN.Text.Trim()))
                //{
                //    info.CN = "%" + txtCN.Text + "%";
                //}
                //if (!string.IsNullOrEmpty(txtName.Text))
                //{
                //    info.TName = "%" + txtName.Text + "%";
                //}
                info.CN = "%600500%";
                dt = new Business.Customer().SelectCustomerPaging(info).Tables[0];

                long lngTotalPage = 0;
                long lngTotalRecord = 0;
                //if (dt.Rows.Count <= 0)
                //{
                //    ngbMain.CurrentPage = 0;
                //    ngbMain.TotalPage = 0;
                //    ngbMain.TotalRecord = 0;
                //    ngbMain.Updates();
                //    DerUtility.MouseOff(this);
                //    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "ไม่พบข้อมูลในระบบ");
                //    return;
                //}
                //foreach (DataRowView item in dt.DefaultView)
                //{
                //    object[] myItems = {
                //                          item["CN"] + "",
                //                          item["CN"] + "",
                //                          item["FullNameThai"] + "",
                //                          item["FullNameEng"] + "",
                //                          item["gender"] + "",
                //                          item["Mobile"] + "",
                //                          item["Tel"] + "",
                //                          item["Address"] + "",
                //                          item["CustomerType"]+""
                //                      };
                //    dgvData.Rows.Add(myItems);
                //    if (lngTotalPage != 0) continue;
                //    DerUtility.FindTotalPage(Convert.ToInt32(item["rowTotal"].ToString()), ref lngTotalPage);
                //    lngTotalRecord = Convert.ToInt32(item["rowTotal"].ToString());
                //}

                //ngbMain.CurrentPage = pIntseq;
                //ngbMain.TotalPage = lngTotalPage;
                //ngbMain.TotalRecord = lngTotalRecord;
                //ngbMain.Updates();
                dgvData.DataSource = null;
                dgvData.DataSource = dt;
                DerUtility.MouseOff(this);
            }
            catch (Exception ex)
            {

            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                FrmPreviewRpt2Page obj = new FrmPreviewRpt2Page();
                obj.FormName = "RptLabel6x3cm";
                obj.dt = dt;
                obj.MaximizeBox = true;
                obj.TopMost = true;
                obj.Show();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
