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
using AryuwatSystem.m_DataSet;
using Entity;
using WeifenLuo.WinFormsUI.Docking;

namespace AryuwatSystem.Forms
{
    public partial class FrmRoomList : DockContent
    {
        private Entity.Promotion info;
        public DerUtility.AccessType FormType { get; set; }
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
        public FrmRoomList()
        {
            InitializeComponent();
            SetColumns();
            BindRoom(1);
            //dgvData.RowPostPaint += dgvData_RowPostPaint;
            //dgvData.RowPostPaint += dgvData_RowPostPaint;
            dgvData.CellMouseClick += dgvData_CellMouseClick;
            menuEdit.Click += new EventHandler(menuEdit_Click);
            menuPreview.Click += new EventHandler(menuPreview_Click);
            //menuDel.Click += new EventHandler(menuDel_Click);
            FormType = DerUtility.AccessType.Insert;
            this.Closing += new CancelEventHandler(FrmPromotionList_Closing);
        }


        void FrmPromotionList_Closing(object sender, CancelEventArgs e)
        {
            Statics.frmPromotionList = null;
        }
        #region Event


        private void menuEdit_Click(object sender, EventArgs e)
        {
            EditRoom("MM");
        }

        private void menuPreview_Click(object sender, EventArgs e)
        {
            //CallForm(CallMode.Preview);
        }

        //private void menuDel_Click(object sender, EventArgs e)
        //{
        //    DeleteData();
        //}
        private void dgvData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                if (e.Button == MouseButtons.Right)
                {
                    dgvData.ClearSelection();
                    //dgvData.Rows[OldrowIndex].Selected = false;
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
        //private void ngbMain_MoveFirst()
        //{
        //    BindRoom(1);
        //}

        //private void ngbMain_MoveLast()
        //{
        //    BindRoom(Convert.ToInt32(ngbMain.TotalPage));
        //}

        //private void ngbMain_MoveNext()
        //{
        //    BindRoom(Convert.ToInt32(Convert.ToInt32(ngbMain.CurrentPage) + 1));
        //}

        //private void ngbMain_MovePrevious()
        //{
        //    BindRoom(Convert.ToInt32(Convert.ToInt32(ngbMain.CurrentPage) - 1));
        //}

        //private void dgvData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        //{
        //    var b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor);
        //    e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1), ((DataGridView)sender).DefaultCellStyle.Font, b,
        //                          e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        //}


        #endregion

        //private void DeleteData()
        //{
        //    //if (Utility.PopMsg(Utility.EnuMsgType.MsgTypeConfirmYesNo, "ยืนยันการลบข้อมูล", "ลบข้อมูล") == DialogResult.Yes)
        //    //{
        //    if (dgvData.CurrentRow.Index == -1) return;
        //    if (DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirmYesNo,
        //                       Statics.StrConfirmDelete + dgvData.CurrentRow.Cells["PRO_Code"].Value + "") != DialogResult.Yes) return;
        //    try
        //    {
        //        Entity.Promotion info = new Promotion();
        //        info.PRO_Code = dgvData.CurrentRow.Cells["PRO_Code"].Value + "";
        //        if (new Business.Promotion().DeletePromotion(info) > 0)
        //        {
        //            DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, Statics.StrMsgDeleteComplete);
        //            BindRoom(1);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, Statics.StrMsgDeleteError + ex);
        //    }
        //    //}
        //}
        private void buttonCancel_BtnClick()
        {
            Statics.frmPromotionList = null;
            this.Close();
        }
        private void SetColumns()
        {
            //DerUtility.SetPropertyDgv(dgvData);
            //dgvData.Columns.Add("PRO_Code", "PRO_Code");
            //dgvData.Columns.Add("PRO_Name", "PRO_Name");
            //dgvData.Columns.Add("ProPrice", "Price");
            //dgvData.Columns.Add("DateStart", "Start date");
            //dgvData.Columns.Add("DateEnd", "Expire date");
            //dgvData.Columns.Add("PRO_Active", "Active");
            //dgvData.Columns.Add("Remark", "Remark");
            //dgvData.Columns.Add("Pro_Type", "Type");
          
            //dgvData.Columns["PRO_Code"].Width = 80;
            //dgvData.Columns["PRO_Name"].Width = 200;
            //dgvData.Columns["ProPrice"].Width = 50;
            //dgvData.Columns["DateStart"].Width = 100;
            //dgvData.Columns["DateEnd"].Width = 100;
            //dgvData.Columns["PRO_Active"].Width = 10;
            //dgvData.Columns["Remark"].Width = 200;
         
        }

        public void BindRoom(int _pIntseq)
        {
            try
            {
                DerUtility.MouseOn(this);
                //dgvData.Rows.Clear();
                pIntseq = _pIntseq;
                #region bkOld
                //info = new Entity.Promotion() { PageNumber = _pIntseq };
                // if (!string.IsNullOrEmpty(txtFindName.Text.Trim()))
                //{
                //    info.PRO_Code = "%" + txtFindName.Text + "%";
                //}
                //if (!string.IsNullOrEmpty(txtFindName.Text))
                //{
                //    info.PRO_Name = "%" + txtFindName.Text + "%";
                //}
                //info.QueryType = "SEARCH";
                //DataTable dt = new Business.Promotion().SelectPromotionPaging(info).Tables[0];
                //dataTable = dt;
                //long lngTotalPage = 0;
                //long lngTotalRecord = 0;
                //if (dt.Rows.Count <= 0)
                //{
                //    ngbMain.CurrentPage = 0;
                //    ngbMain.TotalPage = 0;
                //    ngbMain.TotalRecord = 0;
                //    ngbMain.Updates();
                //    DerUtility.MouseOff(this);
                //    //Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "ไม่พบข้อมูลในระบบ");
                //    return;
                //}
                //foreach (DataRowView item in dt.DefaultView)
                //{
                //  //  PRO_Code
                //  //PRO_Name
                //  //DateStart
                //  //DateEnd
                //  //CreateDate
                //  //CreateBy
                //  //UpdateDate
                //  //UpdateBy
                //  //ProPrice
                //  //PRO_Active
                //  //Remark
                //    var myItems = new[]
                //                      {
                //                          item["PRO_Code"] + "",
                //                          item["PRO_Name"]+"",
                //                          string.IsNullOrEmpty(item["ProPrice"] + "") ? "0" : Convert.ToDouble(item["ProPrice"] + "").ToString("###,###,###.##"),
                //                         Convert.ToDateTime(item["DateStart"] + "").ToString("yyyy-MM-dd") ,
                //                          Convert.ToDateTime(item["DateEnd"] + "").ToString("yyyy-MM-dd") ,
                //                          item["PRO_Active"] + "" ,
                //                          item["Remark"] + "" ,
                //                           item["Pro_Type"] + "" 
                //                      };
                //    dgvData.Rows.Add(myItems);
                //    if (lngTotalPage != 0) continue;
                //    DerUtility.FindTotalPage(Convert.ToInt32(item["rowTotal"].ToString()), ref lngTotalPage);
                //    lngTotalRecord = Convert.ToInt32(item["rowTotal"].ToString());

                //}
                //dgvData.Columns["ProPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                #endregion

                using(var context = new EntitiesOPD_System())
                {
                    var TempRoom = context.Master_Room;
                    var result = new List<Master_Room>();
                    if (!string.IsNullOrEmpty(txtFindName.Text.Trim()))
                    {
                        result = TempRoom.Where(x => x.Room_Name.Contains(txtFindName.Text) || x.Room_Code.Contains(txtFindName.Text)).ToList();
                    }
                    else
                    {
                        result = TempRoom.ToList();
                    }

                    dgvData.DataSource = result;
                }
                DerUtility.MouseOff(this);

            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
            finally
            {
                SetNumberAllRows();
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
    
        private void EditRoom(string type)
        {
            try
            {
                if (dgvData.CurrentRow.Index == -1) return;
                FormType = DerUtility.AccessType.Update;
                CallForm(FormType, type);
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CallForm(DerUtility.AccessType cMode,string type)
        {
            try
            {
                Statics.frmRoomSetting = new FrmRoomSetting();
                if (cMode == DerUtility.AccessType.DisplayOnly)
                {
                    Statics.frmRoomSetting.FormType = DerUtility.AccessType.DisplayOnly;
                    Statics.frmRoomSetting.Text = Text + Statics.StrPreview;
                    Statics.frmRoomSetting.Room_Code = dgvData.CurrentRow.Cells["Room_Code"].Value.ToString();
                }
                else if (cMode == DerUtility.AccessType.Update)
                {
                    Statics.frmRoomSetting.FormType = DerUtility.AccessType.Update;
                    Statics.frmRoomSetting.Text = Text + Statics.StrEdit;
                    Statics.frmRoomSetting.Room_Code = dgvData.CurrentRow.Cells["Room_Code"].Value.ToString();
                }
                else if (cMode == DerUtility.AccessType.Insert)
                {
                    Statics.frmRoomSetting.FormType = DerUtility.AccessType.Insert;
                    //Statics.frmRoomSetting.Text = ;
                }
                Statics.frmRoomSetting.BackColor = Color.FromArgb(255, 230, 217);
                Statics.frmRoomSetting.Show(Statics.frmMain.dockPanel1);
                Statics.frmRoomSetting.Activate();
                BindRoom(1);
            }
            catch (Exception)
            {

            }
        }
        private void buttonFind_BtnClick()
        {
            BindRoom(1);
        }

        private void dgvData_Sorted(object sender, EventArgs e)
        {
            SetNumberAllRows();
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           if (e.RowIndex >= 0)
            {
                EditRoom(dgvData.CurrentRow.Cells["Room_Code"].Value + "");
            }
        }


        private void txtFindName_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void buttonFind1_BtnClick()
        {
            BindRoom(1);
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            CallForm(DerUtility.AccessType.Insert, "");
        }

        private void txtFindName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                BindRoom(1);
        }

        private void txtFindName_MouseClick(object sender, MouseEventArgs e)
        {
            DerUtility.GetSetInputKeyBorad("english");
        }

       

        

    }
}
