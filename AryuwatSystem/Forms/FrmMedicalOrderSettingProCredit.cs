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
using System.Globalization;


namespace AryuwatSystem.Forms
{
    public partial class FrmMedicalOrderSettingProCredit : DockContent, IForm
    {

        public FrmMedicalOrderSettingProCredit()
        {
            InitializeComponent();
        }

        public FrmMedicalOrderSettingProCredit(ref Entity.Customer info)
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
        List<string> LsSelectMS_Code = new List<string>();
        public string typeCustomer { get; set; }
        public string RefCN { get; set; }
        public string RefCN_Name { get; set; }
        public string customerType { get; set; }
        public string PriceRef { get; set; }
        public decimal SalePriceNew { get; set; }
        public decimal SumMS_Price { get; set; }
        public decimal SumDiscount { get; set; }
          
        private string vn = "";
        private string so = "";
        private string CN;
        
        private string docFilePath;
        List<DataGridViewRow> rowsToDelete=new List<DataGridViewRow>();
        //DataGridView dataGridToDelete=new DataGridView();
        public List<Entity.MedicalStuff> MedicalStuffs { get; set; }
        public List<Entity.MedicalOrderUseTrans> MedicalOrderUseTranss{ get; set; }
        public DerUtility.AccessType FormType { get; set; }
        public string RefVN { get; set; }
        public string SORef { get; set; }
        private Dictionary<string,List<Entity.MembersTrans>> dicMemberTran = new Dictionary<string,List<Entity.MembersTrans>> ();
        public string MS_Code="";
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
              string tabTypShortName = "";
              string moso = "SO-";
              string MOType = "";
             public string MO = "";
             public string PROCredit = "";
             public string PROCreditProductGroup = "";
             string MoSubType = "";
              string idMax = "";
              public string PRO_Code { get; set; }
              public string PRO_Name { get; set; }
              public decimal ProCreditMoney = 0;
              public decimal ProCreditRemain = 0;
              bool OverProCredit = false;
              private void showRef()
              {
                  if (this.SORef+"" != "")
                  {
                      this.txtSoRef.Visible = true;
                      this.txtBalanceRef.Visible = true;
                      this.labelref1.Visible = true;
                      this.lblBalanceRef.Visible = true;
                      this.lblRefVN.Visible = true;
                      this.txtSoRef.Text = this.SORef;
                      this.txtBalanceRef.Text = (this.ProCreditRemain==0) ? "0" : Convert.ToDecimal(this.ProCreditRemain).ToString("###,###,###.##");
                      this.txtCustomerName.Text = this.RefCN_Name;
                      this.labelCN.Text = RefCN;
                      lbPromotion.Text = string.Format("Promotion:{0}:{1}", PRO_Code, PRO_Name);
                      lbProCredit.Text = string.Format("ยอดเงินคงเหลือ/Credit ({0}/{1}) บาท/Bth.", (ProCreditRemain) == 0 ? "0" : (ProCreditRemain).ToString("###,###,###.##"), ProCreditMoney.ToString("###,###,###.##"));
                      lbProCredit.Visible = true;
                      radioPRO.Enabled = false;
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
                      tabControl.TabPages.Remove(tabAesthetic);
                      tabControl.TabPages.Remove(tabTreatment);
                      tabControl.TabPages.Remove(tabSurgery);
                      tabControl.TabPages.Remove(tabHair);
                      tabControl.TabPages.Remove(tabWellness_Antiaging);
                      tabControl.TabPages.Remove(tabPromotion);
                      tabControl.TabPages.Insert(0, enableTab);
                      tabControl.SelectedTab = enableTab;
                      //if (enableTab == null)
                      //{
                      //    tabControl.TabPages.Remove(tabAesthetic);
                      //    tabControl.TabPages.Remove(tabTreatment);
                      //    tabControl.TabPages.Remove(tabSurgery);
                      //    tabControl.TabPages.Remove(tabHair);
                      //    tabControl.TabPages.Remove(tabWellness_Antiaging);
                      //    tabControl.TabPages.Remove(tabPromotion);
                      //}
                      //else
                      //{
                      //    tabControl.TabPages.Remove(tabAesthetic);
                      //    tabControl.TabPages.Remove(tabTreatment);
                      //    tabControl.TabPages.Remove(tabSurgery);
                      //    tabControl.TabPages.Remove(tabHair);
                      //    tabControl.TabPages.Remove(tabWellness_Antiaging);
                      //    tabControl.TabPages.Remove(tabPromotion);
                      //    //tabControl.TabPages.Remove(tabPharmacy);
                      //    //tabControl.TabPages.Insert(tabAttachFile);
                      //    tabControl.TabPages.Insert(0, enableTab);
                      //    //tabControl.TabPages.Add(tabPharmacy);
                      //    //tabControl.TabPages.Add(tabAttachFile);
                      //    tabControl.TabPages.Remove(tabTreatment);
                      //    tabControl.TabPages.Remove(tabHair);
                      //    tabControl.SelectedTab = enableTab;
                      //}
                      
                  }
                  catch (Exception)
                  {
                      
                      throw;
                  }
              }
              private void FrmMedicalOrderSetting_Load(object sender, EventArgs e)
              {
                  try
                  {
                      System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
                          System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture;
                      labelCN.Text = "";
                      this.toolTip1.SetToolTip(this.pictureBoxRefreshProduct, "Update Product");
                      this.dataGridViewSelectList.CellEndEdit += new DataGridViewCellEventHandler(this.dataGridViewSelectList_CellEndEdit);
                      this.dataGridViewSelectList.CellMouseUp += new DataGridViewCellMouseEventHandler(this.dataGridViewSelectList_CellMouseUp);
                      this.dataGridViewSelectList.CellContentClick += new DataGridViewCellEventHandler(this.dataGridViewSelectList_CellContentClick);
                      this.dataGridViewSelectList.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(this.dataGridViewSelectList_EditingControlShowing);
                      this.dataGridViewSelectList.RowPostPaint += new DataGridViewRowPostPaintEventHandler(this.dataGridViewSelectList_RowPostPaint);
                      this.btnSave.Click += new EventHandler(this.btnSave_Click);
                      this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
                      this.showRef();
                      foreach (DataRow row in Userinfo.UnitName.Rows)
                      {
                          this.lsUnit.Add(row["UnitName"]+"");
                      }
                      this.SetColumnsDgv();
                   
                      this.BindCommission();
                      this.MedicalStuffs = new List<Entity.MedicalStuff>();
                      this.MedicalOrderUseTranss = new List<Entity.MedicalOrderUseTrans>();
                      dateTimePickerCreate.Format = DateTimePickerFormat.Custom;
                      dateTimePickerCreate.CustomFormat = "dd-MM-yyyy";
                      

                      this.BindDataAesList();
                      this.BindDataSurgeryList();
                      this.BindDataWellness_antiAgentList();
                      this.BindDataPharmacyList();
                      this.BindPromotionList();

                      if (FormType == DerUtility.AccessType.Update)
                      {
                          radioAE.Checked = false;
                          radioPRO.Checked = false;
                          radioWE.Checked = false;
                          radioSU.Checked = false;
                          string tab = "";
                          tab = MoSubType = vn == "" ? SO.Substring(3, 2) : vn.Substring(3, 2);
                        
                          switch (tab.ToUpper())
                          {
                              case "AE":
                                  //this.BindDataAesList();
                                  radioAE.Checked = true;
                                  DisableTab(tabAesthetic);
                                     radioAE.Enabled = false;
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
                                  MoSubType = "PRO";
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
                                  this.txtSONo.Text =  this.idMax.Replace("VNM", moso);
                                  this.idMax = this.idMax.Replace(moso, "").Replace("VNM", "");
                                  tabControl.TabPages.Remove(tabTreatment);
                                  tabControl.TabPages.Remove(tabHair);
                                  //this.BindDataHairList();
                                  this.BindDataAesList();
                                  //this.BindDataTreatmentList();
                                  this.BindDataSurgeryList();
                                  this.BindDataWellness_antiAgentList();
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
                         
                      }
                      else 
                      {
                          this.idMax = UtilityBackEnd.GenMaxSeqnoValues(moso);
                          this.txtSONo.Text =  this.idMax.Replace("VNM", moso);
                          this.idMax = this.idMax.Replace(moso, "").Replace("VNM", "");
                          //tabControl.TabPages.Remove(tabTreatment);
                          //tabControl.TabPages.Remove(tabHair);
                       
                          tabControl.TabPages.Remove(tabTreatment);
                          tabControl.TabPages.Remove(tabSurgery);
                          tabControl.TabPages.Remove(tabHair);
                          tabControl.TabPages.Remove(tabWellness_Antiaging);
                          tabControl.TabPages.Remove(tabPromotion);
                          //tabControl.TabPages.Remove(tabPharmacy);
                      }
                  }
                  catch (Exception exception)
                  {
                      MessageBox.Show(exception.Message);
                  }
              }

 

        //private void FrmMedicalOrderSetting_Load(object sender, EventArgs e)
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
                DataRow dr= dt.NewRow();
                dr["EN"] = "";
                dr["FullNameThai"] = "--ไม่ระบุ--";
                dt.Rows.InsertAt(dr,0);

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
            string tabname = tabControl.SelectedTab.Name;
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
            DataSet ds = new Business.MedicalOrder().SelectMedicalOrderById(vn,SO);
            DataTable dtMed = ds.Tables[0];
            DataTable dtSup = ds.Tables[1];
            DataTable dtStuff = ds.Tables[2];
            DataTable dtDoc = ds.Tables[3];
            DataTable dtMemTrans = ds.Tables[4];

            PRO_Code = dtMed.Rows[0]["Pro_Code"] + "";
            PRO_Name = dtMed.Rows[0]["Pro_Name"] + "";
            lbPromotion.Text = "";
            lbPromotion.Text = string.Format("Promotion:{0}:{1}",PRO_Code,PRO_Name);
            CN = dtMed.Rows[0]["CN"] + "";
            radioButtonMO.Checked = dtMed.Rows[0]["MOType"] + ""=="Y";
            radioButtonSO.Enabled = !radioButtonMO.Checked;
            MOType = dtMed.Rows[0]["MOType"] + "";
            this.RefVN = dtMed.Rows[0]["SOClose"]+"";
            this.PriceRef = (this.RefVN != "") ? (dtMed.Rows[0]["PriceTotalRef"]+"") : "";
            this.showRef();

            customerType = dtMed.Rows[0]["CustomerType"] + "";
            txtCustomerName.Text = dtMed.Rows[0]["FullNameThai"] + "" == "" ? dtMed.Rows[0]["FullNameEng"] + "" : dtMed.Rows[0]["FullNameThai"] + "";
            labelCN.Text = dtMed.Rows[0]["CN"] + "";
            txtAgenMemID.Text = dtMed.Rows[0]["AgenMemID"] + "";
            txtAgenMemName.Text = dtMed.Rows[0]["agencyFullNameThai"] + "";
            Unpaid = dtMed.Rows[0]["Unpaid"] + "" == "" ? 0 : Convert.ToDecimal(dtMed.Rows[0]["Unpaid"] + "");
            NetAmount = dtMed.Rows[0]["NetAmount"] + "" == "" ? 0 : Convert.ToDecimal(dtMed.Rows[0]["NetAmount"] + "");
            dateTimePickerCreate.Value = dtMed.Rows[0]["UpdateDate"] + "" == "" ? DateTime.Now : Convert.ToDateTime(dtMed.Rows[0]["UpdateDate"] + "");
            txtSONo.Text = dtMed.Rows[0]["SONo"] + "";
            comboBoxCommission1.SelectedValue = dtMed.Rows[0]["EN_COMS1"] + "";
            comboBoxCommission2.SelectedValue = dtMed.Rows[0]["EN_COMS2"] + "";

            if (dtMed.Rows[0]["MedStatus_Code"] + "" != "2")
                btnSave.Enabled = true;        //ยังไม่จ่าย บันทึกได้
            else if (dtMed.Rows[0]["MedStatus_Code"] + "" == "2" && dtMed.Rows[0]["UseStatus"] + "" != "4" && dtMed.Rows[0]["UseStatus"] + "" != "5")//จ่ายครบ และ ยังไม่ใช้
                btnSave.Enabled = true; 
            else
                btnSave.Enabled = false; 

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
                txtMO.Text=vn;
            }
              
            DataTable dtSupGroup = GroupByMultiple("MergStatus", dtSup); // Group Layer
            foreach (DataRow rw in dtSupGroup.Rows) 
            {
                string expression = "MergStatus ='" + rw["MergStatus"] + "'";
                foreach (DataRow dr in dtSup.Select(expression))
                {
                    string[] ms_code = (dr["MergStatus"] + "").Split(':');
                    if (ms_code.Length > 1)
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
                        double doubleSpecialPrice = 0;
                        double doubleAmount = 0;
                        double doublePriceUnit = 0;
                        string strTab = "";
                        string unitname = "";
                        string Fee1 = "";
                        string Fee2 = "";

                        string FreeAmount = "";
                        string Complimentary = "";
                        string MarketingBudget = "";
                        string Gift = "";
                        string GiftNumber = "";
                        string Subject = "";
                        string BeforeAfter = "";
                        string Extras_sale = "";
                        string PRO = "";
                        string VIP = "";
                        string MedicalTab = "";
                        string ExpireDate = "";
                        string SpecialPrice = "";
                        string Note = "";
                        foreach (var s in ms_code)
                        {
                            string mscode = "MS_Code ='" + s + "'";
                            foreach (DataRow drmerg in dtSup.Select(mscode)) //Loop Merg
                            {
                                //==========================Merg Item=======================
                                List<Entity.SupplieTrans> listSup = new List<Entity.SupplieTrans>();
                                rowsToDelete = new List<DataGridViewRow>();

                                //rowsToDelete.Add(item);

                                if (msCode != "") msCode += ":";
                                msCode += drmerg["MS_Code"] + "";

                                if (msName != "") msName += ":";
                                msName += drmerg["MS_Name"] + "";

                                if (strAmount != "") strAmount += ":";
                                strAmount += drmerg["Amount"] + "";

                                if (strNumCouse != "") strNumCouse += ":";
                                strNumCouse += drmerg["MS_Number_C"] + "";


                                double dblTotal = (double.Parse(drmerg["Amount"] + "")*
                                                   (drmerg["MS_Number_C"] + "" == ""
                                                        ? 0
                                                        : double.Parse(drmerg["MS_Number_C"] + "")));
                                if (strTotal != "") strTotal += ":";
                                strTotal += dblTotal;

                                if (strUsed != "") strUsed += ":";
                                strUsed += drmerg["NumOfUse"] + "";


                                if (strBalance != "") strBalance += ":";
                                strBalance += (dblTotal - double.Parse(drmerg["NumOfUse"] + "")).ToString("###,###.##");

                                double dblCL = drmerg["MS_CLPrice"] + "" == ""
                                                   ? 0
                                                   : double.Parse(drmerg["MS_CLPrice"] + "");
                                double dblCA = drmerg["MS_CAPrice"] + "" == ""
                                                   ? 0
                                                   : double.Parse(drmerg["MS_CAPrice"] + "");
                                double pricePerUnit =Entity.Userinfo.PriceNormal.Contains(dtMed.Rows[0]["CustomerType"] + "") ? dblCL : dblCA;

                                if (strPriceUnit != "") strPriceUnit += ":";
                                strPriceUnit += pricePerUnit.ToString("###,###.##");

                                doublePriceTotal += (double.Parse(drmerg["Amount"] + "")*pricePerUnit);
                                doubleSpecialPrice = drmerg["SpecialPrice"] + "" == "" ? 0 : double.Parse(drmerg["SpecialPrice"] + "");
                                //if (strTab != "") strTab += ":";

                                strTab = drmerg["MedicalTab"] + "";
                                doubleAmount = Convert.ToDouble(drmerg["Amount"] + "");
                                //doublePriceUnit = Convert.ToDouble(dr["Price/Unit"] + "");
                                doublePriceTotal += doubleAmount*doublePriceUnit;

                                if (!string.IsNullOrEmpty(vn))
                                {
                                    Entity.SupplieTrans supplieInfo = new Entity.SupplieTrans();
                                    supplieInfo.VN = vn;
                                    supplieInfo.MS_Code = drmerg["MS_Code"] + "";
                                    listSup.Add(supplieInfo);
                                }

                                FreeAmount = drmerg["FreeAmount"] + "";
                                Complimentary = drmerg["Complimentary"] + "";
                                MarketingBudget = drmerg["MarketingBudget"] + "";
                                Gift = drmerg["Gift"] + "";
                                GiftNumber = drmerg["GiftNumber"] + "";
                                Subject = drmerg["Subject"] + "";
                                BeforeAfter = drmerg["BeforeAfter"] + "";
                                Extras_sale = drmerg["Extras_sale"] + "";
                                VIP = drmerg["VIP"] + "";
                                PRO = drmerg["PRO"] + "";
                                MedicalTab = drmerg["MedicalTab"] + "";
                                unitname = drmerg["UnitName"] + "";
                                Fee1 = drmerg["FeeRate"] + "";
                                Fee2 = drmerg["FeeRate2"] + "";
                                ExpireDate = drmerg["ExpireDate"] + "";
                                Note = drmerg["Note"] + "";
                            }
                          
                            //==========================Merg Item=======================
                            //MergItem();
                        }
                        //Add New Row
                        if(msName=="") continue; 
                        object[] myItems = {
                                                   false,
                                                   msCode,
                                                   msName,
                                                   strNumCouse, //Num/Couse
                                                   strAmount ==""?"":double.Parse(strAmount).ToString("###,###.##"), //จำนวนที่ซื้อ
                                                   strTotal, //Total
                                                   strUsed, //Use
                                                   unitname,
                                                   strBalance, //Balance
                                                   strPriceUnit, //Price/Unit
                                                   doubleSpecialPrice==0?"0": doubleSpecialPrice.ToString("###,###.##"), //SpecialPrice
                                                   doublePriceTotal==0?"0": doublePriceTotal.ToString("###,###.##"), //PriceTotal
                                                   FreeAmount,//other
                                                    "",//ExpireDate
                                                   Complimentary == "Y" ? true : false,
                                                    Subject == "Y" ? true : false,
                                                    "",// MarketingBudget == "Y" ? true : false,
                                                    "",//Gift == "Y" ? true : false,
                                                    GiftNumber,
                                                   BeforeAfter,
                                                    Extras_sale,
                                                    VIP,
                                                    PRO == "Y" ? true : false,
                                                   MedicalTab,
                                                   Fee1,
                                                   Fee2,
                                                   Note,
                                                   imageList1.Images[0],
                                               };
                        dataGridViewSelectList.Rows.Add(myItems);
                    }
                    else
                    {
                        double dblTotal = (double.Parse(dr["Amount"] + "") * (dr["MS_Number_C"] + "" == "" ? 0 : double.Parse(dr["MS_Number_C"] + "")));
                        double dblCL = dr["MS_CLPrice"] + "" == "" ? 0 : double.Parse(dr["MS_CLPrice"] + "");
                        double dblCA = dr["MS_CAPrice"] + "" == "" ? 0 : double.Parse(dr["MS_CAPrice"] + "");
                        double pricePerUnit = dtMed.Rows[0]["CustomerType"] + "" == "CNT" || dtMed.Rows[0]["CustomerType"] + "" == "CNM" ? dblCL : dblCA;
                        if (dr["MS_Name"] + "" == "" && dr["MS_Code"] + "" == "") continue;
                        if ((dr["MS_Code"] + "").Contains("PRO_CREDIT"))
                        {
                            string ms_name = "";
                            string code = "";
                            foreach (DataGridViewRow item in dgvPromotionList.Rows)
                            {
                                if ((dr["MS_Code"] + "").Contains(item.Cells["PRO_Code"].Value.ToString()))
                                {
                                    ms_name = item.Cells["PRO_Name"].Value.ToString();
                                    code = item.Cells["PRO_Code"].Value.ToString()+"|PRO_CREDIT";
                                    ProCreditMoney = item.Cells["ProPriceCredit"].Value + "" == "" ? 0 : decimal.Parse(item.Cells["ProPriceCredit"].Value + "");
                                    //lbPromotion.Text = string.Format("Promotion:{0}:{1}", PRO_Code, item.Cells["PRO_Name"].Value + "");
                                    lbProCredit.Text = string.Format("ยอดเงินคงเหลือ/Credit ({0}/{1}) บาท/Bth.", (ProCreditRemain) == 0 ? "0" : (ProCreditRemain).ToString("###,###,###.##"), ProCreditMoney.ToString("###,###,###.##"));
                                    lbProCredit.Visible = item.Cells["PRO_Type"].Value + "" == "CREDIT";
                                    PROCredit = item.Cells["PRO_Type"].Value + "" == "CREDIT"?"Y":"";
                                    PROCreditProductGroup = item.Cells["ProductGroup"].Value + "";
                                    //radioAE.Enabled = true;
                                    //radioSU.Enabled = true;
                                    //radioWE.Enabled = true;
                                    //tabControl.TabPages.Insert(0, tabPromotion);
                                    if (PROCredit == "Y" && radioButtonMO.Checked)
                                    {
                                        tabControl.TabPages.Remove(tabPromotion);
                                        tabControl.TabPages.Insert(0, tabWellness_Antiaging);
                                        tabControl.TabPages.Insert(0, tabSurgery);
                                        tabControl.TabPages.Insert(0, tabAesthetic);
                                        tabControl.SelectedTab = tabAesthetic;
                                    }
                                }
                            }
                            double NormalPrice = dr["MS_Price"] + "" == "" ? 0 : double.Parse(dr["MS_Price"] + "");
                            double PROPrice1 = dr["SpecialPrice"] + "" == "" ? 0 : double.Parse(dr["SpecialPrice"] + "");
                            double PriceTotal = NormalPrice > PROPrice1 ? NormalPrice - PROPrice1 : PROPrice1 - NormalPrice;

                             PriceTotal = Math.Abs(NormalPrice) - Math.Abs(PROPrice1);
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
                                            "1",//จำนวนที่ซื้อ
                                           "0",//Total
                                           "0",//Use
                                            "",//Unit
                                           "0",//Balance
                                          NormalPrice,//PricePer
                                          PROPrice1.ToString("###,###,###.##"),//Special Price
                                          PriceTotal.ToString("###,###,###.##"),//PriceTotal
                                          
                                           //customerType == "CNT"||customerType == "CNM" ?double.Parse( item.Cells["MS_CLPrice"].Value+"").ToString("###,###.##") :double.Parse( item.Cells["MS_CAPrice"].Value+"").ToString("###,###.##"),//Price/Unit
                                           //customerType == "CNT"||customerType == "CNM" ?double.Parse( item.Cells["MS_CLPrice"].Value+"").ToString("###,###.##") :double.Parse( item.Cells["MS_CAPrice"].Value+"").ToString("###,###.##"),//PriceTotal
                                           "",//Other
                                           "",//ExpireDate
                                           false,//comp
                                           false,//subject
                                           "",//false,//mkt b
                                           "",//false,//gif
                                           "",//GiftNumber
                                          false,//BeforeAfter
                                          false,//Extras_sale
                                          false,//VIP
                                          PROCredit=="Y",//PRO
                                           tabTyp,
                                           "",//FeeRate
                                           "",//FeeRate2
                                           "",
                                           imageList1.Images[0]
                                       };
                             dataGridViewSelectList.Rows.Add(myItems);
                             if (radioButtonMO.Checked) dataGridViewSelectList.Rows[dataGridViewSelectList.RowCount-1].Visible = false;
                        }
                        else
                        {
                                    object[] myItems = {
                                               false,
                                               dr["MS_Code"] + "",
                                               dr["MS_Name"] + "",
                                               dr["MS_Number_C"] + "",
                                               dr["Amount"] + "" ==""?"":double.Parse(dr["Amount"] + "").ToString("###,###.##"), //จำนวนที่ซื้อ
                                               
                                               dblTotal.ToString("###,###.##"),
                                               dr["NumOfUse"] + "",
                                               dr["UnitName"] + "",
                                               (dblTotal - double.Parse(dr["NumOfUse"] + "")).ToString("###,###.##"),
                                               pricePerUnit.ToString("###,###.##"),
                                               double.Parse(dr["SpecialPrice"] + "").ToString("###,###.##"),//SpecialPrice
                                               ((double.Parse(dr["Amount"] + "")*pricePerUnit)+double.Parse(dr["SpecialPrice"] + "")).ToString("###,###,###.##"),
                                           
                                               dr["FreeAmount"] + "",//Other
                                                 dr["ExpireDate"] + "",//ExpireDate
                                               dr["Complimentary"] + "" == "Y" ? true : false,
                                               dr["Subject"] + "" == "Y" ? true : false,
                                               dr["MarketingBudget"] + "" ,//== "Y" ? true : false,
                                               dr["Gift"] + "",// == "Y" ? true : false,
                                               dr["GiftNumber"] + "",
                                               dr["BeforeAfter"] + "" == "Y" ? true : false,
                                               dr["Extras_sale"] + "" == "Y" ? true : false,
                                               dr["VIP"] + "" == "Y" ? true : false,
                                               dr["PRO"] + "" == "Y" ? true : false,
                                               dr["MedicalTab"] + "",
                                               dr["FeeRate"]+"",
                                               dr["FeeRate2"]+"",
                                               dr["Note"]+"",
                                               imageList1.Images[0],
                                           };  
                            dataGridViewSelectList.Rows.Add(myItems);
                        }
                      
                    }
                    break;
                }
            }
            if (PROCredit == "Y") dataGridViewSelectList.Columns["SpecialPrice"].HeaderText = "Discount";

            dataGridViewSelectList.ClearSelection();
            SumPriceMedicalOrder();
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
                                       imageList1.Images[9],
                                       imageList1.Images[5],
                                       "False",
                                         row["Id"]+""
                                   };
                dgvFile.Rows.Add(myItems);
            }
            // member group trans
            dicMemberTran=new Dictionary<string,List<Entity.MembersTrans>>() ;
            List<Entity.MembersTrans> lsmem=new List<Entity.MembersTrans> ();
            DataView view = new DataView(dtMemTrans);
            DataTable distinctValues = view.ToTable(true, "VN", "MS_Code");
                
                foreach (DataRow ms in distinctValues.Rows)
	            {
                    string sql=string.Format("VN='{0}' and MS_Code='{1}'",ms["VN"],ms["MS_Code"]);
                    lsmem=new List<Entity.MembersTrans> ();
                    foreach (DataRow row in dtMemTrans.Select(sql))
                    {
                        Entity.MembersTrans m=new Entity.MembersTrans ();
                        m.VN=row["VN"]+"";
                        m.MS_Code=row["MS_Code"]+"";
                        m.CN=row["CN"]+"";
                        lsmem.Add(m);
                    }
                     if(!dicMemberTran.ContainsKey(ms["MS_Code"]+""))
                            dicMemberTran.Add(ms["MS_Code"]+"",lsmem);
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
        private void SetColumnsDgv()
        {
            SetColDtTmpHair();
            SetColumnDgvAesList();
            SetColumnDgvTreatmentList();
            SetColumnDgvSurgeryList();
            SetColumnDgvWellness_AntiagingList();
            SetColumnDgvPharmacyList();
            SetColumnDgvHairList();
            SetColumnsPromotion();
            SetColumnDgvSelectList();
            SetColumnDgvFile();
        }

        private void SetColumnDgvFile()
        {
            dgvFile.RowPostPaint+=new DataGridViewRowPostPaintEventHandler(dgvFile_RowPostPaint);
            DerUtility.SetPropertyDgv(dgvFile);
          
            dgvFile.Columns.Add("FilePath", "FilePath");
            dgvFile.Columns.Add("FileName", "ชื่อไฟล์");
            dgvFile.Columns.Add("Detail", "รายละเอียด");
            DataGridViewImageColumn colFile = new DataGridViewImageColumn();
            {
                colFile.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                colFile.CellTemplate = new DataGridViewImageCell();
            }
            dgvFile.Columns.Add(colFile);
            DataGridViewImageColumn colDown = new DataGridViewImageColumn();
            {
                colDown.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                colDown.CellTemplate = new DataGridViewImageCell();
            }
            
            dgvFile.Columns.Add(colDown); 
            dgvFile.Columns.Add("NewRow", "NewRow");
            dgvFile.Columns.Add("Id", "Id");

            dgvFile.Columns["FilePath"].Width = 200;
            dgvFile.Columns["Detail"].Width = 150;
            dgvFile.Columns["FilePath"].Visible = false;
            dgvFile.Columns["NewRow"].Visible = false;
            dgvFile.Columns["Id"].Visible = false;
        }

        private void SetColDtTmpHair()
        {
            dtTmpHairSelect.Columns.Add("MS_Section", typeof (string));
            dtTmpHairSelect.Columns.Add("Code", typeof (string));
            dtTmpHairSelect.Columns.Add("Name", typeof (string));
            dtTmpHairSelect.Columns.Add("MS_CLPrice", typeof(string));
            dtTmpHairSelect.Columns.Add("MS_CAPrice", typeof (string));
            dtTmpHairSelect.Columns.Add("UnitName", typeof(string));
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
            

            dgvPromotionList.Columns["PRO_Code"].Width = 80;
            dgvPromotionList.Columns["PRO_Name"].Width = 200;
            dgvPromotionList.Columns["ProPrice"].Width = 50;
            dgvPromotionList.Columns["DateStart"].Width = 100;
            dgvPromotionList.Columns["DateEnd"].Width = 100;
            dgvPromotionList.Columns["PRO_Active"].Width = 10;
            //dgvPromotionList.Columns["ProductGroup"].Visible = false;

            dgvPromotionList.Columns["Remark"].Width = 200;

            //dgvPromotionList.Columns["ProPriceCredit"].Visible =false;
           

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
            dgvAestheticList.Columns.Add("MS_Section","Section");
            dgvAestheticList.Columns.Add("Code", "Code");
            dgvAestheticList.Columns.Add("Name", "Name");
            
            dgvAestheticList.Columns.Add("MS_CLPrice", "Local Price");
            dgvAestheticList.Columns.Add("MS_CAPrice", "Agency Price");
            //dgvAestheticList.Columns.Add("MS_CMPrice", "MS_CMPrice");
            dgvAestheticList.Columns.Add("MS_Type", "MS_Type");
            dgvAestheticList.Columns.Add("MS_Number_C", "Number/Course");
            dgvAestheticList.Columns.Add("UnitName","Unit");
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
        }

        private void SetColumnDgvTreatmentList()
        {
            DerUtility.SetPropertyDgv(dgvTreatmentList);
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            {
                column.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                column.FlatStyle = FlatStyle.Standard;
                column.ThreeState = false;
                column.CellTemplate = new DataGridViewCheckBoxCell();
                column.CellTemplate.Style.BackColor = Color.Beige;
            }
            dgvTreatmentList.Columns.Add(column);
            dgvTreatmentList.Columns.Add("MS_Section", "Section");
            dgvTreatmentList.Columns.Add("Code", "Code");
            dgvTreatmentList.Columns.Add("Name", "Name");

            dgvTreatmentList.Columns.Add("MS_CLPrice", "Local Price");
            dgvTreatmentList.Columns.Add("MS_CAPrice", "Agency Price");
            //dgvTreatmentList.Columns.Add("MS_CMPrice", "MS_CMPrice");
            dgvTreatmentList.Columns.Add("MS_Type", "MS_Type");
            dgvTreatmentList.Columns.Add("MS_Number_C", "Number/Course");
            dgvTreatmentList.Columns.Add("UnitName", "Unit");
            dgvTreatmentList.Columns.Add("Tab", "Tab");
            dgvTreatmentList.Columns.Add("FeeRate", "Fee Rate");
            dgvTreatmentList.Columns.Add("FeeRate2", "Fee Rate 2");

            dgvTreatmentList.Columns["Tab"].Visible = false;
            dgvTreatmentList.Columns["FeeRate"].Visible = false;
            dgvTreatmentList.Columns["FeeRate2"].Visible = false;
            //dgvTreatmentList.Columns["MS_CAPrice"].Visible = false;
            //dgvTreatmentList.Columns["MS_CMPrice"].Visible = false;
            // dgvTreatmentList.Columns["MS_Type"].Visible = false;
            //dgvTreatmentList.Columns["MS_Number_C"].Visible = false;

            dgvTreatmentList.Columns["Code"].Width = 100;
            dgvTreatmentList.Columns["Name"].Width = 150;
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
            //dgvSurgeryList.Columns["MS_CMPrice"].Visible = false;
            // dgvSurgeryList.Columns["MS_Type"].Visible = false;
            //dgvSurgeryList.Columns["MS_Number_C"].Visible = false;

            dgvSurgeryList.Columns["Code"].Width = 100;
            dgvSurgeryList.Columns["Name"].Width = 150;
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
            dgvWellness_AntiagingList.Columns["Name"].Width = 150;
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
        }

        private void SetColumnDgvHairList()
        {
            DerUtility.SetPropertyDgv(dgvHairList);
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            {
                column.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                column.FlatStyle = FlatStyle.Standard;
                column.ThreeState = false;
                column.CellTemplate = new DataGridViewCheckBoxCell();
                column.CellTemplate.Style.BackColor = Color.Beige;
            }
            dgvHairList.Columns.Add(column);
            dgvHairList.Columns.Add("MS_Section", "Section");
            dgvHairList.Columns.Add("Code", "Code");
            dgvHairList.Columns.Add("Name", "Name");

            dgvHairList.Columns.Add("MS_CLPrice", "Local Price");
            dgvHairList.Columns.Add("MS_CAPrice", "Agency Price");
            //dgvHairList.Columns.Add("MS_CMPrice", "MS_CMPrice");
            dgvHairList.Columns.Add("MS_Type", "MS_Type");
            dgvHairList.Columns.Add("MS_Number_C", "Number/Course");

            dgvHairList.Columns.Add("Tab", "Tab");
            dgvHairList.Columns.Add("FeeRate", "Fee Rate");
            dgvHairList.Columns.Add("FeeRate2", "Fee Rate 2");

            dgvHairList.Columns["Tab"].Visible = false;
            dgvHairList.Columns["FeeRate"].Visible = false;
            dgvHairList.Columns["FeeRate2"].Visible = false;
            //dgvHairList.Columns["MS_CMPrice"].Visible = false;
            // dgvHairList.Columns["MS_Type"].Visible = false;
            //dgvHairList.Columns["MS_Number_C"].Visible = false;

            dgvHairList.Columns["Code"].Width = 100;
            dgvHairList.Columns["Name"].Width = 150;
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
                column.ThreeState = false;
                column.Name = "ChkMove";
                column.HeaderText = "";
                column.CellTemplate = new DataGridViewCheckBoxCell();
                column.CellTemplate.Style.BackColor = Color.LemonChiffon;
            }
          
            
            dataGridViewSelectList.Columns.Add(column); //0
            dataGridViewSelectList.Columns.Add("Code", "Code");//1
            dataGridViewSelectList.Columns["Code"].ReadOnly = true;

            dataGridViewSelectList.Columns.Add("Name", "Name");//2
            dataGridViewSelectList.Columns["Name"].ReadOnly = true;

            dataGridViewSelectList.Columns.Add("No./Course", "No./Course");//3
            dataGridViewSelectList.Columns["No./Course"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["No./Course"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewSelectList.Columns["No./Course"].ReadOnly = true;

            dataGridViewSelectList.Columns.Add("Amount", "Quantity");//4 Amount
            dataGridViewSelectList.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["Amount"].DefaultCellStyle.BackColor = Color.LemonChiffon;
            dataGridViewSelectList.Columns["Amount"].Width = 30;



            dataGridViewSelectList.Columns.Add("Total", "Total");//5
            dataGridViewSelectList.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvHairSelect.Columns["Total"].DefaultCellStyle.BackColor = Color.Black;
            dataGridViewSelectList.Columns["Total"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewSelectList.Columns["Total"].ReadOnly = true;

            dataGridViewSelectList.Columns.Add("Used", "Used");//6
            dataGridViewSelectList.Columns["Used"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvHairSelect.Columns["Used"].DefaultCellStyle.BackColor = Color.Black;
            dataGridViewSelectList.Columns["Used"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewSelectList.Columns["Used"].ReadOnly = true;
            //dataGridViewSelectList.Columns["Used"].Visible = false;



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

            dataGridViewSelectList.Columns.Add("Balance", "Balance");//8
            dataGridViewSelectList.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvHairSelect.Columns["Balance"].DefaultCellStyle.BackColor = Color.Black;
            dataGridViewSelectList.Columns["Balance"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewSelectList.Columns["Balance"].ReadOnly = true;

            dataGridViewSelectList.Columns.Add("Price/Unit", "Price/Unit");//9
            dataGridViewSelectList.Columns["Price/Unit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["Price/Unit"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewSelectList.Columns["Price/Unit"].ReadOnly = true;

            dataGridViewSelectList.Columns.Add("SpecialPrice", "Special Price");
            dataGridViewSelectList.Columns["SpecialPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["SpecialPrice"].DefaultCellStyle.BackColor = Color.LemonChiffon;
            dataGridViewSelectList.Columns["SpecialPrice"].Visible = true;

            dataGridViewSelectList.Columns.Add("PriceTotal", "PriceTotal");//10
            dataGridViewSelectList.Columns["PriceTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["PriceTotal"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewSelectList.Columns["PriceTotal"].ReadOnly = true;

      
            //DataGridViewImageColumn ColUse = new DataGridViewImageColumn();
            //{
            //    ColUse.AutoSizeMode =
            //        DataGridViewAutoSizeColumnMode.DisplayedCells;
            //    ColUse.CellTemplate = new DataGridViewImageCell();
            //    ColUse.Name = "BtnUse";
            //    ColUse.HeaderText = "Course (Record)";
            //}
            //dataGridViewSelectList.Columns.Add(ColUse);

            dataGridViewSelectList.Columns.Add("Other", "Other");
            dataGridViewSelectList.Columns["Other"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["Other"].DefaultCellStyle.BackColor = Color.LemonChiffon;
            //dataGridViewSelectList.Columns["Other"].Visible = false;

            dataGridViewSelectList.Columns.Add("ExpireDate", "ExpireDate");
            dataGridViewSelectList.Columns["ExpireDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["ExpireDate"].DefaultCellStyle.BackColor = Color.LemonChiffon;
            dataGridViewSelectList.Columns["ExpireDate"].Visible = true;
            dataGridViewSelectList.Columns["ExpireDate"].Width = 30;

            DataGridViewCheckBoxColumn colChkComp = new DataGridViewCheckBoxColumn();
            {
                colChkComp.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                colChkComp.FlatStyle = FlatStyle.Standard;
                colChkComp.ThreeState = false;
                colChkComp.Name = "ChkCom";
                colChkComp.HeaderText = "Comp.";
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
                    MKTBudget.Add(item["values"]+"");
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
                dataGridViewSelectList.Columns["GiftNumber"].Width = 30;

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
                    ChkPRO.HeaderText = "PRO";
                    ChkPRO.CellTemplate = new DataGridViewCheckBoxCell();
                }
                dataGridViewSelectList.Columns.Add(ChkPRO);

            dataGridViewSelectList.Columns.Add("Tab", "Tab");
            dataGridViewSelectList.Columns.Add("FeeRate", "FeeRate");
            dataGridViewSelectList.Columns.Add("FeeRate2", "FeeRate2");
            dataGridViewSelectList.Columns["FeeRate"].Visible = false;
            dataGridViewSelectList.Columns["FeeRate2"].Visible = false;

            dataGridViewSelectList.Columns.Add("Note", "Note");//4 Amount
            dataGridViewSelectList.Columns["Note"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["Note"].DefaultCellStyle.BackColor = Color.LemonChiffon;
            dataGridViewSelectList.Columns["Note"].Width = 200;

            DataGridViewImageColumn ColMember = new DataGridViewImageColumn();
            {
                ColMember.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                ColMember.CellTemplate = new DataGridViewImageCell();
                ColMember.Name = "BtnMember";
                ColMember.HeaderText = "Members";
            }
            dataGridViewSelectList.Columns.Add(ColMember);
        }

        void txtExpireDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void BindPromotionList()
        {
            try
            {
                DerUtility.MouseOn(this);

                dgvPromotionList.Rows.Clear();
                Entity.MedicalSupplies info = new Entity.MedicalSupplies();
                if (!string.IsNullOrEmpty(txtFindHair.Text))
                {
                   // info.MS_Name = "%" + txtFindHair.Text + "%";
                    info.Tabwhere = "PRO_Code Like '%" + txtFindHair.Text + "%'" + " or PRO_Name Like '%" + txtFindHair.Text + "%'";
                }
                else
                {
                    info.Tabwhere = "1=1";
                }
                //info.MS_Section = "ODH"; //Hair
                info.Tab = "PROMOTION";
                DataTable dt = new Business.MedicalSupplies().SelectMedicalSuppliesBySection(info).Tables[0];

                foreach (DataRowView item in dt.DefaultView)
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
                                          item["ProductGroup"] + ""
                                           
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
        private void BindDataHairList()
        {
            try
            {
                DerUtility.MouseOn(this);
                dgvHairList.Rows.Clear();
                Entity.MedicalSupplies info = new Entity.MedicalSupplies();
                if (!string.IsNullOrEmpty(txtFindHair.Text))
                {
                    // info.MS_Name = "%" + txtFindHair.Text + "%";
                    info.Tabwhere = "Msup.MS_Code Like '%" + txtFindHair.Text + "%'" + " or Msup.MS_Name Like '%" + txtFindHair.Text + "%'";
                }
                else
                {
                    info.Tabwhere = "1=1";
                }
                //info.MS_Section = "ODH"; //Hair
                info.Tab = "HAIR";
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
                                          //(item["MS_CMPrice"] + ""=="")?"0":(item["MS_CMPrice"] + ""),
                                           item["MS_Type"] + "",
                                          (item["MS_Number_C"] + "" =="")?"0":(item["MS_Number_C"] + ""),
                                          item["UnitName"] + "",
                                          info.Tab,
                                          item["FeeRate"] + "", 
                                          item["FeeRate2"] + ""
                                       };
                    dgvHairList.Rows.Add(myItems);
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
                                          item["FeeRate2"] + ""
                                       };
                    dgvAestheticList.Rows.Add(myItems);
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

        private void BindDataTreatmentList()
        {
            try
            {
                DerUtility.MouseOn(this);
                dgvTreatmentList.Rows.Clear();
                Entity.MedicalSupplies info = new Entity.MedicalSupplies();
                if (!string.IsNullOrEmpty(txtFindTreatment.Text))
                {
                    //info.MS_Name = "%" + txtFindTreatment.Text + "%";
                    info.Tabwhere = "Msup.MS_Code Like '%" + txtFindTreatment.Text + "%'" + " or Msup.MS_Name Like '%" + txtFindTreatment.Text + "%'";
                }
                else
                {
                    info.Tabwhere = "1=1";
                }

                //info.MS_Section = "TTF"; //Hair
                info.Tab = "TREATMENT";
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
                                          (item["MS_Number_C"] + "" =="")?"0":(item["MS_Number_C"] + "")
                                           , item["UnitName"] + ""
                                          ,info.Tab
                                         
                                          ,item["FeeRate"] + ""
                                          ,item["FeeRate2"] + ""
                                       };
                    dgvTreatmentList.Rows.Add(myItems);
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
                                          (item["MS_Number_C"] + "" =="")?"0":(item["MS_Number_C"] + "")
                                            , item["UnitName"] + ""
                                        
                                          ,item["FeeRate"] + ""
                                          ,item["FeeRate2"] + ""
                                            ,info.Tab
                                       };
                    dgvSurgeryList.Rows.Add(myItems);
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
        private void BindDataWellness_antiAgentList()
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
                //info.MS_Section = "ODF";
                info.Tab = "WELLNESS";
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
                                          (item["MS_Number_C"] + "" =="")?"0":(item["MS_Number_C"] + "")
                                           , item["UnitName"] + ""
                                          ,info.Tab
                                         
                                       };
                    dgvWellness_AntiagingList.Rows.Add(myItems);
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
                                          (item["MS_Number_C"] + "" =="")?"0":(item["MS_Number_C"] + "")
                                          ,item["UnitName"] + ""
                                          ,info.Tab
                                         
                                       };
                    dgvPharmacyList.Rows.Add(myItems);
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
        
        private void dgvHairList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHairList.Rows.Count < 0 || dgvHairList.CurrentRow == null) return;
            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
            ch1 = (DataGridViewCheckBoxCell) dgvHairList.Rows[dgvHairList.CurrentRow.Index].Cells[0];
            if (dgvHairList.CurrentCell.ColumnIndex != 0) return;
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
        }

        private void dgvHairList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView) sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView) sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        private void buttonRigth6_BtnClick()
        {
            if (string.IsNullOrEmpty(customerType))
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "กรุณาเลือก \"ลูกค้า\" ก่อน");
                return;
            }
            foreach (DataGridViewRow item in dgvHairList.Rows)
            {
                if ((bool) item.Cells[0].Value == true)
                {
                    object[] myItems = {
                                            false,
                                           item.Cells[1].Value,
                                           item.Cells[2].Value,
                                           "1",
                                           item.Cells[7].Value,
                                           item.Cells[7].Value,
                                           "0",
                                           item.Cells[7].Value+"",
                                           customerType == "CNT"||customerType == "CNM" ?double.Parse( item.Cells["MS_CLPrice"].Value+"").ToString("###,###.##") :double.Parse( item.Cells["MS_CAPrice"].Value+"").ToString("###,###.##"),
                                           customerType == "CNT"||customerType == "CNM" ? double.Parse( item.Cells["MS_CLPrice"].Value+"").ToString("###,###.##") :double.Parse( item.Cells["MS_CAPrice"].Value+"").ToString("###,###.##"),
                                           //imageList1.Images[0],
                                           //false,
                                           imageList1.Images[4],"",false,false,false,false,
                                           "HAIR"
                                       };
                    
                    item.Cells[0].Value = false;

                    dataGridViewSelectList.Rows.Add(myItems);

                    SumPriceMedicalOrder();
                }
            }

        }

        private void dataGridViewSelectList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
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
            var b = new SolidBrush(((DataGridView) sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView) sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        private void dgvTreatmentList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView) sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView) sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        private void dgvSurgeryList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView) sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView) sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        private void dgvPharmacyList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView) sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView) sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        private void dgvAestheticList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAestheticList.Rows.Count < 0 || dgvAestheticList.CurrentRow == null) return;
            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
            ch1 = (DataGridViewCheckBoxCell) dgvAestheticList.Rows[dgvAestheticList.CurrentRow.Index].Cells[0];
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
        }

        private void dgvTreatmentList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTreatmentList.Rows.Count < 0 || dgvTreatmentList.CurrentRow == null) return;
            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
            ch1 = (DataGridViewCheckBoxCell) dgvTreatmentList.Rows[dgvTreatmentList.CurrentRow.Index].Cells[0];
            if (dgvTreatmentList.CurrentCell.ColumnIndex != 0) return;
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
        }

        private void dgvSurgeryList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSurgeryList.Rows.Count < 0 || dgvSurgeryList.CurrentRow == null) return;
            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
            ch1 = (DataGridViewCheckBoxCell) dgvSurgeryList.Rows[dgvSurgeryList.CurrentRow.Index].Cells[0];
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
        }

        private void dgvPharmacyList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPharmacyList.Rows.Count < 0 || dgvPharmacyList.CurrentRow == null) return;
            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
            ch1 = (DataGridViewCheckBoxCell) dgvPharmacyList.Rows[dgvPharmacyList.CurrentRow.Index].Cells[0];
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
        }

        private void dataGridViewSelectList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
               
               DataGridViewCheckBoxCell chCom = new DataGridViewCheckBoxCell();
               chCom = (DataGridViewCheckBoxCell)dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells["ChkCom"];
               //DataGridViewCheckBoxCell chMar = new DataGridViewCheckBoxCell();
               //chMar = (DataGridViewCheckBoxCell)dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells["ChkMar"];
               //DataGridViewCheckBoxCell chGif = new DataGridViewCheckBoxCell();
               //chGif = (DataGridViewCheckBoxCell)dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells["ChkGiftv"];
               DataGridViewCheckBoxCell chSub = new DataGridViewCheckBoxCell();
               chSub = (DataGridViewCheckBoxCell)dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells["ChkSub"];

            if (e.ColumnIndex == chCom.ColumnIndex)
            {
                chCom.Value = true;
                //chMar.Value = false;
               // chGif.Value = false;
                chSub.Value = false;
            }
       
            //if (e.ColumnIndex == chGif.ColumnIndex)
            //{
            //    chCom.Value = false;
            //    //chMar.Value = false;
            //    //chGif.Value = true;
            //    chSub.Value = false;
            //}
            if (e.ColumnIndex == chSub.ColumnIndex)
            {
                chCom.Value = false;
                //chMar.Value = false;
                //chGif.Value = false;
                chSub.Value = true;
            }
            if (e.ColumnIndex == dataGridViewSelectList.Columns["BtnMember"].Index)
            {
                popMemberGroup frm = popMemberGroup.GetInstance();
                frm.CN = CN;
                frm.VN = VN;
                frm.dicMemberTran = dicMemberTran;
                frm.MS_Code =MS_Code= dataGridViewSelectList.Rows[e.RowIndex].Cells["Code"].Value + "";
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
                //PopMedicalUsed obj = new PopMedicalUsed();
                //obj.StartPosition = FormStartPosition.CenterScreen;
                //obj.WindowState = FormWindowState.Normal;
                //obj.BackColor = Color.FromArgb(255, 230, 217);
                //obj.CN = cn;
                //obj.VN = vn;
                //obj.MS_Code = dataGridViewSelectList.Rows[e.RowIndex].Cells["Code"].Value + "";
                //obj.SupplieName = dataGridViewSelectList.Rows[e.RowIndex].Cells["Name"].Value + "";
                //obj.AmountTotal = dataGridViewSelectList.Rows[e.RowIndex].Cells["Total"].Value + "";
                //obj.AmountUsed = dataGridViewSelectList.Rows[e.RowIndex].Cells["Used"].Value + "";
                //obj.AmountBalance = dataGridViewSelectList.Rows[e.RowIndex].Cells["Balance"].Value + "";
                //obj.TabName = dataGridViewSelectList.CurrentRow.Cells["Tab"].Value + "";
                //obj.CustomerName = txtCustomerName.Text;
        
                //obj.ShowDialog();

                //if (obj.MedicalOrderUseTranss != null)
                //{
                //    MedicalOrderUseTranss.AddRange(obj.MedicalOrderUseTranss);
                //}
                //MedicalStuffs = obj.MedicalStuffs;
            }
            if (MoSubType == "PRO")
            {
                if (dataGridViewSelectList.Rows.Count < 0 || dataGridViewSelectList.CurrentRow == null) return;
                DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                ch1 = (DataGridViewCheckBoxCell)dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells[0];
                if (dataGridViewSelectList.CurrentCell.ColumnIndex != 0) return;
                if (ch1.Value == null)
                    ch1.Value = true;
              
                foreach (DataGridViewRow item in dataGridViewSelectList.Rows)
                {
                    item.Cells[0].Value = true;
                }
                ch1.Value = true;
                dataGridViewSelectList.Invalidate();
            }   
            }
            catch (Exception ex)
            {

            }
        }

    private void buttonAddDown_BtnClick()
        {
        try
        {
            lbPromotion.Text = "";
            if (string.IsNullOrEmpty(customerType))
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "กรุณาเลือก \"ลูกค้า\" ก่อน");
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
                    case TabPageActive.tabTreatment:
                        dv = dgvTreatmentList;
                        tabTyp = "TREATMENT";
                        MoSubType = "TR";
                        break;
                    case TabPageActive.tabSurgery:
                        dv = dgvSurgeryList;
                        tabTyp = "SURGERY";
                        MoSubType = "SU";
                        break;
                    case TabPageActive.tabHair:
                        dv = dgvHairList;
                        tabTyp = "HAIR";
                        MoSubType = "HA";
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
                    case TabPageActive.tabAttachFile:
                        //tabPageActive = TabPageActive.tabAesthetic;
                        break;
            }
            //if (dataGridViewSelectList.RowCount > 0 && tabTypShortName!="" && MoSubType != tabTypShortName) return;
            if (MoSubType == "PRO")//โปรธรรมดา
            {
                Entity.Promotion info = new Entity.Promotion();
                info.QueryType = "SEARCHBYID";
                foreach (DataGridViewRow item in dv.Rows)
                {
                    if ((bool)item.Cells[0].Value == true)
                    {
                        info.PRO_Code = item.Cells["PRO_Code"].Value+"";
                        PRO_Code = item.Cells["PRO_Code"].Value + "";
                        ProCreditMoney = item.Cells["ProPriceCredit"].Value + "" == "" ? 0 : decimal.Parse(item.Cells["ProPriceCredit"].Value + "");
                        lbPromotion.Text = string.Format("Promotion:{0}:{1}", PRO_Code, item.Cells["PRO_Name"].Value + "");
                        lbProCredit.Text = string.Format("ยอดเงินคงเหลือ/Credit ({0}/{1}) บาท/Bth.", (ProCreditRemain) == 0 ? "0" : (ProCreditRemain).ToString("###,###,###.##"), ProCreditMoney.ToString("###,###,###.##"));
                        lbProCredit.Visible = item.Cells["PRO_Type"].Value + "" == "CREDIT";
                        PROCredit = item.Cells["PRO_Type"].Value + "" == "CREDIT" ? "Y" : "";
                    }
                }
               
                DataTable dt = new Business.Promotion().SelectPromotionPaging(info).Tables[0];
                if (dt == null || dt.Rows.Count <= 0) return;
                dataGridViewSelectList.Rows.Clear();
                LsSelectMS_Code = new List<string>();
                AddDownToGrid("AESTHETIC", dt);
                AddDownToGrid("SURGERY", dt);
                AddDownToGrid("WELLNESS", dt);
                AddDownToGrid("PHARMACY", dt);
                AddDownToGridProCredit(dt);
            }
            else
            {
                if (FormType != DerUtility.AccessType.Update)
                {
                    //if (radioButtonMO.Checked)
                    //    txtMO.Text = txtMO.Text.Replace("-", string.Format("-{0}-", MoSubType));
                    //else
                    //    txtSONo.Text = txtSONo.Text.Replace("-", string.Format("-{0}-", MoSubType));
                    moso = radioButtonMO.Checked ? "MO-" : "SO-";
                    this.idMax = UtilityBackEnd.GenMaxSeqnoValues(moso + MoSubType + "-");
                    if (radioButtonMO.Checked)
                        this.txtMO.Text = this.MO = this.idMax.Replace("VNM", moso);
                    else
                        this.txtSONo.Text = this.idMax.Replace("VNM", moso);
                }

            tabTypShortName = MoSubType;

            decimal MS_CLPrice = 0;
            decimal MS_CAPrice = 0;
            string MS_Price = "0";
            decimal MS_PriceDouble = 0;
            foreach (DataGridViewRow item in dv.Rows)
            {
                if ((bool)item.Cells[0].Value == true)
                {
                    string MS_Section = item.Cells["MS_Section"].Value + "";
                    if (PROCredit=="Y"&&!PROCreditProductGroup.Contains(MS_Section))
                    {
                        MessageBox.Show("Is not in promotion", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                    }
                    MS_CLPrice = item.Cells["MS_CLPrice"].Value + "" == "" ? 0 : decimal.Parse(item.Cells["MS_CLPrice"].Value + "");
                    MS_CAPrice = item.Cells["MS_CAPrice"].Value + "" == "" ? 0 : decimal.Parse(item.Cells["MS_CAPrice"].Value + "");
                    MS_Price = Entity.Userinfo.PriceNormal.Contains(customerType) ? MS_CLPrice.ToString("###,###,###.##") : MS_CAPrice.ToString("###,###,###.##");
                    MS_PriceDouble = Entity.Userinfo.PriceNormal.Contains(customerType) ? MS_CLPrice : MS_CAPrice;
                    string PriceTotal = (MS_PriceDouble - ProCreditRemain).ToString("###,###,###.##");
                    object[] myItems = {
                                             false,//chk
                                           item.Cells["Code"].Value,
                                           item.Cells["Name"].Value,
                                           item.Cells["MS_Number_C"].Value,//Num/Couse
                                            "1",//จำนวนที่ซื้อ
                                           "0",//Total
                                           "0",//Use
                                             item.Cells["UnitName"].Value,//Unit
                                           "0",//Balance
                                          MS_Price,//PricePer
                                         ( ProCreditRemain*(-1)).ToString("###,###,###.##"),//Special Price
                                          PriceTotal,//PriceTotal
                                          
                                           //customerType == "CNT"||customerType == "CNM" ?double.Parse( item.Cells["MS_CLPrice"].Value+"").ToString("###,###.##") :double.Parse( item.Cells["MS_CAPrice"].Value+"").ToString("###,###.##"),//Price/Unit
                                           //customerType == "CNT"||customerType == "CNM" ?double.Parse( item.Cells["MS_CLPrice"].Value+"").ToString("###,###.##") :double.Parse( item.Cells["MS_CAPrice"].Value+"").ToString("###,###.##"),//PriceTotal
                                           "",//Other
                                           "",//ExpireDate
                                           false,//comp
                                           false,//subject
                                           "",//false,//mkt b
                                           "",//false,//gif
                                           "",//GiftNumber
                                          false,//BeforeAfter
                                          false,//Extras_sale
                                          false,//VIP
                                          false,//Pro
                                           tabTyp,
                                           item.Cells["FeeRate"].Value+"",
                                           item.Cells["FeeRate2"].Value+"",
                                           "",
                                           imageList1.Images[0]
                                       };
                    item.Cells[0].Value = false;

                    //if(!OverProCredit)
                        dataGridViewSelectList.Rows.Add(myItems);
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
            }
            dataGridViewSelectList.ClearSelection();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        }
    private string CalcDiscount(decimal MS_PriceDouble)
    {
        string percenStr = "";
        try
        {
           
            //if (txtTotalPrice.Text.Length > 0 && txtProPrice.Text.Length > 0)
            //{
            //    double valueUp = double.Parse(txtProPrice.Text);
            //    double valueDown = double.Parse(txtTotalPrice.Text);
                
                decimal discount = 0;
                discount = 100 - ((SalePriceNew * 100) / ProCreditMoney);
                if (ProCreditMoney > (SalePriceNew * 2)) discount = ((SalePriceNew * 100) / ProCreditMoney);
                else if (ProCreditMoney < SalePriceNew) discount = 0;
                else discount = 100 - ((SalePriceNew * 100) / ProCreditMoney);
                //if (valueDown<valueUp ) txtDiscountPercen.Text = "";
                //else
                MS_PriceDouble = (MS_PriceDouble*(discount / 100))*-1;
                 //percenStr=Math.Round(discount, 2).ToString("###,###,###.##");
                percenStr= MS_PriceDouble.ToString("###,###,###.##");
               
            //}
        }
        catch (Exception ex)
        {

        }
        return percenStr;
    }
    private string CalcPriceTotal(decimal MS_PriceDouble)
    {
        decimal priceTotal = 0;
        string priceTotalstr = "";
        try
        {
            decimal discount = 0;
            discount = 100 - ((SalePriceNew * 100) / ProCreditMoney);
            if (ProCreditMoney > (SalePriceNew * 2)) discount = ((SalePriceNew * 100) / ProCreditMoney);
            else if (ProCreditMoney < SalePriceNew) discount = 0;
            else discount = 100 - ((SalePriceNew * 100) / ProCreditMoney);
          
            priceTotal = MS_PriceDouble-(MS_PriceDouble * (discount / 100)) ;
            priceTotalstr = priceTotal.ToString("###,###,###.##");
        }
        catch (Exception ex)
        {

        }
        return priceTotalstr;
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
                if (LsSelectMS_Code.Contains(ms["PRO_Code"].ToString())) continue;
                else LsSelectMS_Code.Add(ms["PRO_Code"].ToString());
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
                                          PROPrice1.ToString("###,###.##"),//PriceTotal
                                          
                                           //customerType == "CNT"||customerType == "CNM" ?double.Parse( item.Cells["MS_CLPrice"].Value+"").ToString("###,###.##") :double.Parse( item.Cells["MS_CAPrice"].Value+"").ToString("###,###.##"),//Price/Unit
                                           //customerType == "CNT"||customerType == "CNM" ?double.Parse( item.Cells["MS_CLPrice"].Value+"").ToString("###,###.##") :double.Parse( item.Cells["MS_CAPrice"].Value+"").ToString("###,###.##"),//PriceTotal
                                           "",//Other
                                           "",//ExpireDate
                                           false,//comp
                                           false,//subject
                                           "",//false,//mkt b
                                           "",//false,//gif
                                           "",//GiftNumber
                                          false,//BeforeAfter
                                          false,//Extras_sale
                                          false,//VIP
                                           tabTyp,
                                           "",//FeeRate
                                           "",//FeeRate2
                                           "",
                                           imageList1.Images[0]
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
            double NormalPrice = 0;
            string MS_Price = "0";
            foreach (DataRow ms in dt.Rows)
            {

                foreach (DataGridViewRow item in dv.Rows)
                {
                    if (item.Cells["Code"].Value.ToString() == ms["MS_Code"].ToString())
                    {
                        if (LsSelectMS_Code.Contains(ms["MS_Code"].ToString())) continue;
                        else LsSelectMS_Code.Add(ms["MS_Code"].ToString());
                        MS_CLPrice = item.Cells["MS_CLPrice"].Value + "" == "" ? 0 : double.Parse(item.Cells["MS_CLPrice"].Value + "");
                        MS_CAPrice = item.Cells["MS_CAPrice"].Value + "" == "" ? 0 : double.Parse(item.Cells["MS_CAPrice"].Value + "");
                        PROPrice1 = ms["MS_ProPrice"] + "" == "" ? 0 : double.Parse(ms["MS_ProPrice"] + "");
                        //MS_Price = MS_CLPrice.ToString("###,###,###.##");// Entity.Userinfo.PriceNormal.Contains(customerType) ? MS_CLPrice.ToString("###,###.##") : MS_CAPrice.ToString("###,###.##");
                        MS_Price = Entity.Userinfo.PriceNormal.Contains(customerType) ? MS_CLPrice.ToString("###,###.##") : MS_CAPrice.ToString("###,###.##");
                        NormalPrice = MS_CLPrice;// Entity.Userinfo.PriceNormal.Contains(customerType) ? MS_CLPrice : MS_CAPrice;
                        object[] myItems = {
                                             false,//chk
                                           item.Cells["Code"].Value,
                                           item.Cells["Name"].Value,
                                           item.Cells["MS_Number_C"].Value,//Num/Couse
                                            "1",//จำนวนที่ซื้อ
                                           "0",//Total
                                           "0",//Use
                                             item.Cells["UnitName"].Value,//Unit
                                           "0",//Balance
                                          MS_Price,//PricePer
                                          (PROPrice1-NormalPrice).ToString("###,###.##"),//Special Price
                                          PROPrice1.ToString("###,###.##"),//PriceTotal
                                          
                                           //customerType == "CNT"||customerType == "CNM" ?double.Parse( item.Cells["MS_CLPrice"].Value+"").ToString("###,###.##") :double.Parse( item.Cells["MS_CAPrice"].Value+"").ToString("###,###.##"),//Price/Unit
                                           //customerType == "CNT"||customerType == "CNM" ?double.Parse( item.Cells["MS_CLPrice"].Value+"").ToString("###,###.##") :double.Parse( item.Cells["MS_CAPrice"].Value+"").ToString("###,###.##"),//PriceTotal
                                           "",//Other
                                           "",//ExpireDate
                                           false,//comp
                                           false,//subject
                                           "",//false,//mkt b
                                           "",//false,//gif
                                           "",//GiftNumber
                                          false,//BeforeAfter
                                          false,//Extras_sale
                                          false,//VIP
                                           tabTyp,
                                           item.Cells["FeeRate"].Value+"",
                                           item.Cells["FeeRate2"].Value+"",
                                           "",
                                           imageList1.Images[0]
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
        List<Entity.SupplieTrans> listSup = new List<Entity.SupplieTrans>();
        List<DataGridViewRow> rowsToDelete = new List<DataGridViewRow>();
        foreach (DataGridViewRow row in dataGridViewSelectList.Rows)
        {
            DataGridViewCheckBoxCell chk = row.Cells[0] as DataGridViewCheckBoxCell;
            if (MoSubType == "PRO" && PROCredit!="Y")
            {
                rowsToDelete.Add(row);
                if (FormType == DerUtility.AccessType.Update)
                {
                    Entity.SupplieTrans supplieInfo = new Entity.SupplieTrans();
                    supplieInfo.VN = vn;
                    supplieInfo.SONo = txtSONo.Text;
                    supplieInfo.MS_Code = row.Cells["Code"].Value + "";
                    listSup.Add(supplieInfo);
                }
                lbPromotion.Text = "";
            }
            else
            {
                if (Convert.ToBoolean(chk.Value) == true)
                {
                    rowsToDelete.Add(row);
                    if (FormType == DerUtility.AccessType.Update)
                    {
                        Entity.SupplieTrans supplieInfo = new Entity.SupplieTrans();
                        supplieInfo.VN = vn;
                        supplieInfo.SONo =txtSONo.Text;
                        supplieInfo.MS_Code = row.Cells["Code"].Value + "";
                        listSup.Add(supplieInfo);
                    }
                }
            }
        }
        //if (listSup.Any())
        //{
            int? statusDel = new Business.MedicalSupplies().DeleteSupplies(listSup.ToArray());

            //if (statusDel == 1)
            //{
          
            foreach (DataGridViewRow row in rowsToDelete)
                dataGridViewSelectList.Rows.Remove(row);
            
        SumPriceMedicalOrder();
           
            if (dataGridViewSelectList.RowCount == 0)
            {
                if (FormType == DerUtility.AccessType.Update)
                {

                }
                else
                {
                    tabTypShortName = MoSubType = "";
                    if (txtMO.Text.Length > 0) txtMO.Text = txtMO.Text.Remove(2, 3);
                    if (txtSONo.Text.Length > 0) txtSONo.Text = txtSONo.Text.Remove(2, 3);
                }


            }
        //}
    }
       
        private void txtFindHair_Enter(object sender, EventArgs e)
        {

        }

        private void txtFindHair_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BindDataHairList();
            }
        }

        private void txtFindAes_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BindDataAesList();
            }
        }

        private void txtFindTreatment_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BindDataTreatmentList();
            }
        }

        private void txtFindSurgery_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BindDataSurgeryList();
            }
        }
        private void txtWellness_Antiaging_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BindDataWellness_antiAgentList();
            }
        }
        private void txtFindPharmacy_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BindDataPharmacyList();
            }
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(CN))
            {
                if (DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirmYesNo, "หากคุณเปลี่ยนแปลง \"ชื่อลูกค้า \" รายการที่เลือกจะถูกยกเลิก \n\rคุณต้องการเปลี่ยนใช่หรือไม่?") == DialogResult.Yes)
                {
                    RemoveDgvRows(dataGridViewSelectList);
                    txtPriceTotal.Text = "0.00";
                }
                else return;
            }
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

        private void dataGridViewSelectList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                double dblAmount=0;
                double dbNumPerC = 0;
                double dbPricePerU = 0;
                 double dblTotal = 0;
                 double SPPrice = 0;
                 string[] AmountaArr = (dataGridViewSelectList.Rows[e.RowIndex].Cells["Price/Unit"].Value + "").Split(':');
                if (AmountaArr.Length > 1)
                {
                   
                    foreach (var s in AmountaArr)
                    {
                        //dblAmount = s == "" ? 0 : double.Parse(s);
                        //dbNumPerC = dataGridViewSelectList.Rows[e.RowIndex].Cells["No./Course"].Value + "" == "" ? 0 : double.Parse(dataGridViewSelectList.Rows[e.RowIndex].Cells["No./Course"].Value + "");
                        //dbPricePerU = dataGridViewSelectList.Rows[e.RowIndex].Cells["Price/Unit"].Value + "" == "" ? 0 : double.Parse(dataGridViewSelectList.Rows[e.RowIndex].Cells["Price/Unit"].Value + "");
                        //string[] dblTotalArr = (dataGridViewSelectList.Rows[e.RowIndex].Cells["PriceTotal"].Value + "").Split(':');
                        dblTotal += (s=="" ? 0 : double.Parse(s));
                    }
                  
                }
                else
                {
                    dblAmount = dataGridViewSelectList.Rows[e.RowIndex].Cells["Amount"].Value + "" == "" ? 0 : double.Parse(dataGridViewSelectList.Rows[e.RowIndex].Cells["Amount"].Value + "");
                    dbNumPerC = dataGridViewSelectList.Rows[e.RowIndex].Cells["No./Course"].Value + "" == "" ? 0 : double.Parse(dataGridViewSelectList.Rows[e.RowIndex].Cells["No./Course"].Value + "");
                    dbPricePerU = dataGridViewSelectList.Rows[e.RowIndex].Cells["Price/Unit"].Value + "" == "" ? 0 : double.Parse(dataGridViewSelectList.Rows[e.RowIndex].Cells["Price/Unit"].Value + "");
                    SPPrice = dataGridViewSelectList.Rows[e.RowIndex].Cells["SpecialPrice"].Value + "" == "" ? 0 : double.Parse(dataGridViewSelectList.Rows[e.RowIndex].Cells["SpecialPrice"].Value + "");
                    
                    dataGridViewSelectList.Rows[e.RowIndex].Cells["Total"].Value = dblAmount * dbNumPerC; //จำนวนทั้งหมด
                    double pritotal = (dblAmount * dbPricePerU) + SPPrice;
                    dataGridViewSelectList.Rows[e.RowIndex].Cells["PriceTotal"].Value =pritotal==0?"0": pritotal.ToString("###,###.##"); //ราคารวม

                    //Set Format 
                    dataGridViewSelectList.Rows[e.RowIndex].Cells["Amount"].Value =dblAmount==0?"0":dblAmount.ToString("###,###");

                    string strOther = dataGridViewSelectList.Rows[e.RowIndex].Cells["Other"].Value + "";
                    if(!string.IsNullOrEmpty(strOther))
                    {
                        dataGridViewSelectList.Rows[e.RowIndex].Cells["Other"].Value =  double.Parse(strOther).ToString("###,###.##");
                    }

                }
               // string dateExpire = dataGridViewSelectList.Rows[e.RowIndex].Cells["ExpireDate"].Value+"";
               //if(dateExpire.Length>0) dataGridViewSelectList.Rows[e.RowIndex].Cells["ExpireDate"].Value =ToMaskedExpireString(dataGridViewSelectList.Rows[e.RowIndex].Cells["ExpireDate"].Value.ToString());

                SumPriceMedicalOrder();

                DataGridViewComboBoxColumn chCom = new DataGridViewComboBoxColumn();
               //string  cboMKT = dataGridViewSelectList.Rows[e.RowIndex].Cells["MKTBudget"].Value+"";
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, "เกิดข้อผิดพลาดในการแสดงข้อมูล เนื่องจาก " + ex.Message);
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
        private void SumPriceMedicalOrder()
        {
            try
            {
                if (dataGridViewSelectList.Rows.Count == 0)
                {
                    ProCreditRemain = ProCreditMoney;
                   // return;
                }
                SalePriceNew = 0;
                SumMS_Price = 0;
                SumDiscount = 0;
                ////ราคารวม procredit
                ////SalePriceNew = dataGridViewSelectList.Rows.Cast<DataGridViewRow>().Sum(row => row.Cells["PriceTotal"].Value + "" == "" ? 0 : decimal.Parse(row.Cells["PriceTotal"].Value + ""));
                foreach (DataGridViewRow row in dataGridViewSelectList.Rows)
                {
                    if (row.Visible)
                    {
                        SalePriceNew += row.Cells["PriceTotal"].Value + "" == "" ? 0 : decimal.Parse(row.Cells["PriceTotal"].Value + "");
                        SumMS_Price += row.Cells["Price/Unit"].Value + "" == "" ? 0 : decimal.Parse(row.Cells["Price/Unit"].Value + "");
                        SumDiscount += row.Cells["SpecialPrice"].Value + "" == "" ? 0 : decimal.Parse(row.Cells["SpecialPrice"].Value + "");
                    }

                }

                if (ProCreditMoney > SumMS_Price && SumMS_Price!=0)
                {
                    dataGridViewSelectList.Rows.RemoveAt(dataGridViewSelectList.Rows.Count - 1);
                    MessageBox.Show("ราคาน้อยกว่าวงเงินที่กำหนด","Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ProCreditRemain = ProCreditMoney - SumMS_Price;
                
                //lbProCredit.Text = string.Format("ยอดเงินคงเหลือ/Credit {0} บาท/Bth.", (ProCreditMoney-SalePriceNew) == 0 ? "0" : (ProCreditMoney-SalePriceNew).ToString("###,###,###.##"));
                lbProCredit.Text = string.Format("ยอดเงินคงเหลือ/Credit ({0}/{1}) บาท/Bth.", (ProCreditRemain) <= 0 ? "0" : (ProCreditRemain).ToString("###,###,###.##"), ProCreditMoney.ToString("###,###,###.##"));
                txtPriceTotal.Text = SalePriceNew == 0 ? "0" : SalePriceNew.ToString("###,###,###.##");
            }
            catch (Exception ex)
            {
               
            }
        
        }
        //private void CallFormRef(Statics.CallMode cMode)
        //{
        //    Statics.frmMedicalOrderSetting = new FrmMedicalOrderSetting();
        //    if (cMode == Statics.CallMode.Preview)
        //    {
        //        Statics.frmMedicalOrderSetting.FormType = Utility.AccessType.DisplayOnly;
        //        Statics.frmMedicalOrderSetting.Text = Text + Statics.StrPreview;
        //    }
        //    else if (cMode == Statics.CallMode.Update)
        //    {
        //        Statics.frmMedicalOrderSetting.FormType = Utility.AccessType.Update;
        //        Statics.frmMedicalOrderSetting.Text = Text + Statics.StrEdit;
        //    }
        //    else if (cMode == Statics.CallMode.Ref)
        //    {
        //        Statics.frmMedicalOrderSetting.FormType = Utility.AccessType.Insert;
        //        Statics.frmMedicalOrderSetting.Text = Text + Statics.StrNewRow;
        //        Statics.frmMedicalOrderSetting.SORef = txtSONo.Text;
        //        Statics.frmMedicalOrderSetting.ProCreditRemain = ProCreditRemain;
        //        Statics.frmMedicalOrderSetting.RefCN = CN;
        //        Statics.frmMedicalOrderSetting.RefCN_Name = txtCustomerName.Text;
        //        Statics.frmMedicalOrderSetting.ProCreditMoney = ProCreditRemain;
        //        Statics.frmMedicalOrderSetting.PRO_Name = PRO_Name;
        //        Statics.frmMedicalOrderSetting.PRO_Code = PRO_Code;
        //        Statics.frmMedicalOrderSetting.customerType = customerType;
        //        Statics.frmMedicalOrderSetting.PROCreditProductGroup = PROCreditProductGroup;
        //        Statics.frmMedicalOrderSetting.PROCredit = PROCredit;
                
                
        //    }
        //    //Statics.frmMedicalOrderSetting.VN = dgvData.Rows[rowIndex].Cells["VN"].Value + "";
        //    //if(dgvData.Rows[rowIndex].Cells["VN"].Value + ""=="")
        //    //Statics.frmMedicalOrderSetting.SO = dgvData.Rows[rowIndex].Cells["SONo"].Value + "";

        //    Statics.frmMedicalOrderSetting.BackColor = Color.FromArgb(255, 230, 217);
        //    Statics.frmMedicalOrderSetting.Show(Statics.frmMain.dockPanel1);
        //}

        private void btnSave_Click(object sender, EventArgs e)
        {
               if (DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirm, "ยืนยันการบันทึกข้อมูล") == DialogResult.OK)
                {
                    if (string.IsNullOrEmpty(CN))
                    {
                        DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "กรุณาระบุ \"ชื่อลูกค้า \" ก่อนทำการบันทึกข้อมูล");
                        return;
                    }
                    SaveMedical();
               }
        }
        private void SaveMedical()
        {
            try
            {
                int? intStatus = 0;
                Entity.MedicalOrder info;
                Entity.SupplieTrans supplieInfo;
                Entity.MedicalOrderDoc medDocInfo;
                List<Entity.SupplieTrans> listSuppleTrans = new List<Entity.SupplieTrans>();
                List<Entity.MedicalOrderDoc> listMedicalOrderDoc = new List<Entity.MedicalOrderDoc>();
             
                        info = new Entity.MedicalOrder();
                        info.CN = CN;

                        info.CreateBy = Userinfo.EN;
                        info.Remark = "";
                        info.SalePrice = decimal.Parse(txtPriceTotal.Text.Trim());
                        info.MedStatus_Code = MedStatus_Code;
                        info.EM_COM1 = comboBoxCommission1.SelectedValue + "";
                        info.EM_COM2 = comboBoxCommission2.SelectedValue + "";
                        info.MOType = MOType;
                        info.PRO_Code = PRO_Code;
                        List<string> LsMS_Code = new List<string>();
                        foreach (DataGridViewRow item in dataGridViewSelectList.Rows)
                        {
                            LsMS_Code.Add(item.Cells["Code"].Value + "");
                            string[] CodeArr = (item.Cells["Code"].Value + "").Split(':');
                            string[] AmountArr = (item.Cells["Amount"].Value + "").Split(':');
                            string[] UsedArr = (item.Cells["Used"].Value + "").Split(':');
                            string[] OtherArr = (item.Cells["Other"].Value + "").Split(':');
                            if (CodeArr.Length > 1)
                            {
                                for (int i = 0; i < CodeArr.Length; i++)
                                {
                                    supplieInfo = new Entity.SupplieTrans();
                                    supplieInfo.MS_Code = CodeArr[i];
                                    supplieInfo.SONo = txtSONo.Text;
                                    supplieInfo.Amount = decimal.Parse(AmountArr[i]);
                                    //DataGridViewCheckBoxCell chk = item.Cells["ChkUse"] as DataGridViewCheckBoxCell;
                                    bool chk = true;
                                    supplieInfo.FlagUse = Convert.ToBoolean(chk) == false ? "1" : "0"; //1 = ใช้เลย 0 ยังไม่ใช้
                                    //supplieInfo.NumOfUse = Convert.ToBoolean(chk) == false  // yai  comment
                                    //                           ? decimal.Parse(AmountArr[i])
                                    //                           : decimal.Parse(UsedArr[i]);

                                    supplieInfo.NumOfUse = 0;// decimal.Parse(AmountArr[i]);


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
                                    listSuppleTrans.Add(supplieInfo);
                                }
                            }
                            else
                            {
                                supplieInfo = new Entity.SupplieTrans();
                                supplieInfo.MS_Code = item.Cells["Code"].Value + "";
                                supplieInfo.Amount = item.Cells["Amount"].Value + "" == "" ? 0 : decimal.Parse(item.Cells["Amount"].Value + "");
                                //DataGridViewCheckBoxCell chk = item.Cells["ChkUse"] as DataGridViewCheckBoxCell;
                                bool chk = true;
                                supplieInfo.FlagUse = Convert.ToBoolean(chk) == false ? "1" : "0"; //1 = ใช้เลย 0 ยังไม่ใช้
                                supplieInfo.NumOfUse = Convert.ToBoolean(chk) == false
                                    ? item.Cells["Amount"].Value + "" == "" ? 0 : decimal.Parse(item.Cells["Amount"].Value + "")
                                    : item.Cells["Used"].Value + "" == "" ? 0 : decimal.Parse(item.Cells["Used"].Value + "");
                                if (!string.IsNullOrEmpty(item.Cells["Other"].Value + ""))
                                {
                                    supplieInfo.FreeAmount = item.Cells["Other"].Value + "" == "" ? 0 : decimal.Parse(item.Cells["Other"].Value + "");
                                }
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

                                supplieInfo.MergStatus = item.Cells["Code"].Value + "";
                                try
                                {
                                    supplieInfo.FeeRate = Convert.ToDouble(string.IsNullOrEmpty(item.Cells["FeeRate"].Value + "") ? "0" : item.Cells["FeeRate"].Value + "");
                                    supplieInfo.FeeRate2 = Convert.ToDouble(string.IsNullOrEmpty(item.Cells["FeeRate2"].Value + "") ? "0" : item.Cells["FeeRate2"].Value + "");
                                }
                                catch (Exception)
                                {
                                }
                                supplieInfo.SpecialPrice = Convert.ToDouble(string.IsNullOrEmpty(item.Cells["SpecialPrice"].Value + "") ? "0" : item.Cells["SpecialPrice"].Value + "");
                                supplieInfo.MS_Price = Convert.ToDouble(string.IsNullOrEmpty(item.Cells["Price/Unit"].Value + "") ? "0" : item.Cells["Price/Unit"].Value + "");

                                supplieInfo.Note = item.Cells["Note"].Value + "";
                                supplieInfo.ExpireDate = item.Cells["ExpireDate"].Value + "";
                                listSuppleTrans.Add(supplieInfo);
                            }
                        }

                        foreach (DataGridViewRow item in dgvFile.Rows)
                        {
                            if (item.Cells["NewRow"].Value + "" == "True")
                            {
                                medDocInfo = new Entity.MedicalOrderDoc();
                                medDocInfo.FileName = item.Cells["FileName"].Value + "";
                                medDocInfo.FilePath = item.Cells["FilePath"].Value + "";
                                medDocInfo.Detail = item.Cells["Detail"].Value + "";
                                listMedicalOrderDoc.Add(medDocInfo);
                            }
                        }
                        info.SupplieTransInfo = listSuppleTrans.ToArray();
                        //info.MedicalStuffInfo = MedicalStuffs.ToArray();
                        info.MedicalOrderDocInfo = listMedicalOrderDoc.ToArray();
                        //info.MedicalOrderUseTransesInfo = MedicalOrderUseTranss.ToArray();
                        info.VN = this.txtMO.Text.Trim();
                        this.VN = this.MO = this.txtMO.Text.Trim();

                        info.PriceTotalRef = (this.txtBalanceRef.Text.Trim() == "") ? 0M : Convert.ToDecimal(this.txtBalanceRef.Text.Replace(",", ""));

                        info.SORef = txtSoRef.Text.Trim();

                        info.ListMS_Code = LsMS_Code;
                        info.AgenMemId = txtAgenMemID.Text.Trim();
                        info.UpdateBy = Userinfo.EN;
                        info.CreateDate = dateTimePickerCreate.Value;
                        info.UpdateDate = dateTimePickerCreate.Value;
                        info.SONo = txtSONo.Text;
                        info.EN_COMS1 = comboBoxCommission1.SelectedValue + "";
                        info.EN_COMS2 = comboBoxCommission2.SelectedValue + "";
                        // group member
                        info.dicMembersTran = dicMemberTran;
                        info.VNRef = this.txtSoRef.Text;

                        //if (string.IsNullOrEmpty(vn))
                        //{
                        intStatus = new Business.MedicalOrder().InsertMedicalOrder(info);
                        //}
                        //else
                        //{
                        //    info.VN = vn;
                        //    intStatus = new Business.MedicalOrder().UpdateMedicalOrder(info);
                        //}
                        if (intStatus > 0)
                        {
                            foreach (Entity.MedicalOrderDoc medicalOrderDoc in info.MedicalOrderDocInfo)
                            {
                                if (BrowseFile.MovefileOther(medicalOrderDoc.FilePath, "MEDICALDOC", medicalOrderDoc.FileName))
                                {

                                }
                                else
                                {
                                    MessageBox.Show("Save Image Fail.");
                                }
                            }

                            if (!OverProCredit) DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, Statics.SaveComplete);

                            Statics.frmMedicalOrderList.BindDataMedicalOrder(1);
                            this.Close();
                        }
                 
                
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

        private void FrmMedicalOrderSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics.frmMedicalOrderSetting = null;
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
                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "กรุณาระบุชื่อไฟล์");
                    return;
                }
                object[] myItems = {
                                       txtFilePath.Text,
                                       Path.GetFileName(txtFilePath.Text),
                                       txtFileName.Text,
                                       imageList1.Images[1],
                                       imageList1.Images[2],
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
                    if (DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirm, "ยืนยันการลบไฟล์") == DialogResult.OK)
                    {
                        string Id = dgvFile.Rows[e.RowIndex].Cells["Id"].Value + "";
                        string fnameFullFath = Properties.Settings.Default.ImagePathServer + "\\MEDICALDOC\\" +
                                               dgvFile.Rows[e.RowIndex].Cells["FileName"].Value + "";
                        //BrowseFile.Deletefile(fnameFullFath);
                        var intStatus = new Business.MedicalOrder().DeleteFileName(Id,"");
                        dgvFile.Rows.RemoveAt(e.RowIndex);
                    }
                }
                if (e.ColumnIndex == 4)
                {
                    string filePath = Properties.Settings.Default.ImagePathServer + "\\MEDICALDOC\\" + dgvFile.Rows[e.RowIndex].Cells["FileName"].Value + "";
                    if (File.Exists(filePath))
                        Process.Start(filePath);
                    else MessageBox.Show("File not found.");
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
            Statics.frmMedicalOrderSetting = null;
            this.Close();
        }

        private void dataGridViewSelectList_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                if (e.ColumnIndex == dataGridViewSelectList.Columns["ExpireDate"].Index)
                {
                    PopDateTime pp = new PopDateTime();
                    DateTime d;
                    pp.SelecttDate =DateTime.TryParse(dataGridViewSelectList.Rows[e.RowIndex].Cells["ExpireDate"].Value+"",out d)?d:DateTime.Now;
                    //pp.SelecttDate =Convert.ToDateTime(pp.SelecttDate.ToString("dd/MM/yyyy"));
                    if (pp.ShowDialog() == DialogResult.OK)
                    {
                        dataGridViewSelectList.Rows[e.RowIndex].Cells["ExpireDate"].Value = pp.SelecttDate.Date.ToString("dd/MM/yyyy");
                    }

                }

                if ((e.ColumnIndex == dataGridViewSelectList.Columns["ChkMove"].Index
               || e.ColumnIndex == dataGridViewSelectList.Columns["ChkUse"].Index
               || e.ColumnIndex == dataGridViewSelectList.Columns["ChkCom"].Index
               || e.ColumnIndex == dataGridViewSelectList.Columns["ChkBeforeAfter"].Index
               || e.ColumnIndex == dataGridViewSelectList.Columns["ChkSub"].Index
               || e.ColumnIndex == dataGridViewSelectList.Columns["ChkVIP"].Index
               ) && e.RowIndex != -1)
                {
                    dataGridViewSelectList.EndEdit();
                }
               
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
                            DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "ไม่สามารถรวมรายการได้ เนื่องจาก \"รายการไม่ใช่หมวดเดียวกัน\"");
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
                            DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "ไม่สามารถรวมรายการได้ เนื่องจาก \"รายการไม่ใช่หมวดเดียวกัน\"");
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
                PopAgencySearch obj = new PopAgencySearch();
                obj.StartPosition = FormStartPosition.CenterScreen;
                obj.WindowState = FormWindowState.Normal;
                obj.BackColor = Color.FromArgb(255, 230, 217);
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

        private void pictureBoxRefreshProduct_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Update Product",pictureBoxRefreshProduct);
        }

        private void pictureBoxRefreshProduct_Click(object sender, EventArgs e)
        {
            try
            {
                BindDataHairList();
                BindDataAesList();
                BindDataTreatmentList();
                BindDataSurgeryList();
                BindDataWellness_antiAgentList();
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

                    if (PROCredit == "Y")
                    {
                        //tabControl.TabPages.Insert(0, tabPromotion);

                        tabControl.TabPages.Insert(0, tabWellness_Antiaging);
                        tabControl.TabPages.Insert(0, tabSurgery);
                        tabControl.TabPages.Insert(0, tabAesthetic);
                        tabControl.TabPages.Remove(tabPromotion);
                        tabControl.SelectedIndex = 0;
                        dataGridViewSelectList.Rows[0].Visible = false;
                    }
                }
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
                txtMO.Enabled = !radioButtonSO.Checked;
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
                        tabControl.TabPages.Insert(0,tabPromotion);
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
        private void ControlTab(RadioButton rd,bool chk)
        {
            try 
	        {
                radioAE.Checked = false;
                radioSU.Checked = false;
                radioWE.Checked = false;
                radioPRO.Checked = false;
                rd.Checked = chk;
                switch (rd.Text.ToUpper())
                {
                    case "AE":
                        MoSubType = "AE";
                        DisableTab(tabAesthetic);
                        break;
                    case "SU":
                        MoSubType = "SU";
                        DisableTab(tabSurgery);
                        break;
                    case "WE":
                        MoSubType = "WE";
                        DisableTab(tabWellness_Antiaging);
                        break;
                    case "PRO":
                        MoSubType = "PRO";
                        DisableTab(tabPromotion);
                        break;
                }
                dataGridViewSelectList.Rows.Clear();

                if (FormType != DerUtility.AccessType.Update)
                {
                    moso = radioButtonMO.Checked ? "MO-" : "SO-";
                    this.idMax = UtilityBackEnd.GenMaxSeqnoValues(moso + MoSubType + "-");
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
            ControlTab(radioPRO, radioPRO.Checked);
        }

        private void dgvPromotionList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPromotionList.Rows.Count < 0 || dgvPromotionList.CurrentRow == null) return;
            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
            ch1 = (DataGridViewCheckBoxCell)dgvPromotionList.Rows[dgvPromotionList.CurrentRow.Index].Cells[0];
            if (dgvPromotionList.CurrentCell.ColumnIndex != 0) return;
            foreach (DataGridViewRow item in dgvPromotionList.Rows)
            {
                item.Cells[0].Value = false;
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
        }

        private void dgvPromotionList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

    

      

     
         

    }
}

