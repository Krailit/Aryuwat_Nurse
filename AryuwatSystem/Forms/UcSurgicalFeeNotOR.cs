using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AryuwatSystem.DerClass;
using Entity;
using ciloci.FormulaEngine;
using Utility = AryuwatSystem.DerClass.DerUtility;
using AryuwatSystem.Forms.PrintGridView;

namespace AryuwatSystem.Forms
{
    public partial class UcSurgicalFeeNotOR : UserControl
    {
        private Entity.MedicalSupplies info;
        public Utility.AccessType FormType { get; set; }
        private int? intStatus;
        private int OldrowIndex = 0;
        private DataTable dataTable = null;
        private int ID = 0;
        private string MS_CodeOld = "";
        //public string VN;
        public string CN="";
        public string CNType="";
        public string CustomerName = "";
        bool isCom5Pcer = false;
        double AmountOfUse = 0;
        private DataSet dsStuffCommission;
        private DataTable dtStuffCommission;
        private DataSet dsSurgeryFee;
        private DataTable dtSurgeryFee;
        private DataTable dtStuff=new DataTable();
        private string anesRadio = "";
        private bool disAbleRow = false;
        //public string TypeCashier = "SURGERY";
        public string DoctorFee = "0";
        public string TextDetail = "";
        public string admit = "1";
        private double Amount = 0;
        private double MS_Price = 0;
        private double PharamPrice = 0;
        private double FeeRate = 0;
        private double FeeRate2 = 0;
        private bool ManualReset = false;
        public string FreeType = "";
        public string FreeTypeText = "";
        

        bool VIPRate50 = false;
        public string VN { get; set; }
        public string TypeCashier { get; set; }
        private double SPdouble = 0;
        double Quantity = 1;
        private string SP = "0";
        public string SUR_ID = "";
        string tmin1 = "0";
        string tmin2 = "0";
         DataSet ds = new DataSet();
                 DataTable dtCust = new DataTable();
                 DataTable dtSup =new DataTable();

        public List<Entity.MedicalStuff> MedicalStuffs=new List<MedicalStuff>();

        public DataSet DsSurgicalFee { get; set; }
        public string MS_Code { get; set; }
        public string ListOrder { get; set; }
        public string UseTransID { get; set; }
        public DateTime DateUsed { get; set; }

        string txtMS_NameText = "";

        private bool FirstLoad = true;
        private string where;
        public string Sono { get; set; }
        #region Enum CallMode

        private enum CallMode
        {
            Insert,
            Update,
            Preview
        }
        #endregion
        public UcSurgicalFeeNotOR()
        {
            InitializeComponent();
            SetColumns();
         
            //BindMedicalSupplies(1);
            //ngbMain.MoveFirst += ngbMain_MoveFirst;
            //ngbMain.MoveNext += ngbMain_MoveNext;
            //ngbMain.MoveLast += ngbMain_MoveLast;
            //ngbMain.MovePrevious += ngbMain_MovePrevious;
            dgvData.RowPostPaint += dgvData_RowPostPaint;
            dgvData.RowPostPaint += dgvData_RowPostPaint;
            dgvData.CellMouseClick += dgvData_CellMouseClick;
            menuEdit.Click += new EventHandler(menuEdit_Click);
            menuPreview.Click += new EventHandler(menuPreview_Click);
            menuDel.Click += new EventHandler(menuDel_Click);
            FormType = Utility.AccessType.Insert;
            dgvData.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dgvData_RowPostPaint_1);
            txtEndAnesth.TextChanged+=new EventHandler(txtEndAnesth_TextChanged);
            txtStartAnesth.TextChanged+=new EventHandler(txtStartAnesth_TextChanged);
            txtEndProcedure.TextChanged+=new EventHandler(txtEndProcedure_TextChanged);
            txtStartProcedure.TextChanged+=new EventHandler(txtStartProcedure_TextChanged);
            btnSave.Click+=new EventHandler(btnSave_Click);
            radioButtonIV.CheckedChanged+=new EventHandler(radioButtonIV_CheckedChanged);
            radioButtonGA.CheckedChanged+=new EventHandler(radioButtonGA_CheckedChanged);
            radioButtonLA.CheckedChanged+=new EventHandler(radioButtonLA_CheckedChanged);
            btnCancel.Click+=new EventHandler(btnCancel_Click);
            textBoxAdmit.TextChanged+=new EventHandler(textBoxAdmit_TextChanged);
            dgvData.ColumnAdded+=new DataGridViewColumnEventHandler(dgvData_ColumnAdded);
            
           
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
            //if (Utility.PopMsg(Utility.EnuMsgType.MsgTypeConfirmYesNo, "ยืนยันการลบข้อมูล", "ลบข้อมูล") == DialogResult.Yes)
            //{
            if (dgvData.CurrentRow.Index == -1) return;
            if (Utility.PopMsg(Utility.EnuMsgType.MsgTypeConfirmYesNo,
                               Statics.StrConfirmDelete + dgvData.CurrentRow.Cells["MS_code"].Value + "") !=
                DialogResult.Yes) return;
            try
            {
                if (new Business.MedicalSupplies().DeleteSupplies(dgvData.CurrentRow.Cells["MS_code"].Value + "") == 1)
                {
                    Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, Statics.StrMsgDeleteComplete);
                    //BindMedicalSupplies(1);
                }
            }
            catch (Exception ex)
            {
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeError, Statics.StrMsgDeleteError + ex);
            }
            //}
        }
        private void buttonCancel_BtnClick()
        {
            Statics.frmSurgicalFee = null;
            //this.Close();
        }
        private void SetColumns()
        {
            Utility.SetPropertyDgv(dgvData);
            foreach (DataGridViewColumn dgvCol in dgvData.Columns)
            {
                dgvCol.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            //Use History==================
            Utility.SetPropertyDgv(dgvUsedTrans);
            dgvUsedTrans.Columns.Add("Id", "Id");
            dgvUsedTrans.Columns.Add("DateOfUse", "วันที่ใช้");
            dgvUsedTrans.Columns.Add("RefMO", "RefMO");
            dgvUsedTrans.Columns.Add("Amount", "จำนวนที่ใช้");
            dgvUsedTrans.Columns.Add("ProcedureDate", "สถานะค่ามือ");
            //DataGridViewImageColumn colStaff = new DataGridViewImageColumn();
            //{
            //    colStaff.AutoSizeMode =
            //    DataGridViewAutoSizeColumnMode.DisplayedCells;
            //    colStaff.CellTemplate = new DataGridViewImageCell();
            //    colStaff.HeaderText = "Staff";
            //    colStaff.Name = "BtnStaff";
            //}
            //dgvUsedTrans.Columns.Add(colStaff);
            //dgvUsedTrans.Columns.Add("Remark", "หมายเหตุ");

            dgvUsedTrans.Columns["Id"].Visible = false;
            //dgvUsedTrans.Columns["ProcedureDate"].Visible = false;
            dgvUsedTrans.Columns["Amount"].Width = 80;
            dgvUsedTrans.Columns["RefMO"].Width = 80;
            dgvUsedTrans.Columns["DateOfUse"].Width = 100;
            dgvUsedTrans.Columns["ProcedureDate"].Width =70;


            dgvUsedTrans.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvUsedTrans.Columns["DateOfUse"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvUsedTrans.Columns["ProcedureDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
        }
        private void BindDataUseHistory()
        {
            try
            {
                //Utility.MouseOn(this);
                dgvUsedTrans.Rows.Clear();
                Entity.MedicalOrderUseTrans info = new MedicalOrderUseTrans();
                //info.CN = CN;
                info.VN = VN;
                info.MS_Code = MS_Code;
                info.ListOrder = ListOrder;
                if (!string.IsNullOrEmpty(info.VN))
                {
                   DataTable dtTmp = new Business.MedicalOrderUseTrans().SelectMedicalOrderUseTransById(info).Tables[0];
                    foreach (DataRowView item in dtTmp.DefaultView)
                    {
                        if (UseTransID+""=="")UseTransID = item["ID"] + "";
                        object[] myItems = {
                                               item["ID"] + "",
                                               item["DateOfUse"] + "" != ""? DateTime.Parse(item["DateOfUse"] + "").Date.ToShortDateString():"",
                                               item["RefMO"] + "",
                                               double.Parse(item["AmountOfUse"] + "").ToString("###,###.#0"),
                                               item["JobCostdate"] + "" != ""? "Y":"N",
                                           };
                        dgvUsedTrans.Rows.Add(myItems);
                    }
                    foreach (DataGridViewRow dataRow in dgvUsedTrans.Rows)
                    {
                        dataRow.DefaultCellStyle.BackColor = dataRow.Cells["ProcedureDate"].Value+""=="N" ? Color.DarkGray : Color.Khaki;
                        
                    }
                    if(dgvUsedTrans.RowCount>0)
                    UseTransID = dgvUsedTrans.Rows[dgvUsedTrans.RowCount-1].Cells["Id"].Value + "";

                    if (UseTransID != "") btnSave.Enabled = true;
                    if (dgvUsedTrans.Rows.Count > 0)
                    {
                        dgvUsedTrans.ClearSelection();
                        dgvUsedTrans.Rows[dgvUsedTrans.Rows.Count - 1].Selected = true;
                    }
                        
                }
                
            }
            catch (Exception ex)
            {
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeError, ex.Message);
                
                return;
            }
        }
         public void BindSurgeryFee()
         {
             try
             {
                 SPdouble = 0;
                 SurgeryFee info = new SurgeryFee();
                 info.QueryType = "SELECT";
                 info.VN = VN;
                 info.MS_Code = MS_Code;
                 info.UseTransId = UseTransID;
                 dsSurgeryFee = new Business.StuffCommission().SelectSurgeryFee(info);
                 if(UseTransID+""!="")
                    dtSurgeryFee = dsSurgeryFee.Tables[0].Select("UseTransId='" + UseTransID + "'").CopyToDataTable(); 
                 else
                     dtSurgeryFee = dsSurgeryFee.Tables[0]; 
                 
                 //====================Load saved=============
                 foreach (DataRow item in dtSurgeryFee.Rows)
                 {
                     string p=item["Position_IDSave"] + "";
                 
                     string[] arr = p.Split('|');//====by position
                     foreach (string s in arr)
                     {
                         if (s == "") continue;
                         string[] arrValue = s.Split(':');//====by position  and Value[position,value]
                         if (!DicformuraSave.ContainsKey(arrValue[0]))
                              DicformuraSave.Add(arrValue[0], arrValue[1]);
                     }
                    
                  
                 }
                 //===========================================
                 foreach (DataGridViewRow r in dgvUsedTrans.SelectedRows)
                 {
                     UseTransID = r.Cells["Id"].Value + "";
                     DateUsed = r.Cells["Id"].Value + "" == "" ? DateTime.Now : DateTime.Parse(r.Cells["DateOfUse"].Value + "");
                     dtpProdate.Value = DateUsed;
                 }
                 cboExMoney.DataSource = dsSurgeryFee.Tables[1];
                 cboExMoney.ValueMember = "Money";
                 cboExMoney.DisplayMember = "Money";
                 cboExMoney.SelectedIndex = 0;


                 List<string>lsMS_Name=new List<string>();
                 bool isMatch = false;
                 foreach (DataRow dr in dtSurgeryFee.Rows)
                 {
                     CN = dr["CN"] + "";
                     if (CN.Length > 0) CNType = CN.Substring(3, 3);
                     if (MS_Code == dr["MergStatus"] + "")
                     {
                         isMatch = true;
                         FeeRate = string.IsNullOrEmpty(dr["FeeRate"] + "") ? 0 : Convert.ToDouble(dr["FeeRate"] + "");
                         FeeRate2 = string.IsNullOrEmpty(dr["FeeRate2"] + "") ? 0 : Convert.ToDouble(dr["FeeRate2"] + "");
                         FreeType = string.IsNullOrEmpty(dr["FreeType"] + "") ? "" : dr["FreeType"] + "";
                         FreeTypeText = dr["FreeTypeText"] + "";
                         txtMS_Name.Text += FreeTypeText;
                         if (dr["ExtraMoney"] + ""!="")
                            cboExMoney.SelectedValue = dr["ExtraMoney"] + "";

                         string MS_Type = dr["MS_Type"] + "";
                         double pl1 = string.IsNullOrEmpty(dr["MS_CLPrice"] + "") ? 0 : Convert.ToDouble(dr["MS_CLPrice"] + "");
                         AmountOfUse = string.IsNullOrEmpty(dr["AmountOfUse"] + "") ? 1 : Convert.ToDouble(dr["AmountOfUse"] + "");
                         Quantity = string.IsNullOrEmpty(dr["Amount"] + "") ? 1 : Convert.ToDouble(dr["Amount"] + "");
                          double pAF=  string.IsNullOrEmpty(dr["PriceAfterDis"] + "") ? 0 : Convert.ToDouble(dr["PriceAfterDis"] + "");
                          if (pAF == 0)
                          {
                              if (Userinfo.PriceAgency.Contains(CNType))
                              {
                                pAF = string.IsNullOrEmpty(dr["MS_Price"] + "") ? 0 : Convert.ToDouble(dr["MS_Price"] + "");//ถ้าลดจนเหลือ 0 หละใช้ราคาขาย
                              }
                              else
                                  pAF = string.IsNullOrEmpty(dr["MS_CLPrice"] + "") ? 0 : Convert.ToDouble(dr["MS_CLPrice"] + "");//ถ้าลดจนเหลือ 0 หละใช้ราคาขาย

                              pAF*= Quantity;
                          }

                          //if (TypeCashier == "HAIR")
                          //{
                          //    pl1 *= AmountOfUse;
                          //    SPdouble = pl1;
                          //}
                          //else SPdouble += pAF;

                          //pAF = pl1 < pAF - (pAF * 0.20) ? pAF : pl1;


                          SPdouble += pAF;//* Quantity;

                          //if (SPdouble == 0)//Yai 8-5-2014   เผื่อ เป็น พวก subject  mk   gif พวกนั้น
                          //{
                              // double AmountOfUse = string.IsNullOrEmpty(dr["AmountOfUse"] + "") ? 1 : Convert.ToDouble(dr["AmountOfUse"] + "");
                              //MS_Price = Convert.ToDouble(string.IsNullOrEmpty(dr["MS_Price"] + "") ? "0" : dr["MS_Price"] + "");
                          if (MS_Type.ToUpper() == "C" && TypeCashier != "WELLNESS")
                              {
                                  //SPdouble = MS_Price;
                                  AmountOfUse = string.IsNullOrEmpty(dr["AmountOfUse"] + "") ? 1 : Convert.ToDouble(dr["AmountOfUse"] + "");
                                  int couse = 1;
                                  couse = string.IsNullOrEmpty(dr["MS_Number_C"] + "") ? 1 : Convert.ToInt16(dr["MS_Number_C"] + "");
                                  SPdouble = ((SPdouble / couse) / Quantity) * AmountOfUse;
                              }
                              else {
                                  if (TypeCashier == "WELLNESS" && MS_Type.ToUpper() == "S")
                                      SPdouble = (SPdouble / Quantity) * AmountOfUse;
                                  if (TypeCashier != "WELLNESS" && MS_Type.ToUpper() == "S")
                                      SPdouble = (SPdouble / Quantity) * AmountOfUse;
                                  else
                                  { 
                                      if(TypeCashier == "WELLNESS" && MS_Type.ToUpper() == "C")
                                        SPdouble = (SPdouble / Quantity) * AmountOfUse;
                                        //else
                                        //SPdouble = (SPdouble * Quantity);
                                  }

                              }
                            
                          //}

                          try
                          {
                              //if (MS_Type.ToUpper() == "C")
                              //{
                              //    AmountOfUse = string.IsNullOrEmpty(dr["AmountOfUse"] + "") ? 1 : Convert.ToDouble(dr["AmountOfUse"] + "");
                              //    int couse = 1;
                              //    couse = string.IsNullOrEmpty(dr["MS_Number_C"] + "") ? 1 : Convert.ToInt16(dr["MS_Number_C"] + "");
                              //    SPdouble = (SPdouble / couse) * AmountOfUse;
                              //}
                          }
                          catch (Exception)
                          {
                          }

                          if (Userinfo.PriceAgency.Contains(CNType) && TypeCashier != "SURGERY" && TypeCashier != "HAIR")
                              SPdouble = SPdouble-(SPdouble * Userinfo.AGENCY_RATE);//หักค่า agency ก่อน
                         SP = SPdouble.ToString();
                         lbCN_Name.Text = dr["FullNameThai"] + "";
                         lbCN.Text = dr["CN"] + "";
                         lbVN.Text = dr["VN"] + "";

                         if (dr["SurgicalFeeTyp"] + "" != "") //จำนวนที่คิดค่ามือ
                         {
                             Amount =
                                 Convert.ToDouble(string.IsNullOrEmpty(dr["Amount"] + "") ? "0" : dr["Amount"] + "") +
                                 Convert.ToDouble(string.IsNullOrEmpty(dr["FreeAmount"] + "")
                                                      ? "0"
                                                      : dr["FreeAmount"] + "");
                             MS_Price =
                                 Convert.ToDouble(string.IsNullOrEmpty(dr["MS_Price"] + "")
                                                      ? "0"
                                                      : dr["MS_Price"] + "");
                             // txtMS_Name.Text = dr["MS_Name"] + "\n\r," + txtMS_Name.Text + "(" + (MS_Price + "*" + Amount) + ")";
                             
                             if (MS_Code.Contains(":"))
                             {
                                 if (!lsMS_Name.Contains(dr["MS_Code"] + ""))
                                 {
                                     lsMS_Name.Add(dr["MS_Code"] + "");
                                     txtMS_Name.Text = txtMS_NameText = string.Format("({0}/{1}/NetAmount {2}/Quantity {3}){4}", dr["MS_Code"] + "", MS_Price.ToString("###,###,###"), pAF == 0 ? "0" : pAF.ToString("###,###,###"), Quantity, System.Environment.NewLine + dr["MS_Name"]);
                                 }
                             }
                             else txtMS_Name.Text = txtMS_NameText = string.Format("({0}/{1}/NetAmount {2}/Quantity {3}){4}", dr["MS_Code"] + "", MS_Price.ToString("###,###,###"), pAF == 0 ? "0" : pAF.ToString("###,###,###"), Quantity, System.Environment.NewLine + dr["MS_Name"]);
                         }
                         anesRadio = dr["Anesthesia"] + "";
                         SUR_ID = dr["SUR_ID"] + "";
                         //UseTransID = dr["UseTransID"] + "";
                         string ddate = "";

                         txtStartProcedure.Text = dr["StartProcedure"] + "" != "" ? String.Format("{0:t}", DateTime.Parse(dr["StartProcedure"] + "").TimeOfDay) : "";
                         txtEndProcedure.Text = dr["EndProcedure"] + "" != "" ? DateTime.Parse(dr["EndProcedure"] + "").TimeOfDay.ToString() : "";

                         txtStartAnesth.Text = dr["StartAnesth"] + "" != "" ? DateTime.Parse(dr["StartAnesth"] + "").TimeOfDay.ToString() : "";
                         txtEndAnesth.Text = dr["EndAnesth"] + "" != "" ? DateTime.Parse(dr["EndAnesth"] + "").TimeOfDay.ToString() : "";
                         if (dr["SurgicalFeeTyp"] + "" == "") //ค่ายา
                         {
                             double Amount2 =
                                 Convert.ToDouble(string.IsNullOrEmpty(dr["Amount"] + "") ? "0" : dr["Amount"] + "");
                             double MS_Price2 =
                                 Convert.ToDouble(string.IsNullOrEmpty(dr["MS_Price"] + "")
                                                      ? "0"
                                                      : dr["MS_Price"] + "");
                             PharamPrice += (MS_Price2*Amount2);
                         }

                         // MS_Price = Convert.ToDouble(string.IsNullOrEmpty(dr["MS_Price"] + "") ? "0" : dr["MS_Price"] + "");
                         textBoxAdmit.Text = dr["Admit"] + "";
                         if (TypeCashier == "HAIR")
                         {
                             lbGraft.Visible = true;
                             lbGraft.Text = TypeCashier == "HAIR" ? String.Format("{0}{1} ", Amount, " Graft") : "";
                         }
                         else lbGraft.Visible = false;


                         txtHairG.Text = dr["ActuallyAmount"] + "" == "" ? "0" : Convert.ToDouble(dr["ActuallyAmount"] + "").ToString("###,###,###");

                     }
                     //else if (dr["SurgicalFeeNewTab"] + "".ToUpper() == "N")
                     //dtpProdate.Value = dr["ProcedureDate"] + "" == "" ?DateTime.Now: DateTime.Parse(dr["ProcedureDate"] + "");
                     string startTime = "";
                     string endTime = "";
                     TimeSpan duration;
                     if (TypeCashier == "HAIR") anesRadio = "LA";

               
                     switch (anesRadio)
                     {
                         case "GA":
                             radioButtonGA.Checked = true;

                             startTime = txtStartAnesth.Text;
                             endTime = txtEndAnesth.Text;
                             try
                             {
                                 duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));
                              lbAnesthTimeSpan.Text = "(" + duration.Hours.ToString() + " ชม. " + duration.Minutes + " น.)";
                                tmin1 = duration.TotalMinutes.ToString();
                             }
                             catch (Exception)
                             {

                             }
                             break;
                         case "IV":
                             radioButtonIV.Checked = true;
                             try
                             {
                                 duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));
                                 lbAnesthTimeSpan.Text = "(" + duration.Hours.ToString() + " ชม. " + duration.Minutes + " น.)";
                                 tmin1 = duration.TotalMinutes.ToString();
                             }
                             catch (Exception)
                             {

                             }

                             break;
                         case "LA":
                             radioButtonLA.Checked = true;
                             break;
                         default:
                             radioButtonLA.Checked = false;
                             radioButtonIV.Checked = false;
                             radioButtonGA.Checked = false;
                             break;
                     }
                     if(isMatch)break;
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
            
         }
        Dictionary<String, String> Dicformura = new Dictionary<string, string>();
        Dictionary<String, String> DicformuraSave = new Dictionary<string, string>();
        Dictionary<int, bool> DicCheckBox = new Dictionary<int, bool>();
        Dictionary<int, string> DicManualValue = new Dictionary<int, string>();
        private string GetHr(string tminx)
        {
            string hr = "1";
            try
            {
                if (Convert.ToDouble(tminx) <= 90)
                    hr = "1";
                else if (Convert.ToDouble(tminx) > 90 && Convert.ToDouble(tminx) <= 150)
                    hr = "2";
                else if (Convert.ToDouble(tminx) > 150 && Convert.ToDouble(tminx) <= 210)
                    hr = "3";
                else if (Convert.ToDouble(tminx) > 210 && Convert.ToDouble(tminx) <= 270)
                    hr = "4";
                else if (Convert.ToDouble(tminx) > 270 && Convert.ToDouble(tminx) <= 330)
                    hr = "5";
                else if (Convert.ToDouble(tminx) > 330 && Convert.ToDouble(tminx) <= 390)
                    hr = "6";
                else if (Convert.ToDouble(tminx) > 390 && Convert.ToDouble(tminx) <= 450)
                    hr = "7";
                else if (Convert.ToDouble(tminx) > 450 && Convert.ToDouble(tminx) <= 510)
                    hr = "8";
                else if (Convert.ToDouble(tminx) > 510 && Convert.ToDouble(tminx) <= 570)
                    hr = "9";
                else if (Convert.ToDouble(tminx) > 570 && Convert.ToDouble(tminx) <= 630)
                    hr = "10";
                else if (Convert.ToDouble(tminx) > 630 && Convert.ToDouble(tminx) <= 690)
                    hr = "11";
                else if (Convert.ToDouble(tminx) > 690 && Convert.ToDouble(tminx) <= 750)
                    hr = "12";
            }
            catch (Exception)
            {
                
            }
            return hr;
        }
        public void BindUcSurgicalFee(string Type,int rowZero)
        {
            //int xxx = 0;
            //MessageBox.Show(xxx.ToString());
            try
            {
                dtStuff = new DataTable();
                if (UseTransID != "") where = " UseTransId='" + this.UseTransID + "'";
               if (DsSurgicalFee.Tables[2].Select(@where).Any())
               {
                   if (UseTransID != "") where = " UseTransId='" + this.UseTransID + "'";
                   if(DsSurgicalFee.Tables[2].Select(where).Any())
                   dtStuff = DsSurgicalFee.Tables[2].Select(where).CopyToDataTable();
               }

                //SP=SalePrice
                //COM=rate if(hr)COM1hr,COM2hr,COM3hr
                //T=time minit
                //SUM1,SUM2
                //NET1=SP-SUM1
                //NET2=SP-SUM2+วิสัญญี

                List<double>listResult=new List<double>();
                //Dicformura = new Dictionary<string, string>();

                TxtSalePrice.Text = (double.Parse(SP.ToString().Replace(",", "")) - PharamPrice).ToString("###,###,###.#0");

                //=======================================อันนี้สำคัญ===========================เปลี่ยน เมื่อ 25/11/2019  เปลี่ยนจาก ManualReset ==false เป็น true
                if (dgvData.Rows.Count > 0 && ManualReset == false)//ถ้ากด Recal ManualReset=true
                    SP = dgvData.Rows[0].Cells["Money"].Value.ToString().Replace(",", "");  // SP จะ เอาราคาเดิมที่เคยโหลดมาแล้ว
                else
                    SP = (double.Parse(SP.ToString().Replace(",", "")) - PharamPrice) + "";//คลิกรายการเมื่อไหร่ได้ SP ราคาใหม่มา  คือ
                //=======================================อันนี้สำคัญ===========================

                string where1 = " MS_Code='" + this.MS_Code + "' and ListOrder='" + this.ListOrder + "'";
                if (DsSurgicalFee.Tables[1].Select(@where1).Any())
                {
                    DataTable dttemp = DsSurgicalFee.Tables[1].Select(@where1).CopyToDataTable();
                    string MarketingBudget = dttemp.Rows[0]["MarketingBudget"] + "";
                    string Complimentary = dttemp.Rows[0]["Complimentary"] + "";
                    string Subject = dttemp.Rows[0]["Subject"] + "";
                    string FreeType = dttemp.Rows[0]["FreeType"] + "";
                    string GiftCode = dttemp.Rows[0]["GiftCode"] + "";
                    if (MarketingBudget != "" || Complimentary == "Y" || Subject == "Y" || (FreeType != "" && !GiftCode.Contains("GE")) || txtMS_Name.Text.Contains("(S)"))
                    {
                        //SP = (double.Parse(SP.ToString().Replace(",", "")) / 2).ToString();//"###,###,###,###.##"Entity.Userinfo.MK_DISCOUNT_JOBCOST
                        SP = (double.Parse(SP.ToString().Replace(",", ""))-(double.Parse(SP.ToString().Replace(",", "")) * Entity.Userinfo.MK_DISCOUNT_JOBCOST)).ToString();//"###,###,###,###.##"
                        txtMS_Name.Text = txtMS_NameText + " => Free "+FreeTypeText;//MarketingBudget
                    }
                    if (GiftCode != "") txtMS_Name.Text = txtMS_NameText + " Gift " + GiftCode;
                }
                //=====================silicone ==========
                //bool Nosilicone;
                //if (string.IsNullOrEmpty(dtSup.Rows[0]["MSS_Code"] + "")) Nosilicone = true;
                //string COMSILICONE;
                //if (string.IsNullOrEmpty(dtSup.Rows[0]["MSS_CLPrice"] + "")) COMSILICONE = "0";
                //else
                //{
                //    COMSILICONE = dtSup.Rows[0]["MSS_CLPrice"] + "";
                //   // SP = (double.Parse(SP + "") - double.Parse(COMSILICONE)) + "";
                //}
                //========================================

                String COM = "", CMHR = "";
                //COMSILICONE = "";
                double COM1 = 0, COM2 = 0, COM3 = 0;
                string Expression = "";
                string hr = "1";
                double sum1 = 0;
                double sum2 = 0;
                double sum3 = 0;
                double net1 = 0;
                double net2 = 0;
           
                bool sumF1 = false;
                bool sumF2 = false;
                bool sumF3 = false;
                bool netF1 = false;
                bool netF2 = false;
                string agecy="";
                string tmin1 = "1";
                string tmin2 = "1";
                bool chksum = false;
                int i = 0;
                //Nosilicone = false;
                string resultobj = "0";
                //tmin = Convert.ToInt16(tmin) <= 60 ? "60" : tmin;
               // tmin = "1";
            

                //hr = Math.Ceiling(Convert.ToDouble((Convert.ToDouble(tmin) / 60).ToString())).ToString();
                //if (Convert.ToDouble(tmin) <= 90)
                //    hr = "1";
                //else if (Convert.ToDouble(tmin) > 90 && Convert.ToDouble(tmin) <= 150)
                //    hr = "2";
                //else if (Convert.ToDouble(tmin) > 150 && Convert.ToDouble(tmin) <= 210)
                //    hr = "3";
                //else if (Convert.ToDouble(tmin) > 210 && Convert.ToDouble(tmin) <= 270)
                //    hr = "4";
                //else if (Convert.ToDouble(tmin) > 270 && Convert.ToDouble(tmin) <= 330)
                //    hr = "5";
                //else if (Convert.ToDouble(tmin) > 330 && Convert.ToDouble(tmin) <= 390)
                //    hr = "6";
                //else if (Convert.ToDouble(tmin) > 390 && Convert.ToDouble(tmin) <= 450)
                //    hr = "7";
                //else if (Convert.ToDouble(tmin) > 450 && Convert.ToDouble(tmin) <= 510)
                //    hr = "8";
                //else if (Convert.ToDouble(tmin) > 510 && Convert.ToDouble(tmin) <= 570)
                //    hr = "9";
                //else if (Convert.ToDouble(tmin) > 570 && Convert.ToDouble(tmin) <= 630)
                //    hr = "10";
                //else if (Convert.ToDouble(tmin) > 630 && Convert.ToDouble(tmin) <= 690)
                //    hr = "11";
                //else if (Convert.ToDouble(tmin) > 690 && Convert.ToDouble(tmin) <= 750)
                //    hr = "12";

//                hr = GetHr(tmin);

                try
                {
                    dgvData.Rows.Clear();
                }
                catch (Exception)
                {
                   
                    
                }
                

                 FormulaEngine engine = new FormulaEngine();
                int index = 0;
                MedicalStuffs = new List<MedicalStuff>();
                 foreach (DataRowView item in dtStuffCommission.DefaultView)
                 {
                     bool chkbox = true;
                     index++;
                     resultobj = "0";
                     //Nosilicone = false;
                     //if(Convert.ToInt16(hr)>3)
                     COM1 = string.IsNullOrEmpty(item["Com_Bath1Hr"] + "") ? 0 : Convert.ToDouble(item["Com_Bath1Hr"] + "");
                     COM2 = string.IsNullOrEmpty(item["Com_Bath2Hr"] + "") ? 0 : Convert.ToDouble(item["Com_Bath2Hr"] + "");
                     COM3 = string.IsNullOrEmpty(item["Com_Bath3Hr"] + "") ? 0 : Convert.ToDouble(item["Com_Bath3Hr"] + "");


                     if (Userinfo.PriceNormal.Contains(CNType))
                     {
                         Expression = item["FormulaCNT"] + "";
                     }
                     else if (Userinfo.PriceAgency.Contains(CNType))
                     {
                         Expression = item["FormulaCNA"] + "";
                     }
                

                     string startTime = txtStartProcedure.Text;
                     string endTime = txtEndProcedure.Text;
                     try
                     {
                         if (endTime.Length > 3 && startTime.Length > 3)
                         {
                             TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));
                             tmin1 = duration.TotalMinutes.ToString();
                             //tmin = tmin1;
                             hr = GetHr(tmin1);
                         }
                     }
                     catch (Exception)
                     {
                         //hr = "1";
                     }
                     if (Expression.Contains("_TM2") || Expression.Contains("TIME"))
                     {
                          startTime = txtStartAnesth.Text;
                          endTime = txtEndAnesth.Text;
                         try
                         {
                             TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));
                              tmin2 = duration.TotalMinutes.ToString();
                            // tmin = tmin2;
                             hr = GetHr(tmin2);
                         }
                         catch (Exception)
                         {
                             hr = "1";
                         }
                      
                         Expression = Expression.Replace("_TM2", "");
                     }

                     if (hr == "1") CMHR = COM1.ToString();
                     else if (hr == "2") CMHR = (COM1 + COM2).ToString();
                     else if (hr == "3") CMHR = (COM1 + COM2 + COM3).ToString();
                     else if (Convert.ToInt16(hr) > 3) CMHR =( COM1 + COM2 + COM3 + ((Convert.ToInt16(hr)-3)*COM3)).ToString();
                     //switch (hr)
                     //{
                     //    case "1": COM = item["Com_Bath1Hr"] + "";
                     //        break;
                     //    case "2": COM = item["Com_Bath2Hr"] + "";
                     //        break;
                     //    case "3": COM = item["Com_Bath3Hr"] + "";
                     //        break;
                     //    default: COM = item["Com_Bath1Hr"] + "";
                     //        break;
                     //}
                    
                     //Com_Bath1Hr=3
                     //Com_Bath2Hr=1
                     //if (lbCN.Text.Contains("CNT") || lbCN.Text.Contains("CNM") || lbCN.Text.Contains("CNF") || lbCN.Text.Contains("CNE"))
                     if(Userinfo.PriceAgency.Contains(CNType))
                     {
                         COM = item["Com_Bath1Hr"] + "";//3%
                     }
                     else //if (lbCN.Text.Contains("CNA"))
                     {
                         COM = item["Com_Bath2Hr"] + "";//1%
                     }
                     //Silicone====================
                     //if (Expression == "SILICONE")
                     //{
                     //    if (string.IsNullOrEmpty(dtSup.Rows[0]["MSS_Code"] + "")) Nosilicone = true;

                     //    if (string.IsNullOrEmpty(dtSup.Rows[0]["MSS_CLPrice"] + ""))COMSILICONE = "0";
                     //    else
                     //    {
                     //        COMSILICONE = dtSup.Rows[0]["MSS_CLPrice"] + "";
                     //       // SP = (double.Parse(SP + "") - double.Parse(COMSILICONE)) + ""; silicone ไม่ต้องหักออกจากราคาขาย
                     //    }
                     //}
                     agecy = "";
                 
                     //==================================
            
                     
                     //============================
                     if (Expression != "" && !Expression.Contains("SUM") && !Expression.Contains("NET"))
                     {
                         //if (Userinfo.PriceAgency.Contains(CNType) && Expression.ToLower() == "sp" && TypeCashier != "SURGERY" &&  TypeCashier != "HAIR" && TypeCashier != "WELLNESS") agecy = " Agecy(-18%)";
                         if (Userinfo.PriceAgency.Contains(CNType) && Expression.ToLower() == "sp" && TypeCashier != "SURGERY" && TypeCashier != "HAIR" ) agecy = " Agecy(-18%)";


                         
                         



                         Expression = Expression.Replace("SP", SP);

                         Expression = Expression.Replace("TIME", tmin1);
                         Expression = Expression.Replace("COM", COM != "" ? COM : "0");
                         
                      

                         Expression = Expression.Replace("CMHR", CMHR != "" ? CMHR : "0");
                         Expression = Expression.Replace("ADMI", admit != "" ? admit : "1");
                         //if ((dtSup.Rows[0]["MS_Code"] + "").Contains("ADF") && Expression.Contains("DF"))  ไม่มี fix แล้ว 06/2018
                         //    Expression  = dtSup.Rows[0]["DoctorFee"] + "";//  Expression.Replace("DF", "10000");
                         //else
                         //if()
                             Expression=Expression.Replace("DF", DoctorFee);
                         //Expression = Expression.Replace("SILICONE", COMSILICONE);
                         Expression = Expression.Replace("SILICONE", "0");
                         if(TypeCashier == "HAIR")
                         {
                             txtHairG.Visible = lbGraft.Visible;
                             labelHair.Visible = lbGraft.Visible;
                             if(txtHairG.Text=="" || Convert.ToDouble(txtHairG.Text)<=0)
                                txtHairG.Text = Amount.ToString();

                             Amount = txtHairG.Text == "" ? Amount : Convert.ToDouble(txtHairG.Text);
                         }
                         Expression = Expression.Replace("AMOUNT", Amount+"");

                         if (dtSup.Rows[0]["MS_Section"] + "" == "ATB")
                         {
                             Expression = Expression.Replace("FEERATE", (FeeRate * AmountOfUse) + "");
                             Expression = Expression.Replace("FEEASIS", (FeeRate2 * AmountOfUse) + "");
                         }
                         else
                         {
                             Expression = Expression.Replace("FEERATE", FeeRate + "");
                             Expression = Expression.Replace("FEEASIS", FeeRate2  + "");
                         }

                   


                         Expression = "=" + Expression;
                         Formula f = engine.CreateFormula(Expression);
                         resultobj = f.Evaluate().ToString();

                         if (VIPRate50 && (item["Position_Name"] + "").Contains("DF")) resultobj = (Convert.ToDouble(resultobj) / 2).ToString();//ถ้าเป็นงบการตลาด ค่าแพทย์คิดจากราคาขายหารสอง
                       
                     }
                     TextDetail = item["Position_Name"] + agecy;
                     if ((item["Position_Name"] + "").Contains("DF") )
                     {
                         if ((dtSup.Rows[0]["MS_Code"] + "").Contains("ADF"))
                         {
                             string d = dtSup.Rows[0]["DoctorFee"] + "" == "0" ? "0" : Convert.ToDouble(dtSup.Rows[0]["DoctorFee"] + "").ToString("###,###,###");
                             TextDetail = TextDetail.Replace("DF", d).Replace("%", "");
                         }
                         else
                         {
                             string df=(Convert.ToDouble(DoctorFee == "" ? "0" : DoctorFee) * 100).ToString();
                             //if (ManualValue > 0 && i == ManualValue)
                             //{
                             //    double dfmanual = Convert.ToDouble(dgvData.Rows[i].Cells["Money"] + "" == "" ? "0" : dgvData.Rows[i].Cells["Money"] + "");

                             //    if (dfmanual > 0)
                             //    {
                             //        if (Userinfo.PriceAgency.Contains(CNType) && Expression.ToLower() == "sp" && TypeCashier != "SURGERY" && TypeCashier != "HAIR" && TypeCashier != "WELLNESS")//ถ้าเป็น true จะลบ 18 %
                             //        {
                             //            df = (dfmanual / (Convert.ToDouble(SP) - (Convert.ToDouble(SP) * 0.180))).ToString();
                             //        }
                             //        else
                             //        {
                             //            df = ((dfmanual / Convert.ToDouble(SP)) * 100).ToString();
                             //        }
                             //    }
                             //}
                             
                             TextDetail = TextDetail.Replace("DF", df) + (VIPRate50 ? "(ราคาขาย % 2)" : "");
                         }
                     }
                     if (Expression.Contains("SUM1"))
                     {
                         sumF1 = true;
                         Expression = Expression.Replace("SUM1","");
                         string[] arr=Expression.Split('+');
                         string srt = "";
                         int sc = 0;
                         foreach (var s in arr)
                         {
                             sum1 += Convert.ToDouble(Dicformura[s]);
                             sc = Convert.ToInt16(s)+1;
                         }
                         resultobj = sum1.ToString();
                         Dicformura[sc+""] = resultobj;
                      
                      }
                     
                     if (Expression.Contains("NET1"))
                     {
                         netF1 = true;
                         Expression = Expression.Replace("NET1", "");
                         string[] arr = Expression.Split('-');
                 
                         if(arr.Length==2)
                         {
                             net1 = Convert.ToDouble(Dicformura[arr[0]]) - Convert.ToDouble(Dicformura[arr[1]]);
                             resultobj = net1.ToString();
                             Dicformura[i + ""] = resultobj;
                         }
                         
                     }

                     if (Expression.Contains("NETSUM"))
                     {
                         
                         Expression = Expression.Replace("NETSUM",net1.ToString());
                         Expression = Expression.Replace("DF", DoctorFee);
                         Expression = Expression.Replace("COM", COM != "" ? COM : "0");

                         Expression = "=" + Expression;
                         Formula f = engine.CreateFormula(Expression);
                         resultobj = f.Evaluate().ToString();
                         Dicformura[i + ""] = resultobj;
                         
                     }
                     if (Expression.Contains("SUM2"))
                     {
                         int sc = 0;
                         sumF2 = true;
                         Expression = Expression.Replace("SUM2", "");
                         string[] arr = Expression.Split('+');
                         string srt = "";
                         foreach (var s in arr)
                         {
                             sum2 += Convert.ToDouble(Dicformura[s]);
                         }
                         resultobj = sum2.ToString();
                         //Dicformura[sc + ""] = resultobj;
                         Dicformura[i + ""] = resultobj;
                     }
                     if (Expression.Contains("SUM3"))
                     {
                         sumF3 = true;
                         Expression = Expression.Replace("SUM3", "");
                         string[] arr = Expression.Split('+');
                         sum3 = Convert.ToDouble(Dicformura[arr[0]]) + Convert.ToDouble(Dicformura[arr[1]]);
                         resultobj = sum3.ToString();
                         Dicformura[i + ""] = resultobj;
                     }
                     if (Expression.Contains("NET2"))
                     {
                         netF2 = true;
                         Expression = Expression.Replace("NET2", "");
                         string[] arr = Expression.Split('-');
                         string[] arr3 = arr[1].Split('+');

                         if (arr.Length == 2 && arr3.Count()==2)
                         {
                             net2 = Convert.ToDouble(Dicformura[arr[0]]) - Convert.ToDouble(Dicformura[arr3[0]]) + Convert.ToDouble(Dicformura[arr3[1]]);
                             resultobj = net2.ToString();
                             Dicformura[i + ""] = resultobj;
                         }
                         else
                         {
                             net2 = Convert.ToDouble(Dicformura[arr[0]]) - Convert.ToDouble(Dicformura[arr[1]]);
                             resultobj = net2.ToString();
                             Dicformura[i + ""] = resultobj;
                         }

                     }

                     if (resultobj == "") resultobj = "0";


                     //info.MedicalStuffInfo
                     Entity.MedicalStuff stuffInfo;
                     string nameStuff = "";

                     #region set zero
                     if (anesRadio == "LA" && item["DisableIF"] + "" == "LA")
                     {
                         resultobj = "0";
                         Dicformura[i.ToString()] = resultobj;   
                     }
                         //if ((item["DisableIF"] + "").Contains("BREAST AUGMENTATION") && txtMS_Name.Text.ToUpper().Contains("BREAST AUGMENTATION")) resultobj = "0";
                         //if (((item["DisableIF"] + "").ToUpper().Contains(txtMS_Name.Text.ToUpper())) && txtMS_Name.Text.ToUpper().Contains(item["DisableIF"] + "".ToUpper()))
                     string ss = item["DisableIF"] + "".ToUpper();
                     //if (item["DisableIF"] + "" != "Body Tite VaserTite" && item["DisableIF"] + "" !="Body Tite Vaser VaserTite")
                     //{
                     //    resultobj = resultobj;
                     //}
                     //else if (!txtMS_Name.Text.ToUpper().Contains("TITE"))
                     //    {
                     //        resultobj = "0";
                     //        //dgvData.Rows[i - 2].ReadOnly = true;
                     //        //dgvData.Rows[i - 2].DefaultCellStyle.ForeColor = Color.DarkGray;
                     //        //dgvData.Rows[i - 2].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
                     //    }

                     if(index==2)//ที่ไม่คิดค่า agency/ 18%   
                     {
                   
                         if (!Userinfo.PriceAgency.Contains(CNType) && TypeCashier != "AESTHETIC" )//&& TypeCashier != "WELLNESS"
                         {
                             resultobj = "0";
                             Dicformura[i.ToString()] = resultobj;    
                         }
                     }



                   
                 
      #endregion

                     try
                     {
                         if (double.Parse(resultobj + "") == 9999)
                         {
                             if (cboExMoney.SelectedValue + "" != "")
                                 resultobj = cboExMoney.SelectedValue + "";///=======================ค่าน้ำชชชชชชชชชชชช
                             Dicformura[i.ToString()] = resultobj;                         ///
                         }
                     }
                     catch (Exception)
                     {
                      
                     }
                

                   
                     //if (ManualValue > 0 && i == ManualValue)
                     //    resultobj = Dicformura[i.ToString()];
                     //else
                     //    if (!Dicformura.ContainsKey(i.ToString()))
                     //    {
                     //        if (DicformuraSave.Any())
                     //            if (DicformuraSave.ContainsKey(item["Position_ID"] + ""))
                     //               Dicformura.Add(i.ToString(), DicformuraSave[item["Position_ID"] + ""]+"" == "" ? "0" : DicformuraSave[item["Position_ID"] + ""]);
                     //            else 
                     //                Dicformura.Add(i.ToString(), resultobj + "");
                     //        else
                     //            Dicformura.Add(i.ToString(), resultobj + "");

                     //    }

                     
                     //resultobj = Dicformura[i + ""];


                

                     //======================


                     bool haveEMP = false;
                     //หารตามจำนวนคน===========
                     int stuffCount = dtStuff.Rows.Cast<DataRow>().Count(row => item["Position_ID"] + "" == row["Position_ID"] + "");
                     string moneyPerstuff = "";
                     if ((CNType == "CNS" && TypeCashier == "AESTHETIC" && i != 0 && i != 11) || (CNType == "CNS" && TypeCashier == "WELLNESS" && i != 0 && i != 11))
                     {
                         resultobj = (Convert.ToDouble(resultobj) / 2).ToString();
                                                 
                         if (TextDetail.ToLower().Contains("doctor")) resultobj = "0";
                     }


                     //====================Loop ตรวจสอบหมอ ณิชพนชชชชชชชช แล้ว set/2
                     foreach (DataRow row in dtStuff.Rows)
                     {
                         if (item["Position_ID"] + "" == row["Position_ID"] + "")
                         {
                             if (row["EmployeeId"] + "" == "ENL57100001")
                             {
                                 resultobj = (double.Parse(resultobj) / 2).ToString("###,###,###.#0");
                                 isCom5Pcer = true;
                             }
                             else if (FreeType.ToLower() == "f5" || FreeType.ToLower() == "f6")//subject หรือสวัสดิการ
                                      resultobj = "0";
                             
                         }

                     }
                     //====================================================
                     //=============================2017   04   08===================

                     if (ManualValue > 0 && i == ManualValue)
                         resultobj = Dicformura[i.ToString()];
                     else
                         if (!Dicformura.ContainsKey(i.ToString()))
                         {
                             if (DicformuraSave.Any())
                                 if (DicformuraSave.ContainsKey(item["Position_ID"] + ""))//โหลดมา
                                     Dicformura.Add(i.ToString(), DicformuraSave[item["Position_ID"] + ""] + "" == "" ? "0" : DicformuraSave[item["Position_ID"] + ""]);
                                 else
                                     Dicformura.Add(i.ToString(), resultobj + "");
                             else
                                 Dicformura.Add(i.ToString(), resultobj + "");

                         }


                     resultobj = Dicformura[i + ""];

                     //==============================================================

                     if (stuffCount > 0)
                     {
                         moneyPerstuff = TypeCashier == "AESTHETIC" || TypeCashier == "TREATMENT" ? (Convert.ToDouble(resultobj.Replace(",","")) / stuffCount).ToString() : resultobj;
                    
                     }

                     foreach (DataRow row in dtStuff.Rows)
                     {
                         if (item["Position_ID"] + "" == row["Position_ID"] + "")
                         {
                             nameStuff += row["FullNameThai"] + "" == "" ? row["FullNameEng"] + "" : row["FullNameThai"] + "";
                             nameStuff = nameStuff + ",";
                             stuffInfo = new MedicalStuff();
                             stuffInfo.Position_ID = row["Position_ID"] + "";
                             stuffInfo.EmployeeId = row["EmployeeId"] + "";
                             stuffInfo.MS_Code = row["MergStatus"] + "";
                             stuffInfo.FullNameCustomer = row["FullNameThai"] + "" == "" ? row["FullNameEng"] + "" : row["FullNameThai"] + "";
                             stuffInfo.SectionStuff = row["Position_Type"] + "";
                             stuffInfo.Com_Date = DateTime.Now;
                             stuffInfo.Com_Bath = double.Parse(moneyPerstuff);
                             //if (stuffInfo.EmployeeId == "ENL57100001")
                             //{
                             //    stuffInfo.Com_Bath = double.Parse(moneyPerstuff) / 2;
                             //    //resultobj = (double.Parse(moneyPerstuff) / 2).ToString("###,###,###.#0");
                             //    isCom5Pcer = true;
                             //}
                             //else
                             //{
                             //    stuffInfo.Com_Bath = double.Parse(moneyPerstuff);
                             //    isCom5Pcer = false;
                             //}
                             MedicalStuffs.Add(stuffInfo);
                             haveEMP = true;
                         }

                     }
                     //==============Enable for save   if  Stuff=============
                     //if (haveEMP == false) btnSave.Enabled = false;
                     //else btnSave.Enabled = true;

                     //==============Enable for save   if  Stuff=============

                     if (item["MedicalStuff"] + "" == "N" || item["MedicalStuff"] + "" == "Y" && haveEMP == false)
                     {
                         resultobj = "0";
                         Dicformura[i + ""] = resultobj;
                     }

                     if (item["MedicalStuff"] + "" == "Y" && dtStuff.Rows.Count <= 0)
                     {
                         resultobj = "0";
                         Dicformura[i + ""] = resultobj;
                     }




                          var myItems = new[]
                                      {
                                          DicCheckBox[i]+"",//item["Checkbox"] + ""=="Y"?"True":"False",
                                          TextDetail,
                                          nameStuff,
                                          resultobj=="0"?"":double.Parse(resultobj + "").ToString("###,###,###.#0"),//String.Format("{0:F2}", double.Parse(resultobj + "")),//;
                                          "","",
                                          item["Position_ID"]+""
                                      };
                          dgvData.Rows.Add(myItems);
                     //}
                     //===============================สำหรับ คำนวน % DF  เอง  =============================
                          if ((item["Position_Name"] + "").Contains("DF"))
                          {
                              if ((dtSup.Rows[0]["MS_Code"] + "").Contains("ADF"))
                              {
                                  string d = dtSup.Rows[0]["DoctorFee"] + "" == "0" ? "0" : isCom5Pcer?(Convert.ToDouble(dtSup.Rows[0]["DoctorFee"] + "")/2).ToString("###,###,###"):Convert.ToDouble(dtSup.Rows[0]["DoctorFee"] + "").ToString("###,###,###");
                                  TextDetail = TextDetail.Replace("DF", d).Replace("%", "");
                              }
                              else
                              {
                                  string df = (Convert.ToDouble(DoctorFee == "" ? "0" : DoctorFee) * 100).ToString();
                                  
                                  double dfd = 0;
                                   string dfReplace=df+"";
                                  //if (ManualValue > 0 && i == ManualValue)
                                  //{
                                      double dfmanual = Convert.ToDouble((dgvData.Rows[i].Cells["Money"].Value + "") == "" ? "0" : dgvData.Rows[i].Cells["Money"].Value.ToString().Replace(",", ""));
                                      double spp = Convert.ToDouble((dgvData.Rows[0].Cells["Money"].Value + "") == "" ? "0" : dgvData.Rows[0].Cells["Money"].Value.ToString().Replace(",", ""));
                                      if (dfmanual > 0)
                                      {
                                          if (Userinfo.PriceAgency.Contains(CNType) && Expression.ToLower() == "sp" && TypeCashier != "SURGERY" && TypeCashier != "HAIR" )//ถ้าเป็น true จะลบ 18 %
                                          {
                                             // df = (dfmanual / (Convert.ToDouble(SP) - (Convert.ToDouble(SP) * 0.180))).ToString();
                                              dfd = (dfmanual / (Convert.ToDouble(spp) - (Convert.ToDouble(spp) * Entity.Userinfo.DIS_FOREING_RATE)));
                                              df = dfd.ToString("##");
                                          }
                                          else
                                          {
                                              //df = ((dfmanual / Convert.ToDouble(SP)) * 100).ToString();
                                              dfd = ((dfmanual / Convert.ToDouble(spp)) * 100);
                                              df = dfd.ToString("##");
                                          }
                                      }
                                 
                                  //}

                                      TextDetail = TextDetail.Replace(dfReplace, df);// +(VIPRate50 ? "(ราคาขาย % 2)" : "");
                                  dgvData.Rows[i].Cells["Detail"].Value = TextDetail;
                              }
                          }

                          //===============================สำหรับ คำนวน % DF  เอง  =============================
                     
                  
                         //========================Hidden Checkbox
                         if (dgvData.Rows.Count > 0)
                         {
                             DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                             ch1 = (DataGridViewCheckBoxCell)dgvData.Rows[i].Cells[0];
                             //ch1.ReadOnly = item["Checkbox"] + "" != "Y";
                             dgvData.Rows[i].Cells[0].ReadOnly = item["Checkbox"] + "" != "Y";
                         }
                  
                     //========================
                     //==============Set Color====================
                     if (sumF1 || sumF2||sumF3)
                     {
                         sumF1 = sumF1==true?false:false;
                         sumF2 = sumF2 == true ? false : false;
                         sumF3 = sumF3 == true ? false : false;
                        
                         dgvData.Rows[i].ReadOnly = true;
                         dgvData.Rows[i].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                         //dgvData.Rows[i].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
                     }
                     if (netF1 || netF2)
                     {
                         netF1 = netF1 == true ? false : false;
                         netF2 = netF2 == true ? false : false;
                         dgvData.Rows[i].ReadOnly = true;
                         dgvData.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                         //dgvData.Rows[i].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
                     }
                     #region set Disable
                     //string ss = item["DisableIF"] + "".ToUpper();
                     //if (item["DisableIF"] + "" != "Body Tite VaserTite" && item["DisableIF"] + "" != "Body Tite Vaser VaserTite")
                     //{
                     //    //resultobj = resultobj;
                     //}
                     //else if (!txtMS_Name.Text.ToUpper().Contains("TITE"))
                     //{
                     //    //resultobj = "0";
                     //    dgvData.Rows[i].ReadOnly = true;
                     //    dgvData.Rows[i].DefaultCellStyle.ForeColor = Color.DarkGray;
                     //    dgvData.Rows[i].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
                     //}


                     //if (index == 2)
                     //{
                     //    //if (lbCN.Text.Contains("CNT"))
                     //    //{
                     //    //    resultobj = "0";
                     //    //    dgvData.Rows[index - 1].ReadOnly = true;
                     //    //    dgvData.Rows[index - 1].DefaultCellStyle.ForeColor = Color.DarkGray;
                     //    //    dgvData.Rows[index - 1].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
                     //    //}
                     //    //if (!lbCN.Text.Contains("CNA") && TypeCashier != "AESTHETIC" && TypeCashier != "TREATMENT")//Yai20150713
                     //    if ((!lbCN.Text.Contains("CNA") && !lbCN.Text.Contains("CNF")) && TypeCashier != "AESTHETIC" && TypeCashier != "TREATMENT")
                     //    {
                     //        dgvData.Rows[i].ReadOnly = true;
                     //        dgvData.Rows[i].DefaultCellStyle.ForeColor = Color.DarkGray;
                     //        dgvData.Rows[i].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
                     //    }


                     //}


                         //if (anesRadio == "LA" && item["DisableIF"] + "" == "LA" )
                         //{
                         //    dgvData.Rows[i].ReadOnly=true;
                         //    dgvData.Rows[i].DefaultCellStyle.ForeColor = Color.DarkGray;
                         //    dgvData.Rows[i].DefaultCellStyle.Font=new Font(this.Font, FontStyle.Strikeout);
                         //}
                         //if ((item["DisableIF"] + "").Contains("BREAST AUGMENTATION") && txtMS_Name.Text.ToUpper().Contains("BREAST AUGMENTATION"))
                         //{
                         //    dgvData.Rows[i].ReadOnly = true;
                         //    dgvData.Rows[i].DefaultCellStyle.ForeColor = Color.DarkGray;
                         //    dgvData.Rows[i].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
                         //}
                         //if (Nosilicone)
                         //{
                         //    dgvData.Rows[i].ReadOnly = true;
                         //    dgvData.Rows[i].DefaultCellStyle.ForeColor = Color.DarkGray;
                         //    dgvData.Rows[i].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
                         //}
                     #endregion
                         i++;
                       
                 }
                txtPriceTotal.Text = double.Parse(resultobj + "").ToString("###,###.#0");
                  //MessageBox.Show(xxx.ToString());
                //FirstLoad = false;
               
            }
            catch (Exception ex)
            {
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeError, ex.Message);
                //Utility.MouseOff(this);
                return;
            }
        }
      
       
   

        private void picImport_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string strHeader7 = "";
            //    strHeader7 = (hdr7) ? "Yes" : "No";
            //    OleDbConnection MyConnection = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fn + ";Extended Properties=\"Excel 12.0;HDR=" + strHeader7 + ";IMEX=1\"");
            //    OleDbDataAdapter MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [" + wks + "$]", MyConnection);
            //    MyCommand.TableMappings.Add("Table", "TestTable");
            //    DataSet DtSet = new System.Data.DataSet();
            //    MyCommand.Fill(DtSet);
            //    dgv7.DataSource = DtSet.Tables[0];
            //    MyConnection.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }

       

        private void btnRefresh_BtnClick()
        {
            //txtCN.Text = "";
            //txtVN.Text = "";
            //BindMedicalSupplies(1);
        }
        public DataTable GroupByMultiple(string i_sGroupByColumn1,string i_sGroupByColumn2, DataTable dataSource)
        {
            var dv = new DataView(dataSource);
            //getting distinct values for group column
            dv.Sort = i_sGroupByColumn1 + "," + i_sGroupByColumn2 + " ASC";
            DataTable dtGroup = dv.ToTable(true, new[] { i_sGroupByColumn1, i_sGroupByColumn2 });
            return dtGroup;
        }
        public void BindDicCheckbox()
        {
            try
            {
                DicCheckBox = new Dictionary<int, bool>();
                DicManualValue=new Dictionary<int,string>();
                int i= 0;
                foreach (DataRow item in dtStuffCommission.Rows)
                {
                    if (!DicCheckBox.ContainsKey(i)) DicCheckBox.Add(i,true);
                    if (!DicManualValue.ContainsKey(i)) DicManualValue.Add(i, item["ManualValue"]+"");
                    
                    i++;
                }
            }
            catch (Exception)
            {


            }
        }
        private void UcSurgicalFee_Load(object sender, EventArgs e)
        {
            try
            {
                 //ds = new Business.MedicalOrder().SelectMedicalOrderById(VN);
                where = "MergStatus='" + this.MS_Code + "' and ListOrder='"+this.ListOrder+"'";
                 dtCust = DsSurgicalFee.Tables[0];
                 dtSup = DsSurgicalFee.Tables[1].Select(where).CopyToDataTable();

                 if (DsSurgicalFee.Tables[2].Select(@where).Any())
                 {
                    dtStuff = DsSurgicalFee.Tables[2].Select(where).CopyToDataTable();
                 }
                 txtHairG.Visible = false;
                 labelHair.Visible = false;
                 lbGraft.Visible = false;
                 dsStuffCommission = new Business.StuffCommission().SelectStuffCommission(TypeCashier);
                 dtStuffCommission = dsStuffCommission.Tables[0];

                 DoctorFee = dtSup.Rows[0]["DoctorFee"] + "" == "" ? "0" : dtSup.Rows[0]["DoctorFee"] + "";
                 VIPRate50 = dtSup.Rows[0]["MarketingBudget"] + "" == "" ? false : true;
                // VIPRate50 = (dtSup.Rows[0]["MarketingBudget"] + "") == "" ? "0" : dtSup.Rows[0]["DoctorFee"] + "";
                 BindDicCheckbox();
                BindDataUseHistory();
                BindSurgeryFee();
              
                BindUcSurgicalFee(TypeCashier,0);
                FirstLoad = false;
                if (!Userinfo.IsAdmin.Contains(Userinfo.EN) && !Userinfo.IS_ADMIN_JOBCOST.Contains(Userinfo.EN))
                    dgvData.Columns["Money"].Visible = false;
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void dgvData_RowPostPaint_1(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }
        private void txtEndAnesth_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtStartAnesth.Text.Length == 5 && txtEndAnesth.Text.Length == 5)
                {
                    string startTime = txtStartAnesth.Text;
                    string endTime = txtEndAnesth.Text;
                    TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));
                    lbAnesthTimeSpan.Text = "(" + duration.Hours.ToString() + " ชม. " + duration.Minutes + " น.)";
                    tmin2 = duration.TotalMinutes.ToString();
                    //if (!FirstLoad)
                    //BindUcSurgicalFee("",0);
                }
                else
                {
                    lbAnesthTimeSpan.Text = "";
                }
            }
            catch (Exception)
            {
                
               
            }
           
        }
        private void txtStartAnesth_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtStartAnesth.Text.Length == 5 && txtEndAnesth.Text.Length == 5)
                {
                    string startTime = txtStartAnesth.Text;
                    string endTime = txtEndAnesth.Text;
                    TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));
                    lbAnesthTimeSpan.Text = "(" + duration.Hours.ToString() + " ชม. " + duration.Minutes + " น.)";
                    tmin2 = duration.TotalMinutes.ToString();
                    //if (!FirstLoad)
                    //{
                    //    BindUcSurgicalFee("", 0);
                    //}
                }
                else
                {
                    lbAnesthTimeSpan.Text = "";
                }
            }
            catch (Exception)
            {


            }
        }
        private void txtEndProcedure_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtStartProcedure.Text.Length == 5 && txtEndProcedure.Text.Length == 5)
                {
                    string startTime = txtStartProcedure.Text;
                    string endTime = txtEndProcedure.Text;
                    TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));
                    lbProTimeSpan.Text = "(" + duration.Hours.ToString() + " ชม. " + duration.Minutes + " น.)";
                    tmin1 = duration.TotalMinutes.ToString();
                    //if (!FirstLoad)
                    //{
                    //    //BindSurgeryFee();
                    //    BindUcSurgicalFee("",0);
                    //}
                 
                }
                else
                {
                    lbProTimeSpan.Text = "";
                }
            }
            catch (Exception)
            {


            }
        }

        private void txtStartProcedure_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (txtStartProcedure.Text.Length == 5 && txtEndProcedure.Text.Length == 5)
                {
                    string startTime = txtStartProcedure.Text;
                    string endTime = txtEndProcedure.Text;
                    TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));
                    lbProTimeSpan.Text = "(" + duration.Hours.ToString() + " ชม. " + duration.Minutes + " น.)";
                    tmin1 = duration.TotalMinutes.ToString();
//                    if (!FirstLoad)
//                    {
////                        BindSurgeryFee();
//                        BindUcSurgicalFee("", 0);
//                    }
                
                }
                else
                {
                    lbProTimeSpan.Text = "";
                }
            }
            catch (Exception)
            {


            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SurgeryFee info =new SurgeryFee();
                
                //==========================Save Position
                //foreach (DataGridViewRow item in dgvData)
                for (int i = 0; i < dgvData.RowCount; i++)
                {
                    info.Position_IDSave += string.Format("{0}:{1}|", dgvData["Position_ID", i].Value + "", dgvData["money", i].Value + "" == "" ? "0" : dgvData["money", i].Value + ""); 
                }
                //==========================


                info.QueryType = "SAVE";
                //var idMax = UtilityBackEnd.GenMaxSeqnoValues("SUR");
                info.SUR_ID = SUR_ID;
                info.CN = lbCN.Text;
                info.VN = lbVN.Text;
                info.Sono = this.Sono;
                info.MS_Code = MS_Code;
                info.ListOrder = this.ListOrder;
               // info.MS_Code = "ODF05012";
                info.Tablename = "SURGERYFEE";
                info.Anesthesia = anesRadio;
                  string startTime = txtStartAnesth.Text;
                string endTime = txtEndAnesth.Text;
                info.ProcedureDate = dtpProdate.Value;
                info.Admit = Convert.ToInt16(string.IsNullOrEmpty(textBoxAdmit.Text) ? "0" : textBoxAdmit.Text);
                info.EN_Save = Entity.Userinfo.EN;
               info.UseTransId = UseTransID;

                info.ExtraMoney = cboExMoney.Items.Count > 0 ? Convert.ToInt16(cboExMoney.SelectedValue) : 0;

                if (info.UseTransId==null)
                {
                    MessageBox.Show("กรุณาเลือก Used history");
                    return;
                }
                if (TypeCashier == "SURGERY")
                {
                    if (anesRadio != "LA")
                    {
                        if (txtStartAnesth.Text.Length != 5 && txtEndAnesth.Text.Length != 5)
                        {
                            MessageBox.Show("โปรดระบุ เวลาที่เริ่ม และเสร็จ \n Starttime and endtime");
                            return;
                        }

                        if (txtEndProcedure.Text.Length != 5 && txtStartProcedure.Text.Length != 5)
                        {
                            MessageBox.Show("โปรดระบุ เวลาที่เริ่ม และเสร็จ \n Starttime and endtime");
                            return;
                        }
                    }
                    else
                    {
                        if (txtStartProcedure.Text.Length != 5 && txtEndProcedure.Text.Length != 5)
                        {
                            MessageBox.Show("โปรดระบุ เวลาที่เริ่ม และเสร็จ\n Starttime and endtime");
                            return;
                        }
                    }
                }

                try
                {
                    //if(txtStartProcedure.Text.Length>5)
                    info.StartProcedure = DateTime.Parse(txtStartProcedure.Text); //new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,);// Convert.ToDateTime(DateTime.Now);//Convert.ToDateTime(txtStartProcedure.Text);
                    //if (txtEndProcedure.Text.Length > 5)
                    info.EndProcedure = DateTime.Parse(txtEndProcedure.Text);
                }
                catch (Exception)
                {
                }
                try
                {
                    if (anesRadio != "LA")
                    {
                            info.StartAnesth = DateTime.Parse(txtStartAnesth.Text);// Convert.ToDateTime("12.33");//Convert.ToDateTime(txtStartProcedure.Text);
                        // Convert.ToDateTime("12.33");//Convert.ToDateTime(txtStartProcedure.Text);
                            info.EndAnesth = DateTime.Parse(txtEndAnesth.Text);
                        // Convert.ToDateTime("12.33");//Convert.ToDateTime(txtStartProcedure.Text);
                    }
                }
                catch (Exception)
                {
                }
                
                
                info.Remark = "";
                info.NetIncome = Convert.ToDecimal(txtPriceTotal.Text);
                FormulaEngine engine = new FormulaEngine();
//                string express = "="+TxtSalePrice.Text + "-" + txtPriceTotal.Text;
                //Formula f = engine.CreateFormula(express.Replace(",",""));
                //info.Charges =Convert.ToDouble(f.Evaluate().ToString());
                info.Charges = Convert.ToDecimal(txtPriceTotal.Text.Replace(",", ""));
                info.ActuallyAmount = txtHairG.Text + "" == "" ? 0 : Convert.ToDouble(txtHairG.Text);
                //Update SurgeryFrr
                intStatus = new Business.StuffCommission().SaveSurgeryFee(info);

                    info.Tablename = "MEDICALSTUFF";
                info.MedicalStuffInfo = MedicalStuffs.ToArray();
                if (info.MedicalStuffInfo.Any())
                    intStatus = new Business.StuffCommission().UpdateMedicalStuff(info);//Update MEDICALSTUFF
                //loop ตำแหน่ง // loop แต่ละคน
              
                 if (intStatus >0)
                 {
                     MessageBox.Show(string.Format("บันทึก {0} เรียบร้อย",txtMS_Name.Text));
                     BindDataUseHistory();
                     //BindSurgeryFee();

                     //BindUcSurgicalFee(TypeCashier, 0);
                 }
                 else
                 {
                     MessageBox.Show("ขัดข้อง\n Error");
                 }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radioButtonIV_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonIV.Checked)
            {
                //Dicformura = new Dictionary<string, string>();
                //DicformuraSave = new Dictionary<string, string>();
                anesRadio = "IV";
                //if (!FirstLoad)
                //BindUcSurgicalFee("", 0);
            }
        }

        private void radioButtonGA_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonGA.Checked)
            {
              
                anesRadio = "GA";
                if (!FirstLoad)
                {
                    //Dicformura = new Dictionary<string, string>();
                    //DicformuraSave = new Dictionary<string, string>();
                    //BindUcSurgicalFee("", 0);
                }
            }
        }

        private void radioButtonLA_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLA.Checked)
            {
                //dgvData.Rows[4].ReadOnly = true;
                //dgvData.Rows[11].ReadOnly = true;
                disAbleRow = true;
                txtStartAnesth.ReadOnly = true;
                txtEndAnesth.ReadOnly = true;
                txtEndAnesth.Text = "";
                txtStartAnesth.Text = "";
                anesRadio = "LA";

                if (!FirstLoad)
                {
                    //Dicformura = new Dictionary<string, string>();
                    //DicformuraSave = new Dictionary<string, string>();
                    //BindUcSurgicalFee("", 0);
                }
            }
            else
            {
                disAbleRow = false;
                //dgvData.Rows[4].ReadOnly = false;
                //dgvData.Rows[11].ReadOnly = false;
                txtStartAnesth.ReadOnly = false;
                txtEndAnesth.ReadOnly = false;
            }
         
        
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Statics.frmSurgicalFee = null;
            //this.Close();
        }

        private void textBoxAdmit_TextChanged(object sender, EventArgs e)
        {
            if (!FirstLoad)
            {
                admit = textBoxAdmit.Text;
                //if (!FirstLoad)
                //BindUcSurgicalFee("", 0);
            }
        }

        private void dgvData_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
             e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
       }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            ManualReset = true;
            BindSurgeryFee();
            DicformuraSave = new Dictionary<string, string>();
            Dicformura = new Dictionary<string, string>();

            BindUcSurgicalFee("", 0);
            ManualReset = false;
            
        }

        private void dgvUsedTrans_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                 if (e.RowIndex!=-1)
                {
                    //UseTransID = dgvUsedTrans.Rows[e.RowIndex].Cells["Id"].Value + "";
                    if (UseTransID!="")btnSave.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

   private void dgvUsedTrans_SelectionChanged(object sender, EventArgs e)
   {
       //try
       //{
       //    if (FirstLoad) return;
       //    foreach (DataGridViewRow r in dgvUsedTrans.SelectedRows)
       //    {
       //        UseTransID = r.Cells["Id"].Value + "";

       //        DateUsed = r.Cells["Id"].Value + "" == "" ? DateTime.Now : DateTime.Parse(r.Cells["DateOfUse"].Value + ""); 
       //        dtpProdate.Value = DateUsed;
       //    }
       //    if (UseTransID != "") btnSave.Enabled = true;
           

    
          
       //    Dicformura = new Dictionary<string, string>();
       //    DicformuraSave = new Dictionary<string, string>();
       //    BindSurgeryFee();
       //    //FirstLoad = true;
       //    //if (!FirstLoad)
       //    BindUcSurgicalFee(TypeCashier, 0);
       //}
       //catch (Exception ex)
       //{
       //    MessageBox.Show(ex.Message);
       //}
   }

   private void cboExMoney_SelectedIndexChanged(object sender, EventArgs e)
   {
       //if (!FirstLoad)
       //    BindUcSurgicalFee("", 0);
       
   }

   private void dgvUsedTrans_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
   {
       var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
       e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                             e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
   }
   string oldValue = "";
   private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
   {
       try
       {
           if (dgvData.Rows.Count < 0 || dgvData.CurrentRow == null) return;
            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
            ch1 = (DataGridViewCheckBoxCell) dgvData.Rows[dgvData.CurrentRow.Index].Cells[0];
            if (dgvData.CurrentCell.ColumnIndex != 0) return;
            if (dgvData.CurrentCell.ReadOnly) return;
           
            
            if (ch1.Value == null)
                ch1.Value = false;
            switch (ch1.Value.ToString())
            {
                case "True":
                    ch1.Value = false;
                    DicCheckBox[e.RowIndex] = false;
                    break;
                case "False":
                    ch1.Value = true;
                    DicCheckBox[e.RowIndex] = true;
                    break;
            }
            if ((bool)dgvData.Rows[e.RowIndex].Cells[0].Value)
            {
                if (!FirstLoad)
                    BindUcSurgicalFee(TypeCashier, 0);
            }
            else
            {
                if (!FirstLoad)
                    BindUcSurgicalFee(TypeCashier, e.RowIndex);
            }


          

       }
       catch (Exception ex)
       {
           MessageBox.Show(ex.Message);
       }
   }

   private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
   {

   }

   private void dgvData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
   {

   }

   private void dgvData_CellPainting_1(object sender, DataGridViewCellPaintingEventArgs e)
   {
       try
       {
           if (e.ColumnIndex > -1 && e.RowIndex > -1 && dgvData.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
           {
               if (dgvData[0,e.RowIndex].ReadOnly)
               {
                   e.PaintBackground(e.CellBounds, false);
                   e.Handled = true;
               }
             //if (e.Value == null || !(bool)e.Value) {
             //    e.PaintBackground(e.CellBounds, false);
             //    e.Handled = true;
             //}
            }
       }
       catch (Exception)
       {
       }
   }

   private void dgvData_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
   {
       //try
       //{
       //    if (e.ColumnIndex > -1 && e.RowIndex > -1 && dgvData.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
       //    {
       //        if (e.Value == null || !(bool)e.Value)
       //        {
       //            e.PaintBackground(e.CellBounds, false);
       //            e.Handled = true;
       //        }
       //    }
       //}
       //catch (Exception)
       //{
       //}
   }

   private void dgvData_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
   {
       try
       {
           if (dgvData.CurrentCell.ColumnIndex == dgvData.Columns["Money"].Index)
           {
               //string[] AmountaArr = (dgvData.CurrentCell.Value + "").Split(':');
               //if (AmountaArr.Length > 1)
               //{
               //    dgvData.EndEdit();
               //    return;
               //}DisBath
               TextBox itemMoney = e.Control as TextBox;
               if (itemMoney != null)
               {
                   itemMoney.KeyPress += new KeyPressEventHandler(itemMoney_KeyPress);
               }
           }
       }
       catch (Exception ex)
       {

       }
   }
   private void itemMoney_KeyPress(object sender, KeyPressEventArgs e)
   {
       if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar!='.')
       {
           e.Handled = true;
       }
   }

   private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
   {
       try
       {
           if (dgvData.CurrentCell.ColumnIndex == dgvData.Columns["Money"].Index && DicManualValue[e.RowIndex]+""=="Y")
           {
               dgvData.Columns["Money"].ReadOnly = false;
               //string[] AmountaArr = (dgvData.CurrentCell.Value + "").Split(':');
               //if (AmountaArr.Length > 1)
               //{
               //    dgvData.EndEdit();
               //    return;
               //}DisBath
               //TextBox itemMoney = e.Control as TextBox;
               //if (itemMoney != null)
               //{
               //    itemMoney.KeyPress += new KeyPressEventHandler(itemMoney_KeyPress);
               //}
           }
           else
           {
               dgvData.Columns["Money"].ReadOnly = true;
           }
       }
       catch (Exception ex)
       {

       }
   }
   int ManualValue = 0;
   private void dgvData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
   {
       try
       {
           this.BeginInvoke(new MethodInvoker(() =>
           {
         
           if (dgvData.CurrentCell.ColumnIndex == dgvData.Columns["Money"].Index && DicManualValue[e.RowIndex] + "" == "Y")
           {
               ManualValue = e.RowIndex;
               Dicformura[e.RowIndex + ""] = dgvData["Money", e.RowIndex].Value + "" == "" ? "0" : dgvData["Money", e.RowIndex].Value + "";
               if (!FirstLoad)
               BindUcSurgicalFee(TypeCashier, 0);
               ManualValue = 0;
           }
           }));
       }
       catch (Exception)
       {
        
       }
   }

   private void txtHairG_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
   {
       //if (e.KeyCode == Keys.Return)
       //    BindUcSurgicalFee(TypeCashier, 0);
   }

   private void txtHairG_Leave(object sender, EventArgs e)
   {
       //DicformuraSave = new Dictionary<string, string>();
       //Dicformura = new Dictionary<string, string>();
     //  BindUcSurgicalFee("", 0);
   }

   private void btnPrint_Click(object sender, EventArgs e)
   {
       try
       {

           DataGridViewRow r = dgvUsedTrans.SelectedRows[0];
           string dateUsed = r.Cells["DateOfUse"].Value + "";
           string AmountUsed = r.Cells["Amount"].Value + "";
           string RefMO = r.Cells["RefMO"].Value + "";

           dgvData.Tag = string.Format("ลูกค้า {0} ({1}){2}{3} {4}{5}ใช้คอร์ส {6} จำนวน {7} RefMO {8}", lbCN_Name.Text, lbCN.Text, Environment.NewLine, lbVN.Text, txtMS_Name.Text.Replace(Environment.NewLine, " "), Environment.NewLine, dateUsed, AmountUsed, RefMO);
           PrintDGV.Print_DataGridViewJobCost(dgvData);
       }
       catch (Exception)
       {

       }
   }

   private void dgvUsedTrans_CellClick(object sender, DataGridViewCellEventArgs e)
   {
       try
       {
           if (FirstLoad) return;
           foreach (DataGridViewRow r in dgvUsedTrans.SelectedRows)
           {
               UseTransID = r.Cells["Id"].Value + "";

               DateUsed = r.Cells["Id"].Value + "" == "" ? DateTime.Now : DateTime.Parse(r.Cells["DateOfUse"].Value + "");
               dtpProdate.Value = DateUsed;
           }
           if (UseTransID != "") btnSave.Enabled = true;




           Dicformura = new Dictionary<string, string>();
           DicformuraSave = new Dictionary<string, string>();
          
           BindSurgeryFee();
           //FirstLoad = true;
           //if (!FirstLoad)
           ManualReset = true;//คลิกเปลี่ยนรายการก็โหลดใหม่
           BindUcSurgicalFee(TypeCashier, 0);
       }
       catch (Exception ex)
       {
           MessageBox.Show(ex.Message);
       }
   }

    }
}
