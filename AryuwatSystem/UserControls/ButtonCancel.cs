using System;
using System.Windows.Forms;

namespace AryuwatSystem.UserControls
{
    public partial class ButtonCancel : UserControl
    {
        public ButtonCancel()
        {
            InitializeComponent();
        }
        public delegate void ButtonClick();
        public event ButtonClick BtnClick;

        private void picButtonAdd_MouseLeave(object sender, EventArgs e)
        {
             picButtonSave.Image = global::AryuwatSystem.Properties.Resources.cancelIcon;
        }

        private void picButtonAdd_MouseMove(object sender, MouseEventArgs e)
        {
            picButtonSave.Image = global::AryuwatSystem.Properties.Resources.cancelIcon;
          
        }

        private void picButtonAdd_Click(object sender, EventArgs e)
        {
            if (BtnClick != null)
            {
                BtnClick();
            }
        }
    }
}
