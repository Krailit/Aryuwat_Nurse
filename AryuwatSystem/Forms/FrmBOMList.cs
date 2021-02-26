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
    public partial class FrmBOMList : DockContent, IForm
    {

        public FrmBOMList()
        {
            InitializeComponent();
        }

        public FrmBOMList(ref Entity.Customer info)
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
              string CurrentMS_Code = "";
              DataTable dataTableMain = new DataTable();
              DataTable dataTableMaterial = new DataTable();
              List<string> lsMaterialItem = new List<string>();
              bool Dataedit = false;
        Dictionary<string,DataRow>dicMaterialItem =new Dictionary<string,DataRow>();
        
              
              private void FrmBOMList_Load(object sender, EventArgs e)
              {
                  try
                  {
                      
                      this.dataGridViewSelectList.CellContentClick += new DataGridViewCellEventHandler(this.dataGridViewSelectList_CellContentClick);
                      this.dataGridViewSelectList.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(this.dataGridViewSelectList_EditingControlShowing);
                      this.dataGridViewSelectList.RowPostPaint += new DataGridViewRowPostPaintEventHandler(this.dataGridViewSelectList_RowPostPaint);
                      this.dataGridViewMaterial.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dataGridViewMaterial_EditingControlShowing);
                     

                      this.btnSave.Click += new EventHandler(this.btnSave_Click);
                      this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
                      foreach (DataRow row in Userinfo.UnitName.Rows)
                      {
                          this.lsUnit.Add(row["UnitName"]+"");
                      }
                      this.SetColumnsDgv();

                      BindMedicalSupplies(1);
                    
                     
                  }
                  catch (Exception exception)
                  {
                      MessageBox.Show(exception.Message);
                  }
              }

              void dataGridViewMaterial_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
              {
                  try
                  {
                        e.Control.KeyPress -= new KeyPressEventHandler(itemID_KeyPress);//This line of code resolved my issue
                        if (dataGridViewMaterial.CurrentCell.ColumnIndex == dataGridViewMaterial.Columns["Amount"].Index)
                        {
                            TextBox itemID = e.Control as TextBox;
                            if (itemID != null)
                            {
                                itemID.KeyPress += new KeyPressEventHandler(itemID_KeyPress);
                            }
                        }
                  }
                  catch (Exception ex)
                  {
                      MessageBox.Show(ex.Message);
                  }
              }

              public void BindMedicalSupplies(int _pIntseq)
              {
                  try
                  {
                      DerUtility.MouseOn(this);
                      dataGridViewSelectList.DataSource = null;
                      if (dataGridViewMaterial.Rows.Count > 0)
                          dataGridViewMaterial.Rows.Clear();
                      //dataGridViewSelectList.Rows.Clear();
                      //pIntseq = _pIntseq;
                      Entity.MedicalSupplies  info = new Entity.MedicalSupplies() { PageNumber = _pIntseq };
                      //if (!string.IsNullOrEmpty(txtFindCode.Text.Trim()))
                      //{
                      //    info.MS_Code = "%" + txtFindCode.Text + "%";
                      //}
                      //if (!string.IsNullOrEmpty(txtFindName.Text))
                      //{
                      //    info.MS_Name = "%" + txtFindName.Text + "%";
                      //}
                      info.QueryType = "SEARCHBOM";
                      //info.StartDate = DateTime.Now;
                      //info.EndDate = DateTime.Now;
                      info.BranchID = uBranch1.BranchId;

                      DataTable dt = new Business.MedicalSupplies().SelectMedicalSuppliesPaging(info).Tables[0];
                      dataTableMain = dt;
                      long lngTotalPage = 0;
                      long lngTotalRecord = 0;
                      if (dt.Rows.Count <= 0)
                      {
                          //ngbMain.CurrentPage = 0;
                          //ngbMain.TotalPage = 0;
                          //ngbMain.TotalRecord = 0;
                          //ngbMain.Updates();
                          DerUtility.MouseOff(this);
                          //Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "ไม่พบข้อมูลในระบบ");
                          return;
                      }
                  
                      dataGridViewSelectList.DataSource = dataTableMain;
                    
                      dataGridViewSelectList.Columns["MS_CLPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                      dataGridViewSelectList.Columns["MS_CAPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                      dataGridViewSelectList.Columns["MedicalTab"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                      //dataGridViewSelectList.Columns["MS_Number_C"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                      //dataGridViewSelectList.Columns["FeeRate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                      //dataGridViewSelectList.Columns["FeeRate2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                      //dataGridViewSelectList.Columns["MaxDiscount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;

                      //ngbMain.CurrentPage = _pIntseq;
                      //ngbMain.TotalPage = lngTotalPage;
                      //ngbMain.TotalRecord = lngTotalRecord;
                      //ngbMain.Updates();
                      //dataGridViewSelectList.ClearSelection();
                      //dataGridViewSelectList.CurrentCell = null;
                      //dataGridViewSelectList.Rows[0].Selected = false;
                      DataGridViewSelectionMode oldmode = dataGridViewSelectList.SelectionMode;

                      dataGridViewSelectList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                      dataGridViewSelectList.ClearSelection();

                      dataGridViewSelectList.SelectionMode = oldmode;
                      
                      DerUtility.MouseOff(this);
                      //  RefreshText();

                  }
                  catch (Exception ex)
                  {
                      DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                      DerUtility.MouseOff(this);
                      return;
                  }
                  finally
                  {
                      //SetNumberAllRows();
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
     
        private void SetColumnsDgv()
        {
            //SetColumnDgvSelectList();
            SetColumnDgvMaterial();
         
        }

   

      


        private void SetColumnDgvSelectList()
        {
            //Utility.SetPropertyDgv(dgvHairSelect);
            dataGridViewSelectList.AllowUserToAddRows = false;
            //dataGridViewSelectList.DefaultCellStyle.BackColor = Color.DarkGray;
            //DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            //{
            //    column.AutoSizeMode =
            //        DataGridViewAutoSizeColumnMode.DisplayedCells;
            //    column.FlatStyle = FlatStyle.Standard;
            //    column.ThreeState = false;
            //    column.Name = "ChkMove";
            //    column.HeaderText = "";
            //    column.CellTemplate = new DataGridViewCheckBoxCell();
            //    column.CellTemplate.Style.BackColor = Color.LemonChiffon;
            //}
            //dataGridViewSelectList.Columns.Add(column); //0
            dataGridViewSelectList.Columns.Add("MS_Code", "Code");//1
            dataGridViewSelectList.Columns["MS_Code"].ReadOnly = true;

            dataGridViewSelectList.Columns.Add("MS_Name", "Name");//2
            dataGridViewSelectList.Columns["MS_Name"].ReadOnly = true;


            dataGridViewSelectList.Columns.Add("Unit", "Unit");//6
            dataGridViewSelectList.Columns["Unit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvHairSelect.Columns["Used"].DefaultCellStyle.BackColor = Color.Black;
            dataGridViewSelectList.Columns["Unit"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewSelectList.Columns["Unit"].ReadOnly = true;

            //dataGridViewSelectList.Columns.Add("Balance", "Balance");//8
            //dataGridViewSelectList.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ////dgvHairSelect.Columns["Balance"].DefaultCellStyle.BackColor = Color.Black;
            //dataGridViewSelectList.Columns["Balance"].DefaultCellStyle.ForeColor = Color.Blue;
            //dataGridViewSelectList.Columns["Balance"].ReadOnly = true;

            dataGridViewSelectList.Columns.Add("MS_CLPrice", "Price Local");//9
            dataGridViewSelectList.Columns["MS_CLPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["MS_CLPrice"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewSelectList.Columns["MS_CLPrice"].ReadOnly = true;
            dataGridViewSelectList.Columns.Add("MS_CAPrice", "Price Agency");//9
            dataGridViewSelectList.Columns["MS_CAPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["MS_CAPrice"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewSelectList.Columns["MS_CAPrice"].ReadOnly = true;

            dataGridViewSelectList.Columns.Add("MS_Type", "MS_Type");
          
            dataGridViewSelectList.Columns.Add("Note", "Note");//4 Amount
            dataGridViewSelectList.Columns["Note"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["Note"].DefaultCellStyle.BackColor = Color.LemonChiffon;
            dataGridViewSelectList.Columns["Note"].Width = 200;

        }
        private void SetColumnDgvMaterial()
        {
            try
            {

                //DerUtility.SetPropertyDgv(dataGridViewMaterial);
                dataGridViewMaterial.AllowUserToAddRows = false;
                dataGridViewMaterial.AllowUserToDeleteRows = false;
                DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
                {
                    //column.HeaderText = "Selected";
                    //column.Name = "Selected";
                    column.AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.DisplayedCells;
                    column.FlatStyle = FlatStyle.Standard;
                    column.ThreeState = false;
                    column.CellTemplate = new DataGridViewCheckBoxCell();
                    column.CellTemplate.Style.BackColor = Color.Beige;
                }
                dataGridViewMaterial.Columns.Add(column);

            dataGridViewMaterial.Columns.Add("MS_Code", "Code");//1
            dataGridViewMaterial.Columns["MS_Code"].ReadOnly = true;

            dataGridViewMaterial.Columns.Add("MS_Name", "Name");//2
            dataGridViewMaterial.Columns["MS_Name"].ReadOnly = true;

            //dataGridViewSelectList.Columns.Add("Balance", "Balance");//8
            //dataGridViewSelectList.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ////dgvHairSelect.Columns["Balance"].DefaultCellStyle.BackColor = Color.Black;
            //dataGridViewSelectList.Columns["Balance"].DefaultCellStyle.ForeColor = Color.Blue;
            //dataGridViewSelectList.Columns["Balance"].ReadOnly = true;

            dataGridViewMaterial.Columns.Add("Price/Unit", "Price/Unit");//9
            dataGridViewMaterial.Columns["Price/Unit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dataGridViewMaterial.Columns["Price/Unit"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewMaterial.Columns["Price/Unit"].ReadOnly = true;

            
            dataGridViewMaterial.Columns.Add("Amount", "Amount");
            dataGridViewMaterial.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewMaterial.Columns["Amount"].DefaultCellStyle.BackColor = Color.Yellow;
            dataGridViewMaterial.Columns["Amount"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewMaterial.Columns["Amount"].ReadOnly = false;

            dataGridViewMaterial.Columns.Add("Unit", "Unit");
            dataGridViewMaterial.Columns["Unit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvHairSelect.Columns["Used"].DefaultCellStyle.BackColor = Color.Black;
            //dataGridViewMaterial.Columns["Unit"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewMaterial.Columns["Unit"].ReadOnly = true;

            dataGridViewMaterial.Columns.Add("Total", "Total");
            dataGridViewMaterial.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dataGridViewMaterial.Columns["Total"].DefaultCellStyle.BackColor = Color.Yellow;
            dataGridViewMaterial.Columns["Total"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewMaterial.Columns["Total"].ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void txtExpireDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

     

        

        private void dataGridViewSelectList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //try
            //{
            //    if (dataGridViewSelectList.CurrentCell.ColumnIndex == dataGridViewSelectList.Columns["Amount"].Index || dataGridViewSelectList.CurrentCell.ColumnIndex == dataGridViewSelectList.Columns["Other"].Index)
            //    {
            //        string[] AmountaArr = (dataGridViewSelectList.CurrentCell.Value + "").Split(':');
            //        if (AmountaArr.Length > 1)
            //        {
            //            dataGridViewSelectList.EndEdit();
            //            return;
            //        }
            //        TextBox itemID = e.Control as TextBox;
            //        if (itemID != null)
            //        {
            //            itemID.KeyPress += new KeyPressEventHandler(itemID_KeyPress);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
               
            //}


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

                //SumPriceMedicalOrder();
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
                    if (e.KeyChar != '.')
                        e.Handled = true;
                }
        }
    private void buttonAddDown_BtnClick()
        {
            try
            {

                if (Statics.popBOMMaterialSearch == null) Statics.popBOMMaterialSearch = new PopBOMMaterialSearch(uBranch1.BranchId);

                        Statics.popBOMMaterialSearch.BackColor = Color.FromArgb(255, 230, 217);
                        Statics.popBOMMaterialSearch.StartPosition = FormStartPosition.CenterScreen;
                        Statics.popBOMMaterialSearch.WindowState = FormWindowState.Normal;
                        Statics.popBOMMaterialSearch.BranchID = uBranch1.BranchId;
                        Statics.popBOMMaterialSearch.ShowDialog();
                   
                      

                
               
                if (Statics.popBOMMaterialSearch.lsMaterial.Any())
                {

                    foreach (DataGridViewRow item in Statics.popBOMMaterialSearch.lsMaterial)
                    {
                        if (lsMaterialItem.Contains(item.Cells["รหัสเก่า"].Value + "")) continue;
                            object[] myItems = {
                                             false,
                                             item.Cells["รหัสเก่า"].Value,
                                             item.Cells["ชื่อ"].Value,
                                             item.Cells["ราคาเฉลี่ย"].Value,
                                             0,
                                             item.Cells["หน่วย"].Value
                                          };

                            dataGridViewMaterial.Rows.Add(myItems);
                            lsMaterialItem.Add(item.Cells["รหัส"].Value + "");
                            //dicMaterialItem.Add(item.Cells["รหัส"].Value+"", item);
                    }
                    if (dataGridViewMaterial.Rows.Count > 0 && dataGridViewMaterial.Columns.Contains("Amount"))

                        foreach (DataGridViewColumn dc in dataGridViewMaterial.Columns)
                        {
                            if (dc.Name.ToLower()=="amount")
                            {
                                dc.ReadOnly = false;
                                dc.ValueType = typeof(double);
                            }
                            else
                            {
                                dc.ReadOnly = true;
                            }
                        }
                        
                    SumPriceMaterial();
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


            

            //================ใน Database Delete ทั้งหมดก่อนแล้วค่อย insert ใหม่
        List<DataGridViewRow> rowsToDelete = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in dataGridViewMaterial.Rows)
        {
            DataGridViewCheckBoxCell chk = row.Cells[0] as DataGridViewCheckBoxCell;
            if (Convert.ToBoolean(chk.Value) == true)
            {
                //dataGridViewMaterial.Rows.Remove(row);
                rowsToDelete.Add(row);
               

                //if (FormType == DerUtility.AccessType.Update)
                //{
                //    Entity.SupplieTrans supplieInfo = new Entity.SupplieTrans();
                //    supplieInfo.VN = vn;
                //    supplieInfo.MS_Code = row.Cells["Code"].Value + "";
                //    listSup.Add(supplieInfo);
                //}
            }
        }

        //int? statusDel = new Business.MedicalSupplies().DeleteSupplies(listSup.ToArray());

        ////if (statusDel == 1)
        ////{
            foreach (DataGridViewRow row in rowsToDelete)
            {
                dataGridViewMaterial.Rows.Remove(row);
                //LsSelectMS_Code.Remove(row.Cells[1].Value + "");
                if (lsMaterialItem.Contains(row.Cells[1].Value + ""))//code
                    lsMaterialItem.Remove(row.Cells[1].Value + "");
            }

        SumPriceMaterial();
        //if (dataGridViewSelectList.RowCount == 0)
        //{
        //    if (FormType == DerUtility.AccessType.Update)
        //    { 

        //    }
        //    else
        //    {
        //        tabTypShortName = MoSubType = "";
        //    }
   
            
        //}
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
       
        private void txtFindHair_Enter(object sender, EventArgs e)
        {

        }

    

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        //private void btnBrowse_Click(object sender, EventArgs e)
        //{
        //    if(!string.IsNullOrEmpty(Pro_Code))
        //    {
        //        if (DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirmYesNo, "หากคุณเปลี่ยนแปลง \"ชื่อลูกค้า \" รายการที่เลือกจะถูกยกเลิก \n\rคุณต้องการเปลี่ยนใช่หรือไม่?") == DialogResult.Yes)
        //        {
        //            RemoveDgvRows(dataGridViewSelectList);
        //            txtProPrice.Text = "0.00";
        //        }
        //        else return;
        //    }
        //    PopCustSearch obj = new PopCustSearch();
        //    obj.StartPosition = FormStartPosition.CenterParent;
        //    obj.WindowState = FormWindowState.Normal;
        //    obj.MaximizeBox = false;
        //    obj.MinimizeBox = false;
        //    obj.ShowDialog();
        //    if (obj.CN != "")
        //    {
        //        Pro_Code = obj.CN;
        
        //        customerType = obj.CustomerType;

        //    }
        //}

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

        //private void dataGridViewSelectList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        if (e.RowIndex < 0) return;
        //        double dblAmount=0;
        //        double dbNumPerC = 0;
        //        double dbPricePerU = 0;
        //         double dblTotal = 0;
        //         double SPPrice = 0;
        //         string[] AmountaArr = (dataGridViewSelectList.Rows[e.RowIndex].Cells["Price/Unit"].Value + "").Split(':');
        //        if (AmountaArr.Length > 1)
        //        {
                   
        //            foreach (var s in AmountaArr)
        //            {
        //                //dblAmount = s == "" ? 0 : double.Parse(s);
        //                //dbNumPerC = dataGridViewSelectList.Rows[e.RowIndex].Cells["No./Course"].Value + "" == "" ? 0 : double.Parse(dataGridViewSelectList.Rows[e.RowIndex].Cells["No./Course"].Value + "");
        //                //dbPricePerU = dataGridViewSelectList.Rows[e.RowIndex].Cells["Price/Unit"].Value + "" == "" ? 0 : double.Parse(dataGridViewSelectList.Rows[e.RowIndex].Cells["Price/Unit"].Value + "");
        //                //string[] dblTotalArr = (dataGridViewSelectList.Rows[e.RowIndex].Cells["PriceTotal"].Value + "").Split(':');
        //                dblTotal += (s=="" ? 0 : double.Parse(s));
        //            }
                  
        //        }
        //        else
        //        {
        //            dblAmount = dataGridViewSelectList.Rows[e.RowIndex].Cells["Amount"].Value + "" == "" ? 0 : double.Parse(dataGridViewSelectList.Rows[e.RowIndex].Cells["Amount"].Value + "");
        //            dbNumPerC = dataGridViewSelectList.Rows[e.RowIndex].Cells["No./Course"].Value + "" == "" ? 0 : double.Parse(dataGridViewSelectList.Rows[e.RowIndex].Cells["No./Course"].Value + "");
        //            dbPricePerU = dataGridViewSelectList.Rows[e.RowIndex].Cells["Price/Unit"].Value + "" == "" ? 0 : double.Parse(dataGridViewSelectList.Rows[e.RowIndex].Cells["Price/Unit"].Value + "");
        //            SPPrice = dataGridViewSelectList.Rows[e.RowIndex].Cells["SpecialPrice"].Value + "" == "" ? 0 : double.Parse((dataGridViewSelectList.Rows[e.RowIndex].Cells["SpecialPrice"].Value + "").Replace("--", "-").Replace("--", "-").Replace("--", "-"));
                    
        //            dataGridViewSelectList.Rows[e.RowIndex].Cells["Total"].Value = dblAmount * dbNumPerC; //จำนวนทั้งหมด
        //            double pritotal = (dblAmount * dbPricePerU) + SPPrice;
        //            dataGridViewSelectList.Rows[e.RowIndex].Cells["PriceTotal"].Value =pritotal==0?"0": pritotal.ToString("###,###.##"); //ราคารวม

        //            //Set Format 
        //            dataGridViewSelectList.Rows[e.RowIndex].Cells["Amount"].Value =dblAmount==0?"0":dblAmount.ToString("###,###");

        //            string strOther = dataGridViewSelectList.Rows[e.RowIndex].Cells["Other"].Value + "";
        //            if(!string.IsNullOrEmpty(strOther))
        //            {
        //                dataGridViewSelectList.Rows[e.RowIndex].Cells["Other"].Value =  double.Parse(strOther).ToString("###,###.##");
        //            }

        //        }
        //       // string dateExpire = dataGridViewSelectList.Rows[e.RowIndex].Cells["ExpireDate"].Value+"";
        //       //if(dateExpire.Length>0) dataGridViewSelectList.Rows[e.RowIndex].Cells["ExpireDate"].Value =ToMaskedExpireString(dataGridViewSelectList.Rows[e.RowIndex].Cells["ExpireDate"].Value.ToString());

        //        SumPriceMedicalOrder();

        //        DataGridViewComboBoxColumn chCom = new DataGridViewComboBoxColumn();
        //       //string  cboMKT = dataGridViewSelectList.Rows[e.RowIndex].Cells["MKTBudget"].Value+"";
        //    }
        //    catch (Exception ex)
        //    {
        //        DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, "เกิดข้อผิดพลาดในการแสดงข้อมูล เนื่องจาก " + ex.Message);
        //    }
        //}
        //private string ToMaskedExpireString(String value)
        //{
        //    string txtExpire = "";
        //    try
        //    {
        //        if (value.Contains("/"))
        //        {
        //            string[] txt = value.Split('/');
        //            if (Convert.ToInt16(txt[1]) > 12 || txt[0].Length != 4 || Convert.ToInt16(txt[2]) < 2550)
        //            {
        //                string c = DateTime.Now.ToString("dd/MM/yyyy");
        //                MessageBox.Show(string.Format("Date format incorrect.({0})", c));
        //                txtExpire = "";
        //            }
        //            else
        //            {
        //                txtExpire = string.Format("{0}/{1}/{2}", txt[0], txt[1], txt[2]);
        //            }
        //        }
                 
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    return txtExpire;
        //}
        private void SumPriceMaterial()
        {
            //SalePriceNew = dataGridViewSelectList.Rows.Cast<DataGridViewRow>().Sum(row => row.Cells["Total"].Value + ""==""?0:decimal.Parse(row.Cells["Total"].Value + ""));
            //txtTotalPrice.Text = SalePriceNew == 0 ? "0" : SalePriceNew.ToString("###,###.##");
            ////decimal ProPrice = dataGridViewSelectList.Rows.Cast<DataGridViewRow>().Sum(row => row.Cells["Price/Unit"].Value + "" == "" ? 0 : decimal.Parse(row.Cells["Price/Unit"].Value + "") * (row.Cells["Amount"].Value + ""==""?1:decimal.Parse(row.Cells["Amount"].Value + "")));
            ////txtTotalPrice.Text = ProPrice == 0 ? "0" : ProPrice.ToString("###,###.##");
            try
            {
                foreach (DataGridViewRow item in dataGridViewMaterial.Rows)
                {
                    double pu = item.Cells["Price/Unit"].Value + ""==""?1:Convert.ToDouble(item.Cells["Price/Unit"].Value + "");//(item.Cells["Price/Unit"].Value + "").Length < 3 ? 0 : 
                    double am = item.Cells["Amount"].Value + ""==""?1:Convert.ToDouble(item.Cells["Amount"].Value + "");//(item.Cells["Amount"].Value + "").Length < 3 ? 0 : 
                    item.Cells["Total"].Value = (pu * am).ToString("###,###,###.##");
                }


                SalePriceNew = dataGridViewMaterial.Rows.Cast<DataGridViewRow>().Sum(row => row.Cells["Total"].Value + "" == "" ? 0 : decimal.Parse(row.Cells["Total"].Value + ""));
                txtTotalPrice.Text = SalePriceNew == 0 ? "0" : SalePriceNew.ToString("###,###,###.##");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            int? intStatus = 0;
            Entity.MedicalSupplies info;
            if (DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirm, "ยืนยันการบันทึกข้อมูล") != DialogResult.OK)return;
             
            //if (string.IsNullOrEmpty(txtPro_Code.Text)||string.IsNullOrEmpty(txtPro_Name.Text) )
            //    {
            //        DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "กรุณาระบุ รหัสโปรโมชันและชื่อโปรโมชัน\n Please specify Promotion Codes and Promotion name.");
            //        return;
            //    }
                try
                {
                    info = new Entity.MedicalSupplies();
                    info.LisItemStock=new List<Entity.MedicalSupplies> ();
                    foreach (DataGridViewRow item in dataGridViewMaterial.Rows)
                    {
                        double pu = item.Cells["Price/Unit"].Value + ""==""?1:Convert.ToDouble(item.Cells["Price/Unit"].Value + "");//(item.Cells["Price/Unit"].Value + "").Length < 3 ? 0 : 
                        decimal am = item.Cells["Amount"].Value + ""==""?1:Convert.ToDecimal(item.Cells["Amount"].Value + "");//(item.Cells["Amount"].Value + "").Length < 3 ? 0 : 
                        

                        Entity.MedicalSupplies infoMaterial = new Entity.MedicalSupplies();

                        infoMaterial.MS_Code = CurrentMS_Code;
                        infoMaterial.MS_Code_Ref = item.Cells["MS_Code"].Value + "";//Code ของ stock
                        infoMaterial.Amount = am;
                        infoMaterial.MS_CostAVG = pu;
                        infoMaterial.ENSave = Userinfo.EN;
                        infoMaterial.BranchID = uBranch1.BranchId;
                        info.LisItemStock.Add(infoMaterial);
                    }



                    intStatus = new Business.MedicalSupplies().DeleteBOMMaterial(CurrentMS_Code, uBranch1.BranchId);
                    intStatus = new Business.MedicalSupplies().InsertBOMMaterial(ref info);

                    if (intStatus > 0)
                    {
                        DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, Statics.SaveComplete);
                        //Statics.frmMedicalOrderList.BindDataMedicalOrder(1);
                        //this.Close();
                    }
                }
                catch (Exception ex)
                {
                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                }
        }

       

        private void FrmBOMList_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics.frmBOMList = null;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Statics.frmBOMList = null;
            this.Close();
        }



        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dataTableMain.DefaultView.RowFilter = string.Format("[MS_Name] LIKE '%{0}%'", txtFilter.Text);
            }
            catch (Exception)
            {

            }
        }

        private void dataGridViewSelectList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                buttonAddDown.Enabled = false;
                buttonDeleteUp.Enabled = false;
                buttonAddDown.Visible = false;
                buttonDeleteUp.Visible = false;
                btnSave.Enabled = false;
                Dataedit = false;
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
                Entity.MedicalSupplies info = new Entity.MedicalSupplies() {  };

                info.QueryType = "MaterialUsed";
                info.BranchID = uBranch1.BranchId;
                info.MS_Code =CurrentMS_Code= dataGridViewSelectList.Rows[e.RowIndex].Cells["MS_Code"].Value + "";

                DataSet ds = new Business.MedicalSupplies().SelectMedicalSuppliesPaging(info);

                if (ds == null || ds.Tables.Count <= 0) return;
                //dicMaterialItem = new Dictionary<string, DataRow>();
                if(dataGridViewMaterial.Rows.Count>0)                
                    dataGridViewMaterial.Rows.Clear();
                lsMaterialItem = new List<string>();
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                      object[] myItems = {
                                             false,
                                             item["Stock_Code"]+"",
                                             item["Stock_Name"]+"",
                                             item["CostPerUnit"]+"",
                                             item["UsedAmount"]+"",
                                             item["UnitName"]+"",
                                             (Convert.ToDouble(item["CostPerUnit"]+"")*Convert.ToDouble(item["UsedAmount"]+"")).ToString("###,###,###.##"),//price total
                                          };

                      dataGridViewMaterial.Rows.Add(myItems);
                      lsMaterialItem.Add(item["Stock_Code"] + "");
                }
                SumPriceMaterial();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewMaterial_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //double pu = (dataGridViewMaterial.Rows[e.RowIndex].Cells["Price/Unit"].Value + "").Length < 3 ? 0 : Convert.ToDouble(dataGridViewMaterial.Rows[e.RowIndex].Cells["Price/Unit"].Value + "");
                //double am = (dataGridViewMaterial.Rows[e.RowIndex].Cells["Amount"].Value + "").Length < 3 ? 0 : Convert.ToDouble(dataGridViewMaterial.Rows[e.RowIndex].Cells["Amount"].Value + "");
                //dataGridViewMaterial.Rows[e.RowIndex].Cells["Total"].Value = pu * am;
                if (e.ColumnIndex == 0) return;
                SumPriceMaterial();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewMaterial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != 0 || e.RowIndex < 0) return;

                DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();

                //if (!multiSelect)
                //{
                //    foreach (DataGridViewRow dr in dataGridViewMaterial.Rows)
                //    {
                //        ch1 = (DataGridViewCheckBoxCell)dr.Cells[0];
                //        ch1.Value = false;
                //    }
                //}
                ch1 = (DataGridViewCheckBoxCell)dataGridViewMaterial.Rows[e.RowIndex].Cells[0];
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
                //if (dgvData.CurrentRow.Cells["Active"].Value + ""!="Y")
                //{ ch1.Value = false; }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //if (e.ColumnIndex == 0)
            //dataGridViewMaterial.EndEdit();
            //dataGridViewMaterial.ClearSelection();
            //SendKeys.Send("{Tab}");

        }

        private void uBranch1_SelectedChanged(object sender, EventArgs e)
        {
            Statics.popBOMMaterialSearch = null;
            BindMedicalSupplies(1);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                buttonAddDown.Enabled = true;
                buttonDeleteUp.Enabled = true;
                buttonAddDown.Visible = true;
                buttonDeleteUp.Visible = true;
                btnSave.Enabled = true;
                Dataedit = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmBOMList_Shown(object sender, EventArgs e)
        {
            dataGridViewSelectList.ClearSelection();
        }

        private void dataGridViewMaterial_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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


    

      

     
         

    }
}

