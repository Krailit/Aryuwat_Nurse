namespace AryuwatSystem.UserControls
{
    partial class ButtonRefresh
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picTmp = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picTmp)).BeginInit();
            this.SuspendLayout();
            // 
            // picTmp
            // 
            this.picTmp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picTmp.Image = global::AryuwatSystem.Properties.Resources.filenew;
            this.picTmp.Location = new System.Drawing.Point(0, 0);
            this.picTmp.Name = "picTmp";
            this.picTmp.Size = new System.Drawing.Size(51, 49);
            this.picTmp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTmp.TabIndex = 2;
            this.picTmp.TabStop = false;
            this.picTmp.Click += new System.EventHandler(this.picTmp_Click);
            this.picTmp.MouseLeave += new System.EventHandler(this.picTmp_MouseLeave);
            this.picTmp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picTmp_MouseMove);
            // 
            // ButtonRefresh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.picTmp);
            this.Name = "ButtonRefresh";
            this.Size = new System.Drawing.Size(64, 64);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ButtonRefresh_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picTmp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.PictureBox picTmp;
    }
}
