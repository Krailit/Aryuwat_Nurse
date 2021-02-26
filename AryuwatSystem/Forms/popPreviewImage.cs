using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AryuwatSystem.Forms
{
    public partial class popPreviewImage : Form
    {
        private Image imgObject = null;
        private bool blnFadeOut = true;
        private int intCount = 0;

        public popPreviewImage(Image imgObject)
        {
            InitializeComponent();
            this.imgObject = imgObject;
        }
        public popPreviewImage(Image imgObject, bool blnFadeOut)
        {
            InitializeComponent();
            this.imgObject = imgObject;
            this.blnFadeOut = blnFadeOut;
        }

        public popPreviewImage(object objPictureBox)
        {
            InitializeComponent();
            this.imgObject = ((PictureBox)objPictureBox).Image;
        }

        public popPreviewImage(object objPictureBox, bool blnFadeOut)
        {
            InitializeComponent();
            this.imgObject = ((PictureBox)objPictureBox).Image;
            this.blnFadeOut = blnFadeOut;
        }
        public popPreviewImage(string PicturPath, bool blnFadeOut)
        {
            InitializeComponent();
            try
            {
              this.imgObject = new Bitmap(PicturPath);
                        this.blnFadeOut = blnFadeOut;
            }
            catch (Exception)
            {
        
            }
          
        }
        private void popPreviewImage_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }

        private void popPreviewImage_Load(object sender, EventArgs e)
        {
            picImage.Location = new Point(0, 0);
            picImage.Size = new Size(this.Width - 5, this.Height - 30);
            picImage.SizeMode = PictureBoxSizeMode.Zoom;

            if (imgObject == null)
                picImage.Image =null;
            else
                picImage.Image = imgObject;

            if (blnFadeOut)
                startTimer();
        }

        private void popPreviewImage_Move(object sender, EventArgs e)
        {
            resetCounter();
        }

        private void popPreviewImage_MouseMove(object sender, MouseEventArgs e)
        {
            resetCounter();
        }

        private void resetCounter()
        {
            this.Opacity = 1;
            intCount = 0;
        }

        private void startTimer()
        {
            tmrDissolve.Interval = 100;
            tmrDissolve.Enabled = true;
        }

        private void tmrDissolve_Tick(object sender, EventArgs e)
        {
            if (intCount >= 15)
            {
                this.Opacity = this.Opacity - 0.07;
                if (this.Opacity < 0.05)
                    this.Close();
            }
            intCount++;
        }

        private void picImage_DoubleClick(object sender, EventArgs e)
        {
            if (tmrDissolve.Enabled)
                tmrDissolve.Enabled = false;
            else
                tmrDissolve.Enabled = true;
        }
    }
}