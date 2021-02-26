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
    public partial class popGetInventoryBak : Form
    {
        public string MS_Name = "";
        public string MS_Code = "";
        public double MS_Cost = 0;
        
        public double MS_Instock = 0;
        
        public popGetInventoryBak()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveStockGet();
           this.DialogResult= DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void popGetInventoryBak_Load(object sender, EventArgs e)
        {
            dtpDate.Value = DateTime.Now;
            lbMS_Name.Text = MS_Name;
            txtAmount.Focus();
            txtMS_Instock.Text = MS_Instock.ToString("###,###,###");
            txtaveragecost.Text = MS_Cost.ToString("###,###,###.###");
            BindCboSupplier();
        }
        private void BindCboSupplier()
        {
            try
            {
                Entity.MedicalSupplies info = new MedicalSupplies();
                info.QueryType = "SUPPLIER";

                DataTable dtSUPPLIER = new Business.MedicalSupplies().SelectStock(info).Tables[0];
                
                var dr = dtSUPPLIER.NewRow();
                dr["GetByID"] = "";
                dr["Get_Detail"] = "";
                dtSUPPLIER.Rows.InsertAt(dr, 0);
                cboSupplier.Items.Clear();
                cboSupplier.BeginUpdate();
                cboSupplier.DataSource = dtSUPPLIER;
                cboSupplier.ValueMember = "GetByID";
                cboSupplier.DisplayMember = "Get_Detail";

                cboSupplier.EndUpdate();
                AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                foreach (DataRow row in dtSUPPLIER.Rows)
                {
                    if (row["GetByID"] + "" == "") continue;
                    data.Add(row["Get_Detail"] + "");
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
        double CallAverageCost()
        { 
            double oldCost=0;
            double newCost=0;
            double avrage = 0;
            double NewItem = txtAmount.Text == "" ? 0 : Convert.ToDouble(txtAmount.Text);
            newCost = txtPrice.Text == "" ? 0 : Convert.ToDouble(txtPrice.Text);
          
            oldCost = MS_Cost * MS_Instock;
            if (oldCost == 0)
            {
                avrage = ((MS_Instock + NewItem) * newCost) / (MS_Instock + NewItem);
            }
            else
            {
                avrage = ((MS_Cost * MS_Instock) + (newCost * NewItem)) / (MS_Instock + NewItem);   /// (MS_Cost + newCost) / (MS_Instock + NewItem);
            }                                                                                                 
            return avrage;
        }
        private void SaveStockGet()
        {
            try
            {
                if (string.IsNullOrEmpty(MS_Code))
                {
                    MessageBox.Show("โปรดระบุ Code");
                    return;
                }
                if (string.IsNullOrEmpty(txtAmount.Text))
                {
                    MessageBox.Show("โปรดระบุจำนวน");
                    return;
                }
                MedicalSupplies info = new MedicalSupplies();

                info.MS_Code = MS_Code;
                info.Receive_Cost = txtPrice.Text == "" ? 0 : Convert.ToDouble(txtPrice.Text);
                info.MS_CostAVG = CallAverageCost();
                info.ReceiveQuantity = txtAmount.Text == "" ? 0 : Convert.ToDouble(txtAmount.Text);
                info.DocNo =txtInvID.Text.Trim() + "";
                info.ActiveType = "1";
                info.ByID = cboSupplier.SelectedValue + "";
                info.SaveDate = dtpDate.Value;
                info.ENSave = Userinfo.EN;
                info.Remark = txtRemark.Text;

                info.QueryType = "SaveGetStock";
                          int?  intStatus = new Business.MedicalSupplies().InsertMedicalStockSupplies(ref info);
                            if (intStatus > 0)
                            {
                                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, Statics.StrMsgInsertComplete);
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
