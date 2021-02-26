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
    public partial class FrmPromotionList : DockContent
    {
        private Entity.Promotion info;
        public Utility.AccessType FormType { get; set; }
        private int? intStatus;
        private int OldrowIndex = 0;
        private DataTable dataTable = null;
        private int ID = 0;
        private string MS_CodeOld = "";
        private int pIntseq = 1;
        private enum CallMode
        {
            Insert,
            Update,
            Preview
        }
        public FrmPromotionList()
        {
            InitializeComponent();
            SetColumns();
            BindPromotion(1);
            ngbMain.MoveFirst += ngbMain_MoveFirst;
            ngbMain.MoveNext += ngbMain_MoveNext;
            ngbMain.MoveLast += ngbMain_MoveLast;
            ngbMain.MovePrevious += ngbMain_MovePrevious;
            //dgvData.RowPostPaint += dgvData_RowPostPaint;
            //dgvData.RowPostPaint += dgvData_RowPostPaint;
            dgvData.CellMouseClick += dgvData_CellMouseClick;
            menuEdit.Click += new EventHandler(menuEdit_Click);
            menuPreview.Click += new EventHandler(menuPreview_Click);
            menuDel.Click += new EventHandler(menuDel_Click);
            FormType = Utility.AccessType.Insert;
            this.Closing += new CancelEventHandler(FrmPromotionList_Closing);
        }


        void FrmPromotionList_Closing(object sender, CancelEventArgs e)
        {
            Statics.frmPromotionList = null;
        }
        #region Event


        private void menuEdit_Click(object sender, EventArgs e)
        {
            EditPromotion("MM");
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
            BindPromotion(1);
        }

        private void ngbMain_MoveLast()
        {
            BindPromotion(Convert.ToInt32(ngbMain.TotalPage));
        }

        private void ngbMain_MoveNext()
        {
            BindPromotion(Convert.ToInt32(Convert.ToInt32(ngbMain.CurrentPage) + 1));
        }

        private void ngbMain_MovePrevious()
        {
            BindPromotion(Convert.ToInt32(Convert.ToInt32(ngbMain.CurrentPage) - 1));
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
                    BindPromotion(1);
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
            Statics.frmPromotionList = null;
            this.Close();
        }
        private void SetColumns()
        {
            Utility.SetPropertyDgv(dgvData);
            dgvData.Columns.Add("PRO_Code", "PRO_Code");
            dgvData.Columns.Add("PRO_Name", "PRO_Name");
            dgvData.Columns.Add("ProPrice", "Price");
            dgvData.Columns.Add("DateStart", "Start date");
            dgvData.Columns.Add("DateEnd", "Expire date");
            dgvData.Columns.Add("PRO_Active", "Active");
            dgvData.Columns.Add("Remark", "Remark");
            dgvData.Columns.Add("Pro_Type", "Type");
          
            dgvData.Columns["PRO_Code"].Width = 80;
            dgvData.Columns["PRO_Name"].Width = 200;
            dgvData.Columns["ProPrice"].Width = 50;
            dgvData.Columns["DateStart"].Width = 100;
            dgvData.Columns["DateEnd"].Width = 100;
            dgvData.Columns["PRO_Active"].Width = 10;
            dgvData.Columns["Remark"].Width = 200;
         
        }

        public void BindPromotion(int _pIntseq)
        {
            try
            {
                Utility.MouseOn(this);
                dgvData.Rows.Clear();
                pIntseq = _pIntseq;
                 info = new Entity.Promotion() { PageNumber = _pIntseq };
                 if (!string.IsNullOrEmpty(txtFindName.Text.Trim()))
                {
                    info.PRO_Code = "%" + txtFindName.Text + "%";
                }
                if (!string.IsNullOrEmpty(txtFindName.Text))
                {
                    info.PRO_Name = "%" + txtFindName.Text + "%";
                }
                info.QueryType = "SEARCH";
                DataTable dt = new Business.Promotion().SelectPromotionPaging(info).Tables[0];
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
                  //  PRO_Code
                  //PRO_Name
                  //DateStart
                  //DateEnd
                  //CreateDate
                  //CreateBy
                  //UpdateDate
                  //UpdateBy
                  //ProPrice
                  //PRO_Active
                  //Remark
                    var myItems = new[]
                                      {
                                          item["PRO_Code"] + "",
                                          item["PRO_Name"]+"",
                                          string.IsNullOrEmpty(item["ProPrice"] + "") ? "0" : Convert.ToDouble(item["ProPrice"] + "").ToString("###,###,###.##"),
                                          item["DateStart"] + "" ,
                                          item["DateEnd"] + "" ,
                                          item["PRO_Active"] + "" ,
                                          item["Remark"] + "" ,
                                           item["Pro_Type"] + "" 
                                      };
                    dgvData.Rows.Add(myItems);
                    if (lngTotalPage != 0) continue;
                    Utility.FindTotalPage(Convert.ToInt32(item["rowTotal"].ToString()), ref lngTotalPage);
                    lngTotalRecord = Convert.ToInt32(item["rowTotal"].ToString());
                  
                }
                dgvData.Columns["ProPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            
                
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
    
        private void EditPromotion(string type)
        {
            try
            {
                if (dgvData.CurrentRow.Index == -1) return;
                FormType = Utility.AccessType.Update;
                CallForm(FormType, type);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CallForm(Utility.AccessType cMode,string type)
        {
            try
            {
                if (type == "")
                {
                    Statics.frmPromotionSetting = new FrmPromotionSetting();
                    if (cMode == Utility.AccessType.DisplayOnly)
                    {
                        Statics.frmPromotionSetting.FormType = Utility.AccessType.DisplayOnly;
                        Statics.frmPromotionSetting.Text = Text + Statics.StrPreview;
                        Statics.frmPromotionSetting.PRO_Code = dgvData.CurrentRow.Cells["PRO_Code"].Value + "";
                    }
                    else if (cMode == Utility.AccessType.Update)
                    {
                        Statics.frmPromotionSetting.FormType = Utility.AccessType.Update;
                        Statics.frmPromotionSetting.Text = Text + Statics.StrEdit;
                        Statics.frmPromotionSetting.PRO_Code = dgvData.CurrentRow.Cells["PRO_Code"].Value + "";
                    }
                    else if (cMode == Utility.AccessType.Insert)
                    {
                        Statics.frmPromotionSetting.FormType = Utility.AccessType.Insert;
                        //Statics.frmPromotionSetting.Text = ;
                    }
                    Statics.frmPromotionSetting.BackColor = Color.FromArgb(170, 232, 229);
                    Statics.frmPromotionSetting.Show(Statics.frmMain.dockPanel1);
                    Statics.frmPromotionSetting.Activate();
                }
                else
                {
                    Statics.frmPromotionMMSetting = new FrmPromotionMMSetting();
                    if (cMode == Utility.AccessType.DisplayOnly)
                    {
                        Statics.frmPromotionMMSetting.FormType = Utility.AccessType.DisplayOnly;
                        Statics.frmPromotionMMSetting.Text = Text + Statics.StrPreview;
                        Statics.frmPromotionMMSetting.PRO_Code = dgvData.CurrentRow.Cells["PRO_Code"].Value + "";
                    }
                    else if (cMode == Utility.AccessType.Update)
                    {
                        Statics.frmPromotionMMSetting.FormType = Utility.AccessType.Update;
                        Statics.frmPromotionMMSetting.Text = Text + Statics.StrEdit;
                        Statics.frmPromotionMMSetting.PRO_Code = dgvData.CurrentRow.Cells["PRO_Code"].Value + "";
                    }
                    else if (cMode == Utility.AccessType.Insert)
                    {
                        Statics.frmPromotionMMSetting.FormType = Utility.AccessType.Insert;
                        //Statics.frmPromotionSetting.Text = ;
                    }
                    Statics.frmPromotionMMSetting.BackColor = Color.FromArgb(170, 232, 229);
                    Statics.frmPromotionMMSetting.Show(Statics.frmMain.dockPanel1);
                    Statics.frmPromotionMMSetting.Activate();
                }
            }
            catch (Exception)
            {

            }
        }
        private void buttonFind_BtnClick()
        {
            BindPromotion(1);
        }

        private void dgvData_Sorted(object sender, EventArgs e)
        {
            SetNumberAllRows();
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           if (e.RowIndex >= 0)
            {
                EditPromotion(dgvData.CurrentRow.Cells["PRO_Type"].Value + "");
            }
        }

        private void txtFindCode_TextChanged(object sender, EventArgs e)
        {
            //BindPromotion(1);
        }

        private void txtFindName_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void buttonAdd1_BtnClick()
        {
            CallForm(Utility.AccessType.Insert,"");
        }

        private void buttonFind1_BtnClick()
        {
            BindPromotion(1);
        }

        private void buttonAdd2_BtnClick()
        {
            CallForm(Utility.AccessType.Insert,"MM");
        }

       

        

    }
}
