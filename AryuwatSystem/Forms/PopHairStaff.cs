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

namespace AryuwatSystem.Forms
{
    public partial class PopHairStaff : Form
    {
        public PopHairStaff()
        {
            InitializeComponent();
        }

        private DataTable dtTmp ;
        public string SectionStaff { get; set; }
        //public List<Entity.MedicalStuff> StuffAesthetic { get; set; }
        //public List<Entity.MedicalStuff> StuffTreatment { get; set; }
        //public List<Entity.MedicalStuff> StuffSurgery { get; set; }
        //public List<Entity.MedicalStuff> StuffHair { get; set; }
        public List<Entity.MedicalStuff> MedicalStuffs { get; set; }
        public Entity.MedicalStuff stuffInfo { get; set; }
        public string MS_Code { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            PopEmpSearch obj = new PopEmpSearch();
            obj.StartPosition = FormStartPosition.CenterParent;
            obj.BackColor = Color.FromArgb(255, 230, 217);
            obj.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender,e);
        }

        private void PopHairStaff_Load(object sender, EventArgs e)
        {
            SetColumns();
            //SetColDtTmp();
            BindDataStaffList();
        }

        private void BindDataStaffList()
        {
            try
            {
                DerUtility.MouseOn(this);
                dgvStaff.Rows.Clear();

                dtTmp = new Business.StuffCommission().SelectStuffCommissionByType(SectionStaff).Tables[0];
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
                DerUtility.MouseOff(this);
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
        }


        private void SetColumns()
        {
            DerUtility.SetPropertyDgv(dgvStaff);
            dgvStaff.Columns.Add("ID", "ID");
            dgvStaff.Columns.Add("Position", "ตำแหน่ง");
            dgvStaff.Columns.Add("StaffName", "ชื่อผู้ดำเนินการ");
            dgvStaff.Columns.Add("EmployeeId", "EmployeeId");

            dgvStaff.Columns["ID"].Visible = false;
            dgvStaff.Columns["Position"].Width = 210;
            dgvStaff.Columns["EmployeeId"].Visible = false;
            dgvStaff.Columns["Position"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvStaff.Columns["StaffName"].Width = 690;
            DataGridViewImageColumn colStaff = new DataGridViewImageColumn();
            {
                colStaff.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                colStaff.CellTemplate = new DataGridViewImageCell();
            }
            dgvStaff.Columns.Add(colStaff);
            DataGridViewImageColumn colDel= new DataGridViewImageColumn();
            {
                colDel.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                colDel.CellTemplate = new DataGridViewImageCell();
            }
            dgvStaff.Columns.Add(colDel);
        }

        private void dgvStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                PopEmpSearch obj = new PopEmpSearch();
                obj.StartPosition = FormStartPosition.CenterScreen;
                obj.WindowState = FormWindowState.Normal;
                obj.BackColor = Color.FromArgb(255, 230, 217);
                obj.StaffsName = dgvStaff.Rows[e.RowIndex].Cells[2].Value+"";
                obj.EmployeeId=dgvStaff.Rows[e.RowIndex].Cells["EmployeeId"].Value + "";
                obj.ShowDialog();
                if (obj.StaffsName != "")
                    dgvStaff.Rows[e.RowIndex].Cells[2].Value = obj.StaffsName;
                if (obj.EmployeeId != "")
                    dgvStaff.Rows[e.RowIndex].Cells["EmployeeId"].Value = obj.EmployeeId;
            } else if(e.ColumnIndex == 5)
            {
                dgvStaff.Rows[e.RowIndex].Cells[2].Value = "";
                dgvStaff.Rows[e.RowIndex].Cells["EmployeeId"].Value = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
         
            MedicalStuffs = new List<MedicalStuff>();
            //string[] arrCode = MS_Code.Split(':');
            //for (int j = 0; j < arrCode.Length; j++)
            //{
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
                            stuffInfo.SectionStuff = SectionStaff;
                            stuffInfo.MergStatus = MS_Code;
                            MedicalStuffs.Add(stuffInfo);
                        }
                    }
                }
            //}

            this.Close();
        }

        private void PopHairStaff_FormClosed(object sender, FormClosedEventArgs e)
        {
            btnSave_Click(sender,e);
        }
    }
}
