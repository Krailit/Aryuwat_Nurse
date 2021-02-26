using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Calendar.NET;
using System.Diagnostics;
using AryuwatSystem.DerClass;
using Entity;
using System.Globalization;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using AryuwatSystem.Forms.FRMReport;

namespace AryuwatSystem.Forms
{
    public partial class FrmBookingDoctor : Form
    {
        [CustomRecurringFunction("RehabDates", "Calculates which days I should be getting Rehab")]
        private bool RehabDays(IEvent evnt, DateTime day)
        {
            if (day.DayOfWeek == DayOfWeek.Monday || day.DayOfWeek == DayOfWeek.Friday)
            {
                if (day.Ticks >= (new DateTime(2012, 7, 1)).Ticks)
                    return false;
                return true;
            }

            return false;
        }
        private CustomEvent CurrentclickedEvent;
        private CustomEvent NewEvent;
        private Dictionary<string, CustomEvent> dicAutobook = new Dictionary<string, CustomEvent>();
        public FrmBookingDoctor()
        {
            InitializeComponent();

            calendar1.CalendarDate = new DateTime(DateTime.Now.Year,DateTime.Now.Month , DateTime.Now.Day, 0, 0, 0);
            calendar1.CalendarView = CalendarViews.Month;
            calendar1.AllowEditingEvents = true;
            calendar1.LoadPresetHolidays = false;
            calendar1.CalendarDate = DateTime.Now;
            

       
           
        }

        private void LoadAppointment()
        {
            try
            {
              

                //DataSet dsroom = new Business.BookingRoom().SELECTROOMDOCTOR(DateTime.Now,"","");

                int daynum = DateTime.DaysInMonth(calendar1.CalendarDate.Year, calendar1.CalendarDate.Month);
               


                //int daynum = DateTime.DaysInMonth(calendar1.CalendarDate.Year,calendar1.CalendarDate.Month);
                DateTime startDate = new DateTime(calendar1.CalendarDate.Year, calendar1.CalendarDate.Month, 1, 0, 0, 0);
                DateTime EndDate = new DateTime(calendar1.CalendarDate.Year, calendar1.CalendarDate.Month, daynum,23, 59, 59);

                DataSet ds = new Business.BookingRoom().GetBookingDoctor(startDate, EndDate, uBranch1.BranchId);
                List<IEvent> lsAddBook = new List<IEvent>();
                List<IEvent> lsDelBook = new List<IEvent>();
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                        foreach (CustomEvent iv in calendar1._events)
                        {
                            if (iv.RoomID == item["RoomID"] + "" && iv.Date.Year == Convert.ToDateTime(item["DateBook"] + "").Year && iv.Date.Month == Convert.ToDateTime(item["DateBook"] + "").Month && iv.Date.Day == Convert.ToDateTime(item["DateBook"] + "").Day)
                            {

                                NewEvent = (CustomEvent)iv.Clone();

                                NewEvent.EventText = item["RoomName"] + ":" + item["DrName"] + "";

                                NewEvent.ID = Convert.ToDecimal(item["ID"] + "");
                                NewEvent.IDBookLink = Convert.ToDecimal(item["IDBookLink"] + "");
                                NewEvent.RoomID = item["RoomID"] + "";
                                NewEvent.RoomName = item["RoomName"] + "";
                                NewEvent.DrID = item["DrID"] + "";
                                NewEvent.DrName = item["DrName"] + "";
                                //NewEvent.RoomID = item["RoomID"] + "";
                                NewEvent.Date = Convert.ToDateTime(item["DateBook"] + "");
                                NewEvent.TimeStart = Convert.ToDateTime(item["TimeStart"] + "");
                                NewEvent.TimeEnd = Convert.ToDateTime(item["TimeEnd"] + "");
                                NewEvent.Duration = item["Duration"] + "";
                                NewEvent.Note = item["Note"] + "";
                                NewEvent.BranchID = item["BranchID"] + "";
                                NewEvent.ENSave = item["ENSave"] + "";
                                NewEvent.DateSave = item["DateSave"] + "";

                                //calendar1.RemoveEvent(iv);
                                //calendar1.AddEvent(NewEvent);
                                lsAddBook.Add(NewEvent);
                                lsDelBook.Add(iv);
                            }
                        }
                    }
                    foreach (IEvent item in lsDelBook)
                    {
                        calendar1.RemoveEvent(item);
                    }
                    foreach (IEvent item in lsAddBook)
                    {
                        calendar1.AddEvent(item);
                    }
                        ////else
                        ////{
                        //     int timeAdd = 1;

                        //     string textShow = item["RoomID"] + "";
                        //     DateTime datebook = Convert.ToDateTime(item["DateBook"] + "");
                        //         var ce2 = new CustomEvent
                        //            {
                        //                IgnoreTimeComponent = false,
                        //                EventText = textShow,
                        //                RoomID = item["RoomID"] + "",
                        //                Date = new DateTime(datebook.Year, datebook.Month, datebook.Day, timeAdd, 0, 0),
                        //                ID=Convert.ToInt16(item["ID"] + ""),
                        //                TimeStart=Convert.ToDateTime(item["TimeStart"] + ""),
                        //                TimeEnd=Convert.ToDateTime(item["TimeEnd"] + ""),
                        //                Duration = item["Duration"] + "",
                        //                Note = item["Note"] + "",
                        //                BranchID = item["BranchID"] + "",
                        //                ENSave = item["ENSave"] + "",
                        //                DateSave = item["DateSave"] + "",
                        //                EventLengthInHours = 2f,
                        //                RecurringFrequency = RecurringFrequencies.None,
                        //                EventFont = new Font("Verdana", 8, FontStyle.Regular),
                        //                Enabled = true,
                        //                //EventColor = Color.FromArgb(255, 204, 255),
                        //                EventColor = Color.FromArgb(255, 255, 255),
                        //                EventTextColor = Color.Black,
                        //                ThisDayForwardOnly = true
                        //            };
                        //           calendar1.AddEvent(ce2);
                        //           timeAdd++;
                        //}
	                //} 
                //}


                //CurrentclickedEvent = calendar1.CurrentclickedEvent;
                //NewEvent = CurrentclickedEvent.Clone();

                //calendar1.RemoveEvent(CurrentclickedEvent);
                ////NewEvent = pop.editEvent;
                //NewEvent.EventText = pop.editEvent.RoomID + ":" + pop.editEvent.DrName + " " + pop.editEvent.TimeStart.ToShortTimeString() + "-" + pop.editEvent.TimeEnd.ToShortTimeString();
                //NewEvent.RoomID = pop.editEvent.RoomID;
                //NewEvent.DrID = pop.editEvent.DrID;
                //NewEvent.DrName = pop.editEvent.DrName;
                //NewEvent.TimeStart = pop.editEvent.TimeStart;
                //NewEvent.TimeEnd = pop.editEvent.TimeEnd;
                //NewEvent.Note = pop.editEvent.Note;
                //NewEvent.BranchID = pop.editEvent.BranchID;
                //NewEvent.ID = pop.editEvent.ID;
                //calendar1.AddEvent(NewEvent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ReloadAppointment(int st,int en)
        {
            try
            {
               // int daynum = DateTime.DaysInMonth(calendar1.CalendarDate.Year, calendar1.CalendarDate.Month);

                //int daynum = DateTime.DaysInMonth(calendar1.CalendarDate.Year,calendar1.CalendarDate.Month);
                List<IEvent> lsAddBook = new List<IEvent>();
                List<IEvent> lsDelBook = new List<IEvent>();
                foreach (CustomEvent iv in calendar1._events)
                {
                    if (iv.Date.Day == st)
                        lsDelBook.Add(iv);
                }
                foreach (IEvent item in lsDelBook)
                {
                    calendar1.RemoveEvent(item);
                }
                calendar1.Refresh();
                DateTime startDate = new DateTime(calendar1.CalendarDate.Year, calendar1.CalendarDate.Month, st, 0, 0, 0);
                DateTime EndDate = new DateTime(calendar1.CalendarDate.Year, calendar1.CalendarDate.Month, en, 23, 59, 59);

                DataSet ds = new Business.BookingRoom().GetBookingDoctor(startDate, EndDate, uBranch1.BranchId);
              
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    foreach (CustomEvent iv in calendar1._events)
                    {
                        if (iv.RoomID == item["RoomID"] + "" && iv.Date.Year == Convert.ToDateTime(item["DateBook"] + "").Year && iv.Date.Month == Convert.ToDateTime(item["DateBook"] + "").Month && iv.Date.Day == Convert.ToDateTime(item["DateBook"] + "").Day)
                        {

                            NewEvent = (CustomEvent)iv.Clone();

                            NewEvent.EventText = item["RoomName"] + ":" + item["DrName"] + "";

                            NewEvent.ID = Convert.ToDecimal(item["ID"] + "");
                            NewEvent.IDBookLink = Convert.ToDecimal(item["IDBookLink"] + "");
                            NewEvent.RoomID = item["RoomID"] + "";
                            NewEvent.RoomName = item["RoomName"] + "";
                            NewEvent.DrID = item["DrID"] + "";
                            NewEvent.DrName = item["DrName"] + "";
                            //NewEvent.RoomID = item["RoomID"] + "";
                            NewEvent.Date = Convert.ToDateTime(item["DateBook"] + "");
                            NewEvent.TimeStart = Convert.ToDateTime(item["TimeStart"] + "");
                            NewEvent.TimeEnd = Convert.ToDateTime(item["TimeEnd"] + "");
                            NewEvent.Duration = item["Duration"] + "";
                            NewEvent.Note = item["Note"] + "";
                            NewEvent.BranchID = item["BranchID"] + "";
                            NewEvent.ENSave = item["ENSave"] + "";
                            NewEvent.DateSave = item["DateSave"] + "";

                            //calendar1.RemoveEvent(iv);
                            //calendar1.AddEvent(NewEvent);
                            lsAddBook.Add(NewEvent);
                            lsDelBook.Add(iv);
                        }
                    }
                }
                foreach (IEvent item in lsDelBook)
                {
                    calendar1.RemoveEvent(item);
                }
                foreach (IEvent item in lsAddBook)
                {
                    calendar1.AddEvent(item);
                }
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void setRoom(int year,int month)
        {
            try
            {
                if (DateTime.Now.Day>DateTime.DaysInMonth(year, month))
                    calendar1.CalendarDate = new DateTime(year, month, DateTime.DaysInMonth(year, month), 0, 0, 0);
                else
                    calendar1.CalendarDate = new DateTime(year, month, DateTime.Now.Day, 0, 0, 0);
                calendar1.CalendarView = CalendarViews.Month;
                calendar1.AllowEditingEvents = true;
                calendar1.LoadPresetHolidays = false;
                calendar1.Visible = false;
                DataSet dsroom = new Business.BookingRoom().SELECTROOMDOCTOR(DateTime.Now,"","");

                int daynum = DateTime.DaysInMonth(year, month);
               
             
                    int timeAdd = 1;
                    foreach (DataRow item in dsroom.Tables[0].Rows)
	                        {         
                                for (int i = 1; i <= daynum; i++)
                                {//AES1 AES2 ANT1 HTP1 PLS1 CRP1
                                string textShow = item["RoomName"] + ":";
                      
		                         var ce2 = new CustomEvent
                                    {
                                        IgnoreTimeComponent = false,
                                        EventText = textShow,
                                        RoomID = item["RoomID"] + "",
                                        RoomName = item["RoomName"] + "",
                                        Date = new DateTime(year, month, i, timeAdd, 0, 0),
                                        //EventLengthInHours = 2f,
                                        //RecurringFrequency = RecurringFrequencies.None,
                                        EventFont = new Font("Verdana", 8, FontStyle.Regular),
                                        Enabled = true,
                                        //EventColor = Color.FromArgb(255, 204, 255),
                                        EventColor = Color.FromArgb(255, 255, 255),
                                        EventTextColor = Color.Black,
                                        //ThisDayForwardOnly = true
                                        AddDate = Convert.ToInt16(item["AddDate"] + ""),
                                        BranchID=uBranch1.BranchId,
                                        ENSave=Userinfo.EN
                                    };
                                   calendar1.AddEvent(ce2);
                                  
	                        } 
                        timeAdd++;
                }
                    calendar1.Visible = true;
            }
            catch (Exception)
            {
                
                //throw;
            }
            
        }
        private void ResetRoom(int year,int month,int day)
        {
            try
            {
                //calendar1.CalendarDate = new DateTime(year, month, DateTime.Now.Day, 0, 0, 0);
                //calendar1.CalendarView = CalendarViews.Month;
                //calendar1.AllowEditingEvents = true;
                //calendar1.LoadPresetHolidays = false;
                //calendar1.Visible = false;
                DataSet dsroom = new Business.BookingRoom().SELECTROOMDOCTOR(DateTime.Now, "", "");

              //  int daynum = DateTime.DaysInMonth(year, month);


                int timeAdd = 1;
                foreach (DataRow item in dsroom.Tables[0].Rows)
                {
                    //for (int i = 1; i <= day; i++)
                    //{//AES1 AES2 ANT1 HTP1 PLS1 CRP1
                        string textShow = item["RoomName"] + ":";

                        var ce2 = new CustomEvent
                        {
                            IgnoreTimeComponent = false,
                            EventText = textShow,
                            RoomID = item["RoomID"] + "",
                            RoomName = item["RoomName"] + "",
                            Date = new DateTime(year, month, day, timeAdd, 0, 0),
                            //EventLengthInHours = 2f,
                            //RecurringFrequency = RecurringFrequencies.None,
                            EventFont = new Font("Verdana", 8, FontStyle.Regular),
                            Enabled = true,
                            //EventColor = Color.FromArgb(255, 204, 255),
                            EventColor = Color.FromArgb(255, 255, 255),
                            EventTextColor = Color.Black,
                            //ThisDayForwardOnly = true
                            AddDate = Convert.ToInt16(item["AddDate"] + ""),
                            BranchID = uBranch1.BranchId,
                            ENSave = Userinfo.EN
                        };
                        calendar1.AddEvent(ce2);

                    //}
                    timeAdd++;
                }
                calendar1.Visible = true;
            }
            catch (Exception)
            {

                throw;
            }

        }
        [CustomRecurringFunction("Get Monday and Wednesday", "Selects the Monday and Wednesday of each month")]
        public bool GetMondayAndWednesday(IEvent evnt, DateTime dt)
        {
            if (dt.DayOfWeek == DayOfWeek.Monday || dt.DayOfWeek == DayOfWeek.Wednesday)
                return true;
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           var ce2 = new CustomEvent
            {
                IgnoreTimeComponent = false,
                EventText = "4xxxxDinner",
                Date = new DateTime(2012, 5, 15, 21, 0, 0),
                EventLengthInHours = 2f,
                RecurringFrequency = RecurringFrequencies.None,
                EventFont = new Font("Verdana", 12, FontStyle.Regular),
                Enabled = true,
                EventColor = Color.FromArgb(120, 255, 120),
                EventTextColor = Color.Black,
                ThisDayForwardOnly = true
            };
            calendar1.AddEvent(ce2);
        }

        private void calendar1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                CurrentclickedEvent = calendar1.CurrentclickedEvent;
                PopBookingDoctorAdd pop = new PopBookingDoctorAdd();
                //pop.editEvent.TimeStart = CurrentclickedEvent.TimeStart;
                //pop.editEvent.TimeEnd = CurrentclickedEvent.TimeEnd;
                //pop.editEvent.RoomID = CurrentclickedEvent.RoomID;
                //pop.editEvent.RoomName = CurrentclickedEvent.RoomName;
                //pop.editEvent.DrID = CurrentclickedEvent.DrID;
                //pop.editEvent.DrName = CurrentclickedEvent.DrName;
                //pop.editEvent.Note = CurrentclickedEvent.Note;
                //pop.editEvent.Date = CurrentclickedEvent.Date;
                //pop.editEvent.ENSave = Userinfo.EN;
                //pop.editEvent.BranchID = uBranch1.BranchId;
                //pop.editEvent.ID = CurrentclickedEvent.ID;
                //pop.editEvent.IDBookLink = CurrentclickedEvent.IDBookLink;
                pop.editEvent = (CustomEvent)CurrentclickedEvent.Clone();
                pop.Text = CurrentclickedEvent.RoomName;

                if (pop.ShowDialog() != DialogResult.OK)
                {
                    CurrentclickedEvent = null;
                    calendar1.CurrentclickedEvent = null;
                    return;
                }

                if (pop.ISDelete)
                {
                    calendar1.RemoveEvent(CurrentclickedEvent);
                            var ce2 = new CustomEvent
                                    {
                                        IgnoreTimeComponent = false,
                                        EventText = pop.editEvent.RoomName + ":",
                                        RoomID = pop.editEvent.RoomID+ "",
                                        RoomName = pop.editEvent.RoomName,
                                        Date =CurrentclickedEvent.Date,// new DateTime(pop.editEvent.Date.Year, pop.editEvent.Date.Month, pop.editEvent.Date.Day, pop.editEvent.Date.Hour, 0, 0),
                                        EventLengthInHours = 2f,
                                        RecurringFrequency = RecurringFrequencies.None,
                                        EventFont = new Font("Verdana", 8, FontStyle.Regular),
                                        Enabled = true,
                                        //EventColor = Color.FromArgb(255, 204, 255),
                                        EventColor = Color.FromArgb(255, 255, 255),
                                        EventTextColor = Color.Black,
                                        ThisDayForwardOnly = true
                                    };
                                 calendar1.AddEvent(ce2);
                    
                    //calendar1.Refresh();
                    return;
                }

                

                CurrentclickedEvent = calendar1.CurrentclickedEvent;
                NewEvent = CurrentclickedEvent;

                calendar1.RemoveEvent(CurrentclickedEvent);
                //NewEvent = pop.editEvent;
                NewEvent.EventText = pop.editEvent.RoomName + ":" + pop.editEvent.DrName +" " + pop.editEvent.TimeStart.ToShortTimeString() + "-" + pop.editEvent.TimeEnd.ToShortTimeString();
                NewEvent.RoomID = pop.editEvent.RoomID;
                NewEvent.RoomName = pop.editEvent.RoomName;
                NewEvent.DrID = pop.editEvent.DrID;
                NewEvent.DrName = pop.editEvent.DrName;
                NewEvent.TimeStart = pop.editEvent.TimeStart;
                NewEvent.TimeEnd = pop.editEvent.TimeEnd;
                NewEvent.Note = pop.editEvent.Note;
                NewEvent.BranchID = pop.editEvent.BranchID;
                NewEvent.ID = pop.editEvent.ID;
                NewEvent.IDBookLink = pop.editEvent.IDBookLink;
                calendar1.AddEvent(NewEvent);
                //MessageBox.Show(CurrentclickedEvent.EventText);
                //pop.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void calendar1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    CurrentclickedEvent = calendar1.CurrentclickedEvent;
                    
                    _contextMenuStrip1.Show(this, e.Location);
                }
                else CurrentclickedEvent = null;
            }
            catch (Exception)
            {

                //  throw;
            }
        }

        private void _miProperties_Click(object sender, EventArgs e)
        {
            try
            {
                PopBookingDoctorAdd pop = new PopBookingDoctorAdd();
                //pop.editEvent.TimeStart = CurrentclickedEvent.TimeStart;
                //pop.editEvent.TimeEnd = CurrentclickedEvent.TimeEnd;
                //pop.editEvent.RoomID = CurrentclickedEvent.RoomID;
                //pop.editEvent.RoomName = CurrentclickedEvent.RoomName;
                //pop.editEvent.DrID = CurrentclickedEvent.DrID;
                //pop.editEvent.DrName = CurrentclickedEvent.DrName;
                //pop.editEvent.Note = CurrentclickedEvent.Note;
                //pop.editEvent.Date = CurrentclickedEvent.Date;
                //pop.editEvent.ENSave = Userinfo.EN;
                //pop.editEvent.BranchID = uBranch1.BranchId;
                //pop.editEvent.ID = CurrentclickedEvent.ID;
                //pop.editEvent.IDBookLink = CurrentclickedEvent.IDBookLink;
                pop.editEvent = (CustomEvent)CurrentclickedEvent.Clone();
                pop.Text = CurrentclickedEvent.RoomName;

                if (pop.ShowDialog() != DialogResult.OK)
                {
                    CurrentclickedEvent = null;
                    calendar1.CurrentclickedEvent = null;
                    return;
                }

                if (pop.ISDelete)
                {
                    calendar1.RemoveEvent(CurrentclickedEvent);
                            //var ce2 = new CustomEvent
                            //        {
                            //            IgnoreTimeComponent = false,
                            //            EventText = pop.editEvent.RoomName + ":",
                            //            RoomID = pop.editEvent.RoomID+ "",
                            //            RoomName = pop.editEvent.RoomName,
                            //            Date =CurrentclickedEvent.Date,// new DateTime(pop.editEvent.Date.Year, pop.editEvent.Date.Month, pop.editEvent.Date.Day, pop.editEvent.Date.Hour, 0, 0),
                            //            EventLengthInHours = 2f,
                            //            RecurringFrequency = RecurringFrequencies.None,
                            //            EventFont = new Font("Verdana", 8, FontStyle.Regular),
                            //            Enabled = true,
                            //            //EventColor = Color.FromArgb(255, 204, 255),
                            //            EventColor = Color.FromArgb(255, 255, 255),
                            //            EventTextColor = Color.Black,
                            //            ThisDayForwardOnly = true
                            //        };
                            //     calendar1.AddEvent(ce2);
//                    calendar1.Refresh();
                    ResetRoom(calendar1.CalendarDate.Year, calendar1.CalendarDate.Month, CurrentclickedEvent.Date.Day);
                                 ReloadAppointment(CurrentclickedEvent.Date.Day, CurrentclickedEvent.Date.Day);
                    return;
                }

                

                CurrentclickedEvent = calendar1.CurrentclickedEvent;
                NewEvent = CurrentclickedEvent;

                calendar1.RemoveEvent(CurrentclickedEvent);
                //NewEvent = pop.editEvent;
                NewEvent.EventText = pop.editEvent.RoomName + ":" + pop.editEvent.DrName;// +" " + pop.editEvent.TimeStart.ToShortTimeString() + "-" + pop.editEvent.TimeEnd.ToShortTimeString();
                NewEvent.RoomID = pop.editEvent.RoomID;
                NewEvent.RoomName = pop.editEvent.RoomName;
                NewEvent.DrID = pop.editEvent.DrID;
                NewEvent.DrName = pop.editEvent.DrName;
                NewEvent.TimeStart = pop.editEvent.TimeStart;
                NewEvent.TimeEnd = pop.editEvent.TimeEnd;
                NewEvent.Note = pop.editEvent.Note;
                NewEvent.BranchID = pop.editEvent.BranchID;
                NewEvent.ID = pop.editEvent.ID;
                NewEvent.IDBookLink = pop.editEvent.IDBookLink;
                calendar1.AddEvent(NewEvent);
                //MessageBox.Show(CurrentclickedEvent.EventText);
                //pop.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void FrmBookingDoctor_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics.bookingDoctor = null;
        }

       

        private void _btnRight_Click(object sender, EventArgs e)
        {
            calendar1.Visible = false;
            calendar1.BtnRightButtonClicked(sender);
            setRoom(calendar1.CalendarDate.Year, calendar1.CalendarDate.Month);
            LoadAppointment();
            calendar1.Visible = true;
        }

        private void _btnLeft_Click(object sender, EventArgs e)
        {
            calendar1.Visible = false;
            calendar1.BtnLeftButtonClicked(sender);
            setRoom(calendar1.CalendarDate.Year, calendar1.CalendarDate.Month);
            LoadAppointment();
            calendar1.Visible = true;
        }

        private void _btnToday_Click(object sender, EventArgs e)
        {
            calendar1.Visible = false;
            calendar1.CalendarDate = DateTime.Now;
            setRoom(calendar1.CalendarDate.Year, calendar1.CalendarDate.Month);
            LoadAppointment();
            calendar1.Visible = true;
        }

        private void FrmBookingDoctor_Load(object sender, EventArgs e)
        {
            calendar1.BranchName = uBranch1.BranchName;
            setRoom(DateTime.Now.Year, DateTime.Now.Month);
        }

        private void FrmBookingDoctor_Shown(object sender, EventArgs e)
        {
            LoadAppointment();
        }

        private void uBranch1_SelectedChanged(object sender, EventArgs e)
        {
            if (uBranch1.BranchId == "")
            {
                MessageBox.Show("กรุณาเลือก สาขา.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                uBranch1.setBranchValue("EK");
                return;
            }
            calendar1.BranchName = uBranch1.BranchName;
            setRoom(calendar1.CalendarDate.Year, calendar1.CalendarDate.Month);
            LoadAppointment();
        }

        private void picExport_Click(object sender, EventArgs e)
        {
            try
            {
                //CaptureControl(calendar1).Save("image.png", ImageFormat.Png);
                calendar1.RenderPrint().Save("image.png", ImageFormat.Png);
                if (File.Exists("image.png"))
                {
                    Process.Start("image.png");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void picPrint_Click(object sender, EventArgs e)
        {
            try
            {


                int daynum = DateTime.DaysInMonth(calendar1.CalendarDate.Year, calendar1.CalendarDate.Month);
                DateTime startDate = new DateTime(calendar1.CalendarDate.Year, calendar1.CalendarDate.Month, 1, 0, 0, 0);
                DateTime EndDate = new DateTime(calendar1.CalendarDate.Year, calendar1.CalendarDate.Month, daynum, 23, 59, 59);
                string RoomID = "R23";
                DataSet ds = new Business.BookingRoom().PrintDoctorSign(startDate, EndDate, uBranch1.BranchId, RoomID);
                //DataTable dtPrint;

                PopPrintDoctorBook pg = new PopPrintDoctorBook(ds.Tables[0]);
                pg.startDate = startDate;
                pg.EndDate = EndDate;
                pg.BranchId = uBranch1.BranchId;
                pg.RoomID = RoomID;
                pg.RoomName = "Doctor 1";
                pg.title = String.Format("{0} / {1:MMMM, yyyy} {2}", pg.RoomName, Convert.ToDateTime(EndDate), uBranch1.BranchName);
                pg.Text = String.Format("{0} / {1:MMMM, yyyy} {2}", pg.RoomName, Convert.ToDateTime(EndDate), uBranch1.BranchName);
                pg.BranchName = uBranch1.BranchName;
                pg.ShowDialog();

                //DataView dView = new DataView(ds.Tables[0]);
                //dView.RowFilter = string.Format("[RoomID] LIKE '%{0}%'", "R23");
                ////DataView dvdt = ds.Tables[0].DefaultView.RowFilter = string.Format("[RoomID] LIKE '%{0}%'", "R23");

                //dtPrint = dView.ToTable();
                //dtPrint = PivotTable.GenerateTransposedTable(ds.Tables[0]);
                
            }
            catch (Exception)
            {
                
            }
        }
        [DllImportAttribute("gdi32.dll")]
        private static extern bool BitBlt(
        IntPtr hdcDest,
        int nXDest,
        int nYDest,
        int nWidth,
        int nHeight,
        IntPtr hdcSrc,
        int nXSrc,
        int nYSrc,
        int dwRop);
        public Bitmap CaptureControl(Control control)
        {
            Bitmap controlBmp;
            using (Graphics g1 = control.CreateGraphics())
            {
                controlBmp = new Bitmap(control.Width, control.Height, g1);
                using (Graphics g2 = Graphics.FromImage(controlBmp))
                {
                    IntPtr dc1 = g1.GetHdc();
                    IntPtr dc2 = g2.GetHdc();
                    BitBlt(dc2, 0, 0, control.Width, control.Height, dc1, 0, 0, 13369376);
                    g1.ReleaseHdc(dc1);
                    g2.ReleaseHdc(dc2);
                }
            }

            return controlBmp;
        }
        private void picAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(calendar1.CalendarDate.Month);
                string alert = string.Format("บันทึกรายการของเดือน {0}{1}{2} ใหม่ทั้งหมด", monthName,Environment.NewLine,uBranch1.BranchName);
                //if (DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, alert) == DialogResult.Yes)
                popAlert pa=new popAlert();
                pa.txtShow=alert;
                pa.txtTitle="คำเตือน";

                pa.ShowDialog();
                if (pa.DialogResult == DialogResult.Yes)
                {
                     frmAutoBookDoctor p = new frmAutoBookDoctor();
                    p.AutoBook = true;
                    p.year = calendar1.CalendarDate.Year;
                    p.month = calendar1.CalendarDate.Month;
                    p.BranchId = uBranch1.BranchId;
                    p.BranchName = uBranch1.BranchName;
                    p.monthName = monthName;
                    p.ShowDialog();

                    if (p.DialogResult == DialogResult.OK)
                    { 
                        //Loop add
                        dicAutobook = p.dicRoom;
                        SetAutoBook();
                    }

                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SetAutoBook()
        {
            try
            {
                DateTime now = calendar1.CalendarDate;
                var startDate = new DateTime(now.Year, now.Month, 1);
                var endDate = startDate.AddMonths(1).AddDays(-1);
                int x = new Business.BookingRoom().DelBookingDoctorMonth(uBranch1.BranchId, startDate, endDate);

                int year=calendar1.CalendarDate.Year;
                int month=calendar1.CalendarDate.Month;

                calendar1.CalendarDate = new DateTime(year, month, DateTime.Now.Day, 0, 0, 0);
                calendar1.CalendarView = CalendarViews.Month;
                calendar1.AllowEditingEvents = true;
                calendar1.LoadPresetHolidays = false;
                calendar1.Visible = false;
                DataSet dsroom = new Business.BookingRoom().SELECTROOMDOCTOR(DateTime.Now, "", "");

                int daynum = DateTime.DaysInMonth(year, month);

                string daytxt = "";

                int timeAdd = 1;
                foreach (DataRow item in dsroom.Tables[0].Rows)
                {
                    for (int i = 1; i <= daynum; i++)
                    {//AES1 AES2 ANT1 HTP1 PLS1 CRP1

                        string textShow = item["RoomName"]+"";
                        daytxt = new DateTime(year, month, i).DayOfWeek+"";
                        string RoomName = item["RoomName"] + "";
                        string DicKey = string.Format("{0}:{1}", daytxt, item["RoomName"] + "");//column name:RoomName
                        if (dicAutobook.ContainsKey(DicKey))
                        {
                            NewEvent = (CustomEvent)dicAutobook[DicKey].Clone();
                            //NewEvent.EventText = textShow;
                            //RoomID = item["RoomID"] + "",
                            //RoomName = item["RoomName"] + "",
                            NewEvent.Date = new DateTime(year, month, i, timeAdd, 0, 0);

                            NewEvent.TimeStart = new DateTime(year, month, i, NewEvent.TimeStart.Hour, NewEvent.TimeStart.Minute, 0);
                            NewEvent.TimeEnd = new DateTime(year, month, i, NewEvent.TimeEnd.Hour, NewEvent.TimeEnd.Minute, 0);

                            DateTime AddDate = NewEvent.Date.AddDays(NewEvent.AddDate);
                            DateTime DateShowStart = new DateTime(AddDate.Year, AddDate.Month, AddDate.Day, 8, 0, 0);
                            DateTime DateShowEnd = new DateTime(AddDate.Year, AddDate.Month, AddDate.Day, 8, 30, 0);
                            NewEvent.DateShowStart = DateShowStart;
                            NewEvent.DateShowEnd = DateShowEnd;
                            NewEvent.AppointDate = new DateTime(NewEvent.Date.Year, NewEvent.Date.Month, NewEvent.Date.Day, 0, 0, 0);//For booking Time 0:0:0

                            if ((NewEvent.DrID+"").Length > 5)
                            {
                                int? intStatus = new Business.BookingRoom().SaveBookingDoctor(NewEvent);
                                DataSet ds = new Business.BookingRoom().GetBookingDoctorGETMAXID(NewEvent.BranchID);
                                NewEvent.ID = Convert.ToDecimal(ds.Tables[0].Rows[0]["ID"] + "");
                            }

                            calendar1.AddEvent(NewEvent);
                        };
                  

                    }
                    timeAdd++;
                }
                calendar1.Visible = true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
