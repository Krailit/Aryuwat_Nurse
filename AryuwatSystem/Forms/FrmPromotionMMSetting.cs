using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AryuwatSystem.DerClass;
using Entity;
using WeifenLuo.WinFormsUI.Docking;
using System.Threading;
using AryuwatSystem.Data;
using AryuwatSystem.UserControls;


namespace AryuwatSystem.Forms
{
    public partial class FrmPromotionMMSetting : DockContent, IForm
    {

        public FrmPromotionMMSetting()
        {
            InitializeComponent();
        }

        public FrmPromotionMMSetting(ref Entity.Customer info)
        {
            InitializeComponent();

        }

        #region IForm Members

        void IForm.IsSave()
        {
        }

        void IForm.IsDelete()
        {
            //DeleteData();
        }

        void IForm.IsRefresh()
        {
            //BindDataCustomer(1);
        }

        void IForm.IsEdit()
        {
            //UpdateDataCustomer();
        }

        void IForm.IsPrint()
        {

        }

        void IForm.IsNew()
        {
            //NewCustomer();
        }

        void IForm.IsExit()
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region Private Member


        private DataTable dtTmpHairSelect = new DataTable();

        public string typeCustomer { get; set; }
        public string RefCN { get; set; }
        public string RefCN_Name { get; set; }
        public string customerType { get; set; }
        public string PriceRef { get; set; }
        public decimal SalePriceNew { get; set; }
        private DataTable dtByItem = new DataTable();
        private DataTable dtByItemOrg = new DataTable();

        private string vn = "";
        private string so = "";
        private string Pro_Code;

        List<string> LsSelectMS_Code = new List<string>();
        private string docFilePath;
        List<DataGridViewRow> rowsToDelete = new List<DataGridViewRow>();
        //DataGridView dataGridToDelete=new DataGridView();
        public List<Entity.MedicalStuff> MedicalStuffs { get; set; }
        public List<Entity.MedicalOrderUseTrans> MedicalOrderUseTranss { get; set; }
        public DerUtility.AccessType FormType { get; set; }
        public string RefVN { get; set; }
        private Dictionary<string, List<Entity.MembersTrans>> dicMemberTran = new Dictionary<string, List<Entity.MembersTrans>>();
        public string MS_Code = "";
        public string PRO_Code
        {
            get { return Pro_Code; }
            set { Pro_Code = value; }

        }
        public string SO
        {
            get { return so; }
            set { so = value; }

        }

        public string TypeCustomer
        {
            get { return typeCustomer; }
            set { typeCustomer = value; }

        }

        private TabPageActive tabPageActive = TabPageActive.tabAesthetic;
        public enum TabPageActive
        {
            tabAesthetic = 1,
            tabTreatment = 2,
            tabSurgery = 3,
            tabHair = 4,
            tabWellness_Antiaging = 5,
            tabPharmacy = 6,
            tabAttachFile = 7,
        }
        #endregion
        List<string> lsUnit = new List<string>();
        List<string> MKTBudget = new List<string>();
        List<string> GiftVoucher = new List<string>();
        Dictionary<string, string> dicMKTBudget = new Dictionary<string, string>();
        Dictionary<string, string> dicGiftVoucher = new Dictionary<string, string>();
        decimal Unpaid = 0;
        decimal NetAmount = 0;
        public string MedStatus_Code = "0";
        string tabTyp = "AESTHETIC";
        string tabTypShortName = "AE";
        string moso = "PRO-";
        string MOType = "";
        public string MO = "";
        string MoSubType = "";
        string idMax = "";

        private void BindSurgicalFeeType()
        {
            try
            {
                DataSet dsComRate = new Business.StuffCommission().SurgicalFeeType_Position();

                if (dsComRate.Tables.Count > 0)
                {
                    DataTable dt = dsComRate.Tables[1];
                    DataView view = new DataView(dt);
                    //DataTable distinctValues = view.ToTable(true, "Position_Type", "Column2");
                    DataTable distinctValues = view.ToTable(true, "SurgicalFeeTyp");
                    DataRow dr = distinctValues.NewRow();
                    dr["SurgicalFeeTyp"] = "ALL";
                    distinctValues.Rows.InsertAt(dr, 0);

                    foreach (DataRow item in distinctValues.Rows)
                    {
                        cboSurgicalFeeTyp.Items.Add(item["SurgicalFeeTyp"]);
                    }
                    cboSurgicalFeeTyp.SelectedIndex = 0;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void FrmPromotionMMSetting_Load(object sender, EventArgs e)
        {
            try
            {
                this.btnSave.Click += new EventHandler(this.btnSave_Click);
                this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
                foreach (DataRow row in Userinfo.UnitName.Rows)
                {
                    this.lsUnit.Add(row["UnitName"] + "");
                }

                this.MedicalStuffs = new List<Entity.MedicalStuff>();
                this.MedicalOrderUseTranss = new List<Entity.MedicalOrderUseTrans>();
                this.dateTimePickerEnd.Value = DateTime.Now;
                BindCboMedicalSection();
                BindSurgicalFeeType();
                if (FormType == DerUtility.AccessType.Update)
                {

                    this.BindData();
                }
                else
                {
                    this.idMax = UtilityBackEnd.GenMaxSeqnoValues(moso);
                    this.txtPro_Code.Text = this.idMax;

                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void BindCboMedicalSection()
        {
            try
            {
                var ds = new Business.MedicalSupplies().SelectMedicalSection();
                checkedListBoxProduct.DataSource = null;
                checkedListBoxProduct.Items.Clear();
                checkedListBoxProduct.BeginUpdate();
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    item["Section_Name"] = string.Format("{0} => {1}", item["Section_Code"] + "", item["Section_Name"] + "");
                }

                checkedListBoxProduct.DataSource = ds.Tables[0];
                checkedListBoxProduct.ValueMember = "Section_Code";
                checkedListBoxProduct.DisplayMember = "Section_Name";

                checkedListBoxProduct.EndUpdate();


            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }
        }

        private T StringToEnum<T>(string name)
        {
            string[] names = Enum.GetNames(typeof(T));
            if (((IList)names).Contains(name))
            {
                return (T)Enum.Parse(typeof(T), name);
            }
            else return default(T);
        }

        public DataTable GroupByMultiple(string i_sGroupByColumn, DataTable dataSource)
        {
            var dv = new DataView(dataSource);
            //getting distinct values for group column
            dv.Sort = i_sGroupByColumn + " ASC";
            DataTable dtGroup = dv.ToTable(true, new[] { i_sGroupByColumn });
            return dtGroup;
        }
        private void BindData()
        {
            try
            {
                Entity.Promotion info = new Entity.Promotion();
                info.QueryType = "SEARCHBYID";
                info.PRO_Code = PRO_Code;
                DataSet ds = new Business.Promotion().SelectPromotionPaging(info);
                DataTable dt = ds.Tables[0];
                if (dt == null || dt.Rows.Count <= 0) return;
                txtPro_Code.Text = dt.Rows[0]["PRO_Code"] + "";
                //txtPro_Code.ReadOnly = true;
                txtPro_Name.Text = dt.Rows[0]["PRO_Name"] + "";
                dateTimePickerStart.Value = dt.Rows[0]["DateStart"] + "" == "" ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["DateStart"] + "");
                dateTimePickerEnd.Value = dt.Rows[0]["DateEnd"] + "" == "" ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["DateEnd"] + "");
                checkBoxActive.Checked = dt.Rows[0]["PRO_Active"] + "" == "Y";
                checkBoxWallet.Checked = dt.Rows[0]["MoneyWallet"] + "" == "Y";
                radioButtonByItem.Checked = dt.Rows[0]["FixByItem"] + "" == "Y";
                txtRemark.Text = dt.Rows[0]["Remark"] + "";
                cboSurgicalFeeTyp.Text = dt.Rows[0]["PRO_Dept"] + "" == "" ? "ALL" : dt.Rows[0]["PRO_Dept"] + "";

                txtAmount.Text = dt.Rows[0]["Fix_Amount"] + "" == "" ? "0" : Convert.ToDecimal(dt.Rows[0]["Fix_Amount"] + "").ToString("###,###.##");

                switch (dt.Rows[0]["PRO_CalType"] + "")
                {
                    case "P":
                        radioNormal.Checked = true;
                        break;
                    case "B":
                        radBuffet.Checked = true;
                        break;
                    case "A":
                        radAmount.Checked = true;
                        break;
                }


                txtProPrice.Text = dt.Rows[0]["ProPrice"] + "" == "" ? "0" : Convert.ToDecimal(dt.Rows[0]["ProPrice"] + "").ToString("###,###,###.##");
                txtTotalPrice.Text = dt.Rows[0]["ProPriceCredit"] + "" == "" ? "0" : Convert.ToDecimal(dt.Rows[0]["ProPriceCredit"] + "").ToString("###,###,###.##");
                string ProductGroup = dt.Rows[0]["ProductGroup"] + "";
                if (radioButtonByItem.Checked)//====================ByItem===================
                {
                    if (ds.Tables.Count > 1)
                    {
                        dtByItem = ds.Tables[1];
                        dtByItemOrg = dtByItem.Copy();
                        checkedListBoxProduct.DataSource = null;
                        checkedListBoxProduct.Items.Clear();
                        checkedListBoxProduct.BeginUpdate();
                        foreach (DataRow item in dtByItem.Rows)
                        {
                            item["Section_Name"] = string.Format("{0} => {1}", item["Section_Code"] + "", item["Section_Name"] + "");
                        }
                        checkedListBoxProduct.DataSource = dtByItem;
                        checkedListBoxProduct.ValueMember = "Section_Code";
                        checkedListBoxProduct.DisplayMember = "Section_Name";

                        checkedListBoxProduct.EndUpdate();
                        for (int i = 0; i < checkedListBoxProduct.Items.Count; i++)
                        {
                            checkedListBoxProduct.SetItemChecked(i, true);
                        }
                    }
                }
                else//==============By Group======================
                {
                    for (int i = 0; i < checkedListBoxProduct.Items.Count; i++)
                    {
                        DataRowView view = (DataRowView)checkedListBoxProduct.Items[i];
                        if (ProductGroup.Contains(view[checkedListBoxProduct.ValueMember].ToString()))
                        {
                            checkedListBoxProduct.SetItemChecked(i, true);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DisplayPayInComboColumn(List<string> lsPayin, DataGridView dataGrid, string cname)
        {
            try
            {
                DataGridViewComboBoxColumn column = (DataGridViewComboBoxColumn)dataGrid.Columns[cname];
                for (int x = 0; x <= dataGrid.Rows.Count - 1; x++)
                {
                    DataGridViewCell cell = dataGrid.Rows[x].Cells[cname];
                    if (column.Items.Count > 0)
                    {
                        cell.Value = lsPayin[x];
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }

        void txtExpireDate_KeyPress(object sender, KeyPressEventArgs e)
        {

        }






        private void itemID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridViewSelectList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
                e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                      e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
            }
            catch (Exception ex)
            {

            }

        }


        private void txtFindHair_Enter(object sender, EventArgs e)
        {

        }

        private void RemoveDgvRows(DataGridView dataGridView)
        {
            List<DataGridViewRow> rowsToDelete = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                rowsToDelete.Add(row);
            }
            //loop through the list to delete rows added to list<T>:
            foreach (DataGridViewRow row in rowsToDelete)
                dataGridView.Rows.Remove(row);
        }


        private string ToMaskedExpireString(String value)
        {
            string txtExpire = "";
            try
            {
                if (value.Contains("/"))
                {
                    string[] txt = value.Split('/');
                    if (Convert.ToInt16(txt[1]) > 12 || txt[0].Length != 4 || Convert.ToInt16(txt[2]) < 2550)
                    {
                        string c = DateTime.Now.ToString("dd/MM/yyyy");
                        MessageBox.Show(string.Format("Date format incorrect.({0})", c));
                        txtExpire = "";
                    }
                    else
                    {
                        txtExpire = string.Format("{0}/{1}/{2}", txt[0], txt[1], txt[2]);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return txtExpire;
        }
        private void SumPriceMedicalOrder()
        {
            //SalePriceNew = dataGridViewSelectList.Rows.Cast<DataGridViewRow>().Sum(row => row.Cells["PriceTotal"].Value + ""==""?0:decimal.Parse(row.Cells["PriceTotal"].Value + ""));
            //txtProPrice.Text =SalePriceNew==0?"0": SalePriceNew.ToString("###,###.##");
            //decimal ProPrice = dataGridViewSelectList.Rows.Cast<DataGridViewRow>().Sum(row => row.Cells["Price/Unit"].Value + "" == "" ? 0 : decimal.Parse(row.Cells["Price/Unit"].Value + ""));
            //txtTotalPrice.Text = ProPrice == 0 ? "0" : ProPrice.ToString("###,###.##");

        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            int? intStatus = 0;
            Entity.Promotion info;
            if (DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirm, "ยืนยันการบันทึกข้อมูล") != DialogResult.OK) return;
            //if (cboSurgicalFeeTyp.SelectedIndex == 0)
            //{
            //    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "กรุณาระบุ แผนก\n Please select Department.");
            //    return;
            //}
            if (string.IsNullOrEmpty(txtPro_Code.Text) || string.IsNullOrEmpty(txtPro_Name.Text))
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "กรุณาระบุ รหัสโปรโมชันและชื่อโปรโมชัน\n Please specify Promotion Codes and Promotion name.");
                return;
            }
            try
            {
                info = new Entity.Promotion();
                info.PRO_Code = txtPro_Code.Text.Trim();
                info.PRO_Name = txtPro_Name.Text.Trim();
                info.DateStart = dateTimePickerStart.Value;
                info.DateEnd = dateTimePickerEnd.Value;
                info.CreateDate = DateTime.Now;
                info.CreateBy = Userinfo.EN;
                info.UpdateDate = DateTime.Now;
                info.UpdateBy = Userinfo.EN;
                info.ProPrice = txtProPrice.Text == "" ? 0 : Convert.ToDecimal(txtProPrice.Text);
                info.ProPriceCredit = txtTotalPrice.Text == "" ? 0 : Convert.ToDecimal(txtTotalPrice.Text);
                info.PRO_Active = checkBoxActive.Checked ? "Y" : "N";
                info.MoneyWallet = checkBoxWallet.Checked ? "Y" : "N";
                info.Remark = txtRemark.Text;
                info.PRO_Type = "CREDIT";
                info.PRO_Dept = cboSurgicalFeeTyp.Text;
                info.Fix_Amount = txtAmount.Text == "" ? 0 : Convert.ToDecimal(txtAmount.Text);
                info.FixByItem = radioButtonByItem.Checked ? "Y" : "";
                info.ProSupplieInfo = new List<Entity.MedicalSupplies>();

                if (radioNormal.Checked)
                    info.PRO_CalType = "P";
                if (radBuffet.Checked)
                    info.PRO_CalType = "B";
                if (radAmount.Checked)
                    info.PRO_CalType = "A";

                string val = "";
                foreach (DataRowView view in checkedListBoxProduct.CheckedItems)
                {
                    val = val + view[checkedListBoxProduct.ValueMember].ToString() + ",";
                }
                info.ProductGroup = val;

                Entity.MedicalSupplies supplieInfo = new Entity.MedicalSupplies();
                supplieInfo.MS_Code = "PRO_CREDIT";
                supplieInfo.Amount = 1;
                supplieInfo.MS_PROPrice = txtTotalPrice.Text + "" == "" ? 0 : double.Parse(txtTotalPrice.Text);
                info.ProSupplieInfo.Add(supplieInfo);

                DataTable dt = new Business.MedicalSupplies().CheckProCode(info.PRO_Code).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    //MessageBox.Show("Code นี้ถูกใช้ไปแล้ว");
                    if (DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirm, "Code นี้ถูกใช้ไปแล้ว คุณต้องการจะอัปเดทหรือไม่") == DialogResult.OK)
                    {
                        intStatus = new Business.Promotion().InsertPromotion(info);
                    }
                    else return;

                }
                else
                {
                    intStatus = new Business.Promotion().InsertPromotion(info);
                }
                //intStatus = new Business.Promotion().InsertPromotion(info);
                if (intStatus > 0)
                {
                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, Statics.SaveComplete);
                    //Statics.frmMedicalOrderList.BindDataMedicalOrder(1);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
            }
        }

        private void FrmPromotionMMSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics.frmPromotionSetting = null;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Statics.frmPromotionSetting = null;
            this.Close();
        }

        private void buttonMerg1_BtnClick()
        {

            SumPriceMedicalOrder();
        }

        private void btnRunning_Click(object sender, EventArgs e)
        {
            var idMax = AryuwatSystem.Data.UtilityBackEnd.GenMaxSeqnoValues("MO");
        }

        private void dataGridViewSelectList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }






        private void txtFindPro_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //  BindDataPromotionList();
            }
        }

        private void txtTotalPrice_TextChanged(object sender, EventArgs e)
        {
            if (txtTotalPrice.Text.Length > 0) CalcPercen(txtTotalPrice);
        }

        private void txtProPrice_TextChanged(object sender, EventArgs e)
        {
            if (txtProPrice.Text.Length > 0) CalcPercen(txtProPrice);
        }
        private void CalcPercen(TextboxFormatDouble txt)
        {
            try
            {
                if (txtTotalPrice.Text.Length > 0 && txtProPrice.Text.Length > 0)
                {
                    double valueUp = double.Parse(txtProPrice.Text);
                    double valueDown = double.Parse(txtTotalPrice.Text);

                    double discount = 0;
                    discount = 100 - ((valueUp * 100) / valueDown);
                    //if (valueDown > (valueUp * 2)) discount = ((valueUp * 100) / valueDown);
                    if (valueDown < valueUp) discount = 0;
                    //else   discount = 100 - ((valueUp * 100) / valueDown);

                    txtDiscountPercen.Text = discount + "" == "NaN" ? "0.00" : Math.Round(discount, 2).ToString("###,###,###.##");
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void checkBoxAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < checkedListBoxProduct.Items.Count; i++)
                {
                    checkedListBoxProduct.SetItemChecked(i, checkBoxAll.Checked);
                }
            }
            catch (Exception)
            {


            }
        }



        private void radioButtonGroup_Click(object sender, EventArgs e)
        {
            try
            {
                checkBoxAll.Enabled = true;
                BindCboMedicalSection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radioButtonByItem_Click(object sender, EventArgs e)
        {
            try
            {
                checkBoxAll.Enabled = false;



                List<Entity.SupplieTrans> listSupOther = new List<Entity.SupplieTrans>();
                popSelectMedicalSupplies pop = new popSelectMedicalSupplies();
                pop.OldItem = dtByItemOrg;
                pop.customerType = "";
                DataTable dt = new DataTable();
                dt.Clear();
                dt.Columns.Add("Section_Code");
                dt.Columns.Add("Section_Name");
                if (pop.ShowDialog() == DialogResult.OK)
                {
                    checkedListBoxProduct.DataSource = null;
                    checkedListBoxProduct.Items.Clear();

                    listSupOther = pop.listSupOther;
                    foreach (Entity.SupplieTrans sp in listSupOther)
                    {
                        dt.Rows.Add(new object[] { sp.MS_Code, sp.MS_Name });
                    }
                    dtByItemOrg = dt.Copy();
                    checkedListBoxProduct.Items.Clear();
                    checkedListBoxProduct.BeginUpdate();
                    foreach (DataRow item in dt.Rows)
                    {
                        item["Section_Name"] = string.Format("{0} => {1}", item["Section_Code"] + "", item["Section_Name"] + "");
                    }
                    checkedListBoxProduct.DataSource = dt;
                    checkedListBoxProduct.ValueMember = "Section_Code";
                    checkedListBoxProduct.DisplayMember = "Section_Name";

                    checkedListBoxProduct.EndUpdate();
                    for (int i = 0; i < checkedListBoxProduct.Items.Count; i++)
                    {
                        checkedListBoxProduct.SetItemChecked(i, true);
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

