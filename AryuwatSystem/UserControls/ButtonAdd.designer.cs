namespace AryuwatSystem.UserControls
{
    partial class ButtonAdd
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
            this.picButtonAdd = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picButtonAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // picButtonAdd
            // 
            this.picButtonAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picButtonAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picButtonAdd.Image = global::AryuwatSystem.Properties.Resources.add_icon;
            this.picButtonAdd.Location = new System.Drawing.Point(0, 0);
            this.picButtonAdd.Name = "picButtonAdd";
            this.picButtonAdd.Size = new System.Drawing.Size(26, 26);
            this.picButtonAdd.TabIndex = 0;
            this.picButtonAdd.TabStop = false;
            this.picButtonAdd.Click += new System.EventHandler(this.picButtonAdd_Click);
            this.picButtonAdd.MouseLeave += new System.EventHandler(this.picButtonAdd_MouseLeave);
            this.picButtonAdd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picButtonAdd_MouseMove);
            // 
            // ButtonAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.picButtonAdd);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "ButtonAdd";
            this.Size = new System.Drawing.Size(26, 26);
            ((System.ComponentModel.ISupportInitialize)(this.picButtonAdd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.PictureBox picButtonAdd;

    }
}
