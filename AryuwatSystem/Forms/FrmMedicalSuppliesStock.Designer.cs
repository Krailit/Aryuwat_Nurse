namespace AryuwatSystem.Forms
{
    partial class FrmMedicalSuppliesStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMedicalSuppliesStock));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.pictureBoxFind = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFindName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFindCode = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDel = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cboSubUnit = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpExpDate = new System.Windows.Forms.DateTimePicker();
            this.txtCodeRef = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cboLocation = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.checkBoxActive = new System.Windows.Forms.CheckBox();
            this.cboBranch = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.checkBoxVat = new System.Windows.Forms.CheckBox();
            this.picImport = new System.Windows.Forms.PictureBox();
            this.cboSection = new System.Windows.Forms.ComboBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDetail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboMainUnit = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbNC = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label14 = new System.Windows.Forms.Label();
            this.ngbMain = new AryuwatSystem.UserControls.NavigatoBar();
            this.uBranch1 = new AryuwatSystem.UserControls.UBranch();
            this.buttonFind = new AryuwatSystem.UserControls.ButtonFind();
            this.txtAnountPerMainUnit = new AryuwatSystem.UserControls.TextboxFormatDouble(this.components);
            this.btnRefresh = new AryuwatSystem.UserControls.ButtonRefresh();
            this.txtNC = new AryuwatSystem.UserControls.TextboxFormatInteger(this.components);
            this.buttonSave = new AryuwatSystem.UserControls.ButtonSave();
            this.txtCLPrice = new AryuwatSystem.UserControls.TextboxFormatDouble(this.components);
            this.txtMinStock = new AryuwatSystem.UserControls.TextboxFormatDouble(this.components);
            this.txtInstock = new AryuwatSystem.UserControls.TextboxFormatDouble(this.components);
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFind)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.buttonFind);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.groupBox1.Location = new System.Drawing.Point(0, 194);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1201, 56);
            this.groupBox1.TabIndex = 126;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ค้นหา";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.uBranch1);
            this.panel1.Controls.Add(this.pictureBoxFind);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtFindName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtFindCode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1193, 28);
            this.panel1.TabIndex = 6;
            // 
            // btnExport
            // 
            this.btnExport.BackgroundImage = global::AryuwatSystem.Properties.Resources.recover_excel_files;
            this.btnExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExport.Location = new System.Drawing.Point(487, -3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(36, 35);
            this.btnExport.TabIndex = 3080;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // pictureBoxFind
            // 
            this.pictureBoxFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxFind.Image = global::AryuwatSystem.Properties.Resources.examine_256;
            this.pictureBoxFind.Location = new System.Drawing.Point(445, 3);
            this.pictureBoxFind.Name = "pictureBoxFind";
            this.pictureBoxFind.Size = new System.Drawing.Size(36, 25);
            this.pictureBoxFind.TabIndex = 6;
            this.pictureBoxFind.TabStop = false;
            this.pictureBoxFind.Click += new System.EventHandler(this.pictureBoxFind_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label4.Location = new System.Drawing.Point(197, 7);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 21);
            this.label4.TabIndex = 2;
            this.label4.Text = "Name :";
            // 
            // txtFindName
            // 
            this.txtFindName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtFindName.Location = new System.Drawing.Point(249, 3);
            this.txtFindName.Margin = new System.Windows.Forms.Padding(4);
            this.txtFindName.Name = "txtFindName";
            this.txtFindName.Size = new System.Drawing.Size(189, 28);
            this.txtFindName.TabIndex = 1;
            this.txtFindName.TextChanged += new System.EventHandler(this.txtFindName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label3.Location = new System.Drawing.Point(-1, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Code :";
            // 
            // txtFindCode
            // 
            this.txtFindCode.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtFindCode.Location = new System.Drawing.Point(48, 3);
            this.txtFindCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtFindCode.Name = "txtFindCode";
            this.txtFindCode.Size = new System.Drawing.Size(149, 28);
            this.txtFindCode.TabIndex = 0;
            this.txtFindCode.TextChanged += new System.EventHandler(this.txtFindCode_TextChanged);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 500;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEdit,
            this.menuDel,
            this.menuPreview});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 82);
            // 
            // menuEdit
            // 
            this.menuEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(180, 26);
            this.menuEdit.Text = "แก้ไขข้อมูล";
            // 
            // menuDel
            // 
            this.menuDel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.menuDel.Name = "menuDel";
            this.menuDel.Size = new System.Drawing.Size(180, 26);
            this.menuDel.Text = "ลบข้อมูล";
            // 
            // menuPreview
            // 
            this.menuPreview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.menuPreview.Name = "menuPreview";
            this.menuPreview.Size = new System.Drawing.Size(180, 26);
            this.menuPreview.Text = "ดูรายการข้อมูล";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtAnountPerMainUnit);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.cboSubUnit);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.dtpExpDate);
            this.groupBox2.Controls.Add(this.txtCodeRef);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.cboLocation);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.checkBoxActive);
            this.groupBox2.Controls.Add(this.cboBranch);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.checkBoxVat);
            this.groupBox2.Controls.Add(this.btnRefresh);
            this.groupBox2.Controls.Add(this.txtNC);
            this.groupBox2.Controls.Add(this.picImport);
            this.groupBox2.Controls.Add(this.cboSection);
            this.groupBox2.Controls.Add(this.txtCode);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.buttonSave);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtDetail);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cboMainUnit);
            this.groupBox2.Controls.Add(this.txtCLPrice);
            this.groupBox2.Controls.Add(this.txtMinStock);
            this.groupBox2.Controls.Add(this.txtInstock);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.lbNC);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1201, 194);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "บันทึกข้อมูล";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label13.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label13.Location = new System.Drawing.Point(583, 90);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(167, 21);
            this.label13.TabIndex = 57;
            this.label13.Text = "เช่น 12 อัน ต่อ 1 กล่อง";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label12.Location = new System.Drawing.Point(583, 66);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(158, 21);
            this.label12.TabIndex = 56;
            this.label12.Text = "จำนวนต่อหน่วยใหญ่ :";
            // 
            // cboSubUnit
            // 
            this.cboSubUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubUnit.FormattingEnabled = true;
            this.cboSubUnit.Location = new System.Drawing.Point(720, 39);
            this.cboSubUnit.Name = "cboSubUnit";
            this.cboSubUnit.Size = new System.Drawing.Size(114, 25);
            this.cboSubUnit.TabIndex = 53;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label10.Location = new System.Drawing.Point(652, 39);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 21);
            this.label10.TabIndex = 54;
            this.label10.Text = "SubUnit :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label8.Location = new System.Drawing.Point(930, 107);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 21);
            this.label8.TabIndex = 52;
            this.label8.Text = "วันหมดอายุ :";
            // 
            // dtpExpDate
            // 
            this.dtpExpDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpExpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExpDate.Location = new System.Drawing.Point(1035, 105);
            this.dtpExpDate.Name = "dtpExpDate";
            this.dtpExpDate.ShowUpDown = true;
            this.dtpExpDate.Size = new System.Drawing.Size(108, 23);
            this.dtpExpDate.TabIndex = 51;
            // 
            // txtCodeRef
            // 
            this.txtCodeRef.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtCodeRef.Location = new System.Drawing.Point(142, 50);
            this.txtCodeRef.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodeRef.Name = "txtCodeRef";
            this.txtCodeRef.Size = new System.Drawing.Size(172, 28);
            this.txtCodeRef.TabIndex = 48;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label20.Location = new System.Drawing.Point(72, 54);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(88, 21);
            this.label20.TabIndex = 49;
            this.label20.Text = "Code Ref :";
            // 
            // cboLocation
            // 
            this.cboLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocation.FormattingEnabled = true;
            this.cboLocation.Location = new System.Drawing.Point(553, 158);
            this.cboLocation.Name = "cboLocation";
            this.cboLocation.Size = new System.Drawing.Size(114, 25);
            this.cboLocation.TabIndex = 46;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label19.Location = new System.Drawing.Point(476, 162);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(87, 21);
            this.label19.TabIndex = 47;
            this.label19.Text = "คลังสินค้า :";
            // 
            // checkBoxActive
            // 
            this.checkBoxActive.AutoSize = true;
            this.checkBoxActive.Checked = true;
            this.checkBoxActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.checkBoxActive.Location = new System.Drawing.Point(934, 136);
            this.checkBoxActive.Name = "checkBoxActive";
            this.checkBoxActive.Size = new System.Drawing.Size(94, 29);
            this.checkBoxActive.TabIndex = 45;
            this.checkBoxActive.Text = "Active";
            this.checkBoxActive.UseVisualStyleBackColor = true;
            // 
            // cboBranch
            // 
            this.cboBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBranch.FormattingEnabled = true;
            this.cboBranch.Location = new System.Drawing.Point(299, 158);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(172, 25);
            this.cboBranch.TabIndex = 41;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label18.Location = new System.Drawing.Point(242, 162);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(72, 21);
            this.label18.TabIndex = 42;
            this.label18.Text = "Branch :";
            // 
            // checkBoxVat
            // 
            this.checkBoxVat.AutoSize = true;
            this.checkBoxVat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.checkBoxVat.Location = new System.Drawing.Point(14, 81);
            this.checkBoxVat.Name = "checkBoxVat";
            this.checkBoxVat.Size = new System.Drawing.Size(59, 24);
            this.checkBoxVat.TabIndex = 36;
            this.checkBoxVat.Text = "Vat";
            this.checkBoxVat.UseVisualStyleBackColor = true;
            this.checkBoxVat.Visible = false;
            // 
            // picImport
            // 
            this.picImport.BackColor = System.Drawing.Color.Transparent;
            this.picImport.Image = global::AryuwatSystem.Properties.Resources.Import1;
            this.picImport.Location = new System.Drawing.Point(12, 129);
            this.picImport.Name = "picImport";
            this.picImport.Size = new System.Drawing.Size(53, 50);
            this.picImport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImport.TabIndex = 26;
            this.picImport.TabStop = false;
            this.picImport.Visible = false;
            // 
            // cboSection
            // 
            this.cboSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSection.FormattingEnabled = true;
            this.cboSection.Items.AddRange(new object[] {
            "Hair"});
            this.cboSection.Location = new System.Drawing.Point(142, 158);
            this.cboSection.Name = "cboSection";
            this.cboSection.Size = new System.Drawing.Size(100, 25);
            this.cboSection.TabIndex = 24;
            // 
            // txtCode
            // 
            this.txtCode.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtCode.Location = new System.Drawing.Point(142, 20);
            this.txtCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(172, 28);
            this.txtCode.TabIndex = 6;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtName.Location = new System.Drawing.Point(375, 21);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 48);
            this.txtName.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label2.Location = new System.Drawing.Point(323, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 21);
            this.label2.TabIndex = 8;
            this.label2.Text = "Name :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label1.Location = new System.Drawing.Point(62, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 21);
            this.label1.TabIndex = 9;
            this.label1.Text = "Clinic Code :";
            // 
            // txtDetail
            // 
            this.txtDetail.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtDetail.Location = new System.Drawing.Point(142, 80);
            this.txtDetail.Margin = new System.Windows.Forms.Padding(4);
            this.txtDetail.Multiline = true;
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.Size = new System.Drawing.Size(433, 42);
            this.txtDetail.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label5.Location = new System.Drawing.Point(95, 79);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 21);
            this.label5.TabIndex = 11;
            this.label5.Text = "Detail :";
            // 
            // cboMainUnit
            // 
            this.cboMainUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMainUnit.FormattingEnabled = true;
            this.cboMainUnit.Location = new System.Drawing.Point(720, 12);
            this.cboMainUnit.Name = "cboMainUnit";
            this.cboMainUnit.Size = new System.Drawing.Size(114, 25);
            this.cboMainUnit.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label7.Location = new System.Drawing.Point(709, 136);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 21);
            this.label7.TabIndex = 16;
            this.label7.Text = "จำนวนคงเหลือ :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label6.Location = new System.Drawing.Point(717, 110);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 21);
            this.label6.TabIndex = 15;
            this.label6.Text = "ราคาต่อหน่วย :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label11.Location = new System.Drawing.Point(80, 162);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 21);
            this.label11.TabIndex = 25;
            this.label11.Text = "Section :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label9.Location = new System.Drawing.Point(652, 12);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 21);
            this.label9.TabIndex = 19;
            this.label9.Text = "MainUnit :";
            // 
            // lbNC
            // 
            this.lbNC.AutoSize = true;
            this.lbNC.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lbNC.Location = new System.Drawing.Point(1058, 56);
            this.lbNC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNC.Name = "lbNC";
            this.lbNC.Size = new System.Drawing.Size(137, 21);
            this.lbNC.TabIndex = 28;
            this.lbNC.Text = "Number/Course :";
            this.lbNC.Visible = false;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvData.ColumnHeadersHeight = 29;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 250);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersWidth = 51;
            this.dgvData.RowTemplate.ReadOnly = true;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvData.Size = new System.Drawing.Size(1201, 250);
            this.dgvData.TabIndex = 128;
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            this.dgvData.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvData_RowPostPaint);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label14.Location = new System.Drawing.Point(673, 163);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(159, 21);
            this.label14.TabIndex = 16;
            this.label14.Text = "จำนวนคงเหลือขั้นต่ำ :";
            // 
            // ngbMain
            // 
            this.ngbMain.CanMoveFirst = true;
            this.ngbMain.CanMoveLast = true;
            this.ngbMain.CanMoveNext = true;
            this.ngbMain.CanMovePrevious = true;
            this.ngbMain.CurrentPage = ((long)(0));
            this.ngbMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ngbMain.Enableds = false;
            this.ngbMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ngbMain.Location = new System.Drawing.Point(0, 500);
            this.ngbMain.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.ngbMain.Name = "ngbMain";
            this.ngbMain.Size = new System.Drawing.Size(1201, 26);
            this.ngbMain.TabIndex = 127;
            this.ngbMain.TotalPage = ((long)(0));
            this.ngbMain.TotalRecord = ((long)(0));
            this.ngbMain.Visible = false;
            // 
            // uBranch1
            // 
            this.uBranch1.BranchId = "";
            this.uBranch1.BranchName = "";
            this.uBranch1.Location = new System.Drawing.Point(1316, -1);
            this.uBranch1.Margin = new System.Windows.Forms.Padding(3, 140, 3, 140);
            this.uBranch1.Name = "uBranch1";
            this.uBranch1.Size = new System.Drawing.Size(630, 140);
            this.uBranch1.TabIndex = 57;
            // 
            // buttonFind
            // 
            this.buttonFind.AutoSize = true;
            this.buttonFind.BackColor = System.Drawing.Color.Transparent;
            this.buttonFind.Location = new System.Drawing.Point(25243, 604);
            this.buttonFind.Margin = new System.Windows.Forms.Padding(0);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(4887, 12515);
            this.buttonFind.TabIndex = 4;
            this.buttonFind.BtnClick += new AryuwatSystem.UserControls.ButtonFind.ButtonClick(this.buttonFind_BtnClick);
            // 
            // txtAnountPerMainUnit
            // 
            this.txtAnountPerMainUnit.Location = new System.Drawing.Point(720, 66);
            this.txtAnountPerMainUnit.Name = "txtAnountPerMainUnit";
            this.txtAnountPerMainUnit.Size = new System.Drawing.Size(114, 23);
            this.txtAnountPerMainUnit.TabIndex = 55;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.Location = new System.Drawing.Point(877, 18);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(63, 85);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.BtnClick += new AryuwatSystem.UserControls.ButtonRefresh.ButtonClick(this.btnRefresh_BtnClick);
            // 
            // txtNC
            // 
            this.txtNC.Location = new System.Drawing.Point(1061, 76);
            this.txtNC.Name = "txtNC";
            this.txtNC.Size = new System.Drawing.Size(131, 23);
            this.txtNC.TabIndex = 27;
            this.txtNC.Visible = false;
            // 
            // buttonSave
            // 
            this.buttonSave.AutoSize = true;
            this.buttonSave.BackColor = System.Drawing.Color.Transparent;
            this.buttonSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSave.Location = new System.Drawing.Point(941, 19);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(47, 66);
            this.buttonSave.TabIndex = 22;
            this.toolTip1.SetToolTip(this.buttonSave, "Save");
            this.buttonSave.BtnClick += new AryuwatSystem.UserControls.ButtonSave.ButtonClick(this.buttonSave_BtnClick);
            // 
            // txtCLPrice
            // 
            this.txtCLPrice.Location = new System.Drawing.Point(830, 110);
            this.txtCLPrice.Name = "txtCLPrice";
            this.txtCLPrice.Size = new System.Drawing.Size(60, 23);
            this.txtCLPrice.TabIndex = 12;
            // 
            // txtMinStock
            // 
            this.txtMinStock.Location = new System.Drawing.Point(830, 163);
            this.txtMinStock.Name = "txtMinStock";
            this.txtMinStock.Size = new System.Drawing.Size(60, 23);
            this.txtMinStock.TabIndex = 13;
            // 
            // txtInstock
            // 
            this.txtInstock.Location = new System.Drawing.Point(830, 136);
            this.txtInstock.Name = "txtInstock";
            this.txtInstock.Size = new System.Drawing.Size(60, 23);
            this.txtInstock.TabIndex = 13;
            // 
            // FrmMedicalSuppliesStock
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1201, 526);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.ngbMain);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMedicalSuppliesStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Medical Supplies Stock";
            this.Load += new System.EventHandler(this.FrmMedicalSuppliesStock_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFind)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.NavigatoBar ngbMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private UserControls.ButtonFind buttonFind;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFindCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFindName;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripMenuItem menuDel;
        private System.Windows.Forms.ToolStripMenuItem menuPreview;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxActive;
        private System.Windows.Forms.ComboBox cboBranch;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.CheckBox checkBoxVat;
        private UserControls.ButtonRefresh btnRefresh;
        private UserControls.TextboxFormatInteger txtNC;
        private System.Windows.Forms.PictureBox picImport;
        private System.Windows.Forms.ComboBox cboSection;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtName;
        private UserControls.ButtonSave buttonSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDetail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboMainUnit;
        private UserControls.TextboxFormatDouble txtCLPrice;
        private UserControls.TextboxFormatDouble txtInstock;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbNC;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.ComboBox cboLocation;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxFind;
        private UserControls.UBranch uBranch1;
        private System.Windows.Forms.TextBox txtCodeRef;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpExpDate;
        private System.Windows.Forms.ComboBox cboSubUnit;
        private System.Windows.Forms.Label label10;
        private UserControls.TextboxFormatDouble txtAnountPerMainUnit;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private UserControls.TextboxFormatDouble txtMinStock;
        private System.Windows.Forms.Label label14;
    }
}