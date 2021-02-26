using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DermasterSystem.Class;
using Entity;
using ciloci.FormulaEngine;
using Utility = DermasterSystem.Class.Utility;

namespace DermasterSystem.Forms
{
    public partial class UcSurgicalFee : UserControl
    {
        private Entity.MedicalSupplies info;
        public Utility.AccessType FormType { get; set; }
        private int? intStatus;
        private int OldrowIndex = 0;
        private DataTable dataTable = null;
        private int ID = 0;
        private string MS_CodeOld = "";
        //public string VN;
        public string CN;
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
        
        public string VN { get; set; }
        public string TypeCashier { get; set; }
        private double SPdouble = 0;
        private string SP = "0";
        public string SUR_ID = "";
        string tmin = "0";
         DataSet ds = new DataSet();
                 DataTable dtCust = new DataTable();
                 DataTable dtSup =new DataTable();

        public List<Entity.MedicalStuff> MedicalStuffs=new List<MedicalStuff>();

        public DataSet DsSurgicalFee { get; set; }
        public string MS_Code { get; set; }
        public string UseTransID { get; set; }

        private bool FirstLoad = true;
        private string where;

        #region Enum CallMode

        private enum CallMode
        {
            Insert,
            Update,
            Preview
        }
        #endregion
        public UcSurgicalFee()
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
            dgvUsedTrans.Columns.Add("Amount", "จำนวนที่ใช้");
            dgvUsedTrans.Columns.Add("DateOfUse", "วันที่ใช้");
            dgvUsedTrans.Columns.Add("ProcedureDate", "คิดค่ามือ");
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
                if (!string.IsNullOrEmpty(info.VN))
                {
                   DataTable dtTmp = new Business.MedicalOrderUseTrans().SelectMedicalOrderUseTransById(info).Tables[0];
                    foreach (DataRowView item in dtTmp.DefaultView)
                    {
                        if (UseTransID=="")UseTransID = item["ID"] + "";
                        object[] myItems = {
                                               item["ID"] + "",
                                               double.Parse(item["AmountOfUse"] + "").ToString("###,###.##"),
                                               item["DateOfUse"] + "" != ""? DateTime.Parse(item["DateOfUse"] + "").Date.ToShortDateString():"",
                                               item["ProcedureDate"] + "" != ""? "Y":"N",
                                           };
                        dgvUsedTrans.Rows.Add(myItems);
                    }
                    foreach (DataGridViewRow dataRow in dgvUsedTrans.Rows)
                    {
                        dataRow.DefaultCellStyle.BackColor = dataRow.Cells["ProcedureDate"].Value+""=="N" ? Color.DarkGray : Color.Khaki;
                        
                    }
                   // UseTransID = dgvUsedTrans.Rows[0].Cells["Id"].Value + "";
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
                 dtSurgeryFee = dsSurgeryFee.Tables[0];//.Select("MergStatus='" + MS_Code + "'").CopyToDataTable(); 
                 
                 cboExMoney.DataSource = dsSurgeryFee.Tables[1];
                 cboExMoney.ValueMember = "Money";
                 cboExMoney.DisplayMember = "Money";
                 cboExMoney.SelectedIndex = 0;


                 List<string>lsMS_Name=new List<string>();
                 foreach (DataRow dr in dtSurgeryFee.Rows)
                 {
                     if (MS_Code == dr["MergStatus"] + "")
                     {
                         FeeRate = string.IsNullOrEmpty(dr["FeeRate"] + "") ? 0 : Convert.ToDouble(dr["FeeRate"] + "");
                         FeeRate2 = string.IsNullOrEmpty(dr["FeeRate2"] + "") ? 0 : Convert.ToDouble(dr["FeeRate2"] + "");
                         if (dr["ExtraMoney"] + ""!="")
                            cboExMoney.SelectedValue = dr["ExtraMoney"] + "";

                         string MS_Type = dr["MS_Type"] + "";

                          double pAF=  string.IsNullOrEmpty(dr["PriceAfterDis"] + "") ? 0 : Convert.ToDouble(dr["PriceAfterDis"] + "");
                          double pl1 = string.IsNullOrEmpty(dr["MS_CLPrice"] + "") ? 0 : Convert.ToDouble(dr["MS_CLPrice"] + "");
                          double AmountOfUse = string.IsNullOrEmpty(dr["AmountOfUse"] + "") ? 1 : Convert.ToDouble(dr["AmountOfUse"] + "");
                          if (TypeCashier == "HAIR") pl1 *= AmountOfUse;

                          //pAF = pl1 < pAF - (pAF * 0.20) ? pAF : pl1;


                          SPdouble += pAF;

                          if (SPdouble == 0)//Yai 8-5-2014   เผื่อ เป็น พวก subject  mk   gif พวกนั้น
                          {
                              // double AmountOfUse = string.IsNullOrEmpty(dr["AmountOfUse"] + "") ? 1 : Convert.ToDouble(dr["AmountOfUse"] + "");
                              MS_Price = Convert.ToDouble(string.IsNullOrEmpty(dr["MS_Price"] + "") ? "0" : dr["MS_Price"] + "");
                              if (MS_Type.ToUpper() == "C")
                              {
                                  SPdouble = MS_Price;
                                  AmountOfUse = string.IsNullOrEmpty(dr["AmountOfUse"] + "") ? 1 : Convert.ToDouble(dr["AmountOfUse"] + "");
                                  int couse = 1;
                                  couse = string.IsNullOrEmpty(dr["MS_Number_C"] + "") ? 1 : Convert.ToInt16(dr["MS_Number_C"] + "");
                                  SPdouble = (SPdouble / couse) * AmountOfUse;
                              }
                              else {
                                  SPdouble = AmountOfUse * MS_Price;
                              }
                            
                          }

                          try
                          {
                              if (MS_Type.ToUpper() == "C")
                              {
                                  AmountOfUse = string.IsNullOrEmpty(dr["AmountOfUse"] + "") ? 1 : Convert.ToDouble(dr["AmountOfUse"] + "");
                                  int couse = 1;
                                  couse = string.IsNullOrEmpty(dr["MS_Number_C"] + "") ? 1 : Convert.ToInt16(dr["MS_Number_C"] + "");
                                  SPdouble = (SPdouble / couse) * AmountOfUse;
                              }
                          }
                          catch (Exception)
                          {
                          }
                         
                 
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
                                     txtMS_Name.Text = dr["MS_Name"] + "\n\r," + txtMS_Name.Text;
                                 }
                             }
                             else txtMS_Name.Text = dr["MS_Name"] + "";
                         }
                         anesRadio = dr["Anesthesia"] + "";
                         SUR_ID = dr["SUR_ID"] + "";
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
                         lbGraft.Text = TypeCashier == "HAIR" ? String.Format("{0}{1} ", Amount, " Graft") : "";
                     }
                     //else if (dr["SurgicalFeeNewTab"] + "".ToUpper() == "N")

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
                             duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));
                             lbAnesthTimeSpan.Text = "(" + duration.Hours.ToString() + " ชม. " + duration.Minutes +
                                                     " น.)";
                             tmin = duration.TotalMinutes.ToString();
                             break;
                         case "IV":
                             radioButtonIV.Checked = true;
                             startTime = txtStartAnesth.Text;
                             endTime = txtEndAnesth.Text;
                             duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));
                             lbAnesthTimeSpan.Text = "(" + duration.Hours.ToString() + " ชม. " + duration.Minutes +
                                                     " น.)";
                             tmin = duration.TotalMinutes.ToString();
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
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
            
         }
        Dictionary<String, String> Dicformura = new Dictionary<string, string>();
        public void BindUcSurgicalFee(string Type)
        {
            try
            {
               if (DsSurgicalFee.Tables[2].Select(@where).Any())
               {
                   if (UseTransID != "") where = " UseTransId='" + this.UseTransID + "'";
                   dtStuff = DsSurgicalFee.Tables[2].Select(where).CopyToDataTable();
               }

                //SP=SalePrice
                //COM=rate if(hr)COM1hr,COM2hr,COM3hr
                //T=time minit
                //SUM1,SUM2
                //NET1=SP-SUM1
                //NET2=SP-SUM2+วิสัญญี

                List<double>listResult=new List<double>();
                Dictionary<string,string>dictionary=new Dictionary<string, string>();
                
                TxtSalePrice.Text = (double.Parse(SP + "") - PharamPrice).ToString("###,###.##");
                SP = (double.Parse(SP + "") - PharamPrice)+"";
                //=====================silicone ==========
                bool Nosilicone;
                if (string.IsNullOrEmpty(dtSup.Rows[0]["MSS_Code"] + "")) Nosilicone = true;
                string COMSILICONE;
                if (string.IsNullOrEmpty(dtSup.Rows[0]["MSS_CLPrice"] + "")) COMSILICONE = "0";
                else
                {
                    COMSILICONE = dtSup.Rows[0]["MSS_CLPrice"] + "";
                   // SP = (double.Parse(SP + "") - double.Parse(COMSILICONE)) + "";
                }
                //========================================

                String COM = "", CMHR = "";
                COMSILICONE = "";
                double COM1 = 0, COM2 = 0, COM3 = 0;
                string Expression = "";
                string hr = "1";
                double sum1 = 0;
                double sum2 = 0;
                double sum3 = 0;
                double net1 = 0;
                double net2 = 0;

                bool chksum = false;
                int i = 1;
                Nosilicone = false;
                string resultobj = "0";
                tmin = Convert.ToInt16(tmin) <= 60 ? "60" : tmin;

                //hr = Math.Ceiling(Convert.ToDouble((Convert.ToDouble(tmin) / 60).ToString())).ToString();
                if (Convert.ToDouble(tmin) <= 90)
                    hr = "1";
                else if (Convert.ToDouble(tmin) > 90 && Convert.ToDouble(tmin)<=150)
                    hr = "2";
                else if (Convert.ToDouble(tmin) > 150 && Convert.ToDouble(tmin) <= 180)
                    hr = "3";
                else 
                    hr = Math.Ceiling(Convert.ToDouble((Convert.ToDouble(tmin) / 60).ToString())).ToString();

                 dgvData.Rows.Clear();
                 FormulaEngine engine = new FormulaEngine();
                int index = 0;
                MedicalStuffs = new List<MedicalStuff>();
                 foreach (DataRowView item in dtStuffCommission.DefaultView)
                 {
                    
                     index++;
                     resultobj = "0";
                     Nosilicone = false;
                     //if(Convert.ToInt16(hr)>3)
                     COM1 = string.IsNullOrEmpty(item["Com_Bath1Hr"] + "") ? 0 : Convert.ToDouble(item["Com_Bath1Hr"] + "");
                     COM2 = string.IsNullOrEmpty(item["Com_Bath2Hr"] + "") ? 0 : Convert.ToDouble(item["Com_Bath2Hr"] + "");
                     COM3 = string.IsNullOrEmpty(item["Com_Bath3Hr"] + "") ? 0 : Convert.ToDouble(item["Com_Bath3Hr"] + "");

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
                     if (lbCN.Text.Contains("CNT") || lbCN.Text.Contains("CNM") )
                     {
                         Expression = item["FormulaCNT"] + "";
                     }
                     else if (lbCN.Text.Contains("CNA") || lbCN.Text.Contains("CNF") || lbCN.Text.Contains("CNC") || lbCN.Text.Contains("CNE"))
                     {
                         Expression = item["FormulaCNA"] + "";
                     }
                     
                     //Com_Bath1Hr=3
                     //Com_Bath2Hr=1
                     if (lbCN.Text.Contains("CNT") || lbCN.Text.Contains("CNM") || lbCN.Text.Contains("CNF"))
                     {
                         COM = item["Com_Bath1Hr"] + "";//3%
                     }
                     else if (lbCN.Text.Contains("CNA"))
                     {
                         COM = item["Com_Bath2Hr"] + "";//1%
                     }
                     //Silicone====================
                     if (Expression == "SILICONE")
                     {
                         if (string.IsNullOrEmpty(dtSup.Rows[0]["MSS_Code"] + "")) Nosilicone = true;

                         if (string.IsNullOrEmpty(dtSup.Rows[0]["MSS_CLPrice"] + ""))COMSILICONE = "0";
                         else
                         {
                             COMSILICONE = dtSup.Rows[0]["MSS_CLPrice"] + "";
                            // SP = (double.Parse(SP + "") - double.Parse(COMSILICONE)) + ""; silicone ไม่ต้องหักออกจากราคาขาย
                         }
                     }

                     //============================
                     if (Expression != "" && !Expression.Contains("SUM") && !Expression.Contains("NET"))
                     {
                         Expression = Expression.Replace("SP", SP);
                         Expression = Expression.Replace("TIME", tmin);
                         Expression = Expression.Replace("COM", COM != "" ? COM : "0");
                         Expression = Expression.Replace("CMHR", CMHR != "" ? CMHR : "0");
                         Expression = Expression.Replace("ADMI", admit != "" ? admit : "1");
                         if((dtSup.Rows[0]["MSS_Code"] + "").Contains("ADF"))
                             Expression = Expression.Replace("DF", "10000");
                         else
                             Expression = Expression.Replace("DF", DoctorFee);
                         Expression = Expression.Replace("SILICONE", COMSILICONE);
                         Expression = Expression.Replace("AMOUNT", Amount+"");
                         Expression = Expression.Replace("FEERATE", FeeRate + "");
                         Expression = Expression.Replace("FEEASIS", FeeRate2 + "");
                         
                         Expression = "=" + Expression;
                         Formula f = engine.CreateFormula(Expression);
                         resultobj = f.Evaluate().ToString();
                     }
                     if (Expression.Contains("SUM1"))
                     {
                         Expression = Expression.Replace("SUM1","");
                         string[] arr=Expression.Split('+');
                         string srt = "";
                         foreach (var s in arr)
                         {
                             sum1 +=Convert.ToDouble(dictionary[s]);
                         }
                         resultobj = sum1.ToString();

                         dgvData.Rows[i - 3].ReadOnly = true;
                         dgvData.Rows[i - 3].DefaultCellStyle.BackColor = Color.Yellow;
                         dgvData.Rows[i - 3].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
                      }
                     
                     if (Expression.Contains("NET1"))
                     {
                         Expression = Expression.Replace("NET1", "");
                         string[] arr = Expression.Split('-');
                 
                         if(arr.Length==2)
                         {
                             net1 = Convert.ToDouble(dictionary[arr[0]]) - Convert.ToDouble(dictionary[arr[1]]);
                             resultobj = net1.ToString();
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
                         
                     }
                     if (Expression.Contains("SUM2"))
                     {
                         Expression = Expression.Replace("SUM2", "");
                         string[] arr = Expression.Split('+');
                         string srt = "";
                         foreach (var s in arr)
                         {
                             sum2 += Convert.ToDouble(dictionary[s]);
                         }
                         resultobj = sum2.ToString();
                     }
                     if (Expression.Contains("SUM3"))
                     {
                         Expression = Expression.Replace("SUM3", "");
                         string[] arr = Expression.Split('+');
                         sum3 = Convert.ToDouble(dictionary[arr[0]]) + Convert.ToDouble(dictionary[arr[1]]);
                         resultobj = sum3.ToString();
                     }
                     if (Expression.Contains("NET2"))
                     {
                         Expression = Expression.Replace("NET2", "");
                         string[] arr = Expression.Split('-');

                         if (arr.Length == 2)
                         {
                             net2 = Convert.ToDouble(dictionary[arr[0]]) - Convert.ToDouble(dictionary[arr[1]]);
                             resultobj = net2.ToString();
                         }

                     }

                     if (resultobj == "") resultobj = "0";


                     //info.MedicalStuffInfo
                     Entity.MedicalStuff stuffInfo;
                     string nameStuff = "";

                     #region set zero
                         if (anesRadio == "LA" && item["DisableIF"] + "" == "LA") 
                             resultobj = "0";
                         //if ((item["DisableIF"] + "").Contains("BREAST AUGMENTATION") && txtMS_Name.Text.ToUpper().Contains("BREAST AUGMENTATION")) resultobj = "0";
                         //if (((item["DisableIF"] + "").ToUpper().Contains(txtMS_Name.Text.ToUpper())) && txtMS_Name.Text.ToUpper().Contains(item["DisableIF"] + "".ToUpper()))
                     string ss = item["DisableIF"] + "".ToUpper();
                     if (item["DisableIF"] + "" != "Body Tite VaserTite" && item["DisableIF"] + "" !="Body Tite Vaser VaserTite")
                     {
                         resultobj = resultobj;
                     }
                     else if (!txtMS_Name.Text.ToUpper().Contains("TITE"))
                         {
                             resultobj = "0";
                             //dgvData.Rows[i - 2].ReadOnly = true;
                             //dgvData.Rows[i - 2].DefaultCellStyle.ForeColor = Color.DarkGray;
                             //dgvData.Rows[i - 2].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
                         }

                     if(index==2)//ที่ไม่คิดค่า agency
                     {
                         //if (lbCN.Text.Contains("CNT"))
                         //{
                         //    resultobj = "0";
                         //    //dgvData.Rows[index-1].ReadOnly = true;
                         //    //dgvData.Rows[index-1].DefaultCellStyle.ForeColor = Color.DarkGray;
                         //    //dgvData.Rows[index-1].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
                         //}
                         //if (!lbCN.Text.Contains("CNA") && TypeCashier != "AESTHETIC" && TypeCashier != "TREATMENT")Yai20150713
                         if (!lbCN.Text.Contains("CNA") && !lbCN.Text.Contains("CNF") && TypeCashier != "AESTHETIC" && TypeCashier != "TREATMENT")
                         {
                             resultobj = "0";
                         }
                     }
                   



                         if (item["MedicalStuff"] + "" == "Y" && dtStuff.Rows.Count <= 0) 
                             resultobj = "0";
                     bool haveEMP = false;
                     //หารตามจำนวนคน===========
                     int stuffCount = dtStuff.Rows.Cast<DataRow>().Count(row => item["ID"] + "" == row["Position_ID"] + "");
                     string moneyPerstuff = "";

                     if (stuffCount > 0)
                     {
                         moneyPerstuff = TypeCashier == "AESTHETIC" || TypeCashier == "TREATMENT" ? (Convert.ToDouble(resultobj) / stuffCount).ToString() : resultobj;
                     }
                   
                     //======================
                    
                     foreach (DataRow row in dtStuff.Rows)
                     {
                         if (item["ID"] + "" == row["Position_ID"] + "")
                         {
                             nameStuff += row["FullNameThai"] + "" == "" ? row["FullNameEng"] + "" : row["FullNameThai"] + "";
                             nameStuff = nameStuff + ",";
                             stuffInfo = new MedicalStuff();
                             stuffInfo.Position_ID = row["Position_ID"] + "";
                             stuffInfo.EmployeeId = row["EmployeeId"] + "";
                             stuffInfo.MS_Code = row["MergStatus"] + "";
                             stuffInfo.FullNameCustomer = row["FullNameThai"] + "" == "" ? row["FullNameEng"] + "" : row["FullNameThai"] + "";
                             stuffInfo.SectionStuff = row["Position_Type"] + "";
                             stuffInfo.Com_Date=DateTime.Now;
                             stuffInfo.Com_Bath = double.Parse(moneyPerstuff);
                             MedicalStuffs.Add(stuffInfo);
                             haveEMP = true;
                         }
                        
                     }
                       if ( item["MedicalStuff"] + "" == "N" || item["MedicalStuff"] + "" == "Y" && haveEMP == false)
                         {
                             resultobj = "0";
                         }
      #endregion
                     TextDetail = item["Position_Name"] + "";
                     if ((item["Position_Name"] + "").Contains("DF"))
                     {
                         TextDetail = TextDetail.Replace("DF", (Convert.ToDouble(DoctorFee == "" ? "0" : DoctorFee) * 100).ToString());
                     }
                     if (double.Parse(resultobj + "") == 9999)
                     {
                         if (cboExMoney.SelectedValue+""!="")
                             resultobj = cboExMoney.SelectedValue+"";///=======================ค่าน้ำชชชชชชชชชชชช
                     }
                   var myItems = new[]
                                      {
                                         item["Checkbox"] + ""=="Y"?"True":"False",
                                          TextDetail,
                                          nameStuff,
                                          Math.Round(double.Parse(resultobj + "")).ToString("###,###.##")==""?"0":Math.Round(double.Parse(resultobj + "")).ToString("###,###.##")
                                      };
                     //listResult.Add(Convert.ToDouble(resultobj));
                     dictionary.Add(i.ToString(),resultobj);
                  
                     dgvData.Rows.Add(myItems);
                     //========================Hidden Checkbox
                     if (dgvData.Rows.Count > 0)
                     {
                         DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                         ch1 = (DataGridViewCheckBoxCell)dgvData.Rows[i-1].Cells[0];
                         //ch1.ReadOnly = item["Checkbox"] + "" != "Y";
                         dgvData.Rows[i - 1].Cells[0].ReadOnly = item["Checkbox"] + "" != "Y";
                     }
                     i++;
                     //========================
                     #region set Disable
                     //string ss = item["DisableIF"] + "".ToUpper();
                     if (item["DisableIF"] + "" != "Body Tite VaserTite" && item["DisableIF"] + "" != "Body Tite Vaser VaserTite")
                     {
                         //resultobj = resultobj;
                     }
                     else if (!txtMS_Name.Text.ToUpper().Contains("TITE"))
                     {
                         //resultobj = "0";
                         dgvData.Rows[i - 2].ReadOnly = true;
                         dgvData.Rows[i - 2].DefaultCellStyle.ForeColor = Color.DarkGray;
                         dgvData.Rows[i - 2].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
                     }


                     if (index == 2)
                     {
                         //if (lbCN.Text.Contains("CNT"))
                         //{
                         //    resultobj = "0";
                         //    dgvData.Rows[index - 1].ReadOnly = true;
                         //    dgvData.Rows[index - 1].DefaultCellStyle.ForeColor = Color.DarkGray;
                         //    dgvData.Rows[index - 1].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
                         //}
                         //if (!lbCN.Text.Contains("CNA") && TypeCashier != "AESTHETIC" && TypeCashier != "TREATMENT")//Yai20150713
                         if ((!lbCN.Text.Contains("CNA") && !lbCN.Text.Contains("CNF")) && TypeCashier != "AESTHETIC" && TypeCashier != "TREATMENT")
                         {
                             dgvData.Rows[i - 2].ReadOnly = true;
                             dgvData.Rows[i - 2].DefaultCellStyle.ForeColor = Color.DarkGray;
                             dgvData.Rows[i - 2].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
                         }


                     }


                         if (anesRadio == "LA" && item["DisableIF"] + "" == "LA" )
                         {
                             dgvData.Rows[i-2].ReadOnly=true;
                             dgvData.Rows[i-2].DefaultCellStyle.ForeColor = Color.DarkGray;
                             dgvData.Rows[i - 2].DefaultCellStyle.Font=new Font(this.Font, FontStyle.Strikeout);
                         }
                         if ((item["DisableIF"] + "").Contains("BREAST AUGMENTATION") && txtMS_Name.Text.ToUpper().Contains("BREAST AUGMENTATION"))
                         {
                             dgvData.Rows[i - 2].ReadOnly = true;
                             dgvData.Rows[i - 2].DefaultCellStyle.ForeColor = Color.DarkGray;
                             dgvData.Rows[i - 2].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
                         }
                         if (Nosilicone)
                         {
                             dgvData.Rows[i - 2].ReadOnly = true;
                             dgvData.Rows[i - 2].DefaultCellStyle.ForeColor = Color.DarkGray;
                             dgvData.Rows[i - 2].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
                         }
                     #endregion
                 }
                txtPriceTotal.Text = Math.Round(double.Parse(resultobj + "")).ToString("###,###.##");
               

            }
            catch (Exception ex)
            {
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeError, ex.Message);
                //Utility.MouseOff(this);
                return;
            }
        }
      
       
        //private void SaveMedicalSupplies()
        //{
        //    try
        //    {
        //        info = new MedicalSupplies();
                
        //        info.MS_Code = txtCode.Text;
        //        info.MS_Name = txtName.Text;
        //        info.MS_Detail = txtDetail.Text;
        //        info.MS_CLPrice = txtCLPrice.Text=="" ? 0 : Convert.ToInt32(txtCLPrice.Text);
        //        info.MS_CAPrice = txtCAPrice.Text == "" ? 0 : Convert.ToInt32(txtCAPrice.Text);
        //        info.MS_CMPrice = txtCMPrice.Text == "" ? 0 : Convert.ToInt32(txtCMPrice.Text);
        //        info.MS_Unit = cboUnit.SelectedValue.ToString();
        //        info.MS_CourseDuration =cboDuration.SelectedValue.ToString();
        //        info.MS_Unit = cboUnit.SelectedValue.ToString();
        //        info.Number_C = Convert.ToInt32(txtNC.Text);
        //        info.MS_Section = cboSection.SelectedValue.ToString();

        //        if (string.IsNullOrEmpty(cboSection.SelectedValue.ToString()))
        //        {
        //            MessageBox.Show("โปรดระบุ Section");
        //            return;
        //        }
        //        if (string.IsNullOrEmpty(info.MS_Code))
        //        {
        //            MessageBox.Show("โปรดระบุ Code");
        //            return;
        //        }
                


        //        switch (FormType)
        //        {

        //            case Utility.AccessType.Insert:
        //                if (txtCode.Text.Length < 8)
        //                {
        //                    //MessageBox.Show("โปรดระบุ Code ให้ถูกต้อง");
        //                    //return;
        //                }
        //             DataTable dt = new Business.MedicalSupplies().CheckCode(txtCode.Text).Tables[0];
        //             if (dt.Rows.Count > 0)
        //             {
        //                 MessageBox.Show("Code นี้ถูกใช้ไปแล้ว");
        //                 txtCode.Focus();
        //                 //txtCode.Text = "";
        //                 txtCode.SelectAll();
        //                 //return;
        //             }
        //             else
        //             {
        //                 info.QueryType = "INSERT";
        //                 intStatus = new Business.MedicalSupplies().InsertMedicalSupplies(ref info);
        //                 if (intStatus == 1)
        //                 {
        //                     Statics.frmMedicalSupplies.BindMedicalSupplies(1);
        //                     Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, Statics.StrMsgInsertComplete);
        //                 }
        //                 else
        //                 {
        //                     Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation,
        //                                    Statics.StrMsgCannotSave + " ข้อมูลผิดพลาด");
        //                 }
        //             }
        //                break;
        //            case Utility.AccessType.Update:
        //                info.QueryType = "UPDATE";
        //                info.ID = ID;
        //                if (MS_CodeOld != txtCode.Text.Trim())
        //                {
        //                    dt = new Business.MedicalSupplies().CheckCode(txtCode.Text).Tables[0];
        //                    if (dt.Rows.Count > 0)
        //                    {
        //                        MessageBox.Show("Code นี้ถูกใช้ไปแล้ว");
        //                        txtCode.Focus();
        //                        //txtCode.Text = "";
        //                        txtCode.SelectAll();
        //                        //return;
        //                    }
        //                }
        //                else
        //                {

        //                    intStatus = new Business.MedicalSupplies().InsertMedicalSupplies(ref info);
        //                    if (intStatus == 1)
        //                    {
        //                        BindMedicalSupplies(1);

        //                        Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, Statics.StrMsgUpdateComplete);
        //                    }
        //                    else
        //                    {
        //                        Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation,
        //                                       Statics.StrMsgCannotSave + " ข้อมูลผิดพลาด");
        //                    }
        //                    FormType = Utility.AccessType.Insert;
        //                }
        //                break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void EditMedicalSupplies()
        //{
        //    try
        //    {
        //        if (dgvData.CurrentRow.Index == -1) return;
        //        string sql = "MS_code='" + dgvData.CurrentRow.Cells["MS_code"].Value + "'";
        //        DataRow[] dataRow = dataTable.Select(sql);
        //        FormType = Utility.AccessType.Update;

        //        ID =Convert.ToInt32(dataRow[0]["ID"].ToString());
        //        cboUnit.SelectedValue = dataRow[0]["MS_Unit"].ToString();
        //        cboDuration.SelectedValue = dataRow[0]["MS_CourseDuration"].ToString();
        //        cboSection.SelectedValue = dataRow[0]["MS_Section"].ToString();
        //        txtCode.Text = MS_CodeOld = dataRow[0]["MS_code"].ToString();
        //        txtName.Text = dataRow[0]["MS_Name"].ToString();
        //        txtDetail.Text = dataRow[0]["MS_Detail"].ToString();
        //        txtCLPrice.Text = dataRow[0]["MS_CLPrice"].ToString();
        //        txtCAPrice.Text = dataRow[0]["MS_CAPrice"].ToString();
        //        txtCMPrice.Text = dataRow[0]["MS_CMPrice"].ToString();
        //        txtNC.Text = dataRow[0]["MS_Number_C"].ToString();
              

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
   

        //private void cboSection_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        txtCode.Text = cboSection.SelectedValue.ToString().Trim();
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}

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

        //private void picImport_MouseLeave(object sender, EventArgs e)
        //{
        //    picImport.Image = DermasterSystem.Properties.Resources.Import1;
        //}

        //private void picImport_MouseHover(object sender, EventArgs e)
        //{
        //    picImport.Image = DermasterSystem.Properties.Resources.Import2;
        //    toolTip1.Show("Imports Data From Excel", (Control)sender);
        //}

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
        private void UcSurgicalFee_Load(object sender, EventArgs e)
        {
            try
            {
                 //ds = new Business.MedicalOrder().SelectMedicalOrderById(VN);
                 where = "MergStatus='" + this.MS_Code + "'";
                 dtCust = DsSurgicalFee.Tables[0];
                 dtSup = DsSurgicalFee.Tables[1].Select(where).CopyToDataTable();

                 if (DsSurgicalFee.Tables[2].Select(@where).Any())
                 {
                    dtStuff = DsSurgicalFee.Tables[2].Select(where).CopyToDataTable();
                 }

                 dsStuffCommission = new Business.StuffCommission().SelectStuffCommission(TypeCashier);
                 dtStuffCommission = dsStuffCommission.Tables[0];

                 DoctorFee = dtSup.Rows[0]["DoctorFee"] + "";
                

                BindDataUseHistory();
                BindSurgeryFee();
                BindUcSurgicalFee(TypeCashier);
                FirstLoad = false;
          
                    
            }
            catch (Exception)
            {


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
                    tmin = duration.TotalMinutes.ToString();
                    BindUcSurgicalFee("");
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
                    tmin = duration.TotalMinutes.ToString();
                    BindUcSurgicalFee("");
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
                    tmin = duration.TotalMinutes.ToString();
                    BindUcSurgicalFee("");
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
                    tmin = duration.TotalMinutes.ToString();
                    BindUcSurgicalFee("");
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
                info.QueryType = "SAVE";
                //var idMax = UtilityBackEnd.GenMaxSeqnoValues("SUR");
                info.SUR_ID = SUR_ID;
                info.CN = lbCN.Text;
                info.VN = lbVN.Text;
                info.MS_Code = MS_Code;
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
                
                if (anesRadio != "LA")
                {
                    if (txtStartAnesth.Text.Length != 5 && txtEndAnesth.Text.Length != 5)
                    {
                        MessageBox.Show("โปรดระบุ เวลาที่เริ่ม และเสร็จ");
                        return;
                    }

                    if (txtEndProcedure.Text.Length != 5 && txtStartProcedure.Text.Length != 5)
                     {
                         MessageBox.Show("โปรดระบุ เวลาที่เริ่ม และเสร็จ");
                            return;
                      }
                }
                else
                {
                    if (txtStartProcedure.Text.Length != 5 && txtEndProcedure.Text.Length != 5)
                    {
                        MessageBox.Show("โปรดระบุ เวลาที่เริ่ม และเสร็จ");
                        return;
                    }
                }
               
                info.StartProcedure = DateTime.Parse(txtStartProcedure.Text); //new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,);// Convert.ToDateTime(DateTime.Now);//Convert.ToDateTime(txtStartProcedure.Text);
                info.EndProcedure = DateTime.Parse(txtEndProcedure.Text);
                
                if (anesRadio!="LA")
                {
                    info.StartAnesth = DateTime.Parse(txtStartAnesth.Text);// Convert.ToDateTime("12.33");//Convert.ToDateTime(txtStartProcedure.Text);
                        // Convert.ToDateTime("12.33");//Convert.ToDateTime(txtStartProcedure.Text);
                    info.EndAnesth = DateTime.Parse(txtEndAnesth.Text);
                        // Convert.ToDateTime("12.33");//Convert.ToDateTime(txtStartProcedure.Text);
                }
                info.Remark = "";
                info.NetIncome =Convert.ToDouble(txtPriceTotal.Text);
                FormulaEngine engine = new FormulaEngine();
                string express = "="+TxtSalePrice.Text + "-" + txtPriceTotal.Text;
                Formula f = engine.CreateFormula(express.Replace(",",""));
                info.Charges =Convert.ToDouble(f.Evaluate().ToString());
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

        private void radioButtonIV_CheckedChanged(object sender, EventArgs e)
        {
            anesRadio = "IV";
            BindUcSurgicalFee("");
        }

        private void radioButtonGA_CheckedChanged(object sender, EventArgs e)
        {
            anesRadio = "GA";
            BindUcSurgicalFee("");
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
            }
            else
            {
                disAbleRow = false;
                //dgvData.Rows[4].ReadOnly = false;
                //dgvData.Rows[11].ReadOnly = false;
                txtStartAnesth.ReadOnly = false;
                txtEndAnesth.ReadOnly = false;
            }
            BindUcSurgicalFee("");
        
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Statics.frmSurgicalFee = null;
            //this.Close();
        }

        private void textBoxAdmit_TextChanged(object sender, EventArgs e)
        {
            admit= textBoxAdmit.Text;
            BindUcSurgicalFee("");
        }

        private void dgvData_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
             e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
       }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            //Statics.frmSurgicalFeeMain = null;
            
        }

        private void dgvUsedTrans_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                 if (e.RowIndex!=-1)
                {
                    UseTransID = dgvUsedTrans.Rows[e.RowIndex].Cells["Id"].Value + "";
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
       try
       {
           foreach (DataGridViewRow r in dgvUsedTrans.SelectedRows)
           {
               UseTransID = r.Cells["Id"].Value + "";
           }
           if (UseTransID != "") btnSave.Enabled = true;
           if(FirstLoad)return;

           BindSurgeryFee();
           BindUcSurgicalFee(TypeCashier);
       }
       catch (Exception ex)
       {
           MessageBox.Show(ex.Message);
       }
   }

   private void cboExMoney_SelectedIndexChanged(object sender, EventArgs e)
   {
       if (!FirstLoad)
           BindUcSurgicalFee("");
       
   }

   private void dgvUsedTrans_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
   {
       var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
       e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                             e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
   }

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
                    break;
                case "False":
                    ch1.Value = true;
                    break;
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

    }
}
