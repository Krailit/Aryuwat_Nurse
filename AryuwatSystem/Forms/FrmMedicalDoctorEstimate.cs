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
using System.Drawing.Imaging;
using AryuwatSystem.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Runtime.InteropServices;
namespace AryuwatSystem.Forms
{
    public partial class FrmMedicalDoctorEstimate : DockContent, IForm
    {
        [DllImport("user32.dll")]
        private static extern int GetSystemMetrics(int nIndex);
        // System metric constant for Windows XP Tablet PC Edition
        private const int SM_TABLETPC = 86;
        private readonly bool tabletEnabled;
        DataTable dtList = new DataTable();
        DataTable dtListOrg = new DataTable();
        protected bool IsRunningOnTablet()
        {
            return (GetSystemMetrics(SM_TABLETPC) != 0);
        }
        public FrmMedicalDoctorEstimate()
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
        public bool FrmTypeDoctor { get; set; }
        public string VN { get; set; }
        public string SONo { get; set; }
        public string CN { get; set; }
        public string Custname { get; set; }
        string UserMS_Code = "";
        string _imagetPath = "";
        string Remote_imagetPath = "";
        string Remote_Folder = "";
        string filenameWithExt = "";
        public string Cunsult { get; set; }
        private string customerType;
        List<DataGridViewRow> rowsToDelete = new List<DataGridViewRow>();

        private void FrmMedicalDoctorEstimate_Load(object sender, System.EventArgs e)
        {
            if (FrmTypeDoctor)
            {
                this.Text = "Doctor Estimate";
                labelType.Text = "Doctor Estimate";
            }
            else
            {
                this.Text = "Customer Sign";
                labelType.Text = "Customer Sign";
            }
            SetColumnDgvSelectList();
            SetColumnDgvFile();
            BindCbocboDr();
            if (!string.IsNullOrEmpty(VN))
            {
                BindData();
            }
        }

        private void BindCbocboDr()
        {
            try
            {  DataTable dt = new Business.Personnel().SearchPersonnelByType("SELECTPERSONNEL_DOCTOR").Tables[0];
               var dr = dt.NewRow();
             
               dr["EN"] = "";
                dr["DrName"] = "";
                dt.Rows.InsertAt(dr, 0);
                cboDr.Items.Clear();
                cboDr.BeginUpdate();
                cboDr.DataSource = dt;
                cboDr.ValueMember = "EN";
                cboDr.DisplayMember = "DrName";

                cboDr.EndUpdate();
                AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                foreach (DataRow row in dt.Rows)
                {
                    if (row["DrName"] + "" == "") continue;
                    data.Add(row["DrName"] + "");
                }
                cboDr.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboDr.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cboDr.AutoCompleteCustomSource = data;
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }
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
            dataGridViewSelectList.Columns.Add("Code", "Code");//0
            dataGridViewSelectList.Columns["Code"].ReadOnly = true;

            dataGridViewSelectList.Columns.Add("Name", "ข้อมูลการซื้อ");//1
            dataGridViewSelectList.Columns["Name"].ReadOnly = true;

            dataGridViewSelectList.Columns.Add("Amount", "Quantity");//2
            dataGridViewSelectList.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["Amount"].DefaultCellStyle.BackColor = Color.LemonChiffon;
            dataGridViewSelectList.Columns["Amount"].Width = 30;
            dataGridViewSelectList.Columns["Amount"].ReadOnly = true;

            dataGridViewSelectList.Columns.Add("No./Course", "No./Course");//3
            dataGridViewSelectList.Columns["No./Course"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["No./Course"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewSelectList.Columns["No./Course"].ReadOnly = true;

            dataGridViewSelectList.Columns.Add("Total", "Total");//4
            dataGridViewSelectList.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvHairSelect.Columns["Total"].DefaultCellStyle.BackColor = Color.Black;
            dataGridViewSelectList.Columns["Total"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewSelectList.Columns["Total"].ReadOnly = true;

            dataGridViewSelectList.Columns.Add("Used", "Used");//5
            dataGridViewSelectList.Columns["Used"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvHairSelect.Columns["Used"].DefaultCellStyle.BackColor = Color.Black;
            dataGridViewSelectList.Columns["Used"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewSelectList.Columns["Used"].ReadOnly = true;

            dataGridViewSelectList.Columns.Add("Balance", "Balance");//6
            dataGridViewSelectList.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvHairSelect.Columns["Balance"].DefaultCellStyle.BackColor = Color.Black;
            dataGridViewSelectList.Columns["Balance"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewSelectList.Columns["Balance"].ReadOnly = true;

            dataGridViewSelectList.Columns.Add("Price/Unit", "Price/Unit");//7
            dataGridViewSelectList.Columns["Price/Unit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["Price/Unit"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewSelectList.Columns["Price/Unit"].ReadOnly = true;

            dataGridViewSelectList.Columns.Add("SpecialPrice", "SpecialPrice");//8
            dataGridViewSelectList.Columns["SpecialPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["SpecialPrice"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewSelectList.Columns["SpecialPrice"].ReadOnly = true;

            dataGridViewSelectList.Columns.Add("PriceTotal", "PriceTotal");//8
            dataGridViewSelectList.Columns["PriceTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["PriceTotal"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewSelectList.Columns["PriceTotal"].ReadOnly = true;

            dataGridViewSelectList.Columns.Add("Other", "Other");
            dataGridViewSelectList.Columns["Other"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["Other"].DefaultCellStyle.BackColor = Color.LemonChiffon;
            dataGridViewSelectList.Columns["Other"].Visible = false;

            dataGridViewSelectList.Columns.Add("ExpireDate", "Expire Date");
            dataGridViewSelectList.Columns["ExpireDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["ExpireDate"].DefaultCellStyle.BackColor = Color.LemonChiffon;
            dataGridViewSelectList.Columns["ExpireDate"].ReadOnly = true;
            DataGridViewImageColumn ColUse = new DataGridViewImageColumn();
            {
                ColUse.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                ColUse.CellTemplate = new DataGridViewImageCell();
                ColUse.Name = "BtnUse";
                ColUse.HeaderText = "Course(Record)";
            }
            dataGridViewSelectList.Columns.Add(ColUse);
         
            DataGridViewCheckBoxColumn colChkComp = new DataGridViewCheckBoxColumn();
            {
                colChkComp.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                colChkComp.FlatStyle = FlatStyle.Standard;
                colChkComp.ThreeState = false;
                colChkComp.Name = "ChkCom";
                colChkComp.HeaderText = "Comp.";
                colChkComp.CellTemplate = new DataGridViewCheckBoxCell();
                colChkComp.ReadOnly = true;
            }
            dataGridViewSelectList.Columns.Add(colChkComp);

            DataGridViewCheckBoxColumn colChkMar = new DataGridViewCheckBoxColumn();
            {
                colChkMar.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                colChkMar.FlatStyle = FlatStyle.Standard;
                colChkMar.ThreeState = false;
                colChkMar.Name = "ChkMar";
                colChkMar.HeaderText = "M.Budget";
                colChkMar.CellTemplate = new DataGridViewCheckBoxCell();
                colChkMar.ReadOnly = true;
            }
            dataGridViewSelectList.Columns.Add(colChkMar);

            DataGridViewCheckBoxColumn colChkGiftv = new DataGridViewCheckBoxColumn();
            {
                colChkGiftv.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                colChkGiftv.FlatStyle = FlatStyle.Standard;
                colChkGiftv.ThreeState = false;
                colChkGiftv.Name = "ChkGiftv";
                colChkGiftv.HeaderText = "Gift V.";
                colChkGiftv.CellTemplate = new DataGridViewCheckBoxCell();
                colChkGiftv.ReadOnly = true;
            }
            dataGridViewSelectList.Columns.Add(colChkGiftv);
            DataGridViewCheckBoxColumn colChkSub = new DataGridViewCheckBoxColumn();
            {
                colChkSub.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                colChkSub.FlatStyle = FlatStyle.Standard;
                colChkSub.ThreeState = false;
                colChkSub.Name = "ChkSub";
                colChkSub.HeaderText = "Subject";
                colChkSub.CellTemplate = new DataGridViewCheckBoxCell();
                colChkSub.ReadOnly = true;
            }
            dataGridViewSelectList.Columns.Add(colChkSub);
            dataGridViewSelectList.Columns.Add("Tab", "Tab");
            dataGridViewSelectList.Columns["Tab"].ReadOnly = true;

          
            dataGridViewSelectList.Columns.Add("ListOrder", "ListOrder");
            dataGridViewSelectList.Columns.Add("FeeRate", "FeeRate");
            dataGridViewSelectList.Columns["FeeRate"].Visible = false;
            dataGridViewSelectList.Columns.Add("FeeRate2", "FeeRate2");
            dataGridViewSelectList.Columns["FeeRate2"].Visible = false;

        }
        private void SetColumnDgvFile()
        {
            dgvFile.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dgvFile_RowPostPaint);
            DerUtility.SetPropertyDgv(dgvFile);

            dgvFile.Columns.Add("FilePath", "FilePath");
            dgvFile.Columns.Add("FileName", "ชื่อไฟล์");
            dgvFile.Columns.Add("Detail", "รายละเอียด");
            dgvFile.Columns.Add("DateScan", "วันที่");
            dgvFile.Columns.Add("DoctorName", "Doctor");
            DataGridViewImageColumn colFileDel = new DataGridViewImageColumn();
            {
                colFileDel.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                colFileDel.CellTemplate = new DataGridViewImageCell();
                colFileDel.Name = "del";
            }
            dgvFile.Columns.Add(colFileDel);
            DataGridViewImageColumn colDownOpen = new DataGridViewImageColumn();
            {
                colDownOpen.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                colDownOpen.CellTemplate = new DataGridViewImageCell();
                colDownOpen.Name = "Open";
            }

            dgvFile.Columns.Add(colDownOpen);
            dgvFile.Columns.Add("NewRow", "NewRow");
            dgvFile.Columns.Add("Id", "Id");
            //dgvFile.Columns.Add("ENSave", "ENSave");
            
            

            dgvFile.Columns["Open"].Width = 100;
            dgvFile.Columns["FilePath"].Width = 500;
            dgvFile.Columns["Detail"].Width = 150;
            dgvFile.Columns["del"].Width = 100;
            dgvFile.Columns["FilePath"].Visible = false;
            //dgvFile.Columns["Detail"].Visible = false;
            dgvFile.Columns["Id"].Visible = false;
            dgvFile.Columns["NewRow"].Visible = false;
            if (IsRunningOnTablet())
            {
                dgvFile.RowTemplate.Height = 50;
            }
        }
        private void dataGridViewSelectList_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Can potentially throw an 'IndexOutOfRangeException' if not checked.4.    
            try
            {
                if (e.RowIndex>=0 && e.ColumnIndex >=0 && (e.ColumnIndex == dataGridViewSelectList.Columns["BtnUse"].Index))
                {
                    if (dataGridViewSelectList["Tab", e.RowIndex].Value + "" == "PHARMACY")
                    {
                        //dataGridViewSelectList.Columns["BtnUse"].Visible = false;
                        Cursor = Cursors.Default;
                    }
                    else
                    {
                        //dataGridViewSelectList.Columns["BtnUse"].Visible = true;
                        this.Cursor = Cursors.Hand;
                    }
                }
                else { Cursor = Cursors.Default; }
            }
            catch (Exception)
            {
                
            }
           
        }

        public void BindData()
        {
            try
            {
                Entity.MedicalOrder info;
                dataGridViewSelectList.Rows.Clear();
                DataSet ds = new Business.MedicalOrder().SelectMedicalOrderById(VN,SONo);
                DataTable dtCust = ds.Tables[0];
                DataTable dtSup = ds.Tables[1];
                DataTable dtStuff = ds.Tables[2];
                DataTable dtDoc = ds.Tables[3];
                //CN = dtCust.Rows[0]["CN"] + "";
                customerType = dtCust.Rows[0]["CustomerType"] + "";
                labelCustomer.Text = string.Format("{0}/{1}",CN,Custname);
                //txtCustomerName.Text =dtCust.Rows[0]["FullNameThai"] + "" == "" ? dtCust.Rows[0]["FullNameEng"] + "" : dtCust.Rows[0]["FullNameThai"] + "";
                //labelCN.Text = dtCust.Rows[0]["CN"] + "";
                lbMO.Text = VN;
                //DataTable dtSupGroup = GroupByMultiple("MergStatus", dtSup); // Group Layer
                //foreach (DataRow rw in dtSupGroup.Rows)
                //{
                //    string expression = "MergStatus ='" + rw["MergStatus"] + "'";
                List<DataRow> lsPrint = new List<DataRow>();
                    foreach (DataRow dr in dtSup.Rows)
                    {
                        string[] ms_code = (dr["MergStatus"] + "").Split(':');
                        if ((dr["MS_Code"] + "").Contains("PRO_CREDIT")) continue;
                        
                            double dblTotal = (dr["Amount"] + ""==""?1:double.Parse(dr["Amount"] + "") *(dr["MS_Number_C"] + ""==""?1: double.Parse(dr["MS_Number_C"] + "")));
                            double dblCL = dr["MS_CLPrice"] + "" == "" ? 0 : double.Parse(dr["MS_CLPrice"] + "");
                            double dblCA = dr["MS_CAPrice"] + "" == "" ? 0 : double.Parse(dr["MS_CAPrice"] + "");
                            double pricePerUnit = dtCust.Rows[0]["CustomerType"] + "" == "CNT" || dtCust.Rows[0]["CustomerType"] + "" == "CNM" ? dblCL : dblCA;
                            double SpecialPrice=dr["SpecialPrice"] + "" == "" ? 0 : double.Parse(dr["SpecialPrice"] + "");
                            object[] myItems = {
                                              false,
                                               dr["MS_Code"] + "",
                                               dr["MS_Name"] + "",
                                               dr["Amount"] + "",
                                               dr["MS_Number_C"] + "",
                                               dblTotal.ToString("###,###.##"),
                                               //dr["NumOfUse"] + "",
                                                (dr["AmountOfUse"] + "" ==""?0: double.Parse(dr["AmountOfUse"] + "")).ToString("###,##0.##"),
                                               (dblTotal -(dr["AmountOfUse"] + "" ==""?0: double.Parse(dr["AmountOfUse"] + ""))).ToString("###,##0.##"),
                                               pricePerUnit.ToString("###,###.##"),
                                               SpecialPrice.ToString("###,###,###.##"),
                                               ((double.Parse(dr["Amount"] + "")*pricePerUnit)+(SpecialPrice)).ToString("###,###,###.##"),
                                               dr["FreeAmount"] + "",
                                               dr["ExpireDate"] + ""==""?"":Convert.ToDateTime(dr["ExpireDate"] + "").ToString("yyyy/MM/dd"),//.ToString("yyyy-MM-dd"),
                                               dr["SurgicalFeeTyp"] + ""=="PHARMACY"?new Bitmap(1, 1):imageList1.Images[4],
                                               
                                               dr["Complimentary"] + "" == "Y" ? true : false,
                                               dr["MarketingBudget"] + "" == "Y" ? true : false,
                                               dr["Gift"] + "" == "Y" ? true : false,
                                               dr["Subject"] + "" == "Y" ? true : false,
                                               dr["SurgicalFeeTyp"] + "",
                                               
                                               dr["ListOrder"] + "",
                                                   dr["FeeRate"] + "",
                                                   dr["FeeRate2"] + ""
                                           };
                        
                            dataGridViewSelectList.Rows.Add(myItems);

                            if (dr["SurgicalFeeTyp"] + ""=="" && dblTotal - (dr["AmountOfUse"] + "" == "" ? 0 : double.Parse(dr["AmountOfUse"] + ""))>0)
                                lsPrint.Add(dr);
                        }
                        //break;
                    //}
                //}
                dataGridViewSelectList.ClearSelection();


                try
                {
                    //SetColumnDgvFile();
                    if(FrmTypeDoctor)
                        ds = new Business.MedicalOrder().SelectFileScan(SONo, VN, CN, "SelectFileScanDoctor");
                    else
                        ds = new Business.MedicalOrder().SelectFileScan(SONo, VN, CN, "SelectFileScanCustomer");
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        object[] myItems = {
                                      "",
                                      row["FileName"]+"",
                                      row["Detail"]+"",
                                      //Convert.ToDateTime(row["DateScan"]+"").ToString("yyyy-MM-dd"),
                                      String.Format("{0:g}", Convert.ToDateTime(row["DateScan"]+"")),
                                      row["DoctorName"]+"",
                                      
                                      imageList1.Images[2],
                                      imageList1.Images[1],
                                      "False",
                                      row["Id"]+""
                                   };
                        dgvFile.Rows.Add(myItems);
                    }
                    dgvFile.ClearSelection();
                    dgvFile.RowsDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
                    for (int i = 0; i < dgvFile.Columns.Count - 1; i++)
                    {
                        dgvFile.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    }
                    //dataGridView1.Columns[dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    
                    for (int i = 0; i < dgvFile.Columns.Count; i++)
                    {
                        int colw = dgvFile.Columns[i].Width;
                        dgvFile.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        dgvFile.Columns[i].Width = colw;
                    }
                    dgvFile.Columns["Open"].Width = 100;
                }
                catch (Exception)
                {

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dgvFile_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }
       
        private void dataGridViewSelectList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //     string ms_code = dataGridViewSelectList.Rows[e.RowIndex].Cells["Code"].Value + "";
            //     string ListOrder = dataGridViewSelectList.Rows[e.RowIndex].Cells["ListOrder"].Value + "";


            //     BindDataUsed(ms_code, ListOrder);
            //}
            //catch (Exception ex)
            //{
              
            //}
        }
        private bool IsExpireDate(string str)
        {
            bool IsExpire = false;
            try
            {
                IsExpire = DateTime.Now > (str == "" ? DateTime.Now : Convert.ToDateTime(str));
            }
            catch (Exception)
            {
                
                
            }
            return IsExpire;
        }
        private void BindDataUsed(string MS_Code, string ListOrder)
        {
            try
            {
                DerUtility.MouseOn(this);
                dgvFile.Rows.Clear();
                Entity.MedicalOrderUseTrans info = new Entity.MedicalOrderUseTrans();
                info.CN = CN;
                info.VN = VN;
                info.MS_Code = UserMS_Code=MS_Code;
                info.ListOrder = ListOrder;
                DataTable dtTmp;
                if (!string.IsNullOrEmpty(info.VN))
                {
                    dtTmp = new Business.MedicalOrderUseTrans().SelectMedicalOrderUseTransById(info).Tables[0];
                    foreach (DataRowView item in dtTmp.DefaultView)
                    {
                        double AmountU = Convert.ToDouble(string.IsNullOrEmpty(item["AmountOfUse"] + "") ? "1" : item["AmountOfUse"] + "".Replace(",", ""));
                        object[] myItems = {
                                               item["ID"] + "",
                                               AmountU.ToString("###,###,##0.##"),
                                               item["DateOfUse"] + "" != ""? DateTime.Parse(item["DateOfUse"] + "").Date.ToShortDateString():"",
                                               item["CN_USED"]+"",
                                               item["FullNameThai"]+"" != ""?item["FullNameThai"]+"":item["FullNameEng"]+"",
                                               item["CO"]+"",
                                               item["RefMO"]+"",
                                               imageList1.Images[2],
                                               imageList1.Images[3],
                                               item["BranchName"]+"",
                                               imageList1.Images[6],
                                               imageList1.Images[7],
                                               item["Remark"]+"",
                                               
                                           };
                        dgvFile.Rows.Add(myItems);
                    }
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
        public DataTable GroupByMultiple(string i_sGroupByColumn, DataTable dataSource)
        {
            var dv = new DataView(dataSource);
            //getting distinct values for group column
            dv.Sort = i_sGroupByColumn + " ASC";
            DataTable dtGroup = dv.ToTable(true, new[] { i_sGroupByColumn });
            return dtGroup;
        }

   

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Statics.frmMedicalOrderList.BindDataMedicalOrder(1);
            this.Close();
        }

        private void dataGridViewSelectList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        private void dgvUsedTrans_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        private void btnPrintList_Click(object sender, EventArgs e)
        {
            try
            {
                //Create a new bitmap.
                var bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                               Screen.PrimaryScreen.Bounds.Height,
                                               PixelFormat.Format32bppArgb);

                // Create a graphics object from the bitmap.
                var gfxScreenshot = Graphics.FromImage(bmpScreenshot);

                // Take the screenshot from the upper left corner to the right bottom corner.
                gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                            Screen.PrimaryScreen.Bounds.Y,
                                            0,
                                            0,
                                            Screen.PrimaryScreen.Bounds.Size,
                                            CopyPixelOperation.SourceCopy);

                // Save the screenshot to the specified path that the user has chosen.
                bmpScreenshot.Save("Screenshot.png", ImageFormat.Png);
            }
            catch (Exception)
            {
                
               
            }
        }

   

        private void dgvUsedTrans_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && (e.ColumnIndex == dgvFile.Columns["btnLicence"].Index))
                {
                    if (dgvFile["Tab", e.RowIndex].Value + "" == "PHARMACY")
                    {
                        //dataGridViewSelectList.Columns["BtnUse"].Visible = false;
                        Cursor = Cursors.Default;
                    }
                    else
                    {
                        //dataGridViewSelectList.Columns["BtnUse"].Visible = true;
                        this.Cursor = Cursors.Hand;
                    }
                }
                else { Cursor = Cursors.Default; }
            }
            catch (Exception)
            {

            }
        }

   

        private void btnAddFile_BtnClick()
        {
                try
                {
                    if (txtFilePath.Text != "")
                    {
                        object[] myItems = {
                                       txtFilePath.Text,
                                       Path.GetFileName(txtFilePath.Text),
                                        txtFileName.Text.Length<5?"File Scan":txtFileName.Text,
                                       String.Format("{0:g}", dateTimePickerCreate.Value),
                                       imageList1.Images[2],
                                       imageList1.Images[1],
                                    
                                       "True"
                                   };
                        dgvFile.Rows.Insert(0, myItems);
                        txtFilePath.Text = "";
                        txtFileName.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
         
        }

        private void pictureBoxAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboDr.SelectedText.Length < 5)
                {
                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, "Please Select Dr.");
                    return;
                }
                string NewFileFullPath = "";
                if (FrmTypeDoctor) NewFileFullPath = CreateNewPDFBoardDoctor();
                else NewFileFullPath = CreateNewPDFBoardCustomer();

                object[] myItems = {
                                       NewFileFullPath,
                                       Path.GetFileName(NewFileFullPath),
                                       "New Paper",
                                       String.Format("{0:g}", dateTimePickerCreate.Value),
                                       cboDr.SelectedValue,
                                       imageList1.Images[2],
                                       imageList1.Images[1],
                                       //imageList1.Images[9],
                                       //imageList1.Images[5],
                                       "True"
                                   };
                dgvFile.Rows.Insert(0,myItems);
                txtFilePath.Text = "";
                txtFileName.Text = "";
                dgvFile.ClearSelection();
                dgvFile.RowsDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
                for (int i = 0; i < dgvFile.Columns.Count - 1; i++)
                {
                    dgvFile.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }
                //dataGridView1.Columns[dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                for (int i = 0; i < dgvFile.Columns.Count; i++)
                {
                    int colw = dgvFile.Columns[i].Width;
                    dgvFile.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvFile.Columns[i].Width = colw;
                }
                dgvFile.Columns["Open"].Width = 100;
                if (File.Exists(NewFileFullPath))
                {
                    Process.Start(NewFileFullPath);//.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBoxSave_Click(object sender, EventArgs e)
        {
            SaveFileScan();
        }

        private void btnAddFile_Load(object sender, EventArgs e)
        {
            
        }

        private void dgvFile_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 5)
                {
                    if (DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirm, "ยืนยันการลบไฟล์ \"Confirm delete.\"") == DialogResult.OK)
                    {
                        string FileName = dgvFile.Rows[e.RowIndex].Cells["FileName"].Value + "";
                        string Id = dgvFile.Rows[e.RowIndex].Cells["Id"].Value + "";
                        //string fnameFullFath = Properties.Settings.Default.ImagePathServer + "\\MEDICALDOC\\" +
                        //                       dgvFile.Rows[e.RowIndex].Cells["FileName"].Value + "";
                        DeleteFileFTP(FileName);
                        //BrowseFile.Deletefile(fnameFullFath);
                        var intStatus=new object();
                         if (FrmTypeDoctor)
                             intStatus = new Business.MedicalOrder().DeleteFileScan(Id, "DELETEFileScanDoctor");
                         else
                             intStatus = new Business.MedicalOrder().DeleteFileScan(Id, "DELETEFileScanCustomer");

                        dgvFile.Rows.RemoveAt(e.RowIndex);
                    }
                }
                if (e.ColumnIndex == 6)
                {

                    //string filePath _imagetPath= Properties.Settings.Default.ImagePathServer + "\\MEDICALDOC\\" + dgvFile.Rows[e.RowIndex].Cells["FileName"].Value + "";
                    DownLoadImage(dgvFile.Rows[e.RowIndex].Cells["FileName"].Value + "");
                    dgvFile.Rows[e.RowIndex].Cells["NewRow"].Value = "True";
                    dgvFile.Rows[e.RowIndex].Cells["FilePath"].Value = _imagetPath;
                    dgvFile.Rows[e.RowIndex].Cells["Detail"].Value = "UPDATE";
                    
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void DeleteFileFTP(string keyIDFileNameWithExt)
        {
            try
            {
                //if (_OrgimagePaht == "") return;
                string Remote_imagetPath = "";
                Remote_imagetPath = string.Format(@"\MEDICALDOC\{0}\{1}\{2}", CN, "FileScanCourse", keyIDFileNameWithExt);
                //string Remote_Folder = string.Format(@"\MEDICALDOC\{0}\", CN);

                /* Create Object Instance */
                DermasterFtp ftpClient = new DermasterFtp(Entity.Userinfo.Server, Entity.Userinfo.ServerUser, Entity.Userinfo.ServerPass);

                ftpClient.delete(Remote_imagetPath);

                ftpClient = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DownLoadImage(string fileWithExt)
        {
            try
            {
                //string Remote_imagetPath = "";
                //Remote_imagetPath = string.Format(@"\MEDICALDOC\{0}\{1}\{2}", CN, "FileScanCourse", keyIDFileNameWithExt);
                //string Remote_Folder = string.Format(@"\MEDICALDOC\{0}\{1}", CN, "FileScanCourse");
                filenameWithExt = fileWithExt;
                _imagetPath = string.Format(@"{0}\{1}\{2}\{3}", Application.StartupPath, "MEDICALDOC", CN, filenameWithExt);
                Remote_imagetPath = string.Format(@"\MEDICALDOC\{0}\{1}\{2}", CN, "FileScanCourse", filenameWithExt);
                Remote_Folder = string.Format(@"\MEDICALDOC\{0}\{1}\", CN, "FileScanCourse");
                /* Create Object Instance */
                string Local_Folder = string.Format(@"{0}\MEDICALDOC\{1}\", Application.StartupPath, CN);
                DirectoryInfo df = new DirectoryInfo(Local_Folder);
                if (!df.Exists)
                    df.Create();

                DermasterFtp ftpClient = new DermasterFtp(Entity.Userinfo.Server, Entity.Userinfo.ServerUser, Entity.Userinfo.ServerPass);

                ftpClient.download(Remote_imagetPath, _imagetPath);

                ftpClient = null;
                if (File.Exists(_imagetPath))
                {
                    Process.Start(_imagetPath);//.WaitForExit();
                }
                else MessageBox.Show("File not found.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SaveFileScan()
        {
            try
            {

         
            Entity.MedicalOrderDoc medDocInfo;
            int run = 0;
            List<Entity.MedicalOrderDoc> listMedicalOrderDoc = new List<Entity.MedicalOrderDoc>();
            string idMaxFile="";
                if(FrmTypeDoctor)
                     idMaxFile = UtilityBackEnd.GenMaxSeqnoValuesFileScan("FILEDOCTOR", SONo, VN, CN);
                else
                     idMaxFile = UtilityBackEnd.GenMaxSeqnoValuesFileScan("FILECUST", SONo, VN, CN);

            foreach (DataGridViewRow item in dgvFile.Rows)
            {
                if (item.Cells["NewRow"].Value + "" == "True")
                {

                    medDocInfo = new Entity.MedicalOrderDoc();
                    medDocInfo.FileName = item.Cells["FileName"].Value + "";

                    FileInfo fn = new FileInfo(item.Cells["FilePath"].Value + "");
            
                     string KeyFileName="";

                     if (item.Cells["Detail"].Value + "" == "UPDATE")
                         KeyFileName = item.Cells["FileName"].Value + "";
                     else
                     {
                         if (idMaxFile == "") run = 0;
                         else
                         {
                             int re = idMaxFile.Length - idMaxFile.IndexOf('.');
                             idMaxFile = idMaxFile.Remove(idMaxFile.IndexOf('.'), re);
                             if (FrmTypeDoctor)
                                run = Convert.ToInt16(idMaxFile.Replace(string.Format("FILEDOCTOR_{0}_", VN), ""));
                             else
                                run = Convert.ToInt16(idMaxFile.Replace(string.Format("FILECUST_{0}_", VN), ""));
                         }
                         run++;
                         if (FrmTypeDoctor)
                            KeyFileName = string.Format("FILEDOCTOR_{0}_{1}{2}", VN, run, fn.Extension);
                         else
                             KeyFileName = string.Format("FILECUST_{0}_{1}{2}", VN, run, fn.Extension);

                     }

                    medDocInfo.FileName = KeyFileName;// +"_" + DateTime.Now.ToString("yyyyMMddHH");

                    if (FrmTypeDoctor)
                        medDocInfo.QueryType = "INSERTFileScanDoctor";
                    else
                        medDocInfo.QueryType = "INSERTFileScanCustomer";

                    medDocInfo.UseTransId = "";
                    medDocInfo.Sono =SONo;
                    medDocInfo.VN = VN;
                    medDocInfo.CN = CN;
                    medDocInfo.ENDoctor = item.Cells["DoctorName"].Value + "";
                    medDocInfo.ENSave = Userinfo.EN;
                    
                    medDocInfo.FilePath = item.Cells["FilePath"].Value + "";
                    medDocInfo.Detail = item.Cells["Detail"].Value + "";
                    medDocInfo.DateScan = DateTime.Now;
                    listMedicalOrderDoc.Add(medDocInfo);
                }
            }

            

            int? intStatus = new Business.MedicalOrder().InsertFileScan(listMedicalOrderDoc);

            foreach (Entity.MedicalOrderDoc medicalOrderDoc in listMedicalOrderDoc)
            {
                SaveImage(medicalOrderDoc.FileName, medicalOrderDoc.FilePath);
                
            }
            DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "บันทึกข้อมูลเรียบร้อยแล้ว");
            this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SaveImage(string keyIDFileNameWithExt, string _OrgimagePaht)
        {
            try
            {
                if (_OrgimagePaht == "") return;
                string Remote_imagetPath = "";
                Remote_imagetPath = string.Format(@"\MEDICALDOC\{0}\{1}\{2}", CN, "FileScanCourse", keyIDFileNameWithExt);
                string Remote_Folder = string.Format(@"\MEDICALDOC\{0}\{1}", CN, "FileScanCourse");

                /* Create Object Instance */
                DermasterFtp ftpClient = new DermasterFtp(Entity.Userinfo.Server, Entity.Userinfo.ServerUser, Entity.Userinfo.ServerPass);
                if (ftpClient.directoryListSimple(Remote_Folder).Length <= 1)
                    ftpClient.createDirectory(Remote_Folder);
                /* Upload a File */
                ftpClient.upload(Remote_imagetPath, _OrgimagePaht);
                //FileInfo f = new FileInfo(_imagetPath);
                //if (!f.Exists)
                /* Download a File */
                //ftpClient.download(Remote_imagetPath, _OrgimagePaht);

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
        public string CreateNewPDFBoardDoctor()
        {
            //string appRootDir = Application.StartupPath;
            string Local_Folder = string.Format(@"{0}\MEDICALDOC\{1}\", Application.StartupPath, CN);
            string FullPath = Local_Folder + "/NewPaper1.pdf";
            try
            {
                // Step 1: Creating System.IO.FileStream object

                if (!Directory.Exists(Local_Folder)) Directory.CreateDirectory(Local_Folder);
                if (File.Exists(FullPath)) File.Delete(FullPath);

                using (FileStream fs = new FileStream(FullPath, FileMode.Create, FileAccess.Write, FileShare.None))
                // Step 2: Creating iTextSharp.text.Document object  Document doc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
                using (Document doc = new Document())//PageSize.A4, 0f, 10f, 100f, 0f
                // Step 3: Creating iTextSharp.text.pdf.PdfWriter object
                // It helps to write the Document to the Specified FileStream
                using (PdfWriter writer = PdfWriter.GetInstance(doc, fs))
                {
                    // Step 4: Openning the Document
                    doc.Open();
                    
                    // Step 5: Adding a paragraph
                    // NOTE: When we want to insert text, then we've to do it through creating paragraph

                    //Add  iMage Background
                    string imageURL = string.Format("{0}/bgSaleCheck.jpg", Application.StartupPath);
                    iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);
                    //Resize image depend upon your need
                    jpg.ScaleToFit(doc.PageSize);
                    //Give space before image
                    jpg.SpacingBefore = 10f;
                    //Give some space after the image
                    jpg.SpacingAfter = 0f;
                    //jpg.Alignment = Element.ALIGN_LEFT;
                    jpg.Alignment = iTextSharp.text.Image.UNDERLYING;

                    //If you want to give absolute/specified fix position to image.
                    jpg.SetAbsolutePosition(0, 0);

                    doc.Add(jpg);
 
                    //=====================

                    BaseFont bf = BaseFont.CreateFont(Application.StartupPath + "/THSarabunNew Bold.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    //Font font  = new Font(bf, 30);
                    iTextSharp.text.Font font=new iTextSharp.text.Font(bf, 18);
                    PdfContentByte cb = writer.DirectContent;
                    Paragraph paragraph;// = new Paragraph(cboDr.SelectedText, font);//dr
                    paragraph = new Paragraph(string.Format("ชื่อลูกค้า {0} ({1})",Custname,CN), font);
                    doc.Add(paragraph);
                    paragraph = new Paragraph(string.Format("{0}   {1}",SONo,VN), font);
                    doc.Add(paragraph);
                    paragraph = new Paragraph(string.Format("ชื่อหมอ {0}", cboDr.SelectedText), font);
                    doc.Add(paragraph);
                    paragraph = new Paragraph(string.Format("วันที่ {0}", dateTimePickerCreate.Text), font);//date
                    doc.Add(paragraph);

                    //=============Page number==
                    cb.BeginText();
                    cb.SetFontAndSize(bf, 10);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "Page 2/2", doc.PageSize.Width - doc.RightMargin, 44, 0);
                    cb.EndText();

                    doc.NewPage();//=====================
                    paragraph = new Paragraph(string.Format("ชื่อลูกค้า {0} ({1})", Custname, CN), font);
                    doc.Add(paragraph);
                    paragraph = new Paragraph(string.Format("{0}   {1}", SONo, VN), font);
                    doc.Add(paragraph);
                    paragraph = new Paragraph(string.Format("ชื่อหมอ {0}", cboDr.SelectedText), font);
                    doc.Add(paragraph);
                    paragraph = new Paragraph(string.Format("วันที่ {0}", dateTimePickerCreate.Text), font);//date
                    doc.Add(paragraph);
                    doc.Add(jpg);
                    //=============Page number==
                    cb.BeginText();
                    cb.SetFontAndSize(bf, 10);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "Page 2/2",doc.PageSize.Width- doc.RightMargin, 44, 0);
                    cb.EndText();
                      
                 


                    // Step 6: Closing the Document
                    doc.Close();
                }
            }
            // Catching iTextSharp.text.DocumentException if any
            catch (DocumentException de)
            {
                FullPath = "";
                throw de;
            }
            // Catching System.IO.IOException if any
            catch (IOException ioe)
            {
                FullPath = "";
                throw ioe;
            }
            return FullPath;
        }
        public string CreateNewPDFBoardCustomer()
        {
            //string appRootDir = Application.StartupPath;
            string Local_Folder = string.Format(@"{0}\MEDICALDOC\{1}\", Application.StartupPath, CN);
            string FullPath = Local_Folder + "/NewPaper1.pdf";
            try
            {
                // Step 1: Creating System.IO.FileStream object

                if (!Directory.Exists(Local_Folder)) Directory.CreateDirectory(Local_Folder);
                if (File.Exists(FullPath)) File.Delete(FullPath);

                using (FileStream fs = new FileStream(FullPath, FileMode.Create, FileAccess.Write, FileShare.None))
                // Step 2: Creating iTextSharp.text.Document object  Document doc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
                using (Document doc = new Document())//PageSize.A4, 0f, 10f, 100f, 0f
                // Step 3: Creating iTextSharp.text.pdf.PdfWriter object
                // It helps to write the Document to the Specified FileStream
                using (PdfWriter writer = PdfWriter.GetInstance(doc, fs))
                {
                    // Step 4: Openning the Document
                    doc.Open();

                    // Step 5: Adding a paragraph
                    // NOTE: When we want to insert text, then we've to do it through creating paragraph

                    //Add  iMage Background
                    string imageURL = string.Format("{0}/bgSaleCheck.jpg", Application.StartupPath);
                    iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);
                    //Resize image depend upon your need
                    jpg.ScaleToFit(doc.PageSize);
                    //Give space before image
                    jpg.SpacingBefore = 10f;
                    //Give some space after the image
                    jpg.SpacingAfter = 0f;
                    //jpg.Alignment = Element.ALIGN_LEFT;
                    jpg.Alignment = iTextSharp.text.Image.UNDERLYING;

                    //If you want to give absolute/specified fix position to image.
                    jpg.SetAbsolutePosition(0, 0);

                    //doc.Add(jpg);

                    //=====================

                    BaseFont bf = BaseFont.CreateFont(Application.StartupPath + "/THSarabunNew Bold.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    //Font font  = new Font(bf, 30);
                    iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 18);
                    PdfContentByte cb = writer.DirectContent;
                    Paragraph paragraph;// = new Paragraph(cboDr.SelectedText, font);//dr
                    paragraph = new Paragraph(string.Format("ชื่อลูกค้า {0} ({1})", Custname, CN), font);
                    doc.Add(paragraph);
                    paragraph = new Paragraph(string.Format("{0}   {1}", SONo, VN), font);
                    doc.Add(paragraph);
                    paragraph = new Paragraph(string.Format("ชื่อหมอ {0}", cboDr.SelectedText), font);
                    doc.Add(paragraph);
                    paragraph = new Paragraph(string.Format("วันที่ {0}      พนักงาน ......................................................", dateTimePickerCreate.Text), font);//date
                    doc.Add(paragraph);
                    doc.Add(paragraph);

                    //=============Page number==
                    cb.BeginText();
                    cb.SetFontAndSize(bf, 10);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "Page 2/2", doc.PageSize.Width - doc.RightMargin, 44, 0);
                    cb.EndText();

                    doc.NewPage();//=====================
                    paragraph = new Paragraph(string.Format("ชื่อลูกค้า {0} ({1})", Custname, CN), font);
                    doc.Add(paragraph);
                    paragraph = new Paragraph(string.Format("{0}   {1}", SONo, VN), font);
                    doc.Add(paragraph);
                    paragraph = new Paragraph(string.Format("ชื่อหมอ {0}", cboDr.SelectedText), font);
                    doc.Add(paragraph);
                    paragraph = new Paragraph(string.Format("วันที่ {0}", dateTimePickerCreate.Text), font);//date
                    doc.Add(paragraph);
                    //doc.Add(jpg);
                    //=============Page number==
                    cb.BeginText();
                    cb.SetFontAndSize(bf, 10);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "Page 2/2", doc.PageSize.Width - doc.RightMargin, 44, 0);
                    cb.EndText();




                    // Step 6: Closing the Document
                    doc.Close();
                }
            }
            // Catching iTextSharp.text.DocumentException if any
            catch (DocumentException de)
            {
                FullPath = "";
                MessageBox.Show(de.Message);
                throw de;
            }
            // Catching System.IO.IOException if any
            catch (IOException ioe)
            {
                FullPath = "";
                MessageBox.Show(ioe.Message);
                throw ioe;
            }
            return FullPath;
        }

        private void btnBrown_Click(object sender, EventArgs e)
        {
            try
            {
                txtFilePath.Text = BrowseFile.BrowFileType("IMAGE");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBoxExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBoxSave_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBoxSave, "Save");
        }

        private void pictureBoxExit_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBoxExit, "Close");
        }



    }
}
