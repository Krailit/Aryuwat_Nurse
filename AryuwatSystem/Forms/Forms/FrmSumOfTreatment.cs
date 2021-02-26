using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using DermasterSystem.Class;
using Entity;
using WeifenLuo.WinFormsUI.Docking;
using TextBox = System.Windows.Forms.TextBox;


namespace DermasterSystem.Forms
{
    public partial class FrmSumOfTreatment : DockContent
    {
        private Entity.MedicalSupplies info;
        public Utility.AccessType FormType { get; set; }
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
        Dictionary<string,double> dicCashTranfer=new Dictionary<string, double>();
        Dictionary<string, double> dicCashday = new Dictionary<string, double>();
        Dictionary<string, string> dicCreditNumber = new Dictionary<string, string>();
        Dictionary<string, string> dicCreditPeriod = new Dictionary<string, string>(); 
        List<double> lstCashTranfer=new List<double>();
        

        //public string VN;
        public string cn;
        private DataSet dsSumOfTreat;
        private DataTable dtSumOfTreat;
        private DataTable dtSumOfTreatPay;
     

        public string TypeCashier="";
        public string SaveType="";
        public string VN { get; set; }
        public string SO { get; set; }
        string PlayMS_Code = "";
        #region Enum CallMode

        private enum CallMode
        {
            Insert,
            Update,
            Preview
        }
        #endregion
        public FrmSumOfTreatment()
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
            dataGridViewCashTransfer.RowPostPaint+=new DataGridViewRowPostPaintEventHandler(dataGridViewCashTransfer_RowPostPaint);
            dgvData.CellMouseClick += dgvData_CellMouseClick;
            menuDel.Click += new EventHandler(menuDel_Click);
            FormType = Utility.AccessType.Insert;
            this.Closing += new CancelEventHandler(FrmSurgicalFee_Closing);
      }
        private void FrmSumOfTreatment_Load(object sender, EventArgs e)
        {
            BindCommission();
            BindCreditCard();
            BindFrmSumOfTreatment();
        }
        void FrmSurgicalFee_Closing(object sender, CancelEventArgs e)
        {
                Statics.frmSurgicalFee = null;
                if(Statics.frmSOFList!=null)
                    Statics.frmSOFList.BindFrmSurgicalFee(1);
        }
     
        #region Event


        private void menuEdit_Click(object sender, EventArgs e)
        {
           // EditMedicalSupplies();
            //CallForm(CallMode.Update);
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
                if (actDataGridView == "CASH")
                {
                    if (dataGridViewCashTransfer.CurrentRow.Index == -1) return;
                    if (Utility.PopMsg(Utility.EnuMsgType.MsgTypeConfirmYesNo,
                                       Statics.StrConfirmDelete + dataGridViewCashTransfer.CurrentRow.Cells["cashtyp"].Value + " ยอด " + dataGridViewCashTransfer.CurrentRow.Cells["CashCurrent"].Value + "") !=
                        DialogResult.Yes) return;
                    //resultobj = "0";
                    dataGridViewCashTransfer.Rows[rowIndex].ReadOnly = true;
                    dataGridViewCashTransfer.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.DarkGray;
                    dataGridViewCashTransfer.Rows[rowIndex].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
                    dataGridViewCashTransfer.ClearSelection();
                    dataGridViewCashTransfer.Rows[rowIndex].Cells["statusdelcash"].Value = "DEL";
                    dataGridViewCashTransfer.Rows[rowIndex].Cells["NoBill1"].Value = "";

                    dataGridViewCashTransfer.Rows[rowIndex].Visible = false;
                    //if (new Business.SumOfTreatment().DeleteCashCredit(dataGridViewCashTransfer.CurrentRow.Cells["Pay_Code"].Value + "") == 1)
                    //{
                    //    Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, Statics.StrMsgDeleteComplete);
                    //    dataGridViewCashTransfer.Rows.RemoveAt(rowIndex);
                    //}
                }
                else
                {
                    if (dataGridViewCreditTransfer.CurrentRow.Index == -1) return;
                    if (Utility.PopMsg(Utility.EnuMsgType.MsgTypeConfirmYesNo,
                                       Statics.StrConfirmDelete + dataGridViewCreditTransfer.CurrentRow.Cells["name"].Value + " ยอด " + dataGridViewCreditTransfer.CurrentRow.Cells["cash"].Value + "") !=
                        DialogResult.Yes) return;
                    dataGridViewCreditTransfer.Rows[rowIndex].ReadOnly = true;
                    dataGridViewCreditTransfer.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.DarkGray;
                    dataGridViewCreditTransfer.Rows[rowIndex].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
                    dataGridViewCreditTransfer.ClearSelection();
                    dataGridViewCreditTransfer.Rows[rowIndex].Cells["statusdelcredit"].Value = "DEL";
                    dataGridViewCreditTransfer.Rows[rowIndex].Cells["NoBill2"].Value = "";

                    dataGridViewCreditTransfer.Rows[rowIndex].Visible = false;
                    //if (new Business.SumOfTreatment().DeleteCashCredit(dataGridViewCredit.CurrentRow.Cells["Pay_Code"].Value + "") == 1)
                    //{
                    //    Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, Statics.StrMsgDeleteComplete);
                    //    dataGridViewCredit.Rows.RemoveAt(rowIndex);
                    //}
                    
                   
                }
            }
            catch (Exception ex)
            {
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeError, Statics.StrMsgDeleteError + ex);
            }

           
        }
        private void buttonCancel_BtnClick(object sender, EventArgs e)
        {
            Statics.frmSumOfTreatment = null;
            this.Close();
        }
        private void SetColumns()
        {
            Utility.SetPropertyDgv(dgvData);
            foreach (DataGridViewColumn dgvCol in dataGridViewCashTransfer.Columns)
            {
                dgvCol.SortMode = DataGridViewColumnSortMode.NotSortable;
                if (dgvCol.Index == 0 || dgvCol.Index == 1 || dgvCol.Name=="summarycash")
                    dgvCol.ReadOnly = true;
            }
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
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeError, ex.Message);
                Utility.MouseOff(this);
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
               
                listBoxCashTyp.Items.Clear();
                listBoxCashTyp.DataSource = dt.DefaultView;
                listBoxCashTyp.ValueMember = "Bankvalue";
                listBoxCashTyp.DisplayMember = "BankName";
                listBoxCashTyp.SelectedIndex = -1;

                dt = dataSet.Tables[1];
                listBoxCreditTyp.Items.Clear();
                listBoxCreditTyp.DataSource = dt.DefaultView;
                listBoxCreditTyp.ValueMember = "Bankvalue";
                listBoxCreditTyp.DisplayMember = "BankName";
                listBoxCreditTyp.SelectedIndex = -1;

                DataGridViewComboBoxColumn comboBoxColumn1;
                comboBoxColumn1 = new DataGridViewComboBoxColumn();
                //DataTable data = new DataTable();
                //data.Columns.Add(new DataColumn("Value", typeof(string)));
                //data.Columns.Add(new DataColumn("Description", typeof(string)));
                //data.Rows.Add("", "ไม่ระบุ");
                //data.Rows.Add("item1", "item1");
                //data.Rows.Add("item2", "item2");
                //data.Rows.Add("item3", "item3");
                //dataSet.Tables[1].Rows.Add(0, "ไม่ระบุ");

                comboBoxColumn1.DataSource = dataSet.Tables[2].Select("PayInTyp='CASH'").CopyToDataTable(); 
                comboBoxColumn1.ValueMember = "PayInValue";
                comboBoxColumn1.DisplayMember = "PayInName";
                comboBoxColumn1.HeaderText = "Pay in";
                comboBoxColumn1.Name = "PayinCash";
                comboBoxColumn1.Width = 150;
                comboBoxColumn1.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
               
                //comboBoxColumn1.DisplayIndex = 0;
                DataGridViewComboBoxColumn comboBoxColumn2;
                comboBoxColumn2 = new DataGridViewComboBoxColumn();

                comboBoxColumn2.DataSource = dataSet.Tables[2].Select("PayInTyp='CREDIT'").CopyToDataTable(); ;
                comboBoxColumn2.ValueMember = "PayInValue";
                comboBoxColumn2.DisplayMember = "PayInName";
                comboBoxColumn2.HeaderText = "Pay in";
                comboBoxColumn2.Name = "PayinCredit";
                comboBoxColumn2.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                comboBoxColumn2.Width = 150;
                //
                DataGridViewComboBoxColumn comboBoxColumnCardtype;
                comboBoxColumnCardtype = new DataGridViewComboBoxColumn();

                comboBoxColumnCardtype.DataSource = dataSet.Tables[3];
                comboBoxColumnCardtype.ValueMember = "CardType";
                comboBoxColumnCardtype.DisplayMember = "CardType";
                comboBoxColumnCardtype.HeaderText = "CardType";
                comboBoxColumnCardtype.Name = "CardType";
                comboBoxColumnCardtype.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                comboBoxColumnCardtype.Width = 100;

                //comboBoxColumn2.DisplayIndex = 0;
                dataGridViewCashTransfer.Columns.Add(comboBoxColumn1);
                dataGridViewCreditTransfer.Columns.Add(comboBoxColumn2);
                dataGridViewCreditTransfer.Columns.Add(comboBoxColumnCardtype); 
                //dataGridViewCashTransfer.Columns.Insert(dataGridViewCashTransfer.Columns.Count+1, comboBoxColumn1);
                //dataGridViewCreditTransfer.Columns.Insert(dataGridViewCreditTransfer.Columns.Count+1, comboBoxColumn2);
                //dataGridViewCreditTransfer.Columns.Insert(dataGridViewCreditTransfer.Columns.Count+1, comboBoxColumnCardtype); 
                dataGridViewCashTransfer.Columns["PayCashDate"].DisplayIndex = dataGridViewCashTransfer.Columns.Count-1;
                dataGridViewCreditTransfer.Columns["PayCreditDate"].DisplayIndex = dataGridViewCreditTransfer.Columns.Count-1;
            }
            catch (Exception ex)
            {
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeError, ex.Message);
                Utility.MouseOff(this);
                return;
            }
        }
        public void BindFrmSumOfTreatment()
        {
            try
            {
                 dgvData.Rows.Clear();
                 dsSumOfTreat = new Business.SumOfTreatment().SelectSumOfTreatment("SELECT", SO,VN);
                 dtSumOfTreat = dsSumOfTreat.Tables[0];
                int index = 0;
                foreach (DataRowView item in dtSumOfTreat.DefaultView)
                {
                    double s = Convert.ToDouble(string.IsNullOrEmpty(item["MS_Price"] + "") ? "0" : item["MS_Price"] + "".Replace(",", ""));
                    Amount = Convert.ToDouble(string.IsNullOrEmpty(item["Amount"] + "") ? "1" : item["Amount"] + "".Replace(",", ""));
                    numFreeAmount = Convert.ToDouble(string.IsNullOrEmpty(item["FreeAmount"] + "") ? "0" : item["FreeAmount"] + "".Replace(",", ""));
                    SpecialPrice = Convert.ToDouble(string.IsNullOrEmpty(item["SpecialPrice"] + "") ? "0" : item["SpecialPrice"] + "".Replace(",", ""));
                    //Complimentary   
                    //    MarketingBudget
                    //double PriceAfterDis = string.IsNullOrEmpty(item["PriceAfterDis"] + "") ? (s * Amount) : Convert.ToDouble(item["PriceAfterDis"]);
                    double DiscountBathByItem = Convert.ToDouble(string.IsNullOrEmpty(item["DiscountBathByItem"] + "") ? "0" : item["DiscountBathByItem"] + "".Replace(",", ""));


                    double PriceAfterDis = ((s * Amount) + SpecialPrice) - (DiscountBathByItem);
                    double PayByItem = Convert.ToDouble(string.IsNullOrEmpty(item["PayByItem"] + "") ? "0" : item["PayByItem"] + "".Replace(",", ""));
                    var myItems = new IComparable[]
                                      {
                                          item["MS_Code"] + "",
                                          item["MS_Name"] + "",
                                          s.ToString("###,###,###.##"),
                                          Amount.ToString("###,###,###.##"),
                                          item["MS_Unit"] + "",
                                          numFreeAmount.ToString("###,###,###"),
                                          DiscountBathByItem.ToString("###,###,###"),
                                          item["DiscountPercen"] + "",
                                          SpecialPrice.ToString("###,###,###"),
                                          ((s*Amount)+SpecialPrice).ToString("###,###,###.##"),
                                          PriceAfterDis.ToString("###,###,###.##"),
                                           item["Complimentary"]+""== "Y"?true:false ,
                                           item["MarketingBudget"]+""== "Y"?true:false,
                                           item["Gift"]+""== "Y"?true:false,
                                           item["Subject"]+""== "Y"?true:false,
                                           PayByItem.ToString("###,###,##0.00")
                                      };
                    //double chk = Convert.ToDouble(string.IsNullOrEmpty(item["SalePrice"] + "") ? "0" : item["SalePrice"] + "".Replace(",", ""));
                    //if (chk == 0)
                    //    LastSalePrice = SalePrice += PriceAfterDis;
                    //else
                    //{
                    //    LastSalePrice = SalePrice = chk;
                    //}
                   LastSalePrice = SalePrice += PriceAfterDis;//yai  25-4-2014

                     dgvData.Rows.Add(myItems);
                    //dgvData.Rows[index].Cells["discount"].ReadOnly = item["Gift"] + "" != "Y";
                     if (item["Gift"] + "" == "Y" && item["Complimentary"] + "" == "N" && item["MarketingBudget"] + "" == "N" && item["Subject"] + "" == "N")
                         dgvData.Rows[index].Cells["DisBath"].ReadOnly = false;// giff  พิมพ์ลดได้
                     else if (item["Gift"] + "" == "N" && item["Complimentary"] + "" == "N" && item["MarketingBudget"] + "" == "N" && item["Subject"] + "" == "N")
                         dgvData.Rows[index].Cells["DisBath"].ReadOnly = false;// ไม่กิฟ  พิมพ์ลดได้
                     else if (item["Gift"] + "" == "N" && ( item["Complimentary"] + "" == "Y" || item["MarketingBudget"] + "" == "Y" || item["Subject"] + "" == "Y"))
                     {
                         dgvData.Rows[index].Cells["DisBath"].ReadOnly = true;// อื่นๆ  พิมพ์ลดไม่ได้  *****Set 0******* Yai 25-4-2014
                        // dgvData.Rows[index].Cells["money_dis"].Value = 0;
                        // SalePrice = 0;
                     }
                    index++;
                    
                     lbCN.Text = item["CN"] + "";
                     lbSO.Text = item["SO"] + "";
                    lbNameT.Text = item["FullNameThai"] + ""!=""?item["FullNameThai"] + "":item["FullNameEng"] + "";
                    // lbNameE.Text = item["FullNameEng"] + "";
                     lbIR.Text = item["SOT_Code"] + "";
                    txtIntNetTotal.Text = SalePrice.ToString("###,###,###.##");
                    txtRemark.Text = item["Remark"] + "";
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
                dtSumOfTreatPay = new Business.SumOfTreatment().SelectSumOfTreatment("SELECTSUMOFTREATMENT",SO, VN).Tables[0];
                //dtSumOfTreatPay = dsSumOfTreat.Tables[0];

                foreach (DataRowView item in dtSumOfTreatPay.DefaultView)
                {
                    double s = Convert.ToDouble(string.IsNullOrEmpty(item["NetAmount"] + "") ? "0" : item["NetAmount"] + "".Replace(",", ""));
                    LastSalePrice = s;

                    txtearnestmoney.Text = Convert.ToDouble(string.IsNullOrEmpty(item["EarnestMoney"] + "") ? "0" : item["EarnestMoney"] + "".Replace(",", "")).ToString("###,###,###.##");
                    txtIntDiscountAllItemBath.Text = string.IsNullOrEmpty(item["DiscountPercen"] + "") ? "" : item["DiscountPercen"] + "";
                    txtIntDiscountBath.Text = Convert.ToDouble(string.IsNullOrEmpty(item["DiscountBath"] + "") ? "0" : item["DiscountBath"] + "".Replace(",", "")).ToString("###,###,###.##");
                    txtUnpaid.Text = Convert.ToDouble(string.IsNullOrEmpty(item["Unpaid"] + "") ? "0" : item["Unpaid"] + "".Replace(",", "")).ToString("###,###,###.##");
                    dtpDateSave.Value = Convert.ToDateTime(string.IsNullOrEmpty(item["DateSave"] + "") ? DateTime.Now.ToString() : item["DateSave"] + "");
                    comboBoxCommission.SelectedValue = item["EN_COMS"] + "";
                    comboBoxCommission2.SelectedValue = item["EN_COMS2"] + "";
                   }
                //dsSumOfTreat = new Business.SumOfTreatment().SelectSumOfTreatment("SELECTCASHCREDIT",VN);
                //dtSumOfTreat = dsSumOfTreat.Tables[0];
                //foreach (DataRowView item in dtSumOfTreat.DefaultView)
                //{
                //    double d = Convert.ToDouble(string.IsNullOrEmpty(item["cashmoney"] + "") ? "0" : item["cashmoney"] + "".Replace(",", ""));
                //    dicCashday.Add(item["CD_Code"] + "", d);
                //}
                //dtSumOfTreat = dsSumOfTreat.Tables[1];
                //foreach (DataRowView item in dtSumOfTreat.DefaultView)
                //{
                //    double d = Convert.ToDouble(string.IsNullOrEmpty(item["cashmoney"] + "") ? "0" : item["cashmoney"] + "".Replace(",", ""));
                //    dicCashTranfer.Add(item["CD_Code"] + "", d);
                //}
              
                //foreach (DataGridViewRow row in dataGridViewCashTransfer.Rows)
                //    {
                //        if (dicCashTranfer.ContainsKey(row.Cells["CD_CodeCash"].Value + ""))
                //            row.Cells["summarycash"].Value = dicCashTranfer[row.Cells["CD_CodeCash"].Value + ""] == 0 ? "" : dicCashTranfer[row.Cells["CD_CodeCash"].Value + ""].ToString("###,###,###.##");
                //        if (dicCashday.ContainsKey(row.Cells["CD_CodeCash"].Value + ""))
                //            row.Cells["cashmoney"].Value = dicCashday[row.Cells["CD_CodeCash"].Value + ""] == 0 ? "" : dicCashday[row.Cells["CD_CodeCash"].Value + ""].ToString("###,###,###.##");
                //    }
               
                //foreach (DataGridViewRow row in dataGridViewCredit.Rows)
                //{
                //    if (dicCashTranfer.ContainsKey(row.Cells["CD_Code"].Value + ""))
                //        row.Cells["summary"].Value = dicCashTranfer[row.Cells["CD_Code"].Value + ""] == 0 ? "" : dicCashTranfer[row.Cells["CD_Code"].Value + ""].ToString("###,###,###.##");
                //    if (dicCashday.ContainsKey(row.Cells["CD_Code"].Value + ""))
                //       row.Cells["cashday"].Value = dicCashday[row.Cells["CD_Code"].Value + ""] == 0 ? "" : dicCashday[row.Cells["CD_Code"].Value + ""].ToString("###,###,###.##");
                    
                //}

                dsSumOfTreat = new Business.SumOfTreatment().SelectSumOfTreatment("SELECTCASHCREDIT",SO, VN);
                if (dsSumOfTreat==null || dsSumOfTreat.Tables.Count <= 0) return;
                foreach (DataRow dr in dsSumOfTreat.Tables[0].Rows.Cast<DataRow>().Where(dr => dr["NoBill"] + "".ToUpper() == "Y" || dr["NoBillPayin"] + "".ToUpper() == "Y"))
                {
                    NoBill = true;
                }

                List<string>LsPayIn=new List<string>();
                List<string> LsCardType = new List<string>();
                if (dsSumOfTreat.Tables[0].Select("CashTyp='CASH'").Any())
                {
                    dtSumOfTreatPay = dsSumOfTreat.Tables[0].Select("CashTyp='CASH'").CopyToDataTable();
                    dataGridViewCashTransfer.Rows.Clear();
                    foreach (DataRowView item in dtSumOfTreatPay.DefaultView)
                    {
                        string nobill = "";
                        if (item["NoBill"] + "".ToUpper() == "Y" || item["NoBillPayin"] + "".ToUpper() == "Y") nobill="Y";

                        string no = item["NoBillPayin"] + "".ToUpper() == "Y" ? "Y" : "N";
                        
                        LsPayIn.Add(item["PayInID"] + ":" + no);
                        string CashMoney =
                            Convert.ToDouble(string.IsNullOrEmpty(item["CashMoney"] + "")
                                                 ? "0"
                                                 : item["CashMoney"] + "".Replace(",", "")).ToString("###,###,###.##");
                         var myItems = new ICloneable[]
                                          {
                                              item["ID"] + "",
                                              item["CD_Code"] + "",
                                              item["BankNameCash"] + "",
                                              CashMoney,
                                              "",
                                              "",
                                              "",
                                              nobill,
                                              String.Format("{0:yyyy/MM/dd}",item["UpdateDate"] + ""==""? DateTime.Now:Convert.ToDateTime(item["UpdateDate"] + ""))
                                            };
                        dataGridViewCashTransfer.Rows.Add(myItems);
                    }
                }
                DisplayPayInComboColumn(LsPayIn, dataGridViewCashTransfer,"PayInCash");

                LsPayIn.Clear();
                LsCardType.Clear();
                if (dsSumOfTreat.Tables[0].Select("CashTyp='CREDIT'").Any())
                {
                    dtSumOfTreatPay = dsSumOfTreat.Tables[0].Select("CashTyp='CREDIT'").CopyToDataTable();
                    dataGridViewCreditTransfer.Rows.Clear();
                    foreach (DataRowView item in dtSumOfTreatPay.DefaultView)
                    {
                        string nobill = "";
                        if (item["NoBill"] + "".ToUpper() == "Y" || item["NoBillPayin"] + "".ToUpper() == "Y") nobill = "Y";

                        string no = item["NoBillPayin"] + "".ToUpper() == "Y" ? "Y" : "N";
                        LsPayIn.Add(item["PayInID"] + ":" + no);
                        LsCardType.Add(item["CardType"] + "");
                        string CashMoney =
                            Convert.ToDouble(string.IsNullOrEmpty(item["CashMoney"] + "")
                                                 ? "0"
                                                 : item["CashMoney"] + "".Replace(",", "")).ToString("###,###,###.##");
                        var myItems = new[]
                                          {
                                              item["ID"] + "",
                                              item["CD_Code"] + "",
                                              item["BankNameCash"] + "",
                                              item["CardNumber"] + "",
                                              item["PayInID"] + "",
                                              CashMoney,
                                              "",
                                              "",
                                              "",
                                             nobill,
                                             //item["CardType"] + "",
                                             String.Format("{0:yyyy/MM/dd}",item["UpdateDate"] + ""==""? DateTime.Now:Convert.ToDateTime(item["UpdateDate"] + ""))
                                          };
                        dataGridViewCreditTransfer.Rows.Add(myItems);
                    }
                }
                DisplayPayInComboColumn(LsPayIn, dataGridViewCreditTransfer, "PayInCredit");
                DisplayCardTypeComboColumn(LsCardType, dataGridViewCreditTransfer, "CardType");
                ////255, 224, 192
                //foreach (DataGridViewColumn dgvCol in dgvData.Columns.Cast<DataGridViewColumn>().Where(dgvCol => dgvCol.Name == "discount"))
                //{
                //    dgvCol.DefaultCellStyle.BackColor = Color.BurlyWood;
                //}
                //foreach (DataGridViewColumn dgvCol in dataGridViewCashTransfer.Columns.Cast<DataGridViewColumn>().Where(dgvCol => dgvCol.Name == "CashCurrent"))
                //{
                //    dataGridViewCashTransfer.DefaultCellStyle.BackColor = Color.BurlyWood;
                //}
                //foreach (DataGridViewColumn dgvCol in dataGridViewCredit.Columns.Cast<DataGridViewColumn>().Where(dgvCol => dgvCol.Name == "discount"))
                //{
                //    dataGridViewCredit.DefaultCellStyle.BackColor = Color.BurlyWood;
                //}
                dataGridViewCashTransfer.ClearSelection();
                dataGridViewCreditTransfer.ClearSelection();
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
            }
            catch (Exception ex)
            {
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeError, ex.Message);
                Utility.MouseOff(this);
                return;
            }
        }
        private void DisplayPayInComboColumn(List<string> lsPayin,DataGridView dataGrid,string cname)
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
        private void DisplayCardTypeComboColumn(List<string> lsCardType, DataGridView dataGrid, string cname)
        {
            DataGridViewComboBoxColumn column = (DataGridViewComboBoxColumn)dataGrid.Columns[cname];
            for (int x = 0; x <= dataGrid.Rows.Count - 1; x++)
            {
                DataGridViewCell cell = dataGrid.Rows[x].Cells[cname];
                if (column.Items.Count > 0)
                {
                    cell.Value = lsCardType[x];
                }
            }
        }
        private void dgvData_RowPostPaint_1(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }
        private void dataGridViewCredit_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }
        private void dataGridViewCashTransfer_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        private void itemID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private int comboindex = 0;
        private void dataGridViewCashTransfer_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (dataGridViewCashTransfer.CurrentCell.ColumnIndex == dataGridViewCashTransfer.Columns["CashCurrent"].Index)
                {
                    TextBox itemID = e.Control as TextBox;
                    if (!string.IsNullOrEmpty(itemID.Text.Trim()))
                    {

                        itemID.KeyPress += new KeyPressEventHandler(itemID_KeyPress);
                        string v = string.IsNullOrEmpty(itemID.Text) ? "" : itemID.Text + "".Replace(",", "");
                        if (v == "") return;
                        decimal sss = Convert.ToDecimal(v);
                        itemID.Text = sss.ToString("###,###,###.##");
                    }
                }
                ComboBox cb = e.Control as ComboBox;
                if (cb != null)
                {
                    comboindex = dataGridViewCashTransfer.CurrentCell.ColumnIndex;
                    // first remove event handler to keep from attaching multiple:
                    cb.SelectedIndexChanged -= new EventHandler(cbCash_SelectedIndexChanged);

                    // now attach the event handler
                    cb.SelectedIndexChanged += new EventHandler(cbCash_SelectedIndexChanged);
                    //cb.SelectedValue = 4;
                    //object selectedValue = dataGridViewCashTransfer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        void cbCash_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataGridViewCashTransfer.CurrentCell.ColumnIndex != comboindex) return;

            //dataGridViewCashTransfer.Rows[dataGridViewCashTransfer.CurrentCell.RowIndex].Cells[
            //    dataGridViewCashTransfer.CurrentCell.ColumnIndex].Value = "ไม่ระบุ";
            ComboBox combo = sender as ComboBox;
            if (combo == null) return;
            string[] s = (dataGridViewCashTransfer.CurrentRow.Cells["PayinCash"].Value + "").Split(':');
            if (s.Count() != 2) return;
            dataGridViewCashTransfer.CurrentRow.Cells["NoBill1"].Value = s[1];
            //MessageBox.Show(dataGridViewCashTransfer.CurrentRow.Cells["PayinCash"].Value + "");
        }
        void cbCredit_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (dataGridViewCreditTransfer.CurrentCell.ColumnIndex != comboindex) return;

            //dataGridViewCashTransfer.Rows[dataGridViewCashTransfer.CurrentCell.RowIndex].Cells[
            //    dataGridViewCashTransfer.CurrentCell.ColumnIndex].Value = "ไม่ระบุ";
            ComboBox combo = sender as ComboBox;
            if (combo == null) return;
            //dataGridViewCreditTransfer.CancelEdit();
            //string[] s = (dataGridViewCreditTransfer.CurrentRow.Cells["PayinCredit"].Value + "").Split(':');
            //dataGridViewCreditTransfer.CurrentRow.Cells["NoBill2"].Value = s[1];
            ////MessageBox.Show(dataGridViewCashTransfer.CurrentRow.Cells["PayinCash"].Value + "");
            //foreach (DataGridViewRow row in dataGridViewCreditTransfer.Rows)
            //{
            //    string[] ss = (row.Cells["PayinCredit"].Value + "").Split(':');
            //   // creditInfo.PayInID = int.Parse(s[0]);
            //}
        }
        private void dataGridViewCredit_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {


                if (dataGridViewCreditTransfer.CurrentCell.ColumnIndex == dataGridViewCreditTransfer.Columns["cash"].Index || dataGridViewCreditTransfer.CurrentCell.ColumnIndex == dataGridViewCreditTransfer.Columns["installment"].Index)
                {
                    TextBox itemID = e.Control as TextBox;
                    if (itemID != null)
                    {
                        itemID.KeyPress += new KeyPressEventHandler(itemID_KeyPress);
                    }
                }
                ComboBox cb = e.Control as ComboBox;
                if (cb != null)
                {
                    comboindex = dataGridViewCreditTransfer.CurrentCell.ColumnIndex;
                    // first remove event handler to keep from attaching multiple:
                    cb.SelectedIndexChanged -= new EventHandler(cbCredit_SelectedIndexChanged);
                    // now attach the event handler
                    cb.SelectedIndexChanged += new EventHandler(cbCredit_SelectedIndexChanged);
                    //cb.SelectedValue = 4;
                    //object selectedValue = dataGridViewCashTransfer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    return;
                }
            }
            catch (Exception)
            {

            }
        }
        double sum1 = 0;
        double sum2 = 0;

        private void dataGridViewCashTransfer_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                //checkmoney = true;

                if (dataGridViewCashTransfer.CurrentCell.ColumnIndex == dataGridViewCashTransfer.Columns["CashCurrent"].Index)
                {
                    string v = string.IsNullOrEmpty(dataGridViewCashTransfer.CurrentCell.Value + "") ? "" : dataGridViewCashTransfer.CurrentCell.Value + "".Replace(",", "");
                    if (v == "") return;
                    decimal sss = Convert.ToDecimal(v);
                    dataGridViewCashTransfer.CurrentCell.Value = sss.ToString("###,###,###.##");
                }

                summoney();

                string[] s = (dataGridViewCashTransfer.CurrentRow.Cells["PayinCash"].Value + "").Split(':');
                if (s.Count() != 2) return;
                dataGridViewCashTransfer.CurrentRow.Cells["NoBill1"].Value = s[1];
              
                if (checkmoney == false) //return;
                {
                    dataGridViewCashTransfer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    summoney();
                }

               
            }
            catch (Exception)
            {
            }
        }

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
            foreach (DataGridViewRow row in dataGridViewCashTransfer.Rows)
            {
                string cashmoney = row.Cells["cashmoney"].Value + "";
                cashmoney = cashmoney.Replace(",", "");
                //double s = string.IsNullOrEmpty(cashmoney) ? 0 ; : Convert.ToDouble(cashmoney);
                if (string.IsNullOrEmpty(cashmoney)) continue;

                row.Cells["cashmoney"].Value = Convert.ToDouble(cashmoney) == 0 ? "0.00" : Convert.ToDouble(cashmoney).ToString("###,###,###.##");
            }
            foreach (DataGridViewRow row in dataGridViewCreditTransfer.Rows)
            {
                string cash = row.Cells["cash"].Value + "";
                cash = cash.Replace(",", "");
                //double s = string.IsNullOrEmpty(cash) ? 0 : Convert.ToDouble(cash);
                if (!string.IsNullOrEmpty(cash))
                {
                    row.Cells["cash"].Value = Convert.ToDouble(cash) == 0 ? "0.00" : Convert.ToDouble(cash).ToString("###,###,###.##");
                }



                string number = row.Cells["number"].Value + "";
                number = number.Replace(" ", "");

                decimal numberFormat = string.IsNullOrEmpty(number) ? 0 : Convert.ToDecimal(number);

                row.Cells["number"].Value = numberFormat == 0 ? "" : numberFormat.ToString("#### #### #### ####");
                //if (number.Length != 16) row.Cells["number"].Value = "";
            }
        }
        private void summoney()
        {
            try
            {
                sum1 = 0;
                sum2 = 0;
                //dataGridViewCashTransfer.CurrentRow.Cells["statusdelcash"].Value = "DEL";
                double total1 = dataGridViewCashTransfer.Rows.Cast<DataGridViewRow>()
                    .Where(r => r.Cells["summarycash"].Value + "" != "" && r.Cells["statusdelcash"].Value != "DEL")
                    .Sum(t => Convert.ToDouble(t.Cells["summarycash"].Value));
                double total2 = dataGridViewCashTransfer.Rows.Cast<DataGridViewRow>()
                    .Where(r => r.Cells["CashCurrent"].Value + "" != "" && r.Cells["statusdelcash"].Value != "DEL")
                    .Sum(t => Convert.ToDouble(t.Cells["CashCurrent"].Value));

                //sum1 += total1 + total2;

                double total3 = dataGridViewCreditTransfer.Rows.Cast<DataGridViewRow>()
                  .Where(r => r.Cells["cash"].Value + "" != "" && r.Cells["statusdelcredit"].Value != "DEL")
                  .Sum(t => Convert.ToDouble(t.Cells["cash"].Value));
                double total4 = dataGridViewCreditTransfer.Rows.Cast<DataGridViewRow>()
                    .Where(r => r.Cells["summary"].Value + "" != "" && r.Cells["statusdelcredit"].Value != "DEL")
                    .Sum(t => Convert.ToDouble(t.Cells["summary"].Value));

                sum1 = total1 + total2 + total3 + total4;
                //sum1 = 0;
                ////lstCashTranfer = new List<double>();
                //foreach (DataGridViewRow row in dataGridViewCashTransfer.Rows)
                //{
                //    string v = row.Cells["summarycash"].Value + "".Replace(",", "");
                //    string v2 = row.Cells["cashmoney"].Value + "".Replace(",", "");

                //    double vD = 0;
                //    double vD2 = 0;
                //    if (v == "")
                //    {
                //       // lstCashTranfer.Add(vD);
                //        continue;
                //    }
                //    sum1 += Convert.ToDouble(v);
                //    //vD=Convert.ToDouble(v);
                //    //lstCashTranfer.Add(vD);
                //}

                //sum2 = 0;
                //foreach (DataGridViewRow dr in dataGridViewCredit.Rows)
                //{
                //    string v = string.IsNullOrEmpty(dr.Cells["summary"].Value + "") ? "" : dr.Cells["summary"].Value + "".Replace(",", "");
                //    if (v == "") continue;
                //    sum2 += Convert.ToDouble(v);
                //}
                EarnestMoney = sum1 + sum2;
                UnpaidOld = Unpaid;
                Unpaid = LastSalePrice - EarnestMoney;
                txtearnestmoney.Text = EarnestMoney == 0 ? "0.00" : EarnestMoney.ToString("###,###,###.##");
                txtUnpaid.Text = Unpaid == 0 ? "0.00" : Unpaid.ToString("###,###,###.##");



                if (Unpaid < 0)
                {
                    checkmoney = false;
                    MessageBox.Show("ใส่จำนวนเงินไม่ถูกต้อง");
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

                NoBill = dataGridViewCashTransfer.Rows.Cast<DataGridViewRow>().Any(r => r.Cells["NoBill1"].Value + "" == "Y");
                if (NoBill == false)
                {
                    NoBill = dataGridViewCreditTransfer.Rows.Cast<DataGridViewRow>().Any(r => r.Cells["NoBill2"].Value + "" == "Y");
                }
                btnPrintBill.Enabled = !NoBill;
            }
            catch (Exception)
            {
            }
        }
        private void CheckSummoneyOK()
        {
            bool close = false;
            close = Unpaid == 0 ? false : true;

            btnAdd.Enabled = close;
            listBoxCashTyp.Enabled = close;
        }
        private void DisableButton(bool en)
        {
            //btnAdd.Enabled = en;
            btnCloseStatus.Enabled = en;
            btnPrintBill.Enabled = en;
            btnRefMedical.Enabled = en;
            btnSave.Enabled = en;
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
                foreach (DataGridViewRow dr in from DataGridViewRow dr in dgvData.Rows let v = dr.Cells["complimentary"].Value where (bool)v select dr)
                {
                    DiscountComP += Convert.ToDouble(dr.Cells["money_dis"].Value);
                }
                foreach (DataGridViewRow dr in from DataGridViewRow dr in dgvData.Rows let v = dr.Cells["MarketingBudget"].Value where (bool)v select dr)
                {
                    DiscountMBudget += Convert.ToDouble(dr.Cells["money_dis"].Value);
                }
                foreach (DataGridViewRow dr in from DataGridViewRow dr in dgvData.Rows let v = dr.Cells["Gift"].Value where (bool)v select dr)
                {
                    DiscountGiftV += Convert.ToDouble(dr.Cells["money_dis"].Value);
                    //dr.Cells["money_dis"].Value = (Convert.ToDouble(dr.Cells["discount"].Value) * Convert.ToDouble(dr.Cells["Money"].Value) / 100);

                }
                foreach (DataGridViewRow dr in from DataGridViewRow dr in dgvData.Rows let v = dr.Cells["Subject"].Value where (bool)v select dr)
                {
                    DiscountSubject += Convert.ToDouble(dr.Cells["money_dis"].Value);
                }

                foreach (DataGridViewRow dr in dgvData.Rows)
                {
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
                        dr.Cells["money_dis"].Value = (Convert.ToDouble(dr.Cells["Money"].Value) - ((Convert.ToDouble(dr.Cells["discount"].Value) * Convert.ToDouble(dr.Cells["Money"].Value) / 100))).ToString("###,###,###.##");
                    }
                }

                LastSalePrice = dgvData.Rows.Cast<DataGridViewRow>()
                 .Where(r => r.Cells["money_dis"].Value + "" != "")
                 .Sum(t => Convert.ToDouble(t.Cells["money_dis"].Value));
                DiscountAll = DiscountComP + DiscountMBudget + DiscountGiftV + DiscountSubject;//+ DiscountByItemBath;
                txtIntDiscountAllItemBath.Text = DiscountByItemBath.ToString("###,###,###.##");

                DiscountBath = Convert.ToDouble(string.IsNullOrEmpty(txtIntDiscountBath.Text.Replace(",", "")) ? "0" : txtIntDiscountBath.Text.Replace(",", ""));

                LastSalePrice = SalePrice - DiscountBath- DiscountAll;

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
                      MessageBox.Show(this, "คุณต้องการปิดรายการนี้ ?", "ยืนยันการการปิดรายการ",
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
                      DialogResult.No)
                {
                    Entity.SumOfTreatment info = new SumOfTreatment();
                    info.MedStatus_Code = 2;
                    info.QueryType = "UPDATEMEDICALSTATUS";
                    info.SO = lbSO.Text;
                    int? intStatus = new Business.SumOfTreatment().UpdateMedicalStatus(info);
                    if (intStatus == 1)
                    {
                        MessageBox.Show("ปิดรายการเรียบร้อยแล้ว");
                        Statics.frmSumOfTreatment = null;
                        this.Close();
                    }
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
            Statics.frmMedicalOrderSetting.BackColor = Color.FromArgb(170, 232, 229);
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
                        dblCredit += double.Parse(row.Cells["cash"].Value + ""); //
                        if (strBankName != "") strBankName += ",";
                        strBankName += row.Cells["name"].Value + "";
                    }
                }
                foreach (DataGridViewRow row in dataGridViewCashTransfer.Rows)
                {
                    if (row.Cells["CashCurrent"].Value + "" != "")
                    {
                        dblCash += double.Parse(row.Cells["CashCurrent"].Value + ""); //
                    }
                }
                if (dblCredit > 0)
                {
                    //strTypeofPay = " บัตรเครดิต " + strBankName + " " + dblCredit.ToString("###,##0.00") + " บาท ";
                    strTypeofPay = " บัตรเครดิต :" + dblCredit.ToString("###,##0.00") + " บาท ";
                }
                if (dblCash > 0)
                {
                    if (strTypeofPay.Length > 0) strTypeofPay += "/";
                    strTypeofPay += " เงินสด :" + dblCash.ToString("###,##0.00") + " บาท";
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
        private void PrintBillNoVat()
        {
            try
            {
                FrmPreviewRpt obj = new FrmPreviewRpt();
                DataRow dr;

                DataTable dtTmp;
                //dtSumOfTreatPay
                //string sql = "[Vat] <> 'Y' OR [Vat] is NULL";
                //if (dtSumOfTreat.Select(sql).Any())
                //    dtTmp = dtSumOfTreat.Select(sql).CopyToDataTable();
                //else
                //    return;

                dtTmp = dtSumOfTreat;
                
                string strTypeofPay = "";
                obj.FormName = "RptSOFBillNoVAT";
                double dblCredit = 0.00;
                double dblCash = 0.00;
                string strBankName = "";

                foreach (DataGridViewRow row in dataGridViewCreditTransfer.Rows)
                {

                    if (row.Cells["cash"].Value + "" != "")
                    {
                        dblCredit += double.Parse(row.Cells["cash"].Value + ""); //
                        if (strBankName != "") strBankName += ",";
                        strBankName += row.Cells["name"].Value + "";
                    }
                }
                foreach (DataGridViewRow row in dataGridViewCashTransfer.Rows)
                {
                    if (row.Cells["CashCurrent"].Value + "" != "")
                    {
                        dblCash += double.Parse(row.Cells["CashCurrent"].Value + ""); //
                    }
                }
                if (dblCredit > 0)
                {
                    //strTypeofPay = " บัตรเครดิต " + strBankName + " " + dblCredit.ToString("###,##0.00") + " บาท ";
                    strTypeofPay = " บัตรเครดิต :" + dblCredit.ToString("###,##0.00") + " บาท ";
                }
                if (dblCash > 0)
                {
                    if (strTypeofPay.Length > 0) strTypeofPay += "/";
                    strTypeofPay += " เงินสด " + dblCash.ToString("###,##0.00") + " บาท";
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

        private void buttonTax_Click(object sender, EventArgs e)
        {
            SaveSOF(false);
            PrintBill2Vat();
        }

        private void PrintBill2Vat()//ใบกำกับภาษี
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

                string strTypeofPay = "";
                obj.FormName = "RptSOFBill2Vat";
                double dblCredit = 0.00;
                double dblCash = 0.00;
                string strBankName = "";

                foreach (DataGridViewRow row in dataGridViewCreditTransfer.Rows)
                {
                    if (row.Cells["cash"].Value + "" != "" && row.Cells["cash"].Value + "" == String.Format("{0:yyyy/MM/dd}", DateTime.Now))
                    {
                        dblCredit += double.Parse(row.Cells["cash"].Value + ""); //
                        if (strBankName != "") strBankName += ",";
                        strBankName += row.Cells["name"].Value + "";
                    }
                }
                foreach (DataGridViewRow row in dataGridViewCashTransfer.Rows)
                {
                    if (row.Cells["CashCurrent"].Value + "" != "" && row.Cells["PayCashDate"].Value + "" == String.Format("{0:yyyy/MM/dd}", DateTime.Now))
                    {
                        dblCash += double.Parse(row.Cells["CashCurrent"].Value + ""); //
                    }
                }
                if (dblCredit > 0)
                {
                   //strTypeofPay = " บัตรเครดิต " + strBankName + " " + dblCredit.ToString("###,##0.00") + " บาท ";
                    strTypeofPay = " บัตรเครดิต : " + dblCredit.ToString("###,###,##0.00") + " บาท ";
                }
                if (dblCash > 0)
                {
                    if (strTypeofPay.Length > 0) strTypeofPay += "/";
                    strTypeofPay += " เงินสด :" + dblCash.ToString("###,###,##0.00") + " บาท";
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void PrintBill2NoVat()//ใบเสร็จ
        {
            try
            {
                FrmPreviewRpt obj = new FrmPreviewRpt();
                DataRow dr;

                DataTable dtTmp;
                //dtSumOfTreatPay
                //string sql = "[Vat] <> 'Y'";
                //if (dtSumOfTreat.Select(sql).Any())
                //    dtTmp = dtSumOfTreat.Select(sql).CopyToDataTable();
                //else
                //    return;

                dtTmp = dtSumOfTreat;

                string strTypeofPay = "";
                obj.FormName = "RptSOFBill2NoVat";
                double dblCredit = 0.00;
                double dblCash = 0.00;
                string strBankName = "";
                //var MaxID = dataGridViewCreditTransfer.Rows.Cast<DataGridViewRow>().Max(r =>Convert.ToDateTime(r.Cells["PayCreditDate"].Value));

                DateTime Maxdate = Convert.ToDateTime("2000/01/01");// String.Format("{0:yyyy/MM/dd}", DateTime.Now);
                  foreach (DataGridViewRow row in dataGridViewCreditTransfer.Rows)
                    {
                      if (Convert.ToDateTime(row.Cells["PayCreditDate"].Value + "") > Maxdate)
                      {
                          Maxdate=Convert.ToDateTime(row.Cells["PayCreditDate"].Value + "");
                      }
                    }

                  foreach (DataGridViewRow row in dataGridViewCashTransfer.Rows)
                  {
                      if (Convert.ToDateTime(row.Cells["PayCashDate"].Value + "") > Maxdate)
                      {
                          Maxdate = Convert.ToDateTime(row.Cells["PayCashDate"].Value + "");
                      }
                  }

                foreach (DataGridViewRow row in dataGridViewCreditTransfer.Rows)
                {
                    if (row.Cells["cash"].Value + "" != "" && row.Cells["PayCreditDate"].Value + "" == String.Format("{0:yyyy/MM/dd}", Maxdate))
                    {
                        dblCredit += double.Parse(row.Cells["cash"].Value + ""); //
                        if (strBankName != "") strBankName += ",";
                        strBankName += row.Cells["name"].Value + "";
                    }
                }
            
                foreach (DataGridViewRow row in dataGridViewCashTransfer.Rows)
                {
                    if (row.Cells["CashCurrent"].Value + "" != "" && row.Cells["PayCashDate"].Value + "" == String.Format("{0:yyyy/MM/dd}", Maxdate))
                    {
                        dblCash += double.Parse(row.Cells["CashCurrent"].Value + ""); //
                    }
                }
                if (dblCredit > 0)
                {
                    //strTypeofPay = " บัตรเครดิต " + strBankName + " " + dblCredit.ToString("###,##0.00") + " บาท ";
                    strTypeofPay = " บัตรเครดิต :" + dblCredit.ToString("###,###,##0.00") + " บาท ";
                }
                if (dblCash > 0)
                {
                    if (strTypeofPay.Length > 0) strTypeofPay += "/";
                    strTypeofPay += " เงินสด :" + dblCash.ToString("###,###,##0.00") + " บาท";
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnPrintBill_Click(object sender, EventArgs e)
        {
            try
            {
                SaveSOF(false);
                PrintBillNoVat();
                //PrintBillVat();
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
                //PrintBill2Vat();
                PrintBill2NoVat();
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

        private void SaveSOF(bool saveclose)
        {
            try
            {
                //PopEditOrUpdateSOT obj = new PopEditOrUpdateSOT();
                //obj.StartPosition = FormStartPosition.CenterScreen;
                //obj.BackColor = Color.FromArgb(170, 232, 229);
                //obj.ShowDialog();
                //if(SaveType=="")return;
                SaveType = "SAVECREDITCARD";
                SumOfTreatment info = new SumOfTreatment();
                List<Entity.CreditCardSOT> listCredit = new List<CreditCardSOT>();
                Entity.CreditCardSOT creditInfo;
                info.QueryType = "UPDATE";
                info.SOT_Code = lbIR.Text;
                info.CN = lbCN.Text;
                //info.VN = lbSO.Text;
                info.SO = SO;

                info.DateSave = dtpDateSave.Value; //new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,);// Convert.ToDateTime(DateTime.Now);//Convert.ToDateTime(txtStartProcedure.Text);
                info.DateUpdate = DateTime.Now;
                //info.PettyCash=lstCashTranfer[0];
                //info.Debtor=lstCashTranfer[1];
                //info.DomesticMoney=lstCashTranfer[2];
                //info.AbroadMoney=lstCashTranfer[3];
                //info.ChecksMoney=lstCashTranfer[4];
                //info.DebitMoney=lstCashTranfer[5];
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
                    SupplieTranInfo.DiscountPercen = string.IsNullOrEmpty(row.Cells["discount"].Value + "") ? "0" : row.Cells["discount"].Value + "";
                    SupplieTranInfo.DiscountBath = string.IsNullOrEmpty(row.Cells["DisBath"].Value + "") ? "0" : row.Cells["DisBath"].Value + "";
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
                    creditInfo.PayInID =s[0]+""==""?0: int.Parse(s[0]);
                    if (row.Cells["cash"].Value + "" != "")
                    {
                        creditInfo.CashMoney = decimal.Parse(row.Cells["cash"].Value + ""); //
                    }

                    listCredit.Add(creditInfo);

                }
                foreach (DataGridViewRow row in dataGridViewCashTransfer.Rows)
                {
                    creditInfo = new CreditCardSOT();
                    creditInfo.QueryType = SaveType;
                    creditInfo.VN = VN;
                    creditInfo.SO = SO;
                    creditInfo.EN = Entity.Userinfo.EN;
                    creditInfo.CN = lbCN.Text;
                    //creditInfo.CardNumber = row.Cells["number"].Value + "";//เลขที่บัตร
                    //creditInfo.BankName = row.Cells["cashtyp"].Value + "";//
                    creditInfo.CD_Code = row.Cells["CD_CodeCash"].Value + "";//
                    creditInfo.Pay_Code = row.Cells["Pay_Code"].Value + "";//
                    creditInfo.StatusDel = row.Cells["statusdelcash"].Value + "";
                    creditInfo.DateUpdate = row.Cells["PayCashDate"].Value + ""==""?DateTime.Now:Convert.ToDateTime(row.Cells["PayCashDate"].Value + "");
                    string[] s = (row.Cells["PayinCash"].Value + "").Split(':');
                    creditInfo.PayInID = int.Parse(s[0]);
                    if (row.Cells["CashCurrent"].Value + "" != "")
                    {
                        creditInfo.CashMoney = decimal.Parse(row.Cells["CashCurrent"].Value + ""); //
                    }
                    listCredit.Add(creditInfo);
                }
                info.CreditCardSotInfo = listCredit.ToArray();
                info.SupplieTranInfo = listSupplieTran.ToArray();

                intStatus = new Business.SumOfTreatment().UpdateSumOfTreatment(info);

                if (intStatus > 0)
                {
                    if (saveclose)
                    {
                        Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, Statics.SaveComplete);
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("ขัดข้อง");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                if (dgvData.CurrentCell.ColumnIndex == dgvData.Columns["DisBath"].Index )//discount
                {
                        string v = string.IsNullOrEmpty(dgvData.CurrentCell.Value.ToString()) ? "" : dgvData.CurrentCell.Value + "".Replace(",", "");
                        //string sp = string.IsNullOrEmpty(dgvData.Rows[e.RowIndex].Cells["Money"].Value.ToString()) ? "" : dgvData.Rows[e.RowIndex].Cells["Money"].Value.ToString() + "".Replace(",", "");
                        if (v == "") return;
                        decimal disBath = Convert.ToDecimal(v);
                        //decimal dis = Convert.ToDecimal(sp) * 50 / 100;
                        decimal price = Convert.ToDecimal(dgvData.Rows[e.RowIndex].Cells["Money"].Value); 
                    //if(dis>50)
                     if (disBath > price)
                    {
                        disBath = 0;
                    }
                    //Money
                     dgvData.CurrentCell.Value = disBath.ToString();// ("###,###,###.##");
                    //v = string.IsNullOrEmpty(dgvData.Rows[e.RowIndex].Cells["Money"].Value + "") ? "" : dgvData.Rows[e.RowIndex].Cells["Money"].Value + "" + "".Replace(",", "");
                    //decimal price=Convert.ToDecimal(v);
                    //dgvData.Rows[e.RowIndex].Cells["discount"].Value = (disBath - (price * dis) / 100).ToString("###,###,###.##");
                    dgvData.Rows[e.RowIndex].Cells["discount"].Value = ((disBath*100) /price).ToString("###,###,###.##");
                    dgvData.Rows[e.RowIndex].Cells["money_dis"].Value = (price - disBath).ToString("###,###,###.##");
                  
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
        private void AddPayToGrid(System.Windows.Forms.ListBox ls)
        {
            try
            {
                if (ls.SelectedIndex != -1)
                {
                    string[] value = ls.SelectedValue.ToString().Split(':');
                    string text = ls.Text;
                    //DataGridViewComboBoxColumn comboBoxColumn1;
                    //comboBoxColumn1 = new DataGridViewComboBoxColumn();
                    //comboBoxColumn1.DataSource = dtcash;
                    //comboBoxColumn1.ValueMember = "PayInID";
                    //comboBoxColumn1.DisplayMember = "PayInName";
                    //comboBoxColumn1.HeaderText = "Pay in";
                    //comboBoxColumn1.Name = "PayinCash";
                    //comboBoxColumn1.Width = 150;
                    //comboBoxColumn1.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                    //dataGridViewCashTransfer.Columns.Add(comboBoxColumn1);
                   
                    
                    if (value[1].ToUpper() == "CASH")
                    {
                        var myItems = new ICloneable[]
                                         {
                                             "",
                                             value[0] + "",
                                             text,"0.00","","",""
                                             ,value[2].ToUpper()
                                             ,String.Format("{0:yyyy/MM/dd}", DateTime.Now)
                                         };
                        dataGridViewCashTransfer.Rows.Add(myItems);
                        dataGridViewCashTransfer["PayInCash", dataGridViewCashTransfer.Rows.Count - 1].Value = "ไม่ระบุ";
                    }
                    else
                    {
                        var myItems = new ICloneable[]
                                         {
                                             "",
                                             value[0] + "",
                                             text,
                                             "",
                                             "",
                                             "0.00",
                                             "",
                                             "",
                                             "",
                                             value[2].ToUpper(),

                                            String.Format("{0:yyyy/MM/dd}", DateTime.Now)
                                         };
                        dataGridViewCreditTransfer.Rows.Add(myItems);
                        dataGridViewCreditTransfer["PayInCredit", dataGridViewCreditTransfer.Rows.Count - 1].Value = "ไม่ระบุ";
                    }
                    summoney();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void listBoxCashTyp_DoubleClick(object sender, EventArgs e)
        {
            AddPayToGrid(listBoxCashTyp);
        }
        private void listBoxCreditTyp_DoubleClick(object sender, EventArgs e)
        {
            AddPayToGrid(listBoxCreditTyp);
        }
        private void btnAdd_BtnClick()
        {
            AddPayToGrid(listBoxCashTyp);
        }

        private void btnAddCredit_BtnClick()
        {
            AddPayToGrid(listBoxCreditTyp);
        }
        private void dataGridViewCashTransfer_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    dataGridViewCashTransfer.ClearSelection();
                    //dgvData.Rows[rowIndex].Selected = false;
                    dataGridViewCashTransfer.Rows[e.RowIndex].Selected = true;
                    rowIndex = e.RowIndex;
                    actDataGridView = "CASH";
                    contextMenuStrip1.Show(MousePosition);
                }
                else
                {
                    if (e.ColumnIndex == dataGridViewCashTransfer.Rows[e.RowIndex].Cells["PayCashDate"].ColumnIndex)
                    {
                        PopDateTime pp = new PopDateTime();
                        DateTime d;
                        pp.SelecttDate = DateTime.TryParse(dataGridViewCashTransfer.Rows[e.RowIndex].Cells["PayCashDate"].Value + "", out d) ? d : DateTime.Now;
                        //pp.SelecttDate =Convert.ToDateTime(pp.SelecttDate.ToString("yyyy/MM/dd"));
                        if (pp.ShowDialog() == DialogResult.OK)
                        {
                            dataGridViewCashTransfer.Rows[e.RowIndex].Cells["PayCashDate"].Value = pp.SelecttDate.Date.ToString("yyyy/MM/dd");
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                return;
            }
        }

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
                    contextMenuStrip1.Show(MousePosition);
                }
                else
                {
                    if (e.ColumnIndex == dataGridViewCreditTransfer.Rows[e.RowIndex].Cells["PayCreditDate"].ColumnIndex)
                    {
                        PopDateTime pp = new PopDateTime();
                        DateTime d;
                        pp.SelecttDate = DateTime.TryParse(dataGridViewCreditTransfer.Rows[e.RowIndex].Cells["PayCreditDate"].Value + "", out d) ? d : DateTime.Now;
                        //pp.SelecttDate =Convert.ToDateTime(pp.SelecttDate.ToString("yyyy/MM/dd"));
                        if (pp.ShowDialog() == DialogResult.OK)
                        {
                            dataGridViewCreditTransfer.Rows[e.RowIndex].Cells["PayCreditDate"].Value = pp.SelecttDate.Date.ToString("yyyy/MM/dd");
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

        private void dataGridViewCashTransfer_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridViewCashTransfer.BeginEdit(false);
                if (e.ColumnIndex == dataGridViewCashTransfer.Columns.Count - 1)// the combobox column index
                {
                    if (this.dataGridViewCashTransfer.EditingControl != null
                        && this.dataGridViewCashTransfer.EditingControl is ComboBox)
                    {
                        ComboBox cmb = this.dataGridViewCashTransfer.EditingControl as ComboBox;
                        cmb.DroppedDown = true;
                      
                    }
                }
                dataGridViewCashTransfer.EndEdit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.ColumnIndex == comboboxColumn.Index && e.RowIndex >= 0) //check if combobox column
        //    {
        //        object selectedValue = dataGridViewCashTransfer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        //    }
        //}

        //changes must be committed as soon as the user changes the drop down box
        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewCashTransfer.IsCurrentCellDirty)
            {
                dataGridViewCashTransfer.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void dataGridViewCredit_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridViewCreditTransfer.BeginEdit(false);
                if (e.ColumnIndex == dataGridViewCreditTransfer.Columns.Count-1)// the combobox column index
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

        private void dataGridViewCashTransfer_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dataGridViewCreditTransfer_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dataGridViewCreditTransfer_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvData_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                
                if (e.Button == MouseButtons.Left)
                {
                    PlayMS_Code = dgvData.Rows[e.RowIndex].Cells["MS_Code"].Value + "";
                    string MS_name = dgvData.Rows[e.RowIndex].Cells["Detail"].Value + "";
                    lbPayItem.Visible = true;
                    lbPayItem.Text =string.Format("Product : {0}", MS_name);
                    double PayByItem = Convert.ToDouble(string.IsNullOrEmpty(dgvData.Rows[e.RowIndex].Cells["PayByItem"].Value + "") ? "0" : dgvData.Rows[e.RowIndex].Cells["PayByItem"].Value + "".Replace(",", ""));
                    textBoxPayByItem.Text = PayByItem.ToString("###,###,##0.00");
                    //textBoxPayByItem.Focus();
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
                textBoxPayByItem.ReadOnly =false;
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

      

       

       

      


  

      

   
        
    }
}
