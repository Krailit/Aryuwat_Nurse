namespace AryuwatSystem.Forms
{
    partial class FrmSOTByPerson
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSOTByPerson));
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.gb = new System.Windows.Forms.GroupBox();
            this.btnPaidAll = new System.Windows.Forms.Button();
            this.txtCardID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboCheckMoney = new System.Windows.Forms.CheckBox();
            this.txtRefMo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSurName = new System.Windows.Forms.TextBox();
            this.uBranch1 = new AryuwatSystem.UserControls.UBranchAuth();
            this.label7 = new System.Windows.Forms.Label();
            this.txtStartdate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEnddate = new System.Windows.Forms.TextBox();
            this.checkBoxOld = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBoxClose = new System.Windows.Forms.CheckBox();
            this.checkBoxPending = new System.Windows.Forms.CheckBox();
            this.checkBoxNew = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.txtCN = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.buttonFind = new AryuwatSystem.UserControls.ButtonFind();
            this.ngbMain = new AryuwatSystem.UserControls.NavigatoBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDel = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSurgical = new System.Windows.Forms.ToolStripMenuItem();
            this.summaryOfTreatmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemUse = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemChangeCouse = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.gb.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvData);
            this.panel2.Controls.Add(this.gb);
            this.panel2.Controls.Add(this.ngbMain);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1254, 526);
            this.panel2.TabIndex = 1;
            // 
            // dgvData
            // 
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 114);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowTemplate.ReadOnly = true;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvData.Size = new System.Drawing.Size(1254, 386);
            this.dgvData.TabIndex = 125;
            this.dgvData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellContentClick);
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            this.dgvData.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellMouseEnter);
            this.dgvData.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvData_RowPrePaint);
            this.dgvData.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvData_RowsAdded);
            this.dgvData.Paint += new System.Windows.Forms.PaintEventHandler(this.dgvData_Paint);
            // 
            // gb
            // 
            this.gb.BackColor = System.Drawing.Color.Transparent;
            this.gb.Controls.Add(this.btnPaidAll);
            this.gb.Controls.Add(this.txtCardID);
            this.gb.Controls.Add(this.label5);
            this.gb.Controls.Add(this.cboCheckMoney);
            this.gb.Controls.Add(this.txtRefMo);
            this.gb.Controls.Add(this.label9);
            this.gb.Controls.Add(this.label10);
            this.gb.Controls.Add(this.txtSurName);
            this.gb.Controls.Add(this.uBranch1);
            this.gb.Controls.Add(this.label7);
            this.gb.Controls.Add(this.txtStartdate);
            this.gb.Controls.Add(this.label8);
            this.gb.Controls.Add(this.txtEnddate);
            this.gb.Controls.Add(this.checkBoxOld);
            this.gb.Controls.Add(this.checkBox4);
            this.gb.Controls.Add(this.checkBoxClose);
            this.gb.Controls.Add(this.checkBoxPending);
            this.gb.Controls.Add(this.checkBoxNew);
            this.gb.Controls.Add(this.label3);
            this.gb.Controls.Add(this.txtVN);
            this.gb.Controls.Add(this.label2);
            this.gb.Controls.Add(this.label4);
            this.gb.Controls.Add(this.label1);
            this.gb.Controls.Add(this.txtProduct);
            this.gb.Controls.Add(this.txtCN);
            this.gb.Controls.Add(this.txtName);
            this.gb.Controls.Add(this.buttonFind);
            this.gb.Dock = System.Windows.Forms.DockStyle.Top;
            this.gb.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gb.Location = new System.Drawing.Point(0, 0);
            this.gb.Margin = new System.Windows.Forms.Padding(4);
            this.gb.Name = "gb";
            this.gb.Padding = new System.Windows.Forms.Padding(4);
            this.gb.Size = new System.Drawing.Size(1254, 114);
            this.gb.TabIndex = 126;
            this.gb.TabStop = false;
            this.gb.Text = "ค้นหา";
            // 
            // btnPaidAll
            // 
            this.btnPaidAll.Location = new System.Drawing.Point(805, 24);
            this.btnPaidAll.Name = "btnPaidAll";
            this.btnPaidAll.Size = new System.Drawing.Size(66, 48);
            this.btnPaidAll.TabIndex = 133;
            this.btnPaidAll.Text = "จ่ายทั้งหมด";
            this.btnPaidAll.UseVisualStyleBackColor = true;
            this.btnPaidAll.Click += new System.EventHandler(this.btnPaidAll_Click);
            // 
            // txtCardID
            // 
            this.txtCardID.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtCardID.Location = new System.Drawing.Point(96, 83);
            this.txtCardID.Margin = new System.Windows.Forms.Padding(4);
            this.txtCardID.Name = "txtCardID";
            this.txtCardID.Size = new System.Drawing.Size(152, 24);
            this.txtCardID.TabIndex = 131;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label5.Location = new System.Drawing.Point(30, 88);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 132;
            this.label5.Text = "CardID :";
            // 
            // cboCheckMoney
            // 
            this.cboCheckMoney.AutoSize = true;
            this.cboCheckMoney.Location = new System.Drawing.Point(979, 43);
            this.cboCheckMoney.Name = "cboCheckMoney";
            this.cboCheckMoney.Size = new System.Drawing.Size(188, 20);
            this.cboCheckMoney.TabIndex = 130;
            this.cboCheckMoney.Text = "เฉพาะรายการที่แจงเงินผิดปกติ";
            this.cboCheckMoney.UseVisualStyleBackColor = true;
            // 
            // txtRefMo
            // 
            this.txtRefMo.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtRefMo.Location = new System.Drawing.Point(97, 51);
            this.txtRefMo.Margin = new System.Windows.Forms.Padding(4);
            this.txtRefMo.Name = "txtRefMo";
            this.txtRefMo.Size = new System.Drawing.Size(152, 24);
            this.txtRefMo.TabIndex = 128;
            this.txtRefMo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtRefMo_MouseClick);
            this.txtRefMo.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtRefMo_PreviewKeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label9.Location = new System.Drawing.Point(42, 56);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 17);
            this.label9.TabIndex = 129;
            this.label9.Text = "ใบยา :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label10.Location = new System.Drawing.Point(887, 26);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 17);
            this.label10.TabIndex = 57;
            this.label10.Text = "SurName :";
            this.label10.Visible = false;
            // 
            // txtSurName
            // 
            this.txtSurName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtSurName.Location = new System.Drawing.Point(890, 43);
            this.txtSurName.Margin = new System.Windows.Forms.Padding(4);
            this.txtSurName.Name = "txtSurName";
            this.txtSurName.Size = new System.Drawing.Size(82, 24);
            this.txtSurName.TabIndex = 56;
            this.txtSurName.Visible = false;
            // 
            // uBranch1
            // 
            this.uBranch1.BranchId = "";
            this.uBranch1.BranchName = "";
            this.uBranch1.Location = new System.Drawing.Point(540, 79);
            this.uBranch1.Margin = new System.Windows.Forms.Padding(3, 32, 3, 32);
            this.uBranch1.Name = "uBranch1";
            this.uBranch1.Size = new System.Drawing.Size(185, 26);
            this.uBranch1.TabIndex = 54;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label7.Location = new System.Drawing.Point(519, 23);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 17);
            this.label7.TabIndex = 50;
            this.label7.Text = "Start Date :";
            // 
            // txtStartdate
            // 
            this.txtStartdate.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtStartdate.Location = new System.Drawing.Point(599, 19);
            this.txtStartdate.Margin = new System.Windows.Forms.Padding(4);
            this.txtStartdate.Name = "txtStartdate";
            this.txtStartdate.Size = new System.Drawing.Size(126, 24);
            this.txtStartdate.TabIndex = 47;
            this.txtStartdate.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtStartdate_MouseClick);
            this.txtStartdate.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtStartdate_MouseDoubleClick);
            this.txtStartdate.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtStartdate_PreviewKeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label8.Location = new System.Drawing.Point(525, 52);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 17);
            this.label8.TabIndex = 49;
            this.label8.Text = "End Date :";
            // 
            // txtEnddate
            // 
            this.txtEnddate.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtEnddate.Location = new System.Drawing.Point(599, 48);
            this.txtEnddate.Margin = new System.Windows.Forms.Padding(4);
            this.txtEnddate.Name = "txtEnddate";
            this.txtEnddate.Size = new System.Drawing.Size(126, 24);
            this.txtEnddate.TabIndex = 48;
            this.txtEnddate.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtEnddate_MouseClick);
            this.txtEnddate.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtEnddate_MouseDoubleClick);
            this.txtEnddate.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtEnddate_PreviewKeyDown);
            // 
            // checkBoxOld
            // 
            this.checkBoxOld.AutoSize = true;
            this.checkBoxOld.Checked = true;
            this.checkBoxOld.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxOld.Location = new System.Drawing.Point(1173, 84);
            this.checkBoxOld.Name = "checkBoxOld";
            this.checkBoxOld.Size = new System.Drawing.Size(70, 20);
            this.checkBoxOld.TabIndex = 39;
            this.checkBoxOld.Text = "Old Key";
            this.checkBoxOld.UseVisualStyleBackColor = true;
            this.checkBoxOld.CheckedChanged += new System.EventHandler(this.checkBoxOld_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(890, 80);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(86, 20);
            this.checkBox4.TabIndex = 24;
            this.checkBox4.Text = "checkBox4";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.Visible = false;
            // 
            // checkBoxClose
            // 
            this.checkBoxClose.AutoSize = true;
            this.checkBoxClose.Checked = true;
            this.checkBoxClose.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxClose.Location = new System.Drawing.Point(1173, 63);
            this.checkBoxClose.Name = "checkBoxClose";
            this.checkBoxClose.Size = new System.Drawing.Size(51, 20);
            this.checkBoxClose.TabIndex = 23;
            this.checkBoxClose.Text = "Paid";
            this.checkBoxClose.UseVisualStyleBackColor = true;
            this.checkBoxClose.CheckedChanged += new System.EventHandler(this.checkBoxClose_CheckedChanged);
            // 
            // checkBoxPending
            // 
            this.checkBoxPending.AutoSize = true;
            this.checkBoxPending.Checked = true;
            this.checkBoxPending.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPending.Location = new System.Drawing.Point(1173, 43);
            this.checkBoxPending.Name = "checkBoxPending";
            this.checkBoxPending.Size = new System.Drawing.Size(69, 20);
            this.checkBoxPending.TabIndex = 22;
            this.checkBoxPending.Text = "Deposit";
            this.checkBoxPending.UseVisualStyleBackColor = true;
            this.checkBoxPending.CheckedChanged += new System.EventHandler(this.checkBoxPending_CheckedChanged);
            // 
            // checkBoxNew
            // 
            this.checkBoxNew.AutoSize = true;
            this.checkBoxNew.Checked = true;
            this.checkBoxNew.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNew.Location = new System.Drawing.Point(1173, 23);
            this.checkBoxNew.Name = "checkBoxNew";
            this.checkBoxNew.Size = new System.Drawing.Size(66, 20);
            this.checkBoxNew.TabIndex = 21;
            this.checkBoxNew.Text = "Unpaid";
            this.checkBoxNew.UseVisualStyleBackColor = true;
            this.checkBoxNew.CheckedChanged += new System.EventHandler(this.checkBoxNew_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label3.Location = new System.Drawing.Point(53, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "SO :";
            // 
            // txtVN
            // 
            this.txtVN.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtVN.Location = new System.Drawing.Point(97, 19);
            this.txtVN.Margin = new System.Windows.Forms.Padding(4);
            this.txtVN.Name = "txtVN";
            this.txtVN.Size = new System.Drawing.Size(152, 24);
            this.txtVN.TabIndex = 6;
            this.txtVN.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtVN_MouseClick);
            this.txtVN.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtVN_PreviewKeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label2.Location = new System.Drawing.Point(257, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Product :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label4.Location = new System.Drawing.Point(288, 24);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "CN :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label1.Location = new System.Drawing.Point(271, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Name :";
            // 
            // txtProduct
            // 
            this.txtProduct.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtProduct.Location = new System.Drawing.Point(331, 81);
            this.txtProduct.Margin = new System.Windows.Forms.Padding(4);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(164, 24);
            this.txtProduct.TabIndex = 12;
            this.txtProduct.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtProduct_MouseClick);
            this.txtProduct.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtSurname_PreviewKeyDown);
            // 
            // txtCN
            // 
            this.txtCN.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtCN.Location = new System.Drawing.Point(331, 17);
            this.txtCN.Margin = new System.Windows.Forms.Padding(4);
            this.txtCN.Name = "txtCN";
            this.txtCN.Size = new System.Drawing.Size(164, 24);
            this.txtCN.TabIndex = 7;
            this.txtCN.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtCN_MouseClick);
            this.txtCN.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtCN_PreviewKeyDown);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtName.Location = new System.Drawing.Point(331, 49);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(164, 24);
            this.txtName.TabIndex = 10;
            this.txtName.Text = "ทดสอบ";
            this.txtName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtName_MouseClick);
            this.txtName.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtName_PreviewKeyDown);
            // 
            // buttonFind
            // 
            this.buttonFind.BackColor = System.Drawing.Color.Transparent;
            this.buttonFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFind.Location = new System.Drawing.Point(745, 23);
            this.buttonFind.Margin = new System.Windows.Forms.Padding(3, 16314, 3, 16314);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(62, 62);
            this.buttonFind.TabIndex = 4;
            this.buttonFind.BtnClick += new AryuwatSystem.UserControls.ButtonFind.ButtonClick(this.buttonFind_BtnClick);
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
            this.ngbMain.Size = new System.Drawing.Size(1254, 26);
            this.ngbMain.TabIndex = 127;
            this.ngbMain.TotalPage = ((long)(0));
            this.ngbMain.TotalRecord = ((long)(0));
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEdit,
            this.menuDel,
            this.menuSurgical,
            this.summaryOfTreatmentToolStripMenuItem,
            this.ToolStripMenuItemUse,
            this.ToolStripMenuItemChangeCouse});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(221, 136);
            // 
            // menuEdit
            // 
            this.menuEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(220, 22);
            this.menuEdit.Text = "แก้ไขข้อมูล";
            this.menuEdit.Visible = false;
            // 
            // menuDel
            // 
            this.menuDel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.menuDel.Name = "menuDel";
            this.menuDel.Size = new System.Drawing.Size(220, 22);
            this.menuDel.Text = "ลบข้อมูล";
            this.menuDel.Visible = false;
            // 
            // menuSurgical
            // 
            this.menuSurgical.ForeColor = System.Drawing.Color.Black;
            this.menuSurgical.Name = "menuSurgical";
            this.menuSurgical.Size = new System.Drawing.Size(220, 22);
            this.menuSurgical.Tag = "surgicalfee";
            this.menuSurgical.Text = "Surgical Fee";
            this.menuSurgical.Visible = false;
            this.menuSurgical.Click += new System.EventHandler(this.menuSurgical_Click);
            // 
            // summaryOfTreatmentToolStripMenuItem
            // 
            this.summaryOfTreatmentToolStripMenuItem.Name = "summaryOfTreatmentToolStripMenuItem";
            this.summaryOfTreatmentToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.summaryOfTreatmentToolStripMenuItem.Tag = "sof";
            this.summaryOfTreatmentToolStripMenuItem.Text = "Summary of Treatment";
            this.summaryOfTreatmentToolStripMenuItem.Visible = false;
            this.summaryOfTreatmentToolStripMenuItem.Click += new System.EventHandler(this.summaryOfTreatmentToolStripMenuItem_Click);
            // 
            // ToolStripMenuItemUse
            // 
            this.ToolStripMenuItemUse.Name = "ToolStripMenuItemUse";
            this.ToolStripMenuItemUse.Size = new System.Drawing.Size(220, 22);
            this.ToolStripMenuItemUse.Text = "บันทึกข้อมูลการใช้";
            this.ToolStripMenuItemUse.Visible = false;
            this.ToolStripMenuItemUse.Click += new System.EventHandler(this.ToolStripMenuItemUse_Click);
            // 
            // ToolStripMenuItemChangeCouse
            // 
            this.ToolStripMenuItemChangeCouse.Name = "ToolStripMenuItemChangeCouse";
            this.ToolStripMenuItemChangeCouse.Size = new System.Drawing.Size(220, 22);
            this.ToolStripMenuItemChangeCouse.Text = "เปลี่ยนหรือยกเลิกคอร์ส";
            this.ToolStripMenuItemChangeCouse.Click += new System.EventHandler(this.ToolStripMenuItemChangeCouse_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 300000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmSOTByPerson
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1254, 526);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSOTByPerson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SOT List";
            this.Activated += new System.EventHandler(this.FrmSurgicalFeeList_Activated);
            this.Load += new System.EventHandler(this.FrmSurgicalFeeList_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private UserControls.NavigatoBar ngbMain;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.GroupBox gb;
        private UserControls.ButtonFind buttonFind;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripMenuItem menuDel;
        private System.Windows.Forms.ToolStripMenuItem menuSurgical;
        private System.Windows.Forms.ToolStripMenuItem summaryOfTreatmentToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.TextBox txtCN;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBoxClose;
        private System.Windows.Forms.CheckBox checkBoxPending;
        private System.Windows.Forms.CheckBox checkBoxNew;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemUse;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemChangeCouse;
        private System.Windows.Forms.CheckBox checkBoxOld;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtStartdate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEnddate;
        private UserControls.UBranchAuth uBranch1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSurName;
        private System.Windows.Forms.TextBox txtRefMo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cboCheckMoney;
        private System.Windows.Forms.TextBox txtCardID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPaidAll;
    }
}