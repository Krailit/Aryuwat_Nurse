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
    public partial class popComboboxPay : Form
    {
        public string popType { get; set; }
        public string SelectValues { get; set; }
        public string SelectText { get; set; }
        DataSet dataSet;
        public popComboboxPay()
        {
            InitializeComponent();
     
        }
        public void BindPayIn()
        {
            try
            {
                //dataSet.Tables[2].Rows.Add(0, "ไม่ระบุ");

                comboBox1.DataSource = dataSet.Tables[2];
                comboBox1.ValueMember = "PayInID";
                comboBox1.DisplayMember = "PayInName";

                if(SelectValues!="")
                comboBox1.SelectedValue = SelectValues;
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
        }
        public void BindCardType()
        {
            try
            {
                dataSet.Tables[3].Rows.Add("ไม่ระบุ");
                comboBox1.DataSource = dataSet.Tables[3];
                comboBox1.ValueMember = "CardType";
                comboBox1.DisplayMember = "CardType";
                if (SelectValues != "")
                comboBox1.SelectedValue = SelectValues;
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, ex.Message);
                DerUtility.MouseOff(this);
                return;
            }
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            SelectValues = comboBox1.SelectedValue + "";
            SelectText = comboBox1.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            SelectValues = comboBox1.SelectedValue + "";
            SelectText = comboBox1.SelectedText + "";
            this.DialogResult = DialogResult.No;
        }

        private void popComboboxPay_Load(object sender, EventArgs e)
        {
            try
            {
                dataSet = new Business.SumOfTreatment().SelectCreditCard();
                if (popType == "PayIn")
                {
                    BindPayIn();
                    textLabel.Text = "PayIn";
                }
                else if (popType == "CardType")
                {
                    BindCardType();
                    textLabel.Text = "CardType";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 

        }
    }

}
