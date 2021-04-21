using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entity;
using AryuwatSystem.DerClass;

namespace AryuwatSystem.Forms
{
    public partial class PopInputCourseCard : Form
    {
        public string CourseCardID { get; set; }
        public string CN { get; set; }
        public string CustName { get; set; }
        public DateTime CCdate { get; set; }
        public string MS_Name { get; set; }
        public string MS_Code { get; set; }
        public string ListOrder { get; set; }
        public string SONo { get; set; }
        public string VN { get; set; }
        public string PrintCard { get; set; }
        public decimal Amount { get; set; }
        public bool IsUpdated { get; set; }
        public DataTable dtMain { get; set; }
        public PopInputCourseCard()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            this.Close();
          
        }
   
        private void PopInputCourseCard_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                 if (lbCC.Text.Trim().Length < 3)
                    CourseCardID = "";
                else
                     CourseCardID = lbCC.Text.Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PopInputCourseCard_Load(object sender, EventArgs e)
        {
            try
            {
                lbCN.Text = CN;
                lbName.Text=CustName;
                lbItem.Text=MS_Name;
                lbCC.Text = CourseCardID;
                if (PrintCard == "Y")//มีแล้ว
                {
                    label1Text.Text = label1Text.Text + " (เลขเดิม)";
                    lbCC.ForeColor = System.Drawing.Color.Green;
                    label1Text.ForeColor = System.Drawing.Color.Green;
                    buttonOK.Text = "พิมพ์บัตร/Print";
                  //  buttonOK.Enabled = false;
                }
                else// สร้างใหม่
                {
                    label1Text.Text = label1Text.Text + " (เลขใหม่)";
                    lbCC.ForeColor = System.Drawing.Color.Red;
                    label1Text.ForeColor = System.Drawing.Color.Red;
                    IsUpdated = true;
                    buttonOK.Text = "พิมพ์บัตร/Print";
                    buttonOK.Enabled = true;
                }

                

                lbAmount.Text = Amount.ToString("###,###.##");
                lbDate.Text = CCdate.ToString("dd-MMM-yyyy");
                if (lbCC.Text.Trim().Length > 2) lbCC.Enabled = true;
                else lbCC.Enabled = false;
                if ((Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN))
                {
                    buttonEdit.Visible = true;
                    buttonOK.Enabled = true;
                    btnDel.Visible = true;
                }
                else
                {
                    buttonEdit.Visible = false;
                    btnDel.Visible = false;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            IsUpdated = true;
            buttonOK.BackColor = System.Drawing.Color.ForestGreen;
            buttonOK.Text = buttonOK.Text + "(แก้ไข)";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirmYesNo, Statics.StrConfirmDelete) == DialogResult.Yes)
                {
                    MedicalOrderUseTrans c = new Entity.MedicalOrderUseTrans();
                    c.Sono = SONo;
                    c.VN = VN;
                    c.MS_Code = MS_Code;
                    c.ListOrder = ListOrder;
                    c.CreateBy = Entity.Userinfo.EN;
                    var intStatus = new Business.MedicalOrderUseTrans().DeleteCourseCard(c);
                    //DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, Statics.StrMsgInsertComplete ) ;
                    this.Close();
                }
                
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
        }
    }
}
