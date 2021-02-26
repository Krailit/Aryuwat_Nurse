using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entity;
using AryuwatSystem.DerClass;

namespace AryuwatSystem.Forms
{
    public partial class popCutInventory : Form
    {
        public string MS_Name = "";
        public string MS_Code = "";
        public double MS_Instock = 0;
        public popCutInventory()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveStockCut();
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void popCutInventory_Load(object sender, EventArgs e)
        {
            dtpDate.Value = DateTime.Now;
            lbMS_Name.Text = MS_Name;
            txtAmount.Focus();
            txtMS_Instock.Text = MS_Instock.ToString("###,###,###");
            BindCutCboSupplie();
        }
        private void BindCutCboSupplie()
        {
            try
            {
                Entity.MedicalSupplies info = new MedicalSupplies();
                info.QueryType = "CUTSUPPLIE";

                DataTable dtSUPPLIER = new Business.MedicalSupplies().SelectStock(info).Tables[0];
                
                var dr = dtSUPPLIER.NewRow();
                dr["CutByID"] = "";
                dr["Cut_Detail"] = "";
                dtSUPPLIER.Rows.InsertAt(dr, 0);
                cboSupplier.Items.Clear();
                cboSupplier.BeginUpdate();
                cboSupplier.DataSource = dtSUPPLIER;
                cboSupplier.ValueMember = "CutByID";
                cboSupplier.DisplayMember = "Cut_Detail";

                cboSupplier.EndUpdate();
                AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                foreach (DataRow row in dtSUPPLIER.Rows)
                {
                    if (row["CutByID"] + "" == "") continue;
                    data.Add(row["Cut_Detail"] + "");
                }
                cboSupplier.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboSupplier.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cboSupplier.AutoCompleteCustomSource = data;
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }
        }
         double amountxx = 0;
        private void SaveStockCut()
        {
            try
            {
                amountxx = txtAmount.Text == "" ? 0 : Convert.ToDouble(txtAmount.Text);
              
                if (string.IsNullOrEmpty(MS_Code))
                {
                    MessageBox.Show("โปรดระบุ Code");
                    return;
                }
                else if (string.IsNullOrEmpty(txtAmount.Text))
                {
                    MessageBox.Show("โปรดระบุจำนวน");
                    return;
                }
                else if (amountxx>MS_Instock)
                {
                    MessageBox.Show("ระบุจำนวนไม่ถูกต้อง");
                    return;
                }
                MS_Instock = MS_Instock - amountxx;
                MedicalSupplies info = new MedicalSupplies();

                info.MS_Code = MS_Code;
                info.SellQuantity = amountxx;
                info.MS_Instock = MS_Instock;
                info.DocNo =txtInvID.Text.Trim() + "";
                info.ActiveType = "2";
                info.ByID = cboSupplier.SelectedValue + "";
                info.SaveDate = dtpDate.Value;
                info.ENSave = Userinfo.EN;
                info.Remark = txtRemark.Text;

                info.QueryType = "SaveCutStock";
                          int?  intStatus = new Business.MedicalSupplies().InsertMedicalStockSupplies(ref info);
                            if (intStatus > 0)
                            {
                                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, Statics.StrMsgInsertComplete);
                                this.DialogResult = DialogResult.OK;
                            }
                            else
                            {
                                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation,
                                               Statics.StrMsgCannotSave + " ข้อมูลผิดพลาด");
                            }
                            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnSuppiler_Click(object sender, EventArgs e)
        {

        }

        
    }
}
