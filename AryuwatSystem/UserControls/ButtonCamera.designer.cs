namespace AryuwatSystem.UserControls
{
    partial class ButtonCamera
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
            this.picCamera = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).BeginInit();
            this.SuspendLayout();
            // 
            // picCamera
            // 
            this.picCamera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCamera.Image = global::AryuwatSystem.Properties.Resources.webcam_256_Black;
            this.picCamera.Location = new System.Drawing.Point(0, 0);
            this.picCamera.Name = "picCamera";
            this.picCamera.Size = new System.Drawing.Size(35, 37);
            this.picCamera.TabIndex = 0;
            this.picCamera.TabStop = false;
            this.picCamera.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.picCamera.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.picCamera.Click += new System.EventHandler(this.picCamera_Click);
            // 
            // ButtonCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.picCamera);
            this.Name = "ButtonCamera";
            this.Size = new System.Drawing.Size(35, 37);
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.PictureBox picCamera;

    }
}
