namespace AryuwatSystem.UserControls
{
    partial class ButtonSelectAgency
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
            this.components = new System.ComponentModel.Container();
            this.picTmp = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picTmp)).BeginInit();
            this.SuspendLayout();
            // 
            // picTmp
            // 
            this.picTmp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picTmp.Image = global::AryuwatSystem.Properties.Resources.Invite;
            this.picTmp.Location = new System.Drawing.Point(0, 0);
            this.picTmp.Name = "picTmp";
            this.picTmp.Size = new System.Drawing.Size(35, 33);
            this.picTmp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTmp.TabIndex = 0;
            this.picTmp.TabStop = false;
            this.toolTip1.SetToolTip(this.picTmp, "ผู้แนะนำ");
            this.picTmp.Click += new System.EventHandler(this.picTmp_Click);
            this.picTmp.MouseLeave += new System.EventHandler(this.picTmp_MouseLeave);
            this.picTmp.MouseHover += new System.EventHandler(this.picTmp_MouseHover);
            this.picTmp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picTmp_MouseMove);
            // 
            // ButtonSelectAgency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.picTmp);
            this.Name = "ButtonSelectAgency";
            this.Size = new System.Drawing.Size(38, 39);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ButtonFind_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picTmp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.PictureBox picTmp;
        private System.Windows.Forms.ToolTip toolTip1;

    }
}
