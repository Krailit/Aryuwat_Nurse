using System;
using System.Windows.Forms;

namespace AryuwatSystem.UserControls
{
    public partial class ButtonCamera : UserControl
    {
        public ButtonCamera()
        {
            InitializeComponent();
        }
        public delegate void ButtonClick();
        public event ButtonClick BtnClick;
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            picCamera.Image = global::AryuwatSystem.Properties.Resources.webcam_256_Black;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            picCamera.Image = global::AryuwatSystem.Properties.Resources.webcam_256;
        }

        private void picCamera_Click(object sender, EventArgs e)
        {
            if (BtnClick != null)
            {
                BtnClick();
            }
        }
    }
}
