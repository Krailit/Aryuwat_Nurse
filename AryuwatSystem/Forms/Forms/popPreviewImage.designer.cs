namespace DermasterSystem.Forms
{
    partial class popPreviewImage
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tmrDissolve = new System.Windows.Forms.Timer(this.components);
            this.picImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrDissolve
            // 
            this.tmrDissolve.Interval = 1000;
            this.tmrDissolve.Tick += new System.EventHandler(this.tmrDissolve_Tick);
            // 
            // picImage
            // 
            this.picImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picImage.ErrorImage = null;
            this.picImage.Location = new System.Drawing.Point(0, 0);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(444, 419);
            this.picImage.TabIndex = 1;
            this.picImage.TabStop = false;
            this.picImage.DoubleClick += new System.EventHandler(this.picImage_DoubleClick);
            this.picImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.popPreviewImage_MouseMove);
            // 
            // popPreviewImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ClientSize = new System.Drawing.Size(444, 419);
            this.Controls.Add(this.picImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "popPreviewImage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "· ¥ß¿“æ¢π“¥„À≠Ë";
            this.Load += new System.EventHandler(this.popPreviewImage_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.popPreviewImage_KeyUp);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.popPreviewImage_MouseMove);
            this.Move += new System.EventHandler(this.popPreviewImage_Move);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrDissolve;
        private System.Windows.Forms.PictureBox picImage;
    }
}