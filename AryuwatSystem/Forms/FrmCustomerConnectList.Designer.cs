namespace AryuwatSystem.Forms
{
    partial class FrmCustomerConnectList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustomerConnectList));
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonPrint1 = new AryuwatSystem.UserControls.ButtonPrint();
            this.dpDateBooking = new System.Windows.Forms.DateTimePicker();
            this.comboBoxCommission1 = new System.Windows.Forms.ComboBox();
            this.lbCStext = new System.Windows.Forms.Label();
            this.checkBoxDateBooking = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCloseBal = new AryuwatSystem.UserControls.TextboxFormatInteger(this.components);
            this.buttonDelete21 = new AryuwatSystem.UserControls.ButtonDelete2();
            this.buttonSave1 = new AryuwatSystem.UserControls.ButtonSave();
            this.dpDateConnect = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxFrom = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpDateSave = new System.Windows.Forms.DateTimePicker();
            this.txtContactFB_IN_LineID = new System.Windows.Forms.TextBox();
            this.txtInterest = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new AryuwatSystem.UserControls.ButtonRefresh();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonFind = new AryuwatSystem.UserControls.ButtonFind();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDel = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ngbMain = new AryuwatSystem.UserControls.NavigatoBar();
            this.cboBranch = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 205);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvData.RowTemplate.ReadOnly = true;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvData.Size = new System.Drawing.Size(1285, 368);
            this.dgvData.TabIndex = 122;
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            this.dgvData.Sorted += new System.EventHandler(this.dgvData_Sorted);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1285, 180);
            this.groupBox1.TabIndex = 123;
            this.groupBox1.TabStop = false;
            this.groupBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox1_Paint);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.cboBranch);
            this.groupBox3.Controls.Add(this.buttonPrint1);
            this.groupBox3.Controls.Add(this.dpDateBooking);
            this.groupBox3.Controls.Add(this.comboBoxCommission1);
            this.groupBox3.Controls.Add(this.lbCStext);
            this.groupBox3.Controls.Add(this.checkBoxDateBooking);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txtID);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txtCloseBal);
            this.groupBox3.Controls.Add(this.buttonDelete21);
            this.groupBox3.Controls.Add(this.buttonSave1);
            this.groupBox3.Controls.Add(this.dpDateConnect);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtName);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtMobile);
            this.groupBox3.Controls.Add(this.txtRemark);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.comboBoxFrom);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.dateTimePicker1);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.dtpDateSave);
            this.groupBox3.Controls.Add(this.txtContactFB_IN_LineID);
            this.groupBox3.Controls.Add(this.txtInterest);
            this.groupBox3.Location = new System.Drawing.Point(265, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1020, 162);
            this.groupBox3.TabIndex = 71;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "รายละเอียด";
            this.groupBox3.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox3_Paint);
            // 
            // buttonPrint1
            // 
            this.buttonPrint1.BackColor = System.Drawing.Color.Transparent;
            this.buttonPrint1.Location = new System.Drawing.Point(939, 14);
            this.buttonPrint1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonPrint1.Name = "buttonPrint1";
            this.buttonPrint1.Size = new System.Drawing.Size(52, 53);
            this.buttonPrint1.TabIndex = 3075;
            this.buttonPrint1.BtnClick += new AryuwatSystem.UserControls.ButtonPrint.ButtonClick(this.buttonPrint1_BtnClick);
            // 
            // dpDateBooking
            // 
            this.dpDateBooking.CustomFormat = "MMMMdd, yyyy  |  HH:mm";
            this.dpDateBooking.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpDateBooking.Location = new System.Drawing.Point(448, 82);
            this.dpDateBooking.Name = "dpDateBooking";
            this.dpDateBooking.Size = new System.Drawing.Size(214, 23);
            this.dpDateBooking.TabIndex = 308;
            // 
            // comboBoxCommission1
            // 
            this.comboBoxCommission1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxCommission1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBoxCommission1.Location = new System.Drawing.Point(678, 130);
            this.comboBoxCommission1.Name = "comboBoxCommission1";
            this.comboBoxCommission1.Size = new System.Drawing.Size(207, 24);
            this.comboBoxCommission1.TabIndex = 307;
            // 
            // lbCStext
            // 
            this.lbCStext.AutoSize = true;
            this.lbCStext.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lbCStext.Location = new System.Drawing.Point(678, 111);
            this.lbCStext.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCStext.Name = "lbCStext";
            this.lbCStext.Size = new System.Drawing.Size(54, 17);
            this.lbCStext.TabIndex = 80;
            this.lbCStext.Text = "Consult";
            // 
            // checkBoxDateBooking
            // 
            this.checkBoxDateBooking.AutoSize = true;
            this.checkBoxDateBooking.Location = new System.Drawing.Point(448, 66);
            this.checkBoxDateBooking.Name = "checkBoxDateBooking";
            this.checkBoxDateBooking.Size = new System.Drawing.Size(97, 20);
            this.checkBoxDateBooking.TabIndex = 79;
            this.checkBoxDateBooking.Text = "DateBooking";
            this.checkBoxDateBooking.UseVisualStyleBackColor = true;
            this.checkBoxDateBooking.CheckedChanged += new System.EventHandler(this.checkBoxDateBooking_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label13.Location = new System.Drawing.Point(833, 83);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(22, 17);
            this.label13.TabIndex = 78;
            this.label13.Text = "ID";
            this.label13.Visible = false;
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtID.Location = new System.Drawing.Point(863, 80);
            this.txtID.Margin = new System.Windows.Forms.Padding(4);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(128, 24);
            this.txtID.TabIndex = 77;
            this.txtID.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label11.Location = new System.Drawing.Point(588, 23);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 17);
            this.label11.TabIndex = 76;
            this.label11.Text = "ยอดเงิน";
            // 
            // txtCloseBal
            // 
            this.txtCloseBal.Location = new System.Drawing.Point(588, 40);
            this.txtCloseBal.Name = "txtCloseBal";
            this.txtCloseBal.Size = new System.Drawing.Size(83, 23);
            this.txtCloseBal.TabIndex = 8;
            this.txtCloseBal.Text = "0.00";
            this.txtCloseBal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCloseBal.Leave += new System.EventHandler(this.txtCloseBal_Leave);
            // 
            // buttonDelete21
            // 
            this.buttonDelete21.BackColor = System.Drawing.Color.Transparent;
            this.buttonDelete21.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDelete21.Location = new System.Drawing.Point(883, 15);
            this.buttonDelete21.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonDelete21.Name = "buttonDelete21";
            this.buttonDelete21.Size = new System.Drawing.Size(50, 52);
            this.buttonDelete21.TabIndex = 74;
            this.buttonDelete21.BtnClick += new AryuwatSystem.UserControls.ButtonDelete2.ButtonClick(this.buttonDelete21_BtnClick);
            // 
            // buttonSave1
            // 
            this.buttonSave1.BackColor = System.Drawing.Color.Transparent;
            this.buttonSave1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSave1.Location = new System.Drawing.Point(827, 17);
            this.buttonSave1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSave1.Name = "buttonSave1";
            this.buttonSave1.Size = new System.Drawing.Size(50, 52);
            this.buttonSave1.TabIndex = 9;
            this.buttonSave1.BtnClick += new AryuwatSystem.UserControls.ButtonSave.ButtonClick(this.buttonSave1_BtnClick);
            // 
            // dpDateConnect
            // 
            this.dpDateConnect.CustomFormat = "dd-MMM-yyyy";
            this.dpDateConnect.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpDateConnect.Location = new System.Drawing.Point(448, 40);
            this.dpDateConnect.Name = "dpDateConnect";
            this.dpDateConnect.ShowUpDown = true;
            this.dpDateConnect.Size = new System.Drawing.Size(127, 23);
            this.dpDateConnect.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label1.Location = new System.Drawing.Point(16, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtName.Location = new System.Drawing.Point(16, 40);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 24);
            this.txtName.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label5.Location = new System.Drawing.Point(240, 113);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 17);
            this.label5.TabIndex = 65;
            this.label5.Text = "Remark";
            // 
            // txtMobile
            // 
            this.txtMobile.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtMobile.Location = new System.Drawing.Point(240, 40);
            this.txtMobile.Margin = new System.Windows.Forms.Padding(4);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(180, 24);
            this.txtMobile.TabIndex = 1;
            this.txtMobile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMobile_KeyPress);
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtRemark.Location = new System.Drawing.Point(240, 130);
            this.txtRemark.Margin = new System.Windows.Forms.Padding(4);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(431, 24);
            this.txtRemark.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label4.Location = new System.Drawing.Point(240, 23);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Mobile";
            // 
            // comboBoxFrom
            // 
            this.comboBoxFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFrom.FormattingEnabled = true;
            this.comboBoxFrom.Location = new System.Drawing.Point(16, 81);
            this.comboBoxFrom.Name = "comboBoxFrom";
            this.comboBoxFrom.Size = new System.Drawing.Size(198, 24);
            this.comboBoxFrom.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label2.Location = new System.Drawing.Point(16, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contact From";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.CustomFormat = "dd-MMM-yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(1327, 84);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(127, 23);
            this.dateTimePicker1.TabIndex = 62;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label6.Location = new System.Drawing.Point(16, 109);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Interest";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label8.Location = new System.Drawing.Point(445, 24);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 17);
            this.label8.TabIndex = 60;
            this.label8.Text = "Contact Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label7.Location = new System.Drawing.Point(240, 64);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 17);
            this.label7.TabIndex = 56;
            this.label7.Text = "Line ID";
            // 
            // dtpDateSave
            // 
            this.dtpDateSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDateSave.CustomFormat = "dd-MMM-yyyy";
            this.dtpDateSave.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateSave.Location = new System.Drawing.Point(1327, 41);
            this.dtpDateSave.Name = "dtpDateSave";
            this.dtpDateSave.ShowUpDown = true;
            this.dtpDateSave.Size = new System.Drawing.Size(127, 23);
            this.dtpDateSave.TabIndex = 59;
            // 
            // txtContactFB_IN_LineID
            // 
            this.txtContactFB_IN_LineID.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtContactFB_IN_LineID.Location = new System.Drawing.Point(240, 81);
            this.txtContactFB_IN_LineID.Margin = new System.Windows.Forms.Padding(4);
            this.txtContactFB_IN_LineID.Name = "txtContactFB_IN_LineID";
            this.txtContactFB_IN_LineID.Size = new System.Drawing.Size(180, 24);
            this.txtContactFB_IN_LineID.TabIndex = 3;
            // 
            // txtInterest
            // 
            this.txtInterest.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtInterest.Location = new System.Drawing.Point(16, 130);
            this.txtInterest.Margin = new System.Windows.Forms.Padding(4);
            this.txtInterest.Name = "txtInterest";
            this.txtInterest.Size = new System.Drawing.Size(201, 24);
            this.txtInterest.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRefresh);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.dateTimePickerEnd);
            this.groupBox2.Controls.Add(this.dateTimePickerStart);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.buttonFind);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(235, 162);
            this.groupBox2.TabIndex = 70;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ค้นหา";
            this.groupBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox2_Paint);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.Location = new System.Drawing.Point(154, 76);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 17, 3, 17);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(58, 50);
            this.btnRefresh.TabIndex = 128;
            this.btnRefresh.BtnClick += new AryuwatSystem.UserControls.ButtonRefresh.ButtonClick(this.btnRefresh_BtnClick_1);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label10.Location = new System.Drawing.Point(7, 23);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(133, 17);
            this.label10.TabIndex = 67;
            this.label10.Text = "Contact Date Start :";
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.CustomFormat = "dd-MMM-yyyy";
            this.dateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(10, 99);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.ShowUpDown = true;
            this.dateTimePickerEnd.Size = new System.Drawing.Size(127, 23);
            this.dateTimePickerEnd.TabIndex = 69;
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.CustomFormat = "dd-MMM-yyyy";
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStart.Location = new System.Drawing.Point(10, 40);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.ShowUpDown = true;
            this.dateTimePickerStart.Size = new System.Drawing.Size(127, 23);
            this.dateTimePickerStart.TabIndex = 66;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label3.Location = new System.Drawing.Point(7, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 17);
            this.label3.TabIndex = 68;
            this.label3.Text = "Contact Date End :";
            // 
            // buttonFind
            // 
            this.buttonFind.AutoSize = true;
            this.buttonFind.BackColor = System.Drawing.Color.Transparent;
            this.buttonFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFind.Location = new System.Drawing.Point(162, 23);
            this.buttonFind.Margin = new System.Windows.Forms.Padding(3, 11, 3, 11);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(50, 53);
            this.buttonFind.TabIndex = 4;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEdit,
            this.menuDel,
            this.menuPreview});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(162, 70);
            // 
            // menuEdit
            // 
            this.menuEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(161, 22);
            this.menuEdit.Text = "แก้ไขข้อมูล";
            // 
            // menuDel
            // 
            this.menuDel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.menuDel.Name = "menuDel";
            this.menuDel.Size = new System.Drawing.Size(161, 22);
            this.menuDel.Text = "ลบข้อมูล";
            // 
            // menuPreview
            // 
            this.menuPreview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.menuPreview.Name = "menuPreview";
            this.menuPreview.Size = new System.Drawing.Size(161, 22);
            this.menuPreview.Text = "ดูรายการข้อมูล";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtFilter);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 180);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1285, 25);
            this.panel2.TabIndex = 134;
            // 
            // txtFilter
            // 
            this.txtFilter.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtFilter.Location = new System.Drawing.Point(58, 1);
            this.txtFilter.Margin = new System.Windows.Forms.Padding(4);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(158, 24);
            this.txtFilter.TabIndex = 55;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(2, 4);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 18);
            this.label12.TabIndex = 59;
            this.label12.Text = "Filter :";
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
            this.ngbMain.Location = new System.Drawing.Point(0, 573);
            this.ngbMain.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.ngbMain.Name = "ngbMain";
            this.ngbMain.Size = new System.Drawing.Size(1285, 26);
            this.ngbMain.TabIndex = 124;
            this.ngbMain.TotalPage = ((long)(0));
            this.ngbMain.TotalRecord = ((long)(0));
            // 
            // cboBranch
            // 
            this.cboBranch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBranch.Location = new System.Drawing.Point(668, 80);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(217, 24);
            this.cboBranch.TabIndex = 3077;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label9.Location = new System.Drawing.Point(665, 63);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 17);
            this.label9.TabIndex = 3078;
            this.label9.Text = "Book สาขา";
            // 
            // FrmCustomerConnectList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 599);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ngbMain);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmCustomerConnectList";
            this.Text = "CustomerConnectList";
            this.Activated += new System.EventHandler(this.FrmCustomerConnectList_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCustomerConnectList_FormClosing);
            this.Load += new System.EventHandler(this.FrmCustomerConnectList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.GroupBox groupBox1;
        private UserControls.ButtonFind buttonFind;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private UserControls.NavigatoBar ngbMain;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripMenuItem menuDel;
        private System.Windows.Forms.ToolStripMenuItem menuPreview;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtInterest;
        private System.Windows.Forms.TextBox txtContactFB_IN_LineID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.ComboBox comboBoxFrom;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpDateSave;
        private System.Windows.Forms.GroupBox groupBox3;
        private UserControls.ButtonSave buttonSave1;
        private System.Windows.Forms.DateTimePicker dpDateConnect;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.Label label3;
        private UserControls.ButtonDelete2 buttonDelete21;
        private System.Windows.Forms.Label label11;
        private UserControls.TextboxFormatInteger txtCloseBal;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.CheckBox checkBoxDateBooking;
        private System.Windows.Forms.Label lbCStext;
        private UserControls.ButtonRefresh btnRefresh;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.ComboBox comboBoxCommission1;
        private UserControls.ButtonPrint buttonPrint1;
        private System.Windows.Forms.DateTimePicker dpDateBooking;
        private System.Windows.Forms.ComboBox cboBranch;
        private System.Windows.Forms.Label label9;


    }
}