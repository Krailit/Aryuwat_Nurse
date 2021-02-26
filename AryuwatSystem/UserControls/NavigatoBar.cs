using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace AryuwatSystem.UserControls
{
    public partial class NavigatoBar : UserControl
    {
        public NavigatoBar()
        {
            InitializeComponent();
        }


        private const int mcIntWidth = 2490;
        private const int mcIntHeight = 330;

        private  long mLngCurrentPage;
        private long mLngTotalPage;
        private long mLngTotalRecord;

        private bool mBlnCanMoveFirst;
        private bool mBlnCanMovePrevious;
        private bool mBlnCanMoveNext;
        private bool mBlnCanMoveLast;
        private bool mBlnEnabled;

        public event MoveFirstEventHandler MoveFirst;
        public delegate void MoveFirstEventHandler();
        public event MovePreviousEventHandler MovePrevious;
        public delegate void MovePreviousEventHandler();
        public event MoveNextEventHandler MoveNext;
        public delegate void MoveNextEventHandler();
        public event MoveLastEventHandler MoveLast;
        public delegate void MoveLastEventHandler();


        public object Enableds
        {
            get { return mBlnEnabled; }
            set 
            {
                mBlnEnabled = Convert.ToBoolean( value);
                if (mLngTotalPage == 0 & mLngCurrentPage == 0)
                {
                    cmdFirst.Enabled = Convert.ToBoolean(value);
                    cmdPrevious.Enabled = Convert.ToBoolean(value);
                    cmdNext.Enabled = Convert.ToBoolean(value);
                    cmdLast.Enabled = Convert.ToBoolean(value);
                }
            }
        }


        public  object CanMoveFirst
        {
            get { return mBlnCanMoveFirst; }
            set 
            {
                mBlnCanMoveFirst = Convert.ToBoolean(value);
                cmdFirst.Enabled = Convert.ToBoolean(value);
                SetButton();
            }
        }
        public object CanMovePrevious
        {
            get { return mBlnCanMovePrevious; }
            set
            {
                mBlnCanMovePrevious = Convert.ToBoolean(value);
                SetButton();
            }
        }
        public object CanMoveNext
        {
            get { return mBlnCanMoveNext; }
            set
            {
                mBlnCanMoveNext = Convert.ToBoolean(value);
                SetButton();
            }
        }

        public object CanMoveLast
        {
            get { return mBlnCanMoveLast; }
            set
            {
                mBlnCanMoveLast = Convert.ToBoolean(value);
                SetButton();
            }
        }

        public object CurrentPage
        {
            get { return mLngCurrentPage; }
            set
            {
                if (Convert.ToInt32(value) < 0)
                {
                    value = 0;
                }
                mLngCurrentPage = Convert.ToInt32(value); 
            }
        }



        public object TotalPage
        {
            get { return mLngTotalPage; }
            set
            {
                if (Convert.ToInt32(value) < 0)
                {
                   value = 0;
                }
                mLngTotalPage = Convert.ToInt32(value);
            }
        }
        public object TotalRecord
        {
            get { return mLngTotalRecord; }
            set
            {
                if (Convert.ToInt32(value) < 0)
                {
                   value = 0;
                }
                mLngTotalRecord = Convert.ToInt32(value);
            }
        }
        


        public void Updates()
        {
            SetButton();
            SetPage();
        }




        public void CallMoveFirst()
        {
            if (MoveFirst != null)
            {
                MoveFirst();
            }
        }

        public void CallMoveLast()
        {
            if (MoveLast != null)
            {
                MoveLast();
            }
        }

        public void CallMoveNext()
        {
            if (MoveNext != null)
            {
                MoveNext();
            }
        }

        public void CallMovePrevious()
        {
            if (MovePrevious != null)
            {
                MovePrevious();
            }
        }


        private void SetButton()
        {

            cmdFirst.Enabled = false;
            cmdPrevious.Enabled = false;
            cmdNext.Enabled = false;
            cmdLast.Enabled = false;
            //if ((CanMoveFirst ) && (mLngCurrentPage > 1))
            //{ 
            //}

            if ((bool)CanMoveFirst && (mLngCurrentPage > 1))
            {
                cmdFirst.Enabled = true;
            }

            if ((bool)CanMovePrevious && (mLngCurrentPage > 1))
            {
                cmdPrevious.Enabled = true;
            }

            if ((bool)CanMoveNext && (mLngCurrentPage < mLngTotalPage))
            {
                cmdNext.Enabled = true;
            }

            if ((bool)CanMoveLast && (mLngCurrentPage < mLngTotalPage))
            {
                cmdLast.Enabled = true;
            }


        }
        private void SetPage()
        {
            lblTxtRecord.Text = Convert.ToString(mLngCurrentPage) + "/" + Convert.ToString(mLngTotalPage) + " จำนวนข้อมูลทั้งหมด : " + Convert.ToString(mLngTotalRecord) + " Record";
        }


        private void UserControl1_Load(object sender, EventArgs e)
        {
            mLngTotalPage = 0;
            mLngCurrentPage = 0;
            mLngTotalRecord = 0;
            mBlnCanMoveFirst = true;
            mBlnCanMovePrevious = true;
            mBlnCanMoveNext = true;
            mBlnCanMoveLast = true;
            lblTxtRecord.Font = new Font("tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point, 222);
        }


        //** Event
        private void cmdFirst_Click(object sender, EventArgs e)
        {
            if (MoveFirst != null)
            {
                MoveFirst();
            }
        }

        private void cmdPrevious_Click(object sender, EventArgs e)
        {
            if (MovePrevious != null)
            {
                MovePrevious();
            }
        }

        private void cmdNext_Click(object sender, EventArgs e)
        {
            if (MoveNext != null)
            {
                MoveNext();
            }
        }

        private void cmdLast_Click(object sender, EventArgs e)
        {
            if (MoveLast != null)
            {
                MoveLast();
            }
        }


    }
}
