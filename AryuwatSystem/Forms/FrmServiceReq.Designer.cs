namespace AryuwatSystem.Forms
{
    partial class FrmServiceReq
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
            this.txtFindAes = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvAestheticList = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataGridViewSelectList = new System.Windows.Forms.DataGridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.picPrint = new System.Windows.Forms.PictureBox();
            this.buttonAddDown = new AryuwatSystem.UserControls.ButtonRigth();
            this.buttonDeleteUp = new AryuwatSystem.UserControls.ButtonLeft();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAestheticList)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectList)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFindAes
            // 
            this.txtFindAes.Location = new System.Drawing.Point(54, 4);
            this.txtFindAes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFindAes.Name = "txtFindAes";
            this.txtFindAes.Size = new System.Drawing.Size(241, 20);
            this.txtFindAes.TabIndex = 143;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 13);
            this.label11.TabIndex = 142;
            this.label11.Text = "Find :";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1261, 48);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.picPrint);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 417);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1261, 53);
            this.panel2.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(1048, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 39);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(936, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel3.Controls.Add(this.dgvAestheticList);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 48);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1261, 178);
            this.panel3.TabIndex = 4;
            // 
            // dgvAestheticList
            // 
            this.dgvAestheticList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAestheticList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvAestheticList.BackgroundColor = System.Drawing.Color.White;
            this.dgvAestheticList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvAestheticList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAestheticList.Location = new System.Drawing.Point(0, 28);
            this.dgvAestheticList.Name = "dgvAestheticList";
            //this.dgvAestheticList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvAestheticList.RowTemplate.ReadOnly = true;
            this.dgvAestheticList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAestheticList.Size = new System.Drawing.Size(1261, 150);
            this.dgvAestheticList.TabIndex = 149;
            this.dgvAestheticList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAestheticList_CellContentClick);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtFindAes);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1261, 28);
            this.panel4.TabIndex = 144;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 226);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1261, 3);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel5.Controls.Add(this.dataGridViewSelectList);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 229);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1261, 188);
            this.panel5.TabIndex = 6;
            // 
            // dataGridViewSelectList
            // 
            this.dataGridViewSelectList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewSelectList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridViewSelectList.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewSelectList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewSelectList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSelectList.Location = new System.Drawing.Point(0, 22);
            this.dataGridViewSelectList.Name = "dataGridViewSelectList";
            //this.dataGridViewSelectList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridViewSelectList.RowTemplate.ReadOnly = true;
            this.dataGridViewSelectList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSelectList.Size = new System.Drawing.Size(1261, 166);
            this.dataGridViewSelectList.TabIndex = 150;
            this.dataGridViewSelectList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSelectList_CellContentClick);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel6.Controls.Add(this.buttonAddDown);
            this.panel6.Controls.Add(this.buttonDeleteUp);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1261, 22);
            this.panel6.TabIndex = 151;
            // 
            // picPrint
            // 
            this.picPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picPrint.ErrorImage = global::AryuwatSystem.Properties.Resources.recover_excel_files;
            this.picPrint.Image = global::AryuwatSystem.Properties.Resources.print_printer;
            this.picPrint.Location = new System.Drawing.Point(885, 6);
            this.picPrint.Name = "picPrint";
            this.picPrint.Size = new System.Drawing.Size(45, 42);
            this.picPrint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPrint.TabIndex = 61;
            this.picPrint.TabStop = false;
            this.picPrint.Click += new System.EventHandler(this.picPrint_Click);
            // 
            // buttonAddDown
            // 
            this.buttonAddDown.Location = new System.Drawing.Point(616, 2);
            this.buttonAddDown.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.buttonAddDown.Name = "buttonAddDown";
            this.buttonAddDown.Size = new System.Drawing.Size(30, 26);
            this.buttonAddDown.TabIndex = 146;
            this.buttonAddDown.BtnClick += new AryuwatSystem.UserControls.ButtonRigth.ButtonClick(this.buttonAddDown_BtnClick);
            // 
            // buttonDeleteUp
            // 
            this.buttonDeleteUp.Location = new System.Drawing.Point(582, 2);
            this.buttonDeleteUp.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.buttonDeleteUp.Name = "buttonDeleteUp";
            this.buttonDeleteUp.Size = new System.Drawing.Size(30, 26);
            this.buttonDeleteUp.TabIndex = 147;
            this.buttonDeleteUp.BtnClick += new AryuwatSystem.UserControls.ButtonLeft.ButtonClick(this.buttonDeleteUp_BtnClick);
            // 
            // FrmServiceReq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 470);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Name = "FrmServiceReq";
            this.Text = "FrmServiceReq";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmServiceReq_FormClosing);
            this.Load += new System.EventHandler(this.FrmServiceReq_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAestheticList)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectList)).EndInit();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtFindAes;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvAestheticList;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dataGridViewSelectList;
        private System.Windows.Forms.Panel panel6;
        private UserControls.ButtonRigth buttonAddDown;
        private UserControls.ButtonLeft buttonDeleteUp;
        private System.Windows.Forms.PictureBox picPrint;
    }
}