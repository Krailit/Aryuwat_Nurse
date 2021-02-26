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
    public partial class FrmServiceReq : DockContent, IForm
    {
        public string CN = "";
        public string Sono = "";
        public string MO = "";
        public string CustName = "";
        public string customerType = "";
        
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
        //    FrmPreviewRpt obj = new FrmPreviewRpt();
        //    obj.FormName = "RptCustomerDetail";
        //    obj.Cn = cn;
        //    obj.StrBirthDate = txtYear.Text.Trim();
        //    obj.MaximizeBox = true;
        //    obj.ShowDialog();
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
        public FrmServiceReq()
        {
            InitializeComponent();
        }

        private void FrmServiceReq_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("{0}({1})",CustName,CN);
            SetColumnDgvAesList();
            SetColumnDgvSelectList();
            BindDataAesList();
        }
        private void SetColumnDgvAesList()
        {
            DerUtility.SetPropertyDgv(dgvAestheticList);
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            {
                column.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                column.FlatStyle = FlatStyle.Standard;
                column.ThreeState = false;
                column.CellTemplate = new DataGridViewCheckBoxCell();
                column.CellTemplate.Style.BackColor = Color.Beige;
            }
            dgvAestheticList.Columns.Add(column);
            dgvAestheticList.Columns.Add("MS_Section", "Section");
            dgvAestheticList.Columns.Add("Code", "Code");
            dgvAestheticList.Columns.Add("Name", "Name");

            dgvAestheticList.Columns.Add("MS_CLPrice", "Local Price");
            dgvAestheticList.Columns.Add("MS_CAPrice", "Agency Price");
            //dgvAestheticList.Columns.Add("MS_CMPrice", "MS_CMPrice");
            dgvAestheticList.Columns.Add("MS_Type", "MS_Type");
            dgvAestheticList.Columns.Add("MS_Number_C", "Number/Course");
            dgvAestheticList.Columns.Add("UnitName", "Unit");
            dgvAestheticList.Columns.Add("Tab", "Tab");
            dgvAestheticList.Columns.Add("FeeRate", "Fee Rate");
            dgvAestheticList.Columns.Add("FeeRate2", "Fee Rate 2");

            dgvAestheticList.Columns["Tab"].Visible = false;
            dgvAestheticList.Columns["FeeRate"].Visible = false;
            dgvAestheticList.Columns["FeeRate2"].Visible = false;

            //dgvAestheticList.Columns["MS_CAPrice"].Visible = false;
            //dgvAestheticList.Columns["MS_CMPrice"].Visible = false;
            // dgvAestheticList.Columns["MS_Type"].Visible = false;
            //dgvAestheticList.Columns["MS_Number_C"].Visible = false;

            dgvAestheticList.Columns["Code"].Width = 100;
            dgvAestheticList.Columns["Name"].Width = 150;

            dgvAestheticList.Columns.Add("MS_Detail", "Detail");
            dgvAestheticList.Columns["MS_Detail"].Width = 200;
            dgvAestheticList.Columns.Add("Active", "Active");
        }
        private void SetColumnDgvSelectList()
        {
            //Utility.SetPropertyDgv(dgvHairSelect);
            dataGridViewSelectList.AllowUserToAddRows = false;
            dataGridViewSelectList.DefaultCellStyle.BackColor = Color.DarkGray;
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            {
                column.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                column.FlatStyle = FlatStyle.Standard;
                column.ValueType = typeof(bool);
                column.ThreeState = false;
                column.Name = "ChkMove";
                column.HeaderText = "";
                column.CellTemplate = new DataGridViewCheckBoxCell();
                column.CellTemplate.Style.BackColor = Color.LemonChiffon;
            }
            //DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            //{

            //    column.AutoSizeMode =
            //        DataGridViewAutoSizeColumnMode.DisplayedCells;
            //    column.FlatStyle = FlatStyle.Standard;
            //    column.ThreeState = false;
            //    column.CellTemplate = new DataGridViewCheckBoxCell();
            //    column.CellTemplate.Style.BackColor = Color.Beige;
            //}

            dataGridViewSelectList.Columns.Add(column); //0
            dataGridViewSelectList.Columns.Add("MS_Code", "Code");//1
            dataGridViewSelectList.Columns["MS_Code"].ReadOnly = true;
            dataGridViewSelectList.Columns["MS_Code"].Width = 80;

            dataGridViewSelectList.Columns.Add("MS_Name", "Name");//2
            dataGridViewSelectList.Columns["MS_Name"].ReadOnly = true;
            dataGridViewSelectList.Columns["MS_Name"].Width = 250;

            dataGridViewSelectList.Columns.Add("No./Course", "No./Course");//3
            dataGridViewSelectList.Columns["No./Course"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["No./Course"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewSelectList.Columns["No./Course"].ReadOnly = true;
            dataGridViewSelectList.Columns["No./Course"].Width = 80;

            dataGridViewSelectList.Columns.Add("Amount", "Quantity");//4 Amount
            dataGridViewSelectList.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["Amount"].DefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridViewSelectList.Columns["Amount"].Width = 60;



            dataGridViewSelectList.Columns.Add("Total", "Total");//5
            dataGridViewSelectList.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvHairSelect.Columns["Total"].DefaultCellStyle.BackColor = Color.Black;
            dataGridViewSelectList.Columns["Total"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewSelectList.Columns["Total"].ReadOnly = true;
            dataGridViewSelectList.Columns["Total"].Width = 45;

            //dataGridViewSelectList.Columns.Add("Used", "Used");//6
            //dataGridViewSelectList.Columns["Used"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ////dgvHairSelect.Columns["Used"].DefaultCellStyle.BackColor = Color.Black;
            //dataGridViewSelectList.Columns["Used"].DefaultCellStyle.ForeColor = Color.Blue;
            //dataGridViewSelectList.Columns["Used"].ReadOnly = true;
            //dataGridViewSelectList.Columns["Used"].Width = 45;



            ////comboBoxColumn1.DisplayIndex = 0;
            //DataGridViewComboBoxColumn comboBoxColumn2;
            //comboBoxColumn2 = new DataGridViewComboBoxColumn();

            //comboBoxColumn2.DataSource = Entity.Userinfo.UnitName;//7 
            //comboBoxColumn2.ValueMember = "UnitName";
            //comboBoxColumn2.DisplayMember = "UnitName";
            //comboBoxColumn2.HeaderText = "Unit";
            //comboBoxColumn2.Name = "Unit";
            //comboBoxColumn2.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            //comboBoxColumn2.Width = 100;

            ////comboBoxColumn2.DisplayIndex = 0;
            //dataGridViewSelectList.Columns.Add(comboBoxColumn2);
            dataGridViewSelectList.Columns.Add("Unit", "Unit");//6
            dataGridViewSelectList.Columns["Unit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvHairSelect.Columns["Used"].DefaultCellStyle.BackColor = Color.Black;
            dataGridViewSelectList.Columns["Unit"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewSelectList.Columns["Unit"].ReadOnly = true;
            dataGridViewSelectList.Columns["Unit"].Width = 45;

            dataGridViewSelectList.Columns.Add("Balance", "Balance");//8
            dataGridViewSelectList.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvHairSelect.Columns["Balance"].DefaultCellStyle.BackColor = Color.Black;
            dataGridViewSelectList.Columns["Balance"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewSelectList.Columns["Balance"].ReadOnly = true;
            dataGridViewSelectList.Columns["Balance"].Width = 60;

            dataGridViewSelectList.Columns.Add("Price/Unit", "Price/Unit");//9
            dataGridViewSelectList.Columns["Price/Unit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["Price/Unit"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewSelectList.Columns["Price/Unit"].ReadOnly = true;
            dataGridViewSelectList.Columns["Price/Unit"].Width = 80;

            //dataGridViewSelectList.Columns.Add("SpecialPrice", "Special Price");
            //dataGridViewSelectList.Columns["SpecialPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dataGridViewSelectList.Columns["SpecialPrice"].DefaultCellStyle.BackColor = Color.LemonChiffon;
            //dataGridViewSelectList.Columns["SpecialPrice"].Visible = true;
            //dataGridViewSelectList.Columns["SpecialPrice"].Width = 90;

            dataGridViewSelectList.Columns.Add("PriceTotal", "PriceTotal");//10
            dataGridViewSelectList.Columns["PriceTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["PriceTotal"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewSelectList.Columns["PriceTotal"].ReadOnly = true;
            dataGridViewSelectList.Columns["PriceTotal"].Width = 90;


            //DataGridViewImageColumn ColUse = new DataGridViewImageColumn();
            //{
            //    ColUse.AutoSizeMode =
            //        DataGridViewAutoSizeColumnMode.DisplayedCells;
            //    ColUse.CellTemplate = new DataGridViewImageCell();
            //    ColUse.Name = "BtnUse";
            //    ColUse.HeaderText = "Course (Record)";
            //}
            //dataGridViewSelectList.Columns.Add(ColUse);

            //dataGridViewSelectList.Columns.Add("Other", "โอน");
            //dataGridViewSelectList.Columns["Other"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dataGridViewSelectList.Columns["Other"].DefaultCellStyle.BackColor = Color.LemonChiffon;
            ////dataGridViewSelectList.Columns["Other"].Visible = false;

            dataGridViewSelectList.Columns.Add("ExpireDate", "ExpireDate");
            dataGridViewSelectList.Columns["ExpireDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["ExpireDate"].DefaultCellStyle.BackColor = Color.LemonChiffon;
            dataGridViewSelectList.Columns["ExpireDate"].Visible = true;
            dataGridViewSelectList.Columns["ExpireDate"].Width = 90;

            //DataGridViewCheckBoxColumn colChkComp = new DataGridViewCheckBoxColumn();
            //{
            //    colChkComp.AutoSizeMode =
            //        DataGridViewAutoSizeColumnMode.DisplayedCells;
            //    colChkComp.FlatStyle = FlatStyle.Standard;
            //    colChkComp.ThreeState = false;
            //    colChkComp.Name = "ChkCom";
            //    colChkComp.HeaderText = "แก้ไข";
            //    colChkComp.CellTemplate = new DataGridViewCheckBoxCell();
            //}
            //dataGridViewSelectList.Columns.Add(colChkComp);


            //DataGridViewCheckBoxColumn colChkSub = new DataGridViewCheckBoxColumn();
            //{
            //    colChkSub.AutoSizeMode =
            //        DataGridViewAutoSizeColumnMode.DisplayedCells;
            //    colChkSub.FlatStyle = FlatStyle.Standard;
            //    colChkSub.ThreeState = false;
            //    colChkSub.Name = "ChkSub";
            //    colChkSub.HeaderText = "Subject";
            //    colChkSub.CellTemplate = new DataGridViewCheckBoxCell();
            //}
            //dataGridViewSelectList.Columns.Add(colChkSub);
            ////Entity.Userinfo.MoConfig
            //DataTable dtmb = Entity.Userinfo.MoConfig.Select("[key]='MKTBudget'").CopyToDataTable();
         
            //DataGridViewComboBoxColumn comboBoxColumn2;
            //comboBoxColumn2 = new DataGridViewComboBoxColumn();

            //comboBoxColumn2.DataSource = dtmb;
            //comboBoxColumn2.ValueMember = "Code";
            //comboBoxColumn2.DisplayMember = "values";
            //comboBoxColumn2.HeaderText = "MKT Budget";
            //comboBoxColumn2.Name = "MKTBudget";
            //comboBoxColumn2.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            //comboBoxColumn2.Width = 150;
            //dataGridViewSelectList.Columns.Add(comboBoxColumn2);

    

            //comboBoxColumn2 = new DataGridViewComboBoxColumn();

            //comboBoxColumn2.DataSource = dtmb;
            //comboBoxColumn2.ValueMember = "Code";
            //comboBoxColumn2.DisplayMember = "values";
            //comboBoxColumn2.HeaderText = "GiftVoucher";
            //comboBoxColumn2.Name = "GiftVoucher";
            //comboBoxColumn2.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            //comboBoxColumn2.Width = 150;
            //dataGridViewSelectList.Columns.Add(comboBoxColumn2);

            //dataGridViewSelectList.Columns.Add("GiftNumber", "GiftNumber");
            //dataGridViewSelectList.Columns["GiftNumber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dataGridViewSelectList.Columns["GiftNumber"].DefaultCellStyle.BackColor = Color.LemonChiffon;
            //dataGridViewSelectList.Columns["GiftNumber"].Visible = true;
            //dataGridViewSelectList.Columns["GiftNumber"].Width = 100;

            //DataGridViewCheckBoxColumn ChkBeforeAfter = new DataGridViewCheckBoxColumn();
            //{
            //    ChkBeforeAfter.AutoSizeMode =
            //        DataGridViewAutoSizeColumnMode.DisplayedCells;
            //    ChkBeforeAfter.FlatStyle = FlatStyle.Standard;
            //    ChkBeforeAfter.ThreeState = false;
            //    ChkBeforeAfter.Name = "ChkBeforeAfter";
            //    ChkBeforeAfter.HeaderText = "Before After";
            //    ChkBeforeAfter.CellTemplate = new DataGridViewCheckBoxCell();
            //}
            //dataGridViewSelectList.Columns.Add(ChkBeforeAfter);

            //DataGridViewCheckBoxColumn ChkExtras_sale = new DataGridViewCheckBoxColumn();
            //{
            //    ChkExtras_sale.AutoSizeMode =
            //    DataGridViewAutoSizeColumnMode.DisplayedCells;
            //    ChkExtras_sale.FlatStyle = FlatStyle.Standard;
            //    ChkExtras_sale.ThreeState = false;
            //    ChkExtras_sale.Name = "ChkExtras_sale";
            //    ChkExtras_sale.HeaderText = "ของแถม(ขาย)";
            //    ChkExtras_sale.CellTemplate = new DataGridViewCheckBoxCell();
            //}
            //dataGridViewSelectList.Columns.Add(ChkExtras_sale);

            //DataGridViewCheckBoxColumn ChkVIP = new DataGridViewCheckBoxColumn();
            //{
            //    ChkVIP.AutoSizeMode =
            //        DataGridViewAutoSizeColumnMode.DisplayedCells;
            //    ChkVIP.FlatStyle = FlatStyle.Standard;
            //    ChkVIP.ThreeState = false;
            //    ChkVIP.Name = "ChkVIP";
            //    ChkVIP.HeaderText = "VIP(ฝ่ายบริหาร)";
            //    ChkVIP.CellTemplate = new DataGridViewCheckBoxCell();
            //}
            //dataGridViewSelectList.Columns.Add(ChkVIP);
            //DataGridViewCheckBoxColumn ChkPRO = new DataGridViewCheckBoxColumn();
            //{
            //    ChkPRO.AutoSizeMode =
            //        DataGridViewAutoSizeColumnMode.DisplayedCells;
            //    ChkPRO.FlatStyle = FlatStyle.Standard;
            //    ChkPRO.ThreeState = false;
            //    ChkPRO.Name = "ChkPRO";
            //    ChkPRO.HeaderText = "Add_Dis";
            //    ChkPRO.CellTemplate = new DataGridViewCheckBoxCell();
            //}
            //dataGridViewSelectList.Columns.Add(ChkPRO);

            //dataGridViewSelectList.Columns.Add("Tab", "Tab");
            //dataGridViewSelectList.Columns.Add("FeeRate", "FeeRate");
            //dataGridViewSelectList.Columns.Add("FeeRate2", "FeeRate2");
            //dataGridViewSelectList.Columns["FeeRate"].Visible = false;
            //dataGridViewSelectList.Columns["FeeRate2"].Visible = false;

            dataGridViewSelectList.Columns.Add("Note", "Note");//4 Amount
            dataGridViewSelectList.Columns["Note"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["Note"].DefaultCellStyle.BackColor = Color.LemonChiffon;
            dataGridViewSelectList.Columns["Note"].Width = 250;
            //dataGridViewSelectList.Columns["Tab"].Width = 10;

            //DataGridViewImageColumn ColMember = new DataGridViewImageColumn();
            //{
            //    ColMember.AutoSizeMode =
            //        DataGridViewAutoSizeColumnMode.DisplayedCells;
            //    ColMember.CellTemplate = new DataGridViewImageCell();
            //    ColMember.Name = "BtnMember";
            //    ColMember.HeaderText = "Members";
            //}
            //dataGridViewSelectList.Columns.Add(ColMember);

            dataGridViewSelectList.Columns.Add("ListOrder", "ListOrder");
            dataGridViewSelectList.Columns["ListOrder"].Width = 50;


            //DataGridViewCheckBoxColumn chkSaleCom = new DataGridViewCheckBoxColumn();
            //{
            //    chkSaleCom.AutoSizeMode =
            //        DataGridViewAutoSizeColumnMode.DisplayedCells;
            //    chkSaleCom.FlatStyle = FlatStyle.Standard;
            //    chkSaleCom.ThreeState = false;
            //    chkSaleCom.Name = "chkSaleCom";
            //    chkSaleCom.HeaderText = "SaleCom";
            //    chkSaleCom.CellTemplate = new DataGridViewCheckBoxCell();
            //}
            //dataGridViewSelectList.Columns.Add(chkSaleCom);

            //DataGridViewCheckBoxColumn chkBydr = new DataGridViewCheckBoxColumn();
            //{
            //    chkBydr.AutoSizeMode =
            //        DataGridViewAutoSizeColumnMode.DisplayedCells;
            //    chkBydr.FlatStyle = FlatStyle.Standard;
            //    chkBydr.ThreeState = false;
            //    chkBydr.Name = "chkBydr";
            //    chkBydr.HeaderText = "ByDr.";
            //    chkBydr.CellTemplate = new DataGridViewCheckBoxCell();
            //}
            //dataGridViewSelectList.Columns.Add(chkBydr);

            //DataGridViewCheckBoxColumn chkCanceled = new DataGridViewCheckBoxColumn();
            //{
            //    chkCanceled.AutoSizeMode =
            //        DataGridViewAutoSizeColumnMode.DisplayedCells;
            //    chkCanceled.FlatStyle = FlatStyle.Standard;
            //    chkCanceled.ThreeState = false;
            //    chkCanceled.Name = "chkCanceled";
            //    chkCanceled.HeaderText = "Canceled";
            //    chkCanceled.CellTemplate = new DataGridViewCheckBoxCell();
            //}
            //dataGridViewSelectList.Columns.Add(chkCanceled);

            //dtmb = Entity.Userinfo.MoConfig.Select("[key]='Free'").CopyToDataTable();
            //comboBoxColumn2 = new DataGridViewComboBoxColumn();

            //comboBoxColumn2.DataSource = dtmb;
            //comboBoxColumn2.ValueMember = "Code";
            //comboBoxColumn2.DisplayMember = "values";
            //comboBoxColumn2.HeaderText = "Free";
            //comboBoxColumn2.Name = "Free";
            //comboBoxColumn2.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            ////comboBoxColumn2.Width = 200;
            //dataGridViewSelectList.Columns.Add(comboBoxColumn2);

            //dataGridViewSelectList.Columns["Free"].Width = 100;


            //dataGridViewSelectList.Columns["ChkVIP"].Visible = false;
            //dataGridViewSelectList.Columns["ChkCom"].Visible = false;
            //dataGridViewSelectList.Columns["ChkSub"].Visible = false;
            //dataGridViewSelectList.Columns["MKTBudget"].Visible = false;
            //dataGridViewSelectList.Columns["GiftVoucher"].Visible = false;
            //dataGridViewSelectList.Columns["ChkBeforeAfter"].Visible = false;
            //dataGridViewSelectList.Columns["ChkExtras_sale"].Visible = false;
            ////dataGridViewSelectList.Columns["Other"].Visible = false;

            //dataGridViewSelectList.Columns["Tab"].Visible = false;

        }
        private void BindDataAesList()
        {
            try
            {
                DerUtility.MouseOn(this);
                dgvAestheticList.Rows.Clear();
                Entity.MedicalSupplies info = new Entity.MedicalSupplies();
                if (!string.IsNullOrEmpty(txtFindAes.Text))
                {
                    //info.MS_Name = "%" + txtFindAes.Text + "%";
                    info.Tabwhere = "Msup.MS_Code Like '%" + txtFindAes.Text + "%'" + " or Msup.MS_Name Like '%" + txtFindAes.Text + "%'";
                }
                else
                {
                    info.Tabwhere = "1=1";
                }
                //info.MS_Section = "ADI";
                info.Tab = "AESTHETIC";
                DataTable dt = new Business.MedicalSupplies().SelectMedicalSuppliesBySection(info).Tables[0];


                foreach (DataRowView item in dt.DefaultView)
                {
                    object[] myItems = {
                                          false,
                                           item["MS_Section"] + "",
                                           item["MS_Code"] + "",
                                           item["MS_Name"] + "",
                                          (item["MS_CLPrice"] + ""=="")?"0":(Convert.ToDouble(item["MS_CLPrice"]).ToString("###,###,###.##")),
                                          (item["MS_CAPrice"] + ""=="")?"0":(Convert.ToDouble(item["MS_CAPrice"]).ToString("###,###,###.##")),
                                           item["MS_Type"] + "",
                                          (item["MS_Number_C"] + "" =="")?"0":(item["MS_Number_C"] + ""),
                                           item["UnitName"] + "",
                                          info.Tab,
                                           item["FeeRate"] + "",
                                          item["FeeRate2"] + "",
                                          item["MS_Detail"] + "",
                                          item["Active"] + "",

                                          
                                       };
                    dgvAestheticList.Rows.Add(myItems);
                    if (item["Active"] + "".ToUpper() != "Y")
                    {
                        dgvAestheticList.Rows[dgvAestheticList.Rows.Count - 1].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
                    }
                }

                DerUtility.MouseOff(this);
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
        }

        private void dgvAestheticList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

         
            if (dgvAestheticList.Rows.Count < 0 || dgvAestheticList.CurrentRow == null) return;
            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
            ch1 = (DataGridViewCheckBoxCell)dgvAestheticList.Rows[dgvAestheticList.CurrentRow.Index].Cells[0];
            if (dgvAestheticList.CurrentCell.ColumnIndex != 0) return;
            if (ch1.Value == null)
                ch1.Value = false;
            switch (ch1.Value.ToString())
            {
                case "True":
                    ch1.Value = false;
                    break;
                case "False":
                    ch1.Value = true;
                    break;
            }
            if (!IsActive(dgvAestheticList.Rows[dgvAestheticList.CurrentRow.Index].Cells["Active"].Value + ""))
            { ch1.Value = false; }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public bool IsActive(string specific)
        {
            return specific.ToUpper() == "Y";
        }

        private void buttonDeleteUp_BtnClick()
        {
            try
            {
                //foreach (DataGridViewRow row in rowsToDelete)
                //{
                //    if (row.Index >= 0)
                //        dataGridViewSelectList.Rows.Remove(row);
                //}

                //foreach (DataGridViewRow row in rowsToDeletePro)
                //{
                //    if (row.Index >= 0)
                //        dataGridViewSelectListPro.Rows.Remove(row);
                //}

                //SumPriceMedicalOrder();
                //if (dataGridViewSelectList.RowCount == 0)
                //{
                //    if (FormType == DerUtility.AccessType.Update)
                //    {

                //    }
                //    else
                //    {
                //        tabTypShortName = MoSubType = "";
                //        //if (txtMO.Text.Length > 0) txtMO.Text = txtMO.Text.Remove(2, 3);
                //        //if (txtSONo.Text.Length > 0) txtSONo.Text = txtSONo.Text.Remove(2, 3);
                //    }


                //}

            }
            catch (Exception ex)
            {

                //  MessageBox.Show(ex.Message);
            }
        }

        private void buttonAddDown_BtnClick()
        {
            try
            {
                        AddDownToGrid("AESTHETIC");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AddDownToGrid(string tabPageActive)
        {
            try
            {
                //DataGridView dv = new DataGridView();
                double MS_CLPrice = 0;
                double MS_CAPrice = 0;
                double PROPrice1 = 0;
                double NormalPrice = 0;
                string MS_Price = "0";
                double Amount = 0;
                double SpacialP = 0;
                int ListOrder = 0;

                //foreach (DataRow ms in dt.Rows)
                //{

                foreach (DataGridViewRow item in dgvAestheticList.Rows)
                    {
                        DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                        ch1 = (DataGridViewCheckBoxCell)item.Cells[0];
                        if (dgvAestheticList.CurrentCell.ColumnIndex != 0) return;
                        if (ch1.Value == null)
                            ch1.Value = false;
                        if (ch1.Value.ToString() == "False")
                            continue;
                            
                    string key = "";
                            
                            var MaxID2 = 0;
                            if (dataGridViewSelectList.RowCount == 0)
                                ListOrder = 0;
                            else
                                ListOrder = MaxID2 = dataGridViewSelectList.Rows.Cast<DataGridViewRow>().Max(r => int.TryParse(r.Cells["ListOrder"].Value.ToString(), out ListOrder) ? ListOrder : 0);

                            ListOrder += 1;
                            
                            MS_CLPrice = item.Cells["MS_CLPrice"].Value + "" == "" ? 0 : double.Parse(item.Cells["MS_CLPrice"].Value + "");
                            MS_CAPrice = item.Cells["MS_CAPrice"].Value + "" == "" ? 0 : double.Parse(item.Cells["MS_CAPrice"].Value + "");
                            //PROPrice1 = item.Cells["MS_ProPrice"] + "" == "" ? 0 : double.Parse(item.Cells["MS_ProPrice"] + "");
                            //Amount = item.Cells["Amount"] + "" == "" ? 0 : double.Parse(item.Cells["Amount"] + "");



                            //MS_Price = MS_CLPrice.ToString("###,###,###.##");// Entity.Userinfo.PriceNormal.Contains(customerType) ? MS_CLPrice.ToString("###,###.##") : MS_CAPrice.ToString("###,###.##");
                            MS_Price = Entity.Userinfo.PriceNormal.Contains(customerType) ? MS_CLPrice.ToString("###,###.##") : MS_CAPrice.ToString("###,###.##");
                            NormalPrice = MS_CLPrice;// Entity.Userinfo.PriceNormal.Contains(customerType) ? MS_CLPrice : MS_CAPrice;

                            SpacialP = (PROPrice1 - (NormalPrice * Amount));

                            object[] myItems = {
                                             false,//chk
                                           item.Cells["Code"].Value,
                                           item.Cells["Name"].Value,
                                           item.Cells["MS_Number_C"].Value,//Num/Couse
                                            "",//item.Cells["Amount"]+"",//จำนวนที่ซื้อ
                                           "0",//Total
                                           //"0",//Use
                                             item.Cells["UnitName"].Value,//Unit
                                           "0",//Balance
                                          MS_Price,//PricePer
                                          //(PROPrice1-(NormalPrice*Amount)).ToString("###,###.##"),//Special Price
                                          PROPrice1.ToString("###,###.##"),//PriceTotal
                                          
                                           //customerType == "CNT"||customerType == "CNM" ?double.Parse( item.Cells["MS_CLPrice"].Value+"").ToString("###,###.##") :double.Parse( item.Cells["MS_CAPrice"].Value+"").ToString("###,###.##"),//Price/Unit
                                           //customerType == "CNT"||customerType == "CNM" ?double.Parse( item.Cells["MS_CLPrice"].Value+"").ToString("###,###.##") :double.Parse( item.Cells["MS_CAPrice"].Value+"").ToString("###,###.##"),//PriceTotal
                                           //"",//Other
                                           DateTime.Now.AddYears(1).ToString(),//ExpireDate
                                           //false,//comp
                                           //false,//subject
                                           //"",//false,//mkt b
                                           //"",//false,//gif
                                           //"",//GiftNumber
                                          //false,//BeforeAfter
                                          //false,//Extras_sale
                                          //false,//VIP
                                          //false,//PRO
                                           //"tabTyp",
                                           //item.Cells["FeeRate"].Value+"",
                                           //item.Cells["FeeRate2"].Value+"",
                                           "",//Note
                                           //"",//imageList1.Images[0],
                                           ListOrder,
                                           //true
                                       };
                            item.Cells[0].Value = false;

                            dataGridViewSelectList.Rows.Add(myItems);

                            //SumPriceMedicalOrder();
                        }
                    }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmServiceReq_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics.frmServiceReq = null;
        }

        private void picPrint_Click(object sender, EventArgs e)
        {
            try
            {

                List<DataGridViewRow> lsSelect = new List<DataGridViewRow>();
                DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();

                DataTable dt = new DataTable();
                foreach (DataGridViewColumn col in dataGridViewSelectList.Columns)
                {
                    dt.Columns.Add(col.Name);
                }

                foreach (DataGridViewRow row in dataGridViewSelectList.Rows)
                {
                    //ch1 = (DataGridViewCheckBoxCell)row.Cells["Select"];
                    //if ((ch1.Value + "").ToLower() == "true")
                    //{
                        DataRow dRow = dt.NewRow();
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            dRow[cell.ColumnIndex] = cell.Value;
                        }
                        dt.Rows.Add(dRow);
                    //}
                }

                //foreach (DataGridViewRow dr in dgvData.Rows)
                //{
                //    ch1 = (DataGridViewCheckBoxCell)dr.Cells[0];
                //    if ((ch1.Value+"").ToLower() == "true")
                //        lsSelect.Add(dr);

                //}

                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Select Item.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                FrmPreviewRpt obj = new FrmPreviewRpt();

                string strTypeofPay = "";

                obj.PrintType = "";
                double dblCredit = 0.00;
                double dblCash = 0.00;
                string strBankName = "";

                //obj.PrintType = RoomName;
                //obj.Remark = txtRemark.Text;

                //string MainName = String.Format("{0} ({1})", dataGridViewSelectList.Rows[0].Cells["CustName"].Value + "", CN);// CN ชื่อลูกค้า
                //string UsedName = String.Format("{0} ({1})", dataGridViewSelectList.Rows[0].Cells["UsedName"].Value + "", CN);// CN ชื่อลูกค้าใช้คอร์ส
                obj.MainName = CustName;
                obj.UsedName = CN;

                obj.FormName = "RptCourseApproved";


                obj.dt = dt;
                obj.MaximizeBox = true;
                obj.TopMost = true;
                obj.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewSelectList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {

            }
        }
    }
}
