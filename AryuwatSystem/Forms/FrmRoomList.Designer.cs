namespace AryuwatSystem.Forms
{
    partial class FrmRoomList
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddRoom = new System.Windows.Forms.Button();
            this.buttonFind1 = new AryuwatSystem.UserControls.ButtonFind();
            this.buttonFind = new AryuwatSystem.UserControls.ButtonFind();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFindName = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDel = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1201, 526);
            this.panel2.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvData);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 101);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1201, 392);
            this.groupBox4.TabIndex = 129;
            this.groupBox4.TabStop = false;
            // 
            // dgvData
            // 
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(3, 16);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            //this.dgvData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvData.RowTemplate.ReadOnly = true;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1195, 373);
            this.dgvData.TabIndex = 125;
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            this.dgvData.Sorted += new System.EventHandler(this.dgvData_Sorted);
            // 
            // groupBox3
            // 
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 493);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1201, 33);
            this.groupBox3.TabIndex = 128;
            this.groupBox3.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnAddRoom);
            this.groupBox1.Controls.Add(this.buttonFind1);
            this.groupBox1.Controls.Add(this.buttonFind);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtFindName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1201, 101);
            this.groupBox1.TabIndex = 126;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ค้นหา";
            // 
            // btnAddRoom
            // 
            this.btnAddRoom.Image = global::AryuwatSystem.Properties.Resources.add_icon;
            this.btnAddRoom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddRoom.Location = new System.Drawing.Point(26, 39);
            this.btnAddRoom.Name = "btnAddRoom";
            this.btnAddRoom.Size = new System.Drawing.Size(165, 33);
            this.btnAddRoom.TabIndex = 10;
            this.btnAddRoom.Text = "Room";
            this.btnAddRoom.UseVisualStyleBackColor = true;
            this.btnAddRoom.Click += new System.EventHandler(this.btnAddRoom_Click);
            // 
            // buttonFind1
            // 
            this.buttonFind1.BackColor = System.Drawing.Color.Transparent;
            this.buttonFind1.Location = new System.Drawing.Point(613, 20);
            this.buttonFind1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonFind1.Name = "buttonFind1";
            this.buttonFind1.Size = new System.Drawing.Size(66, 67);
            this.buttonFind1.TabIndex = 6;
            this.buttonFind1.BtnClick += new AryuwatSystem.UserControls.ButtonFind.ButtonClick(this.buttonFind1_BtnClick);
            // 
            // buttonFind
            // 
            this.buttonFind.AutoSize = true;
            this.buttonFind.BackColor = System.Drawing.Color.Transparent;
            this.buttonFind.Location = new System.Drawing.Point(3499, 39);
            this.buttonFind.Margin = new System.Windows.Forms.Padding(0);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(677, 818);
            this.buttonFind.TabIndex = 4;
            this.buttonFind.BtnClick += new AryuwatSystem.UserControls.ButtonFind.ButtonClick(this.buttonFind_BtnClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label3.Location = new System.Drawing.Point(241, 23);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Room Code/Name:";
            // 
            // txtFindName
            // 
            this.txtFindName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtFindName.Location = new System.Drawing.Point(241, 44);
            this.txtFindName.Margin = new System.Windows.Forms.Padding(4);
            this.txtFindName.Name = "txtFindName";
            this.txtFindName.Size = new System.Drawing.Size(320, 24);
            this.txtFindName.TabIndex = 1;
            this.txtFindName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtFindName_MouseClick);
            this.txtFindName.TextChanged += new System.EventHandler(this.txtFindName_TextChanged);
            this.txtFindName.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtFindName_PreviewKeyDown);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 500;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ShowAlways = true;
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
            // FrmRoomList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1201, 526);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Name = "FrmRoomList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Room List";
            this.panel2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.GroupBox groupBox1;
        private UserControls.ButtonFind buttonFind;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFindName;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripMenuItem menuDel;
        private System.Windows.Forms.ToolStripMenuItem menuPreview;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private UserControls.ButtonFind buttonFind1;
        private System.Windows.Forms.Button btnAddRoom;
    }
}