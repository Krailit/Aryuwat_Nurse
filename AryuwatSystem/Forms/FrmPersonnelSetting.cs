using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using AryuwatSystem.DerClass;
using AryuwatSystem.Data;
using AryuwatSystem.UserControls;
using WeifenLuo.WinFormsUI.Docking;
using Customer = Entity.Customer;
using Personnel = Entity.Personnel;
using Entity;

namespace AryuwatSystem.Forms
{
    public partial class FrmPersonnelSetting : DockContent, IForm
    {
        private DataSet dsPrefix = null;
        private Dictionary<string, string> dicPrefix = new Dictionary<string, string>();
        private Dictionary<string, string> dicProvince = new Dictionary<string, string>();
        private Dictionary<string, string> dicDistrict = new Dictionary<string, string>();
        private Dictionary<string, string> dicSubDistrict = new Dictionary<string, string>();
        private AutoCompleteStringCollection colValues = new AutoCompleteStringCollection();

        public FrmPersonnelSetting()
        {
            InitializeComponent();
            CultureInfo ci = new CultureInfo("th-TH");

            System.Threading.Thread.CurrentThread.CurrentCulture = ci;
            System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
            Thread.CurrentThread.CurrentCulture.DateTimeFormat.Calendar = new ThaiBuddhistCalendar();
            Thread.CurrentThread.CurrentUICulture.DateTimeFormat.Calendar = new ThaiBuddhistCalendar();
          
        }
        public static bool IsValidEmailAddress(string s)
        {
            var regex = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
            return regex.IsMatch(s);
        }
        public FrmPersonnelSetting(ref Personnel pn)
        {
            // TODO: Complete member initialization
            this.pn = pn;
            InitializeComponent();
            CultureInfo ci = new CultureInfo("th-TH");

            System.Threading.Thread.CurrentThread.CurrentCulture = ci;
            System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
            Thread.CurrentThread.CurrentCulture.DateTimeFormat.Calendar = new ThaiBuddhistCalendar();
            Thread.CurrentThread.CurrentUICulture.DateTimeFormat.Calendar = new ThaiBuddhistCalendar();
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

        private bool blnCboProvLoad = false;
        private DataTable dtAdministrative = new DataTable();
        private DataTable dtPrefix = new DataTable();
        private DataTable dtProvince = new DataTable();
        private DataTable dtDistrict = new DataTable();
        private DataTable dtSubDistrict = new DataTable();
        private DataTable dtZipcode = new DataTable();
        private string _imagetPath="";
        private bool _Changimage = false;
        public string typeCustomer { get; set; }
        private Personnel pn = null;
        private int? intStatus;
        public DerUtility.AccessType FormType { get; set; }
        public string en = null;

        public string EN
        {
            get { return en; }
            set { en = value; }

        }

        protected bool ThumbnailCallback()
        {
            return false;
        }

        #endregion


        private void SetStartControls()
        {
            BindCboBran_PersonnelType();
            BindCboPersonnelGroup();
            BindCboPrefix();

            BindCboProvince();
        
            //Thread progressThreadLoad = new Thread(delegate()
            //{
            //    BackgroundWorker bgWorker = new BackgroundWorker();
            //    bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
            //    bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
            //    bgWorker.RunWorkerAsync();
            //});
            //progressThreadLoad.Start();

            BindCboDistrict(null);
            BindCboSubDistrict(null);
            BindTxtPostCode(null);
            dtpBirtDate.Checked = false;

            if ((Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN))
                panelGroupAdmin.Visible = true;
            else 
                panelGroupAdmin.Visible = false;

            //dtpBirtDateInfa.ValueChanged+=new EventHandler(dtpBirtDate_ValueChanged);
            dtpBirtDate.ValueChanged += new EventHandler(dtpBirtDate_ValueChanged);

            txtIDcard1.KeyUp += new KeyEventHandler(txtIDcard1_KeyUp);
            txtIDcard2.KeyUp += new KeyEventHandler(txtIDcard2_KeyUp);
            txtIDcard3.KeyUp += new KeyEventHandler(txtIDcard3_KeyUp);
            txtIDcard4.KeyUp += new KeyEventHandler(txtIDcard4_KeyUp);
            txtIDcard5.KeyUp += new KeyEventHandler(txtIDcard5_KeyUp);
            txtIDcard6.KeyUp += new KeyEventHandler(txtIDcard6_KeyUp);
            txtIDcard7.KeyUp += new KeyEventHandler(txtIDcard7_KeyUp);
            txtIDcard8.KeyUp += new KeyEventHandler(txtIDcard8_KeyUp);
            txtIDcard9.KeyUp += new KeyEventHandler(txtIDcard9_KeyUp);
            txtIDcard10.KeyUp += new KeyEventHandler(txtIDcard10_KeyUp);
            txtIDcard11.KeyUp += new KeyEventHandler(txtIDcard11_KeyUp);
            txtIDcard12.KeyUp += new KeyEventHandler(txtIDcard12_KeyUp);


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
            //txtTel1_3.KeyUp += this.txtTel1_3_KeyUp;
            //txtTel1_4.KeyUp += this.txtTel1_4_KeyUp;
            //txtTel1_5.KeyUp += this.txtTel1_5_KeyUp;
            //txtTel1_6.KeyUp += this.txtTel1_6_KeyUp;
            //txtTel1_7.KeyUp += this.txtTel1_7_KeyUp;
            //txtTel1_8.KeyUp += this.txtTel1_8_KeyUp;
              
        }

        private bool bgComplete = false;
        void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bgComplete = true;
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BindCboProvince();
        }


        private void txtIDcard1_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtIDcard1.Text == "") return;
            txtIDcard2.Focus();
            txtIDcard2.SelectAll();
        }

        private void txtIDcard2_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtIDcard2.Text == "") return;
            txtIDcard3.Focus();
            txtIDcard3.SelectAll();
        }

        private void txtIDcard3_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtIDcard3.Text == "") return;
            txtIDcard4.Focus();
            txtIDcard4.SelectAll();
        }

        private void txtIDcard4_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtIDcard4.Text == "") return;
            txtIDcard5.Focus();
            txtIDcard5.SelectAll();
        }

        private void txtIDcard5_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtIDcard5.Text == "") return;
            txtIDcard6.Focus();
            txtIDcard6.SelectAll();
        }

        private void txtIDcard6_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtIDcard6.Text == "") return;
            txtIDcard7.Focus();
            txtIDcard7.SelectAll();
        }

        private void txtIDcard7_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtIDcard7.Text == "") return;
            txtIDcard8.Focus();
            txtIDcard8.SelectAll();
        }

        private void txtIDcard8_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtIDcard8.Text == "") return;
            txtIDcard9.Focus();
            txtIDcard9.SelectAll();
        }

        private void txtIDcard9_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtIDcard9.Text == "") return;
            txtIDcard10.Focus();
            txtIDcard10.SelectAll();
        }

        private void txtIDcard10_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtIDcard10.Text == "") return;
            txtIDcard11.Focus();
            txtIDcard11.SelectAll();
        }

        private void txtIDcard11_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtIDcard11.Text == "") return;
            txtIDcard12.Focus();
            txtIDcard12.SelectAll();
        }

        private void txtIDcard12_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtIDcard12.Text == "") return;
            txtIDcard13.Focus();
            txtIDcard13.SelectAll();
        }

        private void txtMobile1_1_KeyUp(object sender, KeyEventArgs e)
        {
           // if (txtMobile1_1.Text == "") return;
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
            }
            else
            {   
                txtMobile1_2.Focus();
                txtMobile1_2.SelectAll();
                
            }
         
        }

        private void txtMobile1_2_KeyUp(object sender, KeyEventArgs e)
        {
           // if (txtMobile1_2.Text == "") return;
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                txtMobile1_1.Focus();
            }
            else
            {
                txtMobile1_3.Focus();
                txtMobile1_3.SelectAll();
            }
        
        }

        private void txtMobile1_3_KeyUp(object sender, KeyEventArgs e)
        {
          //  if (txtMobile1_3.Text == "") return;

            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                txtMobile1_2.Focus();
            }
            else
            {
                txtMobile1_4.Focus();
                txtMobile1_4.SelectAll();
            }
        }

        private void txtMobile1_4_KeyUp(object sender, KeyEventArgs e)
        {
            //if (txtMobile1_4.Text == "") return;

            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                txtMobile1_3.Focus();
            }
            else
            {
                txtMobile1_5.Focus();
                txtMobile1_5.SelectAll();
            }
        }

        private void txtMobile1_5_KeyUp(object sender, KeyEventArgs e)
        {
          //  if (txtMobile1_5.Text == "") return;

            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                txtMobile1_4.Focus();
            }
            else
            {
                txtMobile1_6.Focus();
                txtMobile1_6.SelectAll();
            }
        }

        private void txtMobile1_6_KeyUp(object sender, KeyEventArgs e)
        {
            //if (txtMobile1_6.Text == "") return;

            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                txtMobile1_5.Focus();
            }
            else
            {
                txtMobile1_7.Focus();
                txtMobile1_7.SelectAll();
            }
        }

        private void txtMobile1_7_KeyUp(object sender, KeyEventArgs e)
        {
           // if (txtMobile1_7.Text == "") return;

            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                txtMobile1_6.Focus();
            }
            else
            {
                txtMobile1_8.Focus();
                txtMobile1_8.SelectAll();
            }
        }

        private void txtMobile1_8_KeyUp(object sender, KeyEventArgs e)
        {
           // if (txtMobile1_8.Text == "") return;

            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                txtMobile1_7.Focus();
            }
            else
            {
                txtMobile1_9.Focus();
                txtMobile1_9.SelectAll();
            }
        }

        private void txtMobile1_9_KeyUp(object sender, KeyEventArgs e)
        {
            //if (txtMobile1_9.Text == "") return;

            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                txtMobile1_8.Focus();
            }
            else
            {
                txtMobile1_10.Focus();
                txtMobile1_10.SelectAll();
            }
        }
        private void txtMobile1_10_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                txtMobile1_9.Focus();
            }
            else
            {
         
            }
        }

 

        private void txtMobile2_1_KeyUp(object sender, KeyEventArgs e)
        {
            //if (txtMobile2_1.Text == "") return;

            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                
            }
            else
            {
                txtMobile2_2.Focus();
                txtMobile2_2.SelectAll();
            }
        }

        private void txtMobile2_2_KeyUp(object sender, KeyEventArgs e)
        {
            //if (txtMobile2_2.Text == "") return;

            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                txtMobile2_1.Focus();
            }
            else
            {
                txtMobile2_3.Focus();
                txtMobile2_3.SelectAll();
            }
        }

        private void txtMobile2_3_KeyUp(object sender, KeyEventArgs e)
        {
            //if (txtMobile2_3.Text == "") return;

            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                txtMobile2_2.Focus();
            }
            else
            {
                txtMobile2_4.Focus();
                txtMobile2_4.SelectAll();
            }
        }

        private void txtMobile2_4_KeyUp(object sender, KeyEventArgs e)
        {
            //if (txtMobile2_4.Text == "") return;

            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                txtMobile2_3.Focus();
            }
            else
            {
                txtMobile2_5.Focus();
                txtMobile2_5.SelectAll();
            }
        }

        private void txtMobile2_5_KeyUp(object sender, KeyEventArgs e)
        {
            //if (txtMobile2_5.Text == "") return;

            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                txtMobile2_4.Focus();
            }
            else
            {
                txtMobile2_6.Focus();
                txtMobile2_6.SelectAll();
            }
        }

        private void txtMobile2_6_KeyUp(object sender, KeyEventArgs e)
        {
            //if (txtMobile2_6.Text == "") return;

            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                txtMobile2_5.Focus();
            }
            else
            {
                txtMobile2_7.Focus();
                txtMobile2_7.SelectAll();
            }
        }

        private void txtMobile2_7_KeyUp(object sender, KeyEventArgs e)
        {
            //if (txtMobile2_7.Text == "") return;

            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                txtMobile2_6.Focus();
            }
            else
            {
                txtMobile2_8.Focus();
                txtMobile2_8.SelectAll();
            }
        }

        private void txtMobile2_8_KeyUp(object sender, KeyEventArgs e)
        {
            //if (txtMobile2_8.Text == "") return;

            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                txtMobile2_7.Focus();
            }
            else
            {
                txtMobile2_9.Focus();
                txtMobile2_9.SelectAll();
            }
        }

        private void txtMobile2_9_KeyUp(object sender, KeyEventArgs e)
        {
            //if (txtMobile2_9.Text == "") return;

            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                txtMobile2_8.Focus();
            }
            else
            {
                txtMobile2_10.Focus();
                txtMobile2_10.SelectAll();
            }
        }
        private void txtMobile2_10_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                txtMobile2_9.Focus();
            }
            else
            {
                txtTel1_1.Focus();
                txtTel1_1.SelectAll();
            }
        }
        private void txtTel1_1_KeyUp(object sender, KeyEventArgs e)
        {
            //if (txtTel1_1.Text == "") return;
            //if (txtTel1_1.Text.Length >=2) return;
            //txtTel1_2.Focus();
            //txtTel1_2.SelectAll();
        }


        private void BindCboBran_PersonnelType()
        {
            try
            {
                var dsPersonnelType = new Business.Personnel().SelectBranch_PersonnelType();
                var drPersonnelType = dsPersonnelType.Tables[0].NewRow();
                drPersonnelType["PersonnelType_code"] = "";
                drPersonnelType["PersonnelType_name"] = Statics.StrValidate;
                dsPersonnelType.Tables[0].Rows.InsertAt(drPersonnelType, 0);
                cboPersonnelType.Items.Clear();
                cboPersonnelType.BeginUpdate();
                cboPersonnelType.DataSource = dsPersonnelType.Tables[0];
                cboPersonnelType.ValueMember = "PersonnelType_code";
                cboPersonnelType.DisplayMember = "PersonnelType_name";

                cboPersonnelType.EndUpdate();
                cboBranch.DataSource = dsPersonnelType.Tables[1];
                cboBranch.ValueMember = "BranchID";
                cboBranch.DisplayMember = "BranchName";


            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }
        }

        private void BindCboPersonnelGroup()
        {
            try
            {
                var dsGroup = new Business.Personnel().SelectPersonnelGroup();
                var drGroup = dsGroup.Tables[0].NewRow();
                drGroup["GroupCode"] = "";
                drGroup["GroupName"] = Statics.StrValidate;
                dsGroup.Tables[0].Rows.InsertAt(drGroup, 0);
                cboGroup.Items.Clear();
                cboGroup.BeginUpdate();
                cboGroup.DataSource = dsGroup.Tables[0];
                cboGroup.ValueMember = "GroupCode";
                cboGroup.DisplayMember = "GroupName";

                cboGroup.EndUpdate();

            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation,
                               "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }
        }

        private void BindCboPrefix()
        {
            try
            {
                 dsPrefix = new Business.Prefix().SelectPrefixAll();
                dtPrefix = dsPrefix.Tables[0];
                //var drPrefix = dtPrefix.NewRow();
                //drPrefix["PrefixCode"] = "0";
                //drPrefix["PrefixName"] = Statics.StrValidate;
                //dtPrefix.Rows.InsertAt(drPrefix, 0);

                //cboPrefix.BeginUpdate();
                //cboPrefix.DataSource = dtPrefix;
                //cboPrefix.ValueMember = "PrefixCode";
                //cboPrefix.DisplayMember = "PrefixName";
                //cboPrefix.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //cboPrefix.AutoCompleteSource = AutoCompleteSource.ListItems;
                //cboPrefix.EndUpdate();

                colValues = new AutoCompleteStringCollection();
                foreach (DataRow dr in dtPrefix.Rows)
                {
                    colValues.Add(dr["PrefixName"]+"");
                    //if (dicPrefix.ContainsKey(dr["PrefixName"]+""))continue;
                    //    dicPrefix.Add(dr["PrefixName"]+"", dr["PrefixCode"]+"");
                }
                //txtPrefix.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //txtPrefix.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtPrefix.AutoCompleteCustomSource = colValues;

            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation,
                               "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }
        }
        
        private void BindCboProvince()
        {
            try
            {
                this.Invoke(new MethodInvoker(delegate
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
                    if (!dicProvince.ContainsKey(dr["PROVINCE_NAME"]+"".Trim())) dicProvince.Add(dr["PROVINCE_NAME"]+"".Trim(), dr["PROVINCE_CODE"]+"".Trim());
                    colValues.Add(dr["PROVINCE_NAME"]+"".Trim());
                }
                //txtProvince.AutoCompleteMode = AutoCompleteMode.Suggest;
                //txtProvince.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtProvince.AutoCompleteCustomSource = colValues;
                }));


            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation,
                               "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }
        }
        private void doAutoCompleteListExample( Dictionary<string,string>dic,DataTable dataTable )
        {
            
            foreach (DataRow dr in dtProvince.Rows)
            {
                dicProvince.Add(dr["PROVINCE_NAME"]+"", dr["PROVINCE_CODE"]+"");
                colValues.Add(dr["PROVINCE_NAME"]+"");
            } 
        }
        private void BindCboDistrict(string provinceCode)
        {
            try
            {
               // txtDistrict.Text = "";
                if (!string.IsNullOrEmpty(provinceCode))
                {
                     this.Invoke(new MethodInvoker(delegate
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
                        colValues.Add(dr["District_NAME"]+"".Trim());
                        if (dicDistrict.ContainsKey(dr["District_NAME"]+"".Trim())) continue;
                        dicDistrict.Add(dr["District_NAME"]+"".Trim(), dr["District_code"]+"".Trim());
                        
                    }
                
               
                    txtDistrict.AutoCompleteCustomSource = colValues;
            }));
                }
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation,
                               "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }
        }

        private void BindCboSubDistrict(string district_code)
        {
            try
            {
                //txtSubDistrict.Text = "";
                if (!string.IsNullOrEmpty(district_code) && district_code != "-1")
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                    //DataView view = new DataView(dtAdministrative);
                    //dtSubDistrict = view.ToTable(true, "SUBDistrict_CODE", "SUBDistrict_NAME", "District_CODE");
                    string sql = "District_CODE=" + district_code;
                    if (!dtAdministrative.Select(sql).Any()) return;
                    dtSubDistrict = dtAdministrative.Select(sql).CopyToDataTable();
                    //MessageBox.Show(dtSubDistrict.Rows.Count+"");
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
                    colValues=new AutoCompleteStringCollection();
                    foreach (DataRow dr in dtSubDistrict.Rows)
                    {
                        colValues.Add(dr["SubDistrict_NAME"]+"".Trim());
                        if (dicSubDistrict.ContainsKey(dr["SubDistrict_NAME"]+"".Trim())) continue;
                        dicSubDistrict.Add(dr["SubDistrict_NAME"]+"".Trim(), dr["SubDistrict_CODE"]+"".Trim());
                       
                    }
                    //txtSubDistrict.AutoCompleteMode = AutoCompleteMode.Suggest;
                    //txtSubDistrict.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtSubDistrict.AutoCompleteCustomSource = colValues;

                     }));
                }
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError,
                               "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }
        }

        private void BindTxtPostCode(string Subdistrict_code)
        {
            try
            {
                //txtPostCode.Text = "";
                if (!string.IsNullOrEmpty(Subdistrict_code) && Subdistrict_code != "-1")
                {
                      this.Invoke(new MethodInvoker(delegate
                    {
                   // MessageBox.Show(Subdistrict_code);
                    //var dsPostCode = new Business.PostCode().SelectPostCodeAll();
                    //AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
                    if (dtZipcode.Select("Subdistrict_code=" + Subdistrict_code).Any())
                    {
                        txtPostCode.Text =dtZipcode.Select("Subdistrict_code=" + Subdistrict_code)[0]["zipcode"]+"";
                        DerUtility.SendKey(Convert.ToChar(13));
                    }
                    }));
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
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError,
                               "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }

        }

      
        //private void cboSubDistrict_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        //{
        //    if (e.KeyCode != Keys.Enter && e.KeyCode != Keys.Tab) return;
        //    txtPostCode.Focus();
        //    txtPostCode.Text = "";
        //}

       private void FrmPersonnelSetting_Load_1(object sender, EventArgs e)
        {
            try
            {
                SetStartControls();
                pn = new Personnel();
                pn.EN = EN;

                //this.tabControl1.Appearance = TabAppearance.FlatButtons;
                //this.tabControl1.ItemSize = new Size(0, 1);
                //this.tabControl1.SizeMode = TabSizeMode.Fixed;
                //this.tabControl1.HotTrack = true;
                BindCboBranch();
                cboGroup.SelectedIndex = 0;
                cboPersonnelType.SelectedIndex = 0;
                if (pn != null && !string.IsNullOrEmpty(pn.EN)) //open
                {
                    FormType = DerUtility.AccessType.Update;
                    pn.QueryType = "SELECT";

                    var dsPersonnel = new Business.Personnel().SearchPersonnelByID(ref pn);
                    if (dsPersonnel != null && dsPersonnel.Tables.Count > 0)
                    {
                        DataTable dt = dsPersonnel.Tables[0];
                        cboBranch.SelectedValue = dt.Rows[0]["BranchID"]+"";
                        txtAddress.Text = dt.Rows[0]["AddressId"]+"";
                        //pn.Age =  txtAge.Text;
                        txtBuilding.Text = dt.Rows[0]["Building"]+"";
                        if (dt.Rows[0]["DateBirth"] + "" != "")
                        {
                            dtpBirtDate.Value = (DateTime)dt.Rows[0]["DateBirth"];
                        }
                        if (dt.Rows[0]["DateEndW"] + "" != "")
                        dateEndW.Value = Convert.ToDateTime(dt.Rows[0]["DateEndW"]+"");
                        if (dt.Rows[0]["DateRegister"] + "" != "")
                        dtpDateReg.Value = Convert.ToDateTime(dt.Rows[0]["DateRegister"]+"");
                        if (dt.Rows[0]["DateStartW"] + "" != "")
                        dateStartW.Value = Convert.ToDateTime(dt.Rows[0]["DateStartW"]+"");
                        //cboProvince.SelectedValue = dt.Rows[0]["ProvinceCode"]+"";
                   
                        txtFristName.Text = dt.Rows[0]["EFirstname"]+"";
                        txtLastName.Text = dt.Rows[0]["ELastname"]+"";
                        txtMiddleName.Text = dt.Rows[0]["EMiddlename"]+"";
                        txtEN.Text = dt.Rows[0]["EN"]+"";
                        txtNickNameE.Text = dt.Rows[0]["ENickname"]+"";
                        txtEmail.Text = dt.Rows[0]["E_mail"]+"";

                        checkBoxActive.Checked = dt.Rows[0]["Active"] + ""=="Y";

                        if (dt.Rows[0]["Gender"]+"" == "M")
                            rdoMale.Checked = true;
                        if (dt.Rows[0]["Gender"]+"" == "W")
                            rdoFemale.Checked = true;
                        txtHeight.Text = dt.Rows[0]["Height"]+"";
                        var idcard = new List<char>();
                        idcard = (dt.Rows[0]["IdCard"]+"").ToList();
                        if (idcard.Count == 13)
                        {
                            txtIDcard1.Text = idcard[0]+"";
                            txtIDcard2.Text = idcard[1]+"";
                            txtIDcard3.Text = idcard[2]+"";
                            txtIDcard4.Text = idcard[3]+"";
                            txtIDcard5.Text = idcard[4]+"";
                            txtIDcard6.Text = idcard[5]+"";
                            txtIDcard7.Text = idcard[6]+"";
                            txtIDcard8.Text = idcard[7]+"";
                            txtIDcard9.Text = idcard[8]+"";
                            txtIDcard10.Text = idcard[9]+"";
                            txtIDcard11.Text = idcard[10]+"";
                            txtIDcard12.Text = idcard[11]+"";
                            txtIDcard13.Text = idcard[12]+"";
                        }
                        var mb = new List<char>();
                        mb = (dt.Rows[0]["Mobile1"]+"").ToList();
                        if (mb.Count == 10)
                        {
                            txtMobile1_1.Text = mb[0]+"";
                            txtMobile1_2.Text = mb[1]+"";
                            txtMobile1_3.Text = mb[2]+"";
                            txtMobile1_4.Text = mb[3]+"";
                            txtMobile1_5.Text = mb[4]+"";
                            txtMobile1_6.Text = mb[5]+"";
                            txtMobile1_7.Text = mb[6]+"";
                            txtMobile1_8.Text = mb[7]+"";
                            txtMobile1_9.Text = mb[8]+"";
                            txtMobile1_10.Text = mb[9]+"";

                        }
                        mb = (dt.Rows[0]["Mobile2"]+"").ToList();
                        if (mb.Count == 10)
                        {
                            txtMobile2_1.Text = mb[0]+"";
                            txtMobile2_2.Text = mb[1]+"";
                            txtMobile2_3.Text = mb[2]+"";
                            txtMobile2_4.Text = mb[3]+"";
                            txtMobile2_5.Text = mb[4]+"";
                            txtMobile2_6.Text = mb[5]+"";
                            txtMobile2_7.Text = mb[6]+"";
                            txtMobile2_8.Text = mb[7]+"";
                            txtMobile2_9.Text = mb[8]+"";
                            txtMobile2_10.Text = mb[9]+"";

                        }
                        //var mb = dt.Rows[0]["Mobile1"]+"".Split('-');
                        //if (mb.Length == 2)
                        //{
                        //    txtMobile1_1.Text = mb[0];
                        //    txtMobile1_2.Text = mb[1];
                        //}
                        //mb = dt.Rows[0]["Mobile2"]+"".Split('-');
                        //if (mb.Length == 2)
                        //{
                        //    txtMobile2_1.Text = mb[0];
                        //    txtMobile2_2.Text = mb[1];
                        //}

                        txtNationality.Text = dt.Rows[0]["Nationality"]+"";
                        txtPassport.Text = dt.Rows[0]["PassportId"]+"";
                        if (dt.Rows[0]["Passwords"]+"" != "")
                        {
                            txtPass1.Text = dt.Rows[0]["Passwords"] + "";// EncryptDecrypText.decryptPassword(dt.Rows[0]["Passwords"] + "");
                            txtPass2.Text = dt.Rows[0]["Passwords"] + "";// EncryptDecrypText.decryptPassword(dt.Rows[0]["Passwords"] + "");
                        }
                        cboPersonnelType.SelectedValue = dt.Rows[0]["PersonnelType"]+"";
                        txtPostCode.Text = dt.Rows[0]["PostCode"]+"";
                       // if (dicPrefix.ContainsValue(dt.Rows[0]["PrefixCode"]+"".Trim()))
                        txtPrefix.Text = dt.Rows[0]["PrefixCode"]+"";//dicPrefix.Where(p => p.Value == dt.Rows[0]["PrefixCode"]+"".Trim()).Select(p => p.Key).FirstOrDefault();
                        if (dicProvince.ContainsValue(dt.Rows[0]["ProvinceCode"] + ""))
                        {
                            txtProvince.Text =
                                dicProvince.Where(p => p.Value == dt.Rows[0]["ProvinceCode"] + "").Select(p => p.Key).
                                    FirstOrDefault(); // dtCust.Rows[0]["ProvinceCode"] + "").Key; 
                            BindCboDistrict(dicProvince[txtProvince.Text.Trim()]);
                        }
                        else
                        {
                            txtProvince.Text = dt.Rows[0]["ProvinceCode"] + "";
                        }
                        if (dicDistrict.ContainsValue(dt.Rows[0]["DistrictCode"] + ""))
                        {
                            txtDistrict.Text =
                                dicDistrict.Where(p => p.Value == dt.Rows[0]["DistrictCode"] + "").Select(p => p.Key).
                                    FirstOrDefault();
                            BindCboSubDistrict(dicDistrict[txtDistrict.Text.Trim()]);
                        }
                        else
                        {
                            txtDistrict.Text = dt.Rows[0]["DistrictCode"] + "";
                        }
                        if (dicSubDistrict.ContainsValue(dt.Rows[0]["Sub_DistrictCode"] + ""))
                        {
                            BindCboSubDistrict(dicDistrict[txtDistrict.Text.Trim()]);
                            txtSubDistrict.Text =
                                dicSubDistrict.Where(p => p.Value == dt.Rows[0]["Sub_DistrictCode"] + "").Select(p => p.Key).
                                    FirstOrDefault();
                            
                        }
                        else
                        {
                            txtSubDistrict.Text = dt.Rows[0]["Sub_DistrictCode"] + "";
                        }
                        txtRace.Text = dt.Rows[0]["Race"]+"";
                        txtRoad.Text = dt.Rows[0]["Road"]+"";
                        txtSoi.Text = dt.Rows[0]["Soi"]+"";
                       
                        txtTName.Text = dt.Rows[0]["TName"]+"";
                        txtNickName.Text = dt.Rows[0]["TNickname"]+"";
                        txtTSurName.Text = dt.Rows[0]["TSurname"]+"";
                        txtLastName.Text = dt.Rows[0]["ELastname"]+"";
                        var tel = (dt.Rows[0]["Telephone1"]+"").Split('-');
                        if (tel.Length == 2)
                        {
                            txtTel1_1.Text = tel[0];
                            txtTel1_2.Text = tel[1];
                        }
                        cboGroup.SelectedValue = dt.Rows[0]["UserGroup"]+"";
                        txtUsername.Text =oldUsername= dt.Rows[0]["Username"]+"";

                        txtWeight.Text = dt.Rows[0]["Weights"]+"";

                        string BranchPrint = dt.Rows[0]["BranchAuth"] + "";

                        for (int i = 0; i < checkedListBoxSecurity.Items.Count; i++)
                        {

                            DataRowView castedItem = checkedListBoxSecurity.Items[i] as DataRowView;
                            string bitem = castedItem["BranchID"] + "";
                            if (BranchPrint.Contains(bitem))
                                checkedListBoxSecurity.SetItemChecked(i, true);
                        }
                        
                        try
                        {
                            _imagetPath = string.Format(@"{0}\Personnels\{1}\{2}.jpg", Application.StartupPath, txtEN.Text, txtEN.Text);
                          
                                DownLoadImage();

                            picPersonnelImage.SizeMode = PictureBoxSizeMode.StretchImage;
                            var callback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                            FileInfo f = new FileInfo(_imagetPath);
                            if (!f.Exists || f.Length==0) return;
                            picPersonnelImage.Image = Image.FromFile(_imagetPath).GetThumbnailImage(200, 300, callback, IntPtr.Zero);
                        }
                        catch (Exception)
                        {
                            
                           
                        }
                            

                        //}
                    }
                    string username = oldUsername;
                    if (Entity.Userinfo.UserGroup == "1")
                    {
                        cboGroup.Visible = true;
                        label30.Visible = true;
                    }
                    else
                    {
                        cboGroup.Visible = false;
                        label30.Visible = false;
                    }
                }
                else //new
                {
                    var idMax = UtilityBackEnd.GenMaxSeqnoValues("ENL");
                    txtEN.Text = idMax;
                    FormType = DerUtility.AccessType.Insert;
                }
                if (FormType == DerUtility.AccessType.DisplayOnly)
                {
                    SetEnabledFalse();
                }
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation,
                               "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }

        }
       private void DownLoadImage()
       {
           try
           {
               string Remote_imagetPath =string.Format( @"\Personnels\{0}\{1}.jpg",txtEN.Text,txtEN.Text);
               string remoteMainFolder = string.Format(@"Personnels\{0}\",txtEN.Text);
               _imagetPath = string.Format(@"{0}\Personnels\{1}\{2}.jpg", Application.StartupPath, txtEN.Text, txtEN.Text);
               // ftp.upload(Remote_imagetPath,imagepath);
               /* Create Object Instance */
               DermasterFtp ftpClient = new DermasterFtp(Entity.Userinfo.Server, Entity.Userinfo.ServerUser, Entity.Userinfo.ServerPass);
               if (ftpClient.directoryListSimple(remoteMainFolder).Length <= 0)
                   ftpClient.createDirectory(remoteMainFolder);
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
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
       }
       private void SaveImage()
       {
           try
           {
               if (_imagetPath == "") return;
               FileInfo f = new FileInfo(_imagetPath);
               if (!f.Exists || f.Length == 0) return;

               string Remote_imagetPath = "";
               Remote_imagetPath = string.Format(@"\Personnels\{0}\{1}.jpg", txtEN.Text, txtEN.Text);
               string remoteMainFolder = @"\Personnels\" + txtEN.Text;
               /* Create Object Instance */
               DermasterFtp ftpClient = new DermasterFtp(Entity.Userinfo.Server, Entity.Userinfo.ServerUser, Entity.Userinfo.ServerPass);
               if (ftpClient.directoryListSimple(remoteMainFolder).Length <= 1)
                   ftpClient.createDirectory(remoteMainFolder);
               /* Upload a File */
               ftpClient.upload(Remote_imagetPath, _imagetPath);
               //FileInfo f = new FileInfo(_imagetPath);
               //if (!f.Exists)
               /* Download a File */
               DownLoadImage();

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
                    //odlgImage.FileName = null;
                }
            }
        }

        private string calulateAge(string dateDOB)
        {
            int now = int.Parse(DateTime.Today.ToString("yyyyMMdd"));
            int dob = int.Parse(dateDOB);
            string dif = (now - dob)+"";
            string age = "0";
            if (dif.Length > 4)
                age = dif.Substring(0, dif.Length - 4);
            return age;
        }

        private void pictureBoxSave_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBoxSave, "บันทึก");
            pictureBoxSave.Location = new Point(pictureBoxSave.Location.X - 2, pictureBoxSave.Location.Y - 2);
        }

        private void pictureBoxCancel_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBoxCancel, "ปิด");
            //pictureBoxCancel.Location=new Point(pictureBoxCancel.Location.X-2,pictureBoxCancel.Location.Y-2);
        }

        private void pictureBoxSave_MouseLeave(object sender, EventArgs e)
        {
        }

        private void pictureBoxCancel_MouseLeave(object sender, EventArgs e)
        {

        }

        private void pictureBoxSave_Click(object sender, EventArgs e)
        {
            SavePersonnels();
        }
        private void BindCboBranch()
        {
            try
            {
                DataTable dtBranch = new Business.Branch().SelectBranchAll().Tables[0];
                cboBranch.DataSource = dtBranch;
                cboBranch.ValueMember = "BranchID";
                cboBranch.DisplayMember = "BranchName";

                checkedListBoxSecurity.DataSource = dtBranch.Copy();
                checkedListBoxSecurity.DisplayMember = "BranchName";
                checkedListBoxSecurity.ValueMember = "BranchID";
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation,
                               "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }
        }
        private void SavePersonnels()
        {
            try
            {
                pn = new Personnel();
                pn.AddressId = txtAddress.Text;
                //pn.Age =  txtAge.Text;
                pn.Building = txtBuilding.Text;
                pn.CreateBy = Entity.Userinfo.EN;
                pn.CreateDate = DateTime.Now;
                if (dtpBirtDate.Checked)
                    pn.DateBirth = dtpBirtDate.Value;//dtpBirtDate.DateTime.Date;
                if (dateEndW.Checked)
                    pn.DateEndW = dateEndW.Value;
                pn.DateRegister = dtpDateReg.Value;
                if (dateStartW.Checked)
                    pn.DateStartW = dateStartW.Value;
                //if (txtDistrict.Text!="")
                //    pn.District = dicDistrict[txtDistrict.Text.Trim()];//cboDistrict.SelectedValue == null ? "" : cboDistrict.SelectedValue+"";
                pn.District = (dicDistrict.ContainsKey(txtDistrict.Text.Trim()))
                             ? dicDistrict[txtDistrict.Text.Trim()]
                             : txtDistrict.Text.Trim();
                pn.EFirstname = txtFristName.Text;
                pn.ELastname = txtLastName.Text;
                pn.EMiddlename = txtMiddleName.Text;
                pn.EN = txtEN.Text;
                pn.ENickname = txtNickNameE.Text;
                pn.E_mail = txtEmail.Text;
                pn.Gender = rdoMale.Checked ? "M" : "W";
                pn.BranchID = cboBranch.SelectedValue+"";
                pn.Active = checkBoxActive.Checked ? "Y" : "N";
                int height;
                int.TryParse(txtHeight.Text, out height);
                pn.Height = height;
                pn.IdCard = txtIDcard1.Text + txtIDcard2.Text + txtIDcard3.Text + txtIDcard4.Text + txtIDcard5.Text +
                            txtIDcard6.Text + txtIDcard7.Text + txtIDcard8.Text + txtIDcard9.Text + txtIDcard10.Text +
                            txtIDcard11.Text + txtIDcard12.Text + txtIDcard13.Text;

                string mobile1 = txtMobile1_1.Text +
                                 txtMobile1_2.Text +
                                 txtMobile1_3.Text +
                                 txtMobile1_4.Text +
                                 txtMobile1_5.Text +
                                 txtMobile1_6.Text +
                                 txtMobile1_7.Text +
                                 txtMobile1_8.Text +
                                 txtMobile1_9.Text +
                                 txtMobile1_10.Text;
                if (mobile1.Length > 0 && mobile1.Length != 10)
                {
                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError,
                                   "กรุณาระบุ \" Mobile (เบอร์มือถือ)  1 \" ให้ถูกต้อง ก่อนทำการบันทึกข้อมูล");
                    txtMobile1_1.Focus();
                    return;
                }
                string mobile2 = txtMobile2_1.Text + txtMobile2_2.Text + txtMobile2_3.Text + txtMobile2_4.Text +
                                 txtMobile2_5.Text + txtMobile2_6.Text + txtMobile2_7.Text + txtMobile2_8.Text +
                                 txtMobile2_9.Text + txtMobile2_10.Text;
                if (mobile2.Length > 0 && mobile2.Length != 10)
                {
                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError,
                                   "กรุณาระบุ \" Mobile (เบอร์มือถือ)  2 \" ให้ถูกต้อง ก่อนทำการบันทึกข้อมูล");
                    txtMobile2_1.Focus();
                    return;
                }
                pn.Mobile1 = mobile1; //txtMobile1_1.Text.Trim() + "-" + txtMobile1_2.Text.Trim();
                pn.Mobile2 = mobile2; // txtMobile2_1.Text.Trim() + "-" + txtMobile2_2.Text.Trim();
                pn.Nationality = txtNationality.Text;
                pn.PassportId = txtPassport.Text;
                if (txtPass1.Text.Equals(txtPass2.Text))
                    pn.Passwords = txtPass2.Text;// EncryptDecrypText.encryptPassword(txtPass2.Text);

                pn.PersonnelType = cboPersonnelType.SelectedValue == null
                                       ? ""
                                       : cboPersonnelType.SelectedValue+"";
                pn.PostCode = txtPostCode.Text;
                //int prefix;
                //if (txtPrefix.Text != "")
                pn.PrefixCode = txtPrefix.Text.Trim();// dicPrefix[txtPrefix.Text.Trim()];
                //if (txtProvince.Text != "")
                //pn.Province = dicProvince[txtProvince.Text.Trim()]; //cboProvince.SelectedValue == null ? "" : cboProvince.SelectedValue+"";
                pn.Province = (dicProvince.ContainsKey(txtProvince.Text.Trim()))
                               ? dicProvince[txtProvince.Text.Trim()]
                               : txtProvince.Text.Trim();

                pn.Race = txtRace.Text;
                pn.Road = txtRoad.Text;
                pn.Soi = txtSoi.Text;
                //if (txtSubDistrict.Text != "")
                //    pn.Sub_district = dicSubDistrict[txtSubDistrict.Text.Trim()];//cboSubDistrict.SelectedValue == null ? "" : cboSubDistrict.SelectedValue+"";
                pn.Sub_district = (dicSubDistrict.ContainsKey(txtSubDistrict.Text.Trim()))
               ? dicSubDistrict[txtSubDistrict.Text]
               : txtSubDistrict.Text.Trim();
                pn.TName = txtTName.Text;
                pn.TNickname = txtNickName.Text;
                pn.TSurname = txtTSurName.Text;
                pn.Telephone1 = txtTel1_1.Text.Trim() + "-" + txtTel1_2.Text.Trim();
                pn.Telephone2 = ""; // txtTel1_1.Text.Trim() + "-" + txtTel1_2.Text.Trim();
                pn.UpdateBy = Entity.Userinfo.EN;
                pn.UpdateDate = DateTime.Now;
                pn.UserGroup = cboGroup.SelectedValue == null ? "" : cboGroup.SelectedValue+"";
                pn.Username = txtUsername.Text;
                int weights;
                int.TryParse(txtWeight.Text.Trim(), out weights);
                pn.Weights = weights;

                string BranchAuth = "";
                foreach (var itemChecked in checkedListBoxSecurity.CheckedItems)
                {
                    DataRowView castedItem = itemChecked as DataRowView;
                    BranchAuth += castedItem["BranchID"] + ",";
                }
                pn.BranchAuth = BranchAuth;


                if (Path.GetFileName(_imagetPath) != null && Path.GetFileName(_imagetPath) != "")
                {
                    pn.ImageFilename = pn.EN + @".jpg";
                    pn.ImagePath = _imagetPath;
                }

                if (pn.EN == null && pn.EN == "")
                {
                    MessageBox.Show("โปรดระบุ รหัสประจำตัวพนักงาน \"Require EMP Code.\"");
                    return;
                }
                if (string.IsNullOrEmpty(pn.PersonnelType))
                {
                    MessageBox.Show("โปรดระบุ ตำแหน่ง\"Require Position.\"");
                    return;
                }
                if (string.IsNullOrEmpty(pn.TName) && string.IsNullOrEmpty(pn.EFirstname))
                {
                    MessageBox.Show("โปรดระบุ ชื่อ\"Require Name.\"");
                    return;
                }
                if (string.IsNullOrEmpty(pn.TSurname) && string.IsNullOrEmpty(pn.ELastname))
                {
                    MessageBox.Show("โปรดระบุ นามสกุล \"Require Surname.\"");
                    return;
                }
                if (string.IsNullOrEmpty(pn.Mobile1))
                {
                    MessageBox.Show("โปรดระบุ เบอร์มือถือ\"Require Mobile.\"");
                    return;
                }
                if (txtEmail.Text.Trim() != "")
                {
                    if (IsValidEmailAddress(txtEmail.Text.Trim()) == false)
                    {
                        DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, "กรุณาระบุ \" รูปแบบ Email  \"\"Require Email.\"");
                        txtEmail.Focus();
                        return ;
                    }
                }



                if (string.IsNullOrEmpty(pn.Province))
                {
                    MessageBox.Show("โปรดระบุ จังหวัด\"Require Province.\"");
                    return;
                }
                if (string.IsNullOrEmpty(pn.District))
                {
                    MessageBox.Show("โปรดระบุ อำเภอ \"Require District.\"");
                    return;
                }
                if (string.IsNullOrEmpty(pn.Sub_district))
                {
                    MessageBox.Show("โปรดระบุ ตำบล \"Require Sub District.\"");
                    return;
                }
                if (string.IsNullOrEmpty(pn.PostCode))
                {
                    MessageBox.Show("โปรดระบุ รหัสไปรษณีย์ \"Require Postcode.\"");
                    return;
                }
                if (string.IsNullOrEmpty(pn.IdCard) && string.IsNullOrEmpty(pn.PassportId))
                {
                    MessageBox.Show("โปรดระบุ เลขบัตรประชาชน หรือ Passport ID \"Require Passport ID\"");
                        return;
                }
                else if((pn.IdCard.Length != 13) && (pn.PassportId.Length < 10))
                {
                    MessageBox.Show("โปรดระบุ เลขบัตรประชาชน หรือ Passport ID \"Require Passport ID\"");
                    return;
                }
             
                if (string.IsNullOrEmpty(pn.Username))
                {
                    MessageBox.Show("โปรดระบุ ชื่อผู้ใช้งานระบบ \"Require UserName\"");
                    return;
                }
                if (string.IsNullOrEmpty(pn.Passwords))
                {
                    MessageBox.Show("โปรดระบุ รหัสผ่าน/หรือยืนยันรหัสผ่านไม่ถูกต้อง \"Require Password.\"");
                    return;
                }
                //if (string.IsNullOrEmpty(pn.UserGroup))
                //{
                //    MessageBox.Show("โปรดระบุ ระดับผู้ใช้งาน \"Require Employee Level.\"");
                //    return;
                //}
                SaveImage();
                switch (FormType)
                {

                    case DerUtility.AccessType.Insert:

                        pn.QueryType = "INSERT";
                        intStatus = new Business.Personnel().InsertPersonnel(ref pn);
                        if (intStatus == 1)
                        {
                            //Statics.frmPersonnelList.BindDataPersonel(1);
                            DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, Statics.StrMsgInsertComplete);
                            //Statics.frmCustomerDetail.BindDataCustomer(1);
                            //if (_Changimage)
                            //    if (BrowseFile.Movefile(_imagetPath, "Personnels", pn.EN))
                            //    {

                            //    }
                            //    else
                            //    {
                            //        MessageBox.Show("Save Image Fail.");
                            //    }

                            if (Statics.frmPersonnelSetting != null)
                            {
                                Statics.frmPersonnelSetting.Close();
                            }
                            if (Statics.frmPersonnelSetting != null) Statics.frmPersonnelSetting.Dispose();
                        }
                        else
                        {
                            DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation,
                                           Statics.StrMsgCannotSave + " ข้อมูลผิดพลาด");
                        }
                        break;
                    case DerUtility.AccessType.Update:
                        pn.QueryType = "UPDATE";
                        intStatus = new Business.Personnel().InsertPersonnel(ref pn);
                        if (intStatus == 1)
                        {
                            //Statics.frmPersonnelList.BindDataPersonel(1);
                            //if (_Changimage)
                            //    if (BrowseFile.Movefile(_imagetPath, "Personnels", pn.EN))
                            //    {

                            //    }
                            //    else
                            //    {
                            //        MessageBox.Show("Save Image Fail.");
                            //    }
                            DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, Statics.StrMsgUpdateComplete);
                            Statics.frmPersonnelSetting.Close();
                        }
                        else
                        {
                            DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation,
                                           Statics.StrMsgCannotSave + " ข้อมูลผิดพลาด");
                        }
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bntSave_Click(object sender, EventArgs e)
        {
            SavePersonnels();
          
        }
       
        private void btnCamera_BtnClick()
        {
            FrmWebCapture webCapture = new FrmWebCapture(txtEN.Text.Trim(),false);
            if (webCapture.ShowDialog() == DialogResult.OK)
            {
                picPersonnelImage.ImageLocation = _imagetPath = webCapture.imagepath;// Entity.Userinfo.ImagePath + @"\PERSONNELS\" + webCapture.PicID + ".jpg";
     
                _Changimage = true;
            }
        }

        private void picBrown_MouseLeave(object sender, EventArgs e)
        {
            picBrown.Image = global::AryuwatSystem.Properties.Resources.Find;
        }

        private void picBrown_MouseHover(object sender, EventArgs e)
        {
            picBrown.Image = global::AryuwatSystem.Properties.Resources.FindOver;
        }

        private void picBrown_Click(object sender, EventArgs e)
        {
            
            string imgPath = BrowseFile.BrowFileType("IMAGE");
            if (imgPath != "")
            {
                picPersonnelImage.ImageLocation = _imagetPath = imgPath;
                _Changimage = true;
            }
        }

        private void textPass2_Leave(object sender, EventArgs e)
        {
            if (!txtPass1.Text.Equals(txtPass2.Text))
            {
                txtPass2.Focus();
                txtPass2.SelectAll();
                MessageBox.Show("ยืนยันรหัสผ่านไม่ถูกต้อง \"Password incorrent.\"");
                return;
            }

        }

        private void dtpBirtDate_ValueChanged(object sender, EventArgs e)
        {
           // if (dtpBirtDate.Value != null)
            if (dtpBirtDate.Checked)
            {
                DateTime myDate = dtpBirtDate.Value.Date; // DateTime(dateTimePicker1.Value);
                DateTime ToDate = DateTime.Now;

                DateDifference dDiff = new DateDifference(myDate, ToDate);
                txtAge.Text = dDiff+"";
            }
        }
        private void picPersonnelImage_Click(object sender, EventArgs e)
        {
            if(_imagetPath=="")return;
            var objForm = new popPreviewImage(_imagetPath, true);
            objForm.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPersonnelSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics.frmPersonnelSetting = null;
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
            bntSave.Visible = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearControl();
        }

        private void cboPrefix_TextChanged(object sender, EventArgs e)
        {
            //HandleTextChanged();
        }

       

        private void cboPrefix_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Back)
            //{
            //    int sStart = cboPrefix.SelectionStart;
            //    if (sStart > 0)
            //    {
            //        sStart--;
            //        cboPrefix.Text = sStart == 0 ? "" : cboPrefix.Text.Substring(0, sStart);
            //    }
            //    e.Handled = true;
            //}

        }

        private void cboPrefix_Leave(object sender, EventArgs e)
        {
          //  HandleTextChanged();
        //    var txt = cboPrefix.Text;
        //    var list = (from object VARIABLE in cboPrefix.Items
        //                where VARIABLE+"".StartsWith(cboPrefix.Text.ToUpper())
        //                select 1).ToList();
        //    if (list.Any())
        //    {

            //}
            //else
            //{
            //    List<string> levels = dsPrefix.Tables[0].AsEnumerable().Select(al => al.Field<string>("PrefixCode")).Distinct().ToList();
            //    int min = Convert.ToInt16(levels.Min());
            //    int max = Convert.ToInt16(levels.Max()) + 1;
            //    var item = new ComboBoxItem(txt, max+"");
            //    cboPrefix.BeginUpdate();
            //    cboPrefix.Items.Add(item);
            //    cboPrefix.EndUpdate();
            //}
        }
     
        private string oldUsername = "";
        private void txtUsername_Leave(object sender, EventArgs e)
        {
            try
            {
                if(FormType == DerUtility.AccessType.Insert || FormType == DerUtility.AccessType.Update)
                {
                    if(oldUsername.Equals(txtUsername.Text))return;
                    DataTable dt = new Business.Personnel().CheckUserPassId(txtUsername.Text).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("มีผู้ใช้งานอื่นใช้ ชื่อนี้แล้ว \"This User name is allready\"");
                        txtUsername.Focus();
                        txtUsername.Text = "";
                        txtUsername.SelectAll();
                        //return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtProvince_Leave(object sender, EventArgs e)
        {
            try
            {
               // txtDistrict.Text = "";
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

        private void FrmPersonnelSetting_Activated(object sender, EventArgs e)
        {
            Statics.SetToolbar(false, false, false, true, false);
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
        }
    }

    
