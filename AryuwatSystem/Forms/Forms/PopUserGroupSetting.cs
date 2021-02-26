using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DermasterSystem.Class;
using Entity;

namespace DermasterSystem.Forms
{
    public partial class PopUserGroupSetting : Form
    {
        public PopUserGroupSetting()
        {
            InitializeComponent();
        }

        public int? ID { get; set; }
        public string GroupCode { get; set; }
        public string GroupName { get; set; }
        public Utility.AccessType FormType { get; set; }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bntSave_Click(object sender, EventArgs e)
        {
            int? intStatus;
            Entity.UserGroup info;
            info = new UserGroup();
            info.GroupName = txtGroupName.Text.Trim();
            if(ID !=null)
            {
                info.ID = ID;
                info.GroupCode = GroupCode;
                intStatus = new Business.UserGroup().UpdateUserGroup(info);
                if (intStatus == 1)
                {
                    Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation,
                                   "บันทึกข้อมูลเรียบร้อยแล้ว", "ผลการตรวจสอบ");
                    Statics.frmUserGroupList.BindFrmUserGroup(1);
                    this.Close();
                }
            }
            else
            {
                intStatus = new Business.UserGroup().InsertUserGroup(info);
                if (intStatus == 1)
                {
                    Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation,
                                   "บันทึกข้อมูลเรียบร้อยแล้ว", "ผลการตรวจสอบ");
                    Statics.frmUserGroupList.BindFrmUserGroup(1);
                    this.Close();
                }
            }

        }

        private void PopUserGroupSetting_Load(object sender, EventArgs e)
        {
            if(FormType == Utility.AccessType.Update)
            {
                txtGroupName.Text = GroupName;
            }
        }
    }
}
