using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Calendar.NET;
using Entity;

namespace AryuwatSystem.Forms
{
    public partial class frmAutoBookDoctor : Form
    {
        public string BranchId;
        public string BranchName;
        public string monthName;
        
        
        public int year;
        public int month;
        public bool AutoBook = false;
        private CustomEvent NewEvent;
       public Dictionary<string,CustomEvent>dicRoom=new Dictionary<string,CustomEvent>();
        public frmAutoBookDoctor()
        {
            InitializeComponent();
            this.Width = Screen.PrimaryScreen.Bounds.Width;
        }

        private void frmAutoBookDoctor_Load(object sender, EventArgs e)
        {
            this.Text = BranchName+" : "+monthName;
            //toolTip1.AutomaticDelay = 5000;
            //toolTip1.AutoPopDelay = 3000;
            //toolTip1.ReshowDelay = 500;
            toolTip1.UseFading = true;
            toolTip1.UseAnimation = true;
            //toolTip1.IsBalloon = true;
            

            dataGridView1.ShowCellToolTips = false; 
            dataGridView1.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            setRoom();
        }
        private void setRoom()
        {
            try
            {
                DataSet dsroom = new Business.BookingRoom().SELECTROOMDOCTOR(DateTime.Now, "", "");
                dicRoom = new Dictionary<string, CustomEvent>();
                if(dataGridView1.Rows.Count>0)
                dataGridView1.Rows.Clear();
                //int daynum = DateTime.DaysInMonth(year, month);

                int timeAdd = 1;
                foreach (DataRow item in dsroom.Tables[0].Rows)
                {
                    //for (int i = 1; i <= daynum; i++)
                    foreach (DataGridViewColumn c in dataGridView1.Columns)
                    {//AES1 AES2 ANT1 HTP1 PLS1 CRP1
                        string textShow = item["RoomName"] + ":";
                        string DicKey = string.Format("{0}:{1}", c.Name, item["RoomName"] + "");//column name:RoomName
                        var ce2 = new CustomEvent
                        {
                            IgnoreTimeComponent = false,
                            EventText = textShow,
                            RoomID = item["RoomID"] + "",
                            RoomName = item["RoomName"] + "",
                            Date = new DateTime(year, month,DateTime.Now.Day, timeAdd, 0, 0),
                            //EventLengthInHours = 2f,
                            //RecurringFrequency = RecurringFrequencies.None,
                            EventFont = new Font("Verdana", 8, FontStyle.Regular),
                            Enabled = true,
                            //EventColor = Color.FromArgb(255, 204, 255),
                            EventColor = Color.FromArgb(255, 255, 255),
                            EventTextColor = Color.Black,
                            //ThisDayForwardOnly = true
                            AddDate = Convert.ToInt16(item["AddDate"] + ""),
                            BranchID = BranchId,
                            ENSave = Userinfo.EN,
                            DicKey = DicKey,
                            DayFullName=c.Name,
                        };
                        dicRoom.Add(DicKey,ce2);
                      
                    }
                    timeAdd++;
                    string[] row = new string[] { item["RoomName"] + "", item["RoomName"] + "", item["RoomName"] + "", item["RoomName"] + "", item["RoomName"] + "", item["RoomName"] + "", item["RoomName"] + "" };
                    dataGridView1.Rows.Add(row);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

                string roomname = (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value + "").Split(':')[0];
                string DicKey = string.Format("{0}:{1}", dataGridView1.Columns[e.ColumnIndex].Name, roomname);//column name:RoomName
                string DayFullName = dataGridView1.Columns[e.ColumnIndex].Name;
                if (dicRoom.ContainsKey(DicKey))
                {
                    //MessageBox.Show(dicRoom[DicKey].DicKey);

                    PopBookingDoctorAdd pop = new PopBookingDoctorAdd();
                    pop.editEvent = (CustomEvent)dicRoom[DicKey].Clone();
                    pop.Text = DicKey;
                    pop.AutoBook = true;

                    if (pop.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    if (pop.ISDelete)//ถ้าลบ  set null 
                    {
                        dicRoom[DicKey].DrID = "";
                        dicRoom[DicKey].DrName = "";
                        dicRoom[DicKey].CustName = "";
                        dicRoom[DicKey].EventText = dicRoom[DicKey].RoomName;
                        DateTime dateIn = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 10, 0, 0);
                        DateTime dateOut = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 0, 0);
                        dicRoom[DicKey].TimeStart = dateIn;
                        dicRoom[DicKey].TimeEnd = dateOut;
                        dicRoom[DicKey].Note = "";
                        dicRoom[DicKey].DayFullName = "";
                        return;
                    }
                    //If Save
                    //==============จะ ได้ DicRoom ทั้งหมด 35 อัน ทุกห้องแยกตามวัน เพื่อที่จะเอาไป Loop Add calendar
                    //NewEvent = pop.editEvent;
                    dicRoom[DicKey].EventText = pop.editEvent.RoomName + ":" + pop.editEvent.DrName;// +" " + pop.editEvent.TimeStart.ToShortTimeString() + "-" + pop.editEvent.TimeEnd.ToShortTimeString();
                    dicRoom[DicKey].RoomID = pop.editEvent.RoomID;
                    dicRoom[DicKey].RoomName = pop.editEvent.RoomName;
                    dicRoom[DicKey].DrID = pop.editEvent.DrID;
                    dicRoom[DicKey].DrName = pop.editEvent.DrName;
                    dicRoom[DicKey].TimeStart = pop.editEvent.TimeStart;
                    dicRoom[DicKey].TimeEnd = pop.editEvent.TimeEnd;
                    dicRoom[DicKey].Note = pop.editEvent.Note;
                    dicRoom[DicKey].BranchID = pop.editEvent.BranchID;
                    dicRoom[DicKey].ID = pop.editEvent.ID;
                    dicRoom[DicKey].IDBookLink = pop.editEvent.IDBookLink;
                    dicRoom[DicKey].CustName = pop.editEvent.CustName;
                    dicRoom[DicKey].DayFullName = DayFullName;
                    

                    //=============Set grid value====================
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = pop.editEvent.RoomName+":"+pop.editEvent.CustName;//column name:RoomName

                    //=============Set grid value====================

                    //calendar1.AddEvent(NewEvent);
                    //MessageBox.Show(CurrentclickedEvent.EventText);
                    //pop.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
             string alert = string.Format("บันทึกรายการของเดือน {0}{1}{2} ใหม่ทั้งหมด", monthName,Environment.NewLine,BranchName);
                //if (DerUtility.PopMsg(DerUtility.EnuMsgType.MsgTypeError, alert) == DialogResult.Yes)
                popAlert pa=new popAlert();
                pa.txtShow=alert;
                pa.txtTitle="คำเตือน";

                pa.ShowDialog();
                if (pa.DialogResult == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    //this.DialogResult = DialogResult.No;
                }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }


     

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            toolTip1.SetToolTip(dataGridView1, dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString());
            dataGridView1[e.ColumnIndex, e.RowIndex].Selected = true;
        }

        private void btnLoadP_Click(object sender, EventArgs e)
        {
            try
            {
                setRoom();
                LoadProfile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveP_Click(object sender, EventArgs e)
        {
            try
            {
                int x = new Business.BookingRoom().DelAutoBookingProfile(BranchId);

                foreach (KeyValuePair<string, CustomEvent> item in dicRoom)
                {
                    item.Value.AppointDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);//For booking Time 0:0:0
                    item.Value.TimeStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, item.Value.TimeStart.Hour, item.Value.TimeStart.Minute, 0);
                    item.Value.TimeEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, item.Value.TimeEnd.Hour, item.Value.TimeEnd.Minute, 0);
                    item.Value.DateShowStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, item.Value.TimeEnd.Hour, item.Value.TimeEnd.Minute, 0);
                    item.Value.DateShowEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, item.Value.TimeEnd.Hour, item.Value.TimeEnd.Minute, 0); 
                    int? intStatus = new Business.BookingRoom().SaveAutoBookingProfile(item.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadProfile()
        {
            try
            {
                DataSet prof = new Business.BookingRoom().LoadAutoBookingProfile(BranchId);


                int timeAdd = 1;
                foreach (DataRow item in prof.Tables[0].Rows)
                {
                    //if ((item["DrID"] + "").Length > 5)//เจอห้องที่ save
                    //{

                        foreach (DataGridViewRow row in dataGridView1.Rows)// loop ทุก row
                        {
                            foreach (DataGridViewColumn c in dataGridView1.Columns)//Loop ทุก column
                            {
                                
                                string roomname = (dataGridView1.Rows[row.Index].Cells[c.Index].Value + "").Split(':')[0];
                                if ((item["RoomName"] + "") == roomname && item["DayFullName"] + "" == c.Name)//ห้องตรง และ วันตรง
                                {
                                    string DicKey = string.Format("{0}:{1}", c.Name, item["RoomName"] + "");//column name:RoomName
                                    if (dicRoom.ContainsKey(DicKey))
                                    {
                                        //If Save
                                        //==============จะ ได้ DicRoom ทั้งหมด 35 อัน ทุกห้องแยกตามวัน เพื่อที่จะเอาไป Loop Add calendar
                                        dicRoom[DicKey].EventText = dicRoom[DicKey].RoomName + ":" + item["CustName"] + "";
                                        //dicRoom[DicKey].RoomID = pop.editEvent.RoomID;
                                        //dicRoom[DicKey].RoomName = pop.editEvent.RoomName;
                                        dicRoom[DicKey].DrID = item["DrID"] + "";
                                        dicRoom[DicKey].DrName = item["DrName"] + "";
                                        dicRoom[DicKey].TimeStart = Convert.ToDateTime(item["TimeStart"] + "");
                                        dicRoom[DicKey].TimeEnd = Convert.ToDateTime(item["TimeEnd"] + "");
                                        dicRoom[DicKey].Note = item["Note"] + "";
                                        //dicRoom[DicKey].BranchID = pop.editEvent.BranchID;
                                        //dicRoom[DicKey].ID = pop.editEvent.ID;
                                        //dicRoom[DicKey].IDBookLink = pop.editEvent.IDBookLink;
                                        dicRoom[DicKey].CustName = item["CustName"] + "";
                                        dicRoom[DicKey].DayFullName = item["DayFullName"] + "";


                                        //=============Set grid value====================
                                        dataGridView1.Rows[row.Index].Cells[c.Index].Value = dicRoom[DicKey].EventText;//column name:RoomName

                                    }

                                }
                            }
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    
        
    }
}
