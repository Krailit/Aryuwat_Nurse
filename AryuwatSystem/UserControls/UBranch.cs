using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AryuwatSystem.DerClass;
using Entity;

namespace AryuwatSystem.UserControls
{
    public partial class UBranch : UserControl
    {
        public string BranchId { get; set; }
        public string BranchName { get; set; }
        public bool ISSecurity = false;
        public event EventHandler SelectedChanged;
        public UBranch()
        {
            InitializeComponent();
            BindCboBranch();
        }
        private void BindCboBranch()
        {
            try
            {
                var ds3 = new Business.Branch().SelectBranchAll();
                DataTable dt = ds3.Tables[0].Clone();
                string strcheck = (Entity.Userinfo.BranchAuth + "," + Entity.Userinfo.BranchId).ToUpper();
                foreach (DataRow dr in ds3.Tables[0].Rows)
                {
                    //if (ISSecurity)
                    //{
                        //if (strcheck.Contains(dr["BranchID"].ToString().ToUpper()))
                            dt.ImportRow(dr);
                    //}
                    //else 
                    //    dt.ImportRow(dr);
                }

                var dr3 = dt.NewRow();
                dr3["BranchID"] = "";
                dr3["BranchName"] = Statics.StrValidate;
                dt.Rows.InsertAt(dr3, 0);
                // cboPurchase.Items.Clear();

                cboBranch.BeginUpdate();
                cboBranch.DataSource = dt;
                cboBranch.ValueMember = "BranchID";
                cboBranch.DisplayMember = "BranchName";
                cboBranch.EndUpdate();
                cboBranch.SelectedIndex = 1;
                BranchId = cboBranch.SelectedValue + "";
                BranchName = cboBranch.Text + "";
                setBranchValue(Entity.Userinfo.BranchId);
            }
            catch (Exception ex)
            {
                //DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }
        }
        public void setBranchValue(string valueID)
        {
            try
            {
                cboBranch.SelectedValue = valueID;
                //if (valueID != "") cboBranch.Enabled = false;
                //else cboBranch.Enabled = true;

                if (Userinfo.IsAdmin.Contains(Userinfo.EN)) cboBranch.Enabled = true;
        
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cboBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BranchId = cboBranch.SelectedValue + "";
                BranchName = cboBranch.Text + "";
                //bubble the event up to the parent
                if (this.SelectedChanged != null)
                    this.SelectedChanged(this, e);    
            }
            catch (Exception)
            {


            }
        }

        private void UBranch_Load(object sender, EventArgs e)
        {
            try
            {
                BranchId = cboBranch.SelectedValue + "";
                BranchName = cboBranch.Text + "";
            }
            catch (Exception)
            {


            }
        }

        //private void cboBranch_MouseUp(object sender, MouseEventArgs e)
        //{
        //    try
        //    {
        //        BranchId = cboBranch.SelectedValue + "";
        //        BranchName = cboBranch.SelectedText + "";
        //    }
        //    catch (Exception)
        //    {
                
               
        //    }
        //}

    }
}
