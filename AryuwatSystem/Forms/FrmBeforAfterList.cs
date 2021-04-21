using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AryuwatSystem.DerClass;
using Entity;
using WeifenLuo.WinFormsUI.Docking;

namespace AryuwatSystem.Forms
{
    public partial class FrmBeforAfterList : DockContent, IForm
    {
        private Entity.MedicalSupplies info;
        public DerUtility.AccessType FormType { get; set; }
        private int? intStatus; 
        private int rowIndex = 0;
        public string TypeCashier;
        public string CN;
        public string CustName;
        public string VN;
        bool bind=true;
        #region IForm Members

        void IForm.IsSave()
        {
        }

        void IForm.IsDelete()
        {
            DeleteData();
        }

        void IForm.IsRefresh()
        {
            
        }

        void IForm.IsEdit()
        {
            CallForm(CallMode.Update);
        }

        void IForm.IsPrint()
        {
        }

        void IForm.IsNew()
        {
            NewUserGroup();
        }

        void IForm.IsExit()
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        #endregion
        #region Enum CallMode

        private enum CallMode
        {
            Insert,
            Update,
            Preview
        }
        #endregion
        public FrmBeforAfterList()
        {
            InitializeComponent();
            SetColumns();
         
            //BindMedicalSupplies(1);
          
            dgvData.RowPostPaint += dgvData_RowPostPaint;
            dgvData.RowPostPaint += dgvData_RowPostPaint;
            dgvData.CellMouseClick += dgvData_CellMouseClick;
            //menuEdit.Click += new EventHandler(menuEdit_Click);
            //menuDel.Click += new EventHandler(menuDel_Click);
            FormType = DerUtility.AccessType.Insert;
            this.Closing += new CancelEventHandler(FrmUserGroup_Closing);
        }
     
        void FrmUserGroup_Closing(object sender, CancelEventArgs e)
        {
            Statics.frmCheckCourseList = null;
        }

        private void CallForm(CallMode cMode)
        {
            //int rowindex = OldrowIndex; //dgvData.CurrentRow.Index;
            PopUserGroupSetting obj = new PopUserGroupSetting();
            if (rowIndex == -1) return;
             if (cMode == CallMode.Preview)
             {
                 obj.FormType = DerUtility.AccessType.DisplayOnly;
                 obj.Text = Text + Statics.StrPreview;
             }
             else if (cMode == CallMode.Update)
             {
                 obj.FormType = DerUtility.AccessType.Update;
                 obj.Text = Text + Statics.StrEdit;
             }

             obj.ID = int.Parse(dgvData.Rows[rowIndex].Cells["ID"].Value + "");
             obj.GroupCode = dgvData.Rows[rowIndex].Cells["GroupCode"].Value + "";
             obj.GroupName = dgvData.Rows[rowIndex].Cells["GroupName"].Value + "";

             obj.BackColor = Color.FromArgb(255, 230, 217);
            obj.ShowDialog();
        }
        #region Event


        private void menuEdit_Click(object sender, EventArgs e)
        {
           // EditMedicalSupplies();
            //CallForm(CallMode.Update);
        }

    
        private void menuSurgical_Click(object sender, EventArgs e)
        {
            TypeCashier = "EN";
            CallForm(CallMode.Preview);
        }
        private void summaryOfTreatmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TypeCashier = "CN";
            CallForm(CallMode.Preview);
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
                    rowIndex = e.RowIndex;
                    dgvData.Rows[rowIndex].Selected = true;
                    //string MedStatus_Code = dgvData.Rows[e.RowIndex].Cells["MedStatus_Code"].Value + "";
                    //double used =Convert.ToDouble(dgvData.Rows[e.RowIndex].Cells["AmountOfUse"].Value + "");
                    //menuSurgical.Visible = MedStatus_Code != "0";
                    //menuSurgical.Visible = used > 0;
                    if (Convert.ToDecimal(dgvData.Rows[e.RowIndex].Cells["Balance"].Value + "") <= 0 && !(Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN)) 
                        return;
                    else
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

        private void NewUserGroup()
        {
            PopUserGroupSetting obj = new PopUserGroupSetting();
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.BackColor = Color.FromArgb(255, 230, 217);
            obj.ShowDialog();
        }

        private void DeleteData()
        {
            //if (Utility.PopMsg(Utility.EnuMsgType.MsgTypeConfirmYesNo, "ยืนยันการลบข้อมูล", "ลบข้อมูล") == DialogResult.Yes)
            //{
            var groupCode = dgvData.CurrentRow.Cells["ID"].Value + "";
            if (groupCode == "1")
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation,
                               "ไม่สามารถลบกลุ่มใช้งานนี้ได้ กรุณาติดต่อผู้ดูแลระบบ", "ผลการตรวจสอบ");
                return;
            }
            if (dgvData.CurrentRow.Index == -1) return;
            if (DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirmYesNo,
                               Statics.StrConfirmDelete + groupCode) !=
                DialogResult.Yes) return;
            try
            {
                if (new Business.UserGroup().DeleteUserGroup(int.Parse(groupCode)) == 1)
                {
                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, Statics.StrMsgDeleteComplete);
                    //BindDataUsed(1);
                }
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, Statics.StrMsgDeleteError + ex);
            }
            //}
        }
      
        private void SetColumns()
        {
            try
            {

    
            DerUtility.SetPropertyDgv(dgvData);

            //DataGridViewImageColumn ColLicencePreview = new DataGridViewImageColumn();
            //{
            //    ColLicencePreview.AutoSizeMode =
            //        DataGridViewAutoSizeColumnMode.DisplayedCells;
            //    ColLicencePreview.CellTemplate = new DataGridViewImageCell();
            //    ColLicencePreview.Name = "btnLicencePreview";
            //    ColLicencePreview.HeaderText = "BeforAfter";
            //}
            //dgvData.Columns.Add(ColLicencePreview);

            //DataGridViewImageColumn ColUsed = new DataGridViewImageColumn();
            //{
            //    ColUsed.AutoSizeMode =
            //        DataGridViewAutoSizeColumnMode.DisplayedCells;
            //    ColUsed.CellTemplate = new DataGridViewImageCell();
            //    ColUsed.Name = "btnUserCourse";
            //    ColUsed.HeaderText = "UserCourse";
            //}
            //dgvData.Columns.Add(ColUsed);
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            {
                //column.HeaderText = "Selected";
                //column.Name = "Selected";
                column.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                column.FlatStyle = FlatStyle.Standard;
                column.ThreeState = false;
                column.CellTemplate = new DataGridViewCheckBoxCell();
                column.CellTemplate.Style.BackColor = Color.Beige;
                column.Name = "Select";
            }
            dgvData.Columns.Add(column);

            //dgvData.Columns.Add("Id", "Id");
            dgvData.Columns.Add("MS_Name", "รายการ");
            dgvData.Columns["MS_Name"].Width = 200;
            dgvData.Columns.Add("Total", "ทั้งหมด");
            dgvData.Columns.Add("Used", "ใช้ไป");
            dgvData.Columns["Used"].Width = 70;
            dgvData.Columns.Add("Balance", "คงเหลือ");
            dgvData.Columns["Balance"].Width = 70;
            dgvData.Columns.Add("FirstUsed", "ใช้ครั้งแรก");
            dgvData.Columns["FirstUsed"].Width = 100;
            dgvData.Columns.Add("LastUsed", "ใช้ล่าสุด");
            dgvData.Columns["LastUsed"].Width = 100;
            dgvData.Columns.Add("ExpireDate", "หมดอายุ");
               dgvData.Columns["ExpireDate"].Width = 100;
            
            //dgvData.Columns.Add("RefMO", "ใบยา");
            //dgvData.Columns.Add("CN_USED", "CN");
            //dgvData.Columns["CN_USED"].Width = 150;
            //dgvData.Columns.Add("CN_USEDFULLNAME", "ผู้ใช้");
            
            //dgvData.Columns["CN_USEDFULLNAME"].Width = 200;
            //DataGridViewImageColumn colStaff = new DataGridViewImageColumn();
            //{
            //    colStaff.AutoSizeMode =
            //        DataGridViewAutoSizeColumnMode.DisplayedCells;
            //    colStaff.CellTemplate = new DataGridViewImageCell();
            //    colStaff.HeaderText = "Staff";
            //    colStaff.Name = "BtnStaff";
            //    colStaff.Visible = false;
            //}
            //dgvData.Columns.Add(colStaff);
            //DataGridViewImageColumn colDel = new DataGridViewImageColumn();
            //{
            //    colDel.AutoSizeMode =
            //        DataGridViewAutoSizeColumnMode.DisplayedCells;
            //    colDel.CellTemplate = new DataGridViewImageCell();
            //    colDel.HeaderText = "Delete";
            //    colDel.Name = "BtnDelete";
            //    colDel.Visible = false;
            //}
            //dgvData.Columns.Add(colDel);




            //dgvData.Columns["Id"].Visible = false;
            //dgvData.Columns["Amount"].Width = 80;
            //dgvData.Columns["AmountBalance"].Width = 110;
            //dgvData.Columns["DateOfUse"].Width = 120;


            dgvData.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvData.Columns["Used"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvData.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvData.Columns["DateOfUse"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvData.Columns.Add("Branch", "สาขาที่ซื้อ");

            //DataGridViewImageColumn ColLicence = new DataGridViewImageColumn();
            //{
            //    ColLicence.AutoSizeMode =
            //        DataGridViewAutoSizeColumnMode.DisplayedCells;
            //    ColLicence.CellTemplate = new DataGridViewImageCell();
            //    ColLicence.Name = "btnLicence";
            //    ColLicence.HeaderText = "Licence";
            //}
            //dgvData.Columns.Add(ColLicence);





            //DataGridViewImageColumn FileScan = new DataGridViewImageColumn();
            //{
            //    FileScan.AutoSizeMode =
            //        DataGridViewAutoSizeColumnMode.DisplayedCells;
            //    FileScan.CellTemplate = new DataGridViewImageCell();
            //    FileScan.Name = "btnFileScan";
            //    FileScan.HeaderText = "FileScan";
            //}
            //dgvData.Columns.Add(FileScan);

            //dgvData.Columns.Add("Remark", "Remark");
            //dgvData.Columns["Remark"].Width = 500;
            dgvData.Columns.Add("SOno", "SOno");
            dgvData.Columns.Add("VN", "MO");

            
            dgvData.Columns.Add("ListOrder", "ListOrder");
            dgvData.Columns.Add("MS_Code", "MS_Code");
            dgvData.Columns.Add("Tab", "Tab");
            dgvData.Columns.Add("CN", "CN");
                dgvData.Columns.Add("CustName", "ชื่อผู้ซื้อ");
            
            dgvData.Columns.Add("FeeRate", "FeeRate");
            dgvData.Columns.Add("FeeRate2", "FeeRate2");
            dgvData.Columns.Add("PriceAfterDis", "PriceAfterDis");

            dgvData.Columns["FeeRate"].Visible = false;
            dgvData.Columns["FeeRate2"].Visible = false;
            

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
            dgvData.Columns.Add(chkCanceled);
            dgvData.Columns.Add("EN_COMS1", "EN_COMS1");
            dgvData.Columns["EN_COMS1"].Visible = false;

            dgvData.Columns.Add("UsedName", "ชื่อผู้ใช้");
            dgvData.Columns.Add("CNUsed", "CNUsed");
            dgvData.Columns.Add("CurrentUsed", "ใช้ครั้งนี้");
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               
            }
        }

      
      
        private void FrmBeforAfterList_Load(object sender, EventArgs e)
        {
            //firstload = false;
            this.Text += " " + CustName;
            labelName.Text = CustName;
            BindDataUsed();
        }

        private void dgvData_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        private void dgvData_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //BindDataUsed(1);
        }

     
     
        private void FrmBeforAfterList_Activated(object sender, EventArgs e)
        {

            //BindDataUsed();
        }

        private void FrmBeforAfterList_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics.frmCheckCourseList = null;
        }
        private void BindDataUsed()
        {
            try
            {
                DerUtility.MouseOn(this);
                dgvData.Rows.Clear();
                Entity.MedicalOrderUseTrans info = new MedicalOrderUseTrans();
                info.CN = CN;
                info.VN = VN;
                //info.MS_Code =  MS_Code;
                //info.ListOrder = ListOrder;
                DataTable dtTmp;
                //if (!string.IsNullOrEmpty(info.VN))
                //{
                dtTmp = new Business.MedicalOrderUseTrans().SelectMedicalOrderUseTransByCN_CheckCouse(info).Tables[0];
                    foreach (DataRowView item in dtTmp.DefaultView)
                    {
                        double AmountT = Convert.ToDouble(string.IsNullOrEmpty(item["Total"] + "") ? "1" : item["Total"] + "".Replace(",", ""));
                        double AmountU = Convert.ToDouble(string.IsNullOrEmpty(item["AmountOfUse"] + "") ? "0" : item["AmountOfUse"] + "".Replace(",", ""));
                        double AmountB = Convert.ToDouble(string.IsNullOrEmpty(item["AmountBalance"] + "") ? AmountT+"" : item["AmountBalance"] + "".Replace(",", ""));
                        object[] myItems = {
                                               //imageList1.Images[8],
                                               //imageList1.Images[4],
                                               false,
                                               //item["ID"] + "",
                                               item["MS_Name"] + "",
                                               AmountT.ToString("###,###,##0.##"),
                                               AmountU.ToString("###,###,##0.##"),
                                                 AmountB.ToString("###,###,##0.##"),
                                               item["FirstUsed"] + "" ,//!= ""? DateTime.Parse(item["FirstUsed"] + "").Date.ToShortDateString():"",
                                               item["LastUsed"] + "" ,//!= ""? DateTime.Parse(item["LastUsed"] + "").Date.ToShortDateString():"",
                                               item["ExpireDate"] + "",
                                               
                                               //item["RefMO"]+"",
                                               //item["CN_USED"]+"",
                                               //item["FullNameThai"]+"" != ""?item["FullNameThai"]+"":item["FullNameEng"]+"",
                                               //item["CO"]+"",
                                               
                                               item["BranchName"]+"",
                                               //item["Remark"]+"",
                                               
                                               item["SOno"]+"",
                                               item["VN"]+"",
                                               
                                               item["ListOrder"]+"",
                                               item["MS_Code"]+"",
                                               item["Tab"]+"",
                                               item["CN"]+"",
                                               item["FullNameThaiBuy"]+"",
                                               item["FeeRate"]+"",
                                               item["FeeRate2"]+"",
                                               item["PriceAfterDis"]+"",
                                               item["Canceled"] + "" == "Y" ? true : false,
                                               item["EN_COMS1"]+""
                                               
                                           };
                        dgvData.Rows.Add(myItems);
                    }
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

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                  for (int u = 0; u < dgvData.RowCount; u++)
                    {
                        if ((dgvData.Rows[u].Cells["MS_Name"].Value + "").Contains(txtFilter.Text)) //|| (dgvData.Rows[u].Cells["CN_USEDFULLNAME"].Value + "").ToLower().Contains(txtFilter.Text))
                                {
                                    dgvData.Rows[u].Visible = true;
                                }
                                else
                                {
                                    dgvData.Rows[u].Visible = false;
                                }
                    }
            }
            catch (Exception)
            {
                
            }
        }
    
        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.ColumnIndex != dgvData.Columns["Select"].Index) return;//&& e.ColumnIndex != dgvData.Columns["btnUserCourse"].Index 

                if (Convert.ToDecimal(dgvData.Rows[e.RowIndex].Cells["Balance"].Value + "") <= 0 && !(Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN)) return;

                if (IsExpireDate(dgvData.Rows[e.RowIndex].Cells["ExpireDate"].Value + "") && !(Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN))
                {
                    MessageBox.Show("This Item Expired", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();

                //if (!multiSelect)
                //{
                //    foreach (DataGridViewRow dr in dgvData.Rows)
                //    {
                //        ch1 = (DataGridViewCheckBoxCell)dr.Cells[0];
                //        ch1.Value = false;
                //    }
                //}
                ch1 = (DataGridViewCheckBoxCell)dgvData.Rows[dgvData.CurrentRow.Index].Cells["Select"];
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
                //if (e.ColumnIndex == dgvData.Columns["btnUserCourse"].Index)
                //{

                    //if (IsExpireDate(dgvData.Rows[e.RowIndex].Cells["ExpireDate"].Value + ""))
                    //{
                    //    MessageBox.Show("This Item Expired", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return;
                    //}

                    DataGridViewCheckBoxCell chkCom = dgvData.Rows[e.RowIndex].Cells["chkCanceled"] as DataGridViewCheckBoxCell;
                    if (Convert.ToBoolean(chkCom.Value))
                    {
                        MessageBox.Show("This Item Closed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                //    PopMedicalUsed obj = new PopMedicalUsed();
                //    obj.StartPosition = FormStartPosition.CenterScreen;
                //    obj.WindowState = FormWindowState.Normal;
                //    obj.BackColor = System.Drawing.Color.FromArgb(255, 230, 217);
                //    obj.CN = CN;
                //    obj.VN = dgvData.Rows[e.RowIndex].Cells["VN"].Value + ""; ;
                //    obj.Sono = dgvData.Rows[e.RowIndex].Cells["SOno"].Value + "";
                //    obj.ListOrder = dgvData.Rows[e.RowIndex].Cells["ListOrder"].Value + "";
                //    obj.MS_Code = dgvData.Rows[e.RowIndex].Cells["MS_Code"].Value + "";
                //    obj.SupplieName = dgvData.Rows[e.RowIndex].Cells["MS_Name"].Value + "";
                //    obj.AmountTotal = dgvData.Rows[e.RowIndex].Cells["Total"].Value + "";
                //    obj.Amounttotal = Convert.ToDouble((dgvData.Rows[e.RowIndex].Cells["Total"].Value + "").Replace(",", ""));
                //    obj.AmountUsed = dgvData.Rows[e.RowIndex].Cells["Used"].Value + "";
                //    obj.AmountBalance = dgvData.Rows[e.RowIndex].Cells["Balance"].Value + "";
                //    obj.PriceAfterDis = dgvData.Rows[e.RowIndex].Cells["PriceAfterDis"].Value + "" == "" ? 0 : Convert.ToDecimal(dgvData.Rows[e.RowIndex].Cells["PriceAfterDis"].Value + "");
                //    obj.TabName = dgvData.CurrentRow.Cells["Tab"].Value + "";
                //    obj.CustomerName = dgvData.Rows[e.RowIndex].Cells["CustName"].Value + "";
                //    //obj.ExpireDate = dgvData.Rows[e.RowIndex].Cells["ExpireDate"].Value + "";
                //    obj.FeeRate = dgvData.Rows[e.RowIndex].Cells["FeeRate"].Value + "" == "" ? 0 : Convert.ToDecimal(dgvData.Rows[e.RowIndex].Cells["FeeRate"].Value + "");
                //    obj.FeeRate2 = dgvData.Rows[e.RowIndex].Cells["FeeRate2"].Value + "" == "" ? 0 : Convert.ToDecimal(dgvData.Rows[e.RowIndex].Cells["FeeRate2"].Value + "");
                //obj.EN_COMS1 = dgvData.CurrentRow.Cells["EN_COMS1"].Value + "";
                ////obj.BranchId = dgvData.CurrentRow.Cells["BranchId"].Value + "";
                
                //    obj.ParentForm = this;
                //    obj.ShowDialog();

                //    dgvData.Rows[e.RowIndex].Cells["UsedName"].Value=obj.UsedName;
                //    dgvData.Rows[e.RowIndex].Cells["CNUsed"].Value=obj.CNUsed;
                //    dgvData.Rows[e.RowIndex].Cells["CurrentUsed"].Value = obj.CurrentUsed;
                
                    
                    


                //}
                //if (e.ColumnIndex == dgvData.Columns["btnLicencePreview"].Index)
                //{
                //    SwitchImageDuringZoomDemoForm frm = new SwitchImageDuringZoomDemoForm();
                //    frm.CN = CN;
                //    frm.ShowDialog();
                //}

                    dgvData.ClearSelection();
                    rowIndex = e.RowIndex;
                    dgvData.Rows[rowIndex].Selected = true;
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
                IsExpire = DateTime.Now > (str == "" ? DateTime.Now : Convert.ToDateTime(str));
            }
            catch (Exception)
            {


            }
            return IsExpire;
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            //    FrmPreviewRpt obj = new FrmPreviewRpt();

            //    string strTypeofPay = "";

            //    obj.PrintType = "";
            //    double dblCredit = 0.00;
            //    double dblCash = 0.00;
            //    string strBankName = "";

            //    //obj.PrintType = RoomName;
            //    //obj.Remark = txtRemark.Text;

            //    //string Title = String.Format("{0:MMMM, yyyy} {1}", Convert.ToDateTime(EndDate), BranchName);// CN ชื่อลูกค้า
            //    //obj.ForDate = Title;

            //    obj.FormName = "RptDoctorAtten";
            //    obj.FormName = "RptDoctorAtten";


            //    //obj.dt = dtx;
            //    obj.MaximizeBox = true;
            //    obj.TopMost = true;
            //    obj.Show();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void picPrint_Click(object sender, EventArgs e)
        {
            try
            {

                List<DataGridViewRow> lsSelect = new List<DataGridViewRow>();
                DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();

                DataTable dt = new DataTable();
                foreach (DataGridViewColumn col in dgvData.Columns)
                {
                    dt.Columns.Add(col.Name);
                }

                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    ch1 = (DataGridViewCheckBoxCell)row.Cells["Select"];
                      if ((ch1.Value + "").ToLower() == "true")
                      {
                          DataRow dRow = dt.NewRow();
                          foreach (DataGridViewCell cell in row.Cells)
                          {
                              dRow[cell.ColumnIndex] = cell.Value;
                          }
                          dt.Rows.Add(dRow);
                      }
                }

                    //foreach (DataGridViewRow dr in dgvData.Rows)
                    //{
                    //    ch1 = (DataGridViewCheckBoxCell)dr.Cells[0];
                    //    if ((ch1.Value+"").ToLower() == "true")
                    //        lsSelect.Add(dr);

                    //}

                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Select Item.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                FrmPreviewRpt obj = new FrmPreviewRpt();

                string strTypeofPay = "";

                obj.PrintType = "";
                double dblCredit = 0.00;
                double dblCash = 0.00;
                string strBankName = "";

                //obj.PrintType = RoomName;
                //obj.Remark = txtRemark.Text;

                string MainName = String.Format("{0} ({1})", dgvData.Rows[0].Cells["CustName"].Value + "",CN);// CN ชื่อลูกค้า
                string UsedName = String.Format("{0} ({1})", dgvData.Rows[0].Cells["UsedName"].Value + "", CN);// CN ชื่อลูกค้าใช้คอร์ส
                obj.MainName = MainName;
                obj.UsedName = UsedName;

                obj.FormName = "RptCourseApproved";


                obj.dt = dt;
                obj.MaximizeBox = true;
                obj.TopMost = true;
                obj.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void menuMOUse_Click(object sender, EventArgs e)
        {
            try
            {
                PopMedicalUsed obj = new PopMedicalUsed();
                obj.StartPosition = FormStartPosition.CenterScreen;
                obj.WindowState = FormWindowState.Normal;
                obj.BackColor = System.Drawing.Color.FromArgb(255, 230, 217);
                obj.CN = CN;
                obj.VN = dgvData.Rows[rowIndex].Cells["VN"].Value + ""; ;
                obj.Sono = dgvData.Rows[rowIndex].Cells["SOno"].Value + "";
                obj.ListOrder = dgvData.Rows[rowIndex].Cells["ListOrder"].Value + "";
                obj.MS_Code = dgvData.Rows[rowIndex].Cells["MS_Code"].Value + "";
                obj.SupplieName = dgvData.Rows[rowIndex].Cells["MS_Name"].Value + "";
                obj.AmountTotal = dgvData.Rows[rowIndex].Cells["Total"].Value + "";
                obj.Amounttotal = Convert.ToDecimal((dgvData.Rows[rowIndex].Cells["Total"].Value + "").Replace(",", ""));
                obj.AmountUsed = dgvData.Rows[rowIndex].Cells["Used"].Value + "";
                obj.AmountBalance = dgvData.Rows[rowIndex].Cells["Balance"].Value + "";
                obj.PriceAfterDis = dgvData.Rows[rowIndex].Cells["PriceAfterDis"].Value + "" == "" ? 0 : Convert.ToDecimal(dgvData.Rows[rowIndex].Cells["PriceAfterDis"].Value + "");
                obj.TabName = dgvData.CurrentRow.Cells["Tab"].Value + "";
                obj.CustomerName = dgvData.Rows[rowIndex].Cells["CustName"].Value + "";
                //obj.ExpireDate = dgvData.Rows[e.RowIndex].Cells["ExpireDate"].Value + "";
                obj.FeeRate = dgvData.Rows[rowIndex].Cells["FeeRate"].Value + "" == "" ? 0 : Convert.ToDecimal(dgvData.Rows[rowIndex].Cells["FeeRate"].Value + "");
                obj.FeeRate2 = dgvData.Rows[rowIndex].Cells["FeeRate2"].Value + "" == "" ? 0 : Convert.ToDecimal(dgvData.Rows[rowIndex].Cells["FeeRate2"].Value + "");
                obj.EN_COMS1 = dgvData.CurrentRow.Cells["EN_COMS1"].Value + "";
                //obj.BranchId = dgvData.CurrentRow.Cells["BranchId"].Value + "";

                obj.ParentForm = this;
                obj.ShowDialog();

                //dgvData.Rows[rowIndex].Cells["UsedName"].Value = obj.UsedName;
                //dgvData.Rows[rowIndex].Cells["CNUsed"].Value = obj.CNUsed;
                //dgvData.Rows[rowIndex].Cells["CurrentUsed"].Value = obj.CurrentUsed;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
