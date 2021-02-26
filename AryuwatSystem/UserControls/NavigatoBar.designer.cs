namespace AryuwatSystem.UserControls
{
    partial class NavigatoBar
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
            this.lblTxtRecord = new System.Windows.Forms.Label();
            this.cmdLast = new System.Windows.Forms.Button();
            this.cmdNext = new System.Windows.Forms.Button();
            this.cmdPrevious = new System.Windows.Forms.Button();
            this.cmdFirst = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTxtRecord
            // 
            this.lblTxtRecord.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblTxtRecord.ForeColor = System.Drawing.Color.DimGray;
            this.lblTxtRecord.Location = new System.Drawing.Point(66, 0);
            this.lblTxtRecord.Name = "lblTxtRecord";
            this.lblTxtRecord.Size = new System.Drawing.Size(298, 26);
            this.lblTxtRecord.TabIndex = 2;
            this.lblTxtRecord.Text = "0 / 0";
            this.lblTxtRecord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdLast
            // 
            this.cmdLast.Image = global::AryuwatSystem.Properties.Resources._2rightarrow;
            this.cmdLast.Location = new System.Drawing.Point(399, 0);
            this.cmdLast.Name = "cmdLast";
            this.cmdLast.Size = new System.Drawing.Size(30, 26);
            this.cmdLast.TabIndex = 4;
            this.cmdLast.UseVisualStyleBackColor = true;
            this.cmdLast.Click += new System.EventHandler(this.cmdLast_Click);
            // 
            // cmdNext
            // 
            this.cmdNext.Image = global::AryuwatSystem.Properties.Resources._1rightarrow;
            this.cmdNext.Location = new System.Drawing.Point(370, 0);
            this.cmdNext.Name = "cmdNext";
            this.cmdNext.Size = new System.Drawing.Size(30, 26);
            this.cmdNext.TabIndex = 3;
            this.cmdNext.UseVisualStyleBackColor = true;
            this.cmdNext.Click += new System.EventHandler(this.cmdNext_Click);
            // 
            // cmdPrevious
            // 
            this.cmdPrevious.Image = global::AryuwatSystem.Properties.Resources._1leftarrow;
            this.cmdPrevious.Location = new System.Drawing.Point(30, 0);
            this.cmdPrevious.Name = "cmdPrevious";
            this.cmdPrevious.Size = new System.Drawing.Size(30, 26);
            this.cmdPrevious.TabIndex = 1;
            this.cmdPrevious.UseVisualStyleBackColor = true;
            this.cmdPrevious.Click += new System.EventHandler(this.cmdPrevious_Click);
            // 
            // cmdFirst
            // 
            this.cmdFirst.Image = global::AryuwatSystem.Properties.Resources._2leftarrow;
            this.cmdFirst.Location = new System.Drawing.Point(1, 0);
            this.cmdFirst.Name = "cmdFirst";
            this.cmdFirst.Size = new System.Drawing.Size(30, 26);
            this.cmdFirst.TabIndex = 0;
            this.cmdFirst.UseVisualStyleBackColor = true;
            this.cmdFirst.Click += new System.EventHandler(this.cmdFirst_Click);
            // 
            // NavigatoBar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.cmdLast);
            this.Controls.Add(this.cmdNext);
            this.Controls.Add(this.cmdPrevious);
            this.Controls.Add(this.cmdFirst);
            this.Controls.Add(this.lblTxtRecord);
            this.Font = new System.Drawing.Font("2005_iannnnnGMO", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "NavigatoBar";
            this.Size = new System.Drawing.Size(431, 26);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTxtRecord;
        private System.Windows.Forms.Button cmdFirst;
        private System.Windows.Forms.Button cmdPrevious;
        private System.Windows.Forms.Button cmdLast;
        private System.Windows.Forms.Button cmdNext;
    }
}
