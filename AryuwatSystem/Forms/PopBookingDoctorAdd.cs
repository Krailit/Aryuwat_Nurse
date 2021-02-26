using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AryuwatSystem.DerClass;
using Entity;
using Calendar.NET;

namespace AryuwatSystem.Forms
{
    public partial class PopBookingDoctorAdd : Form
    {

        public bool AutoBook = false;
        public CustomEvent editEvent=new CustomEvent();
        public bool ISDelete = false;
        public PopBookingDoctorAdd()
        {
            InitializeComponent();
            //var dsPersonnelType = new Business.Personnel().SelectBranch_PersonnelType();
            //cboBranch.DataSource = dsPersonnelType.Tables[1];
            //cboBranch.ValueMember = "BranchID";
            //cboBranch.DisplayMember = "BranchName";
            
            dateTimePickerIn.Format = DateTimePickerFormat.Custom;
            dateTimePickerIn.CustomFormat = "HH:mm tt"; // Only use hours and minutes
            dateTimePickerIn.ShowUpDown = true;
            dateTimePickerOut.Format = DateTimePickerFormat.Custom;
            dateTimePickerOut.CustomFormat = "HH:mm tt"; // Only use hours and minutes
            dateTimePickerOut.ShowUpDown = true;
            cboDoctor.MouseWheel += new MouseEventHandler(cboDoctor_MouseWheel);
            BindCbocboDr();
     }
        void cboDoctor_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        public string Title
        {
            get; set; 
        }
  

    public string ENSave
    {
        get;
        set;
    }

 //  private DataTable dtTreatment;
    private void buttonAdd_Click(object sender, EventArgs e)
    {
        try
        {

            this.editEvent.DrID = cboDoctor.SelectedValue + "";
           
            this.editEvent.Note = txtNote.Text;
            this.editEvent.AppointDate = new DateTime(editEvent.Date.Year, editEvent.Date.Month, editEvent.Date.Day, 0, 0, 0);//For booking Time 0:0:0
            this.editEvent.TimeStart = new DateTime(editEvent.Date.Year, editEvent.Date.Month, editEvent.Date.Day, dateTimePickerIn.Value.Hour, dateTimePickerIn.Value.Minute, 0);
            this.editEvent.TimeEnd = new DateTime(editEvent.Date.Year, editEvent.Date.Month, editEvent.Date.Day, dateTimePickerOut.Value.Hour, dateTimePickerOut.Value.Minute, 0);
            this.editEvent.DrName = cboDoctor.Text;// +editEvent.TimeStart.ToShortTimeString() + "-" + editEvent.TimeEnd.ToShortTimeString();
            //editEvent.AddDate=dicDoctor[cboDoctor.SelectedValue + ""].
            DateTime AddDate = editEvent.Date.AddDays(editEvent.AddDate);
            DateTime DateShowStart = new DateTime(AddDate.Year, AddDate.Month, AddDate.Day, 8, 0, 0);
            DateTime DateShowEnd = new DateTime(AddDate.Year, AddDate.Month, AddDate.Day, 8, 30, 0);
            this.editEvent.DateShowStart = DateShowStart;
            this.editEvent.DateShowEnd = DateShowEnd;
            

            this.editEvent.CustName = dicDoctor[editEvent.DrID] + editEvent.TimeStart.ToShortTimeString() + "-" + editEvent.TimeEnd.ToShortTimeString();
            //this.BranchID = cboBranch.SelectedValue+"";
            //this.BranchName = cboBranch.Text + "";
            this.ENSave = Userinfo.EN;

            if (checkBoxOff.Checked)//===========Set  Text OFF==========
            {
                editEvent.CustName = dicDoctor[editEvent.DrID] + " (Off)";
                this.editEvent.TimeStart = new DateTime(dateTimePickerIn.Value.Year, dateTimePickerIn.Value.Month, dateTimePickerIn.Value.Day, 0, 0, 0);
                this.editEvent.TimeEnd = new DateTime(dateTimePickerOut.Value.Year, dateTimePickerOut.Value.Month, dateTimePickerOut.Value.Day, 0, 0, 0);
                editEvent.A = 255;
                editEvent.R = 255;
                editEvent.G = 0;
                editEvent.B = 0;

            }

            if (AutoBook == false)
            {
                DataSet ds = new Business.BookingRoom().DUP_BOOKINGDOCTOR(editEvent);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    popAlert pop = new popAlert();
                    pop.txtTitle = "";
                    pop.txtShow = string.Format("มีบันทึกไปแล้ว {0}/{1}{2}{3}", ds.Tables[0].Rows[0]["BranchName"] + "", ds.Tables[0].Rows[0]["RoomName"] + "", System.Environment.NewLine, "Duplicate " + ds.Tables[0].Rows[0]["BranchName"] + "/" + ds.Tables[0].Rows[0]["RoomName"] + "");
                    pop.ShowDialog();
                    if (pop.ShowDialog() == DialogResult.Yes || pop.DialogResult == DialogResult.No) return;

                    //DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, string.Format("บันทึกไปแล้ว {0}/{1}", ds.Tables[0].Rows[0]["BranchName"] + "", ds.Tables[0].Rows[0]["RoomName"] + ""));
                    return;
                }
            }
            if(AutoBook==false)
                Save();

            this.DialogResult = DialogResult.OK;
            //this.Hide();
            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
    private void Save()
    {
        try
        {


            int? intStatus = new Business.BookingRoom().SaveBookingDoctor(editEvent);
            DataSet ds = new Business.BookingRoom().GetBookingDoctorGETMAXID(editEvent.BranchID);
            editEvent.ID=Convert.ToInt16(ds.Tables[0].Rows[0]["ID"]+"");
            //=============Save link to Booking
           
                        //string du = item.Duration.Hours + "." + item.Duration.Minutes + "";
                        //item.AppointDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                //        ItemInfo xx=new ItemInfo("", item.AppointDateTime, item.StartDate, item.EndDate, du, item.BackgroundColor.A, item.BackgroundColor.R, item.BackgroundColor.G, item.BackgroundColor.B, item.ENSave.Trim()
                //            , item.CustName, item.CustID, item.Treadment, item.Mobile, item.DrName, item.DrID, item.Howmagazine, item.Howinternet, item.Howfriend
                //            , item.Hownewpaper, item.HowTravel, item.Howother, item.HowotherText, item.Note, item.BranchID, item.BranchName,item.DateSave);

                //int? intStatus = new Business.BookingRoom().SaveBookingRoom(lst, RoomDelete);
            //=================================
            //MessageBox.Show("Save complete");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
    private void PopBookingDoctorAdd_Load(object sender, EventArgs e)
    {
        try
        {
            cboDoctor.SelectedValue = editEvent.DrID+"";
            txtNote.Text = editEvent.Note;
            if (editEvent.TimeStart > DateTime.MinValue)
            {
                dateTimePickerIn.Value = editEvent.TimeStart;
            }
            else
            {
                dateTimePickerIn.Value = new DateTime(editEvent.Date.Year,editEvent.Date.Month,editEvent.Date.Day,10,0,0);
            }
            if (editEvent.TimeEnd > DateTime.MinValue)
                dateTimePickerOut.Value = editEvent.TimeEnd;
            else
                dateTimePickerOut.Value = new DateTime(editEvent.Date.Year, editEvent.Date.Month, editEvent.Date.Day, 17, 0, 0);
            //if (!string.IsNullOrEmpty(BranchID)) cboBranch.SelectedValue = BranchID;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
       
    }
      //  [RoomIDDocBook]
      //,[RoomName]
      //,[RoomDetail]
      //,[ShowOrder]
      //,[Show]
      //,[RoomIDBooking]
      //,[AddDate]
    DataTable dtDoctor;
    RoomDoc roomDoc=new RoomDoc();
    Dictionary<string, string> dicDoctor = new Dictionary<string, string>();
    private void BindCbocboDr()
    {
        try
        {
            RoomDoc roomDoc=new RoomDoc();
            dtDoctor = new Business.Personnel().SearchPersonnelByType("SELECTPERSONNEL_DOCTOR").Tables[0];
            var dr = dtDoctor.NewRow();

            dr["EN"] = "";
            dr["DrName"] = "";
            dtDoctor.Rows.InsertAt(dr, 0);
            cboDoctor.Items.Clear();
            cboDoctor.BeginUpdate();
            cboDoctor.DataSource = dtDoctor;
            cboDoctor.ValueMember = "EN";
            cboDoctor.DisplayMember = "DrName";

            cboDoctor.EndUpdate();

         

            AutoCompleteStringCollection data = new AutoCompleteStringCollection();
            foreach (DataRow row in dtDoctor.Rows)
            {
                if (row["DrName"] + "" == "") continue;
                data.Add(row["DrName"] + "");
                //roomDoc.RoomIDDocBook = row["RoomIDDocBook"] + "";
                //roomDoc.RoomIDBooking = row["RoomIDBooking"] + "";
                //roomDoc.RoomName = row["RoomName"] + "";
                //roomDoc.AddDate = Convert.ToInt16(row["AddDate"] + "");
                dicDoctor.Add(row["EN"] +"", row["DrNameEng"] + "");
            }
            cboDoctor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboDoctor.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboDoctor.AutoCompleteCustomSource = data;

       
        }
        catch (Exception ex)
        {
            DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "เกิดข้อผิดผลาดในการทำงานเนื่องจาก " + ex.Message);
        }
    }
  

    private void btnCancel_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }

    private void dateTimePickerIn_ValueChanged(object sender, EventArgs e)
    {
        //if(dateTimePickerIn.Value>=dateTimePickerOut.Value)
        //{
        //    DateTime date = new DateTime(dateTimePickerIn.Value.Year, dateTimePickerIn.Value.Month, dateTimePickerIn.Value.Day, 10, 0, 0);
        //    dateTimePickerIn.Value = date;
        // }
    }

    private void dateTimePickerOut_ValueChanged(object sender, EventArgs e)
    {
        //if (dateTimePickerIn.Value >= dateTimePickerOut.Value)
        //{
        //    DateTime date = new DateTime(dateTimePickerOut.Value.Year, dateTimePickerOut.Value.Month, dateTimePickerOut.Value.Day, 17, 0, 0);
        //    dateTimePickerOut.Value = date;
        //}
    }

    private void btnDel_Click(object sender, EventArgs e)
    {
        try
        {
            if (DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirmYesNo, Statics.StrConfirmDelete) == DialogResult.Yes)
            {
                int x = new Business.BookingRoom().DelBookingDoctor(editEvent.ID);
                ISDelete = true;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void checkBoxOff_Click(object sender, EventArgs e)
    {
        try
        {
            if (checkBoxOff.Checked)
            {
                dateTimePickerIn.Enabled = false;
                dateTimePickerOut.Enabled = false;
                DateTime dateIn = new DateTime(dateTimePickerIn.Value.Year, dateTimePickerIn.Value.Month, dateTimePickerIn.Value.Day, 0, 0, 0);
                dateTimePickerIn.Value = dateIn;
                DateTime dateOut = new DateTime(dateTimePickerIn.Value.Year, dateTimePickerIn.Value.Month, dateTimePickerIn.Value.Day, 0, 0, 0);
                dateTimePickerIn.Value = dateOut;
            }
            else
            {
                dateTimePickerIn.Enabled = true;
                dateTimePickerOut.Enabled = true;
                DateTime dateIn = new DateTime(dateTimePickerIn.Value.Year, dateTimePickerIn.Value.Month, dateTimePickerIn.Value.Day, 10, 0, 0);
                dateTimePickerIn.Value = dateIn;
                DateTime dateOut = new DateTime(dateTimePickerIn.Value.Year, dateTimePickerIn.Value.Month, dateTimePickerIn.Value.Day, 17, 0, 0);
                dateTimePickerIn.Value = dateOut;
            }
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    }

    public class RoomDoc
    {
        public String RoomIDDocBook { get;set;}
        public String RoomName { get; set; }
        public String RoomIDBooking { get; set; }
        public int AddDate { get; set; }
    }
}
