using System;
using System.Windows.Forms;

namespace AryuwatSystem.UserControls
{
    public partial class ButtonDelete : UserControl
    {
        public ButtonDelete()
        {
            InitializeComponent();
        }
        public delegate void ButtonClick();
        public event ButtonClick BtnClick;
        private void picButtonAdd_MouseLeave(object sender, EventArgs e)
        {
             picButtonAdd.Image = global::AryuwatSystem.Properties.Resources.remove_icon;
        }

        private void picButtonAdd_MouseMove(object sender, MouseEventArgs e)
        {
            picButtonAdd.Image = global::AryuwatSystem.Properties.Resources.remove_icon;
           
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
