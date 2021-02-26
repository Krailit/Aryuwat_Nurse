using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace AryuwatSystem.DerClass
{
    public class ItemInfo
    {
        public string RoomID;
        public string BookID;
        public string Title;
        public string Detail;
        public DateTime AppointDateTime;
        public DateTime DateShowStart;
        public DateTime DateShowEnd;
        public string Duration;
        public int A;
        public int R;
        public int G;
        public int B;
        public string ENSave;
        public virtual string Note { get; set; }
        public string whereDate;
        public string CustName
        {
            get;
            set;
        }
        public string CustID
        {
            get;
            set;
        }
        public string CN
        {
            get;
            set;
        }
        public string DrName
        {
            get;
            set;
        }
        public string DrID
        {
            get;
            set;
        }
        public string Treadment
        {
            get;
            set;
        }
        public string Mobile
        {
            get;
            set;
        }
        public string Howmagazine
        {
            get;
            set;
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
            get;
            set;
        }
        public string HowTravel
        {
            get;
            set;
        }
        public string Howother
        {
            get;
            set;
        }
        public string HowotherText
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
        public string DateSave
        {
            get;
            set;
        }
        public int DrBookID
        {
            get;
            set;
        }
        
        public string ENDoctor
        {
            get;
            set;
        }
        HatchStyle pattern;
        Color patternColor;
        public ItemInfo()
        { }

        public ItemInfo(string _RoomID, DateTime _AppointDateTime, DateTime _DateShowStart, DateTime _DateShowEnd, string _Duration, int _A, int _R, int _G, int _B, string _ENSave
            ,string _CustName,string _CustID,string _Treadment,string _Mobile,string _DrName,string _DrID,string _Howmagazine,string _Howinternet,string _Howfriend
            , string _Hownewpaper, string _HowTravel, string _Howother, string _HowotherText, string _Note, string _BranchID, string _BranchName, string _DateSave, int _DrBookID,string _BookID)
        {
            RoomID = _RoomID;

            Note = _Note;
            AppointDateTime = _AppointDateTime;
            DateShowStart=_DateShowStart;
            DateShowEnd = _DateShowEnd;
            Duration = _Duration;
            A = _A;
            R = _R;
            G = _G;
            B = _B;
            ENSave = _ENSave;

            CustName = _CustName;
            CustID = _CustID;
            Treadment = _Treadment;
            Mobile = _Mobile;
            DrName = _DrName;
            DrID = _DrID;
            Howmagazine = _Howmagazine;
            Howinternet = _Howinternet;
            Howfriend = _Howfriend;
            Hownewpaper = _Hownewpaper;
            HowTravel = _HowTravel;
            Howother = _Howother;
            HowotherText = _HowotherText;
            BranchID = _BranchID;
            BranchName = _BranchName;
            DateSave = _DateSave;
            DrBookID = _DrBookID;
            BookID = _BookID;
        }
        public ItemInfo(string _RoomID, DateTime _AppointDateTime, DateTime _DateShowStart, DateTime _DateShowEnd, string _Duration, int _A, int _R, int _G, int _B, string _ENSave
          , string _DrName, string _DrID, string _Note, string _BranchID, string _BranchName, string _DateSave)
        {
            RoomID = _RoomID;

            Note = _Note;
            AppointDateTime = _AppointDateTime;
            DateShowStart = _DateShowStart;
            DateShowEnd = _DateShowEnd;
            Duration = _Duration;
            A = _A;
            R = _R;
            G = _G;
            B = _B;
            ENSave = _ENSave;
            DrName = _DrName;
            DrID = _DrID;
            BranchID = _BranchID;
            BranchName = _BranchName;
            DateSave = _DateSave;
        }

    }
}
