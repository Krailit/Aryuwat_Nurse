namespace AryuwatSystem.Forms
{
    partial class PopMedicalUsed
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopMedicalUsed));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblSupplie = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvUsedTrans = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.lblAmountUsed = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvStaff = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnGiftcode = new System.Windows.Forms.Button();
            this.txtGiftCode = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtShot = new AryuwatSystem.UserControls.TextboxFormatDouble(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.picBalManual = new System.Windows.Forms.PictureBox();
            this.labelUseBal = new System.Windows.Forms.Label();
            this.textboxFormatDoubleUseBal = new AryuwatSystem.UserControls.TextboxFormatDouble(this.components);
            this.txtCoursID2 = new System.Windows.Forms.TextBox();
            this.txtCoursID1 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxCommission1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtUseNew = new AryuwatSystem.UserControls.TextboxFormatDouble(this.components);
            this.cboBranch = new AryuwatSystem.UserControls.UBranch();
            this.dateTimePickerCreate = new System.Windows.Forms.DateTimePicker();
            this.checkBoxSwap = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRefMO = new System.Windows.Forms.TextBox();
            this.txtUsedName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUsedCN = new System.Windows.Forms.TextBox();
            this.lbCO = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelExpire = new System.Windows.Forms.Label();
            this.panel1Button = new System.Windows.Forms.Panel();
            this.btnToJob = new System.Windows.Forms.Button();
            this.lbREQ = new System.Windows.Forms.Label();
            this.pictureBoxREQ = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsedTrans)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBalManual)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panel1Button.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxREQ)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "ชื่อลูกค้า :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(16, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "รายการ :";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblCustomerName.Location = new System.Drawing.Point(80, 19);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(168, 19);
            this.lblCustomerName.TabIndex = 1;
            this.lblCustomerName.Text = "[lblCustomerName]";
            // 
            // lblSupplie
            // 
            this.lblSupplie.AutoSize = true;
            this.lblSupplie.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblSupplie.Location = new System.Drawing.Point(80, 49);
            this.lblSupplie.Name = "lblSupplie";
            this.lblSupplie.Size = new System.Drawing.Size(103, 19);
            this.lblSupplie.TabIndex = 1;
            this.lblSupplie.Text = "[lblSupplie]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label3.Location = new System.Drawing.Point(519, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "จำนวนทั้งหมด/Total";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(649, 13);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(88, 17);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "xxxxxxxxxx";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvUsedTrans);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(707, 527);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ประวัติการใช้";
            this.groupBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox1_Paint);
            // 
            // dgvUsedTrans
            // 
            this.dgvUsedTrans.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsedTrans.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvUsedTrans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsedTrans.Location = new System.Drawing.Point(3, 19);
            this.dgvUsedTrans.Name = "dgvUsedTrans";
            this.dgvUsedTrans.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvUsedTrans.RowTemplate.ReadOnly = true;
            this.dgvUsedTrans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsedTrans.Size = new System.Drawing.Size(701, 505);
            this.dgvUsedTrans.TabIndex = 149;
            this.dgvUsedTrans.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsedTrans_CellContentClick);
            this.dgvUsedTrans.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvUsedTrans_CellMouseMove);
            this.dgvUsedTrans.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvUsedTrans_RowPostPaint);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label6.Location = new System.Drawing.Point(547, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "ใช้ไปแล้ว/Used";
            // 
            // lblAmountUsed
            // 
            this.lblAmountUsed.AutoSize = true;
            this.lblAmountUsed.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblAmountUsed.Location = new System.Drawing.Point(649, 31);
            this.lblAmountUsed.Name = "lblAmountUsed";
            this.lblAmountUsed.Size = new System.Drawing.Size(88, 17);
            this.lblAmountUsed.TabIndex = 1;
            this.lblAmountUsed.Text = "xxxxxxxxxx";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label8.Location = new System.Drawing.Point(539, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "คงเหลือ/Balance";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblBalance.Location = new System.Drawing.Point(649, 49);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(88, 17);
            this.lblBalance.TabIndex = 1;
            this.lblBalance.Text = "xxxxxxxxxx";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(730, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(641, 620);
            this.groupBox2.TabIndex = 275;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "บันทึกการใช้";
            this.groupBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox2_Paint);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvStaff);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 134);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(635, 483);
            this.panel2.TabIndex = 283;
            // 
            // dgvStaff
            // 
            this.dgvStaff.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvStaff.BackgroundColor = System.Drawing.Color.White;
            this.dgvStaff.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvStaff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStaff.Location = new System.Drawing.Point(0, 0);
            this.dgvStaff.Name = "dgvStaff";
            this.dgvStaff.RowTemplate.ReadOnly = true;
            this.dgvStaff.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStaff.Size = new System.Drawing.Size(635, 483);
            this.dgvStaff.TabIndex = 272;
            this.dgvStaff.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStaff_CellContentClick);
            this.dgvStaff.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvStaff_RowPostPaint);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnGiftcode);
            this.panel3.Controls.Add(this.txtGiftCode);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.txtShot);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.picBalManual);
            this.panel3.Controls.Add(this.labelUseBal);
            this.panel3.Controls.Add(this.textboxFormatDoubleUseBal);
            this.panel3.Controls.Add(this.txtCoursID2);
            this.panel3.Controls.Add(this.txtCoursID1);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.comboBoxCommission1);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.txtUseNew);
            this.panel3.Controls.Add(this.cboBranch);
            this.panel3.Controls.Add(this.dateTimePickerCreate);
            this.panel3.Controls.Add(this.checkBoxSwap);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtRefMO);
            this.panel3.Controls.Add(this.txtUsedName);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.txtUsedCN);
            this.panel3.Controls.Add(this.lbCO);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 19);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(635, 115);
            this.panel3.TabIndex = 3080;
            // 
            // btnGiftcode
            // 
            this.btnGiftcode.Location = new System.Drawing.Point(557, 33);
            this.btnGiftcode.Name = "btnGiftcode";
            this.btnGiftcode.Size = new System.Drawing.Size(29, 25);
            this.btnGiftcode.TabIndex = 3091;
            this.btnGiftcode.Text = "...";
            this.btnGiftcode.UseVisualStyleBackColor = true;
            this.btnGiftcode.Click += new System.EventHandler(this.btnGiftcode_Click);
            // 
            // txtGiftCode
            // 
            this.txtGiftCode.Location = new System.Drawing.Point(439, 34);
            this.txtGiftCode.Name = "txtGiftCode";
            this.txtGiftCode.ReadOnly = true;
            this.txtGiftCode.Size = new System.Drawing.Size(119, 23);
            this.txtGiftCode.TabIndex = 3089;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(374, 37);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 16);
            this.label14.TabIndex = 3090;
            this.label14.Text = "Gift Code";
            // 
            // txtShot
            // 
            this.txtShot.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtShot.Location = new System.Drawing.Point(84, 86);
            this.txtShot.Name = "txtShot";
            this.txtShot.Size = new System.Drawing.Size(65, 24);
            this.txtShot.TabIndex = 3088;
            this.txtShot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(8, 93);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 16);
            this.label13.TabIndex = 3087;
            this.label13.Text = "Shot(ถ้ามี)";
            // 
            // picBalManual
            // 
            this.picBalManual.Image = global::AryuwatSystem.Properties.Resources.reBal;
            this.picBalManual.Location = new System.Drawing.Point(6, 10);
            this.picBalManual.Name = "picBalManual";
            this.picBalManual.Size = new System.Drawing.Size(31, 29);
            this.picBalManual.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBalManual.TabIndex = 3086;
            this.picBalManual.TabStop = false;
            this.picBalManual.Visible = false;
            this.picBalManual.Click += new System.EventHandler(this.picBalManual_Click);
            // 
            // labelUseBal
            // 
            this.labelUseBal.AutoSize = true;
            this.labelUseBal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelUseBal.Location = new System.Drawing.Point(6, 37);
            this.labelUseBal.Name = "labelUseBal";
            this.labelUseBal.Size = new System.Drawing.Size(37, 16);
            this.labelUseBal.TabIndex = 3085;
            this.labelUseBal.Text = "เหลือ";
            this.labelUseBal.Visible = false;
            // 
            // textboxFormatDoubleUseBal
            // 
            this.textboxFormatDoubleUseBal.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textboxFormatDoubleUseBal.Location = new System.Drawing.Point(0, 57);
            this.textboxFormatDoubleUseBal.Name = "textboxFormatDoubleUseBal";
            this.textboxFormatDoubleUseBal.Size = new System.Drawing.Size(43, 24);
            this.textboxFormatDoubleUseBal.TabIndex = 3084;
            this.textboxFormatDoubleUseBal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textboxFormatDoubleUseBal.Visible = false;
            // 
            // txtCoursID2
            // 
            this.txtCoursID2.Location = new System.Drawing.Point(286, 10);
            this.txtCoursID2.Name = "txtCoursID2";
            this.txtCoursID2.ReadOnly = true;
            this.txtCoursID2.Size = new System.Drawing.Size(93, 23);
            this.txtCoursID2.TabIndex = 3083;
            // 
            // txtCoursID1
            // 
            this.txtCoursID1.Location = new System.Drawing.Point(157, 10);
            this.txtCoursID1.Name = "txtCoursID1";
            this.txtCoursID1.ReadOnly = true;
            this.txtCoursID1.Size = new System.Drawing.Size(126, 23);
            this.txtCoursID1.TabIndex = 3082;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(45, 14);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 16);
            this.label12.TabIndex = 3081;
            this.label12.Text = "Course CardID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(260, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 16);
            this.label7.TabIndex = 280;
            this.label7.Text = "ผู้ใช้/Customer";
            // 
            // comboBoxCommission1
            // 
            this.comboBoxCommission1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxCommission1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBoxCommission1.Location = new System.Drawing.Point(200, 86);
            this.comboBoxCommission1.Name = "comboBoxCommission1";
            this.comboBoxCommission1.Size = new System.Drawing.Size(207, 24);
            this.comboBoxCommission1.TabIndex = 3078;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(43, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "จำนวน/Number";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(158, 93);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 16);
            this.label10.TabIndex = 3079;
            this.label10.Text = "ผู้ดูแล";
            // 
            // txtUseNew
            // 
            this.txtUseNew.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtUseNew.Location = new System.Drawing.Point(48, 57);
            this.txtUseNew.Name = "txtUseNew";
            this.txtUseNew.Size = new System.Drawing.Size(101, 24);
            this.txtUseNew.TabIndex = 6;
            this.txtUseNew.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cboBranch
            // 
            this.cboBranch.BranchId = "";
            this.cboBranch.BranchName = "";
            this.cboBranch.Location = new System.Drawing.Point(413, 87);
            this.cboBranch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(208, 31);
            this.cboBranch.TabIndex = 3077;
            // 
            // dateTimePickerCreate
            // 
            this.dateTimePickerCreate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerCreate.Location = new System.Drawing.Point(155, 58);
            this.dateTimePickerCreate.Name = "dateTimePickerCreate";
            this.dateTimePickerCreate.ShowUpDown = true;
            this.dateTimePickerCreate.Size = new System.Drawing.Size(99, 23);
            this.dateTimePickerCreate.TabIndex = 274;
            this.dateTimePickerCreate.Value = new System.DateTime(2016, 2, 13, 0, 0, 0, 0);
            this.dateTimePickerCreate.ValueChanged += new System.EventHandler(this.dateTimePickerCreate_ValueChanged);
            // 
            // checkBoxSwap
            // 
            this.checkBoxSwap.AutoSize = true;
            this.checkBoxSwap.Location = new System.Drawing.Point(562, 10);
            this.checkBoxSwap.Name = "checkBoxSwap";
            this.checkBoxSwap.Size = new System.Drawing.Size(59, 20);
            this.checkBoxSwap.TabIndex = 287;
            this.checkBoxSwap.Text = "Swap";
            this.checkBoxSwap.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(154, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 16);
            this.label4.TabIndex = 275;
            this.label4.Text = "Date Used";
            // 
            // txtRefMO
            // 
            this.txtRefMO.Location = new System.Drawing.Point(439, 9);
            this.txtRefMO.Name = "txtRefMO";
            this.txtRefMO.Size = new System.Drawing.Size(119, 23);
            this.txtRefMO.TabIndex = 285;
            // 
            // txtUsedName
            // 
            this.txtUsedName.Location = new System.Drawing.Point(380, 58);
            this.txtUsedName.Name = "txtUsedName";
            this.txtUsedName.ReadOnly = true;
            this.txtUsedName.Size = new System.Drawing.Size(212, 23);
            this.txtUsedName.TabIndex = 277;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(592, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 25);
            this.button1.TabIndex = 278;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(386, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 16);
            this.label9.TabIndex = 286;
            this.label9.Text = "Ref.MO";
            // 
            // txtUsedCN
            // 
            this.txtUsedCN.Location = new System.Drawing.Point(260, 58);
            this.txtUsedCN.Name = "txtUsedCN";
            this.txtUsedCN.ReadOnly = true;
            this.txtUsedCN.Size = new System.Drawing.Size(119, 23);
            this.txtUsedCN.TabIndex = 279;
            // 
            // lbCO
            // 
            this.lbCO.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbCO.Location = new System.Drawing.Point(323, -4);
            this.lbCO.Name = "lbCO";
            this.lbCO.Size = new System.Drawing.Size(94, 19);
            this.lbCO.TabIndex = 281;
            this.lbCO.Text = "CO xxx";
            this.lbCO.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(1283, 13);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 29);
            this.btnCancel.TabIndex = 273;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1205, 13);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 29);
            this.btnClose.TabIndex = 271;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1127, 13);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 29);
            this.btnSave.TabIndex = 270;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "chief_of_staff_add_128.png");
            this.imageList1.Images.SetKeyName(1, "chief_of_staff_close_128.png");
            this.imageList1.Images.SetKeyName(2, "chief_of_staff_write_128.png");
            this.imageList1.Images.SetKeyName(3, "remove_icon.png");
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelExpire);
            this.groupBox3.Controls.Add(this.lblCustomerName);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.lblBalance);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.lblAmountUsed);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.lblTotal);
            this.groupBox3.Controls.Add(this.lblSupplie);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(730, 93);
            this.groupBox3.TabIndex = 276;
            this.groupBox3.TabStop = false;
            this.groupBox3.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox3_Paint);
            // 
            // labelExpire
            // 
            this.labelExpire.AutoSize = true;
            this.labelExpire.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelExpire.Location = new System.Drawing.Point(526, 67);
            this.labelExpire.Name = "labelExpire";
            this.labelExpire.Size = new System.Drawing.Size(83, 17);
            this.labelExpire.TabIndex = 7;
            this.labelExpire.Text = "Expire Date ";
            // 
            // panel1Button
            // 
            this.panel1Button.Controls.Add(this.btnToJob);
            this.panel1Button.Controls.Add(this.lbREQ);
            this.panel1Button.Controls.Add(this.pictureBoxREQ);
            this.panel1Button.Controls.Add(this.label11);
            this.panel1Button.Controls.Add(this.txtRemark);
            this.panel1Button.Controls.Add(this.btnSave);
            this.panel1Button.Controls.Add(this.btnClose);
            this.panel1Button.Controls.Add(this.btnCancel);
            this.panel1Button.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1Button.Location = new System.Drawing.Point(0, 620);
            this.panel1Button.Name = "panel1Button";
            this.panel1Button.Size = new System.Drawing.Size(1371, 51);
            this.panel1Button.TabIndex = 277;
            // 
            // btnToJob
            // 
            this.btnToJob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToJob.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnToJob.ForeColor = System.Drawing.Color.Black;
            this.btnToJob.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnToJob.Location = new System.Drawing.Point(1049, 13);
            this.btnToJob.Margin = new System.Windows.Forms.Padding(2);
            this.btnToJob.Name = "btnToJob";
            this.btnToJob.Size = new System.Drawing.Size(78, 29);
            this.btnToJob.TabIndex = 279;
            this.btnToJob.Text = "Save&Job";
            this.btnToJob.UseVisualStyleBackColor = true;
            this.btnToJob.Visible = false;
            this.btnToJob.Click += new System.EventHandler(this.btnToJob_Click);
            // 
            // lbREQ
            // 
            this.lbREQ.AutoSize = true;
            this.lbREQ.Location = new System.Drawing.Point(764, 28);
            this.lbREQ.Name = "lbREQ";
            this.lbREQ.Size = new System.Drawing.Size(49, 16);
            this.lbREQ.TabIndex = 278;
            this.lbREQ.Text = "label10";
            // 
            // pictureBoxREQ
            // 
            this.pictureBoxREQ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxREQ.Image = global::AryuwatSystem.Properties.Resources.EMP_color;
            this.pictureBoxREQ.Location = new System.Drawing.Point(716, 5);
            this.pictureBoxREQ.Name = "pictureBoxREQ";
            this.pictureBoxREQ.Size = new System.Drawing.Size(43, 41);
            this.pictureBoxREQ.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxREQ.TabIndex = 277;
            this.pictureBoxREQ.TabStop = false;
            this.pictureBoxREQ.Click += new System.EventHandler(this.pictureBoxREQ_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(38, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 16);
            this.label11.TabIndex = 276;
            this.label11.Text = "Remark :";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(104, 3);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(600, 45);
            this.txtRemark.TabIndex = 274;
            // 
            // PopMedicalUsed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(229)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(1371, 671);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1Button);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PopMedicalUsed";
            this.ShowIcon = false;
            this.Text = "Course Record";
            this.Load += new System.EventHandler(this.PopMedicalUsed_Load);
            this.Shown += new System.EventHandler(this.PopMedicalUsed_Shown);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsedTrans)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBalManual)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1Button.ResumeLayout(false);
            this.panel1Button.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxREQ)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblSupplie;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAmountUsed;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.DataGridView dgvUsedTrans;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvStaff;
        private UserControls.TextboxFormatDouble txtUseNew;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerCreate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtUsedName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUsedCN;
        private System.Windows.Forms.Label labelExpire;
        private System.Windows.Forms.Label lbCO;
        private System.Windows.Forms.TextBox txtRefMO;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1Button;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkBoxSwap;
        private System.Windows.Forms.PictureBox pictureBoxREQ;
        private System.Windows.Forms.Label lbREQ;
        private System.Windows.Forms.Button btnToJob;
        private UserControls.UBranch cboBranch;
        private System.Windows.Forms.ComboBox comboBoxCommission1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtCoursID1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCoursID2;
        private System.Windows.Forms.Label labelUseBal;
        private UserControls.TextboxFormatDouble textboxFormatDoubleUseBal;
        private System.Windows.Forms.PictureBox picBalManual;
        private UserControls.TextboxFormatDouble txtShot;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnGiftcode;
        private System.Windows.Forms.TextBox txtGiftCode;
        private System.Windows.Forms.Label label14;
    }
}