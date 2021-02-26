using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AryuwatSystem.DerClass;
using Entity;

namespace AryuwatSystem.Forms
{
    public partial class FrmGiftVoucherEdit : Form
    {
        public bool IsEdit = false;
      public bool Import = false;
      public bool FromOPD = false;
      private DataTable dtImport = new DataTable();
      public string CN = "";
      public string CustomerName = "";
        
      public string GiftCode = "";
      public string MS_Code = "";
      public string ListOrder = "";
      public string SOno = "";
      public string VN = "";
      public double PriceCredit = 0;
      DataTable dtGift = new DataTable();
        public FrmGiftVoucherEdit()
        {
            InitializeComponent();
            cboEN.MouseWheel += new MouseEventHandler(cboEN_MouseWheel);
            cboApp.MouseWheel += new MouseEventHandler(cboApp_MouseWheel);
            cboTr.MouseWheel += new MouseEventHandler(cboTr_MouseWheel);
            dtpDateExpire.Value = dtpDate.Value.AddMonths(6);
        }

        void cboTr_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        void cboApp_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        void cboEN_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void buttonSave1_BtnClick()
        {
            try
            {
                SaveImport(dtImport);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SaveImport(DataTable dt)
        {
            try
            {
                int i = 0;
                int c = 0;
                StringBuilder sb=new StringBuilder();
                foreach (DataRow item in dt.Rows)
                {
                    c++;
                    i++;
                    //sb.Append(string.Format("INSERT INTO dbo.GiftVoucher(GiftCode,PriceCredit,GiftDetail,DateStart,DateEnd,Gift_Active) VALUES('{0}',{1},'{2}','{3}','{4}','{5}');", item["GiftCode"], item["PriceCredit"], item["GiftDetail"], item["DateStart"] + "" == "" ? DBNull.Value+"" : item["DateStart"] + "", item["DateEnd"] + "" == "" ? DBNull.Value+"" : item["DateEnd"] + "", item["Gift_Active"]));
                    sb.Append(string.Format("INSERT INTO dbo.GiftVoucher(GiftCode,PriceCredit,GiftDetail,Gift_Active) VALUES('{0}',{1},'{2}','{3}');", item["GiftCode"], item["PriceCredit"], item["GiftDetail"], item["Gift_Active"]));
                    if (c == 50 || i == dt.Rows.Count)
                    {
                        int exc = new Business.GiftVoucher_Barter().ImportGiftVoucher(sb.ToString());
                        c = 0;
                        sb = new StringBuilder();
                    }
              
                    
                }
                MessageBox.Show("Saved");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FrmGiftVoucherEdit_Load(object sender, EventArgs e)
        {
            try
            {
                if (Userinfo.IsAdmin.Contains(Userinfo.EN) || Userinfo.FIX_VOUCHEROK.Contains(Userinfo.EN) || Userinfo.IS_ADMIN_EDIT.Contains(Userinfo.EN))
                {
                    btnSaveNew.Visible = true;
                    txtGiftCode.ReadOnly = false;
                }
                Bindcbo();
                //if (Import)
                //{
                //    OpenFileDialog filedlgExcel = new OpenFileDialog();
                //    filedlgExcel.Title = "Select file";
                //    filedlgExcel.InitialDirectory = @"c:\";
                //    //filedlgExcel.FileName = textBox1.Text;
                //    filedlgExcel.Filter = "Excel Sheet(*.xlsx)|*.xlsx|All Files(*.*)|*.*";
                //    filedlgExcel.FilterIndex = 1;
                //    filedlgExcel.RestoreDirectory = true;
                //    if (filedlgExcel.ShowDialog() == DialogResult.OK && filedlgExcel.FileName != "")
                //    {
                //        dataGridView1.DataSource = null;
                //        dataGridView1.DataSource = dtImport = DatasExcel(filedlgExcel.FileName);
                //    }
                //}
                //else
                //{
                //     dtImport = new DataTable();
                //     dtImport.Columns.Add("GiftCode", typeof(string));
                //     dtImport.Columns.Add("PriceCredit", typeof(int));
                //     dtImport.Columns.Add("GiftDetail", typeof(string));
                //     dtImport.Columns.Add("Gift_Active", typeof(string));
                //     dataGridView1.DataSource = dtImport;
                //}

                if (IsEdit)
                {
                    txtGiftCode.Text = GiftCode;
                    BindGiftVoucher();
                    if (txtDetail.Text.Length<5)
                        txtDetail.Text = cboTr.Text;
                }
                else
                {
                    //txtGiftCode.Text = dtGift.Rows[0]["GiftCode"] + "";
                    //txtDetail.Text = dtGift.Rows[0]["GiftDetail"] + "";
                    //txtCredit.Text = dtGift.Rows[0]["PriceCredit"] + "" == "" ? "0" : Convert.ToDecimal(dtGift.Rows[0]["PriceCredit"] + "").ToString("###,###,###");
                    //dtpDate.Value = Convert.ToDateTime(dtGift.Rows[0]["DateStart"] + "");
                    //dtpDateExpire.Value = Convert.ToDateTime(dtGift.Rows[0]["DateEnd"] + "");
                    if (FromOPD) radioButtonGE.Checked=true;
                    labelCN.Text = CN;
                    txtCustomerName.Text = CustomerName;
                    cboTr.SelectedValue = MS_Code;
                    txtCustomerName.Text = CustomerName;
                    txtDetail.Text = cboTr.Text;

                }
                




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private static DataTable DatasExcel(string filename)
        {

            Microsoft.Office.Interop.Excel.Application xlApp;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;


            var missing = System.Reflection.Missing.Value;

            xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(filename, false, true, missing, missing, missing, true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, '\t', false, false, 0, false, true, 0);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            Microsoft.Office.Interop.Excel.Range xlRange = xlWorkSheet.UsedRange;
            Array myValues = (Array)xlRange.Cells.Value2;

            int vertical = myValues.GetLength(0);
            int horizontal = myValues.GetLength(1);

            System.Data.DataTable dt = new System.Data.DataTable();

            // must start with index = 1
            // get header information
            for (int i = 1; i <= horizontal; i++)
            {
                dt.Columns.Add(new DataColumn(myValues.GetValue(1, i).ToString()));
            }

            // Get the row information
            for (int a = 2; a <= vertical; a++)
            {
                object[] poop = new object[horizontal];
                for (int b = 1; b <= horizontal; b++)
                {
                    poop[b - 1] = myValues.GetValue(a, b);
                }
                DataRow row = dt.NewRow();
                row.ItemArray = poop;
                dt.Rows.Add(row);
            }

            //assign table to default data grid view
            //dataGridView1.DataSource = dt;

            xlWorkBook.Close(true, missing, missing);
            xlApp.Quit();
            return dt;

        }

        private void buttonAdd1_BtnClick()
        {
            try
            {
                //txtCredit.Text = "";
                //txtDetail.Text = "";
                //txtGiftCode.Text = "";
                //object[] myItems = {
                //                          txtGiftCode.Text,
                //                          txtCredit.Text ,
                //                          txtDetail.Text,
                //                          "Y"
                //                      };
                //dataGridView1.Rows.Add(myItems);                
                dtImport.Rows.Add(txtGiftCode.Text, Convert.ToInt32( txtCredit.Text),   txtDetail.Text, "Y");
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            SelectCustomer();
        }
        private void SelectCustomer()
        {
            try
            {
                //if (!string.IsNullOrEmpty(CN))//&& SORef == ""
                //{
                //    if (DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirmYesNo, "ต้องการเปลี่ยน ชื่อลูกค้า หรือไม่?") == DialogResult.Yes)
                //    {
                //        if (PRO_CodeGift == "")
                //        {
                //            RemoveDgvRows(dataGridViewSelectList);
                //            txtPriceTotal.Text = "0.00";
                //            textBoxNormal.Text = "0.00";
                //        }
                //    }
                //    else return;
                //}
                //if(SORef == "")
                //{
                PopCustSearch obj = new PopCustSearch();
                obj.StartPosition = FormStartPosition.CenterParent;
                obj.WindowState = FormWindowState.Normal;
                obj.MaximizeBox = false;
                obj.MinimizeBox = false;
                obj.ShowDialog();
                if (obj.CN != "")
                {
                    CN = obj.CN;
                    txtCustomerName.Text = obj.CustomerName;
                    labelCN.Text = obj.CN;
                  //  customerType = obj.CustomerType;
                }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Bindcbo()
        {
            try
            {
                AutoCompleteStringCollection colValues = new AutoCompleteStringCollection();
                AutoCompleteStringCollection colValues2 = new AutoCompleteStringCollection();
                var info = new Entity.Personnel();
                //info.PersonnelType = "11";
                info.QueryType = "SEARCHCOM";
                DataTable dt = new Business.Personnel().SelectCustomerPaging(info).Tables[0];

                info.QueryType = "SEARCHAPPROVE";
                DataTable dtA = new Business.Personnel().SelectCustomerPaging(info).Tables[0];
                //DataRow dr = dt.NewRow();
                //dr["EN"] = "";
                //dr["FullNameThai"] = "--ไม่ระบุ--";
                //dt.Rows.InsertAt(dr, 0);

                foreach (DataRow row in dt.Rows)
                {
                    colValues.Add(row["FullNameThai"].ToString());
                    colValues2.Add(row["FullNameThai"].ToString());
                }
               
                cboEN.Items.Clear();
                cboEN.DataSource = dt;
                cboEN.ValueMember = "EN";
                cboEN.DisplayMember = "FullNameThai";
                cboEN.SelectedValue = Entity.Userinfo.EN;
                cboEN.AutoCompleteCustomSource = colValues;


                cboApp.Items.Clear();
                cboApp.DataSource = dtA;
                cboApp.ValueMember = "EN";
                cboApp.DisplayMember = "FullNameThai";
                cboApp.SelectedValue = "ENL62120002";// Entity.Userinfo.EN;
                //cboApp.AutoCompleteCustomSource = colValues2;




                AutoCompleteStringCollection colValuesdr = new AutoCompleteStringCollection();
                var infoDr = new Entity.Personnel();
                //infoDr.PersonnelType = "11";
                infoDr.QueryType = "VoucherProduct";
                DataTable dtDr = new Business.Personnel().SelectCustomerPaging(infoDr).Tables[0];
                DataRow drx = dtDr.NewRow();
                drx["ID"] = 0;
                drx["MS_Text"] = "--ไม่ระบุ--";
                dtDr.Rows.InsertAt(drx, 0);

                
                foreach (DataRow row in dtDr.Rows)
                {
                    colValuesdr.Add(row["MS_Text"].ToString());
                }


                cboTr.Items.Clear();
                cboTr.DataSource = dtDr;
                cboTr.ValueMember = "ID";
                cboTr.DisplayMember = "MS_Text";
                cboTr.SelectedValue = 0;// Entity.Userinfo.EN;
                cboTr.AutoCompleteCustomSource = colValuesdr;

            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
        }
      
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                
               SaveVoucher(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void picPrint_Click(object sender, EventArgs e)
        {
                 try
            {
                
                //SaveVoucher();
                PrintVoucher();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void BindGiftVoucher()
        {
            try
            {
                AutoCompleteStringCollection colValues = new AutoCompleteStringCollection();
                var info = new Entity.GiftVoucher_Barter();
                info.QueryType = "SelectGVByID";
                info.GiftCode = txtGiftCode.Text.Trim();
                DataSet ds = new Business.GiftVoucher_Barter().SelectGiftVoucherByID(info);
                if (ds.Tables.Count > 0) dtGift = ds.Tables[0];

                if (IsEdit)
                {
                    txtGiftCode.Text = dtGift.Rows[0]["GiftCode"]+"";
                    txtDetail.Text = dtGift.Rows[0]["GiftDetail"] + "";
                    txtCredit.Text = dtGift.Rows[0]["PriceCredit"] + "" == "" ? "0" : Convert.ToDecimal(dtGift.Rows[0]["PriceCredit"] + "").ToString("###,###,###");
                    dtpDate.Value = Convert.ToDateTime(dtGift.Rows[0]["DateStart"] + "");
                    dtpDateExpire.Value = Convert.ToDateTime(dtGift.Rows[0]["DateEnd"] + "");
                    labelCN.Text = dtGift.Rows[0]["CN"] + "";
                    cboEN.SelectedValue = dtGift.Rows[0]["EN"] + "";
                    cboApp.SelectedValue = dtGift.Rows[0]["ENApp"] + "";
                    cboTr.SelectedValue = dtGift.Rows[0]["MS_CodeFIX"] + "";
                    txtRemark.Text = dtGift.Rows[0]["Remark"] + "";
                    txtCustomerName.Text = dtGift.Rows[0]["CustomerName"] + "";
                }
              
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
        }
        private void SaveVoucher(bool Save_New)//ไม่ reset ก่อน
        {
            try
            {
                //if (string.IsNullOrEmpty(txtREQNo.Text))
                //{
                //    MessageBox.Show("โปรดระบุเลขที่เอกสาร");
                //    return;
                //}
                //if (dataGridViewSelectList.RowCount == 0)
                //{
                //    MessageBox.Show("โปรดเลือกรายการ");
                //    return;
                //}
                if (cboEN.SelectedValue + "" == "")
                {
                    MessageBox.Show("โปรดเลือก ผู้มอบ");
                    return;
                }
                //if (cboApp.SelectedValue + "" == "")
                //{
                //    MessageBox.Show("โปรดเลือก ผู้อนุมัติ");
                //    return;
                //}
                //if (cboTr.SelectedValue + "" == "")
                //{
                //    MessageBox.Show("โปรดเลือก ทรีทเม้นต์");
                //    return;
                //}


                //if (REQNoCurrent == "")
                //{
                //    REQNoCurrent = AryuwatSystem.Data.UtilityBackEnd.GenMaxSeqnoValues("REQ", cboReqBranch.SelectedValue + "");
                //    txtREQNo.Text = REQNoCurrent;
                //}
                //REQNoPrint = REQNoCurrent;
                //MedicalSupplies info = new MedicalSupplies();
                //info.LisItemStock = new List<MedicalSupplies>();
                //foreach (DataGridViewRow item in dataGridViewSelectList.Rows)
                //{
                string g = "";
                if (IsEdit == false && txtGiftCode.Text.Length<5)
                {
                  
                    if (radioButtonGE.Checked) g = "GE.";
                    if (radioButtonGV.Checked) g = "GV.";
                    if (radioButtonGS.Checked) g = "GS.";
                    GiftCode = AryuwatSystem.Data.UtilityBackEnd.GenMaxSeqnoValues(g);
                    txtGiftCode.Text = GiftCode;
                    if (DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirmYesNo, "คุณต้องการบันทึก " + GiftCode + " หรือไม่") != DialogResult.Yes) return;
                }
                GiftVoucher_Barter gv = new GiftVoucher_Barter();
                gv.QueryType = "InsertGiftVoucher";//INSER_REQ_STOCK
                txtGiftCode.Text = GiftCode;
                if (radioButtonGE.Checked) g = "GE.";
                if (radioButtonGV.Checked) g = "GV.";
                if (radioButtonGS.Checked) g = "GS.";
                gv.GiftType = g;
                gv.GiftCode =GiftCode;
                gv.GiftDetail = txtDetail.Text;
                gv.Remark = txtRemark.Text;
                gv.Gift_Active = "Y";
                gv.PriceCredit = txtCredit.Text == "" ? 0 : Convert.ToDecimal(txtCredit.Text);
                gv.DateStart = dtpDate.Value;
                gv.DateEnd = dtpDateExpire.Value;
                gv.CN = labelCN.Text;
                gv.EN = cboEN.SelectedValue + "";
                gv.ENApp = cboApp.SelectedValue + "";
                gv.MS_CodeFIX = cboTr.SelectedValue + "";
                gv.Sono = SOno;
                gv.MS_Code = cboTr.SelectedValue + "";
                gv.ListOrder = ListOrder;


               int? intx = new Business.GiftVoucher_Barter().InsertGiftVoucher(gv);
               if (intx>0)
                {
                    txtGiftCode.Text = GiftCode;
                    PriceCredit = txtCredit.Text == "" ? 0 : Convert.ToDouble(txtCredit.Text);
                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, Statics.StrMsgInsertComplete);

                    if (Save_New == false && FromOPD==false)//กดปุ่ม save ธรรมดา 
                    this.DialogResult = DialogResult.Yes;
                    if (FromOPD)//กดปุ่ม save ธรรมดา  จะให้ขึ้นหน้าต่าง ปริ้น ถ้ามาจาก opd
                        PrintVoucher();
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
        private void PrintVoucher()
        {
            try
            {
                BindGiftVoucher();
                FrmPreviewRpt obj = new FrmPreviewRpt();
                DataRow dr;
                obj.PrintType = "";
                string strTypeofPay = "";
                obj.FormName = "RptGiftVoucher";

                double dblCredit = 0.00;
                double dblCash = 0.00;
                string strBankName = "";

                obj.dt = dtGift;
                    
                    obj.MaximizeBox = true;
                    //obj.TopMost = true;
                    obj.Show();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dtpDateExpire.Value = dtpDate.Value.AddMonths(6);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            try
            {
                txtGiftCode.Text = "";
                SaveVoucher(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
