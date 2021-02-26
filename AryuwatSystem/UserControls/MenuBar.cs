using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace AryuwatSystem.UserControls
{
    public partial class MenuBar : UserControl
    {
        public MenuBar()
        {
            InitializeComponent();
        }
        public delegate void ToolMouseDown(object sender, MouseEventArgs e);
        public event ToolMouseDown T_MouseDown;
        private void MenuBar_Load(object sender, EventArgs e)
        {
            //plControlBox.BackColor = Color.FromArgb(53, 177, 170);
            //menuStriptSystem.BackColor = Color.FromArgb(53, 177, 170);
           
        }

        //private void btnMinimizeBox_MouseHover(object sender, EventArgs e)
        //{
        //    btnMinimizeBox.BackColor = Color.FromArgb(192, 192, 192);
        //}

        //private void btnMaximizeBox_MouseHover(object sender, EventArgs e)
        //{
        //    btnMaximizeBox.BackColor = Color.FromArgb(192, 192, 192);;
        //}

        //private void btnClose_MouseHover(object sender, EventArgs e)
        //{
        //    btnMaximizeBox.BackColor =  Color.FromArgb(192, 192, 192);
        //}

        private void cmdMinimize_MouseMove(object sender, MouseEventArgs e)
        {
            cmdMinimize.Image = global::AryuwatSystem.Properties.Resources.Minimumsize_Drak;
        }

        //private void cmdMaximize_MouseMove(object sender, MouseEventArgs e)
        //{
        //    //if (this.WindowState == FormWindowState.Maximized)
        //    //{
        //    //    cmdMaximize.Image = global::AryuwatSystem.Properties.Resources.NormalStat_Drak ;
        //    //}
        //    //else
        //    //{
        //    //    cmdMaximize.Image = global::AryuwatSystem.Properties.Resources.Minimizebox_Drak;
        //    //}
        //}

        private void cmdClose_MouseMove(object sender, MouseEventArgs e)
        {
            cmdClose.Image = global::AryuwatSystem.Properties.Resources.Maximizebox_Drak;
        }

        private void cmdMinimize_MouseLeave(object sender, EventArgs e)
        {
            cmdMinimize.Image = global::AryuwatSystem.Properties.Resources.Minimumsize;
        }

        //private void cmdMaximize_MouseLeave(object sender, EventArgs e)
        //{
        //    //if (this.WindowState == FormWindowState.Maximized)
        //    //{
        //    //   cmdMaximize.Image = global::AryuwatSystem.Properties.Resources.NormalStat;
        //    //}
        //    //else
        //    //{ cmdMaximize.Image = global::AryuwatSystem.Properties.Resources.Minimizebox;
                
        //    //}
        //}

        private void cmdClose_MouseLeave(object sender, EventArgs e)
        {
            cmdClose.Image = global::AryuwatSystem.Properties.Resources.Maximizebox;
        }

        private void menuStriptSystem_MouseDown(object sender, MouseEventArgs e)
        {
            if (T_MouseDown != null)
            {
                T_MouseDown(sender,e);
            }
        }
    }
    
}