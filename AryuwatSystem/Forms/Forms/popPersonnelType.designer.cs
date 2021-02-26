namespace DermasterSystem.Forms
{
    partial class popPersonnelType
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewPersonnelType = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.contextMenuStripPopMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuDel = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonCancel1 = new DermasterSystem.UserControls.ButtonCancel();
            this.buttonSave1 = new DermasterSystem.UserControls.ButtonSave();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPersonnelType)).BeginInit();
            this.panel1.SuspendLayout();
            this.contextMenuStripPopMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewPersonnelType);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(442, 499);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // dataGridViewPersonnelType
            // 
            this.dataGridViewPersonnelType.AllowUserToOrderColumns = true;
            this.dataGridViewPersonnelType.AllowUserToResizeRows = false;
            this.dataGridViewPersonnelType.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewPersonnelType.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(232)))), ((int)(((byte)(229)))));
            this.dataGridViewPersonnelType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPersonnelType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPersonnelType.Location = new System.Drawing.Point(5, 21);
            this.dataGridViewPersonnelType.MultiSelect = false;
            this.dataGridViewPersonnelType.Name = "dataGridViewPersonnelType";
            this.dataGridViewPersonnelType.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewPersonnelType.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewPersonnelType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPersonnelType.Size = new System.Drawing.Size(432, 410);
            this.dataGridViewPersonnelType.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonCancel1);
            this.panel1.Controls.Add(this.buttonSave1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(5, 431);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(432, 63);
            this.panel1.TabIndex = 2;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 499);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // contextMenuStripPopMenu
            // 
            this.contextMenuStripPopMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuUpdate,
            this.toolStripMenuDel});
            this.contextMenuStripPopMenu.Name = "contextMenuStripPopMenu";
            this.contextMenuStripPopMenu.Size = new System.Drawing.Size(155, 48);
            // 
            // toolStripMenuUpdate
            // 
            this.toolStripMenuUpdate.Name = "toolStripMenuUpdate";
            this.toolStripMenuUpdate.Size = new System.Drawing.Size(154, 22);
            this.toolStripMenuUpdate.Text = "บันทึกตาราง";
            this.toolStripMenuUpdate.Click += new System.EventHandler(this.toolStripMenuUpdate_Click);
            // 
            // toolStripMenuDel
            // 
            this.toolStripMenuDel.Name = "toolStripMenuDel";
            this.toolStripMenuDel.Size = new System.Drawing.Size(154, 22);
            this.toolStripMenuDel.Text = "ลบรายการที่เลือก";
            this.toolStripMenuDel.Click += new System.EventHandler(this.toolStripMenuDel_Click);
            // 
            // buttonCancel1
            // 
            this.buttonCancel1.BackColor = System.Drawing.Color.Transparent;
            this.buttonCancel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancel1.Location = new System.Drawing.Point(303, 9);
            this.buttonCancel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCancel1.Name = "buttonCancel1";
            this.buttonCancel1.Size = new System.Drawing.Size(50, 52);
            this.buttonCancel1.TabIndex = 1;
            this.buttonCancel1.BtnClick += new DermasterSystem.UserControls.ButtonCancel.ButtonClick(this.buttonCancel1_BtnClick);
            // 
            // buttonSave1
            // 
            this.buttonSave1.BackColor = System.Drawing.Color.Transparent;
            this.buttonSave1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSave1.Location = new System.Drawing.Point(245, 8);
            this.buttonSave1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSave1.Name = "buttonSave1";
            this.buttonSave1.Size = new System.Drawing.Size(50, 52);
            this.buttonSave1.TabIndex = 0;
            this.buttonSave1.BtnClick += new DermasterSystem.UserControls.ButtonSave.ButtonClick(this.buttonSave1_BtnClick);
            // 
            // popPersonnelType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 499);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "popPersonnelType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ข้อมูลตำแหน่งพนักงาน";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPersonnelType)).EndInit();
            this.panel1.ResumeLayout(false);
            this.contextMenuStripPopMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.DataGridView dataGridViewPersonnelType;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPopMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuUpdate;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuDel;
        private System.Windows.Forms.Panel panel1;
        private UserControls.ButtonSave buttonSave1;
        private UserControls.ButtonCancel buttonCancel1;
    }
}