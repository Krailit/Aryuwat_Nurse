namespace AryuwatSystem.UserControls
{
    partial class ButtonDelete2
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
            this.picButtonDelete2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picButtonDelete2)).BeginInit();
            this.SuspendLayout();
            // 
            // picButtonDelete2
            // 
            this.picButtonDelete2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picButtonDelete2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picButtonDelete2.Image = global::AryuwatSystem.Properties.Resources.delete_big1;
            this.picButtonDelete2.Location = new System.Drawing.Point(0, 0);
            this.picButtonDelete2.Name = "picButtonDelete2";
            this.picButtonDelete2.Size = new System.Drawing.Size(50, 52);
            this.picButtonDelete2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picButtonDelete2.TabIndex = 0;
            this.picButtonDelete2.TabStop = false;
            this.picButtonDelete2.Click += new System.EventHandler(this.picButtonAdd_Click);
            this.picButtonDelete2.MouseLeave += new System.EventHandler(this.picButtonAdd_MouseLeave);
            this.picButtonDelete2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picButtonAdd_MouseMove);
            // 
            // ButtonDelete2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.picButtonDelete2);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "ButtonDelete2";
            this.Size = new System.Drawing.Size(50, 52);
            ((System.ComponentModel.ISupportInitialize)(this.picButtonDelete2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.PictureBox picButtonDelete2;

    }
}
