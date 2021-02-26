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
    public partial class FrmMedicalSupplies : DockContent
    {
        private Entity.MedicalSupplies info;
        public Utility.AccessType FormType { get; set; }
        private int? intStatus;
        private int OldrowIndex = 0;
        private DataTable dataTable = null;
        private int ID = 0;
        private string MS_CodeOld = "";
        private int pIntseq = 1;
        public FrmMedicalSupplies()
        {
            InitializeComponent();
            SetColumns();
            BindCboMedicalSection();
            BindCboCourseDuration();
            BindCboUnit();
            BindCboPurChase_Operation();
            txtCode.Text = "";
            BindMedicalSupplies(1);
            ngbMain.MoveFirst += ngbMain_MoveFirst;
            ngbMain.MoveNext += ngbMain_MoveNext;
            ngbMain.MoveLast += ngbMain_MoveLast;
            ngbMain.MovePrevious += ngbMain_MovePrevious;
            //dgvData.RowPostPaint += dgvData_RowPostPaint;
            //dgvData.RowPostPaint += dgvData_RowPostPaint;
            dgvData.CellMouseClick += dgvData_CellMouseClick;
            cboEXpire.SelectedIndexChanged+=new EventHandler(cboDuration_SelectedIndexChanged);
            menuEdit.Click += new EventHandler(menuEdit_Click);
            menuPreview.Click += new EventHandler(menuPreview_Click);
            menuDel.Click += new EventHandler(menuDel_Click);
            FormType = Utility.AccessType.Insert;
            this.Closing += new CancelEventHandler(FrmMedicalSupplies_Closing);
        }

        private void cboDuration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboEXpire.SelectedIndex!=0)
            {
                lbNC.Visible = true;
                txtNC.Visible = true;
            }
            else
            {
                lbNC.Visible = false;
                txtNC.Visible = false;
            }
        }

        void FrmMedicalSupplies_Closing(object sender, CancelEventArgs e)
        {
            Statics.frmMedicalSupplies = null;
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
            if (Utility.PopMsg(Utility.EnuMsgType.MsgTypeConfirmYesNo,
                               Statics.StrConfirmDelete + dgvData.CurrentRow.Cells["MS_code"].Value + "") !=
                DialogResult.Yes) return;
            try
            {
                if (new Business.MedicalSupplies().DeleteSupplies(dgvData.CurrentRow.Cells["MS_code"].Value + "") == 1)
                {
                    Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, Statics.StrMsgDeleteComplete);
                    BindMedicalSupplies(1);
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
            Statics.frmMedicalSupplies = null;
            this.Close();
        }
        private void SetColumns()
        {
            Utility.SetPropertyDgv(dgvData);
            dgvData.Columns.Add("MS_code", "Code");
            dgvData.Columns.Add("MS_Name", "Name");
            dgvData.Columns.Add("MS_Detail", "Detail");
            dgvData.Columns.Add("MS_CLPrice", "CL Price");
            dgvData.Columns.Add("MS_CAPrice", "CA Price");
            dgvData.Columns.Add("MS_CMPrice", "CM Price");
            dgvData.Columns.Add("MS_Type", "Type");
            dgvData.Columns.Add("MS_Number_C", "Course Number");
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
                cboUnit.Items.Clear();
                cboUnit.BeginUpdate();
                cboUnit.DataSource = ds.Tables[0];
                cboUnit.ValueMember = "UnitCode";
                cboUnit.DisplayMember = "UnitName";

                cboUnit.EndUpdate();


            }
            catch (Exception ex)
            {
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }
        }
        private void BindCboCourseDuration()
        {
            try
            {
                var ds = new Business.MedicalSupplies().SelectCourseDuration();
                var dr = ds.Tables[0].NewRow();
                dr["CD_Code"] = "";
                dr["CD_Name"] = Statics.StrValidate;
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cboEXpire.Items.Clear();
                cboEXpire.BeginUpdate();
                cboEXpire.DataSource = ds.Tables[0];
                cboEXpire.ValueMember = "CD_Code";
                cboEXpire.DisplayMember = "CD_Name";

                cboEXpire.EndUpdate();


            }
            catch (Exception ex)
            {
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }
        }
        private void BindCboMedicalSection()
        {
            try
            {
                var ds = new Business.MedicalSupplies().SelectMedicalSection();
                var dr = ds.Tables[0].NewRow();
                dr["Section_Code"] = "";
                dr["Section_Name"] = Statics.StrValidate;
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cboSection.Items.Clear();
                cboSection.BeginUpdate();
                cboSection.DataSource = ds.Tables[0];
                cboSection.ValueMember = "Section_Code";
                cboSection.DisplayMember = "Section_Name";

                cboSection.EndUpdate();


            }
            catch (Exception ex)
            {
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }
        }
         private void BindCboPurChase_Operation()
        {
            try
            {


                var ds2 = new Business.MedicalSupplies().SelectOperation();
                var dr2 = ds2.Tables[0].NewRow();
                dr2["Setting_Code"] = 0;
                dr2["Setting_Name"] = Statics.StrValidate;
                dr2["Setting_Type"] = Statics.StrValidate;
                ds2.Tables[0].Rows.InsertAt(dr2, 0);
                // cboOperating.Items.Clear();

                cboOperating.BeginUpdate();
                cboOperating.DataSource = ds2.Tables[0];
                cboOperating.ValueMember = "Setting_Code";
                cboOperating.DisplayMember = "Setting_Name";
                cboOperating.EndUpdate();

                var ds = new Business.MedicalSupplies().SelectPurChase();
                var dr = ds.Tables[0].NewRow();
                dr["Setting_Code"] = 0;
                dr["Setting_Name"] = Statics.StrValidate;
                dr["Setting_Type"] = Statics.StrValidate;
                ds.Tables[0].Rows.InsertAt(dr, 0);
                // cboPurchase.Items.Clear();

                cboPurchase.BeginUpdate();
                cboPurchase.DataSource = ds.Tables[0];
                cboPurchase.ValueMember = "Setting_Code";
                cboPurchase.DisplayMember = "Setting_Name";
                cboPurchase.EndUpdate();

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
            }
            catch (Exception ex)
            {
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }
        }

        public void BindMedicalSupplies(int _pIntseq)
        {
            try
            {
                Utility.MouseOn(this);
                dgvData.Rows.Clear();
                pIntseq = _pIntseq;
                 info = new Entity.MedicalSupplies() { PageNumber = _pIntseq };
                if (!string.IsNullOrEmpty(txtFindCode.Text.Trim()))
                {
                    info.MS_Code = "%" + txtFindCode.Text + "%";
                }
                if (!string.IsNullOrEmpty(txtFindName.Text))
                {
                    info.MS_Name = "%" + txtFindName.Text + "%";
                }
                info.QueryType = "SEARCH";  
                DataTable dt = new Business.MedicalSupplies().SelectMedicalSuppliesPaging(info).Tables[0];
                dataTable = dt;
                long lngTotalPage = 0;
                long lngTotalRecord = 0;
                if (dt.Rows.Count <= 0)
                {
                    ngbMain.CurrentPage = 0;
                    ngbMain.TotalPage = 0;
                    ngbMain.TotalRecord = 0;
                    ngbMain.Updates();
                    Utility.MouseOff(this);
                    //Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "ไม่พบข้อมูลในระบบ");
                    return;
                }
                foreach (DataRowView item in dt.DefaultView)
                {
                    var myItems = new[]
                                      {
                                          item["MS_code"] + "",
                                          item["MS_Name"]+"",
                                          item["MS_Detail"] + "",
                                          string.IsNullOrEmpty(item["MS_CLPrice"] + "") ? "0" : Convert.ToDouble(item["MS_CLPrice"] + "").ToString("###,###.##"),
                                          string.IsNullOrEmpty(item["MS_CAPrice"] + "") ? "0" : Convert.ToDouble(item["MS_CAPrice"] + "").ToString("###,###.##"),
                                          string.IsNullOrEmpty(item["MS_CMPrice"] + "") ? "0" : Convert.ToDouble(item["MS_CMPrice"] + "").ToString("###,###.##"),
                                          item["MS_Type"] + "" ,
                                          item["MS_Number_C"] + "" ,
                                          item["UnitName"] + "" ,
                                          string.IsNullOrEmpty(item["FeeRate"] + "") ? "0" : Convert.ToDouble(item["FeeRate"] + "").ToString("###,###.##"),
                                          string.IsNullOrEmpty(item["FeeRate2"] + "") ? "0" : Convert.ToDouble(item["FeeRate2"] + "").ToString("###,###.##"),
                                          string.IsNullOrEmpty(item["MaxDiscount"] + "") ? "" : Convert.ToDouble(item["MaxDiscount"] + "").ToString("###,###.##"),
                                          item["Operation_Name"] + "" ,
                                          item["Purchase_Name"] + "" ,
                                          item["BranchName"] + "" 
                                      };
                    dgvData.Rows.Add(myItems);
                    if (lngTotalPage != 0) continue;
                    Utility.FindTotalPage(Convert.ToInt32(item["rowTotal"].ToString()), ref lngTotalPage);
                    lngTotalRecord = Convert.ToInt32(item["rowTotal"].ToString());
                  
                }
                dgvData.Columns["MS_CMPrice"].Visible = false;
                dgvData.Columns["MS_CLPrice"].DefaultCellStyle.Alignment=DataGridViewContentAlignment.BottomRight;
                dgvData.Columns["MS_CAPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                dgvData.Columns["MS_Type"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                dgvData.Columns["MS_Number_C"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                dgvData.Columns["FeeRate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                dgvData.Columns["FeeRate2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                dgvData.Columns["MaxDiscount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                
                ngbMain.CurrentPage = _pIntseq;
                ngbMain.TotalPage = lngTotalPage;
                ngbMain.TotalRecord = lngTotalRecord;
                ngbMain.Updates();
                Utility.MouseOff(this);
              //  RefreshText();

            }
            catch (Exception ex)
            {
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeError, ex.Message);
                Utility.MouseOff(this);
                return;
            }
            finally
            {
                SetNumberAllRows();
            }
        }

        private void SetNumberAllRows()
        {
            long rowStart = (Utility.ROW_PER_PAGE * (pIntseq - 1));
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
                txtCAPrice.Text = "";
                txtCMPrice.Text = "";
                cboUnit.SelectedIndex = 0;
                cboEXpire.SelectedIndex =0;
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
                if (txtCode.Text.Length < 8 )
                {
                    MessageBox.Show("Code name is short");
                    txtCode.Focus(); 
                    return;
                }
                info.MS_Code = txtCode.Text;
                info.MS_Name = txtName.Text;
                info.MS_Detail = txtDetail.Text;
                info.MS_CLPrice = txtCLPrice.Text=="" ? 0 : Convert.ToDouble(txtCLPrice.Text);
                info.MS_CAPrice = txtCAPrice.Text == "" ? 0 : Convert.ToDouble(txtCAPrice.Text);
                info.MS_CMPrice = txtCMPrice.Text == "" ? 0 : Convert.ToDouble(txtCMPrice.Text);
                info.MS_Unit = cboUnit.SelectedValue+"";
                info.MS_CourseDuration =cboEXpire.SelectedValue+"";
                info.MS_Unit = cboUnit.SelectedValue+"";
                info.Number_C = txtNC.Text == "" ? 0 : Convert.ToInt16(txtNC.Text); 
                info.MS_Section = cboSection.SelectedValue+"";
                info.MS_Type = cboEXpire.SelectedIndex == 0 ? "S" : "C";
                info.Vat = checkBoxVat.Checked ? "Y" : "N";
                
                info.BranchID = cboBranch.SelectedValue + "";
                info.PurchaseID = cboPurchase.SelectedValue + "";
                info.OperationID = cboOperating.SelectedValue + "";

                info.MaxDiscount = textboxFormatDoubleMaxDiscount.Text == "" ? 0 : Convert.ToDouble(textboxFormatDoubleMaxDiscount.Text); 

                if (cboEXpire.SelectedIndex != 0 && info.Number_C==0)
                {
                    MessageBox.Show("Input Number/Course ");
                    txtNC.Focus(); return;
                }
                info.FeeRate = txtFeerate.Text == "" ? 0 : Convert.ToDouble(txtFeerate.Text);
                info.FeeRate2 = txtFeerate2.Text == "" ? 0 : Convert.ToDouble(txtFeerate2.Text);
                if (string.IsNullOrEmpty(cboSection.SelectedValue+""))
                {
                    MessageBox.Show("โปรดระบุ Section");
                    return;
                }
                if (string.IsNullOrEmpty(info.MS_Code))
                {
                    MessageBox.Show("โปรดระบุ Code");
                    return;
                }
                


                switch (FormType)
                {

                    case Utility.AccessType.Insert:
                        if (txtCode.Text.Length < 8)
                        {
                            //MessageBox.Show("โปรดระบุ Code ให้ถูกต้อง");
                            //return;
                        }
                     DataTable dt = new Business.MedicalSupplies().CheckCode(txtCode.Text).Tables[0];
                     if (dt.Rows.Count > 0)
                     {
                         MessageBox.Show("Code นี้ถูกใช้ไปแล้ว");
                         txtCode.Focus();
                         //txtCode.Text = "";
                         txtCode.SelectAll();
                         //return;
                     }
                     else
                     {
                         info.QueryType = "INSERT";
                         intStatus = new Business.MedicalSupplies().InsertMedicalSupplies(ref info);
                         if (intStatus == 1)
                         {
                             BindMedicalSupplies(1);
                             Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, Statics.StrMsgInsertComplete);
                             txtCode.ReadOnly = false;
                         }
                         else
                         {
                             Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation,
                                            Statics.StrMsgCannotSave + " ข้อมูลผิดพลาด");
                         }
                     }
                        break;
                    case Utility.AccessType.Update:
                        info.QueryType = "UPDATE";
                        info.ID = ID;
                        if (MS_CodeOld != txtCode.Text.Trim())
                        {
                            dt = new Business.MedicalSupplies().CheckCode(txtCode.Text).Tables[0];
                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("Code นี้ถูกใช้ไปแล้ว");
                                txtCode.Focus();
                                //txtCode.Text = "";
                                txtCode.SelectAll();
                                //return;
                            }
                        }
                        else
                        {

                            intStatus = new Business.MedicalSupplies().InsertMedicalSupplies(ref info);
                            if (intStatus == 1)
                            {
                              BindMedicalSupplies(1);

                                Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, Statics.StrMsgUpdateComplete);
                                txtCode.ReadOnly = false;
                            }
                            else
                            {
                                Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation,
                                               Statics.StrMsgCannotSave + " ข้อมูลผิดพลาด");
                            }
                            FormType = Utility.AccessType.Insert;
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
                string sql = "MS_code='" + dgvData.CurrentRow.Cells["MS_code"].Value + "'";
                DataRow[] dataRow = dataTable.Select(sql);
                FormType = Utility.AccessType.Update;

                ID =Convert.ToInt32(dataRow[0]["ID"].ToString());
                cboUnit.SelectedValue = dataRow[0]["MS_Unit"].ToString();
                cboEXpire.SelectedValue = dataRow[0]["MS_CourseDuration"].ToString();
                cboSection.SelectedValue = dataRow[0]["MS_Section"].ToString();
                txtCode.ReadOnly = true;
                txtCode.Text = MS_CodeOld = dataRow[0]["MS_code"].ToString();
                txtName.Text = dataRow[0]["MS_Name"].ToString();
                txtDetail.Text = dataRow[0]["MS_Detail"].ToString();


                txtCLPrice.Text = string.IsNullOrEmpty(dataRow[0]["MS_CLPrice"] + "") ? "0" : Convert.ToDouble(dataRow[0]["MS_CLPrice"] + "").ToString("###,###.##");
                txtCAPrice.Text = string.IsNullOrEmpty(dataRow[0]["MS_CAPrice"] + "") ? "0" : Convert.ToDouble(dataRow[0]["MS_CAPrice"] + "").ToString("###,###.##");
                txtCMPrice.Text = string.IsNullOrEmpty(dataRow[0]["MS_CMPrice"] + "") ? "0" : Convert.ToDouble(dataRow[0]["MS_CMPrice"] + "").ToString("###,###.##"); 
                txtNC.Text = dataRow[0]["MS_Number_C"].ToString();
                txtFeerate.Text = string.IsNullOrEmpty(dataRow[0]["FeeRate"] + "") ? "0" : Convert.ToDouble(dataRow[0]["FeeRate"] + "").ToString("###,###.##"); 
                txtFeerate2.Text = string.IsNullOrEmpty(dataRow[0]["FeeRate2"] + "") ? "0" : Convert.ToDouble(dataRow[0]["FeeRate2"] + "").ToString("###,###.##");
                textboxFormatDoubleMaxDiscount.Text = string.IsNullOrEmpty(dataRow[0]["MaxDiscount"] + "") ? "" : Convert.ToDouble(dataRow[0]["MaxDiscount"] + "").ToString("###,###.##");
                checkBoxVat.Checked = dataRow[0]["Vat"] + ""=="Y";


                cboBranch.SelectedValue = dataRow[0]["BranchID"].ToString();
                cboOperating.SelectedValue = dataRow[0]["OperationID"].ToString();
                cboPurchase.SelectedValue = dataRow[0]["PurchaseID"].ToString();
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
            picImport.Image = DermasterSystem.Properties.Resources.Import1;
        }

        private void picImport_MouseHover(object sender, EventArgs e)
        {
            picImport.Image = DermasterSystem.Properties.Resources.Import2;
            toolTip1.Show("Imports Data From Excel", (Control)sender);
        }

        private void btnRefresh_BtnClick()
        {
            txtCode.Text = "";
            txtName.Text = "";
            txtDetail.Text="";
            txtCLPrice.Text = "";
            txtCAPrice.Text = "";
            txtCMPrice.Text = "";
            cboUnit.SelectedIndex = 0;
            cboEXpire.SelectedIndex = 0;
            cboUnit.SelectedIndex = 0;
            txtNC.Text = "";
            cboSection.SelectedIndex = 0;
            cboEXpire.SelectedIndex = 0;
            checkBoxVat.Checked = false;

            cboBranch.SelectedIndex = 0;
            cboPurchase.SelectedIndex = 0;
            cboOperating.SelectedIndex = 0;
            BindMedicalSupplies(1);
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
            }
        }

        private void txtFindCode_TextChanged(object sender, EventArgs e)
        {
            BindMedicalSupplies(1);
        }

        private void txtFindName_TextChanged(object sender, EventArgs e)
        {
            BindMedicalSupplies(1);
        }

        

    }
}
