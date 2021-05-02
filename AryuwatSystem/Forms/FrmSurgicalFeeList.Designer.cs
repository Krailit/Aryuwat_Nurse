namespace AryuwatSystem.Forms
{
    partial class FrmSurgicalFeeList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSurgicalFeeList));
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRefMo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtStartdate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEnddate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDel = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSurgical = new System.Windows.Forms.ToolStripMenuItem();
            this.summaryOfTreatmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.uBranch1 = new AryuwatSystem.UserControls.UBranch();
            this.buttonFind = new AryuwatSystem.UserControls.ButtonFind();
            this.ngbMain = new AryuwatSystem.UserControls.NavigatoBar();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvData);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.ngbMain);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1269, 526);
            this.panel2.TabIndex = 1;
            // 
            // dgvData
            // 
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 120);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            //this.dgvData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvData.RowTemplate.ReadOnly = true;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvData.Size = new System.Drawing.Size(1269, 380);
            this.dgvData.TabIndex = 125;
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            this.dgvData.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellMouseEnter);
            this.dgvData.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvData_RowPrePaint);
            this.dgvData.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvData_RowsAdded);
            this.dgvData.Paint += new System.Windows.Forms.PaintEventHandler(this.dgvData_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.uBranch1);
            this.groupBox1.Controls.Add(this.txtRefMo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtStartdate);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtEnddate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Controls.Add(this.checkBoxClose);
            this.groupBox1.Controls.Add(this.checkBoxPending);
            this.groupBox1.Controls.Add(this.checkBoxNew);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtVN);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtProduct);
            this.groupBox1.Controls.Add(this.txtCN);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.buttonFind);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1269, 120);
            this.groupBox1.TabIndex = 126;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ค้นหา";
            // 
            // txtRefMo
            // 
            this.txtRefMo.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtRefMo.Location = new System.Drawing.Point(279, 25);
            this.txtRefMo.Margin = new System.Windows.Forms.Padding(4);
            this.txtRefMo.Name = "txtRefMo";
            this.txtRefMo.Size = new System.Drawing.Size(98, 24);
            this.txtRefMo.TabIndex = 47;
            this.txtRefMo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtRefMo_MouseClick);
            this.txtRefMo.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtRefMo_PreviewKeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label5.Location = new System.Drawing.Point(228, 29);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 17);
            this.label5.TabIndex = 48;
            this.label5.Text = "RefMO :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label7.Location = new System.Drawing.Point(616, 28);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 17);
            this.label7.TabIndex = 46;
            this.label7.Text = "Start Date :";
            // 
            // txtStartdate
            // 
            this.txtStartdate.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtStartdate.Location = new System.Drawing.Point(696, 24);
            this.txtStartdate.Margin = new System.Windows.Forms.Padding(4);
            this.txtStartdate.Name = "txtStartdate";
            this.txtStartdate.Size = new System.Drawing.Size(148, 24);
            this.txtStartdate.TabIndex = 43;
            this.txtStartdate.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtStartdate_MouseClick);
            this.txtStartdate.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtStartdate_MouseDoubleClick);
            this.txtStartdate.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtStartdate_PreviewKeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label8.Location = new System.Drawing.Point(622, 57);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 17);
            this.label8.TabIndex = 45;
            this.label8.Text = "End Date :";
            // 
            // txtEnddate
            // 
            this.txtEnddate.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtEnddate.Location = new System.Drawing.Point(696, 53);
            this.txtEnddate.Margin = new System.Windows.Forms.Padding(4);
            this.txtEnddate.Name = "txtEnddate";
            this.txtEnddate.Size = new System.Drawing.Size(148, 24);
            this.txtEnddate.TabIndex = 44;
            this.txtEnddate.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtEnddate_MouseClick);
            this.txtEnddate.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtEnddate_MouseDoubleClick);
            this.txtEnddate.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtEnddate_PreviewKeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label6.Location = new System.Drawing.Point(863, 20);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 17);
            this.label6.TabIndex = 20;
            this.label6.Text = "Status (สถานะ)";
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(959, 63);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(86, 20);
            this.checkBox4.TabIndex = 19;
            this.checkBox4.Text = "checkBox4";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.Visible = false;
            // 
            // checkBoxClose
            // 
            this.checkBoxClose.AutoSize = true;
            this.checkBoxClose.Checked = true;
            this.checkBoxClose.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxClose.Location = new System.Drawing.Point(867, 40);
            this.checkBoxClose.Name = "checkBoxClose";
            this.checkBoxClose.Size = new System.Drawing.Size(65, 20);
            this.checkBoxClose.TabIndex = 18;
            this.checkBoxClose.Text = "Closed";
            this.checkBoxClose.UseVisualStyleBackColor = true;
            this.checkBoxClose.CheckedChanged += new System.EventHandler(this.checkBoxClose_CheckedChanged);
            // 
            // checkBoxPending
            // 
            this.checkBoxPending.AutoSize = true;
            this.checkBoxPending.Checked = true;
            this.checkBoxPending.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPending.Location = new System.Drawing.Point(867, 60);
            this.checkBoxPending.Name = "checkBoxPending";
            this.checkBoxPending.Size = new System.Drawing.Size(72, 20);
            this.checkBoxPending.TabIndex = 17;
            this.checkBoxPending.Text = "Pending";
            this.checkBoxPending.UseVisualStyleBackColor = true;
            this.checkBoxPending.CheckedChanged += new System.EventHandler(this.checkBoxPending_CheckedChanged);
            // 
            // checkBoxNew
            // 
            this.checkBoxNew.AutoSize = true;
            this.checkBoxNew.Location = new System.Drawing.Point(959, 43);
            this.checkBoxNew.Name = "checkBoxNew";
            this.checkBoxNew.Size = new System.Drawing.Size(52, 20);
            this.checkBoxNew.TabIndex = 16;
            this.checkBoxNew.Text = "New";
            this.checkBoxNew.UseVisualStyleBackColor = true;
            this.checkBoxNew.Visible = false;
            this.checkBoxNew.CheckedChanged += new System.EventHandler(this.checkBoxNew_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label3.Location = new System.Drawing.Point(58, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "MO :";
            // 
            // txtVN
            // 
            this.txtVN.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtVN.Location = new System.Drawing.Point(99, 24);
            this.txtVN.Margin = new System.Windows.Forms.Padding(4);
            this.txtVN.Name = "txtVN";
            this.txtVN.Size = new System.Drawing.Size(129, 24);
            this.txtVN.TabIndex = 6;
            this.txtVN.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtVN_MouseClick);
            this.txtVN.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtVN_PreviewKeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label2.Location = new System.Drawing.Point(354, 56);
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
            this.label4.Location = new System.Drawing.Point(385, 28);
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
            this.label1.Location = new System.Drawing.Point(43, 56);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Name :";
            // 
            // txtProduct
            // 
            this.txtProduct.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtProduct.Location = new System.Drawing.Point(426, 52);
            this.txtProduct.Margin = new System.Windows.Forms.Padding(4);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(180, 24);
            this.txtProduct.TabIndex = 12;
            this.txtProduct.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtProduct_MouseClick);
            this.txtProduct.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtSurname_PreviewKeyDown);
            // 
            // txtCN
            // 
            this.txtCN.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtCN.Location = new System.Drawing.Point(426, 24);
            this.txtCN.Margin = new System.Windows.Forms.Padding(4);
            this.txtCN.Name = "txtCN";
            this.txtCN.Size = new System.Drawing.Size(180, 24);
            this.txtCN.TabIndex = 7;
            this.txtCN.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtCN_MouseClick);
            this.txtCN.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtCN_PreviewKeyDown);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtName.Location = new System.Drawing.Point(99, 52);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(247, 24);
            this.txtName.TabIndex = 10;
            this.txtName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtName_MouseClick);
            this.txtName.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtName_PreviewKeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEdit,
            this.menuDel,
            this.menuSurgical,
            this.summaryOfTreatmentToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(221, 92);
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
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // uBranch1
            // 
            this.uBranch1.BranchId = "";
            this.uBranch1.BranchName = "";
            this.uBranch1.Location = new System.Drawing.Point(37, 84);
            this.uBranch1.Margin = new System.Windows.Forms.Padding(3, 11, 3, 11);
            this.uBranch1.Name = "uBranch1";
            this.uBranch1.Size = new System.Drawing.Size(309, 32);
            this.uBranch1.TabIndex = 55;
            // 
            // buttonFind
            // 
            this.buttonFind.BackColor = System.Drawing.Color.Transparent;
            this.buttonFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFind.Location = new System.Drawing.Point(1051, 23);
            this.buttonFind.Margin = new System.Windows.Forms.Padding(3, 282406489, 3, 282406489);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(53, 60);
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
            this.ngbMain.Size = new System.Drawing.Size(1269, 26);
            this.ngbMain.TabIndex = 127;
            this.ngbMain.TotalPage = ((long)(0));
            this.ngbMain.TotalRecord = ((long)(0));
            // 
            // FrmSurgicalFeeList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1269, 526);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSurgicalFeeList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Job Cost List";
            this.Activated += new System.EventHandler(this.FrmSurgicalFeeList_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSurgicalFeeList_FormClosing);
            this.Load += new System.EventHandler(this.FrmSurgicalFeeList_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private UserControls.NavigatoBar ngbMain;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.GroupBox groupBox1;
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBoxClose;
        private System.Windows.Forms.CheckBox checkBoxPending;
        private System.Windows.Forms.CheckBox checkBoxNew;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtStartdate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEnddate;
        private System.Windows.Forms.TextBox txtRefMo;
        private System.Windows.Forms.Label label5;
        private UserControls.UBranch uBranch1;
    }
}