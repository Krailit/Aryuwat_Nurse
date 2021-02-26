namespace AryuwatSystem.UserControls
{
    partial class ButtonNoti
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
            this.picButtonNoti = new System.Windows.Forms.PictureBox();
            this.labelCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picButtonNoti)).BeginInit();
            this.SuspendLayout();
            // 
            // picButtonNoti
            // 
            this.picButtonNoti.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picButtonNoti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picButtonNoti.Image = global::AryuwatSystem.Properties.Resources.notification;
            this.picButtonNoti.Location = new System.Drawing.Point(0, 0);
            this.picButtonNoti.Name = "picButtonNoti";
            this.picButtonNoti.Size = new System.Drawing.Size(34, 35);
            this.picButtonNoti.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picButtonNoti.TabIndex = 0;
            this.picButtonNoti.TabStop = false;
            this.picButtonNoti.Click += new System.EventHandler(this.picButtonAdd_Click);
            this.picButtonNoti.MouseLeave += new System.EventHandler(this.picButtonAdd_MouseLeave);
            this.picButtonNoti.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picButtonAdd_MouseMove);
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.BackColor = System.Drawing.Color.Red;
            this.labelCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelCount.ForeColor = System.Drawing.Color.White;
            this.labelCount.Location = new System.Drawing.Point(14, 1);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(16, 16);
            this.labelCount.TabIndex = 1;
            this.labelCount.Text = "1";
            // 
            // ButtonNoti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.picButtonNoti);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "ButtonNoti";
            this.Size = new System.Drawing.Size(34, 35);
            this.Load += new System.EventHandler(this.ButtonNoti_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picButtonNoti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox picButtonNoti;
        private System.Windows.Forms.Label labelCount;

    }
}
