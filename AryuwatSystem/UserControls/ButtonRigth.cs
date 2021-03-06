﻿using System;
using System.Windows.Forms;

namespace AryuwatSystem.UserControls
{
    public partial class ButtonRigth : UserControl
    {
        public ButtonRigth()
        {
            InitializeComponent();
        }
        public delegate void ButtonClick();
        public event ButtonClick BtnClick;
        private void picTmp_MouseLeave(object sender, EventArgs e)
        {
            picTmp.Image = global::AryuwatSystem.Properties.Resources.add_icon;
        }

        private void picTmp_MouseMove(object sender, MouseEventArgs e)
        {
            picTmp.Image = global::AryuwatSystem.Properties.Resources.add_iconB;
        }

        private void picTmp_Click(object sender, EventArgs e)
        {
            if (BtnClick != null)
            {
                BtnClick();
            }
        }
    }
}
