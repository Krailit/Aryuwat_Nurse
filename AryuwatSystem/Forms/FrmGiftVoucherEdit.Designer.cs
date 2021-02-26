namespace AryuwatSystem.Forms
{
    partial class FrmGiftVoucherEdit
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtDetail = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.paneldetailTop = new System.Windows.Forms.Panel();
            this.radioButtonGS = new System.Windows.Forms.RadioButton();
            this.radioButtonGE = new System.Windows.Forms.RadioButton();
            this.radioButtonGV = new System.Windows.Forms.RadioButton();
            this.cboEN = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.cboTr = new System.Windows.Forms.ComboBox();
            this.cboApp = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.labelCN = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpDateExpire = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtGiftCode = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.picPrint = new System.Windows.Forms.PictureBox();
            this.btnSaveNew = new System.Windows.Forms.Button();
            this.txtCredit = new AryuwatSystem.UserControls.TextboxFormatDouble(this.components);
            this.buttonAdd1 = new AryuwatSystem.UserControls.ButtonAdd();
            this.buttonDeleteUp = new AryuwatSystem.UserControls.ButtonLeft();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.paneldetailTop.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(229, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Detail :";
            // 
            // txtDetail
            // 
            this.txtDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtDetail.Location = new System.Drawing.Point(283, 53);
            this.txtDetail.Multiline = true;
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.Size = new System.Drawing.Size(232, 55);
            this.txtDetail.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(45, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(147, 17);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.paneldetailTop);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(942, 190);
            this.panel1.TabIndex = 8;
            // 
            // paneldetailTop
            // 
            this.paneldetailTop.Controls.Add(this.txtCredit);
            this.paneldetailTop.Controls.Add(this.radioButtonGS);
            this.paneldetailTop.Controls.Add(this.radioButtonGE);
            this.paneldetailTop.Controls.Add(this.radioButtonGV);
            this.paneldetailTop.Controls.Add(this.cboEN);
            this.paneldetailTop.Controls.Add(this.panel4);
            this.paneldetailTop.Controls.Add(this.label4);
            this.paneldetailTop.Controls.Add(this.dateTimePicker2);
            this.paneldetailTop.Controls.Add(this.txtDetail);
            this.paneldetailTop.Controls.Add(this.label2);
            this.paneldetailTop.Controls.Add(this.cboTr);
            this.paneldetailTop.Controls.Add(this.cboApp);
            this.paneldetailTop.Controls.Add(this.label15);
            this.paneldetailTop.Controls.Add(this.label14);
            this.paneldetailTop.Controls.Add(this.labelCN);
            this.paneldetailTop.Controls.Add(this.btnBrowse);
            this.paneldetailTop.Controls.Add(this.txtCustomerName);
            this.paneldetailTop.Controls.Add(this.label13);
            this.paneldetailTop.Controls.Add(this.label9);
            this.paneldetailTop.Controls.Add(this.dtpDateExpire);
            this.paneldetailTop.Controls.Add(this.label10);
            this.paneldetailTop.Controls.Add(this.label5);
            this.paneldetailTop.Controls.Add(this.txtRemark);
            this.paneldetailTop.Controls.Add(this.label6);
            this.paneldetailTop.Controls.Add(this.label7);
            this.paneldetailTop.Controls.Add(this.label8);
            this.paneldetailTop.Controls.Add(this.dtpDate);
            this.paneldetailTop.Controls.Add(this.txtGiftCode);
            this.paneldetailTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.paneldetailTop.Location = new System.Drawing.Point(0, 0);
            this.paneldetailTop.Name = "paneldetailTop";
            this.paneldetailTop.Size = new System.Drawing.Size(942, 188);
            this.paneldetailTop.TabIndex = 8;
            // 
            // radioButtonGS
            // 
            this.radioButtonGS.AutoSize = true;
            this.radioButtonGS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonGS.Location = new System.Drawing.Point(388, 13);
            this.radioButtonGS.Name = "radioButtonGS";
            this.radioButtonGS.Size = new System.Drawing.Size(108, 24);
            this.radioButtonGS.TabIndex = 334;
            this.radioButtonGS.Text = "GS(ดอลล่าร์)";
            this.radioButtonGS.UseVisualStyleBackColor = true;
            // 
            // radioButtonGE
            // 
            this.radioButtonGE.AutoSize = true;
            this.radioButtonGE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonGE.Location = new System.Drawing.Point(276, 13);
            this.radioButtonGE.Name = "radioButtonGE";
            this.radioButtonGE.Size = new System.Drawing.Size(112, 24);
            this.radioButtonGE.TabIndex = 333;
            this.radioButtonGE.Text = "GE(หมดอายุ)";
            this.radioButtonGE.UseVisualStyleBackColor = true;
            // 
            // radioButtonGV
            // 
            this.radioButtonGV.AutoSize = true;
            this.radioButtonGV.Checked = true;
            this.radioButtonGV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonGV.Location = new System.Drawing.Point(88, 13);
            this.radioButtonGV.Name = "radioButtonGV";
            this.radioButtonGV.Size = new System.Drawing.Size(188, 24);
            this.radioButtonGV.TabIndex = 332;
            this.radioButtonGV.TabStop = true;
            this.radioButtonGV.Text = "GV(ทั่วไป sale เลือกอันนี้)";
            this.radioButtonGV.UseVisualStyleBackColor = true;
            // 
            // cboEN
            // 
            this.cboEN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboEN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboEN.Font = new System.Drawing.Font("TH Sarabun New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEN.Location = new System.Drawing.Point(650, 46);
            this.cboEN.Name = "cboEN";
            this.cboEN.Size = new System.Drawing.Size(247, 34);
            this.cboEN.TabIndex = 331;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.buttonAdd1);
            this.panel4.Controls.Add(this.buttonDeleteUp);
            this.panel4.Location = new System.Drawing.Point(527, 143);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(98, 33);
            this.panel4.TabIndex = 149;
            this.panel4.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(931, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 16);
            this.label4.TabIndex = 330;
            this.label4.Text = "ใช้เมื่อ :";
            this.label4.Visible = false;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd-MMM-yyyy";
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(988, 12);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.ShowUpDown = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(133, 26);
            this.dateTimePicker2.TabIndex = 329;
            this.dateTimePicker2.Visible = false;
            // 
            // cboTr
            // 
            this.cboTr.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboTr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboTr.BackColor = System.Drawing.Color.White;
            this.cboTr.Font = new System.Drawing.Font("TH Sarabun New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTr.FormattingEnabled = true;
            this.cboTr.Location = new System.Drawing.Point(650, 116);
            this.cboTr.Name = "cboTr";
            this.cboTr.Size = new System.Drawing.Size(247, 34);
            this.cboTr.TabIndex = 327;
            // 
            // cboApp
            // 
            this.cboApp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboApp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboApp.BackColor = System.Drawing.Color.White;
            this.cboApp.Font = new System.Drawing.Font("TH Sarabun New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboApp.FormattingEnabled = true;
            this.cboApp.Location = new System.Drawing.Point(650, 81);
            this.cboApp.Name = "cboApp";
            this.cboApp.Size = new System.Drawing.Size(247, 34);
            this.cboApp.TabIndex = 326;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(598, 92);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 16);
            this.label15.TabIndex = 324;
            this.label15.Text = "ผู้อนุมัติ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(592, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 16);
            this.label14.TabIndex = 322;
            this.label14.Text = "มอบโดย";
            // 
            // labelCN
            // 
            this.labelCN.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCN.Location = new System.Drawing.Point(527, 26);
            this.labelCN.Name = "labelCN";
            this.labelCN.Size = new System.Drawing.Size(123, 16);
            this.labelCN.TabIndex = 320;
            this.labelCN.Text = "CN";
            this.labelCN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(896, 12);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(26, 29);
            this.btnBrowse.TabIndex = 319;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(650, 13);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(247, 27);
            this.txtCustomerName.TabIndex = 318;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(524, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(129, 16);
            this.label13.TabIndex = 317;
            this.label13.Text = "ชื่อลูกค้า/Customer";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(22, 118);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 16);
            this.label9.TabIndex = 183;
            this.label9.Text = "หมดอายุ :";
            // 
            // dtpDateExpire
            // 
            this.dtpDateExpire.CustomFormat = "dd-MMM-yyyy";
            this.dtpDateExpire.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.dtpDateExpire.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateExpire.Location = new System.Drawing.Point(93, 112);
            this.dtpDateExpire.Name = "dtpDateExpire";
            this.dtpDateExpire.ShowUpDown = true;
            this.dtpDateExpire.Size = new System.Drawing.Size(133, 26);
            this.dtpDateExpire.TabIndex = 182;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(4, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 16);
            this.label10.TabIndex = 174;
            this.label10.Text = "Voucher No.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(586, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 160;
            this.label5.Text = "ทรีทเม้นต์";
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("TH Sarabun New", 14F);
            this.txtRemark.Location = new System.Drawing.Point(283, 113);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(232, 60);
            this.txtRemark.TabIndex = 167;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(48, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 16);
            this.label6.TabIndex = 157;
            this.label6.Text = "แจก :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(236, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 16);
            this.label7.TabIndex = 168;
            this.label7.Text = "เหตุผล";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(40, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 16);
            this.label8.TabIndex = 153;
            this.label8.Text = "มูลค่า :";
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(93, 82);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.ShowUpDown = true;
            this.dtpDate.Size = new System.Drawing.Size(133, 26);
            this.dtpDate.TabIndex = 3;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // txtGiftCode
            // 
            this.txtGiftCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtGiftCode.Location = new System.Drawing.Point(93, 51);
            this.txtGiftCode.Name = "txtGiftCode";
            this.txtGiftCode.ReadOnly = true;
            this.txtGiftCode.Size = new System.Drawing.Size(133, 24);
            this.txtGiftCode.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 190);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(942, 3);
            this.panel2.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnSaveNew);
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Controls.Add(this.picPrint);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 193);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(942, 53);
            this.panel3.TabIndex = 10;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(793, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 42);
            this.btnCancel.TabIndex = 158;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(671, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(103, 42);
            this.btnSave.TabIndex = 157;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // picPrint
            // 
            this.picPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picPrint.ErrorImage = global::AryuwatSystem.Properties.Resources.recover_excel_files;
            this.picPrint.Image = global::AryuwatSystem.Properties.Resources.print_printer;
            this.picPrint.Location = new System.Drawing.Point(598, 6);
            this.picPrint.Name = "picPrint";
            this.picPrint.Size = new System.Drawing.Size(45, 42);
            this.picPrint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPrint.TabIndex = 156;
            this.picPrint.TabStop = false;
            this.picPrint.Click += new System.EventHandler(this.picPrint_Click);
            // 
            // btnSaveNew
            // 
            this.btnSaveNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveNew.Location = new System.Drawing.Point(282, 6);
            this.btnSaveNew.Name = "btnSaveNew";
            this.btnSaveNew.Size = new System.Drawing.Size(105, 42);
            this.btnSaveNew.TabIndex = 159;
            this.btnSaveNew.Text = "Save && New";
            this.btnSaveNew.UseVisualStyleBackColor = true;
            this.btnSaveNew.Visible = false;
            this.btnSaveNew.Click += new System.EventHandler(this.btnSaveNew_Click);
            // 
            // txtCredit
            // 
            this.txtCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtCredit.Location = new System.Drawing.Point(93, 143);
            this.txtCredit.Name = "txtCredit";
            this.txtCredit.Size = new System.Drawing.Size(133, 29);
            this.txtCredit.TabIndex = 335;
            // 
            // buttonAdd1
            // 
            this.buttonAdd1.BackColor = System.Drawing.Color.Transparent;
            this.buttonAdd1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAdd1.Location = new System.Drawing.Point(54, 4);
            this.buttonAdd1.Name = "buttonAdd1";
            this.buttonAdd1.Size = new System.Drawing.Size(30, 26);
            this.buttonAdd1.TabIndex = 7;
            this.buttonAdd1.BtnClick += new AryuwatSystem.UserControls.ButtonAdd.ButtonClick(this.buttonAdd1_BtnClick);
            // 
            // buttonDeleteUp
            // 
            this.buttonDeleteUp.Location = new System.Drawing.Point(18, 4);
            this.buttonDeleteUp.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.buttonDeleteUp.Name = "buttonDeleteUp";
            this.buttonDeleteUp.Size = new System.Drawing.Size(30, 26);
            this.buttonDeleteUp.TabIndex = 148;
            // 
            // FrmGiftVoucherEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 246);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGiftVoucherEdit";
            this.ShowInTaskbar = false;
            this.Text = "GiftVoucher Edit";
            this.Load += new System.EventHandler(this.FrmGiftVoucherEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.paneldetailTop.ResumeLayout(false);
            this.paneldetailTop.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDetail;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private UserControls.ButtonAdd buttonAdd1;
        private System.Windows.Forms.Panel paneldetailTop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.ComboBox cboTr;
        private System.Windows.Forms.ComboBox cboApp;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label labelCN;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpDateExpire;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TextBox txtGiftCode;
        private System.Windows.Forms.Panel panel4;
        private UserControls.ButtonLeft buttonDeleteUp;
        private System.Windows.Forms.ComboBox cboEN;
        private System.Windows.Forms.PictureBox picPrint;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RadioButton radioButtonGS;
        private System.Windows.Forms.RadioButton radioButtonGE;
        private System.Windows.Forms.RadioButton radioButtonGV;
        private UserControls.TextboxFormatDouble txtCredit;
        private System.Windows.Forms.Button btnSaveNew;
    }
}