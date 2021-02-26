namespace AryuwatSystem.Forms
{
    partial class PopUserGroup
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
            this.dataGridViewUserGroup = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonCancel1 = new AryuwatSystem.UserControls.ButtonCancel();
            this.buttonSave1 = new AryuwatSystem.UserControls.ButtonSave();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.contextMenuStripPopMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuDel = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserGroup)).BeginInit();
            this.panel1.SuspendLayout();
            this.contextMenuStripPopMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewUserGroup);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(397, 363);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // dataGridViewUserGroup
            // 
            this.dataGridViewUserGroup.AllowUserToOrderColumns = true;
            this.dataGridViewUserGroup.AllowUserToResizeRows = false;
            this.dataGridViewUserGroup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewUserGroup.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(229)))), ((int)(((byte)(218)))));
            this.dataGridViewUserGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUserGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewUserGroup.Location = new System.Drawing.Point(5, 21);
            this.dataGridViewUserGroup.MultiSelect = false;
            this.dataGridViewUserGroup.Name = "dataGridViewUserGroup";
            this.dataGridViewUserGroup.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewUserGroup.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewUserGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUserGroup.Size = new System.Drawing.Size(387, 274);
            this.dataGridViewUserGroup.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonCancel1);
            this.panel1.Controls.Add(this.buttonSave1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(5, 295);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(387, 63);
            this.panel1.TabIndex = 2;
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
            this.buttonCancel1.BtnClick += new AryuwatSystem.UserControls.ButtonCancel.ButtonClick(this.buttonCancel1_BtnClick);
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
            this.buttonSave1.BtnClick += new AryuwatSystem.UserControls.ButtonSave.ButtonClick(this.buttonSave1_BtnClick);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 363);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // contextMenuStripPopMenu
            // 
            this.contextMenuStripPopMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuUpdate,
            this.toolStripMenuDel});
            this.contextMenuStripPopMenu.Name = "contextMenuStripPopMenu";
            this.contextMenuStripPopMenu.Size = new System.Drawing.Size(150, 48);
            // 
            // toolStripMenuUpdate
            // 
            this.toolStripMenuUpdate.Name = "toolStripMenuUpdate";
            this.toolStripMenuUpdate.Size = new System.Drawing.Size(149, 22);
            this.toolStripMenuUpdate.Text = "บันทึกตาราง";
            // 
            // toolStripMenuDel
            // 
            this.toolStripMenuDel.Name = "toolStripMenuDel";
            this.toolStripMenuDel.Size = new System.Drawing.Size(149, 22);
            this.toolStripMenuDel.Text = "ลบรายการที่เลือก";
            // 
            // PopUserGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 363);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.splitter1);
            this.Font = new System.Drawing.Font("Tahoma", 11F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PopUserGroup";
            this.Text = "User Group";
            this.Load += new System.EventHandler(this.PopUserGroup_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserGroup)).EndInit();
            this.panel1.ResumeLayout(false);
            this.contextMenuStripPopMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewUserGroup;
        private System.Windows.Forms.Panel panel1;
        private UserControls.ButtonCancel buttonCancel1;
        private UserControls.ButtonSave buttonSave1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPopMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuUpdate;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuDel;

    }
}