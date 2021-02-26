using System.Windows.Forms;

namespace AryuwatSystem.UserControls
{
    public partial class ButtonFind : UserControl
    {
        public ButtonFind()
        {
            InitializeComponent();
        }
        public delegate void ButtonClick();
        public event ButtonClick BtnClick;
        public delegate void ButtonKeyDown(object sender, KeyEventArgs e);
        public event ButtonKeyDown BtnKeyDown;
        private void picTmp_MouseLeave(object sender, System.EventArgs e)
        {
            picTmp.Image = global::AryuwatSystem.Properties.Resources.Search64;
        }

        private void picTmp_MouseMove(object sender, MouseEventArgs e)
        {
            picTmp.Image = global::AryuwatSystem.Properties.Resources.Search64Over;
            
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
    }
}
