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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Threading;
using System.ComponentModel;

//using ceTe.DynamicPDF;
//using ceTe.DynamicPDF.PageElements;
//using ceTe.DynamicPDF.Text;

namespace AryuwatSystem.Forms
{
    public partial class FrmMedicalUseList : DockContent, IForm
    {
        public FrmMedicalUseList()
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
        public string VN { get; set; }
        public string SONo { get; set; }
        public string CN { get; set; }

        public string MS_Code { get; set; }
        public string ListOrder { get; set; }
        public string CourseCardID { get; set; }
        public DateTime SODate { get; set; }
        

        public bool FromSOT = false;
        public bool IsUpdated = false;
        
        public string BranchName { get; set; }
        public string BranchID { get; set; }
        
        int CurrentRowIndex = -1;
        double ProCredit = 0;
        double SumPriceUsed = 0;
        bool ProCreditType = false;
        bool ProCreditTypeCheckExpire = false;
        string PRO_CalType = "";
        string UserMS_Code = "";
        DataTable dtRefMOUsed = new DataTable();
        DataSet dsTmpUsed = new DataSet();
        DataTable dtTmpUsed = new DataTable();
        DataTable dtTmpUsedMain = new DataTable();

        DataTable dtCust = new DataTable();
        DataTable dtSup = new DataTable();
       
        private string customerType;
        List<DataGridViewRow> rowsToDelete = new List<DataGridViewRow>();

        private void FrmMedicalUseList_Load(object sender, System.EventArgs e)
        {
            if (!(Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN))
                btnSaveCheckCourse.Visible = false;
            else btnSaveCheckCourse.Visible = true;
            
            SetColumnDgvSelectList();
            SetColumnsUsed();
            if (!string.IsNullOrEmpty(VN))
            {
                BindData();
                if (FromSOT)
                    FilterForSOT(MS_Code,ListOrder);
            }
        }


        private void SetColumnDgvSelectList()
        {
            //Utility.SetPropertyDgv(dgvHairSelect);
            dataGridViewSelectList.AllowUserToAddRows = false;
            dataGridViewSelectList.DefaultCellStyle.BackColor = Color.DarkGray;
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

            dataGridViewSelectList.Columns.Add("Discashier", "ส่วนลด Cashier");
            dataGridViewSelectList.Columns["Discashier"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["Discashier"].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridViewSelectList.Columns["Discashier"].Visible = true;
            dataGridViewSelectList.Columns["Discashier"].ReadOnly = true;
            dataGridViewSelectList.Columns["Discashier"].Width = 90;


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

            dataGridViewSelectList.Columns.Add("ExpireDateSO", "ExpireDateSO");
            dataGridViewSelectList.Columns["ExpireDateSO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectList.Columns["ExpireDateSO"].DefaultCellStyle.BackColor = Color.LemonChiffon;
            dataGridViewSelectList.Columns["ExpireDateSO"].ReadOnly = true;

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
                colChkComp.HeaderText = "แก้ไข";
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

            dataGridViewSelectList.Columns["Tab"].Visible = false;
            dataGridViewSelectList.Columns["ChkSub"].Visible = false;
            dataGridViewSelectList.Columns["ChkMar"].Visible = false;
            dataGridViewSelectList.Columns["ChkCom"].Visible = false;
            dataGridViewSelectList.Columns["ChkGiftv"].Visible = false;

          
            dataGridViewSelectList.Columns.Add("ListOrder", "ListOrder");
            dataGridViewSelectList.Columns.Add("FeeRate", "FeeRate");
            dataGridViewSelectList.Columns["FeeRate"].Visible = false;
            dataGridViewSelectList.Columns.Add("FeeRate2", "FeeRate2");
            dataGridViewSelectList.Columns["FeeRate2"].Visible = false;


            DataGridViewCheckBoxColumn colChkFlagUse = new DataGridViewCheckBoxColumn();
            {
                colChkFlagUse.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                colChkFlagUse.FlatStyle = FlatStyle.Standard;
                colChkFlagUse.ThreeState = false;
                colChkFlagUse.Name = "ChkFlagUse";
                colChkFlagUse.HeaderText = "CourseCheck";
                colChkFlagUse.CellTemplate = new DataGridViewCheckBoxCell();    
                colChkFlagUse.ReadOnly = false;
            }
            dataGridViewSelectList.Columns.Add(colChkFlagUse);

            if (!(Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN))
                dataGridViewSelectList.Columns["ChkFlagUse"].Visible = false;
            else dataGridViewSelectList.Columns["ChkFlagUse"].Visible = true;

            DataGridViewCheckBoxColumn chkCanceled = new DataGridViewCheckBoxColumn();
            {
                chkCanceled.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                chkCanceled.FlatStyle = FlatStyle.Standard;
                chkCanceled.ThreeState = false;
                chkCanceled.Name = "chkCanceled";
                chkCanceled.HeaderText = "Canceled";
                chkCanceled.CellTemplate = new DataGridViewCheckBoxCell();
            }
            dataGridViewSelectList.Columns.Add(chkCanceled);


            dataGridViewSelectList.Columns.Add("EN_COMS1", "EN_COMS1");
            dataGridViewSelectList.Columns["EN_COMS1"].Visible = false;

            dataGridViewSelectList.Columns.Add("CourseCardID", "CourseCardID");

          
            DataGridViewImageColumn CoPrintCard = new DataGridViewImageColumn();
            {
                CoPrintCard.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                CoPrintCard.CellTemplate = new DataGridViewImageCell();
                CoPrintCard.Name = "PrintCard";
                CoPrintCard.HeaderText = "PrintCard";
            }
            dataGridViewSelectList.Columns.Add(CoPrintCard);


            

        }
        private void SetColumnsUsed()
        {
            DerUtility.SetPropertyDgv(dgvUsedTrans);
            dgvUsedTrans.Columns.Add("Id", "Id");
            dgvUsedTrans.Columns.Add("MS_NameUse", "รายการ");
            dgvUsedTrans.Columns.Add("Amount", "จำนวนที่ใช้");
            dgvUsedTrans.Columns.Add("AmountBalance", "จำนวนคงเหลือ");
            dgvUsedTrans.Columns.Add("DateOfUse", "วันที่ใช้");
            dgvUsedTrans.Columns.Add("CN_USED", "CN");
            dgvUsedTrans.Columns.Add("CN_USEDFULLNAME", "ผู้ใช้");
            dgvUsedTrans.Columns.Add("CO", "CO");
            dgvUsedTrans.Columns.Add("RefMO", "Ref.MO");
            dgvUsedTrans.Columns["CN_USEDFULLNAME"].Width = 200;
            DataGridViewImageColumn colStaff = new DataGridViewImageColumn();
            {
                colStaff.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                colStaff.CellTemplate = new DataGridViewImageCell();
                colStaff.HeaderText = "Staff";
                colStaff.Name = "BtnStaff";
                colStaff.Visible = false;
            }
            dgvUsedTrans.Columns.Add(colStaff);
            DataGridViewImageColumn colDel = new DataGridViewImageColumn();
            {
                colDel.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                colDel.CellTemplate = new DataGridViewImageCell();
                colDel.HeaderText = "Delete";
                colDel.Name = "BtnDelete";
                colDel.Visible = false;
            }
            dgvUsedTrans.Columns.Add(colDel);

           
            

            dgvUsedTrans.Columns["Id"].Visible = false;
            dgvUsedTrans.Columns["Amount"].Width = 80;
            dgvUsedTrans.Columns["AmountBalance"].Width = 110;
            dgvUsedTrans.Columns["DateOfUse"].Width = 120;


            dgvUsedTrans.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvUsedTrans.Columns["AmountBalance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvUsedTrans.Columns["DateOfUse"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvUsedTrans.Columns.Add("Branch", "Branch");

            DataGridViewImageColumn ColLicencex = new DataGridViewImageColumn();
            {
                ColLicencex.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                ColLicencex.CellTemplate = new DataGridViewImageCell();
                ColLicencex.Name = "btnNewLicence";
                ColLicencex.HeaderText = "New";
            }
            dgvUsedTrans.Columns.Add(ColLicencex);
            DataGridViewImageColumn ColLicence = new DataGridViewImageColumn();
            {
                ColLicence.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                ColLicence.CellTemplate = new DataGridViewImageCell();
                ColLicence.Name = "btnLicence";
                ColLicence.HeaderText = "Sign";
            }
            dgvUsedTrans.Columns.Add(ColLicence);

           
            
            DataGridViewImageColumn ColLicencePreview = new DataGridViewImageColumn();
            {
                ColLicencePreview.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                ColLicencePreview.CellTemplate = new DataGridViewImageCell();
                ColLicencePreview.Name = "btnLicencePreview";
                ColLicencePreview.HeaderText = "SignPreview";
            }
            dgvUsedTrans.Columns.Add(ColLicencePreview);



            DataGridViewImageColumn FileScan = new DataGridViewImageColumn();
            {
                FileScan.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                FileScan.CellTemplate = new DataGridViewImageCell();
                FileScan.Name = "btnFileScan";
                FileScan.HeaderText = "FileScan";
            }
            dgvUsedTrans.Columns.Add(FileScan);

            dgvUsedTrans.Columns.Add("Remark", "Remark");
            dgvUsedTrans.Columns["Remark"].Width = 200;

            //dgvUsedTrans.Columns["btnFileScan"].Visible = false;
            //dgvUsedTrans.Columns["btnLicence"].Visible = false;
            dgvUsedTrans.Columns.Add("ListOrder", "ListOrder");
            dgvUsedTrans.Columns.Add("swap", "swap");
            dgvUsedTrans.Columns.Add("BranchId", "BranchId");
            dgvUsedTrans.Columns.Add("EN_REQ", "EN_REQ");
            dgvUsedTrans.Columns.Add("Name_REQ", "Name_REQ");
            dgvUsedTrans.Columns.Add("EN_Helper", "Helper");
            dgvUsedTrans.Columns["swap"].Visible =false;
            dgvUsedTrans.Columns["BranchId"].Visible = false;
            dgvUsedTrans.Columns["EN_REQ"].Visible = false;
            dgvUsedTrans.Columns["EN_Helper"].Visible = false;

            dgvUsedTrans.Columns["btnNewLicence"].Visible = false;
            dgvUsedTrans.Columns["btnLicencePreview"].Visible = false;
            dgvUsedTrans.Columns["btnLicence"].Visible = false;

            dgvUsedTrans.Columns.Add("CourseCardID", "CourseCardID");
            DataGridViewCheckBoxColumn colChkFlagUse = new DataGridViewCheckBoxColumn();
            {
                colChkFlagUse.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                colChkFlagUse.FlatStyle = FlatStyle.Standard;
                colChkFlagUse.ThreeState = false;
                colChkFlagUse.Name = "Printed";
                colChkFlagUse.HeaderText = "ปริ้น";
                colChkFlagUse.CellTemplate = new DataGridViewCheckBoxCell();
                //colChkFlagUse.ReadOnly = false;
            }
            dgvUsedTrans.Columns.Add(colChkFlagUse);

            DataGridViewImageColumn CoPrintCard = new DataGridViewImageColumn();
            {
                CoPrintCard.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                CoPrintCard.CellTemplate = new DataGridViewImageCell();
                CoPrintCard.Name = "PrintCard";
                CoPrintCard.HeaderText = "PrintCard";
            }
            dgvUsedTrans.Columns.Add(CoPrintCard);
            //dgvUsedTrans.Columns["PrintCard"].Visible = false;
            DataGridViewImageColumn CoPrintList = new DataGridViewImageColumn();
            {
                CoPrintList.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                CoPrintList.CellTemplate = new DataGridViewImageCell();
                CoPrintList.Name = "PrintList";
                CoPrintList.HeaderText = "PrintList";
                CoPrintList.Visible = false;
            }
            dgvUsedTrans.Columns.Add(CoPrintList);

            DataGridViewImageColumn CoSetJob = new DataGridViewImageColumn();
            {
                CoSetJob.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                CoSetJob.CellTemplate = new DataGridViewImageCell();
                CoSetJob.Name = "SetJob";
                CoSetJob.HeaderText = "แจ้งสาขา";
            }
            dgvUsedTrans.Columns.Add(CoSetJob);
            
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
                        //Cursor = Cursors.Default;
                        this.Cursor = Cursors.Hand;
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
                
                 dtCust = ds.Tables[0];
                 PRO_CalType = dtCust.Rows[0]["PRO_CalType"]+"";
                 ProCreditTypeCheckExpire = dtCust.Rows[0]["PRO_Type"] + "" == "CREDIT";
                 dtSup = ds.Tables[1];
                DataTable dtStuff = ds.Tables[2];
                DataTable dtDoc = ds.Tables[3];
                 dtRefMOUsed = ds.Tables[9];
                CN = dtCust.Rows[0]["CN"] + "";
                customerType = dtCust.Rows[0]["CustomerType"] + "";
                txtCustomerName.Text =dtCust.Rows[0]["FullNameThai"] + "" == "" ? dtCust.Rows[0]["FullNameEng"] + "" : dtCust.Rows[0]["FullNameThai"] + "";
                labelCN.Text = dtCust.Rows[0]["CN"] + "";
                lbMO.Text = VN;
                SODate = Convert.ToDateTime(dtCust.Rows[0]["SODate"] + "");
                BranchID = dtCust.Rows[0]["BranchID"] + "";

           
                foreach (DataRow dr in dtSup.Rows)
                {
                    if ((dr["MS_Code"] + "").Contains("PRO_CREDIT")) { ProCreditType = true; continue; }
                    if (PRO_CalType == "P")//A=amount  B=Buffe  P = 60000=>100000
                    {
                        double p =dr["MS_Price"] + ""==""?0: Convert.ToDouble(dr["MS_Price"] + "");
                        double a = dr["Amount"] + "" == "" ? 0 : Convert.ToDouble(dr["Amount"] + "");
                        double nc = dr["MS_Number_C"] + "" == "" ? 0 : Convert.ToDouble(dr["MS_Number_C"] + "");
                        double au = dr["AmountOfUse"] + "" == "" ? 0 : Convert.ToDouble(dr["AmountOfUse"] + "");
                        double Usedprice_avg = ((p * a) / (a * nc)) * au;
                        SumPriceUsed += Usedprice_avg;
                    }
                    else
                    {
                        SumPriceUsed += dr["PriceAfterDis"] + "" == "" ? 0 : Convert.ToDouble(dr["PriceAfterDis"] + "");
                    }

                    //if ((dr["MS_Code"] + "").Contains("PRO_CREDIT"))
                    //{
                    //    ProCreditType = true;
                    //    SumPriceUsed-= dr["PriceAfterDis"] + "" == "" ? 0 : Convert.ToDouble(dr["PriceAfterDis"] + "");
                    //    //break;
                    //}
                }


                ProCredit = dtCust.Rows[0]["ProCreditRemain"] + "" == "" ? 0 : Convert.ToDouble((dtCust.Rows[0]["ProCreditRemain"] + "" + "").Replace(",", ""));
                
                ProCredit = ProCredit - SumPriceUsed;
                //DataTable dtSupGroup = GroupByMultiple("MergStatus", dtSup); // Group Layer
                //foreach (DataRow rw in dtSupGroup.Rows)
                //{
                //    string expression = "MergStatus ='" + rw["MergStatus"] + "'";
                List<DataRow> lsPrint = new List<DataRow>();
                    foreach (DataRow dr in dtSup.Rows)
                    {
                        
                        string[] ms_code = (dr["MergStatus"] + "").Split(':');
                        //if ((dr["MS_Code"] + "").Contains("PRO_CREDIT")) continue;

                        decimal dblTotal = (dr["Amount"] + "" == "" ? 1 : decimal.Parse(dr["Amount"] + "") * (dr["MS_Number_C"] + "" == "" ? 1 : decimal.Parse(dr["MS_Number_C"] + "")));
                            double dblCL = dr["MS_CLPrice"] + "" == "" ? 0 : double.Parse(dr["MS_CLPrice"] + "");
                            double dblCA = dr["MS_CAPrice"] + "" == "" ? 0 : double.Parse(dr["MS_CAPrice"] + "");
                            decimal DiscountBathByItem = dr["DiscountBathByItem"] + "" == "" ? 0 : decimal.Parse(dr["DiscountBathByItem"] + "");
                            double pricePerUnit = dtCust.Rows[0]["CustomerType"] + "" == "CNT" || dtCust.Rows[0]["CustomerType"] + "" == "CNM" || dtCust.Rows[0]["CustomerType"] + "" == "CNS" ? dblCL : dblCA;
                            if (ProCreditType) pricePerUnit = double.Parse(dr["MS_Price"] + "");
                            double SpecialPrice=dr["SpecialPrice"] + "" == "" ? 0 : double.Parse(dr["SpecialPrice"] + "");
                            object[] myItems = {
                                               //false,
                                               dr["MS_Code"] + "",
                                               dr["MS_Name"] + "",
                                               dr["Amount"] + "",
                                               dr["MS_Number_C"] + "",
                                               dblTotal.ToString("###,###.##"),
                                               //dr["NumOfUse"] + "",
                                                (dr["AmountOfUse"] + "" ==""?0: decimal.Parse(dr["AmountOfUse"] + "")).ToString("###,##0.###"),
                                               (dblTotal -(dr["AmountOfUse"] + "" ==""?0: decimal.Parse(dr["AmountOfUse"] + ""))).ToString("###,##0.###"),
                                               pricePerUnit.ToString("###,###.##"),
                                               SpecialPrice.ToString("###,###,###.##"),
                                               DiscountBathByItem.ToString("###,###,###.##"),//ส่วนลด หน้าแคสเชีย
                                               //((double.Parse(dr["Amount"] + "")*pricePerUnit)+(SpecialPrice)).ToString("###,###,###.##"),
                                               double.Parse(dr["PriceAfterDis"] + "").ToString("###,###,###.##"),
                                               
                                               dr["FreeAmount"] + "",
                                               dr["ExpireDate"] + ""==""?"":Convert.ToDateTime(dr["ExpireDate"] + "").ToString("yyyy/MM/dd"),//.ToString("yyyy-MM-dd"),
                                                dr["ExpireDateSO"] + ""==""?"":Convert.ToDateTime(dr["ExpireDateSO"] + "").ToString("yyyy/MM/dd"),//.ToString("yyyy-MM-dd"),
                                               //dr["SurgicalFeeTyp"] + ""=="PHARMACY"?new Bitmap(1, 1):imageList1.Images[4],
                                               imageList1.Images[4],
                                               
                                               dr["Complimentary"]+""== "Y"?true:false ,
                                                dr["MarketingBudget"]+""!= "N"&&dr["MarketingBudget"]+""!=""?true:false,
                                                dr["Gift"]+""!= "N"&&dr["Gift"]+""!=""?true:false,
                                                dr["Subject"]+""== "Y"?true:false,
                                               dr["SurgicalFeeTyp"] + "",
                                               
                                               dr["ListOrder"] + "",
                                                   dr["FeeRate"] + "",
                                                   dr["FeeRate2"] + "",
                                                   dr["FlagUse"]+""== "Y"?true:false,
                                                   dr["Canceled"] + "" == "Y" ? true : false,
                                                   dtCust.Rows[0]["EN_COMS1"]+"",
                                                   dr["CourseCardID"] + "",
                                                   imageList1.Images[10],
                                                 
                                                   
                                           };
                        
                            dataGridViewSelectList.Rows.Add(myItems);
                            ((DataGridViewImageCell)dataGridViewSelectList.Rows[dataGridViewSelectList.RowCount - 1].Cells["PrintCard"]).Value = new Bitmap(1, 1);
                            if (ProCreditType && (dr["MS_Code"] + "").Contains("PRO_CREDIT") )
                            {
                                //Show
                                ((DataGridViewImageCell)dataGridViewSelectList.Rows[dataGridViewSelectList.RowCount - 1].Cells["PrintCard"]).Value = imageList1.Images[10];
                                ((DataGridViewImageCell)dataGridViewSelectList.Rows[dataGridViewSelectList.RowCount - 1].Cells["BtnUse"]).Value = new Bitmap(1, 1);

                                
                            }
                            else if(ProCreditType==false)//hide
                            {
                                ((DataGridViewImageCell)dataGridViewSelectList.Rows[dataGridViewSelectList.RowCount - 1].Cells["PrintCard"]).Value = imageList1.Images[10];
                            }

                        //if ((dr["MS_Number_C"] + ""==""?1:Convert.ToDecimal(dr["MS_Number_C"] + "")) > 1)
                            if (dr["MS_Type"] + "" == "C")
                            {
                                ((DataGridViewImageCell)dataGridViewSelectList.Rows[dataGridViewSelectList.RowCount - 1].Cells["BtnUse"]).Value = imageList1.Images[4];
                                ((DataGridViewImageCell)dataGridViewSelectList.Rows[dataGridViewSelectList.RowCount - 1].Cells["PrintCard"]).Value = imageList1.Images[10];
                            }

                                if (dr["SurgicalFeeTyp"] + "" == "" && dblTotal - (dr["AmountOfUse"] + "" == "" ? 0 : decimal.Parse(dr["AmountOfUse"] + "")) > 0)
                                    lsPrint.Add(dr);

                                //=======================อื่นๆ จะขีดเส้นและกดลิ้งชชชชชชชชชชชชชชชชชชชชชช
                                if (Entity.Userinfo.FIX_OTHER_SUB.Contains((dr["MS_Code"] + "").ToUpper()))
                                {
                                    //dataGridViewSelectList.Rows[dataGridViewSelectList.Rows.Count - 1].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Underline);
                                    dataGridViewSelectList.Rows[dataGridViewSelectList.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Blue;
                                    dataGridViewSelectList.Rows[dataGridViewSelectList.Rows.Count - 1].Cells["Name"].Style.Font =new System.Drawing.Font(this.Font, FontStyle.Underline);
                                }

                        }
                        //break;
                    //}
                //}
            

                dataGridViewSelectList.ClearSelection();
                SumPriceMedicalOrder();

                FilterList();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewSelectList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                 if (e.ColumnIndex == dataGridViewSelectList.Columns["PrintCard"].Index)
                    {
                        //string ccnumber = "";
                        //PopInputCourseCard c = new PopInputCourseCard();
                        //c.CN = cn;
                        //c.CourseCardID = ccnumber = AryuwatSystem.Data.UtilityBackEnd.GenMaxSeqnoValues("CC", BranchID);
                        //c.ShowDialog();
                        PopInputCourseCard c = new PopInputCourseCard();
                        c.SONo = SONo;
                        c.VN = VN;
                        c.CN = CN;
                        c.CustName = txtCustomerName.Text;
                        c.MS_Name = dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells["Name"].Value + "" + " (" + dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells["PriceTotal"].Value + "" + ")";
                        MS_Code = dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells["Code"].Value + "";
                        c.Amount = Convert.ToDecimal(dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells["Total"].Value + "");
                        if (ProCreditType && PRO_CalType != "A" && MS_Code.Contains("|PRO_CREDIT")) c.Amount = Convert.ToDecimal(dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells["Price/Unit"].Value + "");
                        c.CCdate = SODate;
                        
                        ListOrder = dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells["ListOrder"].Value + "";
                        c.MS_Code = MS_Code;
                        c.ListOrder = ListOrder;

                        CourseCardID = CheckCourseCardCreate();//ตรวจดสร้าหรือยัง
                        if (CourseCardID == "")//ถ้ายัง 
                        {
                            c.PrintCard = "N";
                       
                            CourseCardID = AryuwatSystem.Data.UtilityBackEnd.GenMaxSeqnoValues("CC", BranchID); //สร้างเลขใหม่
                        }
                        else
                            c.PrintCard = "Y";
                      

                        c.CourseCardID = CourseCardID;

                        if (c.ShowDialog() == DialogResult.OK)
                        {
                            IsUpdated = c.IsUpdated;
                            //Print Course Card
                            if (SaveCourseCard())
                            {
                                MS_Code = dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells["Code"].Value + "";
                                ListOrder = dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells["ListOrder"].Value + "";
                                BindDataUsed(MS_Code, ListOrder);
                             
                                PrintCourseCardForm();
                            }
                        }
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void dataGridViewSelectList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                 if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
                 CurrentRowIndex = e.RowIndex;
                if (e.ColumnIndex == dataGridViewSelectList.Columns["BtnUse"].Index)
                {
                    //if (dataGridViewSelectList["Tab", e.RowIndex].Value + "" == "PHARMACY")
                    //    return;
                    if (ProCreditTypeCheckExpire)//03-06-2020 เช็ค expire ใหม่
                    {
                        if (IsExpireDate(dataGridViewSelectList.Rows[e.RowIndex].Cells["ExpireDateSO"].Value + "") && !(Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN) && !Userinfo.IS_ADMIN_JOBCOST.Contains(Userinfo.EN))
                        {
                            MessageBox.Show("This Item Expired", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        if (IsExpireDate(dataGridViewSelectList.Rows[e.RowIndex].Cells["ExpireDate"].Value + "") && !(Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN) && !Userinfo.IS_ADMIN_JOBCOST.Contains(Userinfo.EN))
                        {
                            MessageBox.Show("This Item Expired", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    DataGridViewCheckBoxCell chkCom = dataGridViewSelectList.Rows[e.RowIndex].Cells["chkCanceled"] as DataGridViewCheckBoxCell;
                    if (Convert.ToBoolean(chkCom.Value) && !(Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN))
                    {
                        MessageBox.Show("This Item Closed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    //PopInputCourseCard c = new PopInputCourseCard();
                    //c.CN = CN;
                    //c.CourseCardID = dataGridViewSelectList.Rows[e.RowIndex].Cells["CourseCardID"].Value + "";
                    //c.ShowDialog();
                    PopMedicalUsed obj = new PopMedicalUsed();
                    //obj.CourseCardID = c.CourseCardID;


                    obj.StartPosition = FormStartPosition.CenterScreen;
                    //obj.WindowState = FormWindowState.Normal;
                    obj.BackColor = System.Drawing.Color.FromArgb(255, 230, 217);
                    obj.CN = CN;
                    obj.VN = VN;
                    obj.Sono = SONo;
                    obj.ListOrder = dataGridViewSelectList.Rows[e.RowIndex].Cells["ListOrder"].Value + "";
                    obj.EN_COMS1 = dataGridViewSelectList.Rows[e.RowIndex].Cells["EN_COMS1"].Value + "";

                    obj.MS_Code = dataGridViewSelectList.Rows[e.RowIndex].Cells["Code"].Value + "";
                    obj.SupplieName = dataGridViewSelectList.Rows[e.RowIndex].Cells["Name"].Value + "";
                    obj.AmountTotal = dataGridViewSelectList.Rows[e.RowIndex].Cells["Total"].Value + "";
                    obj.Amounttotal = Convert.ToDecimal((dataGridViewSelectList.Rows[e.RowIndex].Cells["Total"].Value + "").Replace(",", ""));
                    obj.AmountUsed = dataGridViewSelectList.Rows[e.RowIndex].Cells["Used"].Value + "";
                    obj.AmountBalance = dataGridViewSelectList.Rows[e.RowIndex].Cells["Balance"].Value + "";
                    obj.PriceAfterDis = dataGridViewSelectList.Rows[e.RowIndex].Cells["PriceTotal"].Value + "" == "" ? 0 : Convert.ToDecimal(dataGridViewSelectList.Rows[e.RowIndex].Cells["PriceTotal"].Value + "");
                    obj.TabName = dataGridViewSelectList.CurrentRow.Cells["Tab"].Value + "";
                    obj.CustomerName = txtCustomerName.Text;
                    obj.ExpireDate = dataGridViewSelectList.Rows[e.RowIndex].Cells["ExpireDate"].Value + "";
                    obj.FeeRate = dataGridViewSelectList.Rows[e.RowIndex].Cells["FeeRate"].Value + "" == "" ? 0 : Convert.ToDecimal(dataGridViewSelectList.Rows[e.RowIndex].Cells["FeeRate"].Value + "");
                    obj.FeeRate2 = dataGridViewSelectList.Rows[e.RowIndex].Cells["FeeRate2"].Value + "" == "" ? 0 : Convert.ToDecimal(dataGridViewSelectList.Rows[e.RowIndex].Cells["FeeRate2"].Value + "");
                    obj.ParentForm = this;

                    //obj.MedicalStuffs = MedicalStuffs;
                    obj.ShowDialog();

                    MS_Code = dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells["Code"].Value + "";
                    ListOrder = dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells["ListOrder"].Value + "";
                    CourseCardID = dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells["CourseCardID"].Value + "";
                  
                    BindDataUsed(MS_Code, ListOrder);
                }
                else
                {
                     MS_Code = dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells["Code"].Value + "";
                     ListOrder = dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells["ListOrder"].Value + "";
                     CourseCardID = dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells["CourseCardID"].Value + "";
                     UpdateExpireDate(e.RowIndex);
                     //BindDataUsed(MS_Code, ListOrder);
                }
                //========================Sun item Other================================
                if (Entity.Userinfo.FIX_OTHER_SUB.Contains(MS_Code))
                {
                    popSubItemOther pop = new popSubItemOther();

                    var MaxID2ListOrder = 0;
                    if (dataGridViewSelectList.RowCount == 0)
                        MaxID2ListOrder = 0;
                    else
                        MaxID2ListOrder = dataGridViewSelectList.Rows.Cast<DataGridViewRow>().Max(r => int.TryParse(r.Cells["ListOrder"].Value.ToString(), out MaxID2ListOrder) ? MaxID2ListOrder : 0);

                    pop.customerType = customerType;
                    pop.VN = VN;
                    pop.SONo = SONo;
                    pop.CN = CN;
                    pop.CustName = txtCustomerName.Text;
                    pop.MS_CodeM = dataGridViewSelectList.Rows[e.RowIndex].Cells["Code"].Value + "";
                  
                    pop.EN_COMS1 = dataGridViewSelectList.Rows[e.RowIndex].Cells["EN_COMS1"].Value + "";
                    pop.ListOrderM = dataGridViewSelectList.Rows[e.RowIndex].Cells["ListOrder"].Value + "";
                    pop.PriceTotal = dataGridViewSelectList.Rows[e.RowIndex].Cells["PriceTotal"].Value + "" == "" ? 0 : Convert.ToDecimal(dataGridViewSelectList.Rows[e.RowIndex].Cells["PriceTotal"].Value + "");
                    pop.Text = dataGridViewSelectList.Rows[e.RowIndex].Cells["Name"].Value + "/" + pop.PriceTotal.ToString("###,###,###.##");
                    //pop.MainUnitCode = dataGridViewSelectList.Rows[e.RowIndex].Cells["MainUnitCode"].Value + "";
                    //pop.MainUnitName = dataGridViewSelectList.Rows[e.RowIndex].Cells["MainUnitName"].Value + "";
                    //pop.SubUnitCode = dataGridViewSelectList.Rows[e.RowIndex].Cells["SubUnitCode"].Value + "";
                    //pop.SubUnitName = dataGridViewSelectList.Rows[e.RowIndex].Cells["SubUnitName"].Value + "";
                    pop.ShowDialog();
                    //if (pop.ShowDialog() == DialogResult.OK)
                    //{
                    //    listSupOther = pop.listSupOther;
                    //}
                    //if (pop.SUMPriceAfterDis != pop.PriceTotal)
                    //    dataGridViewSelectList.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;//Color.Red;
                    //else
                    //    dataGridViewSelectList.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private string CheckCourseCardCreate()
        {
            string CardID = "";
            try
            {
                DataSet ds = new Business.MedicalOrderUseTrans().CheckCourseCardCreated(SONo,VN,MS_Code,ListOrder);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    CardID = ds.Tables[0].Rows[0][0].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            return CardID;
        }
        private bool SaveCourseCard()
        {
            bool saveOK = false;
            try
            {
                MedicalOrderUseTrans c = new Entity.MedicalOrderUseTrans();
                c.CN = CN;
                c.Sono = SONo;
                c.VN = VN;
                c.MS_Code = MS_Code;
                c.ListOrder = ListOrder;
                c.CreateDate = SODate;
                c.CourseCardID = CourseCardID;
                c.CreateBy = Entity.Userinfo.EN;
                c.BranchId = BranchID;

                if (IsUpdated)
                {
                    c.IsUpdated = "Y";
                    var intStatus = new Business.MedicalOrderUseTrans().InsertMedicalCourseCard(c);
                    BindDataUsed(MS_Code, ListOrder);
                }
                else
                    c.IsUpdated = "N";
               
//                MessageBox.Show("บันทึกเรียบร้อยแล้ว");
                saveOK = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return saveOK;
        }
        private bool SaveSlipCourse(string CO,int PrintLineOrder)
        {
            bool saveOK = false;
            try
            {
                MedicalOrderUseTrans c = new Entity.MedicalOrderUseTrans();
                c.CreateBy = Entity.Userinfo.EN;
                c.CO = CO;
                c.PrintSlip = "Y";
                c.PrintLineOrder = PrintLineOrder;
       
                    var intStatus = new Business.MedicalOrderUseTrans().UpdateSlipCourseCard(c);
                    BindDataUsed(MS_Code, ListOrder);

                //                MessageBox.Show("บันทึกเรียบร้อยแล้ว");
                saveOK = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return saveOK;
        }

        private void PrintCourseCard(string co, int rIndex)//ปริ้นแค่รายการที่กดปริ้น
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

                string COx = "";
                    //obj.PrintType = string.Format(" วันที่ {0} - {1}", txtStartdate.Text, txtEnddate.Text);
                    //obj.ForDate = string.Format("วันที่ {0} - {1}", txtStartdate.Text, txtEnddate.Text);

                   DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();


                   bool Find = false;
           
                DataTable dtemp = new DataTable();
                dtemp = dtTmpUsed.Clone();
                foreach (DataRow item in dtTmpUsed.Rows)
                {
                    item["PrintSlip"] = "N";

                    COx = item["Id"].ToString();//dgvUsedTrans.Rows[dgvUsedTrans.CurrentRow.Index].Cells["CO"].Value.ToString();
                        ch1 = (DataGridViewCheckBoxCell)dgvUsedTrans.Rows[dgvUsedTrans.CurrentRow.Index].Cells["Printed"];
                        if (COx == co)//&& ch1.Value.ToString().ToLower() == "true"
                        {
                            if (CourseCardID == "")
                            {
                                MessageBox.Show("Print Course Card First.", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                                //obj.Dispose();
                                //return;
                            }
                            Find = true;
                            ch1.Value = "True";
                            item["PrintSlip"] = "Y";
                            dtemp.ImportRow(item);
                            break;
                        }
                 
                }



                if (ProCreditType)
                {
                    obj.FormName = "RptCourseSlipCredit";// "RptCourseCard";
                    foreach (DataGridViewRow dataRow in dataGridViewSelectList.Rows)
                    {
                        if (dataRow.Cells["Code"].Value.ToString().ToUpper().Contains("CREDIT"))
                        {
                            dtTmpUsedMain.Rows[0]["MS_Name"] = dataRow.Cells["Name"].Value;
                            dtTmpUsedMain.Rows[0]["CourseCardID"] = dataRow.Cells["CourseCardID"].Value;
                            if (CourseCardID == "")
                               // MessageBox.Show("Print Course Card First.","Important Note",MessageBoxButtons.OK,MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button1);
                            break;
                        }
                    }
                }
                else obj.FormName = "RptCourseSlip";
                
                //dtListAll = dsSurgeryFee.Tables[0].DefaultView.ToTable();
                obj.dt = dtemp;// dtTmpUsed.DefaultView.ToTable();
                obj.dt2 = dtTmpUsedMain.DefaultView.ToTable();
                obj.MaximizeBox = true;
          
                obj.TopMost = true;
                //obj.ShowDialog();
                obj.Show();

                popAlert pop = new popAlert();
                pop.txtTitle = "";
                pop.txtShow = string.Format("พิมพ์ข้อมูลสำเร็จหรือไม่ {0}{1}", Environment.NewLine, "Printed Complete.");
                //DialogResult result3=pop.ShowDialog();
                //pop.ShowDialog();
                //if (pop.ShowDialog() == DialogResult.Yes)
                //    SaveSlipCourse(co, rIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void PrintCourseCardList(string co, int rIndex)//ปริ้นแค่รายการที่กดปริ้น
        {
            try
            {
                if (dgvUsedTrans.Rows[rIndex].Cells["CourseCardID"].Value + "" == "")//CourseCardID == ""
                {
                    MessageBox.Show("Print Course Card First.", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }
                FrmPreviewRpt obj = new FrmPreviewRpt();
                DataRow dr;
                string strTypeofPay = "";

                obj.PrintType = "";
                double dblCredit = 0.00;
                double dblCash = 0.00;
                string strBankName = "";

                string COx = "";
                //obj.PrintType = string.Format(" วันที่ {0} - {1}", txtStartdate.Text, txtEnddate.Text);
                //obj.ForDate = string.Format("วันที่ {0} - {1}", txtStartdate.Text, txtEnddate.Text);

                DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();




                DataTable dtemp = new DataTable();
                dtemp = dtTmpUsed.Clone();
                bool isPrint = false;
                foreach (DataRow item in dtTmpUsed.Rows)
                {
                    item["PrintSlip"] = "N";
                    co = item["Id"] + "";
                    foreach (DataGridViewRow dataRow in dgvUsedTrans.Rows)
                    {
                        COx = dataRow.Cells["Id"].Value.ToString();
                        ch1 = (DataGridViewCheckBoxCell)dataRow.Cells["Printed"];
                        if (co == COx && ch1.Value.ToString().ToLower() == "true")
                        {
                            item["PrintSlip"] = "Y";
                            isPrint = true;
                            break;
                        }
                    }
                    dtemp.ImportRow(item);
                }

                //if (isPrint == false)
                //{
                //    MessageBox.Show("Select item to print", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                //    return;
                //}

                if (ProCreditType)
                {
                    obj.FormName = "RptCourseCardCreditLand";// "RptCourseCard";
                    foreach (DataGridViewRow dataRow in dataGridViewSelectList.Rows)
                    {
                        if (dataRow.Cells["Code"].Value.ToString().ToUpper().Contains("CREDIT"))
                        {
                            dtTmpUsedMain.Rows[0]["MS_Name"] = dataRow.Cells["Name"].Value;
                            dtTmpUsedMain.Rows[0]["CourseCardID"] = dataRow.Cells["CourseCardID"].Value;

                            break;
                        }
                    }
                }
                else obj.FormName = "RptCourseCard";

                //dtListAll = dsSurgeryFee.Tables[0].DefaultView.ToTable();
                obj.dt = dtemp;// dtTmpUsed.DefaultView.ToTable();
                obj.dt2 = dtTmpUsedMain.DefaultView.ToTable();
               // obj.MaximizeBox = true;

                //obj.TopMost = true;
                //obj.ShowDialog();
                obj.Show();

                //popAlert pop = new popAlert();
                //pop.txtTitle = "";
                //pop.txtShow = string.Format("พิมพ์ข้อมูลสำเร็จหรือไม่ {0}{1}", Environment.NewLine, "Printed Complete.");
                ////DialogResult result3=pop.ShowDialog();
                //pop.ShowDialog();
                //if (pop.ShowDialog() == DialogResult.Yes)
                //    SaveSlipCourse(co, rIndex);

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
                dtemp = dtTmpUsed.Clone();

                if (!(Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN))
                {
                    foreach (DataRow item in dtTmpUsed.Rows)
                    {
                        item["PrintSlip"] = "N";
                    }
                }

                foreach (DataRow item in dtTmpUsed.Rows)
                {
                    item["PrintSlip"] = "N";
                    foreach (DataGridViewRow dataRow in dgvUsedTrans.Rows)
                    {
                        COx = dataRow.Cells["Id"].Value.ToString();
                        ch1 = (DataGridViewCheckBoxCell)dataRow.Cells["Printed"];
                        if (item["Id"] + "" == COx && ch1.Value.ToString().ToLower() == "true")
                        {
                            item["PrintSlip"] = "Y";
                            item["CCDate"] = SODate;
                        }
                        //else
                        //    item["PrintCard"] = "N";


                    }
                    dtemp.ImportRow(item);
                }

                        if (ProCreditType)
                            obj.FormName = "RptCourseCardFormCreditLand";
                        else
                            obj.FormName = "RptCourseCardForm";
                //dtListAll = dsSurgeryFee.Tables[0].DefaultView.ToTable();
                obj.dt = dtemp;// dtTmpUsed.DefaultView.ToTable();
                //if (dtTmpUsedMain.DefaultView.ToTable().Rows.Count > 0)
                obj.dt2 = dtTmpUsedMain.DefaultView.ToTable();
                obj.MaximizeBox = true; 

                obj.TopMost = true;
                obj.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool IsExpireDate(string str)
        {
            bool IsExpire = false;
            try
            {
                IsExpire = DateTime.Now.Date > (str == "" ? DateTime.Now.Date : Convert.ToDateTime(str).Date);
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
                decimal SumUsed = 0;
                dgvUsedTrans.Rows.Clear();
                Entity.MedicalOrderUseTrans info = new MedicalOrderUseTrans();
                info.CN = CN;
                info.VN = VN;
                info.MS_Code = UserMS_Code=MS_Code;
                info.ListOrder = ListOrder;
                

                if (MS_Code.Contains("PRO_CREDIT"))
                    ProCreditType = true;
                else
                    ProCreditType = false; 
                //DataTable dtTmpUsed;
                if (!string.IsNullOrEmpty(info.VN))
                {
                    dsTmpUsed = new Business.MedicalOrderUseTrans().SelectMedicalOrderUseTransById(info);
                    dtTmpUsed = dsTmpUsed.Tables[0];
                    if(dsTmpUsed.Tables.Count>1)dtTmpUsedMain = dsTmpUsed.Tables[1];


                    foreach (DataRowView item in dtTmpUsed.DefaultView)
                    {

                        SumUsed += item["UsedValue"] + "" == "" ? 0 : Convert.ToDecimal(item["UsedValue"] + "");
                        decimal AmountU = Convert.ToDecimal(string.IsNullOrEmpty(item["AmountOfUse"] + "") ? "1" : item["AmountOfUse"] + "".Replace(",", ""));
                        decimal AmountB = Convert.ToDecimal(string.IsNullOrEmpty(item["AmountBalance"] + "") ? "0" : item["AmountBalance"] + "".Replace(",", ""));
                        object[] myItems = {
                                               item["ID"] + "",
                                               item["MS_NameUse"] + "",
                                               AmountU.ToString("###,###,##0.###"),
                                                 AmountB.ToString("###,###,##0.###"),
                                               item["DateOfUse"] + "" != ""? DateTime.Parse(item["DateOfUse"] + "").Date.ToShortDateString():"",
                                               item["CN_USED"]+"",
                                               item["FullNameThai"]+"" != ""?item["FullNameThai"]+"":item["FullNameEng"]+"",
                                               item["CO"]+"",
                                               item["RefMO"]+"",
                                               imageList1.Images[2],
                                               imageList1.Images[3],
                                               item["BranchName"]+"",
                                               imageList1.Images[9],//new
                                               imageList1.Images[6],//เซ็น
                                               imageList1.Images[8],//preview
                                               imageList1.Images[7],//
                                               item["Remark"]+"",
                                               
                                               item["ListOrder"]+"",
                                                //item["Remark"]+"",
                                                item["swap"]+"",
                                                item["BranchId"]+"",
                                                item["EN_REQ"]+"",
                                                item["Name_REQ"]+"",
                                                item["EN_Helper"]+"",
                                                item["CourseCardID"]+"",
                                                item["PrintSlip"]+""== "Y"?true:false,
                                                imageList1.Images[10],
                                                imageList1.Images[10],
                                                imageList1.Images[12],
                                               
                                           };
                        dgvUsedTrans.Rows.Add(myItems);

                        ((DataGridViewImageCell)dgvUsedTrans.Rows[dgvUsedTrans.RowCount - 1].Cells["PrintList"]).Value = new Bitmap(1, 1);
                        ((DataGridViewImageCell)dgvUsedTrans.Rows[dgvUsedTrans.RowCount - 1].Cells["PrintCard"]).Value = new Bitmap(1, 1);
                        if (ProCreditType && (dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells["Code"].Value + "").Contains("PRO_CREDIT") || Convert.ToDecimal(item["MS_Number_C"] + "")>1)
                        {
                            //Show
                            ((DataGridViewImageCell)dgvUsedTrans.Rows[dgvUsedTrans.RowCount - 1].Cells["PrintList"]).Value = imageList1.Images[10];
                            ((DataGridViewImageCell)dgvUsedTrans.Rows[dgvUsedTrans.RowCount - 1].Cells["PrintCard"]).Value = imageList1.Images[10];
                            
                        }
                        else if (ProCreditType == false)//hide
                        {

                            ((DataGridViewImageCell)dgvUsedTrans.Rows[dgvUsedTrans.RowCount - 1].Cells["PrintList"]).Value = imageList1.Images[10];
                            ((DataGridViewImageCell)dgvUsedTrans.Rows[dgvUsedTrans.RowCount - 1].Cells["PrintCard"]).Value = imageList1.Images[10];

                        }
                    }
                    txtPriceTotal.Text= SumUsed.ToString("###,###,###.##");
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

        private void SumPriceMedicalOrder()
        {
            double dblTotal = 0;//dataGridViewSelectList.Rows.Cast<DataGridViewRow>().Sum(row => row.Cells["PriceTotal"].Value + ""==""?0:double.Parse(row.Cells["PriceTotal"].Value + ""));
            foreach (DataGridViewRow row in dataGridViewSelectList.Rows)
            {
                if ((row.Cells["Code"].Value + "").Contains("|PRO_CREDIT")) continue;
                dblTotal += row.Cells["PriceTotal"].Value + "" == "" ? 0 : double.Parse(row.Cells["PriceTotal"].Value + "");
            }
            txtPriceTotal.Text = dblTotal.ToString("###,###,###.##");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (Statics.frmMedicalOrderList != null)
                    Statics.frmMedicalOrderList.BindDataMedicalOrder(1);

                this.Close();
            }
            catch (Exception)
            {
                
               
            }
           
        }

        private void dataGridViewSelectList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);

            DataGridViewCheckBoxCell chkCom = dataGridViewSelectList.Rows[e.RowIndex].Cells["chkCanceled"] as DataGridViewCheckBoxCell;
            if (Convert.ToBoolean(chkCom.Value))
            {
                dataGridViewSelectList.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font(this.Font, FontStyle.Strikeout);
            }
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
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && (e.ColumnIndex == dgvUsedTrans.Columns["btnLicence"].Index))
                {
                    if (dgvUsedTrans["Tab", e.RowIndex].Value + "" == "PHARMACY")
                    {
                        //dataGridViewSelectList.Columns["BtnUse"].Visible = false;
                        //Cursor = Cursors.Default;
                        this.Cursor = Cursors.Hand;
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


        BackgroundWorker bgWorker = new BackgroundWorker();

        //private void btnStart_Click(object sender, EventArgs e)
        //{
        //    bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
        //    bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
        //    bgWorker.ProgressChanged += new ProgressChangedEventHandler(bgWorker_ProgressChanged);

        //    bgWorker.RunWorkerAsync();
        //}

        private void btnStop_Click(object sender, EventArgs e)
        {
            bgWorker.CancelAsync();
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {

           
        }

        // This event handler updates the progress.
        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Update Progress Status to UI
        }

        // This event handler deals with the results of the background operation.
        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Finish
            bgWorker.Dispose();
        }

        string Local_Folder = "";
        string FullPath = "";
        string filename = "";

        string remote_path = "";
        int currentdgvUsedTransRow = 0;
        bool ISPreview = true;
        bool ISNewPaper = false;
        private void dgvUsedTrans_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if (e.ColumnIndex == dgvUsedTrans.Columns["PrintCard"].Index || e.ColumnIndex == dgvUsedTrans.Columns["PrintList"].Index)
                //{
                //    //Print Course Card
                //    string CO = dgvUsedTrans.Rows[e.RowIndex].Cells["CO"].Value + "";

                //    DataGridViewCheckBoxCell ch1 = (DataGridViewCheckBoxCell)dgvUsedTrans.Rows[e.RowIndex].Cells["Printed"];
                //    //if (ch1.Value.ToString().ToLower() != "true" && (Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN))
                //    //{
                //    if (e.ColumnIndex == dgvUsedTrans.Columns["PrintList"].Index)
                //            PrintCourseCardList(CO, e.RowIndex);
                //        else
                //            PrintCourseCard(CO, e.RowIndex);

                 
                //    //}
                //    //else
                //    //{
                //    //    MessageBox.Show("ต้องการพิมพ์ใหม่ กรุณาติดต่อผู้ดูแลระบบ");
                //    //}
                //}
                if (e.ColumnIndex == dgvUsedTrans.Columns["SetJob"].Index)
                {
                    string CO = dgvUsedTrans.Rows[e.RowIndex].Cells["CO"].Value + "";
                    //MessageBox.Show("แจ้งสาขาเที่เปิดคอร์ส."+" Co = "+CO, "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
               

                    popAlert pop = new popAlert();
                    pop.txtShow = string.Format("แจ้งสาขาเที่เปิดคอร์ส.{0}", System.Environment.NewLine+CO);
                    pop.txtTitle = "";
                    //DialogResult result3=pop.ShowDialog();
                    pop.ShowDialog();
                    if (pop.ShowDialog() != DialogResult.Yes) return;
                    
                    MessageBox.Show("Insert to job table", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    //Print Course Card

                    //DataGridViewCheckBoxCell ch1 = (DataGridViewCheckBoxCell)dgvUsedTrans.Rows[e.RowIndex].Cells["Printed"];
               
                    //if (e.ColumnIndex == dgvUsedTrans.Columns["PrintList"].Index)
                    //        PrintCourseCardList(CO, e.RowIndex);
                    //    else
                    //        PrintCourseCard(CO, e.RowIndex);
                }
            

                if ((e.ColumnIndex == dgvUsedTrans.Columns["btnLicence"].Index) || (e.ColumnIndex == dgvUsedTrans.Columns["btnLicencePreview"].Index) || e.ColumnIndex == dgvUsedTrans.Columns["btnNewLicence"].Index)
                {
                    if (e.ColumnIndex == dgvUsedTrans.Columns["btnLicencePreview"].Index)
                    {
                        ISPreview = true;
                        ISNewPaper = false;
                    }
                    else if (e.ColumnIndex == dgvUsedTrans.Columns["btnLicence"].Index)
                    {
                        ISPreview = false;
                          ISNewPaper = false;
                    }

                    if (e.ColumnIndex == dgvUsedTrans.Columns["btnNewLicence"].Index)
                    {
                        ISNewPaper = true;
                        ISPreview = false;
                    }

                    

                    currentdgvUsedTransRow=e.RowIndex;
                    //bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
                    //bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
                    //bgWorker.ProgressChanged += new ProgressChangedEventHandler(bgWorker_ProgressChanged);

                    //bgWorker.RunWorkerAsync();
                    Local_Folder = string.Format(@"{0}\MEDICALDOC\{1}\", Application.StartupPath, CN);
                    FullPath = Local_Folder + "NewPaper1.pdf";
                    filename = string.Format("{0}_{1}_{2}_{3}.pdf", CN, VN.Replace("-", "_"), UserMS_Code, dgvUsedTrans.Rows[currentdgvUsedTransRow].Cells["Id"].Value + "");
                    string path = string.Format(@"{0}\Customers\{1}\", Application.StartupPath, CN);
                    remote_path = string.Format(@"\Customers\{0}\CustomersSign\", CN);
                    if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                    string saveFullPath = path + filename;
                    //bmp.Save(saveFullPath);

                    if (DerClass.DerUtility.DownLoadImage(saveFullPath, remote_path, filename))
                    {
                        FullPath = saveFullPath;
                    }
                     if(ISNewPaper) //new
                    {
                        saveFullPath = "";


                        // Step 1: Creating System.IO.FileStream object

                        if (!Directory.Exists(Local_Folder)) Directory.CreateDirectory(Local_Folder);
                        if (File.Exists(FullPath)) File.Delete(FullPath);

                       


                            using (FileStream fs = new FileStream(FullPath, FileMode.Create, FileAccess.Write, FileShare.None))
                            // Step 2: Creating iTextSharp.text.Document object  Document doc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);


                            using (Document doc = new Document(PageSize.A5.Rotate()))//PageSize.A4, 0f, 10f, 100f, 0f
                            // Step 3: Creating iTextSharp.text.pdf.PdfWriter object
                            // It helps to write the Document to the Specified FileStream


                            using (PdfWriter writer = PdfWriter.GetInstance(doc, fs))
                            {
                                // Step 4: Openning the Document
                                writer.ViewerPreferences = PdfWriter.PageModeUseOutlines;

                                writer.PdfVersion = PdfWriter.VERSION_1_6;
                                writer.SetFullCompression();
                                
                                doc.Open();
                                BaseFont bf = BaseFont.CreateFont(Application.StartupPath + "/THSarabunNew Bold.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                                //Font font  = new Font(bf, 30);
                                //iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 18);
                                //iTextSharp.text.Font fontB = new iTextSharp.text.Font(bf, 24);

                                //Paragraph paragraph;// = new Paragraph(cboDr.SelectedText, font);//dr
                                //paragraph = new Paragraph(string.Format("ชื่อลูกค้า {0} ({1})", txtCustomerName.Text, CN), fontB);
                                //doc.Add(paragraph);
                                //paragraph = new Paragraph(string.Format("{0}   {1}", SONo, VN), font);
                                //doc.Add(paragraph);
                                //paragraph = new Paragraph(string.Format("รายการ {0}", dataGridViewSelectList.CurrentRow.Cells["Name"].Value + ""), font);

                                //doc.Add(paragraph);
                                //paragraph = new Paragraph(string.Format("จำนวนทั้งหมด/Total       {0}", dataGridViewSelectList.CurrentRow.Cells["Total"].Value + ""), font);
                                //doc.Add(paragraph);
                                //paragraph = new Paragraph(string.Format("ใช้ไปแล้ว/Used           {0}", dataGridViewSelectList.CurrentRow.Cells["Used"].Value + ""), font);
                                //doc.Add(paragraph);
                                //paragraph = new Paragraph(string.Format("ใช้ครั้งนี้/Current Used    {0}", dgvUsedTrans.CurrentRow.Cells["Amount"].Value + ""), font);
                                //doc.Add(paragraph);
                                //paragraph = new Paragraph(string.Format("คงเหลือ/Balance         {0}", dataGridViewSelectList.CurrentRow.Cells["Balance"].Value + ""), font);
                                //doc.Add(paragraph);
                                //paragraph = new Paragraph(string.Format("วันที่ {0}   อ้างอิงใบยา/Ref.MO {1}   สาขา/Branch {2}", dgvUsedTrans.Rows[e.RowIndex].Cells["DateOfUse"].Value + "", dgvUsedTrans.Rows[e.RowIndex].Cells["RefMO"].Value + "", dgvUsedTrans.Rows[e.RowIndex].Cells["Branch"].Value + ""), font);//date
                                //doc.Add(paragraph);
                                // Step 6: Closing the Document

                                PdfContentByte cb = writer.DirectContent;
                                // we tell the ContentByte we're ready to draw text
                                cb.BeginText();


                                //==========================BeginText TExt==========================
                                // we draw some text on a certain position
                                cb.SetFontAndSize(bf, 22);
                                cb.SetTextMatrix(30, 370);
                                cb.ShowText(string.Format("ชื่อลูกค้า {0} ({1})", txtCustomerName.Text, CN));

                                cb.SetFontAndSize(bf, 20);
                                cb.SetTextMatrix(30, 340);
                                cb.ShowText(string.Format("ชื่อผู้ใช้ {0} ({1})", dgvUsedTrans.CurrentRow.Cells["CN_USEDFULLNAME"].Value + "", dgvUsedTrans.CurrentRow.Cells["CN_USED"].Value + ""));

                                //cb.SetFontAndSize(bf, 14);
                                //cb.SetTextMatrix(450, 400);
                                //cb.ShowText(string.Format("{0}", SONo));
                                //cb.SetFontAndSize(bf, 13);
                                //cb.SetTextMatrix(450, 390);
                                //cb.ShowText(string.Format("{0}", VN));

                                //cb.SetFontAndSize(bf, 10);
                                //cb.SetTextMatrix(500, 380);
                                //cb.ShowText(string.Format("ซื้อที่/Branch {0}", BranchName));

                                //=================
                                double t = Convert.ToDouble(dataGridViewSelectList.CurrentRow.Cells["Total"].Value + "");
                                double curUsed = Convert.ToDouble(dgvUsedTrans.CurrentRow.Cells["Amount"].Value + "");

                                double bal = Convert.ToDouble(dgvUsedTrans.CurrentRow.Cells["AmountBalance"].Value + "");
                                double AllUsed =(t-bal);//ใช้ไปแล้ว คือ ที่เลือกและใช้ก่อนหน้ารวมกัน
                                //=================
                                cb.SetFontAndSize(bf, 20);
                                cb.SetTextMatrix(30, 320);
                                cb.ShowText(string.Format("รายการ {0}", dataGridViewSelectList.CurrentRow.Cells["Name"].Value + ""));//"Text at position 30,360."
                                cb.SetTextMatrix(30, 290);
                                cb.ShowText(string.Format("จำนวนทั้งหมด/Total         {0}", t.ToString("###,###,###.##")));///"Text at position 30,340."
                                cb.SetTextMatrix(300, 290);
                     
                                cb.ShowText(string.Format("ใช้ไปแล้ว/Used           {0}", AllUsed.ToString("###,###,###.##")));//"Text at position 300,340."

                                cb.SetTextMatrix(30, 270);
                                cb.ShowText(string.Format("ใช้ครั้งนี้/Current Used      {0}", dgvUsedTrans.CurrentRow.Cells["Amount"].Value + ""));///"Text at position 30,340."
                                cb.SetTextMatrix(300, 270);
                                cb.ShowText(string.Format("คงเหลือ/Balance         {0}", bal.ToString("###,###,##0.##")));//"Text at position 300,340."

                                double TotalAmount = 0;
                                double UsedAmount = 0;
                                double PriceAfterDis = 0;
                          
                                
                                TotalAmount = dataGridViewSelectList.CurrentRow.Cells["Total"].Value + "" == "" ? 0 : Convert.ToDouble((dataGridViewSelectList.CurrentRow.Cells["Total"].Value + "").Replace(",",""));
                                UsedAmount = dgvUsedTrans.CurrentRow.Cells["AmountBalance"].Value + "" == "" ? 0 : Convert.ToDouble((dgvUsedTrans.CurrentRow.Cells["AmountBalance"].Value + "").Replace(",", ""));
                                PriceAfterDis = dataGridViewSelectList.CurrentRow.Cells["PriceTotal"].Value + "" == "" ? 0 : Convert.ToDouble((dataGridViewSelectList.CurrentRow.Cells["PriceTotal"].Value + "").Replace(",", ""));

                                if (ProCreditType == false)
                                    ProCredit = ((PriceAfterDis / TotalAmount) * UsedAmount);
                                //else 
                                //    ProCredit = ProCredit - SumPriceUsed;

                               
                                cb.SetTextMatrix(30, 250);
                                cb.ShowText(string.Format("วงเงินคงเหลือ/Balance(THB)      {0}", ProCredit.ToString("###,###,###,##0.00")));///"Text at position 30,340."
                                
                                
                                cb.SetFontAndSize(bf, 16);
                                cb.SetTextMatrix(30, 230);
                                cb.ShowText(string.Format("วันที่ {0}   อ้างอิงใบยา/Ref.MO {1}   ใช้บริการ/Branch {2}", dgvUsedTrans.Rows[e.RowIndex].Cells["DateOfUse"].Value + "", dgvUsedTrans.Rows[e.RowIndex].Cells["RefMO"].Value + "", dgvUsedTrans.Rows[e.RowIndex].Cells["Branch"].Value + ""));///"Text at position 30,340."
                                ///
                                //===============Line
                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(30, 80);
                                cb.ShowText("..........................................................................................................................................................................................................................................................................................................................");///"Text at position 30,340."
                                // we tell the contentByte, we've finished drawing text


                                cb.SetFontAndSize(bf, 14);
                                cb.SetTextMatrix(420, 40);
                                cb.ShowText(string.Format("{0}", SONo));
                                cb.SetFontAndSize(bf, 13);
                                cb.SetTextMatrix(420, 30);
                                cb.ShowText(string.Format("{0}", VN));

                                cb.SetFontAndSize(bf, 14);
                                cb.SetTextMatrix(420, 15);
                                cb.ShowText(string.Format("{0}  {1}",Userinfo.TName + " " + Userinfo.TSurname,DateTime.Now.ToString("yyyy/MM/dd HH:mm")));///"Text at position 30,340."

                                //==========================End TExt==========================

                                cb.EndText();

                                doc.Close();
                                //writer.SetPdfVersion(PdfWriter.PDF_VERSION_1_5);


                                writer.CompressionLevel = 20;// PdfStream.BEST_COMPRESSION;
                                writer.SetFullCompression();


                            }
                        }
                    //}
                    //frmCustomerLicence frm = new frmCustomerLicence();
                    //frm.CN = CN;// dgvUsedTrans.Rows[e.RowIndex].Cells["CN_USED"].Value + "";
                    //frm.VN = VN;
                    //frm.ListOrder = dataGridViewSelectList.CurrentRow.Cells["ListOrder"].Value + "";
                    //frm.MS_Code = UserMS_Code;// dataGridViewSelectList.Rows[e.RowIndex].Cells["Code"].Value + "";
                    //frm.SupplieName = dataGridViewSelectList.CurrentRow.Cells["Name"].Value + "";
                    //frm.AmountTotal = dataGridViewSelectList.CurrentRow.Cells["Total"].Value + "";
                    //frm.AmountUsed = dataGridViewSelectList.CurrentRow.Cells["Used"].Value + "";
                    //frm.AmountBalance = dataGridViewSelectList.CurrentRow.Cells["Balance"].Value + "";
                    //frm.CurrentUsed = dgvUsedTrans.CurrentRow.Cells["Amount"].Value + "";
                    //frm.TabName = dataGridViewSelectList.CurrentRow.Cells["Tab"].Value + "";
                    //frm.RefMO = dgvUsedTrans.Rows[e.RowIndex].Cells["RefMO"].Value + "";
                    //frm.CustomerName = txtCustomerName.Text;
                    //frm.ReMark = dgvUsedTrans.Rows[e.RowIndex].Cells["Remark"].Value + "";
                    //frm.MUT = dgvUsedTrans.Rows[e.RowIndex].Cells["Id"].Value + "";
                    //frm.BranchName = dgvUsedTrans.Rows[e.RowIndex].Cells["Branch"].Value + "";
                    //frm.DateUsed = dgvUsedTrans.Rows[e.RowIndex].Cells["DateOfUse"].Value + "";

                    //frm.LicenceFullPath = saveFullPath;

                    //frm.ShowDialog();
                    if (File.Exists(FullPath))
                    {

                        Process.Start(FullPath);
                        Process[] _proceses = null;
                        _proceses = Process.GetProcesses();
                        bool ISClose = true;
                        if (ISPreview == false)
                        {
                            while (ISClose)
                            {
                                ISClose = false;
                                foreach (Process proces in _proceses)
                                {
                                    if (proces.ProcessName.Contains("Xodo"))
                                    {
                                        ISClose = true;
                                        //Thread.Sleep(10);
                                        Application.DoEvents();
                                    }
                                }
                                Application.DoEvents();
                                _proceses = Process.GetProcesses();
                            }
                            FileInfo f = new FileInfo(FullPath);
                            bool sav = false;
                            if (f.Length > 0)
                            {
                                Application.DoEvents();
                                sav = DerClass.DerUtility.SaveImage(FullPath, remote_path, filename);
                            }
                            this.BringToFront();
                            if (sav)
                            {
                                MessageBox.Show("Save complete.");
                            }
                            else MessageBox.Show("Save fail.");
                        }
                    }
                }
                else if (e.ColumnIndex == dgvUsedTrans.Columns["btnFileScan"].Index)
                {
                    string filename = string.Format("{0}_{1}_{2}_{3}.pdf", CN, VN.Replace("-", "_"), UserMS_Code, dgvUsedTrans.Rows[e.RowIndex].Cells["Id"].Value + "");
                    string path = string.Format(@"{0}\Customers\{1}\", Application.StartupPath, CN);
                    string remote_path = string.Format(@"\Customers\{0}\CustomersSign\", CN);
                    if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                    string saveFullPath = path + filename;
                    //bmp.Save(saveFullPath);

                    if (DerClass.DerUtility.DownLoadImage(saveFullPath, remote_path, filename))
                    {

                    }
                    else //new
                    {
                        saveFullPath = "";
                    }

                    popAddFileScan frm = new popAddFileScan();
                    frm.CN = dgvUsedTrans.Rows[e.RowIndex].Cells["CN_USED"].Value + "";
                    //frm.ListOrder = dataGridViewSelectList.CurrentRow.Cells["ListOrder"].Value + "";
                    //frm.MS_Code = UserMS_Code;// dataGridViewSelectList.Rows[e.RowIndex].Cells["Code"].Value + "";
                    //frm.SupplieName = dataGridViewSelectList.CurrentRow.Cells["Name"].Value + "";
                    //frm.AmountTotal = dataGridViewSelectList.CurrentRow.Cells["Total"].Value + "";
                    //frm.AmountUsed = dataGridViewSelectList.CurrentRow.Cells["Used"].Value + "";
                    //frm.AmountBalance = dataGridViewSelectList.CurrentRow.Cells["Balance"].Value + "";
                    //frm.CurrentUsed = dgvUsedTrans.CurrentRow.Cells["Amount"].Value + "";
                    //frm.TabName = dataGridViewSelectList.CurrentRow.Cells["Tab"].Value + "";
                    //frm.RefMO = dgvUsedTrans.Rows[e.RowIndex].Cells["RefMO"].Value + "";
                    //frm.CustomerName = txtCustomerName.Text;
                    //frm.ReMark = dgvUsedTrans.Rows[e.RowIndex].Cells["Remark"].Value + "";
                    frm.UseTransId = dgvUsedTrans.Rows[e.RowIndex].Cells["ID"].Value + "";
                    //frm.BranchName = dgvUsedTrans.Rows[e.RowIndex].Cells["Branch"].Value + "";
                    //frm.DateUsed = dgvUsedTrans.Rows[e.RowIndex].Cells["DateOfUse"].Value + "";

                    //frm.LicenceFullPath = saveFullPath;

                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveCheckCourse_Click(object sender, EventArgs e)
        {
            try
            {
                List<MedicalOrderUseTrans> lsItem = new List<MedicalOrderUseTrans>();
                foreach (DataGridViewRow item in dataGridViewSelectList.Rows)
                {
                        MedicalOrderUseTrans useInfo = new Entity.MedicalOrderUseTrans();
                        useInfo.MS_Code = item.Cells["Code"].Value + "";
                        useInfo.ListOrder = item.Cells["ListOrder"].Value + "";
                        useInfo.VN = VN;
                        useInfo.FlagUse = item.Cells["ChkFlagUse"].Value + "" == "True" ? "Y" : "N";
                        lsItem.Add(useInfo);
                }
                var intStatus = new Business.MedicalOrderUseTrans().UpdateMedicalCheckCouse(lsItem.ToArray());
                MessageBox.Show("บันทึกเรียบร้อยแล้ว");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FilterList()
        {
            try
            {
                if (txtFilter.Text.Trim().Length <= 0)
                {
                    foreach (DataGridViewRow item in dataGridViewSelectList.Rows)
                    {
                        item.Visible = true;
                    }
                    return;
                }
                string MS_Code1 = "";
                string ListOrder1 = "";
                DataView dv = new DataView(dtRefMOUsed);
                //view.Table = dtRefMOUsed;
                //dv.RowFilter = string.Format("[MS_Name] LIKE '%ต%'", txtFilter.Text, txtFilter.Text);
                dv.RowFilter = string.Format("[RefMO] LIKE '%{0}%' or [MS_Name] LIKE '%{0}%'", txtFilter.Text);
                if (dv.Count > 0)
                {
                    foreach (DataGridViewRow item in dataGridViewSelectList.Rows)
                    {
                        item.Visible = false;
                    }
                    foreach (DataRowView drv in dv)
                    {

                        MS_Code1 = drv["MS_Code"].ToString();
                        ListOrder1 = drv["ListOrder"].ToString();

                        foreach (DataGridViewRow item in dataGridViewSelectList.Rows)
                        {
                            //item.Visible = false;
                            string MS_Code = item.Cells["Code"].Value + "";
                            string ListOrder = item.Cells["ListOrder"].Value + "";
                            if ((MS_Code1 == MS_Code) && (ListOrder1 == ListOrder))
                                item.Visible = true;

                        }
                    }

                }
                else
                {
                    foreach (DataGridViewRow item in dataGridViewSelectList.Rows)
                    {
                        item.Visible = false;
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            FilterList();
        }

        private void dataGridViewSelectList_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                //string ms_code = dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells["Code"].Value + "";
                //string ListOrder = dataGridViewSelectList.Rows[dataGridViewSelectList.CurrentRow.Index].Cells["ListOrder"].Value + "";


                //BindDataUsed(ms_code, ListOrder);
            }
            catch (Exception ex)
            {

            }
        }

        private void dgvUsedTrans_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                
                if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

                    //PopInputCourseCard c = new PopInputCourseCard();
                    //c.CN = CN;
                    //c.CourseCardID = dataGridViewSelectList.Rows[e.RowIndex].Cells["CourseCardID"].Value + "";
                    //c.ShowDialog();
                PopMedicalUsed obj = new PopMedicalUsed();
                //obj.CourseCardID = c.CourseCardID;


                    obj.StartPosition = FormStartPosition.CenterScreen;
                    obj.BackColor = System.Drawing.Color.FromArgb(255, 230, 217);
                    obj.CN = CN;
                    obj.VN = VN;
                    obj.Sono = SONo;
                    obj.ListOrder = dataGridViewSelectList.Rows[CurrentRowIndex].Cells["ListOrder"].Value + "";
                    obj.EN_COMS1 = dataGridViewSelectList.Rows[CurrentRowIndex].Cells["EN_COMS1"].Value + "";

                    obj.MS_Code = dataGridViewSelectList.Rows[CurrentRowIndex].Cells["Code"].Value + "";
                    obj.SupplieName = dataGridViewSelectList.Rows[CurrentRowIndex].Cells["Name"].Value + "";
                    obj.AmountTotal = dataGridViewSelectList.Rows[CurrentRowIndex].Cells["Total"].Value + "";
                    obj.Amounttotal = Convert.ToDecimal((dataGridViewSelectList.Rows[CurrentRowIndex].Cells["Total"].Value + "").Replace(",", ""));
                    obj.AmountUsed = dataGridViewSelectList.Rows[CurrentRowIndex].Cells["Used"].Value + "";
                    obj.AmountBalance = dataGridViewSelectList.Rows[CurrentRowIndex].Cells["Balance"].Value + "";
                    obj.PriceAfterDis = dataGridViewSelectList.Rows[CurrentRowIndex].Cells["PriceTotal"].Value + "" == "" ? 0 : Convert.ToDecimal(dataGridViewSelectList.Rows[CurrentRowIndex].Cells["PriceTotal"].Value + "");
                    obj.TabName = dataGridViewSelectList.CurrentRow.Cells["Tab"].Value + "";
                    obj.CustomerName = txtCustomerName.Text;
                    obj.ExpireDate = dataGridViewSelectList.Rows[CurrentRowIndex].Cells["ExpireDate"].Value + "";
                    obj.FeeRate = dataGridViewSelectList.Rows[CurrentRowIndex].Cells["FeeRate"].Value + "" == "" ? 0 : Convert.ToDecimal(dataGridViewSelectList.Rows[CurrentRowIndex].Cells["FeeRate"].Value + "");
                    obj.FeeRate2 = dataGridViewSelectList.Rows[CurrentRowIndex].Cells["FeeRate2"].Value + "" == "" ? 0 : Convert.ToDecimal(dataGridViewSelectList.Rows[CurrentRowIndex].Cells["FeeRate2"].Value + "");
                    obj.ParentForm = this;
                    obj.MutID=dgvUsedTrans.Rows[e.RowIndex].Cells["Id"].Value + "";
                    obj.ShowDialog();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void FilterForSOT(string c,string list)
        {
            try
            {
                
                    foreach (DataGridViewRow item in dataGridViewSelectList.Rows)
                    {
                        item.Visible = false;
                    }
                  
                        foreach (DataGridViewRow item in dataGridViewSelectList.Rows)
                        {

                            if ((item.Cells["Code"].Value + "" == c) && (item.Cells["ListOrder"].Value + "" == list))
                            {
                                item.Visible = true;
                                item.Selected=true;
                            }
                        }
                        
                        BindDataUsed(c, ListOrder);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvUsedTrans_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvUsedTrans.Columns["PrintCard"].Index || e.ColumnIndex == dgvUsedTrans.Columns["PrintList"].Index)
                {
                    //if(e.RowIndex==0)UpdateExpireDate(e.RowIndex);
                    //Print Course Card
                    string CO = dgvUsedTrans.Rows[e.RowIndex].Cells["Id"].Value + "";

                    DataGridViewCheckBoxCell ch1 = (DataGridViewCheckBoxCell)dgvUsedTrans.Rows[e.RowIndex].Cells["Printed"];
                    //if (ch1.Value.ToString().ToLower() != "true" && (Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN))
                    //{
                    if (e.ColumnIndex == dgvUsedTrans.Columns["PrintList"].Index)
                        PrintCourseCardList(CO, e.RowIndex);
                    else
                        PrintCourseCard(CO, e.RowIndex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        private void UpdateExpireDate(int row)
        {
            try
            {
                  MedicalOrderUseTrans c = new Entity.MedicalOrderUseTrans();
                c.CN = CN;
                c.Sono = SONo;
                c.VN = VN;
                c.MS_Code = MS_Code;
                c.ListOrder = ListOrder;
                //c.CreateDate = SODate;
                //c.CourseCardID = CourseCardID;
                //c.CreateBy = Entity.Userinfo.EN;
                //c.BranchId = BranchID;
                //c.DateOfUse = Convert.ToDateTime(dgvUsedTrans.Rows[row].Cells["DateOfUse"].Value + "");

                    var intStatus = new Business.MedicalOrderUseTrans().UpdateExpireCourseCard(c);
                    BindDataUsed(MS_Code, ListOrder);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
