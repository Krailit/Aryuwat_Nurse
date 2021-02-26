using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DermasterSystem.Class;
using Entity;

namespace DermasterSystem.Forms
{
    public partial class PopMedicalUsed : Form
    {
        public PopMedicalUsed()
        {
            InitializeComponent();
            dateTimePickerCreate.CustomFormat = "dd-MM-yyyy";
        }

        private List<Entity.MedicalOrderUseTrans> listUse = new List<MedicalOrderUseTrans>();
        private Entity.MedicalOrderUseTrans useInfo;
        //public Entity.MedicalOrderUseTrans info;
        public string CustomerName { get; set; }
        public string AmountTotal { get; set; }//จำนวนทั้งหมด
        public string AmountUsed { get; set; }//จำนวนที่ใช้
        private double Amounttotal = 0;
        public string AmountBalance { get; set; }//คงเหลือ
        public string SupplieName { get; set; }//ชื่อรายการ
        public string CN { get; set; }
        public string VN { get; set; }
        public string MS_Code { get; set; }
        public string CO { get; set; }
        
        public string ExpireDate { get; set; }
        private string useTransId;
        private DataTable dtTmp;
        private List<Entity.MedicalStuff> MedicalStuffs;
        private Entity.MedicalStuff stuffInfo;
        public string TabName { get; set; }
        private string statusSave = "INSERT";
        public Form ParentForm { get; set; }
      

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                listUse = new List<MedicalOrderUseTrans>();

                int? intStatus = 0;
                if (statusSave == "INSERT")
                {
                    if (txtUseNew.Text.Trim() == "" || Convert.ToDouble(txtUseNew.Text) == 0 || txtRefMO.Text.Trim()=="")
                    {
                        Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "กรุณาระบุจำนวนที่ใช้ หรือ เลขอ้างอิงใบยา");
                        txtUseNew.Focus();
                        return;
                    }

                    if (double.Parse(txtUseNew.Text.Trim()) > double.Parse(lblBalance.Text.Trim()))
                    {
                        Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation,
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
                useInfo.CN = CN;
                useInfo.VN = VN;
                useInfo.CreateBy = Statics.StrEmployeeID;
                useInfo.UpdateBy = Statics.StrEmployeeID;
                useInfo.AmountOfUse = double.Parse(txtUseNew.Text.Trim());
                useInfo.DateOfUse = dateTimePickerCreate.Value;
                useInfo.CN_USED = txtUsedCN.Text == "" ? CN : txtUsedCN.Text;
                useInfo.CO = lbCO.Text;
                useInfo.RefMO = txtRefMO.Text.Trim();

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
                            stuffInfo.Position_ID = row.Cells["ID"].Value + "";
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
                if (intStatus == 1)
                {
                    Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "บันทึกข้อมูลเรียบร้อยแล้ว");
                    //BindData();
                    txtUseNew.Text = "";
                    txtRefMO.Text = "";
                    btnSave.Text = "เพิ่ม";
                    statusSave = "INSERT";
                    ((FrmMedicalUseList) ParentForm).BindData();
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
        private string GetCOnumber()
        {
            string co = "";
            try
            {
                co=CO = DermasterSystem.Data.UtilityBackEnd.GenMaxSeqnoValues("CO");
            }
            catch (Exception ex)
            {
              
            }
            return co;
        }
        private void PopMedicalUsed_Load(object sender, EventArgs e)
        {
            dateTimePickerCreate.Value = DateTime.Now;
            SetColumns();
            BindDataStaffList();
            lblAmountUsed.Text = AmountUsed;
            lblCustomerName.Text  = CustomerName+"     CN : "+CN;
            lblSupplie.Text = SupplieName;
            lblTotal.Text = AmountTotal;
            //if (AmountBalance.Split(':').Length > 1) AmountBalance = AmountBalance.Split(':')[0];
            lblBalance.Text = AmountBalance;
            labelExpire.Text =labelExpire.Text+ ExpireDate;
            lbCO.Text = GetCOnumber();// string.Format("CO{0}-{1}-{2}-{3}-{4}", "001", VN, MS_Code, AmountTotal, AmountUsed);
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
            Utility.SetPropertyDgv(dgvUsedTrans);
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

            SetColDgvStaff();
        }

        private void BindDataStaffList()
        {
            try
            {
                Utility.MouseOn(this);
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
                                          item["ID"] + "",
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
                Utility.MouseOff(this);
            }
            catch (Exception ex)
            {
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeError, ex.Message);
                Utility.MouseOff(this);
                return;
            }
        }

        private void BindDataStaffList(DataTable dt)
        {
            try
            {
                Utility.MouseOn(this);
                dgvStaff.Rows.Clear();

                dtTmp = new Business.StuffCommission().SelectStuffCommissionByType(TabName).Tables[0];
                foreach (DataRowView item in dtTmp.DefaultView)
                {
                    string empId = "";
                    string empName = "";
                    foreach (DataRowView  dr in dt.DefaultView)
                    {
                        if (item["ID"] + "" == dr["Position_ID"]+"" &&  dr["MS_Code"]+"" == MS_Code )//&& medicalStuff.SectionStuff == SectionStaff
                        {
                            if (empId != "") empId += ",";
                            empId += dr["EmployeeId"]+"";
                            if (empName != "") empName += ",";
                            empName += dr["FullNameThai"] + "" == "" ? dr["FullNameEng"] + "" : dr["FullNameThai"] + "";
                        }
                    }
                    object[] myItems = { 
                                          item["ID"] + "",
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
                Utility.MouseOff(this);
            }
            catch (Exception ex)
            {
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeError, ex.Message);
                Utility.MouseOff(this);
                return;
            }
        }

        private void SetColDgvStaff()
        {
            //DatagridView Stafff
            Utility.SetPropertyDgv(dgvStaff);
            dgvStaff.Columns.Add("ID", "ID");
            dgvStaff.Columns.Add("Position", "ตำแหน่ง/");
            dgvStaff.Columns.Add("StaffName", "ชื่อผู้ดำเนินการ/Operator");
            dgvStaff.Columns.Add("EmployeeId", "EmployeeId");

            dgvStaff.Columns["ID"].Visible = false;
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
                Utility.MouseOn(this);
                dgvUsedTrans.Rows.Clear();
                Entity.MedicalOrderUseTrans info = new MedicalOrderUseTrans();
                info.CN = CN;
                info.VN = VN;
                info.MS_Code = MS_Code;

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
                                               imageList1.Images[3]
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
                Utility.MouseOff(this);
            }
            catch (Exception ex)
            {
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeError, ex.Message);
                Utility.MouseOff(this);
                return;
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
                obj.BackColor = Color.FromArgb(170, 232, 229);
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
            if (e.ColumnIndex == dgvUsedTrans.Columns["BtnStaff"].Index)
            {
                txtUseNew.Text = dgvUsedTrans.Rows[e.RowIndex].Cells["Amount"].Value+"";
                Entity.MedicalStuff info = new MedicalStuff();
                info.VN = VN;
                info.MS_Code = MS_Code;
                info.UseTransId = dgvUsedTrans.Rows[e.RowIndex].Cells["Id"].Value + "";
                txtUsedCN.Text = dgvUsedTrans.Rows[e.RowIndex].Cells["CN_USED"].Value + "";
                txtUsedName.Text = dgvUsedTrans.Rows[e.RowIndex].Cells["CN_USEDFULLNAME"].Value + "";
                useTransId = info.UseTransId;
                DataTable dt = new Business.MedicalStuff().SelectMedicalStuffById(info).Tables[0];
                BindDataStaffList(dt);
                btnSave.Text = "Update";
                txtUseNew.Enabled = false;
                statusSave = "UPDATE";

                txtRefMO.Text = dgvUsedTrans.Rows[e.RowIndex].Cells["RefMO"].Value + "";
            }
            if (e.ColumnIndex == dgvUsedTrans.Columns["BtnDelete"].Index)
            {
                string useId = dgvUsedTrans.Rows[e.RowIndex].Cells["Id"].Value + "";
                int? intStatus = new Business.MedicalOrderUseTrans().DeleteMedicalOrderUseTransById(useId,VN,CN,MS_Code);
                if(intStatus !=-1 )
                {
                    Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "ลบข้อมูลเรียบร้อยแล้ว");
                    ((FrmMedicalUseList)ParentForm).BindData();
                    Close();
                }
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
