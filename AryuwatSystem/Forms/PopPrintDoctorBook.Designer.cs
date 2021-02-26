namespace AryuwatSystem.Forms.FRMReport
{
    partial class PopPrintDoctorBook
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopPrintDoctorBook));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonExp = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioR29 = new System.Windows.Forms.RadioButton();
            this.radioR25 = new System.Windows.Forms.RadioButton();
            this.radioR24 = new System.Windows.Forms.RadioButton();
            this.radioR30 = new System.Windows.Forms.RadioButton();
            this.radioR23 = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 29);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(875, 587);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonExp);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 616);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(875, 55);
            this.panel1.TabIndex = 1;
            // 
            // buttonExp
            // 
            this.buttonExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.buttonExp.Location = new System.Drawing.Point(681, 6);
            this.buttonExp.Name = "buttonExp";
            this.buttonExp.Size = new System.Drawing.Size(124, 37);
            this.buttonExp.TabIndex = 59;
            this.buttonExp.Text = "Export";
            this.buttonExp.UseVisualStyleBackColor = true;
            this.buttonExp.Click += new System.EventHandler(this.buttonExp_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnPrint.Location = new System.Drawing.Point(533, 6);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(124, 37);
            this.btnPrint.TabIndex = 58;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioR29);
            this.panel2.Controls.Add(this.radioR25);
            this.panel2.Controls.Add(this.radioR24);
            this.panel2.Controls.Add(this.radioR30);
            this.panel2.Controls.Add(this.radioR23);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(875, 29);
            this.panel2.TabIndex = 2;
            // 
            // radioR29
            // 
            this.radioR29.AutoSize = true;
            this.radioR29.Location = new System.Drawing.Point(210, 6);
            this.radioR29.Name = "radioR29";
            this.radioR29.Size = new System.Drawing.Size(44, 17);
            this.radioR29.TabIndex = 4;
            this.radioR29.Text = "Hair";
            this.radioR29.UseVisualStyleBackColor = true;
            this.radioR29.Click += new System.EventHandler(this.radioR29_Click);
            // 
            // radioR25
            // 
            this.radioR25.AutoSize = true;
            this.radioR25.Location = new System.Drawing.Point(144, 6);
            this.radioR25.Name = "radioR25";
            this.radioR25.Size = new System.Drawing.Size(66, 17);
            this.radioR25.TabIndex = 3;
            this.radioR25.Text = "Doctor 3";
            this.radioR25.UseVisualStyleBackColor = true;
            this.radioR25.Click += new System.EventHandler(this.radioR25_Click);
            // 
            // radioR24
            // 
            this.radioR24.AutoSize = true;
            this.radioR24.Location = new System.Drawing.Point(78, 6);
            this.radioR24.Name = "radioR24";
            this.radioR24.Size = new System.Drawing.Size(66, 17);
            this.radioR24.TabIndex = 2;
            this.radioR24.Text = "Doctor 2";
            this.radioR24.UseVisualStyleBackColor = true;
            this.radioR24.Click += new System.EventHandler(this.radioR24_Click);
            // 
            // radioR30
            // 
            this.radioR30.AutoSize = true;
            this.radioR30.Location = new System.Drawing.Point(254, 6);
            this.radioR30.Name = "radioR30";
            this.radioR30.Size = new System.Drawing.Size(43, 17);
            this.radioR30.TabIndex = 1;
            this.radioR30.Text = "Anti";
            this.radioR30.UseVisualStyleBackColor = true;
            this.radioR30.Click += new System.EventHandler(this.radioR30_Click);
            // 
            // radioR23
            // 
            this.radioR23.AutoSize = true;
            this.radioR23.Checked = true;
            this.radioR23.Location = new System.Drawing.Point(12, 6);
            this.radioR23.Name = "radioR23";
            this.radioR23.Size = new System.Drawing.Size(66, 17);
            this.radioR23.TabIndex = 0;
            this.radioR23.TabStop = true;
            this.radioR23.Text = "Doctor 1";
            this.radioR23.UseVisualStyleBackColor = true;
            this.radioR23.Click += new System.EventHandler(this.radioR23_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtRemark);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(875, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(383, 671);
            this.panel3.TabIndex = 3;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(6, 29);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(374, 250);
            this.txtRemark.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Remark";
            // 
            // PopPrintDoctorBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1258, 671);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "PopPrintDoctorBook";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PopPrintDoctorBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button buttonExp;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioR29;
        private System.Windows.Forms.RadioButton radioR25;
        private System.Windows.Forms.RadioButton radioR24;
        private System.Windows.Forms.RadioButton radioR30;
        private System.Windows.Forms.RadioButton radioR23;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRemark;
    }
}