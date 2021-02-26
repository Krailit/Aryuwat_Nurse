using System;
using System.Windows.Forms;

namespace AryuwatSystem.UserControls
{
    public partial class ButtonGenBar : UserControl
    {
        public ButtonGenBar()
        {
            InitializeComponent();
        }
        public delegate void ButtonClick();
        public event ButtonClick BtnClick;
        public delegate void ButtonKeyDown(object sender, KeyEventArgs e);
        public event ButtonKeyDown BtnKeyDown;
        private void picTmp_MouseLeave(object sender, EventArgs e)
        {
            //picTmp.Image = global::AryuwatSystem.Properties.Resources.document_add_256;
        }

        private void picTmp_MouseMove(object sender, MouseEventArgs e)
        {
           // picTmp.Image = global::AryuwatSystem.Properties.Resources.document_add_256;
           
        }

        private void picTmp_Click(object sender, EventArgs e)
        {
            if (BtnClick != null)
            {
                BtnClick();
            }

        }

        private void ButtonRefresh_KeyDown(object sender, KeyEventArgs e)
        {
            if (BtnKeyDown != null)
            {
                BtnKeyDown(sender, e);
            }
        }
    }
}
