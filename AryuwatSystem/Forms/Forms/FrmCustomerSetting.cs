using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DermasterSystem.Class;
using DermasterSystem.UserControls;
using DermasterSystem.m_DataSet;
using Entity;
using WeifenLuo.WinFormsUI.Docking;

namespace DermasterSystem.Forms
{
    public partial class FrmCustomerSetting : DockContent, IForm
    {
        private Entity.Customer info = new Customer();
        private Dictionary<string, string> dicPrefix = new Dictionary<string, string>();
        private Dictionary<string, string> dicPrefixCont = new Dictionary<string, string>();
        private Dictionary<string, string> dicProvince = new Dictionary<string, string>();
        private Dictionary<string, string> dicDistrict = new Dictionary<string, string>();
        private Dictionary<string, string> dicSubDistrict = new Dictionary<string, string>();
        private DataTable dtPrefix = new DataTable();
        private DataTable dtPrefixCont = new DataTable();
        private string _imagePaht = "";
        private int intYear;
        private AutoCompleteStringCollection colValues = new AutoCompleteStringCollection();

        public FrmCustomerSetting()
        {
            InitializeComponent();
        }

        public FrmCustomerSetting(ref Entity.Customer info)
        {
            InitializeComponent();
            this.info = info;
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
            FrmPreviewRpt obj = new FrmPreviewRpt();
            obj.FormName = "RptCustomerDetail";
            obj.Cn = cn;
            obj.StrBirthDate = txtYear.Text.Trim();
            obj.MaximizeBox = true;
            obj.ShowDialog();
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

        private bool blnCboProvLoad = false;
        private DataTable dtAdministrative = new DataTable();
        private DataTable dtCountry = new DataTable();
        private DataTable dtProvince = new DataTable();
        private DataTable dtDistrict = new DataTable();
        private DataTable dtSubDistrict = new DataTable();
        private DataTable dtZipcode = new DataTable();
        //public string typeCustomer { get; set; }
        private bool _Changimage = false;
        private string typeCustomer { get; set; }
        private string cn = null;
        private string cnPrefix = "";
        private int? intStatus;
        public Utility.AccessType FormType { get; set; }
        private string mobile1, mobile2, tel1, tel2, mobileC1, mobileC2, telC1, telC2 = "";
        private string cardId = "";
        private string birthDateOther;

        public string CN
        {
            get { return cn; }
            set { cn = value; }

        }

        public string TypeCustomer
        {
            get { return typeCustomer; }
            set { typeCustomer = value; }
        }

        private string _imageCustPath;
        //private bool _imageCustChange;
        private string imageType = "";
        private string mStrimagePath;

        #endregion

        private void FrmCustomerSetting_Load(object sender, EventArgs e)
        {
            try
            {
              
                SetStartControls();
                SetColumnDgvMembers();
                if (string.IsNullOrEmpty(cn))
                {
                    var strPrefix = new Business.Customer().GetCnNumber("CN" + typeCustomer);
                    //string docPrefix = strPrefix.Substring(0, 2);
                    //string strRunnig = strPrefix.Substring(2, 8);
                    txtCnPrefix.Text = strPrefix.Substring(0, 3);
                    cnPrefix = txtCnPrefix.Text;
                    txtCN.Text = strPrefix.Substring(3, strPrefix.Length - 3);
                    BindCboProvider();
                }
                else
                {
                    BindData();
                    if (FormType == Utility.AccessType.DisplayOnly)
                    {
                        SetEnabledFalse();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void SetColumnDgvMembers()
        {
            Utility.SetPropertyDgv(dgvMember);
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            {
                column.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                column.FlatStyle = FlatStyle.Standard;
                column.ThreeState = false;
                column.Name = "CHKSELECT";
                column.HeaderText = "";
                column.CellTemplate = new DataGridViewCheckBoxCell();
                column.CellTemplate.Style.BackColor = Color.Beige;
            }

            dgvMember.Columns.Add(column);
            dgvMember.Columns.Add("CN", "CN");
            dgvMember.Columns.Add("CustomerName", "Customer Name");
            dgvMember.Columns.Add("CustomerType", "CustomerType");

            dgvMember.Columns["CN"].Width = 100;
            dgvMember.Columns["CustomerName"].Width = 150;
            dgvMember.Columns["CustomerType"].Width = 150;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            //SendKeys.SendWait("{RIGHT}");
            //return true;
            if (dtpBirtDate.Focused)
            {
                if (keyData == Keys.Tab)
                {
                    SendKeys.SendWait("{RIGHT}");
                    return true;
                }
            }

            //Utility.SendKey(Convert.ToChar(13));
            return base.ProcessDialogKey(keyData);
        }
        private void SetStartControls()
        {
            BindCboBranch();
     
            BindCboPrefix();
            BindCboPrefixCont();
            BindCboProvince();
            BindCboDistrict(null);
            BindCboSubDistrict(null);
            BindTxtPostCode(null);
            BindCboCountry();
           // dtpBirtDate.Value = null;
            dtpBirtDate.Checked = false;
            dtpBirtDate.ValueChanged+=new EventHandler(dtpBirtDate_ValueChanged);
            dtpBirtDate.EnabledChanged += new EventHandler(dtpBirtDate_EnabledChanged);
            //Add Event 
            btnCamera.BtnClick += btnCamera_BtnClick;
            //picBrown.BtnClick += new UserControls.ButtonFind.ButtonClick(cmdBrowseImage_BtnClick);

            txtDayBirth1.KeyUp += txtDayBirth1_KeyUp;
            txtDayBirth2.KeyUp += txtDayBirth2_KeyUp;
            txtMBirth1.KeyUp += txtMBirth1_KeyUp;

            txtMobile1_1.KeyUp += this.txtMobile1_1_KeyUp;
            txtMobile1_2.KeyUp += this.txtMobile1_2_KeyUp;
            txtMobile1_3.KeyUp += this.txtMobile1_3_KeyUp;
            txtMobile1_4.KeyUp += this.txtMobile1_4_KeyUp;
            txtMobile1_5.KeyUp += this.txtMobile1_5_KeyUp;
            txtMobile1_6.KeyUp += this.txtMobile1_6_KeyUp;
            txtMobile1_7.KeyUp += this.txtMobile1_7_KeyUp;
            txtMobile1_8.KeyUp += this.txtMobile1_8_KeyUp;
            txtMobile1_9.KeyUp += this.txtMobile1_9_KeyUp;
            txtMobile1_10.KeyUp += this.txtMobile1_10_KeyUp;

            txtMobile2_1.KeyUp += this.txtMobile2_1_KeyUp;
            txtMobile2_2.KeyUp += this.txtMobile2_2_KeyUp;
            txtMobile2_3.KeyUp += this.txtMobile2_3_KeyUp;
            txtMobile2_4.KeyUp += this.txtMobile2_4_KeyUp;
            txtMobile2_5.KeyUp += this.txtMobile2_5_KeyUp;
            txtMobile2_6.KeyUp += this.txtMobile2_6_KeyUp;
            txtMobile2_7.KeyUp += this.txtMobile2_7_KeyUp;
            txtMobile2_8.KeyUp += this.txtMobile2_8_KeyUp;
            txtMobile2_9.KeyUp += this.txtMobile2_9_KeyUp;
            txtMobile2_10.KeyUp += this.txtMobile2_10_KeyUp;

            txtTel1_1.KeyUp += this.txtTel1_1_KeyUp;
            txtTel1_2.KeyUp += this.txtTel1_2_KeyUp;
            txtTel1_3.KeyUp += this.txtTel1_3_KeyUp;
            txtTel1_4.KeyUp += this.txtTel1_4_KeyUp;
            txtTel1_5.KeyUp += this.txtTel1_5_KeyUp;
            txtTel1_6.KeyUp += this.txtTel1_6_KeyUp;
            txtTel1_7.KeyUp += this.txtTel1_7_KeyUp;
            txtTel1_8.KeyUp += this.txtTel1_8_KeyUp;
            txtTel1_9.KeyUp += this.txtTel1_9_KeyUp;

            txtTel2_1.KeyUp += this.txtTel2_1_KeyUp;
            txtTel2_2.KeyUp += this.txtTel2_2_KeyUp;
            txtTel2_3.KeyUp += this.txtTel2_3_KeyUp;
            txtTel2_4.KeyUp += this.txtTel2_4_KeyUp;
            txtTel2_5.KeyUp += this.txtTel2_5_KeyUp;
            txtTel2_6.KeyUp += this.txtTel2_6_KeyUp;
            txtTel2_7.KeyUp += this.txtTel2_7_KeyUp;
            txtTel2_8.KeyUp += this.txtTel2_8_KeyUp;
            txtTel2_9.KeyUp += this.txtTel2_9_KeyUp;
            txtTel2_10.KeyUp += this.txtTel2_10_KeyUp;
            txtTel2_11.KeyUp += this.txtTel2_11_KeyUp;
            txtTel2_12.KeyUp += this.txtTel2_12_KeyUp;

            txtMobileC1_1.KeyUp += this.txtMobileC1_1_KeyUp;
            txtMobileC1_2.KeyUp += this.txtMobileC1_2_KeyUp;
            txtMobileC1_3.KeyUp += this.txtMobileC1_3_KeyUp;
            txtMobileC1_4.KeyUp += this.txtMobileC1_4_KeyUp;
            txtMobileC1_5.KeyUp += this.txtMobileC1_5_KeyUp;
            txtMobileC1_6.KeyUp += this.txtMobileC1_6_KeyUp;
            txtMobileC1_7.KeyUp += this.txtMobileC1_7_KeyUp;
            txtMobileC1_8.KeyUp += this.txtMobileC1_8_KeyUp;
            txtMobileC1_9.KeyUp += this.txtMobileC1_9_KeyUp;

            txtMobileC2_1.KeyUp += this.txtMobileC2_1_KeyUp;
            txtMobileC2_2.KeyUp += this.txtMobileC2_2_KeyUp;
            txtMobileC2_3.KeyUp += this.txtMobileC2_3_KeyUp;
            txtMobileC2_4.KeyUp += this.txtMobileC2_4_KeyUp;
            txtMobileC2_5.KeyUp += this.txtMobileC2_5_KeyUp;
            txtMobileC2_6.KeyUp += this.txtMobileC2_6_KeyUp;
            txtMobileC2_7.KeyUp += this.txtMobileC2_7_KeyUp;
            txtMobileC2_8.KeyUp += this.txtMobileC2_8_KeyUp;
            txtMobileC2_9.KeyUp += this.txtMobileC2_9_KeyUp;

            txtTelC1_1.KeyUp += this.txtTelC1_1_KeyUp;
            txtTelC1_2.KeyUp += this.txtTelC1_2_KeyUp;
            txtTelC1_3.KeyUp += this.txtTelC1_3_KeyUp;
            txtTelC1_4.KeyUp += this.txtTelC1_4_KeyUp;
            txtTelC1_5.KeyUp += this.txtTelC1_5_KeyUp;
            txtTelC1_6.KeyUp += this.txtTelC1_6_KeyUp;
            txtTelC1_7.KeyUp += this.txtTelC1_7_KeyUp;
            txtTelC1_8.KeyUp += this.txtTelC1_8_KeyUp;

            txtTelC2_1.KeyUp += this.txtTelC2_1_KeyUp;
            txtTelC2_2.KeyUp += this.txtTelC2_2_KeyUp;
            txtTelC2_3.KeyUp += this.txtTelC2_3_KeyUp;
            txtTelC2_4.KeyUp += this.txtTelC2_4_KeyUp;
            txtTelC2_5.KeyUp += this.txtTelC2_5_KeyUp;
            txtTelC2_6.KeyUp += this.txtTelC2_6_KeyUp;
            txtTelC2_7.KeyUp += this.txtTelC2_7_KeyUp;
            txtTelC2_8.KeyUp += this.txtTelC2_8_KeyUp;
            txtTelC2_9.KeyUp += this.txtTelC2_9_KeyUp;
            txtTelC2_10.KeyUp += this.txtTelC2_10_KeyUp;
            txtTelC2_11.KeyUp += this.txtTelC2_11_KeyUp;


            txtPassCode1.KeyUp += txtPassCode1_KeyUp;
            txtPassCode2.KeyUp += txtPassCode2_KeyUp;
            txtPassCode3.KeyUp += txtPassCode3_KeyUp;
            txtPassCode4.KeyUp += txtPassCode4_KeyUp;
            txtPassCode5.KeyUp += txtPassCode5_KeyUp;
            txtPassCode6.KeyUp += txtPassCode6_KeyUp;
            txtPassCode7.KeyUp += txtPassCode7_KeyUp;
            txtPassCode8.KeyUp += txtPassCode8_KeyUp;
            txtPassCode9.KeyUp += txtPassCode9_KeyUp;
            txtPassCode10.KeyUp += txtPassCode10_KeyUp;
            txtPassCode11.KeyUp += txtPassCode11_KeyUp;
            txtPassCode12.KeyUp += txtPassCode12_KeyUp;
        }
        
        private void BindCboPrefix()
        {
            try
            {
                DataSet dsPrefix = new Business.Prefix().SelectPrefixAll();
                dtPrefix = dsPrefix.Tables[0];

                colValues = new AutoCompleteStringCollection();
                foreach (DataRow dr in dtPrefix.Rows)
                {
                    colValues.Add(dr["PrefixName"].ToString());
                    //if (dicPrefix.ContainsKey(dr["PrefixName"].ToString())) continue;
                    //dicPrefix.Add(dr["PrefixName"].ToString(), dr["PrefixCode"].ToString());
                }
                
                txtPrefix.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtPrefix.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtPrefix.AutoCompleteCustomSource = colValues;
            }
            catch (Exception ex)
            {
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation,
                               "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }
        }

        private void BindCboBranch()
        {
            try
            {
                DataTable dtBranch = new Business.Branch().SelectBranchAll().Tables[0];
                cboBranch.DataSource = dtBranch;
                cboBranch.ValueMember = "BranchID";
                cboBranch.DisplayMember = "BranchName";
            }
            catch (Exception ex)
            {
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation,
                               "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }
        }

        private void BindCboProvider()
        {
            try
            {
                DataTable dtBranch = new Business.CustProvider().SelectCustProviderAll(cnPrefix).Tables[0];
                DataRow newCustomersRow = dtBranch.NewRow();

                    newCustomersRow["ProviderTypID"] = "";
                    newCustomersRow["ProviderTypName"] = "-";
                dtBranch.Rows.Add(newCustomersRow);
                comboBoxCustProvider.DataSource = dtBranch;
                comboBoxCustProvider.ValueMember = "ProviderTypID";
                comboBoxCustProvider.DisplayMember = "ProviderTypName";
                comboBoxCustProvider.SelectedValue = "";
            }
            catch (Exception ex)
            {
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation,
                               "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }
        }

        private void BindCboPrefixCont()
        {
            try
            {
                DataSet dsPrefixCont = new Business.Prefix().SelectPrefixAll();
                dtPrefixCont = dsPrefixCont.Tables[0];

                colValues = new AutoCompleteStringCollection();
                foreach (DataRow dr in dtPrefix.Rows)
                {
                    colValues.Add(dr["PrefixName"].ToString());
                    //if (dicPrefixCont.ContainsKey(dr["PrefixName"].ToString())) continue;
                    //dicPrefixCont.Add(dr["PrefixName"].ToString(), dr["PrefixCode"].ToString());
                }

                txtPrefixCont.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtPrefixCont.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtPrefixCont.AutoCompleteCustomSource = colValues;
            }
            catch (Exception ex)
            {
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation,
                               "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }
        }
        private void BindCboCountry()
        {
            try
            {
                txtCountry.Text = "";
                //var dsProv = new Business.Province().SelectProvinceAll();
                ////var drProv = dsProv.Tables[0].NewRow();
                ////drProv["PROVINCE_CODE"] = "";
                ////drProv["PROVINCE_NAME"] = Statics.StrValidate;
                ////dsProv.Tables[0].Rows.InsertAt(drProv, 0);
                //dtAdministrative = dsProv.Tables[0];

                DataView view = new DataView(dtAdministrative);
                dtCountry = view.ToTable(true, "Country_ID", "Country_Name");
                //dtProvince = dtAdministrative.Select("DISTINCT PROVINCE_CODE,DISTINCT PROVINCE_NAME").CopyToDataTable();
                //cboProvince.BeginUpdate();

                //cboProvince.DisplayMember = "PROVINCE_NAME";
                //cboProvince.ValueMember = "PROVINCE_CODE";

                //cboProvince.DataSource = dtProvince; // dsProv.Tables[0];
                //cboProvince.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //cboProvince.AutoCompleteSource = AutoCompleteSource.ListItems;
                //cboProvince.EndUpdate();
                //blnCboProvLoad = true;
                colValues = new AutoCompleteStringCollection();
                foreach (DataRow dr in dtCountry.Rows)
                {
                    //if (dicProvince.ContainsKey(dr["PROVINCE_NAME"].ToString().Trim())) continue;
                    //dicProvince.Add(dr["PROVINCE_NAME"].ToString().Trim(), dr["PROVINCE_CODE"].ToString().Trim());
                    colValues.Add(dr["Country_Name"].ToString().Trim());
                }

                txtCountry.BeginUpdate();
                txtCountry.AutoCompleteCustomSource = colValues;
                txtCountry.DisplayMember = "Country_Name";
                txtCountry.ValueMember = "Country_ID";
                txtCountry.DataSource = dtCountry;
                txtCountry.EndUpdate();



            }
            catch (Exception ex)
            {
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation,
                               "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }
        }
        private void BindCboProvince()
        {
            try
            {
                txtProvince.Text = "";
                var dsProv = new Business.Province().SelectProvinceAll();
                //var drProv = dsProv.Tables[0].NewRow();
                //drProv["PROVINCE_CODE"] = "";
                //drProv["PROVINCE_NAME"] = Statics.StrValidate;
                //dsProv.Tables[0].Rows.InsertAt(drProv, 0);
                dtAdministrative = dsProv.Tables[0];

                DataView view = new DataView(dtAdministrative);
                dtProvince = view.ToTable(true, "PROVINCE_CODE", "PROVINCE_NAME");
                //dtProvince = dtAdministrative.Select("DISTINCT PROVINCE_CODE,DISTINCT PROVINCE_NAME").CopyToDataTable();
                //cboProvince.BeginUpdate();

                //cboProvince.DisplayMember = "PROVINCE_NAME";
                //cboProvince.ValueMember = "PROVINCE_CODE";

                //cboProvince.DataSource = dtProvince; // dsProv.Tables[0];
                //cboProvince.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //cboProvince.AutoCompleteSource = AutoCompleteSource.ListItems;
                //cboProvince.EndUpdate();
                //blnCboProvLoad = true;
                colValues = new AutoCompleteStringCollection();
                foreach (DataRow dr in dtProvince.Rows)
                {
                    if (dicProvince.ContainsKey(dr["PROVINCE_NAME"].ToString().Trim())) continue;
                    dicProvince.Add(dr["PROVINCE_NAME"].ToString().Trim(), dr["PROVINCE_CODE"].ToString().Trim());
                    colValues.Add(dr["PROVINCE_NAME"].ToString().Trim());
                }
                //txtProvince.AutoCompleteMode = AutoCompleteMode.Suggest;
                //txtProvince.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtProvince.BeginUpdate();
                txtProvince.AutoCompleteCustomSource = colValues;
                txtProvince.DisplayMember = "PROVINCE_NAME";
                txtProvince.ValueMember = "PROVINCE_CODE";
                txtProvince.DataSource = dtProvince; 
                txtProvince.EndUpdate();



            }
            catch (Exception ex)
            {
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation,
                               "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }
        }

        private void BindCboDistrict(string provinceCode)
        {
            try
            {
                
                if (!string.IsNullOrEmpty(provinceCode))
                {

                    DataView view = new DataView(dtAdministrative);
                    dtDistrict = view.ToTable(true, "District_CODE", "District_NAME", "PROVINCE_CODE");
                    string sql = "PROVINCE_CODE='" + provinceCode + "'";
                    if (!dtDistrict.Select(sql).Any()) return;
                    dtDistrict = dtDistrict.Select(sql).CopyToDataTable();
                    //var drDist = dtDistrict.NewRow();
                    //drDist["District_code"] = "";
                    //drDist["District_NAME"] = Statics.StrValidate;
                    //dtDistrict.Rows.InsertAt(drDist, 0);

                    //cboDistrict.BeginUpdate();
                    //cboDistrict.DisplayMember = "District_NAME";
                    //cboDistrict.ValueMember = "District_CODE";
                    //cboDistrict.DataSource = dtDistrict; // dsDist.Tables[0];


                    //cboDistrict.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    //cboDistrict.AutoCompleteSource = AutoCompleteSource.ListItems;

                    //cboDistrict.SelectedIndex = 0;
                    //cboDistrict.EndUpdate();
                    colValues = new AutoCompleteStringCollection();
                    foreach (DataRow dr in dtDistrict.Rows)
                    {
                        colValues.Add(dr["District_NAME"].ToString().Trim());
                        if (dicDistrict.ContainsKey(dr["District_NAME"].ToString().Trim())) continue;
                        dicDistrict.Add(dr["District_NAME"].ToString().Trim(), dr["District_code"].ToString().Trim());

                    }
                    txtDistrict.BeginUpdate();
                    txtDistrict.DisplayMember = "District_NAME";
                    txtDistrict.ValueMember = "District_CODE";
                    txtDistrict.DataSource = dtDistrict; 
                    txtDistrict.AutoCompleteCustomSource = colValues;
                    txtDistrict.EndUpdate();
                    //txtDistrict.Text = "";

                }
            }
            catch (Exception ex)
            {
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation,
                               "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }
        }

        private void BindCboSubDistrict(string district_code)
        {
            try
            {
              //  txtSubDistrict.Text = "";
                if (!string.IsNullOrEmpty(district_code) && district_code != "-1")
                {

                    //DataView view = new DataView(dtAdministrative);
                    //dtSubDistrict = view.ToTable(true, "SUBDistrict_CODE", "SUBDistrict_NAME", "District_CODE");
                    string sql = "District_CODE=" + district_code;
                    if (!dtAdministrative.Select(sql).Any()) return;
                    dtSubDistrict = dtAdministrative.Select(sql).CopyToDataTable();
                    //MessageBox.Show(dtSubDistrict.Rows.Count.ToString());
                    //var drDist = dtSubDistrict.NewRow();
                    //drDist["SubDistrict_CODE"] = "";
                    //drDist["SubDistrict_NAME"] = Statics.StrValidate;
                    //dtSubDistrict.Rows.InsertAt(drDist, 0);

                    //cboSubDistrict.BeginUpdate();
                    //cboSubDistrict.DisplayMember = "SubDistrict_NAME";
                    //cboSubDistrict.ValueMember = "SubDistrict_CODE";
                    //cboSubDistrict.DataSource = dtSubDistrict; // dsDist.Tables[0];


                    //cboSubDistrict.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    //cboSubDistrict.AutoCompleteSource = AutoCompleteSource.ListItems;

                    //cboSubDistrict.SelectedIndex = 0;
                    //cboSubDistrict.EndUpdate();
                    colValues = new AutoCompleteStringCollection();
                    //txtSubDistrict.Items.Clear();
                    foreach (DataRow dr in dtSubDistrict.Rows)
                    {
                        colValues.Add(dr["SubDistrict_NAME"].ToString().Trim());
                        if (dicSubDistrict.ContainsKey(dr["SubDistrict_NAME"].ToString().Trim())) continue;
                        dicSubDistrict.Add(dr["SubDistrict_NAME"].ToString().Trim(), dr["SubDistrict_CODE"].ToString().Trim());
                        //txtSubDistrict.Items.Add(dr["SubDistrict_NAME"].ToString().Trim());
                    }
                    txtSubDistrict.BeginUpdate();
                    txtSubDistrict.DisplayMember = "SubDistrict_NAME";
                    txtSubDistrict.ValueMember = "SubDistrict_CODE";
                    txtSubDistrict.DataSource = dtSubDistrict; 
                    txtSubDistrict.AutoCompleteCustomSource = colValues;
                }
            }
            catch (Exception ex)
            {
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeError,
                               "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }
        }

        private void BindTxtPostCode(string Subdistrict_code)
        {
            try
            {
               // txtPostCode.Text = "";
                if (!string.IsNullOrEmpty(Subdistrict_code) && Subdistrict_code != "-1")
                {

                    // MessageBox.Show(Subdistrict_code);
                    //var dsPostCode = new Business.PostCode().SelectPostCodeAll();
                    //AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
                    if (dtZipcode.Select("Subdistrict_code=" + Subdistrict_code).Any())
                    {
                        txtPostCode.Text =
                            dtZipcode.Select("Subdistrict_code=" + Subdistrict_code)[0]["zipcode"].ToString();
                        Utility.SendKey(Convert.ToChar(13));
                    }

                }
                else
                {
                    txtPostCode.Text = "";
                    if (dtZipcode.Rows.Count == 0)
                        dtZipcode = new Business.PostCode().SelectPostCodeAll().Tables[0];
                }
            }
            catch (Exception ex)
            {
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeError,
                               "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }

        }


        private void bntSave_Click(object sender, EventArgs e)
        {
            Customer customerInfo;
            if (!ValidateData()) return;
            GetDataCustomer(out customerInfo);
            //if (!SendImageToServer()) return;
            if (customerInfo == null) return;
            try
            {
                switch (FormType)
                {
                    case Utility.AccessType.Insert:
                        bool blnChkDup = new Business.Customer().CheckDupCustomer(customerInfo.CN);
                        if (blnChkDup)
                        {
                            Utility.PopMsg(Utility.EnuMsgType.MsgTypeError,
                             "เลขที่ CN ซ้ำกรุณาตรวจสอบอีกครั้ง " );
                            txtCN.Focus();
                            return;
                        }
                        
                        intStatus = new Business.Customer().InsertCustomer(customerInfo);
                        if (intStatus == 1)
                        {
                            Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, Statics.StrMsgInsertComplete);
                            Statics.frmCustomerList.BindDataCustomer(1);
                            if (Statics.frmCustormerSetting != null)
                            {
                                Statics.frmCustormerSetting.Close();
                            }
                            if (Statics.frmCustormerSetting != null) Statics.frmCustormerSetting.Dispose();
                        }
                        break;
                    case Utility.AccessType.Update:
                        customerInfo.CN = cn;
                       
                        intStatus = new Business.Customer().UpdateCustomer(customerInfo);
                        if (intStatus == 1)
                        {
                            Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, Statics.StrMsgUpdateComplete);
                            Statics.frmCustomerList.BindDataCustomer(1);
                            Statics.frmCustormerSetting.Close();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeError, Statics.StrMsgCannotSave + ex.Message);
            }
        }

        private void GetDataCustomer(out Customer customerInfo)
        {
            Entity.Customer info = new Customer();
            Entity.AestheticCenter aesInfo = new AestheticCenter();
            Entity.BodyCenter bodyInfo = new BodyCenter();
            Entity.HairCenter hairInfo = new HairCenter();
            Entity.CosmeticSurgery cosmeticInfo = new CosmeticSurgery();
            Entity.ContactCustomer contactInfo = new ContactCustomer();
            Entity.HowYouhear howInfo = new HowYouhear();

            info.UpdateBy = Entity.Userinfo.EN;
            info.DocPrefix = "CN" + typeCustomer;
            info.CN = txtCnPrefix.Text.Trim() + txtCN.Text.Trim();
            info.BranchId = cboBranch.SelectedValue + "";
            info.ProviderTypID = comboBoxCustProvider.SelectedValue + "";
            info.CustomerType = info.DocPrefix;
            if (dtpDateReg.Checked)
            info.DateRegister = dtpDateReg.Value.Date;
            //if (dicPrefix.ContainsKey(txtPrefix.Text.Trim()))
            info.PrefixCode = txtPrefix.Text.Trim();//dicPrefix[txtPrefix.Text];
            info.TName = txtTName.Text.Trim();
            info.TSurname = txtTSurName.Text.Trim();
            info.TNickname = txtTNickName.Text.Trim();
            info.Firstname = txtFirstName.Text.Trim();
            info.Middlename = txtMiddleName.Text.Trim();
            info.Surname = txtSurName.Text.Trim();
            info.NickName = txtNickName.Text.Trim();
            if (dtpBirtDate.Checked)
                info.DateBirth = dtpBirtDate.Value.Date;
            info.DateBirthOther = birthDateOther;
            info.Gender = rdoMale.Checked ? "M" : "W";
            info.AgenMemId = txtAgenMemID.Text.Trim();
            if (txtHeight.Text != "")
            {
                info.Height = int.Parse(txtHeight.Text);
            }
            if (txtWeight.Text != "")
            {
                info.Weights = int.Parse(txtWeight.Text);
            }
            info.BloodPressure = txtBP.Text.Trim();
            info.Nationality = txtNationality.Text.Trim();
            info.Race = txtRace.Text.Trim();
            info.Mobile1 = mobile1;
            info.Mobile2 = mobile2;
            info.Tel1 = tel1;
            info.Tel2 = tel2;
            info.E_mail = txtEmail.Text.Trim();
            info.AddressId = txtAddress.Text.Trim();
            info.Building = txtBuilding.Text.Trim();
            info.Soi = txtSoi.Text.Trim();
            info.Road = txtRoad.Text.Trim();
            info.Country = txtCountry.SelectedValue+"";
            //if (dicSubDistrict.ContainsKey(txtSubDistrict.Text.Trim()))
            //    info.Sub_district = dicSubDistrict[txtSubDistrict.Text]; //cboSubDistrict.SelectedValue + "";
            info.Sub_district = (dicSubDistrict.ContainsKey(txtSubDistrict.Text.Trim()))
                ?dicSubDistrict[txtSubDistrict.Text]
                :txtSubDistrict.Text.Trim();
                //cboSubDistrict.SelectedValue + "";
            //if (dicDistrict.ContainsKey(txtDistrict.Text.Trim()))
            //    info.District = dicDistrict[txtDistrict.Text.Trim()]; // cboDistrict.SelectedValue + "";
            info.District = (dicDistrict.ContainsKey(txtDistrict.Text.Trim()))
                                ? dicDistrict[txtDistrict.Text.Trim()]
                                : txtDistrict.Text.Trim();
            //if (dicProvince.ContainsKey(txtProvince.Text.Trim()))
            //    info.Province = dicProvince[txtProvince.Text.Trim()]; //cboProvince.SelectedValue + "";
            info.Province = (dicProvince.ContainsKey(txtProvince.Text.Trim()))
                                ? dicProvince[txtProvince.Text.Trim()]
                                : txtProvince.Text.Trim();
            info.PostCode = txtPostCode.Text.Trim();
            info.IdCard = cardId;
            info.PassportNo = txtPassportNo.Text.Trim();
            info.VipFlag = chkVip.Checked ? "Y" : "N";
            info.Remark = txtRemark.Text.Trim();
            info.AllergyHistory = txtAllergyHist.Text.Trim();
            info.UnderlyingDisease = txtUnderlying.Text.Trim();
            info.WhereGotTreatment = txtWhereDid.Text.Trim();
            info.Credit_Bath = txtCredit_bath.Text.Length == 0 ? 0 : Convert.ToInt16(txtCredit_bath.Text);
            info.Credit_Day = txtCredit_day.Text.Length == 0 ? 0 : Convert.ToInt16(txtCredit_day.Text);
            //Get Data Aes Center
            if (chkAesOther.Checked)
            {
                aesInfo.AestheticOther = txtAesOther.Text.Trim();
            }
            aesInfo.CN = cn;
            if (chkFacialDesign.Checked)
            {
                aesInfo.FacialDesign = txtFacialDesign.Text.Trim();
            }
            if (chkFacialTreatment.Checked)
            {
                aesInfo.FacialTreatment = txtFacialTreatment.Text.Trim();
            }
            if (chkLaser.Checked)
            {
                aesInfo.Laser = txtLaser.Text.Trim();
            }
            info.AestheticCenterInfo = aesInfo;

            //Get Data Body Center
            if (chkBodyOther.Checked)
            {
                bodyInfo.BodyOther = txtBodyOther.Text.Trim();
            }
            if (chkBodyTreatment.Checked)
            {
                bodyInfo.BodyTreatment = txtBodyTreatment.Text.Trim();
            }
            if (chkBodyVaser.Checked)
            {
                bodyInfo.BodyVaserTite = txtBodyVaser.Text.Trim();
            }
            bodyInfo.CN = cn;
            info.BodyCenterInfo = bodyInfo;

            //Get Data Hair Center
            hairInfo.CN = cn;
            if (chkHairTrans.Checked)
            {
                hairInfo.HairTransplantation = txtHairTrans.Text.Trim();
            }
            if (chkHairReform.Checked)
            {
                hairInfo.HairReform = txtHairReform.Text.Trim();
            }
            if (chkHairOther.Checked)
            {
                hairInfo.HairOther = txtHairOther.Text.Trim();
            }
            info.HairCenterInfo = hairInfo;

            //Get Data Cosmetic
            cosmeticInfo.CN = cn;
            if (chkEye.Checked)
            {
                cosmeticInfo.Eye = txtEye.Text.Trim();
            }
            if (chkNose.Checked)
            {
                cosmeticInfo.Nose = txtNose.Text.Trim();
            }
            if (chkChest.Checked)
            {
                cosmeticInfo.Chest = txtChest.Text.Trim();
            }
            if (chkCosOther.Checked)
            {
                cosmeticInfo.Other = txtCosmeticOther.Text.Trim();
            }
            info.CosmeticSurgeryCenterInfo = cosmeticInfo;

            //Get DataContact
            contactInfo.CN = cn;
            //if (dicPrefixCont.ContainsKey(txtPrefixCont.Text.Trim()))
            contactInfo.PrefixCode = txtPrefixCont.Text.Trim();// dicPrefixCont[txtPrefixCont.Text];
            contactInfo.Tname = txtTNameCont.Text.Trim();
            contactInfo.TsurName = txtTSurNameCont.Text.Trim();
            contactInfo.TNickname = txtTNickNameCont.Text.Trim();
            contactInfo.FirstName = txtFirstNameCont.Text.Trim();
            contactInfo.MiddleName = txtMidNameCont.Text.Trim();
            contactInfo.SurName = txtSurNameCont.Text.Trim();
            contactInfo.NickName = txtNickNameCont.Text.Trim();
            contactInfo.Gender = rdoMaleCont.Checked ? "M" : "F";
            contactInfo.Mobile1 = mobileC1;
            contactInfo.Mobile2 = mobileC2;
            contactInfo.Tel1 = telC1;
            contactInfo.Tel2 = telC2;
            if (rdoParent.Checked)
            {
                contactInfo.RelationFlag = "P";
            }
            else if (rdoMate.Checked)
            {
                contactInfo.RelationFlag = "M";
            }
            else if (rdoChild.Checked)
            {
                contactInfo.RelationFlag = "C";
            }
            else if (rdoFriend.Checked)
            {
                contactInfo.RelationFlag = "F";
            }
            else if (rdoOther.Checked)
            {
                contactInfo.RelationFlag = "O";
                contactInfo.RelationOther = txtRelationOther.Text.Trim();
            }
            info.ContactCustomerInfo = contactInfo;

            //GetData HowYouHear
            howInfo.Newspaper = rdoNewspaper.Checked ? "Y" : "N";
            howInfo.Magazine = rdoMagazine.Checked ? "Y" : "N";
            howInfo.Internet = rdoInternet.Checked ? "Y" : "N";
            howInfo.Friend = rdoFriend.Checked ? "Y" : "N";
            howInfo.Travelthrough = rdoTravel.Checked ? "Y" : "N";
            howInfo.Facebook = rdoFacebook.Checked ? "Y" : "N";
            howInfo.Instagram = rdoInstagram.Checked ? "Y" : "N";
            howInfo.Sms = rdoSms.Checked ? "Y" : "N";
            if (rdo_Other.Checked)
            {
                howInfo.HowYouhearOther = txtHowDid.Text.Trim();
            }
            info.HowYouhearInfo = howInfo;

            info.Image = (_Changimage ? Path.GetFileName(_imageCustPath) : null);
            info.ImagePath = (_Changimage ? _imageCustPath : null);

            customerInfo = info;
            info.CreateBy = Entity.Userinfo.EN;
            info.UpdateBy = Entity.Userinfo.EN;
            customerInfo.BranchId = cboBranch.SelectedValue.ToString();

            //  group member
            info.MembersGroupInfo = new List<MembersGroup>();

                 foreach (DataGridViewRow row in dgvMember.Rows)
                    {
                        MembersGroup m = new MembersGroup();
                        m.CN_MAIN = info.CN;
                        m.CN_SUB = row.Cells["CN"].Value + "";
                        info.MembersGroupInfo.Add(m);
                    }
                 if (dgvMember.RowCount <= 0)
                 {
                     MembersGroup mm = new MembersGroup();
                     mm.CN_MAIN = info.CN;
                     mm.CN_SUB = info.CN;
                     info.MembersGroupInfo.Add(mm);
                 }
            //info.MembersGroupInfo.Add
        }

        public static bool IsValidEmailAddress(string s)
        {
            var regex = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
            return regex.IsMatch(s);
        }

        private bool ValidateData()
        {
            var dt = new Business.Customer().SelectCustomerByCN(txtCN.Text.Trim()).Tables[0];
            if (dt.Rows.Count > 1)
            {
                tabCustomer.SelectedTab = tabCustomer.TabPages["tabData"];
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeError, " \"CN\" ซ้ำ กรุณาตรวจสอบอีกครั้ง");
                txtCN.Focus();
                return false;
            }

            if (txtPrefix.Text == "")
            {
                tabCustomer.SelectedTab = tabCustomer.TabPages["tabData"];
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation,
                               "กรุณาระบุ \" คำนำหน้าชื่อ \" ก่อนทำการบันทึกข้อมูล");

                txtPrefix.Focus();
                return false;
            }

            if (txtTName.Text.Trim() == "" && txtFirstName.Text.Trim() == "")
            {
                tabCustomer.SelectedTab = tabCustomer.TabPages["tabData"];
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation,
                               "กรุณาระบุ \" ชื่อ หรือ FirstName \" ก่อนทำการบันทึกข้อมูล");

                txtTName.Focus();
                return false;
            }

            if (rdoMale.Checked == false && rdoFemale.Checked == false)
            {
                tabCustomer.SelectedTab = tabCustomer.TabPages["tabData"];
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation,
                               "กรุณาระบุ \" Gender (เพศ) \" ก่อนทำการบันทึกข้อมูล");

                rdoMale.Focus();
                return false;
            }

            if (!string.IsNullOrEmpty(txtMBirth1.Text) && int.Parse(txtMBirth1.Text + txtMBirth2.Text) > 12)
            {
                tabCustomer.SelectedTab = tabCustomer.TabPages["tabData"];
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeError,
                               "กรุณาระบุ \" เดือน กรณีไม่ระบุ(วันเกิด) \" ให้ถูกต้อง ก่อนทำการบันทึกข้อมูล");

                txtMBirth1.Focus();
                return false;
            }

            birthDateOther = txtDayBirth1.Text + txtDayBirth2.Text + txtMBirth1.Text + txtMBirth2.Text;
            if (birthDateOther.Length > 1 && birthDateOther.Length < 4)
            {
                tabCustomer.SelectedTab = tabCustomer.TabPages["tabData"];
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeError,
                               "กรุณาระบุ \" วันเกิด กรณีไม่ระบุ(วันเกิด) \" ให้ถูกต้อง ก่อนทำการบันทึกข้อมูล");

                txtDayBirth1.Focus();
                return false;
            }

            mobile1 = txtMobile1_1.Text +
                      txtMobile1_2.Text +
                      txtMobile1_3.Text +
                      txtMobile1_4.Text +
                      txtMobile1_5.Text +
                      txtMobile1_6.Text +
                      txtMobile1_7.Text +
                      txtMobile1_8.Text +
                      txtMobile1_9.Text +
                      txtMobile1_10.Text;
            if (mobile1.Length > 1 && mobile1.Length < 10)
            {
                tabCustomer.SelectedTab = tabCustomer.TabPages["tabData"];
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeError,
                               "กรุณาระบุ \" Mobile (เบอร์มือถือ)  1 \" ให้ถูกต้อง ก่อนทำการบันทึกข้อมูล");

                txtMobileC1_1.Focus();
                return false;
            }
            if (mobile1.Length == 0)
            {
                tabCustomer.SelectedTab = tabCustomer.TabPages["tabData"];
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation,
                               "กรุณาระบุ \" Mobile (เบอร์มือถือ)  1 \" ก่อนทำการบันทึกข้อมูล");

                txtMobileC1_1.Focus();
                return false;
            }
            mobile2 = txtMobile2_1.Text +
                      txtMobile2_2.Text +
                      txtMobile2_3.Text +
                      txtMobile2_4.Text +
                      txtMobile2_5.Text +
                      txtMobile2_6.Text +
                      txtMobile2_7.Text +
                      txtMobile2_8.Text +
                      txtMobile2_9.Text +
                      txtMobile2_10.Text;
            if (mobile2.Length > 1 && mobile2.Length < 10)
            {
                tabCustomer.SelectedTab = tabCustomer.TabPages["tabData"];
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeError,
                               "กรุณาระบุ \" Mobile (เบอร์มือถือ)  2 \" ให้ถูกต้อง ก่อนทำการบันทึกข้อมูล");

                txtMobileC1_1.Focus();
                return false;
            }

            tel1 = txtTel1_1.Text +
                   txtTel1_2.Text +
                   txtTel1_3.Text +
                   txtTel1_4.Text +
                   txtTel1_5.Text +
                   txtTel1_6.Text +
                   txtTel1_7.Text +
                   txtTel1_8.Text +
                   txtTel1_9.Text;
            if (tel1.Length > 1 && tel1.Length < 9)
            {
                tabCustomer.SelectedTab = tabCustomer.TabPages["tabData"];
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeError,
                               "กรุณาระบุ \" Telephone (บ้าน) \" ให้ถูกต้อง ก่อนทำการบันทึกข้อมูล");

                txtTel1_1.Focus();
                return false;
            }

            tel2 = txtTel2_1.Text +
                   txtTel2_2.Text +
                   txtTel2_3.Text +
                   txtTel2_4.Text +
                   txtTel2_5.Text +
                   txtTel2_6.Text +
                   txtTel2_7.Text +
                   txtTel2_8.Text +
                   txtTel2_9.Text;
            if (tel2.Length > 1 && tel2.Length < 9)
            {
                tabCustomer.SelectedTab = tabCustomer.TabPages["tabData"];
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeError,
                               "กรุณาระบุ \" เบอร์ต่างประเทศ \" ให้ถูกต้อง ก่อนทำการบันทึกข้อมูล");

                txtTel2_1.Focus();
                return false;
            }

            if (txtEmail.Text.Trim() != "")
            {
                if (IsValidEmailAddress(txtEmail.Text.Trim()) ==false)
                {
                    tabCustomer.SelectedTab = tabCustomer.TabPages["tabData"];
                    Utility.PopMsg(Utility.EnuMsgType.MsgTypeError,
                                   "กรุณาระบุ \" รูปแบบ Email  \" ให้ถูกต้อง ก่อนทำการบันทึกข้อมูล ");

                    txtEmail.Focus();
                    return false;
                }
            }

            if (txtAddress.Text.Trim() == "")
            {
                tabCustomer.SelectedTab = tabCustomer.TabPages["tabData"];
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation,
                               "กรุณาระบุ \" Address (ที่อยู่)  เลขที่ \" ก่อนทำการบันทึกข้อมูล");

                txtSurName.Focus();
                return false;
            }

            if (txtProvince.Text == "")
            {
                tabCustomer.SelectedTab = tabCustomer.TabPages["tabData"];
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation,
                               "กรุณาระบุ \" Province (จังหวัด) \" ก่อนทำการบันทึกข้อมูล");

                txtProvince.Focus();
                return false;
            }

            if (txtDistrict.Text == "")
            {
                tabCustomer.SelectedTab = tabCustomer.TabPages["tabData"];
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation,
                               "กรุณาระบุ \" District (อำเภอ/เขต) \" ก่อนทำการบันทึกข้อมูล");

                txtDistrict.Focus();
                return false;
            }

            if (txtSubDistrict.Text == "")
            {
                tabCustomer.SelectedTab = tabCustomer.TabPages["tabData"];
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation,
                               "กรุณาระบุ \" Sub-district (ตำบล/แขวง) \" ก่อนทำการบันทึกข้อมูล");

                txtSubDistrict.Focus();
                return false;
            }

            if (txtPostCode.Text == "")
            {
                tabCustomer.SelectedTab = tabCustomer.TabPages["tabData"];
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation,
                               "กรุณาระบุ \" Postcode (รหัสไปรษีย์) \" ก่อนทำการบันทึกข้อมูล");

                txtPostCode.Focus();
                return false;
            }
            if (txtPostCode.Text.Trim().Length != 5)
            {
                tabCustomer.SelectedTab = tabCustomer.TabPages["tabData"];
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation,
                               "กรุณาระบุ \" Postcode (รหัสไปรษีย์) \" ให้ถูกต้อง ก่อนทำการบันทึกข้อมูล");

                txtPostCode.Focus();
                return false;
            }
            cardId = txtPassCode1.Text +
                     txtPassCode2.Text +
                     txtPassCode3.Text +
                     txtPassCode4.Text +
                     txtPassCode5.Text +
                     txtPassCode6.Text +
                     txtPassCode7.Text +
                     txtPassCode8.Text +
                     txtPassCode9.Text +
                     txtPassCode10.Text +
                     txtPassCode11.Text +
                     txtPassCode12.Text +
                     txtPassCode13.Text;
            if (cardId.Length < 13)
            {
                tabCustomer.SelectedTab = tabCustomer.TabPages["tabData"];
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeError,
                               "กรุณาระบุ \" หมายเลขบัตรประชาชน \" ให้ถูกต้อง ก่อนทำการบันทึกข้อมูล");

                txtPassCode1.Focus();
                return false;
            }

            
            if(txtAllergyHist.Text.Trim() == "")
            {
                tabCustomer.SelectedTab = tabCustomer.TabPages["tabInterested"];
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation,
                               "กรุณาระบุ \" Allergy History (ประวัติแพ้ยา/เครื่องสำอาง) \"ก่อนทำการบันทึกข้อมูล");

                txtAllergyHist.Focus();
                return false;
            }

            if (txtUnderlying.Text.Trim() == "")
            {
                tabCustomer.SelectedTab = tabCustomer.TabPages["tabInterested"];
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation,
                               "กรุณาระบุ \" Underlying disease (โรคประจำตัว) \"ก่อนทำการบันทึกข้อมูล");

                txtUnderlying.Focus();
                return false;
            }
            return true;
        }

        protected void SetEnabledFalse()
        {
            var ctl = new Control();
            while (GetNextControl(ctl, true) != null)
            {
                ctl = GetNextControl(ctl, true);
                if ((ctl.GetType() == typeof (TextBox)) || (ctl.GetType() == typeof (RichTextBox)) ||
                    (ctl.GetType() == typeof (MaskedTextBox)) || (ctl.GetType() == typeof (ComboBox))
                    || (ctl.GetType() == typeof (UserControls.ButtonFind))
                    || (ctl.GetType() == typeof (UserControls.ButtonCamera))
                    //|| (ctl.GetType() == typeof(Infragistics.Win.UltraWinEditors.UltraDateTimeEditor))
                    || (ctl.GetType() == typeof (TextboxFormatInteger))
                    || (ctl.GetType() == typeof (CheckBox))
                    || (ctl.GetType() == typeof (DateTimePicker))
                    || (ctl.GetType() == typeof (RadioButton))
                    )
                {
                    ctl.Enabled = false;
                }
            }

            btnClear.Visible = false;
            btnSave.Visible = false;
        }


        /// <summary>
        /// 
        /// </summary>
        private void BindData()
        {
            try
            {


                //เรียงตามลำดับ
                //Customers      
                //AestheticCenter
                //BodyCenter     
                //CosmeticSurgery
                //HairCenter     
                //HowYouhear  
                //ContactCustomer
                //Membergroup
                DataSet ds = new Business.Customer().SelectCustomerById(cn);
                DataTable dtCust = ds.Tables[0];
                DataTable dtCont = ds.Tables[6];
                DataTable dtAes = ds.Tables[1];
                DataTable dtBody = ds.Tables[2];
                DataTable dtCos = ds.Tables[3];
                DataTable dtHair = ds.Tables[4];
                DataTable dtHow = ds.Tables[5];
                DataTable dtMembergroup = ds.Tables[7];

                var strPrefix = dtCust.Rows[0]["CN"] + "";
                txtCnPrefix.Text = strPrefix.Substring(0, 3);
                cnPrefix = txtCnPrefix.Text;
                txtCN.Text = strPrefix.Substring(3, strPrefix.Length - 3);

                BindCboProvider();

                if (dtCust.Rows[0]["BranchId"] + ""!="") cboBranch.SelectedValue = dtCust.Rows[0]["BranchId"] + "";
                if (dtCust.Rows[0]["ProviderTypID"] + "" != "") comboBoxCustProvider.SelectedValue = dtCust.Rows[0]["ProviderTypID"] + "";
                //Bind IMage
                if (!string.IsNullOrEmpty(Convert.ToString(dtCust.Rows[0]["Image"])))
                {
                    try
                    {
                        _imagePaht = Properties.Settings.Default.ImagePathServer + "\\" +
                                     Convert.ToString(dtCust.Rows[0]["Image"]);
                        var callback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                        picCustImage.Image =
                            Image.FromFile(Properties.Settings.Default.ImagePathServer + "\\" +
                                           Convert.ToString(dtCust.Rows[0]["Image"])).GetThumbnailImage(
                                               200, 300, callback, IntPtr.Zero);
                        //picCustImage.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    catch (Exception exI)
                    {
                        picCustImage.Image = Properties.Resources.images;
                    }

                }
                if (dtCust.Rows[0]["Dateregister"] + "" != "")
                {
                    dtpDateReg.Value = (DateTime) dtCust.Rows[0]["Dateregister"];
                }
                //if (dicPrefix.ContainsValue(dtCust.Rows[0]["PrefixCode"] + ""))
                txtPrefix.Text = dtCust.Rows[0]["PrefixCode"].ToString();//dicPrefix.Where(p => p.Value == dtCust.Rows[0]["PrefixCode"] + "").Select(p => p.Key).FirstOrDefault();
                txtTName.Text = dtCust.Rows[0]["Tname"] + "";
                txtTSurName.Text = dtCust.Rows[0]["TsurName"] + "";
                txtTNickName.Text = dtCust.Rows[0]["Tnickname"] + "";
                txtFirstName.Text = dtCust.Rows[0]["FirstName"] + "";
                txtMiddleName.Text = dtCust.Rows[0]["MiddleName"] + "";
                txtSurName.Text = dtCust.Rows[0]["Surname"] + "";
                txtNickName.Text = dtCust.Rows[0]["NickName"] + "";
                if (dtCust.Rows[0]["Country_ID"] + "" != "") txtCountry.SelectedValue = dtCust.Rows[0]["Country_ID"] + "";
                else txtCountry.SelectedIndex = -1;
                
                if (dtCust.Rows[0]["DateBirth"] + "" != "")
                {
                    dtpBirtDate.Value = (DateTime) dtCust.Rows[0]["DateBirth"];
                }
                if (dtCust.Rows[0]["DateBirthOther"] + "" != "")
                {
                    var strBirth = dtCust.Rows[0]["DateBirthOther"] + "";
                    txtDayBirth1.Text = strBirth.ToString().Substring(0, 1);
                    txtDayBirth2.Text = strBirth.ToString().Substring(1, 1);
                    txtMBirth1.Text = strBirth.ToString().Substring(2, 1);
                    txtMBirth2.Text = strBirth.ToString().Substring(3, 1);
                }
                if (dtCust.Rows[0]["Gender"] + "" == "M")
                {
                    rdoMale.Checked = true;
                }
                else rdoFemale.Checked = true;

                txtHeight.Text = dtCust.Rows[0]["Height"] + "";
                txtWeight.Text = dtCust.Rows[0]["Weights"] + "";
                txtBP.Text = dtCust.Rows[0]["BloodPressure"] + "";
                txtNationality.Text = dtCust.Rows[0]["Nationality"] + "";
                txtRace.Text = dtCust.Rows[0]["Race"] + "";
                var strMobile1 = dtCust.Rows[0]["Mobile1"] + "";
                if (!string.IsNullOrEmpty(strMobile1) && strMobile1.Length == 10)
                {
                    txtMobile1_1.Text = strMobile1.Substring(0, 1);
                    txtMobile1_2.Text = strMobile1.Substring(1, 1);
                    txtMobile1_3.Text = strMobile1.Substring(2, 1);
                    txtMobile1_4.Text = strMobile1.Substring(3, 1);
                    txtMobile1_5.Text = strMobile1.Substring(4, 1);
                    txtMobile1_6.Text = strMobile1.Substring(5, 1);
                    txtMobile1_7.Text = strMobile1.Substring(6, 1);
                    txtMobile1_8.Text = strMobile1.Substring(7, 1);
                    txtMobile1_9.Text = strMobile1.Substring(8, 1);
                    txtMobile1_10.Text = strMobile1.Substring(9, 1);
                }
                var strMobile2 = dtCust.Rows[0]["Mobile2"] + "";
                if (!string.IsNullOrEmpty(strMobile2) && strMobile2.Length == 10)
                {

                    txtMobile2_1.Text = strMobile2.Substring(0, 1);
                    txtMobile2_2.Text = strMobile2.Substring(1, 1);
                    txtMobile2_3.Text = strMobile2.Substring(2, 1);
                    txtMobile2_4.Text = strMobile2.Substring(3, 1);
                    txtMobile2_5.Text = strMobile2.Substring(4, 1);
                    txtMobile2_6.Text = strMobile2.Substring(5, 1);
                    txtMobile2_7.Text = strMobile2.Substring(6, 1);
                    txtMobile2_8.Text = strMobile2.Substring(7, 1);
                    txtMobile2_9.Text = strMobile2.Substring(8, 1);
                    txtMobile2_10.Text = strMobile2.Substring(9, 1);
                }
                var strTel1 = dtCust.Rows[0]["Tel1"] + "";
                if (!string.IsNullOrEmpty(strTel1) && strTel1.Length == 9)
                {

                    txtTel1_1.Text = strTel1.Substring(0, 1);
                    txtTel1_2.Text = strTel1.Substring(1, 1);
                    txtTel1_3.Text = strTel1.Substring(2, 1);
                    txtTel1_4.Text = strTel1.Substring(3, 1);
                    txtTel1_5.Text = strTel1.Substring(4, 1);
                    txtTel1_6.Text = strTel1.Substring(5, 1);
                    txtTel1_7.Text = strTel1.Substring(6, 1);
                    txtTel1_8.Text = strTel1.Substring(7, 1);
                    txtTel1_9.Text = strTel1.Substring(8, 1);
                }
                var strTel2 = dtCust.Rows[0]["Tel2"] + "";
                if (!string.IsNullOrEmpty(strTel2) && strTel2.Length == 9)
                {

                    txtTel2_1.Text = strTel2.Substring(0, 1);
                    txtTel2_2.Text = strTel2.Substring(1, 1);
                    txtTel2_3.Text = strTel2.Substring(2, 1);
                    txtTel2_4.Text = strTel2.Substring(3, 1);
                    txtTel2_5.Text = strTel2.Substring(4, 1);
                    txtTel2_6.Text = strTel2.Substring(5, 1);
                    txtTel2_7.Text = strTel2.Substring(6, 1);
                    txtTel2_8.Text = strTel2.Substring(7, 1);
                    txtTel2_9.Text = strTel2.Substring(8, 1);
                }
                txtEmail.Text = dtCust.Rows[0]["E_mail"] + "";
                txtAddress.Text = dtCust.Rows[0]["AddressId"] + "";
                txtBuilding.Text = dtCust.Rows[0]["Building"] + "";
                txtSoi.Text = dtCust.Rows[0]["Soi"] + "";
                txtRoad.Text = dtCust.Rows[0]["Road"] + "";
                txtAgenMemID.Text = dtCust.Rows[0]["AgenMemID"] + "";
                txtAgenMemName.Text = dtCust.Rows[0]["agencyFullNameThai"] + "";
                txtCredit_bath.Text = dtCust.Rows[0]["Credit_Bath"] + "";
                txtCredit_day.Text = dtCust.Rows[0]["Credit_Day"] + "";
                
                if (dicProvince.ContainsValue(dtCust.Rows[0]["ProvinceCode"] + ""))
                {
                    txtProvince.Text =
                        dicProvince.Where(p => p.Value == dtCust.Rows[0]["ProvinceCode"] + "").Select(p => p.Key).
                            FirstOrDefault(); // dtCust.Rows[0]["ProvinceCode"] + "").Key; 
                    BindCboDistrict(dicProvince[txtProvince.Text.Trim()]);
                }else
                {
                    txtProvince.Text = dtCust.Rows[0]["ProvinceCode"] + "";
                }
                if (dicDistrict.ContainsValue(dtCust.Rows[0]["DistrictCode"] + ""))
                {
                    txtDistrict.Text =
                        dicDistrict.Where(p => p.Value == dtCust.Rows[0]["DistrictCode"] + "").Select(p => p.Key).
                            FirstOrDefault();
                    BindCboSubDistrict(dicDistrict[txtDistrict.Text.Trim()]);
                }
                else
                {
                    txtDistrict.Text = dtCust.Rows[0]["DistrictCode"] + "";
                }
                if (dicSubDistrict.ContainsValue(dtCust.Rows[0]["Sub_districtCode"] + ""))
                {
                    txtSubDistrict.Text =
                        dicSubDistrict.Where(p => p.Value == dtCust.Rows[0]["Sub_districtCode"] + "").Select(p => p.Key)
                            .FirstOrDefault();
                }
                else
                {
                    txtSubDistrict.Text = dtCust.Rows[0]["Sub_districtCode"] + "";
                }
                txtPostCode.Text = dtCust.Rows[0]["Postcode"] + "";

                if (dtCust.Rows[0]["IdCard"] + "" != "")
                {
                    try
                    {
                        var strIdCard = dtCust.Rows[0]["IdCard"] + "";
                        txtPassCode1.Text = strIdCard.Substring(0, 1);
                        txtPassCode2.Text = strIdCard.Substring(1, 1);
                        txtPassCode3.Text = strIdCard.Substring(2, 1);
                        txtPassCode4.Text = strIdCard.Substring(3, 1);
                        txtPassCode5.Text = strIdCard.Substring(4, 1);
                        txtPassCode6.Text = strIdCard.Substring(5, 1);
                        txtPassCode7.Text = strIdCard.Substring(6, 1);
                        txtPassCode8.Text = strIdCard.Substring(7, 1);
                        txtPassCode9.Text = strIdCard.Substring(8, 1);
                        txtPassCode10.Text = strIdCard.Substring(9, 1);
                        txtPassCode11.Text = strIdCard.Substring(10, 1);
                        txtPassCode12.Text = strIdCard.Substring(11, 1);
                        txtPassCode13.Text = strIdCard.Substring(12, 1);
                    }
                    catch (Exception)
                    {
                      
                    }
                    
                }
                txtPassportNo.Text = dtCust.Rows[0]["PassportNo"] + "";
                if (!string.IsNullOrEmpty(dtCust.Rows[0]["VipFlag"] + ""))
                {
                    chkVip.Checked = dtCust.Rows[0]["VipFlag"] + ""=="Y";
                }
                txtRemark.Text = dtCust.Rows[0]["Remark"] + "";
                txtAllergyHist.Text = dtCust.Rows[0]["AllergyHistory"] + "";
                txtUnderlying.Text = dtCust.Rows[0]["UnderlyingDisease"] + "";
                txtHowDid.Text = dtCust.Rows[0]["WhereGotTreatment"] + "";

                //BindDataContact
                if (dtCont.Rows.Count > 0)
                {
                    //if (dicPrefixCont.ContainsValue(dtCont.Rows[0]["PrefixCode"] + ""))
                    txtPrefixCont.Text = dtCont.Rows[0]["PrefixCode"] + "";// dicPrefixCont.Where(p => p.Value == dtCont.Rows[0]["PrefixCode"] + "").Select(p => p.Key).FirstOrDefault();
                    txtTNameCont.Text = dtCont.Rows[0]["Tname"] + "";
                    txtTSurNameCont.Text = dtCont.Rows[0]["TsurName"] + "";
                    txtTNickNameCont.Text = dtCont.Rows[0]["Tnickname"] + "";
                    txtFirstNameCont.Text = dtCont.Rows[0]["FirstName"] + "";
                    txtMidNameCont.Text = dtCont.Rows[0]["MiddleName"] + "";
                    txtSurNameCont.Text = dtCont.Rows[0]["Surname"] + "";
                    txtNickNameCont.Text = dtCont.Rows[0]["NickName"] + "";
                    if (dtCont.Rows[0]["Gender"] + "" == "M")
                    {
                        rdoMaleCont.Checked = true;
                    }
                    else rdoFemaleCont.Checked = true;
                    var strMobileC1 = dtCont.Rows[0]["Mobile1"] + "";
                    if (!string.IsNullOrEmpty(strMobileC1) && strMobileC1.Length == 10)
                    {

                        txtMobileC1_1.Text = strMobileC1.Substring(0, 1);
                        txtMobileC1_2.Text = strMobileC1.Substring(1, 1);
                        txtMobileC1_3.Text = strMobileC1.Substring(2, 1);
                        txtMobileC1_4.Text = strMobileC1.Substring(3, 1);
                        txtMobileC1_5.Text = strMobileC1.Substring(4, 1);
                        txtMobileC1_6.Text = strMobileC1.Substring(5, 1);
                        txtMobileC1_7.Text = strMobileC1.Substring(6, 1);
                        txtMobileC1_8.Text = strMobileC1.Substring(7, 1);
                        txtMobileC1_9.Text = strMobileC1.Substring(8, 1);
                        txtMobileC1_10.Text = strMobileC1.Substring(9, 1);
                    }
                    var strMobileC2 = dtCont.Rows[0]["Mobile2"] + "";
                    if (!string.IsNullOrEmpty(strMobileC2) && strMobileC2.Length == 10)
                    {

                        txtMobileC2_1.Text = strMobileC2.Substring(0, 1);
                        txtMobileC2_2.Text = strMobileC2.Substring(1, 1);
                        txtMobileC2_3.Text = strMobileC2.Substring(2, 1);
                        txtMobileC2_4.Text = strMobileC2.Substring(3, 1);
                        txtMobileC2_5.Text = strMobileC2.Substring(4, 1);
                        txtMobileC2_6.Text = strMobileC2.Substring(5, 1);
                        txtMobileC2_7.Text = strMobileC2.Substring(6, 1);
                        txtMobileC2_8.Text = strMobileC2.Substring(7, 1);
                        txtMobileC2_9.Text = strMobileC2.Substring(8, 1);
                        txtMobileC2_10.Text = strMobileC2.Substring(9, 1);
                    }
                    var strTelC1 = dtCont.Rows[0]["Tel1"] + "";
                    if (!string.IsNullOrEmpty(strTelC1) && strTelC1.Length == 9)
                    {

                        txtTelC1_1.Text = strTelC1.Substring(0, 1);
                        txtTelC1_2.Text = strTelC1.Substring(1, 1);
                        txtTelC1_3.Text = strTelC1.Substring(2, 1);
                        txtTelC1_4.Text = strTelC1.Substring(3, 1);
                        txtTelC1_5.Text = strTelC1.Substring(4, 1);
                        txtTelC1_6.Text = strTelC1.Substring(5, 1);
                        txtTelC1_7.Text = strTelC1.Substring(6, 1);
                        txtTelC1_8.Text = strTelC1.Substring(7, 1);
                        txtTelC1_9.Text = strTelC1.Substring(8, 1);
                    }
                    var strTelC2 = dtCont.Rows[0]["Tel2"] + "";
                    if (!string.IsNullOrEmpty(strTelC2) && strTelC2.Length == 9)
                    {

                        txtTelC2_1.Text = strTelC2.Substring(0, 1);
                        txtTelC2_2.Text = strTelC2.Substring(1, 1);
                        txtTelC2_3.Text = strTelC2.Substring(2, 1);
                        txtTelC2_4.Text = strTelC2.Substring(3, 1);
                        txtTelC2_5.Text = strTelC2.Substring(4, 1);
                        txtTelC2_6.Text = strTelC2.Substring(5, 1);
                        txtTelC2_7.Text = strTelC2.Substring(6, 1);
                        txtTelC2_8.Text = strTelC2.Substring(7, 1);
                        txtTelC2_9.Text = strTelC2.Substring(8, 1);
                    }
                    //"P" = Parent,"M"=Mate,"C"=Child,"F"=Friend,"O"=Other
                    if (dtCont.Rows[0]["RelationFlag"] + "" == "P")
                    {
                        rdoParent.Checked = true;
                    }
                    else if (dtCont.Rows[0]["RelationFlag"] + "" == "M")
                    {
                        rdoMate.Checked = true;
                    }
                    else if (dtCont.Rows[0]["RelationFlag"] + "" == "C")
                    {
                        rdoChild.Checked = true;
                    }
                    else if (dtCont.Rows[0]["RelationFlag"] + "" == "F")
                    {
                        rdoFriend.Checked = true;
                    }
                    else if (dtCont.Rows[0]["RelationFlag"] + "" == "O")
                    {
                        rdoOther.Checked = true;
                        txtRelationOther.ReadOnly = false;
                        txtRelationOther.Text = dtCont.Rows[0]["RelationOther"] + "";
                    }
                }

                //Bind Data Interested
                if (dtAes.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dtAes.Rows[0]["FacialDesign"] + ""))
                    {
                        chkFacialDesign.Checked = true;
                        txtFacialDesign.Text = dtAes.Rows[0]["FacialDesign"] + "";
                    }
                    if (!string.IsNullOrEmpty(dtAes.Rows[0]["FacialTreatment"] + ""))
                    {
                        chkFacialTreatment.Checked = true;
                        txtFacialTreatment.Text = dtAes.Rows[0]["FacialTreatment"] + "";
                    }
                    if (!string.IsNullOrEmpty(dtAes.Rows[0]["Laser"] + ""))
                    {
                        chkLaser.Checked = true;
                        txtLaser.Text = dtAes.Rows[0]["Laser"] + "";
                    }
                    if (!string.IsNullOrEmpty(dtAes.Rows[0]["AestheticOther"] + ""))
                    {
                        chkAesOther.Checked = true;
                        txtAesOther.Text = dtAes.Rows[0]["AestheticOther"] + "";
                    }
                }
                //Hair
                if (dtHair.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dtHair.Rows[0]["HairTransplantation"] + ""))
                    {
                        chkHairTrans.Checked = true;
                        txtHairTrans.Text = dtHair.Rows[0]["HairTransplantation"] + "";
                    }
                    if (!string.IsNullOrEmpty(dtHair.Rows[0]["HairReform"] + ""))
                    {
                        chkHairReform.Checked = true;
                        txtHairReform.Text = dtHair.Rows[0]["HairReform"] + "";
                    }
                    if (!string.IsNullOrEmpty(dtHair.Rows[0]["HairOther"] + ""))
                    {
                        chkHairOther.Checked = true;
                        txtHairOther.Text = dtHair.Rows[0]["HairOther"] + "";
                    }
                }
                //Bind Data Cosmetic
                if (dtCos.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dtCos.Rows[0]["Eye"] + ""))
                    {
                        chkEye.Checked = true;
                        txtEye.Text = dtCos.Rows[0]["Eye"] + "";
                    }
                    if (!string.IsNullOrEmpty(dtCos.Rows[0]["Nose"] + ""))
                    {
                        chkNose.Checked = true;
                        txtNose.Text = dtCos.Rows[0]["Nose"] + "";
                    }
                    if (!string.IsNullOrEmpty(dtCos.Rows[0]["Chest"] + ""))
                    {
                        chkChest.Checked = true;
                        txtChest.Text = dtCos.Rows[0]["Chest"] + "";
                    }
                    if (!string.IsNullOrEmpty(dtCos.Rows[0]["Other"] + ""))
                    {
                        chkCosOther.Checked = true;
                        txtCosmeticOther.Text = dtCos.Rows[0]["Other"] + "";
                    }
                }
                //Body Center
                if (dtBody.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dtBody.Rows[0]["BodyVaserTite"] + ""))
                    {
                        chkBodyVaser.Checked = true;
                        txtBodyVaser.Text = dtBody.Rows[0]["BodyVaserTite"] + "";
                    }
                    if (!string.IsNullOrEmpty(dtBody.Rows[0]["BodyTreatment"] + ""))
                    {
                        chkBodyTreatment.Checked = true;
                        txtBodyTreatment.Text = dtBody.Rows[0]["BodyTreatment"] + "";
                    }
                    if (!string.IsNullOrEmpty(dtBody.Rows[0]["BodyOther"] + ""))
                    {
                        chkBodyOther.Checked = true;
                        txtBodyOther.Text = dtBody.Rows[0]["BodyOther"] + "";
                    }
                }
                //How you hear
                if (dtHow.Rows.Count > 0)
                {
                    if (dtHow.Rows[0]["Newspaper"] + "" == "Y")
                    {
                        rdoNewspaper.Checked = true;
                    }
                    if (dtHow.Rows[0]["Magazine"] + "" == "Y")
                    {
                        rdoMagazine.Checked = true;
                    }
                    if (dtHow.Rows[0]["Internet"] + "" == "Y")
                    {
                        rdoInternet.Checked = true;
                    }
                    if (dtHow.Rows[0]["Friend"] + "" == "Y")
                    {
                        rdoFriend.Checked = true;
                    }
                    if (dtHow.Rows[0]["Travelthrough"] + "" == "Y")
                    {
                        rdoTravel.Checked = true;
                    }
                    if (dtHow.Rows[0]["Facebook"] + "" == "Y")
                    {
                        rdoFacebook.Checked = true;
                    }
                    if (dtHow.Rows[0]["Instagram"] + "" == "Y")
                    {
                        rdoInstagram.Checked = true;
                    }
                    if (dtHow.Rows[0]["Sms"] + "" == "Y")
                    {
                        rdoSms.Checked = true;
                    }
                    if (!string.IsNullOrEmpty(dtHow.Rows[0]["HowYouhearOther"] + ""))
                    {
                        rdo_Other.Checked = true;
                        txtHowDid.Text = dtHow.Rows[0]["HowYouhearOther"] + "";
                    }
                }

                //Member group 
                if (dtMembergroup.Rows.Count > 0)
                {
                    foreach (DataRow item in dtMembergroup.Rows)
                    {
                        object[] myItems = {
                                                     false,//chk
                                                     item["CN_Sub"],
                                                     item["FullNameThai"]!=""?item["FullNameThai"]:item["FullNameEng"],
                                                    item["CustomerType"],
                                           };
                        dgvMember.Rows.Add(myItems);
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Event

        private void cboProvince_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            //{
            //    cboDistrict.Focus();
            //}
        }

        private void cboDistrict_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            //{
            //    cboSubDistrict.Focus();
            //}
        }

        private void cboSubDistrict_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //if (e.KeyCode != Keys.Enter && e.KeyCode != Keys.Tab) return;
            //txtPostCode.Focus();
            //txtPostCode.Text = "";
        }



        private void FrmCustomerSetting_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.SendKey(e.KeyChar);
        }

        private void FrmCustomerSetting_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void FrmCustomerSetting_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void txtPassCode1_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtPassCode1.Text == "") return;
            txtPassCode2.Focus();
            txtPassCode2.SelectAll();
        }

        private void txtPassCode2_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtPassCode2.Text == "") return;
            txtPassCode3.Focus();
            txtPassCode3.SelectAll();
        }

        private void txtPassCode3_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtPassCode3.Text == "") return;
            txtPassCode4.Focus();
            txtPassCode4.SelectAll();
        }

        private void txtPassCode4_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtPassCode4.Text == "") return;
            txtPassCode5.Focus();
            txtPassCode5.SelectAll();
        }

        private void txtPassCode5_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtPassCode5.Text == "") return;
            txtPassCode6.Focus();
            txtPassCode6.SelectAll();
        }

        private void txtPassCode6_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtPassCode6.Text == "") return;
            txtPassCode7.Focus();
            txtPassCode7.SelectAll();
        }

        private void txtPassCode7_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtPassCode7.Text == "") return;
            txtPassCode8.Focus();
            txtPassCode8.SelectAll();
        }

        private void txtPassCode8_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtPassCode8.Text == "") return;
            txtPassCode9.Focus();
            txtPassCode9.SelectAll();
        }

        private void txtPassCode9_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtPassCode9.Text == "") return;
            txtPassCode10.Focus();
            txtPassCode10.SelectAll();
        }

        private void txtPassCode10_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtPassCode10.Text == "") return;
            txtPassCode11.Focus();
            txtPassCode11.SelectAll();
        }

        private void txtPassCode11_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtPassCode11.Text == "") return;
            txtPassCode12.Focus();
            txtPassCode12.SelectAll();
        }

        private void txtPassCode12_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtPassCode12.Text == "") return;
            txtPassCode13.Focus();
            txtPassCode13.SelectAll();
        }

        private void txtDayBirth1_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtDayBirth1.Text == "") return;
            txtDayBirth2.Focus();
            txtDayBirth2.SelectAll();
        }

        private void txtDayBirth2_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtDayBirth2.Text == "") return;
            txtMBirth1.Focus();
            txtMBirth1.SelectAll();
        }

        private void txtMBirth1_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMBirth1.Text == "") return;
            txtMBirth2.Focus();
            txtMBirth2.SelectAll();
        }

        private void tabInterested_Click(object sender, EventArgs e)
        {

        }

        //private void dtpDateReg_ValueChanged(object sender, EventArgs e)
        //{
        //    dtpDateReg.CustomFormat = "dd/MM/yyyy";
        //}

        //private void dtpBirtDate_ValueChanged(object sender, EventArgs e)
        //{
        //    dtpBirtDate.CustomFormat = "dd/MM/yyyy";
        //}

        private void chkFacialDesign_CheckedChanged(object sender, EventArgs e)
        {
            txtFacialDesign.ReadOnly = !chkFacialDesign.Checked;
        }

        private void chkFacialTreatment_CheckedChanged(object sender, EventArgs e)
        {
            txtFacialTreatment.ReadOnly = !chkFacialTreatment.Checked;
        }

        private void chkLaser_CheckedChanged(object sender, EventArgs e)
        {
            txtLaser.ReadOnly = !chkLaser.Checked;
        }

        private void chkAesOther_CheckedChanged(object sender, EventArgs e)
        {
            txtAesOther.ReadOnly = !chkAesOther.Checked;
        }

        private void chkHairTrans_CheckedChanged(object sender, EventArgs e)
        {
            txtHairTrans.ReadOnly = !chkHairTrans.Checked;
        }

        private void chkHairReform_CheckedChanged(object sender, EventArgs e)
        {
            txtHairReform.ReadOnly = !chkHairReform.Checked;
        }

        private void chkHairOther_CheckedChanged(object sender, EventArgs e)
        {
            txtHairOther.ReadOnly = !chkHairOther.Checked;
        }

        private void chkEye_CheckedChanged(object sender, EventArgs e)
        {
            txtEye.ReadOnly = !chkEye.Checked;
        }

        private void chkNose_CheckedChanged(object sender, EventArgs e)
        {
            txtNose.ReadOnly = !chkNose.Checked;
        }

        private void chkChest_CheckedChanged(object sender, EventArgs e)
        {
            txtChest.ReadOnly = !chkChest.Checked;
        }

        private void chkCosOther_CheckedChanged(object sender, EventArgs e)
        {
            txtCosmeticOther.ReadOnly = !chkCosOther.Checked;
        }

        private void rdo_Other_CheckedChanged(object sender, EventArgs e)
        {
            txtHowDid.ReadOnly = !rdo_Other.Checked;
            if (rdo_Other.Checked == false) txtHowDid.Text = "";
        }

        private void rdoOther_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOther.Checked)
            {
                txtRelationOther.ReadOnly = false;
            }
            else
            {
                txtRelationOther.ReadOnly = true;
            }
        }

        private void txtMobile1_1_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMobile1_1.Text == "") return;
            txtMobile1_2.Focus();
            txtMobile1_2.SelectAll();
        }

        private void txtMobile1_2_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMobile1_2.Text == "") return;
            txtMobile1_3.Focus();
            txtMobile1_3.SelectAll();
        }

        private void txtMobile1_3_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMobile1_3.Text == "") return;
            txtMobile1_4.Focus();
            txtMobile1_4.SelectAll();
        }

        private void txtMobile1_4_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMobile1_4.Text == "") return;
            txtMobile1_5.Focus();
            txtMobile1_5.SelectAll();
        }

        private void txtMobile1_5_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMobile1_5.Text == "") return;
            txtMobile1_6.Focus();
            txtMobile1_6.SelectAll();
        }

        private void txtMobile1_6_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMobile1_6.Text == "") return;
            txtMobile1_7.Focus();
            txtMobile1_7.SelectAll();
        }

        private void txtMobile1_7_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMobile1_7.Text == "") return;
            txtMobile1_8.Focus();
            txtMobile1_8.SelectAll();
        }

        private void txtMobile1_8_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMobile1_8.Text == "") return;
            txtMobile1_9.Focus();
            txtMobile1_9.SelectAll();
        }

        private void txtMobile1_9_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMobile1_9.Text == "") return;
            txtMobile1_10.Focus();
            txtMobile1_10.SelectAll();
        }

        private void txtMobile1_10_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMobile1_10.Text == "") return;
            txtMobile2_1.Focus();
            txtMobile2_1.SelectAll();
        }

        private void txtMobile2_1_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMobile2_1.Text == "") return;
            txtMobile2_2.Focus();
            txtMobile2_2.SelectAll();
        }

        private void txtMobile2_2_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMobile2_2.Text == "") return;
            txtMobile2_3.Focus();
            txtMobile2_3.SelectAll();
        }

        private void txtMobile2_3_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMobile2_3.Text == "") return;
            txtMobile2_4.Focus();
            txtMobile2_4.SelectAll();
        }

        private void txtMobile2_4_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMobile2_4.Text == "") return;
            txtMobile2_5.Focus();
            txtMobile2_5.SelectAll();
        }

        private void txtMobile2_5_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMobile2_5.Text == "") return;
            txtMobile2_6.Focus();
            txtMobile2_6.SelectAll();
        }

        private void txtMobile2_6_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMobile2_6.Text == "") return;
            txtMobile2_7.Focus();
            txtMobile2_7.SelectAll();
        }

        private void txtMobile2_7_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMobile2_7.Text == "") return;
            txtMobile2_8.Focus();
            txtMobile2_8.SelectAll();
        }

        private void txtMobile2_8_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMobile2_8.Text == "") return;
            txtMobile2_9.Focus();
            txtMobile2_9.SelectAll();
        }

        private void txtMobile2_9_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMobile2_9.Text == "") return;
            txtMobile2_10.Focus();
            txtMobile2_10.SelectAll();
        }

        private void txtMobile2_10_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMobile2_10.Text == "") return;
            txtTel1_1.Focus();
            txtTel1_1.SelectAll();
        }

        private void txtTel1_1_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTel1_1.Text == "") return;
            txtTel1_2.Focus();
            txtTel1_2.SelectAll();
        }

        private void txtTel1_2_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTel1_2.Text == "") return;
            txtTel1_3.Focus();
            txtTel1_3.SelectAll();
        }

        private void txtTel1_3_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTel1_3.Text == "") return;
            txtTel1_4.Focus();
            txtTel1_4.SelectAll();
        }

        private void txtTel1_4_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTel1_4.Text == "") return;
            txtTel1_5.Focus();
            txtTel1_5.SelectAll();
        }

        private void txtTel1_5_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTel1_5.Text == "") return;
            txtTel1_6.Focus();
            txtTel1_6.SelectAll();
        }

        private void txtTel1_6_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTel1_6.Text == "") return;
            txtTel1_7.Focus();
            txtTel1_7.SelectAll();
        }

        private void txtTel1_7_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTel1_7.Text == "") return;
            txtTel1_8.Focus();
            txtTel1_8.SelectAll();
        }

        private void txtTel1_8_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTel1_8.Text == "") return;
            txtTel1_9.Focus();
            txtTel1_9.SelectAll();
        }

        private void txtTel1_9_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTel1_9.Text == "") return;
            txtTel2_1.Focus();
            txtTel2_1.SelectAll();
        }

        private void txtTel2_1_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTel2_1.Text == "") return;
            txtTel2_2.Focus();
            txtTel2_2.SelectAll();
        }

        private void txtTel2_2_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTel2_2.Text == "") return;
            txtTel2_3.Focus();
            txtTel2_3.SelectAll();
        }

        private void txtTel2_3_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTel2_3.Text == "") return;
            txtTel2_4.Focus();
            txtTel2_4.SelectAll();
        }

        private void txtTel2_4_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTel2_4.Text == "") return;
            txtTel2_5.Focus();
            txtTel2_5.SelectAll();
        }

        private void txtTel2_5_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTel2_5.Text == "") return;
            txtTel2_6.Focus();
            txtTel2_6.SelectAll();
        }

        private void txtTel2_6_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTel2_6.Text == "") return;
            txtTel2_7.Focus();
            txtTel2_7.SelectAll();
        }

        private void txtTel2_7_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTel2_7.Text == "") return;
            txtTel2_8.Focus();
            txtTel2_8.SelectAll();
        }

        private void txtTel2_8_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTel2_8.Text == "") return;
            txtTel2_9.Focus();
            txtTel2_9.SelectAll();
        }

        private void txtTel2_9_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTel2_9.Text == "") return;
            txtTel2_10.Focus();
            txtTel2_10.SelectAll();
        }

        private void txtTel2_10_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTel2_10.Text == "") return;
            txtTel2_11.Focus();
            txtTel2_11.SelectAll();
        }

        private void txtTel2_11_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTel2_11.Text == "") return;
            txtTel2_12.Focus();
            txtTel2_12.SelectAll();
        }

        private void txtTel2_12_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTel2_12.Text == "") return;
            txtEmail.Focus();
            txtEmail.SelectAll();
        }

        private void txtMobileC1_1_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMobileC1_1.Text == "") return;
            txtMobileC1_2.Focus();
            txtMobileC1_2.SelectAll();
        }

        private void txtMobileC1_2_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMobileC1_2.Text == "") return;
            txtMobileC1_3.Focus();
            txtMobileC1_3.SelectAll();
        }

        private void txtMobileC1_3_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMobileC1_3.Text == "") return;
            txtMobileC1_4.Focus();
            txtMobileC1_4.SelectAll();
        }

        private void txtMobileC1_4_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMobileC1_4.Text == "") return;
            txtMobileC1_5.Focus();
            txtMobileC1_5.SelectAll();
        }

        private void txtMobileC1_5_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMobileC1_5.Text == "") return;
            txtMobileC1_6.Focus();
            txtMobileC1_6.SelectAll();
        }

        private void txtMobileC1_6_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMobileC1_6.Text == "") return;
            txtMobileC1_7.Focus();
            txtMobileC1_7.SelectAll();
        }

        private void txtMobileC1_7_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMobileC1_7.Text == "") return;
            txtMobileC1_8.Focus();
            txtMobileC1_8.SelectAll();
        }

        private void txtMobileC1_8_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMobileC1_8.Text == "") return;
            txtMobileC1_9.Focus();
            txtMobileC1_9.SelectAll();
        }

        private void txtMobileC1_9_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMobileC1_9.Text == "") return;
            txtMobileC1_10.Focus();
            txtMobileC1_10.SelectAll();
        }

        private void txtMobileC2_1_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMobileC2_1.Text == "") return;
            txtMobileC2_2.Focus();
            txtMobileC2_2.SelectAll();
        }

        private void txtMobileC2_2_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMobileC2_2.Text == "") return;
            txtMobileC2_3.Focus();
            txtMobileC2_3.SelectAll();
        }

        private void txtMobileC2_3_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMobileC2_3.Text == "") return;
            txtMobileC2_4.Focus();
            txtMobileC2_4.SelectAll();
        }

        private void txtMobileC2_4_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMobileC2_4.Text == "") return;
            txtMobileC2_5.Focus();
            txtMobileC2_5.SelectAll();
        }

        private void txtMobileC2_5_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMobileC2_5.Text == "") return;
            txtMobileC2_6.Focus();
            txtMobileC2_6.SelectAll();
        }

        private void txtMobileC2_6_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMobileC2_6.Text == "") return;
            txtMobileC2_7.Focus();
            txtMobileC2_7.SelectAll();
        }

        private void txtMobileC2_7_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMobileC2_7.Text == "") return;
            txtMobileC2_8.Focus();
            txtMobileC2_8.SelectAll();
        }

        private void txtMobileC2_8_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMobileC2_8.Text == "") return;
            txtMobileC2_9.Focus();
            txtMobileC2_9.SelectAll();
        }

        private void txtMobileC2_9_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMobileC2_9.Text == "") return;
            txtMobileC2_10.Focus();
            txtMobileC2_10.SelectAll();
        }


        private void txtTelC1_1_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTelC1_1.Text == "") return;
            txtTelC1_2.Focus();
            txtTelC1_2.SelectAll();
        }

        private void txtTelC1_2_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTelC1_2.Text == "") return;
            txtTelC1_3.Focus();
            txtTelC1_3.SelectAll();
        }

        private void txtTelC1_3_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTelC1_3.Text == "") return;
            txtTelC1_4.Focus();
            txtTelC1_4.SelectAll();
        }

        private void txtTelC1_4_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTelC1_4.Text == "") return;
            txtTelC1_5.Focus();
            txtTelC1_5.SelectAll();
        }

        private void txtTelC1_5_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTelC1_5.Text == "") return;
            txtTelC1_6.Focus();
            txtTelC1_6.SelectAll();
        }

        private void txtTelC1_6_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTelC1_6.Text == "") return;
            txtTelC1_7.Focus();
            txtTelC1_7.SelectAll();
        }

        private void txtTelC1_7_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTelC1_7.Text == "") return;
            txtTelC1_8.Focus();
            txtTelC1_8.SelectAll();
        }

        private void txtTelC1_8_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTelC1_8.Text == "") return;
            txtTelC1_9.Focus();
            txtTelC1_9.SelectAll();
        }


        private void txtTelC2_1_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTelC2_1.Text == "") return;
            txtTelC2_2.Focus();
            txtTelC2_2.SelectAll();
        }

        private void txtTelC2_2_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTelC2_2.Text == "") return;
            txtTelC2_3.Focus();
            txtTelC2_3.SelectAll();
        }

        private void txtTelC2_3_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTelC2_3.Text == "") return;
            txtTelC2_4.Focus();
            txtTelC2_4.SelectAll();
        }

        private void txtTelC2_4_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTelC2_4.Text == "") return;
            txtTelC2_5.Focus();
            txtTelC2_5.SelectAll();
        }

        private void txtTelC2_5_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTelC2_5.Text == "") return;
            txtTelC2_6.Focus();
            txtTelC2_6.SelectAll();
        }

        private void txtTelC2_6_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTelC2_6.Text == "") return;
            txtTelC2_7.Focus();
            txtTelC2_7.SelectAll();
        }

        private void txtTelC2_7_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTelC2_7.Text == "") return;
            txtTelC2_8.Focus();
            txtTelC2_8.SelectAll();
        }

        private void txtTelC2_8_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTelC2_8.Text == "") return;
            txtTelC2_9.Focus();
            txtTelC2_9.SelectAll();
        }

        private void txtTelC2_9_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTelC2_9.Text == "") return;
            txtTelC2_10.Focus();
            txtTelC2_10.SelectAll();
        }
        private void txtTelC2_10_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTelC2_10.Text == "") return;
            txtTelC2_11.Focus();
            txtTelC2_11.SelectAll();
        }
        private void txtTelC2_11_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTelC2_11.Text == "") return;
            txtTelC2_12.Focus();
            txtTelC2_12.SelectAll();
        }

        private void chkBodyVaser_CheckedChanged(object sender, EventArgs e)
        {
            txtBodyVaser.ReadOnly = !chkBodyVaser.Checked;
        }

        private void chkBodyTreatment_CheckedChanged(object sender, EventArgs e)
        {
            txtBodyTreatment.ReadOnly = !chkBodyTreatment.Checked;
        }

        private void chkBodyOther_CheckedChanged(object sender, EventArgs e)
        {
            txtBodyOther.ReadOnly = !chkBodyOther.Checked;
        }

        private void btnCamera_BtnClick()
        {
            FrmWebCapture obj = new FrmWebCapture(txtCN.Text.Trim());
            if (obj.ShowDialog() == DialogResult.OK)
            {
                picCustImage.ImageLocation =
                    _imageCustPath = Application.StartupPath + @"\PersonnelImage\" + obj.EN + ".jpg";
                _Changimage = true;
            }
        }


        public void SetPicture(string sLocation)
        {
            try
            {
                //if (boolGet == true) { boolCamera = true; }
                Statics.setPicture(picCustImage, sLocation);

                //this.imageCustPath = sLocation;
                //this.picCustImage.ImageLocation = this.imageCustPath;
                //this.imageCustChange = true;


                imageType = sLocation.Substring(sLocation.Length - 4, 4);
                Image.GetThumbnailImageAbort callback = ThumbnailCallback;
                picCustImage.Image = Image.FromFile(sLocation).GetThumbnailImage(320, 320, callback, IntPtr.Zero);
                mStrimagePath = sLocation;
                //lblNoPic.Visible = false;
            }
            catch (Exception ex)
            {
            }
        }

        //private void cmdBrowseImage_BtnClick()
        //{
        //    SetPictureBoxControls();
        //}

        protected bool ThumbnailCallback()
        {
            return false;
        }

        //private void SetPictureBoxControls()
        //{
        //    try
        //    {
        //        odlgImage.Title = "เลือกไฟล์รูปภาพ";
        //        odlgImage.Filter = "All Image Formats (*.bmp;*.jpg;*.gif;*.png;)|*.bmp;*.jpg;*.gif;*.png" +
        //                           "|Bitmaps (*.bmp)|*.bmp|GIFs (*.gif)|*.gif|JPEGs (*.jpg)|*.jpg;*.jpeg|PNGs (*.png)|*.png;*.png";
        //        odlgImage.FileName = "";
        //        odlgImage.Multiselect = false;
        //        odlgImage.FilterIndex = 0;
        //        if (odlgImage.ShowDialog() == DialogResult.OK)
        //        {
        //            _imageCustPath = odlgImage.FileName;
        //            picCustImage.ImageLocation = _imageCustPath;

        //            picCustImage.SizeMode = PictureBoxSizeMode.Zoom;
        //            _imageCustChange = true;

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Utility.PopMsg(Utility.EnuMsgType.MsgTypeError,
        //                       "ไม่สามารถแสดงรูปภาพได้เนื่องจาก  \" " + ex.Message + "\"");
        //    }
        //}

        private void FrmCustomerSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics.frmCustormerSetting = null;
        }


        protected void ClearControl()
        {
            var ctl = new Control();
            while (GetNextControl(ctl, true) != null)
            {
                ctl = GetNextControl(ctl, true);
                if ((ctl.GetType() == typeof (TextBox)) || (ctl.GetType() == typeof (RichTextBox)) ||
                    (ctl.GetType() == typeof (MaskedTextBox)))
                {
                    ctl.Text = "";
                }
                else if ((ctl.GetType() == typeof (ComboBox)) && (((ComboBox) ctl).Items.Count > 0))
                {
                    ((ComboBox) ctl).SelectedIndex = 0;
                }
                else if ((ctl.GetType() == typeof (RadioButton)))
                {
                    ((RadioButton) ctl).Checked = false;
                }
                else if ((ctl.GetType() == typeof (CheckBox)))
                {
                    ((CheckBox) ctl).Checked = false;
                }
                else if ((ctl.GetType() == typeof (TextboxFormatInteger)))
                {
                    ctl.Text = "";
                }
                else if ((ctl.GetType() == typeof (PictureBox)))
                {
                    ((PictureBox) ctl).Image = null;
                    odlgImage.FileName = null;
                }
            }
        }

        private void picCustImage_Click(object sender, EventArgs e)
        {
            if(_imagePaht=="")return;
            var objForm = new popPreviewImage(_imagePaht, true);
            objForm.ShowDialog();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Statics.frmCustormerSetting = null;
            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearControl();
        }

        #endregion

        private void picBrown_Click(object sender, EventArgs e)
        {

            string imgPath = BrowseFile.BrowFileType("IMAGE");
            if (imgPath != "")
            {
                picCustImage.ImageLocation = _imagePaht = imgPath;
                _Changimage = true;
            }


            //FrmWebCapture webCapture = new FrmWebCapture(txtEN.Text.Trim());
            //if (webCapture.ShowDialog() == DialogResult.OK)
            //{
            //    picPersonnelImage.ImageLocation = _imagetPath = Application.StartupPath + @"\PersonnelImage\" + webCapture.EN + ".jpg";
            //    _Changimage = true;
            //}
        }

        private void txtProvince_Leave(object sender, EventArgs e)
        {
            try
            {
                //txtDistrict.Text = "";
                BindCboDistrict(dicProvince[txtProvince.Text.Trim()]);
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
        }

        private void txtDistrict_Leave(object sender, EventArgs e)
        {
            try
            {
                //txtSubDistrict.Text = "";
                BindCboSubDistrict(dicDistrict[txtDistrict.Text.Trim()]);
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }

        }

        private void txtSubDistrict_Leave(object sender, EventArgs e)
        {

            try
            {
                //txtPostCode.Text = "";
                BindTxtPostCode(dicSubDistrict[txtSubDistrict.Text.Trim()]);
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
        }

        private void dtpDateReg_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpBirtDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpBirtDate.Value != null)
            {
                DateTime myDate = dtpBirtDate.Value.Date; // DateTime(dateTimePicker1.Value);
                DateTime ToDate = DateTime.Now;

                DateDifference dDiff = new DateDifference(myDate, ToDate);
                txtYear.Text = dDiff.Year.ToString();
                txtMonth.Text = dDiff.Month.ToString();
                txtDay.Text = dDiff.Day.ToString();
                intYear = dDiff.Year;
            }
            if (dtpBirtDate.Checked)
            {
                txtDayBirth1.Enabled = false;
                txtDayBirth2.Enabled = false;
                txtMBirth1.Enabled = false;
                txtMBirth2.Enabled = false;
            }
            else
            {
                txtDayBirth1.Enabled = true;
                txtDayBirth2.Enabled = true;
                txtMBirth1.Enabled = true;
                txtMBirth2.Enabled = true;
            }
        }
      private void dtpBirtDate_EnabledChanged(object sender, EventArgs e)
        {
           
        }
        private void FrmCustomerSetting_Activated(object sender, EventArgs e)
        {
            Statics.SetToolbar(false,false,false,true,false);
        }

        private void txtProvince_TextChanged(object sender, EventArgs e)
        {
            txtDistrict.Text = "";
        }

        private void txtDistrict_TextChanged(object sender, EventArgs e)
        {
            txtSubDistrict.Text = "";
        }

        private void txtSubDistrict_TextChanged(object sender, EventArgs e)
        {
           // txtPostCode.Text = "";
        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtYear_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        private void txtYear_Leave(object sender, EventArgs e)
        {
            if (txtYear.Text.Trim() != "")
            {
                dtpBirtDate.Value = dtpBirtDate.Value.AddYears(intYear -int.Parse(txtYear.Text.Trim()) );
                //dtpBirtDate.Value = new DateTime(int year,int month,int date);
            }
        }

        private void btnSelectAgency_Click(object sender, EventArgs e)
        {
            try
            {
                PopAgencySearch obj = new PopAgencySearch();
                obj.StartPosition = FormStartPosition.CenterScreen;
                obj.WindowState = FormWindowState.Normal;
                obj.BackColor = Color.FromArgb(170, 232, 229);
                obj.multiSelect = false;
                obj.ShowDialog();

                if (!string.IsNullOrEmpty(obj.agenMemberId))
                {
                    txtAgenMemName.Text = obj.agencyMemberName;
                    txtAgenMemID.Text = obj.agenMemberId;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMemberShip_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddDown_BtnClick()
        {
            try
            {
                  PopCustSearch obj = new PopCustSearch();
                    obj.StartPosition = FormStartPosition.CenterScreen;
                    obj.WindowState = FormWindowState.Normal;
                    obj.BackColor = Color.FromArgb(170, 232, 229);
                    obj.ShowDialog();

                    if (!string.IsNullOrEmpty(obj.CN))
                    {
                        object[] myItems = {
                                                     false,//chk
                                                     obj.CN,
                                                     obj.CustomerName,
                                                     obj.CustomerType,
                                           };
                        dgvMember.Rows.Add(myItems);
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
                List<DataGridViewRow> rowsToDelete = new List<DataGridViewRow>();
                foreach (DataGridViewRow row in dgvMember.Rows)
                {
                    DataGridViewCheckBoxCell chk = row.Cells[0] as DataGridViewCheckBoxCell;
                    if (Convert.ToBoolean(chk.Value) == true)
                    {
                        rowsToDelete.Add(row);
                    }
                }

                foreach (DataGridViewRow row in rowsToDelete)
                    dgvMember.Rows.Remove(row);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        private void dgvMember_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        private void dgvMember_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                   DataGridViewCheckBoxCell chCom = new DataGridViewCheckBoxCell();
                   chCom = (DataGridViewCheckBoxCell)dgvMember.Rows[dgvMember.CurrentRow.Index].Cells["CHKSELECT"];
                   if (e.ColumnIndex == chCom.ColumnIndex)
                   {
                       //if ((bool)chCom.Value)
                           chCom.Value = !(bool)chCom.Value;
                   }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
    // class Item
    //{
    //    public string Name;
    //    public string Value;
    //    public Item(string name, string value)
    //    {
    //        Name = name; Value = value;
    //    }
    //    public override string ToString()
    //    {
    //        // Generates the text shown in the combo box
    //        return Name;
    //    }
    //}
}

