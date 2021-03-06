﻿namespace DermasterSystem.Forms
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtonSale = new System.Windows.Forms.RadioButton();
            this.radioButtonFee = new System.Windows.Forms.RadioButton();
            this.txtCommoney = new DermasterSystem.UserControls.TextboxFormatDouble(this.components);
            this.txtMoney = new DermasterSystem.UserControls.TextboxFormatDouble(this.components);
            this.lblComRate = new System.Windows.Forms.Label();
            this.labelbathtext = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCom1 = new System.Windows.Forms.Label();
            this.lblMoney1 = new System.Windows.Forms.Label();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.lblEN = new System.Windows.Forms.Label();
            this.buttonFind = new DermasterSystem.UserControls.ButtonFind();
            this.dtpDateEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpDateStart = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFindEMP = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvData = new System.Windows.Forms.DataGridView();
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
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.VN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MS_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PositionFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProcedureDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Money = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comp = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MBudget = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.GifV = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Subject = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
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
            // radioButtonSale
            // 
            this.radioButtonSale.AutoSize = true;
            this.radioButtonSale.Location = new System.Drawing.Point(561, 46);
            this.radioButtonSale.Name = "radioButtonSale";
            this.radioButtonSale.Size = new System.Drawing.Size(46, 17);
            this.radioButtonSale.TabIndex = 48;
            this.radioButtonSale.Text = "Sale";
            this.radioButtonSale.UseVisualStyleBackColor = true;
            // 
            // radioButtonFee
            // 
            this.radioButtonFee.AutoSize = true;
            this.radioButtonFee.Checked = true;
            this.radioButtonFee.Location = new System.Drawing.Point(561, 20);
            this.radioButtonFee.Name = "radioButtonFee";
            this.radioButtonFee.Size = new System.Drawing.Size(43, 17);
            this.radioButtonFee.TabIndex = 47;
            this.radioButtonFee.TabStop = true;
            this.radioButtonFee.Text = "Fee";
            this.radioButtonFee.UseVisualStyleBackColor = true;
            // 
            // txtCommoney
            // 
            this.txtCommoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCommoney.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCommoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtCommoney.Location = new System.Drawing.Point(884, 42);
            this.txtCommoney.Name = "txtCommoney";
            this.txtCommoney.ReadOnly = true;
            this.txtCommoney.Size = new System.Drawing.Size(100, 26);
            this.txtCommoney.TabIndex = 46;
            // 
            // txtMoney
            // 
            this.txtMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMoney.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtMoney.Location = new System.Drawing.Point(884, 10);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.ReadOnly = true;
            this.txtMoney.Size = new System.Drawing.Size(100, 26);
            this.txtMoney.TabIndex = 45;
            // 
            // lblComRate
            // 
            this.lblComRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblComRate.AutoSize = true;
            this.lblComRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComRate.Location = new System.Drawing.Point(1044, 20);
            this.lblComRate.Name = "lblComRate";
            this.lblComRate.Size = new System.Drawing.Size(47, 16);
            this.lblComRate.TabIndex = 44;
            this.lblComRate.Text = "Com :";
            // 
            // labelbathtext
            // 
            this.labelbathtext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelbathtext.AutoSize = true;
            this.labelbathtext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelbathtext.Location = new System.Drawing.Point(983, 49);
            this.labelbathtext.Name = "labelbathtext";
            this.labelbathtext.Size = new System.Drawing.Size(31, 16);
            this.labelbathtext.TabIndex = 43;
            this.labelbathtext.Text = "บาท";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(983, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 16);
            this.label4.TabIndex = 42;
            this.label4.Text = "บาท";
            // 
            // lblCom1
            // 
            this.lblCom1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCom1.AutoSize = true;
            this.lblCom1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCom1.Location = new System.Drawing.Point(787, 50);
            this.lblCom1.Name = "lblCom1";
            this.lblCom1.Size = new System.Drawing.Size(100, 16);
            this.lblCom1.TabIndex = 40;
            this.lblCom1.Text = "Commission :";
            // 
            // lblMoney1
            // 
            this.lblMoney1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMoney1.AutoSize = true;
            this.lblMoney1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoney1.Location = new System.Drawing.Point(789, 20);
            this.lblMoney1.Name = "lblMoney1";
            this.lblMoney1.Size = new System.Drawing.Size(98, 16);
            this.lblMoney1.TabIndex = 38;
            this.lblMoney1.Text = "รายได้/ยอดขาย :";
            this.lblMoney1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // 
            // buttonFind
            // 
            this.buttonFind.BackColor = System.Drawing.Color.Transparent;
            this.buttonFind.Location = new System.Drawing.Point(677, 8);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(68, 59);
            this.buttonFind.TabIndex = 35;
            this.buttonFind.BtnClick += new DermasterSystem.UserControls.ButtonFind.ButtonClick(this.buttonFind_BtnClick);
            // 
            // dtpDateEnd
            // 
            this.dtpDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateEnd.Location = new System.Drawing.Point(428, 42);
            this.dtpDateEnd.Name = "dtpDateEnd";
            this.dtpDateEnd.ShowCheckBox = true;
            this.dtpDateEnd.ShowUpDown = true;
            this.dtpDateEnd.Size = new System.Drawing.Size(127, 20);
            this.dtpDateEnd.TabIndex = 34;
            // 
            // dtpDateStart
            // 
            this.dtpDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateStart.Location = new System.Drawing.Point(428, 17);
            this.dtpDateStart.Name = "dtpDateStart";
            this.dtpDateStart.ShowCheckBox = true;
            this.dtpDateStart.ShowUpDown = true;
            this.dtpDateStart.Size = new System.Drawing.Size(127, 20);
            this.dtpDateStart.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(377, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 17);
            this.label3.TabIndex = 32;
            this.label3.Text = "ถึงวันที่ :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(372, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 31;
            this.label2.Text = "เริ่มวันที่ :";
            // 
            // btnFindEMP
            // 
            this.btnFindEMP.BackgroundImage = global::DermasterSystem.Properties.Resources.EMP_color;
            this.btnFindEMP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFindEMP.Location = new System.Drawing.Point(25, 5);
            this.btnFindEMP.Name = "btnFindEMP";
            this.btnFindEMP.Size = new System.Drawing.Size(65, 68);
            this.btnFindEMP.TabIndex = 30;
            this.btnFindEMP.UseVisualStyleBackColor = true;
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
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvData);
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
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VN,
            this.SO,
            this.CN,
            this.CustomerName,
            this.EMName,
            this.MS_Name,
            this.PositionFee,
            this.ProcedureDate,
            this.StartTime,
            this.EndTime,
            this.Money,
            this.comp,
            this.MBudget,
            this.GifV,
            this.Subject});
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1177, 412);
            this.dgvData.TabIndex = 1;
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
            this.dataGridViewTextBoxColumn8.Width = 72;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "เวลาสิ้นสุด";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 81;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "จำนวนเงิน";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 83;
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
            // VN
            // 
            this.VN.HeaderText = "VN";
            this.VN.Name = "VN";
            this.VN.ReadOnly = true;
            this.VN.Width = 47;
            // 
            // SO
            // 
            this.SO.HeaderText = "SO";
            this.SO.Name = "SO";
            this.SO.Width = 47;
            // 
            // CN
            // 
            this.CN.HeaderText = "CN";
            this.CN.Name = "CN";
            this.CN.Width = 47;
            // 
            // CustomerName
            // 
            this.CustomerName.HeaderText = "ชื่อ-สกุล(ลูกค้า)";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.Width = 98;
            // 
            // EMName
            // 
            this.EMName.HeaderText = "ชื่อ-สกุล(พนักงาน)";
            this.EMName.Name = "EMName";
            this.EMName.Width = 114;
            // 
            // MS_Name
            // 
            this.MS_Name.HeaderText = "Treatment";
            this.MS_Name.Name = "MS_Name";
            this.MS_Name.ReadOnly = true;
            this.MS_Name.Width = 80;
            // 
            // PositionFee
            // 
            this.PositionFee.HeaderText = "Position Fee";
            this.PositionFee.Name = "PositionFee";
            this.PositionFee.Width = 90;
            // 
            // ProcedureDate
            // 
            this.ProcedureDate.HeaderText = "วันที่";
            this.ProcedureDate.Name = "ProcedureDate";
            this.ProcedureDate.ReadOnly = true;
            this.ProcedureDate.Width = 53;
            // 
            // StartTime
            // 
            this.StartTime.HeaderText = "เวลาเริ่ม";
            this.StartTime.Name = "StartTime";
            this.StartTime.Width = 72;
            // 
            // EndTime
            // 
            this.EndTime.HeaderText = "เวลาสิ้นสุด";
            this.EndTime.Name = "EndTime";
            this.EndTime.Width = 81;
            // 
            // Money
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            this.Money.DefaultCellStyle = dataGridViewCellStyle1;
            this.Money.HeaderText = "จำนวนเงิน";
            this.Money.Name = "Money";
            this.Money.ReadOnly = true;
            this.Money.Width = 83;
            // 
            // comp
            // 
            this.comp.HeaderText = "Comp.";
            this.comp.Name = "comp";
            this.comp.ReadOnly = true;
            this.comp.Width = 43;
            // 
            // MBudget
            // 
            this.MBudget.HeaderText = "M.Budget";
            this.MBudget.Name = "MBudget";
            this.MBudget.ReadOnly = true;
            this.MBudget.Width = 59;
            // 
            // GifV
            // 
            this.GifV.HeaderText = "Gift.V";
            this.GifV.Name = "GifV";
            this.GifV.ReadOnly = true;
            this.GifV.Width = 39;
            // 
            // Subject
            // 
            this.Subject.HeaderText = "Subject";
            this.Subject.Name = "Subject";
            this.Subject.ReadOnly = true;
            this.Subject.Width = 49;
            // 
            // FrmCommissionCheck
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1177, 493);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Name = "FrmCommissionCheck";
            this.Text = "Commission Check";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCommissionCheck_FormClosing);
            this.Load += new System.EventHandler(this.FrmCommissionCheck_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn VN;
        private System.Windows.Forms.DataGridViewTextBoxColumn SO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CN;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MS_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn PositionFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcedureDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Money;
        private System.Windows.Forms.DataGridViewCheckBoxColumn comp;
        private System.Windows.Forms.DataGridViewCheckBoxColumn MBudget;
        private System.Windows.Forms.DataGridViewCheckBoxColumn GifV;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Subject;
    }
}