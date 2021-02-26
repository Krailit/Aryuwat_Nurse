using System;
using System.Windows.Forms;

namespace AryuwatSystem.UserControls
{
    public partial class ButtonDelete2 : UserControl
    {
        public ButtonDelete2()
        {
            InitializeComponent();
        }
        public delegate void ButtonClick();
        public event ButtonClick BtnClick;

        private void picButtonAdd_MouseLeave(object sender, EventArgs e)
        {
            picButtonDelete2.Image = global::AryuwatSystem.Properties.Resources.delete_big1;
        }

        private void picButtonAdd_MouseMove(object sender, MouseEventArgs e)
        {
            picButtonDelete2.Image = global::AryuwatSystem.Properties.Resources.delete_big1;
          
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
