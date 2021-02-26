using System;
using System.Windows.Forms;
using System.Data;

namespace AryuwatSystem.UserControls
{
    public partial class ButtonNoti : UserControl
    {
        public int NotiCount { get; set; }
        public ButtonNoti()
        {
            InitializeComponent();
           
        }
        public delegate void ButtonClick();
        public event ButtonClick BtnClick;

        private void picButtonAdd_MouseLeave(object sender, EventArgs e)
        {
            //picButtonNoti.Image = global::AryuwatSystem.Properties.Resources.save;
        }

        private void picButtonAdd_MouseMove(object sender, MouseEventArgs e)
        {
            //picButtonNoti.Image = global::AryuwatSystem.Properties.Resources.save;
          
        }

        private void picButtonAdd_Click(object sender, EventArgs e)
        {
            if (BtnClick != null)
            {
                BtnClick();
            }
        }

        private void ButtonNoti_Load(object sender, EventArgs e)
        {
            //DataTable dt = new Business.Personnel().getNoti();
            //if (NotiCount <= 0) this.Visible = false;
        }
    }
}
