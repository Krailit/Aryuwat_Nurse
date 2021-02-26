namespace AryuwatSystem.Forms
{
    partial class FrmMedicalOrderPaperList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMedicalOrderPaperList));
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.picNew = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSurName = new System.Windows.Forms.TextBox();
            this.uBranch1 = new AryuwatSystem.UserControls.UBranch();
            this.checkBoxMO = new System.Windows.Forms.CheckBox();
            this.checkBoxSO = new System.Windows.Forms.CheckBox();
            this.txtRefMo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtStartdate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEnddate = new System.Windows.Forms.TextBox();
            this.checkBoxOld = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSo = new System.Windows.Forms.TextBox();
            this.checkBoxPaid = new System.Windows.Forms.CheckBox();
            this.checkBoxDeposit = new System.Windows.Forms.CheckBox();
            this.checkBoxUnpaid = new System.Windows.Forms.CheckBox();
            this.checkBoxClose = new System.Windows.Forms.CheckBox();
            this.checkBoxPending = new System.Windows.Forms.CheckBox();
            this.checkBoxNew = new System.Windows.Forms.CheckBox();
            this.buttonFind = new AryuwatSystem.UserControls.ButtonFind();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.txtCN = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuUse = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDel = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemChangCouse = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDoctorEstimate = new System.Windows.Forms.ToolStripMenuItem();
            this.menucustomerSign = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ngbMain = new AryuwatSystem.UserControls.NavigatoBar();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNew)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 101);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgvData.RowTemplate.ReadOnly = true;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvData.Size = new System.Drawing.Size(1248, 472);
            this.dgvData.TabIndex = 122;
            this.dgvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellClick);
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            this.dgvData.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellMouseEnter);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.picNew);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtSurName);
            this.groupBox1.Controls.Add(this.uBranch1);
            this.groupBox1.Controls.Add(this.checkBoxMO);
            this.groupBox1.Controls.Add(this.checkBoxSO);
            this.groupBox1.Controls.Add(this.txtRefMo);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtStartdate);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtEnddate);
            this.groupBox1.Controls.Add(this.checkBoxOld);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtSo);
            this.groupBox1.Controls.Add(this.checkBoxPaid);
            this.groupBox1.Controls.Add(this.checkBoxDeposit);
            this.groupBox1.Controls.Add(this.checkBoxUnpaid);
            this.groupBox1.Controls.Add(this.checkBoxClose);
            this.groupBox1.Controls.Add(this.checkBoxPending);
            this.groupBox1.Controls.Add(this.checkBoxNew);
            this.groupBox1.Controls.Add(this.buttonFind);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtVN);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtProduct);
            this.groupBox1.Controls.Add(this.txtCN);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1248, 101);
            this.groupBox1.TabIndex = 123;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ค้นหา";
            // 
            // picNew
            // 
            this.picNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picNew.Image = global::AryuwatSystem.Properties.Resources.document_add_256;
            this.picNew.Location = new System.Drawing.Point(1099, 14);
            this.picNew.Name = "picNew";
            this.picNew.Size = new System.Drawing.Size(43, 47);
            this.picNew.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picNew.TabIndex = 56;
            this.picNew.TabStop = false;
            this.toolTip1.SetToolTip(this.picNew, "สร้างใบยา");
            this.picNew.Click += new System.EventHandler(this.picNew_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label10.Location = new System.Drawing.Point(448, 44);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 17);
            this.label10.TabIndex = 55;
            this.label10.Text = "SurName :";
            // 
            // txtSurName
            // 
            this.txtSurName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtSurName.Location = new System.Drawing.Point(521, 40);
            this.txtSurName.Margin = new System.Windows.Forms.Padding(4);
            this.txtSurName.Name = "txtSurName";
            this.txtSurName.Size = new System.Drawing.Size(117, 24);
            this.txtSurName.TabIndex = 54;
            this.txtSurName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSurName_MouseClick);
            this.txtSurName.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtSurName_PreviewKeyDown_1);
            // 
            // uBranch1
            // 
            this.uBranch1.BranchId = "";
            this.uBranch1.BranchName = "";
            this.uBranch1.Location = new System.Drawing.Point(671, 72);
            this.uBranch1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uBranch1.Name = "uBranch1";
            this.uBranch1.Size = new System.Drawing.Size(240, 25);
            this.uBranch1.TabIndex = 53;
            // 
            // checkBoxMO
            // 
            this.checkBoxMO.AutoSize = true;
            this.checkBoxMO.Checked = true;
            this.checkBoxMO.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMO.Location = new System.Drawing.Point(1171, 75);
            this.checkBoxMO.Name = "checkBoxMO";
            this.checkBoxMO.Size = new System.Drawing.Size(46, 20);
            this.checkBoxMO.TabIndex = 52;
            this.checkBoxMO.Text = "MO";
            this.checkBoxMO.UseVisualStyleBackColor = true;
            this.checkBoxMO.Visible = false;
            this.checkBoxMO.Click += new System.EventHandler(this.checkBoxMO_Click);
            // 
            // checkBoxSO
            // 
            this.checkBoxSO.AutoSize = true;
            this.checkBoxSO.Checked = true;
            this.checkBoxSO.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSO.Location = new System.Drawing.Point(1127, 75);
            this.checkBoxSO.Name = "checkBoxSO";
            this.checkBoxSO.Size = new System.Drawing.Size(44, 20);
            this.checkBoxSO.TabIndex = 51;
            this.checkBoxSO.Text = "SO";
            this.checkBoxSO.UseVisualStyleBackColor = true;
            this.checkBoxSO.Visible = false;
            this.checkBoxSO.Click += new System.EventHandler(this.checkBoxSO_Click);
            // 
            // txtRefMo
            // 
            this.txtRefMo.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtRefMo.Location = new System.Drawing.Point(259, 13);
            this.txtRefMo.Margin = new System.Windows.Forms.Padding(4);
            this.txtRefMo.Name = "txtRefMo";
            this.txtRefMo.Size = new System.Drawing.Size(98, 24);
            this.txtRefMo.TabIndex = 49;
            this.txtRefMo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtRefMo_MouseClick);
            this.txtRefMo.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtRefMo_PreviewKeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label9.Location = new System.Drawing.Point(207, 17);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 17);
            this.label9.TabIndex = 50;
            this.label9.Text = "RefMO :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label7.Location = new System.Drawing.Point(651, 18);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 17);
            this.label7.TabIndex = 42;
            this.label7.Text = "Start Date :";
            // 
            // txtStartdate
            // 
            this.txtStartdate.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtStartdate.Location = new System.Drawing.Point(731, 14);
            this.txtStartdate.Margin = new System.Windows.Forms.Padding(4);
            this.txtStartdate.Name = "txtStartdate";
            this.txtStartdate.Size = new System.Drawing.Size(180, 24);
            this.txtStartdate.TabIndex = 39;
            this.txtStartdate.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtStartdate_MouseClick);
            this.txtStartdate.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtStartdate_MouseDoubleClick);
            this.txtStartdate.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtStartdate_PreviewKeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label8.Location = new System.Drawing.Point(657, 47);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 17);
            this.label8.TabIndex = 41;
            this.label8.Text = "End Date :";
            // 
            // txtEnddate
            // 
            this.txtEnddate.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtEnddate.Location = new System.Drawing.Point(731, 43);
            this.txtEnddate.Margin = new System.Windows.Forms.Padding(4);
            this.txtEnddate.Name = "txtEnddate";
            this.txtEnddate.Size = new System.Drawing.Size(180, 24);
            this.txtEnddate.TabIndex = 40;
            this.txtEnddate.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtEnddate_MouseClick);
            this.txtEnddate.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtEnddate_MouseDoubleClick);
            this.txtEnddate.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtEnddate_PreviewKeyDown);
            // 
            // checkBoxOld
            // 
            this.checkBoxOld.AutoSize = true;
            this.checkBoxOld.Checked = true;
            this.checkBoxOld.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxOld.Location = new System.Drawing.Point(940, 73);
            this.checkBoxOld.Name = "checkBoxOld";
            this.checkBoxOld.Size = new System.Drawing.Size(70, 20);
            this.checkBoxOld.TabIndex = 38;
            this.checkBoxOld.Text = "Old Key";
            this.checkBoxOld.UseVisualStyleBackColor = true;
            this.checkBoxOld.CheckedChanged += new System.EventHandler(this.checkBoxOld_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label6.Location = new System.Drawing.Point(45, 73);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 17);
            this.label6.TabIndex = 36;
            this.label6.Text = "SO :";
            // 
            // txtSo
            // 
            this.txtSo.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtSo.Location = new System.Drawing.Point(86, 69);
            this.txtSo.Margin = new System.Windows.Forms.Padding(4);
            this.txtSo.Name = "txtSo";
            this.txtSo.Size = new System.Drawing.Size(180, 24);
            this.txtSo.TabIndex = 35;
            this.txtSo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSo_MouseClick);
            this.txtSo.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtSo_PreviewKeyDown);
            // 
            // checkBoxPaid
            // 
            this.checkBoxPaid.AutoSize = true;
            this.checkBoxPaid.Location = new System.Drawing.Point(1148, 54);
            this.checkBoxPaid.Name = "checkBoxPaid";
            this.checkBoxPaid.Size = new System.Drawing.Size(51, 20);
            this.checkBoxPaid.TabIndex = 32;
            this.checkBoxPaid.Text = "Paid";
            this.checkBoxPaid.UseVisualStyleBackColor = true;
            this.checkBoxPaid.Visible = false;
            // 
            // checkBoxDeposit
            // 
            this.checkBoxDeposit.AutoSize = true;
            this.checkBoxDeposit.Location = new System.Drawing.Point(1148, 34);
            this.checkBoxDeposit.Name = "checkBoxDeposit";
            this.checkBoxDeposit.Size = new System.Drawing.Size(69, 20);
            this.checkBoxDeposit.TabIndex = 31;
            this.checkBoxDeposit.Text = "Deposit";
            this.checkBoxDeposit.UseVisualStyleBackColor = true;
            this.checkBoxDeposit.Visible = false;
            // 
            // checkBoxUnpaid
            // 
            this.checkBoxUnpaid.AutoSize = true;
            this.checkBoxUnpaid.Location = new System.Drawing.Point(1148, 14);
            this.checkBoxUnpaid.Name = "checkBoxUnpaid";
            this.checkBoxUnpaid.Size = new System.Drawing.Size(66, 20);
            this.checkBoxUnpaid.TabIndex = 29;
            this.checkBoxUnpaid.Text = "Unpaid";
            this.checkBoxUnpaid.UseVisualStyleBackColor = true;
            this.checkBoxUnpaid.Visible = false;
            // 
            // checkBoxClose
            // 
            this.checkBoxClose.AutoSize = true;
            this.checkBoxClose.Checked = true;
            this.checkBoxClose.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxClose.Location = new System.Drawing.Point(940, 53);
            this.checkBoxClose.Name = "checkBoxClose";
            this.checkBoxClose.Size = new System.Drawing.Size(51, 20);
            this.checkBoxClose.TabIndex = 28;
            this.checkBoxClose.Text = "Paid";
            this.checkBoxClose.UseVisualStyleBackColor = true;
            this.checkBoxClose.CheckedChanged += new System.EventHandler(this.checkBoxClose_CheckedChanged);
            // 
            // checkBoxPending
            // 
            this.checkBoxPending.AutoSize = true;
            this.checkBoxPending.Checked = true;
            this.checkBoxPending.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPending.Location = new System.Drawing.Point(940, 33);
            this.checkBoxPending.Name = "checkBoxPending";
            this.checkBoxPending.Size = new System.Drawing.Size(69, 20);
            this.checkBoxPending.TabIndex = 27;
            this.checkBoxPending.Text = "Deposit";
            this.checkBoxPending.UseVisualStyleBackColor = true;
            this.checkBoxPending.CheckedChanged += new System.EventHandler(this.checkBoxPending_CheckedChanged);
            // 
            // checkBoxNew
            // 
            this.checkBoxNew.AutoSize = true;
            this.checkBoxNew.Checked = true;
            this.checkBoxNew.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNew.Location = new System.Drawing.Point(940, 13);
            this.checkBoxNew.Name = "checkBoxNew";
            this.checkBoxNew.Size = new System.Drawing.Size(66, 20);
            this.checkBoxNew.TabIndex = 26;
            this.checkBoxNew.Text = "Unpaid";
            this.checkBoxNew.UseVisualStyleBackColor = true;
            this.checkBoxNew.CheckedChanged += new System.EventHandler(this.checkBoxNew_CheckedChanged);
            // 
            // buttonFind
            // 
            this.buttonFind.AutoSize = true;
            this.buttonFind.BackColor = System.Drawing.Color.Transparent;
            this.buttonFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFind.Location = new System.Drawing.Point(1041, 13);
            this.buttonFind.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(52, 53);
            this.buttonFind.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label3.Location = new System.Drawing.Point(45, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "MO :";
            // 
            // txtVN
            // 
            this.txtVN.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtVN.Location = new System.Drawing.Point(86, 13);
            this.txtVN.Margin = new System.Windows.Forms.Padding(4);
            this.txtVN.Name = "txtVN";
            this.txtVN.Size = new System.Drawing.Size(121, 24);
            this.txtVN.TabIndex = 0;
            this.txtVN.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtVN_MouseClick);
            this.txtVN.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtVN_PreviewKeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label2.Location = new System.Drawing.Point(326, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Product :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label4.Location = new System.Drawing.Point(357, 17);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "CN :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label1.Location = new System.Drawing.Point(271, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name :";
            // 
            // txtProduct
            // 
            this.txtProduct.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtProduct.Location = new System.Drawing.Point(398, 70);
            this.txtProduct.Margin = new System.Windows.Forms.Padding(4);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(240, 24);
            this.txtProduct.TabIndex = 3;
            this.txtProduct.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtProduct_MouseClick);
            this.txtProduct.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtSurname_PreviewKeyDown);
            // 
            // txtCN
            // 
            this.txtCN.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtCN.Location = new System.Drawing.Point(398, 13);
            this.txtCN.Margin = new System.Windows.Forms.Padding(4);
            this.txtCN.Name = "txtCN";
            this.txtCN.Size = new System.Drawing.Size(240, 24);
            this.txtCN.TabIndex = 1;
            this.txtCN.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtCN_MouseClick);
            this.txtCN.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtCN_PreviewKeyDown);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtName.Location = new System.Drawing.Point(329, 43);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(117, 24);
            this.txtName.TabIndex = 2;
            this.txtName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtName_MouseClick);
            this.txtName.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtName_PreviewKeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUse,
            this.menuEdit,
            this.menuDel,
            this.menuPreview,
            this.ToolStripMenuItemChangCouse,
            this.menuDoctorEstimate,
            this.menucustomerSign});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(486, 240);
            // 
            // menuUse
            // 
            this.menuUse.AutoToolTip = true;
            this.menuUse.Image = global::AryuwatSystem.Properties.Resources.medical_history_128_Red;
            this.menuUse.Name = "menuUse";
            this.menuUse.Size = new System.Drawing.Size(485, 32);
            this.menuUse.Text = "บันทึกข้อมูลการใช้/Course Used";
            this.menuUse.ToolTipText = "Course Information";
            this.menuUse.Click += new System.EventHandler(this.menuUse_Click);
            // 
            // menuEdit
            // 
            this.menuEdit.ForeColor = System.Drawing.Color.Black;
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(485, 32);
            this.menuEdit.Text = "เปิดข้อมูล";
            this.menuEdit.ToolTipText = "Modified";
            // 
            // menuDel
            // 
            this.menuDel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.menuDel.Name = "menuDel";
            this.menuDel.Size = new System.Drawing.Size(485, 32);
            this.menuDel.Text = "ลบข้อมูล/Delete";
            this.menuDel.ToolTipText = "Delete";
            // 
            // menuPreview
            // 
            this.menuPreview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.menuPreview.Name = "menuPreview";
            this.menuPreview.Size = new System.Drawing.Size(485, 32);
            this.menuPreview.Text = "ดูรายการข้อมูล";
            this.menuPreview.ToolTipText = "View";
            this.menuPreview.Visible = false;
            // 
            // ToolStripMenuItemChangCouse
            // 
            this.ToolStripMenuItemChangCouse.Name = "ToolStripMenuItemChangCouse";
            this.ToolStripMenuItemChangCouse.Size = new System.Drawing.Size(485, 32);
            this.ToolStripMenuItemChangCouse.Text = "เปลี่ยนหรือยกเลิกคอร์ส/Cancel Course";
            this.ToolStripMenuItemChangCouse.ToolTipText = "Change or cancel courses";
            this.ToolStripMenuItemChangCouse.Visible = false;
            this.ToolStripMenuItemChangCouse.Click += new System.EventHandler(this.ToolStripMenuItemChangCouse_Click);
            // 
            // menuDoctorEstimate
            // 
            this.menuDoctorEstimate.Image = global::AryuwatSystem.Properties.Resources.general_surgery_256;
            this.menuDoctorEstimate.Name = "menuDoctorEstimate";
            this.menuDoctorEstimate.Size = new System.Drawing.Size(485, 32);
            this.menuDoctorEstimate.Text = "DoctorEstimate";
            this.menuDoctorEstimate.Click += new System.EventHandler(this.menuDoctorEstimate_Click);
            // 
            // menucustomerSign
            // 
            this.menucustomerSign.AutoSize = false;
            this.menucustomerSign.Image = global::AryuwatSystem.Properties.Resources.customers_next_256;
            this.menucustomerSign.Name = "menucustomerSign";
            this.menucustomerSign.Size = new System.Drawing.Size(301, 44);
            this.menucustomerSign.Text = "Customer Sign";
            this.menucustomerSign.Click += new System.EventHandler(this.menucustomerSign_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 300000;
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
            this.ngbMain.Size = new System.Drawing.Size(1248, 26);
            this.ngbMain.TabIndex = 124;
            this.ngbMain.TotalPage = ((long)(0));
            this.ngbMain.TotalRecord = ((long)(0));
            // 
            // FrmMedicalOrderPaperList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 599);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ngbMain);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMedicalOrderPaperList";
            this.Text = "รายการใบยา";
            this.Activated += new System.EventHandler(this.FrmMedicalOrderPaperList_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMedicalOrderPaperList_FormClosing);
            this.Load += new System.EventHandler(this.FrmMedicalOrderPaperList_Load);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.FrmMedicalOrderPaperList_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNew)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.GroupBox groupBox1;
        private UserControls.ButtonFind buttonFind;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.TextBox txtCN;
        

        private System.Windows.Forms.TextBox txtName;
        private UserControls.NavigatoBar ngbMain;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripMenuItem menuDel;
        private System.Windows.Forms.ToolStripMenuItem menuPreview;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem menuUse;
        private System.Windows.Forms.CheckBox checkBoxUnpaid;
        private System.Windows.Forms.CheckBox checkBoxClose;
        private System.Windows.Forms.CheckBox checkBoxPending;
        private System.Windows.Forms.CheckBox checkBoxNew;
        private System.Windows.Forms.CheckBox checkBoxPaid;
        private System.Windows.Forms.CheckBox checkBoxDeposit;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemChangCouse;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtSo;
        private System.Windows.Forms.CheckBox checkBoxOld;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtStartdate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEnddate;
        private System.Windows.Forms.TextBox txtRefMo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBoxMO;
        private System.Windows.Forms.CheckBox checkBoxSO;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem menuDoctorEstimate;
        private System.Windows.Forms.ToolStripMenuItem menucustomerSign;
        private UserControls.UBranch uBranch1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSurName;
        private System.Windows.Forms.PictureBox picNew;


    }
}