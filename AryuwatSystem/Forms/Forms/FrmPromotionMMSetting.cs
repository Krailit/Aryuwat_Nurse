using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DermasterSystem.Class;
using Entity;
using WeifenLuo.WinFormsUI.Docking;
using System.Threading;
using DermasterSystem.Data;


namespace DermasterSystem.Forms
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
          
        private string vn = "";
        private string so = "";
        private string Pro_Code;

        List<string> LsSelectMS_Code = new List<string>();
        private string docFilePath;
        List<DataGridViewRow> rowsToDelete=new List<DataGridViewRow>();
        //DataGridView dataGridToDelete=new DataGridView();
        public List<Entity.MedicalStuff> MedicalStuffs { get; set; }
        public List<Entity.MedicalOrderUseTrans> MedicalOrderUseTranss{ get; set; }
        public Utility.AccessType FormType { get; set; }
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
          

     
              private void FrmPromotionMMSetting_Load(object sender, EventArgs e)
              {
                  try
                  {
                      this.btnSave.Click += new EventHandler(this.btnSave_Click);
                      this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
                      foreach (DataRow row in Userinfo.UnitName.Rows)
                      {
                          this.lsUnit.Add(row["UnitName"]+"");
                      }
                   
                      this.MedicalStuffs = new List<Entity.MedicalStuff>();
                      this.MedicalOrderUseTranss = new List<Entity.MedicalOrderUseTrans>();
                      this.dateTimePickerEnd.Value = DateTime.Now;
                      if (FormType == Utility.AccessType.Update)
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
            Entity.Promotion info=new Entity.Promotion() ;
            info.QueryType = "SEARCHBYID";
            info.PRO_Code = PRO_Code;
            DataTable dt = new Business.Promotion().SelectPromotionPaging(info).Tables[0];
            if (dt == null || dt.Rows.Count <= 0) return;
            txtPro_Code.Text = dt.Rows[0]["PRO_Code"] + "";
            txtPro_Code.ReadOnly = true;
            txtPro_Name.Text = dt.Rows[0]["PRO_Name"] + "";
            dateTimePickerStart.Value = dt.Rows[0]["DateStart"] + "" == "" ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["DateStart"] + "");
            dateTimePickerEnd.Value = dt.Rows[0]["DateEnd"] + "" == "" ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["DateEnd"] + "");
            checkBoxActive.Checked = dt.Rows[0]["PRO_Active"] + ""=="Y";
            txtRemark.Text = dt.Rows[0]["Remark"] + "";

            txtProPrice.Text = dt.Rows[0]["ProPrice"] + "" == "" ? "0" : Convert.ToDecimal(dt.Rows[0]["ProPrice"] + "").ToString("###,###,###.##");
            txtTotalPrice.Text = dt.Rows[0]["ProPriceCredit"] + "" == "" ? "0" : Convert.ToDecimal(dt.Rows[0]["ProPriceCredit"] + "").ToString("###,###,###.##");
          
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
            if (Utility.PopMsg(Utility.EnuMsgType.MsgTypeConfirm, "ยืนยันการบันทึกข้อมูล") != DialogResult.OK)return;
             
            if (string.IsNullOrEmpty(txtPro_Code.Text)||string.IsNullOrEmpty(txtPro_Name.Text) )
                {
                    Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "กรุณาระบุ รหัสโปรโมชันและชื่อโปรโมชัน\n Please specify Promotion Codes and Promotion name.");
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
                    info.ProPriceCredit = txtTotalPrice.Text == "" ? 0 : Convert.ToDecimal(txtTotalPrice.Text);
                    info.PRO_Active = checkBoxActive.Checked ? "Y" : "N";
                    info.Remark = txtRemark.Text;
                    info.PRO_Type = "CREDIT";
                    info.ProSupplieInfo = new List<Entity.MedicalSupplies>();
                  
                        
                    Entity.MedicalSupplies supplieInfo = new Entity.MedicalSupplies();
                    supplieInfo.MS_Code = "PRO_CREDIT";
                    supplieInfo.Amount = 1;
                    supplieInfo.MS_PROPrice = txtTotalPrice.Text + "" == "" ? 0 : double.Parse(txtTotalPrice.Text);
                    info.ProSupplieInfo.Add(supplieInfo);
                   
                    intStatus = new Business.Promotion().InsertPromotion(info);
                    if (intStatus > 0)
                    {
                        Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, Statics.SaveComplete);
                        //Statics.frmMedicalOrderList.BindDataMedicalOrder(1);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    Utility.PopMsg(Utility.EnuMsgType.MsgTypeError, ex.Message);
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
            var idMax = DermasterSystem.Data.UtilityBackEnd.GenMaxSeqnoValues("MO");
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


    

      

     
         

    }
}

