using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using DermasterSystem.Class;
using DermasterSystem.Data;
using WeifenLuo.WinFormsUI.Docking;
using ciloci.FormulaEngine;
using Utility = DermasterSystem.Class.Utility;
using DermasterSystem.Business;
using MedicalStuff = Entity.MedicalStuff;
using SurgeryFee = Entity.SurgeryFee;

namespace DermasterSystem.Forms
{
    public partial class FrmSurgicalFee : DockContent
    {
        private Entity.MedicalSupplies info;
        public Utility.AccessType FormType { get; set; }
        private int? intStatus;
        private int OldrowIndex = 0;
        private DataTable dataTable = null;
        private int ID = 0;
        private string MS_CodeOld = "";
        //public string VN;
        public string cn;
        private DataSet dsStuffCommission;
        private DataTable dtStuffCommission;
        private DataSet dsSurgeryFee;
        private DataTable dtSurgeryFee;
        private DataTable dtStuff=new DataTable();
        private string anesRadio = "";
        private bool disAbleRow = false;
        public string TypeCashier = "SURGERY";
        public string DoctorFee = "0";
        public string TextDetail = "";
        public string admit = "1";
        private double Amount = 0;
        private double MS_Price = 0;
        private double PharamPrice = 0;
        
        public string VN { get; set; }
        public string SUR_ID = "";
        string tmin = "0";
         DataSet ds = new DataSet();
                 DataTable dtCust = new DataTable();
                 DataTable dtSup =new DataTable();

        public List<Entity.MedicalStuff> MedicalStuffs=new List<MedicalStuff>();
        #region Enum CallMode

        private enum CallMode
        {
            Insert,
            Update,
            Preview
        }
        #endregion
        public FrmSurgicalFee()
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
            this.Closing += new CancelEventHandler(FrmSurgicalFee_Closing);
      
           
        }
     
        void FrmSurgicalFee_Closing(object sender, CancelEventArgs e)
        {
                Statics.frmSurgicalFee = null;
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
            this.Close();
        }
        private void SetColumns()
        {
            Utility.SetPropertyDgv(dgvData);
            foreach (DataGridViewColumn dgvCol in dgvData.Columns)
            {
                dgvCol.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            //dgvData.Columns.Add("Position_Name", "รายการ");
            //dgvData.Columns.Add("Com_Bath1Hr", "ชื่อผู้รับเงิน");
            //dgvData.Columns.Add("Com_Bath1Hr", "จำนวนเงิน");
            ////dgvData.Columns.Add("MS_CLPrice", "CL Price");
            ////dgvData.Columns.Add("MS_CAPrice", "CA Price");
            ////dgvData.Columns.Add("MS_CMPrice", "CM Price");
            ////dgvData.Columns.Add("MS_Unit", "Unit");

            ////dgvData.Columns["MS_code"].Visible = false;
            //dgvData.Columns["CN"].Width = 200;
            //dgvData.Columns["VN"].Width = 200;
            //dgvData.Columns["CN_NAME"].Width = 500;
           
        }

         public void BindSurgeryFee()
         {
             try
             {
                 SurgeryFee info = new SurgeryFee();
                 info.QueryType = "SELECT";
                 info.VN = VN;
                 //info.MS_Code = MS_Code;
                 dsSurgeryFee = new Business.StuffCommission().SelectSurgeryFee(info);
                dtSurgeryFee = dsSurgeryFee.Tables[0];
                foreach (DataRow dr in dtSurgeryFee.Rows)
                {
                    lbCN_Name.Text = dr["FullNameThai"] + "";
                    lbCN.Text = dr["CN"] + "";
                    lbVN.Text = dr["VN"] + "";
                    if (dr["SurgicalFeeTyp"] + "" != "")//จำนวนที่คิดค่ามือ
                    {
                        Amount = Convert.ToDouble(string.IsNullOrEmpty(dr["Amount"] + "") ? "0" : dr["Amount"] + "") + Convert.ToDouble(string.IsNullOrEmpty(dr["FreeAmount"] + "") ? "0" : dr["FreeAmount"] + "");
                         MS_Price = Convert.ToDouble(string.IsNullOrEmpty(dr["MS_Price"] + "") ? "0" : dr["MS_Price"] + "");
                        // txtMS_Name.Text = dr["MS_Name"] + "\n\r," + txtMS_Name.Text + "(" + (MS_Price + "*" + Amount) + ")";
                         txtMS_Name.Text = dr["MS_Name"] + "\n\r," + txtMS_Name.Text ;
                    }
                    anesRadio = dr["Anesthesia"] + "";
                    SUR_ID = dr["SUR_ID"] + "";
                    string ddate = "";
                    if (dr["StartProcedure"] + "" != "") txtStartProcedure.Text = String.Format("{0:t}", DateTime.Parse(dr["StartProcedure"] + "").TimeOfDay); 
                    if (dr["EndProcedure"] + "" != "") txtEndProcedure.Text = DateTime.Parse(dr["EndProcedure"] + "").TimeOfDay.ToString();
                    if (dr["StartAnesth"] + "" != "") txtStartAnesth.Text = DateTime.Parse(dr["StartAnesth"] + "").TimeOfDay.ToString();
                    if (dr["EndAnesth"] + "" != "") txtEndAnesth.Text = DateTime.Parse(dr["EndAnesth"] + "").TimeOfDay.ToString();
                    if( dr["SurgicalFeeTyp"] + ""!="")TypeCashier = dr["SurgicalFeeTyp"] + "";
                    if (dr["SurgicalFeeTyp"] + "" == "")//ค่ายา
                    {
                       double Amount2 = Convert.ToDouble(string.IsNullOrEmpty(dr["Amount"] + "") ? "0" : dr["Amount"] + "");
                       double MS_Price2 = Convert.ToDouble(string.IsNullOrEmpty(dr["MS_Price"] + "") ? "0" : dr["MS_Price"] + "");
                       PharamPrice += (MS_Price2 * Amount2);
                    }
                    
                   // MS_Price = Convert.ToDouble(string.IsNullOrEmpty(dr["MS_Price"] + "") ? "0" : dr["MS_Price"] + "");
                    textBoxAdmit.Text = dr["Admit"] + "";
                    lbGraft.Text = TypeCashier == "HAIR" ? String.Format("{0}{1} ", Amount, " Graft") : "";
                }
                 string startTime = "";
                 string endTime = "";
                 TimeSpan duration;
                 if (TypeCashier == "HAIR") anesRadio = "LA";
                switch (anesRadio)
                 {
                    case    "GA":
                            radioButtonGA.Checked = true;
                            startTime = txtStartAnesth.Text;
                            endTime = txtEndAnesth.Text;
                            duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));
                            lbAnesthTimeSpan.Text = "(" + duration.Hours.ToString() + " ชม. " + duration.Minutes + " น.)";
                            tmin = duration.TotalMinutes.ToString();
                            break;
                    case "IV":
                            radioButtonIV.Checked = true;
                            startTime = txtStartAnesth.Text;
                            endTime = txtEndAnesth.Text;
                            duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));
                            lbAnesthTimeSpan.Text = "(" + duration.Hours.ToString() + " ชม. " + duration.Minutes + " น.)";
                            tmin = duration.TotalMinutes.ToString();    
                            break;
                    case "LA":
                        radioButtonLA.Checked = true;
                        break;
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
            
         }
        Dictionary<String, String> Dicformura = new Dictionary<string, string>();
        public void BindFrmSurgicalFee(string Type)
        {
            try
            {
               Entity.MedicalOrder info;
             

                //SP=SalePrice
                //COM=rate if(hr)COM1hr,COM2hr,COM3hr
                //T=time minit
                //SUM1,SUM2
                //NET1=SP-SUM1
                //NET2=SP-SUM2+วิสัญญี

                List<double>listResult=new List<double>();
                Dictionary<string,string>dictionary=new Dictionary<string, string>();
                string SP = dtSurgeryFee.Rows[0]["NetAmount"].ToString();// "50000";
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

                hr = Math.Ceiling(Convert.ToDouble((Convert.ToDouble(tmin) / 60).ToString())).ToString();
                 dgvData.Rows.Clear();
                 FormulaEngine engine = new FormulaEngine();
                int index = 0;
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

                     Expression = item["FormulaCNT"] + "";
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
                             SP = (double.Parse(SP + "") - double.Parse(COMSILICONE)) + "";
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
                         Expression = Expression.Replace("DF", DoctorFee);
                         Expression = Expression.Replace("SILICONE", COMSILICONE);
                         Expression = Expression.Replace("AMOUNT", Amount+"");
                         
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
                         if (anesRadio == "LA" && item["DisableIF"] + "" == "LA") resultobj = "0";
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

                     if(index==2)
                     {
                         //if (lbCN.Text.Contains("CNT"))
                         //{
                         //    resultobj = "0";
                         //    //dgvData.Rows[index-1].ReadOnly = true;
                         //    //dgvData.Rows[index-1].DefaultCellStyle.ForeColor = Color.DarkGray;
                         //    //dgvData.Rows[index-1].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
                         //}
                         if (!lbCN.Text.Contains("CNA"))
                         {
                             resultobj = "0";
                         }
                     }
                   



                         if (item["MedicalStuff"] + "" == "Y" && dtStuff.Rows.Count <= 0) resultobj = "0";
                     bool haveEMP = false;
                     //หารตามจำนวนคน===========
                     int stuffCount = dtStuff.Rows.Cast<DataRow>().Count(row => item["ID"] + "" == row["Position_ID"] + "");
                     string moneyPerstuff = "";

                     if (stuffCount > 0)
                     {
                         moneyPerstuff = TypeCashier == "AESTHETIC" ? (Convert.ToDouble(resultobj) / stuffCount).ToString() : resultobj;
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
                             stuffInfo.MS_Code = row["MS_Code"] + "";
                             stuffInfo.FullNameCustomer = row["FullNameThai"] + "" == "" ? row["FullNameEng"] + "" : row["FullNameThai"] + "";
                             stuffInfo.SectionStuff = row["Position_Type"] + "";
                             stuffInfo.Com_Date=DateTime.Now;
                             stuffInfo.Com_Bath = double.Parse(moneyPerstuff);
                             MedicalStuffs.Add(stuffInfo);
                             haveEMP = true;
                         }
                        
                     }
                       if ( item["MedicalStuff"] + "" == "Y" && haveEMP == false)
                         {
                             resultobj = "0";
                         }
      #endregion
                     TextDetail = item["Position_Name"] + "";
                     if ((item["Position_Name"] + "").Contains("DF"))
                     {
                         TextDetail = TextDetail.Replace("DF", (Convert.ToDouble(DoctorFee) * 100).ToString());
                     }
                   var myItems = new[]
                                      {
                                          TextDetail,
                                          nameStuff,
                                          Math.Round(double.Parse(resultobj + "")).ToString("###,###.##")
                                      };
                     //listResult.Add(Convert.ToDouble(resultobj));
                     dictionary.Add(i.ToString(),resultobj);
                     i++;
                     dgvData.Rows.Add(myItems);

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
                         if (!lbCN.Text.Contains("CNA"))
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
                //==============================ผ่าตัด===============================
                //dgvData.Rows.Add("Sale Price (ราคาขาย)", "", "299,625.00");
                //dgvData.Rows.Add("หัก Agen (นายหน้า 20% ของ 1)", "", "");
                //dgvData.Rows.Add("หัก Commission (ถ้ามาจากAgen หัก 1% หน้าร้าน 3% ของ 1)", "", "8,988.75");
                //dgvData.Rows.Add("หักค่าน้ำ", "", "8,988.75");
                //dgvData.Rows.Add("หักค่าวิสัญญี (10% ของ 1 ไม่น้อยกว่า 6000 บาท)", "", "29,962.50");
                //dgvData.Rows.Add("หักค่าเช่าเครื่อง Body Tite/VaserTite (10% ของ(1) ไม่เกิน 10,000)", "", "48,951.25");
                //dgvData.Rows.Add("หักค่าหัว Body Tite/Vaser/VaserTite", "", "2,000.00");

                //dgvData.Rows.Add("หักค่า Silicone", "", "2,000.00");

                //dgvData.Rows.Add("รวม = (2)ถึง(9) ", "", "250,673.75");
                //dgvData.Rows.Add("ขายหลังจากหักค่านายหน้า = (1)-(9)", "", "250,673.75");

                //dgvData.Rows.Add("Surgeon(50% ของ 10)", "", "250,673.75");
                //dgvData.Rows.Add("Anesthiologist(1=4800,15min+600)", "", "250,673.75");
                //dgvData.Rows.Add("Assistant", "", "250,673.75");
                //dgvData.Rows.Add("Scrub Nurse", "", "250,673.75");
                //dgvData.Rows.Add("Scrub&Assistant", "", "250,673.75");
                //dgvData.Rows.Add("Circulate Nurse 1", "", "250,673.75");
                //dgvData.Rows.Add("Circulate Nurse 2", "", "250,673.75");
                //dgvData.Rows.Add("Circulate Nurse 3", "", "250,673.75");
                //dgvData.Rows.Add("Assistant Anesth.", "", "250,673.75");
                //dgvData.Rows.Add("Recovery Room Nurse", "", "250,673.75");
                //dgvData.Rows.Add("Special Nurse 1", "", "250,673.75");
                //dgvData.Rows.Add("Special Nurse 2", "", "250,673.75");

                //dgvData.Rows.Add("รวม (11)ถึง(22)", "", "250,673.75");

                //dgvData.Rows.Add("ขายหลังหักค่าใช้จ่ายผันแปร=(10)-(23)+(4)", "", "250,673.75");
                /////////////////////////////////End===================================

                //=========================Hair=====================================
                //dgvData.Rows.Add("Sale Price (ราคาขาย)", "", "299,625.00");
                //dgvData.Rows.Add("หัก Agen (นายหน้า 20% ของ 1)", "", "");
                //dgvData.Rows.Add("หัก Commission (ถ้ามาจากAgen หัก 1% หน้าร้าน 3% ของ 1)", "", "8,988.75");
                //dgvData.Rows.Add("หักค่าน้ำ", "", "8,988.75");
                //dgvData.Rows.Add("รวม = (2)ถึง(4) ", "", "250,673.75");

                //dgvData.Rows.Add("ขายหลังจากหักค่านายหน้า = (1)-(5)", "", "250,673.75");

                //dgvData.Rows.Add("Surgeon(43.75% ของ 6)", "", "250,673.75");
                //dgvData.Rows.Add("Scrub Nurse(50บ.)", "", "250,673.75");

                //dgvData.Rows.Add("Hair Therapist 9(1)", "", "250,673.75");
                //dgvData.Rows.Add("Hair Therapist 8(.90)", "", "250,673.75");
                //dgvData.Rows.Add("Hair Therapist 7(.90)", "", "250,673.75");
                //dgvData.Rows.Add("Hair Therapist 6(.90)", "", "250,673.75");
                //dgvData.Rows.Add("Hair Therapist 5(.90)", "", "250,673.75");
                //dgvData.Rows.Add("Hair Therapist 4(.90)", "", "250,673.75");
                //dgvData.Rows.Add("Hair Therapist 3(.90)", "", "250,673.75");
                //dgvData.Rows.Add("Hair Therapist 2(.90)", "", "250,673.75");
                //dgvData.Rows.Add("Hair Therapist 1(.90)", "", "250,673.75");

                //dgvData.Rows.Add("รวม (7)ถึง(17)", "", "250,673.75");

                //dgvData.Rows.Add("ค่าใช้จ่ายผันแปร=(6)+(18)", "", "250,673.75");
                //dgvData.Rows.Add("ขายหลังหักค่าใช้จ่ายผันแปร=(1)-(19)", "", "250,673.75");

            }
            catch (Exception ex)
            {
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeError, ex.Message);
                Utility.MouseOff(this);
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

        private void FrmSurgicalFee_Load(object sender, EventArgs e)
        {
            try
            {
                 ds = new Business.MedicalOrder().SelectMedicalOrderById(VN);
                 dtCust = ds.Tables[0];
                 dtSup = ds.Tables[1];
                 dtStuff = ds.Tables[2];
                TypeCashier = dtSup.Rows[0]["SurgicalFeeTyp"].ToString();
                 dsStuffCommission = new Business.StuffCommission().SelectStuffCommission(TypeCashier);
                 dtStuffCommission = dsStuffCommission.Tables[0];

                 DoctorFee = dtSup.Rows[0]["DoctorFee"] + "";
                BindSurgeryFee();
                BindFrmSurgicalFee(TypeCashier);
               
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

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

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
                    BindFrmSurgicalFee("");
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
                    BindFrmSurgicalFee("");
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
                    BindFrmSurgicalFee("");
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
                    BindFrmSurgicalFee("");
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
                info.QueryType = "UPDATE";
                //var idMax = UtilityBackEnd.GenMaxSeqnoValues("SUR");
                info.SUR_ID = SUR_ID;
                info.CN = lbCN.Text;
                info.VN = lbVN.Text;
               // info.MS_Code = "ODF05012";
                info.Tablename = "SURGERYFEE";
                info.Anesthesia = anesRadio;
                  string startTime = txtStartAnesth.Text;
                string endTime = txtEndAnesth.Text;
                info.ProcedureDate = dtpProdate.Value;
                info.Admit = Convert.ToInt16(string.IsNullOrEmpty(textBoxAdmit.Text) ? "0" : textBoxAdmit.Text); 

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
              
                 if (intStatus == 1)
                 {
                     MessageBox.Show("บันทึก");
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
            BindFrmSurgicalFee("");
        }

        private void radioButtonGA_CheckedChanged(object sender, EventArgs e)
        {
            anesRadio = "GA";
            BindFrmSurgicalFee("");
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
            BindFrmSurgicalFee("");
        
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Statics.frmSurgicalFee = null;
            this.Close();
        }

        private void textBoxAdmit_TextChanged(object sender, EventArgs e)
        {
            admit= textBoxAdmit.Text;
            BindFrmSurgicalFee("");
        }

        private void dgvData_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
             e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
       }

       
    }
}
