namespace AryuwatSystem.Forms
{
    partial class FrmCustomerList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustomerList));
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMemID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIDCard = new System.Windows.Forms.TextBox();
            this.label120 = new System.Windows.Forms.Label();
            this.m_ListReaderCard = new System.Windows.Forms.ComboBox();
            this.pictureBoxReadCard = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBirthDate = new System.Windows.Forms.MaskedTextBox();
            this.btnRefresh = new AryuwatSystem.UserControls.ButtonRefresh();
            this.buttonFind = new AryuwatSystem.UserControls.ButtonFind();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.labelยาToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printLabelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printLabelForSaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.beforAfterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.oPDScanToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.checkCourseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.memberCardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.opdScanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ngbMain = new AryuwatSystem.UserControls.NavigatoBar();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReadCard)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 92);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgvData.RowTemplate.ReadOnly = true;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1147, 481);
            this.dgvData.TabIndex = 122;
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            this.dgvData.Sorted += new System.EventHandler(this.dgvData_Sorted);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtMemID);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtIDCard);
            this.groupBox1.Controls.Add(this.label120);
            this.groupBox1.Controls.Add(this.m_ListReaderCard);
            this.groupBox1.Controls.Add(this.pictureBoxReadCard);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtBirthDate);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.buttonFind);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCN);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSurname);
            this.groupBox1.Controls.Add(this.txtMobile);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1147, 92);
            this.groupBox1.TabIndex = 123;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ค้นหา";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label7.Location = new System.Drawing.Point(321, 33);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 17);
            this.label7.TabIndex = 3104;
            this.label7.Text = "MemberID :";
            // 
            // txtMemID
            // 
            this.txtMemID.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtMemID.Location = new System.Drawing.Point(401, 29);
            this.txtMemID.Margin = new System.Windows.Forms.Padding(4);
            this.txtMemID.Name = "txtMemID";
            this.txtMemID.Size = new System.Drawing.Size(104, 24);
            this.txtMemID.TabIndex = 3103;
            this.txtMemID.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtMemID_PreviewKeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label6.Location = new System.Drawing.Point(642, 65);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 17);
            this.label6.TabIndex = 3102;
            this.label6.Text = "IDCard :";
            // 
            // txtIDCard
            // 
            this.txtIDCard.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtIDCard.Location = new System.Drawing.Point(702, 60);
            this.txtIDCard.Margin = new System.Windows.Forms.Padding(4);
            this.txtIDCard.Name = "txtIDCard";
            this.txtIDCard.Size = new System.Drawing.Size(152, 24);
            this.txtIDCard.TabIndex = 3101;
            // 
            // label120
            // 
            this.label120.AutoSize = true;
            this.label120.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label120.Location = new System.Drawing.Point(915, 63);
            this.label120.Name = "label120";
            this.label120.Size = new System.Drawing.Size(95, 20);
            this.label120.TabIndex = 3100;
            this.label120.Text = "เครื่องอ่านบัตร";
            this.label120.Visible = false;
            // 
            // m_ListReaderCard
            // 
            this.m_ListReaderCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.m_ListReaderCard.FormattingEnabled = true;
            this.m_ListReaderCard.Location = new System.Drawing.Point(1016, 55);
            this.m_ListReaderCard.Name = "m_ListReaderCard";
            this.m_ListReaderCard.Size = new System.Drawing.Size(115, 28);
            this.m_ListReaderCard.TabIndex = 3099;
            this.m_ListReaderCard.Visible = false;
            // 
            // pictureBoxReadCard
            // 
            this.pictureBoxReadCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxReadCard.Image = global::AryuwatSystem.Properties.Resources.smart_card_readerReload;
            this.pictureBoxReadCard.Location = new System.Drawing.Point(27, 29);
            this.pictureBoxReadCard.Name = "pictureBoxReadCard";
            this.pictureBoxReadCard.Size = new System.Drawing.Size(36, 33);
            this.pictureBoxReadCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxReadCard.TabIndex = 3097;
            this.pictureBoxReadCard.TabStop = false;
            this.pictureBoxReadCard.Click += new System.EventHandler(this.pictureBoxReadCard_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label5.Location = new System.Drawing.Point(674, 36);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 17);
            this.label5.TabIndex = 59;
            this.label5.Text = "BirthDate :";
            // 
            // txtBirthDate
            // 
            this.txtBirthDate.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtBirthDate.Location = new System.Drawing.Point(748, 32);
            this.txtBirthDate.Margin = new System.Windows.Forms.Padding(4);
            this.txtBirthDate.Mask = "00/00/0000";
            this.txtBirthDate.Name = "txtBirthDate";
            this.txtBirthDate.Size = new System.Drawing.Size(106, 24);
            this.txtBirthDate.TabIndex = 58;
            this.txtBirthDate.ValidatingType = typeof(System.DateTime);
            this.txtBirthDate.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtBirthDate_MouseClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoSize = true;
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Location = new System.Drawing.Point(945, 17);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(65, 64);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Visible = false;
            this.btnRefresh.BtnClick += new AryuwatSystem.UserControls.ButtonRefresh.ButtonClick(this.btnRefresh_BtnClick_1);
            // 
            // buttonFind
            // 
            this.buttonFind.AutoSize = true;
            this.buttonFind.BackColor = System.Drawing.Color.Transparent;
            this.buttonFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFind.Location = new System.Drawing.Point(872, 13);
            this.buttonFind.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(55, 57);
            this.buttonFind.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label3.Location = new System.Drawing.Point(95, 33);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "CN :";
            // 
            // txtCN
            // 
            this.txtCN.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtCN.Location = new System.Drawing.Point(136, 29);
            this.txtCN.Margin = new System.Windows.Forms.Padding(4);
            this.txtCN.Name = "txtCN";
            this.txtCN.Size = new System.Drawing.Size(180, 24);
            this.txtCN.TabIndex = 0;
            this.txtCN.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtCN_MouseClick);
            this.txtCN.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtCN_PreviewKeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label2.Location = new System.Drawing.Point(327, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Surname :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label4.Location = new System.Drawing.Point(508, 34);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Mobile :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label1.Location = new System.Drawing.Point(77, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name :";
            // 
            // txtSurname
            // 
            this.txtSurname.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtSurname.Location = new System.Drawing.Point(401, 58);
            this.txtSurname.Margin = new System.Windows.Forms.Padding(4);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(161, 24);
            this.txtSurname.TabIndex = 3;
            this.txtSurname.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSurname_MouseClick);
            this.txtSurname.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtSurname_PreviewKeyDown);
            // 
            // txtMobile
            // 
            this.txtMobile.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtMobile.Location = new System.Drawing.Point(562, 30);
            this.txtMobile.Margin = new System.Windows.Forms.Padding(4);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(104, 24);
            this.txtMobile.TabIndex = 1;
            this.txtMobile.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtMobile_MouseClick);
            this.txtMobile.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtMobile_PreviewKeyDown);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtName.Location = new System.Drawing.Point(136, 58);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(180, 24);
            this.txtName.TabIndex = 2;
            this.txtName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtName_MouseClick);
            this.txtName.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtName_PreviewKeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEdit,
            this.menuDel,
            this.toolStripMenuItem2,
            this.printLabelToolStripMenuItem,
            this.printLabelForSaleToolStripMenuItem,
            this.labelยาToolStripMenuItem,
            this.menuPreview,
            this.toolStripSeparator1,
            this.beforAfterToolStripMenuItem,
            this.toolStripMenuItem4,
            this.oPDScanToolStripMenuItem1,
            this.checkCourseToolStripMenuItem,
            this.memberCardToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(271, 324);
            // 
            // menuEdit
            // 
            this.menuEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(264, 28);
            this.menuEdit.Text = "แก้ไขข้อมูล/Edit";
            // 
            // menuDel
            // 
            this.menuDel.Font = new System.Drawing.Font("Tahoma", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuDel.ForeColor = System.Drawing.Color.Red;
            this.menuDel.Name = "menuDel";
            this.menuDel.Size = new System.Drawing.Size(264, 28);
            this.menuDel.Text = "ลบข้อมูล/Delete";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(261, 6);
            // 
            // labelยาToolStripMenuItem
            // 
            this.labelยาToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelยาToolStripMenuItem.Name = "labelยาToolStripMenuItem";
            this.labelยาToolStripMenuItem.Size = new System.Drawing.Size(264, 28);
            this.labelยาToolStripMenuItem.Text = "Print Label ยา";
            this.labelยาToolStripMenuItem.Click += new System.EventHandler(this.labelยาToolStripMenuItem_Click);
            // 
            // printLabelToolStripMenuItem
            // 
            this.printLabelToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printLabelToolStripMenuItem.Name = "printLabelToolStripMenuItem";
            this.printLabelToolStripMenuItem.Size = new System.Drawing.Size(270, 28);
            this.printLabelToolStripMenuItem.Text = "Print Label OR&&Anti";
            this.printLabelToolStripMenuItem.Click += new System.EventHandler(this.printLabelToolStripMenuItem_Click);
            // 
            // printLabelForSaleToolStripMenuItem
            // 
            this.printLabelForSaleToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.printLabelForSaleToolStripMenuItem.Name = "printLabelForSaleToolStripMenuItem";
            this.printLabelForSaleToolStripMenuItem.Size = new System.Drawing.Size(264, 28);
            this.printLabelForSaleToolStripMenuItem.Text = "Print Label For Sale";
            this.printLabelForSaleToolStripMenuItem.Click += new System.EventHandler(this.printLabelForSaleToolStripMenuItem_Click);
            // 
            // menuPreview
            // 
            this.menuPreview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.menuPreview.Name = "menuPreview";
            this.menuPreview.Size = new System.Drawing.Size(264, 28);
            this.menuPreview.Text = "ดูรายการข้อมูล";
            this.menuPreview.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(261, 6);
            // 
            // beforAfterToolStripMenuItem
            // 
            this.beforAfterToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.beforAfterToolStripMenuItem.Name = "beforAfterToolStripMenuItem";
            this.beforAfterToolStripMenuItem.Size = new System.Drawing.Size(264, 28);
            this.beforAfterToolStripMenuItem.Text = "Before&&After";
            this.beforAfterToolStripMenuItem.Click += new System.EventHandler(this.beforAfterToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(261, 6);
            // 
            // oPDScanToolStripMenuItem1
            // 
            this.oPDScanToolStripMenuItem1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oPDScanToolStripMenuItem1.Name = "oPDScanToolStripMenuItem1";
            this.oPDScanToolStripMenuItem1.Size = new System.Drawing.Size(264, 28);
            this.oPDScanToolStripMenuItem1.Text = "OPD Scan";
            this.oPDScanToolStripMenuItem1.Click += new System.EventHandler(this.oPDScanToolStripMenuItem1_Click);
            // 
            // checkCourseToolStripMenuItem
            // 
            this.checkCourseToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.checkCourseToolStripMenuItem.Name = "checkCourseToolStripMenuItem";
            this.checkCourseToolStripMenuItem.Size = new System.Drawing.Size(264, 28);
            this.checkCourseToolStripMenuItem.Text = "Check Course";
            this.checkCourseToolStripMenuItem.Click += new System.EventHandler(this.checkCourseToolStripMenuItem_Click);
            // 
            // memberCardToolStripMenuItem
            // 
            this.memberCardToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.memberCardToolStripMenuItem.Name = "memberCardToolStripMenuItem";
            this.memberCardToolStripMenuItem.Size = new System.Drawing.Size(264, 28);
            this.memberCardToolStripMenuItem.Text = "Member Card";
            this.memberCardToolStripMenuItem.Click += new System.EventHandler(this.memberCardToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Checked = true;
            this.toolStripMenuItem3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(204, 28);
            this.toolStripMenuItem3.Text = "________________";
            // 
            // opdScanToolStripMenuItem
            // 
            this.opdScanToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opdScanToolStripMenuItem.Name = "opdScanToolStripMenuItem";
            this.opdScanToolStripMenuItem.Size = new System.Drawing.Size(202, 28);
            this.opdScanToolStripMenuItem.Text = "Opd Scan";
            this.opdScanToolStripMenuItem.Click += new System.EventHandler(this.opdScanToolStripMenuItem_Click);
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
            this.ngbMain.Size = new System.Drawing.Size(1147, 26);
            this.ngbMain.TabIndex = 124;
            this.ngbMain.TotalPage = ((long)(0));
            this.ngbMain.TotalRecord = ((long)(0));
            // 
            // FrmCustomerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 599);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ngbMain);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmCustomerList";
            this.Text = "ข้อมูลลูกค้า/Customer";
            this.Activated += new System.EventHandler(this.FrmCustomerList_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCustomerList_FormClosing);
            this.Load += new System.EventHandler(this.FrmCustomerList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReadCard)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.GroupBox groupBox1;
        private UserControls.ButtonRefresh btnRefresh;
        private UserControls.ButtonFind buttonFind;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.TextBox txtName;
        private UserControls.NavigatoBar ngbMain;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripMenuItem menuDel;
        private System.Windows.Forms.ToolStripMenuItem menuPreview;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox txtBirthDate;
        private System.Windows.Forms.ToolStripMenuItem printLabelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beforAfterToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem opdScanToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem oPDScanToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem checkCourseToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBoxReadCard;
        private System.Windows.Forms.Label label120;
        private System.Windows.Forms.ComboBox m_ListReaderCard;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIDCard;
        private System.Windows.Forms.ToolStripMenuItem labelยาToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem memberCardToolStripMenuItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMemID;
        private System.Windows.Forms.ToolStripMenuItem printLabelForSaleToolStripMenuItem;


    }
}