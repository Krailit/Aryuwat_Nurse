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
using JR.Utils.GUI.Forms;
using AryuwatSystem.m_DataSet;

namespace AryuwatSystem.Forms
{
    public partial class FrmMedicalOrderSettingPro : DockContent, IForm
    {

        public FrmMedicalOrderSettingPro()
        {
            InitializeComponent();
            comboBoxCommission1.MouseWheel += new MouseEventHandler(comboBoxCommission1_MouseWheel);
            comboBoxCommission2.MouseWheel += new MouseEventHandler(comboBoxCommission2_MouseWheel);
            comboBoxByDr.MouseWheel += new MouseEventHandler(comboBoxByDr_MouseWheel);
        }

        public FrmMedicalOrderSettingPro(ref Entity.Customer info)
        {
            InitializeComponent();
            comboBoxCommission1.MouseWheel += new MouseEventHandler(comboBoxCommission1_MouseWheel);
            comboBoxCommission2.MouseWheel += new MouseEventHandler(comboBoxCommission2_MouseWheel);
            comboBoxByDr.MouseWheel += new MouseEventHandler(comboBoxByDr_MouseWheel);

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
        List<string> LsSelectMS_Code = new List<string>();
        public string typeCustomer { get; set; }
        public string RefCN { get; set; }
        public string RefCN_Name { get; set; }
        public string customerType { get; set; }
        public string ApploveID { get; set; }
        public string EN_COM1 { get; set; }
        public string EN_COM2 { get; set; }
        public string DR_COM { get; set; }
        public string BranchID { get; set; }


        public string PriceRef { get; set; }
        public decimal SalePriceNew { get; set; }
        public decimal SumAllTypeSalePrice { get; set; }
        public decimal SumMS_Price { get; set; }
        private bool firstload = true;

        private string vn = "";
        private string so = "";
        private string CN;
        DataSet dsData = new DataSet();
        DataSet dsStock = new DataSet();
        private string docFilePath;
        List<DataGridViewRow> rowsToDelete = new List<DataGridViewRow>();
        //DataGridView dataGridToDelete=new DataGridView();
        public List<Entity.MedicalStuff> MedicalStuffs { get; set; }
        public List<Entity.MedicalOrderUseTrans> MedicalOrderUseTranss { get; set; }
        public DerUtility.AccessType FormType { get; set; }
        public string RefVN { get; set; }
        //=======================สำหรับวงเงินโอน มา
        public string SORef = "";
        public string MS_CodeRef = "";
        public string ListOrderRef = "";
        public bool AddMoney = false;
        private Dictionary<string, List<Entity.MembersTrans>> dicMemberTran = new Dictionary<string, List<Entity.MembersTrans>>();

        List<Entity.SupplieTrans> listSupOther = new List<Entity.SupplieTrans>();

        public string MS_Code = "";
        public Dictionary<string, FreeTrans> dicFreeTrans = new Dictionary<string, FreeTrans>();
        public Dictionary<string, FreeTrans> dicFreeTransDel = new Dictionary<string, FreeTrans>();

        public string VN
        {
            get { return vn; }
            set { vn = value; }

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
            tabPromotion = 8,
            tabRoom = 9,
        }
        #endregion
        List<string> lsUnit = new List<string>();
        List<string> MKTBudget = new List<string>();
        List<string> GiftVoucher = new List<string>();
        Dictionary<string, string> dicMKTBudget = new Dictionary<string, string>();
        Dictionary<string, string> dicGiftVoucher = new Dictionary<string, string>();
        Dictionary<string, List<string>> dicPromotion = new Dictionary<string, List<string>>();
        Dictionary<string, decimal> dicProSubItem = new Dictionary<string, decimal>();
        DataTable dtAESTHETIC;
        DataTable dtSURGERY;
        DataTable dtWELLNESS;
        DataTable dtPHARMACY;
        DataTable dtPromotion = new DataTable();
        DataTable dtRoom = new DataTable();
        string COUPON_PRO_Code = "";
        decimal COUPON_Price = 0;
        string COUPON_Note = "";
        string COUPON_Pro = "";


        public string PRO_CodeGift = "";
        bool Bydr = false;
        decimal Unpaid = 0;
        decimal NetAmount = 0;
        public string MedStatus_Code = "0";
        string tabTyp = "AESTHETIC";
        string tabTypShortName = "";
        string moso = "SO-";
        string MOType = "";
        public string MO = "";
        string PROCredit = "";
        string PROCreditProductGroup = "";
        string MoSubType = "AE";
        string idMax = "";
        public string PRO_Code = "xxx";//{ get; set; }
        public string PRO_Name { get; set; }
        public string PRO_CalType { get; set; }
        public decimal ProFix_Amount = 0;
        public decimal ProCreditMoney = 0;
        public decimal ProPricePay = 0;
        public decimal ProPricePayx = 0;
        public decimal ProCreditRemain = 0;
        public decimal ProDiscountPercen = 0;
        public decimal SpecialDiscountBath = 0;
        public string ProCreditRemark = "";
        List<string> ListOfProCredit = new List<string>();
        bool OverProCredit = false;
        public Entity.HowYouhear HowYouhearInfo { get; set; }

        private void showRef()
        {
            if (this.SORef + "" != "")
            {
                this.txtSoRef.Visible = true;
                this.txtBalanceRef.Visible = true;
                this.labelref1.Visible = true;
                this.lblBalanceRef.Visible = true;
                this.lblRefVN.Visible = true;
                this.txtSoRef.Text = this.SORef;
                this.txtBalanceRef.Text = (this.ProCreditRemain == 0) ? "0" : Convert.ToDecimal(this.ProCreditRemain).ToString("###,###,###.##");
                this.txtCustomerName.Text = this.RefCN_Name;
                this.labelCN.Text = RefCN;
                lbPromotion.Text = string.Format("Promotion:{0}:{1}", PRO_Code, PRO_Name);
                lbProCredit.Text = string.Format("Balances/Credit ({0}/{1}) บาท/Bth.", (ProCreditRemain) == 0 ? "0" : (ProCreditRemain).ToString("###,###,###.##"), ProCreditMoney.ToString("###,###,###.##"));
                //lbProCredit.Visible = true;

                if ((this.EN_COM1 + "").Length > 3)
                    comboBoxCommission1.SelectedValue = this.EN_COM1;
                if ((this.EN_COM2 + "").Length > 3)
                    comboBoxCommission2.SelectedValue = this.EN_COM2;
                if ((this.DR_COM + "").Length > 3)
                    comboBoxByDr.SelectedValue = this.DR_COM;
                if ((this.BranchID + "").Length > 1)
                    cboBranch.SelectedValue = this.BranchID;


                //radioPRO.Enabled = false;
                if ((this.RefCN ?? "") != "")
                {
                    this.CN = this.RefCN;
                }
            }
        }

        private void DisableTab(TabPage enableTab)
        {
            try
            {
                var checktab = false;
                tabControl.TabPages.Remove(tabAesthetic);
                //tabControl.TabPages.Remove(tabTreatment);
                tabControl.TabPages.Remove(tabSurgery);
                tabControl.TabPages.Remove(tabWellness_Antiaging);
                tabControl.TabPages.Remove(tabPromotion);
                tabControl.TabPages.Remove(tabRoom);
                tabControl.TabPages.Insert(0, enableTab);
                tabControl.SelectedTab = enableTab;
                if (enableTab.ToString() == "TabPage: {Room}")
                {
                    tabControl.TabPages.Remove(tabAttachFile);
                    tabControl.TabPages.Remove(tabPharmacy);
                }
                else
                {
                    foreach (var tab in tabControl.TabPages)
                    {
                        if (tab.ToString() == "TabPage: {Pharmacy & Product}")
                        {
                            checktab = true;
                        }
                    }
                    if (!checktab)
                    {
                        tabControl.TabPages.Insert(0, tabPharmacy);
                        tabControl.TabPages.Insert(0, tabAttachFile);
                        BindDataPharmacyList();
                    }
                }
                //if (MoSubType != "PRO")
                //{
                if (dataGridViewSelectList.RowCount > 0)
                    dataGridViewSelectList.Rows.Clear();
                if (dataGridViewSelectListPro.RowCount > 0)
                    dataGridViewSelectListPro.Rows.Clear();
                // }
                tabControl.TabPages.Remove(tabAesthetic);

            }
            catch (Exception)
            {

                throw;
            }
        }
        private void FrmMedicalOrderSettingPro_Load(object sender, EventArgs e)
        {
            try
            {
                if (!(Userinfo.IsAdmin ?? "").Contains(Userinfo.EN))
                {
                    label4.Visible = false;
                    txtPriceTotal.Visible = false;
                    label13.Visible = false;
                }
                labelCN.Text = "";
                labelKey1.Text = "";
                lbPromotion.Text = "";
                this.toolTip1.SetToolTip(this.pictureBoxRefreshProduct, "Update Product");
                this.toolTip1.SetToolTip(this.pictureBoxPstock, "Print Stock");
                this.dataGridViewSelectList.CellEndEdit += new DataGridViewCellEventHandler(this.dataGridViewSelectList_CellEndEdit);
                this.dataGridViewSelectList.CellMouseUp += new DataGridViewCellMouseEventHandler(this.dataGridViewSelectList_CellMouseUp);
                this.dataGridViewSelectList.CellContentClick += new DataGridViewCellEventHandler(this.dataGridViewSelectList_CellContentClick);
                this.dataGridViewSelectList.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(this.dataGridViewSelectList_EditingControlShowing);
                this.dataGridViewSelectList.RowPostPaint += new DataGridViewRowPostPaintEventHandler(this.dataGridViewSelectList_RowPostPaint);
                this.btnSave.Click += new EventHandler(this.btnSave_Click);
                this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
                //this.showRef();
                foreach (DataRow row in Userinfo.UnitName.Rows)
                {
                    this.lsUnit.Add(row["UnitName"] + "");
                }
                this.SetColumnsDgv();

                this.BindCommission();
                this.MedicalStuffs = new List<Entity.MedicalStuff>();
                this.MedicalOrderUseTranss = new List<Entity.MedicalOrderUseTrans>();
                dateTimePickerCreate.Format = DateTimePickerFormat.Custom;
                dateTimePickerCreate.CustomFormat = "dd-MM-yyyy";
                this.dateTimePickerCreate.Value = DateTime.Now;
                dateTimePickerEnd.Format = DateTimePickerFormat.Custom;
                dateTimePickerEnd.CustomFormat = "dd-MM-yyyy";
                this.dateTimePickerEnd.Value = DateTime.Now;
                this.BindDataAesList(false);
                this.BindDataSurgeryList();
                this.BindDataWellness_antiAgentList(false);
                this.BindDataPharmacyList();
                this.BindPromotionList();
                this.BindRoomList();
                BindCboBranch();
                splitContainer1.Panel1Collapsed = true;
                splitContainer1.Panel1.Hide();
                dataGridViewSelectListPro.Visible = false;

                this.showRef();

                //labelKey1.Text = "ssssss";
                //labelkey2.Text = "ssssss";
                //labelkey3.Text = "ssssss";
                //labelkey4.Text = "ssssss";
                if (FormType == DerUtility.AccessType.Update)
                {
                    radioAE.Checked = false;
                    radioPRO.Checked = false;
                    radioWE.Checked = false;
                    radioSU.Checked = false;
                    radioRoom.Checked = false;
                    radioAE.Enabled = false;
                    radioPRO.Enabled = false;
                    radioWE.Enabled = false;
                    radioSU.Enabled = false;
                    radioRoom.Enabled = false;

                    string tab = "";
                    tab = MoSubType = vn == "" ? SO.Substring(3, 2) : vn.Substring(3, 2);

                    switch (tab.ToUpper())
                    {
                        case "AE":
                            //this.BindDataAesList();
                            radioAE.Checked = true;
                            DisableTab(tabAesthetic);
                            MoSubType = "AE";
                            break;
                        //case "TR":
                        //    this.BindDataTreatmentList();
                        //    DisableTab(tabTreatment);
                        //    break;
                        case "SU":
                            //this.BindDataSurgeryList();
                            radioSU.Checked = true;
                            DisableTab(tabSurgery);
                            MoSubType = "SU";
                            break;
                        case "PR":
                            this.BindPromotionList();
                            radioPRO.Checked = true;
                            DisableTab(tabPromotion);
                            //EnableTabPro(tabPromotion);
                            MoSubType = "PRO";
                            break;
                        case "RO":
                            this.BindRoomList();
                            radioRoom.Checked = true;
                            radioRoom.Enabled = false;
                            lblStartDate.Visible = true;
                            lblEndDate.Visible = true;
                            dateTimePickerCreate.Visible = true;
                            dateTimePickerEnd.Visible = true;
                            DisableTab(tabRoom);
                            MoSubType = "ROOM";
                            break;
                        case "WE":
                            //this.BindDataWellness_antiAgentList();
                            radioWE.Checked = true;
                            DisableTab(tabWellness_Antiaging);
                            MoSubType = "WE";
                            //MoType = "WE";
                            break;
                        default:
                            FormType = DerUtility.AccessType.Insert;
                            this.idMax = UtilityBackEnd.GenMaxSeqnoValues(moso);
                            this.txtSONo.Text = this.idMax.Replace("VNM", moso);
                            this.idMax = this.idMax.Replace(moso, "").Replace("VNM", "");

                            //this.BindDataHairList();
                            this.BindDataAesList(false);
                            //this.BindDataTreatmentList();
                            this.BindDataSurgeryList();
                            this.BindDataWellness_antiAgentList(false);
                            this.BindDataPharmacyList();
                            this.BindPromotionList();
                            break;
                    }
                    //this.BindDataPharmacyList();
                    radioAE.Enabled = false;
                    radioPRO.Enabled = false;
                    radioWE.Enabled = false;
                    radioSU.Enabled = false;

                    this.BindData();

                    if (PROCredit == "Y" && PRO_CalType == "B")
                    {
                        //========================For Pro  Buffet  and Amount  26-04-2019
                        //ลบรายการอื่นออกให้หมดยกเว้น Buffet
                        BindDataAesList(true);
                        this.BindDataWellness_antiAgentList(true);
                    }


                }
                else //New
                {

                    if (MoSubType == "ROOM")
                    {
                        using (var context = new EntitiesOPD_System())
                        {
                            var getRoomMO = context.MedicalOrders.Where(x => x.Room_Status == true).Take(1).OrderByDescending(x => x.ID).FirstOrDefault();
                            int maxid = getRoomMO != null ? Convert.ToInt32(getRoomMO.SONo.Substring(12, 4).ToString()) : 0; var strCheck = moso + MoSubType + "-" + ((DateTime.Now.Year + 543).ToString().Substring(2, 2) + (DateTime.Now.Month).ToString("0#") + (maxid + 1).ToString("000#")).ToString();
                            this.idMax = strCheck;
                        }
                    }
                    else
                    {
                        this.idMax = UtilityBackEnd.GenMaxSeqnoValues(moso + MoSubType + "-");
                    }
                    if (radioButtonMO.Checked)
                        this.txtMO.Text = this.MO = this.idMax.Replace("VNM", moso);
                    else
                        this.txtSONo.Text = this.idMax.Replace("VNM", moso);


                    //this.idMax = UtilityBackEnd.GenMaxSeqnoValues(moso);
                    //this.txtSONo.Text = this.idMax.Replace("VNM", moso);
                    //this.idMax = this.idMax.Replace(moso, "").Replace("VNM", "");



                    //tabControl.TabPages.Remove(tabTreatment);
                    //tabControl.TabPages.Remove(tabHair);



                    DisableTab(tabAesthetic);
                    //tabControl.TabPages.Remove(tabPharmacy);
                    //SelectCustomer();
                }
                dataGridViewSelectListPro.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridViewSelectListPro.Columns["Amount"].DefaultCellStyle.BackColor = Color.LemonChiffon;
                dataGridViewSelectList.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridViewSelectList.Columns["Amount"].DefaultCellStyle.BackColor = Color.LemonChiffon;
                dataGridViewSelectList.Columns["SpecialPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridViewSelectList.Columns["SpecialPrice"].DefaultCellStyle.BackColor = Color.LemonChiffon;
                dataGridViewSelectList.Columns["Free"].Width = 150;
                dataGridViewSelectList.CellEnter += new DataGridViewCellEventHandler(dataGridViewSelectList_CellEnter);
                if (PRO_CodeGift != "")
                {
                    moso = "SO-PRO-";
                    this.idMax = UtilityBackEnd.GenMaxSeqnoValues(moso);
                    this.txtSONo.Text = this.idMax.Replace("VNM", moso);
                    this.idMax = this.idMax.Replace(moso, "").Replace("VNM", "");

                    //this.BindPromotionList();
                    radioPRO.Checked = true;
                    radioAE.Checked = false;
                    radioAE.Enabled = false;
                    radioPRO.Enabled = false;
                    radioWE.Enabled = false;
                    radioSU.Enabled = false;
                    radioRoom.Enabled = false;
                    DisableTab(tabPromotion);

                    MoSubType = "PRO";
                    foreach (DataGridViewRow Pitem in dgvPromotionList.Rows)//Promotion
                    {
                        if (PRO_CodeGift == Pitem.Cells["PRO_Code"].Value + "")
                        {
                            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                            ch1 = (DataGridViewCheckBoxCell)dgvPromotionList.Rows[Pitem.Index].Cells[0];
                            ch1.Value = true;
                            dataGridViewSelectListPro.Visible = true;

                            //======================2019 - 11- 02====================
                            tabPageActive = TabPageActive.tabPromotion;
                            //buttonAddDown(null,null);
                            buttonAddDown_BtnClick();
                        }
                    }
                }
                //DisableControls(this);
                //if (radioButtonSO.Checked) btnChange.Visible = false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        private void DisableControls(Control con)
        {
            foreach (Control c in con.Controls)
            {
                DisableControls(c);
            }
            con.Enabled = false;
        }

        private void EnableControls(Control con)
        {
            if (con != null)
            {
                con.Enabled = true;
                EnableControls(con.Parent);
            }
        }
        void dataGridViewSelectList_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dg = (DataGridView)sender;

            if (dg.CurrentCell.EditType == typeof(DataGridViewComboBoxEditingControl))
            {
                SendKeys.Send("{F4}");
            }
        }

        //private void FrmMedicalOrderSettingPro_Load(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        toolTip1.SetToolTip(pictureBoxRefreshProduct, "Update Product");
        //        //dataGridViewSelectList.CellValueChanged += new DataGridViewCellEventHandler(dataGridViewSelectList_CellValueChanged);
        //        dataGridViewSelectList.CellEndEdit += new DataGridViewCellEventHandler(dataGridViewSelectList_CellEndEdit);
        //        //dataGridViewSelectList.CellMouseMove += new DataGridViewCellMouseEventHandler(dataGridViewSelectList_CellMouseMove);
        //        dataGridViewSelectList.CellMouseUp += new DataGridViewCellMouseEventHandler(dataGridViewSelectList_CellMouseUp);
        //        dataGridViewSelectList.CellContentClick += new DataGridViewCellEventHandler(dataGridViewSelectList_CellContentClick);
        //        dataGridViewSelectList.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dataGridViewSelectList_EditingControlShowing);
        //        dataGridViewSelectList.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dataGridViewSelectList_RowPostPaint);
        //        btnSave.Click += new EventHandler(btnSave_Click);
        //        btnCancel.Click += new EventHandler(btnCancel_Click);
        //        foreach (DataRow item in Entity.Userinfo.UnitName.Rows)
        //        {
        //            lsUnit.Add(item["UnitName"] + "");
        //        }
        //        SetColumnsDgv();
        //        BindDataHairList();
        //        BindDataAesList();
        //        BindDataTreatmentList();
        //        BindDataSurgeryList();
        //        BindDataWellness_antiAgentList();
        //        BindDataPharmacyList();
        //        BindCommission();
        //        MedicalStuffs = new List<MedicalStuff>();
        //        MedicalOrderUseTranss = new List<MedicalOrderUseTrans>();
        //        dateTimePickerCreate.Value = DateTime.Now;
        //        if (!string.IsNullOrEmpty(vn))
        //        {
        //            BindData();
        //        }
        //        else
        //        {
        //             idMax = AryuwatSystem.Data.UtilityBackEnd.GenMaxSeqnoValues("MO-");
        //            txtMO.Text =MO= idMax.Replace("VNM","MO-") ;
        //            idMax = idMax.Replace("MO-", "").Replace("VNM", "");
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //}
        public void BindCommission()
        {
            try
            {
                AutoCompleteStringCollection colValues = new AutoCompleteStringCollection();
                var info = new Entity.Personnel();
                info.PersonnelType = "11";
                info.QueryType = "SEARCHCOM";
                DataTable dt = new Business.Personnel().SelectCustomerPaging(info).Tables[0];
                DataRow dr = dt.NewRow();
                dr["EN"] = "";
                dr["FullNameThai"] = "--ไม่ระบุ--";
                dt.Rows.InsertAt(dr, 0);

                foreach (DataRow row in dt.Rows)
                {
                    colValues.Add(row["FullNameThai"].ToString());
                }

                comboBoxCommission1.Items.Clear();
                comboBoxCommission1.DataSource = dt;
                comboBoxCommission1.ValueMember = "EN";
                comboBoxCommission1.DisplayMember = "FullNameThai";
                comboBoxCommission1.SelectedValue = "";// Entity.Userinfo.EN;
                comboBoxCommission1.AutoCompleteCustomSource = colValues;

                comboBoxCommission2.Items.Clear();
                comboBoxCommission2.DataSource = dt.Copy();
                comboBoxCommission2.ValueMember = "EN";
                comboBoxCommission2.DisplayMember = "FullNameThai";
                comboBoxCommission2.SelectedValue = "";// Entity.Userinfo.EN;
                comboBoxCommission2.AutoCompleteCustomSource = colValues;




                AutoCompleteStringCollection colValuesdr = new AutoCompleteStringCollection();
                var infoDr = new Entity.Personnel();
                //infoDr.PersonnelType = "11";
                infoDr.QueryType = "LISTDOCTOR";
                DataTable dtDr = new Business.Personnel().SelectCustomerPaging(infoDr).Tables[0];
                DataRow drx = dtDr.NewRow();
                drx["EN"] = "";
                drx["FullNameThai"] = "--ไม่ระบุ--";
                dtDr.Rows.InsertAt(drx, 0);

                foreach (DataRow row in dtDr.Rows)
                {
                    colValuesdr.Add(row["FullNameThai"].ToString());
                }


                comboBoxByDr.Items.Clear();
                comboBoxByDr.DataSource = dtDr;
                comboBoxByDr.ValueMember = "EN";
                comboBoxByDr.DisplayMember = "FullNameThai";
                comboBoxByDr.SelectedValue = "";// Entity.Userinfo.EN;
                comboBoxByDr.AutoCompleteCustomSource = colValuesdr;


                ////txtSubDistrict.Items.Clear();
                //foreach (DataRow dr in dt.Rows)
                //{
                //    colValues.Add(dr["SubDistrict_NAME"].ToString().Trim());
                //}
                //txtSubDistrict.BeginUpdate();
                //txtSubDistrict.DisplayMember = "SubDistrict_NAME";
                //txtSubDistrict.ValueMember = "SubDistrict_CODE";
                //txtSubDistrict.DataSource = dtSubDistrict;
                //txtSubDistrict.AutoCompleteCustomSource = colValues;


            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
        }

        void comboBoxByDr_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        void comboBoxCommission2_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        void comboBoxCommission1_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
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
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tabname = tabControl.SelectedTab == null ? null : tabControl.SelectedTab.Name;
            if (!String.IsNullOrEmpty(tabname))
                tabPageActive = StringToEnum<TabPageActive>(tabname);

            //switch (tabname)
            //{
            //    case   "tabAesthetic":
            //        tabPageActive =TabPageActive.tabAesthetic;
            //        break;
            //    case "tabTreatment":
            //        tabPageActive = TabPageActive.tabAesthetic;
            //        break;
            //    case "tabSurgery":
            //        tabPageActive = TabPageActive.tabAesthetic;
            //        break;
            //    case "tabHair":
            //        tabPageActive = TabPageActive.tabAesthetic;
            //        break;
            //    case "tabWellness_Antiaging":
            //        tabPageActive = TabPageActive.tabAesthetic;
            //        break;
            //    case "tabPharmacy":
            //        tabPageActive = TabPageActive.tabAesthetic;
            //        break;
            //    case "tabAttachFile":
            //        tabPageActive = TabPageActive.tabAesthetic;
            //        break;
            //}
        }
        private void dgvFile_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
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
                Entity.MedicalOrder info;
                DataSet ds = new Business.MedicalOrder().SelectMedicalOrderById(vn, SO);
                DataTable dtMed = ds.Tables[0];
                DataTable dtSup = ds.Tables[1];
                DataTable dtStuff = ds.Tables[2];
                DataTable dtDoc = ds.Tables[3];
                DataTable dtMemTrans = ds.Tables[4];
                DataTable dtPro = ds.Tables[7];
                DataTable dtHow = ds.Tables[8];
                DataTable dtFreeTrans = ds.Tables[10];

                using (var context = new EntitiesOPD_System())
                {
                    if (!String.IsNullOrEmpty(vn))
                    {
                        var getdate = context.MedicalOrders.Where(x => x.SONo == SO).FirstOrDefault();
                        if (getdate != null)
                        {
                            dateTimePickerCreate.Value = getdate.Start_Date == null ? DateTime.Now : getdate.Start_Date.Value;
                            dateTimePickerEnd.Value = getdate.End_Date == null ? DateTime.Now : getdate.End_Date.Value;
                        }
                    }
                    else
                    {
                        var getdate = context.MedicalOrders.Where(x => x.VN == vn).FirstOrDefault();
                        if (getdate != null)
                        {
                            dateTimePickerCreate.Value = getdate.Start_Date == null ? DateTime.Now : getdate.Start_Date.Value;
                            dateTimePickerEnd.Value = getdate.End_Date == null ? DateTime.Now : getdate.End_Date.Value;
                        }
                    }
                }

                foreach (DataRow item in dtFreeTrans.Rows)
                {
                    string dickey = string.Format("{0}{1}{2}{3}", item["Sono"], item["VN"], item["MS_Code"], item["ListOrder"]);
                    FreeTrans f = new FreeTrans();
                    if (dicFreeTrans.ContainsKey(dickey)) continue;

                    f.SONo = item["Sono"] + "";
                    f.VN = item["VN"] + "";
                    f.MS_Code = item["MS_Code"] + "";
                    f.ListOrder = item["ListOrder"] + "";
                    f.FreeType = item["FreeType"] + "";
                    f.GiftCodeOther = item["GiftCodeOther"] + "";
                    f.Approve = item["Approve"] + "";
                    f.Approve2 = item["Approve2"] + "";
                    f.Remark = item["Remark"] + "";
                    dicFreeTrans.Add(dickey, f);
                }
                //===================Promotion Grid==============
                foreach (DataRow dr in dtPro.Rows)
                {
                    object[] myItems = {
                                             false,//chk
                                             dr["Pro_Code"] + "",
                                             dr["Pro_Name"] + "",
                                             dr["Amount"] + "",
                                             dr["Pro_Price"] + "",
                                             "",
                                             dr["ListOrder"] + "",
                                             dr["ListMS_Code"] + ""

                                       };
                    dataGridViewSelectListPro.Rows.Add(myItems);
                }
                if (dtPro.Rows.Count > 0)
                {
                    dataGridViewSelectListPro.Visible = true;
                    splitContainer1.Panel1Collapsed = false;
                    splitContainer1.Panel1.Show();
                    dataGridViewSelectList.Columns["Amount"].ReadOnly = true;
                }
                //===================Promotion Grid==============

                int rowCount = 0;
                if (dtPro.Rows.Count > 0)
                {
                    PRO_Code = dtPro.Rows[0]["Pro_Code"] + "";
                    PRO_Name = dtPro.Rows[0]["Pro_Name"] + "";
                }
                if (dtMed.Rows[0]["PRO_Name"] + "" != "")
                {
                    PRO_Code = dtMed.Rows[0]["Pro_Code"] + "";
                    PRO_Name = dtMed.Rows[0]["PRO_Name"] + "";
                    PRO_CalType = dtMed.Rows[0]["PRO_CalType"] + "";
                    ProFix_Amount = dtMed.Rows[0]["Fix_Amount"] + "" == "" ? 0 : Convert.ToDecimal(dtMed.Rows[0]["Fix_Amount"] + "");
                    decimal am = 1;
                    foreach (DataRow item in dtSup.Rows)
                    {
                        if ((item["MS_Code"] + "").Contains("CREDIT"))
                        {
                            am = item["Amount"] + "" == "" ? 0 : Convert.ToDecimal(item["Amount"] + "");
                            break;
                        }
                    }

                    ProFix_Amount = ProFix_Amount * am;

                    PROCredit = dtMed.Rows[0]["PRO_Type"] + "" == "CREDIT" ? "Y" : "";
                }

                lbPromotion.Text = "";
                lbPromotion.Text = string.Format("Promotion:{0}:{1}", PRO_Code, PRO_Name);
                lbPromotion.Visible = PRO_Code != "xxx";
                CN = dtMed.Rows[0]["CN"] + "";
                radioButtonMO.Checked = dtMed.Rows[0]["MOType"] + "" == "Y";
                txtSORefAccount.Visible = dtMed.Rows[0]["MOType"] + "" != "Y";
                labelSOrefAcc.Visible = dtMed.Rows[0]["MOType"] + "" != "Y";
                //radioButtonMO.Enabled = !radioButtonMO.Checked;
                //radioButtonSO.Enabled = !radioButtonMO.Checked;

                MOType = dtMed.Rows[0]["MOType"] + "";
                this.RefVN = dtMed.Rows[0]["SOClose"] + "";
                this.PriceRef = (this.RefVN != "") ? (dtMed.Rows[0]["PriceTotalRef"] + "") : "";
                //ProCreditRemark = dtMed.Rows[0]["Remark"] + "";
                txtRemark.Text = dtMed.Rows[0]["Remark"] + "";
                checkBoxOld.Checked = dtMed.Rows[0]["OldKey"] + "" == "Y";
                this.showRef();

                customerType = dtMed.Rows[0]["CustomerType"] + "";
                txtCustomerName.Text = dtMed.Rows[0]["FullNameThai"] + "" == "" ? dtMed.Rows[0]["FullNameEng"] + "" : dtMed.Rows[0]["FullNameThai"] + "";
                labelCN.Text = dtMed.Rows[0]["CN"] + "";
                txtAgenMemID.Text = dtMed.Rows[0]["AgenMemID"] + "";
                txtAgenMemName.Text = dtMed.Rows[0]["agencyFullNameThai"] + "";
                txtAgenMemIDOPD.Text = dtMed.Rows[0]["AgenMemIDOPD"] + "";
                txtAgenMemNameOPD.Text = dtMed.Rows[0]["agencyOPDFullNameThai"] + "";
                Unpaid = dtMed.Rows[0]["Unpaid"] + "" == "" ? 0 : Convert.ToDecimal(dtMed.Rows[0]["Unpaid"] + "");
                NetAmount = dtMed.Rows[0]["NetAmount"] + "" == "" ? 0 : Convert.ToDecimal(dtMed.Rows[0]["NetAmount"] + "");
                dateTimePickerCreate.Value = dtMed.Rows[0]["CreateDate"] + "" == "" ? DateTime.Now : Convert.ToDateTime(dtMed.Rows[0]["CreateDate"] + "");
                txtSONo.Text = dtMed.Rows[0]["SONo"] + "";
                txtSoRef.Text = dtMed.Rows[0]["SORef"] + "";
                txtSORefAccount.Text = dtMed.Rows[0]["SORefAccount"] + "";
                txtNote.Text = dtMed.Rows[0]["Notes"] + "";
                txtBalanceRef.Text = dtMed.Rows[0]["PriceCreditRef"] + "" == "" ? "" : Convert.ToDouble(dtMed.Rows[0]["PriceCreditRef"] + "").ToString("###,###,###.##"); ;
                comboBoxCommission1.SelectedValue = dtMed.Rows[0]["EN_COMS1"] + "";
                comboBoxCommission2.SelectedValue = dtMed.Rows[0]["EN_COMS2"] + "";
                comboBoxByDr.SelectedValue = dtMed.Rows[0]["DR_COM"] + "";


                labelKey1.Text = dtMed.Rows[0]["SaveBy"] + "";
                //labelkey2.Text = dtMed.Rows[0]["SaveBy"] + "";
                //labelkey3.Text = dtMed.Rows[0]["SaveBy"] + "";
                //labelkey4.Text = dtMed.Rows[0]["SaveBy"] + "";

                if (dtMed.Rows[0]["BranchId"] + "" != "") cboBranch.SelectedValue = dtMed.Rows[0]["BranchId"] + "";

                //if (dtMed.Rows[0]["MedStatus_Code"] + "" != "2" )
                //    btnSave.Enabled = true;        //ยังไม่จ่าย บันทึกได้
                //else if (dtMed.Rows[0]["MedStatus_Code"] + "" == "2" && dtMed.Rows[0]["UseStatus"] + "" != "4" && dtMed.Rows[0]["UseStatus"] + "" != "5")//จ่ายครบ และ ยังไม่ใช้
                //    btnSave.Enabled = true; 
                //else
                //    btnSave.Enabled = false; 
                //if( dateTimePickerCreate.Value.Month >4)
                //    btnSave.Enabled = false; 
                //if (Unpaid == 0 )
                //    MedStatus_Code = "2";//Paid

                //if (Unpaid > 0 && NetAmount > Unpaid)
                //    MedStatus_Code = "1";//Deposit
                //if (Unpaid > 0 && NetAmount == Unpaid)
                //    MedStatus_Code = "0";//UnPaid

                //if (Unpaid == 0 && NetAmount == 0)
                //    MedStatus_Code = "0";//UnPaid

                if (!string.IsNullOrEmpty(vn))
                {
                    //lblVn.Visible = true; lblVn.Text = "VN:"+ vn; 
                    txtMO.Text = vn;
                    radioButtonMO.Checked = true;
                    MOType = "Y";
                    radioButtonSO.Enabled = false;
                    radioButtonMO.Enabled = false;
                }

                //DataTable dtSupGroup = GroupByMultiple("MergStatus", dtSup); // Group Layer
                //foreach (DataRow rw in dtSupGroup.Rows) 
                //{
                //string expression = "MergStatus ='" + rw["MergStatus"] + "'";
                foreach (DataRow dr in dtSup.Rows)
                {


                    double dblTotal = (double.Parse(dr["Amount"] + "") * (dr["MS_Number_C"] + "" == "" ? 0 : double.Parse(dr["MS_Number_C"] + "")));
                    //decimal dblCL = dr["MS_CLPrice"] + "" == "" ? 0 : decimal.Parse(dr["MS_CLPrice"] + "");
                    //decimal dblCA = dr["MS_CAPrice"] + "" == "" ? 0 : decimal.Parse(dr["MS_CAPrice"] + "");

                    decimal dblCL = dr["MS_Price"] + "" == "" ? 0 : decimal.Parse(dr["MS_Price"] + "");// เปลี่ยนเป็น ดึงราคาจากที่บันทึกไว้ตอนซื้อ 21-01-2020
                    decimal dblCA = dr["MS_Price"] + "" == "" ? 0 : decimal.Parse(dr["MS_Price"] + "");

                    string MS_Name = dr["MS_Name"] + "";
                    decimal pricePerUnit = 0;
                    decimal ProAmount = 0;
                    customerType = dtMed.Rows[0]["CustomerType"] + "";
                    if (Userinfo.PriceAgency.Contains(customerType))
                        pricePerUnit = dblCA;
                    else
                        pricePerUnit = dblCL;

                    if (Entity.Userinfo.FIX_PRO_TOPUP5.Contains(PRO_Code))
                    {
                        pricePerUnit = dblCL;
                    }

                    //===================ตอนโหลดมา ก็ เช็คและลด 5 %=================================
                    //if (Entity.Userinfo.FIX_PRO_TOPUP5.Contains(PRO_Code) && !Entity.Userinfo.FIX_COUPON_Wallet.Contains(dr["MS_Code"] + "") && !(dr["MS_Code"] + "").Contains(PRO_Code) && !MS_Name.ToUpper().Contains(Entity.Userinfo.FIX_Contains_BUFFET))
                    //{
                    //    pricePerUnit = pricePerUnit - (pricePerUnit * Entity.Userinfo.FIX_COUPON_TOPUP);
                    //    //MS_Price = pricePerUnit.ToString("###,###,###.##");
                    //}

                    //===================ตอนโหลดมา ก็ เช็คและลด 5 %=================================
                    if (dr["MS_Name"] + "" == "" && dr["MS_Code"] + "" == "") continue;
                    if ((dr["MS_Code"] + "").Contains("PRO_CREDIT"))//ถ้าเป็น โปรวงเงิน แต่ต้องเป็น MO เท่านั้น
                    {
                        if (radioButtonMO.Checked)
                            SetbuttonSave(true);
                        else if (CheckMOCreate())
                            SetbuttonSave(false);
                        if ((Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN) || Userinfo.IS_ADMIN_EDIT.Contains(Userinfo.EN))
                            SetbuttonSave(true);


                        string ms_name = "";
                        string code = "";
                        foreach (DataGridViewRow item in dgvPromotionList.Rows)
                        {
                            if ((dr["MS_Code"] + "").Contains(item.Cells["PRO_Code"].Value.ToString()))
                            {
                                ms_name = item.Cells["PRO_Name"].Value.ToString();
                                PRO_Code = item.Cells["PRO_Code"].Value.ToString();
                                code = item.Cells["PRO_Code"].Value.ToString() + "|PRO_CREDIT";
                                ProAmount = dr["Amount"] + "" == "" ? 1 : decimal.Parse(dr["Amount"] + "");
                                ProCreditMoney += item.Cells["ProPriceCredit"].Value + "" == "" ? 0 : decimal.Parse(item.Cells["ProPriceCredit"].Value + "") * ProAmount;
                                //ProCreditMoney +=  (decimal.Parse(dr["PriceAfterDis"] + "") == 0 ? decimal.Parse(item.Cells["ProPrice"].Value + "") : decimal.Parse(dr["PriceAfterDis"] + "")) * ProAmount;// item.Cells["ProPrice"].Value + "" == "" ? 0 : decimal.Parse(item.Cells["ProPrice"].Value + "");
                                ProPricePayx = dr["PriceAfterDis"] + "" == "" ? Convert.ToDecimal(item.Cells["ProPrice"].Value + "") : Convert.ToDecimal(dr["PriceAfterDis"] + "");// item.Cells["ProPrice"].Value + "" == "" ? 0 : decimal.Parse(item.Cells["ProPrice"].Value + "");
                                ProPricePay += ProPricePayx;
                                //=================2018-02-27==========ขายเกินราคาชชชชชชชชชชช
                                //============2020-06-22===============
                                if (PRO_CalType == "A")
                                    ProCreditMoney = ProPricePay;
                                else
                                    ProCreditMoney = ProCreditMoney < ProPricePay ? ProPricePay : ProCreditMoney;
                                //============2020-06-22=============== ถ้าเป็นแบบ A
                                //=================2018-02-27==========ขายเกินราคาชชชชชชชชชชProCreditMoneyช
                                //ProPricePay = dataGridViewSelectList.Rows[0].Cells["PriceTotal"].Value + "" == "" ? 0 : decimal.Parse(dataGridViewSelectList.Rows[0].Cells["PriceTotal"].Value + "");
                                //ProCreditMoney =ProCreditMoney* ProAmount;
                                //ProPricePay = ProPricePay * ProAmount;
                                CalcPercen();
                                //lbPromotion.Text = string.Format("Promotion:{0}:{1}", PRO_Code, item.Cells["PRO_Name"].Value + "");
                                lbProCredit.Text = string.Format("Balances/Credit ({0}/{1}) บาท/Bth.", (ProCreditRemain) == 0 ? "0" : (ProCreditRemain).ToString("###,###,###.##"), ProCreditMoney.ToString("###,###,###.##"));
                                lbProCredit.Visible = item.Cells["PRO_Type"].Value + "" == "CREDIT";
                                PROCredit = item.Cells["PRO_Type"].Value + "" == "CREDIT" ? "Y" : "";
                                PROCreditProductGroup = item.Cells["ProductGroup"].Value + "";

                                //radioAE.Enabled = true;
                                //radioSU.Enabled = true;
                                //radioWE.Enabled = true;
                                //tabControl.TabPages.Insert(0, tabPromotion);
                                if (PROCredit == "Y" && radioButtonMO.Checked)
                                {
                                    tabControl.TabPages.Remove(tabPromotion);
                                    tabControl.TabPages.Remove(tabRoom);
                                    tabControl.TabPages.Insert(0, tabWellness_Antiaging);
                                    tabControl.TabPages.Insert(0, tabSurgery);
                                    tabControl.TabPages.Insert(0, tabAesthetic);
                                    tabControl.SelectedTab = tabAesthetic;
                                }
                            }
                        }
                        decimal NormalPrice = dr["MS_Price"] + "" == "" ? 0 : decimal.Parse(dr["MS_Price"] + "");
                        decimal PROPrice1 = dr["SpecialPrice"] + "" == "" ? 0 : decimal.Parse(dr["SpecialPrice"] + "");
                        decimal Discashier = dr["DiscountBathByItem"] + "" == "" ? 0 : decimal.Parse(dr["DiscountBathByItem"] + "");
                        decimal PriceTotal = NormalPrice > PROPrice1 ? NormalPrice - PROPrice1 : PROPrice1 - NormalPrice;

                        PriceTotal = dr["PriceAfterDis"] + "" == "" ? 0 : decimal.Parse(dr["PriceAfterDis"] + ""); //(Math.Abs(NormalPrice) - Math.Abs(PROPrice1)) * (double)ProAmount;

                        //===================ตอนโหลดมา ก็ เช็คและลด 5 %=================================
                        if (Entity.Userinfo.FIX_PRO_TOPUP5.Contains(PRO_Code) && !Entity.Userinfo.FIX_COUPON_Wallet.Contains(dr["MS_Code"] + "") && !(dr["MS_Code"] + "").Contains(PRO_Code))
                        {
                            NormalPrice = NormalPrice - (NormalPrice * Entity.Userinfo.FIX_COUPON_TOPUP);
                            //MS_Price = pricePerUnit.ToString("###,###,###.##");
                        }

                        //===================ตอนโหลดมา ก็ เช็คและลด 5 %=================================

                        //if (PriceTotal < 0)
                        //{
                        //    PriceTotal *= -1;
                        //}
                        //PriceTotal = Math.Abs(NormalPrice - PROPrice1);
                        object[] myItems = {
                                             false,//chk
                                           code,
                                           ms_name,
                                           "1",//Num/Couse
                                            ProAmount.ToString("###,###,###.##"),//จำนวนที่ซื้อ
                                           "0",//Total
                                           "0",//Use
                                            "",//Unit
                                           "0",//Balance
                                          NormalPrice,//PricePer
                                          PROPrice1.ToString("###,###,###.##"),//Special Price
                                          Discashier.ToString("###,###,###.##"),//Discashier ส่วนลดจากแคสเชีย
                                          PriceTotal.ToString("###,###,###.##"),//PriceTotal
                                          
                                           //customerType == "CNT"||customerType == "CNM" ?double.Parse( item.Cells["MS_CLPrice"].Value+"").ToString("###,###.##") :double.Parse( item.Cells["MS_CAPrice"].Value+"").ToString("###,###.##"),//Price/Unit
                                           //customerType == "CNT"||customerType == "CNM" ?double.Parse( item.Cells["MS_CLPrice"].Value+"").ToString("###,###.##") :double.Parse( item.Cells["MS_CAPrice"].Value+"").ToString("###,###.##"),//PriceTotal
                                           dr["FlagUse"]+"",//Other
                                           dr["ExpireDate"] +""==""?"":Convert.ToDateTime(dr["ExpireDate"] +"").ToString("yyyy/MM/dd"),//ExpireDate
                                           false,//comp
                                           false,//subject
                                           "",//false,//mkt b
                                           "",//false,//gif
                                           "",//GiftNumber
                                          false,//BeforeAfter
                                          false,//Extras_sale
                                          false,//VIP
                                          dr["PRO_MDiscount"]+""=="Y"?true:false,//PROCredit=="Y",//PRO  //Add_dis
                                           tabTyp,
                                           dr["FeeRate"]+"",
                                           dr["FeeRate2"]+"",
                                           "",
                                           imageList1.Images[0],
                                           dr["ListOrder"]+"",
                                          dr["SaleCom"]+""=="Y"?true:false,
                                          dr["ByDr"]+""=="Y"?true:false,
                                           false,
                                            dr["AmountPro"]+"",
                                            dr["PricePerPro"]+"",
                                            dr["SurgicalFeeNewTab"]+"",
                                            dr["COUPON_Pro"]+"",
                                            dr["SOnoSub"]+"",
                                            dr["VNSub"]+""

                                       };
                        dataGridViewSelectList.Rows.Add(myItems);
                        // ProPricePay =(decimal)PriceTotal;
                        //CalcPercen();


                        if (radioButtonMO.Checked) dataGridViewSelectList.Rows[dataGridViewSelectList.RowCount - 1].Visible = false;

                    }
                    else //ถ้าเป็น ธรรมดา
                    {

                        object[] myItems = {
                                               false,
                                               dr["MS_Code"] + "",
                                               dr["MS_Name"] + "",
                                               dr["MS_Number_C"] + "",
                                               dr["Amount"] + "" ==""?"":double.Parse(dr["Amount"] + "").ToString("###,###.##"), //จำนวนที่ซื้อ
                                               
                                               dblTotal.ToString("###,###.##"),
                                               dr["NumOfUse"] + ""==""?"0":Convert.ToDouble(dr["NumOfUse"] + "").ToString("###,###,###.##"),
                                               dr["UnitName"] + "",
                                               (dblTotal - (dr["NumOfUse"] + ""==""?0:double.Parse(dr["NumOfUse"] + ""))).ToString("###,###.##"),
                                               pricePerUnit.ToString("###,###.##"),
                                               double.Parse(dr["SpecialPrice"] + "").ToString("###,###.##"),//SpecialPrice
                                               dr["DiscountBathByItem"] + ""==""?"0":Convert.ToDouble(dr["DiscountBathByItem"] + "").ToString("###,###,###.##"),
                                                dr["PriceAfterDis"] + ""==""?"0":Convert.ToDouble(dr["PriceAfterDis"] + "").ToString("###,###,###.##"),

                                               dr["FreeAmount"] + "",//Other
                                                 dr["ExpireDate"] + ""==""?DateTime.Now.AddYears(1).ToString("yyyy/MM/dd"):Convert.ToDateTime(dr["ExpireDate"] + "").ToString("yyyy/MM/dd"),//ExpireDate
                                               dr["Complimentary"] + "" == "Y" ? true : false,
                                               dr["Subject"] + "" == "Y" ? true : false,
                                               dr["MarketingBudget"] + "" ,//== "Y" ? true : false,
                                               dr["Gift"] + "",// == "Y" ? true : false,
                                               dr["GiftNumber"] + "",
                                               dr["BeforeAfter"] + "" == "Y" ? true : false,
                                               dr["Extras_sale"] + "" == "Y" ? true : false,
                                               dr["VIP"] + "" == "Y" ? true : false,
                                               dr["PRO_MDiscount"] + "" == "Y" ? true : false,//Add_dis
                                               dr["MedicalTab"] + "",
                                               dr["FeeRate"]+"",
                                               dr["FeeRate2"]+"",
                                               dr["Note"]+"",
                                               imageList1.Images[0],
                                               dr["ListOrder"]+"",
                                               dr["SaleCom"] + "" == "Y" ? true : false,
                                               dr["ByDr"] + "" == "Y" ? true : false,
                                               dr["Canceled"] + "" == "Y" ? true : false,
                                               dr["FreeType"] + "" ,
                                                dr["AmountPro"]+"",
                                                dr["PricePerPro"]+"",
                                               dr["SurgicalFeeNewTab"]+"",
                                               dr["COUPON_Pro"]+"",
                                                dr["SOnoSub"]+"",
                                                dr["VNSub"]+""
                                           };
                        dataGridViewSelectList.Rows.Add(myItems);
                        if ((dr["MS_Code"] + "").ToUpper().Contains(Entity.Userinfo.FIX_COOL))
                            this.dataGridViewSelectList.Rows[dataGridViewSelectList.RowCount - 1].Cells["Amount"].ReadOnly = true;

                        if (Entity.Userinfo.FIX_OTHER_SUB.Contains((dr["MS_Code"] + "").ToUpper()))
                        {
                            //dataGridViewSelectList.Rows[dataGridViewSelectList.Rows.Count - 1].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Underline);
                            dataGridViewSelectList.Rows[dataGridViewSelectList.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Blue;
                            dataGridViewSelectList.Rows[dataGridViewSelectList.Rows.Count - 1].Cells["Name"].Style.Font = new Font(this.Font, FontStyle.Underline);
                        }

                    }

                }
                //  break;
                //}
                //}
                //if (PROCredit == "Y") dataGridViewSelectList.Columns["SpecialPrice"].HeaderText = "Discount";
                if (radioButtonMO.Checked && PROCredit == "Y" && PRO_CalType == "P" && ProDiscountPercen == 0) dataGridViewSelectList.Columns["ChkPRO"].Visible = true;

                dataGridViewSelectList.ClearSelection();

                //SumPriceMedicalOrder();


                ISAlert = false;
                Entity.MedicalStuff stuffInfo;
                bool blnChkDup = false;
                foreach (DataRow row in dtStuff.Rows)
                {

                    stuffInfo = new Entity.MedicalStuff();
                    stuffInfo.Position_ID = row["Position_ID"] + "";
                    stuffInfo.EmployeeId = row["EmployeeId"] + "";
                    stuffInfo.MS_Code = row["MergStatus"] + "";
                    stuffInfo.FullNameCustomer = row["FullNameThai"] + "" == ""
                                                     ? row["FullNameEng"] + ""
                                                     : row["FullNameThai"] + "";
                    stuffInfo.SectionStuff = row["Position_Type"] + "";
                    MedicalStuffs.Add(stuffInfo);
                    //}

                }
                foreach (DataRow row in dtDoc.Rows)
                {
                    object[] myItems = {
                                      "",
                                       row["FileName"]+"",
                                       row["Detail"]+"",
                                   imageList1.Images[2],
                                       imageList1.Images[1],

                                       "False",
                                         row["Id"]+""
                                   };
                    dgvFile.Rows.Add(myItems);
                }
                // member group trans
                dicMemberTran = new Dictionary<string, List<Entity.MembersTrans>>();
                List<Entity.MembersTrans> lsmem = new List<Entity.MembersTrans>();
                DataView view = new DataView(dtMemTrans);
                DataTable distinctValues = view.ToTable(true, "VN", "MS_Code");

                foreach (DataRow ms in distinctValues.Rows)
                {
                    string sql = string.Format("VN='{0}' and MS_Code='{1}'", ms["VN"], ms["MS_Code"]);
                    lsmem = new List<Entity.MembersTrans>();
                    foreach (DataRow row in dtMemTrans.Select(sql))
                    {
                        Entity.MembersTrans m = new Entity.MembersTrans();
                        m.VN = row["VN"] + "";
                        m.MS_Code = row["MS_Code"] + "";
                        m.CN = row["CN"] + "";
                        lsmem.Add(m);
                    }
                    if (!dicMemberTran.ContainsKey(ms["MS_Code"] + ""))
                        dicMemberTran.Add(ms["MS_Code"] + "", lsmem);
                }


                //===========HowYouhearSO============= 

                foreach (DataRow ms in dtHow.Rows)
                {
                    HowYouhearInfo = new Entity.HowYouhear();
                    HowYouhearInfo.Newspaper = dtHow.Rows[0]["Newspaper"].ToString();
                    HowYouhearInfo.Magazine = dtHow.Rows[0]["Magazine"].ToString();
                    HowYouhearInfo.Internet = dtHow.Rows[0]["Internet"].ToString();
                    HowYouhearInfo.Friend = dtHow.Rows[0]["Friend"].ToString();
                    HowYouhearInfo.Travelthrough = dtHow.Rows[0]["Travelthrough"].ToString();
                    HowYouhearInfo.Facebook = dtHow.Rows[0]["Facebook"].ToString();
                    HowYouhearInfo.Instagram = dtHow.Rows[0]["Instagram"].ToString();
                    HowYouhearInfo.Sms = dtHow.Rows[0]["Sms"].ToString();
                    HowYouhearInfo.LineAt = dtHow.Rows[0]["LineAt"].ToString();
                    HowYouhearInfo.Line = dtHow.Rows[0]["Line"].ToString();
                    HowYouhearInfo.Taxi = dtHow.Rows[0]["Taxi"].ToString();
                    HowYouhearInfo.Agency = dtHow.Rows[0]["Agency"].ToString();
                    HowYouhearInfo.AgencyName = dtHow.Rows[0]["AgencyMemberName"].ToString();
                    HowYouhearInfo.AgencyOPD = dtMed.Rows[0]["AgenMemIDOPD"].ToString();
                    HowYouhearInfo.AgencyNameOPD = dtMed.Rows[0]["agencyOPDFullNameThai"].ToString();

                    HowYouhearInfo.TV = dtHow.Rows[0]["TV"].ToString();
                    HowYouhearInfo.CallIn = dtHow.Rows[0]["CallIn"].ToString();

                    HowYouhearInfo.HowYouhearOther = dtHow.Rows[0]["HowYouhearOther"].ToString();
                    if (HowYouhearInfo.Agency != "N")
                    {
                        txtAgenMemID.Visible = true;
                        txtAgenMemName.Visible = true;
                        labelIDAgency.Visible = true;
                        labelNameAgency.Visible = true;

                        txtAgenMemName.Text = HowYouhearInfo.AgencyName;
                        txtAgenMemID.Text = HowYouhearInfo.Agency;

                    }
                    else
                    {
                        //txtAgenMemID.Visible = false;
                        //txtAgenMemName.Visible = false;
                        //labelIDAgency.Visible = false;
                        //labelNameAgency.Visible = false;
                    }
                }


                firstload = false;


                btnHow.Visible = txtMO.Text.Length < 5;
                dataGridViewSelectList.Columns["Free"].Width = 150;

                SumPriceMedicalOrder();
                if (radioButtonMO.Checked == false)
                    radioButtonMO.Enabled = !CheckMOCreate();


                pictureBoxPstock.Visible = radioButtonMO.Checked;
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
        private void SetColumnsDgv()
        {
            SetColDtTmpHair();
            SetColumnDgvAesList();

            SetColumnDgvSurgeryList();
            SetColumnDgvWellness_AntiagingList();
            SetColumnDgvPharmacyList();

            SetColumnsPromotion();
            SetColumnsRoom();
            SetColumnDgvSelectList();
            SetColumnDgvSelectListPro();
            SetColumnDgvFile();
        }
        private void SetColumnDgvFile()
        {
            dgvFile.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dgvFile_RowPostPaint);
            DerUtility.SetPropertyDgv(dgvFile);

            dgvFile.Columns.Add("FilePath", "FilePath");
            dgvFile.Columns.Add("FileName", "ชื่อไฟล์");
            dgvFile.Columns.Add("Detail", "รายละเอียด");
            DataGridViewImageColumn colFile = new DataGridViewImageColumn();
            {
                colFile.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                colFile.CellTemplate = new DataGridViewImageCell();
                colFile.Name = "DelFile";
            }
            dgvFile.Columns.Add(colFile);
            DataGridViewImageColumn colDown = new DataGridViewImageColumn();
            {
                colDown.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                colDown.CellTemplate = new DataGridViewImageCell();
                colDown.Name = "ViewFile";
            }

            dgvFile.Columns.Add(colDown);
            dgvFile.Columns.Add("NewRow", "NewRow");
            dgvFile.Columns.Add("Id", "Id");

            dgvFile.Columns["FileName"].Width = 200;
            dgvFile.Columns["Detail"].Width = 300;
            dgvFile.Columns["FilePath"].Visible = false;
            dgvFile.Columns["NewRow"].Visible = false;
            dgvFile.Columns["Id"].Visible = false;
            dgvFile.Columns["DelFile"].Width = 50;
            dgvFile.Columns["ViewFile"].Width = 50;
        }
        private void SetColDtTmpHair()
        {
            dtTmpHairSelect.Columns.Add("MS_Section", typeof(string));
            dtTmpHairSelect.Columns.Add("Code", typeof(string));
            dtTmpHairSelect.Columns.Add("Name", typeof(string));
            dtTmpHairSelect.Columns.Add("MS_CLPrice", typeof(string));
            dtTmpHairSelect.Columns.Add("MS_CAPrice", typeof(string));
            dtTmpHairSelect.Columns.Add("UnitName", typeof(string));
        }
        private void SetColumnsRoom()
        {
            DerUtility.SetPropertyDgv(gvRoom);
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            {

                column.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                column.FlatStyle = FlatStyle.Standard;
                column.ThreeState = false;
                column.CellTemplate = new DataGridViewCheckBoxCell();
                column.CellTemplate.Style.BackColor = Color.Beige;
            }
            gvRoom.Columns.Add(column);
            gvRoom.Columns.Add("Room_Code", "Room Code");
            gvRoom.Columns.Add("Room_Name", "Room Name");
            gvRoom.Columns.Add("Amount_Day", "Amount Day");
            gvRoom.Columns.Add("Room_PriceCredit", "Room Price Credit");
            gvRoom.Columns.Add("Room_Price", "Room Price");
            gvRoom.Columns.Add("Remark", "Remark");

        }
        private void SetColumnsPromotion()
        {
            DerUtility.SetPropertyDgv(dgvPromotionList);
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            {

                column.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                column.FlatStyle = FlatStyle.Standard;
                column.ThreeState = false;
                column.CellTemplate = new DataGridViewCheckBoxCell();
                column.CellTemplate.Style.BackColor = Color.Beige;
            }
            dgvPromotionList.Columns.Add(column);
            dgvPromotionList.Columns.Add("PRO_Code", "PRO_Code");
            dgvPromotionList.Columns.Add("PRO_Name", "PRO_Name");
            dgvPromotionList.Columns.Add("ProPrice", "Price");
            dgvPromotionList.Columns.Add("DateStart", "Start date");
            dgvPromotionList.Columns.Add("DateEnd", "Expire date");
            dgvPromotionList.Columns.Add("PRO_Active", "Active");
            dgvPromotionList.Columns.Add("Remark", "Remark");
            dgvPromotionList.Columns.Add("Tab", "Tab");
            dgvPromotionList.Columns.Add("PRO_Type", "PRO_Type");
            dgvPromotionList.Columns.Add("ProPriceCredit", "ProPriceCredit");
            dgvPromotionList.Columns.Add("ProductGroup", "ProductGroup");
            dgvPromotionList.Columns.Add("PRO_Dept", "แผนก");


            dgvPromotionList.Columns["PRO_Code"].Width = 80;
            dgvPromotionList.Columns["PRO_Name"].Width = 200;
            dgvPromotionList.Columns["ProPrice"].Width = 50;
            dgvPromotionList.Columns["DateStart"].Width = 100;
            dgvPromotionList.Columns["DateEnd"].Width = 100;
            dgvPromotionList.Columns["PRO_Active"].Width = 10;
            //dgvPromotionList.Columns["ProductGroup"].Visible = false;

            dgvPromotionList.Columns["Remark"].Width = 200;

            //dgvPromotionList.Columns["ProPriceCredit"].Visible =false;
            dgvPromotionList.Columns.Add("SurgicalFeeNewTab", "Com.");

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
            dgvAestheticList.Columns.Add("SurgicalFeeNewTab", "Com.");

        }
        private void SetColumnDgvSurgeryList()
        {
            DerUtility.SetPropertyDgv(dgvSurgeryList);
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            {
                column.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                column.FlatStyle = FlatStyle.Standard;
                column.ThreeState = false;
                column.CellTemplate = new DataGridViewCheckBoxCell();
                column.CellTemplate.Style.BackColor = Color.Beige;
            }
            dgvSurgeryList.Columns.Add(column);
            dgvSurgeryList.Columns.Add("MS_Section", "Section");
            dgvSurgeryList.Columns.Add("Code", "Code");
            dgvSurgeryList.Columns.Add("Name", "Name");

            dgvSurgeryList.Columns.Add("MS_CLPrice", "Local Price");
            dgvSurgeryList.Columns.Add("MS_CAPrice", "Agency Price");
            //dgvSurgeryList.Columns.Add("MS_CMPrice", "MS_CMPrice");
            dgvSurgeryList.Columns.Add("MS_Type", "MS_Type");
            dgvSurgeryList.Columns.Add("MS_Number_C", "Number/Course");
            dgvSurgeryList.Columns.Add("UnitName", "Unit");
            dgvSurgeryList.Columns.Add("FeeRate", "Fee Rate");
            dgvSurgeryList.Columns.Add("FeeRate2", "Fee Rate 2");

            dgvSurgeryList.Columns.Add("Tab", "Tab");

            dgvSurgeryList.Columns["Tab"].Visible = false;
            dgvSurgeryList.Columns["FeeRate"].Visible = false;
            dgvSurgeryList.Columns["FeeRate2"].Visible = false;
            dgvSurgeryList.Columns.Add("MS_Detail", "Detail");
            dgvSurgeryList.Columns["MS_Detail"].Width = 200;
            //dgvSurgeryList.Columns["MS_CMPrice"].Visible = false;
            // dgvSurgeryList.Columns["MS_Type"].Visible = false;
            //dgvSurgeryList.Columns["MS_Number_C"].Visible = false;

            dgvSurgeryList.Columns["Code"].Width = 100;
            dgvSurgeryList.Columns["Name"].Width = 150;
            dgvSurgeryList.Columns.Add("Active", "Active");
            dgvSurgeryList.Columns.Add("SurgicalFeeNewTab", "Com.");


        }
        private void SetColumnDgvWellness_AntiagingList()
        {
            DerUtility.SetPropertyDgv(dgvWellness_AntiagingList);
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            {
                column.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                column.FlatStyle = FlatStyle.Standard;
                column.ThreeState = false;
                column.CellTemplate = new DataGridViewCheckBoxCell();
                column.CellTemplate.Style.BackColor = Color.Beige;
                column.ReadOnly = false;
            }
            dgvWellness_AntiagingList.Columns.Add(column);
            dgvWellness_AntiagingList.Columns.Add("MS_Section", "Section");
            dgvWellness_AntiagingList.Columns.Add("Code", "Code");
            dgvWellness_AntiagingList.Columns.Add("Name", "Name");

            dgvWellness_AntiagingList.Columns.Add("MS_CLPrice", "Local Price");
            dgvWellness_AntiagingList.Columns.Add("MS_CAPrice", "Agency Price");
            //dgvWellness_AntiagingList.Columns.Add("MS_CMPrice", "MS_CMPrice");
            dgvWellness_AntiagingList.Columns.Add("MS_Type", "MS_Type");
            dgvWellness_AntiagingList.Columns.Add("MS_Number_C", "Number/Course");
            dgvWellness_AntiagingList.Columns.Add("UnitName", "Unit");
            dgvWellness_AntiagingList.Columns.Add("Tab", "Tab");
            dgvWellness_AntiagingList.Columns.Add("FeeRate", "Fee Rate");
            dgvWellness_AntiagingList.Columns.Add("FeeRate2", "Fee Rate 2");

            dgvWellness_AntiagingList.Columns["Tab"].Visible = false;
            dgvWellness_AntiagingList.Columns["FeeRate"].Visible = false;
            dgvWellness_AntiagingList.Columns["FeeRate2"].Visible = false;
            //dgvWellness_AntiagingList.Columns["MS_CMPrice"].Visible = false;
            // dgvWellness_AntiagingList.Columns["MS_Type"].Visible = false;
            //dgvWellness_AntiagingList.Columns["MS_Number_C"].Visible = false;

            dgvWellness_AntiagingList.Columns["Code"].Width = 100;
            dgvWellness_AntiagingList.Columns["Name"].Width = 120;

            dgvWellness_AntiagingList.Columns.Add("MS_Detail", "Detail");
            dgvWellness_AntiagingList.Columns["MS_Detail"].Width = 200;

            dgvWellness_AntiagingList.Columns.Add("Active", "Active");
            dgvWellness_AntiagingList.Columns.Add("SurgicalFeeNewTab", "Com.");
        }
        private void SetColumnDgvPharmacyList()
        {
            DerUtility.SetPropertyDgv(dgvPharmacyList);
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            {
                column.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                column.FlatStyle = FlatStyle.Standard;
                column.ThreeState = false;
                column.CellTemplate = new DataGridViewCheckBoxCell();
                column.CellTemplate.Style.BackColor = Color.Beige;
            }
            dgvPharmacyList.Columns.Add(column);
            dgvPharmacyList.Columns.Add("MS_Section", "Section");
            dgvPharmacyList.Columns.Add("Code", "Code");
            dgvPharmacyList.Columns.Add("Name", "Name");

            dgvPharmacyList.Columns.Add("MS_CLPrice", "Local Price");
            dgvPharmacyList.Columns.Add("MS_CAPrice", "Agency Price");
            //dgvPharmacyList.Columns.Add("MS_CMPrice", "MS_CMPrice");
            dgvPharmacyList.Columns.Add("MS_Type", "MS_Type");
            dgvPharmacyList.Columns.Add("MS_Number_C", "Number/Course");
            dgvPharmacyList.Columns.Add("UnitName", "Unit");
            dgvPharmacyList.Columns.Add("Tab", "Tab");
            dgvPharmacyList.Columns.Add("FeeRate", "Fee Rate");
            dgvPharmacyList.Columns.Add("FeeRate2", "Fee Rate 2");

            dgvPharmacyList.Columns["Tab"].Visible = false;
            dgvPharmacyList.Columns["FeeRate"].Visible = false;
            dgvPharmacyList.Columns["FeeRate2"].Visible = false;
            //dgvPharmacyList.Columns["MS_CMPrice"].Visible = false;
            // dgvPharmacyList.Columns["MS_Type"].Visible = false;
            //dgvPharmacyList.Columns["MS_Number_C"].Visible = false;

            dgvPharmacyList.Columns["Code"].Width = 100;
            dgvPharmacyList.Columns["Name"].Width = 150;

            dgvPharmacyList.Columns.Add("MS_Detail", "Detail");
            dgvPharmacyList.Columns["MS_Detail"].Width = 200;

            dgvPharmacyList.Columns.Add("Active", "Active");
            dgvPharmacyList.Columns.Add("SurgicalFeeNewTab", "Com.");
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
            dataGridViewSelectList.Columns.Add("Code", "Code");//1
            dataGridViewSelectList.Columns["Code"].ReadOnly = true;
            dataGridViewSelectList.Columns["Code"].Width = 80;

            dataGridViewSelectList.Columns.Add("Name", "Name");//2
            dataGridViewSelectList.Columns["Name"].ReadOnly = true;
            dataGridViewSelectList.Columns["Name"].Width = 250;

            dataGridViewSelectList.Columns.Add("No./Course", "No./Course");//3
            dataGridViewSelectList.Columns["No./Course"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["No./Course"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewSelectList.Columns["No./Course"].ReadOnly = true;
            dataGridViewSelectList.Columns["No./Course"].Width = 80;

            dataGridViewSelectList.Columns.Add("Amount", "Quantity");//4 Amount
            dataGridViewSelectList.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["Amount"].DefaultCellStyle.BackColor = Color.Red;
            dataGridViewSelectList.Columns["Amount"].Width = 60;



            dataGridViewSelectList.Columns.Add("Total", "Total");//5
            dataGridViewSelectList.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvHairSelect.Columns["Total"].DefaultCellStyle.BackColor = Color.Black;
            dataGridViewSelectList.Columns["Total"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewSelectList.Columns["Total"].ReadOnly = true;
            dataGridViewSelectList.Columns["Total"].Width = 45;

            dataGridViewSelectList.Columns.Add("Used", "Used");//6
            dataGridViewSelectList.Columns["Used"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvHairSelect.Columns["Used"].DefaultCellStyle.BackColor = Color.Black;
            dataGridViewSelectList.Columns["Used"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewSelectList.Columns["Used"].ReadOnly = true;
            dataGridViewSelectList.Columns["Used"].Width = 45;



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

            dataGridViewSelectList.Columns.Add("SpecialPrice", "Special Price");
            dataGridViewSelectList.Columns["SpecialPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["SpecialPrice"].DefaultCellStyle.BackColor = Color.LemonChiffon;
            dataGridViewSelectList.Columns["SpecialPrice"].Visible = true;
            dataGridViewSelectList.Columns["SpecialPrice"].Width = 90;

            dataGridViewSelectList.Columns.Add("Discashier", "ส่วนลด Cashier");
            dataGridViewSelectList.Columns["Discashier"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["Discashier"].DefaultCellStyle.BackColor = Color.LemonChiffon;
            dataGridViewSelectList.Columns["Discashier"].Visible = true;
            dataGridViewSelectList.Columns["Discashier"].ReadOnly = true;
            dataGridViewSelectList.Columns["Discashier"].Width = 90;

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

            dataGridViewSelectList.Columns.Add("Other", "โอนไปที่");
            dataGridViewSelectList.Columns["Other"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["Other"].DefaultCellStyle.BackColor = Color.LemonChiffon;
            //dataGridViewSelectList.Columns["Other"].Visible = false;

            dataGridViewSelectList.Columns.Add("ExpireDate", "ExpireDate");
            dataGridViewSelectList.Columns["ExpireDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["ExpireDate"].DefaultCellStyle.BackColor = Color.LemonChiffon;
            dataGridViewSelectList.Columns["ExpireDate"].Visible = true;
            dataGridViewSelectList.Columns["ExpireDate"].Width = 90;

            DataGridViewCheckBoxColumn colChkComp = new DataGridViewCheckBoxColumn();
            {
                colChkComp.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                colChkComp.FlatStyle = FlatStyle.Standard;
                colChkComp.ThreeState = false;
                colChkComp.Name = "ChkCom";
                colChkComp.HeaderText = "แก้ไข";
                colChkComp.CellTemplate = new DataGridViewCheckBoxCell();
            }
            dataGridViewSelectList.Columns.Add(colChkComp);


            DataGridViewCheckBoxColumn colChkSub = new DataGridViewCheckBoxColumn();
            {
                colChkSub.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                colChkSub.FlatStyle = FlatStyle.Standard;
                colChkSub.ThreeState = false;
                colChkSub.Name = "ChkSub";
                colChkSub.HeaderText = "Subject";
                colChkSub.CellTemplate = new DataGridViewCheckBoxCell();
            }
            dataGridViewSelectList.Columns.Add(colChkSub);
            //Entity.Userinfo.MoConfig
            DataTable dtmb = Entity.Userinfo.MoConfig.Select("[key]='MKTBudget'").CopyToDataTable();
            MKTBudget.Add("");

            foreach (DataRow item in dtmb.Rows)
            {
                MKTBudget.Add(item["values"] + "");
                dicMKTBudget.Add(item["values"] + "", item["Code"] + "");
            }
            DataGridViewComboBoxColumn comboBoxColumn2;
            comboBoxColumn2 = new DataGridViewComboBoxColumn();

            comboBoxColumn2.DataSource = dtmb;
            comboBoxColumn2.ValueMember = "Code";
            comboBoxColumn2.DisplayMember = "values";
            comboBoxColumn2.HeaderText = "MKT Budget";
            comboBoxColumn2.Name = "MKTBudget";
            comboBoxColumn2.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            comboBoxColumn2.Width = 150;
            dataGridViewSelectList.Columns.Add(comboBoxColumn2);

            dtmb = Entity.Userinfo.MoConfig.Select("[key]='GiftVoucher'").CopyToDataTable();
            GiftVoucher.Add("");

            foreach (DataRow item in dtmb.Rows)
            {
                GiftVoucher.Add(item["values"] + "");
                dicGiftVoucher.Add(item["values"] + "", item["Code"] + "");
            }

            comboBoxColumn2 = new DataGridViewComboBoxColumn();

            comboBoxColumn2.DataSource = dtmb;
            comboBoxColumn2.ValueMember = "Code";
            comboBoxColumn2.DisplayMember = "values";
            comboBoxColumn2.HeaderText = "GiftVoucher";
            comboBoxColumn2.Name = "GiftVoucher";
            comboBoxColumn2.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            comboBoxColumn2.Width = 150;
            dataGridViewSelectList.Columns.Add(comboBoxColumn2);

            dataGridViewSelectList.Columns.Add("GiftNumber", "GiftNumber");
            dataGridViewSelectList.Columns["GiftNumber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["GiftNumber"].DefaultCellStyle.BackColor = Color.LemonChiffon;
            dataGridViewSelectList.Columns["GiftNumber"].Visible = true;
            dataGridViewSelectList.Columns["GiftNumber"].Width = 100;

            DataGridViewCheckBoxColumn ChkBeforeAfter = new DataGridViewCheckBoxColumn();
            {
                ChkBeforeAfter.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                ChkBeforeAfter.FlatStyle = FlatStyle.Standard;
                ChkBeforeAfter.ThreeState = false;
                ChkBeforeAfter.Name = "ChkBeforeAfter";
                ChkBeforeAfter.HeaderText = "Before After";
                ChkBeforeAfter.CellTemplate = new DataGridViewCheckBoxCell();
            }
            dataGridViewSelectList.Columns.Add(ChkBeforeAfter);

            DataGridViewCheckBoxColumn ChkExtras_sale = new DataGridViewCheckBoxColumn();
            {
                ChkExtras_sale.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.DisplayedCells;
                ChkExtras_sale.FlatStyle = FlatStyle.Standard;
                ChkExtras_sale.ThreeState = false;
                ChkExtras_sale.Name = "ChkExtras_sale";
                ChkExtras_sale.HeaderText = "ของแถม(ขาย)";
                ChkExtras_sale.CellTemplate = new DataGridViewCheckBoxCell();
            }
            dataGridViewSelectList.Columns.Add(ChkExtras_sale);

            DataGridViewCheckBoxColumn ChkVIP = new DataGridViewCheckBoxColumn();
            {
                ChkVIP.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                ChkVIP.FlatStyle = FlatStyle.Standard;
                ChkVIP.ThreeState = false;
                ChkVIP.Name = "ChkVIP";
                ChkVIP.HeaderText = "VIP(ฝ่ายบริหาร)";
                ChkVIP.CellTemplate = new DataGridViewCheckBoxCell();
            }
            dataGridViewSelectList.Columns.Add(ChkVIP);
            DataGridViewCheckBoxColumn ChkPRO = new DataGridViewCheckBoxColumn();
            {
                ChkPRO.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                ChkPRO.FlatStyle = FlatStyle.Standard;
                ChkPRO.ThreeState = false;
                ChkPRO.Name = "ChkPRO";
                ChkPRO.HeaderText = "Add_Dis";
                ChkPRO.CellTemplate = new DataGridViewCheckBoxCell();
                ChkPRO.Visible = (Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN) ? true : false;
            }
            dataGridViewSelectList.Columns.Add(ChkPRO);

            dataGridViewSelectList.Columns.Add("Tab", "Tab");
            dataGridViewSelectList.Columns.Add("FeeRate", "FeeRate");
            dataGridViewSelectList.Columns.Add("FeeRate2", "FeeRate2");
            dataGridViewSelectList.Columns["FeeRate"].Visible = false;
            dataGridViewSelectList.Columns["FeeRate2"].Visible = false;

            dataGridViewSelectList.Columns.Add("Note", "Note");//4 Amount
            dataGridViewSelectList.Columns["Note"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewSelectList.Columns["Note"].DefaultCellStyle.BackColor = Color.LemonChiffon;
            dataGridViewSelectList.Columns["Note"].Width = 250;
            dataGridViewSelectList.Columns["Tab"].Width = 10;

            DataGridViewImageColumn ColMember = new DataGridViewImageColumn();
            {
                ColMember.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                ColMember.CellTemplate = new DataGridViewImageCell();
                ColMember.Name = "BtnMember";
                ColMember.HeaderText = "Members";
            }
            dataGridViewSelectList.Columns.Add(ColMember);

            dataGridViewSelectList.Columns.Add("ListOrder", "ListOrder");
            dataGridViewSelectList.Columns["ListOrder"].Width = 50;


            DataGridViewCheckBoxColumn chkSaleCom = new DataGridViewCheckBoxColumn();
            {
                chkSaleCom.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                chkSaleCom.FlatStyle = FlatStyle.Standard;
                chkSaleCom.ThreeState = false;
                chkSaleCom.Name = "chkSaleCom";
                chkSaleCom.HeaderText = "SaleCom";
                chkSaleCom.CellTemplate = new DataGridViewCheckBoxCell();
            }
            dataGridViewSelectList.Columns.Add(chkSaleCom);

            DataGridViewCheckBoxColumn chkBydr = new DataGridViewCheckBoxColumn();
            {
                chkBydr.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                chkBydr.FlatStyle = FlatStyle.Standard;
                chkBydr.ThreeState = false;
                chkBydr.Name = "chkBydr";
                chkBydr.HeaderText = "ByDr.";
                chkBydr.CellTemplate = new DataGridViewCheckBoxCell();
            }
            dataGridViewSelectList.Columns.Add(chkBydr);

            DataGridViewCheckBoxColumn chkCanceled = new DataGridViewCheckBoxColumn();
            {
                chkCanceled.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                chkCanceled.FlatStyle = FlatStyle.Standard;
                chkCanceled.ThreeState = false;
                chkCanceled.Name = "chkCanceled";
                chkCanceled.HeaderText = "Canceled";
                chkCanceled.CellTemplate = new DataGridViewCheckBoxCell();
            }
            dataGridViewSelectList.Columns.Add(chkCanceled);

            dtmb = Entity.Userinfo.MoConfig.Select("[key]='Free'").CopyToDataTable();
            comboBoxColumn2 = new DataGridViewComboBoxColumn();

            comboBoxColumn2.DataSource = dtmb;
            comboBoxColumn2.ValueMember = "Code";
            comboBoxColumn2.DisplayMember = "values";
            comboBoxColumn2.HeaderText = "Free";
            comboBoxColumn2.Name = "Free";
            comboBoxColumn2.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            //comboBoxColumn2.Width = 200;
            dataGridViewSelectList.Columns.Add(comboBoxColumn2);

            dataGridViewSelectList.Columns["Free"].Width = 100;


            dataGridViewSelectList.Columns["ChkVIP"].Visible = false;
            dataGridViewSelectList.Columns["ChkCom"].Visible = false;
            dataGridViewSelectList.Columns["ChkSub"].Visible = false;
            dataGridViewSelectList.Columns["MKTBudget"].Visible = false;
            dataGridViewSelectList.Columns["GiftVoucher"].Visible = false;
            dataGridViewSelectList.Columns["ChkBeforeAfter"].Visible = false;
            dataGridViewSelectList.Columns["ChkExtras_sale"].Visible = false;
            //dataGridViewSelectList.Columns["Other"].Visible = false;

            dataGridViewSelectList.Columns["Tab"].Visible = false;
            dataGridViewSelectList.Columns.Add("AmountPro", "จำนวนในโปร");
            dataGridViewSelectList.Columns.Add("PricePerPro", "ราคาต่อหน่วยโปร");
            dataGridViewSelectList.Columns.Add("SurgicalFeeNewTab", "Com.");
            dataGridViewSelectList.Columns.Add("COUPON_Pro", "COUPON_Pro");
            dataGridViewSelectList.Columns.Add("SOnoSub", "SOnoSub");
            dataGridViewSelectList.Columns.Add("VNSub", "VNSub");

            dataGridViewSelectList.Columns.Add("Room_Amount_Day", "Room_Amount_Day");
            dataGridViewSelectList.Columns["Room_Amount_Day"].Visible = false;
        }
        private void SetColumnDgvSelectListPro()
        {
            //Utility.SetPropertyDgv(dgvHairSelect);
            dataGridViewSelectListPro.AllowUserToAddRows = false;
            dataGridViewSelectListPro.DefaultCellStyle.BackColor = Color.DarkGray;
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            {
                column.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                column.FlatStyle = FlatStyle.Standard;
                column.ThreeState = false;
                column.Name = "ChkMove";
                column.HeaderText = "";
                column.CellTemplate = new DataGridViewCheckBoxCell();
                column.CellTemplate.Style.BackColor = Color.LemonChiffon;
            }


            dataGridViewSelectListPro.Columns.Add(column); //0
            dataGridViewSelectListPro.Columns.Add("Code", "Code");//1
            dataGridViewSelectListPro.Columns["Code"].ReadOnly = true;

            dataGridViewSelectListPro.Columns.Add("Name", "Name");//2
            dataGridViewSelectListPro.Columns["Name"].ReadOnly = true;



            dataGridViewSelectListPro.Columns.Add("Amount", "Quantity");//4 Amount
            dataGridViewSelectListPro.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectListPro.Columns["Amount"].DefaultCellStyle.BackColor = Color.LemonChiffon;
            dataGridViewSelectListPro.Columns["Amount"].Width = 30;



            dataGridViewSelectListPro.Columns.Add("Price/Unit", "Price/Unit");//9
            dataGridViewSelectListPro.Columns["Price/Unit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectListPro.Columns["Price/Unit"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewSelectListPro.Columns["Price/Unit"].ReadOnly = true;


            dataGridViewSelectListPro.Columns.Add("Note", "Note");
            dataGridViewSelectListPro.Columns["Note"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectListPro.Columns["Note"].DefaultCellStyle.BackColor = Color.LemonChiffon;
            dataGridViewSelectListPro.Columns["Note"].Width = 200;



            dataGridViewSelectListPro.Columns.Add("ListOrder", "ListOrder");
            dataGridViewSelectListPro.Columns.Add("ListMS_Code", "ListMS_Code");

        }
        private void BindRoomList()
        {
            try
            {
                DerUtility.MouseOn(this);

                gvRoom.Rows.Clear();
                using (var context = new EntitiesOPD_System())
                {
                    var tempRoom = context.Master_Room.Where(x => x.Is_Active == true).ToList();

                    if (tempRoom.Count > 0)
                    {
                        //gvRoom.DataSource = tempRoom;
                        foreach (var item in tempRoom)
                        {
                            object[] myItems = {
                                           false,
                                           item.Room_Code ?? "",
                                           item.Room_Name ?? "",
                                           item.Amount_Day == null ? "0" : Convert.ToInt32(item.Amount_Day).ToString(),
                                           item.Room_PriceCredit == null ? "0" : Convert.ToDouble(item.Room_PriceCredit).ToString("###,###,###.##"),
                                           item.Room_Price == null ? "0" : Convert.ToDouble(item.Room_Price).ToString("###,###,###.##"),
                                           item.Remark ?? ""
                                       };
                            gvRoom.Rows.Add(myItems);
                        }
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
        private void BindPromotionList()
        {
            try
            {
                DerUtility.MouseOn(this);

                dgvPromotionList.Rows.Clear();
                Entity.MedicalSupplies info = new Entity.MedicalSupplies();
                if (!string.IsNullOrEmpty(txtFindPro.Text))
                {
                    // info.MS_Name = "%" + txtFindHair.Text + "%";
                    info.Tabwhere = "PRO_Code Like '%" + txtFindPro.Text + "%'" + " or PRO_Name Like '%" + txtFindPro.Text + "%'";
                }
                else
                {
                    info.Tabwhere = "1=1";
                }
                //info.MS_Section = "ODH"; //Hair
                info.Tab = "PROMOTION";
                dtPromotion = new Business.MedicalSupplies().SelectMedicalSuppliesBySection(info).Tables[0];

                foreach (DataRowView item in dtPromotion.DefaultView)
                {
                    object[] myItems = {
                                           false,
                                           item["PRO_Code"] + "",
                                           item["PRO_Name"] + "",
                                          (item["ProPrice"] + ""=="")?"0":(Convert.ToDouble(item["ProPrice"]).ToString("###,###,###.##")),
                                           item["DateStart"] + "",
                                          item["DateEnd"] + "",
                                          item["PRO_Active"] + "",
                                          item["Remark"] + "",
                                           info.Tab,
                                          item["PRO_Type"] + "",
                                          item["ProPriceCredit"] + "",
                                          item["ProductGroup"] + "",
                                          item["PRO_Dept"] + "",
                                           "Y"
                                       };
                    dgvPromotionList.Rows.Add(myItems);

                }

                DerUtility.MouseOff(this);
                //menuDel.Enabled = dgvData.RowCount != 1;
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
        }
        //private bool IsExpired(string start,string end)
        //{
        //    bool Expire = false;
        //    try
        //    {
        //        DateTime dtStart=DateTime.Now;
        //        DateTime dtEnd=DateTime.Now;
        //        dtStart=Convert.ToDateTime(start);
        //        dtEnd=Convert.ToDateTime(end);
        //        if(DateTime.Now >=dtStart && DateTime.Now <=dtEnd)
        //            Expire=false;
        //        else  Expire=true;
        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show(ex.Message);
        //        Expire=false;
        //    }
        //    return Expire;
        //}
        public bool IsExpired(string specificDate)
        {
            bool flag = false;
            DateTime currentDate = DateTime.Now.Date;

            DateTime target;

            if (DateTime.TryParse(specificDate, out target))
            {
                flag = target < currentDate;
            }

            return flag;
        }
        public bool IsActive(string specific)
        {
            return specific.ToUpper() == "Y";
        }
        private void BindCboBranch()
        {
            try
            {
                DataTable dtBranch = new Business.Branch().SelectBranchAll().Tables[0];
                var dr3 = dtBranch.NewRow();
                dr3["BranchID"] = "";
                dr3["BranchName"] = Statics.StrValidate;
                dtBranch.Rows.InsertAt(dr3, 0);
                cboBranch.DataSource = dtBranch;
                cboBranch.ValueMember = "BranchID";
                cboBranch.DisplayMember = "BranchName";
                cboBranch.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation,
                               "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }
        }
        private void BindDataAesList(bool buffet)
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
                if (buffet) info.Tabwhere += " and Msup.MS_Name Like '%buffet%'";
                //info.MS_Section = "ADI";
                info.Tab = "AESTHETIC";
                dtAESTHETIC = new Business.MedicalSupplies().SelectMedicalSuppliesBySection(info).Tables[0];


                foreach (DataRowView item in dtAESTHETIC.DefaultView)
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
                                          item["SurgicalFeeNewTab"] + ""

                                       };
                    dgvAestheticList.Rows.Add(myItems);
                    //if (item["Active"] + "".ToUpper() != "Y")
                    //{
                    //    dgvAestheticList.Rows[dgvAestheticList.Rows.Count - 1].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
                    //}
                }

                //foreach (DataGridViewRow row in dgvAestheticList.Rows)
                //{
                //    if (row.Cells["Active"] + "".ToUpper() != "Y")
                //    {
                //        row.DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
                //    }
                //}
                DerUtility.MouseOff(this);
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
        }
        private void BindDataSurgeryList()
        {
            try
            {
                DerUtility.MouseOn(this);
                dgvSurgeryList.Rows.Clear();
                Entity.MedicalSupplies info = new Entity.MedicalSupplies();
                if (!string.IsNullOrEmpty(txtFindSurgery.Text))
                {
                    //info.MS_Name = "%" + txtFindSurgery.Text + "%";
                    info.Tabwhere = "Msup.MS_Code Like '%" + txtFindSurgery.Text + "%'" + " or Msup.MS_Name Like '%" + txtFindSurgery.Text + "%'";
                }
                else
                {
                    info.Tabwhere = "1=1";
                }
                //info.MS_Section = "ODF";
                info.Tab = "SURGERY";
                dtSURGERY = new Business.MedicalSupplies().SelectMedicalSuppliesBySection(info).Tables[0];

                foreach (DataRowView item in dtSURGERY.DefaultView)
                {
                    object[] myItems = {
                                          false,
                                          item["MS_Section"] + "",
                                           item["MS_Code"] + "",
                                           item["MS_Name"] + "",
                                          (item["MS_CLPrice"] + ""=="")?"0":(Convert.ToDouble(item["MS_CLPrice"]).ToString("###,###,###.##")),
                                          (item["MS_CAPrice"] + ""=="")?"0":(Convert.ToDouble(item["MS_CAPrice"]).ToString("###,###,###.##")),
                                          item["MS_Type"] + "",
                                          (item["MS_Number_C"] + "" =="")?"0":(item["MS_Number_C"] + "")
                                            , item["UnitName"] + ""

                                          ,item["FeeRate"] + ""
                                          ,item["FeeRate2"] + ""
                                            ,info.Tab
                                          ,item["MS_Detail"] + ""
                                          ,item["Active"] + ""
                                       };
                    dgvSurgeryList.Rows.Add(myItems);
                    //if (item["Active"] + "".ToUpper() != "Y")
                    //{
                    //    dgvSurgeryList.Rows[dgvSurgeryList.Rows.Count - 1].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
                    //}
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
        private void BindDataWellness_antiAgentList(bool buffet)
        {
            try
            {
                DerUtility.MouseOn(this);
                dgvWellness_AntiagingList.Rows.Clear();
                Entity.MedicalSupplies info = new Entity.MedicalSupplies();
                if (!string.IsNullOrEmpty(txtWellness_Antiaging.Text))
                {
                    //info.MS_Name = "%" + txtFindSurgery.Text + "%";
                    info.Tabwhere = "Msup.MS_Code Like '%" + txtWellness_Antiaging.Text + "%'" + " or Msup.MS_Name Like '%" + txtWellness_Antiaging.Text + "%'";
                }
                else
                {
                    info.Tabwhere = "1=1";
                }
                if (buffet) info.Tabwhere += " and Msup.MS_Name Like '%buffet%'";
                //info.MS_Section = "ODF";
                info.Tab = "WELLNESS";
                dtWELLNESS = new Business.MedicalSupplies().SelectMedicalSuppliesBySection(info).Tables[0];

                foreach (DataRowView item in dtWELLNESS.DefaultView)
                {
                    object[] myItems = {
                                          false,
                                          item["MS_Section"] + "",
                                           item["MS_Code"] + "",
                                           item["MS_Name"] + "",
                                       (item["MS_CLPrice"] + ""=="")?"0":(Convert.ToDouble(item["MS_CLPrice"]).ToString("###,###,###.##")),
                                          (item["MS_CAPrice"] + ""=="")?"0":(Convert.ToDouble(item["MS_CAPrice"]).ToString("###,###,###.##")),
                                          item["MS_Type"] + "",
                                          (item["MS_Number_C"] + "" =="")?"0":(item["MS_Number_C"] + "")
                                           , item["UnitName"] + ""
                                          ,info.Tab
                                          ,item["FeeRate"] + ""
                                          ,item["FeeRate2"] + ""
                                          ,item["MS_Detail"] + ""
                                          ,item["Active"] + ""
                                         ,item["SurgicalFeeNewTab"] + ""
                                       };
                    dgvWellness_AntiagingList.Rows.Add(myItems);
                    //if (item["Active"] + "".ToUpper() != "Y")
                    //{
                    //    dgvWellness_AntiagingList.Rows[dgvWellness_AntiagingList.Rows.Count - 1].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
                    //}
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
        private void BindDataPharmacyList()
        {
            try
            {
                DerUtility.MouseOn(this);
                dgvPharmacyList.Rows.Clear();
                Entity.MedicalSupplies info = new Entity.MedicalSupplies();
                if (!string.IsNullOrEmpty(txtFindPharmacy.Text))
                {
                    //info.MS_Name = "%" + txtFindPharmacy.Text + "%";
                    info.Tabwhere = "Msup.MS_Code Like '%" + txtFindPharmacy.Text + "%'" + " or Msup.MS_Name Like '%" + txtFindPharmacy.Text + "%'";
                }
                else
                {
                    info.Tabwhere = "1=1";
                }
                //info.MS_Section = "PMC";
                
                info.Tab = "PHARMACY";
                
                dtPHARMACY = new Business.MedicalSupplies().SelectMedicalSuppliesBySection(info).Tables[0];

                foreach (DataRowView item in dtPHARMACY.DefaultView)
                {
                    object[] myItems = {
                                          false,
                                           item["MS_Section"] + "",
                                           item["MS_Code"] + "",
                                           item["MS_Name"] + "",
                                           (item["MS_CLPrice"] + ""=="")?"0":(Convert.ToDouble(item["MS_CLPrice"]).ToString("###,###,###.##")),
                                          (item["MS_CAPrice"] + ""=="")?"0":(Convert.ToDouble(item["MS_CAPrice"]).ToString("###,###,###.##")),
                                          item["MS_Type"] + "",
                                          (item["MS_Number_C"] + "" =="")?"0":(item["MS_Number_C"] + "")
                                          ,item["UnitName"] + ""
                                          ,info.Tab
                                          ,""
                                          ,""
                                          ,""
                                          ,item["Active"] + ""
                                          ,item["SurgicalFeeNewTab"] + ""

                                       };
                    dgvPharmacyList.Rows.Add(myItems);
                    //if (item["Active"] + "".ToUpper() != "Y")
                    //{
                    //    dgvPharmacyList.Rows[dgvPharmacyList.Rows.Count - 1].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
                    //}
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



        private void dgvHairList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        private void buttonRigth6_BtnClick()
        {
            if (string.IsNullOrEmpty(customerType))
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "กรุณาเลือก \"ลูกค้า\" ก่อน \"Please Select Customer\"");
                return;
            }
            //foreach (DataGridViewRow item in dgvHairList.Rows)
            //{
            //    if ((bool) item.Cells[0].Value == true)
            //    {
            //        object[] myItems = {
            //                                false,
            //                               item.Cells[1].Value,
            //                               item.Cells[2].Value,
            //                               "1",
            //                               item.Cells[7].Value,
            //                               item.Cells[7].Value,
            //                               "0",
            //                               item.Cells[7].Value+"",
            //                               customerType == "CNT"||customerType == "CNM" ?double.Parse( item.Cells["MS_CLPrice"].Value+"").ToString("###,###.##") :double.Parse( item.Cells["MS_CAPrice"].Value+"").ToString("###,###.##"),
            //                               customerType == "CNT"||customerType == "CNM" ? double.Parse( item.Cells["MS_CLPrice"].Value+"").ToString("###,###.##") :double.Parse( item.Cells["MS_CAPrice"].Value+"").ToString("###,###.##"),
            //                               //imageList1.Images[0],
            //                               //false,
            //                               imageList1.Images[4],"",false,false,false,false,
            //                               "HAIR"
            //                           };

            //        item.Cells[0].Value = false;

            //        dataGridViewSelectList.Rows.Add(myItems);

            //        SumPriceMedicalOrder();
            //    }
            //}

        }

        private void dataGridViewSelectList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                currentRowIndex = dataGridViewSelectList.CurrentCell.RowIndex;
                currentColIndex = dataGridViewSelectList.CurrentCell.ColumnIndex;
                if (dataGridViewSelectList.CurrentCell.ColumnIndex == dataGridViewSelectList.Columns["Amount"].Index || dataGridViewSelectList.CurrentCell.ColumnIndex == dataGridViewSelectList.Columns["Other"].Index)
                {
                    string[] AmountaArr = (dataGridViewSelectList.CurrentCell.Value + "").Split(':');
                    if (AmountaArr.Length > 1)
                    {
                        dataGridViewSelectList.EndEdit();
                        return;
                    }
                    TextBox itemID = e.Control as TextBox;
                    if (itemID != null)
                    {
                        itemID.KeyPress += new KeyPressEventHandler(itemID_KeyPress);
                    }
                }
            }
            catch (Exception ex)
            {

            }


        }

        private void itemID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                if (e.KeyChar != '-')
                    e.Handled = true;
            }
        }
        int rowHide = 0;
        List<int> lsRowHide = new List<int>();
        private void setRowNumber(DataGridView dataGridViewSelectList)
        {
            int rownum = 0;
            foreach (DataGridViewRow row in dataGridViewSelectList.Rows)
            {
                if (row.Visible)
                {
                    rownum++;
                    row.HeaderCell.Value = rownum;
                }
                else
                {
                    if (!lsRowHide.Contains(row.Index)) lsRowHide.Add(row.Index);
                }
            }
            dataGridViewSelectList.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

        }
        int hiderowCount = 0;
        private void dataGridViewSelectList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                int rownumLast = 0;
                //if (dataGridViewSelectList.Rows[e.RowIndex].Visible)
                //{
                if (lsRowHide.Any() && lsRowHide[0] < e.RowIndex)
                    rownumLast = e.RowIndex;
                else rownumLast = e.RowIndex + 1;
                var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
                e.Graphics.DrawString(Convert.ToString(rownumLast - hiderowCount), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                      e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);



                DataGridViewCheckBoxCell chkCom = dataGridViewSelectList.Rows[e.RowIndex].Cells["chkCanceled"] as DataGridViewCheckBoxCell;

                if (Convert.ToBoolean(chkCom.Value))
                    dataGridViewSelectList.Rows[e.RowIndex].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
                //else
                //    dataGridViewSelectList.Rows[e.RowIndex].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Regular);

            }
            catch (Exception ex)
            {

            }

        }

        private void buttonLeft6_BtnClick()
        {
            List<Entity.SupplieTrans> listSup = new List<Entity.SupplieTrans>();
            List<DataGridViewRow> rowsToDelete = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in dataGridViewSelectList.Rows)
            {
                DataGridViewCheckBoxCell chk = row.Cells[0] as DataGridViewCheckBoxCell;
                if (Convert.ToBoolean(chk.Value) == true)
                {
                    rowsToDelete.Add(row);

                    if (!string.IsNullOrEmpty(vn))
                    {
                        Entity.SupplieTrans supplieInfo = new Entity.SupplieTrans();
                        supplieInfo.VN = vn;
                        supplieInfo.MS_Code = row.Cells["Code"].Value + "";
                        listSup.Add(supplieInfo);
                    }
                }
            }

            int? statusDel = new Business.MedicalSupplies().DeleteSupplies(listSup.ToArray());

            //if (statusDel == 1)
            //{
            foreach (DataGridViewRow row in rowsToDelete)
                dataGridViewSelectList.Rows.Remove(row);

            SumPriceMedicalOrder();
            //}
        }


        private void dgvAestheticList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        private void dgvTreatmentList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        private void dgvSurgeryList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        private void dgvPharmacyList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        private void dgvAestheticList_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
            {
                ch1.Value = false;
                MessageBox.Show("No Active", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void dgvSurgeryList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSurgeryList.Rows.Count < 0 || dgvSurgeryList.CurrentRow == null) return;
            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
            ch1 = (DataGridViewCheckBoxCell)dgvSurgeryList.Rows[dgvSurgeryList.CurrentRow.Index].Cells[0];
            if (dgvSurgeryList.CurrentCell.ColumnIndex != 0) return;
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
            if (!IsActive(dgvSurgeryList.Rows[dgvSurgeryList.CurrentRow.Index].Cells["Active"].Value + ""))
            {
                ch1.Value = false;
                MessageBox.Show("No Active", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvPharmacyList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPharmacyList.Rows.Count < 0 || dgvPharmacyList.CurrentRow == null) return;
            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
            ch1 = (DataGridViewCheckBoxCell)dgvPharmacyList.Rows[dgvPharmacyList.CurrentRow.Index].Cells[0];
            if (dgvPharmacyList.CurrentCell.ColumnIndex != 0) return;
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
            if (!IsActive(dgvPharmacyList.Rows[dgvPharmacyList.CurrentRow.Index].Cells["Active"].Value + ""))
            {
                ch1.Value = false;
                MessageBox.Show("No Active", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridViewSelectList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    List<Entity.SupplieTrans> listSup = new List<Entity.SupplieTrans>();

            //    Entity.SupplieTrans supplieInfo = new Entity.SupplieTrans();
            //    supplieInfo = new Entity.SupplieTrans();
            //    supplieInfo.VN = txtMO.Text;
            //    supplieInfo.SONo = txtSONo.Text;
            //    supplieInfo.MS_Code = dataGridViewSelectList.Rows[e.RowIndex].Cells["Code"].Value + "";
            //    supplieInfo.ListOrder = dataGridViewSelectList.Rows[e.RowIndex].Cells["ListOrder"].Value + "";

            //    listSup.Add(supplieInfo);

            //    foreach (Entity.SupplieTrans item in listSup)
            //    {

            //        DataSet dsSurgeryFee = new Business.MedicalOrderUseTrans().SELECTSAVEDJOBCOST_COM(item.VN, item.SONo, item.MS_Code, item.ListOrder);
            //        if (dsSurgeryFee.Tables.Count > 0 && dsSurgeryFee.Tables[0].Rows.Count > 0 && !(Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN) && !Userinfo.IS_ADMIN_JOBCOST.Contains(Userinfo.EN))
            //        {

            //            dataGridViewSelectList.Rows[e.RowIndex].ReadOnly = true;
            //            //dataGridViewSelectList.Rows[e.RowIndex].Cells["chkCanceled"].ReadOnly = true;
            //            //DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
            //            //ch1 = (DataGridViewCheckBoxCell)dataGridViewSelectList.Rows[e.RowIndex].Cells[e.ColumnIndex];
            //            //if (ch1.Value == null)
            //            //    return;
            //            //else
            //            //{
            //            //    ch1.Value = ch0.Value;

            //            //}
            //            dataGridViewSelectList.CommitEdit(DataGridViewDataErrorContexts.CurrentCellChange);
            //            dataGridViewSelectList.EndEdit();


            //            //DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, "ไม่สามารถแก้ไขข้อมูลได้เนื่องจาก ได้บันทึกค่ามือและค่าแพทย์ไปแล้ว" + Environment.NewLine + "กรุณาติดต่อผู้ดูแลระบบ");
            //            return;
            //        }
            //    }


            //    if (e.ColumnIndex == dataGridViewSelectList.Columns["BtnMember"].Index)
            //    {
            //        popMemberGroup frm = popMemberGroup.GetInstance();
            //        frm.CN = CN;
            //        frm.VN = VN;
            //        frm.dicMemberTran = dicMemberTran;
            //        frm.MS_Code = MS_Code = dataGridViewSelectList.Rows[e.RowIndex].Cells["Code"].Value + "";
            //        frm.ShowDialog();
            //        Thread.Sleep(100);

            //        if (frm.DialogResult == DialogResult.OK)
            //        {
            //            if (!dicMemberTran.ContainsKey(MS_Code))
            //                dicMemberTran.Add(MS_Code, frm.member);
            //            else
            //            {
            //                dicMemberTran[MS_Code] = frm.member;
            //            }
            //        }

            //    }


            //    if (e.ColumnIndex == dataGridViewSelectList.Columns["ChkPRO"].Index)
            //    {

            //        DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
            //        ch1 = (DataGridViewCheckBoxCell)dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells["ChkPRO"];
            //        if (ch1.Value == null)
            //            return;
            //        else
            //        {
            //            if ((ch1.Value + "").ToLower() == "true")
            //                ch1.Value = "false";
            //            else
            //                ch1.Value = "true";



            //        }
            //        if (e.ColumnIndex == dataGridViewSelectList.Columns["SpecialPrice"].Index || e.ColumnIndex == dataGridViewSelectList.Columns["SpecialPrice"].Index || e.ColumnIndex == dataGridViewSelectList.Columns["ChkPRO"].Index)
            //            ISEndEdit = false;

            //        SumPriceMedicalOrder();

            //    }

            //    if (e.ColumnIndex == dataGridViewSelectList.Columns["chkCanceled"].Index)
            //    {
            //        DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
            //        ch1 = (DataGridViewCheckBoxCell)dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells["chkCanceled"];
            //        if (ch1.Value == null)
            //            return;
            //        else
            //        {
            //            if ((ch1.Value + "").ToLower() == "true")
            //                ch1.Value = "false";
            //            else
            //            {
            //                ch1.Value = "true";




            //                double dblTotalAmount = double.Parse(dataGridViewSelectList.Rows[currentRowIndex].Cells["Amount"].Value + "");// * (dataGridViewSelectList.Rows[currentRowIndex].Cells["No./Course"].Value + "" == "" ? 1 : double.Parse(dataGridViewSelectList.Rows[currentRowIndex].Cells["No./Course"].Value + "")));
            //                double pricePer = dataGridViewSelectList.Rows[currentRowIndex].Cells["Price/Unit"].Value + "" == "" ? 0 : double.Parse(dataGridViewSelectList.Rows[currentRowIndex].Cells["Price/Unit"].Value + "");
            //                //double SpecialPriceOld = dataGridViewSelectList.Rows[currentRowIndex].Cells["SpecialPrice"].Value + "" == "" ? 0 : double.Parse(dataGridViewSelectList.Rows[currentRowIndex].Cells["SpecialPrice"].Value + "");

            //                dblTotalAmount = dblTotalAmount * pricePer;

            //                dataGridViewSelectList.Rows[currentRowIndex].Cells["SpecialPrice"].Value = dblTotalAmount * -1;
            //                dataGridViewSelectList.CommitEdit(DataGridViewDataErrorContexts.Commit);
            //                dataGridViewSelectList.EndEdit();
            //            }
            //        }
            //    }

            //}
            //catch (Exception ex)
            //{

            //}
        }
        List<string> lsMS_Code = new List<string>();
        Dictionary<string, double> dicAmount = new Dictionary<string, double>();
        Dictionary<string, double> dicSpecialPrice = new Dictionary<string, double>();
        private void buttonAddDown_BtnClick()
        {
            try
            {

                COUPON_Price = 0;
                COUPON_Note = "";

                strMS_Code = "";
                //lbPromotion.Text = "";
                dblAmount = 1;
                dataGridViewSelectList.Columns["Amount"].ReadOnly = false;
                if (string.IsNullOrEmpty(customerType))
                {
                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "กรุณาเลือก \"ลูกค้า\" ก่อน \"Please Select Customer\"");
                    return;
                }
                DataGridView dv = new DataGridView();
                switch (tabPageActive)
                {
                    case TabPageActive.tabAesthetic:
                        dv = dgvAestheticList;
                        tabTyp = "AESTHETIC";
                        MoSubType = "AE";
                        break;

                    case TabPageActive.tabSurgery:
                        dv = dgvSurgeryList;
                        tabTyp = "SURGERY";
                        MoSubType = "SU";
                        break;

                    case TabPageActive.tabWellness_Antiaging:
                        dv = dgvWellness_AntiagingList;
                        tabTyp = "WELLNESS";
                        MoSubType = "WE";
                        break;
                    case TabPageActive.tabPharmacy:
                        dv = dgvPharmacyList;
                        tabTyp = "PHARMACY";
                        MoSubType = tabTypShortName;
                        break;
                    case TabPageActive.tabPromotion:
                        dv = dgvPromotionList;
                        tabTyp = "PROMOTION";
                        MoSubType = "PRO";
                        dataGridViewSelectList.Columns["SpecialPrice"].HeaderText = "Discount";

                        break;
                    case TabPageActive.tabRoom:
                        dv = gvRoom;
                        tabTyp = "ROOM";
                        MoSubType = "ROOM";
                        //dataGridViewSelectList.Columns["SpecialPrice"].HeaderText = "Discount";

                        break;
                    case TabPageActive.tabAttachFile:
                        //tabPageActive = TabPageActive.tabAesthetic;
                        break;
                }
                //if (dataGridViewSelectList.RowCount > 0 && tabTypShortName!="" && MoSubType != tabTypShortName) return;

                bool ISGIFT = false;
                //===========================================================
                if (MoSubType == "PRO" && tabTyp != "PHARMACY")//โปรธรรมดา
                {
                    Entity.Promotion info = new Entity.Promotion();
                    info.QueryType = "SEARCHBYID";
                    DataTable dtPro = new DataTable();
                    foreach (DataGridViewColumn column in dv.Columns)
                        dtPro.Columns.Add(column.Name, typeof(String)); //better to have cell type

                    foreach (DataGridViewRow item in dv.Rows)
                    {
                        if ((bool)item.Cells[0].Value == true && tabTyp != "PHARMACY")
                        {

                            info.PRO_Code = item.Cells["PRO_Code"].Value + "";
                            info.PRO_Name = item.Cells["PRO_Name"].Value + "";
                            PRO_Code = item.Cells["PRO_Code"].Value + "";
                            ProCreditMoney = (Convert.ToDecimal(item.Cells["ProPriceCredit"].Value) == 0 ? item.Cells["ProPrice"].Value : item.Cells["ProPriceCredit"].Value) + "" == "" ? 0 : decimal.Parse((Convert.ToDecimal(item.Cells["ProPriceCredit"].Value) == 0 ? item.Cells["ProPrice"].Value : item.Cells["ProPriceCredit"].Value) + "");
                            ProPricePay = item.Cells["ProPrice"].Value + "" == "" ? 0 : decimal.Parse(item.Cells["ProPrice"].Value + "");
                            info.ProPrice = ProPricePay;
                            CalcPercen();
                            //lbPromotion.Text = string.Format("Promotion:{0}:{1}", PRO_Code, item.Cells["PRO_Name"].Value + "");
                            lbProCredit.Text = string.Format("Balances/Credit ({0}/{1}) บาท/Bth.", (ProCreditRemain) == 0 ? "0" : (ProCreditRemain).ToString("###,###,###.##"), ProCreditMoney.ToString("###,###,###.##"));
                            lbProCredit.Visible = item.Cells["PRO_Type"].Value + "" == "CREDIT";
                            PROCredit = item.Cells["PRO_Type"].Value + "" == "CREDIT" ? "Y" : "";

                            if (item.Cells["PRO_Dept"].Value + "" == "GIFT")
                            {
                                if (!dtPro.Columns.Contains("MS_Code"))
                                    dtPro.Columns.Add("MS_Code", typeof(String));
                                //for (int i = 0; i < dv.SelectedRows.Count; i++)
                                //{
                                //if ((bool)item.Cells[0].Value == true && tabTyp != "PHARMACY")
                                //{
                                dtPro.Rows.Add();
                                for (int j = 0; j < dv.Columns.Count; j++)
                                {
                                    if (j == 0)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        dtPro.Rows[dtPro.Rows.Count - 1][j] = item.Cells[j].Value;
                                        dtPro.Rows[dtPro.Rows.Count - 1]["MS_Code"] = "PRO_CREDIT";
                                    }
                                    //^^^^^^^^^^^
                                }
                                ISGIFT = true;
                                //}
                                //}
                            }

                        }
                    }

                    DataTable dt = new Business.Promotion().SelectPromotionPaging(info).Tables[0];// ไปดึงรหัส สินค้ที่เป็นของโปรนั้นจาก PromotionSupplie เพื่อที่จะ add ลงกริด
                    if (dt == null || dt.Rows.Count <= 0)
                        return;
                    if (ISGIFT == false)
                    {
                        dtPro = dt.Copy();
                    }



                    //dataGridViewSelectList.Rows.Clear();
                    lsMS_Code = new List<string>();


                    if (PROCredit == "Y" && dataGridViewSelectListPro.RowCount > 0)
                    {
                        lbProCredit.Visible = false;
                        MessageBox.Show("Cannot select multiple for Member Promotion & Normal Promotion", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;

                    }
                    else if (PROCredit == "Y" && dataGridViewSelectListPro.RowCount == 0)//เลือกโปรเครดิต อันแรก
                    {

                        dataGridViewSelectListPro.Visible = false;
                        splitContainer1.Panel1Collapsed = true;
                        splitContainer1.Panel1.Hide();
                        AddDownToGridProCredit(dtPro);
                        //AddDownToGridProCredit(dt);
                    }
                    else if (ListOfProCredit.Any())//==========เลือกโปรธรรมดา แต่มีโปรเครดิตอยู่แล้ว
                    {
                        MessageBox.Show("Cannot select multiple for Member Promotion & Normal Promotion", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (!ListOfProCredit.Any())
                    {
                        dataGridViewSelectListPro.Visible = true;
                        splitContainer1.Panel1Collapsed = false;
                        splitContainer1.Panel1.Show();

                        AddDownToGrid("AESTHETIC", dt);
                        AddDownToGrid("SURGERY", dt);
                        AddDownToGrid("WELLNESS", dt);
                        AddDownToGrid("PHARMACY", dt);

                        info.ProductGroup = strMS_Code;
                        AddDownToGridPromotion(info);// สำหรับกริดโปรโมชั่น

                        dataGridViewSelectList.Columns["Amount"].ReadOnly = true;
                    }




                }
                else if (MoSubType == "ROOM")//Room
                {
                    Master_Room msroom = new Master_Room();
                    DataTable dtPro = new DataTable();
                    foreach (DataGridViewColumn column in dv.Columns)
                        dtPro.Columns.Add(column.Name, typeof(String));

                    foreach (DataGridViewRow item in dv.Rows)
                    {
                        double PROPrice1 = 0;
                        double NormalPrice = 0;
                        if ((bool)item.Cells[0].Value == true)
                        {
                            var chkdata = true;
                            foreach (DataGridViewRow data in dataGridViewSelectList.Rows)
                            {
                                if (item.Cells[1].Value.ToString() == data.Cells["Code"].Value.ToString())
                                {
                                    chkdata = false;
                                }
                            }
                            msroom.Room_Code = item.Cells["Room_Code"].Value + "";
                            msroom.Room_Name = item.Cells["Room_Name"].Value + "";
                            PRO_Code = item.Cells["Room_Code"].Value + "";
                            ProCreditMoney = item.Cells["Room_PriceCredit"].Value + "" == "" ? 0 : decimal.Parse(item.Cells["Room_PriceCredit"].Value + "");
                            ProPricePay = item.Cells["Room_Price"].Value + "" == "" ? 0 : decimal.Parse(item.Cells["Room_Price"].Value + "");
                            msroom.Room_Price = ProPricePay;
                            CalcPercen();
                            lbProCredit.Text = string.Format("Balances/Credit ({0}/{1}) บาท/Bth.", (ProCreditRemain) == 0 ? "0" : (ProCreditRemain).ToString("###,###,###.##"), ProCreditMoney.ToString("###,###,###.##"));

                            PROPrice1 = Convert.ToDouble(ProPricePay);
                            NormalPrice = Convert.ToDouble(ProCreditMoney);
                            object[] myItems = {
                                             false,//chk
                                           msroom.Room_Code + "",
                                           msroom.Room_Name + "",
                                           "1",//Num/Couse
                                            "1",//จำนวนที่ซื้อ
                                           "0",//Total
                                           "0",//Use
                                            "",//Unit
                                           "0",//Balance
                                          NormalPrice,//PricePer
                                          (PROPrice1-NormalPrice).ToString("###,###.##"),//Special Price
                                            "0",//ส่วนลดแคสเชีย
                                          PROPrice1.ToString("###,###.##"),//PriceTotal
                                           "",//Other
                                           DateTime.Now.AddYears(1).ToString("yyyy/MM/dd"),//ExpireDate
                                           false,//comp
                                           false,//subject
                                           "",//false,//mkt b
                                           "",//false,//gif
                                           "",//GiftNumber
                                          false,//BeforeAfter
                                          false,//Extras_sale
                                          false,//VIP
                                          false,//Pro M DIS
                                           tabTyp,
                                           "",//FeeRate
                                           "",//FeeRate2
                                           "",
                                           imageList1.Images[0],
                                           1,
                                           true,
                                           null,
                                           null,
                                           null,
                                           null,
                                           null,
                                           null,
                                           null,
                                           null,
                                           null,
                                           item.Cells[3].Value + ""
                                       };

                            if (chkdata)
                            {
                                //dateTimePickerEnd.Value = dateTimePickerEnd.Value.AddDays(Convert.ToInt32(item.Cells["Amount_Day"].Value ?? "0"));
                                dataGridViewSelectList.Rows.Add(myItems);
                            }

                            SumPriceMedicalOrder();

                        }
                    }
                    //AddDownToGridRoomCredit(dtPro);
                }
                //========================โปรธรรมดา===================================
                else
                {
                    if (FormType != DerUtility.AccessType.Update)
                    {
                        //if (radioButtonMO.Checked)
                        //    txtMO.Text = txtMO.Text.Replace("-", string.Format("-{0}-", MoSubType));
                        //else
                        //    txtSONo.Text = txtSONo.Text.Replace("-", string.Format("-{0}-", MoSubType));
                        moso = radioButtonMO.Checked ? "MO-" : "SO-";
                        //this.idMax = UtilityBackEnd.GenMaxSeqnoValues(moso + MoSubType + "-");
                        //if (radioButtonMO.Checked)
                        //    this.txtMO.Text = this.MO = this.idMax.Replace("VNM", moso);
                        //else
                        //    this.txtSONo.Text = this.idMax.Replace("VNM", moso);
                    }

                    tabTypShortName = MoSubType;

                    decimal MS_CLPrice = 0;
                    decimal MS_CAPrice = 0;
                    string MS_Price = "0";
                    decimal MS_PriceDouble = 0;
                    int ListOrder = 0;
                    var MaxID2 = 0;
                    if (dataGridViewSelectList.RowCount == 0)
                        ListOrder = 0;
                    else
                        ListOrder = MaxID2 = dataGridViewSelectList.Rows.Cast<DataGridViewRow>().Max(r => int.TryParse(r.Cells["ListOrder"].Value.ToString(), out ListOrder) ? ListOrder : 0);
                    //ListOrder = dataGridViewSelectList["ListOrder", dataGridViewSelectList.RowCount - 1].Value + "" == "" ? 0 : Convert.ToInt16(dataGridViewSelectList["ListOrder", dataGridViewSelectList.RowCount - 1].Value + "");

                    foreach (DataGridViewRow item in dv.Rows)//ถ้าเลือกรายการแบบทั่วไป ใช้อันนี้
                    {
                        if ((bool)item.Cells[0].Value == true)
                        {
                            string MS_Section = item.Cells["MS_Section"].Value + "";
                            string MS_Code = item.Cells["Code"].Value + "";
                            string MS_Name = item.Cells["Name"].Value + "";
                            //if (PROCredit == "Y" && !PROCreditProductGroup.Contains(MS_Section) && (item.Cells["MS_Type"].Value + "").ToUpper() != "S")
                            if (PROCredit == "Y") //&& !PROCreditProductGroup.Contains(MS_Section) && (item.Cells["MS_Type"].Value + "").ToUpper() != "S")
                            {
                                if (!PROCreditProductGroup.Contains(MS_Section) && !PROCreditProductGroup.Contains(MS_Code))
                                {
                                    MessageBox.Show("Is not in promotion", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    continue;
                                }
                            }
                            MS_CLPrice = item.Cells["MS_CLPrice"].Value + "" == "" ? 0 : decimal.Parse(item.Cells["MS_CLPrice"].Value + "");
                            MS_CAPrice = item.Cells["MS_CAPrice"].Value + "" == "" ? 0 : decimal.Parse(item.Cells["MS_CAPrice"].Value + "");
                            MS_Price = Entity.Userinfo.PriceNormal.Contains(customerType) ? MS_CLPrice.ToString("###,###,###.##") : MS_CAPrice.ToString("###,###,###.##");
                            MS_PriceDouble = Entity.Userinfo.PriceNormal.Contains(customerType) ? MS_CLPrice : MS_CAPrice;

                            if (Entity.Userinfo.FIX_PRO_TOPUP5.Contains(PRO_Code))
                            {
                                MS_PriceDouble = MS_CLPrice;
                            }

                            if (Entity.Userinfo.FIX_PRO_TOPUP5.Contains(PRO_Code) && !Entity.Userinfo.FIX_COUPON_Wallet.Contains(MS_Code) && (!MS_Name.ToUpper().Contains(Entity.Userinfo.FIX_Contains_BUFFET)))//ไม่ใช่ คูปอง  ไม่ใช่ buffet
                            {
                                //MS_PriceDouble = MS_PriceDouble - (MS_PriceDouble * Entity.Userinfo.FIX_COUPON_TOPUP); เดิม ลด 5% เสมอ
                                // ตอนนี้ เพิ่ม popup เลือกราคา จะลดหรือไม่ลด

                                popTopUpPrice pop = new popTopUpPrice();
                                pop.Text = item.Cells["Name"].Value + "";
                                pop.MS_Name = item.Cells["Name"].Value + "";
                                pop.MS_Price = MS_PriceDouble;
                                //pop.txtShow = "Please" + "\n" +"ติ๊กรายการที่แพทย์ขาย "+ "\n" +"Check mark items";
                                //DialogResult result3=pop.ShowDialog();
                                if (pop.ShowDialog() == DialogResult.Yes)
                                    MS_PriceDouble = pop.PriceAfterDis;
                                else return;

                                MS_Price = MS_PriceDouble.ToString("###,###,###.##");
                            }
                            decimal npLast = 0;
                            npLast = textBoxNormal.Text == "" ? 0 : Convert.ToDecimal(textBoxNormal.Text);
                            // if ((npLast + MS_PriceDouble) > ProCreditMoney) return;

                            //========สำหรับติ๊ก ค่าคอม เซล และหมอ
                            bool chkComSale = false;
                            bool chkComDr = false;
                            if (item.Cells["SurgicalFeeNewTab"].Value + "" == "Y" && customerType != "CNS")
                                chkComSale = true;
                            if (item.Cells["SurgicalFeeNewTab"].Value + "" == "Y" && customerType != "CNS" && (comboBoxByDr.SelectedValue + "").Length > 5)
                            {
                                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "Please" + "\n" + "ติ๊กรายการที่แพทย์ขาย " + "\n" + "Check mark items");

                                //popAlert pop = new popAlert();
                                //pop.txtTitle = "";
                                //pop.txtShow = "Please" + "\n" +"ติ๊กรายการที่แพทย์ขาย "+ "\n" +"Check mark items";
                                ////DialogResult result3=pop.ShowDialog();
                                //if (pop.ShowDialog() == DialogResult.Yes) return;
                                //pop.Dispose();
                                //chkComDr = true;
                            }

                            dblAmount = Entity.Userinfo.FIX_COOL.ToUpper().Contains((item.Cells["Code"].Value + "").ToUpper()) ? 2 : 1;//จำนวนที่ซื้อ   //ATBS0304 Cool Plus ใส่ 2 จุดอตโนมัติ

                            decimal Cal_COUPON = Cal_COUPON_Wallet(item.Cells["Code"].Value + "", (ListOrder + 1));
                            if (Cal_COUPON > 0)
                                dblAmount = Cal_COUPON;
                            else if (Cal_COUPON < 0 || (PRO_CalType + "" != "" && PRO_CalType + "" != "A" && PRO_CalType + "" != "P" && ProCreditRemain < MS_PriceDouble))// ถ้าติดลบ แอ็ดไม่ได้ เพราะเกินโปร
                            {
                                btnSave.Visible = false;
                                MessageBox.Show("มูลค่าเกินวงเงิน", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            else btnSave.Visible = true;


                            //====================
                            object[] myItems = {
                                             false,//chk
                                           item.Cells["Code"].Value,//ATBS0304 Cool Plus ใส่ 2 จุดอตโนมัติ
                                           item.Cells["Name"].Value+" "+COUPON_Note,
                                           item.Cells["MS_Number_C"].Value,//Num/Couse
                                            dblAmount.ToString("###,###,###.##"),//จำนวนที่ซื้อ   //ATBS0304 Cool Plus ใส่ 2 จุดอตโนมัติ
                                           "0",//Total
                                           "0",//Use
                                             item.Cells["UnitName"].Value,//Unit
                                           "0",//Balance
                                          MS_Price,//PricePer
                                          PROCredit=="Y"?CalcDiscount(MS_PriceDouble):"0",//Special Price
                                          "",
                                          PROCredit=="Y"?CalcPriceTotal(MS_PriceDouble):MS_Price,//PriceTotal
                                          
                                           //customerType == "CNT"||customerType == "CNM" ?double.Parse( item.Cells["MS_CLPrice"].Value+"").ToString("###,###.##") :double.Parse( item.Cells["MS_CAPrice"].Value+"").ToString("###,###.##"),//Price/Unit
                                           //customerType == "CNT"||customerType == "CNM" ?double.Parse( item.Cells["MS_CLPrice"].Value+"").ToString("###,###.##") :double.Parse( item.Cells["MS_CAPrice"].Value+"").ToString("###,###.##"),//PriceTotal
                                           "",//Other
                                           DateTime.Now.AddYears(1).ToString("yyyy/MM/dd"),//ExpireDate
                                           false,//comp
                                           false,//subject
                                           "",//false,//mkt b
                                           "",//false,//gif
                                           "",//GiftNumber
                                          false,//BeforeAfter
                                          false,//Extras_sale
                                          false,//VIP
                                          false,//Pro  ตอนนี้คือ Addist  PRO_CalType=="A" || PRO_CalType=="B"?true:
                                           tabTyp,
                                           item.Cells["FeeRate"].Value+"",
                                           item.Cells["FeeRate2"].Value+"",
                                           COUPON_Note,//Note
                                           imageList1.Images[0],
                                           ListOrder+1,
                                            chkComSale,//Sale Com  ตั้งค่่าที่ MedicalSection
                                            false,//Bydr Com  ตั้งค่่าที่ MedicalSection และแจ้งเตือนให้ติ๊ก ให้หมอ
                                           //       ListOrder,
                                           //true,
                                           //false,
                                           false,//cancel
                                           "",//Free
                                           "",//ราคาโปร
                                           "",//ราคาเฉลี่ยยต่อโปร
                                           item.Cells["SurgicalFeeNewTab"].Value+""
                                       };
                            item.Cells[0].Value = false;

                            //if(!OverProCredit)
                            dataGridViewSelectList.Rows.Add(myItems);

                            if ((item.Cells["Code"].Value + "").ToUpper().Contains(Entity.Userinfo.FIX_COOL))
                                this.dataGridViewSelectList.Rows[dataGridViewSelectList.RowCount - 1].Cells["Amount"].ReadOnly = true;


                            if (radioPRO.Checked && PROCredit != "Y")//ถ้าเป็นโปรแล้วซื้อ ยา ให้ addto datagrid Pro
                            {
                                Entity.Promotion info = new Entity.Promotion();
                                info.PRO_Code = item.Cells["Code"].Value + "";
                                info.PRO_Name = item.Cells["Name"].Value + "";
                                //  ProCreditMoney = item.Cells["ProPriceCredit"].Value + "" == "" ? 0 : decimal.Parse(item.Cells["ProPriceCredit"].Value + "");
                                //ProPricePay = item.Cells["ProPrice"].Value + "" == "" ? 0 : decimal.Parse(item.Cells["ProPrice"].Value + "");
                                info.ProPrice = Convert.ToDecimal(MS_Price);
                                AddDownToGridPromotion(info);// สำหรับกริดโปรโมชั่น
                            }
                            //dataGridViewSelectList["Unit", dataGridViewSelectList.Rows.Count - 1].Value = "0";
                            //DisplayPayInComboColumn(MKTBudget, dataGridViewSelectList, "MKTBudget");
                            //DisplayPayInComboColumn(GiftVoucher, dataGridViewSelectList, "GiftVoucher");

                            if (PROCredit == "Y")
                            {

                            }
                            else
                            {

                            }
                            SumPriceMedicalOrder();

                            item.Cells[0].Value = false;
                        }
                    }
                    foreach (DataGridViewRow item in dataGridViewSelectList.Rows)//ReadOnly ถ้าเป็น FIX_COOL
                    {
                        if ((item.Cells["Code"].Value + "".ToUpper()).Contains(Entity.Userinfo.FIX_COOL))
                            item.Cells["Amount"].ReadOnly = true;
                        //this.dataGridViewSelectList.Rows[dataGridViewSelectList.RowCount - 1].Cells["Amount"].ReadOnly = true;
                    }
                }
                dataGridViewSelectList.ClearSelection();
                setRowNumber(dataGridViewSelectList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private string CalcDiscount(decimal MS_PriceDouble)
        {
            string specialDiscount = "";
            try
            {

                //if (txtTotalPrice.Text.Length > 0 && txtProPrice.Text.Length > 0)
                //{
                //    double valueUp = double.Parse(txtProPrice.Text);
                //    double valueDown = double.Parse(txtTotalPrice.Text);

                //decimal discount = 0;
                //discount = 100 - ((SalePriceNew * 100) / ProCreditMoney);
                //if (ProCreditMoney > (SalePriceNew * 2)) discount = ((SalePriceNew * 100) / ProCreditMoney);
                //else if (ProCreditMoney < SalePriceNew) discount = 0;
                //else discount = 100 - ((SalePriceNew * 100) / ProCreditMoney);
                ////if (valueDown<valueUp ) txtDiscountPercen.Text = "";
                ////else
                //if (MS_PriceDouble != 1)
                //{
                if (MS_PriceDouble * dblAmount != 1)
                {
                    if (PRO_CalType == "A")//Pro amount
                    {  //ProFix_Amount
                       //  คือ ราคาขาย-xxx = ราคาเฉลี่ย  =>(ราคาโปร / จำนวนที่กำหนดในโปร)
                       //xxx=ราคาขาย-ราคาเฉลี่ย
                        decimal PriceAV = ProPricePay / ProFix_Amount;
                        if ((MS_PriceDouble * dblAmount) < (PriceAV * dblAmount))
                        {
                            SpecialDiscountBath = MS_PriceDouble = ((PriceAV * dblAmount)) - (MS_PriceDouble * dblAmount);//ทำให้บวกเสมอ
                        }
                        else
                            SpecialDiscountBath = MS_PriceDouble = ((MS_PriceDouble * dblAmount) - (PriceAV * dblAmount)) * -1;//ทำให้ลบเสมอ
                    }
                    else
                    {
                        SpecialDiscountBath = MS_PriceDouble = ((MS_PriceDouble * dblAmount) * (ProDiscountPercen / 100)) * -1;
                    }
                    SpecialDiscountBath = Convert.ToDecimal(SpecialDiscountBath.ToString("n2"));
                    //percenStr=Math.Round(discount, 2).ToString("###,###,###.##");
                    specialDiscount = MS_PriceDouble.ToString("###,###,###.##");
                }
                //}

                //}
            }
            catch (Exception ex)
            {

            }
            return specialDiscount;
        }
        private string CalcPriceTotal(decimal MS_PriceDouble)
        {
            decimal priceTotal = 0;
            string priceTotalstr = "";
            try
            {
                //decimal discount = 0;
                //discount = 100 - ((SalePriceNew * 100) / ProCreditMoney);
                //if (ProCreditMoney > (SalePriceNew * 2)) discount = ((SalePriceNew * 100) / ProCreditMoney);
                //else if (ProCreditMoney < SalePriceNew) discount = 0;
                //else discount = 100 - ((SalePriceNew * 100) / ProCreditMoney);

                //priceTotal = MS_PriceDouble-(MS_PriceDouble * (discount / 100)) ;
                if ((MS_PriceDouble * dblAmount) < Math.Abs(SpecialDiscountBath))
                    priceTotal = MS_PriceDouble + Math.Abs(SpecialDiscountBath);
                else
                    priceTotal = (MS_PriceDouble * dblAmount) - Math.Abs(SpecialDiscountBath);


                priceTotalstr = priceTotal.ToString("###,###,###.##");
            }
            catch (Exception ex)
            {

            }
            return priceTotalstr;
        }
        private void CalcPercen()
        {
            try
            {
                if (ProCreditMoney > 0)
                {
                    decimal valueUp = ProPricePay;//50,000
                    decimal valueDown = ProCreditMoney;//100,000

                    ProDiscountPercen = 0;
                    ProDiscountPercen = 100 - ((valueUp * 100) / valueDown);
                    //if (valueDown > (valueUp * 2)) ProDiscountPercen = ((valueUp * 100) / valueDown);
                    //else if (valueDown < valueUp) ProDiscountPercen = 0;
                    //else ProDiscountPercen = 100 - ((valueUp * 100) / valueDown);
                    if (valueDown < valueUp) ProDiscountPercen = 0;


                    string str = String.Format("{0:F2}", ProDiscountPercen);
                    ProDiscountPercen = Convert.ToDecimal(str);
                    //  if (txtSoRef.Text.Length > 5) ProDiscountPercen = 0;//ถ้ามีวงเงินโอนมา จะไม่คิด % ส่วนลด ถือว่าคิดเป็นราคาเต็ม แก้ปัญ หาคอร์ส member ไม่แน่ใจ จะมีปัญหา มั้ย ถ้าซื้อโปรธรรมดา แล้วลดราคาให้ลูกค้า
                    if (PRO_CalType == "B") ProDiscountPercen = 0; //ถ้าเป็นโปร buffet จะไม่มี % ส่วนลด

                    //  txtDiscountPercen.Text = Math.Round(discount, 2).ToString("###,###,###.##");
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void AddDownToGridPromotion(Entity.Promotion info)
        {
            try
            {
                //if (dt.Rows[0]["MS_Code"] + "" != "PRO_CREDIT") return;

                //double MS_CLPrice = 0;
                //double MS_CAPrice = 0;
                //double PROPrice1 = 0;
                //double NormalPrice = 0;
                //string MS_Price = "0";
                //foreach (DataRow ms in dt.Rows)
                //{
                //    if (LsSelectMS_Code.Contains(ms["PRO_Code"].ToString())) continue;
                //    else LsSelectMS_Code.Add(ms["PRO_Code"].ToString());
                //    //MS_CLPrice = item.Cells["MS_CLPrice"].Value + "" == "" ? 0 : double.Parse(item.Cells["MS_CLPrice"].Value + "");
                //    //MS_CAPrice = item.Cells["MS_CAPrice"].Value + "" == "" ? 0 : double.Parse(item.Cells["MS_CAPrice"].Value + "");
                //    PROPrice1 = ms["ProPrice"] + "" == "" ? 0 : double.Parse(ms["ProPrice"] + "");
                //    //MS_Price = MS_CLPrice.ToString("###,###,###.##");// Entity.Userinfo.PriceNormal.Contains(customerType) ? MS_CLPrice.ToString("###,###.##") : MS_CAPrice.ToString("###,###.##");
                //    //MS_Price = Entity.Userinfo.PriceNormal.Contains(customerType) ? MS_CLPrice.ToString("###,###.##") : MS_CAPrice.ToString("###,###.##");
                //    NormalPrice = ms["ProPriceCredit"] + "" == "" ? 0 : double.Parse(ms["ProPriceCredit"] + "");
                int ListOrder = 0;
                var MaxID2 = 0;
                if (dataGridViewSelectListPro.RowCount == 0)
                    ListOrder = 0;
                else
                    ListOrder = MaxID2 = dataGridViewSelectListPro.Rows.Cast<DataGridViewRow>().Max(r => int.TryParse(r.Cells["ListOrder"].Value.ToString(), out ListOrder) ? ListOrder : 0);
                object[] myItems = {
                                             false,//chk
                                             info.PRO_Code,
                                             info.PRO_Name,
                                             "1",//amount
                                             info.ProPrice,
                                             "",
                                           ListOrder+1,
                                           info.ProductGroup

                                       };
                //item.Cells[0].Value = false;

                dataGridViewSelectListPro.Rows.Add(myItems);

                //SumPriceMedicalOrder();
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AddDownToGridRoomCredit(DataTable dt)
        {
            try
            {
                if (dt.Rows[0]["MS_Code"] + "" != "PRO_CREDIT") return;

                //double MS_CLPrice = 0;
                //double MS_CAPrice = 0;
                double PROPrice1 = 0;
                double NormalPrice = 0;
                //string MS_Price = "0";
                foreach (DataRow ms in dt.Rows)
                {
                    if (ListOfProCredit.Contains(ms["PRO_Code"].ToString() + "|PRO_CREDIT")) return;
                    int ListOrder = 0;
                    var MaxID2 = 0;
                    if (dataGridViewSelectList.RowCount == 0)
                        ListOrder = 0;
                    else
                        ListOrder = MaxID2 = dataGridViewSelectList.Rows.Cast<DataGridViewRow>().Max(r => int.TryParse(r.Cells["ListOrder"].Value.ToString(), out ListOrder) ? ListOrder : 0);

                    ListOfProCredit.Add(ms["PRO_Code"].ToString() + "|PRO_CREDIT");
                    //if (LsSelectMS_Code.Contains(ms["PRO_Code"].ToString())) continue;
                    //else LsSelectMS_Code.Add(ms["PRO_Code"].ToString());
                    //MS_CLPrice = item.Cells["MS_CLPrice"].Value + "" == "" ? 0 : double.Parse(item.Cells["MS_CLPrice"].Value + "");
                    //MS_CAPrice = item.Cells["MS_CAPrice"].Value + "" == "" ? 0 : double.Parse(item.Cells["MS_CAPrice"].Value + "");
                    PROPrice1 = ms["ProPrice"] + "" == "" ? 0 : double.Parse(ms["ProPrice"] + "");
                    NormalPrice = ms["ProPriceCredit"] + "" == "" ? 0 : double.Parse(ms["ProPriceCredit"] + "");
                    object[] myItems = {
                                             false,//chk
                                           ms["PRO_Code"].ToString()+"|PRO_CREDIT",
                                           ms["PRO_Name"]+"",
                                           "1",//Num/Couse
                                            "1",//จำนวนที่ซื้อ
                                           "0",//Total
                                           "0",//Use
                                            "",//Unit
                                           "0",//Balance
                                          NormalPrice,//PricePer
                                          (PROPrice1-NormalPrice).ToString("###,###.##"),//Special Price
                                            "0",//ส่วนลดแคสเชีย
                                          PROPrice1.ToString("###,###.##"),//PriceTotal
                                          
                                           //customerType == "CNT"||customerType == "CNM" ?double.Parse( item.Cells["MS_CLPrice"].Value+"").ToString("###,###.##") :double.Parse( item.Cells["MS_CAPrice"].Value+"").ToString("###,###.##"),//Price/Unit
                                           //customerType == "CNT"||customerType == "CNM" ?double.Parse( item.Cells["MS_CLPrice"].Value+"").ToString("###,###.##") :double.Parse( item.Cells["MS_CAPrice"].Value+"").ToString("###,###.##"),//PriceTotal
                                           "",//Other
                                           DateTime.Now.AddYears(1).ToString("yyyy/MM/dd"),//ExpireDate
                                           false,//comp
                                           false,//subject
                                           "",//false,//mkt b
                                           "",//false,//gif
                                           "",//GiftNumber
                                          false,//BeforeAfter
                                          false,//Extras_sale
                                          false,//VIP
                                          false,//Pro M DIS
                                           tabTyp,
                                           "",//FeeRate
                                           "",//FeeRate2
                                           "",
                                           imageList1.Images[0],
                                           ListOrder+1,
                                           true
                                       };
                    dataGridViewSelectList.Rows.Add(myItems);
                    SumPriceMedicalOrder();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddDownToGridProCredit(DataTable dt)
        {
            try
            {
                if (dt.Rows[0]["MS_Code"] + "" != "PRO_CREDIT") return;

                //double MS_CLPrice = 0;
                //double MS_CAPrice = 0;
                double PROPrice1 = 0;
                double NormalPrice = 0;
                //string MS_Price = "0";
                foreach (DataRow ms in dt.Rows)
                {
                    if (ListOfProCredit.Contains(ms["PRO_Code"].ToString() + "|PRO_CREDIT")) return;
                    int ListOrder = 0;
                    var MaxID2 = 0;
                    if (dataGridViewSelectList.RowCount == 0)
                        ListOrder = 0;
                    else
                        ListOrder = MaxID2 = dataGridViewSelectList.Rows.Cast<DataGridViewRow>().Max(r => int.TryParse(r.Cells["ListOrder"].Value.ToString(), out ListOrder) ? ListOrder : 0);

                    ListOfProCredit.Add(ms["PRO_Code"].ToString() + "|PRO_CREDIT");
                    //if (LsSelectMS_Code.Contains(ms["PRO_Code"].ToString())) continue;
                    //else LsSelectMS_Code.Add(ms["PRO_Code"].ToString());
                    //MS_CLPrice = item.Cells["MS_CLPrice"].Value + "" == "" ? 0 : double.Parse(item.Cells["MS_CLPrice"].Value + "");
                    //MS_CAPrice = item.Cells["MS_CAPrice"].Value + "" == "" ? 0 : double.Parse(item.Cells["MS_CAPrice"].Value + "");
                    PROPrice1 = ms["ProPrice"] + "" == "" ? 0 : double.Parse(ms["ProPrice"] + "");
                    //MS_Price = MS_CLPrice.ToString("###,###,###.##");// Entity.Userinfo.PriceNormal.Contains(customerType) ? MS_CLPrice.ToString("###,###.##") : MS_CAPrice.ToString("###,###.##");
                    //MS_Price = Entity.Userinfo.PriceNormal.Contains(customerType) ? MS_CLPrice.ToString("###,###.##") : MS_CAPrice.ToString("###,###.##");
                    NormalPrice = ms["ProPriceCredit"] + "" == "" ? 0 : double.Parse(ms["ProPriceCredit"] + "");
                    object[] myItems = {
                                             false,//chk
                                           ms["PRO_Code"].ToString()+"|PRO_CREDIT",
                                           ms["PRO_Name"]+"",
                                           "1",//Num/Couse
                                            "1",//จำนวนที่ซื้อ
                                           "0",//Total
                                           "0",//Use
                                            "",//Unit
                                           "0",//Balance
                                          NormalPrice,//PricePer
                                          (PROPrice1-NormalPrice).ToString("###,###.##"),//Special Price
                                            "0",//ส่วนลดแคสเชีย
                                          PROPrice1.ToString("###,###.##"),//PriceTotal
                                          
                                           //customerType == "CNT"||customerType == "CNM" ?double.Parse( item.Cells["MS_CLPrice"].Value+"").ToString("###,###.##") :double.Parse( item.Cells["MS_CAPrice"].Value+"").ToString("###,###.##"),//Price/Unit
                                           //customerType == "CNT"||customerType == "CNM" ?double.Parse( item.Cells["MS_CLPrice"].Value+"").ToString("###,###.##") :double.Parse( item.Cells["MS_CAPrice"].Value+"").ToString("###,###.##"),//PriceTotal
                                           "",//Other
                                           DateTime.Now.AddYears(1).ToString("yyyy/MM/dd"),//ExpireDate
                                           false,//comp
                                           false,//subject
                                           "",//false,//mkt b
                                           "",//false,//gif
                                           "",//GiftNumber
                                          false,//BeforeAfter
                                          false,//Extras_sale
                                          false,//VIP
                                          false,//Pro M DIS
                                           tabTyp,
                                           "",//FeeRate
                                           "",//FeeRate2
                                           "",
                                           imageList1.Images[0],
                                           ListOrder+1,
                                           true
                                       };
                    //item.Cells[0].Value = false;

                    dataGridViewSelectList.Rows.Add(myItems);

                    SumPriceMedicalOrder();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private decimal Cal_COUPON_Wallet(string ms_code, int listorder)
        {
            decimal PriceAfterDis = 0;
            AddMoney = false;
            try
            {
                if (Entity.Userinfo.FIX_COUPON_Wallet.Contains(ms_code))//ตรวจสอบว่าเลือกคูปอง
                {
                    //=========Popup ให้เลือกว่าจะแลกโปรโมชั่นไหน
                    //=========================แลกคูปอง เป็นโปรโมชั่น==========================
                    if (Entity.Userinfo.FIX_OTHER_SUB.Contains(MS_Code))
                    {
                        popSelectPromotion pop = new popSelectPromotion();

                        pop.customerType = customerType;
                        pop.VN = VN;
                        pop.SONo = SO;
                        pop.MS_CodeM = ms_code;
                        pop.ListOrderM = listorder + "";
                        //pop.PriceTotal = dataGridViewSelectList.Rows[e.RowIndex].Cells["PriceTotal"].Value + "" == "" ? 0 : Convert.ToDecimal(dataGridViewSelectList.Rows[e.RowIndex].Cells["PriceTotal"].Value + "");
                        //pop.Text = dataGridViewSelectList.Rows[e.RowIndex].Cells["Name"].Value + "/" + pop.PriceTotal.ToString("###,###,###.##");
                        //pop.MainUnitCode = dataGridViewSelectList.Rows[e.RowIndex].Cells["MainUnitCode"].Value + "";
                        //pop.MainUnitName = dataGridViewSelectList.Rows[e.RowIndex].Cells["MainUnitName"].Value + "";
                        //pop.SubUnitCode = dataGridViewSelectList.Rows[e.RowIndex].Cells["SubUnitCode"].Value + "";
                        //pop.SubUnitName = dataGridViewSelectList.Rows[e.RowIndex].Cells["SubUnitName"].Value + "";
                        if (pop.ShowDialog() == DialogResult.OK)
                        {
                            // listSupOther = pop.listSupOther;
                            if (pop.listSupOther.Any())
                            {
                                if (ProCreditRemain >= pop.listSupOther[0].PriceAfterDis)
                                {
                                    //PriceAfterDis = pop.listSupOther[0].PriceAfterDis - (pop.listSupOther[0].PriceAfterDis * Entity.Userinfo.FIX_COUPON_TOPUP);
                                    popTopUpPrice popx = new popTopUpPrice();
                                    popx.Text = pop.listSupOther[0].MS_Name;
                                    popx.MS_Name = pop.listSupOther[0].MS_Name;
                                    popx.MS_Price = pop.listSupOther[0].PriceAfterDis;
                                    //pop.txtShow = "Please" + "\n" +"ติ๊กรายการที่แพทย์ขาย "+ "\n" +"Check mark items";
                                    //DialogResult result3=pop.ShowDialog();
                                    if (popx.ShowDialog() == DialogResult.Yes)
                                        PriceAfterDis = popx.PriceAfterDis;
                                }
                                else
                                {
                                    PriceAfterDis = ProCreditRemain;
                                    AddMoney = true;

                                    return -99999;//  555 return 99999 เอาไปเช็คว่า ไม่ให้แอ็ด เกินโปร
                                }
                                COUPON_PRO_Code = PRO_CodeGift = pop.listSupOther[0].PRO_Code;
                                COUPON_Note = pop.listSupOther[0].MS_Name;




                            }
                        }
                        COUPON_Price = PriceAfterDis;
                        //if (pop.SUMPriceAfterDis != pop.PriceTotal)
                        //    dataGridViewSelectList.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                        //else
                        //    dataGridViewSelectList.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    //เพื่อดึงราคามาลด ตาม FIX_COUPON_TOPUP
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                PriceAfterDis = 0;
            }

            return PriceAfterDis;
        }
        //private double Call_COUPON_SpecialPrice(double OldSpecial)
        //{
        //    double NewSpecial = 0;
        //    try
        //    {   
        //        if (PRO_CodeGift.Length > 4)
        //            NewSpecial = OldSpecial + (OldSpecial * Convert.ToDouble(Entity.Userinfo.FIX_COUPON_TOPUP));
        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show(ex.Message);
        //        NewSpecial = OldSpecial;
        //    }

        //    return NewSpecial;
        //}
        private double Call_COUPON_PROPrice1(double OldPROPrice1Item, double PROPriceSale)
        {
            double PROPrice1 = OldPROPrice1Item;
            try
            {
                if (PRO_CodeGift.Length > 4)
                {
                    PROPrice1 = OldPROPrice1Item - (OldPROPrice1Item * Call_COUPON_DIS_Percen(PROPriceSale));
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                PROPrice1 = OldPROPrice1Item;
            }

            return PROPrice1;
        }
        private double Call_COUPON_DIS_Percen(double OldPROPrice)
        {
            double PercenCOUPON_Dis = 0;
            double BalanceRef = AddMoney ? OldPROPrice : Convert.ToDouble(txtBalanceRef.Text);// AddMoney=true ถ้าเพิ่มเงิน ใช้ราคาเดิม ไม่ต้องลด 
            try
            {
                if (PRO_CodeGift.Length > 4)
                {
                    PercenCOUPON_Dis = ((OldPROPrice - BalanceRef) * 100) / OldPROPrice;
                    PercenCOUPON_Dis = PercenCOUPON_Dis / 100;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                PercenCOUPON_Dis = 0;
            }

            return PercenCOUPON_Dis;
        }
        string strMS_Code = "";
        private void AddDownToGrid(string tabPageActive, DataTable dt)
        {
            try
            {
                DataGridView dv = new DataGridView();
                switch (tabPageActive)
                {
                    case "AESTHETIC":
                        dv = dgvAestheticList;
                        break;
                    case "SURGERY":
                        dv = dgvSurgeryList;
                        break;
                    case "WELLNESS":
                        dv = dgvWellness_AntiagingList;
                        break;
                    case "PHARMACY":
                        dv = dgvPharmacyList;
                        break;
                    case "PROMOTION":
                        dv = dgvPromotionList;
                        break;
                }

                double MS_CLPrice = 0;
                double MS_CAPrice = 0;
                double PROPrice1 = 0;
                double ProPrice = 0;
                double NormalPrice = 0;
                string MS_Price = "0";
                double Amount = 0;
                double MS_Number_C = 0;
                double SpacialP = 0;

                foreach (DataRow ms in dt.Rows)
                {

                    foreach (DataGridViewRow item in dv.Rows)
                    {
                        if (item.Cells["Code"].Value.ToString() == ms["MS_Code"].ToString())
                        {
                            string key = "";
                            int ListOrder = 0;
                            var MaxID2 = 0;
                            if (dataGridViewSelectList.RowCount == 0)
                                ListOrder = 0;
                            else
                                ListOrder = MaxID2 = dataGridViewSelectList.Rows.Cast<DataGridViewRow>().Max(r => int.TryParse(r.Cells["ListOrder"].Value.ToString(), out ListOrder) ? ListOrder : 0);

                            ListOrder += 1;
                            strMS_Code += ms["MS_Code"].ToString() + "," + ListOrder + "|";

                            //if (LsSelectMS_Code.Contains(ms["MS_Code"].ToString()))  continue;

                            //else
                            //    LsSelectMS_Code.Add(ms["MS_Code"].ToString());

                            //LsSelectMS_Code.Add(ms["MS_Code"].ToString());
                            MS_CLPrice = item.Cells["MS_CLPrice"].Value + "" == "" ? 0 : double.Parse(item.Cells["MS_CLPrice"].Value + "");
                            MS_CAPrice = item.Cells["MS_CAPrice"].Value + "" == "" ? 0 : double.Parse(item.Cells["MS_CAPrice"].Value + "");
                            PROPrice1 = ms["MS_ProPrice"] + "" == "" ? 0 : double.Parse(ms["MS_ProPrice"] + "");
                            ProPrice = ms["ProPrice"] + "" == "" ? 0 : double.Parse(ms["ProPrice"] + "");
                            Amount = ms["Amount"] + "" == "" ? 0 : double.Parse(ms["Amount"] + "");

                            //double  Cal_COUPON=Cal_COUPON_Wallet(ms["MS_Code"].ToString());
                            //if (Cal_COUPON > 0) Amount = Cal_COUPON;

                            //MS_Number_C = ms["MS_Number_C"] + "" == "" ? 0 : double.Parse(ms["MS_Number_C"] + "");



                            //MS_Price = MS_CLPrice.ToString("###,###,###.##");// Entity.Userinfo.PriceNormal.Contains(customerType) ? MS_CLPrice.ToString("###,###.##") : MS_CAPrice.ToString("###,###.##");
                            MS_Price = Entity.Userinfo.PriceNormal.Contains(customerType) ? MS_CLPrice.ToString("###,###.##") : MS_CAPrice.ToString("###,###.##");
                            NormalPrice = Entity.Userinfo.PriceNormal.Contains(customerType) ? MS_CLPrice : MS_CAPrice;

                            PROPrice1 = Call_COUPON_PROPrice1(PROPrice1, ProPrice);//คำนวนราคาใหม่ถ้าเป็น คูปอง
                            SpacialP = PROPrice1 - (NormalPrice * Amount);



                            if (dicAmount.ContainsKey(strMS_Code))
                            {
                                dicAmount[strMS_Code] = Amount;
                                dicSpecialPrice[strMS_Code] = SpacialP;
                            }
                            else
                            {
                                dicAmount.Add(strMS_Code, Amount);
                                dicSpecialPrice.Add(strMS_Code, SpacialP);
                            }

                            object[] myItems = {
                                             false,//chk
                                           item.Cells["Code"].Value,
                                           item.Cells["Name"].Value,
                                           Convert.ToDouble(item.Cells["MS_Number_C"].Value).ToString("###,###.##"),//Num/Couse
                                            Convert.ToDouble(ms["Amount"]+"").ToString("###,###.##"),//จำนวนที่ซื้อ
                                           (Amount).ToString("###,###.##"),//"0",//Total
                                           "0",//Use
                                             item.Cells["UnitName"].Value,//Unit
                                           "0",//Balance
                                          MS_Price,//PricePer
                                          (SpacialP).ToString("###,###.##"),//Special Price
                                          "0",//ส่วนลดแคสเชีย
                                          PROPrice1.ToString("###,###.##"),//PriceTotal
                                          
                                           //customerType == "CNT"||customerType == "CNM" ?double.Parse( item.Cells["MS_CLPrice"].Value+"").ToString("###,###.##") :double.Parse( item.Cells["MS_CAPrice"].Value+"").ToString("###,###.##"),//Price/Unit
                                           //customerType == "CNT"||customerType == "CNM" ?double.Parse( item.Cells["MS_CLPrice"].Value+"").ToString("###,###.##") :double.Parse( item.Cells["MS_CAPrice"].Value+"").ToString("###,###.##"),//PriceTotal
                                           "",//Other
                                           DateTime.Now.AddYears(1).ToString(),//ExpireDate
                                           false,//comp
                                           false,//subject
                                           "",//false,//mkt b
                                           "",//false,//gif
                                           "",//GiftNumber
                                          false,//BeforeAfter
                                          false,//Extras_sale
                                          false,//VIP
                                          false,//PRO
                                           tabTyp,
                                           item.Cells["FeeRate"].Value+"",
                                           item.Cells["FeeRate2"].Value+"",
                                           "",
                                           imageList1.Images[0],
                                           ListOrder,
                                           //ms["COMS"].ToString().ToUpper()=="Y"?true:false,//true,
                                           false,
                                           false,
                                           "",
                                           Amount,//จำนวนที่ตั้งโปร
                                           (PROPrice1/Amount),//ราคาต่อหน่วยที่ตั้งโปร  PricePerPro
                                           item.Cells["SurgicalFeeNewTab"].Value+""
                                       };
                            item.Cells[0].Value = false;

                            dataGridViewSelectList.Rows.Add(myItems);

                            SumPriceMedicalOrder();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void buttonDeleteUp_BtnClick()
        {
            try
            {
                dataGridViewSelectListPro.EndEdit();
                dataGridViewSelectList.EndEdit();
                List<Entity.SupplieTrans> listSup = new List<Entity.SupplieTrans>();
                List<DataGridViewRow> rowsToDelete = new List<DataGridViewRow>();
                List<DataGridViewRow> rowsToDeletePro = new List<DataGridViewRow>();

                //==========================For Promotion========================
                foreach (DataGridViewRow row in dataGridViewSelectListPro.Rows)
                {
                    if ((row.Cells[0].Value + "").ToLower() == "true")
                    {
                        rowsToDeletePro.Add(row);
                        if (FormType == DerUtility.AccessType.Update)
                        {
                            Entity.SupplieTrans supplieInfo = new Entity.SupplieTrans();
                            supplieInfo.VN = vn;
                            supplieInfo.SONo = txtSONo.Text;
                            supplieInfo.MS_Code = row.Cells["Code"].Value + "";
                            supplieInfo.ListMS_Code = row.Cells["ListMS_Code"].Value + "";
                            supplieInfo.ListOrder = row.Cells["ListOrder"].Value + "";
                            supplieInfo.BranchID = cboBranch.SelectedValue + "";
                            listSup.Add(supplieInfo);

                        }
                    }
                }

                string mscode = "";
                foreach (DataGridViewRow row in dataGridViewSelectList.Rows)
                {
                    mscode = row.Cells["Code"].Value + "";
                    if (MoSubType == "PRO" && PROCredit != "Y" && (row.Cells[0].Value + "").ToLower() == "true")
                    {

                        rowsToDelete.Add(row);
                        if (FormType == DerUtility.AccessType.Update)
                        {
                            Entity.SupplieTrans supplieInfo = new Entity.SupplieTrans();
                            supplieInfo.VN = vn;
                            supplieInfo.SONo = txtSONo.Text;
                            supplieInfo.MS_Code = mscode;
                            supplieInfo.ListOrder = row.Cells["ListOrder"].Value + "";
                            supplieInfo.BranchID = cboBranch.SelectedValue + "";
                            listSup.Add(supplieInfo);
                        }
                        string key = row.Cells["Code"].Value + "," + row.Cells["ListOrder"].Value + "" + "|";
                        dicAmount.Remove(key);
                        dicSpecialPrice.Remove(key);

                        //lbPromotion.Text = "";
                        dicPromotion.Remove(mscode);
                    }
                    else
                    {
                        if ((row.Cells[0].Value + "").ToLower() == "true")
                        {
                            //=================For Gift=================
                            string ms_code = row.Cells["Code"].Value + "";
                            string PRO_Dept = "";
                            string PRO_CodeGift = "";

                            string[] lsCode = (ms_code).Split('|');
                            if (lsCode.Count() > 1)
                            {
                                foreach (DataGridViewRow Pitem in dgvPromotionList.Rows)//Promotion
                                {
                                    if (lsCode[0] == Pitem.Cells["PRO_Code"].Value + "")
                                    {
                                        PRO_Dept = Pitem.Cells["PRO_Dept"].Value + "";
                                        PRO_CodeGift = Pitem.Cells["PRO_Code"].Value + "";
                                        break;
                                    }
                                }
                            }
                            //=================For Gift=================
                            rowsToDelete.Add(row);
                            if (FormType == DerUtility.AccessType.Update)
                            {
                                Entity.SupplieTrans supplieInfo = new Entity.SupplieTrans();
                                supplieInfo = new Entity.SupplieTrans();
                                supplieInfo.PRO_Dept = PRO_Dept;
                                supplieInfo.PRO_Code = PRO_CodeGift;
                                supplieInfo.SORef = SORef;
                                supplieInfo.MS_CodeRef = MS_CodeRef;
                                supplieInfo.ListOrderRef = ListOrderRef;
                                supplieInfo.VN = vn;
                                supplieInfo.SONo = txtSONo.Text;
                                supplieInfo.MS_Code = mscode;
                                supplieInfo.ListOrder = row.Cells["ListOrder"].Value + "";
                                supplieInfo.BranchID = cboBranch.SelectedValue + "";
                                listSup.Add(supplieInfo);
                            }
                        }
                    }
                    if (ListOfProCredit.Contains(mscode)) ListOfProCredit.Remove(mscode);

                    //if (statusDel == 1)
                    //{=================Delete File  For  Free===================
                    if (currentRowIndex >= 0)
                    {
                        if (dataGridViewSelectList.Rows[currentRowIndex].Cells["Free"].Value + "" != "")
                        {
                            string dickey = string.Format("{0}{1}{2}{3}", txtSONo.Text, txtMO.Text, dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentCell.RowIndex].Cells["Code"].Value + "", dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentCell.RowIndex].Cells["ListOrder"].Value + "");
                            if (dicFreeTrans.ContainsKey(dickey))
                            {
                                dicFreeTransDel.Add(dickey, dicFreeTrans[dickey]);
                                dicFreeTrans.Remove(dickey);

                            }
                        }
                    }
                    //===========================================================
                }

                foreach (Entity.SupplieTrans item in listSup)
                {
                    DataSet dsSurgeryFee = new Business.MedicalOrderUseTrans().SelectSavedJobCostById("SELECTSAVEDJOBCOSTForDelMO", item.VN, item.MS_Code, item.ListOrder, "");
                    if (dsSurgeryFee.Tables.Count > 0 && dsSurgeryFee.Tables[0].Rows.Count > 0 && !(Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN) && !Userinfo.IS_ADMIN_JOBCOST.Contains(Userinfo.EN) && !Userinfo.IS_ADMIN_EDIT.Contains(Userinfo.EN))
                    {
                        DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, "ไม่สามารถแก้ไขข้อมูลได้เนื่องจาก ได้บันทึกค่ามือและค่าแพทย์ไปแล้ว" + Environment.NewLine + "กรุณาติดต่อผู้ดูแลระบบ");
                        return;
                    }
                }



                int? statusDel = new Business.MedicalSupplies().DeleteSupplies(listSup.ToArray());


                foreach (DataGridViewRow row in rowsToDelete)
                {
                    if (row.Index >= 0)
                        dataGridViewSelectList.Rows.Remove(row);
                }

                foreach (DataGridViewRow row in rowsToDeletePro)
                {
                    if (row.Index >= 0)
                        dataGridViewSelectListPro.Rows.Remove(row);
                }

                SumPriceMedicalOrder();
                if (dataGridViewSelectList.RowCount == 0)
                {
                    if (FormType == DerUtility.AccessType.Update)
                    {

                    }
                    else
                    {
                        tabTypShortName = MoSubType = "";
                        //if (txtMO.Text.Length > 0) txtMO.Text = txtMO.Text.Remove(2, 3);
                        //if (txtSONo.Text.Length > 0) txtSONo.Text = txtSONo.Text.Remove(2, 3);
                    }


                }
                //}

            }
            catch (Exception ex)
            {

                //  MessageBox.Show(ex.Message);
            }
        }
        private void FilterList(DataGridView dgv, DataTable dt, string txtFilter, string tab)
        {
            try
            {
                DataView dv = new DataView(dt);

                if (txtFilter.Length == 0)
                {
                    if (dt.Rows.Count == dgv.Rows.Count)
                        return;
                    //dv.RowFilter = string.Format("[MS_Code] LIKE '%{0}%' or [MS_Name] LIKE '%{0}%'", txtFilter);
                }
                else
                {
                    if (tab.ToLower().IndexOf("pro") > -1)
                        dv.RowFilter = string.Format("[PRO_Code] LIKE '%{0}%' or [PRO_Name] LIKE '%{0}%' or [Remark] LIKE '%{0}%'", txtFilter);
                    else
                    {
                        dv.RowFilter = string.Format("[MS_Code] LIKE '%{0}%' or [MS_Name] LIKE '%{0}%' or [MS_Detail] LIKE '%{0}%'", txtFilter);
                    }
                }



                if (dgv.Rows.Count > 0)
                    dgv.Rows.Clear();

                if (tab.ToLower().IndexOf("pro") > -1)
                {
                    foreach (DataRowView item in dv)
                    {
                        object[] myItems = {
                                           false,
                                           item["PRO_Code"] + "",
                                           item["PRO_Name"] + "",
                                          (item["ProPrice"] + ""=="")?"0":(Convert.ToDouble(item["ProPrice"]).ToString("###,###,###.##")),
                                           item["DateStart"] + "",
                                          item["DateEnd"] + "",
                                          item["PRO_Active"] + "",
                                          item["Remark"] + "",
                                           tab,
                                          item["PRO_Type"] + "",
                                          item["ProPriceCredit"] + "",
                                          item["ProductGroup"] + "",
                                          item["PRO_Dept"] + ""

                                       };
                        dgv.Rows.Add(myItems);

                    }
                }
                else
                {
                    foreach (DataRowView item in dv)
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
                                          tab,
                                           item["FeeRate"] + "",
                                          item["FeeRate2"] + "",
                                          item["MS_Detail"] + "",
                                          item["Active"] + "",
                                          item["SurgicalFeeNewTab"] + ""

                                       };
                        dgv.Rows.Add(myItems);
                        if (item["Active"] + "".ToUpper() != "Y")
                        {
                            //dgv.Rows[dgv.Rows.Count - 1].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
                            dgv.Rows[dgv.Rows.Count - 1].Visible = false;
                        }
                        if ((PRO_CalType == "B" && (item["MS_Name"] + "").ToLower().IndexOf("buffet") <= 0))
                        {
                            //dgv.Rows[dgv.Rows.Count - 1].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
                            dgv.Rows[dgv.Rows.Count - 1].Visible = false;
                        }
                    }
                }



            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtFindHair_Enter(object sender, EventArgs e)
        {

        }

        private void txtFindPro_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //BindPromotionList();
            //}
            try
            {
                //if (txtFindAes.Text.Length == 0) return;
                if (e.KeyCode == Keys.Enter)
                    FilterList(dgvPromotionList, dtPromotion, txtFindPro.Text.Trim(), "Promotion");
            }
            catch (Exception)
            {

            }

        }
        private void txtFindRoom_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    using (var context = new EntitiesOPD_System())
                    {
                        var tmepRoom = context.Master_Room.Where(x => x.Room_Name.Contains(txtSearchRoom.Text) && x.Is_Active == true).ToList();

                        gvRoom.DataSource = tmepRoom;
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void txtFindAes_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                    FilterList(dgvAestheticList, dtAESTHETIC, txtFindAes.Text.Trim(), "AESTHETIC");
            }
            catch (Exception)
            {

            }
            ////if (e.KeyCode == Keys.Enter)
            ////{
            //   BindDataAesList();
            ////}
        }



        private void txtFindSurgery_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                // if (txtFindSurgery.Text.Length == 0) return;
                if (e.KeyCode == Keys.Enter)
                    FilterList(dgvSurgeryList, dtSURGERY, txtFindSurgery.Text.Trim(), "SURGERY");
            }
            catch (Exception)
            {

            }
        }
        private void txtWellness_Antiaging_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //BindDataWellness_antiAgentList();
            //}
            try
            {
                if (e.KeyCode == Keys.Enter)
                    FilterList(dgvWellness_AntiagingList, dtWELLNESS, txtWellness_Antiaging.Text.Trim(), "WELLNESS");
            }
            catch (Exception)
            {

            }
        }
        private void txtFindPharmacy_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    BindDataPharmacyList();
            //}
            try
            {
                if (txtFindPharmacy.Text.Length < 2 && e.KeyCode != Keys.Enter) return;
                // FilterList(dgvPharmacyList, dtPHARMACY, txtFindPharmacy.Text.Trim(), "PHARMACY");
                BindDataPharmacyList();
            }
            catch (Exception)
            {

            }
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }
        private void SelectCustomer()
        {
            try
            {
                if (!string.IsNullOrEmpty(CN))//&& SORef == ""
                {
                    if (DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirmYesNo, "ต้องการเปลี่ยน ชื่อลูกค้า หรือไม่?") == DialogResult.Yes)
                    {
                        if (PRO_CodeGift == "")
                        {
                            RemoveDgvRows(dataGridViewSelectList);
                            txtPriceTotal.Text = "0.00";
                            textBoxNormal.Text = "0.00";
                        }
                    }
                    else return;
                }
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
                    customerType = obj.CustomerType;
                }
                //}
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
        decimal dblAmount = 0;
        decimal AllAmount = 0;
        int alertcount = 0;
        bool endedit = false;


        private void dataGridViewSelectList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (alertcount == 0)
                    sumdataGridviewSelectList(e.RowIndex);
            }
            catch (Exception ex)
            {

            }

        }
        private void sumdataGridviewSelectList(int RowIndex)
        {
            try
            {
                // if (ISEndEdit) return;
                if (RowIndex < 0) return;

                decimal dbNumPerC = 0;
                decimal dbPricePerU = 0;
                decimal dblTotal = 0;
                decimal SPPrice = 0;
                decimal Discashier = 0;
                string[] AmountaArr = (dataGridViewSelectList.Rows[RowIndex].Cells["Price/Unit"].Value + "").Split(':');
                if (AmountaArr.Length > 1)
                {

                    foreach (var s in AmountaArr)
                    {
                        //dblAmount = s == "" ? 0 : double.Parse(s);
                        //dbNumPerC = dataGridViewSelectList.Rows[e.RowIndex].Cells["No./Course"].Value + "" == "" ? 0 : double.Parse(dataGridViewSelectList.Rows[e.RowIndex].Cells["No./Course"].Value + "");
                        //dbPricePerU = dataGridViewSelectList.Rows[e.RowIndex].Cells["Price/Unit"].Value + "" == "" ? 0 : double.Parse(dataGridViewSelectList.Rows[e.RowIndex].Cells["Price/Unit"].Value + "");
                        //string[] dblTotalArr = (dataGridViewSelectList.Rows[e.RowIndex].Cells["PriceTotal"].Value + "").Split(':');
                        dblTotal += (s == "" ? 0 : decimal.Parse(s));
                    }

                }
                else
                {
                    dblAmount = dataGridViewSelectList.Rows[RowIndex].Cells["Amount"].Value + "" == "" ? 0 : decimal.Parse(dataGridViewSelectList.Rows[RowIndex].Cells["Amount"].Value + "");
                    if (dblAmount < 0)
                    {
                        dblAmount = 1;
                        dataGridViewSelectList.Rows[RowIndex].Cells["Amount"].Value = 1;
                    }
                    dbNumPerC = dataGridViewSelectList.Rows[RowIndex].Cells["No./Course"].Value + "" == "" ? 0 : decimal.Parse(dataGridViewSelectList.Rows[RowIndex].Cells["No./Course"].Value + "");
                    dbPricePerU = dataGridViewSelectList.Rows[RowIndex].Cells["Price/Unit"].Value + "" == "" ? 0 : decimal.Parse(dataGridViewSelectList.Rows[RowIndex].Cells["Price/Unit"].Value + "");
                    //dataGridViewSelectList.Rows[RowIndex].Cells["SpecialPrice"].Value = 0;//คืนค่าเป็น 0 ก่อนจะคำนวน  15-06-2019
                    Discashier = dataGridViewSelectList.Rows[RowIndex].Cells["Discashier"].Value + "" == "" ? 0 : decimal.Parse(dataGridViewSelectList.Rows[RowIndex].Cells["Discashier"].Value + "");
                    SPPrice = dataGridViewSelectList.Rows[RowIndex].Cells["SpecialPrice"].Value + "" == "" ? 0 : decimal.Parse(dataGridViewSelectList.Rows[RowIndex].Cells["SpecialPrice"].Value + "");

                    dataGridViewSelectList.Rows[RowIndex].Cells["Total"].Value = dblAmount * dbNumPerC; //จำนวนทั้งหมด
                    decimal pritotal = ((dblAmount * dbPricePerU) - Discashier) + SPPrice;




                    decimal Price50Per = (dblAmount * dbPricePerU) / 2;
                    decimal Price60Per = ((dblAmount * dbPricePerU) * 60) / 100;
                    decimal Price80Per = ((dblAmount * dbPricePerU) * 80) / 100;
                    decimal Price95Per = ((dblAmount * dbPricePerU) * 95) / 100;

                    string txtPercen = "";
                    if (Entity.Userinfo.PriceNormal.Contains(customerType))
                    {
                        Price50Per = Price50Per;
                        txtPercen = "50%";
                    }
                    else
                    {
                        Price50Per = Price60Per;
                        txtPercen = "60%";
                    }
                    if (txtSONo.Text.ToLower().Contains("pro"))
                    {
                        Price50Per = Price80Per;
                        txtPercen = "80%";
                    }

                    if (customerType == "CNM" || customerType == "CNS")
                    {
                        Price50Per = Price95Per;
                        txtPercen = "95%";
                    }

                    Price50Per = SPPrice < 0 ? ((dblAmount * dbPricePerU) - Price50Per) : Price50Per;

                    bool Free = dataGridViewSelectList.Rows[RowIndex].Cells["Free"].Value + "" != "";
                    //if (pritotal < Price50Per && Free == false && txtMO.Text.Length < 5 && !(Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN) && !Userinfo.IS_ADMIN_DISCOUNT.Contains(Userinfo.EN))
                    if (pritotal < Price50Per && Free == false && txtMO.Text.Length < 5)
                    {

                        if (!(Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN) && !Userinfo.IS_ADMIN_DISCOUNT.Contains(Userinfo.EN))
                        {
                            dataGridViewSelectList.Rows[RowIndex].Cells["PriceTotal"].Value = (dblAmount * dbPricePerU).ToString("###,###,###,###.##"); //ราคารวม
                            dataGridViewSelectList.Rows[RowIndex].Cells["SpecialPrice"].Value = "0";
                            //endedit = true;
                            alertcount++;
                            MessageBox.Show("Cannot discount over " + txtPercen, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            if (dataGridViewSelectList.CurrentCell.ColumnIndex != dataGridViewSelectList.Columns["chkBydr"].Index && dataGridViewSelectList.CurrentCell.ColumnIndex != dataGridViewSelectList.Columns["chkSaleCom"].Index)
                            {
                                MessageBox.Show("Cannot discount over " + txtPercen + " Please recheck approved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }

                    alertcount = 0;

                    //dataGridViewSelectList.Rows[RowIndex].Cells["PriceTotal"].Value =pritotal==0?"0": pritotal.ToString("###,###.##"); //ราคารวม


                    //CalDiscount
                    DataGridViewCheckBoxCell ch1 = (DataGridViewCheckBoxCell)dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells["ChkPRO"];
                    bool adddis = (ch1.Value + "").ToLower() == "true";
                    //dataGridViewSelectList.Rows[e.RowIndex].Cells["SpecialPrice"].Value = SPPrice != 0 ? SPPrice.ToString("###,###,###.##") : CalcDiscount(dbPricePerU); //จำนวนทั้งหมด  || dataGridViewSelectList.Rows[e.RowIndex].Cells["SpecialPrice"].Value + "" == "0" 
                    if (PROCredit == "Y" && PRO_CalType != "B" && dataGridViewSelectList.Rows[RowIndex].Cells["Free"].Value + "" == "")
                    {
                        if (!(dataGridViewSelectList.Rows[RowIndex].Cells["Code"].Value + "").Contains("CREDIT") && adddis == false) //ถ้าเป็นรายการแรก จะข้ามการใส่ส่วนลด
                            dataGridViewSelectList.Rows[RowIndex].Cells["SpecialPrice"].Value = CalcDiscount(dbPricePerU); //จำนวนทั้งหมด
                    }
                    else//ขายแบบธรรมดา
                        dataGridViewSelectList.Rows[RowIndex].Cells["SpecialPrice"].Value = SPPrice.ToString("###,###,###.##");


                    //Set Format 
                    dataGridViewSelectList.Rows[RowIndex].Cells["Amount"].Value = dblAmount == 0 ? "0" : dblAmount.ToString("###,###");
                    if (PROCredit == "Y")
                    {
                        SPPrice = dataGridViewSelectList.Rows[RowIndex].Cells["SpecialPrice"].Value + "" == "" ? 0 : decimal.Parse(dataGridViewSelectList.Rows[RowIndex].Cells["SpecialPrice"].Value + "");
                        pritotal = ((dblAmount * dbPricePerU) - Discashier) + SPPrice;
                    }
                    dataGridViewSelectList.Rows[RowIndex].Cells["PriceTotal"].Value = pritotal == 0 ? "0" : pritotal.ToString("###,###.##"); //ราคารวม ใส่เพิ่ม 15-06-2019
                                                                                                                                             //string strOther = dataGridViewSelectList.Rows[RowIndex].Cells["Other"].Value + "";
                                                                                                                                             //if(!string.IsNullOrEmpty(strOther))
                                                                                                                                             //{
                                                                                                                                             //    dataGridViewSelectList.Rows[RowIndex].Cells["Other"].Value =  double.Parse(strOther).ToString("###,###.##");
                                                                                                                                             //}

                }
                // string dateExpire = dataGridViewSelectList.Rows[e.RowIndex].Cells["ExpireDate"].Value+"";
                //if(dateExpire.Length>0) dataGridViewSelectList.Rows[e.RowIndex].Cells["ExpireDate"].Value =ToMaskedExpireString(dataGridViewSelectList.Rows[e.RowIndex].Cells["ExpireDate"].Value.ToString());

                //if ((dataGridViewSelectList.Rows[e.RowIndex].Cells["ChkPRO"].Value+"").ToLower() == "true")
                //    SumManualPriceMedicalOrder();
                //else SumPriceMedicalOrder();
                alertcount++;
                SumPriceMedicalOrder();

                //DataGridViewComboBoxColumn chCom = new DataGridViewComboBoxColumn();
                //string  cboMKT = dataGridViewSelectList.Rows[e.RowIndex].Cells["MKTBudget"].Value+"";
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, "เกิดข้อผิดพลาดในการแสดงข้อมูล เนื่องจาก \"Error.\"" + ex.Message);
            }
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
        bool ISAlert = false;
        bool ISEndEdit = false;
        private void SumPriceMedicalOrderAll()
        {
            try
            {
                if (dataGridViewSelectList.Rows.Count == 0) return;
                SalePriceNew = 0;
                SumAllTypeSalePrice = 0;
                SumMS_Price = 0;
                decimal PriceNormal = 0;
                dblAmount = 0;
                decimal p = 0;
                string ms_name = "";
                foreach (DataGridViewRow row in dataGridViewSelectList.Rows)
                {
                    if (row.Visible)
                    {

                        dblAmount = row.Cells["Amount"].Value + "" == "" ? 0 : decimal.Parse(row.Cells["Amount"].Value + "");
                        p = row.Cells["Price/Unit"].Value + "" == "" ? 0 : decimal.Parse(row.Cells["Price/Unit"].Value + "");
                        SumMS_Price += (dblAmount * p);//row.Cells["Price/Unit"].Value + "" == "" ? 0 : decimal.Parse(row.Cells["Price/Unit"].Value + "");
                        SumAllTypeSalePrice += row.Cells["PriceTotal"].Value + "" == "" ? 0 : decimal.Parse(row.Cells["PriceTotal"].Value + "");
                        PriceNormal += dblAmount * p;
                    }

                }
                //if (PROCredit == "Y" && firstload == false && alertcount <= 1 && ms_name!="")
                //    MessageBox.Show(string.Format(ms_name +" Is manual discount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning));
                //===============คำนวน Pro credit=========
                if (SumMS_Price > ProCreditMoney && ProCreditMoney != 0) OverProCredit = true;
                else OverProCredit = false;

                if (dataGridViewSelectList.RowCount <= 1) ProCreditRemain = ProCreditMoney;
                else
                {
                    ProCreditRemain = (ProCreditMoney - SumMS_Price) - SalePriceNew;
                }

                lbProCredit.Text = string.Format("Balances/Credit ({0}/{1}) บาท/Bth. {2}", (ProCreditRemain) == 0 ? "0" : (ProCreditRemain).ToString("###,###,###.##"), ProCreditMoney.ToString("###,###,###.##"), ProCreditRemark);
                txtPriceTotal.Text = SumAllTypeSalePrice == 0 ? "0" : SumAllTypeSalePrice.ToString("###,###,###.##");
                textBoxNormal.Text = PriceNormal.ToString("###,###,###.##"); ;

                ISEndEdit = false;
            }
            catch (Exception ex)
            {

            }

        }
        private void SumPriceMedicalOrder()
        {
            try
            {
                //ProCreditRemark = "";
                if (dataGridViewSelectList.Rows.Count == 0) return;
                SalePriceNew = 0;
                SumAllTypeSalePrice = 0;
                SumMS_Price = 0;
                dblAmount = 0;
                decimal p = 0;
                decimal PriceNormal = 0;
                //CalcPercen();
                //ราคารวม procredit
                //SalePriceNew = dataGridViewSelectList.Rows.Cast<DataGridViewRow>().Sum(row => row.Cells["PriceTotal"].Value + "" == "" ? 0 : decimal.Parse(row.Cells["PriceTotal"].Value + ""));
                string ms_name = "";
                foreach (DataGridViewRow row in dataGridViewSelectList.Rows)
                {
                    if (row.Visible)
                    {
                        //if ((row.Cells["ChkPRO"].Value + "").ToLower() == "true")//ติ๊ก Add_Dis
                        //{
                        //    if (PRO_CalType == "A" || PRO_CalType == "B" || PRO_CalType == "P")
                        //        SalePriceNew += row.Cells["PriceTotal"].Value + "" == "" ? 0 : decimal.Parse(row.Cells["PriceTotal"].Value + "");
                        //    else
                        //    {
                        //        //===============เพิ่มเมื่อ 15-06-2019  ใช้ราคาเต็มตัดวงเงินเสมอ===========================
                        //        dblAmount = row.Cells["Amount"].Value + "" == "" ? 0 : decimal.Parse(row.Cells["Amount"].Value + "");
                        //        p = row.Cells["Price/Unit"].Value + "" == "" ? 0 : decimal.Parse(row.Cells["Price/Unit"].Value + "");
                        //        SalePriceNew += (dblAmount * p);
                        //        //==========================================
                        //    }

                        //    ms_name += row.Cells["Name"].Value + System.Environment.NewLine;

                        //    //PriceNormal += dblAmount * p;

                        //}
                        //else
                        //{
                        dblAmount = row.Cells["Amount"].Value + "" == "" ? 0 : decimal.Parse(row.Cells["Amount"].Value + "");
                        p = row.Cells["Price/Unit"].Value + "" == "" ? 0 : decimal.Parse(row.Cells["Price/Unit"].Value + "");



                        SumMS_Price += (dblAmount * p);//row.Cells["Price/Unit"].Value + "" == "" ? 0 : decimal.Parse(row.Cells["Price/Unit"].Value + "");
                                                       //=====================โปรนม ยอดคงเหลือจะติดลบ เพราะ ใช้ราคาเต็ม ตัดวงเงิน เหมือนโปรวงเงินทั่วไป

                        // }

                        //========12-06-2019  ช่องราคาเต็ม ใช้ราคาเต็ทเสมอ ไม่สนใจ  addis
                        dblAmount = row.Cells["Amount"].Value + "" == "" ? 0 : decimal.Parse(row.Cells["Amount"].Value + "");
                        p = row.Cells["Price/Unit"].Value + "" == "" ? 0 : decimal.Parse(row.Cells["Price/Unit"].Value + "");
                        PriceNormal += dblAmount * p;

                        //if (PRO_CalType == "P")
                        //    SumAllTypeSalePrice = PriceNormal;
                        //else
                        SumAllTypeSalePrice += row.Cells["PriceTotal"].Value + "" == "" ? 0 : decimal.Parse(row.Cells["PriceTotal"].Value + "");

                    }

                }
                //if (PROCredit == "Y" && firstload == false && alertcount <= 1 && ms_name!="")
                //    MessageBox.Show(string.Format(ms_name +" Is manual discount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning));
                //===============คำนวน Pro credit=========
                if (SumMS_Price > ProCreditMoney && ProCreditMoney != 0) OverProCredit = true;
                else OverProCredit = false;
                //===============คำนวน Pro credit=========
                //if (OverProCredit)
                //{
                //    if (SORef + "" == "")
                //    {
                //        SalePriceNew = 0;
                //        SumMS_Price = 0;
                //        if (Utility.PopMsg(Utility.EnuMsgType.MsgTypeConfirmYesNo, Statics.OverProCredit) == DialogResult.Yes)
                //        {
                //            CallFormRef(Statics.CallMode.Ref);
                //            ProCreditRemark = string.Format("ยอดยกไป SO ใหม่ {0}",ProCreditRemain.ToString("###,###,###.##"));
                //            dataGridViewSelectList.Rows.RemoveAt(dataGridViewSelectList.Rows.Count - 1);
                //            SaveMedical();
                //        }
                //        else
                //        {
                //        }
                //    }

                //    //SumPriceMedicalOrder();

                //    OverProCredit = false;
                //}
                if (dataGridViewSelectList.RowCount <= 1) ProCreditRemain = ProCreditMoney;
                else
                {
                    //ProCreditRemain = (ProCreditMoney - SumMS_Price) - SalePriceNew;//เอาออก 2018-03-14 เพราะ Gift
                    if (radioButtonMO.Checked == false)
                        ProCreditRemain = PriceNormal;
                    else
                    {
                        if ((PRO_CalType == "P" || PRO_CalType == "A") && ProDiscountPercen > 0)
                            ProCreditRemain = (ProCreditMoney - PriceNormal);//20-09-2019 ใช้ราคาหลังส่วนลด ถ้า if (PRO_CalType == "P") ใช้ราคาเต็มPriceNormal; แต่ถ้า ไม่มี% ให้ใช้ราคาหลังหักส่วนลด
                        else
                            ProCreditRemain = (ProCreditMoney - SumAllTypeSalePrice);//20-09-2019 ใช้ราคาหลังส่วนลด ถ้า if (PRO_CalType == "P") ใช้ราคาเต็ม
                    }
                    //ProCreditRemain = (ProCreditMoney - SumMS_Price) - SalePriceNew;


                }

                //lbProCredit.Text = string.Format("ยอดเงินคงเหลือ/Credit {0} บาท/Bth.", (ProCreditMoney-SalePriceNew) == 0 ? "0" : (ProCreditMoney-SalePriceNew).ToString("###,###,###.##"));
                lbProCredit.Text = string.Format("Balances/Credit ({0}/{1}) บาท/Bth. {2}", (ProCreditRemain) == 0 ? "0" : (ProCreditRemain).ToString("###,###,###.##"), ProCreditMoney.ToString("###,###,###.##"), ProCreditRemark);
                txtPriceTotal.Text = SumAllTypeSalePrice == 0 ? "0" : SumAllTypeSalePrice.ToString("###,###,###.##");//เงินหลังหักส่วนลด
                textBoxNormal.Text = PriceNormal.ToString("###,###,###.##");
                ISEndEdit = false;
                //setRowNumber(dataGridViewSelectList);
                CheckAmountForProFix_Amount(dblAmount);
            }
            catch (Exception ex)
            {

            }

        }
        private void CheckAmountForProFix_Amount(decimal dblAmount)
        {
            try
            {

                if (PRO_CalType == "A")//Pro amount
                {
                    AllAmount = 0;
                    foreach (DataGridViewRow row in dataGridViewSelectList.Rows)
                    {
                        if (row.Visible)
                        {
                            AllAmount += row.Cells["Amount"].Value + "" == "" ? 0 : decimal.Parse(row.Cells["Amount"].Value + "");
                            //=====================
                            //DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                            //ch1 = (DataGridViewCheckBoxCell)dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells["ChkPRO"];
                            //if (ch1.Value == null)
                            //    return;
                            //else
                            //{
                            //    if ((ch1.Value + "").ToLower() == "true")
                            //        ch1.Value = "false";
                            //    else
                            //        ch1.Value = "true";



                            //}
                            ////if (e.ColumnIndex == dataGridViewSelectList.Columns["SpecialPrice"].Index || e.ColumnIndex == dataGridViewSelectList.Columns["SpecialPrice"].Index || e.ColumnIndex == dataGridViewSelectList.Columns["ChkPRO"].Index)
                            //    //ISEndEdit = false;

                            ////SumPriceMedicalOrder();
                            //dataGridViewSelectList.CommitEdit(DataGridViewDataErrorContexts.Commit);
                            //dataGridViewSelectList.EndEdit();
                        }
                    }
                    if (ProFix_Amount <= 0)//Pro amount
                    {
                        MessageBox.Show("ติดต่อผู้ดูแลระบบ ตั้งค่าโปรโมชั่น", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        return;
                    }
                    if (AllAmount > ProFix_Amount)//Pro amount
                    {//ลบรายการสุดท้ายออกเพราะ จำนวนเกินโปรที่ตั้งไว้
                        MessageBox.Show("จำนวนรวม เกินโปรโมชั่น", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        btnSave.Visible = false;
                        //เตือนเฉยๆก่อน
                        //dataGridViewSelectList.AllowUserToAddRows = false;

                        //dataGridViewSelectList.Rows.RemoveAt(dataGridViewSelectList.Rows.Count - 1);
                        //SumPriceMedicalOrder();
                    }
                    else btnSave.Visible = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SumManualPriceMedicalOrder()
        {
            try
            {
                //ProCreditRemark = "";
                if (dataGridViewSelectList.Rows.Count == 0) return;
                SalePriceNew = 0;
                SumMS_Price = 0;
                dblAmount = 0;
                decimal p = 0;
                //ราคารวม procredit
                //SalePriceNew = dataGridViewSelectList.Rows.Cast<DataGridViewRow>().Sum(row => row.Cells["PriceTotal"].Value + "" == "" ? 0 : decimal.Parse(row.Cells["PriceTotal"].Value + ""));
                foreach (DataGridViewRow row in dataGridViewSelectList.Rows)
                {
                    if (row.Visible)
                    {
                        SalePriceNew += row.Cells["PriceTotal"].Value + "" == "" ? 0 : decimal.Parse(row.Cells["PriceTotal"].Value + "");
                        dblAmount = row.Cells["Amount"].Value + "" == "" ? 0 : decimal.Parse(row.Cells["Amount"].Value + "");
                        p = row.Cells["Price/Unit"].Value + "" == "" ? 0 : decimal.Parse(row.Cells["Price/Unit"].Value + "");
                        SumMS_Price += (dblAmount * p);//row.Cells["Price/Unit"].Value + "" == "" ? 0 : decimal.Parse(row.Cells["Price/Unit"].Value + "");
                    }

                }
                //===============คำนวน Pro credit=========
                if (SumMS_Price > ProCreditMoney && ProCreditMoney != 0) OverProCredit = true;
                else OverProCredit = false;
                //===============คำนวน Pro credit=========
                if (OverProCredit)
                {


                    if (SORef + "" == "")
                    {
                        dataGridViewSelectList.Rows.RemoveAt(dataGridViewSelectList.Rows.Count - 1);
                        SalePriceNew = 0;
                        SumMS_Price = 0;
                        if (DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirmYesNo, Statics.OverProCredit) == DialogResult.Yes)
                        {
                            CallFormRef(Statics.CallMode.Ref);
                            ProCreditRemark = string.Format("ยอดยกไป SO ใหม่ {0}", ProCreditRemain.ToString("###,###,###.##"));
                            SaveMedical();

                        }
                        else
                        {
                        }
                    }
                    SumPriceMedicalOrder();
                    OverProCredit = false;
                }
                if (dataGridViewSelectList.RowCount <= 1) ProCreditRemain = ProCreditMoney;
                else ProCreditRemain = ProCreditMoney - SalePriceNew;

                //lbProCredit.Text = string.Format("ยอดเงินคงเหลือ/Credit {0} บาท/Bth.", (ProCreditMoney-SalePriceNew) == 0 ? "0" : (ProCreditMoney-SalePriceNew).ToString("###,###,###.##"));
                lbProCredit.Text = string.Format("Balances/Credit ({0}/{1}) บาท/Bth. {2}", (ProCreditRemain) == 0 ? "0" : (ProCreditRemain).ToString("###,###,###.##"), ProCreditMoney.ToString("###,###,###.##"), ProCreditRemark);
                txtPriceTotal.Text = SalePriceNew == 0 ? "0" : SalePriceNew.ToString("###,###,###.##");
            }
            catch (Exception ex)
            {

            }

        }
        private void CallFormRef(Statics.CallMode cMode)
        {
            //GetPendingBySO
            DataTable dt = new Business.MedicalSupplies().GetPendingBySO(txtSONo.Text).Tables[0];
            if (dt.Rows.Count <= 0 || dt.Rows[0]["Pending"] + "" == "")
            {
                // MessageBox.Show("No Pending", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //return;
            }
            Statics.frmMedicalOrderSettingPro = new FrmMedicalOrderSettingPro();

            Statics.frmMedicalOrderSettingPro.FormType = DerUtility.AccessType.Insert;
            Statics.frmMedicalOrderSettingPro.Text = Text + Statics.StrNewRow;
            Statics.frmMedicalOrderSettingPro.SORef = txtSONo.Text;

            Statics.frmMedicalOrderSettingPro.ProCreditRemain = dt.Rows.Count <= 0 ? 0 : Convert.ToDecimal(dt.Rows[0]["Pending"] + "");
            Statics.frmMedicalOrderSettingPro.RefCN = CN;
            Statics.frmMedicalOrderSettingPro.CN = CN;
            Statics.frmMedicalOrderSettingPro.RefCN_Name = txtCustomerName.Text;
            Statics.frmMedicalOrderSettingPro.EN_COM1 = comboBoxCommission1.SelectedValue + "";
            Statics.frmMedicalOrderSettingPro.EN_COM2 = comboBoxCommission2.SelectedValue + "";
            Statics.frmMedicalOrderSettingPro.DR_COM = comboBoxByDr.SelectedValue + "";
            Statics.frmMedicalOrderSettingPro.BranchID = cboBranch.SelectedValue + "";


            Statics.frmMedicalOrderSettingPro.customerType = customerType;

            string PRO_Dept = "";
            //  string PRO_CodeGift = "";
            bool ISCheck = false;
            string ms_code = "";

            if (dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells["Other"].Value + "" == "Y")
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "รายการนี้ถูกใช้ไปแล้ว");
                return;
            }
            else//==============ใช้ code ที่ ติ๊ก  เช็คก่อน ว่าเป็น giff
            {
                COUPON_Price = dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells["PriceTotal"].Value + "" == "" ? 0 : Convert.ToDecimal(dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells["PriceTotal"].Value + "");
                COUPON_Pro = dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells["COUPON_Pro"].Value + "";
                ms_code = dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells["Code"].Value + "";
                Statics.frmMedicalOrderSettingPro.MS_CodeRef = ms_code;
                Statics.frmMedicalOrderSettingPro.ListOrderRef = dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells["ListOrder"].Value + "";

                string[] lsCode = (ms_code).Split('|');
                if (lsCode.Count() > 1)
                {
                    foreach (DataGridViewRow Pitem in dgvPromotionList.Rows)//Promotion
                    {
                        if (lsCode[0] == Pitem.Cells["PRO_Code"].Value + "")
                        {

                            PRO_Dept = Pitem.Cells["PRO_Dept"].Value + "";
                            PRO_CodeGift = Pitem.Cells["PRO_Code"].Value + "";
                            if (!PRO_CodeGift.Contains("G")) PRO_CodeGift = "";
                            //row.Cells["Other"].Value = "Y";
                            break;
                        }
                    }
                }
            }

            if (COUPON_Pro.Length > 4)
                PRO_CodeGift = COUPON_Pro;

            Statics.frmMedicalOrderSettingPro.PRO_CodeGift = PRO_CodeGift;
            if (PRO_CodeGift.Length > 4)
                Statics.frmMedicalOrderSettingPro.ProCreditRemain = COUPON_Price;

            Statics.frmMedicalOrderSettingPro.AddMoney = AddMoney;

            Statics.frmMedicalOrderSettingPro.BackColor = Color.FromArgb(255, 230, 217);
            Statics.frmMedicalOrderSettingPro.Show(Statics.frmMain.dockPanel1);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirm, "ยืนยันการบันทึกข้อมูล \"Confirm Save ?\"") == DialogResult.OK)
            {
                if (cboBranch.SelectedValue == "")
                {
                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "กรุณาระบุ \"ชื่อสาขา \" ก่อนทำการบันทึกข้อมูล \"Please Select Branch\"");
                    return;
                }
                if (string.IsNullOrEmpty(CN))
                {
                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "กรุณาระบุ \"ชื่อลูกค้า \" ก่อนทำการบันทึกข้อมูล \"Please Select Customer\"");
                    return;
                }
                if (radioButtonSO.Checked && txtSONo.Text.Trim().Length <= 12)
                {
                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "SO ไม่ถูกต้อง คลิกเลือก แผนกอีกครั้ง");
                    return;
                }
                if (radioButtonMO.Checked && txtMO.Text.Trim().Length <= 12)
                {
                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "MO ไม่ถูกต้อง คลิกเลือก แผนกอีกครั้ง");
                    return;
                }

                if (FormType == DerUtility.AccessType.Update)
                {

                }
                else
                {
                    if (txtMO.Text.Trim() != "")
                    {
                        if (MoSubType == "ROOM")
                        {
                            using (var context = new EntitiesOPD_System())
                            {
                                var getRoomMO = context.MedicalOrders.Where(x => x.Room_Status == true).Take(1).OrderByDescending(x => x.ID).FirstOrDefault();
                                int maxid = getRoomMO != null ? Convert.ToInt32(getRoomMO.SONo.Substring(12, 4).ToString()) : 0;
                                var strCheck = moso + MoSubType + "-" + ((DateTime.Now.Year + 543).ToString().Substring(2, 2) + (DateTime.Now.Month).ToString("0#") + (maxid + 1).ToString("000#")).ToString();
                                this.idMax = strCheck;
                            }
                        }
                        else
                        {
                            DataTable dt = new Business.MedicalSupplies().CheckMOCode(txtMO.Text, true).Tables[0];
                            if (dt.Rows.Count > 0)
                            {
                                this.idMax = UtilityBackEnd.GenMaxSeqnoValues(moso + MoSubType + "-");
                                this.txtMO.Text = this.idMax.Replace("VNM", moso);
                                this.idMax = this.idMax.Replace(moso, "").Replace("VNM", "");
                                //MessageBox.Show("MO Is already.\"New : " + txtMO.Text + "\"Please Save again\"");
                                MessageBox.Show(string.Format("MO is already.{0}New:{1} Please Save again.", Environment.NewLine, txtMO.Text));

                                return;
                            }
                        }
                    }
                    if (txtMO.Text.Trim() == "" && txtSONo.Text.Trim() != "")
                    {
                        if (MoSubType == "ROOM")
                        {
                            using (var context = new EntitiesOPD_System())
                            {

                                var getRoomMO = context.MedicalOrders.Where(x => x.Room_Status == true).Take(1).OrderByDescending(x => x.ID).FirstOrDefault();
                                int maxid = getRoomMO != null ? Convert.ToInt32(getRoomMO.SONo.Substring(12, 4).ToString()) : 0;
                                var strCheck = moso + MoSubType + "-" + ((DateTime.Now.Year + 543).ToString().Substring(2, 2) + (DateTime.Now.Month).ToString("0#") + (maxid + 1).ToString("000#")).ToString();
                                this.idMax = strCheck;
                            }
                        }
                        else
                        {
                            DataTable dt = new Business.MedicalSupplies().CheckMOCode(txtSONo.Text, false).Tables[0];
                            if (dt.Rows.Count > 0)
                            {
                                this.idMax = UtilityBackEnd.GenMaxSeqnoValues(moso + MoSubType + "-");
                                this.txtSONo.Text = this.idMax.Replace("VNM", moso);
                                this.idMax = this.idMax.Replace(moso, "").Replace("VNM", "");
                                MessageBox.Show(string.Format("SO is already.{0}New:{1} Please Save again.", Environment.NewLine, txtSONo.Text));
                                return;
                            }
                        }
                    }
                }
                if (comboBoxCommission1.SelectedValue + "" == "" && comboBoxCommission2.SelectedValue + "" == "")
                {
                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "Please Select Sale consult.");

                    return;
                }
                if (txtSORefAccount.Text + "" == "" && radioButtonMO.Checked == false)
                {
                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "กรุณาระบุ \"เลขที่ใบยา.\"");
                    return;
                }
                //if (HowYouhearInfo == null || !HaveHowYouHear())
                //{
                //    SHowHowdidyouHear();
                //    if (!HaveHowYouHear()) return;
                //}


                SaveMedical();
            }
        }
        private void SaveMedical()
        {
            try
            {
                using (var context = new EntitiesOPD_System())
                {
                    int? intStatus = 0;
                    Entity.MedicalOrder info;
                    Entity.SupplieTrans supplieInfo;
                    Entity.SupplieTransPro supplieInfoPro;
                    Entity.MedicalOrderDoc medDocInfo;
                    List<Entity.SupplieTrans> listSuppleTrans = new List<Entity.SupplieTrans>();
                    List<Entity.SupplieTransPro> listSuppleTransPro = new List<Entity.SupplieTransPro>();
                    List<Entity.MedicalOrderDoc> listMedicalOrderDoc = new List<Entity.MedicalOrderDoc>();
                    double SpecialPrice = 0;
                    info = new Entity.MedicalOrder();
                    info.CN = CN;

                    info.CreateBy = Userinfo.EN;
                    info.Remark = ProCreditRemark + " " + txtRemark.Text;
                    info.SalePrice = txtPriceTotal.Text.Trim() == "" ? 0 : decimal.Parse(txtPriceTotal.Text.Trim());
                    info.MedStatus_Code = MedStatus_Code;
                    info.EM_COM1 = comboBoxCommission1.SelectedValue + "";
                    info.EM_COM2 = comboBoxCommission2.SelectedValue + "";
                    info.DR_COM = comboBoxByDr.SelectedValue + "";

                    info.MOType = MOType;
                    info.PRO_Code = PRO_Code;
                    info.OldKey = checkBoxOld.Checked ? "Y" : "";
                    info.BranchId = cboBranch.SelectedValue + "";
                    info.ProCreditRemain = ProCreditRemain;
                    List<string> LsMS_Code = new List<string>();
                    int consult = 0;
                    int ms = 0;

                    foreach (DataGridViewRow item in dataGridViewSelectListPro.Rows)//Promotion
                    {
                        supplieInfoPro = new Entity.SupplieTransPro();
                        supplieInfoPro.Pro_Code = item.Cells["Code"].Value + "";
                        supplieInfoPro.Amount = item.Cells["Amount"].Value + "" == "" ? 0 : decimal.Parse(item.Cells["Amount"].Value + "");
                        supplieInfoPro.Pro_Price = Convert.ToDouble(string.IsNullOrEmpty(item.Cells["Price/Unit"].Value + "") ? "0" : item.Cells["Price/Unit"].Value + "");


                        //DataGridViewCheckBoxCell chkCom = item.Cells["ChkCom"] as DataGridViewCheckBoxCell;
                        //    supplieInfoPro.Complimentary = Convert.ToBoolean(chkCom.Value) == false ? "N" : "Y";
                        //    //DataGridViewCheckBoxCell chkMar = item.Cells["ChkMar"] as DataGridViewCheckBoxCell;
                        //    supplieInfoPro.MarketingBudget = item.Cells["MKTBudget"].Value + ""; //Convert.ToBoolean(chkMar.Value) == false ? "N" : "Y";
                        //    chkCom = item.Cells["ChkSub"] as DataGridViewCheckBoxCell;
                        //    supplieInfoPro.Subject = Convert.ToBoolean(chkCom.Value) == false ? "N" : "Y";
                        //    //DataGridViewCheckBoxCell chkGift = item.Cells["ChkGiftv"] as DataGridViewCheckBoxCell;
                        //    supplieInfoPro.Gift = item.Cells["GiftVoucher"].Value + ""; //Convert.ToBoolean(chkGift.Value) == false ? "N" : "Y";
                        //    supplieInfoPro.GiftNumber = item.Cells["GiftNumber"].Value + "";
                        //    //string cboMKT = dataGridViewSelectList.Rows[e.RowIndex].Cells["MKTBudget"].Value + "";
                        //    chkCom = item.Cells["ChkBeforeAfter"] as DataGridViewCheckBoxCell;
                        //    supplieInfoPro.BeforeAfter = Convert.ToBoolean(chkCom.Value) == false ? "N" : "Y";
                        //    chkCom = item.Cells["ChkExtras_sale"] as DataGridViewCheckBoxCell;
                        //    supplieInfoPro.Extras_sale = Convert.ToBoolean(chkCom.Value) == false ? "N" : "Y";
                        //    chkCom = item.Cells["ChkVIP"] as DataGridViewCheckBoxCell;
                        //    supplieInfoPro.VIP = Convert.ToBoolean(chkCom.Value) == false ? "N" : "Y";

                        //supplieInfoPro.SpecialPrice = Convert.ToDouble(string.IsNullOrEmpty(item.Cells["SpecialPrice"].Value + "") ? "0" : item.Cells["SpecialPrice"].Value + "");


                        supplieInfoPro.Note = item.Cells["Note"].Value + "";
                        //supplieInfoPro.ExpireDate = item.Cells["ExpireDate"].Value + "" == "" ? DateTime.Now.AddYears(1).ToString() : item.Cells["ExpireDate"].Value + "";
                        supplieInfoPro.ListOrder = item.Cells["ListOrder"].Value + "";
                        supplieInfoPro.ListMS_Code = item.Cells["ListMS_Code"].Value + "";
                        listSuppleTransPro.Add(supplieInfoPro);

                    }
                    //=======สำหรับ Gift voucher===================
                    foreach (DataGridViewRow item in dataGridViewSelectList.Rows)//product
                    {
                        string ms_code = item.Cells["Code"].Value + "";
                        string PRO_Dept = "";
                        string PRO_CodeGift = "";
                        string[] lsCode = (ms_code).Split('|');
                        if (lsCode.Count() > 1)
                        {
                            foreach (DataGridViewRow Pitem in dgvPromotionList.Rows)//Promotion
                            {
                                if (lsCode[0] == Pitem.Cells["PRO_Code"].Value + "")
                                {
                                    PRO_Dept = Pitem.Cells["PRO_Dept"].Value + "";
                                    PRO_CodeGift = Pitem.Cells["PRO_Code"].Value + "";
                                    break;
                                }
                            }
                        }


                        string section = ms_code.Substring(0, 3);
                        if (section.ToLower() == "cae" || section.ToLower() == "cwe" || section.ToLower() == "csu")
                        {
                            consult++;
                        }
                        ms++;
                        LsMS_Code.Add(ms_code);
                        string[] CodeArr = (ms_code).Split(':');
                        string[] AmountArr = (item.Cells["Amount"].Value + "").Split(':');
                        string[] UsedArr = (item.Cells["Used"].Value + "").Split(':');
                        string[] OtherArr = (item.Cells["Other"].Value + "").Split(':');
                        if (CodeArr.Length > 1)
                        {
                            for (int i = 0; i < CodeArr.Length; i++)
                            {
                                supplieInfo = new Entity.SupplieTrans();
                                supplieInfo.PRO_Dept = PRO_Dept;
                                supplieInfo.PRO_Code = PRO_CodeGift;
                                supplieInfo.SORef = SORef;
                                supplieInfo.MS_CodeRef = MS_CodeRef;
                                supplieInfo.ListOrderRef = ListOrderRef;

                                supplieInfo.MS_Code = CodeArr[i];
                                supplieInfo.SONo = txtSONo.Text;
                                supplieInfo.Amount = decimal.Parse(AmountArr[i]);
                                //DataGridViewCheckBoxCell chk = item.Cells["ChkUse"] as DataGridViewCheckBoxCell;
                                bool chk = true;
                                supplieInfo.FlagUse = item.Cells["Other"].Value + "";//?Convert.ToBoolean(chk) == false ? "1" : "0"; //1 = ใช้เลย 0 ยังไม่ใช้
                                                                                     //supplieInfo.NumOfUse = Convert.ToBoolean(chk) == false  // yai  comment
                                                                                     //                           ? decimal.Parse(AmountArr[i])
                                                                                     //                           : decimal.Parse(UsedArr[i]);

                                supplieInfo.NumOfUse = 0;// decimal.Parse(AmountArr[i]);
                                supplieInfo.PriceAfterDis = Convert.ToDecimal(string.IsNullOrEmpty(item.Cells["PriceTotal"].Value + "") ? "0" : item.Cells["PriceTotal"].Value + "");

                                if (i < OtherArr.Length && OtherArr[i] != "")
                                {
                                    supplieInfo.FreeAmount = decimal.Parse(OtherArr[i]);
                                }
                                DataGridViewCheckBoxCell chkCom = item.Cells["ChkCom"] as DataGridViewCheckBoxCell;
                                supplieInfo.Complimentary = Convert.ToBoolean(chkCom.Value) == false ? "N" : "Y";
                                //DataGridViewCheckBoxCell chkMar = item.Cells["ChkMar"] as DataGridViewCheckBoxCell;
                                supplieInfo.MarketingBudget = item.Cells["MKTBudget"].Value + ""; //Convert.ToBoolean(chkMar.Value) == false ? "N" : "Y";
                                chkCom = item.Cells["ChkSub"] as DataGridViewCheckBoxCell;
                                supplieInfo.Subject = Convert.ToBoolean(chkCom.Value) == false ? "N" : "Y";
                                //DataGridViewCheckBoxCell chkGift = item.Cells["ChkGiftv"] as DataGridViewCheckBoxCell;
                                supplieInfo.Gift = item.Cells["GiftVoucher"].Value + ""; //Convert.ToBoolean(chkGift.Value) == false ? "N" : "Y";
                                                                                         //string cboMKT = dataGridViewSelectList.Rows[e.RowIndex].Cells["MKTBudget"].Value + "";
                                chkCom = item.Cells["ChkBeforeAfter"] as DataGridViewCheckBoxCell;
                                supplieInfo.BeforeAfter = Convert.ToBoolean(chkCom.Value) == false ? "N" : "Y";
                                chkCom = item.Cells["ChkExtras_sale"] as DataGridViewCheckBoxCell;
                                supplieInfo.Extras_sale = Convert.ToBoolean(chkCom.Value) == false ? "N" : "Y";
                                chkCom = item.Cells["ChkVIP"] as DataGridViewCheckBoxCell;
                                supplieInfo.VIP = Convert.ToBoolean(chkCom.Value) == false ? "N" : "Y";
                                chkCom = item.Cells["ChkPRO"] as DataGridViewCheckBoxCell;
                                supplieInfo.PRO_MDiscount = Convert.ToBoolean(chkCom.Value) == false ? "N" : "Y";

                                try
                                {
                                    supplieInfo.FeeRate = Convert.ToDouble(string.IsNullOrEmpty(item.Cells["FeeRate"].Value + "") ? "0" : item.Cells["FeeRate"].Value + "");
                                    supplieInfo.FeeRate2 = Convert.ToDouble(string.IsNullOrEmpty(item.Cells["FeeRate2"].Value + "") ? "0" : item.Cells["FeeRate2"].Value + "");
                                }
                                catch (Exception)
                                {

                                    // throw;
                                }
                                supplieInfo.Note = item.Cells["Note"].Value + "";
                                supplieInfo.MergStatus = item.Cells["Code"].Value + "";
                                supplieInfo.ListOrder = item.Cells["ListOrder"].Value + "";

                                chkCom = item.Cells["chkSaleCom"] as DataGridViewCheckBoxCell;
                                supplieInfo.SaleCom = Convert.ToBoolean(chkCom.Value) == false ? "" : "Y";

                                chkCom = item.Cells["chkByDr"] as DataGridViewCheckBoxCell;
                                supplieInfo.ByDr = Convert.ToBoolean(chkCom.Value) == false ? "" : "Y";



                                chkCom = item.Cells["chkCanceled"] as DataGridViewCheckBoxCell;
                                supplieInfo.Canceled = Convert.ToBoolean(chkCom.Value) == false ? "" : "Y";

                                supplieInfo.FreeType = item.Cells["Free"].Value + "";
                                supplieInfo.AmountPro = item.Cells["AmountPro"].Value + "";
                                supplieInfo.PricePerPro = item.Cells["PricePerPro"].Value + "";

                                listSuppleTrans.Add(supplieInfo);

                                if (supplieInfo.ByDr == "Y" && (comboBoxByDr.SelectedValue + "").Length < 5)
                                {
                                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "กรุณาระบุ \"ชื่อแพทย์.\"");
                                    return;
                                }
                            }
                        }
                        else
                        {
                            supplieInfo = new Entity.SupplieTrans();
                            supplieInfo.MS_Code = item.Cells["Code"].Value + "";
                            supplieInfo.Amount = item.Cells["Amount"].Value + "" == "" ? 0 : decimal.Parse(item.Cells["Amount"].Value + "");
                            supplieInfo.PRO_Dept = PRO_Dept;
                            supplieInfo.PRO_Code = PRO_CodeGift;
                            supplieInfo.SORef = SORef;
                            supplieInfo.MS_CodeRef = MS_CodeRef;
                            supplieInfo.ListOrderRef = ListOrderRef;
                            //DataGridViewCheckBoxCell chk = item.Cells["ChkUse"] as DataGridViewCheckBoxCell;
                            bool chk = true;
                            supplieInfo.FlagUse = item.Cells["Other"].Value + ""; //Convert.ToBoolean(chk) == false ? "1" : "0"; //1 = ใช้เลย 0 ยังไม่ใช้
                            supplieInfo.NumOfUse = Convert.ToBoolean(chk) == false
                                ? item.Cells["Amount"].Value + "" == "" ? 0 : decimal.Parse(item.Cells["Amount"].Value + "")
                                : item.Cells["Used"].Value + "" == "" ? 0 : decimal.Parse(item.Cells["Used"].Value + "");
                            //if (!string.IsNullOrEmpty(item.Cells["Other"].Value + ""))
                            //{
                            //    supplieInfo.FreeAmount = item.Cells["Other"].Value + "" == "" ? 0 : decimal.Parse(item.Cells["Other"].Value + "");
                            //}
                            DataGridViewCheckBoxCell chkCom = item.Cells["ChkCom"] as DataGridViewCheckBoxCell;
                            supplieInfo.Complimentary = Convert.ToBoolean(chkCom.Value) == false ? "N" : "Y";
                            //DataGridViewCheckBoxCell chkMar = item.Cells["ChkMar"] as DataGridViewCheckBoxCell;
                            supplieInfo.MarketingBudget = item.Cells["MKTBudget"].Value + ""; //Convert.ToBoolean(chkMar.Value) == false ? "N" : "Y";
                            chkCom = item.Cells["ChkSub"] as DataGridViewCheckBoxCell;
                            supplieInfo.Subject = Convert.ToBoolean(chkCom.Value) == false ? "N" : "Y";
                            //DataGridViewCheckBoxCell chkGift = item.Cells["ChkGiftv"] as DataGridViewCheckBoxCell;
                            supplieInfo.Gift = item.Cells["GiftVoucher"].Value + ""; //Convert.ToBoolean(chkGift.Value) == false ? "N" : "Y";
                            supplieInfo.GiftNumber = item.Cells["GiftNumber"].Value + "";
                            //string cboMKT = dataGridViewSelectList.Rows[e.RowIndex].Cells["MKTBudget"].Value + "";
                            chkCom = item.Cells["ChkBeforeAfter"] as DataGridViewCheckBoxCell;
                            supplieInfo.BeforeAfter = Convert.ToBoolean(chkCom.Value) == false ? "N" : "Y";
                            chkCom = item.Cells["ChkExtras_sale"] as DataGridViewCheckBoxCell;
                            supplieInfo.Extras_sale = Convert.ToBoolean(chkCom.Value) == false ? "N" : "Y";
                            chkCom = item.Cells["ChkVIP"] as DataGridViewCheckBoxCell;
                            supplieInfo.VIP = Convert.ToBoolean(chkCom.Value) == false ? "N" : "Y";
                            chkCom = item.Cells["ChkPRO"] as DataGridViewCheckBoxCell;
                            supplieInfo.PRO_MDiscount = Convert.ToBoolean(chkCom.Value) == false ? "N" : "Y";

                            supplieInfo.MergStatus = item.Cells["Code"].Value + "";
                            supplieInfo.PriceAfterDis = Convert.ToDecimal(string.IsNullOrEmpty(item.Cells["PriceTotal"].Value + "") ? "0" : item.Cells["PriceTotal"].Value + "");
                            try
                            {
                                supplieInfo.FeeRate = Convert.ToDouble(string.IsNullOrEmpty(item.Cells["FeeRate"].Value + "") ? "0" : item.Cells["FeeRate"].Value + "");
                                supplieInfo.FeeRate2 = Convert.ToDouble(string.IsNullOrEmpty(item.Cells["FeeRate2"].Value + "") ? "0" : item.Cells["FeeRate2"].Value + "");
                            }
                            catch (Exception)
                            {
                            }
                            supplieInfo.SpecialPrice = SpecialPrice = Convert.ToDouble(string.IsNullOrEmpty(item.Cells["SpecialPrice"].Value + "") ? "0" : item.Cells["SpecialPrice"].Value + "");
                            supplieInfo.MS_Price = Convert.ToDouble(string.IsNullOrEmpty(item.Cells["Price/Unit"].Value + "") ? "0" : item.Cells["Price/Unit"].Value + "");

                            supplieInfo.Note = item.Cells["Note"].Value + "";
                            supplieInfo.ExpireDate = item.Cells["ExpireDate"].Value + "" == "" ? DateTime.Now.AddYears(1).ToString() : item.Cells["ExpireDate"].Value + "";
                            supplieInfo.ListOrder = item.Cells["ListOrder"].Value + "";

                            chkCom = item.Cells["chkSaleCom"] as DataGridViewCheckBoxCell;
                            supplieInfo.SaleCom = Convert.ToBoolean(chkCom.Value) == false ? "" : "Y";

                            chkCom = item.Cells["chkByDr"] as DataGridViewCheckBoxCell;
                            supplieInfo.ByDr = Convert.ToBoolean(chkCom.Value) == false ? "" : "Y";

                            //chkCom = item.Cells["chkCanceled"] as DataGridViewCheckBoxCell;
                            //supplieInfo.Canceled = Convert.ToBoolean(chkCom.Value) == false ? "" : "Y";

                            supplieInfo.FreeType = item.Cells["Free"].Value + "";
                            supplieInfo.AmountPro = item.Cells["AmountPro"].Value + "";
                            supplieInfo.PricePerPro = item.Cells["PricePerPro"].Value + "";

                            listSuppleTrans.Add(supplieInfo);

                            if (supplieInfo.ByDr == "Y" && (comboBoxByDr.SelectedValue + "").Length < 5)
                            {
                                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "กรุณาระบุ \"ชื่อแพทย์.\"");
                                return;
                            }
                        }

                        if (consult == ms && SpecialPrice == 0) info.MedStatus_Code = "2";

                    }
                    Int64 idMaxFileInt = 0;
                    string idMaxFile = "";
                    foreach (DataGridViewRow item in dgvFile.Rows)
                    {
                        if (item.Cells["NewRow"].Value + "" == "True")
                        {
                            medDocInfo = new Entity.MedicalOrderDoc();
                            medDocInfo.FileName = item.Cells["FileName"].Value + "";
                            if (idMaxFileInt <= 0)
                            {
                                idMaxFile = UtilityBackEnd.GenMaxSeqnoValues("FIL");
                                idMaxFileInt = Convert.ToInt64(idMaxFile.Replace("FIL", ""));
                            }
                            else
                            {
                                idMaxFileInt += 1;
                                idMaxFile = "FIL" + idMaxFileInt;
                            }
                            FileInfo fn = new FileInfo(item.Cells["FilePath"].Value + "");
                            string KeyFileName = string.Format("{0}_{1}_{2}{3}", idMaxFile, SO, VN, fn.Extension);
                            medDocInfo.FileName = KeyFileName;
                            medDocInfo.Id = idMaxFile;
                            medDocInfo.FilePath = item.Cells["FilePath"].Value + "";
                            medDocInfo.Detail = item.Cells["Detail"].Value + "";
                            listMedicalOrderDoc.Add(medDocInfo);
                        }
                    }
                    info.SupplieTransInfo = listSuppleTrans.ToArray();
                    //================Update VV  if MO
                    foreach (KeyValuePair<string, FreeTrans> item in dicFreeTrans)
                    {
                        item.Value.VN = txtMO.Text;
                    }
                    List<FreeTrans> listFreeTrans = new List<FreeTrans>(dicFreeTrans.Values);
                    List<FreeTrans> listFreeTransDel = new List<FreeTrans>(dicFreeTransDel.Values);

                    //myDico.Values.SelectMany(c => c).ToList();
                    info.FreeTrans = listFreeTrans.ToArray();
                    info.FreeTransDel = listFreeTransDel.ToArray();
                    //dicFreeTrans.SelectMany(d => d.Value).ToList(); //dicFreeTrans.ToList(listFreeTrans);
                    info.SupplieTransProInfo = listSuppleTransPro.ToArray();
                    info.MedicalOrderDocInfo = listMedicalOrderDoc.ToArray();
                    //info.HowYouhearInfo = HowYouhearInfo;

                    //info.MedicalOrderUseTransesInfo = MedicalOrderUseTranss.ToArray();
                    info.VN = this.txtMO.Text.Trim();
                    this.VN = this.MO = this.txtMO.Text.Trim();

                    info.PriceTotalRef = (this.txtBalanceRef.Text.Trim() == "") ? 0M : Convert.ToDecimal(this.txtBalanceRef.Text.Replace(",", ""));

                    info.ListMS_Code = LsMS_Code;
                    info.AgenMemId = txtAgenMemID.Text.Trim();
                    info.AgenMemIdOPD = txtAgenMemIDOPD.Text.Trim();
                    info.UpdateBy = Userinfo.EN;
                    //info.CreateDate = dateTimePickerCreate.Value;
                    info.CreateDate = DateTime.Now;
                    info.UpdateDate = DateTime.Now;
                    this.SO = info.SONo = txtSONo.Text;

                    info.EN_COMS1 = comboBoxCommission1.SelectedValue + "";
                    info.EN_COMS2 = comboBoxCommission2.SelectedValue + "";
                    info.DR_COM = comboBoxByDr.SelectedValue + "";

                    // group member
                    info.dicMembersTran = dicMemberTran;
                    info.SORef = this.txtSoRef.Text;
                    info.SORefAccount = txtSORefAccount.Text;
                    info.Notes = txtNote.Text;

                    //if (string.IsNullOrEmpty(vn))
                    //{
                    intStatus = new Business.MedicalOrder().InsertMedicalOrder(info);
                    //}
                    //else
                    //{
                    //    info.VN = vn;
                    //    intStatus = new Business.MedicalOrder().UpdateMedicalOrder(info);
                    //}
                    var FK_MO_ID = 0;
                    if (PRO_Code.Contains("ROOM"))
                    {
                        if (String.IsNullOrEmpty(VN))
                        {
                            var updateSORoomStatus = context.MedicalOrders.Where(x => x.SONo == this.SO && x.CN == CN).FirstOrDefault();

                            if (updateSORoomStatus != null)
                            {
                                FK_MO_ID = updateSORoomStatus.ID;

                                updateSORoomStatus.Start_Date = dateTimePickerCreate.Value;
                                updateSORoomStatus.End_Date = dateTimePickerEnd.Value;
                                updateSORoomStatus.Room_Status = true;
                                context.SaveChanges();
                            }
                        }
                        else
                        {
                            var updateMORoomStatus = context.MedicalOrders.Where(x => x.VN == this.VN && x.CN == CN && x.MOType == "Y").FirstOrDefault();

                            if (updateMORoomStatus != null)
                            {
                                FK_MO_ID = updateMORoomStatus.ID;
                                updateMORoomStatus.Room_Status = true;
                                updateMORoomStatus.Start_Date = dateTimePickerCreate.Value;
                                updateMORoomStatus.End_Date = dateTimePickerEnd.Value;
                                context.SaveChanges();
                            }
                        }

                        foreach (DataGridViewRow item in dataGridViewSelectList.Rows)//product
                        {
                            string coderoom = item.Cells["Code"].Value + "";
                            var itemRoom = context.Master_Room.Where(x => x.Room_Code == coderoom.ToString()).Take(1).FirstOrDefault();

                            if (itemRoom != null)
                            {
                                var chkOldRoom = context.Room_Detail.Where(x => x.FK_Room_ID == itemRoom.ID && x.FK_MO_ID == FK_MO_ID && x.Is_Active == true).ToList();

                                foreach (var disroom in chkOldRoom)
                                {
                                    disroom.Is_Active = false;
                                    disroom.Update_By = Userinfo.EN;
                                    disroom.Update_Date = DateTime.Now;
                                    context.SaveChanges();
                                }

                                Room_Detail rd = new Room_Detail();
                                rd.FK_MO_ID = FK_MO_ID;
                                rd.FK_Room_ID = itemRoom.ID;
                                rd.Qty_Date = Convert.ToInt32(item.Cells["Room_Amount_Day"].Value ?? "0");
                                rd.Start_Date = Convert.ToDateTime(dateTimePickerCreate.Value);
                                rd.End_Date = Convert.ToDateTime(dateTimePickerEnd.Value);
                                rd.Is_Active = true;
                                rd.Create_By = Userinfo.EN;
                                rd.Create_Date = DateTime.Now;
                                context.Room_Detail.Add(rd);
                                context.SaveChanges();
                            }
                        }

                    }


                    if (intStatus > 0)
                    {
                        foreach (Entity.MedicalOrderDoc medicalOrderDoc in info.MedicalOrderDocInfo)
                        {
                            //Save File 
                            //string    idMaxFile = UtilityBackEnd.GenMaxSeqnoValues("FIL");
                            //  //string  strPrefix = idMaxFile.Substring(0, 7);
                            //  //double runNo = double.Parse(idMax.Substring(7, 4));
                            //  FileInfo fn = new FileInfo(medicalOrderDoc.FilePath);
                            //  string KeyFileName = string.Format("{0}_{1}_{2}{3}", idMaxFile, SO, VN, fn.Extension);
                            SaveImage(medicalOrderDoc.FileName, medicalOrderDoc.FilePath);
                            //if (BrowseFile.MovefileOther(medicalOrderDoc.FilePath, "MEDICALDOC", medicalOrderDoc.FileName))
                            //{

                            //}
                            //else
                            //{
                            //    MessageBox.Show("Save Image Fail.");
                            //}
                        }

                        if (!OverProCredit) DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, Statics.SaveComplete);

                        if (Statics.frmMedicalOrderList != null)
                        {
                            Statics.frmMedicalOrderList.txtSo.Text = txtSONo.Text;
                            Statics.frmMedicalOrderList.BindDataMedicalOrder(1);
                        }
                        COUPON_PRO_Code = "";
                        this.Close();
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DownLoadImage(string filenameWithExt)
        {
            try
            {
                string _imagetPath = string.Format(@"{0}\{1}\{2}\{3}", Application.StartupPath, "MEDICALDOC", CN, filenameWithExt);
                string Remote_imagetPath = string.Format(@"\MEDICALDOC\{0}\{1}", CN, filenameWithExt);
                /* Create Object Instance */
                string Remote_Folder = string.Format(@"{0}\MEDICALDOC\{1}\", Application.StartupPath, CN);
                DirectoryInfo df = new DirectoryInfo(Remote_Folder);
                if (!df.Exists)
                    df.Create();

                DermasterFtp ftpClient = new DermasterFtp(Entity.Userinfo.Server, Entity.Userinfo.ServerUser, Entity.Userinfo.ServerPass);
                //if (ftpClient.directoryListSimple(Remote_Folder).Length <= 1)
                //    ftpClient.createDirectory(Remote_Folder);
                /* Upload a File */
                //FileInfo f = new FileInfo(_imagetPath);
                //if (!f.Exists)
                /* Download a File */
                ftpClient.download(Remote_imagetPath, _imagetPath);

                /* Delete a File */
                //  ftpClient.delete("etc/test.txt");

                /* Rename a File */
                //  ftpClient.rename("etc/test.txt", "test2.txt");

                /* Create a New Directory */
                // ftpClient.createDirectory("etc/test");

                ///* Get the Date/Time a File was Created */
                //string fileDateTime = ftpClient.getFileCreatedDateTime("etc/test.txt");
                //Console.WriteLine(fileDateTime);

                ///* Get the Size of a File */
                //string fileSize = ftpClient.getFileSize("etc/test.txt");
                //Console.WriteLine(fileSize);

                ///* Get Contents of a Directory (Names Only) */
                //string[] simpleDirectoryListing = ftpClient.directoryListDetailed("/etc");
                //for (int i = 0; i < simpleDirectoryListing.C; i++) { Console.WriteLine(simpleDirectoryListing[i]); }

                ///* Get Contents of a Directory with Detailed File/Directory Info */
                //string[] detailDirectoryListing = ftpClient.directoryListDetailed("/etc");
                //for (int i = 0; i < detailDirectoryListing.Count(); i++) { Console.WriteLine(detailDirectoryListing[i]); }
                /* Release Resources */
                ftpClient = null;
                if (File.Exists(_imagetPath))
                    Process.Start(_imagetPath);
                else MessageBox.Show("File not found.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SaveImage(string keyIDFileNameWithExt, string _OrgimagePaht)
        {
            try
            {
                if (_OrgimagePaht == "") return;
                string Remote_imagetPath = "";
                Remote_imagetPath = string.Format(@"\MEDICALDOC\{0}\{1}", CN, keyIDFileNameWithExt);
                string Remote_Folder = string.Format(@"\MEDICALDOC\{0}\", CN);

                /* Create Object Instance */
                DermasterFtp ftpClient = new DermasterFtp(Entity.Userinfo.Server, Entity.Userinfo.ServerUser, Entity.Userinfo.ServerPass);
                if (ftpClient.directoryListSimple(Remote_Folder).Length <= 1)
                    ftpClient.createDirectory(Remote_Folder);
                /* Upload a File */
                ftpClient.upload(Remote_imagetPath, _OrgimagePaht);
                //FileInfo f = new FileInfo(_imagetPath);
                //if (!f.Exists)
                /* Download a File */
                //ftpClient.download(Remote_imagetPath, _OrgimagePaht);

                /* Delete a File */
                //  ftpClient.delete("etc/test.txt");

                /* Rename a File */
                //  ftpClient.rename("etc/test.txt", "test2.txt");

                /* Create a New Directory */
                // ftpClient.createDirectory("etc/test");

                ///* Get the Date/Time a File was Created */
                //string fileDateTime = ftpClient.getFileCreatedDateTime("etc/test.txt");
                //Console.WriteLine(fileDateTime);

                ///* Get the Size of a File */
                //string fileSize = ftpClient.getFileSize("etc/test.txt");
                //Console.WriteLine(fileSize);

                ///* Get Contents of a Directory (Names Only) */
                //string[] simpleDirectoryListing = ftpClient.directoryListDetailed("/etc");
                //for (int i = 0; i < simpleDirectoryListing.C; i++) { Console.WriteLine(simpleDirectoryListing[i]); }

                ///* Get Contents of a Directory with Detailed File/Directory Info */
                //string[] detailDirectoryListing = ftpClient.directoryListDetailed("/etc");
                //for (int i = 0; i < detailDirectoryListing.Count(); i++) { Console.WriteLine(detailDirectoryListing[i]); }
                /* Release Resources */
                ftpClient = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DeleteFileFTP(string keyIDFileNameWithExt)
        {
            try
            {
                //if (_OrgimagePaht == "") return;
                string Remote_imagetPath = "";
                Remote_imagetPath = string.Format(@"\MEDICALDOC\{0}\{1}", CN, keyIDFileNameWithExt);
                //string Remote_Folder = string.Format(@"\MEDICALDOC\{0}\", CN);

                /* Create Object Instance */
                DermasterFtp ftpClient = new DermasterFtp(Entity.Userinfo.Server, Entity.Userinfo.ServerUser, Entity.Userinfo.ServerPass);
                //if (ftpClient.directoryListSimple(Remote_Folder).Length <= 1)
                //    ftpClient.createDirectory(Remote_Folder);
                /* Upload a File */
                //ftpClient.upload(Remote_imagetPath, _OrgimagePaht);
                //FileInfo f = new FileInfo(_imagetPath);
                //if (!f.Exists)
                /* Download a File */
                //ftpClient.download(Remote_imagetPath, _OrgimagePaht);

                /* Delete a File */
                ftpClient.delete(Remote_imagetPath);

                /* Rename a File */
                //  ftpClient.rename("etc/test.txt", "test2.txt");

                /* Create a New Directory */
                // ftpClient.createDirectory("etc/test");

                ///* Get the Date/Time a File was Created */
                //string fileDateTime = ftpClient.getFileCreatedDateTime("etc/test.txt");
                //Console.WriteLine(fileDateTime);

                ///* Get the Size of a File */
                //string fileSize = ftpClient.getFileSize("etc/test.txt");
                //Console.WriteLine(fileSize);

                ///* Get Contents of a Directory (Names Only) */
                //string[] simpleDirectoryListing = ftpClient.directoryListDetailed("/etc");
                //for (int i = 0; i < simpleDirectoryListing.C; i++) { Console.WriteLine(simpleDirectoryListing[i]); }

                ///* Get Contents of a Directory with Detailed File/Directory Info */
                //string[] detailDirectoryListing = ftpClient.directoryListDetailed("/etc");
                //for (int i = 0; i < detailDirectoryListing.Count(); i++) { Console.WriteLine(detailDirectoryListing[i]); }
                /* Release Resources */
                ftpClient = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnDocument_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabControl.TabPages["tabAttachFile"];
        }

        private void FrmMedicalOrderSettingPro_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (COUPON_PRO_Code.Length > 4)
            {
                MessageBox.Show("Please save.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnSave.PerformClick();
                COUPON_PRO_Code = "";
            }
            Statics.frmMedicalOrderSettingPro = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            docFilePath = BrowseFile.BrowFileType("IMAGE");
            txtFilePath.Text = docFilePath;
            //if (docFilePath != "")
            //{
            //    //picCustImage.ImageLocation = _imageCustPath = imgPath;
            //    //_Changimage = true;
            //}

        }

        private void btnAddFile_BtnClick()
        {
            //info.Image = (_Changimage ? Path.GetFileName(_imageCustPath) : null);

            if (txtFilePath.Text != "")
            {
                if (txtFileName.Text == "")
                {
                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "กรุณาระบุชื่อไฟล์ \"Filename is empty\"");
                    return;
                }
                object[] myItems = {
                                    txtFilePath.Text,
                                    Path.GetFileName(txtFilePath.Text),
                                    txtFileName.Text,

                                    imageList1.Images[2],
                                    imageList1.Images[1],
                                    //imageList1.Images[9],
                                    //imageList1.Images[5],
                                    "True"
                                };
                dgvFile.Rows.Add(myItems);
                txtFilePath.Text = "";
                txtFileName.Text = "";
            }
        }

        private void dgvFile_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3)
                {
                    if (DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirm, "ยืนยันการลบไฟล์ \"Confirm delete.\"") == DialogResult.OK)
                    {
                        string Id = dgvFile.Rows[e.RowIndex].Cells["Id"].Value + "";
                        string RemotePart = dgvFile.Rows[e.RowIndex].Cells["FileName"].Value + "";
                        //string fnameFullFath = Properties.Settings.Default.ImagePathServer + "\\MEDICALDOC\\" +
                        //                       dgvFile.Rows[e.RowIndex].Cells["FileName"].Value + "";
                        DeleteFileFTP(RemotePart);
                        //BrowseFile.Deletefile(fnameFullFath);
                        var intStatus = new Business.MedicalOrder().DeleteFileName(Id, "DELETE");
                        dgvFile.Rows.RemoveAt(e.RowIndex);
                    }
                }
                if (e.ColumnIndex == 4)
                {

                    //string filePath _imagetPath= Properties.Settings.Default.ImagePathServer + "\\MEDICALDOC\\" + dgvFile.Rows[e.RowIndex].Cells["FileName"].Value + "";
                    DownLoadImage(dgvFile.Rows[e.RowIndex].Cells["FileName"].Value + "");

                }
            }
            catch (Exception ex)
            {

            }
        }

        //private void dataGridViewSelectList_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    // Can potentially throw an 'IndexOutOfRangeException' if not checked.4.    
        //    if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && (e.ColumnIndex == dataGridViewSelectList.Columns["BtnUse"].Index))
        //    {
        //        this.Cursor = Cursors.Hand;
        //    }
        //    else{Cursor = Cursors.Default;}
        //}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (COUPON_PRO_Code.Length > 4)
            {
                MessageBox.Show("Please save.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                COUPON_PRO_Code = "";
                btnSave.PerformClick();

            }

            Statics.frmMedicalOrderSettingPro = null;
            this.Close();
        }
        int currentRowIndex = 0;
        int currentColIndex = 0;
        private bool IsExpireDate(string str)
        {
            bool IsExpire = false;
            try
            {
                IsExpire = DateTime.Now > (str == "" ? DateTime.Now : Convert.ToDateTime(str));
            }
            catch (Exception)
            {


            }
            return IsExpire;
        }
        private void dataGridViewSelectList_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                currentRowIndex = e.RowIndex;
                currentColIndex = e.ColumnIndex;
                dataGridViewSelectList.BeginEdit(true);
                if (e.ColumnIndex == dataGridViewSelectList.Columns["ExpireDate"].Index)
                {
                    if (IsExpireDate(dataGridViewSelectList.Rows[e.RowIndex].Cells["ExpireDate"].Value + "") && !(Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN) && !Userinfo.IS_ADMIN_EDIT.Contains(Userinfo.EN))
                    {
                        MessageBox.Show("This Item Expired", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    PopDateTime pp = new PopDateTime();
                    DateTime d;
                    pp.SelecttDate = DateTime.TryParse(dataGridViewSelectList.Rows[e.RowIndex].Cells["ExpireDate"].Value + "", out d) ? d : DateTime.Now;
                    //pp.SelecttDate =Convert.ToDateTime(pp.SelecttDate.ToString("dd/MM/yyyy"));
                    if (pp.ShowDialog() == DialogResult.OK)
                    {
                        dataGridViewSelectList.Rows[e.RowIndex].Cells["ExpireDate"].Value = pp.SelecttDate.Date.ToString("yyyy/MM/dd");
                        dataGridViewSelectList.EndEdit();
                    }

                }
                if (e.ColumnIndex == dataGridViewSelectList.Columns["SpecialPrice"].Index || e.ColumnIndex == dataGridViewSelectList.Columns["SpecialPrice"].Index || e.ColumnIndex == dataGridViewSelectList.Columns["ChkPRO"].Index)
                    ISEndEdit = false;

                // if ((e.ColumnIndex == dataGridViewSelectList.Columns["ChkMove"].Index
                //|| e.ColumnIndex == dataGridViewSelectList.Columns["ChkUse"].Index
                //|| e.ColumnIndex == dataGridViewSelectList.Columns["ChkCom"].Index
                //|| e.ColumnIndex == dataGridViewSelectList.Columns["ChkBeforeAfter"].Index
                //|| e.ColumnIndex == dataGridViewSelectList.Columns["ChkSub"].Index
                //|| e.ColumnIndex == dataGridViewSelectList.Columns["ChkVIP"].Index
                //) && e.RowIndex != -1)
                // {
                //     dataGridViewSelectList.EndEdit();
                // }

            }
            catch (Exception ex)
            {

            }

        }
        private void MergItemLoad(DataGridViewRow item)
        {
            try
            {
                string msCode = "";
                string msName = "";
                string strAmount = "";
                string strNumCouse = "";
                string strTotal = "";
                string strUsed = "";
                string strBalance = "";
                string strPriceUnit = "";
                string strPriceTotal = "";
                double doublePriceTotal = 0;
                double doubleAmount = 0;
                double doublePriceUnit = 0;
                string strTab = "";

                List<Entity.SupplieTrans> listSup = new List<Entity.SupplieTrans>();
                rowsToDelete = new List<DataGridViewRow>();

                rowsToDelete.Add(item);

                if (msCode != "") msCode += ":";
                msCode += item.Cells["Code"].Value + "";

                if (msName != "") msName += ":";
                msName += item.Cells["Name"].Value + "";

                if (strAmount != "") strAmount += ":";
                strAmount += item.Cells["Amount"].Value + "";

                if (strNumCouse != "") strNumCouse += ":";
                strNumCouse += item.Cells["No./Course"].Value + "";

                if (strTotal != "") strTotal += ":";
                strTotal += item.Cells["Total"].Value + "";

                if (strUsed != "") strUsed += ":";
                strUsed += item.Cells["Used"].Value + "";

                if (strBalance != "") strBalance += ":";
                strBalance += item.Cells["Balance"].Value + "";

                if (strPriceUnit != "") strPriceUnit += ":";
                strPriceUnit += item.Cells["Price/Unit"].Value + "";

                if (strPriceTotal != "") strPriceTotal += ":";
                strPriceTotal += item.Cells["PriceTotal"].Value + "";

                //if (strTab != "") strTab += ":";

                if (strTab != "" && strTab != item.Cells["Tab"].Value + "")
                {
                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "ไม่สามารถรวมรายการได้ เนื่องจาก \"รายการไม่ใช่หมวดเดียวกัน\"\"Cannot merge.\"");
                    return;
                }
                else
                {
                    strTab = item.Cells["Tab"].Value + "";
                }
                doubleAmount = Convert.ToDouble(item.Cells["Amount"].Value + "");
                doublePriceUnit = Convert.ToDouble(item.Cells["Price/Unit"].Value + "");
                doublePriceTotal += doubleAmount * doublePriceUnit;

                if (!string.IsNullOrEmpty(vn))
                {
                    Entity.SupplieTrans supplieInfo = new Entity.SupplieTrans();
                    supplieInfo.VN = vn;
                    supplieInfo.MS_Code = item.Cells["Code"].Value + "";
                    listSup.Add(supplieInfo);
                }

                //foreach (DataGridViewRow row in rowsToDelete)
                //{
                //    dataGridViewSelectList.Rows.Remove(row);
                //}

                //Add New Row
                object[] myItems = {
                                        false,
                                        msCode,
                                        msName,
                                        strAmount,//จำนวนที่ซื้อ
                                        strNumCouse,//Num/Couse
                                        strTotal,//Total
                                        strUsed,//Use
                                        strBalance,//Balance
                                        strPriceUnit,//Price/Unit
                                        doublePriceTotal.ToString("###,###.##"),//PriceTotal
                                        imageList1.Images[0],
                                        //false,
                                        imageList1.Images[4],"",false,false,false,false,
                                        strTab
                            };
                dataGridViewSelectList.Rows.Add(myItems);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MergItem()
        {
            try
            {
                string msCode = "";
                string msName = "";
                string strAmount = "";
                string strNumCouse = "";
                string strTotal = "";
                string strUsed = "";
                string strBalance = "";
                string strPriceUnit = "";
                string strPriceTotal = "";
                double doublePriceTotal = 0;
                double doubleAmount = 0;
                double doublePriceUnit = 0;
                string strTab = "";

                List<Entity.SupplieTrans> listSup = new List<Entity.SupplieTrans>();
                rowsToDelete = new List<DataGridViewRow>();
                foreach (DataGridViewRow item in dataGridViewSelectList.Rows)
                {
                    DataGridViewCheckBoxCell chk = item.Cells["ChkMove"] as DataGridViewCheckBoxCell;
                    if (Convert.ToBoolean(chk.Value) == true)
                    {
                        rowsToDelete.Add(item);

                        if (msCode != "") msCode += ":";
                        msCode += item.Cells["Code"].Value + "";

                        if (msName != "") msName += ":";
                        msName += item.Cells["Name"].Value + "";

                        if (strAmount != "") strAmount += ":";
                        strAmount += item.Cells["Amount"].Value + "";

                        if (strNumCouse != "") strNumCouse += ":";
                        strNumCouse += item.Cells["No./Course"].Value + "";

                        if (strTotal != "") strTotal += ":";
                        strTotal += item.Cells["Total"].Value + "";

                        if (strUsed != "") strUsed += ":";
                        strUsed += item.Cells["Used"].Value + "";

                        if (strBalance != "") strBalance += ":";
                        strBalance += item.Cells["Balance"].Value + "";

                        if (strPriceUnit != "") strPriceUnit += ":";
                        strPriceUnit += item.Cells["Price/Unit"].Value + "";

                        //if (strPriceTotal != "") strPriceTotal += ":";
                        strPriceTotal = item.Cells["PriceTotal"].Value + "";

                        //if (strTab != "") strTab += ":";
                        if (item.Cells["Tab"].Value + "" != "SURGERY")
                        {
                            DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation,
                                            "ไม่สามารถรวมรายการได้ เนื่องจาก \"ไม่ใช่หมวด SURGERY\"");
                            return;
                        }
                        else if (strTab != "" && strTab != item.Cells["Tab"].Value + "")
                        {
                            DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "ไม่สามารถรวมรายการได้ เนื่องจาก \"รายการไม่ใช่หมวดเดียวกัน\"\"Cannot merge.\"");
                            return;
                        }

                        else
                        {
                            strTab = item.Cells["Tab"].Value + "";
                        }
                        doubleAmount = Convert.ToDouble(item.Cells["Amount"].Value + "");
                        doublePriceUnit = Convert.ToDouble(item.Cells["Price/Unit"].Value + "");
                        doublePriceTotal += doubleAmount * doublePriceUnit;

                        if (!string.IsNullOrEmpty(vn))
                        {
                            Entity.SupplieTrans supplieInfo = new Entity.SupplieTrans();
                            supplieInfo.VN = vn;
                            supplieInfo.MS_Code = item.Cells["Code"].Value + "";
                            listSup.Add(supplieInfo);
                        }
                    }
                }

                int? statusDel = new Business.MedicalSupplies().DeleteSupplies(listSup.ToArray());

                //if (statusDel == 1)
                //{
                foreach (DataGridViewRow row in rowsToDelete)
                {
                    dataGridViewSelectList.Rows.Remove(row);
                }

                //Add New Row
                object[] myItems = {
                                        false,
                                        msCode,
                                        msName,
                                        strAmount,//จำนวนที่ซื้อ
                                        strNumCouse,//Num/Couse
                                        strTotal,//Total
                                        strUsed,//Use
                                        strBalance,//Balance
                                        strPriceUnit,//Price/Unit
                                        doublePriceTotal.ToString("###,###.##"),//PriceTotal
                                        //imageList1.Images[0],
                                        //false,
                                        //imageList1.Images[4],
                                        "",false,false,false,false,
                                        strTab
                            };
                dataGridViewSelectList.Rows.Add(myItems);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void buttonMerg1_BtnClick()
        {
            MergItem();
            SumPriceMedicalOrder();
        }

        private void dgvWellness_AntiagingList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvWellness_AntiagingList.Rows.Count < 0 || dgvWellness_AntiagingList.CurrentRow == null) return;
            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
            ch1 = (DataGridViewCheckBoxCell)dgvWellness_AntiagingList.Rows[dgvWellness_AntiagingList.CurrentRow.Index].Cells[0];
            if (dgvWellness_AntiagingList.CurrentCell.ColumnIndex != 0) return;
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
            if (!IsActive(dgvWellness_AntiagingList.Rows[dgvWellness_AntiagingList.CurrentRow.Index].Cells["Active"].Value + ""))
            {
                ch1.Value = false;
                MessageBox.Show("No Active", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvWellness_AntiagingList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                    e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        private void buttonSelectAgency1_BtnClick()
        {
            try
            {
                popHowYouHearSO obj = new popHowYouHearSO();
                obj.StartPosition = FormStartPosition.CenterScreen;
                obj.WindowState = FormWindowState.Normal;
                obj.BackColor = Color.FromArgb(255, 230, 217);
                obj.howInfo = HowYouhearInfo;
                //obj.multiSelect = false;
                if (DialogResult.OK == obj.ShowDialog())
                {
                    HowYouhearInfo = obj.howInfo;
                    HowYouhearInfo.SOno = txtSONo.Text.Trim();
                    HowYouhearInfo.CN = CN;
                    HowYouhearInfo.QueryType = "FOR_SO";
                }
                ////if (!string.IsNullOrEmpty(obj.agenMemberId))
                ////{
                ////    txtAgenMemName.Text = obj.agencyMemberName;
                ////    txtAgenMemID.Text = obj.agenMemberId;
                ////}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBoxRefreshProduct_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Update Product", pictureBoxRefreshProduct);
        }

        private void pictureBoxRefreshProduct_Click(object sender, EventArgs e)
        {
            try
            {
                // BindDataHairList();
                BindDataAesList(false);
                //BindDataTreatmentList();
                BindDataSurgeryList();
                BindDataWellness_antiAgentList(false);
                BindDataPharmacyList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRunning_Click(object sender, EventArgs e)
        {
            var idMax = AryuwatSystem.Data.UtilityBackEnd.GenMaxSeqnoValues("MO");
            txtMO.Text = idMax;

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

        private void radioButtonMO_CheckedChanged(object sender, EventArgs e)
        {
            try
            {


                //if (radioButtonMO.Checked)
                //{
                //    //dataGridViewSelectList.Rows.Clear();
                //    moso = radioButtonMO.Checked ? "MO-" : "SO-";
                //    if (FormType != DerUtility.AccessType.Update || SO != "")
                //    {
                //        //this.idMax = UtilityBackEnd.GenMaxSeqnoValues(moso);
                //        //this.txtMO.Text = this.MO = this.idMax.Replace("VNM", moso);
                //        //this.idMax = this.idMax.Replace("MO-", "").Replace("VNM", "");
                //        this.idMax = UtilityBackEnd.GenMaxSeqnoValues(moso + MoSubType + "-");
                //        if (radioButtonMO.Checked)
                //        {
                //            this.txtMO.Text = this.MO = this.idMax.Replace("VNM", moso);
                //            MOType = "Y";

                //        }
                //        else
                //        {
                //            this.txtSONo.Text = this.idMax.Replace("VNM", moso);
                //            MOType = "N";
                //        }
                //    }
                //    if (SO != "")
                //        txtSONo.Text = SO;
                //    else
                //        txtSONo.Text = radioButtonMO.Checked ? "" : txtSONo.Text;
                //    if (radioButtonMO.Checked)
                //    {
                //        MOType = "Y";
                //    }
                //    else
                //    {
                //        MOType = "N";
                //    }

                //    //if (PROCredit == "Y" || PROCredit == "")
                //    if (PROCredit == "Y" )
                //    {
                //        //========================For Pro  Buffet  and Amount  26-04-2019
                //        if (PRO_CalType == "B")//Buffet
                //        { //ลบรายการอื่นออกให้หมดยกเว้น Buffet
                //            BindDataAesList(true);
                //            this.BindDataWellness_antiAgentList(true);

                //        }
                //        else if (PRO_CalType == "A")//Amount
                //        {
                //            //ProFix_Amount
                //            //  คือ ราคาขาย-xxx = ราคาเฉลี่ย  =>(ราคาโปร / จำนวนที่กำหนดในโปร)

                //        }

                //            //=========================

                //            tabControl.TabPages.Insert(0, tabWellness_Antiaging);
                //            tabControl.TabPages.Insert(0, tabSurgery);
                //            tabControl.TabPages.Insert(0, tabAesthetic);
                //            tabControl.TabPages.Remove(tabPromotion);
                //            tabControl.SelectedIndex = 0;


                //        dataGridViewSelectList.Rows[0].Visible = false;
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radioButtonSO_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonSO.Checked)
                {
                    //dataGridViewSelectList.Rows.Clear();
                    moso = radioButtonMO.Checked ? "MO-" : "SO-";
                    if (FormType != DerUtility.AccessType.Update)// || SO != "")
                    {
                        //this.idMax = UtilityBackEnd.GenMaxSeqnoValues(moso);
                        //this.txtSONo.Text  = this.idMax.Replace("VNM", moso);
                        //this.idMax = this.idMax.Replace(moso, "").Replace("VNM", "");
                        this.idMax = UtilityBackEnd.GenMaxSeqnoValues(moso + MoSubType + "-");
                        if (radioButtonMO.Checked)
                        {
                            this.txtMO.Text = this.MO = this.idMax.Replace("VNM", moso);
                            MOType = "Y";
                        }
                        else
                        {
                            this.txtSONo.Text = this.idMax.Replace("VNM", moso);
                            MOType = "N";
                        }
                    }
                    //txtMO.Enabled = !radioButtonSO.Checked;//xxxxxxxxxxxxxxxxxxxxxxx

                    txtMO.Text = radioButtonSO.Checked ? "" : txtMO.Text;
                    if (radioButtonMO.Checked)
                    {
                        MOType = "Y";
                    }
                    else
                    {
                        MOType = "N";
                    }
                    if (PROCredit == "Y")
                    {

                        tabControl.TabPages.Remove(tabAesthetic);
                        tabControl.TabPages.Remove(tabSurgery);
                        tabControl.TabPages.Remove(tabWellness_Antiaging);
                        tabControl.TabPages.Remove(tabRoom);
                        tabControl.TabPages.Insert(0, tabPromotion);
                        dataGridViewSelectList.Rows[0].Visible = true;
                        tabControl.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void ControlTab(RadioButton rd, bool chk)
        {
            try
            {
                radioAE.Checked = false;
                radioSU.Checked = false;
                radioWE.Checked = false;
                radioRoom.Checked = false;
                radioPRO.Checked = false;
                rd.Checked = chk;
                PROCredit = "";
                switch (rd.Text.ToUpper())
                {
                    case "AE":
                        MoSubType = "AE";
                        DisableTab(tabAesthetic);
                        //tabControl.SelectedTab = tabAesthetic;
                        splitContainer1.Panel1Collapsed = true;
                        splitContainer1.Panel1.Hide();
                        dataGridViewSelectListPro.Visible = false;
                        break;
                    case "SU":
                        MoSubType = "SU";
                        DisableTab(tabSurgery);
                        //tabControl.SelectedTab = tabSurgery;
                        dataGridViewSelectListPro.Visible = false;
                        splitContainer1.Panel1Collapsed = true;
                        splitContainer1.Panel1.Hide();

                        break;
                    case "WE":
                        MoSubType = "WE";
                        //tabControl.SelectedTab = tabWellness_Antiaging;
                        dataGridViewSelectListPro.Visible = false;
                        splitContainer1.Panel1Collapsed = true;
                        splitContainer1.Panel1.Hide();
                        DisableTab(tabWellness_Antiaging);
                        break;
                    case "PRO && PHA":
                        MoSubType = "PRO";
                        DisableTab(tabPromotion);
                        //dataGridViewSelectListPro.Visible = true;
                        //splitContainer1.Panel1Collapsed =false;
                        //splitContainer1.Panel1.Show();

                        //EnableTabPro(tabPromotion);
                        break;
                    case "ROOM":
                        MoSubType = "ROOM";
                        DisableTab(tabRoom);
                        break;
                }
                //dataGridViewSelectList.Rows.Clear();

                if (FormType != DerUtility.AccessType.Update)
                {
                    moso = radioButtonMO.Checked ? "MO-" : "SO-";
                    if (MoSubType == "ROOM")
                    {
                        using (var context = new EntitiesOPD_System())
                        {

                            var getRoomMO = radioButtonMO.Checked ? context.MedicalOrders.Where(x => x.Room_Status == true && !String.IsNullOrEmpty(x.VN)).Take(1).OrderByDescending(x => x.ID).FirstOrDefault() : context.MedicalOrders.Where(x => x.Room_Status == true && !String.IsNullOrEmpty(x.SONo)).Take(1).OrderByDescending(x => x.ID).FirstOrDefault();
                            int maxid = radioButtonMO.Checked ? (getRoomMO != null ? Convert.ToInt32(getRoomMO.VN.Substring(12, 4).ToString()) : 0) : (getRoomMO != null ? Convert.ToInt32(getRoomMO.SONo.Substring(12, 4).ToString()) : 0); 
                            var strCheck = moso + MoSubType + "-" + ((DateTime.Now.Year + 543).ToString().Substring(2, 2) + (DateTime.Now.Month).ToString("0#") + (maxid + 1).ToString("000#")).ToString();
                            this.idMax = strCheck;
                        }
                    }
                    else
                    {
                        this.idMax = UtilityBackEnd.GenMaxSeqnoValues(moso + MoSubType + "-");
                    }
                    if (radioButtonMO.Checked)
                        this.txtMO.Text = this.MO = this.idMax.Replace("VNM", moso);
                    else
                        this.txtSONo.Text = this.idMax.Replace("VNM", moso);
                }


                tabTypShortName = MoSubType;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void radioAE_CheckedChanged(object sender, EventArgs e)
        {
            //try
            //{

            //    ControlTab(radioAE, radioAE.Checked);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

        }

        private void radioSU_CheckedChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    ControlTab(radioSU, radioSU.Checked);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void radioWE_CheckedChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    ControlTab(radioWE, radioWE.Checked);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void radioSU_Click(object sender, EventArgs e)
        {
            radioSU.Checked = true;
            MoSubType = "SU";
            ControlTab(radioSU, radioSU.Checked);
        }

        private void radioAE_Click(object sender, EventArgs e)
        {
            radioAE.Checked = true;
            MoSubType = "AE";
            ControlTab(radioAE, radioAE.Checked);
        }

        private void radioWE_Click(object sender, EventArgs e)
        {
            radioWE.Checked = true;
            MoSubType = "WE";
            ControlTab(radioWE, radioWE.Checked);
        }

        private void radioPRO_Click(object sender, EventArgs e)
        {
            radioPRO.Checked = true;
            MoSubType = "PRO";
            lblStartDate.Visible = false;
            lblEndDate.Visible = false;
            dateTimePickerCreate.Visible = false;
            dateTimePickerEnd.Visible = false;
            ControlTab(radioPRO, radioPRO.Checked);
        }

        private void radioROOM_Click(object sender, EventArgs e)
        {
            radioRoom.Checked = true;
            lblStartDate.Visible = true;
            lblEndDate.Visible = true;
            dateTimePickerCreate.Visible = true;
            dateTimePickerEnd.Visible = true;
            MoSubType = "ROOM";
            ControlTab(radioRoom, radioRoom.Checked);
        }

        private void gvRoomList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || gvRoom.CurrentRow == null)
                {
                    return;
                }

                DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                ch1 = (DataGridViewCheckBoxCell)gvRoom.Rows[gvRoom.CurrentRow.Index].Cells[0];

                if (gvRoom.CurrentCell.ColumnIndex != 0)
                {
                    return;
                }
                //if (dgvPromotionList.Rows[e.RowIndex].Cells["PRO_Dept"].Value + "" != "GIFT")
                //{
                //    foreach (DataGridViewRow item in dgvPromotionList.Rows)
                //    {
                //        item.Cells[0].Value = false;
                //    }
                //}
                if (ch1.Value == null)
                {
                    ch1.Value = false;
                }
                switch (ch1.Value.ToString().ToUpper())
                {
                    case "TRUE":
                        ch1.Value = false;
                        break;
                    case "FALSE":
                        ch1.Value = true;
                        break;
                }
            }
            catch (Exception)
            {

            }

        }
        private void dgvPromotionList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                if (e.RowIndex < 0 || dgvPromotionList.CurrentRow == null) return;
                DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                ch1 = (DataGridViewCheckBoxCell)dgvPromotionList.Rows[dgvPromotionList.CurrentRow.Index].Cells[0];
                if (dgvPromotionList.CurrentCell.ColumnIndex != 0) return;
                if (dgvPromotionList.Rows[e.RowIndex].Cells["PRO_Dept"].Value + "" != "GIFT")
                {
                    foreach (DataGridViewRow item in dgvPromotionList.Rows)
                    {
                        item.Cells[0].Value = false;
                    }
                }
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
                if (IsExpired(dgvPromotionList.Rows[dgvPromotionList.CurrentRow.Index].Cells["DateEnd"].Value + "") || dgvPromotionList.Rows[e.RowIndex].Cells["PRO_Active"].Value + "" == "N")
                {
                    ch1.Value = false;
                    MessageBox.Show("No Active", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {

            }

        }

        private void dgvPromotionList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                    e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
            if (IsExpired(dgvPromotionList.Rows[e.RowIndex].Cells["DateEnd"].Value + "") || dgvPromotionList.Rows[e.RowIndex].Cells["PRO_Active"].Value + "" == "N")
            {
                //dgvPromotionList.Rows[e.RowIndex].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
                dgvPromotionList.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkGray;
                dgvPromotionList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    //FrmCommonReport fr = new FrmCommonReport();

            //    //fr.BindReportSO(1);

            //    //BindReportSO(1);
            //}
            //catch (Exception)
            //{

            //}
            BindReportSO(1);
            PrintSO(dsData.Tables[0]);
        }
        public void BindReportSO(int pIntseq)
        {
            try
            {
                var info = new Entity.Report() { PageNumber = pIntseq };
                //Entity.Report custInfo = new Customer();

                //if (!string.IsNullOrEmpty(txtStartdate.Text.Trim()))
                //{
                // info.StartDate = DateTime.Now.ToString("yyyy/MM/dd");
                //}
                //if (!string.IsNullOrEmpty(txtEnddate.Text.Trim()))
                //{
                //   info.EndDate = DateTime.Now.AddDays(1).ToString("yyyy/MM/dd");
                //}
                //if (!string.IsNullOrEmpty(txtCN.Text.Trim()))
                //{
                //    info.CN = "%" + txtCN.Text + "%";
                //}
                //if (!string.IsNullOrEmpty(txtSO.Text.Trim()))
                //{
                //    info.SONo = "%" + txtSO.Text + "%";
                //}
                info.SONo = txtSONo.Text;
                info.VN = txtMO.Text;
                //if (radioGroupSO.Checked)
                //{
                //    info.SONo = "%" + txtSO.Text + "%";
                //}
                //if (radioGroupCN.Checked)
                //{
                //    info.SONo = "%" + txtSO.Text + "%";
                //}

                //MedStatus_CodeNew = "0" ;
                //MedStatus_CodePending = "1";
                //MedStatus_CodeClosed = "2";
                info.MedStatus_CodeNew = "0";
                info.MedStatus_CodePending = "1";
                info.MedStatus_CodeClosed = "2";
                info.QueryType = "SEARCHSOSALE";

                dsData = new Business.Report().SelectReportPaging(info);
                decimal SalePrice = 0;
                decimal MS_Price = 0;
                decimal Amount = 0;
                decimal SpecialPrice = 0;
                decimal PriceAfterDis = 0;
                decimal DiscountBathByItem = 0;

                long lngTotalPage = 0;
                long lngTotalRecord = 0;
                if (dsData.Tables[0].Rows.Count <= 0)
                {
                    //ngbMain.CurrentPage = 0;
                    //ngbMain.TotalPage = 0;
                    //ngbMain.TotalRecord = 0;
                    //ngbMain.Updates();
                    DerUtility.MouseOff(this);
                    // Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "ไม่พบข้อมูลในระบบ");
                    return;
                }
                foreach (DataRowView item in dsData.Tables[0].DefaultView)
                {
                    if (item["SONo"] + "" == "")
                        continue;
                    else
                    {
                        if (item["VN"] + "" != "")
                            continue;
                    }

                    // SalePrice = item["SalePrice"] + "" == "" ? 0 : Convert.ToDecimal(item["SalePrice"] + "");
                    MS_Price = item["MS_Price"] + "" == "" ? 0 : Convert.ToDecimal(item["MS_Price"] + "");
                    Amount = item["Amount"] + "" == "" ? 0 : Convert.ToDecimal(item["Amount"] + "");
                    SpecialPrice = item["SpecialPrice"] + "" == "" ? 0 : Convert.ToDecimal(item["SpecialPrice"] + "");
                    PriceAfterDis = item["PriceAfterDis"] + "" == "" ? 0 : Convert.ToDecimal(item["PriceAfterDis"] + "");
                    DiscountBathByItem = item["DiscountBathByItem"] + "" == "" ? 0 : Convert.ToDecimal(item["DiscountBathByItem"] + "");
                    var myItems = new[]
                                        {
                                        String.Format("{0:dd/MM/yyyy}",DateTime.Parse( item["UpdateDate"]+"")),
                                        item["SONo"] + "",
                                        "",
                                        item["CN"]+"",
                                        item["FullNameThai"] + ""!=""?item["FullNameThai"] + "":item["FullNameEng"] + "",
                                        item["Section_Code"] + "",
                                        item["MedicalTab"] + "",
                                        item["MS_Name"] + "",
                                        MS_Price.ToString("###,###,###.##"),
                                        Amount.ToString("###,###,###.##"),
                                        (SpecialPrice).ToString("###,###,###.##"),
                                            (DiscountBathByItem).ToString("###,###,###.##"),
                                        PriceAfterDis.ToString("###,###,###.##"),

                                        item["MedStatus_Name"] + "",
                                        item["MedStatus_Code"] + "",

                                    };
                    //dgvData.Rows.Add(myItems);
                    //if (lngTotalPage != 0) continue;
                    //Utility.FindTotalPage(Convert.ToInt32(item["rowTotal"].ToString()), ref lngTotalPage);
                    //lngTotalRecord = Convert.ToInt32(item["rowTotal"].ToString());
                }
                //foreach (DataGridViewRow dataRow in dgvData.Rows)
                //{
                //    MedStatus_Code = dataRow.Cells["MedStatusCode"].Value + "";

                //    if (MedStatus_Code == "0" || MedStatus_Code == "" || MedStatus_Code == "6")
                //        dataRow.DefaultCellStyle.BackColor = Color.DarkGray;
                //    if (MedStatus_Code == "1" || MedStatus_Code == "7")
                //        dataRow.DefaultCellStyle.BackColor = Color.Khaki;
                //    if (MedStatus_Code == "2" || MedStatus_Code == "8")
                //        dataRow.DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                //    if (MedStatus_Code == "3")
                //        dataRow.DefaultCellStyle.BackColor = Color.LightBlue;
                //}
                //dgvData.Columns["MO"].Visible = false;
                //dgvData.Columns["SONo"].Visible = true;
                //dgvData.Columns["DiscountBathByItem"].Visible = true;

                //dgvData.ClearSelection();
                //foreach (DataGridViewColumn column in dgvData.Columns)
                //{

                //    dgvData.Columns[column.Name].SortMode = DataGridViewColumnSortMode.Automatic;
                //}
                //ngbMain.CurrentPage = pIntseq;
                //ngbMain.TotalPage = lngTotalPage;
                //ngbMain.TotalRecord = lngTotalRecord;
                //ngbMain.Updates();
                //Utility.MouseOff(this);
                //SaveMedical();

            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
        }
        public void BindReportPrintStock(int pIntseq)
        {
            try
            {
                var info = new Entity.MedicalSupplies() { PageNumber = pIntseq };

                //}
                //info.SONo = txtSONo.Text;
                info.VN = txtMO.Text;

                info.QueryType = "PrintSO_Stock";

                //dsStock = new Business.Report().SelectReportPaging(info);
                dsStock = new Business.MedicalSupplies().SelectMedicalSuppliesPaging(info);

            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
        }
        private void PrintSO_Stock()
        {
            try
            {
                FrmPreviewRpt obj = new FrmPreviewRpt();
                DataRow dr;
                obj.PrintType = "";
                //DataTable dtTmp;
                //dtSumOfTreatPay
                //string sql = "[Vat] <> 'Y'";
                //if (dtSumOfTreat.Select(sql).Any())
                //    dtTmp = dtSumOfTreat.Select(sql).CopyToDataTable();
                //else
                //    return;

                //dtTmp = dtSumOfTreat;

                string strTypeofPay = "";
                obj.FormName = "RptPrintSO_Stock";


                double dblCredit = 0.00;
                double dblCash = 0.00;
                string strBankName = "";

                dblCredit += dblCash;
                obj.TypeOfPayment = strTypeofPay;
                obj.PayToday = dblCredit.ToString("###,###,##0.00");

                //obj.SumUnpaid = Convert.ToDouble(dtTmp.Rows[0]["Unpaid"]);//.Compute("Sum(Unpaid)", ""));
                obj.dt = dsStock.Tables[0];
                obj.MaximizeBox = true;
                obj.TopMost = true;
                obj.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void PrintSO(DataTable dtTmp)
        {
            try
            {
                FrmPreviewRpt obj = new FrmPreviewRpt();
                DataRow dr;
                obj.PrintType = "";
                //DataTable dtTmp;
                //dtSumOfTreatPay
                //string sql = "[Vat] <> 'Y'";
                //if (dtSumOfTreat.Select(sql).Any())
                //    dtTmp = dtSumOfTreat.Select(sql).CopyToDataTable();
                //else
                //    return;

                //dtTmp = dtSumOfTreat;

                string strTypeofPay = "";
                obj.FormName = "RptMedicalOrderSaleSO";
                //int disByItem= Convert.ToInt32(dtTmp.Compute("Sum(DiscountBathByItem)", "");
                //if (Convert.ToInt32(dtTmp.Compute("Sum(DiscountBathByItem)", "")) > 0 || (txtIntDiscountBath.Text != "" && txtIntDiscountBath.Text != "0.00"))
                //    obj.HasDiscount = true;

                double dblCredit = 0.00;
                double dblCash = 0.00;
                string strBankName = "";
                //var MaxID = dataGridViewCreditTransfer.Rows.Cast<DataGridViewRow>().Max(r =>Convert.ToDateTime(r.Cells["PayCreditDate"].Value));

                //DateTime Maxdate = Convert.ToDateTime("2000/01/01");// String.Format("{0:yyyy/MM/dd}", DateTime.Now);
                //foreach (DataGridViewRow row in dataGridViewCreditTransfer.Rows)
                //{
                //    if (Convert.ToDateTime(row.Cells["PayCreditDate"].Value + "") > Maxdate)
                //    {
                //        Maxdate = Convert.ToDateTime(row.Cells["PayCreditDate"].Value + "");
                //    }
                //}

                //foreach (DataGridViewRow row in dataGridViewCashTransfer.Rows)
                //{
                //    if (Convert.ToDateTime(row.Cells["PayCashDate"].Value + "") > Maxdate)
                //    {
                //        Maxdate = Convert.ToDateTime(row.Cells["PayCashDate"].Value + "");
                //    }
                //}

                //foreach (DataGridViewRow row in dataGridViewCreditTransfer.Rows)
                //{
                //    if (row.Cells["cash"].Value + "" != "" && row.Cells["PayCreditDate"].Value + "" == String.Format("{0:yyyy/MM/dd}", Maxdate))
                //    {
                //        dblCredit += double.Parse(row.Cells["cash"].Value + ""); //
                //        if (strBankName != "") strBankName += ",";
                //        strBankName += row.Cells["name"].Value + "";
                //    }
                //}

                //foreach (DataGridViewRow row in dataGridViewCashTransfer.Rows)
                //{
                //    if (row.Cells["CashCurrent"].Value + "" != "" && row.Cells["PayCashDate"].Value + "" == String.Format("{0:yyyy/MM/dd}", Maxdate))
                //    {
                //        dblCash += double.Parse(row.Cells["CashCurrent"].Value + ""); //
                //    }
                //}
                //if (dblCredit > 0)
                //{
                //    //strTypeofPay = " บัตรเครดิต " + strBankName + " " + dblCredit.ToString("###,##0.00") + " บาท ";
                //    strTypeofPay = " บัตรเครดิต :" + dblCredit.ToString("###,###,##0.00") + " บาท ";
                //}
                //if (dblCash > 0)
                //{
                //    if (strTypeofPay.Length > 0) strTypeofPay += "/";
                //    strTypeofPay += " เงินสด :" + dblCash.ToString("###,###,##0.00") + " บาท";
                //}
                //obj.DiscountBath = string.IsNullOrEmpty(txtIntDiscountBath.Text.Trim())
                //                       ? 0.00
                //                       : double.Parse(txtIntDiscountBath.Text.Trim());

                dblCredit += dblCash;
                obj.TypeOfPayment = strTypeofPay;
                obj.PayToday = dblCredit.ToString("###,###,##0.00");

                //obj.SumUnpaid = Convert.ToDouble(dtTmp.Rows[0]["Unpaid"]);//.Compute("Sum(Unpaid)", ""));
                obj.dt = dtTmp;
                obj.MaximizeBox = true;
                obj.TopMost = true;
                obj.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPrint_Click_1(object sender, EventArgs e)
        {

        }



        private void dataGridViewSelectList_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            alertcount = 0;

        }


        private void chkBoxChange(object sender, EventArgs e)
        {
            for (int k = 0; k <= dataGridViewSelectList.RowCount - 1; k++)
            {
                this.dataGridViewSelectList[0, k].Value = true;
            }
            this.dataGridViewSelectList.EndEdit();
        }
        private void SetSelectProductInPro(string strMS)
        {
            try
            {
                List<string> lsMs = new List<string>();
                List<string> lsMPro = new List<string>();
                lsMs = strMS.Split('|').ToList();
                lsMPro = strMS.Split('@').ToList();
                dataGridViewSelectList.ClearSelection();
                //for (int k = 0; k <= dataGridViewSelectList.RowCount - 1; k++)
                //{
                //    this.dataGridViewSelectList[0, k].Value = false;
                //}
                //this.dataGridViewSelectList.EndEdit();

                string p = lsMPro[1].Split(',')[0];
                string chk = lsMPro[1].Split(',')[1].ToLower();

                foreach (string item in lsMs)
                {
                    string[] strCol = item.Split(',');
                    if (strCol.Any())
                    {
                        foreach (DataGridViewRow row in dataGridViewSelectList.Rows)
                        {
                            if (lsMPro[0] != "")
                            {
                                if (row.Cells["Code"].Value + "" == strCol[0].Replace("@", "") && row.Cells["ListOrder"].Value + "" == strCol[1])
                                {
                                    row.Selected = true;

                                    if (chk == "true")
                                        row.Cells[0].Value = true;
                                    else row.Cells[0].Value = false;

                                }
                            }
                            else
                            {
                                if (row.Cells["Code"].Value + "" == strCol[0].Replace("@", ""))
                                {
                                    row.Selected = true;

                                    if (chk == "true")
                                        row.Cells[0].Value = true;
                                    else row.Cells[0].Value = false;

                                }
                            }

                        }
                    }
                }
                this.dataGridViewSelectList.EndEdit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


        private void dataGridViewSelectListPro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //string strMS = dataGridViewSelectListPro["ListMS_Code", e.RowIndex].Value + "@"+dataGridViewSelectListPro["Code", e.RowIndex].Value+",";
                dataGridViewSelectListPro.EndEdit();
                string strMS = string.Format("{0}@{1},{2}", dataGridViewSelectListPro["ListMS_Code", e.RowIndex].Value + "", dataGridViewSelectListPro["Code", e.RowIndex].Value + "", dataGridViewSelectListPro["ChkMove", e.RowIndex].Value + "");

                SetSelectProductInPro(strMS);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewSelectListPro_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewSelectListPro.Columns["Amount"].Index)
            {
                sumAmountPro();
                SumPriceMedicalOrderAll();
            }
        }
        private void sumAmountPro()
        {
            try
            {
                dataGridViewSelectListPro.EndEdit();
                List<string> ListOfPro = new List<string>();
                double ProAmount = 1;
                double MSAmount = 1;
                double SpecialPrice = 0;
                foreach (DataGridViewRow row in dataGridViewSelectListPro.Rows)
                {
                    string strMS = string.Format("{0}@{1},{2}", dataGridViewSelectListPro["ListMS_Code", row.Index].Value + "", dataGridViewSelectListPro["Code", row.Index].Value + "", dataGridViewSelectListPro["ChkMove", row.Index].Value + "");
                    if (dataGridViewSelectListPro["Amount", row.Index].Value + "" != "" || dataGridViewSelectListPro["Amount", row.Index].Value + "" != "0")
                    {
                        ProAmount = dataGridViewSelectListPro["Amount", row.Index].Value == null ? 1 : Convert.ToDouble(dataGridViewSelectListPro["Amount", row.Index].Value + "");
                    }
                    else
                    {
                        ProAmount = 1;
                    }

                    dataGridViewSelectListPro["Amount", row.Index].Value = ProAmount;


                    List<string> lsMs = new List<string>();
                    List<string> lsMPro = new List<string>();
                    lsMs = strMS.Split('|').ToList();
                    lsMPro = strMS.Split('@').ToList();
                    dataGridViewSelectList.ClearSelection();
                    //for (int k = 0; k <= dataGridViewSelectList.RowCount - 1; k++)
                    //{
                    //    this.dataGridViewSelectList[0, k].Value = false;
                    //}
                    //this.dataGridViewSelectList.EndEdit();

                    string p = lsMPro[1].Split(',')[0];
                    string chk = lsMPro[1].Split(',')[1].ToLower();

                    foreach (string item in lsMs)
                    {
                        string[] strCol = item.Split(',');
                        if (strCol.Any())
                        {
                            foreach (DataGridViewRow row2 in dataGridViewSelectList.Rows)
                            {
                                if (row2.Cells["Code"].Value + "" == strCol[0] && row2.Cells["ListOrder"].Value + "" == strCol[1])
                                {
                                    if (dataGridViewSelectList.Rows[row2.Index].Cells["Amount"].Value + "" != "" || dataGridViewSelectList.Rows[row2.Index].Cells["Amount"].Value + "" != "0")
                                        MSAmount = dataGridViewSelectList.Rows[row2.Index].Cells["AmountPro"].Value + "" == "" ? 1 : Convert.ToDouble(dataGridViewSelectList.Rows[row2.Index].Cells["AmountPro"].Value + "");
                                    SpecialPrice = dataGridViewSelectList.Rows[row2.Index].Cells["SpecialPrice"].Value + "" == "" ? 0 : Convert.ToDouble(dataGridViewSelectList.Rows[row2.Index].Cells["SpecialPrice"].Value + "");

                                    //if (ProAmount == 1)
                                    //{
                                    //    //dicAmount.Remove(row2.Cells["Code"].Value + "" + row.Cells["ListOrder"].Value + "");
                                    //    //lbPromotion.Text = "";
                                    //    //dicPromotion.Remove(row2.Cells["Code"].Value + "");

                                    string key = row2.Cells["Code"].Value + "," + row2.Cells["ListOrder"].Value + "|";
                                    //MSAmount = dicAmount[key];
                                    //SpecialPrice = dicSpecialPrice[key];
                                    //}
                                    double dbNumPerC = dataGridViewSelectList.Rows[row2.Index].Cells["No./Course"].Value + "" == "" ? 0 : double.Parse(dataGridViewSelectList.Rows[row2.Index].Cells["No./Course"].Value + "");
                                    double itemAmount = dataGridViewSelectList.Rows[row2.Index].Cells["AmountPro"].Value + "" == "" ? 0 : double.Parse(dataGridViewSelectList.Rows[row2.Index].Cells["AmountPro"].Value + "");
                                    double PricePerPro = dataGridViewSelectList.Rows[row2.Index].Cells["PricePerPro"].Value + "" == "" ? 0 : double.Parse(dataGridViewSelectList.Rows[row2.Index].Cells["PricePerPro"].Value + "");
                                    double PriceTotal = dataGridViewSelectList.Rows[row2.Index].Cells["PriceTotal"].Value + "" == "" ? 0 : double.Parse(dataGridViewSelectList.Rows[row2.Index].Cells["PriceTotal"].Value + "");
                                    dataGridViewSelectList.Rows[row2.Index].Cells["Amount"].Value = (itemAmount * ProAmount).ToString("###,###,###");
                                    dataGridViewSelectList.Rows[row2.Index].Cells["Total"].Value = MSAmount * dbNumPerC * ProAmount; //จำนวนทั้งหมด
                                                                                                                                     //dataGridViewSelectList.Rows[row2.Index].Cells["SpecialPrice"].Value = (SpecialPrice * ProAmount).ToString("###,###,###");
                                    double pU = row2.Cells["Price/Unit"].Value + "" == "" ? 0 : double.Parse(row2.Cells["Price/Unit"].Value + "");
                                    //dataGridViewSelectList.Rows[row2.Index].Cells["PriceTotal"].Value = ((MSAmount * dbNumPerC * ProAmount * pU) + (SpecialPrice * ProAmount)).ToString("###,###,###");
                                    double priTotal = itemAmount * ProAmount * PricePerPro;
                                    dataGridViewSelectList.Rows[row2.Index].Cells["PriceTotal"].Value = priTotal.ToString("###,###,###,###");
                                    double SpecialTotal = priTotal - (pU * itemAmount * ProAmount);
                                    dataGridViewSelectList.Rows[row2.Index].Cells["SpecialPrice"].Value = SpecialTotal.ToString("###,###,###,###");

                                    row2.Selected = true;

                                    if (chk == "true")
                                        row2.Cells[0].Value = true;
                                    else row2.Cells[0].Value = false;

                                }
                            }
                        }
                    }
                }
                this.dataGridViewSelectList.EndEdit();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewSelectListPro_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //====================Set color===========================
            try
            {
                dataGridViewSelectListPro.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridViewSelectListPro.Columns["Amount"].DefaultCellStyle.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {

            }

        }

        private void dataGridViewSelectList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //====================Set color===========================


            try
            {

            }
            catch (Exception ex)
            {

            }
        }

        private void FrmMedicalOrderSettingPro_Shown(object sender, EventArgs e)
        {
            try
            {


                if (FormType != DerUtility.AccessType.Update)
                    SelectCustomer();//new
                else
                {

                    //================For SO อย่างเดียว ไม่่เกี่ยว MO ======================================================
                    //
                    //DataSet dsSurgeryFee = new Business.MedicalOrderUseTrans().SELECTSAVEDJOBCOST_COM(txtMO.Text, txtSONo.Text, "", ""); ไม่เช็ค job แล้ว


                    //if (dsSurgeryFee.Tables.Count > 0 && dsSurgeryFee.Tables[0].Rows.Count > 0 && !(Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN) && !Userinfo.IS_ADMIN_JOBCOST.Contains(Userinfo.EN) && dateTimePickerCreate.Value.Date < DateTime.Now.Date && PROCredit!="Y")
                    if (!(Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN) && !Userinfo.IS_ADMIN_EDIT.Contains(Userinfo.EN) && dateTimePickerCreate.Value.Date < DateTime.Now.Date.AddDays(-3) && PROCredit != "Y")
                    {
                        //DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, "ไม่สามารถแก้ไขข้อมูลได้เนื่องจาก ได้บันทึกค่ามือและค่าแพทย์ไปแล้ว" + Environment.NewLine + "กรุณาติดต่อผู้ดูแลระบบ");
                        DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, "จะไม่สามารถแก้ไขข้อมูลได้เนื่องจาก เกินกำหนดเวลา หรือตัดคอร์สไปแล้ว");//+ Environment.NewLine + "กรุณาติดต่อผู้ดูแลระบบ");
                                                                                                                                                     //btnSave.Enabled = false;
                                                                                                                                                     //buttonAddDown.Visible = false;
                                                                                                                                                     //buttonDeleteUp.Visible = false;

                        //comboBoxCommission1.Enabled = false;
                        //comboBoxCommission2.Enabled = false;
                        //comboBoxByDr.Enabled = false;
                        SetbuttonSave(false);
                    }

                    DataSet dsExpire = new Business.MedicalOrderUseTrans().CheckExpireSO(txtMO.Text, txtSONo.Text, "", "");//check Expire SO
                    if (dsExpire.Tables.Count > 0 && dsExpire.Tables[0].Rows.Count > 0 && !(Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN) && !Userinfo.IS_ADMIN_EDIT.Contains(Userinfo.EN))
                    {
                        DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, "จะไม่สามารถแก้ไขข้อมูลได้เนื่องจาก คอร์สหมดอายุ");
                        SetbuttonSave(false);
                    }
                    //================For SO ======================================================

                    //cboBranch.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SetbuttonSave(bool canSave)
        {
            btnSave.Enabled = canSave;
            buttonAddDown.Visible = canSave;
            buttonDeleteUp.Visible = canSave;

            comboBoxCommission1.Enabled = canSave;
            comboBoxCommission2.Enabled = canSave;
            comboBoxByDr.Enabled = canSave;
        }
        private void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                string SOnoSub = dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells["SOnoSub"].Value + "";
                if (SOnoSub.Length > 5)
                {
                    MessageBox.Show("รายการนี้ โอนไปแล้ว=> " + SOnoSub, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    CallFormRef(Statics.CallMode.Ref);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radioButtonMO_Click(object sender, EventArgs e)
        {
            if (radioButtonMO.Checked && SO != "")
            {

                FormType = DerUtility.AccessType.Insert;

            }

            if (radioButtonMO.Checked)
            {
                //dataGridViewSelectList.Rows.Clear();
                moso = radioButtonMO.Checked ? "MO-" : "SO-";
                if (FormType != DerUtility.AccessType.Update || SO != "")
                {
                    //this.idMax = UtilityBackEnd.GenMaxSeqnoValues(moso);
                    //this.txtMO.Text = this.MO = this.idMax.Replace("VNM", moso);
                    //this.idMax = this.idMax.Replace("MO-", "").Replace("VNM", "");
                    this.idMax = UtilityBackEnd.GenMaxSeqnoValues(moso + MoSubType + "-");
                    if (radioButtonMO.Checked)
                    {
                        this.txtMO.Text = this.MO = this.idMax.Replace("VNM", moso);
                        MOType = "Y";

                    }
                    else
                    {
                        this.txtSONo.Text = this.idMax.Replace("VNM", moso);
                        MOType = "N";
                    }
                }
                if (SO != "")
                    txtSONo.Text = SO;
                else
                    txtSONo.Text = radioButtonMO.Checked ? "" : txtSONo.Text;
                if (radioButtonMO.Checked)
                {
                    MOType = "Y";
                }
                else
                {
                    MOType = "N";
                }

                //if (PROCredit == "Y" || PROCredit == "")
                if (PROCredit == "Y")
                {
                    //========================For Pro  Buffet  and Amount  26-04-2019
                    if (PRO_CalType == "B")//Buffet
                    { //ลบรายการอื่นออกให้หมดยกเว้น Buffet
                        BindDataAesList(true);
                        this.BindDataWellness_antiAgentList(true);

                    }
                    else if (PRO_CalType == "A")//Amount //Pro amount
                    {
                        //ProFix_Amount
                        //  คือ ราคาขาย-xxx = ราคาเฉลี่ย  =>(ราคาโปร / จำนวนที่กำหนดในโปร)

                    }

                    //=========================

                    tabControl.TabPages.Insert(0, tabWellness_Antiaging);
                    tabControl.TabPages.Insert(0, tabSurgery);
                    tabControl.TabPages.Insert(0, tabAesthetic);
                    tabControl.TabPages.Remove(tabRoom);
                    tabControl.TabPages.Remove(tabPromotion);
                    tabControl.SelectedIndex = 0;


                    dataGridViewSelectList.Rows[0].Visible = false;
                }
            }
        }
        private bool CheckMOCreate()
        {
            bool created = false;
            try
            {
                DataSet ds = new Business.MedicalOrder().CheckMoCreated(SO);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    string vn = ds.Tables[0].Rows[0][0].ToString();
                    radioButtonMO.Checked = false;
                    radioButtonSO.Checked = true;
                    //MessageBox.Show("MO Created.=> " + vn, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    created = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            return created;
        }
        private void btnHow_Click(object sender, EventArgs e)
        {
            SHowHowdidyouHear();
        }
        bool HaveHowYouHear()
        {
            bool ok = false;
            if (HowYouhearInfo != null)
            {
                if (HowYouhearInfo.CallIn == "Y" || HowYouhearInfo.Newspaper == "Y" || HowYouhearInfo.Magazine == "Y" || HowYouhearInfo.Internet == "Y" || HowYouhearInfo.Friend == "Y" || HowYouhearInfo.Travelthrough == "Y" || HowYouhearInfo.Facebook == "Y" || HowYouhearInfo.Facebook == "Y" || HowYouhearInfo.Instagram == "Y" || HowYouhearInfo.Sms == "Y" || HowYouhearInfo.LineAt == "Y" || HowYouhearInfo.Line == "Y" || HowYouhearInfo.Taxi == "Y" || HowYouhearInfo.TV == "Y" || HowYouhearInfo.Agency != "N" || HowYouhearInfo.HowYouhearOther != "N")
                    ok = true;
            }
            return ok;
        }
        private void SHowHowdidyouHear()
        {
            try
            {

                popHowYouHearSO obj = new popHowYouHearSO();
                obj.StartPosition = FormStartPosition.CenterScreen;
                obj.WindowState = FormWindowState.Normal;
                obj.BackColor = Color.FromArgb(255, 230, 217);
                obj.howInfo = HowYouhearInfo;
                //obj.multiSelect = false;
                if (DialogResult.OK == obj.ShowDialog())
                {
                    HowYouhearInfo = obj.howInfo;
                    HowYouhearInfo.SOno = txtSONo.Text.Trim();
                    HowYouhearInfo.CN = CN;
                    HowYouhearInfo.QueryType = "FOR_SO";
                    txtAgenMemNameOPD.Text = obj.AgencyNameOPD;
                    txtAgenMemIDOPD.Text = obj.AgencyIDOPD;
                    if (HowYouhearInfo.Agency != "N")
                    {
                        txtAgenMemID.Visible = true;
                        txtAgenMemName.Visible = true;
                        labelIDAgency.Visible = true;
                        labelNameAgency.Visible = true;

                        txtAgenMemName.Text = obj.AgencyName;
                        txtAgenMemID.Text = obj.AgencyID;

                    }
                    else
                    {
                        txtAgenMemID.Visible = false;
                        txtAgenMemName.Visible = false;
                        labelIDAgency.Visible = false;
                        labelNameAgency.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewSelectList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {

                //dataGridViewSelectList.EndEdit();

                if (dataGridViewSelectList.IsCurrentCellDirty && dataGridViewSelectList.Columns["Free"].Index == currentColIndex)
                {
                    dataGridViewSelectList.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    //if (!(dataGridViewSelectList.Rows[currentRowIndex].Cells["Free"].Value + "").ToLower().Contains("f7"))//อื่นๆ ไม่ใช่ Gift
                    //{
                    //    dataGridViewSelectList.Rows[currentRowIndex].Cells["GiftNumber"].Value = "";
                    //    //return;
                    //}
                    string dickey = string.Format("{0}{1}{2}{3}", txtSONo.Text, txtMO.Text, dataGridViewSelectList.Rows[currentRowIndex].Cells["Code"].Value + "", dataGridViewSelectList.Rows[currentRowIndex].Cells["ListOrder"].Value + "");
                    string OldFreeType = "";
                    if (dicFreeTrans.ContainsKey(dickey))
                    {
                        OldFreeType = dicFreeTrans[dickey].FreeType;
                    }

                    if (dataGridViewSelectList.Rows[currentRowIndex].Cells["Free"].Value + "" == "f7")//Gift
                    {
                        PopGiftVoucher();
                        dataGridViewSelectList.EndEdit();
                    }
                    else if (dataGridViewSelectList.Rows[currentRowIndex].Cells["Free"].Value + "" == "f3")//3.	Complication(งานแก้ไข)	f3
                    {

                        dataGridViewSelectList.Rows[currentRowIndex].Cells["GiftNumber"].Value = "";
                        PopComplication();
                        dataGridViewSelectList.EndEdit();
                    }
                    else if (dataGridViewSelectList.Rows[currentRowIndex].Cells["Free"].Value + "" == "f2")//3.	Marketing	f2
                    {
                        dataGridViewSelectList.Rows[currentRowIndex].Cells["GiftNumber"].Value = "";
                        PopMarketing();
                        dataGridViewSelectList.EndEdit();
                    }
                    else if (dataGridViewSelectList.Rows[currentRowIndex].Cells["Free"].Value + "" == "f5")//	SubjectTraining	f5
                    {
                        dataGridViewSelectList.Rows[currentRowIndex].Cells["GiftNumber"].Value = "";
                        PopSubjectTraining();
                        dataGridViewSelectList.EndEdit();
                    }
                    else if (dataGridViewSelectList.Rows[currentRowIndex].Cells["Free"].Value + "" == "f4")//	Complementary(ของแถม) f4
                    {
                        dataGridViewSelectList.Rows[currentRowIndex].Cells["GiftNumber"].Value = "";
                        PopComplementary();
                        dataGridViewSelectList.EndEdit();
                    }
                    else if (dataGridViewSelectList.Rows[currentRowIndex].Cells["Free"].Value + "" == "f1")//	Barter f1
                    {
                        dataGridViewSelectList.Rows[currentRowIndex].Cells["GiftNumber"].Value = "";
                        PopBarter();
                        dataGridViewSelectList.EndEdit();
                    }
                    else if (dataGridViewSelectList.Rows[currentRowIndex].Cells["Free"].Value + "" == "f6")//	Benefits f6
                    {
                        dataGridViewSelectList.Rows[currentRowIndex].Cells["GiftNumber"].Value = "";
                        PopBenefits();
                        dataGridViewSelectList.EndEdit();
                    }
                    else if (dataGridViewSelectList.Rows[currentRowIndex].Cells["Free"].Value + "" == "" || dataGridViewSelectList.Rows[currentRowIndex].Cells["Free"].Value + "" != OldFreeType)//	ไม่เลือก หรือเปลี่ยน
                    {
                        dataGridViewSelectList.Rows[currentRowIndex].Cells["GiftNumber"].Value = "";
                        dataGridViewSelectList.Rows[currentRowIndex].Cells["Free"].Value = "";
                        dataGridViewSelectList.Rows[currentRowIndex].Cells["SpecialPrice"].Value = 0;
                        dataGridViewSelectList.EndEdit();
                        dataGridViewSelectList.CommitEdit(DataGridViewDataErrorContexts.Commit);
                        //string dickey = string.Format("{0}{1}{2}{3}", txtSONo.Text, txtMO.Text, dataGridViewSelectList.Rows[currentRowIndex].Cells["Code"].Value + "", dataGridViewSelectList.Rows[currentRowIndex].Cells["ListOrder"].Value + "");
                        //string GiftCode = "";
                        if (dicFreeTrans.ContainsKey(dickey))
                        {
                            if (!dicFreeTransDel.ContainsKey(dickey))
                            {
                                dicFreeTransDel.Add(dickey, dicFreeTrans[dickey]);
                            }
                            dicFreeTrans.Remove(dickey);
                        }
                    }



                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void PopGiftVoucher()
        {
            try
            {

                if (dataGridViewSelectList.Rows[currentRowIndex].Cells["Tab"].Value + "" == "SURGERY")
                {
                    dataGridViewSelectList.Rows[currentRowIndex].Cells["Free"].Value = "";
                    dataGridViewSelectList.EndEdit();
                    dataGridViewSelectList.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    MessageBox.Show("SURGERY Not available.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string dickey = string.Format("{0}{1}{2}{3}", txtSONo.Text, txtMO.Text, dataGridViewSelectList.Rows[currentRowIndex].Cells["Code"].Value + "", dataGridViewSelectList.Rows[currentRowIndex].Cells["ListOrder"].Value + "");
                string GiftCode = "";
                if (dicFreeTrans.ContainsKey(dickey))
                {
                    GiftCode = dicFreeTrans[dickey].GiftCodeOther;
                }

                FrmFreeGiftVoucher frm = new FrmFreeGiftVoucher();
                frm.GiftCode = GiftCode;// dataGridViewSelectList.Rows[currentRowIndex].Cells["GiftNumber"].Value + "";
                frm.Sono = txtSONo.Text;
                frm.VN = txtMO.Text;
                frm.CustomerName = txtCustomerName.Text;
                frm.MS_Code = dataGridViewSelectList.Rows[currentRowIndex].Cells["Code"].Value + "";
                frm.ListOrder = dataGridViewSelectList.Rows[currentRowIndex].Cells["ListOrder"].Value + "";
                frm.MS_Name = dataGridViewSelectList.Rows[currentRowIndex].Cells["Name"].Value + "";

                frm.CN = CN;
                frm.ShowDialog();

                //FrmGiftVoucherEdit frm = new FrmGiftVoucherEdit();
                //frm.Import = false;

                //frm.CN = CN;
                //frm.CustomerName = txtCustomerName.Text; ;
                //frm.SOno = txtSONo.Text;
                //frm.VN = txtMO.Text;
                //frm.MS_Code = dataGridViewSelectList.Rows[currentRowIndex].Cells["Code"].Value + "";
                //frm.ListOrder = dataGridViewSelectList.Rows[currentRowIndex].Cells["ListOrder"].Value + "";


                //frm.ShowDialog();

                //MessageBox.Show(frm.GiftCode + "");

                if (frm.GiftCode == "")//ถ้าไม่เลือก Gift เลย
                {
                    dataGridViewSelectList.Rows[currentRowIndex].Cells["GiftNumber"].Value = "";
                    dataGridViewSelectList.Rows[currentRowIndex].Cells["Free"].Value = "";
                    dataGridViewSelectList.Rows[currentRowIndex].Cells["SpecialPrice"].Value = 0;
                    dataGridViewSelectList.EndEdit();
                    dataGridViewSelectList.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                else
                {
                    double dblTotalAmount = double.Parse(dataGridViewSelectList.Rows[currentRowIndex].Cells["Amount"].Value + "");// * (dataGridViewSelectList.Rows[currentRowIndex].Cells["No./Course"].Value + "" == "" ? 1 : double.Parse(dataGridViewSelectList.Rows[currentRowIndex].Cells["No./Course"].Value + "")));
                    double pricePer = dataGridViewSelectList.Rows[currentRowIndex].Cells["Price/Unit"].Value + "" == "" ? 0 : double.Parse(dataGridViewSelectList.Rows[currentRowIndex].Cells["Price/Unit"].Value + "");
                    double SpecialPriceOld = dataGridViewSelectList.Rows[currentRowIndex].Cells["SpecialPrice"].Value + "" == "" ? 0 : double.Parse(dataGridViewSelectList.Rows[currentRowIndex].Cells["SpecialPrice"].Value + "");

                    dblTotalAmount = dblTotalAmount * pricePer;
                    dataGridViewSelectList.Rows[currentRowIndex].Cells["GiftNumber"].Value = frm.GiftCode + "";
                    dataGridViewSelectList.Rows[currentRowIndex].Cells["SpecialPrice"].Value = dblTotalAmount <= frm.PriceCredit || frm.PriceCredit == 0 ? dblTotalAmount * -1 : frm.PriceCredit * -1;
                    dataGridViewSelectList.EndEdit();
                    dataGridViewSelectList.CommitEdit(DataGridViewDataErrorContexts.Commit);

                }

                if (dicFreeTrans.ContainsKey(dickey))
                {
                    if (!dicFreeTransDel.ContainsKey(dickey))
                        dicFreeTransDel.Add(dickey, dicFreeTrans[dickey]);
                    dicFreeTrans.Remove(dickey);
                    FreeTrans f = new FreeTrans();

                    f.SONo = txtSONo.Text;
                    f.VN = txtMO.Text;
                    f.MS_Code = dataGridViewSelectList.Rows[currentRowIndex].Cells["Code"].Value + "";
                    f.ListOrder = dataGridViewSelectList.Rows[currentRowIndex].Cells["ListOrder"].Value + "";
                    f.FreeType = dataGridViewSelectList.Rows[currentRowIndex].Cells["Free"].Value + "";
                    f.GiftCodeOther = frm.GiftCode + "";
                    f.Approve = "";
                    f.Remark = "";
                    dicFreeTrans.Add(dickey, f);
                }
                else
                {
                    FreeTrans f = new FreeTrans();

                    f.SONo = txtSONo.Text;
                    f.VN = txtMO.Text;
                    f.MS_Code = dataGridViewSelectList.Rows[currentRowIndex].Cells["Code"].Value + "";
                    f.ListOrder = dataGridViewSelectList.Rows[currentRowIndex].Cells["ListOrder"].Value + "";
                    f.FreeType = dataGridViewSelectList.Rows[currentRowIndex].Cells["Free"].Value + "";
                    f.GiftCodeOther = frm.GiftCode + "";
                    f.Approve = "";
                    f.Remark = "";
                    dicFreeTrans.Add(dickey, f);

                }


                frm.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void PopBarter()
        {
            try
            {

                //if (dataGridViewSelectList.Rows[currentRowIndex].Cells["Tab"].Value + "" == "SURGERY")
                //{
                //    dataGridViewSelectList.Rows[currentRowIndex].Cells["Free"].Value = "";
                //    dataGridViewSelectList.EndEdit();
                //    dataGridViewSelectList.CommitEdit(DataGridViewDataErrorContexts.Commit);
                //    MessageBox.Show("SURGERY Not available.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                string dickey = string.Format("{0}{1}{2}{3}", txtSONo.Text, txtMO.Text, dataGridViewSelectList.Rows[currentRowIndex].Cells["Code"].Value + "", dataGridViewSelectList.Rows[currentRowIndex].Cells["ListOrder"].Value + "");
                string GiftCode = "";
                if (dicFreeTrans.ContainsKey(dickey))
                {
                    GiftCode = dicFreeTrans[dickey].GiftCodeOther;
                }
                FrmFreeBarterVat frm = new FrmFreeBarterVat();
                frm.GiftCode = GiftCode;// dataGridViewSelectList.Rows[currentRowIndex].Cells["GiftNumber"].Value + "";
                frm.Sono = txtSONo.Text;
                frm.VN = txtMO.Text;
                frm.CustomerName = txtCustomerName.Text;
                frm.MS_Code = dataGridViewSelectList.Rows[currentRowIndex].Cells["Code"].Value + "";
                frm.ListOrder = dataGridViewSelectList.Rows[currentRowIndex].Cells["ListOrder"].Value + "";
                frm.MS_Name = dataGridViewSelectList.Rows[currentRowIndex].Cells["Name"].Value + "";
                frm.CN = CN;
                frm.ShowDialog();
                //MessageBox.Show(frm.GiftCode + "");

                if (frm.GiftCode == "")//ถ้าไม่เลือก เลย
                {
                    dataGridViewSelectList.Rows[currentRowIndex].Cells["GiftNumber"].Value = "";
                    dataGridViewSelectList.Rows[currentRowIndex].Cells["Free"].Value = "";
                    dataGridViewSelectList.Rows[currentRowIndex].Cells["SpecialPrice"].Value = 0;
                    dataGridViewSelectList.EndEdit();
                    dataGridViewSelectList.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                else
                {

                    double dblTotalAmount = double.Parse(dataGridViewSelectList.Rows[currentRowIndex].Cells["Amount"].Value + "");// * (dataGridViewSelectList.Rows[currentRowIndex].Cells["No./Course"].Value + "" == "" ? 1 : double.Parse(dataGridViewSelectList.Rows[currentRowIndex].Cells["No./Course"].Value + "")));
                    double pricePer = dataGridViewSelectList.Rows[currentRowIndex].Cells["Price/Unit"].Value + "" == "" ? 0 : double.Parse(dataGridViewSelectList.Rows[currentRowIndex].Cells["Price/Unit"].Value + "");
                    double SpecialPriceOld = dataGridViewSelectList.Rows[currentRowIndex].Cells["SpecialPrice"].Value + "" == "" ? 0 : double.Parse(dataGridViewSelectList.Rows[currentRowIndex].Cells["SpecialPrice"].Value + "");

                    dblTotalAmount = dblTotalAmount * pricePer;
                    //ถ้าเลือก 
                    dataGridViewSelectList.Rows[currentRowIndex].Cells["GiftNumber"].Value = frm.GiftCode + "";
                    dataGridViewSelectList.Rows[currentRowIndex].Cells["SpecialPrice"].Value = dblTotalAmount <= frm.PriceCredit || frm.PriceCredit == 0 ? dblTotalAmount * -1 : frm.PriceCredit * -1;
                    dataGridViewSelectList.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }

                if (dicFreeTrans.ContainsKey(dickey))
                {
                    if (!dicFreeTransDel.ContainsKey(dickey))
                        dicFreeTransDel.Add(dickey, dicFreeTrans[dickey]);
                    dicFreeTrans.Remove(dickey);
                    FreeTrans f = new FreeTrans();

                    f.SONo = txtSONo.Text;
                    f.VN = txtMO.Text;
                    f.MS_Code = dataGridViewSelectList.Rows[currentRowIndex].Cells["Code"].Value + "";
                    f.ListOrder = dataGridViewSelectList.Rows[currentRowIndex].Cells["ListOrder"].Value + "";
                    f.FreeType = dataGridViewSelectList.Rows[currentRowIndex].Cells["Free"].Value + "";
                    f.GiftCodeOther = frm.GiftCode + "";
                    f.Approve = "";
                    f.Remark = "";
                    dicFreeTrans.Add(dickey, f);
                }
                else
                {
                    FreeTrans f = new FreeTrans();

                    f.SONo = txtSONo.Text;
                    f.VN = txtMO.Text;
                    f.MS_Code = dataGridViewSelectList.Rows[currentRowIndex].Cells["Code"].Value + "";
                    f.ListOrder = dataGridViewSelectList.Rows[currentRowIndex].Cells["ListOrder"].Value + "";
                    f.FreeType = dataGridViewSelectList.Rows[currentRowIndex].Cells["Free"].Value + "";
                    f.GiftCodeOther = frm.GiftCode + "";
                    f.Approve = "";
                    f.Remark = "";
                    dicFreeTrans.Add(dickey, f);

                }



                frm.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void PopComplication()
        {
            try
            {


                string dickey = string.Format("{0}{1}{2}{3}", txtSONo.Text, txtMO.Text, dataGridViewSelectList.Rows[currentRowIndex].Cells["Code"].Value + "", dataGridViewSelectList.Rows[currentRowIndex].Cells["ListOrder"].Value + "");
                string Approve1 = "";
                string Approve2 = "";
                if (dicFreeTrans.ContainsKey(dickey))
                {
                    Approve1 = dicFreeTrans[dickey].Approve;
                    Approve2 = dicFreeTrans[dickey].Approve2;
                }
                FrmFreeComplication frm = new FrmFreeComplication();
                frm.ApploveID1 = Approve1;
                frm.ApploveID2 = Approve2;
                frm.Sono = txtSONo.Text;
                frm.VN = txtMO.Text;
                frm.CustomerName = txtCustomerName.Text;
                frm.MS_Code = dataGridViewSelectList.Rows[currentRowIndex].Cells["Code"].Value + "";
                frm.ListOrder = dataGridViewSelectList.Rows[currentRowIndex].Cells["ListOrder"].Value + "";
                frm.MS_Name = dataGridViewSelectList.Rows[currentRowIndex].Cells["Name"].Value + "";
                frm.MS_Price = Convert.ToDouble(dataGridViewSelectList.Rows[currentRowIndex].Cells["Price/Unit"].Value + "");
                frm.Amount = Convert.ToDouble(dataGridViewSelectList.Rows[currentRowIndex].Cells["Amount"].Value + "");
                frm.CN = CN;
                frm.ShowDialog();
                //MessageBox.Show(frm.GiftCode + "");

                if (frm.ApploveID1 == "" || frm.ApploveID2 == "")// ถ้าไม่เลือก หรือเลือกแค่คนเดียว
                {
                    dataGridViewSelectList.Rows[currentRowIndex].Cells["GiftNumber"].Value = "";
                    dataGridViewSelectList.Rows[currentRowIndex].Cells["Free"].Value = "";
                    dataGridViewSelectList.Rows[currentRowIndex].Cells["SpecialPrice"].Value = 0;
                    dataGridViewSelectList.EndEdit();
                    dataGridViewSelectList.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                else
                {
                    double dblTotalAmount = double.Parse(dataGridViewSelectList.Rows[currentRowIndex].Cells["Amount"].Value + "");// * (dataGridViewSelectList.Rows[currentRowIndex].Cells["No./Course"].Value + "" == "" ? 1 : double.Parse(dataGridViewSelectList.Rows[currentRowIndex].Cells["No./Course"].Value + "")));
                    double pricePer = dataGridViewSelectList.Rows[currentRowIndex].Cells["Price/Unit"].Value + "" == "" ? 0 : double.Parse(dataGridViewSelectList.Rows[currentRowIndex].Cells["Price/Unit"].Value + "");
                    double SpecialPriceOld = dataGridViewSelectList.Rows[currentRowIndex].Cells["SpecialPrice"].Value + "" == "" ? 0 : double.Parse(dataGridViewSelectList.Rows[currentRowIndex].Cells["SpecialPrice"].Value + "");

                    dblTotalAmount = dblTotalAmount * pricePer;
                    dataGridViewSelectList.Rows[currentRowIndex].Cells["SpecialPrice"].Value = dblTotalAmount * -1;
                    dataGridViewSelectList.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                if (dicFreeTrans.ContainsKey(dickey))
                {
                    if (!dicFreeTransDel.ContainsKey(dickey))
                        dicFreeTransDel.Add(dickey, dicFreeTrans[dickey]);
                    dicFreeTrans.Remove(dickey);
                    FreeTrans f = new FreeTrans();

                    f.SONo = txtSONo.Text;
                    f.VN = txtMO.Text;
                    f.MS_Code = dataGridViewSelectList.Rows[currentRowIndex].Cells["Code"].Value + "";
                    f.ListOrder = dataGridViewSelectList.Rows[currentRowIndex].Cells["ListOrder"].Value + "";
                    f.FreeType = dataGridViewSelectList.Rows[currentRowIndex].Cells["Free"].Value + "";
                    f.GiftCodeOther = "";
                    f.Approve = frm.ApploveID1 + "";
                    f.Approve2 = frm.ApploveID2 + "";
                    f.Remark = "";
                    dicFreeTrans.Add(dickey, f);
                }
                else
                {
                    FreeTrans f = new FreeTrans();

                    f.SONo = txtSONo.Text;
                    f.VN = txtMO.Text;
                    f.MS_Code = dataGridViewSelectList.Rows[currentRowIndex].Cells["Code"].Value + "";
                    f.ListOrder = dataGridViewSelectList.Rows[currentRowIndex].Cells["ListOrder"].Value + "";
                    f.FreeType = dataGridViewSelectList.Rows[currentRowIndex].Cells["Free"].Value + "";
                    f.GiftCodeOther = "";
                    f.Approve = frm.ApploveID1 + "";
                    f.Approve2 = frm.ApploveID2 + "";
                    f.Remark = "";
                    dicFreeTrans.Add(dickey, f);

                }



                frm.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void PopMarketing()
        {
            try
            {

                string dickey = string.Format("{0}{1}{2}{3}", txtSONo.Text, txtMO.Text, dataGridViewSelectList.Rows[currentRowIndex].Cells["Code"].Value + "", dataGridViewSelectList.Rows[currentRowIndex].Cells["ListOrder"].Value + "");
                string Approve = "";
                string Remark = "";
                if (dicFreeTrans.ContainsKey(dickey))
                {
                    Approve = dicFreeTrans[dickey].Approve;
                    Remark = dicFreeTrans[dickey].Remark;

                }
                FrmFreeMarketing frm = new FrmFreeMarketing();
                frm.ApploveID = Approve;
                frm.Remark = Remark;
                frm.Sono = txtSONo.Text;
                frm.VN = txtMO.Text;
                frm.CustomerName = txtCustomerName.Text;
                frm.MS_Code = dataGridViewSelectList.Rows[currentRowIndex].Cells["Code"].Value + "";
                frm.ListOrder = dataGridViewSelectList.Rows[currentRowIndex].Cells["ListOrder"].Value + "";
                frm.MS_Name = dataGridViewSelectList.Rows[currentRowIndex].Cells["Name"].Value + "";
                frm.MS_Price = Convert.ToDouble(dataGridViewSelectList.Rows[currentRowIndex].Cells["Price/Unit"].Value + "");
                frm.Amount = Convert.ToDouble(dataGridViewSelectList.Rows[currentRowIndex].Cells["Amount"].Value + "");
                frm.CN = CN;
                frm.ShowDialog();
                //MessageBox.Show(frm.GiftCode + "");

                if (frm.ApploveID == "")//ถ้าไม่เลือก เลย
                {
                    dataGridViewSelectList.Rows[currentRowIndex].Cells["GiftNumber"].Value = "";
                    dataGridViewSelectList.Rows[currentRowIndex].Cells["Free"].Value = "";
                    dataGridViewSelectList.Rows[currentRowIndex].Cells["SpecialPrice"].Value = 0;
                    dataGridViewSelectList.EndEdit();
                    dataGridViewSelectList.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                else
                {
                    double dblTotalAmount = double.Parse(dataGridViewSelectList.Rows[currentRowIndex].Cells["Amount"].Value + "");//* (dataGridViewSelectList.Rows[currentRowIndex].Cells["No./Course"].Value + "" == "" ? 1 : double.Parse(dataGridViewSelectList.Rows[currentRowIndex].Cells["No./Course"].Value + "")));
                    double pricePer = dataGridViewSelectList.Rows[currentRowIndex].Cells["Price/Unit"].Value + "" == "" ? 0 : double.Parse(dataGridViewSelectList.Rows[currentRowIndex].Cells["Price/Unit"].Value + "");
                    double SpecialPriceOld = dataGridViewSelectList.Rows[currentRowIndex].Cells["SpecialPrice"].Value + "" == "" ? 0 : double.Parse(dataGridViewSelectList.Rows[currentRowIndex].Cells["SpecialPrice"].Value + "");

                    dblTotalAmount = dblTotalAmount * pricePer;
                    dataGridViewSelectList.Rows[currentRowIndex].Cells["SpecialPrice"].Value = dblTotalAmount * -1;
                    dataGridViewSelectList.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                if (dicFreeTrans.ContainsKey(dickey))
                {
                    if (!dicFreeTransDel.ContainsKey(dickey))
                        dicFreeTransDel.Add(dickey, dicFreeTrans[dickey]);
                    dicFreeTrans.Remove(dickey);
                    FreeTrans f = new FreeTrans();
                    f.SONo = txtSONo.Text;
                    f.VN = txtMO.Text;
                    f.MS_Code = dataGridViewSelectList.Rows[currentRowIndex].Cells["Code"].Value + "";
                    f.ListOrder = dataGridViewSelectList.Rows[currentRowIndex].Cells["ListOrder"].Value + "";
                    f.FreeType = dataGridViewSelectList.Rows[currentRowIndex].Cells["Free"].Value + "";
                    f.GiftCodeOther = "";
                    f.Approve = frm.ApploveID + "";
                    f.ApproveTxt = frm.Applove1Txt + "";
                    f.Remark = frm.Remark + "";
                    dicFreeTrans.Add(dickey, f);
                    //dicFreeTrans[dickey].Approve = frm.ApploveID + "";
                    //dicFreeTrans[dickey].Remark = frm.Remark + "";
                    //dicFreeTrans[dickey].GiftCodeOther = "";
                    //dicFreeTrans[dickey].Approve = "";
                    //dicFreeTrans[dickey].Approve2 = "";
                    //dicFreeTrans[dickey].Remark = "";
                }
                else
                {
                    FreeTrans f = new FreeTrans();
                    f.SONo = txtSONo.Text;
                    f.VN = txtMO.Text;
                    f.MS_Code = dataGridViewSelectList.Rows[currentRowIndex].Cells["Code"].Value + "";
                    f.ListOrder = dataGridViewSelectList.Rows[currentRowIndex].Cells["ListOrder"].Value + "";
                    f.FreeType = dataGridViewSelectList.Rows[currentRowIndex].Cells["Free"].Value + "";
                    f.GiftCodeOther = "";
                    f.Approve = frm.ApploveID + "";
                    f.ApproveTxt = frm.Applove1Txt + "";
                    f.Remark = frm.Remark + "";
                    dicFreeTrans.Add(dickey, f);

                }



                frm.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void PopBenefits()
        {
            try
            {
                string ms_code = dataGridViewSelectList.Rows[currentRowIndex].Cells["Code"].Value + "";
                if (!ms_code.ToLower().Contains("atb") && !ms_code.ToLower().Contains("atf") && !ms_code.ToLower().Contains("adl") && !(Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN))
                {
                    //dataGridViewSelectList.Rows[currentRowIndex].Cells["Free"].Value = "";
                    dataGridViewSelectList.Rows[currentRowIndex].Cells["SpecialPrice"].Value = 0;
                    dataGridViewSelectList.EndEdit();
                    dataGridViewSelectList.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    //MessageBox.Show("ATB,ATF Only", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // return;
                }
                string dickey = string.Format("{0}{1}{2}{3}", txtSONo.Text, txtMO.Text, dataGridViewSelectList.Rows[currentRowIndex].Cells["Code"].Value + "", dataGridViewSelectList.Rows[currentRowIndex].Cells["ListOrder"].Value + "");
                string Approve = "";
                string Remark = "";
                if (dicFreeTrans.ContainsKey(dickey))
                {
                    Approve = dicFreeTrans[dickey].Approve;
                    Remark = dicFreeTrans[dickey].Remark;

                }
                FrmFreeBenefits frm = new FrmFreeBenefits();
                frm.ApploveID = Approve;
                frm.Remark = Remark;
                frm.Sono = txtSONo.Text;
                frm.VN = txtMO.Text;
                frm.CustomerName = txtCustomerName.Text;
                frm.MS_Code = dataGridViewSelectList.Rows[currentRowIndex].Cells["Code"].Value + "";
                frm.ListOrder = dataGridViewSelectList.Rows[currentRowIndex].Cells["ListOrder"].Value + "";
                frm.MS_Price = Convert.ToDouble(dataGridViewSelectList.Rows[currentRowIndex].Cells["Price/Unit"].Value + "");
                frm.Amount = Convert.ToDouble(dataGridViewSelectList.Rows[currentRowIndex].Cells["Amount"].Value + "");
                frm.MS_Name = dataGridViewSelectList.Rows[currentRowIndex].Cells["Name"].Value + "";
                frm.CN = CN;
                frm.ShowDialog();
                //MessageBox.Show(frm.GiftCode + "");

                if (frm.ApploveID == "")//ถ้าไม่เลือก เลย
                {
                    dataGridViewSelectList.Rows[currentRowIndex].Cells["GiftNumber"].Value = "";
                    dataGridViewSelectList.Rows[currentRowIndex].Cells["Free"].Value = "";
                    dataGridViewSelectList.Rows[currentRowIndex].Cells["SpecialPrice"].Value = 0;
                    dataGridViewSelectList.EndEdit();
                    dataGridViewSelectList.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                else//ถ้าเลือก ให้ ใส่ special เท่ากับมูลค่าและติ๊กค่าคอมออก
                {
                    double dblTotalAmount = double.Parse(dataGridViewSelectList.Rows[currentRowIndex].Cells["Amount"].Value + "");//* (dataGridViewSelectList.Rows[currentRowIndex].Cells["No./Course"].Value + "" == "" ? 1 : double.Parse(dataGridViewSelectList.Rows[currentRowIndex].Cells["No./Course"].Value + "")));
                    double pricePer = dataGridViewSelectList.Rows[currentRowIndex].Cells["Price/Unit"].Value + "" == "" ? 0 : double.Parse(dataGridViewSelectList.Rows[currentRowIndex].Cells["Price/Unit"].Value + "");
                    double SpecialPriceOld = dataGridViewSelectList.Rows[currentRowIndex].Cells["SpecialPrice"].Value + "" == "" ? 0 : double.Parse(dataGridViewSelectList.Rows[currentRowIndex].Cells["SpecialPrice"].Value + "");

                    dblTotalAmount = dblTotalAmount * pricePer;
                    dataGridViewSelectList.Rows[currentRowIndex].Cells["SpecialPrice"].Value = dblTotalAmount * -1;



                    DataGridViewCheckBoxCell chSaleCom = new DataGridViewCheckBoxCell();
                    chSaleCom = (DataGridViewCheckBoxCell)dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells["chkSaleCom"];
                    DataGridViewCheckBoxCell chBydr = new DataGridViewCheckBoxCell();
                    chBydr = (DataGridViewCheckBoxCell)dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells["chkBydr"];
                    if (chSaleCom.Value == null && chBydr.Value == null)
                        return;
                    else
                    {
                        chSaleCom.Value = "false";
                        chBydr.Value = "false";
                        //dataGridViewSelectList.Rows[currentRowIndex].Cells["chkSaleCom"].Value = dblTotalAmount * -1;
                        //dataGridViewSelectList.Rows[currentRowIndex].Cells["chkBydr"].Value = dblTotalAmount * -1;
                    }



                    dataGridViewSelectList.EndEdit();
                    dataGridViewSelectList.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                if (dicFreeTrans.ContainsKey(dickey))
                {
                    if (!dicFreeTransDel.ContainsKey(dickey))
                        dicFreeTransDel.Add(dickey, dicFreeTrans[dickey]);
                    dicFreeTrans.Remove(dickey);
                    FreeTrans f = new FreeTrans();

                    f.SONo = txtSONo.Text;
                    f.VN = txtMO.Text;
                    f.MS_Code = dataGridViewSelectList.Rows[currentRowIndex].Cells["Code"].Value + "";
                    f.ListOrder = dataGridViewSelectList.Rows[currentRowIndex].Cells["ListOrder"].Value + "";
                    f.FreeType = dataGridViewSelectList.Rows[currentRowIndex].Cells["Free"].Value + "";
                    f.GiftCodeOther = "";
                    f.Approve = frm.ApploveID + "";
                    f.Remark = frm.Remark + "";
                    dicFreeTrans.Add(dickey, f);
                }
                else
                {
                    FreeTrans f = new FreeTrans();

                    f.SONo = txtSONo.Text;
                    f.VN = txtMO.Text;
                    f.MS_Code = dataGridViewSelectList.Rows[currentRowIndex].Cells["Code"].Value + "";
                    f.ListOrder = dataGridViewSelectList.Rows[currentRowIndex].Cells["ListOrder"].Value + "";
                    f.FreeType = dataGridViewSelectList.Rows[currentRowIndex].Cells["Free"].Value + "";
                    f.GiftCodeOther = "";
                    f.Approve = frm.ApploveID + "";
                    f.Remark = frm.Remark + "";
                    dicFreeTrans.Add(dickey, f);

                }


                //dataGridViewSelectList.EndEdit();
                //dataGridViewSelectList.CommitEdit(DataGridViewDataErrorContexts.Commit);

                frm.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void PopSubjectTraining()
        {
            try
            {


                string dickey = string.Format("{0}{1}{2}{3}", txtSONo.Text, txtMO.Text, dataGridViewSelectList.Rows[currentRowIndex].Cells["Code"].Value + "", dataGridViewSelectList.Rows[currentRowIndex].Cells["ListOrder"].Value + "");
                string Approve1 = "";
                string Remark = "";
                if (dicFreeTrans.ContainsKey(dickey))
                {
                    Approve1 = dicFreeTrans[dickey].Approve;
                    Remark = dicFreeTrans[dickey].Remark;
                }
                FrmSubjectTraining frm = new FrmSubjectTraining();
                frm.ApploveID = Approve1;
                frm.Remark = Remark;
                frm.Sono = txtSONo.Text;
                frm.VN = txtMO.Text;
                frm.CustomerName = txtCustomerName.Text;
                frm.MS_Code = dataGridViewSelectList.Rows[currentRowIndex].Cells["Code"].Value + "";
                frm.ListOrder = dataGridViewSelectList.Rows[currentRowIndex].Cells["ListOrder"].Value + "";
                frm.MS_Name = dataGridViewSelectList.Rows[currentRowIndex].Cells["Name"].Value + "";
                frm.MS_Price = Convert.ToDouble(dataGridViewSelectList.Rows[currentRowIndex].Cells["Price/Unit"].Value + "");
                frm.Amount = Convert.ToDouble(dataGridViewSelectList.Rows[currentRowIndex].Cells["Amount"].Value + "");
                frm.CN = CN;
                frm.ShowDialog();
                //MessageBox.Show(frm.GiftCode + "");
                if (frm.ApploveID == "")//ถ้าไม่เลือก เลย
                {
                    dataGridViewSelectList.Rows[currentRowIndex].Cells["GiftNumber"].Value = "";
                    dataGridViewSelectList.Rows[currentRowIndex].Cells["Free"].Value = "";
                    dataGridViewSelectList.Rows[currentRowIndex].Cells["SpecialPrice"].Value = 0;
                    dataGridViewSelectList.EndEdit();
                    dataGridViewSelectList.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                else
                {
                    double dblTotalAmount = double.Parse(dataGridViewSelectList.Rows[currentRowIndex].Cells["Amount"].Value + "");//* (dataGridViewSelectList.Rows[currentRowIndex].Cells["No./Course"].Value + "" == "" ? 1 : double.Parse(dataGridViewSelectList.Rows[currentRowIndex].Cells["No./Course"].Value + "")));
                    double pricePer = dataGridViewSelectList.Rows[currentRowIndex].Cells["Price/Unit"].Value + "" == "" ? 0 : double.Parse(dataGridViewSelectList.Rows[currentRowIndex].Cells["Price/Unit"].Value + "");
                    double SpecialPriceOld = dataGridViewSelectList.Rows[currentRowIndex].Cells["SpecialPrice"].Value + "" == "" ? 0 : double.Parse(dataGridViewSelectList.Rows[currentRowIndex].Cells["SpecialPrice"].Value + "");

                    dblTotalAmount = dblTotalAmount * pricePer;
                    dataGridViewSelectList.Rows[currentRowIndex].Cells["SpecialPrice"].Value = dblTotalAmount * -1;
                    dataGridViewSelectList.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                if (dicFreeTrans.ContainsKey(dickey))
                {
                    if (!dicFreeTransDel.ContainsKey(dickey))
                        dicFreeTransDel.Add(dickey, dicFreeTrans[dickey]);
                    dicFreeTrans.Remove(dickey);
                    FreeTrans f = new FreeTrans();

                    f.SONo = txtSONo.Text;
                    f.VN = txtMO.Text;
                    f.MS_Code = dataGridViewSelectList.Rows[currentRowIndex].Cells["Code"].Value + "";
                    f.ListOrder = dataGridViewSelectList.Rows[currentRowIndex].Cells["ListOrder"].Value + "";
                    f.FreeType = dataGridViewSelectList.Rows[currentRowIndex].Cells["Free"].Value + "";
                    f.GiftCodeOther = "";
                    f.Approve = frm.ApploveID + "";
                    f.Approve2 = "";
                    f.Remark = frm.Remark + "";

                    dicFreeTrans.Add(dickey, f);
                }
                else
                {
                    FreeTrans f = new FreeTrans();

                    f.SONo = txtSONo.Text;
                    f.VN = txtMO.Text;
                    f.MS_Code = dataGridViewSelectList.Rows[currentRowIndex].Cells["Code"].Value + "";
                    f.ListOrder = dataGridViewSelectList.Rows[currentRowIndex].Cells["ListOrder"].Value + "";
                    f.FreeType = dataGridViewSelectList.Rows[currentRowIndex].Cells["Free"].Value + "";
                    f.GiftCodeOther = "";
                    f.Approve = frm.ApploveID + "";
                    f.Approve2 = "";
                    f.Remark = frm.Remark + "";

                    dicFreeTrans.Add(dickey, f);

                }



                frm.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void PopComplementary()
        {
            try
            {


                string dickey = string.Format("{0}{1}{2}{3}", txtSONo.Text, txtMO.Text, dataGridViewSelectList.Rows[currentRowIndex].Cells["Code"].Value + "", dataGridViewSelectList.Rows[currentRowIndex].Cells["ListOrder"].Value + "");
                string Approve1 = "";
                string Remark = "";
                //if (dicFreeTrans.ContainsKey(dickey))
                //{
                //    Approve1 = dicFreeTrans[dickey].Approve;
                //    Remark = dicFreeTrans[dickey].Remark;
                //}
                //FrmSubjectTraining frm = new FrmSubjectTraining();
                //frm.ApploveID = Approve1;
                //frm.Remark = Remark;
                //frm.ShowDialog();
                //MessageBox.Show(frm.GiftCode + "");

                double dblTotalAmount = double.Parse(dataGridViewSelectList.Rows[currentRowIndex].Cells["Amount"].Value + "");//* (dataGridViewSelectList.Rows[currentRowIndex].Cells["No./Course"].Value + "" == "" ? 1 : double.Parse(dataGridViewSelectList.Rows[currentRowIndex].Cells["No./Course"].Value + "")));
                double pricePer = dataGridViewSelectList.Rows[currentRowIndex].Cells["Price/Unit"].Value + "" == "" ? 0 : double.Parse(dataGridViewSelectList.Rows[currentRowIndex].Cells["Price/Unit"].Value + "");
                double SpecialPriceOld = dataGridViewSelectList.Rows[currentRowIndex].Cells["SpecialPrice"].Value + "" == "" ? 0 : double.Parse(dataGridViewSelectList.Rows[currentRowIndex].Cells["SpecialPrice"].Value + "");

                dblTotalAmount = dblTotalAmount * pricePer;
                if (dicFreeTrans.ContainsKey(dickey))
                {
                    if (!dicFreeTransDel.ContainsKey(dickey))
                        dicFreeTransDel.Add(dickey, dicFreeTrans[dickey]);
                    dicFreeTrans.Remove(dickey);

                    FreeTrans f = new FreeTrans();

                    f.SONo = txtSONo.Text;
                    f.VN = txtMO.Text;
                    f.MS_Code = dataGridViewSelectList.Rows[currentRowIndex].Cells["Code"].Value + "";
                    f.ListOrder = dataGridViewSelectList.Rows[currentRowIndex].Cells["ListOrder"].Value + "";
                    f.FreeType = dataGridViewSelectList.Rows[currentRowIndex].Cells["Free"].Value + "";
                    //f.MS_Price = Convert.ToDouble(dataGridViewSelectList.Rows[currentRowIndex].Cells["Price/Unit"].Value + "");
                    //f.Amount = Convert.ToDouble(dataGridViewSelectList.Rows[currentRowIndex].Cells["Amount"].Value + "");
                    f.GiftCodeOther = "";
                    f.Approve = "";
                    f.Approve2 = "";
                    f.Remark = "";

                    dicFreeTrans.Add(dickey, f);
                }
                else
                {
                    FreeTrans f = new FreeTrans();

                    f.SONo = txtSONo.Text;
                    f.VN = txtMO.Text;
                    f.MS_Code = dataGridViewSelectList.Rows[currentRowIndex].Cells["Code"].Value + "";
                    f.ListOrder = dataGridViewSelectList.Rows[currentRowIndex].Cells["ListOrder"].Value + "";
                    f.FreeType = dataGridViewSelectList.Rows[currentRowIndex].Cells["Free"].Value + "";
                    f.GiftCodeOther = "";
                    f.Approve = "";
                    f.Approve2 = "";
                    f.Remark = "";

                    dicFreeTrans.Add(dickey, f);

                }

                dataGridViewSelectList.Rows[currentRowIndex].Cells["SpecialPrice"].Value = dblTotalAmount * -1;
                dataGridViewSelectList.CommitEdit(DataGridViewDataErrorContexts.Commit);

                // frm.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewSelectList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //DataGridViewCheckBoxCell ch0 = new DataGridViewCheckBoxCell();
                //ch0 = (DataGridViewCheckBoxCell)dataGridViewSelectList.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (e.ColumnIndex < 0 || e.RowIndex < 0) return;



                //Entity.SupplieTrans supplieInfo = new Entity.SupplieTrans();
                //supplieInfo = new Entity.SupplieTrans();
                //supplieInfo.VN = txtMO.Text;
                //supplieInfo.SONo = txtSONo.Text;
                //supplieInfo.MS_Code = dataGridViewSelectList.Rows[e.RowIndex].Cells["Code"].Value + "";
                //supplieInfo.ListOrder = dataGridViewSelectList.Rows[e.RowIndex].Cells["ListOrder"].Value + "";
                decimal SUMPriceAfterDis = 0;

                if (e.ColumnIndex != dataGridViewSelectList.Rows[e.RowIndex].Cells["Name"].ColumnIndex) return;
                string MS_Code = dataGridViewSelectList.Rows[e.RowIndex].Cells["Code"].Value + "";

                //========================Sun item Other================================
                if (Entity.Userinfo.FIX_OTHER_SUB.Contains(MS_Code))
                {
                    popSubItemOther pop = new popSubItemOther();

                    var MaxID2ListOrder = 0;
                    if (dataGridViewSelectList.RowCount == 0)
                        MaxID2ListOrder = 0;
                    else
                        MaxID2ListOrder = dataGridViewSelectList.Rows.Cast<DataGridViewRow>().Max(r => int.TryParse(r.Cells["ListOrder"].Value.ToString(), out MaxID2ListOrder) ? MaxID2ListOrder : 0);

                    pop.customerType = customerType;
                    pop.VN = VN;
                    pop.SONo = SO;
                    pop.CN = CN;
                    pop.EN_COMS1 = comboBoxCommission1.SelectedValue + "";
                    pop.CustName = txtCustomerName.Text;
                    pop.MS_CodeM = dataGridViewSelectList.Rows[e.RowIndex].Cells["Code"].Value + "";
                    pop.ListOrderM = dataGridViewSelectList.Rows[e.RowIndex].Cells["ListOrder"].Value + "";
                    pop.PriceTotal = dataGridViewSelectList.Rows[e.RowIndex].Cells["PriceTotal"].Value + "" == "" ? 0 : Convert.ToDecimal(dataGridViewSelectList.Rows[e.RowIndex].Cells["PriceTotal"].Value + "");
                    pop.Text = dataGridViewSelectList.Rows[e.RowIndex].Cells["Name"].Value + "/" + pop.PriceTotal.ToString("###,###,###.##");
                    //pop.MainUnitCode = dataGridViewSelectList.Rows[e.RowIndex].Cells["MainUnitCode"].Value + "";
                    //pop.MainUnitName = dataGridViewSelectList.Rows[e.RowIndex].Cells["MainUnitName"].Value + "";
                    //pop.SubUnitCode = dataGridViewSelectList.Rows[e.RowIndex].Cells["SubUnitCode"].Value + "";
                    //pop.SubUnitName = dataGridViewSelectList.Rows[e.RowIndex].Cells["SubUnitName"].Value + "";
                    if (pop.ShowDialog() == DialogResult.OK)
                    {
                        listSupOther = pop.listSupOther;
                    }
                    if (pop.SUMPriceAfterDis != pop.PriceTotal)
                        dataGridViewSelectList.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;//Color.Red;
                    else
                        dataGridViewSelectList.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                }
                else if (Entity.Userinfo.FIX_COUPON_Wallet.Contains(MS_Code))
                {
                    ////========================แบบเปิด SO=====================
                    //string SOnoSub=dataGridViewSelectList.Rows[e.RowIndex].Cells["SOnoSub"].Value + "";
                    //if (SOnoSub.Length > 5)//คลิกที่คูปอง เปิด SO
                    //{
                    //    //===========เปิด แบบ มี SORef อ้างอิงชชชชชชชชชชช
                    //    //if (dgvData.Rows[rowIndex].Cells["SORef"].Value + "" != "")
                    //        Statics.frmMedicalOrderSettingPro = new FrmMedicalOrderSettingPro();
                    //        Statics.frmMedicalOrderSettingPro.FormType = DerUtility.AccessType.Update;
                    //        Statics.frmMedicalOrderSettingPro.Text = Text + Statics.StrEdit;
                    //        Statics.frmMedicalOrderSettingPro.SO = SOnoSub;
                    //        //Statics.frmMedicalOrderSettingPro.MedStatus_Code = dgvData.Rows[rowIndex].Cells["MedStatus_Code"].Value + "";
                    //        Statics.frmMedicalOrderSettingPro.SORef = SO;
                    //        //Statics.frmMedicalOrderSettingPro.ProCreditRemain = dgvData.Rows[rowIndex].Cells["PriceCreditRef"].Value + "" == "" ? 0 : Convert.ToDecimal(dgvData.Rows[rowIndex].Cells["PriceCreditRef"].Value + "");
                    //        Statics.frmMedicalOrderSettingPro.BackColor = Color.FromArgb(255, 230, 217);
                    //        Statics.frmMedicalOrderSettingPro.Show(Statics.frmMain.dockPanel1);
                    //        return;
                    //}
                    ////========================แบบเปิด SO=====================

                    //========================แบบเปิด หน้าต่าง โปร=====================
                    popSelectPromotion pop = new popSelectPromotion();

                    pop.customerType = customerType;
                    pop.VN = VN;
                    pop.SONo = SO;
                    pop.SOno_Sub = dataGridViewSelectList.Rows[e.RowIndex].Cells["SOnoSub"].Value + "";
                    pop.VN_Sub = dataGridViewSelectList.Rows[e.RowIndex].Cells["VNSub"].Value + "";

                    pop.MS_CodeM = dataGridViewSelectList.Rows[e.RowIndex].Cells["Code"].Value + "";
                    pop.ListOrderM = dataGridViewSelectList.Rows[e.RowIndex].Cells["ListOrder"].Value + "";
                    pop.PriceTotal = COUPON_Price = dataGridViewSelectList.Rows[e.RowIndex].Cells["PriceTotal"].Value + "" == "" ? 0 : Convert.ToDecimal(dataGridViewSelectList.Rows[e.RowIndex].Cells["PriceTotal"].Value + "");
                    pop.Text = dataGridViewSelectList.Rows[e.RowIndex].Cells["Name"].Value + "/" + pop.PriceTotal.ToString("###,###,###.##");
                    //pop.MainUnitCode = dataGridViewSelectList.Rows[e.RowIndex].Cells["MainUnitCode"].Value + "";
                    //pop.MainUnitName = dataGridViewSelectList.Rows[e.RowIndex].Cells["MainUnitName"].Value + "";
                    //pop.SubUnitCode = dataGridViewSelectList.Rows[e.RowIndex].Cells["SubUnitCode"].Value + "";
                    //pop.SubUnitName = dataGridViewSelectList.Rows[e.RowIndex].Cells["SubUnitName"].Value + "";
                    if (pop.ShowDialog() == DialogResult.OK)
                    {
                        if (pop.listSupOther.Any())
                        {
                            listSupOther = pop.listSupOther;
                            PRO_CodeGift = listSupOther[0].PRO_Code;
                            dataGridViewSelectList.Rows[e.RowIndex].Cells["Note"].Value = listSupOther[0].MS_Name;
                        }
                    }
                    if (pop.SUMPriceAfterDis != pop.PriceTotal)
                        dataGridViewSelectList.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;//Color.Red;
                    else
                        dataGridViewSelectList.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFreeApplove_Click(object sender, EventArgs e)
        {
            BindReportSO(1);
            FreeApplove(dsData.Tables[0]);
        }

        private void FreeApplove(DataTable dtTmp)
        {
            try
            {
                FrmPreviewRpt obj = new FrmPreviewRpt();
                DataRow dr;
                obj.PrintType = "";
                //DataTable dtTmp;
                //dtSumOfTreatPay
                //string sql = "[Vat] <> 'Y'";
                //if (dtSumOfTreat.Select(sql).Any())
                //    dtTmp = dtSumOfTreat.Select(sql).CopyToDataTable();
                //else
                //    return;

                ////dtTmp = dtSumOfTreat;
                //string dickey = string.Format("{0}{1}{2}{3}", txtSONo.Text, txtMO.Text, dataGridViewSelectList.Rows[currentRowIndex].Cells["Code"].Value + "", dataGridViewSelectList.Rows[currentRowIndex].Cells["ListOrder"].Value + "");
                //if (dicFreeTrans.ContainsKey(dickey))
                //{ 

                //}


                foreach (DataRow item in dtTmp.Rows)
                {
                    if (item["ApproveDr"] + "" != "") obj.ApploveDr = item["ApproveDr"] + "";
                    if (item["Approve2"] + "" != "") obj.Applove2 = item["Approve2"] + "";
                    if (item["Remark"] + "" != "") obj.ApploveRemark = item["Remark"] + "";
                }

                //foreach (KeyValuePair<string, FreeTrans> item in dicFreeTrans)
                //{
                //    if (item.Value.Approve != "") obj.ApploveDr = item.Value.ApproveTxt;
                //    if (item.Value.Approve2 != "") obj.Applove2 = item.Value.Approve2Txt;
                //    if (item.Value.Remark != "") obj.ApploveRemark = item.Value.Remark;

                //}

                string strTypeofPay = "";
                obj.FormName = "RptMedicalOrderFreeApplove";
                //obj.ApploveDr = "RptMedicalOrderFreeApplove";
                //obj.Applove2 = "RptMedicalOrderFreeApplove";
                //obj.ApploveRemark = "RptMedicalOrderFreeApplove";
                //int disByItem= Convert.ToInt32(dtTmp.Compute("Sum(DiscountBathByItem)", "");
                //if (Convert.ToInt32(dtTmp.Compute("Sum(DiscountBathByItem)", "")) > 0 || (txtIntDiscountBath.Text != "" && txtIntDiscountBath.Text != "0.00"))
                //    obj.HasDiscount = true;

                double dblCredit = 0.00;
                double dblCash = 0.00;
                string strBankName = "";

                //dblCredit += dblCash;
                //obj.TypeOfPayment = strTypeofPay;
                //obj.PayToday = dblCredit.ToString("###,###,##0.00");

                //obj.SumUnpaid = Convert.ToDouble(dtTmp.Rows[0]["Unpaid"]);//.Compute("Sum(Unpaid)", ""));
                obj.dt = dtTmp;
                obj.MaximizeBox = true;
                obj.TopMost = true;
                obj.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewSelectList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
                //===================ไม่ให้ติ๊ก ถ้าเป็น ลูกของ โปร
                if (dataGridViewSelectList.Rows[e.RowIndex].Cells["AmountPro"].Value + "" != "")
                {
                    dataGridViewSelectList.EndEdit();
                    foreach (DataGridViewRow item in dataGridViewSelectList.Rows)
                    {
                        item.Cells[0].Value = false;
                    }
                }
                //======================================

                List<Entity.SupplieTrans> listSup = new List<Entity.SupplieTrans>();

                Entity.SupplieTrans supplieInfo = new Entity.SupplieTrans();
                supplieInfo = new Entity.SupplieTrans();
                supplieInfo.VN = txtMO.Text;
                supplieInfo.SONo = txtSONo.Text;
                supplieInfo.MS_Code = dataGridViewSelectList.Rows[e.RowIndex].Cells["Code"].Value + "";
                supplieInfo.ListOrder = dataGridViewSelectList.Rows[e.RowIndex].Cells["ListOrder"].Value + "";

                listSup.Add(supplieInfo);

                foreach (Entity.SupplieTrans item in listSup)
                {

                    DataSet dsSurgeryFee = new Business.MedicalOrderUseTrans().SELECTSAVEDJOBCOST_COM(item.VN, item.SONo, item.MS_Code, item.ListOrder);
                    if (dsSurgeryFee.Tables.Count > 0 && dsSurgeryFee.Tables[0].Rows.Count > 0 && !(Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN) && !Userinfo.IS_ADMIN_EDIT.Contains(Userinfo.EN))//&& !Userinfo.IS_ADMIN_JOBCOST.Contains(Userinfo.EN)
                    {

                        dataGridViewSelectList.Rows[e.RowIndex].ReadOnly = true;
                        dataGridViewSelectListPro.ReadOnly = true;
                        //dataGridViewSelectList.Rows[e.RowIndex].Cells["chkCanceled"].ReadOnly = true;
                        //DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                        //ch1 = (DataGridViewCheckBoxCell)dataGridViewSelectList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        //if (ch1.Value == null)
                        //    return;
                        //else
                        //{
                        //    ch1.Value = ch0.Value;

                        //}
                        dataGridViewSelectList.CommitEdit(DataGridViewDataErrorContexts.CurrentCellChange);
                        dataGridViewSelectList.EndEdit();


                        //DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, "ไม่สามารถแก้ไขข้อมูลได้เนื่องจาก ได้บันทึกค่ามือและค่าแพทย์ไปแล้ว" + Environment.NewLine + "กรุณาติดต่อผู้ดูแลระบบ");
                        return;
                    }
                }


                if (e.ColumnIndex == dataGridViewSelectList.Columns["BtnMember"].Index)
                {
                    popMemberGroup frm = popMemberGroup.GetInstance();
                    frm.CN = CN;
                    frm.VN = VN;
                    frm.dicMemberTran = dicMemberTran;
                    frm.MS_Code = MS_Code = dataGridViewSelectList.Rows[e.RowIndex].Cells["Code"].Value + "";
                    frm.ShowDialog();
                    Thread.Sleep(100);

                    if (frm.DialogResult == DialogResult.OK)
                    {
                        if (!dicMemberTran.ContainsKey(MS_Code))
                            dicMemberTran.Add(MS_Code, frm.member);
                        else
                        {
                            dicMemberTran[MS_Code] = frm.member;
                        }
                    }
                    dataGridViewSelectList.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    dataGridViewSelectList.EndEdit();
                }


                if (e.ColumnIndex == dataGridViewSelectList.Columns["ChkPRO"].Index)//ใส่ add_Dis
                {

                    DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                    ch1 = (DataGridViewCheckBoxCell)dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells["ChkPRO"];
                    if (ch1.Value == null)
                        return;
                    else
                    {
                        if ((ch1.Value + "").ToLower() == "true")
                            ch1.Value = "false";
                        else
                            ch1.Value = "true";



                    }
                    if (e.ColumnIndex == dataGridViewSelectList.Columns["SpecialPrice"].Index || e.ColumnIndex == dataGridViewSelectList.Columns["SpecialPrice"].Index || e.ColumnIndex == dataGridViewSelectList.Columns["ChkPRO"].Index)
                        ISEndEdit = false;

                    SumPriceMedicalOrder();
                    dataGridViewSelectList.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    dataGridViewSelectList.EndEdit();
                }

                if (e.ColumnIndex == dataGridViewSelectList.Columns["chkCanceled"].Index)
                {
                    DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                    ch1 = (DataGridViewCheckBoxCell)dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells["chkCanceled"];
                    if (ch1.Value == null)
                        return;
                    else
                    {
                        if ((ch1.Value + "").ToLower() == "true")
                            ch1.Value = "false";
                        else
                        {
                            ch1.Value = "true";




                            double dblTotalAmount = double.Parse(dataGridViewSelectList.Rows[currentRowIndex].Cells["Amount"].Value + "");// * (dataGridViewSelectList.Rows[currentRowIndex].Cells["No./Course"].Value + "" == "" ? 1 : double.Parse(dataGridViewSelectList.Rows[currentRowIndex].Cells["No./Course"].Value + "")));
                            double pricePer = dataGridViewSelectList.Rows[currentRowIndex].Cells["Price/Unit"].Value + "" == "" ? 0 : double.Parse(dataGridViewSelectList.Rows[currentRowIndex].Cells["Price/Unit"].Value + "");
                            //double SpecialPriceOld = dataGridViewSelectList.Rows[currentRowIndex].Cells["SpecialPrice"].Value + "" == "" ? 0 : double.Parse(dataGridViewSelectList.Rows[currentRowIndex].Cells["SpecialPrice"].Value + "");

                            dblTotalAmount = dblTotalAmount * pricePer;

                            dataGridViewSelectList.Rows[currentRowIndex].Cells["SpecialPrice"].Value = dblTotalAmount * -1;
                            dataGridViewSelectList.CommitEdit(DataGridViewDataErrorContexts.Commit);
                            dataGridViewSelectList.EndEdit();
                        }
                    }
                }
                if (e.ColumnIndex == dataGridViewSelectList.Columns["chkSaleCom"].Index || e.ColumnIndex == dataGridViewSelectList.Columns["chkBydr"].Index)
                {
                    string SurgicalFeeNewTab = dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells["SurgicalFeeNewTab"].Value + "";
                    DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                    ch1 = (DataGridViewCheckBoxCell)dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells[e.ColumnIndex];
                    if (ch1.Value == null)
                        return;
                    else
                    {
                        if ((!Userinfo.IS_ADMIN_EDIT.Contains(Userinfo.EN) || (!(Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN) || !Userinfo.IS_ADMIN_JOBCOST.Contains(Userinfo.EN)) && SurgicalFeeNewTab.ToUpper() != "Y" || CN.Contains("CNS") || supplieInfo.MS_Code.Contains("(S)")))// ถ้าธรรมดา ไม่ใช้ติ๊กdataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells["Tab"].Value + "".ToUpper() == "PHARMACY"
                        {
                            ch1.Value = "false";

                        }
                        else //ถ้า admin  ปกติ
                        {
                            if ((ch1.Value + "").ToLower() == "true")
                                ch1.Value = "false";
                            else
                            {
                                ch1.Value = "true";
                            }
                        }


                    }
                    dataGridViewSelectList.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    dataGridViewSelectList.EndEdit();
                }

                if (e.ColumnIndex == dataGridViewSelectList.Columns["Amount"].Index)//คลิก Amount ตรวจสอบว่า ถ้าตัดคอร์สไปแล้ว ไม่ให้แก้จำนวน
                {
                    string ms = dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells["Code"].Value + "";
                    string lis = dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells["ListOrder"].Value + "";
                    DataSet dsUsed = new Business.MedicalOrderUseTrans().CheckUsedCourse(txtMO.Text, txtSONo.Text, ms, lis); // เช็ค ถ้ามีการตัดใช้แล้วไม่ให้แก้ไข จำนวน
                    if (dsUsed.Tables.Count > 0 && dsUsed.Tables[0].Rows.Count > 0 && !(Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN) && !Userinfo.IS_ADMIN_EDIT.Contains(Userinfo.EN))
                    {
                        dataGridViewSelectList.CommitEdit(DataGridViewDataErrorContexts.Commit);
                        dataGridViewSelectList.EndEdit();

                        dataGridViewSelectList.Rows[e.RowIndex].ReadOnly = true;
                        MessageBox.Show("ตัดการใช้งานไปแล้ว จะไม่สามารถแก้ไขตัวเลขได้", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return;
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void dataGridViewSelectList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dataGridViewSelectList.Columns["chkSaleCom"].Index || e.ColumnIndex == dataGridViewSelectList.Columns["chkBydr"].Index)
                {

                    DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                    ch1 = (DataGridViewCheckBoxCell)dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells[e.ColumnIndex];
                    if (ch1.Value == null)
                        return;
                    else
                    {
                        if ((Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN) || Userinfo.IS_ADMIN_EDIT.Contains(Userinfo.EN) || Userinfo.IS_ADMIN_JOBCOST.Contains(Userinfo.EN))//ถ้า admin  ปกติ
                        {
                            if ((ch1.Value + "").ToLower() == "true")
                                ch1.Value = "false";
                            else
                            {
                                ch1.Value = "true";
                            }
                        }
                        else// ถ้าธรรมดา ไม่ใช้ติ๊ก
                            ch1.Value = "false";

                    }
                }
                dataGridViewSelectList.CommitEdit(DataGridViewDataErrorContexts.Commit);
                dataGridViewSelectList.EndEdit();
                //if (e.ColumnIndex == dataGridViewSelectList.Columns["chkBydr"].Index || e.ColumnIndex == dataGridViewSelectList.Columns["chkSaleCom"].Index)
                //{
                //    DataGridViewCheckBoxCell ch0 = new DataGridViewCheckBoxCell();
                //    ch0 = (DataGridViewCheckBoxCell)dataGridViewSelectList.Rows[e.RowIndex].Cells[e.ColumnIndex];



                //    List<Entity.SupplieTrans> listSup = new List<Entity.SupplieTrans>();

                //    Entity.SupplieTrans supplieInfo = new Entity.SupplieTrans();
                //    supplieInfo = new Entity.SupplieTrans();
                //    supplieInfo.VN = txtMO.Text;
                //    supplieInfo.SONo = txtSONo.Text;
                //    supplieInfo.MS_Code = dataGridViewSelectList.Rows[e.RowIndex].Cells["Code"].Value + "";
                //    supplieInfo.ListOrder = dataGridViewSelectList.Rows[e.RowIndex].Cells["ListOrder"].Value + "";

                //    listSup.Add(supplieInfo);

                //    foreach (Entity.SupplieTrans item in listSup)
                //    {

                //        DataSet dsSurgeryFee = new Business.MedicalOrderUseTrans().SELECTSAVEDJOBCOST_COM(item.VN, item.SONo, item.MS_Code, item.ListOrder);
                //        if (dsSurgeryFee.Tables.Count > 0 && dsSurgeryFee.Tables[0].Rows.Count > 0 && !(Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN) && !Userinfo.IS_ADMIN_JOBCOST.Contains(Userinfo.EN))
                //        {
                //            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                //            ch1 = (DataGridViewCheckBoxCell)dataGridViewSelectList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                //            if (ch1.Value == null)
                //                return;
                //            else
                //            {
                //                ch1.Value = ch0.Value;
                //            }
                //            dataGridViewSelectList.CommitEdit(DataGridViewDataErrorContexts.Commit);
                //            dataGridViewSelectList.EndEdit();
                //            //DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, "ไม่สามารถแก้ไขข้อมูลได้เนื่องจาก ได้บันทึกค่ามือและค่าแพทย์ไปแล้ว" + Environment.NewLine + "กรุณาติดต่อผู้ดูแลระบบ");
                //            return;
                //        }
                //    }
                //}
            }
            catch (Exception)
            {


            }
        }

        private void dataGridViewSelectList_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            toolTip1.Show("CellMouseEnter", dataGridViewSelectList);
        }

        private void dataGridViewSelectList_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            toolTip1.Hide(this);
        }

        private void dgvAestheticList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void btnRefund_Click(object sender, EventArgs e)
        {
            try
            {
                List<Entity.SupplieTrans> listSuppleTrans = new List<Entity.SupplieTrans>();
                Entity.SupplieTrans supplieInfo = new Entity.SupplieTrans();
                foreach (DataGridViewRow item in dataGridViewSelectList.Rows)
                {
                    if ((bool)item.Cells[0].Value == true)
                    {
                        supplieInfo = new Entity.SupplieTrans();
                        supplieInfo.MS_Code = item.Cells["Code"].Value + "";
                        supplieInfo.MS_Name = item.Cells["Name"].Value + "";
                        supplieInfo.ListOrder = item.Cells["ListOrder"].Value + "";
                        supplieInfo.Amount = item.Cells["Amount"].Value + "" == "" ? 0 : decimal.Parse(item.Cells["Amount"].Value + "");
                        supplieInfo.PriceAfterDis = Convert.ToDecimal(string.IsNullOrEmpty(item.Cells["PriceTotal"].Value + "") ? "0" : item.Cells["PriceTotal"].Value + "");
                        listSuppleTrans.Add(supplieInfo);
                    }
                }
                if (listSuppleTrans.Count == 0)
                {
                    MessageBox.Show("กรุณาเลือกรายการ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                popRefundReq p = new popRefundReq();
                p.CustName = txtCustomerName.Text;
                p.CN = CN;
                p.RefVN = txtSORefAccount.Text.Trim();
                p.SONo = txtSONo.Text.Trim();
                p.VN = txtMO.Text.Trim();
                p.BranchID = cboBranch.SelectedValue + "";

                p.PriceTotal = txtPriceTotal.Text;

                if ((this.comboBoxCommission1.SelectedValue + "").Length > 3)
                    p.ConsultName += comboBoxCommission1.Text;
                if ((this.comboBoxCommission2.SelectedValue + "").Length > 3)
                    p.ConsultName += "/" + comboBoxCommission2.Text;

                p.BuyDate = dateTimePickerCreate.Value;

                p.listSuppleTrans = listSuppleTrans;
                p.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBoxPstock_Click(object sender, EventArgs e)
        {
            try
            {
                BindReportPrintStock(1);
                if (dsStock.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show("ไม่มีรายการ สต๊อค", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                PrintSO_Stock();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridViewSelectListPro_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataSet dsSurgeryFee = new Business.MedicalOrderUseTrans().CheckUsedCoursePro("", txtSONo.Text.Trim(), "", "");
                if (dsSurgeryFee.Tables.Count > 0 && dsSurgeryFee.Tables[0].Rows.Count > 0 && !(Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN) && !Userinfo.IS_ADMIN_EDIT.Contains(Userinfo.EN))//&& !Userinfo.IS_ADMIN_JOBCOST.Contains(Userinfo.EN)
                {

                    dataGridViewSelectListPro.ReadOnly = true;
                    //dataGridViewSelectList.Rows[e.RowIndex].Cells["chkCanceled"].ReadOnly = true;
                    //DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                    //ch1 = (DataGridViewCheckBoxCell)dataGridViewSelectList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    //if (ch1.Value == null)
                    //    return;
                    //else
                    //{
                    //    ch1.Value = ch0.Value;

                    //}
                    dataGridViewSelectListPro.CommitEdit(DataGridViewDataErrorContexts.CurrentCellChange);
                    dataGridViewSelectListPro.EndEdit();


                    //DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, "ไม่สามารถแก้ไขข้อมูลได้เนื่องจาก ได้บันทึกค่ามือและค่าแพทย์ไปแล้ว" + Environment.NewLine + "กรุณาติดต่อผู้ดูแลระบบ");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}


