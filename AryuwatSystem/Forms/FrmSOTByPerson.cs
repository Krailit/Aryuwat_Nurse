using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AryuwatSystem.DerClass;
using Entity;
using WeifenLuo.WinFormsUI.Docking;

namespace AryuwatSystem.Forms
{
    public partial class FrmSOTByPerson : DockContent
    {
        private Entity.MedicalSupplies info;
        public DerUtility.AccessType FormType { get; set; }
        private int? intStatus;
        private int OldrowIndex = 0;
        private int CurrentRow = 0;
        private DataTable dataTable = null;
        private int ID = 0;
        private string MS_CodeOld = "";
        public string TypeCashier;
        bool bind = true;
        private bool firstload = true;
        private string MedStatus_Code = "";
        private string MedStatus_CodeNew = "";

        private string MedStatus_CodePending = "";
        private string MedStatus_CodeClosed = "";
        private int AmountOfUse = 0;
        private string MoneyCheckComplete = "Y";
        DataTable dtListOrg = new DataTable();
        DataTable dtList = new DataTable();

        #region Enum CallMode

        private enum CallMode
        {
            Insert,
            Update,
            Preview
        }
        #endregion
        public FrmSOTByPerson()
        {
            InitializeComponent();
            SetColumns();

            //BindMedicalSupplies(1);
            ngbMain.MoveFirst += ngbMain_MoveFirst;
            ngbMain.MoveNext += ngbMain_MoveNext;
            ngbMain.MoveLast += ngbMain_MoveLast;
            ngbMain.MovePrevious += ngbMain_MovePrevious;
            dgvData.RowPostPaint += dgvData_RowPostPaint;
            dgvData.RowPostPaint += dgvData_RowPostPaint;
            dgvData.CellMouseClick += dgvData_CellMouseClick;
            buttonFind.BtnClick += buttonFind_BtnClick;
            menuEdit.Click += new EventHandler(menuEdit_Click);
            menuDel.Click += new EventHandler(menuDel_Click);
            FormType = DerUtility.AccessType.Insert;
            this.Closing += new CancelEventHandler(FrmSurgicalFee_Closing);
        }

        void FrmSurgicalFee_Closing(object sender, CancelEventArgs e)
        {
            Statics.frmSOFList = null;
        }

        private void CallForm(CallMode cMode)
        {
            try
            {


                int rowindex = OldrowIndex; //dgvData.CurrentCell.Index;
                int colindex = dgvData.CurrentCell.ColumnIndex;
                if (rowindex == -1) return;
                if (colindex == -1 || colindex == 0) return;
                if (TypeCashier == "EN")
                {
                    Statics.frmSurgicalFeeMain = new FrmSurgicalFeeMain();
                    Statics.frmSurgicalFeeMain.VN = dgvData.Rows[CurrentRow].Cells["VN"].Value + "";
                    Statics.frmSurgicalFeeMain.BackColor = Color.FromArgb(255, 230, 217);
                    Statics.frmSurgicalFeeMain.Show(Statics.frmMain.dockPanel1);


                    //if (cMode == CallMode.Preview)
                    //{
                    //    //Statics.frmSurgicalFee.Text = Statics.StrPreview;
                    //}
                    ////Statics.frmSurgicalFeeMain.VN = dgvData.Rows[rowindex].Cells["VN"].Value + "";
                    ////Statics.frmSurgicalFeeMain.BackColor = Color.FromArgb(255, 230, 217);
                    ////Statics.frmSurgicalFeeMain.Show(Statics.frmMain.dockPanel1);


                    //Statics.frmSurgicalFee = new FrmSurgicalFee();

                    //if (cMode == CallMode.Preview)
                    //{
                    //    Statics.frmSurgicalFee.FormType = Utility.AccessType.DisplayOnly;
                    //    //Statics.frmSurgicalFee.Text = Statics.StrPreview;
                    //}
                    //Statics.frmSurgicalFee.VN = dgvData.Rows[CurrentRow].Cells["VN"].Value + "";
                    //Statics.frmSurgicalFee.BackColor = Color.FromArgb(255, 230, 217);
                    //Statics.frmSurgicalFee.Show(Statics.frmMain.dockPanel1);
                }
                else if (TypeCashier == "CN")
                {
                    Statics.frmSumOfTreatment = new FrmSumOfTreatment();

                    if (cMode == CallMode.Preview)
                    {
                        Statics.frmSumOfTreatment.FormType = DerUtility.AccessType.DisplayOnly;
                        //Statics.frmSumOfTreatment.Text += Statics.StrPreview;
                    }
                    Statics.frmSumOfTreatment.VN = dgvData.Rows[CurrentRow].Cells["VN"].Value + "";
                    Statics.frmSumOfTreatment.SO = dgvData.Rows[CurrentRow].Cells["SO"].Value + "";
                    Statics.frmSumOfTreatment.BackColor = Color.FromArgb(255, 230, 217);
                    Statics.frmSumOfTreatment.Show(Statics.frmMain.dockPanel1);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            //try
            //{
            //    ToolStripMenuItemUse.Visible = false;
            //    if (e.Button == MouseButtons.Left)
            //    {
            //        dgvData.ClearSelection();
            //        dgvData.Rows[OldrowIndex].Selected = false;
            //        dgvData.Rows[e.RowIndex].Selected = true;
            //        OldrowIndex = e.RowIndex;
            //        CurrentRow = e.RowIndex;
            //        string MedStatus_Code = dgvData.Rows[e.RowIndex].Cells["MedStatus_Code"].Value + "";
            //        double used =Convert.ToDouble(dgvData.Rows[e.RowIndex].Cells["AmountOfUse"].Value + "");
            //        //menuSurgical.Visible = MedStatus_Code != "0";
            //        //menuSurgical.Visible = used > 0;
            //        if (used == 0 || (MedStatus_Code != "1" && MedStatus_Code!="2"))
            //        {
            //            menuSurgical.Text = "ไม่สามารถคิดค่ามือได้:เนื่องจาก ค้างชำระ หรือ ยังไม่มีการบันทึกกข้อมูลการใช้";
            //            //menuSurgical.Enabled = false;
            //        }
            //        else
            //        {
            //            menuSurgical.Text = "Surgical Fee";
            //            //menuSurgical.Enabled = true;
            //        }

            //        contextMenuStrip1.Show(MousePosition);
            //    }
            //    else if (e.Button == MouseButtons.Right)
            //    {
            //        CurrentRow = e.RowIndex;
            //        dgvData.ClearSelection();
            //        //dgvData.Rows[rowIndex].Selected = false;
            //        dgvData.Rows[e.RowIndex].Selected = true;
            //        //rowIndex = e.RowIndex;
            //        if (dgvData.Rows[e.RowIndex].Cells["SO"].Value + "" == "" || dgvData.Rows[e.RowIndex].Cells["MedStatus_Code"].Value + "" == "0")
            //        {
            //            ToolStripMenuItemChangeCouse.Visible = false;
            //        }
            //        else
            //        {
            //            ToolStripMenuItemChangeCouse.Visible = true;
            //        }

            //        contextMenuStrip1.Show(MousePosition);
            //    }
            //}
            //catch
            //{
            //    return;
            //}
        }
        private void ngbMain_MoveFirst()
        {
            BindFrmSurgicalFee(1);
        }

        private void ngbMain_MoveLast()
        {
            BindFrmSurgicalFee(Convert.ToInt32(ngbMain.TotalPage));
        }

        private void ngbMain_MoveNext()
        {
            BindFrmSurgicalFee(Convert.ToInt32(Convert.ToInt32(ngbMain.CurrentPage) + 1));
        }

        private void ngbMain_MovePrevious()
        {
            BindFrmSurgicalFee(Convert.ToInt32(Convert.ToInt32(ngbMain.CurrentPage) - 1));
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
            if (DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirmYesNo,
                               Statics.StrConfirmDelete + dgvData.CurrentRow.Cells["MS_code"].Value + "") !=
                DialogResult.Yes) return;
            try
            {
                if (new Business.MedicalSupplies().DeleteSupplies(dgvData.CurrentRow.Cells["MS_code"].Value + "") == 1)
                {
                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, Statics.StrMsgDeleteComplete);
                    //BindMedicalSupplies(1);
                }
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, Statics.StrMsgDeleteError + ex);
            }
            //}
        }
        private void buttonCancel_BtnClick()
        {
            Statics.frmSurgicalFeeList = null;

            this.Close();
        }
        private void SetColumns()
        {
            try
            {
                DerUtility.SetPropertyDgv(dgvData);

                DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                checkColumn.Name = "select";
                checkColumn.HeaderText = "เลือก";
                checkColumn.Width = 50;
                checkColumn.ReadOnly = false;
                checkColumn.FillWeight = 10; //if the datagridview is resized (on form resize) the checkbox won't take up too much; value is relative to the other columns' fill values
                dgvData.Columns.Add(checkColumn);
                dgvData.Columns[0].ReadOnly = false;
                dgvData.Columns.Add("MedStatus_Code", "MedStatus_Code");
                dgvData.Columns.Add("MedStatus_Name", "สถานะ");
                //var columnSpec = new DataGridViewColumn
                //    {

                //        CellType = typeof(DateTime), // This is of type System.Type
                //        ColumnName = "UpdateDate" ,
                //        Caption="วันที่"
                //    };
                //dgvData.Columns.Add(columnSpec);
                dgvData.Columns.Add("UpdateDate", "วันที่");
                dgvData.Columns.Add("SORefAccount", "ใบยา");
                dgvData.Columns.Add("SO", "SO");
                dgvData.Columns.Add("VN", "MO");
                dgvData.Columns.Add("CN", "CN");
                dgvData.Columns.Add("FullNameThai", "ชื่อ-นามสกุล");


                dgvData.Columns.Add("SalePrice", "ราคาขาย");
                dgvData.Columns.Add("Pay", "เป็นยอดรับเงิน");
                dgvData.Columns.Add("PriceCreditRef", "เป็นยอดโอนมา");
                dgvData.Columns.Add("PayByItem", "ยอดรวมแจงเงิน");
                dgvData.Columns.Add("SORef", "โอนมาจาก");
                dgvData.Columns.Add("CourseCardID", "CourseCardID");
                dgvData.Columns.Add("BranchName", "สาขา");
                dgvData.Columns.Add("Mobile", "Mobile (มือถือ)");

                dgvData.Columns["VN"].Width = 120;
                dgvData.Columns["SO"].Width = 120;
                dgvData.Columns["CN"].Width = 100;
                dgvData.Columns["FullNameThai"].Width = 150;
                dgvData.Columns["Mobile"].Width = 200;
                dgvData.Columns["CourseCardID"].Width = 200;
                dgvData.Columns["UpdateDate"].Width = 80;
                dgvData.Columns["MedStatus_Code"].Visible = false;
                dgvData.Columns["MedStatus_Name"].Width = 80;
                dgvData.Columns["SalePrice"].Width = 80;
                dgvData.Columns["SalePrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvData.Columns["PayByItem"].Width = 80;
                dgvData.Columns["PayByItem"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvData.Columns["PayByItem"].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                dgvData.Columns["PriceCreditRef"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvData.Columns["Pay"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        public void BindFrmSurgicalFee(int pIntseq)
        {
            try
            {
                bind = false;
                DerUtility.MouseOn(this);
                dgvData.Rows.Clear();
                var info = new Entity.MedicalOrder() { PageNumber = pIntseq };
                Entity.Customer custInfo = new Customer();

                if (!string.IsNullOrEmpty(txtCN.Text.Trim()))
                {
                    custInfo.CN = "%" + txtCN.Text.Trim() + "%";
                }
                if (!string.IsNullOrEmpty(txtName.Text.Trim()))
                {
                    custInfo.TName = "%" + txtName.Text.Trim() + "%";
                }
                if (!string.IsNullOrEmpty(txtSurName.Text.Trim()))
                {
                    custInfo.TSurname = "%" + txtSurName.Text.Trim() + "%";
                }
                if (!string.IsNullOrEmpty(txtProduct.Text.Trim()))
                {
                    info.Product = "%" + txtProduct.Text.Trim() + "%";
                }
                if (!string.IsNullOrEmpty(txtVN.Text.Trim()))
                {
                    info.SONo = "%" + txtVN.Text.Trim() + "%";
                }
                if (checkBoxOld.Checked)
                {
                    info.OldKey = "%Y%";
                }
                if (!string.IsNullOrEmpty(txtStartdate.Text.Trim()))
                {
                    info.StartDate = txtStartdate.Text;
                }
                if (!string.IsNullOrEmpty(txtEnddate.Text.Trim()))
                {
                    info.EndDate = Convert.ToDateTime(txtEnddate.Text).AddDays(1) + "";
                }
                if (!string.IsNullOrEmpty(txtRefMo.Text.Trim()))
                {
                    info.RefMO = "%" + txtRefMo.Text.Trim() + "%";
                }
                if (!string.IsNullOrEmpty(txtCardID.Text.Trim()))
                {
                    info.CO = "%" + txtCardID.Text.Trim() + "%";
                }


                info.CustomerInfo = custInfo;
                MedStatus_CodeNew = checkBoxNew.Checked ? "0" : null;
                MedStatus_CodePending = checkBoxPending.Checked ? "1" : null;
                MedStatus_CodeClosed = checkBoxClose.Checked ? "2" : null;
                MoneyCheckComplete = cboCheckMoney.Checked ? "Y" : null;
                //info.MedStatus_Code = string.Format("''{0}'',''{1}'',''{2}''", MedStatus_CodeNew, MedStatus_CodePending, MedStatus_CodeClosed);
                info.MedStatus_CodeNew = MedStatus_CodeNew;
                info.MedStatus_CodePending = MedStatus_CodePending;
                info.MedStatus_CodeClosed = MedStatus_CodeClosed;
                info.MoneyCheckComplete = MoneyCheckComplete;
                info.BranchId = uBranch1.BranchId;

                DataSet ds = new Business.MedicalOrder().SelectMedicalOrderSOTPaging(info);
                dtList = ds.Tables[0];
                if (ds.Tables.Count > 2) dtListOrg = ds.Tables[1];
                decimal SalePrice = 0;
                decimal Pay = 0;
                decimal PayByItem = 0;
                decimal PriceCreditRef = 0;

                long lngTotalPage = 0;
                long lngTotalRecord = 0;
                if (dtList.Rows.Count <= 0)
                {
                    ngbMain.CurrentPage = 0;
                    ngbMain.TotalPage = 0;
                    ngbMain.TotalRecord = 0;
                    ngbMain.Updates();
                    DerUtility.MouseOff(this);
                    // Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "ไม่พบข้อมูลในระบบ");
                    return;
                }
                foreach (DataRowView item in dtList.DefaultView)
                {
                    if (item["SONo"] + "" == "") continue;
                    //else
                    //{
                    //    if (item["VN"] + "" != "") continue;
                    //} 

                    SalePrice = item["SalePrice"] + "" == "" ? 0 : Convert.ToDecimal(item["SalePrice"] + "");
                    Pay = item["Pay"] + "" == "" ? 0 : Convert.ToDecimal(item["Pay"] + "");
                    PayByItem = item["PayByItem"] + "" == "" ? 0 : Convert.ToDecimal(item["PayByItem"] + "");
                    PriceCreditRef = item["PriceCreditRef"] + "" == "" ? 0 : Convert.ToDecimal(item["PriceCreditRef"] + "");

                    var myItems = new[]
                                      {
                                          "false",
                                          item["MedStatus_Code"] + "",
                                          item["MedStatus_Name"] + "",
                                           String.Format("{0:dd/MM/yyyy}",DateTime.Parse( item["CreateDate"]+"")),
                                          item["SORefAccount"]+"",
                                          item["SONo"] + "",
                                          item["VN"] + "",
                                          item["CN"]+"",
                                          item["FullNameThai"] + ""!=""?item["FullNameThai"] + "":item["FullNameEng"] + "",
                                          //item["FullNameEng"] + "",
                                          //item["gender"] + "" ,
                                       
                                          SalePrice.ToString("###,###,###.##"),
                                           Pay.ToString("###,###,###.##"),
                                           PriceCreditRef.ToString("###,###,###.##"),
                                          PayByItem.ToString("###,###,###.##"),
                                           item["SORef"]+"",
                                           item["CourseCardID"]+"",
                                          item["BranchName"] + "",
                                           item["Mobile"] + "",

                                      };
                    dgvData.Rows.Add(myItems);
                    if (lngTotalPage != 0) continue;
                    DerUtility.FindTotalPage(Convert.ToInt32(item["rowTotal"].ToString()), ref lngTotalPage);
                    lngTotalRecord = Convert.ToInt32(item["rowTotal"].ToString());
                }
                foreach (DataGridViewRow dataRow in dgvData.Rows)
                {
                    MedStatus_Code = dataRow.Cells["MedStatus_Code"].Value.ToString();
                    MedStatus_Code = dataRow.Cells["MedStatus_Code"].Value.ToString();
                    SalePrice = dataRow.Cells["SalePrice"].Value + "" == "" ? 0 : Convert.ToDecimal(dataRow.Cells["SalePrice"].Value + "");
                    PayByItem = dataRow.Cells["PayByItem"].Value + "" == "" ? 0 : Convert.ToDecimal(dataRow.Cells["PayByItem"].Value + "");
                    PriceCreditRef = dataRow.Cells["PriceCreditRef"].Value + "" == "" ? 0 : Convert.ToDecimal(dataRow.Cells["PriceCreditRef"].Value + "");
                    Pay = dataRow.Cells["Pay"].Value + "" == "" ? 0 : Convert.ToDecimal(dataRow.Cells["Pay"].Value + "");
                    if (MedStatus_Code == "0" || MedStatus_Code == "" || MedStatus_Code == "6")
                        dataRow.DefaultCellStyle.BackColor = Color.DarkGray;//py'w,j0jkp
                    else if (MedStatus_Code == "1" || MedStatus_Code == "7")//จ่ายบางส่วน
                        dataRow.DefaultCellStyle.BackColor = Color.Khaki;
                    else if (MedStatus_Code == "2" || MedStatus_Code == "8")//จ่ายครบ
                        dataRow.DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                    else if (MedStatus_Code == "3")
                        dataRow.DefaultCellStyle.BackColor = Color.LightBlue;

                    else if (MedStatus_Code == "99")//ปิด
                    {
                        dataRow.DefaultCellStyle.BackColor = Color.AntiqueWhite;
                        dataRow.DefaultCellStyle.Font = new Font(dgvData.DefaultCellStyle.Font, FontStyle.Strikeout);
                    }

                    if (Pay + PriceCreditRef != PayByItem)
                    {
                        dataRow.Cells["PayByItem"].Style.BackColor = Color.Gold;
                        //dataRow.Cells["SalePrice"].Style.BackColor = Color.Gold;
                        dataRow.Cells["Pay"].Style.BackColor = Color.Gold;
                        dataRow.Cells["PriceCreditRef"].Style.BackColor = Color.Gold;

                    }
                }

                dgvData.RowsDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
                for (int i = 0; i < dgvData.Columns.Count - 1; i++)
                {
                    dgvData.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                //dgvData.Columns[dgvData.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                for (int i = 0; i < dgvData.Columns.Count; i++)
                {
                    int colw = dgvData.Columns[i].Width;
                    dgvData.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvData.Columns[i].Width = colw;
                }

                dgvData.ClearSelection();
                ngbMain.CurrentPage = pIntseq;
                ngbMain.TotalPage = lngTotalPage;
                ngbMain.TotalRecord = lngTotalRecord;
                ngbMain.Updates();
                DerUtility.MouseOff(this);
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
        }
        private void buttonSave_BtnClick()
        {
            //SaveMedicalSupplies();
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
        //    picImport.Image = AryuwatSystem.Properties.Resources.Import1;
        //}

        //private void picImport_MouseHover(object sender, EventArgs e)
        //{
        //    picImport.Image = AryuwatSystem.Properties.Resources.Import2;
        //    toolTip1.Show("Imports Data From Excel", (Control)sender);
        //}

        private void btnRefresh_BtnClick()
        {
            txtCN.Text = "";
            txtVN.Text = "";
            txtName.Text = "";
            txtProduct.Text = "";
        }
        private void SelectDate(TextBox txt)
        {
            try
            {
                PopDateTime pp = new PopDateTime();
                DateTime d;
                if (txt.Text.Trim() != "")
                    pp.SelecttDate = Convert.ToDateTime(txt.Text.Trim());// DateTime.TryParse(txt.Text, out d) ? d : DateTime.Now;
                else
                    pp.SelecttDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));// DateTime.TryParse(txt.Text, out d) ? d : DateTime.Now;
                //pp.SelecttDate =Convert.ToDateTime(pp.SelecttDate);
                if (pp.ShowDialog() == DialogResult.OK)
                {
                    //txt.Text = pp.SelecttDate.Date.ToString("dd/MM/yyyy");
                    txt.Text = pp.SelecttDate.Date.ToString("yyyy/MM/dd");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FrmSurgicalFeeList_Load(object sender, EventArgs e)
        {
            //if (Entity.MenuPermission.DicMenu != null)
            //{
            //    if (Entity.MenuPermission.DicMenu[menuSurgical.Tag + ""].Contains(Entity.Userinfo.EN))
            //    {
            //        menuSurgical.Visible = true;
            //    }
            //    if (
            //        Entity.MenuPermission.DicMenu[summaryOfTreatmentToolStripMenuItem.Tag + ""].Contains(
            //            Entity.Userinfo.EN))
            //    {
            //        summaryOfTreatmentToolStripMenuItem.Visible = true;
            //    }
            //}
            // BindcboStatus();
            txtEnddate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            txtStartdate.Text = DateTime.Now.AddYears(-5).ToString("yyyy/MM/dd");
            firstload = false;
            // BindFrmSurgicalFee(1);
            //timer1.Start();
            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;
            //uBranch1.ISSecurity = true;
            uBranch1.setBranchValue(Entity.Userinfo.BranchId);
            //if(!(Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN))
            //    uBranch1.Enabled = false; 
        }

        //private void BindcboStatus()
        //{
        //    try
        //    {
        //        DataTable dt = new Business.MedicalOrder().SelectMedicalStatus().Tables[0];
        //        var dr = dt.NewRow();
        //        dr["MedStatus_Code"] = 99;
        //        dr["MedStatus_Name"] = Statics.StrNewRow;
        //        dt.Rows.InsertAt(dr, 0);
        //        cboStatus.Items.Clear();
        //        cboStatus.DataSource = dt;
        //        cboStatus.ValueMember = "MedStatus_Code";
        //        cboStatus.DisplayMember = "MedStatus_Name";

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void buttonFind_BtnClick()
        {
            if (bind)
                BindFrmSurgicalFee(1);
            else
            {
                bind = true;
            }

        }

        private void dgvData_Paint(object sender, PaintEventArgs e)
        {
            //foreach (DataGridViewRow dataRow in dgvData.Rows)
            //{
            //    MedStatus_Code = dataRow.Cells["MedStatus_Code"].Value.ToString();

            //    if (MedStatus_Code == "0" || MedStatus_Code == "")
            //        dgvData.CurrentRow.DefaultCellStyle.BackColor = Color.DarkGray;
            //    if (MedStatus_Code == "1")
            //        dgvData.CurrentRow.DefaultCellStyle.BackColor = Color.Goldenrod;
            //    if (MedStatus_Code == "2")
            //        dgvData.CurrentRow.DefaultCellStyle.BackColor = Color.Green;
            //    if (MedStatus_Code == "3")
            //        dgvData.CurrentRow.DefaultCellStyle.BackColor = Color.LightCoral;
            //}
        }

        private void dgvData_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {

        }

        private void dgvData_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //BindFrmSurgicalFee(1);
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (firstload == false)
                BindFrmSurgicalFee(1);
        }


        private void FrmSurgicalFeeList_Activated(object sender, EventArgs e)
        {
            //BindFrmSurgicalFee(1);
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CurrentRow = e.RowIndex; ;
            TypeCashier = "CN";
            CallForm(CallMode.Preview);
        }

        private void checkBoxNew_CheckedChanged(object sender, EventArgs e)
        {
            if (firstload == false)
                BindFrmSurgicalFee(1);
        }

        private void checkBoxPending_CheckedChanged(object sender, EventArgs e)
        {
            if (firstload == false)
                BindFrmSurgicalFee(1);
        }

        private void checkBoxClose_CheckedChanged(object sender, EventArgs e)
        {
            if (firstload == false)
                BindFrmSurgicalFee(1);
        }
        private void checkBoxOld_CheckedChanged(object sender, EventArgs e)
        {
            if (firstload == false)
                BindFrmSurgicalFee(1);
        }
        private void ToolStripMenuItemUse_Click(object sender, EventArgs e)
        {
            try
            {
                FrmMedicalUseList obj = new FrmMedicalUseList();
                obj.VN = dgvData.Rows[CurrentRow].Cells["VN"].Value + "";
                obj.BackColor = Color.FromArgb(255, 230, 217);
                obj.Show(Statics.frmMain.dockPanel1);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (bind)
                BindFrmSurgicalFee(1);
            else
            {
                bind = true;
            }
        }

        private void ToolStripMenuItemChangeCouse_Click(object sender, EventArgs e)
        {
            try
            {
                new FrmMedicalUseChangCouse
                {
                    SORef = this.dgvData.Rows[this.CurrentRow].Cells["SO"].Value + "",
                    BackColor = Color.FromArgb(170, 0xe8, 0xe5)
                }.Show(Statics.frmMain.dockPanel1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtVN_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                BindFrmSurgicalFee(1);
        }

        private void txtName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                BindFrmSurgicalFee(1);
        }

        private void txtCN_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                BindFrmSurgicalFee(1);
        }

        private void txtSurname_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                BindFrmSurgicalFee(1);
        }

        private void txtStartdate_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelectDate(txtStartdate);
        }

        private void txtEnddate_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelectDate(txtEnddate);
        }

        private void txtStartdate_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                BindFrmSurgicalFee(1);
        }

        private void txtEnddate_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                BindFrmSurgicalFee(1);
        }

        private void dgvData_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex < 0 || e.RowIndex < 0 || ((dgvData.Columns[e.ColumnIndex].Name.ToLower() != "so") && (dgvData.Columns[e.ColumnIndex].Name.ToLower() != "vn")))
                {
                    //panelTootip.Visible = false;
                    toolTip1.Hide(this);
                    return;
                }
                string tt = "";
                //toolTip1.Show(dgvData[e.ColumnIndex,e.RowIndex].Value.ToString(),);
                //toolTip1.Show(dgvData[e.ColumnIndex,e.RowIndex].Value.ToString(), (Control)sender);
                //lbTooltip.Text = dgvData["VN", e.RowIndex].Value.ToString() + Environment.NewLine + dgvData["Sono", e.RowIndex].Value.ToString();
                tt = SelectProductPopup(dgvData["So", e.RowIndex].Value.ToString(), "");
                dgvData.CurrentCell = dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex];
                Point p = new Point(MousePosition.X - 180, MousePosition.Y - 120);
                // Point p = new Point(MousePosition.X , MousePosition.Y );
                Point p2 = this.PointToScreen(p);
                //   panelTootip.Location = p2;
                //panelTootip.Visible = true;

                //toolTip1.SetToolTip(this,tt);
                toolTip1.Show(tt, this, p2.X, p2.Y);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private string SelectProductPopup(string so, string mo)
        {
            string product = "";

            try
            {
                string sql = string.Format("SONo ='{0}'", so);
                var filter = dtListOrg.Select(sql);
                if (filter.Any())
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (DataRow dr in filter)
                    {
                        sb.Append(" " + dr["MS_Name"]);
                        sb.Append(Environment.NewLine);
                    }
                    product = sb.ToString();
                }
            }
            catch (Exception ex)
            {
            }
            return product;
        }

        private void txtVN_MouseClick(object sender, MouseEventArgs e)
        {
            DerUtility.GetSetInputKeyBorad("english");
        }

        private void txtCN_MouseClick(object sender, MouseEventArgs e)
        {
            DerUtility.GetSetInputKeyBorad("english");
        }

        private void txtStartdate_MouseClick(object sender, MouseEventArgs e)
        {
            DerUtility.GetSetInputKeyBorad("english");
        }

        private void txtEnddate_MouseClick(object sender, MouseEventArgs e)
        {
            DerUtility.GetSetInputKeyBorad("english");
        }

        private void txtName_MouseClick(object sender, MouseEventArgs e)
        {
            DerUtility.GetSetInputKeyBorad("thai");
        }

        private void txtProduct_MouseClick(object sender, MouseEventArgs e)
        {
            DerUtility.GetSetInputKeyBorad("english");
        }

        private void txtRefMo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                BindFrmSurgicalFee(1);
        }

        private void txtRefMo_MouseClick(object sender, MouseEventArgs e)
        {
            DerUtility.GetSetInputKeyBorad("english");
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
            ch1 = (DataGridViewCheckBoxCell)dgvData.Rows[dgvData.CurrentRow.Index].Cells[0];

            if (dgvData.Rows[dgvData.CurrentRow.Index].Cells[2].Value.ToString() != "Paid" && dgvData.Rows[dgvData.CurrentRow.Index].Cells[2].Value.ToString() != "CourseClose")
            {
                if (ch1.Value == null)
                    ch1.Value = false;
                switch (ch1.Value.ToString().ToLower())
                {
                    case "true":
                        ch1.Value = false;
                        break;
                    case "false":
                        ch1.Value = true;
                        break;
                }
            }
        }

        GraphicsPath GetRoundPath(RectangleF Rect, int radius)
        {
            float r2 = radius / 2f;
            GraphicsPath GraphPath = new GraphicsPath();
            GraphPath.AddArc(Rect.X, Rect.Y, radius, radius, 180, 90);
            GraphPath.AddLine(Rect.X + r2, Rect.Y, Rect.Width - r2, Rect.Y);
            GraphPath.AddArc(Rect.X + Rect.Width - radius, Rect.Y, radius, radius, 270, 90);
            GraphPath.AddLine(Rect.Width, Rect.Y + r2, Rect.Width, Rect.Height - r2);
            GraphPath.AddArc(Rect.X + Rect.Width - radius,
                             Rect.Y + Rect.Height - radius, radius, radius, 0, 90);
            GraphPath.AddLine(Rect.Width - r2, Rect.Height, Rect.X + r2, Rect.Height);
            GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - radius, radius, radius, 90, 90);
            GraphPath.AddLine(Rect.X, Rect.Height - r2, Rect.X, Rect.Y + r2);
            GraphPath.CloseFigure();
            return GraphPath;
        }
        private void btnPaidAll_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = "";
                List<string> itemselect = new List<string>();
                bool first = true;
                string firstCN = "";
                foreach (DataGridViewRow roow in dgvData.Rows)
                {
                    DataGridViewCheckBoxCell chkchecking = roow.Cells["Select"] as DataGridViewCheckBoxCell;

                    if (Convert.ToBoolean(chkchecking.Value) == true)
                    {
                        if (first)
                        {
                            firstCN = roow.Cells["CN"].Value.ToString();
                            first = false;
                        }

                        if (roow.Cells["CN"].Value.ToString() != firstCN)
                        {
                            MessageBox.Show("รหัสลูกค้าไม่ตรงกัน", "แจ้งเตือน");
                            return;
                        }

                        //msg += "SO:" + roow.Cells["SO"].Value.ToString() + "" + "\r\n";
                        //msg += "MO:" + roow.Cells["VN"].Value.ToString() + "" + "\r\n\r\n";
                        //itemselect.Add(roow.Cells["SO"].Value.ToString() + ";" + roow.Cells["VN"].Value.ToString());
                        itemselect.Add(roow.Cells["SO"].Value.ToString() + ";" + roow.Cells["VN"].Value.ToString());
                    }
                }
                //MessageBox.Show(msg);
                //FrmPaidSelectSOT frmPaidSelectSOT1 = new FrmPaidSelectSOT();
                //frmPaidSelectSOT1.itemselect = itemselect;

                if (itemselect.Count <= 0)
                {
                    MessageBox.Show("กรุณาเลือกรายการ", "แจ้งเตือน"); 
                    return;
                }
                Statics.frmPaidSelectSOT = new FrmPaidSelectSOT();
                Statics.frmPaidSelectSOT.itemselect = itemselect;
                Statics.frmPaidSelectSOT.BackColor = Color.FromArgb(255, 230, 217);
                Statics.frmPaidSelectSOT.Show(Statics.frmMain.dockPanel1);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
