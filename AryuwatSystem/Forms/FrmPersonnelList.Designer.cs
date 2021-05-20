namespace AryuwatSystem.Forms
{
    partial class FrmPersonnelList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPersonnelList));
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtELastname = new System.Windows.Forms.TextBox();
            this.txtEFirstname = new System.Windows.Forms.TextBox();
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
            this.menuPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.ngbMain = new AryuwatSystem.UserControls.NavigatoBar();
            this.uBranch1 = new AryuwatSystem.UserControls.UBranch();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 109);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            //this.dgvData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvData.RowTemplate.ReadOnly = true;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1128, 464);
            this.dgvData.TabIndex = 122;
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            this.dgvData.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvData_RowPostPaint);
            this.dgvData.Sorted += new System.EventHandler(this.dgvData_Sorted);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.uBranch1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtELastname);
            this.groupBox1.Controls.Add(this.txtEFirstname);
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
            this.groupBox1.Size = new System.Drawing.Size(1128, 109);
            this.groupBox1.TabIndex = 123;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ค้นหา";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label5.Location = new System.Drawing.Point(854, 80);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "SurName :";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label6.Location = new System.Drawing.Point(557, 80);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Name :";
            this.label6.Visible = false;
            // 
            // txtELastname
            // 
            this.txtELastname.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtELastname.Location = new System.Drawing.Point(935, 80);
            this.txtELastname.Margin = new System.Windows.Forms.Padding(4);
            this.txtELastname.Name = "txtELastname";
            this.txtELastname.Size = new System.Drawing.Size(180, 24);
            this.txtELastname.TabIndex = 9;
            this.txtELastname.Visible = false;
            this.txtELastname.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtELastname_PreviewKeyDown);
            // 
            // txtEFirstname
            // 
            this.txtEFirstname.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtEFirstname.Location = new System.Drawing.Point(617, 80);
            this.txtEFirstname.Margin = new System.Windows.Forms.Padding(4);
            this.txtEFirstname.Name = "txtEFirstname";
            this.txtEFirstname.Size = new System.Drawing.Size(180, 24);
            this.txtEFirstname.TabIndex = 7;
            this.txtEFirstname.Visible = false;
            this.txtEFirstname.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtEFirstname_PreviewKeyDown);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Location = new System.Drawing.Point(788, 20);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 11, 3, 11);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(68, 63);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Visible = false;
            // 
            // buttonFind
            // 
            this.buttonFind.AutoSize = true;
            this.buttonFind.BackColor = System.Drawing.Color.Transparent;
            this.buttonFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFind.Location = new System.Drawing.Point(667, 20);
            this.buttonFind.Margin = new System.Windows.Forms.Padding(3, 11, 3, 11);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(78, 84);
            this.buttonFind.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label3.Location = new System.Drawing.Point(95, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "EN :";
            // 
            // txtCN
            // 
            this.txtCN.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtCN.Location = new System.Drawing.Point(136, 20);
            this.txtCN.Margin = new System.Windows.Forms.Padding(4);
            this.txtCN.Name = "txtCN";
            this.txtCN.Size = new System.Drawing.Size(180, 24);
            this.txtCN.TabIndex = 0;
            this.txtCN.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtCN_PreviewKeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label2.Location = new System.Drawing.Point(403, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "สกุล :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label4.Location = new System.Drawing.Point(349, 24);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Mobile (มือถือ) :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label1.Location = new System.Drawing.Point(94, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "ชื่อ :";
            // 
            // txtSurname
            // 
            this.txtSurname.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtSurname.Location = new System.Drawing.Point(454, 49);
            this.txtSurname.Margin = new System.Windows.Forms.Padding(4);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(180, 24);
            this.txtSurname.TabIndex = 3;
            this.txtSurname.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtSurname_PreviewKeyDown);
            // 
            // txtMobile
            // 
            this.txtMobile.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtMobile.Location = new System.Drawing.Point(454, 20);
            this.txtMobile.Margin = new System.Windows.Forms.Padding(4);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(180, 24);
            this.txtMobile.TabIndex = 1;
            this.txtMobile.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtMobile_PreviewKeyDown);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtName.Location = new System.Drawing.Point(136, 49);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(180, 24);
            this.txtName.TabIndex = 2;
            this.txtName.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtName_PreviewKeyDown);
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
            this.ngbMain.Size = new System.Drawing.Size(1128, 26);
            this.ngbMain.TabIndex = 124;
            this.ngbMain.TotalPage = ((long)(0));
            this.ngbMain.TotalRecord = ((long)(0));
            // 
            // uBranch1
            // 
            this.uBranch1.BranchId = null;
            this.uBranch1.BranchName = null;
            this.uBranch1.Location = new System.Drawing.Point(76, 78);
            this.uBranch1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.uBranch1.Name = "uBranch1";
            this.uBranch1.Size = new System.Drawing.Size(240, 26);
            this.uBranch1.TabIndex = 55;
            // 
            // FrmPersonnelList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 599);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ngbMain);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmPersonnelList";
            this.Text = "ค้นหาข้อมูลพนักงาน/Employee";
            this.Activated += new System.EventHandler(this.FrmPersonnelList_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPersonnelList_FormClosing);
            this.Load += new System.EventHandler(this.FrmPersonnelList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtELastname;
        private System.Windows.Forms.TextBox txtEFirstname;
        private UserControls.UBranch uBranch1;


    }
}