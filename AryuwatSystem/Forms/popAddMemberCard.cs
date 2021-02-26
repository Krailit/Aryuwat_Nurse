using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AryuwatSystem.DerClass;

namespace AryuwatSystem.Forms
{
    public partial class popAddMemberCard : Form
    {
        
        public string CN { get; set; }
        public string CustomerShow { get; set; }
        public string OldMemID { get; set; }
        public string newMemID { get; set; }
        
       
        public popAddMemberCard()
        {
            InitializeComponent();
        }

        private void popAddMemberCard_Load(object sender, EventArgs e)
        {
            try
            {
                lbCustomer.Text = CustomerShow;
                if (OldMemID != "") txtID.Text = OldMemID;
                else
                {
                    txtID.Text = "";
                    txtID.Select();
                }
              
                //Timer t = new Timer();
                //t.Interval = 10;
                //t.Tick += new EventHandler((s, ev) => txtID.Focus());
                //t.Start();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
               
                SaveID();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
        private void SaveID()
        {
            try
            {

                //if (txtID.Text.Length<5)
                //{
                //    MessageBox.Show("โปรดระบุ Member ID");
                //    return;
                //}

                if (OldMemID == txtID.Text) { this.DialogResult = DialogResult.Yes; return; }

                Entity.Customer info = new Entity.Customer();
                info.CN = CN;
                info.MemID = txtID.Text;
                newMemID = txtID.Text;
                info.CreateBy = Entity.Userinfo.EN;
                
                int? intx = new Business.Customer().InsertMembersID(info);
                if (intx > 0)
                {
                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, Statics.StrMsgInsertComplete);
                    this.DialogResult = DialogResult.Yes;
                }
                else
                {
                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation,
                                   Statics.StrMsgCannotSave + " ข้อมูลผิดพลาด");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
      
    }
}
