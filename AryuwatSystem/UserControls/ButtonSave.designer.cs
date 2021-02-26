namespace AryuwatSystem.UserControls
{
    partial class ButtonSave
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
            this.picButtonSave = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picButtonSave)).BeginInit();
            this.SuspendLayout();
            // 
            // picButtonSave
            // 
            this.picButtonSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picButtonSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picButtonSave.Image = global::AryuwatSystem.Properties.Resources.save;
            this.picButtonSave.Location = new System.Drawing.Point(0, 0);
            this.picButtonSave.Name = "picButtonSave";
            this.picButtonSave.Size = new System.Drawing.Size(50, 52);
            this.picButtonSave.TabIndex = 0;
            this.picButtonSave.TabStop = false;
            this.picButtonSave.Click += new System.EventHandler(this.picButtonAdd_Click);
            this.picButtonSave.MouseLeave += new System.EventHandler(this.picButtonAdd_MouseLeave);
            this.picButtonSave.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picButtonAdd_MouseMove);
            // 
            // ButtonSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.picButtonSave);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "ButtonSave";
            this.Size = new System.Drawing.Size(50, 52);
            ((System.ComponentModel.ISupportInitialize)(this.picButtonSave)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.PictureBox picButtonSave;

    }
}
