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
    public partial class popHowYouHearSO : Form
    {
        public string Newspaper
        {
            get;
            set;
        }
        public string Magazine
        {
            get;
            set;
        }
        public string Internet
        {
            get;
            set;
        }
        public string Friend
        {
            get;
            set;
        }
        public string Travelthrough
        {
            get;
            set;
        }
        public string Facebook
        {
            get;
            set;
        }
        public string Instagram
        {
            get;
            set;
        }
        public string Sms
        {
            get;
            set;
        }
        public string LineAt
        {
            get;
            set;
        }
        public string Line
        {
            get;
            set;
        }
          public string Taxi
        {
            get;
            set;
        }
          public string Agency
        {
            get;
            set;
        }
          public string AgencyID
          {
              get;
              set;
          }
          public string AgencyName
          {
              get;
              set;
          }
          public string AgencyIDOPD
          {
              get;
              set;
          }
          public string AgencyNameOPD
          {
              get;
              set;
          }
          public string HowYouhearOther
        {
            get;
            set;
        }
          public Entity.HowYouhear howInfo
          {
              get;
              set;
          }
        public popHowYouHearSO()
        {
            InitializeComponent();
        }

        private void rdo_Other_Click(object sender, EventArgs e)
        {
            txtHowDid.Text = "";
            txtHowDid.Enabled = rdo_Other.Checked;
            txtHowDid.ReadOnly = !rdo_Other.Checked;
        }

        private void popHowYouHearSO_Load(object sender, EventArgs e)
        {
            BindCboAgen();
            if (howInfo!=null)
            {
                rdoNewspaper.Checked = howInfo.Newspaper == "Y";
                rdoMagazine.Checked = howInfo.Magazine == "Y";
                rdoInternet.Checked = howInfo.Internet == "Y";
                rdoFriendss.Checked = howInfo.Friend == "Y";
                rdoTravel.Checked = howInfo.Travelthrough == "Y";
                rdoFacebook.Checked = howInfo.Facebook == "Y";
                rdoInstagram.Checked = howInfo.Instagram == "Y";
                rdoSms.Checked = howInfo.Sms == "Y";
                rdoLineAt.Checked = howInfo.LineAt == "Y";
                rdoLine.Checked = howInfo.Line == "Y";
                rdoTaxi.Checked = howInfo.Taxi == "Y";
                rdoTV.Checked = howInfo.TV == "Y";
                rdoAgency.Checked =cboAgency.Enabled= howInfo.Agency != "N";
                rdo_Other.Checked = howInfo.HowYouhearOther != "N";
                txtHowDid.ReadOnly = !rdo_Other.Checked;
               if(rdo_Other.Checked) txtHowDid.Text = howInfo.HowYouhearOther.ToString();
                cboAgency.SelectedValue = howInfo.Agency;
                cboAgencyOPD.SelectedValue = howInfo.AgencyOPD;
                rdoCallIn.Checked = howInfo.CallIn == "Y";
            }
        }
       

        private void BindCboAgen()
        {
            try
            {
                var info = new Entity.Agency() { PageNumber = 1 };
                
              
                    //info.AgenMemName = "%''%";
               
                    //info.AgenMemSurName = "%''%";
                DataTable dt = new Business.Agency().SelectAgencyMember("SEARCHMEMBER", info).Tables[0];
                var dr = dt.NewRow();
                dr["AgenMemID"] = "";
                dr["FullNameThai"] = "";
                dt.Rows.InsertAt(dr, 0);
                cboAgency.Items.Clear();
                cboAgency.BeginUpdate();
                cboAgency.DataSource = dt;
                cboAgency.ValueMember = "AgenMemID";
                cboAgency.DisplayMember = "FullNameThai";

                cboAgency.EndUpdate();
                AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                foreach (DataRow row in dt.Rows)
                {
                    if (row["AgenMemID"] + "" == "") continue;
                    data.Add(row["FullNameThai"] + "");
                }
                cboAgency.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboAgency.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cboAgency.AutoCompleteCustomSource = data;

                cboAgencyOPD.Items.Clear();
                cboAgencyOPD.BeginUpdate();
                cboAgencyOPD.DataSource = dt.Copy();
                cboAgencyOPD.ValueMember = "AgenMemID";
                cboAgencyOPD.DisplayMember = "FullNameThai";

                cboAgencyOPD.EndUpdate();
               
                cboAgencyOPD.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboAgencyOPD.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cboAgencyOPD.AutoCompleteCustomSource = data;
            }
            catch (Exception ex)
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                 //GetData HowYouHear
                howInfo = new Entity.HowYouhear();
                howInfo.QueryType = "FOR_SO";
                howInfo.Newspaper = rdoNewspaper.Checked ? "Y" : "N";
                howInfo.Newspaper = rdoNewspaper.Checked ? "Y" : "N";
                howInfo.Magazine = rdoMagazine.Checked ? "Y" : "N";
                howInfo.Internet = rdoInternet.Checked ? "Y" : "N";
                howInfo.Friend = rdoFriendss.Checked ? "Y" : "N";
                howInfo.Travelthrough = rdoTravel.Checked ? "Y" : "N";
                howInfo.Facebook = rdoFacebook.Checked ? "Y" : "N";
                howInfo.Instagram = rdoInstagram.Checked ? "Y" : "N";
                howInfo.Sms = rdoSms.Checked ? "Y" : "N";
                howInfo.LineAt = rdoLineAt.Checked ? "Y" : "N";
                howInfo.Line = rdoLine.Checked ? "Y" : "N";
                howInfo.Taxi = rdoTaxi.Checked ? "Y" : "N";
                howInfo.TV = rdoTV.Checked ? "Y" : "N";
                howInfo.CallIn = rdoCallIn.Checked ? "Y" : "N";

                howInfo.Agency = cboAgency.SelectedValue + ""!="" ? cboAgency.SelectedValue + "" : "N";

                if (rdo_Other.Checked && txtHowDid.Text == "")
                    howInfo.HowYouhearOther = "Old Customer";
                else if (rdo_Other.Checked && txtHowDid.Text != "")
                    howInfo.HowYouhearOther = txtHowDid.Text;
                else
                    howInfo.HowYouhearOther = "N";

              
                    AgencyID = cboAgency.SelectedValue+"";
                    AgencyName = cboAgency.Text;
                    AgencyIDOPD = cboAgencyOPD.SelectedValue + "";
                    AgencyNameOPD = cboAgencyOPD.Text;

                howInfo.AgencyOPD=cboAgencyOPD.SelectedValue+"";
                howInfo.AgencyNameOPD = cboAgencyOPD.Text;
                
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rdoAgency_Click(object sender, EventArgs e)
        {
            cboAgency.SelectedIndex = 0;
            cboAgency.Enabled = rdoAgency.Checked;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void buttonAddAgency_BtnClick()
        {
            try
            {
                  if (Statics.frmAgencySetting == null)
                    {
                        Statics.frmAgencySetting = new FrmAgencySetting();
                        {
                            Statics.frmAgencySetting.BackColor = Color.FromArgb(255, 230, 217);
                        };
                        Statics.frmAgencySetting.Show();
                    }
                    else
                    {
                        Statics.frmAgencySetting.BringToFront();
                    }
                    
            }
            catch (Exception)
            {
                
               
            }
        }
    }
}
