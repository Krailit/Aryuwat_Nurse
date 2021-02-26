namespace AryuwatSystem.Forms
{
    partial class FrmCommissionCheck
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCommissionCheck));
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxYears = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxPeriod = new System.Windows.Forms.ComboBox();
            this.labelMonth = new System.Windows.Forms.Label();
            this.txtStartdate = new System.Windows.Forms.TextBox();
            this.txtEnddate = new System.Windows.Forms.TextBox();
            this.radioButtonSale = new System.Windows.Forms.RadioButton();
            this.radioButtonFee = new System.Windows.Forms.RadioButton();
            this.lblComRate = new System.Windows.Forms.Label();
            this.labelbathtext = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCom1 = new System.Windows.Forms.Label();
            this.lblMoney1 = new System.Windows.Forms.Label();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.lblEN = new System.Windows.Forms.Label();
            this.dtpDateEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpDateStart = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFindEMP = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.dataGridViewSummary = new System.Windows.Forms.DataGridView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.buttonExport1 = new AryuwatSystem.UserControls.ButtonExport();
            this.txtCommoney = new AryuwatSystem.UserControls.TextboxFormatDouble(this.components);
            this.txtMoney = new AryuwatSystem.UserControls.TextboxFormatDouble(this.components);
            this.buttonFind = new AryuwatSystem.UserControls.ButtonFind();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSummary)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonExport1);
            this.panel1.Controls.Add(this.comboBoxYears);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.comboBoxPeriod);
            this.panel1.Controls.Add(this.labelMonth);
            this.panel1.Controls.Add(this.txtStartdate);
            this.panel1.Controls.Add(this.txtEnddate);
            this.panel1.Controls.Add(this.radioButtonSale);
            this.panel1.Controls.Add(this.radioButtonFee);
            this.panel1.Controls.Add(this.txtCommoney);
            this.panel1.Controls.Add(this.txtMoney);
            this.panel1.Controls.Add(this.lblComRate);
            this.panel1.Controls.Add(this.labelbathtext);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblCom1);
            this.panel1.Controls.Add(this.lblMoney1);
            this.panel1.Controls.Add(this.lblEmployeeName);
            this.panel1.Controls.Add(this.lblEN);
            this.panel1.Controls.Add(this.buttonFind);
            this.panel1.Controls.Add(this.dtpDateEnd);
            this.panel1.Controls.Add(this.dtpDateStart);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnFindEMP);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1177, 81);
            this.panel1.TabIndex = 0;
            // 
            // comboBoxYears
            // 
            this.comboBoxYears.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxYears.FormattingEnabled = true;
            this.comboBoxYears.Location = new System.Drawing.Point(374, 17);
            this.comboBoxYears.Name = "comboBoxYears";
            this.comboBoxYears.Size = new System.Drawing.Size(147, 21);
            this.comboBoxYears.TabIndex = 75;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label6.Location = new System.Drawing.Point(327, 22);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 17);
            this.label6.TabIndex = 76;
            this.label6.Text = "Years :";
            // 
            // comboBoxPeriod
            // 
            this.comboBoxPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPeriod.FormattingEnabled = true;
            this.comboBoxPeriod.Location = new System.Drawing.Point(374, 44);
            this.comboBoxPeriod.Name = "comboBoxPeriod";
            this.comboBoxPeriod.Size = new System.Drawing.Size(147, 21);
            this.comboBoxPeriod.TabIndex = 74;
            // 
            // labelMonth
            // 
            this.labelMonth.AutoSize = true;
            this.labelMonth.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelMonth.Location = new System.Drawing.Point(322, 48);
            this.labelMonth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMonth.Name = "labelMonth";
            this.labelMonth.Size = new System.Drawing.Size(56, 17);
            this.labelMonth.TabIndex = 73;
            this.labelMonth.Text = "Month :";
            // 
            // txtStartdate
            // 
            this.txtStartdate.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtStartdate.Location = new System.Drawing.Point(719, 18);
            this.txtStartdate.Margin = new System.Windows.Forms.Padding(4);
            this.txtStartdate.Name = "txtStartdate";
            this.txtStartdate.Size = new System.Drawing.Size(120, 24);
            this.txtStartdate.TabIndex = 55;
            this.txtStartdate.Visible = false;
            this.txtStartdate.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtStartdate_MouseDoubleClick);
            this.txtStartdate.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtStartdate_PreviewKeyDown);
            // 
            // txtEnddate
            // 
            this.txtEnddate.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtEnddate.Location = new System.Drawing.Point(719, 44);
            this.txtEnddate.Margin = new System.Windows.Forms.Padding(4);
            this.txtEnddate.Name = "txtEnddate";
            this.txtEnddate.Size = new System.Drawing.Size(120, 24);
            this.txtEnddate.TabIndex = 56;
            this.txtEnddate.Visible = false;
            this.txtEnddate.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtEnddate_MouseDoubleClick);
            this.txtEnddate.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtEnddate_PreviewKeyDown);
            // 
            // radioButtonSale
            // 
            this.radioButtonSale.AutoSize = true;
            this.radioButtonSale.Checked = true;
            this.radioButtonSale.Location = new System.Drawing.Point(848, 49);
            this.radioButtonSale.Name = "radioButtonSale";
            this.radioButtonSale.Size = new System.Drawing.Size(46, 17);
            this.radioButtonSale.TabIndex = 48;
            this.radioButtonSale.TabStop = true;
            this.radioButtonSale.Text = "Sale";
            this.radioButtonSale.UseVisualStyleBackColor = true;
            this.radioButtonSale.Visible = false;
            // 
            // radioButtonFee
            // 
            this.radioButtonFee.AutoSize = true;
            this.radioButtonFee.Location = new System.Drawing.Point(848, 23);
            this.radioButtonFee.Name = "radioButtonFee";
            this.radioButtonFee.Size = new System.Drawing.Size(43, 17);
            this.radioButtonFee.TabIndex = 47;
            this.radioButtonFee.Text = "Fee";
            this.radioButtonFee.UseVisualStyleBackColor = true;
            this.radioButtonFee.Visible = false;
            // 
            // lblComRate
            // 
            this.lblComRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblComRate.AutoSize = true;
            this.lblComRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComRate.Location = new System.Drawing.Point(1149, 18);
            this.lblComRate.Name = "lblComRate";
            this.lblComRate.Size = new System.Drawing.Size(47, 16);
            this.lblComRate.TabIndex = 44;
            this.lblComRate.Text = "Com :";
            this.lblComRate.Visible = false;
            // 
            // labelbathtext
            // 
            this.labelbathtext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelbathtext.AutoSize = true;
            this.labelbathtext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelbathtext.Location = new System.Drawing.Point(1088, 47);
            this.labelbathtext.Name = "labelbathtext";
            this.labelbathtext.Size = new System.Drawing.Size(31, 16);
            this.labelbathtext.TabIndex = 43;
            this.labelbathtext.Text = "บาท";
            this.labelbathtext.Visible = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1088, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 16);
            this.label4.TabIndex = 42;
            this.label4.Text = "บาท";
            this.label4.Visible = false;
            // 
            // lblCom1
            // 
            this.lblCom1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCom1.AutoSize = true;
            this.lblCom1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCom1.Location = new System.Drawing.Point(892, 48);
            this.lblCom1.Name = "lblCom1";
            this.lblCom1.Size = new System.Drawing.Size(100, 16);
            this.lblCom1.TabIndex = 40;
            this.lblCom1.Text = "Commission :";
            this.lblCom1.Visible = false;
            // 
            // lblMoney1
            // 
            this.lblMoney1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMoney1.AutoSize = true;
            this.lblMoney1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoney1.Location = new System.Drawing.Point(894, 18);
            this.lblMoney1.Name = "lblMoney1";
            this.lblMoney1.Size = new System.Drawing.Size(98, 16);
            this.lblMoney1.TabIndex = 38;
            this.lblMoney1.Text = "รายได้/ยอดขาย :";
            this.lblMoney1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblMoney1.Visible = false;
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.AutoSize = true;
            this.lblEmployeeName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblEmployeeName.Location = new System.Drawing.Point(190, 18);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(125, 19);
            this.lblEmployeeName.TabIndex = 36;
            this.lblEmployeeName.Text = "[lblEMPName]";
            this.lblEmployeeName.Visible = false;
            // 
            // lblEN
            // 
            this.lblEN.AutoSize = true;
            this.lblEN.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblEN.Location = new System.Drawing.Point(190, 49);
            this.lblEN.Name = "lblEN";
            this.lblEN.Size = new System.Drawing.Size(65, 19);
            this.lblEN.TabIndex = 37;
            this.lblEN.Text = "[lblEN]";
            this.lblEN.Visible = false;
            // 
            // dtpDateEnd
            // 
            this.dtpDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateEnd.Location = new System.Drawing.Point(249, 42);
            this.dtpDateEnd.Name = "dtpDateEnd";
            this.dtpDateEnd.ShowUpDown = true;
            this.dtpDateEnd.Size = new System.Drawing.Size(127, 20);
            this.dtpDateEnd.TabIndex = 34;
            this.dtpDateEnd.Visible = false;
            // 
            // dtpDateStart
            // 
            this.dtpDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateStart.Location = new System.Drawing.Point(249, 17);
            this.dtpDateStart.Name = "dtpDateStart";
            this.dtpDateStart.ShowUpDown = true;
            this.dtpDateStart.Size = new System.Drawing.Size(127, 20);
            this.dtpDateStart.TabIndex = 33;
            this.dtpDateStart.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(664, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 17);
            this.label3.TabIndex = 32;
            this.label3.Text = "ถึงวันที่ :";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(659, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 31;
            this.label2.Text = "เริ่มวันที่ :";
            this.label2.Visible = false;
            // 
            // btnFindEMP
            // 
            this.btnFindEMP.BackgroundImage = global::AryuwatSystem.Properties.Resources.EMP_color;
            this.btnFindEMP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFindEMP.Location = new System.Drawing.Point(25, 5);
            this.btnFindEMP.Name = "btnFindEMP";
            this.btnFindEMP.Size = new System.Drawing.Size(65, 68);
            this.btnFindEMP.TabIndex = 30;
            this.btnFindEMP.UseVisualStyleBackColor = true;
            this.btnFindEMP.Visible = false;
            this.btnFindEMP.Click += new System.EventHandler(this.btnFindEMP_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(97, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 18);
            this.label1.TabIndex = 29;
            this.label1.Text = "รหัสพนักงาน :";
            this.label1.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(105, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 18);
            this.label5.TabIndex = 25;
            this.label5.Text = "ชื่อพนักงาน :";
            this.label5.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvData);
            this.panel2.Controls.Add(this.splitter2);
            this.panel2.Controls.Add(this.dataGridViewSummary);
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 81);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1177, 412);
            this.panel2.TabIndex = 1;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 218);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1177, 191);
            this.dgvData.TabIndex = 1;
            this.dgvData.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvData_CellFormatting);
            this.dgvData.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvData_RowPostPaint);
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 215);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(1177, 3);
            this.splitter2.TabIndex = 4;
            this.splitter2.TabStop = false;
            // 
            // dataGridViewSummary
            // 
            this.dataGridViewSummary.AllowUserToAddRows = false;
            this.dataGridViewSummary.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewSummary.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewSummary.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewSummary.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewSummary.MultiSelect = false;
            this.dataGridViewSummary.Name = "dataGridViewSummary";
            this.dataGridViewSummary.ReadOnly = true;
            this.dataGridViewSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSummary.Size = new System.Drawing.Size(1177, 215);
            this.dataGridViewSummary.TabIndex = 3;
            this.dataGridViewSummary.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSummary_CellClick);
            this.dataGridViewSummary.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewSummary_CellFormatting);
            this.dataGridViewSummary.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridViewSummary_RowPostPaint);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 409);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1177, 3);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "VN";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 47;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Treatment";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Course use";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 85;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "วันที่";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 53;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "เวลาเริ่ม";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 72;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "เวลาสิ้นสุด";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 81;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "จำนวนเงิน";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 83;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "เวลาเริ่ม";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 72;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "เวลาสิ้นสุด";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 81;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "จำนวนเงิน";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 83;
            // 
            // dataGridViewTextBoxColumn11
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            this.dataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn11.HeaderText = "จำนวนเงิน";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 83;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "Comp.";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Width = 43;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.HeaderText = "M.Budget";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.ReadOnly = true;
            this.dataGridViewCheckBoxColumn2.Width = 59;
            // 
            // dataGridViewCheckBoxColumn3
            // 
            this.dataGridViewCheckBoxColumn3.HeaderText = "Gift.V";
            this.dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
            this.dataGridViewCheckBoxColumn3.ReadOnly = true;
            this.dataGridViewCheckBoxColumn3.Width = 39;
            // 
            // dataGridViewCheckBoxColumn4
            // 
            this.dataGridViewCheckBoxColumn4.HeaderText = "Subject";
            this.dataGridViewCheckBoxColumn4.Name = "dataGridViewCheckBoxColumn4";
            this.dataGridViewCheckBoxColumn4.ReadOnly = true;
            this.dataGridViewCheckBoxColumn4.Width = 49;
            // 
            // buttonExport1
            // 
            this.buttonExport1.AutoSize = true;
            this.buttonExport1.BackColor = System.Drawing.Color.Transparent;
            this.buttonExport1.Location = new System.Drawing.Point(648, 1);
            this.buttonExport1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.buttonExport1.Name = "buttonExport1";
            this.buttonExport1.Size = new System.Drawing.Size(79, 67);
            this.buttonExport1.TabIndex = 77;
            this.buttonExport1.BtnClick += new AryuwatSystem.UserControls.ButtonExport.ButtonClick(this.buttonExport1_BtnClick);
            // 
            // txtCommoney
            // 
            this.txtCommoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCommoney.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCommoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtCommoney.Location = new System.Drawing.Point(973, 40);
            this.txtCommoney.Name = "txtCommoney";
            this.txtCommoney.ReadOnly = true;
            this.txtCommoney.Size = new System.Drawing.Size(116, 26);
            this.txtCommoney.TabIndex = 46;
            this.txtCommoney.Visible = false;
            // 
            // txtMoney
            // 
            this.txtMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMoney.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtMoney.Location = new System.Drawing.Point(973, 8);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.ReadOnly = true;
            this.txtMoney.Size = new System.Drawing.Size(116, 26);
            this.txtMoney.TabIndex = 45;
            this.txtMoney.Visible = false;
            // 
            // buttonFind
            // 
            this.buttonFind.BackColor = System.Drawing.Color.Transparent;
            this.buttonFind.Location = new System.Drawing.Point(562, 8);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(68, 67);
            this.buttonFind.TabIndex = 35;
            this.buttonFind.BtnClick += new AryuwatSystem.UserControls.ButtonFind.ButtonClick(this.buttonFind_BtnClick);
            // 
            // FrmCommissionCheck
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1177, 493);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCommissionCheck";
            this.Text = "Commission Check";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCommissionCheck_FormClosing);
            this.Load += new System.EventHandler(this.FrmCommissionCheck_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSummary)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnFindEMP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDateEnd;
        private System.Windows.Forms.DateTimePicker dtpDateStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private UserControls.ButtonFind buttonFind;
        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.Label lblEN;
        private System.Windows.Forms.Label lblMoney1;
        private System.Windows.Forms.Label lblCom1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn4;
        private System.Windows.Forms.Label lblComRate;
        private System.Windows.Forms.Label labelbathtext;
        private System.Windows.Forms.Label label4;
        private UserControls.TextboxFormatDouble txtCommoney;
        private UserControls.TextboxFormatDouble txtMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.RadioButton radioButtonSale;
        private System.Windows.Forms.RadioButton radioButtonFee;
        private System.Windows.Forms.TextBox txtStartdate;
        private System.Windows.Forms.TextBox txtEnddate;
        private System.Windows.Forms.DataGridView dataGridViewSummary;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.ComboBox comboBoxYears;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxPeriod;
        private System.Windows.Forms.Label labelMonth;
        private UserControls.ButtonExport buttonExport1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}