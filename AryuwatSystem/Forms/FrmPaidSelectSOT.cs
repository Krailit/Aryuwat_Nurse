using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using AryuwatSystem.DerClass;
using Entity;
using WeifenLuo.WinFormsUI.Docking;
using TextBox = System.Windows.Forms.TextBox;
using System.Diagnostics;
using System.Text;
using Newtonsoft.Json;

namespace AryuwatSystem.Forms
{
    public partial class FrmPaidSelectSOT : DockContent
    {
        private Entity.MedicalSupplies info;
        public DerUtility.AccessType FormType { get; set; }
        private int? intStatus;
        private int OldrowIndex = 0;
        private DataTable dataTable = null;
        private int ID = 0;
        private string MS_CodeOld = "";
        private double SalePrice = 0;
        private double LastSalePrice = 0;
        private double DiscountPercen = 0;
        private double DiscountBath = 0;
        private double DiscountByItemBath = 0;
        private double DiscountComP = 0;
        private double DiscountMBudget = 0;
        private double DiscountGiftV = 0;
        private double DiscountSubject = 0;
        private double DiscountAll = 0;
        private double LastDiscount = 0;
        private double Unpaid = 0;
        private double UnpaidOld = 0;
        private double EarnestMoney = 0;
        private bool checkmoney = true;
        private bool NoBill = false;
        private int rowIndex = 0;
        private double Amount = 0;
        private double numFreeAmount = 0;
        private double SpecialPrice = 0;
        private string actDataGridView;

        private double PettyCash = 0;
        private double Debtor = 0;
        private double DomesticMoney = 0;
        private double AbroadMoney = 0;
        private double ChecksMoney = 0;
        private double DebitMoney = 0;
        Dictionary<string, double> dicCashTranfer = new Dictionary<string, double>();
        Dictionary<string, double> dicCashday = new Dictionary<string, double>();
        Dictionary<string, string> dicCreditNumber = new Dictionary<string, string>();
        Dictionary<string, string> dicCreditPeriod = new Dictionary<string, string>();
        List<double> lstCashTranfer = new List<double>();
        DateTime Maxdate;
        DateTime PayCurrentDate;
        string PRO_Code = "";//เอาไว้เช็คโปร member การให้ค่าคอมแพทย์ คิดจากราคาโปร
        string SORef = "";//เอาไว้เช็คโปร member การให้ค่าคอมแพทย์

        //public string VN;
        public string cn;
        public string customerType;
        private DataSet dsSumOfTreat;
        private DataSet dsSumOfTreatCash_Credit;
        private DataTable dtSumOfTreat;
        private DataTable dtSumOfTreatPay;
        private DataTable dtSumOfTreatInvoice;
        private DataTable dtSumOfTreatRcn;
        private DataTable dtSumOfTreatPayByItem;


        public string TypeCashier = "";
        public string SaveType = "";
        public List<string> itemselect { get; set; }
        public string VN { get; set; }
        public string SO { get; set; }
        public string SOReceiptPrint { get; set; }
        public string SOReceipt { get; set; }
        public string BranchID { get; set; }
        public string BranchName { get; set; }

        string RCNoCurrent = "";
        DateTime ReceiptDateCurrent = DateTime.Now.Date;
        decimal ReceiptBathCurrent = 0;

        string PlayMS_Code = "";

        string REQNoCurrent = "";
        #region Enum CallMode

        private enum CallMode
        {
            Insert,
            Update,
            Preview
        }
        #endregion
        public FrmPaidSelectSOT()
        {
            InitializeComponent();
            SetColumns();

            //BindMedicalSupplies(1);
            //ngbMain.MoveFirst += ngbMain_MoveFirst;
            //ngbMain.MoveNext += ngbMain_MoveNext;
            //ngbMain.MoveLast += ngbMain_MoveLast;
            //ngbMain.MovePrevious += ngbMain_MovePrevious;
            dgvData.RowPostPaint += dgvData_RowPostPaint;
            dataGridViewCreditTransfer.RowPostPaint += dataGridViewCredit_RowPostPaint;
            //dataGridViewCashTransfer.RowPostPaint+=new DataGridViewRowPostPaintEventHandler(dataGridViewCashTransfer_RowPostPaint);
            dgvData.CellMouseClick += dgvData_CellMouseClick;
            menuPaybyItem.Click += new EventHandler(menuPaybyItem_Click);
            FormType = DerUtility.AccessType.Insert;
            this.Closing += new CancelEventHandler(FrmSurgicalFee_Closing);
        }
        private void FrmSumOfTreatment_Load(object sender, EventArgs e)
        {
            var test = itemselect;
            lbsumList.Text = "";
            BindCommission();
            BindCreditCard();
            BindPayByItem();
            BindFrmSumOfTreatment();
            BindReciept();
            //DateTime dt1 = DateTime.ParseExact(date1, "dd-MM-yyyy", null);
            //DateTime dt2 = DateTime.ParseExact(date2, "dd-MM-yyyy", null);
            if (!(Userinfo.IsAdmin ?? "").Contains(Userinfo.EN) && !Userinfo.IS_ADMIN_JOBCOST.Contains(Userinfo.EN) && !(dtpDateSave.Value.Date < DateTime.Now.Date) && checkmoney == false)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, "จะไม่สามารถแก้ไขข้อมูลได้เนื่องจาก เกินกำหนดเวลา หรือตัดคอร์สไปแล้ว");
                DisableButton(false);
            }
        }
        void FrmSurgicalFee_Closing(object sender, CancelEventArgs e)
        {
            Statics.frmSurgicalFee = null;
            if (Statics.frmSOFList != null)
                Statics.frmSOFList.BindFrmSurgicalFee(1);
        }

        #region Event


        private void menuEdit_Click(object sender, EventArgs e)
        {
            // EditMedicalSupplies();
            //CallForm(CallMode.Update);
        }
        private void menuPaybyItem_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void menuPreview_Click(object sender, EventArgs e)
        {
            // CallForm(CallMode.Preview);
        }

        private void menuDel_Click(object sender, EventArgs e)
        {
            DeleteData();
            summoney();
        }
        private void dgvData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                if (e.Button == MouseButtons.Right)
                {
                    dgvData.ClearSelection();
                    dgvData.Rows[OldrowIndex].Selected = false;
                    dgvData.Rows[e.RowIndex].Selected = true;
                    OldrowIndex = e.RowIndex;
                    ToolStripMenuItemDel.Visible = false;
                    menuPaybyItem.Visible = true;
                    menuPrintCard.Visible = true;
                    contextMenuStrip1.Show(MousePosition);
                }
            }
            catch
            {
                return;
            }
        }
        private void ngbMain_MoveFirst()
        {
            //BindMedicalSupplies(1);
        }

        private void ngbMain_MoveLast()
        {
            //BindMedicalSupplies(Convert.ToInt32(ngbMain.TotalPage));
        }

        private void ngbMain_MoveNext()
        {
            // BindMedicalSupplies(Convert.ToInt32(Convert.ToInt32(ngbMain.CurrentPage) + 1));
        }

        private void ngbMain_MovePrevious()
        {
            //BindMedicalSupplies(Convert.ToInt32(Convert.ToInt32(ngbMain.CurrentPage) - 1));
        }

        private void dgvData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }


        #endregion

        private void DeleteData()
        {
            try
            {
                //if (actDataGridView == "CASH")
                //{
                //    if (dataGridViewCashTransfer.CurrentRow.Index == -1) return;
                //    if (DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirmYesNo,
                //                       Statics.StrConfirmDelete + dataGridViewCashTransfer.CurrentRow.Cells["cashtyp"].Value + " ยอด " + dataGridViewCashTransfer.CurrentRow.Cells["CashCurrent"].Value + "") !=
                //        DialogResult.Yes) return;
                //    //resultobj = "0";
                //    dataGridViewCashTransfer.Rows[rowIndex].ReadOnly = true;
                //    dataGridViewCashTransfer.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.DarkGray;
                //    dataGridViewCashTransfer.Rows[rowIndex].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
                //    dataGridViewCashTransfer.ClearSelection();
                //    dataGridViewCashTransfer.Rows[rowIndex].Cells["statusdelcash"].Value = "DEL";
                //    dataGridViewCashTransfer.Rows[rowIndex].Cells["NoBill1"].Value = "";

                //    dataGridViewCashTransfer.Rows[rowIndex].Visible = false;
                //    //if (new Business.SumOfTreatment().DeleteCashCredit(dataGridViewCashTransfer.CurrentRow.Cells["Pay_Code"].Value + "") == 1)
                //    //{
                //    //    Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, Statics.StrMsgDeleteComplete);
                //    //    dataGridViewCashTransfer.Rows.RemoveAt(rowIndex);
                //    //}
                //}
                //else
                //{
                if (dataGridViewCreditTransfer.CurrentRow == null || dataGridViewCreditTransfer.CurrentRow.Index == -1) return;
                if (DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirmYesNo,
                                   Statics.StrConfirmDelete + dataGridViewCreditTransfer.CurrentRow.Cells["name"].Value + " ยอด " + dataGridViewCreditTransfer.CurrentRow.Cells["cash"].Value + "") !=
                    DialogResult.Yes) return;
                dataGridViewCreditTransfer.Rows[rowIndex].ReadOnly = true;
                dataGridViewCreditTransfer.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.DarkGray;
                dataGridViewCreditTransfer.Rows[rowIndex].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
                dataGridViewCreditTransfer.ClearSelection();
                dataGridViewCreditTransfer.Rows[rowIndex].Cells["statusdelcredit"].Value = "DEL";
                //dataGridViewCreditTransfer.Rows[rowIndex].Cells["NoBill2"].Value = "";

                dataGridViewCreditTransfer.Rows[rowIndex].Visible = false;
                if (new Business.SumOfTreatment().DeleteCashCredit(dataGridViewCreditTransfer.Rows[rowIndex].Cells["Pay_Code"].Value + "") > 0)
                {
                    //Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, Statics.StrMsgDeleteComplete);
                    dataGridViewCreditTransfer.Rows.RemoveAt(rowIndex);
                }


                //  }
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, Statics.StrMsgDeleteError + ex);
            }


        }
        private void buttonCancel_BtnClick(object sender, EventArgs e)
        {
            Statics.frmPaidSelectSOT = null;
            this.Close();
        }
        private void SetColumns()
        {
            DerUtility.SetPropertyDgv(dgvData);
            //foreach (DataGridViewColumn dgvCol in dataGridViewCashTransfer.Columns)
            //{
            //    dgvCol.SortMode = DataGridViewColumnSortMode.NotSortable;
            //    if (dgvCol.Index == 0 || dgvCol.Index == 1 || dgvCol.Name=="summarycash")
            //        dgvCol.ReadOnly = true;
            //}
            foreach (DataGridViewColumn dgvCol in dataGridViewCreditTransfer.Columns)
            {
                dgvCol.SortMode = DataGridViewColumnSortMode.NotSortable;
                if (dgvCol.Index == 0 || dgvCol.Index == 1 || dgvCol.Name == "summary")
                    dgvCol.ReadOnly = true;
            }
        }
        public void BindCommission()
        {
            try
            {
                var info = new Entity.Personnel();
                info.PersonnelType = "11";
                info.QueryType = "SEARCHCOM";
                DataTable dt = new Business.Personnel().SelectCustomerPaging(info).Tables[0];
                DataRow dr = dt.NewRow();
                dr["EN"] = "";
                dr["FullNameThai"] = "--ไม่ระบุ--";
                dt.Rows.InsertAt(dr, 0);
                comboBoxCommission.Items.Clear();
                comboBoxCommission.DataSource = dt;
                comboBoxCommission.ValueMember = "EN";
                comboBoxCommission.DisplayMember = "FullNameThai";
                comboBoxCommission.SelectedValue = "";

                comboBoxCommission2.Items.Clear();
                comboBoxCommission2.DataSource = dt.Copy();
                comboBoxCommission2.ValueMember = "EN";
                comboBoxCommission2.DisplayMember = "FullNameThai";
                comboBoxCommission2.SelectedValue = "";

            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
        }

        private DataTable dtcash;
        public void BindCreditCard()
        {
            try
            {

                DataSet dataSet = new Business.SumOfTreatment().SelectCreditCard();
                DataTable dt = dataSet.Tables[0];//.Select("CashTyp='CREDIT'").CopyToDataTable();

                //listBoxCashTyp.Items.Clear();
                //listBoxCashTyp.DataSource = dt.DefaultView;
                //listBoxCashTyp.ValueMember = "Bankvalue";
                //listBoxCashTyp.DisplayMember = "BankName";
                //listBoxCashTyp.SelectedIndex = -1;

                dt = dataSet.Tables[4];
                listBoxCreditTyp.Items.Clear();
                listBoxCreditTyp.DataSource = dt.DefaultView;
                listBoxCreditTyp.ValueMember = "Bankvalue";
                listBoxCreditTyp.DisplayMember = "BankName";
                listBoxCreditTyp.SelectedIndex = -1;

                //DataGridViewComboBoxColumn comboBoxColumn1;
                //comboBoxColumn1 = new DataGridViewComboBoxColumn();
                //DataTable data = new DataTable();
                //data.Columns.Add(new DataColumn("Value", typeof(string)));
                //data.Columns.Add(new DataColumn("Description", typeof(string)));
                //data.Rows.Add("", "ไม่ระบุ");
                //data.Rows.Add("item1", "item1");
                //data.Rows.Add("item2", "item2");
                //data.Rows.Add("item3", "item3");
                //dataSet.Tables[1].Rows.Add(0, "ไม่ระบุ");

                //comboBoxColumn1.DataSource = dataSet.Tables[2].Select("PayInTyp='CASH'").CopyToDataTable(); 
                //comboBoxColumn1.ValueMember = "PayInValue";
                //comboBoxColumn1.DisplayMember = "PayInName";
                //comboBoxColumn1.HeaderText = "Pay in";
                //comboBoxColumn1.Name = "PayinCash";
                //comboBoxColumn1.Width = 150;
                //comboBoxColumn1.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;

                ////comboBoxColumn1.DisplayIndex = 0;
                //DataGridViewComboBoxColumn comboBoxColumn2;
                //comboBoxColumn2 = new DataGridViewComboBoxColumn();

                //comboBoxColumn2.DataSource = dataSet.Tables[2].Select("PayInTyp='CREDIT'").CopyToDataTable(); 
                //comboBoxColumn2.ValueMember = "PayInValue";
                //comboBoxColumn2.DisplayMember = "PayInName";
                //comboBoxColumn2.HeaderText = "Pay in";
                //comboBoxColumn2.Name = "PayinCredit";
                //comboBoxColumn2.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                //comboBoxColumn2.Width = 150;
                //
                //DataGridViewComboBoxColumn comboBoxColumnCardtype;
                //comboBoxColumnCardtype = new DataGridViewComboBoxColumn();

                //comboBoxColumnCardtype.DataSource = dataSet.Tables[3];
                //comboBoxColumnCardtype.ValueMember = "CardType";
                //comboBoxColumnCardtype.DisplayMember = "CardType";
                //comboBoxColumnCardtype.HeaderText = "CardType";
                //comboBoxColumnCardtype.Name = "CardType";
                //comboBoxColumnCardtype.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                //comboBoxColumnCardtype.Width = 100;

                //comboBoxColumn2.DisplayIndex = 0;

                //comboBoxColumn1.DefaultCellStyle.NullValue = dataSet.Tables[2].Select("PayInTyp='CASH'").CopyToDataTable().Rows[0]["PayInName"];


                //dataGridViewCashTransfer.Columns.Add(comboBoxColumn1);
                //dataGridViewCreditTransfer.Columns.Add(comboBoxColumn2);
                //dataGridViewCreditTransfer.Columns.Add(comboBoxColumnCardtype); 
                //dataGridViewCashTransfer.Columns.Insert(dataGridViewCashTransfer.Columns.Count+1, comboBoxColumn1);
                //dataGridViewCreditTransfer.Columns.Insert(dataGridViewCreditTransfer.Columns.Count+1, comboBoxColumn2);
                //dataGridViewCreditTransfer.Columns.Insert(dataGridViewCreditTransfer.Columns.Count+1, comboBoxColumnCardtype); 
                //dataGridViewCashTransfer.Columns["PayCashDate"].DisplayIndex = dataGridViewCashTransfer.Columns.Count-1;
                //dataGridViewCreditTransfer.Columns["PayCreditDate"].DisplayIndex = dataGridViewCreditTransfer.Columns.Count-1;
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
        }
        private void ClearVariable()
        {
            SalePrice = 0;
            dgvData.Rows.Clear();
            //while (dgvData.Rows.Count > 0)
            //{
            //    dgvData.Rows.RemoveAt(0);
            //}
            //dgvData.DataSource = null;
            //dgvData.Refresh();
        }
        List<string> LsPayIn = new List<string>();
        List<string> LsCardType = new List<string>();
        public void BindPayByItem()
        {
            try
            {
                DataSet ds = new Business.SumOfTreatment().SelectSumOfTreatment("SelectPayByItem_SO", SO, VN);
                if (ds.Tables.Count <= 0) return;
                dtSumOfTreatPayByItem = ds.Tables[0];
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
        }
        public void BindReciept()
        {
            try
            {
                //ReceiptBathCurrent = 0;
                //ReceiptDateCurrent = DateTime.Now.Date;
                //RCNoCurrent = "";
                List<DataRow> lst = new List<DataRow>();
                foreach (var items in itemselect)
                {
                    //itemsSOT[0] = SO, itemsSOT[1]= VN
                    var itemsSOT = items.Split(';');
                    //    var test = context.sp_SumOfTreatment("SELECT","", itemsSOT[1], null, null, null, itemsSOT[0], null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
                    //    test = test;
                    DataSet ds = new Business.SumOfTreatment().SelectSumOfTreatment("SelectReciept", itemsSOT[0], itemsSOT[1]);
                    //foreach (var roww in dsSumOfTreat.Tables[0].Rows)
                    //{
                    //    DataRow row = dsSumOfTreat.Tables[0].NewRow();
                    //    dsSumOfTreat.Tables[0].Rows.Add(roww);
                    //}   
                    var empList = ds.Tables[0].AsEnumerable().ToList();
                    foreach (var dataa in empList)
                    {
                        lst.Add(dataa);
                    }
                }
                //DataSet ds = new Business.SumOfTreatment().SelectSumOfTreatment("SelectRecieptList", SO, VN);
                //if (ds.Tables.Count <= 0) return;
                //dtSumOfTreatRcn = ds.Tables[0];

                if (dgvReciept.RowCount > 0) dgvReciept.Rows.Clear();
                decimal Amount = 0;
                var myItemsAll = new[]
                                          {

                                               "ทั้งหมด",
                                              "",
                                              "",
                                          };
                dgvReciept.Rows.Add(myItemsAll);
                foreach (var item in lst)
                {
                    Amount = item["ReceiptBath"] + "" == "" ? 0 : Convert.ToDecimal(item["ReceiptBath"] + "");
                    object[] myItems = {
                                          item["SONo"] + "",
                                          item["RCNo"] + "",
                                         String.Format("{0:yyyy/MM/dd}",item["ReceiptDate"] + ""==""? DateTime.Now:Convert.ToDateTime(item["ReceiptDate"] + "")),
                                          Amount.ToString("###,###,###.##")
                                      };
                    dgvReciept.Rows.Add(myItems);
                }
                dgvReciept.ClearSelection();
                dgvReciept.Rows[0].Selected = true;

            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
        }
        private void BindCashCredit()
        {
            try
            {
                //ReceiptBathCurrent = 0;
                //ReceiptDateCurrent = DateTime.Now.Date;
                //RCNoCurrent = "";
                List<DataRow> lst = new List<DataRow>();
                foreach (var items in itemselect)
                {
                    //itemsSOT[0] = SO, itemsSOT[1]= VN
                    var itemsSOT = items.Split(';');
                    //    var test = context.sp_SumOfTreatment("SELECT","", itemsSOT[1], null, null, null, itemsSOT[0], null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
                    //    test = test;
                    DataSet ds = new Business.SumOfTreatment().SelectSumOfTreatment("SELECTCASHCREDIT", itemsSOT[0], itemsSOT[1]);
                    //foreach (var roww in dsSumOfTreat.Tables[0].Rows)
                    //{
                    //    DataRow row = dsSumOfTreat.Tables[0].NewRow();
                    //    dsSumOfTreat.Tables[0].Rows.Add(roww);
                    //}   
                    var empList = ds.Tables[0].AsEnumerable().ToList();
                    foreach (var dataa in empList)
                    {
                        lst.Add(dataa);
                    }
                }

                //dsSumOfTreatCash_Credit = new Business.SumOfTreatment().SelectSumOfTreatment("SELECTCASHCREDIT", SO, VN);
                if (dataGridViewCreditTransfer.Rows.Count > 0) dataGridViewCreditTransfer.Rows.Clear();
                if (lst == null || lst.Count <= 0) return;
                //foreach (DataRow dr in dsSumOfTreatCash_Credit.Tables[0].Rows.Cast<DataRow>().Where(dr => dr["NoBill"] + "".ToUpper() == "Y" || dr["NoBillPayin"] + "".ToUpper() == "Y"))
                //{
                //    NoBill = true;
                //}

                //LsPayIn.Clear();
                //LsCardType.Clear();

                foreach (var item in lst)
                    {
                        string nobill = "";
                        if (item["NoBill"] + "".ToUpper() == "Y" || item["NoBillPayin"] + "".ToUpper() == "Y") nobill = "Y";

                        string no = item["NoBillPayin"] + "".ToUpper() == "Y" ? "Y" : "N";
                        //LsPayIn.Add(item["PayInID"] + ":" + no);
                        //LsCardType.Add(item["CardType"] + "");
                        string CashMoney =
                            Convert.ToDouble(string.IsNullOrEmpty(item["CashMoney"] + "")
                                                 ? "0"
                                                 : item["CashMoney"] + "".Replace(",", "")).ToString("###,###,###.##");
                        var myItems = new[]
                                          {
                                              item["ID"] + "",
                                               item["BillType"] + "",
                                                item["RCNo"] + "",
                                              item["CD_Code"] + "",
                                              item["BankNameCash"] + "",
                                              CashMoney,
                                              String.Format("{0:yyyy/MM/dd}",item["UpdateDate"] + ""==""? DateTime.Now:Convert.ToDateTime(item["UpdateDate"] + "")),
                                              item["CardNumber"] + "",
                                              item["PayInName"] + "",
                                              item["PayInID"] + "",
                                              item["CardType"] + "",

                                          };
                        dataGridViewCreditTransfer.Rows.Add(myItems);
                    }
                dataGridViewCreditTransfer.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void BindFrmSumOfTreatment()
        {
            try
            {
                using (var context = new m_DataSet.EntitiesOPD_System())
                {
                    ClearVariable();
                    DataSet ds = new DataSet();
                    DataRow toInsert;
                    List<DataRow> lst = new List<DataRow>();
                    foreach (var items in itemselect)
                    {
                        //itemsSOT[0] = SO, itemsSOT[1]= VN
                        var itemsSOT = items.Split(';');
                        //    var test = context.sp_SumOfTreatment("SELECT","", itemsSOT[1], null, null, null, itemsSOT[0], null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
                        //    test = test;
                        dsSumOfTreat = new Business.SumOfTreatment().SelectSumOfTreatment("SELECT", itemsSOT[0], itemsSOT[1], ReceiptDateCurrent);
                        //foreach (var roww in dsSumOfTreat.Tables[0].Rows)
                        //{
                        //    DataRow row = dsSumOfTreat.Tables[0].NewRow();
                        //    dsSumOfTreat.Tables[0].Rows.Add(roww);
                        //}   
                        var empList = dsSumOfTreat.Tables[0].AsEnumerable().ToList();
                        foreach (var dataa in empList)
                        {
                            lst.Add(dataa);
                        }
                    }
                    //dtSumOfTreat = dsSumOfTreat.Tables[0];
                    dtSumOfTreatInvoice = dsSumOfTreat.Tables[1];
                    //dtSumOfTreatRcn = dsSumOfTreat.Tables[2];

                    //DataTable dtmb = Entity.Userinfo.MoConfig.Select("[key]='Free'").CopyToDataTable();
                    //DataGridViewComboBoxColumn  comboBoxColumn2 = new DataGridViewComboBoxColumn();

                    // comboBoxColumn2.DataSource = dtmb;
                    // comboBoxColumn2.ValueMember = "Code";
                    // comboBoxColumn2.DisplayMember = "values";
                    // comboBoxColumn2.HeaderText = "Free";
                    // comboBoxColumn2.Name = "Free";
                    // comboBoxColumn2.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                    // comboBoxColumn2.Width = 200;
                    // dgvData.Columns.Add(comboBoxColumn2);



                    int index = 0;
                    double PriceCreditRef = 0;
                    double Sale = 0;
                    bool ReqStock = false;
                    foreach (var item in lst)
                    {
                        double s = Convert.ToDouble(string.IsNullOrEmpty(item["MS_Price"] + "") ? "0" : item["MS_Price"] + "".Replace(",", ""));
                        PriceCreditRef = Convert.ToDouble(string.IsNullOrEmpty(item["PriceCreditRef"] + "") ? "0" : item["PriceCreditRef"] + "".Replace(",", ""));
                        Amount = Convert.ToDouble(string.IsNullOrEmpty(item["Amount"] + "") ? "1" : item["Amount"] + "".Replace(",", ""));
                        numFreeAmount = Convert.ToDouble(string.IsNullOrEmpty(item["FreeAmount"] + "") ? "0" : item["FreeAmount"] + "".Replace(",", ""));
                        SpecialPrice = Math.Round(Convert.ToDouble(string.IsNullOrEmpty(item["SpecialPrice"] + "") ? "0" : item["SpecialPrice"] + "".Replace(",", "")), 2); ;
                        BranchID = item["BranchID"] + "";
                        BranchName = item["BranchName"] + "";
                        if (SORef == "")
                        {
                            PRO_Code = item["PRO_Code"] + "";
                            SORef = item["SORef"] + "";
                        }

                        if (REQNoCurrent == "")
                        {
                            REQNoCurrent = item["REQNo"] + "";
                            btnREQStock.Enabled = true;
                        }
                        else btnREQStock.Enabled = false;


                        if ((item["MS_Code_Ref"] + "").Length > 3) ReqStock = true;


                        double DiscountBathByItem = Convert.ToDouble(string.IsNullOrEmpty(item["DiscountBathByItem"] + "") ? "0" : item["DiscountBathByItem"] + "".Replace(",", ""));


                        double PriceAfterDis = ((s * Amount) + SpecialPrice) - (DiscountBathByItem);
                        double PayByItem = Convert.ToDouble(string.IsNullOrEmpty(item["PayByItem"] + "") ? "0" : item["PayByItem"] + "".Replace(",", ""));

                        Sale = Math.Round((s * Amount) + SpecialPrice, 2);

                        object[] myItems = {
                                          item["MS_Code"] + "", //1
                                          item["SO"] + "", //2
                                          item["MS_Name"] + ""==""?item["PRO_Name"] + "":item["MS_Name"] + "", //3
                                          s.ToString("###,###,###.##"), //4
                                          Amount.ToString("###,###,###.##"),//5
                                          item["MS_Unit"] + "",//6
                                          numFreeAmount.ToString("###,###,###.##"),//7
                                          DiscountBathByItem.ToString("###,###,###.##"),//8
                                          item["DiscountPercen"] + "",//9
                                          SpecialPrice.ToString("###,###,###.##"),//10
                                          (Sale).ToString("###,###,###.##"),//11
                                          PriceAfterDis.ToString("###,###,###.##"),//12
                                           item["Complimentary"]+""== "Y"?true:false ,//13
                                           item["MarketingBudget"]+""!= "N"&&item["MarketingBudget"]+""!=""?true:false,//14
                                           item["Gift"]+""!= "N"&&item["Gift"]+""!=""?true:false,//15
                                           item["Subject"]+""== "Y"?true:false,//16
                                           PayByItem.ToString("###,###,###.##"),//17
                                           item["Vat"]+"",//18
                                           item["ListOrder"]+"",//19
                                           item["Free"]+"",//20
                                           item["ByDr"]+"",//21
                                              item["MS_Code_Ref"]+"",//22
                                              item["MS_UnitStk"]+"",//23
                                              item["Dept"]+"",//24
                                              item["REQNo"]+"",//25
                                           imageList1.Images[10],//26
                                      };

                        SalePrice += Sale;

                        dgvData.Rows.Add(myItems);

                        if ((item["Free"] + "").Trim() == "" || (item["Free"] + "").ToLower().Contains("gift") || (item["Free"] + "").ToLower().Contains("complementary"))
                            dgvData.Rows[index].Cells["DisBath"].ReadOnly = false;
                        else
                        {
                            dgvData.Rows[index].Cells["DisBath"].ReadOnly = true;
                            dgvData.Rows[index].Cells["DisBath"].Style.BackColor = Color.Gainsboro;
                        }
                        //===============================================================

                        index++;

                        lbDoctorCom.Text = item["DR_COM"] + "";
                        lbCN.Text = item["CN"] + "";
                        //lbSO.Text = item["SO"] + "";
                        lbNameT.Text = item["FullNameThai"] + "" != "" ? item["FullNameThai"] + "" : item["FullNameEng"] + "";
                        // lbNameE.Text = item["FullNameEng"] + "";
                        lbIR.Text = item["SOT_Code"] + "";
                        txtIntNetTotal.Text = SalePrice.ToString("###,###,###.##");
                        txtRemark.Text = item["Remark"] + "";
                        txtBillTo.Text = item["BillTo"] + "";
                        txtBillTo.Text = item["BillTo"] + "";
                        txtIntDiscountBath.Text = PriceCreditRef.ToString("###,###,###.##");
                        lbSORef.Text = item["SORefAccount"] + "";
                        labelSORef.Text = item["SORef"] + "";
                        labelSORef.Visible = label5.Visible = item["SORef"] + "" != "";
                        labelProName.Visible = item["PRO_Name"] + "" != "";
                        labelProName.Text = "Pro : " + item["PRO_Name"] + "";
                        labelBranch.Text = BranchName;
                        string dateFormat = "yyyy/MM/dd";
                        string resultdt = Convert.ToDateTime(item["DateSave"] + "" == "" ? DateTime.Now.ToString() : item["DateSave"] + "").ToString(dateFormat);

                        dtpDateSave.Value = string.IsNullOrEmpty(item["DateSave"] + "") ? DateTime.Now : Convert.ToDateTime(resultdt);
                    }
                    //foreach (DataRowView item in dtSumOfTreat.DefaultView)
                    //{
                    //    dgvData.Rows[2].Cells[3].Value = true;
                    //}

                    //var myItemssum = new[]
                    //                      { "",
                    //                          "",
                    //                          "",
                    //                          "รวม",
                    //                          SalePrice.ToString("###,###,###.##"),
                    //                      };
                    //dgvData.Rows.Add(myItemssum);
                    ///summary==========
                    //dgvData.Rows[dgvData.RowCount - 1].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Bold);
                    //dgvData.Rows[dgvData.RowCount - 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    //dsSumOfTreat = new Business.SumOfTreatment().SelectSumOfTreatment("SELECTSUMOFTREATMENT", VN);//Edit By tu_cs
                    dtSumOfTreatPay = new Business.SumOfTreatment().SelectSumOfTreatment("SELECTSUMOFTREATMENT", SO, VN).Tables[0];
                    //dtSumOfTreatPay = dsSumOfTreat.Tables[0];

                    foreach (DataRowView item in dtSumOfTreatPay.DefaultView)
                    {
                        double s = Convert.ToDouble(string.IsNullOrEmpty(item["NetAmount"] + "") ? "0" : item["NetAmount"] + "".Replace(",", ""));
                        LastSalePrice = Math.Round(s, 2);
                        double DiscountBath = Convert.ToDouble(string.IsNullOrEmpty(item["DiscountBath"] + "") ? "0" : item["DiscountBath"] + "".Replace(",", ""));
                        txtearnestmoney.Text = Convert.ToDouble(string.IsNullOrEmpty(item["EarnestMoney"] + "") ? "0" : item["EarnestMoney"] + "".Replace(",", "")).ToString("###,###,###.##");
                        txtIntDiscountAllItemBath.Text = string.IsNullOrEmpty(item["DiscountPercen"] + "") ? "" : item["DiscountPercen"] + "";
                        if (PriceCreditRef == 0 || DiscountBath > PriceCreditRef)
                        {
                            txtIntDiscountBath.Text = Convert.ToDouble(string.IsNullOrEmpty(item["DiscountBath"] + "") ? "0" : item["DiscountBath"] + "".Replace(",", "")).ToString("###,###,###.##");
                        }
                        txtUnpaid.Text = Convert.ToDouble(string.IsNullOrEmpty(item["Unpaid"] + "") ? "0" : item["Unpaid"] + "".Replace(",", "")).ToString("###,###,###.##");
                        //dtpDateSave.Value = Convert.ToDateTime(string.IsNullOrEmpty(item["DateSave"] + "") ? DateTime.Now.ToString() : item["DateSave"] + "");
                        comboBoxCommission.SelectedValue = item["EN_COMS"] + "";
                        comboBoxCommission2.SelectedValue = item["EN_COMS2"] + "";

                    }

                    BindCashCredit();
                    dgvData.ClearSelection();
                    //txtIntNetTotal.Text = LastSalePrice>0 ? LastSalePrice.ToString("###,###,###.##") : SalePrice.ToString("###,###,###.##");//ยอดหลังหักลด
                    txtUnpaid.Text = LastSalePrice > 0 ? LastSalePrice.ToString("###,###,###.##") : SalePrice.ToString("###,###,###.##");//ลูกหนี้ค้างชำระ
                    summoneyDiscount();
                    summoney();

                    //txtearnestmoney.Text = EarnestMoney.ToString("###,###,###.##");
                    //LastSalePrice = SalePrice - (DiscountPercen + DiscountBath);
                    //Unpaid = LastSalePrice - EarnestMoney;
                    //txtUnpaid.Text = Unpaid.ToString("###,###,###.##");
                    //txtIntDiscountPercen.Text = DiscountPercen.ToString();
                    //txtIntDiscountBath.Text = DiscountBath.ToString();
                    FilterCash_Credit("All");

                    if (ReqStock)
                        btnREQStock.Enabled = true;
                    else btnREQStock.Enabled = false;

                }
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
        }
        //private void DisplayPayInComboColumn(List<string> lsPayin,DataGridView dataGrid,string cname)
        //{
        //    if(lsPayin.Count()<=0) return;
        //    DataGridViewComboBoxColumn column = (DataGridViewComboBoxColumn)dataGrid.Columns[cname];
        //    for (int x = 0; x <= dataGrid.Rows.Count - 1; x++)
        //    {
        //        DataGridViewCell cell = dataGrid.Rows[x].Cells[cname];
        //        if (column.Items.Count > 0)
        //        {
        //            cell.Value = lsPayin[x];
        //        }
        //    }
        //}
        //private void DisplayDefaultPayInComboColumn(List<string> lsPayin, DataGridView dataGrid, string cname)
        //{
        //    DataGridViewComboBoxColumn column = (DataGridViewComboBoxColumn)dataGrid.Columns[cname];
        //    //for (int x = 0; x <= dataGrid.Rows.Count - 1; x++)
        //    //{
        //    DataGridViewCell cell = dataGrid.Rows[dataGrid.RowCount-1].Cells[cname];
        //        if (column.Items.Count > 0)
        //        {
        //            cell.Value = lsPayin[0];
        //        }
        //    //}
        //}
        //private void DisplayCardTypeComboColumn(List<string> lsCardType, DataGridView dataGrid, string cname)
        //{
        //    DataGridViewComboBoxColumn column = (DataGridViewComboBoxColumn)dataGrid.Columns[cname];
        //    for (int x = 0; x <= dataGrid.Rows.Count - 1; x++)
        //    {
        //        DataGridViewCell cell = dataGrid.Rows[x].Cells[cname];
        //        if (column.Items.Count > 0)
        //        {
        //            cell.Value = lsCardType[x];
        //        }
        //    }
        //}
        private void dgvData_RowPostPaint_1(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }
        private void dataGridViewCredit_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            //e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
            //                      e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }
        //private void dataGridViewCashTransfer_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        //{
        //    var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
        //    e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
        //                          e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        //}

        private void itemID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar.ToString() != "."
                )
            {
                e.Handled = true;
            }
        }

        private int comboindex = 0;
        //private void dataGridViewCashTransfer_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        //{
        //    try
        //    {
        //        //if (dataGridViewCashTransfer.CurrentCell.ColumnIndex == dataGridViewCashTransfer.Columns["CashCurrent"].Index)
        //        //{
        //        //    TextBox itemID = e.Control as TextBox;
        //        //    if (!string.IsNullOrEmpty(itemID.Text.Trim()))
        //        //    {

        //        //        itemID.KeyPress += new KeyPressEventHandler(itemID_KeyPress);
        //        //        string v = string.IsNullOrEmpty(itemID.Text) ? "" : itemID.Text + "".Replace(",", "");
        //        //        if (v == "") return;
        //        //        decimal sss = Convert.ToDecimal(v);
        //        //        itemID.Text = sss.ToString("###,###,###.##");
        //        //    }
        //        //}
        //        //ComboBox cb = e.Control as ComboBox;
        //        //if (cb != null)
        //        //{
        //        //    comboindex = dataGridViewCashTransfer.CurrentCell.ColumnIndex;
        //        //    // first remove event handler to keep from attaching multiple:
        //        //    cb.SelectedIndexChanged -= new EventHandler(cbCash_SelectedIndexChanged);

        //        //    // now attach the event handler
        //        //    cb.SelectedIndexChanged += new EventHandler(cbCash_SelectedIndexChanged);
        //        //    //cb.SelectedValue = 4;
        //        //    //object selectedValue = dataGridViewCashTransfer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        //        //    return;
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //}

        //void cbCash_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (dataGridViewCashTransfer.CurrentCell.ColumnIndex != comboindex) return;

        //    //dataGridViewCashTransfer.Rows[dataGridViewCashTransfer.CurrentCell.RowIndex].Cells[
        //    //    dataGridViewCashTransfer.CurrentCell.ColumnIndex].Value = "ไม่ระบุ";
        //    ComboBox combo = sender as ComboBox;
        //    if (combo == null) return;
        //    string[] s = (dataGridViewCashTransfer.CurrentRow.Cells["PayinCash"].Value + "").Split(':');
        //    if (s.Count() != 2) return;
        //    dataGridViewCashTransfer.CurrentRow.Cells["NoBill1"].Value = s[1];
        //    //MessageBox.Show(dataGridViewCashTransfer.CurrentRow.Cells["PayinCash"].Value + "");
        //}
        //void cbCredit_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    if (dataGridViewCreditTransfer.CurrentCell.ColumnIndex != comboindex) return;

        //    //dataGridViewCashTransfer.Rows[dataGridViewCashTransfer.CurrentCell.RowIndex].Cells[
        //    //    dataGridViewCashTransfer.CurrentCell.ColumnIndex].Value = "ไม่ระบุ";
        //    ComboBox combo = sender as ComboBox;
        //    if (combo == null) return;
        //    //dataGridViewCreditTransfer.CancelEdit();
        //    //string[] s = (dataGridViewCreditTransfer.CurrentRow.Cells["PayinCredit"].Value + "").Split(':');
        //    //dataGridViewCreditTransfer.CurrentRow.Cells["NoBill2"].Value = s[1];
        //    ////MessageBox.Show(dataGridViewCashTransfer.CurrentRow.Cells["PayinCash"].Value + "");
        //    //foreach (DataGridViewRow row in dataGridViewCreditTransfer.Rows)
        //    //{
        //    //    string[] ss = (row.Cells["PayinCredit"].Value + "").Split(':');
        //    //   // creditInfo.PayInID = int.Parse(s[0]);
        //    //}
        //}
        //private void dataGridViewCredit_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        //{
        //    try
        //    {


        //        if (dataGridViewCreditTransfer.CurrentCell.ColumnIndex == dataGridViewCreditTransfer.Columns["cash"].Index || dataGridViewCreditTransfer.CurrentCell.ColumnIndex == dataGridViewCreditTransfer.Columns["installment"].Index)
        //        {
        //            TextBox itemID = e.Control as TextBox;
        //            if (itemID != null)
        //            {
        //                itemID.KeyPress += new KeyPressEventHandler(itemID_KeyPress);
        //            }
        //        }
        //        ComboBox cb = e.Control as ComboBox;
        //        if (cb != null)
        //        {
        //            comboindex = dataGridViewCreditTransfer.CurrentCell.ColumnIndex;
        //            // first remove event handler to keep from attaching multiple:
        //            cb.SelectedIndexChanged -= new EventHandler(cbCredit_SelectedIndexChanged);
        //            // now attach the event handler
        //            cb.SelectedIndexChanged += new EventHandler(cbCredit_SelectedIndexChanged);
        //            //cb.SelectedValue = 4;
        //            //object selectedValue = dataGridViewCashTransfer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        //            return;
        //        }
        //    }
        //    catch (Exception)
        //    {

        //    }
        //}
        double sum1 = 0;
        double sum2 = 0;

        //private void dataGridViewCashTransfer_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {

        //        //checkmoney = true;

        //        if (dataGridViewCashTransfer.CurrentCell.ColumnIndex == dataGridViewCashTransfer.Columns["CashCurrent"].Index)
        //        {
        //            string v = string.IsNullOrEmpty(dataGridViewCashTransfer.CurrentCell.Value + "") ? "" : dataGridViewCashTransfer.CurrentCell.Value + "".Replace(",", "");
        //            if (v == "") return;
        //            decimal sss = Convert.ToDecimal(v);
        //            dataGridViewCashTransfer.CurrentCell.Value = sss.ToString("###,###,###.##");
        //        }

        //        summoney();

        //        string[] s = (dataGridViewCashTransfer.CurrentRow.Cells["PayinCash"].Value + "").Split(':');
        //        if (s.Count() != 2) return;
        //        dataGridViewCashTransfer.CurrentRow.Cells["NoBill1"].Value = s[1];

        //        if (checkmoney == false) //return;
        //        {
        //            dataGridViewCashTransfer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
        //            summoney();
        //        }


        //    }
        //    catch (Exception)
        //    {
        //    }
        //}

        private void dataGridViewCredit_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (dataGridViewCreditTransfer.CurrentCell.ColumnIndex == dataGridViewCreditTransfer.Columns["cash"].Index)
                {
                    string v = string.IsNullOrEmpty(dataGridViewCreditTransfer.CurrentCell.Value.ToString()) ? "" : dataGridViewCreditTransfer.CurrentCell.Value + "".Replace(",", "");
                    if (v == "") return;
                    decimal sss = Convert.ToDecimal(v);
                    dataGridViewCreditTransfer.CurrentCell.Value = sss.ToString("###,###,###.##");
                }

                summoney();

                string[] s = (dataGridViewCreditTransfer.CurrentRow.Cells["PayinCredit"].Value + "").Split(':');
                if (s.Count() != 2) return;
                dataGridViewCreditTransfer.CurrentRow.Cells["NoBill2"].Value = s[1];

                summoney();

                if (checkmoney != false) return;
                dataGridViewCreditTransfer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                checkmoney = true;



            }
            catch (Exception)
            {
            }

        }
        private void SetNumberFormat()
        {
            //foreach (DataGridViewRow row in dataGridViewCashTransfer.Rows)
            //{
            //    string cashmoney = row.Cells["cashmoney"].Value + "";
            //    cashmoney = cashmoney.Replace(",", "");
            //    //double s = string.IsNullOrEmpty(cashmoney) ? 0 ; : Convert.ToDouble(cashmoney);
            //    if (string.IsNullOrEmpty(cashmoney)) continue;

            //    row.Cells["cashmoney"].Value = Convert.ToDouble(cashmoney) == 0 ? "0.00" : Convert.ToDouble(cashmoney).ToString("###,###,###.##");
            //}
            foreach (DataGridViewRow row in dataGridViewCreditTransfer.Rows)
            {
                if (row.Cells["cash"].Value + "" == "") continue;
                string cash = row.Cells["cash"].Value + "";
                cash = cash.Replace(",", "");
                //double s = string.IsNullOrEmpty(cash) ? 0 : Convert.ToDouble(cash);
                if (!string.IsNullOrEmpty(cash))
                {
                    row.Cells["cash"].Value = Convert.ToDouble(cash) == 0 ? "0.00" : Convert.ToDouble(cash).ToString("###,###,###.##");
                }



                //string number = row.Cells["number"].Value + "";
                //number = number.Replace(" ", "");

                //decimal numberFormat = string.IsNullOrEmpty(number) ? 0 : Convert.ToDecimal(number);

                //row.Cells["number"].Value = numberFormat == 0 ? "" : numberFormat.ToString("#### #### #### ####");
                //if (number.Length != 16) row.Cells["number"].Value = "";
            }
        }
        private void summoney()
        {
            try
            {
                sum1 = 0;
                sum2 = 0;


                ShowSumList_Check();


                double total3 = dataGridViewCreditTransfer.Rows.Cast<DataGridViewRow>()
                  .Where(r => r.Cells["cash"].Value + "" != "")
                  .Sum(t => Convert.ToDouble(t.Cells["cash"].Value));
                //double total4 = dataGridViewCreditTransfer.Rows.Cast<DataGridViewRow>()
                //    .Where(r => r.Cells["summary"].Value + "" != "" && r.Cells["statusdelcredit"].Value != "DEL")
                //    .Sum(t => Convert.ToDouble(t.Cells["summary"].Value));

                sum1 = total3; //+ total4;// total1 + total2 +

                EarnestMoney = sum1 + sum2;
                UnpaidOld = Unpaid;
                Unpaid = LastSalePrice - EarnestMoney;
                txtearnestmoney.Text = EarnestMoney == 0 ? "0.00" : EarnestMoney.ToString("###,###,###.##");
                txtUnpaid.Text = Unpaid == 0 ? "0.00" : Unpaid.ToString("###,###,###.##");



                if (Unpaid < 0)
                {
                    checkmoney = false;
                    //MessageBox.Show("ใส่จำนวนเงินไม่ถูกต้อง \"Number incorrect\"");
                    Unpaid = UnpaidOld;
                }
                else
                {
                    checkmoney = true;
                }

                CheckSummoneyOK();//จ่ายหมด disable ปุ่ม

                DisableButton(checkmoney);
                SetNumberFormat();

                //==========================ทีปกร DisBtn print Bill===================

                //NoBill = dataGridViewCashTransfer.Rows.Cast<DataGridViewRow>().Any(r => r.Cells["NoBill1"].Value + "" == "Y");
                //if (NoBill == false)
                //{
                //    NoBill = dataGridViewCreditTransfer.Rows.Cast<DataGridViewRow>().Any(r => r.Cells["NoBill2"].Value + "" == "Y");
                //}
                btnPrintInv.Enabled = !NoBill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CheckSummoneyOK()
        {
            bool close = false;
            close = Unpaid == 0 ? false : true;

            //btnAdd.Enabled = close;
            //listBoxCashTyp.Enabled = close;
        }
        private void DisableButton(bool en)
        {
            //btnAdd.Enabled = en;
            //btnCloseStatus.Enabled = en;
            btnPrintInv.Enabled = en;
            btnRefMedical.Enabled = en;
            btnSave.Enabled = en;
            btnBill2.Enabled = en;
            buttonTax.Enabled = en;
        }
        private void summoneyDiscount()
        {
            try
            {
                sum1 = 0;
                sum2 = 0;
                double DiscountByItemBath = dgvData.Rows.Cast<DataGridViewRow>()
                    .Where(r => r.Cells["DisBath"].Value + "" != "")
                    .Sum(t => Convert.ToDouble(t.Cells["DisBath"].Value));//Yai 25-4-2014

                //foreach (DataGridViewRow dr in from DataGridViewRow dr in dgvData.Rows let v = dr.Cells["complimentary"].Value where (bool)v select dr)
                //{
                //    DiscountByItemBath += Convert.ToDouble(dr.Cells["DisBath"].Value);
                //}

                //DiscountComP = dgvData.Rows.Cast<DataGridViewRow>()
                //.Where(r => r.Cells["complimentary"].Value == true)
                //.Sum(t => (Convert.ToDouble(t.Cells["money_dis"].Value)));

                DiscountComP = 0;
                DiscountMBudget = 0;
                DiscountGiftV = 0;
                DiscountSubject = 0;
                double SpecialPrice = 0;
                foreach (DataGridViewRow dr in from DataGridViewRow dr in dgvData.Rows let v = dr.Cells["complimentary"].Value where (bool)v select dr)
                {
                    DiscountComP += dr.Cells["Money"].Value + "" == "" ? 0 : Convert.ToDouble(dr.Cells["Money"].Value);
                    SpecialPrice += (dr.Cells["colSpecialPrice"].Value + "" == "" ? 0 : Convert.ToDouble(dr.Cells["colSpecialPrice"].Value));
                    DiscountComP += SpecialPrice;
                }
                SpecialPrice = 0;
                foreach (DataGridViewRow dr in from DataGridViewRow dr in dgvData.Rows let v = dr.Cells["MarketingBudget"].Value where (bool)v select dr)
                {
                    DiscountMBudget += dr.Cells["Money"].Value + "" == "" ? 0 : Convert.ToDouble(dr.Cells["Money"].Value);//money_dis
                    SpecialPrice = dr.Cells["colSpecialPrice"].Value + "" == "" ? 0 : Convert.ToDouble(dr.Cells["colSpecialPrice"].Value);
                    DiscountMBudget += SpecialPrice;
                }
                foreach (DataGridViewRow dr in from DataGridViewRow dr in dgvData.Rows let v = dr.Cells["Gift"].Value where (bool)v select dr)
                {
                    //  DiscountGiftV +=dr.Cells["DisBath"].Value+""==""?0: Convert.ToDouble(dr.Cells["DisBath"].Value);
                    //dr.Cells["money_dis"].Value = (Convert.ToDouble(dr.Cells["discount"].Value) * Convert.ToDouble(dr.Cells["Money"].Value) / 100);

                }
                SpecialPrice = 0;
                foreach (DataGridViewRow dr in from DataGridViewRow dr in dgvData.Rows let v = dr.Cells["Subject"].Value where (bool)v select dr)
                {
                    DiscountSubject += dr.Cells["Money"].Value + "" == "" ? 0 : Convert.ToDouble(dr.Cells["Money"].Value);
                }

                foreach (DataGridViewRow dr in dgvData.Rows)
                {
                    // if ((bool)dr.Cells["Subject"].Value || (dr.Cells["MarketingBudget"].Value+""!="Y" && dr.Cells["MarketingBudget"].Value+""!="")   || (bool)dr.Cells["complimentary"].Value)
                    if ((bool)dr.Cells["Subject"].Value || (bool)dr.Cells["MarketingBudget"].Value || (bool)dr.Cells["complimentary"].Value)
                    {
                        //dr.Cells["money_dis"].Value =
                        //    Convert.ToDouble(string.IsNullOrEmpty(dr.Cells["Money"].Value + "")
                        //                         ? ""
                        //                         : dr.Cells["Money"].Value + "").ToString("###,###,###.##");
                        dr.Cells["money_dis"].Value = 0; //Yai 25-4-2014
                    }
                    if ((bool)dr.Cells["Gift"].Value)
                    {
                        double dis = string.IsNullOrEmpty(dr.Cells["discount"].Value + "") ? 0 : Convert.ToDouble(dr.Cells["discount"].Value + "");
                        if (dis <= 0) continue;
                        //dr.Cells["money_dis"].Value = (Convert.ToDouble(dr.Cells["Money"].Value) - ((Convert.ToDouble(dr.Cells["discount"].Value) * Convert.ToDouble(dr.Cells["Money"].Value) / 100))).ToString("###,###,###.##");
                        dr.Cells["money_dis"].Value = (Convert.ToDouble(dr.Cells["Money"].Value.ToString().Replace(",", "")) - Convert.ToDouble(dr.Cells["DisBath"].Value)).ToString("###,###,###.##");
                    }
                }

                LastSalePrice = dgvData.Rows.Cast<DataGridViewRow>()
                 .Where(r => r.Cells["money_dis"].Value + "" != "")
                 .Sum(t => Convert.ToDouble(t.Cells["money_dis"].Value));
                DiscountAll = DiscountComP + DiscountMBudget + DiscountGiftV + DiscountSubject + DiscountByItemBath;//yai 02-02-2017
                txtIntDiscountAllItemBath.Text = DiscountByItemBath.ToString("###,###,###.##");

                DiscountBath = Convert.ToDouble(string.IsNullOrEmpty(txtIntDiscountBath.Text.Replace(",", "")) ? "0" : txtIntDiscountBath.Text.Replace(",", ""));

                //if (LastSalePrice < SalePrice) 
                //    SalePrice = LastSalePrice;
                //else SalePrice = LastSalePrice;

                //if (LastSalePrice > SalePrice && LastSalePrice>0)
                //    SalePrice = LastSalePrice;

                // else SalePrice = LastSalePrice;
                //if(DiscountAll>0)
                LastSalePrice = Math.Round(SalePrice, 2) - (Math.Round(DiscountBath, 2) + Math.Round(DiscountAll, 2));

                txtBeforDiscount.Text = SalePrice.ToString("###,###,###.##");//ยอดก่อนหักลด
                txtIntNetTotal.Text = LastSalePrice.ToString("###,###,###.##");//ยอดหลังหักลด
            }
            catch (Exception)
            {
            }
        }
        private void CalDisCount()
        {
            try
            {
                DiscountPercen = Convert.ToDouble(string.IsNullOrEmpty(txtIntDiscountAllItemBath.Text) ? "0" : txtIntDiscountAllItemBath.Text.Replace(",", ""));
                DiscountBath = Convert.ToDouble(string.IsNullOrEmpty(txtIntDiscountBath.Text) ? "0" : txtIntDiscountBath.Text.Replace(",", ""));
                //DiscountPercen = SalePrice * (DiscountPercen / 100);
                lbPersenBath.Text = "(" + DiscountPercen.ToString("###,###,###.##") + ")";
                LastDiscount = DiscountPercen + DiscountBath;
                LastSalePrice = SalePrice - LastDiscount;

                txtIntNetTotal.Text = LastSalePrice.ToString("###,###,###.##");

                Unpaid = LastSalePrice - EarnestMoney;
                txtUnpaid.Text = Unpaid.ToString("###,###,###.##");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtIntDiscountPercen_TextChanged(object sender, EventArgs e)
        {
            // CalDisCount();
        }

        private void txtIntDiscountBath_TextChanged(object sender, EventArgs e)
        {

            CalDisCount();
        }
        private void txtIntDiscountBath_Leave(object sender, EventArgs e)
        {
            try
            {
                double d = Convert.ToDouble(txtIntDiscountBath.Text);
                txtIntDiscountBath.Text = d.ToString("###,###,###.##");
            }
            catch (Exception)
            {
            }
        }
        private void btnCloseStatus_Click(object sender, EventArgs e)
        {
            try
            {
                if (
                      MessageBox.Show(this, "คุณต้องการปิดรายการนี้ ? \"Confirm Close ?.\"", "ยืนยันการการปิดรายการ",
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
                      DialogResult.No)
                {
                    //popSOClose frm2 = new popSOClose();
                    ////pp.ShowDialog();
                    //DialogResult dr = frm2.ShowDialog(this);
                    //if (dr != DialogResult.OK)
                    //{
                    //    frm2.Close();
                    //    return;
                    //}
                    using (var f = new popSOClose())
                    {
                        f.SO = SO;
                        DialogResult dr = f.ShowDialog(this);
                        if (dr != DialogResult.OK)
                        {
                            return;
                        }

                        Entity.SumOfTreatment info = new SumOfTreatment();
                        if (f.OpenCourse) info.QueryType = "SOOpen";
                        else info.QueryType = "SOClose";

                        //info.SO = lbSO.Text;
                        info.Refund = f.Refund;
                        info.RefundDate = f.RefundDate;
                        info.RefundType = f.RefundType;
                        info.RefundRemark = f.RefundRemark;
                        info.EN_Save = Entity.Userinfo.EN.Trim();

                        int? intStatus = new Business.SumOfTreatment().SOClose(info);
                        if (intStatus > 0)
                        {
                            if (f.OpenCourse)
                                MessageBox.Show("เปิดรายการเรียบร้อยแล้ว \"Open\"");
                            else
                                MessageBox.Show("ปิดรายการเรียบร้อยแล้ว \"Closed\"");

                            Statics.frmPaidSelectSOT = null;
                            this.Close();
                        }
                    } // Disposal, even on exceptions or nested return statements, occurs here.
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefMedical_Click(object sender, EventArgs e)
        {
            Statics.frmMedicalOrderSetting = new FrmMedicalOrderSetting();
            Statics.frmMedicalOrderSetting.BackColor = Color.FromArgb(255, 230, 217);
            Statics.frmMedicalOrderSetting.Text = Text + Statics.StrAdd;
            Statics.frmMedicalOrderSetting.RefVN = VN;
            Statics.frmMedicalOrderSetting.lblRefVN.Text = "อ้างอิง VN : " + VN;
            Statics.frmMedicalOrderSetting.lblRefVN.Visible = true;
            Statics.frmMedicalOrderSetting.txtBalanceRef.Text = txtUnpaid.Text;
            Statics.frmMedicalOrderSetting.txtBalanceRef.Visible = true;
            Statics.frmMedicalOrderSetting.lblBalanceRef.Visible = true;
            Statics.frmMedicalOrderSetting.Show(Statics.frmMain.dockPanel1);
        }

        private void PrintBillVat()
        {
            try
            {
                FrmPreviewRpt obj = new FrmPreviewRpt();
                DataRow dr;

                DataTable dtTmp;
                //dtSumOfTreatPay
                string sql = string.Format("Vat='{0}'", "Y");
                if (dtSumOfTreat.Select(sql).Any())
                    dtTmp = dtSumOfTreat.Select(sql).CopyToDataTable();
                else
                    return;
                //dr = dtTmp.NewRow();
                //object sumObject;
                //sumObject = dtTmp.Compute("Sum(PriceAfterDocFee)", "");
                //if (sumObject != null)
                //{
                //    dr["SOT_Code"] = dtTmp.Rows[0]["SOT_Code"];
                //    dr["CN"] = dtTmp.Rows[0]["CN"];
                //    dr["VN"] = dtTmp.Rows[0]["VN"];
                //    dr["ReceiptNo"] = dtTmp.Rows[0]["ReceiptNo"];
                //    dr["FullNameThai"] = dtTmp.Rows[0]["FullNameThai"];
                //    dr["Amount"] = "1";
                //    dr["MS_NAME"] = "ค่าแพทย์/Doctor Fee";
                //    dr["PriceAfterDis"] = double.Parse(sumObject.ToString());
                //    dtTmp.Rows.InsertAt(dr, 0);
                //}
                string strTypeofPay = "";
                obj.FormName = "RptSOFBillVAT";
                double dblCredit = 0.00;
                double dblCash = 0.00;
                string strBankName = "";

                foreach (DataGridViewRow row in dataGridViewCreditTransfer.Rows)
                {

                    if (row.Cells["cash"].Value + "" != "")
                    {
                        if (row.Cells["BillType"].Value + "" == "PayCredit")
                        {
                            dblCredit += double.Parse(row.Cells["cash"].Value + ""); //
                            if (strBankName != "") strBankName += ",";
                            strBankName += row.Cells["name"].Value + "";
                        }
                        else if (row.Cells["BillType"].Value + "" == "PayCash")
                        {
                            dblCash += double.Parse(row.Cells["cash"].Value + ""); //
                        }
                    }
                }
                //foreach (DataGridViewRow row in dataGridViewCashTransfer.Rows)
                //{
                //    if (row.Cells["CashCurrent"].Value + "" != "")
                //    {
                //        dblCash += double.Parse(row.Cells["CashCurrent"].Value + ""); //
                //    }
                //}
                if (dblCredit > 0)
                {
                    //strTypeofPay = " บัตรเครดิต " + strBankName + " " + dblCredit.ToString("###,##0.00") + " บาท ";
                    strTypeofPay = " บัตรเครดิต/Credit Card :" + dblCredit.ToString("###,##0.00") + " บาท ";
                }
                if (dblCash > 0)
                {
                    if (strTypeofPay.Length > 0) strTypeofPay += "/";
                    strTypeofPay += " เงินสด/Cash :" + dblCash.ToString("###,##0.00") + " บาท";
                }
                obj.DiscountBath = string.IsNullOrEmpty(txtIntDiscountBath.Text.Trim())
                                       ? 0.00
                                       : double.Parse(txtIntDiscountBath.Text.Trim());
                obj.TypeOfPayment = strTypeofPay;
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
        private void PrintBillNoVatINV(int type)
        {
            try
            {
                FrmPreviewRpt2Page obj = new FrmPreviewRpt2Page();
                DataRow dr;
                DataTable dtTmp = new DataTable();
                DataTable dtClone = new DataTable();
                List<DataTable> tables = new List<DataTable>();
                string InvNo = "";
                double dblCredit = 0.00;
                double dblCash = 0.00;
                double SumUnpaid = 0.00;
                string strTypeofPay = "";
                string strBankName = "";

                foreach (var items in itemselect)
                {
                    var itemsSOT = items.Split(';');

                    if (!items.Contains("PRO"))
                    {
                        dsSumOfTreat = new Business.SumOfTreatment().SelectSumOfTreatment("SELECT", itemsSOT[0], itemsSOT[1], ReceiptDateCurrent);
                    }
                    else
                    {
                        dsSumOfTreat = new Business.SumOfTreatment().SelectSumOfTreatment("SELECTBYPRO", itemsSOT[0], itemsSOT[1], ReceiptDateCurrent);
                    }
                    dtClone = dsSumOfTreat.Tables[0];
                    tables.Add(dtClone);

                    SumUnpaid += dtClone.Rows[0]["Unpaid"] + "" == "" ? 0 : Convert.ToDouble(dtClone.Rows[0]["Unpaid"]);

                    obj.FormName = "RptSOFInvNoVatDiscountAll";

                    if (txtIntDiscountBath.Text != "" && txtIntDiscountBath.Text != "0.00")
                        obj.HasDiscount = true;


                    foreach (DataGridViewRow row in dataGridViewCreditTransfer.Rows)
                    {

                        if (row.Cells["cash"].Value + "" != "")
                        {
                            if (row.Cells["BillType"].Value + "" == "PayCredit")
                            {
                                dblCredit += double.Parse(row.Cells["cash"].Value + ""); 
                                if (strBankName != "") strBankName += ",";
                                strBankName += row.Cells["name"].Value + "";
                            }
                            else if (row.Cells["BillType"].Value + "" == "PayCash")
                            {
                                dblCash += double.Parse(row.Cells["cash"].Value + ""); 
                            }
                        }
                    }
                }
                dtTmp = tables.SelectMany(dt => dt.AsEnumerable()).CopyToDataTable();
                foreach(DataRow tmp in dtTmp.Rows)
                {
                    tmp["Unpaid"] = SumUnpaid + "";
                }
                //dtTmp.Rows[0]["Unpaid"] = SumUnpaid + "";
                if (dblCredit > 0)
                {
                    strTypeofPay = " บัตรเครดิต/Credit Card :" + dblCredit.ToString("###,###,##0.00") + " บาท ";
                }
                if (dblCash > 0)
                {
                    if (strTypeofPay.Length > 0) strTypeofPay += "/";
                    strTypeofPay += " เงินสด/Cash :" + dblCash.ToString("###,###,##0.00") + " บาท";
                }
                obj.DiscountBath = string.IsNullOrEmpty(txtIntDiscountBath.Text.Trim())
                                       ? 0.00
                                       : double.Parse(txtIntDiscountBath.Text.Trim());
                dblCredit += dblCash;
                obj.TypeOfPayment = strTypeofPay;
                obj.PayToday = dblCredit.ToString("###,###,##0.00");
                obj.PayTodayDouble = dblCredit;                
                obj.SumUnpaid = dtTmp.Rows[0]["Unpaid"] + "" == "" ? 0 : Convert.ToDouble(dtTmp.Rows[0]["Unpaid"]);
                obj.SumPriceAfterDis = Convert.ToDouble(dtTmp.Compute("Sum(PriceAfterDis)", ""));
                obj.INVNo = InvNo;
                obj.dt = dtTmp;
                obj.MaximizeBox = true;
                obj.TopMost = true;
                obj.Show();
                obj.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void PrintBillVatINV()
        {
            try
            {
                FrmPreviewRpt2Page obj = new FrmPreviewRpt2Page();
                DataRow dr;
                //obj.PrintType = Type;
                DataTable dtTmp;
                string InvNo = "";
                dtTmp = dtSumOfTreat;
                string sql = string.Format("Vat='{0}'", "Y");
                if (dtTmp.Select(sql).Any())
                {
                    dtTmp = dtTmp.Select(sql).CopyToDataTable();
                    InvNo = dtSumOfTreatInvoice.Select(sql).CopyToDataTable().Rows[0]["INVNo"] + "";
                }
                else
                    return;

                string strTypeofPay = "";
                obj.FormName = "RptSOFInvVatDiscount";
                if (Convert.ToInt32(dtTmp.Compute("Sum(DiscountBathByItem)", "")) > 0 || (txtIntDiscountBath.Text != "" && txtIntDiscountBath.Text != "0.00"))
                    obj.HasDiscount = true;

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

                foreach (DataGridViewRow row in dataGridViewCreditTransfer.Rows)
                {

                    if (row.Cells["cash"].Value + "" != "")
                    {
                        if (row.Cells["BillType"].Value + "" == "PayCredit")
                        {
                            dblCredit += double.Parse(row.Cells["cash"].Value + ""); //
                            if (strBankName != "") strBankName += ",";
                            strBankName += row.Cells["name"].Value + "";
                        }
                        else if (row.Cells["BillType"].Value + "" == "PayCash")
                        {
                            dblCash += double.Parse(row.Cells["cash"].Value + ""); //
                        }
                    }
                }
                if (dblCredit > 0)
                {
                    //strTypeofPay = " บัตรเครดิต " + strBankName + " " + dblCredit.ToString("###,##0.00") + " บาท ";
                    strTypeofPay = " บัตรเครดิต/Credit Card :" + dblCredit.ToString("###,###,##0.00") + " บาท ";
                }
                if (dblCash > 0)
                {
                    if (strTypeofPay.Length > 0) strTypeofPay += "/";
                    strTypeofPay += " เงินสด/Cash :" + dblCash.ToString("###,###,##0.00") + " บาท";
                }
                obj.DiscountBath = string.IsNullOrEmpty(txtIntDiscountBath.Text.Trim())
                                       ? 0.00
                                       : double.Parse(txtIntDiscountBath.Text.Trim());
                dblCredit += dblCash;
                obj.TypeOfPayment = strTypeofPay;
                obj.PayToday = dblCredit.ToString("###,###,##0.00");
                obj.PayTodayDouble = dblCredit;

                obj.SumUnpaid = Convert.ToDouble(dtTmp.Rows[0]["Unpaid"]);//.Compute("Sum(Unpaid)", ""));
                obj.INVNo = InvNo;
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

        private void buttonTax_Click(object sender, EventArgs e)
        {
            SaveSOF(false);
            BindFrmSumOfTreatment();
            PrintTaxVat(1);
        }
        private void buttonTaxClinic_Click(object sender, EventArgs e)
        {
            SaveSOF(false);
            BindFrmSumOfTreatment();
            PrintTaxVat(2);
        }

        private void PrintTaxVat(int type)//ใบเสร็จ vat
        {
            try
            {
                foreach (var items in itemselect)
                {
                    var itemsSOT = items.Split(';');
                    dsSumOfTreat = new Business.SumOfTreatment().SelectSumOfTreatment("SELECT", itemsSOT[0], itemsSOT[1], ReceiptDateCurrent);

                    FrmPreviewRpt2Page obj = new FrmPreviewRpt2Page();
                    DataRow dr;
                    DataTable dtTmp;
                    string InvNo = "";

                    dtTmp = dsSumOfTreat.Tables[0];

                    string sql = string.Format("Vat='{0}'", "Y");
                    if (dsSumOfTreat.Tables[0].Select(sql).Any())
                        dtTmp = dsSumOfTreat.Tables[0];
                    else
                        return;

                    string strTypeofPay = "";
                    if (type == 1)
                    {
                        obj.FormName = "RptSOFTaxVat";
                    }
                    else
                    {
                        obj.FormName = "RptSOFTaxVatClinic";
                    }
                    double dblCredit = 0.00;
                    double dblCash = 0.00;
                    string strBankName = "";

                    foreach (DataGridViewRow row in dataGridViewCreditTransfer.Rows)
                    {
                        if (row.Cells["cash"].Value + "" != "" && row.Cells["cash"].Value + "" == String.Format("{0:yyyy/MM/dd}", DateTime.Now))
                        {
                            if (row.Cells["BillType"].Value + "" == "PayCredit")
                            {
                                dblCredit += double.Parse(row.Cells["cash"].Value + ""); //
                                if (strBankName != "") strBankName += ",";
                                strBankName += row.Cells["name"].Value + "";
                            }
                            else if (row.Cells["BillType"].Value + "" == "PayCash")
                            {
                                dblCash += double.Parse(row.Cells["cash"].Value + ""); //
                            }
                        }
                    }
                    //foreach (DataGridViewRow row in dataGridViewCashTransfer.Rows)
                    //{
                    //    if (row.Cells["CashCurrent"].Value + "" != "" && row.Cells["PayCashDate"].Value + "" == String.Format("{0:yyyy/MM/dd}", DateTime.Now))
                    //    {
                    //        dblCash += double.Parse(row.Cells["CashCurrent"].Value + ""); //
                    //    }
                    //}
                    if (dblCredit > 0)
                    {
                        //strTypeofPay = " บัตรเครดิต " + strBankName + " " + dblCredit.ToString("###,##0.00") + " บาท ";
                        strTypeofPay = " บัตรเครดิต/Credit Card : " + dblCredit.ToString("###,###,##0.00") + " บาท ";
                    }
                    if (dblCash > 0)
                    {
                        if (strTypeofPay.Length > 0) strTypeofPay += "/";
                        strTypeofPay += " เงินสด//Cash :" + dblCash.ToString("###,###,##0.00") + " บาท";
                    }
                    obj.DiscountBath = string.IsNullOrEmpty(txtIntDiscountBath.Text.Trim())
                                           ? 0.00
                                           : double.Parse(txtIntDiscountBath.Text.Trim());
                    dblCredit += dblCash;
                    obj.TypeOfPayment = strTypeofPay;
                    obj.PayToday = dblCredit.ToString("###,###,##0.00");
                    obj.dt = dtTmp;
                    obj.MaximizeBox = true;
                    obj.TopMost = true;
                    obj.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSOF(true);
        }

        private void SaveNewReciept(bool saveclose)
        {
            try
            {

                SaveType = "SAVECREDITCARD";
                SumOfTreatment info = new SumOfTreatment();
                List<Entity.CreditCardSOT> listCredit = new List<CreditCardSOT>();
                Entity.CreditCardSOT creditInfo;
                info.QueryType = "UPDATE";
                info.SOT_Code = lbIR.Text;
                info.CN = lbCN.Text;
                //info.VN = lbSO.Text;
                info.SO = SO;
                string dateFormat = "yyyyMMdd";
                string resultdt = dtpDateSave.Value.ToString(dateFormat);
                info.DateSave = Convert.ToDateTime(resultdt);// dtpDateSave.Value; //new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,);// Convert.ToDateTime(DateTime.Now);//Convert.ToDateTime(txtStartProcedure.Text);
                info.DateUpdate = DateTime.Now;

                info.SalePrice = SalePrice;
                //info.Discount = LastDiscount;
                info.NetAmount = LastSalePrice;
                info.EarnestMoney = EarnestMoney;
                info.Unpaid = Unpaid;
                int sts = 0;
                if (Unpaid == 0)
                    sts = 2;
                else if (Unpaid != 0 && LastSalePrice != Unpaid)
                    sts = 1;
                else if (LastSalePrice == Unpaid)
                    sts = 0;

                info.MedStatus_Code = sts;
                info.Remark = txtRemark.Text;
                info.BillTo = txtBillTo.Text;

                info.DiscountAllItemBath = Convert.ToDouble(string.IsNullOrEmpty(txtIntDiscountAllItemBath.Text) ? "0" : txtIntDiscountAllItemBath.Text.Replace(",", ""));
                info.DiscountBath = Convert.ToDouble(string.IsNullOrEmpty(txtIntDiscountBath.Text) ? "0" : txtIntDiscountBath.Text.Replace(",", "")); ;
                info.EN_Save = Entity.Userinfo.EN.Trim();
                if (string.IsNullOrEmpty(comboBoxCommission.SelectedValue + "") || comboBoxCommission.SelectedValue == Entity.Userinfo.EN)
                    info.EN_COMS = Entity.Userinfo.EN.Trim();
                else
                {
                    info.EN_COMS = (comboBoxCommission.SelectedValue + "").Trim();
                }

                info.EN_COMS2 = (comboBoxCommission2.SelectedValue + "").Trim();
                info.PriceAfterDis = EarnestMoney;
                if (info.EN_COMS2 != "")
                    info.Com_Bath = info.Com_Bath2 = EarnestMoney / 2;
                else
                    info.Com_Bath = EarnestMoney;


                //For DiscountPercen===========================
                List<Entity.SupplieTrans> listSupplieTran = new List<SupplieTrans>();
                Entity.SupplieTrans SupplieTranInfo;
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    SupplieTranInfo = new SupplieTrans();
                    SupplieTranInfo.QueryType = "UPDATESUPPLIETRANS";
                    SupplieTranInfo.VN = VN;
                    SupplieTranInfo.SONo = SO;
                    SupplieTranInfo.MS_Code = row.Cells["MS_Code"].Value + ""; //Entity.Userinfo.EN;
                    SupplieTranInfo.DiscountPercen = string.IsNullOrEmpty(row.Cells["discount"].Value + "") ? 0 : Convert.ToDecimal(row.Cells["discount"].Value + "");
                    SupplieTranInfo.DiscountBath = string.IsNullOrEmpty(row.Cells["DisBath"].Value + "") ? 0 : Convert.ToDecimal(row.Cells["DisBath"].Value + "");
                    SupplieTranInfo.PriceAfterDis = Convert.ToDecimal(string.IsNullOrEmpty(row.Cells["money_dis"].Value + "") ? "0" : row.Cells["money_dis"].Value + "".Replace(",", ""));
                    SupplieTranInfo.PayByItem = Convert.ToDecimal(string.IsNullOrEmpty(row.Cells["PayByItem"].Value + "") ? "0" : row.Cells["PayByItem"].Value + "");
                    listSupplieTran.Add(SupplieTranInfo);
                }
                //For DiscountPercen===========================
                foreach (DataGridViewRow row in dataGridViewCreditTransfer.Rows)
                {
                    if (decimal.Parse(row.Cells["cash"].Value + "") == 0) continue;
                    creditInfo = new CreditCardSOT();
                    creditInfo.QueryType = SaveType;
                    creditInfo.VN = VN;
                    creditInfo.SO = SO;
                    creditInfo.EN = Entity.Userinfo.EN;
                    creditInfo.CN = lbCN.Text;
                    creditInfo.CardNumber = row.Cells["number"].Value + "";//เลขที่บัตร
                    //creditInfo.BankName = row.Cells["name"].Value + "";//
                    creditInfo.CD_Code = row.Cells["CD_Code"].Value + "";//
                    creditInfo.Pay_Code = row.Cells["Pay_CodeCre"].Value + "";
                    creditInfo.StatusDel = row.Cells["statusdelcredit"].Value + "";
                    creditInfo.CardType = row.Cells["CardType"].Value + "";
                    creditInfo.DateUpdate = row.Cells["PayCreditDate"].Value + "" == "" ? DateTime.Now : Convert.ToDateTime(row.Cells["PayCreditDate"].Value + "");
                    string[] s = (row.Cells["PayinCredit"].Value + "").Split(':');
                    creditInfo.PayInID = s[0] + "" == "" ? 0 : int.Parse(s[0]);
                    if (row.Cells["cash"].Value + "" != "")
                    {
                        creditInfo.CashMoney = decimal.Parse(row.Cells["cash"].Value + ""); //
                    }

                    listCredit.Add(creditInfo);

                }
                //foreach (DataGridViewRow row in dataGridViewCashTransfer.Rows)
                //{
                //    creditInfo = new CreditCardSOT();
                //    creditInfo.QueryType = SaveType;
                //    creditInfo.VN = VN;
                //    creditInfo.SO = SO;
                //    creditInfo.EN = Entity.Userinfo.EN;
                //    creditInfo.CN = lbCN.Text;
                //    //creditInfo.CardNumber = row.Cells["number"].Value + "";//เลขที่บัตร
                //    //creditInfo.BankName = row.Cells["cashtyp"].Value + "";//
                //    creditInfo.CD_Code = row.Cells["CD_CodeCash"].Value + "";//
                //    creditInfo.Pay_Code = row.Cells["Pay_Code"].Value + "";//
                //    creditInfo.StatusDel = row.Cells["statusdelcash"].Value + "";
                //    creditInfo.DateUpdate = row.Cells["PayCashDate"].Value + ""==""?DateTime.Now:Convert.ToDateTime(row.Cells["PayCashDate"].Value + "");
                //    string[] s = (row.Cells["PayinCash"].Value + "").Split(':');
                //    creditInfo.PayInID = int.Parse(s[0]);
                //    if (row.Cells["CashCurrent"].Value + "" != "")
                //    {
                //        creditInfo.CashMoney = decimal.Parse(row.Cells["CashCurrent"].Value + ""); //
                //    }
                //    listCredit.Add(creditInfo);
                //}
                info.CreditCardSotInfo = listCredit.ToArray();
                info.SupplieTranInfo = listSupplieTran.ToArray();

                intStatus = new Business.SumOfTreatment().UpdateSumOfTreatment(info);

                if (intStatus > 0)
                {
                    if (saveclose)
                    {
                        DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, Statics.SaveComplete);
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("ขัดข้อง \"Save error\"");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public class gvdata_model
        {
            public string MS_SO { get; set; }
            public string money_dis { get; set; }
            public string DisBath { get; set; }
            public string Money { get; set; }
        }
        private void SaveSOF(bool saveclose)
        {
            try
            {
                using (var context = new m_DataSet.EntitiesOPD_System())
                {
                    SaveType = "SAVECREDITCARD";
                    List<gvdata_model> gvList = new List<gvdata_model>();
                    foreach (DataGridViewRow dr in dgvData.Rows) // list รายการ ใน gridview
                    {
                        gvdata_model gvdata = new gvdata_model();
                        gvdata.MS_SO = dr.Cells["MS_SO"].Value + "";
                        gvdata.money_dis = dr.Cells["money_dis"].Value + "";
                        gvdata.DisBath = dr.Cells["DisBath"].Value + "";
                        gvdata.Money = dr.Cells["Money"].Value + "";

                        gvList.Add(gvdata);
                    }
                    string dateFormat = "yyyy/MM/dd";
                    string resultdt = dtpDateSave.Value.ToString(dateFormat);
                    foreach (var items in itemselect) // list SO ที่เลือก
                    {
                        SumOfTreatment info = new SumOfTreatment();
                        List<Entity.CreditCardSOT> listCredit = new List<CreditCardSOT>();
                        Entity.CreditCardSOT creditInfo;

                        var itemsSOT = items.Split(';');
                        SO = itemsSOT[0];
                        double saleprice = 0.00;
                        double lastprice = 0.00;
                        double sumdiscount = 0.00;
                        decimal? cashcreditcardSOT = 0;


                        var rowdata = gvList.Where(x => x.MS_SO == SO).ToList();
                        foreach (var val in rowdata) //หาข้อมูลในราคารวมหลังหักส่วนลด ใน gridview
                        {
                            saleprice += double.Parse(String.IsNullOrEmpty(val.Money) ? "0" : val.Money.Replace(",", ""));
                            sumdiscount += double.Parse(String.IsNullOrEmpty(val.DisBath) ? "0" : val.DisBath.Replace(",", ""));
                            lastprice += double.Parse(String.IsNullOrEmpty(val.money_dis) ? "0" : val.money_dis.Replace(",", ""));
                        }

                        var dataCashCreditCardSOT = context.CashCreditCardSOTs.Where(x => x.SO == SO).ToList();
                        foreach (var val in dataCashCreditCardSOT) //หาข้อมูลในราคารวมหลังหักส่วนลด ใน gridview
                        {
                            cashcreditcardSOT += val.CashMoney;
                        }
                        Unpaid = lastprice - Convert.ToDouble(cashcreditcardSOT);
                        EarnestMoney = Convert.ToDouble(cashcreditcardSOT);

                        info.QueryType = "UPDATE";
                        info.SOT_Code = lbIR.Text;
                        info.CN = lbCN.Text;
                        info.SORef = labelSORef.Text;
                        //info.PRO_Code = PRO_Code;
                        info.SO = SO;
                        //info.EN_COMSDoctor = lbDoctorCom.Text;
                        info.DateSave = Convert.ToDateTime(resultdt);
                        info.DateUpdate = DateTime.Now;
                        info.SalePrice = saleprice;
                        info.NetAmount = lastprice;
                        info.EarnestMoney = EarnestMoney; //ราคาที่มาจากใบเสร็จ
                        info.Unpaid = Unpaid;
                        int sts = 0;
                        if (Unpaid == 0)
                            sts = 2;
                        else if (Unpaid != 0 && lastprice != Unpaid)
                            sts = 1;
                        else if (lastprice == Unpaid)
                            sts = 0;

                        info.MedStatus_Code = sts;
                        info.Remark = txtRemark.Text;
                        info.BillTo = txtBillTo.Text;

                        info.DiscountAllItemBath = sumdiscount; //ส่วนลดทั้งหมดใน so
                        info.DiscountBath = Convert.ToDouble(string.IsNullOrEmpty(txtIntDiscountBath.Text) ? "0" : txtIntDiscountBath.Text.Replace(",", "")); ;
                        info.EN_Save = Entity.Userinfo.EN.Trim();
                        info.EN_COMS = (comboBoxCommission.SelectedValue + "").Trim();

                        info.EN_COMS2 = (comboBoxCommission2.SelectedValue + "").Trim();
                        info.PriceAfterDis = EarnestMoney;
                        if (info.EN_COMS2 != "")
                            info.Com_Bath = info.Com_Bath2 = EarnestMoney / 2;
                        else
                            info.Com_Bath = EarnestMoney;


                        //For DiscountPercen===========================
                        List<Entity.SupplieTrans> listSupplieTran = new List<SupplieTrans>();
                        Entity.SupplieTrans SupplieTranInfo;
                        info.Vat = "N";
                        info.NonVat = "N";
                        foreach (DataGridViewRow row in dgvData.Rows)
                        {
                            SupplieTranInfo = new SupplieTrans();
                            SupplieTranInfo.QueryType = "UPDATESUPPLIETRANS";
                            SupplieTranInfo.VN = VN;
                            SupplieTranInfo.SONo = SO;
                            SupplieTranInfo.SORef = labelSORef.Text;
                            SupplieTranInfo.PRO_Code = PRO_Code;
                            SupplieTranInfo.MS_Code = row.Cells["MS_Code"].Value + "";
                            SupplieTranInfo.DiscountPercen = string.IsNullOrEmpty(row.Cells["discount"].Value + "") ? 0 : Convert.ToDecimal(row.Cells["discount"].Value + "");
                            SupplieTranInfo.DiscountBath = string.IsNullOrEmpty(row.Cells["DisBath"].Value + "") ? 0 : Convert.ToDecimal(row.Cells["DisBath"].Value + "");
                            SupplieTranInfo.PriceAfterDis = Convert.ToDecimal(string.IsNullOrEmpty(row.Cells["money_dis"].Value + "") ? "0" : row.Cells["money_dis"].Value + "".Replace(",", ""));
                            SupplieTranInfo.PayByItem = Convert.ToDecimal(string.IsNullOrEmpty(row.Cells["PayByItem"].Value + "") ? "0" : row.Cells["PayByItem"].Value + "");
                            SupplieTranInfo.ListOrder = row.Cells["ListOrder"].Value + "";
                            SupplieTranInfo.ByDr = row.Cells["ByDr"].Value + "";
                            listSupplieTran.Add(SupplieTranInfo);
                            if (row.Cells["Vat"].Value + "" == "Y")
                                info.Vat = "Y";
                            if (row.Cells["Vat"].Value + "" == "N" || (row.Cells["Vat"].Value + "").Trim() == "")
                                info.NonVat = "Y";
                        }
                        listCredit = new List<CreditCardSOT>();
                        info.CreditCardSotInfo = listCredit.ToArray();
                        info.SupplieTranInfo = listSupplieTran.ToArray();

                        //==================================get last  pay==========================
                        double dblCredit = 0.00;
                        double dblCash = 0.00;
                        double dblCredteRcn = 0.00;
                        double dblCashRcn = 0.00;
                        Dictionary<string, double> lsdateRcn = new Dictionary<string, double>();

                        intStatus = new Business.SumOfTreatment().UpdateSumOfTreatment(info);
                    }

                    if (intStatus > 0)
                    {
                        if (saveclose)
                        {

                            //if (Convert.ToInt32(String.IsNullOrEmpty(txtUnpaid.Text) ? "0" : txtUnpaid.Text.Replace(",", "")) > 0)
                            //{
                            //    MessageBox.Show("กรุณาจ่ายเงินเต็มจำนวน", "แจ้งเตือน");
                            //}
                            //else
                            //{
                            DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, Statics.SaveComplete);
                            this.Close();
                            //}
                        }
                    }
                    else
                    {
                        MessageBox.Show("ขัดข้อง \"Save error\"");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log4net.Config.BasicConfigurator.Configure();
                log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));
                log.Error("Error Message: " + ex.Message.ToString(), ex);
            }
        }
        public static string FlattenException(Exception exception)
        {
            var stringBuilder = new StringBuilder();

            while (exception != null)
            {
                stringBuilder.AppendLine(exception.Message);
                stringBuilder.AppendLine(exception.StackTrace);

                exception = exception.InnerException;
            }

            return stringBuilder.ToString();
        }
        public string GetLineNumber(Exception ex)
        {
            string lineNumber = "";
            //const string lineSearch = ":line ";
            //var index = ex.StackTrace.LastIndexOf(lineSearch);
            //if (index != -1)
            //{
            //    var lineNumberText = ex.StackTrace.Substring(index + lineSearch.Length);
            //    if (int.TryParse(lineNumberText, out lineNumber))
            //    {
            //    }
            //}
            StackTrace st = new StackTrace(ex, true);
            //Get the first stack frame
            StackFrame frame = st.GetFrame(0);

            //Get the file name
            string fileName = frame.GetFileName();

            //Get the method name
            string methodName = frame.GetMethod().Name;

            //Get the line number from the stack frame
            int line = frame.GetFileLineNumber();

            //Get the column number
            int col = frame.GetFileColumnNumber();
            lineNumber = string.Format("GetFileName={0} GetMethod={1} GetFileLineNumber={2}", fileName, methodName, line + "");
            return lineNumber;
        }
        private void dgvData_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (dgvData.CurrentCell.ColumnIndex == dgvData.Columns["discount"].Index)
                {
                    TextBox itemID = e.Control as TextBox;
                    if (itemID != null)
                    {
                        itemID.KeyPress += new KeyPressEventHandler(itemID_KeyPress);
                        string v = string.IsNullOrEmpty(itemID.Text) ? "" : itemID.Text + "".Replace(",", "");
                        if (v == "") return;
                        decimal sss = Convert.ToDecimal(v);
                        if (sss > 50) sss = 0;
                        itemID.Text = sss.ToString();// ("###,###,###.##");
                    }
                }
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.Message);
            }
        }

        private void dgvData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if ((bool)dgvData.Rows[e.RowIndex].Cells["Subject"].Value || (bool)dgvData.Rows[e.RowIndex].Cells["MarketingBudget"].Value || (bool)dgvData.Rows[e.RowIndex].Cells["complimentary"].Value)
                    return;
                if (dgvData.CurrentCell.ColumnIndex == dgvData.Columns["DisBath"].Index || dgvData.CurrentCell.ColumnIndex == dgvData.Columns["discount"].Index)//discount
                {
                    bool KeyDisBath = false;
                    decimal discount = 0;
                    decimal money_dis = 0;
                    if (dgvData.CurrentCell.ColumnIndex == dgvData.Columns["DisBath"].Index)
                        KeyDisBath = true;

                    string v = dgvData.CurrentCell.Value + "" == "" ? "0" : dgvData.CurrentCell.Value + "".Replace(",", "");
                    //string sp = string.IsNullOrEmpty(dgvData.Rows[e.RowIndex].Cells["Money"].Value.ToString()) ? "" : dgvData.Rows[e.RowIndex].Cells["Money"].Value.ToString() + "".Replace(",", "");
                    if (v == "") return;
                    decimal disBath = Convert.ToDecimal(v);
                    //decimal dis = Convert.ToDecimal(sp) * 50 / 100;
                    decimal price = Convert.ToDecimal(dgvData.Rows[e.RowIndex].Cells["Money"].Value);
                    //if(dis>50)
                    if (KeyDisBath)//เเบบคีย์ เงิน
                    {
                        if (disBath > price)
                        {
                            disBath = 0;
                        }
                        discount = (disBath * 100) / price;//%ที่ลดไป
                        money_dis = price - disBath;
                        //Money
                        dgvData.Rows[e.RowIndex].Cells["discount"].Value = String.Format("{0:F2}", discount);
                    }
                    else//เเบบคีย์ %
                    {
                        if (disBath <= 0 || disBath > 100)
                        {
                            disBath = 0;
                        }
                        money_dis = price - (price * (disBath / 100));//=500*(5/100)//หลังหักส่วนลด 
                        discount = (price * (disBath / 100)); //จำนวนเงินที่ลดไป

                        dgvData.Rows[e.RowIndex].Cells["DisBath"].Value = String.Format("{0:F2}", discount);


                    }



                    //dgvData.Rows[e.RowIndex].Cells["discount"].Value = (discount).ToString("###,###,###.##");//ลดไปเท่าไหร่ บาท
                    dgvData.Rows[e.RowIndex].Cells["money_dis"].Value = (money_dis).ToString("###,###,###.##");//หลังหักส่วนลด 

                    decimal Price60Per = (price * 60) / 100;
                    decimal Price95Per = (price * 95) / 100;
                    decimal Price80Per = (price * 80) / 100;
                    decimal Price50Per = price / 2;

                    customerType = lbCN.Text.Substring(3, 3);
                    //Price50Per = Entity.Userinfo.PriceNormal.Contains(customerType) ? Price50Per : Price60Per;
                    string txtPercen = "";
                    if (Entity.Userinfo.PriceNormal.Contains(customerType))
                    {
                        Price50Per = Price50Per;
                        txtPercen = "50 %.";
                    }
                    else
                    {
                        Price50Per = Price60Per;
                        txtPercen = "60 %.";
                    }

                    //if (lbSO.Text.ToLower().Contains("pro"))
                    //{
                    //    Price50Per = Price80Per;
                    //    txtPercen = "80%";
                    //}
                    if (customerType == "CNM" || customerType == "CNS")
                    {
                        Price50Per = Price95Per;
                        txtPercen = "95 %.";
                    }


                    //if (disBath > Price50Per && !(Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN) && !Userinfo.IS_ADMIN_DISCOUNT.Contains(Userinfo.EN))
                    if (disBath > Price50Per)
                    {
                        if (!(Userinfo.IsAdmin ?? "").Contains(Userinfo.EN) && !Userinfo.IS_ADMIN_DISCOUNT.Contains(Userinfo.EN))
                        {
                            dgvData.Rows[e.RowIndex].Cells["Money"].Value = price.ToString("###,###,###,###.##"); //ราคารวม
                            dgvData.Rows[e.RowIndex].Cells["money_dis"].Value = price.ToString("###,###,###,###.##"); //ราคารวม
                            dgvData.Rows[e.RowIndex].Cells["discount"].Value = "0";
                            dgvData.Rows[e.RowIndex].Cells["DisBath"].Value = "0";

                            MessageBox.Show("Cannot discount over " + txtPercen, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //DisableButton(false);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Cannot discount over " + txtPercen + " Please recheck approved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //DisableButton(true);
                        }

                    }


                    summoneyDiscount();
                    summoney();
                }
                //test chack box========================================

                //test chack box========================================
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.Message);
            }
        }
        private void AddPayToGrid(/*System.Windows.Forms.ComboBox ls, */double price)
        {
            try
            {
                //if (ls.SelectedIndex != -1)
                //{
                    string[] value = "PettyCash:CASH:N".Split(':');//ls.SelectedValue.ToString().Split(':');//PettyCash:CASH:N
                    string text = "เงินสด";//ls.Text;
                    string CD_Code = value[0] + "";
                    string BillType = value[1] + "";
                    //string RCNo = dgvReciept.Rows[dgvReciept.CurrentRow.Index].Cells["RCNo"].Value + "";
                    //string ReceiptDate = Convert.ToDateTime(dgvReciept.Rows[dgvReciept.Rows.].Cells["ReceiptDate"].Value).ToString("yyyy/MM/dd");
                    //if (value[1].ToUpper() == "CASH")
                    //{
                    //    var myItems = new ICloneable[]
                    //                     {
                    //                         "",
                    //                         "",
                    //                         value[0] + "",
                    //                         text,"0.00","","",""
                    //                         ,value[2].ToUpper()
                    //                         ,String.Format("{0:yyyy/MM/dd}", DateTime.Now)
                    //                     };
                    //    dataGridViewCashTransfer.Rows.Add(myItems);
                    if (value[1].ToUpper() == "CASH")
                    {
                        //List<string> LsPayInx = new List<string>();
                        //LsPayInx.Add("1:N");

                        //DisplayPayInComboColumn(LsPayIn, dataGridViewCreditTransfer, "PayInCredit");
                        //DisplayCardTypeComboColumn(LsCardType, dataGridViewCreditTransfer, "CardType");
                    }
                    //    dataGridViewCashTransfer["PayInCash", dataGridViewCashTransfer.Rows.Count - 1].Value = "1:N";
                    bool isVoucher = false;
                    string VS = "";
                    double VP = 0;
                    if (value[1].ToUpper() == "GIFT")
                    {
                        FrmFreeGiftVoucher frm = new FrmFreeGiftVoucher();
                        frm.ShowDialog();
                        isVoucher = true;
                        VS = frm.GiftCode;
                        VP = frm.PriceCredit;
                    }

                    var myItems = new ICloneable[]
                                     {
                                             "",//Pay_Code
                                             BillType,
                                             RCNoCurrent,
                                             CD_Code,
                                             text,
                                               price.ToString("###,###.##"),//จ่าย
                                            String.Format("{0:yyyy/MM/dd}", ReceiptDateCurrent),//date
                                             isVoucher?VS:"",//เลขที่บัตร
                                             "",//PayIn
                                             "",//PayInCode
                                             "",//CardType
                                                // value[2].ToUpper(),

                                         //String.Format("{0:yyyy/MM/dd}", DateTime.Now)
                                     };
                    dataGridViewCreditTransfer.Rows.Add(myItems);
                    dataGridViewCreditTransfer["PayInCredit", dataGridViewCreditTransfer.Rows.Count - 1].Value = "ไม่ระบุ";
                    // }
                    summoney();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void listBoxCashTyp_DoubleClick(object sender, EventArgs e)
        {
            // AddPayToGrid(listBoxCashTyp);
        }
        private void listBoxCreditTyp_DoubleClick(object sender, EventArgs e)
        {
            // AddPayToGrid(listBoxCreditTyp);
        }
        //private void btnAdd_BtnClick()
        //{
        //    AddPayToGrid(listBoxCashTyp);
        //}

        private void btnAddCredit_BtnClick()
        {
            //AddPayToGrid(listBoxCreditTyp);
        }
        //private void dataGridViewCashTransfer_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Button == MouseButtons.Right)
        //        {
        //            dataGridViewCashTransfer.ClearSelection();
        //            //dgvData.Rows[rowIndex].Selected = false;
        //            dataGridViewCashTransfer.Rows[e.RowIndex].Selected = true;
        //            rowIndex = e.RowIndex;
        //            actDataGridView = "CASH";
        //            ToolStripMenuItemDel.Visible = true;
        //            menuPaybyItem.Visible = false;
        //            menuPrintCard.Visible = false;
        //            contextMenuStrip1.Show(MousePosition);
        //        }
        //        else
        //        {
        //            if (e.ColumnIndex == dataGridViewCashTransfer.Rows[e.RowIndex].Cells["PayCashDate"].ColumnIndex)
        //            {
        //                PopDateTime pp = new PopDateTime();
        //                DateTime d;
        //                pp.SelecttDate = DateTime.TryParse(dataGridViewCashTransfer.Rows[e.RowIndex].Cells["PayCashDate"].Value + "", out d) ? d : DateTime.Now;
        //                //pp.SelecttDate =Convert.ToDateTime(pp.SelecttDate.ToString("yyyy/MM/dd"));
        //                if (pp.ShowDialog() == DialogResult.OK)
        //                {
        //                    dataGridViewCashTransfer.Rows[e.RowIndex].Cells["PayCashDate"].Value = pp.SelecttDate.Date.ToString("yyyy/MM/dd");
        //                }
        //            }
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        return;
        //    }
        //}

        private void dataGridViewCredit_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    dataGridViewCreditTransfer.ClearSelection();
                    //dgvData.Rows[rowIndex].Selected = false;
                    dataGridViewCreditTransfer.Rows[e.RowIndex].Selected = true;
                    rowIndex = e.RowIndex;
                    actDataGridView = "CREDIT";
                    ToolStripMenuItemDel.Visible = true;
                    menuPaybyItem.Visible = false;
                    menuPrintCard.Visible = false;
                    contextMenuStrip1.Show(MousePosition);
                }
                else
                {
                    if (e.ColumnIndex == dataGridViewCreditTransfer.Rows[e.RowIndex].Cells["PayCreditDate"].ColumnIndex)
                    {
                        //PopDateTime pp = new PopDateTime();
                        //DateTime d;
                        //pp.SelecttDate = DateTime.TryParse(dataGridViewCreditTransfer.Rows[e.RowIndex].Cells["PayCreditDate"].Value + "", out d) ? d : DateTime.Now;
                        ////pp.SelecttDate =Convert.ToDateTime(pp.SelecttDate.ToString("yyyy/MM/dd"));
                        //if (pp.ShowDialog() == DialogResult.OK)
                        //{
                        //    dataGridViewCreditTransfer.Rows[e.RowIndex].Cells["PayCreditDate"].Value = pp.SelecttDate.Date.ToString("yyyy/MM/dd");
                        //}

                    }
                    else if (e.ColumnIndex == dataGridViewCreditTransfer.Rows[e.RowIndex].Cells["PayInCredit"].ColumnIndex)
                    {
                        popComboboxPay pc = new popComboboxPay();
                        pc.popType = "PayIn";
                        pc.SelectValues = dataGridViewCreditTransfer.Rows[e.RowIndex].Cells["PayInCode"].Value + "";
                        pc.SelectText = dataGridViewCreditTransfer.Rows[e.RowIndex].Cells["PayInCredit"].Value + "";
                        //pp.SelecttDate =Convert.ToDateTime(pp.SelecttDate.ToString("yyyy/MM/dd"));
                        if (pc.ShowDialog() == DialogResult.OK)
                        {
                            dataGridViewCreditTransfer.Rows[e.RowIndex].Cells["PayInCode"].Value = pc.SelectValues;
                            dataGridViewCreditTransfer.Rows[e.RowIndex].Cells["PayInCredit"].Value = pc.SelectText;
                        }
                    }
                    else if (e.ColumnIndex == dataGridViewCreditTransfer.Rows[e.RowIndex].Cells["CardType"].ColumnIndex)
                    {
                        popComboboxPay pc = new popComboboxPay();
                        pc.popType = "CardType";
                        pc.SelectValues = dataGridViewCreditTransfer.Rows[e.RowIndex].Cells["CardType"].Value + "";
                        //pc.SelectText = dataGridViewCreditTransfer.Rows[e.RowIndex].Cells["PayInCredit"].Value + "";
                        //pp.SelecttDate =Convert.ToDateTime(pp.SelecttDate.ToString("yyyy/MM/dd"));
                        if (pc.ShowDialog() == DialogResult.OK)
                        {
                            dataGridViewCreditTransfer.Rows[e.RowIndex].Cells["CardType"].Value = pc.SelectValues;
                            //dataGridViewCreditTransfer.Rows[e.RowIndex].Cells["PayInCredit"].Value = pc.SelectText;
                        }
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void checkBoxCommissionEdit_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxCommission.Enabled = checkBoxCommissionEdit.Checked;
        }

        //private void dataGridViewCashTransfer_CellEnter(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        dataGridViewCashTransfer.BeginEdit(false);
        //        if (e.ColumnIndex == dataGridViewCashTransfer.Columns.Count - 1)// the combobox column index
        //        {
        //            if (this.dataGridViewCashTransfer.EditingControl != null
        //                && this.dataGridViewCashTransfer.EditingControl is ComboBox)
        //            {
        //                ComboBox cmb = this.dataGridViewCashTransfer.EditingControl as ComboBox;
        //                cmb.DroppedDown = true;
        //                cmb.SelectedIndex = 0;

        //            }
        //        }
        //        dataGridViewCashTransfer.EndEdit();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        //private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.ColumnIndex == comboboxColumn.Index && e.RowIndex >= 0) //check if combobox column
        //    {
        //        object selectedValue = dataGridViewCashTransfer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        //    }
        //}

        //changes must be committed as soon as the user changes the drop down box
        //private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        //{
        //    if (dataGridViewCashTransfer.IsCurrentCellDirty)
        //    {
        //        dataGridViewCashTransfer.CommitEdit(DataGridViewDataErrorContexts.Commit);
        //    }
        //}
        private void dataGridViewCredit_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridViewCreditTransfer.BeginEdit(false);
                if (e.ColumnIndex == dataGridViewCreditTransfer.Columns.Count - 1)// the combobox column index
                {
                    if (this.dataGridViewCreditTransfer.EditingControl != null
                        && this.dataGridViewCreditTransfer.EditingControl is ComboBox)
                    {
                        ComboBox cmb = this.dataGridViewCreditTransfer.EditingControl as ComboBox;
                        cmb.DroppedDown = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void dataGridViewCashTransfer_DataError(object sender, DataGridViewDataErrorEventArgs e)
        //{

        //}

        //private void dataGridViewCreditTransfer_DataError(object sender, DataGridViewDataErrorEventArgs e)
        //{

        //}

        //private void dataGridViewCreditTransfer_CellLeave(object sender, DataGridViewCellEventArgs e)
        //{

        //}

        private void dgvData_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

                if (e.Button == MouseButtons.Left)
                {
                    PlayMS_Code = dgvData.Rows[e.RowIndex].Cells["MS_Code"].Value + "";
                    string lisorder = dgvData.Rows[e.RowIndex].Cells["ListOrder"].Value + "";
                    string MS_name = dgvData.Rows[e.RowIndex].Cells["Detail"].Value + "";
                    double proAF = dgvData.Rows[e.RowIndex].Cells["money_dis"].Value + "" == "" ? 0 : Convert.ToDouble(dgvData.Rows[e.RowIndex].Cells["money_dis"].Value + "");
                    lbPayItem.Visible = true;
                    lbPayItem.Text = string.Format("Product : {0}", MS_name);
                    //double PayByItem = Convert.ToDouble(string.IsNullOrEmpty(dgvData.Rows[e.RowIndex].Cells["PayByItem"].Value + "") ? "0" : dgvData.Rows[e.RowIndex].Cells["PayByItem"].Value + "".Replace(",", ""));

                    double db = 0;
                    string pd = "";
                    foreach (DataRow item in dtSumOfTreatPayByItem.Rows)
                    {
                        if (item["MS_Code"] + "" == PlayMS_Code && item["ListOrder"] + "" == lisorder)
                        {
                            db = db += Convert.ToDouble(item["CashMoney"] + "" == "" ? "0" : item["CashMoney"] + "") + Convert.ToDouble(item["MoneyCredit"] + "" == "" ? "0" : item["MoneyCredit"] + "");
                            pd += item["PayDate"] + ",";
                        }
                    }
                    textBoxPayByItem.Text = db.ToString("###,###,###,###.##");// +" " + pd;
                    pictureBoxPaid.Visible = db == proAF;
                    ////toolTip1.SetToolTip(dgvData, db.ToString("###,###,###,###.##") + " " + pd);
                    //ToolTip buttonToolTip = new ToolTip();

                    //buttonToolTip.ToolTipTitle = "Button Tooltip";

                    //buttonToolTip.UseFading = true;

                    //buttonToolTip.UseAnimation = true;

                    //buttonToolTip.IsBalloon = true;



                    //buttonToolTip.ShowAlways = true;



                    //buttonToolTip.AutoPopDelay = 5000;

                    //buttonToolTip.InitialDelay = 1000;

                    //buttonToolTip.ReshowDelay = 500;



                    //buttonToolTip.SetToolTip(this, db.ToString("###,###,###,###.##") + " " + pd);
                }
                else
                {
                    dgvData.CurrentCell = dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    // Can leave these here - doesn't hurt
                    dgvData.Rows[e.RowIndex].Selected = true;
                    dgvData.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void textBoxPayByItem_Leave(object sender, EventArgs e)
        {
            try
            {
                dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["PayByItem"].Value = Convert.ToDecimal(string.IsNullOrEmpty(textBoxPayByItem.Text) ? "0" : textBoxPayByItem.Text.Replace(",", ""));
            }
            catch (Exception ex)
            {

            }
        }
        private void checkBoxCommissionEdit_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void txtIntDiscountBath_Leave_1(object sender, EventArgs e)
        {
            summoneyDiscount();
            summoney();
        }

        private void dgvData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((bool)dgvData.Rows[e.RowIndex].Cells["Subject"].Value || (bool)dgvData.Rows[e.RowIndex].Cells["MarketingBudget"].Value || (bool)dgvData.Rows[e.RowIndex].Cells["complimentary"].Value)
            {
                textBoxPayByItem.ReadOnly = true;
                return;
            }
            else
            {
                dgvData.BeginEdit(false);
                textBoxPayByItem.ReadOnly = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtIntDiscountBath_TextChanged_1(object sender, EventArgs e)
        {
            summoneyDiscount();
            summoney();
        }




        private void menuNewRC_ID_Click(object sender, EventArgs e)
        {
            try
            {
                //MessageBox.Show("New and Print");
                //SaveSOF(false);
                //BindFrmSumOfTreatment();
                ////PrintBill2Vat();
                //PrintBill2NoVat();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void menuPrintBill_Click(object sender, EventArgs e)
        {
            try
            {
                //MessageBox.Show("Print Only");
                //SaveSOF(false);
                //BindFrmSumOfTreatment();
                ////PrintBill2Vat();
                //PrintBill2NoVat();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnPrintInv_Click(object sender, EventArgs e)
        {
            try
            {
                SaveSOF(false);
                BindFrmSumOfTreatment();
                PrintBillNoVatINV(1);//ใบแจ้งหนี้ ORG
                //PrintBillVatINV();//ใบแจ้งหนี้ ORG
                //PrintBillNoVatINV("COPY");//ใบแจ้งหนี้ COPY
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnPrintInvClinic_Click(object sender, EventArgs e)
        {
            try
            {
                SaveSOF(false);
                BindFrmSumOfTreatment();
                PrintBillNoVatINV(2);//ใบแจ้งหนี้ ORG
                //PrintBillVatINV();//ใบแจ้งหนี้ ORG
                //PrintBillNoVatINV("COPY");//ใบแจ้งหนี้ COPY
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnBill2_Click(object sender, EventArgs e)
        {
            try
            {

                SaveSOF(false);
                DateTime Maxdate = DateTime.MinValue;// String.Format("{0:yyyy/MM/dd}", DateTime.Now);
                foreach (DataGridViewRow row in dataGridViewCreditTransfer.Rows)
                {
                    if (Convert.ToDateTime(row.Cells["PayCreditDate"].Value + "") > Maxdate)
                    {
                        Maxdate = Convert.ToDateTime(row.Cells["PayCreditDate"].Value + "");
                    }
                }

                //foreach (DataGridViewRow row in dataGridViewCashTransfer.Rows)
                //{
                //    if (Convert.ToDateTime(row.Cells["PayCashDate"].Value + "") > Maxdate)
                //    {
                //        Maxdate = Convert.ToDateTime(row.Cells["PayCashDate"].Value + "");
                //    }
                //}
                if (!(Userinfo.IsAdmin ?? "").Contains(Userinfo.EN) && !Userinfo.IS_ADMIN_DISCOUNT.Contains(Userinfo.EN) && Maxdate.AddDays(3) <= DateTime.Now.Date)//ใช้วันที่จ่าย ล่าสุด + 3 วัน
                {
                    string alert = string.Format("ไม่สามารถปริ้นใบเสร็จย้อนหลังเกิน 3 วัน{0}กรุณาติดต่อผู้ดูแลระบบ", Environment.NewLine);
                    popAlert pa = new popAlert();
                    pa.txtShow = alert;
                    pa.txtTitle = "คำเตือน";

                    pa.ShowDialog();
                    if (pa.DialogResult == DialogResult.Yes)
                    {
                        return;
                    }
                    else
                    {
                        return;
                    }
                }


                BindFrmSumOfTreatment();
                PrintBill2NoVat();//ใบเสร็จ 
                //PrintBill2Vat();//ใบเสร็จ 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnPrintInv_MouseEnter(object sender, EventArgs e)
        {
            //contextMenuStripPrintINV.AutoClose = true;
            //var relativePoint = this.PointToClient(Cursor.Position);
            //contextMenuStripPrintINV.Show(this, relativePoint);
        }
        private void btnBill2_MouseHover(object sender, EventArgs e)
        {
            //contextMenuStripPrintBill.AutoClose = true;
            //var relativePoint = this.PointToClient(Cursor.Position);
            //contextMenuStripPrintBill.Show(this, relativePoint);

        }

        private void btnPrintInv_Click_1(object sender, EventArgs e)
        {

        }

        //private void dataGridViewCashTransfer_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    try
        //    {
        //          //if (e.ColumnIndex == dataGridViewCashTransfer.Columns.Count - 1)// the combobox column index
        //          //{
        //          //    e.Value = "ไทยพานิชย์ 1090";
        //          //}
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        private void txtIntDiscountAllItemBath_TextChanged(object sender, EventArgs e)
        {
            //summoneyDiscount();
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    int rowIndex = e.RowIndex;
            //    if (rowIndex < 0) return;
            //    double pricePay = dgvData.Rows[rowIndex].Cells["money_dis"].Value + ""==""?0:Convert.ToDouble(dgvData.Rows[rowIndex].Cells["money_dis"].Value + "");

            //    textBoxPayByItem.Text = pricePay.ToString("###,###,###,###");
            //}
            //catch (Exception ex)
            //{

            //}
            try
            {
                int rowIndex = e.RowIndex;
                if (rowIndex < 0) return;
                popPayByItem p = new popPayByItem();
                if (!(Userinfo.IsAdmin ?? "").Contains(Userinfo.EN) && !Userinfo.IS_ADMIN_JOBCOST.Contains(Userinfo.EN) && dtpDateSave.Value.Date < DateTime.Now.Date && checkmoney == false)
                {
                    p.DisableSave = true;
                }
                p.MS_Code = dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["MS_Code"].Value + "";
                p.Product = dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["Detail"].Value + "";
                p.ListOrder = dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["ListOrder"].Value + "";
                p.ListOrder = dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["ListOrder"].Value + "";
                p.PriceAfterDis = dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["money_dis"].Value + "";

                p.SOno = SO;

                if (p.ShowDialog() == DialogResult.OK)
                {
                    BindPayByItem();
                    CheckPayItemComplete();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CheckPayItemComplete()
        {

            try
            {
                Int32 SumPayItem = 0;
                if (dtSumOfTreatPayByItem.Rows.Count > 0)
                    SumPayItem = Convert.ToInt32(dtSumOfTreatPayByItem.Compute("Sum(CashMoney)", "")) + Convert.ToInt32(dtSumOfTreatPayByItem.Compute("Sum(MoneyCredit)", "")); ;
                //EarnestMoney   ยอดมัดจำ
                string alert = "";
                if (EarnestMoney > 0 && EarnestMoney == SumPayItem)//เงินจ่ายมัดจำ  =  เงินที่จ่าย byItem  ถือว่าเท่ากัน ไม่ต้อง pop แม้จะยังจ่ายไม่ครบ
                {

                }
                else if (EarnestMoney > 0 && EarnestMoney < SumPayItem)//
                {
                    alert = string.Format("การตัดจ่าย มากกว่า จำนวนเงินที่รับจริง");
                }
                else if (EarnestMoney > 0 && EarnestMoney > SumPayItem)//
                {
                    alert = string.Format("การตัดจ่าย น้อยกว่า จำนวนเงินที่รับจริง");
                }
                else alert = "";

                if (alert == "") return;

                popAlert pop = new popAlert();
                pop.txtTitle = "";
                pop.txtShow = alert;
                pop.ShowDialog();
                if (pop.ShowDialog() != DialogResult.Yes) return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void menuPaybyItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                popPayByItem p = new popPayByItem();
                if (!(Userinfo.IsAdmin ?? "").Contains(Userinfo.EN) && !Userinfo.IS_ADMIN_JOBCOST.Contains(Userinfo.EN) && dtpDateSave.Value < DateTime.Now.Date)
                {
                    p.DisableSave = true;
                }
                p.MS_Code = dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["MS_Code"].Value + "";
                p.Product = dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["Detail"].Value + "";
                p.ListOrder = dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["ListOrder"].Value + "";
                p.ListOrder = dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["ListOrder"].Value + "";
                p.PriceAfterDis = dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["money_dis"].Value + "";

                p.SOno = SO;

                if (p.ShowDialog() == DialogResult.OK)
                    BindPayByItem();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void menuPrintCard_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    FrmMedicalUseList obj = new FrmMedicalUseList();
                    obj.SONo = SO;
                    obj.VN = VN;
                    obj.MS_Code = dgvData.Rows[dgvData.CurrentRow.Index].Cells["MS_Code"].Value + ""; ;
                    obj.ListOrder = dgvData.Rows[dgvData.CurrentRow.Index].Cells["ListOrder"].Value + ""; ;
                    obj.FromSOT = true;
                    obj.BranchID = BranchID;
                    //obj.SONo = dgvData.Rows[rowIndex].Cells["SONo"].Value + "";
                    //obj.SONo = dgvData.Rows[rowIndex].Cells["SONo"].Value + "";
                    obj.BackColor = Color.FromArgb(255, 230, 217);
                    obj.Show(Statics.frmMain.dockPanel1);
                    //obj.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //string ccnumber = "";
                //PopInputCourseCard c = new PopInputCourseCard();
                //c.CN = cn;
                //c.CourseCardID = ccnumber = AryuwatSystem.Data.UtilityBackEnd.GenMaxSeqnoValues("CC", BranchID);
                //c.ShowDialog();

                ////Print Course Card
                //PrintCourseCardForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void PrintCourseCardForm()//รายละเอียดและตีเส้น 
        {
            try
            {
                FrmPreviewRpt obj = new FrmPreviewRpt();
                DataRow dr;
                string strTypeofPay = "";

                obj.PrintType = "";
                double dblCredit = 0.00;
                double dblCash = 0.00;
                string strBankName = "";


                //obj.PrintType = string.Format(" วันที่ {0} - {1}", txtStartdate.Text, txtEnddate.Text);
                //obj.ForDate = string.Format("วันที่ {0} - {1}", txtStartdate.Text, txtEnddate.Text);

                string COx = "";
                DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();

                DataTable dtemp = new DataTable();
                dtemp = dtSumOfTreat.Clone();
                foreach (DataRow item in dtSumOfTreat.Rows)
                {
                    item["PrintCard"] = "N";
                    foreach (DataGridViewRow dataRow in dtSumOfTreat.Rows)
                    {
                        COx = dataRow.Cells["CO"].Value.ToString();
                        ch1 = (DataGridViewCheckBoxCell)dataRow.Cells["Printed"];
                        if (item["CO"] + "" == COx && ch1.Value.ToString().ToLower() == "true")
                            item["PrintCard"] = "Y";
                        //else
                        //    item["PrintCard"] = "N";


                    }
                    dtemp.ImportRow(item);
                }


                obj.FormName = "RptCourseCardForm";
                //dtListAll = dsSurgeryFee.Tables[0].DefaultView.ToTable();
                obj.dt = dtemp;// dtTmpUsed.DefaultView.ToTable();
                obj.dt2 = dtSumOfTreat.DefaultView.ToTable();
                obj.MaximizeBox = true;

                obj.TopMost = true;
                obj.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewCreditTransfer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //lbPayItem.Text="";
                //lbPayItem.Text = dataGridViewCreditTransfer.Rows[e.RowIndex].Cells["PayCreditDate"].Value + "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void dataGridViewCashTransfer_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        //lbPayItem.Text = "";
        //        //lbPayItem.Text = dataGridViewCashTransfer.Rows[e.RowIndex].Cells["PayCashDate"].Value + "";
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}



        private void dgvReciept_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                panelPayType.Visible = false;
                //Filter รายการที่จ่าย
                if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

                RCNoCurrent = dgvReciept.Rows[e.RowIndex].Cells["RCNo"].Value + "";
                ReceiptDateCurrent = dgvReciept.Rows[e.RowIndex].Cells["ReceiptDate"].Value + "" == "" ? DateTime.Now.Date : Convert.ToDateTime(dgvReciept.Rows[e.RowIndex].Cells["ReceiptDate"].Value + "");
                ReceiptBathCurrent = dgvReciept.Rows[e.RowIndex].Cells["ReceiptBath"].Value + "" == "" ? 0 : Convert.ToDecimal(dgvReciept.Rows[e.RowIndex].Cells["ReceiptBath"].Value + "");
                FilterCash_Credit(RCNoCurrent);


                ShowSumList_Check();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FilterCash_Credit(string RCno)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridViewCreditTransfer.Rows)
                {
                    if (RCno != "All" && RCno != "ทั้งหมด") row.Visible = false;
                    else row.Visible = true;
                    if (row.Cells["RCNo_Cre"].Value + "" == RCno) row.Visible = true;
                }

                ShowSumList_Check();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void toolStripEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvReciept.CurrentRow.Index <= 0 && dgvReciept.Rows[dgvReciept.CurrentRow.Index].Cells["ReceiptBath"].Value + "" == "") return;
                popRecieptAdd pp = new popRecieptAdd();

                decimal SumReciept = 0;
                DateTime d = DateTime.MinValue;
                DateTime Lastdate = DateTime.MinValue;
                int c = 0;
                foreach (DataGridViewRow item in dgvReciept.Rows)//รวมยอดใบเสร็จ
                {
                    SumReciept += item.Cells["ReceiptBath"].Value + "" == "" ? 0 : Convert.ToDecimal(item.Cells["ReceiptBath"].Value + "");
                    d = item.Cells["ReceiptDate"].Value + "" == "" ? DateTime.MinValue.Date : Convert.ToDateTime(item.Cells["ReceiptDate"].Value + "").Date;
                    if (Lastdate < d) Lastdate = d;
                    c++;
                }
                if (c == 1) Lastdate = DateTime.MinValue;
                decimal ump = Convert.ToDecimal(txtIntNetTotal.Text) - SumReciept;
                pp.Lastdate = Lastdate;
                pp.UnpaidBath = ump;//ดึงจากราคาขาย หรือดึงจากยอดค้างชำระ
                pp.NetTotal = Convert.ToDecimal(txtIntNetTotal.Text);
                pp.ReceiptSum = SumReciept;
                pp.ReceiptBath = dgvReciept.Rows[dgvReciept.CurrentRow.Index].Cells["ReceiptBath"].Value + "" == "" ? 0 : Convert.ToDecimal(dgvReciept.Rows[dgvReciept.CurrentRow.Index].Cells["ReceiptBath"].Value);
                pp.ReceiptDate = ReceiptDateCurrent = Convert.ToDateTime(dgvReciept.Rows[dgvReciept.CurrentRow.Index].Cells["ReceiptDate"].Value);
                ReceiptBathCurrent = dgvReciept.Rows[dgvReciept.CurrentRow.Index].Cells["ReceiptBath"].Value + "" == "" ? 0 : Convert.ToDecimal(dgvReciept.Rows[dgvReciept.CurrentRow.Index].Cells["ReceiptBath"].Value);
                pp.RCNo = RCNoCurrent = dgvReciept.Rows[dgvReciept.CurrentRow.Index].Cells["RCNo"].Value + "";
                //pp.SO = SO;
                SOReceipt = dgvReciept.Rows[dgvReciept.CurrentRow.Index].Cells["dataSO"].Value + "";
                DateTime oldDate = Convert.ToDateTime(dgvReciept.Rows[dgvReciept.CurrentRow.Index].Cells["ReceiptDate"].Value);
                if (pp.ShowDialog() == DialogResult.OK)
                {
                    //Lastdate.DateTime d = DateTime.MinValue.Date;
                    foreach (DataGridViewRow item in dgvReciept.Rows)
                    {
                        d = item.Cells["ReceiptDate"].Value + "" == "" ? DateTime.MinValue.Date : Convert.ToDateTime(item.Cells["ReceiptDate"].Value + "").Date;
                        if (d == pp.ReceiptDate && oldDate != pp.ReceiptDate)
                        {
                            MessageBox.Show("วันที่ ซ้ำ");
                            dgvReciept.Rows[0].Selected = true;
                            return;
                        }
                    }

                    DataSet ds = new Business.SumOfTreatment().SAVERCNo(pp.RCNo, SO, pp.ReceiptDate, Entity.Userinfo.EN, pp.ReceiptBath);
                    //rc = ds.Tables[0].Rows[0][0] + "";

                    ReceiptBathCurrent = pp.ReceiptBath;
                    ReceiptDateCurrent = pp.ReceiptDate;
                    dgvReciept.Rows[dgvReciept.CurrentRow.Index].Cells["ReceiptBath"].Value = pp.ReceiptBath.ToString("###,###,###,###.##");
                    dgvReciept.Rows[dgvReciept.CurrentRow.Index].Cells["ReceiptDate"].Value = pp.ReceiptDate.ToString("yyyy/MM/dd");
                    //dgvReciept.Rows[dgvReciept.CurrentRow.Index].Cells["RCNo"].Value = pp.RCNo;


                    foreach (DataGridViewRow row in dataGridViewCreditTransfer.Rows)
                    {
                        if (row.Cells["cash"].Value + "" != "" && row.Cells["RCNo_Cre"].Value + "" == RCNoCurrent)
                        {
                            row.Cells["PayCreditDate"].Value = pp.ReceiptDate.ToString("yyyy/MM/dd");
                        }

                    }

                    panelPayType.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvReciept.CurrentRow.Index < 0) return;

                decimal SumReciept = 0;
                DateTime d = DateTime.MinValue;
                DateTime Lastdate = DateTime.MinValue;
                foreach (DataGridViewRow item in dgvReciept.Rows)//รวมยอดใบเสร็จ
                {
                    SumReciept += item.Cells["ReceiptBath"].Value + "" == "" ? 0 : Convert.ToDecimal(item.Cells["ReceiptBath"].Value + "");
                    d = item.Cells["ReceiptDate"].Value + "" == "" ? DateTime.MinValue.Date : Convert.ToDateTime(item.Cells["ReceiptDate"].Value + "").Date;
                    if (Lastdate < d) Lastdate = d;
                }
                decimal ump = Convert.ToDecimal(txtIntNetTotal.Text) - SumReciept;

                if (ump == 0)
                {
                    MessageBox.Show("จำนวนเงินครบแล้ว", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                popRecieptSelectAdd pp = new popRecieptSelectAdd();
                //pp.ReceiptBath = ump;//ดึงจากราคาขาย หรือดึงจากยอดค้างชำระ
                pp.Lastdate = Lastdate;
                pp.ReceiptDate = DateTime.Now.Date;
                pp.RCNo = "";
                //pp.SO = SO;
                var itemsplit = new List<string>();
                foreach(var itm in itemselect)
                {
                    var itemsSOT = itm.Split(';');

                    itemsplit.Add(itemsSOT[0]);
                }
                pp.itemselect = itemsplit;
                if (pp.ShowDialog() == DialogResult.OK)
                {
                    SOReceipt = pp.SO;
                    //DateTime d = DateTime.MinValue;
                    foreach (DataGridViewRow item in dgvReciept.Rows)
                    {
                        d = item.Cells["ReceiptDate"].Value + "" == "" ? DateTime.MinValue.Date : Convert.ToDateTime(item.Cells["ReceiptDate"].Value + "").Date;
                        if (d == pp.ReceiptDate && item.Cells["dataSO"].Value + "" == SOReceipt)
                        {
                            MessageBox.Show("SO:" + item.Cells["dataSO"].Value + " วันที่เพิ่มใบเสร็จซ้ำ กรุณาแก้ไขข้อมูล", "แจ้งเตือน");
                            dgvReciept.Rows[0].Selected = true;
                            return;
                        }
                    }
                    string ReceiptBath = pp.ReceiptBath.ToString("###,###,###,###.##");
                    string ReceiptDate = pp.ReceiptDate.ToString("yyyy/MM/dd");
                    ReceiptDateCurrent = pp.ReceiptDate;
                    ReceiptBathCurrent = pp.ReceiptBath;
                    string rc = "";//= pp.RCNo;

                    DataSet ds = new Business.SumOfTreatment().SAVERCNo(rc, pp.SO, pp.ReceiptDate, Entity.Userinfo.EN, pp.ReceiptBath);
                    rc = ds.Tables[0].Rows[0][0] + "";
                    RCNoCurrent = rc;
                    object[] myItems = {
                                         pp.SO,
                                         RCNoCurrent,
                                         ReceiptDate,
                                         ReceiptBath
                                      };
                    dgvReciept.Rows.Add(myItems);
                    dgvReciept.ClearSelection();
                    dgvReciept.Rows[dgvReciept.Rows.Count - 1].Selected = true;
                    panelPayType.Visible = true;

                    double dbReceiptBath = Convert.ToDouble(ReceiptBath);
                    // string r = dgvReciept.Rows[dgvReciept.Rows.Count - 1].Cells["RCNo"].Value + "";
                    AddPayToGrid(dbReceiptBath);
                    SaveRCNoSUBList();
                    SaveSOF(false);
                    BindFrmSumOfTreatment();
                    BindReciept();
                    FilterCash_Credit("All");
                    FilterCash_Credit(RCNoCurrent);
                    summoneyDiscount();
                    summoney();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripdel_Click(object sender, EventArgs e)
        {
            RCNoCurrent = "";
            ReceiptDateCurrent = DateTime.Now;
            ReceiptBathCurrent = 0;
            deleteRCNo();
            BindCashCredit();
            FilterCash_Credit("All");
            summoneyDiscount();
            summoney();
        }
        private void deleteRCNo()
        {
            try
            {
                string ReceiptBath = dgvReciept.Rows[dgvReciept.CurrentRow.Index].Cells["ReceiptBath"].Value + "" == "" ? "0" : Convert.ToDecimal(dgvReciept.Rows[dgvReciept.CurrentRow.Index].Cells["ReceiptBath"].Value).ToString("###,###,###,###.##");
                string ReceiptDate = Convert.ToDateTime(dgvReciept.Rows[dgvReciept.CurrentRow.Index].Cells["ReceiptDate"].Value).ToString("yyyy/MM/dd");
                string rc = dgvReciept.Rows[dgvReciept.CurrentRow.Index].Cells["RCNo"].Value + "";
                if (DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirmYesNo, Statics.StrConfirmDelete + Environment.NewLine + rc + Environment.NewLine + ReceiptDate + Environment.NewLine + ReceiptBath) == DialogResult.Yes)
                {
                    int? ds = new Business.SumOfTreatment().DeleteRCNo(rc);
                    BindReciept();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SaveRCNoSUBList()
        {
            try
            {

                List<Entity.CreditCardSOT> listCredit = new List<CreditCardSOT>();
                //string ReceiptBath = Convert.ToDecimal(dgvReciept.Rows[dgvReciept.CurrentRow.Index].Cells["ReceiptBath"].Value).ToString("###,###,###,###.##");
                //DateTime ReceiptDate = Convert.ToDateTime(dgvReciept.Rows[dgvReciept.CurrentRow.Index].Cells["ReceiptDate"].Value);
                //string rc = dgvReciept.Rows[dgvReciept.CurrentRow.Index].Cells["RCNo"].Value + "";

                //if (DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirmYesNo, "บันทึกรายการรับเงิน" + Environment.NewLine + rc + Environment.NewLine + ReceiptDate + Environment.NewLine + ReceiptBath) == DialogResult.Yes)
                //if (DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirmYesNo, "บันทึกรายการรับเงิน") == DialogResult.Yes)
                //{
                    //foreach (DataGridViewRow row in dataGridViewCreditTransfer.Rows)
                    //{
                    //    if (row.Cells["cash"].Value + "" == "" || row.Visible==false) continue;
                    //    CreditCardSOT creditInfo = new CreditCardSOT();
                    //    creditInfo.QueryType = "SAVECREDITCARD";
                    //    creditInfo.SO = SO;
                    //    creditInfo.EN = Entity.Userinfo.EN;
                    //    creditInfo.CN = lbCN.Text;
                    //    creditInfo.CardNumber = row.Cells["number"].Value + "";//เลขที่บัตร
                    //    creditInfo.CD_Code = row.Cells["CD_Code"].Value + "";//

                    //    if(row.Cells["Pay_Code"].Value + ""!="")
                    //    creditInfo.Pay_Code = row.Cells["Pay_Code"].Value + "";

                    //    creditInfo.CardType = row.Cells["CardType"].Value + "";
                    //    creditInfo.DateUpdate = ReceiptDate;
                    //    creditInfo.PayInID = row.Cells["PayInCode"].Value + ""==""?0:Convert.ToInt16(row.Cells["PayInCode"].Value + "");
                    //    creditInfo.CashMoney = decimal.Parse(row.Cells["cash"].Value + "");
                    //    creditInfo.RCNo = row.Cells["RCNo_Cre"].Value + "";

                    //    listCredit.Add(creditInfo);

                    //}

                    foreach (DataGridViewRow row in dataGridViewCreditTransfer.Rows)
                    {
                        if (row.Cells["cash"].Value + "" == "" || row.Visible == false) continue;
                        CreditCardSOT creditInfo = new CreditCardSOT();
                        creditInfo = new CreditCardSOT();
                        SaveType = "SAVECREDITCARD";
                        creditInfo.QueryType = SaveType;
                        creditInfo.VN = String.IsNullOrEmpty(VN) ? "" : VN;
                        creditInfo.SO = SOReceipt;//SO;
                        creditInfo.EN = Entity.Userinfo.EN;
                        creditInfo.CN = lbCN.Text;
                        creditInfo.CardNumber = row.Cells["number"].Value + "";//เลขที่บัตร
                        creditInfo.CD_Code = row.Cells["CD_Code"].Value + "";//
                        creditInfo.Pay_Code = row.Cells["Pay_Code"].Value + "";
                        creditInfo.CardType = row.Cells["CardType"].Value + "";
                        creditInfo.DateUpdate = row.Cells["PayCreditDate"].Value + "" == "" ? DateTime.Now : Convert.ToDateTime(row.Cells["PayCreditDate"].Value + "");
                        creditInfo.PayInID = row.Cells["PayInCode"].Value + "" == "" ? 0 : Convert.ToInt16(row.Cells["PayInCode"].Value + "");
                        creditInfo.CashMoney = decimal.Parse(row.Cells["cash"].Value + ""); //
                        creditInfo.RCNo = row.Cells["RCNo_Cre"].Value + "";
                        listCredit.Add(creditInfo);

                    }
                    SumOfTreatment info = new SumOfTreatment();
                    info.CreditCardSotInfo = listCredit.ToArray();

                    intStatus = new Business.SumOfTreatment().SaveRCNoSUBList(info);

                    if (dgvReciept.RowCount > 0) dgvReciept.Rows.Clear();
                //}
                panelPayType.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void pictureBoxSaveRCNList_Click(object sender, EventArgs e)
        {
            //if (ShowSumList_Check() == false)
            //{
            //    MessageBox.Show("จำนวนเงินไม่ถูกต้อง", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            SaveRCNoSUBList();
            //BindCashCredit();
            SaveSOF(false);
            BindFrmSumOfTreatment();
            BindReciept();
            FilterCash_Credit("All");
        }

        private void toolStripPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvReciept.CurrentRow.Index <= 0)
                {
                    MessageBox.Show("กรุณาเลือกรายการใบเสร็จ");
                    return;
                }
                SaveSOF(false);
                string ReceiptBath = Convert.ToDecimal(dgvReciept.Rows[dgvReciept.CurrentRow.Index].Cells["ReceiptBath"].Value).ToString("###,###,###,###.##");
                DateTime ReceiptDate = Convert.ToDateTime(dgvReciept.Rows[dgvReciept.CurrentRow.Index].Cells["ReceiptDate"].Value);
                string rc = dgvReciept.Rows[dgvReciept.CurrentRow.Index].Cells["RCNo"].Value + "";
                SOReceiptPrint = dgvReciept.Rows[dgvReciept.CurrentRow.Index].Cells["dataSO"].Value + "";
                double SumRCN = 0;
                foreach (DataGridViewRow row in dataGridViewCreditTransfer.Rows)
                {
                    if (row.Visible)
                    {
                        SumRCN += row.Cells["cash"].Value + "" == "" ? 0 : Convert.ToDouble(row.Cells["cash"].Value + "");
                    }
                }
                if (SumRCN != Convert.ToDouble(ReceiptBath))
                {
                    MessageBox.Show("จำนวนเงินไม่ถูกต้อง");
                    return;
                }

                if (!(Userinfo.IsAdmin ?? "").Contains(Userinfo.EN) && !Userinfo.IS_ADMIN_DISCOUNT.Contains(Userinfo.EN) && ReceiptDate.AddDays(3) <= DateTime.Now.Date)//ใช้วันที่จ่าย ล่าสุด + 3 วัน
                {
                    string alert = string.Format("ไม่สามารถปริ้นใบเสร็จย้อนหลังเกิน 3 วัน{0}กรุณาติดต่อผู้ดูแลระบบ", Environment.NewLine);
                    popAlert pa = new popAlert();
                    pa.txtShow = alert;
                    pa.txtTitle = "คำเตือน";

                    pa.ShowDialog();
                    if (pa.DialogResult == DialogResult.Yes)
                    {
                        return;
                    }
                    else
                    {
                        return;
                    }
                }


                BindFrmSumOfTreatment();
                PrintBill2NoVat();//ใบเสร็จ ต้องปริ้นก่อนค่อย reload ใหม่
                BindReciept();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void PrintBill2NoVat()//ใบเสร็จ
        {
            try
            {
                DataRow dr;
                //obj.PrintType = type;
                DataTable dtTmp;
                //dtSumOfTreatPay
                //string sql = "[Vat] <> 'Y'";
                //if (dtSumOfTreat.Select(sql).Any())
                //    dtTmp = dtSumOfTreat.Select(sql).CopyToDataTable();
                //else
                //    return;
                List<DataRow> lst = new List<DataRow>();
                dsSumOfTreat = new Business.SumOfTreatment().SelectSumOfTreatment("SELECT", SOReceiptPrint, "", ReceiptDateCurrent);
                dtSumOfTreat = dsSumOfTreat.Tables[0];
                dtTmp = dtSumOfTreat;

                string strTypeofPay = "";
                FrmPreviewRpt2Page obj = new FrmPreviewRpt2Page();
                //obj.FormName = "RptSOFBill2NoVat";
                if (Convert.ToInt32(dtTmp.Compute("Sum(DiscountBathByItem)", "")) > 0 || (txtIntDiscountBath.Text != "" && txtIntDiscountBath.Text != "0.00"))
                    obj.HasDiscount = true;

                double dblCredit = 0.00;
                double dblCash = 0.00;
                double dblVoucher = 0.00;
                string strBankName = "";
                double sumunpaid = 0;
                sumunpaid = dtTmp.Rows[0]["Unpaid"] + "" == "" ? 0 : Convert.ToDouble(dtTmp.Rows[0]["Unpaid"]);//.Compute("Sum(Unpaid)", ""));
                string add = dtTmp.Rows[0]["AddressTextCode"] + "";
                obj.AddressDer = add;// "บริษัท เดอมาสเตอร์ จำกัด 342/1,342/2 ซอยสุขุมวิท 63 (เอกมัย) แขวงคลองตันเหนือ" + Environment.NewLine + "เขตวัฒนา กรุงเทพฯ 10110 โทร. 02-71-444-71 แฟกซ์ 02-714-4001 เลขที่ประจำตัวผู้เสียภาษี 0105554026949" + Environment.NewLine + "Dermaster Company Limited (Head Office) 342/1,342/2 Soi Sukhumvit 63 (Ekkamai), Klongton Nua," + Environment.NewLine + "Wattana Bangkok 10110 Tel: +662-71-444-71 Fax: +662-714-4001 Tax ID No. 0105554026949";

                decimal PayDeposit = dtTmp.Rows[0]["PayDeposit"] + "" == "" ? 0 : Convert.ToDecimal(dtTmp.Rows[0]["PayDeposit"]);
                decimal NetAmount = dtTmp.Rows[0]["NetAmount"] + "" == "" ? 0 : Convert.ToDecimal(dtTmp.Rows[0]["NetAmount"]);

                //decimal total3 = dataGridViewCreditTransfer.Rows.Cast<DataGridViewRow>()
                //.Where(r => r.Cells["cash"].Value + "" != "" && r.Visible)
                //.Sum(t => Convert.ToDecimal(t.Cells["cash"].Value));


                decimal? total3 = 0;
                using (var context = new m_DataSet.EntitiesOPD_System())
                {
                    var dataCashCreditCardSOT = context.CashCreditCardSOTs.Where(x => x.SO == SO).ToList();
                    foreach (var val in dataCashCreditCardSOT) //หาข้อมูลในราคารวมหลังหักส่วนลด ใน gridview
                    {
                        total3 += val.CashMoney;
                    }
                }
                //PayDeposit + 
                if (total3 != NetAmount)
                {
                    obj.FormName = "RptSOFBillDeposit";

                    dtTmp = dtSumOfTreat.Select().Skip(0).Take(1).CopyToDataTable();// skips 10 rows, then selects ten after that.
                }
                else
                    obj.FormName = "RptSOFBillComplete";

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

                // decimal ReceiptBath = Convert.ToDecimal(dgvReciept.Rows[dgvReciept.CurrentRow.Index].Cells["ReceiptBath"].Value);
                //  DateTime ReceiptDate = Convert.ToDateTime(dgvReciept.Rows[dgvReciept.CurrentRow.Index].Cells["ReceiptDate"].Value);
                //string rc = dgvReciept.Rows[dgvReciept.CurrentRow.Index].Cells["RCNo"].Value + "";


                foreach (DataGridViewRow row in dataGridViewCreditTransfer.Rows)
                {
                    if (row.Cells["cash"].Value + "" != "" && row.Cells["RCNo_Cre"].Value + "" == RCNoCurrent.ToUpper())
                    {
                        if (row.Cells["BillType"].Value + "" == "PayCredit")
                        {
                            dblCredit += double.Parse(row.Cells["cash"].Value + ""); //
                            if (strBankName != "") strBankName += ",";
                            strBankName += row.Cells["name"].Value + "";
                        }
                        else if (row.Cells["BillType"].Value + "" == "PayCash")
                        {
                            dblCash += double.Parse(row.Cells["cash"].Value + ""); //
                        }
                        else if (row.Cells["BillType"].Value + "" == "PayGift")
                        {
                            dblVoucher += double.Parse(row.Cells["cash"].Value + ""); //
                        }

                    }

                }


                //DataRow newdr = dtTmp.NewRow();
                if (!dtTmp.Columns.Contains("DateInv"))
                    dtTmp.Columns.Add("DateInv");

                dtTmp.Rows[0]["DateInv"] = ReceiptDateCurrent;

                if (dtTmp.Columns.Contains("RCNo"))
                    dtTmp.Rows[0]["RCNo"] = RCNoCurrent;

                if (dtTmp.Columns.Contains("ReceiptDate"))
                    dtTmp.Rows[0]["ReceiptDate"] = ReceiptDateCurrent;

                if (dblCredit > 0)
                {
                    //strTypeofPay = " บัตรเครดิต " + strBankName + " " + dblCredit.ToString("###,##0.00") + " บาท ";
                    strTypeofPay = " บัตรเครดิต/Credit Card: " + dblCredit.ToString("###,###,###.##") + " บาท ";
                }
                if (dblCash > 0)
                {
                    if (strTypeofPay.Length > 0) strTypeofPay += "|";
                    strTypeofPay += " เงินสด/Cash: " + dblCash.ToString("###,###,###.##") + " บาท ";
                }
                if (dblVoucher > 0)
                {
                    if (strTypeofPay.Length > 0) strTypeofPay += "|";
                    strTypeofPay += " อื่นๆ/Voucher: " + dblVoucher.ToString("###,###,###.##") + " บาท";
                }
                obj.DiscountBath = string.IsNullOrEmpty(txtIntDiscountBath.Text.Trim())
                                       ? 0.00
                                       : double.Parse(txtIntDiscountBath.Text.Trim());
                dblCredit += dblCash + dblVoucher;
                obj.TypeOfPayment = strTypeofPay;
                obj.PayToday = dblCredit.ToString("###,###,##0.00");
                obj.PayTodayDouble = dblCredit;

                obj.SumUnpaid = Convert.ToDouble(dtTmp.Rows[0]["Unpaid"]);//.Compute("Sum(Unpaid)", ""));
                obj.dt = dtTmp;
                obj.MaximizeBox = true;
                obj.TopMost = true;
                obj.Show();
                obj.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewCreditTransfer_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ShowSumList_Check();
        }
        private bool ShowSumList_Check()
        {
            bool Perfect = false;
            try
            {
                //decimal total3 = dataGridViewCreditTransfer.Rows.Cast<DataGridViewRow>()
                // .Where(r => r.Cells["cash"].Value + "" != "" && r.Visible)
                // .Sum(t => Convert.ToDecimal(t.Cells["cash"].Value));
                decimal totalCreditTransfer = 0;
                decimal AllCreditTransfer = 0;

                decimal totaldgvReciept = 0;
                decimal netAmount = 0;
                decimal row = 0;
                foreach (DataGridViewRow r in dataGridViewCreditTransfer.Rows)
                {
                    if (r.Cells["cash"].Value + "" != "" && r.Visible)
                    {
                        totalCreditTransfer += Convert.ToDecimal(r.Cells["cash"].Value);
                        row += 1;
                    }
                }
                foreach (DataGridViewRow r in dataGridViewCreditTransfer.Rows)
                {
                    if (r.Cells["cash"].Value + "" != "")
                    {
                        AllCreditTransfer += Convert.ToDecimal(r.Cells["cash"].Value);
                    }
                }
                foreach (DataGridViewRow r in dgvReciept.Rows)
                {
                    if (r.Cells["ReceiptBath"].Value + "" != "" && r.Visible)
                    {
                        totaldgvReciept += Convert.ToDecimal(r.Cells["ReceiptBath"].Value);

                    }
                }

                netAmount = txtIntNetTotal.Text == "" ? 0 : Convert.ToDecimal(txtIntNetTotal.Text);

                string div = "";
                if (ReceiptBathCurrent != totalCreditTransfer)
                {

                    if (ReceiptBathCurrent > 0)
                    {
                        div = (ReceiptBathCurrent - totalCreditTransfer).ToString("###,###,###,###.##");
                        lbMoneyError.Visible = true;// MessageBox.Show("ใส่จำนวนเงินไม่ถูกต้อง");
                    }
                    else
                    {

                        div = (netAmount - totalCreditTransfer).ToString("###,###,###,###.##");
                    }
                }
                else
                {
                    lbMoneyError.Visible = false;
                }
                lbsumList.Text = string.Format("{0} รายการ {1}", row, totalCreditTransfer.ToString("###,###,###,###.##"));
                lbMoneyError.Text = "จำนวนเงินไม่ถูกต้อง " + div;
                if (AllCreditTransfer == totaldgvReciept)//==netAmount
                    if (netAmount == AllCreditTransfer)
                        Perfect = true;
                    else
                        Perfect = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Perfect = false;
            }
            return Perfect;
        }

        private void btnREQStock_Click(object sender, EventArgs e)
        {
            try
            {
                SaveREQStock();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveREQStock()//ไม่ reset ก่อน
        {
            try
            {
                ////if (string.IsNullOrEmpty(txtREQNo.Text))
                ////{
                ////    MessageBox.Show("โปรดระบุเลขที่เอกสาร");
                ////    return;
                ////}
                ////if (dataGridViewSelectList.RowCount == 0)
                ////{
                ////    MessageBox.Show("โปรดเลือกรายการ");
                ////    return;
                ////}
                //if (cboReqBranch.SelectedValue + "" == "" || cboReqToBranch.SelectedValue + "" == "")
                //{
                //    MessageBox.Show("โปรดเลือกสาขา");
                //    return;
                //}
                //if (cboWH.SelectedValue + "" == "")
                //{
                //    MessageBox.Show("โปรดเลือก W/H");
                //    return;
                //}
                //if (cboDept.SelectedValue + "" == "")
                //{
                //    MessageBox.Show("โปรดเลือก แผนก");
                //    return;
                //}


                if (REQNoCurrent == "")
                {
                    REQNoCurrent = AryuwatSystem.Data.UtilityBackEnd.GenMaxSeqnoValues("REQ", BranchID + "");
                    //txtREQNo.Text = REQNoCurrent;
                }
                else
                {
                    PrintREQ();
                    return;
                }
                //  REQNoPrint = REQNoCurrent;
                MedicalSupplies info = new MedicalSupplies();
                info.LisItemStock = new List<MedicalSupplies>();
                string dep = "";
                foreach (DataGridViewRow item in dgvData.Rows)
                {
                    if ((item.Cells["MS_Code_Ref"].Value + "").Length < 3) continue;
                    MedicalSupplies aa = new MedicalSupplies();
                    aa.QueryType = "INSER_REQ_STOCK";//INSER_REQ_STOCK
                    aa.MS_Code = item.Cells["MS_Code_Ref"].Value + "";
                    aa.Quantity = item.Cells["amountnumber"].Value + "" == "" || item.Cells["amountnumber"].Value + "" == "0" ? 0 : Convert.ToDouble(item.Cells["amountnumber"].Value + "");
                    aa.REQDate = DateTime.Now.Date;
                    aa.EN_Req = Userinfo.EN;
                    aa.Remark = txtRemark.Text;
                    aa.REQNo = REQNoCurrent;
                    aa.Req_BranchId = BranchID + "";
                    aa.ReqTo_BranchId = BranchID + "";
                    aa.WHCode = BranchID + "";
                    if (dep == "")
                        aa.Dept = dep = item.Cells["Dept"].Value + "";
                    else aa.Dept = dep;

                    aa.ReturnsFlag = "N";
                    aa.UrgentFlag = "N";
                    aa.Fortype = "B";
                    aa.REQUnitCode = item.Cells["MS_UnitStk"].Value + "";
                    //aa.SOno = lbSO.Text;
                    //if (item.Cells["_ExpireDate"].Value + "" == "")
                    //{
                    //    MessageBox.Show("Input Expire Date", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    //    return;
                    //}
                    //else
                    //{
                    //    aa.ExpireDate = Convert.ToDateTime(item.Cells["_ExpireDate"].Value + "");
                    //}

                    info.LisItemStock.Add(aa);
                }

                int? intStatusx = new Business.MedicalSupplies().DeleteStockSuppliesTranREQ(REQNoCurrent);
                int? intStatus = new Business.MedicalSupplies().InsertMedicalStockSuppliesREQ(ref info);
                if (intStatus > 0)
                {
                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, Statics.StrMsgInsertComplete);

                    PrintREQ();

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

        private void PrintREQ()
        {
            try
            {
                FrmPreviewRpt obj = new FrmPreviewRpt();
                DataRow dr;
                obj.PrintType = "";
                string strTypeofPay = "";
                obj.FormName = "RtpREQInventory";

                double dblCredit = 0.00;
                double dblCash = 0.00;
                string strBankName = "";

                dblCredit += dblCash;
                obj.TypeOfPayment = strTypeofPay;
                obj.PayToday = dblCredit.ToString("###,###,##0.00");

                Entity.MedicalSupplies info = new MedicalSupplies();
                info.QueryType = "Search_REQ_STOCKTRAN_ByID";
                info.REQNo = REQNoCurrent;
                info.StartDate = DateTime.Now.Date.AddDays(-1);
                info.EndDate = DateTime.Now.Date.AddDays(1);
                DataSet ds = new Business.MedicalSupplies().SelectStock(info);
                if (ds.Tables.Count <= 0) return;

                if (ds.Tables[0].Rows.Count > 0)
                {
                    obj.dt = ds.Tables[0];
                    obj.MaximizeBox = true;
                    obj.TopMost = true;
                    obj.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
