namespace AryuwatSystem.Forms
{
    partial class FrmMedicalDoctorEstimate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMedicalDoctorEstimate));
            this.dataGridViewSelectList = new System.Windows.Forms.DataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panelName = new System.Windows.Forms.Panel();
            this.labelType = new System.Windows.Forms.Label();
            this.cboDr = new System.Windows.Forms.ComboBox();
            this.btnPrintList = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbMO = new System.Windows.Forms.Label();
            this.dateTimePickerCreate = new System.Windows.Forms.DateTimePicker();
            this.labelCustomer = new System.Windows.Forms.Label();
            this.pictureBoxAddNew = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnBrown = new System.Windows.Forms.Button();
            this.btnAddFile = new AryuwatSystem.UserControls.ButtonAdd();
            this.txtBalanceRef = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxExit = new System.Windows.Forms.PictureBox();
            this.pictureBoxSave = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvFile = new System.Windows.Forms.DataGridView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectList)).BeginInit();
            this.panelName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAddNew)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSave)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFile)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewSelectList
            // 
            this.dataGridViewSelectList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewSelectList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridViewSelectList.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewSelectList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewSelectList.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewSelectList.Location = new System.Drawing.Point(0, 97);
            this.dataGridViewSelectList.Name = "dataGridViewSelectList";
            this.dataGridViewSelectList.ReadOnly = true;
            this.dataGridViewSelectList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridViewSelectList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSelectList.Size = new System.Drawing.Size(1239, 159);
            this.dataGridViewSelectList.TabIndex = 151;
            this.dataGridViewSelectList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSelectList_CellClick);
            this.dataGridViewSelectList.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewSelectList_CellMouseMove);
            this.dataGridViewSelectList.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridViewSelectList_RowPostPaint);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "chief_of_staff_add_128.png");
            this.imageList1.Images.SetKeyName(1, "chief_of_staff_write_128.png");
            this.imageList1.Images.SetKeyName(2, "progress_notes_ok_128.png");
            this.imageList1.Images.SetKeyName(3, "delete_256ssss_black.png");
            this.imageList1.Images.SetKeyName(4, "progress_notes_add_128.png");
            this.imageList1.Images.SetKeyName(5, "loupe_256ssss.png");
            this.imageList1.Images.SetKeyName(6, "blackboard_write_128ssss_6vC_icon.ico");
            this.imageList1.Images.SetKeyName(7, "Business-Survey-icon.png");
            // 
            // panelName
            // 
            this.panelName.Controls.Add(this.panel3);
            this.panelName.Controls.Add(this.cboDr);
            this.panelName.Controls.Add(this.label5);
            this.panelName.Controls.Add(this.label1);
            this.panelName.Controls.Add(this.lbMO);
            this.panelName.Controls.Add(this.dateTimePickerCreate);
            this.panelName.Controls.Add(this.labelCustomer);
            this.panelName.Controls.Add(this.pictureBoxAddNew);
            this.panelName.Controls.Add(this.panel2);
            this.panelName.Controls.Add(this.txtBalanceRef);
            this.panelName.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelName.Location = new System.Drawing.Point(0, 0);
            this.panelName.Name = "panelName";
            this.panelName.Size = new System.Drawing.Size(1239, 97);
            this.panelName.TabIndex = 152;
            // 
            // labelType
            // 
            this.labelType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelType.AutoSize = true;
            this.labelType.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelType.Location = new System.Drawing.Point(15, 6);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(85, 29);
            this.labelType.TabIndex = 0;
            this.labelType.Text = "label2";
            this.labelType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboDr
            // 
            this.cboDr.FormattingEnabled = true;
            this.cboDr.Location = new System.Drawing.Point(548, 61);
            this.cboDr.Name = "cboDr";
            this.cboDr.Size = new System.Drawing.Size(231, 21);
            this.cboDr.TabIndex = 307;
            // 
            // btnPrintList
            // 
            this.btnPrintList.Location = new System.Drawing.Point(92, 41);
            this.btnPrintList.Name = "btnPrintList";
            this.btnPrintList.Size = new System.Drawing.Size(75, 23);
            this.btnPrintList.TabIndex = 155;
            this.btnPrintList.Text = "Print รับยา";
            this.btnPrintList.UseVisualStyleBackColor = true;
            this.btnPrintList.Visible = false;
            this.btnPrintList.Click += new System.EventHandler(this.btnPrintList_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(507, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 16);
            this.label5.TabIndex = 306;
            this.label5.Text = "Dr.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(503, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 16);
            this.label1.TabIndex = 305;
            this.label1.Text = "Date";
            // 
            // lbMO
            // 
            this.lbMO.AutoSize = true;
            this.lbMO.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMO.Location = new System.Drawing.Point(11, 9);
            this.lbMO.Name = "lbMO";
            this.lbMO.Size = new System.Drawing.Size(51, 19);
            this.lbMO.TabIndex = 153;
            this.lbMO.Text = "MO : ";
            this.lbMO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateTimePickerCreate
            // 
            this.dateTimePickerCreate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerCreate.Location = new System.Drawing.Point(548, 32);
            this.dateTimePickerCreate.Name = "dateTimePickerCreate";
            this.dateTimePickerCreate.ShowUpDown = true;
            this.dateTimePickerCreate.Size = new System.Drawing.Size(99, 20);
            this.dateTimePickerCreate.TabIndex = 304;
            this.dateTimePickerCreate.Value = new System.DateTime(2016, 2, 13, 0, 0, 0, 0);
            // 
            // labelCustomer
            // 
            this.labelCustomer.AutoSize = true;
            this.labelCustomer.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCustomer.Location = new System.Drawing.Point(237, 9);
            this.labelCustomer.Name = "labelCustomer";
            this.labelCustomer.Size = new System.Drawing.Size(83, 19);
            this.labelCustomer.TabIndex = 152;
            this.labelCustomer.Text = "ชื่อลูกค้า :";
            this.labelCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBoxAddNew
            // 
            this.pictureBoxAddNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxAddNew.Image = global::AryuwatSystem.Properties.Resources.note_add1;
            this.pictureBoxAddNew.Location = new System.Drawing.Point(805, 32);
            this.pictureBoxAddNew.Name = "pictureBoxAddNew";
            this.pictureBoxAddNew.Size = new System.Drawing.Size(54, 50);
            this.pictureBoxAddNew.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAddNew.TabIndex = 301;
            this.pictureBoxAddNew.TabStop = false;
            this.pictureBoxAddNew.Click += new System.EventHandler(this.pictureBoxAddNew_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtFileName);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.txtFilePath);
            this.panel2.Controls.Add(this.btnBrown);
            this.panel2.Controls.Add(this.btnAddFile);
            this.panel2.Location = new System.Drawing.Point(15, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(482, 61);
            this.panel2.TabIndex = 303;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(-1, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 16);
            this.label4.TabIndex = 295;
            this.label4.Text = "Upload File Scan";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(110, 32);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(305, 20);
            this.txtFileName.TabIndex = 294;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(44, 34);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 16);
            this.label14.TabIndex = 290;
            this.label14.Text = "คำอธิบาย";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(110, 4);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(278, 20);
            this.txtFilePath.TabIndex = 291;
            // 
            // btnBrown
            // 
            this.btnBrown.Location = new System.Drawing.Point(387, 3);
            this.btnBrown.Name = "btnBrown";
            this.btnBrown.Size = new System.Drawing.Size(28, 21);
            this.btnBrown.TabIndex = 292;
            this.btnBrown.Text = "...";
            this.btnBrown.UseVisualStyleBackColor = true;
            this.btnBrown.Click += new System.EventHandler(this.btnBrown_Click);
            // 
            // btnAddFile
            // 
            this.btnAddFile.BackColor = System.Drawing.Color.Transparent;
            this.btnAddFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddFile.Location = new System.Drawing.Point(441, 18);
            this.btnAddFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(26, 26);
            this.btnAddFile.TabIndex = 293;
            this.btnAddFile.BtnClick += new AryuwatSystem.UserControls.ButtonAdd.ButtonClick(this.btnAddFile_BtnClick);
            // 
            // txtBalanceRef
            // 
            this.txtBalanceRef.BackColor = System.Drawing.Color.Black;
            this.txtBalanceRef.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalanceRef.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtBalanceRef.Location = new System.Drawing.Point(1086, 57);
            this.txtBalanceRef.Name = "txtBalanceRef";
            this.txtBalanceRef.Size = new System.Drawing.Size(141, 27);
            this.txtBalanceRef.TabIndex = 147;
            this.txtBalanceRef.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBalanceRef.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.pictureBoxExit);
            this.panel1.Controls.Add(this.pictureBoxSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 512);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1239, 53);
            this.panel1.TabIndex = 153;
            // 
            // pictureBoxExit
            // 
            this.pictureBoxExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxExit.Image = global::AryuwatSystem.Properties.Resources.Letter_X_blue_icon;
            this.pictureBoxExit.Location = new System.Drawing.Point(1175, 8);
            this.pictureBoxExit.Name = "pictureBoxExit";
            this.pictureBoxExit.Size = new System.Drawing.Size(40, 40);
            this.pictureBoxExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxExit.TabIndex = 301;
            this.pictureBoxExit.TabStop = false;
            this.pictureBoxExit.Click += new System.EventHandler(this.pictureBoxExit_Click);
            this.pictureBoxExit.MouseHover += new System.EventHandler(this.pictureBoxExit_MouseHover);
            // 
            // pictureBoxSave
            // 
            this.pictureBoxSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxSave.Image = global::AryuwatSystem.Properties.Resources.save;
            this.pictureBoxSave.Location = new System.Drawing.Point(1099, 8);
            this.pictureBoxSave.Name = "pictureBoxSave";
            this.pictureBoxSave.Size = new System.Drawing.Size(40, 40);
            this.pictureBoxSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSave.TabIndex = 300;
            this.pictureBoxSave.TabStop = false;
            this.pictureBoxSave.Click += new System.EventHandler(this.pictureBoxSave_Click);
            this.pictureBoxSave.MouseHover += new System.EventHandler(this.pictureBoxSave_MouseHover);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvFile);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(0, 256);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1239, 256);
            this.groupBox1.TabIndex = 155;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "History";
            // 
            // dgvFile
            // 
            this.dgvFile.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvFile.BackgroundColor = System.Drawing.Color.White;
            this.dgvFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFile.Location = new System.Drawing.Point(3, 16);
            this.dgvFile.Name = "dgvFile";
            //this.dgvFile.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvFile.RowTemplate.Height = 35;
            this.dgvFile.RowTemplate.ReadOnly = true;
            this.dgvFile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFile.Size = new System.Drawing.Size(1233, 237);
            this.dgvFile.TabIndex = 150;
            this.dgvFile.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFile_CellClick);
            this.dgvFile.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvUsedTrans_CellMouseMove);
            this.dgvFile.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvUsedTrans_RowPostPaint);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 256);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1239, 3);
            this.splitter1.TabIndex = 156;
            this.splitter1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnPrintList);
            this.panel3.Controls.Add(this.labelType);
            this.panel3.Location = new System.Drawing.Point(1003, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(179, 69);
            this.panel3.TabIndex = 308;
            // 
            // FrmMedicalDoctorEstimate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 565);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewSelectList);
            this.Controls.Add(this.panelName);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMedicalDoctorEstimate";
            this.Text = "Doctor Estimate";
            this.Load += new System.EventHandler(this.FrmMedicalDoctorEstimate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectList)).EndInit();
            this.panelName.ResumeLayout(false);
            this.panelName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAddNew)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSave)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFile)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSelectList;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panelName;
        internal System.Windows.Forms.TextBox txtBalanceRef;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelCustomer;
        private System.Windows.Forms.Label lbMO;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvFile;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.TextBox txtFilePath;
        private UserControls.ButtonAdd btnAddFile;
        private System.Windows.Forms.Button btnBrown;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox pictureBoxAddNew;
        private System.Windows.Forms.PictureBox pictureBoxSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerCreate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboDr;
        private System.Windows.Forms.Button btnPrintList;
        private System.Windows.Forms.PictureBox pictureBoxExit;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.Panel panel3;
    }
}