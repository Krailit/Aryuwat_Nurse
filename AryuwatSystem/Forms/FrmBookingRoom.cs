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
using AryuwatSystem.DerClass;
using Entity;
using WeifenLuo.WinFormsUI.Docking;
using BookingRoomEnt = System.Windows.Forms.Calendar.BookingRoomEnt;
using System.Drawing.Imaging;
using AryuwatSystem.Forms.FRMReport;

namespace AryuwatSystem.Forms
{
    public partial class FrmBookingRoom : DockContent, IForm
    {
        List<CalendarItem> _items = new List<CalendarItem>();
        CalendarItem ItemCopy;
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
        CalendarItem CurrentItem;
        public FrmBookingRoom()
        {
            InitializeComponent();

            //Monthview colors
            monthView1.MonthTitleColor = monthView1.MonthTitleColorInactive = CalendarColorTable.FromHex("#C2DAFC");
            monthView1.ArrowsColor = CalendarColorTable.FromHex("#77A1D3");
            monthView1.DaySelectedBackgroundColor = CalendarColorTable.FromHex("#F4CC52");
            monthView1.DaySelectedTextColor = monthView1.ForeColor;
            dtRoom = new Business.BookingRoom().SelectRoom("");
            calendar1.KeyDown += new KeyEventHandler(calendar1_KeyDown);
           
        }
        private bool IsDoctorBook(string BookID)
        {
            bool isDocbook = false;
            DataSet ds = new Business.BookingRoom().GetBookingDoctorID(Convert.ToDecimal(BookID));
            if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["DrBookID"]+""!="")
            {
                DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "For Doctor booking." + System.Environment.NewLine + "You can change color only.");
                isDocbook= true;
            }
            else isDocbook= false;
            return isDocbook;
        }
        void calendar1_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.KeyCode == Keys.Delete)
            {
                if (IsDoctorBook(CurrentItem.BookID))
                {
                    e.SuppressKeyPress = true;
                }
                if (CheckPermission(ENSave) == false)
                {
                    e.SuppressKeyPress = true;
                }
            }
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

            //panelCarenda.Width = 3000;
            //calendar1.Width = 3000;
            //calendar1.Height = 1000;
            //panelCarenda.VerticalScroll.Visible = true;
            //panelCarenda.HorizontalScroll.Visible = true;

            

            AppointDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            dtAppointment = new Business.BookingRoom().GetBookingRoom(AppointDate, "", uBranch1.BranchId);
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
                dtAppointment = new Business.BookingRoom().GetBookingRoom(curentDate, typ,uBranch1.BranchId);
                this.dsCheckDup = new Business.BookingRoom().DUP_BOOKINGROOM(this.AppointDate.ToString());

                string sql = string.Format("RoomTyp='{0}'", typ);
                List<ItemInfo> lst = new List<ItemInfo>();
                if (dtAppointment == null || dtAppointment.Tables.Count <= 0) return;
                foreach (DataRow item in dtAppointment.Tables[0].Select(sql))
                {
                    CalendarItem cal = new CalendarItem(calendar1, item["ID"].ToString(), item["RoomID"].ToString(),
                                                        Convert.ToDateTime(item["AppointDate"].ToString()),
                                                        Convert.ToDateTime(item["DateShowStart"].ToString()),
                                                        Convert.ToDateTime(item["DateShowEnd"].ToString()),
                                                        item["Duration"].ToString(),
                                                        Convert.ToInt16(item["A"].ToString()),
                                                        Convert.ToInt16(item["R"].ToString()),
                                                        Convert.ToInt16(item["G"].ToString()),
                                                        Convert.ToInt16(item["B"].ToString()), 
                                                        item["ENSave"].ToString(),
                                                         item["ENSaveName"] + "",
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
                                                         item["BranchName"] + "",
                                                         item["DateSave"] + "",
                                                         item["DrBookID"] + "" == "" ? 0 : Convert.ToInt16(item["DrBookID"] + "")
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
        private void calendar1_ItemCreating(object sender, CalendarItemCancelEventArgs e)
        {
            try
            {


                if (e.Item.StartDate.Hour == 8 && e.Item.StartDate.Minute == 0 && e.Item.DayStart._containedItems.Count==0 && radioButtonDoctor.Checked)
                {
                     DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "For Doctor booking." + System.Environment.NewLine + "You can change color only.");
                        e.Cancel = true;
                        return;
                }
                else if (e.Item.StartDate.Hour == 8 && e.Item.StartDate.Minute == 0 && e.Item.DayStart._containedItems.Count > 0 && radioButtonDoctor.Checked)
                { 
                    string DoctorBookEN = e.Item.DayStart._containedItems[0].DrID + "";
                    //string DoctorBookName = e.Item.DayStart._containedItems[0].DrName + "";
                    if (DoctorBookEN == "")
                    {
                        DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "For Doctor booking." + System.Environment.NewLine + "You can change color only.");
                        e.Cancel = true;
                        return;
                    }
                }
            }
            catch (Exception)
            {
                
               
            }
            
        }
        private void calendar1_ItemCreated(object sender, CalendarItemCancelEventArgs e)
        {
            //string DoctorBookEN = e.Item.DayStart._containedItems[0].DrID + "";
            //string DoctorBookName = e.Item.DayStart._containedItems[0].DrName + "";

            //if (e.Item.StartDate.Hour == 8 && e.Item.StartDate.Minute == 0 && DoctorBookEN == "" && radioButtonDoctor.Checked)
            //{
            //   // DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "For Doctor booking." + System.Environment.NewLine + "You can change color only.");
            //    e.Cancel = true;
            //    return;
            //}
            _items.Add(e.Item);
          

        }
        private bool CheckPermission(string ENSave)
        {
            bool Pass = false;
            try
            {
                if (ENSave + "" == "") return true;
                
                

                if (!(Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN) && Userinfo.EN != ENSave && !Userinfo.IS_ADMIN_BOOKING.Contains(Userinfo.EN))
                {
                    DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "Is not Admin or Owner");
                    return false;
                }
                else
                {
                    Pass = true;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Pass;
        }
        private void calendar1_ItemDoubleClick(object sender, CalendarItemEventArgs e)
        {
            try
            {
              if(IsDoctorBook(e.Item.BookID))return;

              string DoctorBookEN =  "";
              string DoctorBookName =  "";
              foreach (CalendarItem item in e.Item.DayStart._containedItems)
	            {
                    if (item.Date.TimeOfDay.Hours == 8)
                    {
                        DoctorBookEN = item.DrID + "";
                        DoctorBookName = item.DrName + "";
                    }
	            } 

              //string DoctorBookEN = e.Item.DayStart._containedItems[0].DrID+"";
              //string DoctorBookName = e.Item.DayStart._containedItems[0].DrName+"";

              if (e.Item.StartDate.Hour == 8 && e.Item.StartDate.Minute == 0 && DoctorBookEN == "" && radioButtonDoctor.Checked)
              {
                  DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "For Doctor booking."+System.Environment.NewLine+"You can change color only.");
                
                  return;
              }

            if (CheckPermission(e.Item.ENSave) == false) return;
            if (Statics.popbookingAdd == null)
            {
                Statics.popbookingAdd = new PopBookingAdd();
            }
            //Statics.popbookingAdd.drExclude = this.drExclude;
            Statics.popbookingAdd.StartPosition = FormStartPosition.CenterScreen;
            Statics.popbookingAdd.WindowState = FormWindowState.Normal;
            Statics.popbookingAdd.BackColor = Color.FromArgb(255, 230, 217);
            //this.EditBook = false;
            //if ((e.Item.CustName + "".Trim()) != "")
            //{
            //    this.EditBook = true;
            //}

            Statics.popbookingAdd.Title = e.Item.CustName;

            Statics.popbookingAdd.CustName = e.Item.CustName;
            Statics.popbookingAdd.CustID = e.Item.CustID;
            Statics.popbookingAdd.Treadment = e.Item.Treadment;
        
              

          

            string oldDrID = "";
            if (DoctorBookEN != "")
            {
                Statics.popbookingAdd.DrID = DoctorBookEN;
                 oldDrID = DoctorBookEN;
                 Statics.popbookingAdd.DrName = DoctorBookName;
            }
            else
            {
                Statics.popbookingAdd.DrID = e.Item.DrID;
                Statics.popbookingAdd.ENDoctor = e.Item.ENDoctor;
                 oldDrID = e.Item.DrID;
                 Statics.popbookingAdd.DrName = e.Item.DrName;
            }

            
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
            Statics.popbookingAdd.BranchID = !string.IsNullOrEmpty(e.Item.BranchID)?e.Item.BranchID:uBranch1.BranchId; 
            //Statics.popbookingAdd.ENDoctor = e.Item.ENDoctor;
            Statics.popbookingAdd.ENSave = e.Item.ENSave;
            //Statics.popbookingAdd.ShowDialog();
        
            if (Statics.popbookingAdd.ShowDialog() != DialogResult.OK)
                    LoadAppointment(AppointDate, RoomTyp); return;
            //if (Statics.popbookingAdd.Title+"" != "")
            //{
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
                                    if (oldDrID != "" && oldDrID == Statics.popbookingAdd.DrID) continue;
                                    if (Convert.ToDateTime(rowArray[i]["DateShowStart"] + "").TimeOfDay == e.Item.StartDate.TimeOfDay )// ถ้าหมอไม่เปลี่ยนคน ก็ไม่ต้องเช็ค
                                    {
                                        Statics.popbookingAdd.DrID = strArray[num]+""!=""?Statics.popbookingAdd.DrID.Replace(strArray[num]+"", "").Replace(",,", ","):Statics.popbookingAdd.DrID.Replace(",,", ",");
                                        Statics.popbookingAdd.DrName = strArray2[num] != "" ? Statics.popbookingAdd.DrName.Replace(strArray2[num], "").Replace(",,", ",") : Statics.popbookingAdd.DrName.Replace(",,", ",");
                                        object[] args = new object[] { strArray2[num], rowArray[i]["RoomName"] + "", Convert.ToDateTime(rowArray[i]["DateShowStart"] + "").ToString("hh:mm tt") ?? "", "\n\r", text };
                                        text = string.Format("{0} ถูกจองไว้แล้ว,ห้อง {1},เวลา {2}{3}{4}{5}{6}", args[0], args[1], args[2], args[3], args[4], Environment.NewLine, "กรุณา เลือกใหม่อีกครั้ง");
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
                e.Item.ENSave = Statics.popbookingAdd.ENSave;
                e.Item.DateSave = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                this.calendar1.Invalidate(e.Item);
                for (num = 0; num < this._items.Count; num++)
                {
                    if (this._items[num].CustName.ToUpper() == e.Item.CustName.ToUpper())
                    {
                        this.indexEdit = num;
                        break;
                    }
                }
                //this.Save(false);
                this.Save(true,false);
                this.LoadAppointment(this.AppointDate, this.RoomTyp);

                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                panelTootip.Size = lbTooltip.Size;
            }
            else
            {
                panelTootip.Visible = false;
            }
        }
        string ENSave = "";
        private void calendar1_ItemClick(object sender, CalendarItemEventArgs e)
        {
            ENSave = e.Item.ENSave;
            CurrentItem = e.Item;
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
            try
            {
                
                if (DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeConfirmYesNo,Statics.StrConfirmDelete +" "+e.Item.CustName) ==DialogResult.Yes)
                {
                    RoomDelete = new List<ItemInfo>();
                    _items.Remove(e.Item);
                    ItemInfo o = new ItemInfo();
                    o.RoomID = e.Item.RoomID;
                    o.BookID = e.Item.BookID;
                    o.DateShowStart = e.Item.StartDate;
                    RoomDelete.Add(o);
                    Save(false, true);
                    //dtAppointment = new Business.BookingRoom().GetBookingRoom(AppointDate, "");
                    LoadAppointment(AppointDate, RoomTyp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
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
            dtAppointment = new Business.BookingRoom().GetBookingRoom(AppointDate, "",uBranch1.BranchId);
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
            Save(true,false);
        }
        private void Save(bool showMessageBox,bool delOnly)
        {
            try
            {
                List<ItemInfo> lst = new List<ItemInfo>();
                if (delOnly == false)
                {
                    foreach (CalendarItem item in _items)
                    {
                        string du = item.Duration.Hours + "." + item.Duration.Minutes + "";
                        //item.AppointDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                        lst.Add(new ItemInfo(item.RoomID, item.AppointDateTime, item.StartDate, item.EndDate, du, item.BackgroundColor.A, item.BackgroundColor.R, item.BackgroundColor.G, item.BackgroundColor.B, item.ENSave.Trim()
                            , item.CustName, item.CustID, item.Treadment, item.Mobile, item.DrName, item.DrID, item.Howmagazine, item.Howinternet, item.Howfriend
                            , item.Hownewpaper, item.HowTravel, item.Howother, item.HowotherText, item.Note, item.BranchID, item.BranchName, item.DateSave, item.DrBookID,item.BookID));
                    }
                }

                int? intStatus = new Business.BookingRoom().SaveBookingRoom(lst, RoomDelete);
                RoomDelete=new List<ItemInfo>();
                if (intStatus != null || intStatus > 0)
                {
                    if (showMessageBox) MessageBox.Show("Save complete");
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
                RoomTyp = "DRIVER";
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
                RoomTyp = "ANTI";
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
                RoomTyp = "HAIRTRANS";
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
                RoomTyp = "MARKETING";
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
                    //MessageBox.Show("Not found");
                    return;
                }
             
                string roomID = obj.WhereRoomID;
                string date = obj.whereDate;
                DataSet dsExport = new Business.BookingRoom().GetBookingRoomExport(date, roomID);
                //PopGridBooking pg = new PopGridBooking(dsExport.Tables[0]);
                //pg.Text = "";
                //pg.ShowDialog();
               
                ExportFile exp = new ExportFile();
                
                    DataTable dt=new DataTable();
                    dt = dsExport.Tables[0].Copy();
                    if (dt.Rows.Count == 0) 
                    {
                        MessageBox.Show("Not found");
                        return;
                    }
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
                    //dt.Columns.Remove("RoomTyp");
                    //dataSet.Tables.Add(dt);
                    DataTable dt2 = new DataTable("Booking");
                //foreach (var VARIABLE in dt.Columns)
                //{
                //    dt2.Columns.Add("", typeof (string));
                //}
                    dt2.Columns.Add("RoomTyp", typeof(string));
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
                        DateTime APdateTime = Convert.ToDateTime(item["AppointDate"] + "");
                        DateTime dateTimeStart = Convert.ToDateTime(item["DateShowStart"] + "");
                        DateTime dateTimeEnd = Convert.ToDateTime(item["DateShowEnd"] + "");
                        var myItems = new IComparable[]
                                      {  
                                          item["RoomTyp"] + "",
                                          item["RoomName"] + "",
                                          String.Format("{0:dd/MM/yyyy}", APdateTime),
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
                        AryuwatSystem.Forms.ExcelHelper.ExportToExcel(dataSet, saveDlg.FileName, "");

                    }
               
               //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void copyItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                 foreach (CalendarItem Item in calendar1.GetSelectedItems())
                    {

                        //Item.StartDate = new DateTime(2017, 01, 13, 15, 0, 0);
                        //Item.EndDate = new DateTime(2017, 01, 13, 15, 30, 0);
                        //Item.AppointDateTime = new DateTime(2017, 01, 13, 0, 0, 0);
                        ItemCopy = Item;
                        //this.calendar1.Invalidate(Item);
                        //for (num = 0; num < this._items.Count; num++)
                        //{
                        //    if (this._items[num].CustName.ToUpper() == e.Item.CustName.ToUpper())
                        //    {
                        //        this.indexEdit = num;
                        //        break;
                        //    }
                        //}
                        //this.Save(false);
                        //this.LoadAppointment(this.AppointDate, this.RoomTyp);
                        break;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);   
            }
        }

        private void paseItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ItemCopy == null) return;
                CalendarItem Item = ItemCopy;
                DateTime dstart = new DateTime(calendar1.hitItem.Date.Year, calendar1.hitItem.Date.Month, calendar1.hitItem.Date.Day, calendar1.hitItem.Date.Hour, calendar1.hitItem.Date.Minute, 0);
                DateTime AppointDateTime = new DateTime(calendar1.hitItem.Date.Year, calendar1.hitItem.Date.Month, calendar1.hitItem.Date.Day,0, 0, 0);
                DateTime dEnd = new DateTime(calendar1.hitItem.Date.Year, calendar1.hitItem.Date.Month, calendar1.hitItem.Date.Day, calendar1.hitItem.Date.Hour, calendar1.hitItem.Date.Minute, 0).AddHours(ItemCopy.Duration.Hours).AddMinutes(ItemCopy.Duration.Minutes);
                Item.StartDate = dstart;
                Item.EndDate = dEnd;// new DateTime(calendar1.hitItem.Date.Year, calendar1.hitItem.Date.Month, calendar1.hitItem.Date.Day, calendar1.hitItem.Date.Hour, calendar1.hitItem.Date.Minute, 0).AddHours(ItemCopy.Duration.Hours).AddMinutes(ItemCopy.Duration.Minutes);
                Item.AppointDateTime = AppointDateTime;// ItemCopy.AppointDateTime;

                
                _items.Add(Item);
                this.calendar1.Invalidate(Item);
                //for (num = 0; num < this._items.Count; num++)
                //{
                //    if (this._items[num].CustName.ToUpper() == e.Item.CustName.ToUpper())
                //    {
                //        this.indexEdit = num;
                //        break;
                //    }
                //}
                this.Save(false,false);
                this.LoadAppointment(this.AppointDate, this.RoomTyp);
                 //foreach (CalendarItem Item in calendar1.GetSelectedItems())
                 //   {
                 //       if (ItemCopy == null) return;
                 //       ItemCopy.StartDate = calendar1.SelectionStart; // Item.StartDate;
                 //       ItemCopy.EndDate = calendar1.SelectionEnd; //Item.EndDate;
                 //       ItemCopy.AppointDateTime = calendar1.SelectionStart.Date;//Item.AppointDateTime;
                        
                 //       this.calendar1.Invalidate(ItemCopy);
                 //       //for (num = 0; num < this._items.Count; num++)
                 //       //{
                 //       //    if (this._items[num].CustName.ToUpper() == e.Item.CustName.ToUpper())
                 //       //    {
                 //       //        this.indexEdit = num;
                 //       //        break;
                 //       //    }
                 //       //}
                 //       this.Save(false);
                 //       this.LoadAppointment(this.AppointDate, this.RoomTyp);

                 //       break;
                 //   }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try 
	        {	        
		
                      Bitmap bmpScreenshot;
                  Graphics gfxScreenshot;
                  btnSave.Visible=false;
                      pictureBoxExport.Visible = false;
                      button2.Visible = false;
                      panelLeft.BackColor = Color.White;
                     // calendar1.BackColor = Color.Transparent;

                      bmpScreenshot = new Bitmap(panelPrint.Bounds.Width, panelPrint.Bounds.Height, PixelFormat.Format24bppRgb);
                    gfxScreenshot = Graphics.FromImage(bmpScreenshot);
                    gfxScreenshot.CopyFromScreen(PointToScreen(panelPrint.Location).X, PointToScreen(panelPrint.Location).Y, 0, 0, panelPrint.Bounds.Size, CopyPixelOperation.SourcePaint);
                string filePath=Application.StartupPath + @"\CaptureSourcePaint.jpg";
                bmpScreenshot.Save(filePath, ImageFormat.Jpeg);
                FileInfo f = new FileInfo(filePath);
                if (f.Exists) Process.Start(filePath);
                    gfxScreenshot.Dispose();
                   // panelLeft.BackColor = Color.LightBlue;
                //calendar1.BackColor=
                    btnSave.Visible = true;
                    pictureBoxExport.Visible = true;
                    button2.Visible = true;
                    
                }
	        catch (Exception ex)
	        {
                btnSave.Visible = true;
                pictureBoxExport.Visible = true;
                button2.Visible = true;
	        }

        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            try
            {
                  PopBookingExport obj = new PopBookingExport();
                obj.StartPosition = FormStartPosition.CenterParent;
                obj.WindowState = FormWindowState.Normal;
                obj.MaximizeBox = false;
                obj.MinimizeBox = false;
                obj.A3 = true;
                obj.dtRoom = dtRoom.Tables[0].Copy();
                obj.BranchID = uBranch1.BranchId;
                obj.Text = String.Format("{0:dddd, MMMM d, yyyy} {1}", Convert.ToDateTime(AppointDate), uBranch1.BranchName); 
                obj.ShowDialog();


                if (obj.whereDate == "" || obj.WhereRoomID == "")
                {
                    //MessageBox.Show("Not found");
                    return;
                }
             
                string roomID = obj.WhereRoomID;
                string date = obj.startDate;
                List<string> lsroom = new List<string>();
                lsroom = obj.lsRoomNameNoCheck;
                DataSet dsExport = new Business.BookingRoom().GetBookingRoomExport(date, roomID, "BOOKINGROOM_A3", uBranch1.BranchId);
                DataTable dttemp = MergTable(dsExport);
                foreach (string item in lsroom)
                {
                    if(dttemp.Columns.Contains(item))
                    {
                        dttemp.Columns.Remove(item);
                    }
                }
                PopGridBooking pg = new PopGridBooking(dttemp);

                pg.title = String.Format("{0:dddd, MMMM d, yyyy} {1}", Convert.ToDateTime(date), uBranch1.BranchName);
                pg.Text = String.Format("{0:dddd, MMMM d, yyyy} {1}", Convert.ToDateTime(date), uBranch1.BranchName); 
                pg.ShowDialog();
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message);
               
            }
        }
        private DataTable MergTable(DataSet ds)
        {
            //DataTable dtx = new DataTable();
            DataTable dtok = ds.Tables[1].Copy();
            DataTable dtData = ds.Tables[0].Copy();
            List<string> lsroom = new List<string>();
            foreach (DataRow item in dtRoom.Tables[0].Rows)
	            {
                    lsroom.Add(item["RoomName"] + "");
	            }
            foreach (DataColumn c in ds.Tables[1].Columns)
            {
                if (!lsroom.Contains(c.ColumnName) && c.ColumnName.ToLower()!="time")
                    if(dtok.Columns.Contains(c.ColumnName))
                    dtok.Columns.Remove(c.ColumnName);
            }

            //for (int i = 1; i < dtok.Columns.Count; i++)
            //{
            //    if (!lsroom.Contains(dtok.Columns[i].ColumnName))
            //        dtok.Columns.Remove(dtok.Columns[i].ColumnName);
            //}
           
            try
            {
                bool ex = false;

                if (dtData.Rows.Count > 0)
                {
                    foreach (DataRow item in dtData.Rows)//ข้อมูล book
                    {
                        string EndDate = item["DateShowEnd"].ToString().Trim().ToLower();
                        foreach (DataRow drOK in dtok.Rows)//ตารางเวลา
                        {
                            string r = item["RoomName"].ToString();
                            
                            if (dtok.Columns.Contains(r))
                            {
                                string str = "";
                                if (!dtok.Columns.Contains(item["RoomName"].ToString())) continue;
                                string time = item[item["RoomName"].ToString()].ToString().Trim().ToLower();
                                string APDate = drOK["Time"].ToString().Trim().ToLower();

                                DateTime endD = DateTime.Parse(EndDate);
                                //string w3Time = "2009/02/26 18:37:58";
                                DateTime nowD = DateTime.Parse(APDate);
                                DateTime startD = DateTime.Parse(time);
                                //if (Dtime >= BookStarttime && Dtime < BookEndtime && BookEndtime)

                                TimeSpan start = new TimeSpan(startD.Hour, startD.Minute, 0); //10 o'clock
                                TimeSpan end = new TimeSpan(endD.Hour, endD.Minute, 0); //12 o'clock
                                TimeSpan now = new TimeSpan(nowD.Hour, nowD.Minute, 0);
                                if ((now >= start) && (now <= end))
                                {
                                    //match found
                                    str = "";
                                    if (item["CustID"].ToString() != "")
                                        str = str + Environment.NewLine + item["CustID"].ToString();
                                    if (item["CustName"].ToString() != "")
                                        str = str + Environment.NewLine + item["CustName"].ToString();
                                    if (item["Treadment"].ToString() != "")
                                        str = str + Environment.NewLine + item["Treadment"].ToString();
                                    if (item["Mobile"].ToString() != "")
                                        str = str + Environment.NewLine + item["Mobile"].ToString();
                                    if (item["DrName"].ToString() != "")
                                        str = str + Environment.NewLine + item["DrName"].ToString();
                                    if (item["Note"].ToString() != "")
                                        str = str + Environment.NewLine + "Note:" + item["Note"].ToString();


                                    //if(drOK[r].ToString().Length>10 )
                                    //    drOK[r] = drOK[r].ToString() + Environment.NewLine+str;
                                    //else drOK[r] = str;
                                    if (str == "")
                                    {
                                        //str = "." + Environment.NewLine + "." + Environment.NewLine;
                                        drOK[r] = "";
                                    }
                                    else
                                    drOK[r] = str;
                                   
                                    // str = item["CustID"].ToString() + Environment.NewLine + item["CustName"].ToString() + Environment.NewLine + item["Treadment"].ToString() + Environment.NewLine + item["Mobile"].ToString() + Environment.NewLine + item["DrName"].ToString() + Environment.NewLine + "Note:" + item["Note"].ToString();
                                }
                                else
                                {
                                    if (drOK[r].ToString() == "")
                                    {
                                        //str = "." + Environment.NewLine + "." + Environment.NewLine;
                                        drOK[r] = "";
                                    }
                                }

                               
                            }
                         }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
              
            }
            return dtok ;
        }

        private void uBranch1_SelectedChanged(object sender, EventArgs e)
        {
            try
            {
                //if (radioButtonDoctor.Checked == false) return;
                //Save(false);
                //Roomnames = null;
                //RoomTyp = "DOCTOR";
                SelectRoom(AppointDate, RoomTyp);
                LoadAppointment(AppointDate, RoomTyp);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void calendar1_ItemsPositioned(object sender, EventArgs e)
        {

           
        }

        private void calendar1_ItemSelected(object sender, CalendarItemEventArgs e)
        {
            try
            {
                List<CalendarItem> items = new List<CalendarItem>();
                foreach (CalendarItem item in calendar1.GetSelectedItems())
                {

                    //if (CheckPermission(item.ENSave) == false)
                        if (!(Userinfo.IsAdmin ?? "" ).Contains(Userinfo.EN) && Userinfo.EN != ENSave && !Userinfo.IS_ADMIN_BOOKING.Contains(Userinfo.EN))
                        {
                            //DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeInformation, "Is not Admin or Owner");
                            //calendar1.Invalidate();

                            //calendar1.ClearSelectedItems();

                            calendar1.AllowItemEdit = false;


                        }
                        else calendar1.AllowItemEdit = true; 
                    //item = item;
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

       
       

       
    }
}