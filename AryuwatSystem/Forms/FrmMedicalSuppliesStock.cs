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
using AryuwatSystem.Forms.FRMReport;
using System.IO;
using System.Diagnostics;

namespace AryuwatSystem.Forms
{
    public partial class FrmMedicalSuppliesStock : DockContent
    {
        private Entity.MedicalSupplies info;
        public DerUtility.AccessType FormType { get; set; }
        private int? intStatus;
        private int OldrowIndex = 0;
        private int CurrentrowIndex = 0;
        private DataTable dataTable = new DataTable();
        private int ID = 0;
        private string MS_CodeOld = "";
        private int pIntseq = 1;
        public FrmMedicalSuppliesStock()
        {
            InitializeComponent();
           // SetColumns();
            BindCboMedicalSection();
            //BindCboCourseDuration();
            BindCboUnit();
            BindCboPurChase_Operation();
            BindCboLocation();
            txtCode.Text = "";
            //BindMedicalSupplies(1);
            ngbMain.MoveFirst += ngbMain_MoveFirst;
            ngbMain.MoveNext += ngbMain_MoveNext;
            ngbMain.MoveLast += ngbMain_MoveLast;
            ngbMain.MovePrevious += ngbMain_MovePrevious;
            //dgvData.RowPostPaint += dgvData_RowPostPaint;
            //dgvData.RowPostPaint += dgvData_RowPostPaint;
            dgvData.CellMouseClick += dgvData_CellMouseClick;
            //cboEXpire.SelectedIndexChanged+=new EventHandler(cboDuration_SelectedIndexChanged);
            menuEdit.Click += new EventHandler(menuEdit_Click);
            menuPreview.Click += new EventHandler(menuPreview_Click);
            menuDel.Click += new EventHandler(menuDel_Click);
            FormType = DerUtility.AccessType.Insert;
            this.Closing += new CancelEventHandler(FrmMedicalSuppliesStock_Closing);
            uBranch1.SelectedChanged += new EventHandler(uBranch1_SelectedChanged);
        }

     
        private void BindCboLocation()
        {
            try
            {
                Entity.MedicalSupplies info = new MedicalSupplies();
                info.QueryType = "SUPPLIER";
                info.StartDate = DateTime.Now;
                info.EndDate = DateTime.Now;

                DataTable dtSUPPLIER = new Business.MedicalSupplies().SelectStock(info).Tables[1];

                var dr = dtSUPPLIER.NewRow();
                dr["LocationID"] = "";
                dr["Location_Detail"] = "";
                dtSUPPLIER.Rows.InsertAt(dr, 0);
                cboLocation.Items.Clear();
                cboLocation.BeginUpdate();
                cboLocation.DataSource = dtSUPPLIER;
                cboLocation.ValueMember = "LocationID";
                cboLocation.DisplayMember = "Location_Detail";

                cboLocation.EndUpdate();
                //AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                //foreach (DataRow row in dtSUPPLIER.Rows)
                //{
                //    if (row["LocationID"] + "" == "") continue;
                //    data.Add(row["Location_Detail"] + "");
                //}
                //cboLocation.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //cboLocation.AutoCompleteSource = AutoCompleteSource.CustomSource;
                //cboLocation.AutoCompleteCustomSource = data;
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }
        }
        private void cboDuration_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(cboEXpire.SelectedIndex!=0)
            //{
            //    lbNC.Visible = true;
            //    txtNC.Visible = true;
            //}
            //else
            //{
            //    lbNC.Visible = false;
            //    txtNC.Visible = false;
            //}
        }

        void FrmMedicalSuppliesStock_Closing(object sender, CancelEventArgs e)
        {
            Statics.frmMedicalSuppliesStock = null;
        }
        #region Event


        private void menuEdit_Click(object sender, EventArgs e)
        {
            EditMedicalSupplies();
            //CallForm(CallMode.Update);
        }

        private void menuPreview_Click(object sender, EventArgs e)
        {
            //CallForm(CallMode.Preview);
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
                    if(dgvData.Rows.Count>OldrowIndex)
                    dgvData.Rows[OldrowIndex].Selected = false;

                    dgvData.Rows[e.RowIndex].Selected = true;
                    OldrowIndex = e.RowIndex;
                    contextMenuStrip1.Show(MousePosition);
                }
            }
            catch
            {
               // return;
            }
        }
        private void ngbMain_MoveFirst()
        {
            BindMedicalSupplies(1);
        }

        private void ngbMain_MoveLast()
        {
            BindMedicalSupplies(Convert.ToInt32(ngbMain.TotalPage));
        }

        private void ngbMain_MoveNext()
        {
            BindMedicalSupplies(Convert.ToInt32(Convert.ToInt32(ngbMain.CurrentPage) + 1));
        }

        private void ngbMain_MovePrevious()
        {
            BindMedicalSupplies(Convert.ToInt32(Convert.ToInt32(ngbMain.CurrentPage) - 1));
        }

        //private void dgvData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        //{
        //    var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
        //    e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
        //                          e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        //}


        #endregion

        private void DeleteData()
        {
            //if (Utility.PopMsg(Utility.EnuMsgType.MsgTypeConfirmYesNo, "ยืนยันการลบข้อมูล", "ลบข้อมูล") == DialogResult.Yes)
            //{
            if (dgvData.CurrentRow.Index == -1) return;
            if (DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirmYesNo,
                               Statics.StrConfirmDelete + dgvData.CurrentRow.Cells["รหัส"].Value + " "+dgvData.CurrentRow.Cells["ชื่อ"].Value + "") !=
                DialogResult.Yes) return;
            try
            {
                if (new Business.MedicalSupplies().DeleteSuppliesStock(dgvData.CurrentRow.Cells["id"].Value + "") == 1)
                {
                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, Statics.StrMsgDeleteComplete);
                    BindMedicalSupplies(1);
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
            Statics.frmMedicalSuppliesStock = null;
            this.Close();
        }
        private void SetColumns()
        {
            DerUtility.SetPropertyDgv(dgvData);
            dgvData.Columns.Add("MS_code", "Code");
            dgvData.Columns.Add("MS_Name", "Name");
            dgvData.Columns.Add("MS_Detail", "Detail");
            dgvData.Columns.Add("MS_CLPrice", "CL Price");
            dgvData.Columns.Add("MS_CAPrice", "CA Price");
            dgvData.Columns.Add("MS_CMPrice", "CM Price");
            dgvData.Columns.Add("MS_Type", "Type");
            dgvData.Columns.Add("MS_Number_C", "Course Number");
            dgvData.Columns.Add("MS_Instock", "Instock");
            dgvData.Columns.Add("MS_Cost", "Average Cost");
            dgvData.Columns.Add("MS_CourseDuration", "Cycle day");
            
            dgvData.Columns.Add("UnitName", "Unit");
            dgvData.Columns.Add("FeeRate", "Fee Rate");
            dgvData.Columns.Add("FeeRate2", "Fee Rate 2");
            dgvData.Columns.Add("MaxDiscount", "Max Discount %");
            dgvData.Columns.Add("Operation_Name", "Operation");
            dgvData.Columns.Add("Purchase_Name", "Purchase");
            dgvData.Columns.Add("BranchName", "Branch");
            
            //dgvData.Columns["MS_code"].Visible = false;
            dgvData.Columns["MS_code"].Width = 100;
            dgvData.Columns["MS_Name"].Width = 150;
            dgvData.Columns["MS_Detail"].Width = 150;
            dgvData.Columns["MS_CLPrice"].Width = 80;
            dgvData.Columns["MS_CAPrice"].Width = 200;
            dgvData.Columns["MS_CMPrice"].Width = 200;
            dgvData.Columns["MS_Type"].Width = 50;
            dgvData.Columns["MS_Number_C"].Width = 50;
            dgvData.Columns["MS_CourseDuration"].Width = 50;
            dgvData.Columns["MaxDiscount"].Width = 50;

        }

        private void BindCboUnit()
        {
            try
            {
                var ds = new Business.MedicalSupplies().SelectUnit();
                var dr = ds.Tables[0].NewRow();
                dr["UnitCode"] = "";
                dr["UnitName"] = Statics.StrValidate;
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cboMainUnit.Items.Clear();
                cboMainUnit.BeginUpdate();
                cboMainUnit.DataSource = ds.Tables[0];
                cboMainUnit.ValueMember = "UnitCode";
                cboMainUnit.DisplayMember = "UnitName";
                cboMainUnit.EndUpdate();

       
               
                cboSubUnit.Items.Clear();
                cboSubUnit.BeginUpdate();
                cboSubUnit.DataSource = ds.Tables[0].Copy();
                cboSubUnit.ValueMember = "UnitCode";
                cboSubUnit.DisplayMember = "UnitName";
                cboSubUnit.EndUpdate();

                


            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }
        }
        //private void BindCboCourseDuration()
        //{
        //    try
        //    {
        //        var ds = new Business.MedicalSupplies().SelectCourseDuration();
        //        var dr = ds.Tables[0].NewRow();
        //        dr["CD_Code"] = "";
        //        dr["CD_Name"] = Statics.StrValidate;
        //        ds.Tables[0].Rows.InsertAt(dr, 0);
        //        cboEXpire.Items.Clear();
        //        cboEXpire.BeginUpdate();
        //        cboEXpire.DataSource = ds.Tables[0];
        //        cboEXpire.ValueMember = "CD_Code";
        //        cboEXpire.DisplayMember = "CD_Name";

        //        cboEXpire.EndUpdate();


        //    }
        //    catch (Exception ex)
        //    {
        //        DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
        //    }
        //}
        private void BindCboMedicalSection()
        {
            try
            {
                var ds = new Business.MedicalSupplies().SelectMedicalSectionStock();
                var dr = ds.Tables[0].NewRow();
                dr["MS_Section"] = "";
                dr["MS_Section"] = Statics.StrValidate;
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cboSection.Items.Clear();
                cboSection.BeginUpdate();
                cboSection.DataSource = ds.Tables[0];
                cboSection.ValueMember = "MS_Section";
                cboSection.DisplayMember = "MS_Section";

                cboSection.EndUpdate();


            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }
        }
        private void BindCboPurChase_Operation()
        {
            try
            {


                //var ds2 = new Business.MedicalSupplies().SelectOperation();
                //var dr2 = ds2.Tables[0].NewRow();
                //dr2["Setting_Code"] = 0;
                //dr2["Setting_Name"] = Statics.StrValidate;
                //dr2["Setting_Type"] = Statics.StrValidate;
                //ds2.Tables[0].Rows.InsertAt(dr2, 0);
                //// cboOperating.Items.Clear();

                //cboOperating.BeginUpdate();
                //cboOperating.DataSource = ds2.Tables[0];
                //cboOperating.ValueMember = "Setting_Code";
                //cboOperating.DisplayMember = "Setting_Name";
                //cboOperating.EndUpdate();

                //var ds = new Business.MedicalSupplies().SelectPurChase();
                //var dr = ds.Tables[0].NewRow();
                //dr["Setting_Code"] = 0;
                //dr["Setting_Name"] = Statics.StrValidate;
                //dr["Setting_Type"] = Statics.StrValidate;
                //ds.Tables[0].Rows.InsertAt(dr, 0);
                //// cboPurchase.Items.Clear();

                //cboPurchase.BeginUpdate();
                //cboPurchase.DataSource = ds.Tables[0];
                //cboPurchase.ValueMember = "Setting_Code";
                //cboPurchase.DisplayMember = "Setting_Name";
                //cboPurchase.EndUpdate();

                var ds3 = new Business.Branch().SelectBranchAll();
                var dr3 = ds3.Tables[0].NewRow();
                dr3["BranchID"] = 0;
                dr3["BranchName"] = Statics.StrValidate;
                ds3.Tables[0].Rows.InsertAt(dr3, 0);
                // cboPurchase.Items.Clear();

                cboBranch.BeginUpdate();
                cboBranch.DataSource = ds3.Tables[0];
                cboBranch.ValueMember = "BranchID";
                cboBranch.DisplayMember = "BranchName";
                cboBranch.EndUpdate();
                cboBranch.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                //DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }
        }

        public void BindMedicalSupplies(int _pIntseq)
        {
            try
            {
                DerUtility.MouseOn(this);
                //dgvData.Rows.Clear();
                pIntseq = _pIntseq;
                dgvData.DataSource = null;
                 info = new Entity.MedicalSupplies() { PageNumber = _pIntseq };
                if (!string.IsNullOrEmpty(txtFindCode.Text.Trim()))
                {
                    info.MS_Code = "%" + txtFindCode.Text + "%";
                }
                if (!string.IsNullOrEmpty(txtFindName.Text))
                {
                    info.MS_Name = "%" + txtFindName.Text + "%";
                }
                info.QueryType = "SEARCHSTOCK";
                info.StartDate = DateTime.Now;
                info.EndDate = DateTime.Now;
                info.BranchID = uBranch1.BranchId;

                dataTable = new Business.MedicalSupplies().SelectMedicalSuppliesPaging(info).Tables[0];
                
                long lngTotalPage = 0;
                long lngTotalRecord = 0;
                if (dataTable.Rows.Count <= 0)
                {
                    ngbMain.CurrentPage = 0;
                    ngbMain.TotalPage = 0;
                    ngbMain.TotalRecord = 0;
                    ngbMain.Updates();
                    DerUtility.MouseOff(this);
                    //Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "ไม่พบข้อมูลในระบบ");
                    return;
                }
                //foreach (DataRowView item in dt.DefaultView)
                //{
                //    var myItems = new[]
                //                      {
                //                          item["MS_code"] + "",
                //                          item["MS_Name"]+"",
                //                          item["MS_Detail"] + "",
                //                          string.IsNullOrEmpty(item["MS_CLPrice"] + "") ? "0" : Convert.ToDouble(item["MS_CLPrice"] + "").ToString("###,###.##"),
                //                          string.IsNullOrEmpty(item["MS_CAPrice"] + "") ? "0" : Convert.ToDouble(item["MS_CAPrice"] + "").ToString("###,###.##"),
                //                          string.IsNullOrEmpty(item["MS_CMPrice"] + "") ? "0" : Convert.ToDouble(item["MS_CMPrice"] + "").ToString("###,###.##"),
                //                          item["MS_Type"] + "" ,
                //                          item["MS_Number_C"] + "" ,
                //                          item["MS_Instock"] + "" ,
                //                          item["MS_Cost"] + "" ,
                //                          item["MS_CourseDuration"] + "" ,
                                          
                //                          item["UnitName"] + "" ,
                //                          string.IsNullOrEmpty(item["FeeRate"] + "") ? "0" : Convert.ToDouble(item["FeeRate"] + "").ToString("###,###.##"),
                //                          string.IsNullOrEmpty(item["FeeRate2"] + "") ? "0" : Convert.ToDouble(item["FeeRate2"] + "").ToString("###,###.##"),
                //                          string.IsNullOrEmpty(item["MaxDiscount"] + "") ? "" : Convert.ToDouble(item["MaxDiscount"] + "").ToString("###,###.##"),
                //                          item["Operation_Name"] + "" ,
                //                          item["Purchase_Name"] + "" ,
                //                          item["BranchName"] + "" 
                //                      };
                //    dgvData.Rows.Add(myItems);
                //    if (lngTotalPage != 0) continue;
                //    DerUtility.FindTotalPage(Convert.ToInt32(item["rowTotal"].ToString()), ref lngTotalPage);
                //    lngTotalRecord = Convert.ToInt32(item["rowTotal"].ToString());
                  
                //}
                
                //dgvData.Columns["MS_CLPrice"].DefaultCellStyle.Alignment=DataGridViewContentAlignment.BottomRight;
                //dgvData.Columns["MS_CAPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                //dgvData.Columns["MS_Type"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                //dgvData.Columns["MS_Number_C"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                //dgvData.Columns["FeeRate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                //dgvData.Columns["FeeRate2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                //dgvData.Columns["MaxDiscount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;

                dgvData.DataSource = null;
                dgvData.DataSource = dataTable;
                dgvData.Columns["id"].Visible = false;

         
                //dgvData.Columns[dgvData.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dgvData.AlternatingRowsDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
                for (int i = 0; i < dgvData.Columns.Count - 1; i++)
                {
                    dgvData.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }
                dgvData.RowsDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
                for (int i = 0; i < dgvData.Columns.Count; i++)
                {
                    int colw = dgvData.Columns[i].Width;
                    dgvData.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvData.Columns[i].Width = colw;
                }



                ngbMain.CurrentPage = _pIntseq;
                ngbMain.TotalPage = lngTotalPage;
                ngbMain.TotalRecord = lngTotalRecord;
                ngbMain.Updates();
                DerUtility.MouseOff(this);
              //  RefreshText();

            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
            finally
            {
               // SetNumberAllRows();
            }
        }

        private void SetNumberAllRows()
        {
            long rowStart = (DerUtility.ROW_PER_PAGE * (pIntseq - 1));
            for (int i = 0; i < dgvData.Rows.Count; i++)
            {
                rowStart += 1;
                dgvData.Rows[i].HeaderCell.Value = rowStart.ToString();
            }
        }

       private void RefreshText()
        {
            txtCode.Text = "";
                txtName.Text = "";
                txtDetail.Text = "";
                txtCLPrice.Text = "";
                txtInstock.Text = "";
                //txtCMPrice.Text = "";
                cboMainUnit.SelectedIndex = 0;
                //cboEXpire.SelectedIndex =0;
                cboSection.SelectedIndex = 0;
        }
        private void buttonSave_BtnClick()
        {
            SaveMedicalSupplies();
           
        }
        private void SaveMedicalSupplies()
        {
             try
            {
                info = new MedicalSupplies();
                //if (txtCode.Text.Length < 8 || txtName.Text.Length<5)
                if (txtCodeRef.Text.Length < 5)
                {
                    MessageBox.Show("Code name is short");
                    txtCode.Focus(); 
                    return;
                }
                info.MS_Code = txtCode.Text;
                info.MS_Code_Ref = txtCodeRef.Text;
                info.MS_Name = txtName.Text;
                info.MS_Detail = txtDetail.Text;
                info.MS_CLPrice = txtCLPrice.Text=="" ? 0 : Convert.ToDouble(txtCLPrice.Text);
                info.MS_Instock = txtInstock.Text == "" ? 0 : Convert.ToDouble(txtInstock.Text);
                //info.MS_CMPrice = txtCMPrice.Text == "" ? 0 : Convert.ToDouble(txtCMPrice.Text);
                info.MS_Unit = cboMainUnit.SelectedValue+"";
                info.MS_SubUnit = cboSubUnit.SelectedValue + "";
                info.MS_Unit = cboMainUnit.SelectedValue+"";
                info.Number_C = txtNC.Text == "" ? 0 : Convert.ToInt16(txtNC.Text);
                info.AnountPerMainUnit = txtAnountPerMainUnit.Text == "" ? 0 : Convert.ToInt16(txtAnountPerMainUnit.Text.Replace(",","")); 
                info.MS_Section = cboSection.SelectedValue+"";
                //info.MS_Type =radioButtonS.Checked? "S" : "C";
                info.Vat = checkBoxVat.Checked ? "Y" : "N";

                info.Active = checkBoxActive.Checked ? "Y" : "N";
                
                info.BranchID = cboBranch.SelectedValue + "";
                //info.PurchaseID = cboPurchase.SelectedValue + "";
                //info.OperationID = cboOperating.SelectedValue + "";
                info.LocationID = cboLocation.SelectedValue + "";
                info.ExpireDate = DateTime.Now.Date == dtpExpDate.Value.Date ? dtpExpDate.Value.AddYears(1) : dtpExpDate.Value;

               // info.MaxDiscount = textboxFormatDoubleMaxDiscount.Text == "" ? 0 : Convert.ToDouble(textboxFormatDoubleMaxDiscount.Text); 

                //if (cboEXpire.SelectedIndex != 0 && info.Number_C==0)
                //{
                //    MessageBox.Show("Input Number/Course ");
                //    txtNC.Focus(); return;
                //}
              //  info.FeeRate = txtFeerate.Text == "" ? 0 : Convert.ToDouble(txtFeerate.Text);
                //info.FeeRate2 = txtFeerate2.Text == "" ? 0 : Convert.ToDouble(txtFeerate2.Text);
                //if (string.IsNullOrEmpty(cboSection.SelectedValue+""))
                //{
                //    MessageBox.Show("โปรดระบุ Section");
                //    return;
                //}
                if (string.IsNullOrEmpty(info.MS_Code))
                {
                    MessageBox.Show("โปรดระบุ Code");
                    return;
                }
                


                switch (FormType)
                {

                    case DerUtility.AccessType.Insert:
                        if (txtCode.Text.Length < 8)
                        {
                            //MessageBox.Show("โปรดระบุ Code ให้ถูกต้อง");
                            //return;
                        }
                    //
                        DataTable dt = new Business.MedicalSupplies().CheckCodeStock(txtCodeRef.Text, cboBranch.SelectedValue + "").Tables[0];
                     if (dt.Rows.Count > 0)
                     {
                         MessageBox.Show("Code นี้ถูกใช้ไปแล้ว");
                         txtCodeRef.Focus();
                         
                         //txtCode.Text = "";
                         txtCodeRef.SelectAll();
                         //return;
                     }
                     else
                     {
                         info.QueryType = "INSERTSTOCK";
                         intStatus = new Business.MedicalSupplies().InsertMedicalSupplies(ref info);
                         //if (intStatus == 1)
                         //{
                             //BindMedicalSupplies(1);
                             CallRefresh();
                             DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, Statics.StrMsgInsertComplete);
                             txtCode.ReadOnly = false;
                         //}
                         //else
                         //{
                         //    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation,
                         //                   Statics.StrMsgCannotSave + " ข้อมูลผิดพลาด");
                         //}
                     }
                        break;
                    case DerUtility.AccessType.Update:
                        info.QueryType = "UPDATESTOCK";
                        info.ID = ID;
                        if (MS_CodeOld != txtCode.Text.Trim())
                        {
                            //dt = new Business.MedicalSupplies().CheckCode(txtCode.Text).Tables[0];
                            //if (dt.Rows.Count > 0)//ซ้ำ
                            //{
                            //    MessageBox.Show("Code นี้ถูกใช้ไปแล้ว");
                            //    txtCode.Focus();
                            //    //txtCode.Text = "";
                            //    txtCode.SelectAll();
                            //    //return;
                            //}
                            //else// ไม่ซ้ำ ให้อัปเดท
                            //{
                                intStatus = new Business.MedicalSupplies().InsertMedicalSupplies(ref info);
                                if (intStatus > 0)
                                {
                                    //BindMedicalSupplies(1);
                                    CallRefresh();
                                    dgvData.Rows[CurrentrowIndex].DefaultCellStyle.BackColor = Color.Aqua;
                                    dgvData.Rows[CurrentrowIndex].Cells["จำนวน"].Value = Convert.ToDouble(info.MS_Instock).ToString("###,###,###.##");
                                    dgvData.Rows[CurrentrowIndex].Cells["ราคาเฉลี่ย"].Value = Convert.ToDouble(info.MS_CLPrice).ToString("###,###,###.##");
                                    dgvData.Rows[CurrentrowIndex].Cells["มูลค่ารวม"].Value = Convert.ToDouble(info.MS_Instock * info.MS_CLPrice).ToString("###,###,###.##");
                                    dgvData.Rows[CurrentrowIndex].Cells["วันหมดอายุ"].Value = info.ExpireDate;
                                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, Statics.StrMsgUpdateComplete);
                                    //txtCode.ReadOnly = false;
                                }
                                else
                                {
                                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation,
                                                   Statics.StrMsgCannotSave + " ข้อมูลผิดพลาด");
                                }
                                FormType = DerUtility.AccessType.Insert;
                            //}
                        }
                        else
                        {

                            intStatus = new Business.MedicalSupplies().InsertMedicalSupplies(ref info);
                            if (intStatus > 0)
                            {
                                //BindMedicalSupplies(1);
                                CallRefresh();
                                dgvData.Rows[CurrentrowIndex].DefaultCellStyle.BackColor = Color.Aqua;
                                dgvData.Rows[CurrentrowIndex].Cells["จำนวน"].Value = Convert.ToDouble(info.MS_Instock).ToString("###,###,###.##");
                                dgvData.Rows[CurrentrowIndex].Cells["ราคาเฉลี่ย"].Value = Convert.ToDouble(info.MS_CLPrice).ToString("###,###,###.##");
                                dgvData.Rows[CurrentrowIndex].Cells["มูลค่ารวม"].Value = Convert.ToDouble(info.MS_Instock * info.MS_CLPrice).ToString("###,###,###.##");
                                dgvData.Rows[CurrentrowIndex].Cells["วันหมดอายุ"].Value = info.ExpireDate;
                                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, Statics.StrMsgUpdateComplete);
                                //txtCode.ReadOnly = false;
                            }
                            else
                            {
                                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation,
                                               Statics.StrMsgCannotSave + " ข้อมูลผิดพลาด");
                            }
                            FormType = DerUtility.AccessType.Insert;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ClearTxt()
        {
            //txtCode.Text = "";
            //txtName.Text = "";
            //txtCAPrice
            //BindMedicalSupplies(1);
        }
        private void EditMedicalSupplies()
        {
            try
            {
                if (dgvData.CurrentRow.Index == -1) return;
                string sql = "id='" + dgvData.CurrentRow.Cells["id"].Value + "'";
                DataRow[] dataRow = dataTable.Select(sql);
                FormType = DerUtility.AccessType.Update;

                ID =Convert.ToInt32(dataRow[0]["ID"].ToString());
                cboMainUnit.SelectedValue = dataRow[0]["MainUnitCode"].ToString();
                cboSubUnit.SelectedValue = dataRow[0]["SubUnitCode"].ToString();
                //cboEXpire.SelectedValue = dataRow[0]["MS_CourseDuration"].ToString();
                cboSection.SelectedValue = dataRow[0]["MS_Section"].ToString();
                //txtCode.ReadOnly = true;
                txtCode.Text = MS_CodeOld = dataRow[0]["รหัส"].ToString();
                txtCodeRef.Text = dataRow[0]["รหัสเก่า"].ToString();
                
                txtName.Text = dataRow[0]["ชื่อ"].ToString();
                txtDetail.Text = dataRow[0]["รายละเอียด"].ToString();


                txtCLPrice.Text = string.IsNullOrEmpty(dataRow[0]["ราคาเฉลี่ย"] + "") ? "0" : Convert.ToDouble(dataRow[0]["ราคาเฉลี่ย"] + "").ToString("###,###.##");
                txtInstock.Text = string.IsNullOrEmpty(dataRow[0]["จำนวน"] + "") ? "0" : Convert.ToDouble(dataRow[0]["จำนวน"] + "").ToString("###,###.##");
                txtAnountPerMainUnit.Text = string.IsNullOrEmpty(dataRow[0]["AnountPerMainUnit"] + "") ? "0" : Convert.ToDouble(dataRow[0]["AnountPerMainUnit"] + "").ToString("###,###.##");
                
                dtpExpDate.Value = string.IsNullOrEmpty(dataRow[0]["วันหมดอายุ"] + "") ? DateTime.Now : Convert.ToDateTime(dataRow[0]["วันหมดอายุ"] + "");
                //txtCMPrice.Text = string.IsNullOrEmpty(dataRow[0]["MS_CMPrice"] + "") ? "0" : Convert.ToDouble(dataRow[0]["MS_CMPrice"] + "").ToString("###,###.##"); 
                //txtNC.Text = dataRow[0]["MS_Number_C"].ToString();
                //txtFeerate.Text = string.IsNullOrEmpty(dataRow[0]["FeeRate"] + "") ? "0" : Convert.ToDouble(dataRow[0]["FeeRate"] + "").ToString("###,###.##"); 
                //txtFeerate2.Text = string.IsNullOrEmpty(dataRow[0]["FeeRate2"] + "") ? "0" : Convert.ToDouble(dataRow[0]["FeeRate2"] + "").ToString("###,###.##");
                //textboxFormatDoubleMaxDiscount.Text = string.IsNullOrEmpty(dataRow[0]["MaxDiscount"] + "") ? "" : Convert.ToDouble(dataRow[0]["MaxDiscount"] + "").ToString("###,###.##");
                //checkBoxVat.Checked = dataRow[0]["Vat"] + ""=="Y";
                //dtpDateSave.Value = string.IsNullOrEmpty(item["DateSave"] + "") ? DateTime.Now : Convert.ToDateTime(resultdt);
                checkBoxActive.Checked = dataRow[0]["Active"] + "" == "Y";

                //radioButtonS.Checked = dataRow[0]["MS_Type"]+""=="S";

                cboBranch.SelectedValue = dataRow[0]["BranchID"].ToString();
                //cboOperating.SelectedValue = dataRow[0]["OperationID"].ToString();
                //cboPurchase.SelectedValue = dataRow[0]["PurchaseID"].ToString();
                cboLocation.SelectedValue = dataRow[0]["LocationID"].ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void buttonFind_BtnClick()
        {
            BindMedicalSupplies(1);
        }

        private void cboSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtCode.Text = cboSection.SelectedValue.ToString().Trim();
                txtCode.ReadOnly = false;
            }
            catch (Exception)
            {
            }
        }

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

        private void picImport_MouseLeave(object sender, EventArgs e)
        {
            picImport.Image = AryuwatSystem.Properties.Resources.Import1;
        }

        private void picImport_MouseHover(object sender, EventArgs e)
        {
            picImport.Image = AryuwatSystem.Properties.Resources.Import2;
            toolTip1.Show("Imports Data From Excel", (Control)sender);
        }

        private void CallRefresh()
        {
            try
            {
                txtCode.Text = "";
                txtCodeRef.Text = "";
                txtName.Text = "";
                txtDetail.Text = "";
                txtCLPrice.Text = "";
                txtInstock.Text = "";
                txtAnountPerMainUnit.Text = "";
                //txtCMPrice.Text = "";
                cboMainUnit.SelectedIndex = 0;
                ///cboEXpire.SelectedIndex = 0;
                cboMainUnit.SelectedIndex = 0;
                txtNC.Text = "";
                cboSection.SelectedIndex = 0;
                //cboEXpire.SelectedIndex = 0;
                checkBoxVat.Checked = false;

                cboBranch.SelectedIndex = 0;
                //cboPurchase.SelectedIndex = 0;
                //cboOperating.SelectedIndex = 0;
                //BindMedicalSupplies(1);
                buttonSave.Enabled = true;
                FormType = DerUtility.AccessType.Insert;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void btnRefresh_BtnClick()
        {
            CallRefresh();
        }

        private void dgvData_Sorted(object sender, EventArgs e)
        {
            SetNumberAllRows();
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           if (e.RowIndex >= 0)
            {
                EditMedicalSupplies();
                buttonSave.Enabled = true;
                CurrentrowIndex = e.RowIndex;
               
            }
        }

        private void txtFindCode_TextChanged(object sender, EventArgs e)
        {
            //BindMedicalSupplies(1); //BindMedicalSupplies(1);
            try
            {
                dataTable.DefaultView.RowFilter = string.Format("[รหัสเก่า] LIKE '%{0}%' or รหัส LIKE '%{1}%'", txtFindCode.Text, txtFindCode.Text);
            }
            catch (Exception)
            {

            }
        }

        private void txtFindName_TextChanged(object sender, EventArgs e)
        {
            //BindMedicalSupplies(1);
            try
            {
                dataTable.DefaultView.RowFilter = string.Format("[ชื่อ] LIKE '%{0}%'", txtFindName.Text);
            }
            catch (Exception)
            {


            }
        }

        private void lbNC_Click(object sender, EventArgs e)
        {

        }

        //private void radioButtonC_CheckedChanged(object sender, EventArgs e)
        //{
        //        if (radioButtonC.Checked)
        //        {
        //            lbNC.Visible = true;
        //            txtNC.Visible = true;
        //        }
        //        else
        //        {
        //            lbNC.Visible = false;
        //            txtNC.Visible = false;
        //        }
        //}

        //private void radioButtonS_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (radioButtonC.Checked)
        //    {
        //        lbNC.Visible = true;
        //        txtNC.Visible = true;
        //    }
        //    else
        //    {
        //        lbNC.Visible = false;
        //        txtNC.Visible = false;
        //    }
        //}

        private void menuGet_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvData.CurrentRow.Index == -1) return;
                popGetInventory pop = new popGetInventory();
                pop.BackColor = Color.FromArgb(255, 230, 217);
                //if (Statics._popGetInventory == null)
                //{
                //    Statics._popGetInventory = new popGetInventory(); // These forms inherit from DockContent 
                //    Statics._popGetInventory.BackColor = Color.FromArgb(255, 230, 217);
                //    Statics._popGetInventory.Show(dockPanel1);
                //}
                //else
                //{
                //    Statics.frmCommonReportAE_Month.BringToFront();
                //}
                //_popGetInventory.MS_Code = dgvData.CurrentRow.Cells["MS_code"].Value + "";
                //_popGetInventory.MS_Name = dgvData.CurrentRow.Cells["MS_Name"].Value + "";
                //_popGetInventory.MS_Cost = dgvData.CurrentRow.Cells["MS_Cost"].Value + "" == "" ? 0 : Convert.ToDouble(dgvData.CurrentRow.Cells["MS_Cost"].Value + "");
                //_popGetInventory.MS_Instock = dgvData.CurrentRow.Cells["MS_Instock"].Value + "" == "" ? 0 : Convert.ToDouble(dgvData.CurrentRow.Cells["MS_Instock"].Value + "");


                if (pop.ShowDialog() == DialogResult.OK)
                    BindMedicalSupplies(1);
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, Statics.StrMsgDeleteError + ex);
            }
           
        }

        private void menuCutStock_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvData.CurrentRow.Index == -1) return;
                popCutInventory pop = new popCutInventory();
                pop.MS_Code = dgvData.CurrentRow.Cells["MS_code"].Value + "";
                pop.MS_Name = dgvData.CurrentRow.Cells["MS_Name"].Value + "";
                pop.MS_Instock = dgvData.CurrentRow.Cells["MS_Instock"].Value + "" == "" ? 0 : Convert.ToDouble(dgvData.CurrentRow.Cells["MS_Instock"].Value + "");
                if (pop.ShowDialog() == DialogResult.OK)
                    BindMedicalSupplies(1);
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, Statics.StrMsgDeleteError + ex);
            }
        }

        private void viewHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmStockHistory pop = new FrmStockHistory();
                pop.ShowDialog();
                
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, Statics.StrMsgDeleteError + ex);
            }
        }

        private void dgvData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
                                  e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        private void pictureBoxFind_Click(object sender, EventArgs e)
        {
            BindMedicalSupplies(1);
        }
        void uBranch1_SelectedChanged(object sender, EventArgs e)
        {
            BindMedicalSupplies(1);
        }

        private void FrmMedicalSuppliesStock_Load(object sender, EventArgs e)
        {
            BindMedicalSupplies(1);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.InitialDirectory = Convert.ToString(Environment.SpecialFolder.MyDocuments);
                saveFileDialog1.Filter = "Excel file(*.xlsx)|*.xlsx";
                saveFileDialog1.FilterIndex = 1;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (ClosedXML.Excel.XLWorkbook wb = new ClosedXML.Excel.XLWorkbook())
                    {
                        ExportFile exp = new ExportFile();
                        wb.Worksheets.Add(exp.GetDataTableFromDGV(dgvData, "Result"));

                        //wb.Worksheets.Add(DGVTODatable());

                        wb.SaveAs(saveFileDialog1.FileName);
                        if (File.Exists(saveFileDialog1.FileName))
                        {
                            Process.Start(saveFileDialog1.FileName);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
      

        

    }
}
