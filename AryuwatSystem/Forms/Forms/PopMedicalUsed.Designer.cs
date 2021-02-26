namespace DermasterSystem.Forms
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
            this.label10 = new System.Windows.Forms.Label();
            this.lbCO = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUsedCN = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtUsedName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerCreate = new System.Windows.Forms.DateTimePicker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dgvStaff = new System.Windows.Forms.DataGridView();
            this.txtUseNew = new DermasterSystem.UserControls.TextboxFormatDouble(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtRefMO = new System.Windows.Forms.TextBox();
            this.labelExpire = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cachedRptSummaryTherapist1 = new DermasterSystem.Reports.CachedRptSummaryTherapist();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsedTrans)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(21, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "ชื่อลูกค้า :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(30, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "รายการ :";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblCustomerName.Location = new System.Drawing.Point(94, 19);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(168, 19);
            this.lblCustomerName.TabIndex = 1;
            this.lblCustomerName.Text = "[lblCustomerName]";
            // 
            // lblSupplie
            // 
            this.lblSupplie.AutoSize = true;
            this.lblSupplie.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblSupplie.Location = new System.Drawing.Point(94, 49);
            this.lblSupplie.Name = "lblSupplie";
            this.lblSupplie.Size = new System.Drawing.Size(103, 19);
            this.lblSupplie.TabIndex = 1;
            this.lblSupplie.Text = "[lblSupplie]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(664, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "จำนวนทั้งหมด/Total";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblTotal.Location = new System.Drawing.Point(809, 19);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(49, 19);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "xxxx";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvUsedTrans);
            this.groupBox1.Location = new System.Drawing.Point(12, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(556, 443);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ประวัติการใช้";
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
            this.dgvUsedTrans.Size = new System.Drawing.Size(550, 421);
            this.dgvUsedTrans.TabIndex = 149;
            this.dgvUsedTrans.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsedTrans_CellContentClick);
            this.dgvUsedTrans.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvUsedTrans_CellMouseMove);
            this.dgvUsedTrans.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvUsedTrans_RowPostPaint);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(858, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "ใช้ไปแล้ว/Used";
            // 
            // lblAmountUsed
            // 
            this.lblAmountUsed.AutoSize = true;
            this.lblAmountUsed.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblAmountUsed.Location = new System.Drawing.Point(970, 19);
            this.lblAmountUsed.Name = "lblAmountUsed";
            this.lblAmountUsed.Size = new System.Drawing.Size(49, 19);
            this.lblAmountUsed.TabIndex = 1;
            this.lblAmountUsed.Text = "xxxx";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.Location = new System.Drawing.Point(1019, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 19);
            this.label8.TabIndex = 0;
            this.label8.Text = "คงเหลือ/Balance";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblBalance.Location = new System.Drawing.Point(1140, 19);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(49, 19);
            this.lblBalance.TabIndex = 1;
            this.lblBalance.Text = "xxxx";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lbCO);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtUsedCN);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.txtUsedName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dateTimePickerCreate);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.dgvStaff);
            this.groupBox2.Controls.Add(this.txtUseNew);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(574, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(641, 443);
            this.groupBox2.TabIndex = 275;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "บันทึกการใช้";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label10.Location = new System.Drawing.Point(286, 1);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 19);
            this.label10.TabIndex = 282;
            this.label10.Text = "CO :";
            // 
            // lbCO
            // 
            this.lbCO.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbCO.Location = new System.Drawing.Point(330, 1);
            this.lbCO.Name = "lbCO";
            this.lbCO.Size = new System.Drawing.Size(133, 19);
            this.lbCO.TabIndex = 281;
            this.lbCO.Text = "xxxx";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(286, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 19);
            this.label7.TabIndex = 280;
            this.label7.Text = "ผู้ใช้/Customer";
            // 
            // txtUsedCN
            // 
            this.txtUsedCN.Location = new System.Drawing.Point(290, 47);
            this.txtUsedCN.Name = "txtUsedCN";
            this.txtUsedCN.ReadOnly = true;
            this.txtUsedCN.Size = new System.Drawing.Size(93, 23);
            this.txtUsedCN.TabIndex = 279;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(553, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 25);
            this.button1.TabIndex = 278;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtUsedName
            // 
            this.txtUsedName.Location = new System.Drawing.Point(384, 47);
            this.txtUsedName.Name = "txtUsedName";
            this.txtUsedName.ReadOnly = true;
            this.txtUsedName.Size = new System.Drawing.Size(170, 23);
            this.txtUsedName.TabIndex = 277;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(138, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 275;
            this.label4.Text = "Date :";
            // 
            // dateTimePickerCreate
            // 
            this.dateTimePickerCreate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerCreate.Location = new System.Drawing.Point(136, 47);
            this.dateTimePickerCreate.Name = "dateTimePickerCreate";
            this.dateTimePickerCreate.ShowUpDown = true;
            this.dateTimePickerCreate.Size = new System.Drawing.Size(99, 23);
            this.dateTimePickerCreate.TabIndex = 274;
            this.dateTimePickerCreate.Value = new System.DateTime(2016, 2, 13, 0, 0, 0, 0);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnCancel.ForeColor = System.Drawing.Color.DimGray;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(412, 407);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 31);
            this.btnCancel.TabIndex = 273;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dgvStaff
            // 
            this.dgvStaff.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStaff.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvStaff.BackgroundColor = System.Drawing.Color.White;
            this.dgvStaff.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvStaff.Location = new System.Drawing.Point(6, 83);
            this.dgvStaff.Name = "dgvStaff";
            this.dgvStaff.RowTemplate.ReadOnly = true;
            this.dgvStaff.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStaff.Size = new System.Drawing.Size(630, 319);
            this.dgvStaff.TabIndex = 272;
            this.dgvStaff.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStaff_CellContentClick);
            this.dgvStaff.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvStaff_RowPostPaint);
            // 
            // txtUseNew
            // 
            this.txtUseNew.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtUseNew.Location = new System.Drawing.Point(39, 47);
            this.txtUseNew.Name = "txtUseNew";
            this.txtUseNew.Size = new System.Drawing.Size(70, 24);
            this.txtUseNew.TabIndex = 6;
            this.txtUseNew.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnClose.ForeColor = System.Drawing.Color.DimGray;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(525, 407);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(111, 31);
            this.btnClose.TabIndex = 271;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnSave.ForeColor = System.Drawing.Color.DimGray;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(299, 407);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 31);
            this.btnSave.TabIndex = 270;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(1, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 19);
            this.label5.TabIndex = 5;
            this.label5.Text = "จำนวน/Number";
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
            this.groupBox3.Controls.Add(this.txtRefMO);
            this.groupBox3.Controls.Add(this.labelExpire);
            this.groupBox3.Controls.Add(this.label9);
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
            this.groupBox3.Size = new System.Drawing.Size(1225, 80);
            this.groupBox3.TabIndex = 276;
            this.groupBox3.TabStop = false;
            // 
            // txtRefMO
            // 
            this.txtRefMO.Location = new System.Drawing.Point(1061, 46);
            this.txtRefMO.Name = "txtRefMO";
            this.txtRefMO.Size = new System.Drawing.Size(128, 23);
            this.txtRefMO.TabIndex = 285;
            // 
            // labelExpire
            // 
            this.labelExpire.AutoSize = true;
            this.labelExpire.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelExpire.Location = new System.Drawing.Point(688, 49);
            this.labelExpire.Name = "labelExpire";
            this.labelExpire.Size = new System.Drawing.Size(101, 19);
            this.labelExpire.TabIndex = 7;
            this.labelExpire.Text = "Expire Date :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label9.Location = new System.Drawing.Point(920, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 19);
            this.label9.TabIndex = 286;
            this.label9.Text = "อ้างอิงใบยา Ref.MO";
            // 
            // PopMedicalUsed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(232)))), ((int)(((byte)(229)))));
            this.ClientSize = new System.Drawing.Size(1225, 543);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PopMedicalUsed";
            this.Text = "ข้อมูลการใช้";
            this.Load += new System.EventHandler(this.PopMedicalUsed_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsedTrans)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private Reports.CachedRptSummaryTherapist cachedRptSummaryTherapist1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerCreate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtUsedName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUsedCN;
        private System.Windows.Forms.Label labelExpire;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbCO;
        private System.Windows.Forms.TextBox txtRefMO;
        private System.Windows.Forms.Label label9;
    }
}