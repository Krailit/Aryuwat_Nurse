using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AryuwatSystem.Forms
{
    public partial class PopBookingExport : Form
    {
        public DataTable dtRoom;
        public Dictionary<string, string> DicRoom;
        public List<string> lsRoomTypeCheck = new List<string>();
        public List<string> lsRoomNameNoCheck = new List<string>();
        public string BranchID="";
        public string WhereRoomID { get; set; }
        public string startDate { get; set; }
        //public DateTime endDate { get; set; }
        public bool A3 { get; set; }
        public string whereDate { get; set; }
        string Cmndate = "AppointDate";// "DateShowStart";
        public PopBookingExport()
        {
            InitializeComponent();
       
        }

        private void pictureBoxExport_Click(object sender, EventArgs e)
        {
           
        }

     
        private void PopBookingExport_Load(object sender, EventArgs e)
        {
            try
            {
                DicRoom = new Dictionary<string, string>();

                DataView view = new DataView(dtRoom);
                DataTable distinctValues = view.ToTable(true, new[] { "RoomTyp" });//distinct All column  checkDup
                foreach (DataRow dr in dtRoom.Rows)
                {
                    if (!DicRoom.ContainsKey(dr["RoomName"] + ""))
                    DicRoom.Add(dr["RoomName"] + "", dr["RoomTyp"] + "");
                }
            
                foreach (DataRow dr in distinctValues.Rows)
                {
                    //DicRoom.Add(dr["RoomType"] + "", dr["RoomType"] + "");
                    checkedListBoxRoomType.Items.Add(dr["RoomTyp"] + "", true);
                   
                }
                if (A3)
                {
                    dtpDateStart.Visible = false;
                    labelDateStart.Visible= false;
                    labelDateEnd.Text = "วันที่ ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            whereDate = "";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpDateStart.Checked)
                {
                    whereDate = Cmndate + " >='" + dtpDateStart.Value.ToString("yyyy-MM-dd 00:00:00") + "'";
                    //mydate between ('3/01/2013 12:00:00') and ('3/30/2013 12:00:00')
                }
                if (dtpDateEnd.Checked)
                {
                    whereDate = Cmndate + " <='" + dtpDateStart.Value.ToString("yyyy-MM-dd 23:59:59") + "'";
                    //mydate between ('3/01/2013 12:00:00') and ('3/30/2013 12:00:00')
                }
                if (dtpDateStart.Checked && dtpDateEnd.Checked)
                {
                    whereDate = Cmndate + " between ('" + dtpDateStart.Value.ToString("yyyy-MM-dd 00:00:00") + "') and ('" + dtpDateEnd.Value.ToString("yyyy-MM-dd 23:59:59") + "')";
                    startDate = dtpDateEnd.Value.ToString("yyyy/MM/dd");
                }
                if (!dtpDateStart.Checked && !dtpDateEnd.Checked)
                {
                    whereDate = " 1=1 ";
                }

                string room = "";
                foreach (string itemChecked in checkedListBoxRoomType.CheckedItems)
                {
                    room += "'" + itemChecked + "',";
                    lsRoomTypeCheck.Add(itemChecked + "");
                    
                }
                
                if (room.Length > 0)
                {
                    room = room.Substring(0, room.Length - 1);
                    WhereRoomID = string.Format("({0})", room);
                }
                else
                {
                    WhereRoomID = "";
                }

                foreach (KeyValuePair<string, string> entry in DicRoom)
                {
                    if (!lsRoomTypeCheck.Contains(entry.Value))
                        lsRoomNameNoCheck.Add(entry.Key);
                }
                //foreach
                //if (DicRoom.ContainsKey(itemChecked + "")) DicRoom.Remove(itemChecked + "");


                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBoxAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < checkedListBoxRoomType.Items.Count; i++)
                {
                    checkedListBoxRoomType.SetItemChecked(i, checkBoxAll.Checked);
                }
            }
            catch (Exception)
            {


            }
        }
    }
}
