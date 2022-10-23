using System.Windows.Forms;

namespace AryuwatSystem.UserControls
{
    public partial class ButtonSelectAgency : UserControl
    {
        public ButtonSelectAgency()
        {
            InitializeComponent();
        }
        public delegate void ButtonClick();
        public event ButtonClick BtnClick;

        //public delegate void Tootip();
        //public event Tootip BtnTooltip;
        public delegate void ButtonKeyDown(object sender, KeyEventArgs e);
        public event ButtonKeyDown BtnKeyDown;
        private void picTmp_MouseLeave(object sender, System.EventArgs e)
        {
            picTmp.Image = global::AryuwatSystem.Properties.Resources.Invite;
        }

        private void picTmp_MouseMove(object sender, MouseEventArgs e)
        {
            picTmp.Image = global::AryuwatSystem.Properties.Resources.InviteB;
            
        }

        private void picTmp_Click(object sender, System.EventArgs e)
        {
            if (BtnClick != null)
            {
                BtnClick();
            }
        }

        private void ButtonFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (BtnKeyDown != null)
            {
                BtnKeyDown(sender, e);
            }
        }

        private void picTmp_MouseHover(object sender, System.EventArgs e)
        {
            //if (BtnTooltip != null)
            //{
            //    BtnTooltip();
            //}
            toolTip1.SetToolTip(this.picTmp, "�����¡�÷�����͡");
        }
    }
}
