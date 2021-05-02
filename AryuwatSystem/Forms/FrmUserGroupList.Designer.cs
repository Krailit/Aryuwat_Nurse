namespace AryuwatSystem.Forms
{
    partial class FrmUserGroupList
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDel = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSurgical = new System.Windows.Forms.ToolStripMenuItem();
            this.summaryOfTreatmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvData);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1204, 526);
            this.panel2.TabIndex = 1;
            // 
            // dgvData
            // 
            this.dgvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            //this.dgvData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvData.RowTemplate.ReadOnly = true;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1204, 526);
            this.dgvData.TabIndex = 125;
            this.dgvData.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvData_RowPrePaint);
            this.dgvData.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvData_RowsAdded);
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
            this.menuSurgical.Click += new System.EventHandler(this.menuSurgical_Click);
            // 
            // summaryOfTreatmentToolStripMenuItem
            // 
            this.summaryOfTreatmentToolStripMenuItem.Name = "summaryOfTreatmentToolStripMenuItem";
            this.summaryOfTreatmentToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.summaryOfTreatmentToolStripMenuItem.Tag = "sof";
            this.summaryOfTreatmentToolStripMenuItem.Text = "Summary of Treatment";
            this.summaryOfTreatmentToolStripMenuItem.Click += new System.EventHandler(this.summaryOfTreatmentToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmUserGroupList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1204, 526);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Name = "FrmUserGroupList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "กลุ่มผู้ใช้งาน";
            this.Activated += new System.EventHandler(this.FrmUserGroupList_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmUserGroupList_FormClosing);
            this.Load += new System.EventHandler(this.FrmUserGroupList_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripMenuItem menuDel;
        private System.Windows.Forms.ToolStripMenuItem menuSurgical;
        private System.Windows.Forms.ToolStripMenuItem summaryOfTreatmentToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
    }
}