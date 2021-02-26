namespace AryuwatSystem.Forms
{
    partial class FrmCommissionHeadCheck
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            PresentationControls.CheckBoxProperties checkBoxProperties1 = new PresentationControls.CheckBoxProperties();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCommissionHeadCheck));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonExport1 = new AryuwatSystem.UserControls.ButtonExport();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.VN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MORef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CN_USED = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustFullNameThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStartdate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEnddate = new System.Windows.Forms.TextBox();
            this.cboPosition = new PresentationControls.CheckBoxComboBox();
            this.buttonFind = new AryuwatSystem.UserControls.ButtonFind();
            this.label7 = new System.Windows.Forms.Label();
            this.cboSurgicalFeeTyp = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ngbMain = new AryuwatSystem.UserControls.NavigatoBar();
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
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonExport1);
            this.panel1.Controls.Add(this.dgvData);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.ngbMain);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1257, 493);
            this.panel1.TabIndex = 0;
            // 
            // buttonExport1
            // 
            this.buttonExport1.BackColor = System.Drawing.Color.Transparent;
            this.buttonExport1.Location = new System.Drawing.Point(850, 13);
            this.buttonExport1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.buttonExport1.Name = "buttonExport1";
            this.buttonExport1.Size = new System.Drawing.Size(79, 70);
            this.buttonExport1.TabIndex = 131;
            this.buttonExport1.BtnClick += new AryuwatSystem.UserControls.ButtonExport.ButtonClick(this.buttonExport1_BtnClick);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToOrderColumns = true;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VN,
            this.MORef,
            this.SO,
            this.CN,
            this.CustomerName,
            this.CN_USED,
            this.CustFullNameThai,
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
            this.dgvData.Location = new System.Drawing.Point(0, 90);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1257, 377);
            this.dgvData.TabIndex = 1;
            // 
            // VN
            // 
            this.VN.HeaderText = "MO Main";
            this.VN.Name = "VN";
            this.VN.ReadOnly = true;
            this.VN.Width = 75;
            // 
            // MORef
            // 
            this.MORef.HeaderText = "MO Ref.";
            this.MORef.Name = "MORef";
            this.MORef.ReadOnly = true;
            this.MORef.Width = 72;
            // 
            // SO
            // 
            this.SO.HeaderText = "SO";
            this.SO.Name = "SO";
            this.SO.ReadOnly = true;
            this.SO.Width = 47;
            // 
            // CN
            // 
            this.CN.HeaderText = "CN";
            this.CN.Name = "CN";
            this.CN.ReadOnly = true;
            this.CN.Width = 47;
            // 
            // CustomerName
            // 
            this.CustomerName.HeaderText = "ชื่อ-สกุล(ลูกค้า)";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            this.CustomerName.Width = 98;
            // 
            // CN_USED
            // 
            this.CN_USED.HeaderText = "CN_USED";
            this.CN_USED.Name = "CN_USED";
            this.CN_USED.ReadOnly = true;
            this.CN_USED.Width = 83;
            // 
            // CustFullNameThai
            // 
            this.CustFullNameThai.HeaderText = "ชื่อผู้ใช้";
            this.CustFullNameThai.Name = "CustFullNameThai";
            this.CustFullNameThai.ReadOnly = true;
            this.CustFullNameThai.Width = 65;
            // 
            // EMName
            // 
            this.EMName.HeaderText = "ชื่อ-สกุล(พนักงาน)";
            this.EMName.Name = "EMName";
            this.EMName.ReadOnly = true;
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
            this.PositionFee.ReadOnly = true;
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
            this.StartTime.ReadOnly = true;
            this.StartTime.Visible = false;
            this.StartTime.Width = 72;
            // 
            // EndTime
            // 
            this.EndTime.HeaderText = "เวลาสิ้นสุด";
            this.EndTime.Name = "EndTime";
            this.EndTime.ReadOnly = true;
            this.EndTime.Visible = false;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtStartdate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtEnddate);
            this.groupBox1.Controls.Add(this.cboPosition);
            this.groupBox1.Controls.Add(this.buttonFind);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cboSurgicalFeeTyp);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1257, 90);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ตรวจสอบค่ามือ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label3.Location = new System.Drawing.Point(511, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 56;
            this.label3.Text = "Start Date :";
            // 
            // txtStartdate
            // 
            this.txtStartdate.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtStartdate.Location = new System.Drawing.Point(591, 18);
            this.txtStartdate.Margin = new System.Windows.Forms.Padding(4);
            this.txtStartdate.Name = "txtStartdate";
            this.txtStartdate.Size = new System.Drawing.Size(120, 24);
            this.txtStartdate.TabIndex = 53;
            this.txtStartdate.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtStartdate_MouseClick);
            this.txtStartdate.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtStartdate_MouseDoubleClick);
            this.txtStartdate.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtStartdate_PreviewKeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label4.Location = new System.Drawing.Point(517, 54);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 17);
            this.label4.TabIndex = 55;
            this.label4.Text = "End Date :";
            // 
            // txtEnddate
            // 
            this.txtEnddate.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtEnddate.Location = new System.Drawing.Point(591, 50);
            this.txtEnddate.Margin = new System.Windows.Forms.Padding(4);
            this.txtEnddate.Name = "txtEnddate";
            this.txtEnddate.Size = new System.Drawing.Size(120, 24);
            this.txtEnddate.TabIndex = 54;
            this.txtEnddate.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtEnddate_MouseClick);
            this.txtEnddate.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtEnddate_MouseDoubleClick);
            this.txtEnddate.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtEnddate_PreviewKeyDown);
            // 
            // cboPosition
            // 
            checkBoxProperties1.AutoSize = true;
            checkBoxProperties1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboPosition.CheckBoxProperties = checkBoxProperties1;
            this.cboPosition.DisplayMemberSingleItem = "";
            this.cboPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboPosition.FormattingEnabled = true;
            this.cboPosition.Location = new System.Drawing.Point(281, 51);
            this.cboPosition.Name = "cboPosition";
            this.cboPosition.Size = new System.Drawing.Size(219, 24);
            this.cboPosition.TabIndex = 51;
            // 
            // buttonFind
            // 
            this.buttonFind.BackColor = System.Drawing.Color.Transparent;
            this.buttonFind.Location = new System.Drawing.Point(763, 16);
            this.buttonFind.Margin = new System.Windows.Forms.Padding(131750, 27623, 131750, 27623);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(67, 70);
            this.buttonFind.TabIndex = 35;
            this.buttonFind.BtnClick += new AryuwatSystem.UserControls.ButtonFind.ButtonClick(this.buttonFind_BtnClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(210, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 18);
            this.label7.TabIndex = 52;
            this.label7.Text = "ตำแหน่ง :";
            // 
            // cboSurgicalFeeTyp
            // 
            this.cboSurgicalFeeTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSurgicalFeeTyp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboSurgicalFeeTyp.FormattingEnabled = true;
            this.cboSurgicalFeeTyp.Location = new System.Drawing.Point(281, 20);
            this.cboSurgicalFeeTyp.Name = "cboSurgicalFeeTyp";
            this.cboSurgicalFeeTyp.Size = new System.Drawing.Size(121, 24);
            this.cboSurgicalFeeTyp.TabIndex = 49;
            this.cboSurgicalFeeTyp.SelectedIndexChanged += new System.EventHandler(this.cboSurgicalFeeTyp_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(225, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 18);
            this.label6.TabIndex = 50;
            this.label6.Text = "แผนก :";
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
            this.ngbMain.Location = new System.Drawing.Point(0, 467);
            this.ngbMain.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.ngbMain.Name = "ngbMain";
            this.ngbMain.Size = new System.Drawing.Size(1257, 26);
            this.ngbMain.TabIndex = 130;
            this.ngbMain.TotalPage = ((long)(0));
            this.ngbMain.TotalRecord = ((long)(0));
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
            this.dataGridViewTextBoxColumn10.Visible = false;
            this.dataGridViewTextBoxColumn10.Width = 83;
            // 
            // dataGridViewTextBoxColumn11
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            this.dataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn11.HeaderText = "จำนวนเงิน";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Visible = false;
            this.dataGridViewTextBoxColumn11.Width = 83;
            // 
            // dataGridViewTextBoxColumn12
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            this.dataGridViewTextBoxColumn12.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn12.HeaderText = "จำนวนเงิน";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 83;
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
            // FrmCommissionHeadCheck
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1257, 493);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCommissionHeadCheck";
            this.Text = "Commission Check";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCommissionHeadCheck_FormClosing);
            this.Load += new System.EventHandler(this.FrmCommissionHeadCheck_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private UserControls.ButtonFind buttonFind;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.Label label7;
        private PresentationControls.CheckBoxComboBox cboPosition;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboSurgicalFeeTyp;
        private System.Windows.Forms.GroupBox groupBox1;
        private UserControls.NavigatoBar ngbMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStartdate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEnddate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private UserControls.ButtonExport buttonExport1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn VN;
        private System.Windows.Forms.DataGridViewTextBoxColumn MORef;
        private System.Windows.Forms.DataGridViewTextBoxColumn SO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CN;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CN_USED;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustFullNameThai;
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