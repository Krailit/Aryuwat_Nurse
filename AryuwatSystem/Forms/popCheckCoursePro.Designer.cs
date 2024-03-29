﻿namespace AryuwatSystem.Forms
{
    partial class popCheckCoursePro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(popCheckCoursePro));
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtonPro = new System.Windows.Forms.RadioButton();
            this.radioButtonNormal = new System.Windows.Forms.RadioButton();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPrintRenew = new System.Windows.Forms.Button();
            this.pictureBox_Save = new System.Windows.Forms.PictureBox();
            this.labelName = new System.Windows.Forms.Label();
            this.picPrint = new System.Windows.Forms.PictureBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuEditJobCost = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMOUse = new System.Windows.Forms.ToolStripMenuItem();
            this.resetRenewalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Save)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvData);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(973, 526);
            this.panel2.TabIndex = 1;
            // 
            // dgvData
            // 
            this.dgvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 83);
            this.dgvData.Name = "dgvData";
            //this.dgvData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvData.RowTemplate.ReadOnly = true;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvData.Size = new System.Drawing.Size(973, 443);
            this.dgvData.TabIndex = 125;
            this.dgvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellClick);
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            this.dgvData.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvData_RowPrePaint);
            this.dgvData.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvData_RowsAdded);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.radioButtonPro);
            this.panel1.Controls.Add(this.radioButtonNormal);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnPrintRenew);
            this.panel1.Controls.Add(this.pictureBox_Save);
            this.panel1.Controls.Add(this.labelName);
            this.panel1.Controls.Add(this.picPrint);
            this.panel1.Controls.Add(this.txtFilter);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(973, 83);
            this.panel1.TabIndex = 134;
            // 
            // radioButtonPro
            // 
            this.radioButtonPro.AutoSize = true;
            this.radioButtonPro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.radioButtonPro.Location = new System.Drawing.Point(398, 6);
            this.radioButtonPro.Name = "radioButtonPro";
            this.radioButtonPro.Size = new System.Drawing.Size(50, 20);
            this.radioButtonPro.TabIndex = 66;
            this.radioButtonPro.Text = "Pro";
            this.radioButtonPro.UseVisualStyleBackColor = true;
            this.radioButtonPro.Visible = false;
            this.radioButtonPro.Click += new System.EventHandler(this.radioButtonPro_Click);
            // 
            // radioButtonNormal
            // 
            this.radioButtonNormal.AutoSize = true;
            this.radioButtonNormal.Checked = true;
            this.radioButtonNormal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.radioButtonNormal.Location = new System.Drawing.Point(322, 6);
            this.radioButtonNormal.Name = "radioButtonNormal";
            this.radioButtonNormal.Size = new System.Drawing.Size(76, 20);
            this.radioButtonNormal.TabIndex = 65;
            this.radioButtonNormal.TabStop = true;
            this.radioButtonNormal.Text = "Normal";
            this.radioButtonNormal.UseVisualStyleBackColor = true;
            this.radioButtonNormal.Visible = false;
            this.radioButtonNormal.Click += new System.EventHandler(this.radioButtonNormal_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnPrint.Location = new System.Drawing.Point(304, 29);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(135, 37);
            this.btnPrint.TabIndex = 64;
            this.btnPrint.Text = "Service Request";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPrintRenew
            // 
            this.btnPrintRenew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnPrintRenew.Location = new System.Drawing.Point(446, 29);
            this.btnPrintRenew.Name = "btnPrintRenew";
            this.btnPrintRenew.Size = new System.Drawing.Size(135, 37);
            this.btnPrintRenew.TabIndex = 63;
            this.btnPrintRenew.Text = "Renewal";
            this.btnPrintRenew.UseVisualStyleBackColor = true;
            this.btnPrintRenew.Visible = false;
            this.btnPrintRenew.Click += new System.EventHandler(this.btnPrintRenew_Click);
            // 
            // pictureBox_Save
            // 
            this.pictureBox_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_Save.ErrorImage = global::AryuwatSystem.Properties.Resources.recover_excel_files;
            this.pictureBox_Save.Image = global::AryuwatSystem.Properties.Resources.save;
            this.pictureBox_Save.Location = new System.Drawing.Point(597, 22);
            this.pictureBox_Save.Name = "pictureBox_Save";
            this.pictureBox_Save.Size = new System.Drawing.Size(45, 42);
            this.pictureBox_Save.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Save.TabIndex = 62;
            this.pictureBox_Save.TabStop = false;
            this.pictureBox_Save.Visible = false;
            this.pictureBox_Save.Click += new System.EventHandler(this.pictureBox_Save_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold);
            this.labelName.Location = new System.Drawing.Point(83, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(125, 26);
            this.labelName.TabIndex = 61;
            this.labelName.Text = "CustName";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picPrint
            // 
            this.picPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picPrint.ErrorImage = global::AryuwatSystem.Properties.Resources.recover_excel_files;
            this.picPrint.Image = global::AryuwatSystem.Properties.Resources.print_printer;
            this.picPrint.Location = new System.Drawing.Point(642, 22);
            this.picPrint.Name = "picPrint";
            this.picPrint.Size = new System.Drawing.Size(45, 42);
            this.picPrint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPrint.TabIndex = 60;
            this.picPrint.TabStop = false;
            this.picPrint.Visible = false;
            this.picPrint.Click += new System.EventHandler(this.picPrint_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Font = new System.Drawing.Font("Tahoma", 18F);
            this.txtFilter.Location = new System.Drawing.Point(85, 30);
            this.txtFilter.Margin = new System.Windows.Forms.Padding(4);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(212, 36);
            this.txtFilter.TabIndex = 55;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(2, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 18);
            this.label1.TabIndex = 59;
            this.label1.Text = "      Filter :";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "chief_of_staff_add_128.png");
            this.imageList1.Images.SetKeyName(1, "chief_of_staff_write_128.png");
            this.imageList1.Images.SetKeyName(2, "delete_256ssss_black.png");
            this.imageList1.Images.SetKeyName(3, "progress_notes_ok_128.png");
            this.imageList1.Images.SetKeyName(4, "progress_notes_add_128.png");
            this.imageList1.Images.SetKeyName(5, "loupe_256ssss.png");
            this.imageList1.Images.SetKeyName(6, "blackboard_write_128ssss_6vC_icon.ico");
            this.imageList1.Images.SetKeyName(7, "Business-Survey-icon.png");
            this.imageList1.Images.SetKeyName(8, "pre_resize.jpg");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEditJobCost,
            this.menuMOUse,
            this.resetRenewalToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(249, 100);
            // 
            // menuEditJobCost
            // 
            this.menuEditJobCost.ForeColor = System.Drawing.Color.Black;
            this.menuEditJobCost.Image = global::AryuwatSystem.Properties.Resources.MoneyBagB;
            this.menuEditJobCost.Name = "menuEditJobCost";
            this.menuEditJobCost.Size = new System.Drawing.Size(248, 32);
            this.menuEditJobCost.Text = "Go JobCost";
            this.menuEditJobCost.Visible = false;
            // 
            // menuMOUse
            // 
            this.menuMOUse.AutoToolTip = true;
            this.menuMOUse.Image = global::AryuwatSystem.Properties.Resources.medical_history_128_Red;
            this.menuMOUse.Name = "menuMOUse";
            this.menuMOUse.Size = new System.Drawing.Size(248, 32);
            this.menuMOUse.Text = "Course Record";
            this.menuMOUse.Click += new System.EventHandler(this.menuMOUse_Click);
            // 
            // resetRenewalToolStripMenuItem
            // 
            this.resetRenewalToolStripMenuItem.Name = "resetRenewalToolStripMenuItem";
            this.resetRenewalToolStripMenuItem.Size = new System.Drawing.Size(248, 32);
            this.resetRenewalToolStripMenuItem.Text = "Reset Renewal";
            this.resetRenewalToolStripMenuItem.Click += new System.EventHandler(this.resetRenewalToolStripMenuItem_Click);
            // 
            // popCheckCoursePro
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(973, 526);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "popCheckCoursePro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pro";
            this.Activated += new System.EventHandler(this.FrmCheckCourseList_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCheckCourseList_FormClosing);
            this.Load += new System.EventHandler(this.FrmCheckCourseList_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Save)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picPrint;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuEditJobCost;
        private System.Windows.Forms.ToolStripMenuItem menuMOUse;
        private System.Windows.Forms.PictureBox pictureBox_Save;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnPrintRenew;
        private System.Windows.Forms.ToolStripMenuItem resetRenewalToolStripMenuItem;
        private System.Windows.Forms.RadioButton radioButtonPro;
        private System.Windows.Forms.RadioButton radioButtonNormal;
    }
}