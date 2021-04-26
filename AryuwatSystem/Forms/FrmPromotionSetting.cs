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


namespace AryuwatSystem.Forms
{
    public partial class FrmPromotionSetting : DockContent, IForm
    {

        public FrmPromotionSetting()
        {
            InitializeComponent();
        }

        public FrmPromotionSetting(ref Entity.Customer info)
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
          
        private string vn = "";
        private string so = "";
        private string Pro_Code;

        List<string> LsSelectMS_Code = new List<string>();
        private string docFilePath;
        List<DataGridViewRow> rowsToDelete=new List<DataGridViewRow>();
        //DataGridView dataGridToDelete=new DataGridView();
        public List<Entity.MedicalStuff> MedicalStuffs { get; set; }
        public List<Entity.MedicalOrderUseTrans> MedicalOrderUseTranss{ get; set; }
        public DerUtility.AccessType FormType { get; set; }
        public string RefVN { get; set; }
        private Dictionary<string,List<Entity.MembersTrans>> dicMemberTran = new Dictionary<string,List<Entity.MembersTrans>> ();
        public string MS_Code="";
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
          

              private void DisableTab(TabPage enableTab)
              {
                  try
                  {
                      if (enableTab == null)
                      {
                          tabControl.TabPages.Remove(tabAesthetic);
                          tabControl.TabPages.Remove(tabSurgery);
                          tabControl.TabPages.Remove(tabWellness_Antiaging);
                      }
                      else
                      {
                          tabControl.TabPages.Remove(tabAesthetic);
                          tabControl.TabPages.Remove(tabSurgery);
                          tabControl.TabPages.Remove(tabWellness_Antiaging);
                          tabControl.TabPages.Insert(0, enableTab);
                          tabControl.SelectedTab = enableTab;
                      }
                      
                  }
                  catch (Exception)
                  {
                      
                      throw;
                  }
              }
              private void FrmPromotionSetting_Load(object sender, EventArgs e)
              {
                  try
                  {
                      this.toolTip1.SetToolTip(this.pictureBoxRefreshProduct, "Update Product");
                      this.dataGridViewSelectList.CellEndEdit += new DataGridViewCellEventHandler(this.dataGridViewSelectList_CellEndEdit);
                      this.dataGridViewSelectList.CellMouseUp += new DataGridViewCellMouseEventHandler(this.dataGridViewSelectList_CellMouseUp);
                      this.dataGridViewSelectList.CellContentClick += new DataGridViewCellEventHandler(this.dataGridViewSelectList_CellContentClick);
                      this.dataGridViewSelectList.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(this.dataGridViewSelectList_EditingControlShowing);
                      this.dataGridViewSelectList.RowPostPaint += new DataGridViewRowPostPaintEventHandler(this.dataGridViewSelectList_RowPostPaint);
                      this.btnSave.Click += new EventHandler(this.btnSave_Click);
                      this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
                      foreach (DataRow row in Userinfo.UnitName.Rows)
                      {
                          this.lsUnit.Add(row["UnitName"]+"");
                      }
                      this.SetColumnsDgv();
                   
                      this.MedicalStuffs = new List<Entity.MedicalStuff>();
                      this.MedicalOrderUseTranss = new List<Entity.MedicalOrderUseTrans>();
                      this.dateTimePickerEnd.Value = DateTime.Now;
                      this.BindDataAesList();
                      this.BindDataSurgeryList();
                      this.BindDataWellness_antiAgentList();
                      this.BindDataPharmacyList();
                      BindSurgicalFeeType();
                     // this.BindDataPromotionList();
                      if (FormType == DerUtility.AccessType.Update)
                      {
                   
                          this.BindData();
                      }
                      else 
                      {
                          this.idMax = UtilityBackEnd.GenMaxSeqnoValues(moso);
                          this.txtPro_Code.Text = this.idMax;
//                          this.idMax = this.idMax.Replace(moso, "").Replace("PRO", "");
                        
                          //this.BindDataAesList();
                          //this.BindDataSurgeryList();
                          //this.BindDataWellness_antiAgentList();
                          //this.BindDataPharmacyList();

                          //tabControl.TabPages.Remove(tabSurgery);

                          //tabControl.TabPages.Remove(tabWellness_Antiaging);
                        
                      }
                        tabControl.TabPages.Remove(tabAesthetic);
                        tabControl.TabPages.Remove(tabSurgery);
                        tabControl.TabPages.Remove(tabWellness_Antiaging);
                        tabControl.TabPages.Remove(tabAttachFile);

                     
                  }
                  catch (Exception exception)
                  {
                      MessageBox.Show(exception.Message);
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
            Entity.Promotion info=new Entity.Promotion() ;
            info.QueryType = "SEARCHBYID";
            info.PRO_Code = PRO_Code;
            DataTable dt = new Business.Promotion().SelectPromotionPaging(info).Tables[0];
            if (dt == null || dt.Rows.Count <= 0) return;
            txtPro_Code.Text = dt.Rows[0]["PRO_Code"] + "";
            //txtPro_Code.ReadOnly = true;
            txtPro_Name.Text = dt.Rows[0]["PRO_Name"] + "";
            dateTimePickerStart.Value = dt.Rows[0]["DateStart"] + "" == "" ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["DateStart"] + "");
            dateTimePickerEnd.Value = dt.Rows[0]["DateEnd"] + "" == "" ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["DateEnd"] + "");
            checkBoxActive.Checked = dt.Rows[0]["PRO_Active"] + ""=="Y";
            txtRemark.Text = dt.Rows[0]["Remark"] + "";
            cboSurgicalFeeTyp.Text = dt.Rows[0]["PRO_Dept"] + "" == "" ? "ALL" : dt.Rows[0]["PRO_Dept"] + "";
            AddDownToGrid("AESTHETIC", dt);
            AddDownToGrid("SURGERY", dt);
            AddDownToGrid("WELLNESS", dt);
            AddDownToGrid("PHARMACY", dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
      
        private void AddDownToGrid(string tabPageActive,DataTable dt)
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
                }

                decimal MS_CLPrice = 0;
                decimal MS_CAPrice = 0;
                string MS_Price = "0";
                decimal MS_PriceSpacial = 0;
                decimal MS_PriceTotal = 0;
                decimal Amount = 0;
                foreach (DataRow ms in dt.Rows)
                {
               
                    foreach (DataGridViewRow item in dv.Rows)
                    {
                        if(item.Cells["Code"].Value.ToString().ToUpper().Equals(ms["MS_Code"].ToString().ToUpper()))
                        {
                            //if (LsSelectMS_Code.Contains(ms["MS_Code"].ToString())) continue;
                            //else 
                                LsSelectMS_Code.Add(ms["MS_Code"].ToString());
                            MS_CLPrice = item.Cells["MS_CLPrice"].Value + "" == "" ? 0 : decimal.Parse(item.Cells["MS_CLPrice"].Value + "");
                            MS_CAPrice = item.Cells["MS_CAPrice"].Value + "" == "" ? 0 : decimal.Parse(item.Cells["MS_CAPrice"].Value + "");
                            MS_PriceTotal = ms["MS_ProPrice"] + "" == "" ? 0 : decimal.Parse(ms["MS_ProPrice"] + "");
                            Amount = ms["Amount"] + "" == "" ? 1 : decimal.Parse(ms["Amount"] + "");
                            MS_Price = MS_CLPrice.ToString("###,###,###.##");// Entity.Userinfo.PriceNormal.Contains(customerType) ? MS_CLPrice.ToString("###,###.##") : MS_CAPrice.ToString("###,###.##");
                            MS_PriceSpacial = MS_PriceTotal-(MS_CLPrice * Amount) ;
                            object[] myItems = {
                                             false,//chk
                                           item.Cells["Code"].Value,
                                           item.Cells["Name"].Value,
                                           item.Cells["MS_Number_C"].Value,//Num/Couse
                                           ms["Amount"]+"",//จำนวนที่ซื้อ
                                           "0",//Total
                                           "0",//Use
                                             item.Cells["UnitName"].Value,//Unit
                                           "0",//Balance
                                          MS_Price,//PricePer
                                          MS_PriceSpacial.ToString("###,###.##"),//Special Price
                                          MS_PriceTotal.ToString("###,###.##"),//PriceTotal
                                          
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

            SetColumnDgvSelectList();
            SetColumnDgvFile();
            //SetColumnsDgvPromotion();
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
        //private void SetColumnsDgvPromotion()
        //{
        //    Utility.SetPropertyDgv(dgvPromotionList);
        //    DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
        //    {
        //        column.Name = "select";
        //        column.AutoSizeMode =
        //            DataGridViewAutoSizeColumnMode.DisplayedCells;
        //        column.FlatStyle = FlatStyle.Standard;
        //        column.ThreeState = false;
        //        column.CellTemplate = new DataGridViewCheckBoxCell();
        //        column.CellTemplate.Style.BackColor = Color.Beige;
        //    }
        //    dgvAestheticList.Columns.Add(column);
        //    dgvPromotionList.Columns.Add("PRO_Code", "PRO_Code");
        //    dgvPromotionList.Columns.Add("PRO_Name", "PRO_Name");
        //    dgvPromotionList.Columns.Add("ProPrice", "Price");
        //    dgvPromotionList.Columns.Add("DateStart", "Start date");
        //    dgvPromotionList.Columns.Add("DateEnd", "Expire date");
        //    dgvPromotionList.Columns.Add("PRO_Active", "Active");
        //    dgvPromotionList.Columns.Add("Remark", "Remark");

        //    dgvPromotionList.Columns["PRO_Code"].Width = 80;
        //    dgvPromotionList.Columns["PRO_Name"].Width = 200;
        //    dgvPromotionList.Columns["ProPrice"].Width = 50;
        //    dgvPromotionList.Columns["DateStart"].Width = 100;
        //    dgvPromotionList.Columns["DateEnd"].Width = 100;
        //    dgvPromotionList.Columns["PRO_Active"].Width = 10;
        //    dgvPromotionList.Columns["Remark"].Width = 200;

        //}

        private void SetColumnDgvAesList()
        {
            DerUtility.SetPropertyDgv(dgvAestheticList);
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            {
                column.Name = "select";
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
            dgvAestheticList.Columns.Add("MS_Detail", "Detail");
            dgvAestheticList.Columns["MS_Detail"].Width = 200;
        }


        private void SetColumnDgvSurgeryList()
        {
            DerUtility.SetPropertyDgv(dgvSurgeryList);
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            {
                column.Name = "select";
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
            dgvSurgeryList.Columns.Add("MS_Detail", "Detail");
            dgvSurgeryList.Columns["MS_Detail"].Width = 200;
        }
        private void SetColumnDgvWellness_AntiagingList()
        {
            DerUtility.SetPropertyDgv(dgvWellness_AntiagingList);
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            {
                column.Name = "select";
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
            dgvWellness_AntiagingList.Columns.Add("MS_Detail", "Detail");
            dgvWellness_AntiagingList.Columns["MS_Detail"].Width = 200;
        }
        private void SetColumnDgvPharmacyList()
        {
            DerUtility.SetPropertyDgv(dgvPharmacyList);
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            {
                column.Name = "select";
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
            dataGridViewSelectList.Columns["Code"].Width = 80;

            dataGridViewSelectList.Columns.Add("Name", "Name");//2
            dataGridViewSelectList.Columns["Name"].ReadOnly = true;
            dataGridViewSelectList.Columns["Name"].Width =300;

            dataGridViewSelectList.Columns.Add("No./Course", "No./Course");//3
            dataGridViewSelectList.Columns["No./Course"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["No./Course"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewSelectList.Columns["No./Course"].ReadOnly = true;
            dataGridViewSelectList.Columns["No./Course"].Width = 80;

            dataGridViewSelectList.Columns.Add("Amount", "Quantity");//4 Amount
            dataGridViewSelectList.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["Amount"].DefaultCellStyle.BackColor = Color.LemonChiffon;
            dataGridViewSelectList.Columns["Amount"].Width = 80;



            dataGridViewSelectList.Columns.Add("Total", "Total");//5
            dataGridViewSelectList.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvHairSelect.Columns["Total"].DefaultCellStyle.BackColor = Color.Black;
            dataGridViewSelectList.Columns["Total"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewSelectList.Columns["Total"].ReadOnly = true;
            dataGridViewSelectList.Columns["Total"].Width = 80;

            dataGridViewSelectList.Columns.Add("Used", "Used");//6
            dataGridViewSelectList.Columns["Used"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvHairSelect.Columns["Used"].DefaultCellStyle.BackColor = Color.Black;
            dataGridViewSelectList.Columns["Used"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewSelectList.Columns["Used"].ReadOnly = true;
            dataGridViewSelectList.Columns["Used"].Visible = false;



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
            dataGridViewSelectList.Columns["Balance"].Width = 80;

            dataGridViewSelectList.Columns.Add("Price/Unit", "Price/Unit");//9
            dataGridViewSelectList.Columns["Price/Unit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["Price/Unit"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewSelectList.Columns["Price/Unit"].ReadOnly = true;
            dataGridViewSelectList.Columns["Price/Unit"].Width = 80;

            dataGridViewSelectList.Columns.Add("SpecialPrice", "Discount");
            dataGridViewSelectList.Columns["SpecialPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["SpecialPrice"].DefaultCellStyle.BackColor = Color.LemonChiffon;
            dataGridViewSelectList.Columns["SpecialPrice"].Visible = true;
            dataGridViewSelectList.Columns["SpecialPrice"].Width = 80;

            dataGridViewSelectList.Columns.Add("PriceTotal", "PriceTotal");//10
            dataGridViewSelectList.Columns["PriceTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["PriceTotal"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewSelectList.Columns["PriceTotal"].ReadOnly = true;
            dataGridViewSelectList.Columns["PriceTotal"].Width = 100;

      
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
            dataGridViewSelectList.Columns["Other"].Visible = false;

            dataGridViewSelectList.Columns.Add("ExpireDate", "ExpireDate");
            dataGridViewSelectList.Columns["ExpireDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["ExpireDate"].DefaultCellStyle.BackColor = Color.LemonChiffon;
            dataGridViewSelectList.Columns["ExpireDate"].Visible = false;
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
            dataGridViewSelectList.Columns["ChkCom"].Visible = false;

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
            dataGridViewSelectList.Columns["ChkSub"].Visible = false;
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
                dataGridViewSelectList.Columns["MKTBudget"].Visible = false;

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
                dataGridViewSelectList.Columns["GiftVoucher"].Visible = false;

                dataGridViewSelectList.Columns.Add("GiftNumber", "GiftNumber");
                dataGridViewSelectList.Columns["GiftNumber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridViewSelectList.Columns["GiftNumber"].DefaultCellStyle.BackColor = Color.LemonChiffon;
                dataGridViewSelectList.Columns["GiftNumber"].Visible = true;
                dataGridViewSelectList.Columns["GiftNumber"].Width = 30;

                dataGridViewSelectList.Columns["GiftNumber"].Visible = false;

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
                dataGridViewSelectList.Columns["ChkBeforeAfter"].Visible = false;

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
                dataGridViewSelectList.Columns["ChkExtras_sale"].Visible = false;
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
                dataGridViewSelectList.Columns["ChkVIP"].Visible = false;

            dataGridViewSelectList.Columns.Add("Tab", "Tab");
            dataGridViewSelectList.Columns["Tab"].Visible = false;
            dataGridViewSelectList.Columns.Add("FeeRate", "FeeRate");
            dataGridViewSelectList.Columns.Add("FeeRate2", "FeeRate2");
            dataGridViewSelectList.Columns["FeeRate"].Visible = false;
            dataGridViewSelectList.Columns["FeeRate2"].Visible = false;

            dataGridViewSelectList.Columns.Add("Note", "Note");//4 Amount
            dataGridViewSelectList.Columns["Note"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["Note"].DefaultCellStyle.BackColor = Color.LemonChiffon;
            dataGridViewSelectList.Columns["Note"].Width = 250;

            DataGridViewImageColumn ColMember = new DataGridViewImageColumn();
            {
                ColMember.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                ColMember.CellTemplate = new DataGridViewImageCell();
                ColMember.Name = "BtnMember";
                ColMember.HeaderText = "Members";
            }
            dataGridViewSelectList.Columns.Add(ColMember);
            dataGridViewSelectList.Columns["BtnMember"].Visible = false;
        }

        void txtExpireDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

       
        //private void BindDataPromotionList()
        //{
        //    try
        //    {
        //        Utility.MouseOn(this);

        //        dgvPromotionList.Rows.Clear();
        //        Entity.MedicalSupplies info = new Entity.MedicalSupplies();
        //        if (!string.IsNullOrEmpty(txtFindAes.Text))
        //        {
        //            //info.MS_Name = "%" + txtFindAes.Text + "%";
        //            info.Tabwhere = "Pro_Code Like '%" + txtFindAes.Text + "%'" + " or Pro_Name Like '%" + txtFindAes.Text + "%'";
        //        }
        //        else
        //        {
        //            info.Tabwhere = "1=1";
        //        }
        //        //info.MS_Section = "ADI";
        //        info.Tab = "PROMOTION";
        //        DataTable dt = new Business.MedicalSupplies().SelectMedicalSuppliesBySection(info).Tables[0];

        //        foreach (DataRowView item in dt.DefaultView)
        //        {
        //            //  PRO_Code
        //            //PRO_Name
        //            //DateStart
        //            //DateEnd
        //            //CreateDate
        //            //CreateBy
        //            //UpdateDate
        //            //UpdateBy
        //            //ProPrice
        //            //PRO_Active
        //            //Remark
        //            object[] myItems = {
        //                                  false,
        //                                  item["PRO_Code"] + "",
        //                                  item["PRO_Name"]+"",
        //                                  string.IsNullOrEmpty(item["ProPrice"] + "") ? "0" : Convert.ToDouble(item["ProPrice"] + "").ToString("###,###,###.##"),
        //                                  item["DateStart"] + "" ,
        //                                  item["DateEnd"] + "" ,
        //                                  item["PRO_Active"] + "" ,
        //                                  item["Remark"] + "" ,
        //                              };

        //            dgvPromotionList.Rows.Add(myItems);

        //            Utility.MouseOff(this);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Utility.PopMsg(Utility.EnuMsgType.MsgTypeError, ex.Message);
        //        Utility.MouseOff(this);
        //        return;
        //    }
        //}
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
                    info.Tabwhere = "Msup.MS_Code Like '%" + txtFindAes.Text + "%'" + " or Msup.MS_Name Like '%" + txtFindAes.Text + "%' or Msup.MS_Detail Like '%" + txtFindAes.Text + "%'";
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
                                          item["MS_Detail"] + ""
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
                    info.Tabwhere = "Msup.MS_Code Like '%" + txtFindSurgery.Text + "%'" + " or Msup.MS_Name Like '%" + txtFindSurgery.Text + "%' or Msup.MS_Detail Like '%" + txtFindSurgery.Text + "%'";
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
                                            ,info.Tab,
                                            item["MS_Detail"] + ""
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
                    info.Tabwhere = "Msup.MS_Code Like '%" + txtWellness_Antiaging.Text + "%'" + " or Msup.MS_Name Like '%" + txtWellness_Antiaging.Text + "%' or Msup.MS_Detail Like '%" + txtWellness_Antiaging.Text + "%'";
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
                                          ,info.Tab,
                                          item["MS_Detail"] + ""
                                         
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
                    info.Tabwhere = "Msup.MS_Code Like '%" + txtFindPharmacy.Text + "%'" + " or Msup.MS_Name Like '%" + txtFindPharmacy.Text + "%' or Msup.MS_Name Like '%" + txtFindPharmacy.Text + "%'";
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
                                          ,info.Tab,
                                          item["MS_Detail"] + ""
                                         
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
        


        //private void buttonRigth6_BtnClick()
        //{
        //    if (string.IsNullOrEmpty(customerType))
        //    {
        //        Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "กรุณาเลือก \"ลูกค้า\" ก่อน");
        //        return;
        //    }
        //    foreach (DataGridViewRow item in dgvHairList.Rows)
        //    {
        //        if ((bool) item.Cells[0].Value == true)
        //        {
        //            object[] myItems = {
        //                                    false,
        //                                   item.Cells[1].Value,
        //                                   item.Cells[2].Value,
        //                                   "1",
        //                                   item.Cells[7].Value,
        //                                   item.Cells[7].Value,
        //                                   "0",
        //                                   item.Cells[7].Value+"",
        //                                   customerType == "CNT"||customerType == "CNM" ?double.Parse( item.Cells["MS_CLPrice"].Value+"").ToString("###,###.##") :double.Parse( item.Cells["MS_CAPrice"].Value+"").ToString("###,###.##"),
        //                                   customerType == "CNT"||customerType == "CNM" ? double.Parse( item.Cells["MS_CLPrice"].Value+"").ToString("###,###.##") :double.Parse( item.Cells["MS_CAPrice"].Value+"").ToString("###,###.##"),
        //                                   //imageList1.Images[0],
        //                                   //false,
        //                                   imageList1.Images[4],"",false,false,false,false,
        //                                   "HAIR"
        //                               };
                    
        //            item.Cells[0].Value = false;

        //            dataGridViewSelectList.Rows.Add(myItems);

        //            SumPriceMedicalOrder();
        //        }
        //    }

        //}

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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                if(e.KeyChar!='-')
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
                frm.CN = Pro_Code;
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
            }
            catch (Exception ex)
            {

            }
        }

        private void buttonAddDown_BtnClick()
        {
        try
        {
            //if (string.IsNullOrEmpty(customerType))
            //{
            //    Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "กรุณาเลือก \"ลูกค้า\" ก่อน");
            //    return;
            //}

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
                case TabPageActive.tabAttachFile:
                    //tabPageActive = TabPageActive.tabAesthetic;
                    break;
            }
           // txtMO.Text = MO = string.Format("MO-{0}{1}", tabTypShortName, idMax);
          //  if (dataGridViewSelectList.RowCount>0 && MoSubType != tabTypShortName) return;

            if (FormType != DerUtility.AccessType.Update)
            {
                //if (radioButtonMO.Checked)
                //    txtMO.Text = txtMO.Text.Replace("-", string.Format("-{0}-", MoSubType));
                //else
                //    txtSONo.Text = txtSONo.Text.Replace("-", string.Format("-{0}-", MoSubType));
                this.idMax = UtilityBackEnd.GenMaxSeqnoValues(moso + MoSubType + "-");
            }
          

            tabTypShortName = MoSubType;
         
            double MS_CLPrice = 0;
            double MS_CAPrice = 0;
            string MS_Price = "0";
            foreach (DataGridViewRow item in dv.Rows)
            {
                if ((bool) item.Cells[0].Value == true)
                {
                        var chkdata = true;
                        foreach (DataGridViewRow data in dataGridViewSelectList.Rows)
                        {
                            if(item.Cells["Code"].Value.ToString() == data.Cells["Code"].Value.ToString())
                            {
                                chkdata = false;
                                data.Cells["Amount"].Value = Convert.ToInt32(data.Cells["Amount"].Value) + 1;
                            }
                        }
                    //if (LsSelectMS_Code.Contains(item.Cells["Code"].Value.ToString())) continue;
                    //else 
                        LsSelectMS_Code.Add(item.Cells["Code"].Value.ToString());
                    MS_CLPrice = item.Cells["MS_CLPrice"].Value + ""==""?0:double.Parse(item.Cells["MS_CLPrice"].Value + "");
                    MS_CAPrice = item.Cells["MS_CAPrice"].Value + "" == "" ? 0 : double.Parse(item.Cells["MS_CAPrice"].Value + "");
                    MS_Price = MS_CLPrice.ToString("###,###,###.##");// Entity.Userinfo.PriceNormal.Contains(customerType) ? MS_CLPrice.ToString("###,###.##") : MS_CAPrice.ToString("###,###.##");
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
                                          "0",//Special Price
                                          MS_Price,//PriceTotal
                                          
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

                    if(chkdata)
                    {
                        dataGridViewSelectList.Rows.Add(myItems);
                    }
                        //dataGridViewSelectList["Unit", dataGridViewSelectList.Rows.Count - 1].Value = "0";
                        //DisplayPayInComboColumn(MKTBudget, dataGridViewSelectList, "MKTBudget");
                        //DisplayPayInComboColumn(GiftVoucher, dataGridViewSelectList, "GiftVoucher");
                    SumPriceMedicalOrder();
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

     
        List<Entity.SupplieTrans> listSup = new List<Entity.SupplieTrans>();
        List<DataGridViewRow> rowsToDelete = new List<DataGridViewRow>();
        foreach (DataGridViewRow row in dataGridViewSelectList.Rows)
        {
            DataGridViewCheckBoxCell chk = row.Cells[0] as DataGridViewCheckBoxCell;
            if (Convert.ToBoolean(chk.Value) == true)
            {
                rowsToDelete.Add(row);

                if (FormType == DerUtility.AccessType.Update)
                {
                    Entity.SupplieTrans supplieInfo = new Entity.SupplieTrans();
                    supplieInfo.VN = vn;
                    supplieInfo.SONo =txtPro_Code.Text;
                    supplieInfo.MS_Code = row.Cells["Code"].Value + "";
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
            LsSelectMS_Code.Remove(row.Cells[1].Value + "");
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
                if (txtPro_Code.Text.Length > 0) txtPro_Code.Text = txtPro_Code.Text.Remove(2, 3);
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

    

        private void txtFindAes_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BindDataAesList();
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
            if(!string.IsNullOrEmpty(Pro_Code))
            {
                if (DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirmYesNo, "หากคุณเปลี่ยนแปลง \"ชื่อลูกค้า \" รายการที่เลือกจะถูกยกเลิก \n\rคุณต้องการเปลี่ยนใช่หรือไม่?") == DialogResult.Yes)
                {
                    RemoveDgvRows(dataGridViewSelectList);
                    txtProPrice.Text = "0.00";
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
                Pro_Code = obj.CN;
        
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
                    SPPrice = dataGridViewSelectList.Rows[e.RowIndex].Cells["SpecialPrice"].Value + "" == "" ? 0 : double.Parse((dataGridViewSelectList.Rows[e.RowIndex].Cells["SpecialPrice"].Value + "").Replace("--", "-").Replace("--", "-").Replace("--", "-"));
                    
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
            SalePriceNew = dataGridViewSelectList.Rows.Cast<DataGridViewRow>().Sum(row => row.Cells["PriceTotal"].Value + ""==""?0:decimal.Parse(row.Cells["PriceTotal"].Value + ""));
            txtProPrice.Text =SalePriceNew==0?"0": SalePriceNew.ToString("###,###.##");
            decimal ProPrice = dataGridViewSelectList.Rows.Cast<DataGridViewRow>().Sum(row => row.Cells["Price/Unit"].Value + "" == "" ? 0 : decimal.Parse(row.Cells["Price/Unit"].Value + "") * (row.Cells["Amount"].Value + ""==""?1:decimal.Parse(row.Cells["Amount"].Value + "")));
            txtTotalPrice.Text = ProPrice == 0 ? "0" : ProPrice.ToString("###,###.##");
            
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            int? intStatus = 0;
            Entity.Promotion info;
            if (DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirm, "ยืนยันการบันทึกข้อมูล") != DialogResult.OK)return;
             
            if (string.IsNullOrEmpty(txtPro_Code.Text)||string.IsNullOrEmpty(txtPro_Name.Text) )
                {
                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "กรุณาระบุ รหัสโปรโมชันและชื่อโปรโมชัน\n Please specify Promotion Codes and Promotion name.");
                    return;
                }
                try
                {
     
     
                    info = new Entity.Promotion();
                    info.PRO_Code = txtPro_Code.Text.Trim();
                    info.PRO_Name=txtPro_Name.Text.Trim();
                    info.DateStart = dateTimePickerStart.Value;
                    info.DateEnd = dateTimePickerEnd.Value;
                    info.CreateDate = DateTime.Now;
                    info.CreateBy = Userinfo.EN;
                    info.UpdateDate = DateTime.Now;
                    info.UpdateBy = Userinfo.EN;
                    info.ProPrice = txtProPrice.Text == "" ? 0 : Convert.ToDecimal(txtProPrice.Text);
                    info.PRO_Active = checkBoxActive.Checked ? "Y" : "N";
                    info.Remark = txtRemark.Text;
                    info.PRO_Type = "";
                    info.PRO_Dept = cboSurgicalFeeTyp.Text;
                    info.ProSupplieInfo = new List<Entity.MedicalSupplies>();
                    
                    
                    foreach (DataGridViewRow item in dataGridViewSelectList.Rows)
                    {
                        Entity.MedicalSupplies supplieInfo = new Entity.MedicalSupplies();
                        supplieInfo.MS_Code = item.Cells["Code"].Value + "";
                        supplieInfo.Amount =item.Cells["Amount"].Value + ""==""?0:decimal.Parse(item.Cells["Amount"].Value + "");
                        supplieInfo.MS_PROPrice = item.Cells["PriceTotal"].Value + "" == "" ? 0 : double.Parse(item.Cells["PriceTotal"].Value + "");
                        info.ProSupplieInfo.Add(supplieInfo);
                    }
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

        private void btnDocument_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabControl.TabPages["tabAttachFile"];
        }

        private void FrmPromotionSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics.frmPromotionSetting = null;
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
            Statics.frmPromotionSetting = null;
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
               /*|| e.ColumnIndex == dataGridViewSelectList.Columns["ChkUse"].Index*/
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
        
                BindDataAesList();
          
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

     

    
        private void ControlTab(RadioButton rd,bool chk)
        {
            try 
	        {
              
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
                }
                dataGridViewSelectList.Rows.Clear();

             


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

        private void txtFindPro_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
              //  BindDataPromotionList();
            }
        }

        private void dataGridViewSelectList_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            

        }


    

      

     
         

    }
}

