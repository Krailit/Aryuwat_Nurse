using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DermasterSystem.Class;
using Entity;
using WeifenLuo.WinFormsUI.Docking;

namespace DermasterSystem.Forms
{
    public partial class FrmSOTList : DockContent
    {
        private Entity.MedicalSupplies info;
        public Utility.AccessType FormType { get; set; }
        private int? intStatus;
        private int OldrowIndex = 0;
        private int CurrentRow = 0;
        private DataTable dataTable = null;
        private int ID = 0;
        private string MS_CodeOld = "";
        public string TypeCashier;
        bool bind=true;
        private bool firstload = true;
        private string MedStatus_Code = "";
        private string MedStatus_CodeNew = "";
        private string MedStatus_CodePending = "";
        private string MedStatus_CodeClosed = "";
        private int AmountOfUse = 0;
        #region Enum CallMode

        private enum CallMode
        {
            Insert,
            Update,
            Preview
        }
        #endregion
        public FrmSOTList()
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
            btnRefresh.BtnClick += btnRefresh_BtnClick;
            menuEdit.Click += new EventHandler(menuEdit_Click);
            menuDel.Click += new EventHandler(menuDel_Click);
            FormType = Utility.AccessType.Insert;
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

         
            int rowindex = OldrowIndex; //dgvData.CurrentRow.Index;
             if (rowindex == -1) return;
             if (TypeCashier == "EN")
             {
                 Statics.frmSurgicalFeeMain = new FrmSurgicalFeeMain();
                 Statics.frmSurgicalFeeMain.VN = dgvData.Rows[CurrentRow].Cells["VN"].Value + "";
                 Statics.frmSurgicalFeeMain.BackColor = Color.FromArgb(170, 232, 229);
                 Statics.frmSurgicalFeeMain.Show(Statics.frmMain.dockPanel1);


                 //if (cMode == CallMode.Preview)
                 //{
                 //    //Statics.frmSurgicalFee.Text = Statics.StrPreview;
                 //}
                 ////Statics.frmSurgicalFeeMain.VN = dgvData.Rows[rowindex].Cells["VN"].Value + "";
                 ////Statics.frmSurgicalFeeMain.BackColor = Color.FromArgb(170, 232, 229);
                 ////Statics.frmSurgicalFeeMain.Show(Statics.frmMain.dockPanel1);


                 //Statics.frmSurgicalFee = new FrmSurgicalFee();

                 //if (cMode == CallMode.Preview)
                 //{
                 //    Statics.frmSurgicalFee.FormType = Utility.AccessType.DisplayOnly;
                 //    //Statics.frmSurgicalFee.Text = Statics.StrPreview;
                 //}
                 //Statics.frmSurgicalFee.VN = dgvData.Rows[CurrentRow].Cells["VN"].Value + "";
                 //Statics.frmSurgicalFee.BackColor = Color.FromArgb(170, 232, 229);
                 //Statics.frmSurgicalFee.Show(Statics.frmMain.dockPanel1);
             }
             else if (TypeCashier == "CN")
             {
                 Statics.frmSumOfTreatment = new FrmSumOfTreatment();

                 if (cMode == CallMode.Preview)
                 {
                     Statics.frmSumOfTreatment.FormType = Utility.AccessType.DisplayOnly;
                     //Statics.frmSumOfTreatment.Text += Statics.StrPreview;
                 }
                 Statics.frmSumOfTreatment.VN = dgvData.Rows[CurrentRow].Cells["VN"].Value + "";
                 Statics.frmSumOfTreatment.SO = dgvData.Rows[CurrentRow].Cells["SO"].Value + "";
                 Statics.frmSumOfTreatment.BackColor = Color.FromArgb(170, 232, 229);
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
            try
            {
                ToolStripMenuItemUse.Visible = false;
                if (e.Button == MouseButtons.Left)
                {
                    dgvData.ClearSelection();
                    dgvData.Rows[OldrowIndex].Selected = false;
                    dgvData.Rows[e.RowIndex].Selected = true;
                    OldrowIndex = e.RowIndex;
                    CurrentRow = e.RowIndex;
                    string MedStatus_Code = dgvData.Rows[e.RowIndex].Cells["MedStatus_Code"].Value + "";
                    double used =Convert.ToDouble(dgvData.Rows[e.RowIndex].Cells["AmountOfUse"].Value + "");
                    //menuSurgical.Visible = MedStatus_Code != "0";
                    //menuSurgical.Visible = used > 0;
                    if (used == 0 || (MedStatus_Code != "1" && MedStatus_Code!="2"))
                    {
                        menuSurgical.Text = "ไม่สามารถคิดค่ามือได้:เนื่องจาก ค้างชำระ หรือ ยังไม่มีการบันทึกกข้อมูลการใช้";
                        //menuSurgical.Enabled = false;
                    }
                    else
                    {
                        menuSurgical.Text = "Surgical Fee";
                        //menuSurgical.Enabled = true;
                    }
                    
                    contextMenuStrip1.Show(MousePosition);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    //try
                    //{
                    //       ToolStripMenuItemUse.Visible = true;
                    //        dgvData.ClearSelection();
                    //        dgvData.Rows[e.RowIndex].Selected = true;
                    //        CurrentRow = e.RowIndex;
                    //        contextMenuStrip1.Show(MousePosition);
                       
                    //}
                    //catch
                    //{
                    //    return;
                    //}
                }
            }
            catch
            {
                return;
            }
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
                Statics.frmSurgicalFeeList = null;

            this.Close();
        }
        private void SetColumns()
        {
            try
            {
                Utility.SetPropertyDgv(dgvData);

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
                dgvData.Columns.Add("SO", "SO");
                dgvData.Columns.Add("VN", "MO");
                dgvData.Columns.Add("CN", "CN");
                dgvData.Columns.Add("FullNameThai", "ชื่อ-นามสกุล");
                dgvData.Columns.Add("Mobile", "Mobile (มือถือ)");
                dgvData.Columns.Add("SalePrice", "จำนวนเงิน");


                dgvData.Columns["VN"].Width = 100;
                dgvData.Columns["SO"].Width = 100;
                dgvData.Columns["CN"].Width = 100;
                dgvData.Columns["FullNameThai"].Width = 150;
                dgvData.Columns["Mobile"].Width = 200;
                dgvData.Columns["UpdateDate"].Width = 80;
                dgvData.Columns["MedStatus_Code"].Visible = false;
                dgvData.Columns["MedStatus_Name"].Width = 80;
                dgvData.Columns["SalePrice"].Width = 80;
                dgvData.Columns["SalePrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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
                Utility.MouseOn(this);
                dgvData.Rows.Clear();
                var info = new Entity.MedicalOrder() { PageNumber = pIntseq };
                Entity.Customer custInfo = new Customer();

                if (!string.IsNullOrEmpty(txtCN.Text.Trim()))
                {
                    custInfo.CN = "%" + txtCN.Text + "%";
                }
                if (!string.IsNullOrEmpty(txtName.Text))
                {
                    custInfo.TName = "%" + txtName.Text + "%";
                }
                if (!string.IsNullOrEmpty(txtSurname.Text.Trim()))
                {
                    custInfo.TSurname = "%" + txtSurname.Text + "%";
                }
                if (!string.IsNullOrEmpty(txtVN.Text.Trim()))
                {
                    info.SONo = "%" + txtVN.Text + "%";
                }

                info.CustomerInfo = custInfo;
                MedStatus_CodeNew = checkBoxNew.Checked ? "0" : null;
                MedStatus_CodePending = checkBoxPending.Checked ? "1" : null;
                MedStatus_CodeClosed = checkBoxClose.Checked ? "2" : null;
                //info.MedStatus_Code = string.Format("''{0}'',''{1}'',''{2}''", MedStatus_CodeNew, MedStatus_CodePending, MedStatus_CodeClosed);
                info.MedStatus_CodeNew = MedStatus_CodeNew;
                info.MedStatus_CodePending = MedStatus_CodePending;
                info.MedStatus_CodeClosed = MedStatus_CodeClosed;
                //info.MedStatus_Unpaid = checkBoxUnpaid.Checked ? "6" : null;
                //info.MedStatus_Deposit = checkBoxDeposit.Checked ? "7" : null;
                //info.MedStatus_Paid = checkBoxPaid.Checked ? "8" : null;
                DataTable dt = new Business.MedicalOrder().SelectMedicalOrderSOTPaging(info).Tables[0];
                decimal SalePrice = 0;
                long lngTotalPage = 0;
                long lngTotalRecord = 0;
                if (dt.Rows.Count <= 0)
                {
                    ngbMain.CurrentPage = 0;
                    ngbMain.TotalPage = 0;
                    ngbMain.TotalRecord = 0;
                    ngbMain.Updates();
                    Utility.MouseOff(this);
                   // Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "ไม่พบข้อมูลในระบบ");
                    return;
                }
                foreach (DataRowView item in dt.DefaultView)
                {
                    if (item["SONo"] + "" == "")continue;
                    else
	                {
                        if (item["VN"] + "" != "") continue;
	                } 

                    SalePrice = item["SalePrice"] + "" == "" ? 0 : Convert.ToDecimal(item["SalePrice"] + "");
                    var myItems = new[]
                                      {
                                          item["MedStatus_Code"] + "",
                                          item["MedStatus_Name"] + "",
                                           String.Format("{0:dd/MM/yyyy}",DateTime.Parse( item["UpdateDate"]+"")),
                                           //DateTime.Parse( item["UpdateDate"]+"")+"",
                                           
                                           //item["UpdateDate"]+"",
                                          item["SONo"] + "",
                                          item["VN"] + "",
                                          item["CN"]+"",
                                          item["FullNameThai"] + ""!=""?item["FullNameThai"] + "":item["FullNameEng"] + "",
                                          //item["FullNameEng"] + "",
                                          //item["gender"] + "" ,
                                          item["Mobile"] + "",
                                          SalePrice.ToString("###,###,###.##"),
                                          //item["Address"] + "",
                                         
                                      };
                    dgvData.Rows.Add(myItems);
                    if (lngTotalPage != 0) continue;
                    Utility.FindTotalPage(Convert.ToInt32(item["rowTotal"].ToString()), ref lngTotalPage);
                    lngTotalRecord = Convert.ToInt32(item["rowTotal"].ToString());
                }
                foreach (DataGridViewRow dataRow in dgvData.Rows)
                {
                    MedStatus_Code = dataRow.Cells["MedStatus_Code"].Value.ToString();

                    if (MedStatus_Code == "0" || MedStatus_Code == "" || MedStatus_Code == "6")
                        dataRow.DefaultCellStyle.BackColor = Color.DarkGray;
                    if (MedStatus_Code == "1" || MedStatus_Code == "7")
                        dataRow.DefaultCellStyle.BackColor = Color.Khaki;
                    if (MedStatus_Code == "2" || MedStatus_Code == "8")
                        dataRow.DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                    if (MedStatus_Code == "3")
                        dataRow.DefaultCellStyle.BackColor = Color.LightBlue;
                }
                dgvData.ClearSelection();
                ngbMain.CurrentPage = pIntseq;
                ngbMain.TotalPage = lngTotalPage;
                ngbMain.TotalRecord = lngTotalRecord;
                ngbMain.Updates();
                Utility.MouseOff(this);
            }
            catch (Exception ex)
            {
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeError, ex.Message);
                Utility.MouseOff(this);
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
        //    picImport.Image = DermasterSystem.Properties.Resources.Import1;
        //}

        //private void picImport_MouseHover(object sender, EventArgs e)
        //{
        //    picImport.Image = DermasterSystem.Properties.Resources.Import2;
        //    toolTip1.Show("Imports Data From Excel", (Control)sender);
        //}

        private void btnRefresh_BtnClick()
        {
            txtCN.Text = "";
            txtVN.Text = "";
            txtName.Text = "";
            txtSurname.Text = "";
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
            firstload = false;
            BindFrmSurgicalFee(1);
           timer1.Start();
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
            BindFrmSurgicalFee(1);
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

        private void ToolStripMenuItemUse_Click(object sender, EventArgs e)
        {
            try
            {
                FrmMedicalUseList obj = new FrmMedicalUseList();
                obj.VN = dgvData.Rows[CurrentRow].Cells["VN"].Value + "";
                obj.BackColor = Color.FromArgb(170, 232, 229);
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

    }
}
