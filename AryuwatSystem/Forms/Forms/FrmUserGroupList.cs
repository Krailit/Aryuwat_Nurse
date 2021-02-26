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
    public partial class FrmUserGroupList : DockContent, IForm
    {
        private Entity.MedicalSupplies info;
        public Utility.AccessType FormType { get; set; }
        private int? intStatus; 
        private int rowIndex = 0;
        public string TypeCashier;
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
        public FrmUserGroupList()
        {
            InitializeComponent();
            SetColumns();
         
            //BindMedicalSupplies(1);
          
            dgvData.RowPostPaint += dgvData_RowPostPaint;
            dgvData.RowPostPaint += dgvData_RowPostPaint;
            dgvData.CellMouseClick += dgvData_CellMouseClick;
            menuEdit.Click += new EventHandler(menuEdit_Click);
            menuDel.Click += new EventHandler(menuDel_Click);
            FormType = Utility.AccessType.Insert;
            this.Closing += new CancelEventHandler(FrmUserGroup_Closing);
        }
     
        void FrmUserGroup_Closing(object sender, CancelEventArgs e)
        {
            Statics.frmUserGroupList = null;
        }

        private void CallForm(CallMode cMode)
        {
            //int rowindex = OldrowIndex; //dgvData.CurrentRow.Index;
            PopUserGroupSetting obj = new PopUserGroupSetting();
            if (rowIndex == -1) return;
             if (cMode == CallMode.Preview)
             {
                 obj.FormType = Utility.AccessType.DisplayOnly;
                 obj.Text = Text + Statics.StrPreview;
             }
             else if (cMode == CallMode.Update)
             {
                 obj.FormType = Utility.AccessType.Update;
                 obj.Text = Text + Statics.StrEdit;
             }

             obj.ID = int.Parse(dgvData.Rows[rowIndex].Cells["ID"].Value + "");
             obj.GroupCode = dgvData.Rows[rowIndex].Cells["GroupCode"].Value + "";
             obj.GroupName = dgvData.Rows[rowIndex].Cells["GroupName"].Value + "";

             obj.BackColor = Color.FromArgb(170, 232, 229);
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
                    string MedStatus_Code = dgvData.Rows[e.RowIndex].Cells["MedStatus_Code"].Value + "";
                    double used =Convert.ToDouble(dgvData.Rows[e.RowIndex].Cells["AmountOfUse"].Value + "");
                    //menuSurgical.Visible = MedStatus_Code != "0";
                    menuSurgical.Visible = used > 0;
                    
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
            obj.BackColor = Color.FromArgb(170, 232, 229);
            obj.ShowDialog();
        }

        private void DeleteData()
        {
            //if (Utility.PopMsg(Utility.EnuMsgType.MsgTypeConfirmYesNo, "ยืนยันการลบข้อมูล", "ลบข้อมูล") == DialogResult.Yes)
            //{
            var groupCode = dgvData.CurrentRow.Cells["ID"].Value + "";
            if (groupCode == "1")
            {
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation,
                               "ไม่สามารถลบกลุ่มใช้งานนี้ได้ กรุณาติดต่อผู้ดูแลระบบ", "ผลการตรวจสอบ");
                return;
            }
            if (dgvData.CurrentRow.Index == -1) return;
            if (Utility.PopMsg(Utility.EnuMsgType.MsgTypeConfirmYesNo,
                               Statics.StrConfirmDelete + groupCode) !=
                DialogResult.Yes) return;
            try
            {
                if (new Business.UserGroup().DeleteUserGroup(int.Parse(groupCode)) == 1)
                {
                    Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, Statics.StrMsgDeleteComplete);
                    BindFrmUserGroup(1);
                }
            }
            catch (Exception ex)
            {
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeError, Statics.StrMsgDeleteError + ex);
            }
            //}
        }
      
        private void SetColumns()
        {
            Utility.SetPropertyDgv(dgvData);
            dgvData.Columns.Add("ID", "ID");
            dgvData.Columns.Add("GroupCode", "รหัสกลุ่ม");
            dgvData.Columns.Add("GroupName", "ชื่อกลุ่ม");
         
            dgvData.Columns["GroupCode"].Width = 150;
            dgvData.Columns["GroupName"].Width = 500;
            dgvData.Columns["ID"].Visible = false;

        }

        public void BindFrmUserGroup(int pIntseq)
        {
            try
            {
                bind = false;
                dgvData.Rows.Clear();
                DataTable dt = new Business.UserGroup().SelectUserGroupAll().Tables[0];
                foreach (DataRowView item in dt.DefaultView)
                {
                    var myItems = new[]
                                      {
                                          item["ID"] + "",
                                          item["GroupCode"] + "",
                                          item["GroupName"] + ""
                                      };
                    dgvData.Rows.Add(myItems);
                  
                }
            }
            catch (Exception ex)
            {
                Utility.PopMsg(Utility.EnuMsgType.MsgTypeError, ex.Message);
                Utility.MouseOff(this);
                return;
            }
        }
      
        private void FrmUserGroupList_Load(object sender, EventArgs e)
        {
            //firstload = false;
            BindFrmUserGroup(1);
        }

        private void dgvData_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
           
        }

        private void dgvData_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BindFrmUserGroup(1);
        }

     
     
        private void FrmUserGroupList_Activated(object sender, EventArgs e)
        {
            
            BindFrmUserGroup(1);
        }

        private void FrmUserGroupList_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics.frmUserGroupList = null;
        }
    }
}
