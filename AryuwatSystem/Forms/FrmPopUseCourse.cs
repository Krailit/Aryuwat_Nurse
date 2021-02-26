using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AryuwatSystem.DerClass;
using Entity;
using System.Drawing.Imaging;

namespace AryuwatSystem.Forms
{
    public partial class FrmPopUseCourse : Form
    {
        public FrmPopUseCourse()
        {
            InitializeComponent();
            dateTimePickerCreate.CustomFormat = "dd-MM-yyyy";
            comboBoxCommission1.MouseWheel += new MouseEventHandler(comboBoxCommission1_MouseWheel);
        }
        void comboBoxCommission1_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        int? intStatus = 0;
        private List<Entity.MedicalOrderUseTrans> listUse = new List<MedicalOrderUseTrans>();
        private Entity.MedicalOrderUseTrans useInfo;
        //public Entity.MedicalOrderUseTrans info;
        public string CustomerName { get; set; }
        public string AmountTotal { get; set; }//จำนวนทั้งหมด
        public string AmountUsed { get; set; }//จำนวนที่ใช้
        public decimal Amounttotal = 0;
        public string AmountBalance { get; set; }//คงเหลือ
        public string SupplieName { get; set; }//ชื่อรายการ
        public string CN { get; set; }
        public string EN_COMS1 { get; set; }
        public string VN { get; set; }
        public string Sono { get; set; }
        public string MS_Code { get; set; }
        public string ListOrder { get; set; }
        public decimal FeeRate { get; set; }
        public decimal FeeRate2 { get; set; }
        public decimal PriceAfterDis { get; set; }
        
        public string CO { get; set; }
        
        public string ExpireDate { get; set; }
        private string useTransId;
        private DataTable dtTmp;
        private List<Entity.MedicalStuff> MedicalStuffs;
        private Entity.MedicalStuff stuffInfo;
        public string TabName { get; set; }
        private string statusSave = "INSERT";
        public Form ParentForm { get; set; }
        public string EN_REQ { get; set; }
        public string EN_Helper { get; set; }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private string GetCOnumber()
        {
            string co = "";
            try
            {
                co=CO = AryuwatSystem.Data.UtilityBackEnd.GenMaxSeqnoValues("CO-");
            }
            catch (Exception ex)
            {
              
            }
            return co;
        }
        private void bindSale()
        {
            try
            {
                AutoCompleteStringCollection colValues = new AutoCompleteStringCollection();
                var info = new Entity.Personnel();
                info.PersonnelType = "11";
                info.QueryType = "SEARCHCOM";
                DataTable dt = new Business.Personnel().SelectCustomerPaging(info).Tables[0];
                DataRow dr= dt.NewRow();
                dr["EN"] = "";
                dr["FullNameThai"] = "--ไม่ระบุ--";
                dt.Rows.InsertAt(dr,0);

                foreach (DataRow row in dt.Rows)
                {
                    colValues.Add(row["FullNameThai"].ToString());
                }

                comboBoxCommission1.Items.Clear();
                comboBoxCommission1.DataSource = dt;
                comboBoxCommission1.ValueMember = "EN";
                comboBoxCommission1.DisplayMember = "FullNameThai";
                comboBoxCommission1.SelectedValue = "";// Entity.Userinfo.EN;
                comboBoxCommission1.AutoCompleteCustomSource = colValues;

                comboBoxCommission1.SelectedValue = EN_COMS1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FrmPopUseCourse_Load(object sender, EventArgs e)
        {

            btnToJob.Visible = Statics.GroupPermission.ToLower().Contains("jobcost");
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBoxREQ, "Request staff.");

            lbREQ.Text = "";
            dateTimePickerCreate.Value = DateTime.Now;
            SetColumns();
            bindSale();
            BindDataStaffList();
            lblAmountUsed.Text = AmountUsed;
            lblCustomerName.Text  = CustomerName+"     CN : "+CN;
            lblSupplie.Text = SupplieName;
            lblTotal.Text = AmountTotal;
            //if (AmountBalance.Split(':').Length > 1) AmountBalance = AmountBalance.Split(':')[0];
            lblBalance.Text = AmountBalance;
            labelExpire.Text =labelExpire.Text+ ExpireDate;
            lbCO.Text = GetCOnumber();// string.Format("CO{0}-{1}-{2}-{3}-{4}", "001", VN, MS_Code, AmountTotal, AmountUsed);
            //BindCboBranch();
            cboBranch.setBranchValue("");
            BindData();

            //SumAmountUse();
        }
        //private void SumAmountUse()
        //{
        //    Amounttotal = dgvUsedTrans.Rows.Cast<DataGridViewRow>()
        //           .Where(r => r.Cells["Amount"].Value + "" != "")
        //           .Sum(t => Convert.ToDouble(t.Cells["Amount"].Value));

        //    AmountUsed = Amounttotal.ToString("###,###,###.##");
        //    AmountBalance = (Convert.ToDouble(AmountTotal) - Amounttotal).ToString("###,###,###.##");
            
        //    lblAmountUsed.Text = AmountUsed;
        //    lblBalance.Text = AmountBalance;
        //}
        private void SetColumns()
        {
            DerUtility.SetPropertyDgv(dgvUsedTrans);
            dgvUsedTrans.Columns.Add("Id", "Id");
            dgvUsedTrans.Columns.Add("Amount", "จำนวนที่ใช้/Use");
            dgvUsedTrans.Columns.Add("DateOfUse", "วันที่ใช้/Date");
            dgvUsedTrans.Columns.Add("CN_USED", "CN_USED");
            dgvUsedTrans.Columns.Add("CN_USEDFULLNAME", "ผู้ใช้/Customer");
            dgvUsedTrans.Columns.Add("CO", "CO");
            dgvUsedTrans.Columns.Add("RefMO", "Ref.MO");
            DataGridViewImageColumn colStaff = new DataGridViewImageColumn();
            {
                colStaff.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                colStaff.CellTemplate = new DataGridViewImageCell();
                colStaff.HeaderText = "Staff";
                colStaff.Name = "BtnStaff";
            }
            dgvUsedTrans.Columns.Add(colStaff);
            DataGridViewImageColumn colDel = new DataGridViewImageColumn();
            {
                colDel.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                colDel.CellTemplate = new DataGridViewImageCell();
                colDel.HeaderText = "Delete";
                colDel.Name = "BtnDelete";
            }
            dgvUsedTrans.Columns.Add(colDel);

            dgvUsedTrans.Columns["Id"].Visible = false;
            dgvUsedTrans.Columns["Amount"].Width = 80;
            dgvUsedTrans.Columns["DateOfUse"].Width = 120;


            dgvUsedTrans.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvUsedTrans.Columns["DateOfUse"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

              dgvUsedTrans.Columns.Add("ListOrder", "ListOrder");
              dgvUsedTrans.Columns.Add("Remark", "Remark");
              dgvUsedTrans.Columns.Add("swap", "swap");
              dgvUsedTrans.Columns.Add("BranchId", "Branch");
              dgvUsedTrans.Columns.Add("BranchName", "Branch");
              dgvUsedTrans.Columns.Add("EN_REQ", "EN_REQ");
              dgvUsedTrans.Columns.Add("Name_REQ", "Name_REQ");
              dgvUsedTrans.Columns.Add("EN_Helper", "Helper");
            
              //dgvUsedTrans.Columns["BranchId"].Visible = false;
            
              SetColDgvStaff();
        }

        private void BindDataStaffList()
        {
            try
            {
                DerUtility.MouseOn(this);
                dgvStaff.Rows.Clear();

                dtTmp = new Business.StuffCommission().SelectStuffCommissionByType(TabName).Tables[0];
                foreach (DataRowView item in dtTmp.DefaultView)
                {
                    string empId = "";
                    string empName = "";
                    //foreach (Entity.MedicalStuff medicalStuff in MedicalStuffs)
                    //{
                    //    if(item["ID"]+""==medicalStuff.Position_ID && medicalStuff.MS_Code == MS_Code && medicalStuff.SectionStuff == SectionStaff)
                    //    {
                    //        if (empId != "") empId += ",";
                    //        empId += medicalStuff.EmployeeId;
                    //        if (empName != "") empName += ",";
                    //        empName += medicalStuff.FullNameCustomer;
                    //    }
                    //}
                    object[] myItems = { 
                                          item["Position_ID"] + "",
                                          item["Position_Name"] + "",
                                          empName,//Staff Name
                                          empId,//Staff Id
                                          imageList1.Images[0],
                                          imageList1.Images[1]
                                      };
                    dgvStaff.Rows.Add(myItems);
                }
                //if (MedicalStuffs.Count > 0)
                //{
                //    //var itemToRemove = StuffAesthetic.Single(r => r.MS_Code == MS_Code);
                //    //StuffAesthetic.Remove(itemToRemove);
                //    MedicalStuffs.RemoveAll(x => x.MS_Code == MS_Code);
                //}
                DerUtility.MouseOff(this);
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
        }

        private void BindDataStaffList(DataTable dt)
        {
            try
            {
                DerUtility.MouseOn(this);
                dgvStaff.Rows.Clear();

                dtTmp = new Business.StuffCommission().SelectStuffCommissionByType(TabName).Tables[0];
                foreach (DataRowView item in dtTmp.DefaultView)
                {
                    string empId = "";
                    string empName = "";
                    foreach (DataRowView  dr in dt.DefaultView)
                    {
                        if (item["Position_ID"] + "" == dr["Position_ID"] + "" && dr["MS_Code"] + "" == MS_Code)//&& medicalStuff.SectionStuff == SectionStaff
                        {
                            if (empId != "") empId += ",";
                            empId += dr["EmployeeId"]+"";
                            if (empName != "") empName += ",";
                            empName += dr["FullNameThai"] + "" == "" ? dr["FullNameEng"] + "" : dr["FullNameThai"] + "";
                        }
                    }
                    object[] myItems = { 
                                          item["Position_ID"] + "",
                                          item["Position_Name"] + "",
                                          empName,//Staff Name
                                          empId,//Staff Id
                                          imageList1.Images[0],
                                          imageList1.Images[1]
                                      };
                    dgvStaff.Rows.Add(myItems);
                }
                //if (MedicalStuffs.Count > 0)
                //{
                //    //var itemToRemove = StuffAesthetic.Single(r => r.MS_Code == MS_Code);
                //    //StuffAesthetic.Remove(itemToRemove);
                //    MedicalStuffs.RemoveAll(x => x.MS_Code == MS_Code);
                //}
                DerUtility.MouseOff(this);
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
        }

        private void SetColDgvStaff()
        {
            //DatagridView Stafff
            DerUtility.SetPropertyDgv(dgvStaff);
            dgvStaff.Columns.Add("Position_ID", "Position_ID");
            dgvStaff.Columns.Add("Position", "ตำแหน่ง/");
            dgvStaff.Columns.Add("StaffName", "ชื่อผู้ดำเนินการ/Operator");
            dgvStaff.Columns.Add("EmployeeId", "EmployeeId");

            dgvStaff.Columns["Position_ID"].Visible = false;
            dgvStaff.Columns["Position"].Width = 200;
            dgvStaff.Columns["EmployeeId"].Visible = false;
            dgvStaff.Columns["Position"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvStaff.Columns["StaffName"].Width = 300;
            DataGridViewImageColumn colStaff = new DataGridViewImageColumn();
            {
                colStaff.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                colStaff.CellTemplate = new DataGridViewImageCell();
            }
            dgvStaff.Columns.Add(colStaff);
            DataGridViewImageColumn colDel = new DataGridViewImageColumn();
            {
                colDel.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                colDel.CellTemplate = new DataGridViewImageCell();
            }
            dgvStaff.Columns.Add(colDel);

            foreach (DataGridViewColumn dgvCol in dgvStaff.Columns)
            {
                dgvCol.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void BindData()
        {
            try
            {
                DerUtility.MouseOn(this);
                dgvUsedTrans.Rows.Clear();
                Entity.MedicalOrderUseTrans info = new MedicalOrderUseTrans();
                info.CN = CN;
                info.VN = VN;
                info.MS_Code = MS_Code;
                info.ListOrder = ListOrder;

                if (!string.IsNullOrEmpty(info.VN))
                {
                    dtTmp = new Business.MedicalOrderUseTrans().SelectMedicalOrderUseTransById(info).Tables[0];
                    foreach (DataRowView item in dtTmp.DefaultView)
                    {
                        double AmountU = Convert.ToDouble(string.IsNullOrEmpty(item["AmountOfUse"] + "") ? "1" : item["AmountOfUse"] + "".Replace(",", ""));
                        object[] myItems = {
                                               item["ID"] + "",
                                               AmountU.ToString("###,###,###.##"),
                                               item["DateOfUse"] + "" != ""? DateTime.Parse(item["DateOfUse"] + "").Date.ToShortDateString():"",
                                               item["CN_USED"]+"",
                                               item["FullNameThai"]+"" != ""?item["FullNameThai"]+"":item["FullNameEng"]+"",
                                                item["CO"]+"",
                                                item["RefMO"]+"",
                                               imageList1.Images[2],
                                               imageList1.Images[3],
                                                item["ListOrder"]+"",
                                                item["Remark"]+"",
                                                item["swap"]+"",
                                                item["BranchId"]+"",
                                                item["BranchName"]+"",
                                                item["EN_REQ"]+"",
                                                item["Name_REQ"]+"",
                                                item["EN_Helper"]+""
                                                
                                           };
                        dgvUsedTrans.Rows.Add(myItems);
                    }
                    //foreach (Entity.MedicalOrderUseTrans medicalInfo in MedicalOrderUseTranss)
                    //{
                    //    if (medicalInfo.MS_Code == MS_Code)
                    //    {
                    //        txtUseNew.Text = Convert.ToDouble(medicalInfo.AmountOfUse).ToString("###,##0.00");
                    //    }
                    //}
                    //if (MedicalOrderUseTranss.Count > 0)
                    //{
                    //    //var itemToRemove = StuffAesthetic.Single(r => r.MS_Code == MS_Code);
                    //    //StuffAesthetic.Remove(itemToRemove);
                    //    MedicalOrderUseTranss.RemoveAll(x => x.MS_Code == MS_Code);
                    //}
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
        private void SaveData()
        {
            try 
	        {
                if (!Userinfo.IsAdmin.Contains(Userinfo.EN) && dateTimePickerCreate.Value >= DateTime.Now.AddMonths(1).AddDays(10))
                {
                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, "ไม่สามารถแก้ไขข้อมูลได้เนื่องจาก เกินกำหนดเวลาการตรวจสอบข้อมูล" + Environment.NewLine + "กรุณาติดต่อผู้ดูแลระบบ");
                    return;
                }

                listUse = new List<MedicalOrderUseTrans>();
                //MessageBox.Show(dateTimePickerCreate.Value,;
                //DialogResult result3=MessageBox.Show( "Date used =>" + dateTimePickerCreate.Value.ToString("dd-MM-yyyy"),"Confirm date ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                popAlert pop = new popAlert();
                pop.txtTitle = "";
                pop.txtShow = string.Format("Date used => {0}{1}({2})", dateTimePickerCreate.Value.ToString("dd-MM-yyyy"), Environment.NewLine, dateTimePickerCreate.Value.ToLongDateString());
                //DialogResult result3=pop.ShowDialog();
                pop.ShowDialog();
                if (pop.ShowDialog() != DialogResult.Yes) return;
                if (txtUseNew.Text.Trim() == "" || Convert.ToDecimal(txtUseNew.Text) == 0 || txtRefMO.Text.Trim() == "" || cboBranch.BranchId == "")
                {
                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "กรุณาระบุจำนวนที่ใช้,เลขอ้างอิงใบยา,เลือกสาขาที่ใช้คอร์ส,ผู้ดูแล");
                    txtUseNew.Focus();
                    return;
                }

                if (statusSave == "INSERT")
                {
                  
                    if (decimal.Parse(txtUseNew.Text.Trim()) > decimal.Parse(lblBalance.Text.Trim()))
                    {
                        DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation,
                                       "จำนวนที่ใช้ \"มากกว่า\" จำนวนคงเหลือ กรุณาตรวจสอบอีกครั้ง");
                        txtUseNew.Focus();
                        return;
                    }

                }
                //string[] arrCode = MS_Code.Split(':');
                //for (int j = 0; j < arrCode.Length ; j++)
                //{
                useInfo = new Entity.MedicalOrderUseTrans();
                //info = new MedicalOrderUseTrans();
                useInfo.Id = useTransId;
                useInfo.MS_Code = MS_Code;
                useInfo.ListOrder = ListOrder;
                useInfo.CN = CN;
                useInfo.VN = VN;
                useInfo.Sono = Sono;
                useInfo.CreateBy = Userinfo.EN;
                useInfo.UpdateBy = Userinfo.EN;
                useInfo.AmountOfUse = decimal.Parse(txtUseNew.Text.Trim());
                useInfo.AmountTotal = Amounttotal;
                useInfo.AmountBalance = Convert.ToDecimal(AmountBalance.Replace(",", "")) == 0 ? 0 : Convert.ToDecimal(AmountBalance.Replace(",", "")) - decimal.Parse(txtUseNew.Text.Trim());
                useInfo.DateOfUse = dateTimePickerCreate.Value;
                useInfo.CN_USED = txtUsedCN.Text == "" ? CN : txtUsedCN.Text;
                useInfo.CO = lbCO.Text;
                useInfo.RefMO = txtRefMO.Text.Trim();
                useInfo.Remark = txtRemark.Text;
                useInfo.FeeRate = FeeRate;
                useInfo.FeeRate2 = FeeRate2;
                useInfo.PriceAfterDis = PriceAfterDis;
                useInfo.EN_REQ = EN_REQ;
                useInfo.EN_Helper = comboBoxCommission1.SelectedValue+"";

                useInfo.swap = checkBoxSwap.Checked ? "Y" : "";

                useInfo.BranchId = cboBranch.BranchId;

                MedicalStuffs = new List<MedicalStuff>();

                foreach (DataGridViewRow row in dgvStaff.Rows)
                {
                    if (!string.IsNullOrEmpty(row.Cells["EmployeeId"].Value + ""))
                    {
                        string[] arEmpId = row.Cells["EmployeeId"].Value.ToString().Split(',');
                        string[] arEmpName = row.Cells["StaffName"].Value.ToString().Split(',');
                        for (int i = 0; i < arEmpId.Length; i++)
                        {
                            stuffInfo = new MedicalStuff();
                            stuffInfo.Position_ID = row.Cells["Position_ID"].Value + "";
                            stuffInfo.EmployeeId = arEmpId[i];
                            stuffInfo.MS_Code = MS_Code;
                            stuffInfo.FullNameCustomer = arEmpName[i];
                            stuffInfo.SectionStuff = TabName;
                            stuffInfo.MergStatus = MS_Code;
                            stuffInfo.VN = VN;

                            MedicalStuffs.Add(stuffInfo);
                        }
                    }
                }
                useInfo.MedicalStuffInfo = MedicalStuffs.ToArray();
                useInfo.MedicalOrderStatus = "1";//Pending
                listUse.Add(useInfo);
                //useInfo .MedicalStuffInfo = 
                //midInfo.MedicalStuffInfo = MedicalStuffs.ToArray();
                //} 

                if (statusSave == "INSERT")
                {
                    intStatus = new Business.MedicalOrderUseTrans().InsertMedicalUseTrans(listUse.ToArray());

                }
                else
                {
                    intStatus = new Business.MedicalOrderUseTrans().UpdateMedicalUseTrans(listUse.ToArray());
                }
                if (intStatus != -1)
                {
                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "บันทึกข้อมูลเรียบร้อยแล้ว");
                    //BindData();
                    txtUseNew.Text = "";
                    txtRefMO.Text = "";
                    btnSave.Text = "เพิ่ม";
                    statusSave = "INSERT";
                    ((FrmMedicalUseList)ParentForm).BindData();
                    //BindDataStaffList();
                    //SumAmountUse();
                    Close();
                }
	        }
	        catch (Exception ex)
	        {
                MessageBox.Show(ex.Message);
	        }
        }
        List<string> lsEmp = new List<string>();
        private void dgvStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex  == 4)
            {
                PopEmpSearch obj = new PopEmpSearch();
                obj.StartPosition = FormStartPosition.CenterScreen;
                obj.WindowState = FormWindowState.Normal;
                obj.BackColor = Color.FromArgb(255, 230, 217);
                obj.StaffsName = dgvStaff.Rows[e.RowIndex].Cells[2].Value + "";
                obj.EmployeeId = dgvStaff.Rows[e.RowIndex].Cells["EmployeeId"].Value + "";
                obj.ShowDialog();
                if (obj.StaffsName != "")
                {
                    string[] arremp = obj.StaffsName.Split(',');
                    foreach (string item in arremp)
                    {
                        if ((dgvStaff.Rows[e.RowIndex].Cells[2].Value + "").Contains(item)) continue;
                        dgvStaff.Rows[e.RowIndex].Cells[2].Value = dgvStaff.Rows[e.RowIndex].Cells[2].Value+""!=""?dgvStaff.Rows[e.RowIndex].Cells[2].Value + "," + item:dgvStaff.Rows[e.RowIndex].Cells[2].Value+"" + item;
                    }
                    
                }
                if (obj.EmployeeId != "")
                {
                    string[] arremp = obj.EmployeeId.Split(',');
                    foreach (string item in arremp)
                    {
                        if ((dgvStaff.Rows[e.RowIndex].Cells["EmployeeId"].Value + "").Contains(item)) continue;
                        dgvStaff.Rows[e.RowIndex].Cells["EmployeeId"].Value = dgvStaff.Rows[e.RowIndex].Cells["EmployeeId"].Value + "" != "" ? dgvStaff.Rows[e.RowIndex].Cells["EmployeeId"].Value + "," + item : dgvStaff.Rows[e.RowIndex].Cells["EmployeeId"].Value+item;
                    }
                    
                }
            }
            else if (e.ColumnIndex == 5)
            {
                dgvStaff.Rows[e.RowIndex].Cells[2].Value = "";
                dgvStaff.Rows[e.RowIndex].Cells["EmployeeId"].Value = "";
            }
        }

        private void dgvUsedTrans_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        private void dgvStaff_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUseNew.Text = "";
            BindDataStaffList();
            btnSave.Text = "Save";
             statusSave = "INSERT";
            txtUseNew.Enabled = true;
        }

        private void dgvUsedTrans_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

          
            if (e.ColumnIndex == dgvUsedTrans.Columns["BtnStaff"].Index)
            {
                string id=dgvUsedTrans.Rows[e.RowIndex].Cells["Id"].Value + "";
                DataSet dsSurgeryFee = new Business.MedicalOrderUseTrans().SelectSavedJobCostById("SELECTSAVEDJOBCOSTForEdit", VN, MS_Code, ListOrder, id);
                if (dsSurgeryFee.Tables[0].Rows.Count > 0 && !Userinfo.IsAdmin.Contains(Userinfo.EN) && !Userinfo.IS_ADMIN_JOBCOST.Contains(Userinfo.EN))
                {
                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, "ไม่สามารถแก้ไขข้อมูลได้เนื่องจาก ได้บันทึกค่ามือและค่าแพทย์ไปแล้ว" + Environment.NewLine + "กรุณาติดต่อผู้ดูแลระบบ");
                    return;
                }
                txtUseNew.Text = dgvUsedTrans.Rows[e.RowIndex].Cells["Amount"].Value + "";
                AmountBalance=(Convert.ToDecimal(AmountBalance.Replace(",", "")) + decimal.Parse(txtUseNew.Text.Trim())).ToString("###,###,###.##");
                Entity.MedicalStuff info = new MedicalStuff();
                info.VN = VN;
                info.MS_Code = MS_Code;
                info.ListOrder = dgvUsedTrans.Rows[e.RowIndex].Cells["ListOrder"].Value+"";
                
                info.UseTransId = dgvUsedTrans.Rows[e.RowIndex].Cells["Id"].Value + "";
                txtUsedCN.Text = dgvUsedTrans.Rows[e.RowIndex].Cells["CN_USED"].Value + "";
                txtUsedName.Text = dgvUsedTrans.Rows[e.RowIndex].Cells["CN_USEDFULLNAME"].Value + "";
                txtRemark.Text = dgvUsedTrans.Rows[e.RowIndex].Cells["Remark"].Value + "";
                checkBoxSwap.Checked = dgvUsedTrans.Rows[e.RowIndex].Cells["swap"].Value + "" == "Y";
                EN_REQ = dgvUsedTrans.Rows[e.RowIndex].Cells["EN_REQ"].Value + "";
                lbREQ.Text = dgvUsedTrans.Rows[e.RowIndex].Cells["Name_REQ"].Value + "";
                
                dateTimePickerCreate.Value = dgvUsedTrans.Rows[e.RowIndex].Cells["DateOfUse"].Value + "" == "" ? DateTime.Now : Convert.ToDateTime(dgvUsedTrans.Rows[e.RowIndex].Cells["DateOfUse"].Value + "");

                if (dgvUsedTrans.Rows[e.RowIndex].Cells["BranchId"].Value + "" != "") cboBranch.setBranchValue(dgvUsedTrans.Rows[e.RowIndex].Cells["BranchId"].Value + "");

                comboBoxCommission1.SelectedValue =EN_Helper= dgvUsedTrans.Rows[e.RowIndex].Cells["EN_Helper"].Value + ""; 


                useTransId = info.UseTransId;
                DataTable dt = new Business.MedicalStuff().SelectMedicalStuffById(info).Tables[0];
                BindDataStaffList(dt);
                btnSave.Text = "Update";
                //txtUseNew.Enabled = false;
                statusSave = "UPDATE";

                txtRefMO.Text = dgvUsedTrans.Rows[e.RowIndex].Cells["RefMO"].Value + "";
            }
            if (e.ColumnIndex == dgvUsedTrans.Columns["BtnDelete"].Index)
            {
                string id = dgvUsedTrans.Rows[e.RowIndex].Cells["Id"].Value + "";
                DataSet dsSurgeryFee = new Business.MedicalOrderUseTrans().SelectSavedJobCostById("SELECTSAVEDJOBCOSTForEdit", VN, MS_Code, ListOrder, id);
                if (dsSurgeryFee.Tables[0].Rows.Count > 0 && !Userinfo.IsAdmin.Contains(Userinfo.EN) && !Userinfo.IS_ADMIN_JOBCOST.Contains(Userinfo.EN))
                {
                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, "ไม่สามารถแก้ไขข้อมูลได้เนื่องจาก ได้บันทึกค่ามือและค่าแพทย์ไปแล้ว" + Environment.NewLine + "กรุณาติดต่อผู้ดูแลระบบ");
                    return;
                }
                //if (!Userinfo.IsAdmin.Contains(Userinfo.EN) && dateTimePickerCreate.Value >= DateTime.Now.AddMonths(1).AddDays(10))
                //{
                //    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, "ไม่สามารถแก้ไขข้อมูลได้เนื่องจาก เกินกำหนดเวลาการตรวจสอบข้อมูล" + Environment.NewLine + "กรุณาติดต่อผู้ดูแลระบบ");
                //    return;
                //}
                if (DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirmYesNo, Statics.StrConfirmDelete) == DialogResult.Yes)
                {
                    string useId = dgvUsedTrans.Rows[e.RowIndex].Cells["Id"].Value + "";
                    int? intStatus = new Business.MedicalOrderUseTrans().DeleteMedicalOrderUseTransById(useId, VN, CN, MS_Code, dgvUsedTrans.Rows[e.RowIndex].Cells["ListOrder"].Value + "", Userinfo.EN, dgvUsedTrans.Rows[e.RowIndex].Cells["BranchId"].Value + "");

                    if (intStatus != -1)
                    {
                        DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "ลบข้อมูลเรียบร้อยแล้ว");
                        ((FrmMedicalUseList)ParentForm).BindData();
                        Close();
                    }
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvUsedTrans_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && ((e.ColumnIndex == dgvUsedTrans.Columns["BtnStaff"].Index) || (e.ColumnIndex == dgvUsedTrans.Columns["BtnDelete"].Index)))
            {
                this.Cursor = Cursors.Hand;
            }
            else { Cursor = Cursors.Default; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            popMemberGroup frm = new popMemberGroup();
            frm.UsedForm = true;
            frm.CN = CN ;
            frm.VN = VN;          
            //frm.MS_Code = MS_Code = dataGridViewSelectList.Rows[e.RowIndex].Cells["Code"].Value + "";
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                if (frm.member.Any())
                {
                    txtUsedCN.Text = frm.member[0].CN;
                    txtUsedName.Text = frm.member[0].CN_NAME;
                }
            }
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            Pen p = new Pen(Color.Black, 1);
            gfx.DrawLine(p, 0, 5, 0, e.ClipRectangle.Height - 2);
            gfx.DrawLine(p, 0, 5, 10, 5);
            gfx.DrawLine(p, 80, 5, e.ClipRectangle.Width - 2, 5);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, 5, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2, 0, e.ClipRectangle.Height - 2);  
        }

        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            Pen p = new Pen(Color.Black, 1);
            gfx.DrawLine(p, 0, 5, 0, e.ClipRectangle.Height - 2);
            gfx.DrawLine(p, 0, 5, 10, 5);
            gfx.DrawLine(p, 80, 5, e.ClipRectangle.Width - 2, 5);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, 5, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2, 0, e.ClipRectangle.Height - 2);  
        }

        private void groupBox3_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            Pen p = new Pen(Color.Black, 1);
            gfx.DrawLine(p, 0, 5, 0, e.ClipRectangle.Height - 2);
            gfx.DrawLine(p, 0, 5, 10, 5);
            gfx.DrawLine(p, 0, 5, e.ClipRectangle.Width - 2, 5);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, 5, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2, 0, e.ClipRectangle.Height - 2);  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Use this version to capture the full extended desktop (i.e. multiple screens)

                //Bitmap screenshot = new Bitmap(this.Width,
                //                               this.Height,
                //                               PixelFormat.Format24bppRgb);
                //Graphics screenGraph = Graphics.FromImage(screenshot);
                //screenGraph.CopyFromScreen(this.Location.X,
                //                           this.Location.Y,
                //                           0,
                //                           0,
                //                           this.Size,
                //                           CopyPixelOperation.SourceCopy);

                //screenshot.Save("Screenshot.png", System.Drawing.Imaging.ImageFormat.Png);
                frmCustomerLicence frm = new frmCustomerLicence();
                frm.ShowDialog();
            }
            catch (Exception)
            {


            }
        }

        private void BindCboBranch()
        {
            try
            {
                //DataTable dtBranch = new Business.Branch().SelectBranchAll().Tables[0];
                //cboBranch.DataSource = dtBranch;
                //cboBranch.ValueMember = "BranchID";
                //cboBranch.DisplayMember = "BranchName";
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation,
                               "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }
        }

        private void dateTimePickerCreate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!Userinfo.IsAdmin.Contains(Userinfo.EN))
                {
                    if (dateTimePickerCreate.Value.Month > DateTime.Now.Month || dateTimePickerCreate.Value.Year > DateTime.Now.Year)
                    {
                        if (statusSave == "INSERT")
                        {
                            DateTime date1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, dateTimePickerCreate.Value.Day);
                            dateTimePickerCreate.Value = date1;
                        }
                        //                    dateTimePickerCreate.Value = DateTime.Now.Year;
                    }
                }
            }
            catch (Exception)
            {
                
              
            }
        }

        private void pictureBoxREQ_Click(object sender, EventArgs e)
        {
            try
            {
                PopEmpSearch obj = new PopEmpSearch();
                obj.StartPosition = FormStartPosition.CenterScreen;
                obj.WindowState = FormWindowState.Normal;
                obj.BackColor = Color.FromArgb(255, 230, 217);
                //obj.StaffsName = dgvStaff.Rows[e.RowIndex].Cells[2].Value + "";
                //obj.EmployeeId = dgvStaff.Rows[e.RowIndex].Cells["EmployeeId"].Value + "";
                obj.ShowDialog();
                if (obj.StaffsName+"" != "")
                {
                    lbREQ.Text = "";
                    lbREQ.Text="REQ "+obj.StaffsName;
                    EN_REQ = obj.EmployeeId;
                    string[] arremp = obj.StaffsName.Split(',');
                    //foreach (string item in arremp)
                    //{
                    //    //if ((dgvStaff.Rows[e.RowIndex].Cells[2].Value + "").Contains(item)) continue;
                    //    //dgvStaff.Rows[e.RowIndex].Cells[2].Value = dgvStaff.Rows[e.RowIndex].Cells[2].Value + "" != "" ? dgvStaff.Rows[e.RowIndex].Cells[2].Value + "," + item : dgvStaff.Rows[e.RowIndex].Cells[2].Value + "" + item;
                    //}

                }

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnToJob_Click(object sender, EventArgs e)
        {
            try
            {
                SaveData();
              //  if (intStatus <= 0) return;
               
                 //string vn=dgvData.Rows[rowindex].Cells["VN"].Value + "";
                  //CN = dgvData.Rows[rowindex].Cells["CN"].Value + "";
                 //string SONo=dgvData.Rows[rowindex].Cells["SONo"].Value + "";
                 DataSet dsSurgeryFee = new Business.MedicalOrder().SelectMedicalOrderById(VN,Sono);
                 DataTable dtSurgeryFee = dsSurgeryFee.Tables[1];//.Select("SurgicalFeeNewTab='Y'").CopyToDataTable();
                 //var distinctTable = dtSurgeryFee.DefaultView.ToTable(true, "MergStatus");
            int PHAMACYCount = 0;
            int MSCount = 0;
            int consult = 0;
            //foreach (DataRow row in distinctTable.Rows)
            //{
                //string where = "MergStatus='" + row["MergStatus"] + "'";
                foreach (DataRow dr in dtSurgeryFee.Rows)
                {
                    MSCount++;
                    if (dr["SurgicalFeeTyp"] + "" == "" )//|| dr["SurgicalFeeTyp"] + "" == "PHAMACY")
                    {
                        PHAMACYCount++;
                        continue;
                    }
                    string ms_code = dr["MergStatus"] + "";
                    string section = ms_code.Substring(0, 3);
                    if (section.ToLower() == "cae" || section.ToLower() == "cwe" || section.ToLower() == "csu")
                    {
                        consult++;
                        continue;
                    }
                }
            //}
            if (MSCount == PHAMACYCount || consult == MSCount || (consult + PHAMACYCount) == MSCount)
            {
                MessageBox.Show("PHAMACY OR Consult", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                   
                 Statics.frmSurgicalFeeMain = new FrmSurgicalFeeMain();
                 Statics.frmSurgicalFeeMain.dsSurgeryFee = dsSurgeryFee;
                 Statics.frmSurgicalFeeMain.dtSurgeryFee = dtSurgeryFee;
                 Statics.frmSurgicalFeeMain.VN = VN;
                 Statics.frmSurgicalFeeMain.CN = CN;
                 Statics.frmSurgicalFeeMain.SONo = Sono;
                 
                 Statics.frmSurgicalFeeMain.MS_Code = MS_Code;
                 Statics.frmSurgicalFeeMain.ListOrder = ListOrder;
                 
                 Statics.frmSurgicalFeeMain.BackColor = Color.FromArgb(255, 230, 217);
                 Statics.frmSurgicalFeeMain.Show(Statics.frmMain.dockPanel1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void pictureBoxREQ_MouseHover(object sender, EventArgs e)
        //{
        //    ToolTip tt = new ToolTip();
        //    tt.SetToolTip(this.pictureBoxREQ, "Request.");
        //}


        //private void txtUseNew_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (statusSave == "UPDATE") return;
        //        if((Convert.ToDouble(AmountTotal) - (Amounttotal+Convert.ToDouble(txtUseNew.Text)))<0)
        //        {
        //            MessageBox.Show("ใส่จำนวนการใช้มากกว่า คงเหลือ");
        //            txtUseNew.Text ="0";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show(ex.Message);
        //    }
        //}

    }
}
