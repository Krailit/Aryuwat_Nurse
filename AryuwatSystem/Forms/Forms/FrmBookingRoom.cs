using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Calendar;
using System.Xml.Serialization;
using System.IO;
using DermasterSystem.Class;
using Entity;
using WeifenLuo.WinFormsUI.Docking;
using BookingRoomEnt = System.Windows.Forms.Calendar.BookingRoomEnt;

namespace DermasterSystem.Forms
{
    public partial class FrmBookingRoom : DockContent, IForm
    {
        List<CalendarItem> _items = new List<CalendarItem>();
        CalendarItem contextItem = null;
        List<BookingRoomEnt> Roomnames;
        List<ItemInfo> RoomDelete = new List<ItemInfo>();
        private string RoomTyp = "OR";
        private Dictionary<DateTime, BookingRoomEnt> dicRoomname=new Dictionary<DateTime, BookingRoomEnt>();
        private DateTime AppointDate;
        private DataSet dtRoom;
        private DataSet dtAppointment;
        private int indexEdit = 0;
        private DataSet dsCheckDup = new DataSet();

        public FrmBookingRoom()
        {
            InitializeComponent();

            //Monthview colors
            monthView1.MonthTitleColor = monthView1.MonthTitleColorInactive = CalendarColorTable.FromHex("#C2DAFC");
            monthView1.ArrowsColor = CalendarColorTable.FromHex("#77A1D3");
            monthView1.DaySelectedBackgroundColor = CalendarColorTable.FromHex("#F4CC52");
            monthView1.DaySelectedTextColor = monthView1.ForeColor;
            dtRoom = new Business.BookingRoom().SelectRoom("");
           
        }

        public FileInfo ItemsFile
        {
            get 
            {
                return new FileInfo(Path.Combine(Application.StartupPath, "items.xml"));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //if (ItemsFile.Exists)
            //{
            //    List<ItemInfo> lst = new List<ItemInfo>();

            //    XmlSerializer xml = new XmlSerializer(lst.GetType());

            //    using (Stream s = ItemsFile.OpenRead())
            //    {
            //        lst = xml.Deserialize(s) as List<ItemInfo>;
            //    }

            //    foreach (ItemInfo item in lst)
            //    {
            //        CalendarItem cal = new CalendarItem(calendar1, item.StartTime, item.EndTime, item.Text);

            //        if (!(item.R == 0 && item.G == 0 && item.B == 0))
            //        {
            //            cal.ApplyColor(Color.FromArgb(item.A, item.R, item.G, item.B));
            //        }

            //        _items.Add(cal);
            //    }

            //    PlaceItems();
            //}
            //Use it

            AppointDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            dtAppointment = new Business.BookingRoom().GetBookingRoom(AppointDate, "");
            LoadAppointment(AppointDate, RoomTyp);
            SelectRoom(AppointDate, RoomTyp);
        }
        private void LoadAppointment(DateTime curentDate,string typ)
        {
            try
            {
                //AppointDate = new DateTime(curentDate.Year, curentDate.Month, curentDate.Day, 0, 0, 0);
                //SelectRoom(AppointDate);
                _items.Clear();
                calendar1.Items.Clear();
                dtAppointment = new Business.BookingRoom().GetBookingRoom(curentDate, typ);
                this.dsCheckDup = new Business.BookingRoom().DUP_BOOKINGROOM(this.AppointDate.ToString());

                string sql = string.Format("RoomTyp='{0}'", typ);
                List<ItemInfo> lst = new List<ItemInfo>();
                if (dtAppointment == null || dtAppointment.Tables.Count <= 0) return;
                foreach (DataRow item in dtAppointment.Tables[0].Select(sql))
                {
                    CalendarItem cal = new CalendarItem(calendar1, item["RoomID"].ToString(),
                                                        Convert.ToDateTime(item["AppointDate"].ToString()),
                                                        Convert.ToDateTime(item["DateShowStart"].ToString()),
                                                        Convert.ToDateTime(item["DateShowEnd"].ToString()),
                                                        item["Duration"].ToString(),
                                                        Convert.ToInt16(item["A"].ToString()),
                                                        Convert.ToInt16(item["R"].ToString()),
                                                        Convert.ToInt16(item["G"].ToString()),
                                                        Convert.ToInt16(item["B"].ToString()), item["ENSave"].ToString(),
                                                         item["CustName"]+"",
                                                         item["CustID"]+"",
                                                         item["Treadment"]+"",
                                                         item["DrName"]+"",
                                                         item["DrID"]+"",
                                                         item["Mobile"]+"",
                                                         item["Howmagazine"]+"",
                                                         item["Howinternet"]+"",
                                                         item["Howfriend"]+"",
                                                         item["Hownewpaper"]+"",
                                                         item["HowTravel"]+"",
                                                         item["Howother"]+"",
                                                         item["HowotherText"]+"",
                                                         item["Note"]+"",
                                                         item["HowFaceBook"] + "",
                                                         item["HowInstagram"] + "",
                                                         item["BranchID"] + "",
                                                         item["BranchName"] + ""
                                                        
                                                        );

                    if (!(Convert.ToInt16(item["R"].ToString()) == 0 && Convert.ToInt16(item["G"].ToString()) == 0 && Convert.ToInt16(item["B"].ToString()) == 0))
                    {
                    cal.ApplyColor(Color.FromArgb(200, Convert.ToInt16(item["R"].ToString()), Convert.ToInt16(item["G"].ToString()), Convert.ToInt16(item["B"].ToString())));
                    }
                    //cal.ApplyColor(Color.Brown);
                    //Color.FromArgb(Convert.ToInt16(item["A"].ToString())
                    _items.Add(cal);
                }
                calendar1.Items.AddRange(_items);
                calendar1.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SelectRoom(DateTime AppointDate, string typ)
        {
            try
            {
                int i = 0;
                dicRoomname=new Dictionary<DateTime, BookingRoomEnt>();
                if (Roomnames == null)
                {
                    string sql = string.Format("RoomTyp='{0}'", typ);
                    Roomnames = new List<BookingRoomEnt>();
                    BookingRoomEnt o;

                    foreach (DataRow dr in dtRoom.Tables[0].Select(sql))
                    {
                        o = new BookingRoomEnt();
                        o.RoomID = dr["RoomID"] + "";
                        o.RoomName = dr["RoomName"] + "";
                        o.RoomDetail = dr["RoomDetail"] + "";
                        Roomnames.Add(o);
                     }
                }
                foreach (BookingRoomEnt o in Roomnames)
                {
                    DateTime d = AppointDate.AddDays(i);
                    dicRoomname.Add(d, o);
                    i++;
                }
                calendar1.SetViewRange(AppointDate, AppointDate.AddDays(Roomnames.Count - 1));
                calendar1.setVariable(Roomnames);
                //var dr = dt.NewRow();
                //dr["MedStatus_Code"] = 99;
                //dr["MedStatus_Name"] = Statics.StrNewRow;
                //dt.Rows.InsertAt(dr, 0);
                //cboStatus.Items.Clear();
                //cboStatus.DataSource = dt;
                //cboStatus.ValueMember = "MedStatus_Code";
                //cboStatus.DisplayMember = "MedStatus_Name";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void calendar1_ItemCreated(object sender, CalendarItemCancelEventArgs e)
        {
            _items.Add(e.Item);
          

        }

        private void calendar1_ItemDoubleClick(object sender, CalendarItemEventArgs e)
        {
            if (Statics.popbookingAdd == null)
            {
                Statics.popbookingAdd = new PopBookingAdd();
            }
            //Statics.popbookingAdd.drExclude = this.drExclude;
            Statics.popbookingAdd.StartPosition = FormStartPosition.CenterScreen;
            Statics.popbookingAdd.WindowState = FormWindowState.Normal;
            Statics.popbookingAdd.BackColor = Color.FromArgb(170, 0xe8, 0xe5);
            //this.EditBook = false;
            //if ((e.Item.CustName + "".Trim()) != "")
            //{
            //    this.EditBook = true;
            //}
            Statics.popbookingAdd.CustName = e.Item.CustName;
            Statics.popbookingAdd.CustID = e.Item.CustID;
            Statics.popbookingAdd.Treadment = e.Item.Treadment;
            Statics.popbookingAdd.DrName = e.Item.DrName;
            Statics.popbookingAdd.DrID = e.Item.DrID;
            Statics.popbookingAdd.Mobile = e.Item.Mobile;
            Statics.popbookingAdd.Note = e.Item.Note;
            Statics.popbookingAdd.Howmagazine = e.Item.Howmagazine;
            Statics.popbookingAdd.Howinternet = e.Item.Howinternet;
            Statics.popbookingAdd.Howfriend = e.Item.Howfriend;
            Statics.popbookingAdd.Hownewpaper = e.Item.Hownewpaper;
            Statics.popbookingAdd.HowTravel = e.Item.HowTravel;
            Statics.popbookingAdd.Howother = e.Item.Howother;
            Statics.popbookingAdd.HowotherText = e.Item.HowotherText;
            Statics.popbookingAdd.HowFaceBook = e.Item.HowFaceBook;
            Statics.popbookingAdd.HowInstagram = e.Item.HowInstagram;
            Statics.popbookingAdd.BranchID = e.Item.BranchID;
            Statics.popbookingAdd.ENDoctor = e.Item.ENDoctor;
            Statics.popbookingAdd.ShowDialog();
            if (Statics.popbookingAdd.Title != "")
            {
                int num;
                e.Item.Text = "CN:   " + Statics.popbookingAdd.CustID + " " + Statics.popbookingAdd.CustName + "\n\r Tx:   " + Statics.popbookingAdd.Treadment + "\n\r Tel:   " + Statics.popbookingAdd.Mobile + "\n\r Dr.:   " + Statics.popbookingAdd.DrName + "\n\r Note:   " + Statics.popbookingAdd.Note + "\n\r Branch:   " + Statics.popbookingAdd.BranchName;
                e.Item.CustName = Statics.popbookingAdd.CustName;
                e.Item.CustID = Statics.popbookingAdd.CustID;
                e.Item.Treadment = Statics.popbookingAdd.Treadment;
                e.Item.Mobile = Statics.popbookingAdd.Mobile;
                e.Item.Note = Statics.popbookingAdd.Note;
                if ((this.dtAppointment != null) && (this.dtAppointment.Tables.Count > 0))
                {
                    string str = Statics.popbookingAdd.DrID ?? "";
                    string str2 = Statics.popbookingAdd.DrName ?? "";
                    if (str != "")
                    {
                        string text = "";
                        string[] strArray = str.Split(new char[] { ',' });
                        string[] strArray2 = str2.Split(new char[] { ',' });
                        for (num = 0; num < strArray.Length; num++)
                        {
                            string filterExpression = string.Format("DrID like '%{0}%'", strArray[num]);
                            DataRow[] rowArray = this.dsCheckDup.Tables[0].Select(filterExpression);
                            if (rowArray.Length > 0)
                            {
                                for (int i = 0; i < rowArray.Length; i++)
                                {
                                    if (Convert.ToDateTime(rowArray[i]["DateShowStart"] + "").TimeOfDay == e.Item.StartDate.TimeOfDay)
                                    {
                                        Statics.popbookingAdd.DrID = strArray[num]+""!=""?Statics.popbookingAdd.DrID.Replace(strArray[num]+"", "").Replace(",,", ","):Statics.popbookingAdd.DrID.Replace(",,", ",");
                                        Statics.popbookingAdd.DrName = strArray2[num] != "" ? Statics.popbookingAdd.DrName.Replace(strArray2[num], "").Replace(",,", ",") : Statics.popbookingAdd.DrName.Replace(",,", ",");
                                        object[] args = new object[] { strArray2[num], rowArray[i]["RoomName"] + "", Convert.ToDateTime(rowArray[i]["DateShowStart"] + "").ToString("hh:mm tt") ?? "", "\n\r", text };
                                        text = string.Format("{0} ถูกจองไว้แล้ว,ห้อง {1},เวลา {2}{3}{4}", args);
                                    }
                                }
                            }
                        }
                        if (text != "")
                        {
                            MessageBox.Show(text);
                        }
                    }
                }
                e.Item.DrName = Statics.popbookingAdd.DrName;
                e.Item.DrID = Statics.popbookingAdd.DrID;
                e.Item.Howmagazine = Statics.popbookingAdd.Howmagazine;
                e.Item.Howinternet = Statics.popbookingAdd.Howinternet;
                e.Item.Howfriend = Statics.popbookingAdd.Howfriend;
                e.Item.Hownewpaper = Statics.popbookingAdd.Hownewpaper;
                e.Item.HowTravel = Statics.popbookingAdd.HowTravel;
                e.Item.Howother = Statics.popbookingAdd.Howother;
                e.Item.HowotherText = Statics.popbookingAdd.HowotherText;
                e.Item.HowFaceBook = Statics.popbookingAdd.HowFaceBook;
                e.Item.HowInstagram = Statics.popbookingAdd.HowInstagram;
                e.Item.BranchID = Statics.popbookingAdd.BranchID;
                e.Item.BranchName = Statics.popbookingAdd.BranchName;
                e.Item.RoomID = this.dicRoomname[e.Item.DayStart.Date].RoomID ?? "";
                e.Item.AppointDateTime = this.AppointDate;
                this.calendar1.Invalidate(e.Item);
                for (num = 0; num < this._items.Count; num++)
                {
                    if (this._items[num].CustName.ToUpper() == e.Item.CustName.ToUpper())
                    {
                        this.indexEdit = num;
                        break;
                    }
                }
                this.Save(false);
                this.LoadAppointment(this.AppointDate, this.RoomTyp);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // Wheel(1200, true);//Wheel down
            Wheel(1200, false);//Wheel up
        }
        private void Wheel(int ticks, bool down){
          //WM_MOUSEWHEEL = 0x20a
          Message msg = Message.Create(Handle, 0x20a, new IntPtr((down ? -1 : 1)<<16), new IntPtr(MousePosition.X + MousePosition.Y << 16));
          for(int i = 0; i < ticks; i++)
              WndProc(ref msg);
        }

        public void doMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
        }
        private void calendar1_LoadItems(object sender, CalendarLoadEventArgs e)
        {
            PlaceItems();
          
        }

        private void PlaceItems()
        {
            foreach (CalendarItem item in _items)
            {
                if (calendar1.ViewIntersects(item))
                {
                    calendar1.Items.Add(item);
                }
            }
        }

    

        private void calendar1_ItemMouseHover(object sender, CalendarItemEventArgs e)
        {
            //Text = e.Item.Text;
           // toolTip1.Show(e.Item.Text + "\n\r" + e.Item.Detail, (Control)sender);
         
            if(e.Item.Text.Length>0)
            {
                lbTooltip.Text = e.Item.Text;
                Point p=new Point(MousePosition.X-250,MousePosition.Y-50);
                panelTootip.Location = p;
                panelTootip.Visible = true;
            }
            else
            {
                panelTootip.Visible = false;
            }
        }

        private void calendar1_ItemClick(object sender, CalendarItemEventArgs e)
        {
            //MessageBox.Show(e.Item.Text);
        }

        private void hourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calendar1.TimeScale = CalendarTimeScale.SixtyMinutes;
        }

        private void minutesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calendar1.TimeScale = CalendarTimeScale.ThirtyMinutes;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            calendar1.TimeScale = CalendarTimeScale.FifteenMinutes;
        }

        private void minutesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            calendar1.TimeScale = CalendarTimeScale.SixMinutes;
        }

        private void minutesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            calendar1.TimeScale = CalendarTimeScale.TenMinutes;
        }

        private void minutesToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            calendar1.TimeScale = CalendarTimeScale.FiveMinutes;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            contextItem = calendar1.ItemAt(contextMenuStrip1.Bounds.Location);
        }

        private void redTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.ApplyColor(Color.Red);
                calendar1.Invalidate(item);
            }
        }

        private void yellowTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.ApplyColor(Color.Gold);
                calendar1.Invalidate(item);
            }
        }

        private void greenTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.ApplyColor(Color.Green);
                calendar1.Invalidate(item);
            }
        }

        private void blueTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.ApplyColor(Color.DarkBlue);
                calendar1.Invalidate(item);
            }
        }

        private void editItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calendar1.ActivateEditMode();
        }

        private void DemoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //List<ItemInfo> lst = new List<ItemInfo>();
            
            //foreach (CalendarItem item in _items)
            //{
            //    lst.Add(new ItemInfo(item.StartDate, item.EndDate, item.Text, item.BackgroundColor,item.Tag.ToString()));
            //}
            ////intStatus = new Business.SumOfTreatment().UpdateSumOfTreatment(info);
            ////foreach (ItemInfo Info in lst)
            ////{
            ////    string ss=Info.
            ////}
            //XmlSerializer xmls = new XmlSerializer(lst.GetType());

            //if (ItemsFile.Exists)
            //{
            //    ItemsFile.Delete();
            //}

            //using (Stream s = ItemsFile.OpenWrite())
            //{
            //    xmls.Serialize(s, lst);
            //    s.Close();
            //}
            Statics.bookingroom = null;
        }

        private void otherColorTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ColorDialog dlg = new ColorDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    foreach (CalendarItem item in calendar1.GetSelectedItems())
                    {
                        item.ApplyColor(dlg.Color);
                        calendar1.Invalidate(item);
                    }
                }
            }
        }
       

        private void calendar1_ItemDeleted(object sender, CalendarItemEventArgs e)
        {
            RoomDelete=new List<ItemInfo>();
            _items.Remove(e.Item);
            ItemInfo o = new ItemInfo();
            o.RoomID = e.Item.RoomID;
            o.DateShowStart = e.Item.StartDate;
            RoomDelete.Add(o);
            Save(false);
            //dtAppointment = new Business.BookingRoom().GetBookingRoom(AppointDate, "");
            LoadAppointment(AppointDate, RoomTyp);
        }

        private void calendar1_DayHeaderClick(object sender, CalendarDayEventArgs e)
        {
            calendar1.SetViewRange(e.CalendarDay.Date, e.CalendarDay.Date.AddDays(4));
        }

        private void diagonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.Pattern = System.Drawing.Drawing2D.HatchStyle.ForwardDiagonal;
                item.PatternColor = Color.Red;
                calendar1.Invalidate(item);
            }
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.Pattern = System.Drawing.Drawing2D.HatchStyle.Vertical;
                item.PatternColor = Color.Red;
                calendar1.Invalidate(item);
            }
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.Pattern = System.Drawing.Drawing2D.HatchStyle.Horizontal;
                item.PatternColor = Color.Red;
                calendar1.Invalidate(item);
            }
        }

        private void hatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.Pattern = System.Drawing.Drawing2D.HatchStyle.DiagonalCross;
                item.PatternColor = Color.Red;
                calendar1.Invalidate(item);
            }
        }

        private void noneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.Pattern = System.Drawing.Drawing2D.HatchStyle.DiagonalCross;
                item.PatternColor = Color.Empty;
                calendar1.Invalidate(item);
            }
        }

        private void monthView1_SelectionChanged(object sender, EventArgs e)
        {
            //calendar1.SetViewRange(monthView1.SelectionStart, monthView1.SelectionEnd);
            //calendar1.SetViewRange(monthView1.SelectionStart, monthView1.SelectionStart.AddDays(4));
          //  Save(false);
            AppointDate = new DateTime(monthView1.SelectionStart.Year, monthView1.SelectionStart.Month, monthView1.SelectionStart.Day, 0, 0, 0);
            dtAppointment = new Business.BookingRoom().GetBookingRoom(AppointDate, "");
            SelectRoom(AppointDate, RoomTyp); //Add By tu_cs
            LoadAppointment(AppointDate,RoomTyp);
            calendar1.Invalidate();
        }

        private void northToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.ImageAlign = CalendarItemImageAlign.North;
                calendar1.Invalidate(item);
            }
        }

        private void eastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.ImageAlign = CalendarItemImageAlign.East;
                calendar1.Invalidate(item);
            }
        }

        private void southToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.ImageAlign = CalendarItemImageAlign.South;
                calendar1.Invalidate(item);
            }
        }

        private void westToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                item.ImageAlign = CalendarItemImageAlign.West;
                calendar1.Invalidate(item);
            }
        }

        private void selectImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "*.gif|*.gif|*.png|*.png|*.jpg|*.jpg";

                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    Image img = Image.FromFile(dlg.FileName);

                    foreach (CalendarItem item in calendar1.GetSelectedItems())
                    {
                        item.Image = img;
                        calendar1.Invalidate(item);
                    }
                }
            }

            
        }


        public void IsSave()
        {
            //throw new NotImplementedException();
        }

        public void IsDelete()
        {
            //throw new NotImplementedException();
        }

        public void IsRefresh()
        {
            //throw new NotImplementedException();
        }

        public void IsEdit()
        {
           // throw new NotImplementedException();
        }

        public void IsPrint()
        {
           // throw new NotImplementedException();
        }

        public void IsNew()
        {
            //throw new NotImplementedException();
        }

        public void IsExit()
        {
            //throw new NotImplementedException();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save(true);
        }
        private void Save(bool showMessageBox)
        {
            try
            {
                List<ItemInfo> lst = new List<ItemInfo>();

                foreach (CalendarItem item in _items)
                {
                    string du = item.Duration.Hours + "." + item.Duration.Minutes + "";
                    //item.AppointDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                    lst.Add(new ItemInfo(item.RoomID, item.AppointDateTime, item.StartDate, item.EndDate, du, item.BackgroundColor.A, item.BackgroundColor.R, item.BackgroundColor.G, item.BackgroundColor.B, Entity.Userinfo.EN.Trim()
                        ,item.CustName,item.CustID,item.Treadment,item.Mobile,item.DrName,item.DrID,item.Howmagazine,item.Howinternet,item.Howfriend
                        ,item.Hownewpaper,item.HowTravel,item.Howother,item.HowotherText,item.Note,item.BranchID,item.BranchName));
                }

                int? intStatus = new Business.BookingRoom().SaveBookingRoom(lst, RoomDelete);
                RoomDelete=new List<ItemInfo>();
                if (intStatus != null || intStatus > 0)
                {
                    if (showMessageBox)MessageBox.Show("Save compleate");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Statics.bookingroom = null;
            this.Close();
        }

        private void rdbRoom_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbRoom.Checked == false) return;
                //Save(false);
                Roomnames = null;
                RoomTyp = "OR";
                SelectRoom(AppointDate, RoomTyp);
                LoadAppointment(AppointDate, RoomTyp);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }

        private void rdbVIP_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbVIP.Checked == false) return;
               // Save(false);
                Roomnames = null;
                RoomTyp = "VIP";
                SelectRoom(AppointDate, RoomTyp);
                LoadAppointment(AppointDate, RoomTyp);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
       
        }

        private void rdbVAN_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbVAN.Checked == false) return;
                //Save(false);
                Roomnames = null;
                RoomTyp = "VAN";
                SelectRoom(AppointDate, RoomTyp);
                LoadAppointment(AppointDate, RoomTyp);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        //private void rdbDoctor_CheckedChanged(object sender, EventArgs e)
        //{
        //    try
        //    { 
        //        if (rdbDoctor.Checked == false) return;
        //       // Save(false);
        //        Roomnames = null;
        //        RoomTyp = "LASER";
        //        SelectRoom(AppointDate, RoomTyp);
        //        LoadAppointment(AppointDate, RoomTyp);
               
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
            
        //}

        //private void rdbTx_CheckedChanged(object sender, EventArgs e)
        //{
        //    try
        //    { 
        //        if (rdbTx.Checked == false) return;
        //        //Save(false);
        //        Roomnames = null;
        //        RoomTyp = "TXROOM";
        //        SelectRoom(AppointDate, RoomTyp);
        //        LoadAppointment(AppointDate, RoomTyp);
              
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
            
        //}

        private void rdbTxHaie_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                
                if (rdbTxHaie.Checked == false) return;
                //Save(false);
                Roomnames = null;
                RoomTyp = "TXHAIR";
                SelectRoom(AppointDate, RoomTyp);
                LoadAppointment(AppointDate, RoomTyp);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void rdbHis_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
               
                if (rdbHis.Checked == false) return;
               // Save(false);
                Roomnames = null;
                RoomTyp = "THERAPIST";
                SelectRoom(AppointDate, RoomTyp);
                LoadAppointment(AppointDate, RoomTyp);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        //private void rdbHer_CheckedChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
              
        //        if (rdbHer.Checked == false) return;
        //        //Save(false);
        //                Roomnames = null;
        //                RoomTyp = "HER";
        //                SelectRoom(AppointDate, RoomTyp);
        //                LoadAppointment(AppointDate, RoomTyp);
                        
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
            
        //}

        private void calendar1_ItemMouseLeave(object sender, CalendarItemEventArgs e)
        {
            panelTootip.Visible = false;
        }

        private void radioButtonDoctor_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonDoctor.Checked == false) return;
                //Save(false);
                Roomnames = null;
                RoomTyp = "DOCTOR";
                SelectRoom(AppointDate, RoomTyp);
                LoadAppointment(AppointDate, RoomTyp);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void raRecovery_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (raRecovery.Checked == false) return;
                //Save(false);
                Roomnames = null;
                RoomTyp = "RECOVERY";
                SelectRoom(AppointDate, RoomTyp);
                LoadAppointment(AppointDate, RoomTyp);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void radioMetting_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioMetting.Checked == false) return;
                //Save(false);
                Roomnames = null;
                RoomTyp = "METTING";
                SelectRoom(AppointDate, RoomTyp);
                LoadAppointment(AppointDate, RoomTyp);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void pictureBoxExport_Click(object sender, EventArgs e)
        {
            try
            {
                PopBookingExport obj = new PopBookingExport();
                obj.StartPosition = FormStartPosition.CenterParent;
                obj.WindowState = FormWindowState.Normal;
                obj.MaximizeBox = false;
                obj.MinimizeBox = false;
                obj.dtRoom = dtRoom.Tables[0].Copy();
                obj.ShowDialog();


                if (obj.whereDate == "" || obj.WhereRoomID == "")
                {
                    MessageBox.Show("Not found"); return;
                }
             
                string roomID = obj.WhereRoomID;
                string date = obj.whereDate;
                DataSet dsExport = new Business.BookingRoom().GetBookingRoomExport(date, roomID);
               
                ExportFile exp = new ExportFile();
                //DataSet ds=new DataSet();
                //ds.Tables.Add();
                //SaveFileDialog saveDlg = new SaveFileDialog();
                //saveDlg.Filter = "Excel File (*.xls)|*.xls";
                ////saveDlg.Filter = "Excel(xlsx)|*.xlsx";
                //if (saveDlg.ShowDialog() == DialogResult.OK)
                //{
                    //DataSet dataSet=new DataSet();
                    DataTable dt=new DataTable();
                    dt = dsExport.Tables[0].Copy();
                    if (dt.Rows.Count == 0) MessageBox.Show("Not found");
                    dt.Columns.Remove("ID");
                    dt.Columns.Remove("RoomID");
                    dt.Columns.Remove("Duration"); 
                    dt.Columns.Remove("A");
                    dt.Columns.Remove("R");
                    dt.Columns.Remove("G");
                    dt.Columns.Remove("B");
                    dt.Columns.Remove("ENSave");
                    dt.Columns.Remove("CustID");
                    dt.Columns.Remove("DrID");

                      dt.Columns.Remove("Howmagazine");
                    dt.Columns.Remove("Howinternet"); 
                    dt.Columns.Remove("Howfriend");
                    dt.Columns.Remove("Hownewpaper");
                    dt.Columns.Remove("HowTravel");
                    dt.Columns.Remove("Howother");
                    dt.Columns.Remove("HowotherText");
                    dt.Columns.Remove("HowFaceBook");
                    dt.Columns.Remove("HowInstagram");
                       dt.Columns.Remove("BranchID");
                    dt.Columns.Remove("ENDoctor");
                    dt.Columns.Remove("RoomTyp");
                    //dataSet.Tables.Add(dt);
                    DataTable dt2 = new DataTable("Booking");
                //foreach (var VARIABLE in dt.Columns)
                //{
                //    dt2.Columns.Add("", typeof (string));
                //}
                    dt2.Columns.Add("Room Name", typeof(string));
                dt2.Columns.Add("Date", typeof(string));
                dt2.Columns.Add("StartTime", typeof(string));
                dt2.Columns.Add("EndTime", typeof(string));
                dt2.Columns.Add("Customer Name", typeof(string));
                dt2.Columns.Add("Mobile", typeof(string));
                dt2.Columns.Add("Treadment", typeof(string));
                dt2.Columns.Add("Dr.", typeof(string));
                dt2.Columns.Add("Note", typeof(string));
                dt2.Columns.Add("Branch", typeof(string));
                    foreach (DataRowView item in dt.DefaultView)
                    {
                        DateTime dateTimeStart = Convert.ToDateTime(item["DateShowStart"] + "");
                        DateTime dateTimeEnd = Convert.ToDateTime(item["DateShowEnd"] + "");
                        var myItems = new IComparable[]
                                      {  item["RoomName"] + "",
                                          String.Format("{0:dd/MM/yyyy}", dateTimeStart),
                                          dateTimeStart.ToString("HH:mm")+"",
                                          dateTimeEnd.ToString("HH:mm")+"",
                                          item["CustName"] + "",
                                          item["Mobile"] + "",
                                          item["Treadment"] + "",
                                          item["DrName"] + "",
                                          item["Note"] + "",
                                          item["BranchName"] + ""
                                      };
                        dt2.Rows.Add(myItems);
                    }
                   // exp.ExportMultipleGridToOneExcel(dt2);
                    SaveFileDialog saveDlg = new SaveFileDialog();
                    saveDlg.Filter = "Excel File (*.xlsx)|*.xlsx";
                    //saveDlg.Filter = "Excel(xlsx)|*.xlsx";
                    if (saveDlg.ShowDialog() == DialogResult.OK)
                    {
                        DataSet dataSet = new DataSet();
                        dataSet.Tables.Add(dt2);
                        //exp.Export(dataSet, saveDlg.FileName);
                        DermasterSystem.Forms.ExcelHelper.ExportToExcel(dataSet, saveDlg.FileName, "");

                    }
               
               //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

       
    }
}