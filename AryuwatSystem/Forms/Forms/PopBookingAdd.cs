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
    public partial class PopBookingAdd : Form
    {
        public PopBookingAdd()
        {
            InitializeComponent();
            var dsPersonnelType = new Business.Personnel().SelectBranch_PersonnelType();
            cboBranch.DataSource = dsPersonnelType.Tables[1];
            cboBranch.ValueMember = "BranchID";
            cboBranch.DisplayMember = "BranchName";
            BindCboTreatment();
     }
        public string Title
        {
            get; set; 
        }
    public string Note
        {
            get { return txtNote.Text; }
            set { txtNote.Text = value; }
        }
    public string CustName
    {
        get { return txtName.Text; }
        set { txtName.Text = value; }
    }
    public string CustID
    {
        get;set;
    }
    public string CN
    {
        get;set;
    }
    public string DrName
    {
        get { return txtDr.Text; }
        set { txtDr.Text = value; }
    }
    public string DrID
    {
        get;set;
    }
    public string Treadment
    {
        get;set;
    }
    public string Mobile
    {
        get;set;
    }
    public string Howmagazine
    {
        get;set;
    }
    public string Howinternet
    {
        get;
        set;
    }
    public string Howfriend
    {
        get;
        set;
    }
    public string Hownewpaper
    {
        get;set;
    }
    public string HowTravel
    {
        get;set;
    }
    public string Howother
    {
        get;set;
    }
    public string HowotherText
    {
        get;set;
    }
    public string HowFaceBook
    {
        get;
        set;
    }
    public string HowInstagram
    {
        get;
        set;
    }
    public string BranchID
    {
        get;
        set;
    }
    public string BranchName
    {
        get;
        set;
    }
    public string ENDoctor
    {
        get;
        set;
    }
    private DataTable dtTreatment;
    private void buttonAdd_Click(object sender, EventArgs e)
    {
        this.CustName = txtName.Text.Trim();
        this.Treadment = cboTreadment.Text.Trim();
        //this.Dr = txtDr.Text;
        this.Mobile = txtMobile.Text;
        this.Howmagazine = chkMagazine.Checked ? "Y" : "N";
        this.Howinternet = chkInternet.Checked ? "Y" : "N";
        this.Howfriend = chkFriend.Checked ? "Y" : "N";
        this.Hownewpaper = chkNewspaper.Checked ? "Y" : "N";
        this.HowTravel = chkTravel.Checked ? "Y" : "N";
        this.Howother = chkHowDidOther.Checked ? "Y" : "N";
        this.HowotherText = txtOther.Text;
        this.Note = txtNote.Text;
        this.HowFaceBook = chkFacebook.Checked ? "Y" : "N";
        this.HowInstagram = chkInstagram.Checked ? "Y" : "N";
        this.BranchID = cboBranch.SelectedValue+"";
        this.BranchName = cboBranch.Text + "";

        this.Hide();
    }

    private void PopBookingAdd_Load(object sender, EventArgs e)
    {
        try
        {
            txtName.Text = CustName;
            cboTreadment.Text = Treadment;
            txtDr.Text = DrName;
            txtMobile.Text = Mobile;
            chkMagazine.Checked = Howmagazine == "Y";
            chkInternet.Checked = Howinternet == "Y";
            chkFriend.Checked = Howfriend == "Y";
            chkNewspaper.Checked = Hownewpaper == "Y";
            chkTravel.Checked = HowTravel == "Y";
            chkHowDidOther.Checked = Howother == "Y";
            txtOther.Text = HowotherText;
            txtNote.Text = Note;
            chkFacebook.Checked = HowFaceBook == "Y";
            chkInstagram.Checked = HowInstagram == "Y";
            if (!string.IsNullOrEmpty(BranchID)) cboBranch.SelectedValue = BranchID;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
       
    }

        
    private void BindCboTreatment()
    {
        try
        {
            Entity.MedicalSupplies info = new MedicalSupplies();
            info.Tab = "All";
            //if (!string.IsNullOrEmpty(cboTreadment.Text))
            //{
            //   info.Tabwhere = "Msup.MS_Code Like '%" + cboTreadment.Text + "%'" + " or Msup.MS_Name Like '%" + cboTreadment.Text + "%'";
            //}
            //else
            //{
                info.Tabwhere = "1=1";
           // }
            dtTreatment = new Business.MedicalSupplies().SelectMedicalSuppliesBySection(info).Tables[0];
            var dr = dtTreatment.NewRow();
            dr["MS_Code"] = "";
            dr["MS_Name"] = "";
            dtTreatment.Rows.InsertAt(dr, 0);
            cboTreadment.Items.Clear();
            cboTreadment.BeginUpdate();
            cboTreadment.DataSource = dtTreatment;
            cboTreadment.ValueMember = "MS_Code";
            cboTreadment.DisplayMember = "MS_Name";

            cboTreadment.EndUpdate();
            AutoCompleteStringCollection data = new AutoCompleteStringCollection();
            foreach (DataRow row in dtTreatment.Rows)
            {
                if (row["MS_Name"] + ""=="")continue;
                data.Add(row["MS_Name"] + "");
            }
            cboTreadment.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboTreadment.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboTreadment.AutoCompleteCustomSource = data;
        }
        catch (Exception ex)
        {
            Utility.PopMsg(Utility.EnuMsgType.MsgTypeInformation, "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
        }
    }
    private void cboTreadment_TextChanged(object sender, EventArgs e)
    {
        //if (cboTreadment.SelectedIndex == -1)
        //{
        //    string sql = "MS_Name LIKE '%" + cboTreadment.Text + "%' or MS_Code LIKE '%" + cboTreadment.Text + "%'";
        //    dtTreatment.DefaultView.RowFilter = sql;
        //}
    }
    private void chkHowDidOther_CheckedChanged(object sender, EventArgs e)
    {
        txtOther.ReadOnly = !chkHowDidOther.Checked;
    }

    private void btnName_Click(object sender, EventArgs e)
    {
        PopEMP("CUST");
    }

    private void btnDr_Click(object sender, EventArgs e)
    {
        PopEMP("DR");
    }
    private void PopEMP(string typ)
    {
        try
        {
            if (typ == "DR")
            {
                PopEmpSearch obj = new PopEmpSearch();
                obj.StartPosition = FormStartPosition.CenterScreen;
                obj.WindowState = FormWindowState.Normal;
                obj.BackColor = Color.FromArgb(170, 232, 229);
                obj.StaffsName = DrName;
                obj.EmployeeId = DrID;
                obj.ShowDialog();
                
                
                if (obj.StaffsName != "")
                    DrName = obj.StaffsName;
                if (obj.EmployeeId != "")
                    DrID = obj.EmployeeId;
            }
            else if (typ == "CUST")
            {
                
                PopCustSearch obj = new PopCustSearch();
                obj.StartPosition = FormStartPosition.CenterParent;
                obj.WindowState = FormWindowState.Normal;
                obj.MaximizeBox = false;
                obj.MinimizeBox = false;
                obj.ShowDialog();
             

                //if (obj.CN != "")
                //{
                    CustName = obj.CustomerName;
                    CustID = obj.CN;
               // }
            }
        }
        catch (Exception)
        {
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        this.Hide();
    }

 

    }
}
