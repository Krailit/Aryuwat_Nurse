namespace AryuwatSystem.Forms
{
    partial class PopBaseAdministrative
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.addUpadateButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewProvince = new System.Windows.Forms.DataGridView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewDistrict = new System.Windows.Forms.DataGridView();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridViewSubDistrict = new System.Windows.Forms.DataGridView();
            this.contextMenuStripPopMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuDel = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProvince)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDistrict)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSubDistrict)).BeginInit();
            this.contextMenuStripPopMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(229)))), ((int)(((byte)(218)))));
            this.panel1.Controls.Add(this.addUpadateButton);
            this.panel1.Controls.Add(this.deleteButton);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 527);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1110, 45);
            this.panel1.TabIndex = 0;
            this.panel1.Visible = false;
            // 
            // addUpadateButton
            // 
            this.addUpadateButton.Location = new System.Drawing.Point(830, 13);
            this.addUpadateButton.Name = "addUpadateButton";
            this.addUpadateButton.Size = new System.Drawing.Size(101, 23);
            this.addUpadateButton.TabIndex = 3;
            this.addUpadateButton.Text = "&Add / Update";
            this.addUpadateButton.UseVisualStyleBackColor = true;
            this.addUpadateButton.Click += new System.EventHandler(this.addUpadateButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(722, 13);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "&Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(297, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(75, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(215, 20);
            this.textBox1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewProvince);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 527);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "จังหวัด";
            // 
            // dataGridViewProvince
            // 
            this.dataGridViewProvince.AllowUserToOrderColumns = true;
            this.dataGridViewProvince.AllowUserToResizeRows = false;
            this.dataGridViewProvince.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewProvince.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(229)))), ((int)(((byte)(218)))));
            this.dataGridViewProvince.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProvince.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewProvince.Location = new System.Drawing.Point(3, 22);
            this.dataGridViewProvince.MultiSelect = false;
            this.dataGridViewProvince.Name = "dataGridViewProvince";
            this.dataGridViewProvince.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewProvince.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewProvince.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProvince.Size = new System.Drawing.Size(323, 502);
            this.dataGridViewProvince.TabIndex = 1;
            this.dataGridViewProvince.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProvince_CellClick);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(329, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 527);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewDistrict);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox2.Location = new System.Drawing.Point(332, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(380, 527);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "อำเภอ/เขต";
            // 
            // dataGridViewDistrict
            // 
            this.dataGridViewDistrict.AllowUserToOrderColumns = true;
            this.dataGridViewDistrict.AllowUserToResizeRows = false;
            this.dataGridViewDistrict.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewDistrict.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(229)))), ((int)(((byte)(218)))));
            this.dataGridViewDistrict.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDistrict.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDistrict.Location = new System.Drawing.Point(3, 22);
            this.dataGridViewDistrict.MultiSelect = false;
            this.dataGridViewDistrict.Name = "dataGridViewDistrict";
            this.dataGridViewDistrict.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewDistrict.Size = new System.Drawing.Size(374, 502);
            this.dataGridViewDistrict.TabIndex = 1;
            this.dataGridViewDistrict.VirtualMode = true;
            this.dataGridViewDistrict.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDistrict_CellClick);
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(332, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 527);
            this.splitter2.TabIndex = 4;
            this.splitter2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridViewSubDistrict);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox3.Location = new System.Drawing.Point(712, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(398, 527);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ตำบล/แขวง";
            // 
            // dataGridViewSubDistrict
            // 
            this.dataGridViewSubDistrict.AllowUserToOrderColumns = true;
            this.dataGridViewSubDistrict.AllowUserToResizeRows = false;
            this.dataGridViewSubDistrict.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewSubDistrict.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(229)))), ((int)(((byte)(218)))));
            this.dataGridViewSubDistrict.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSubDistrict.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSubDistrict.Location = new System.Drawing.Point(3, 22);
            this.dataGridViewSubDistrict.MultiSelect = false;
            this.dataGridViewSubDistrict.Name = "dataGridViewSubDistrict";
            this.dataGridViewSubDistrict.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewSubDistrict.Size = new System.Drawing.Size(392, 502);
            this.dataGridViewSubDistrict.TabIndex = 1;
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
            this.toolStripMenuUpdate.Click += new System.EventHandler(this.toolStripMenuUpdate_Click);
            // 
            // toolStripMenuDel
            // 
            this.toolStripMenuDel.Name = "toolStripMenuDel";
            this.toolStripMenuDel.Size = new System.Drawing.Size(149, 22);
            this.toolStripMenuDel.Text = "ลบรายการที่เลือก";
            this.toolStripMenuDel.Click += new System.EventHandler(this.toolStripMenuDel_Click);
            // 
            // PopBaseAdministrative
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 572);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PopBaseAdministrative";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ข้อมูลเขตการปกครอง";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProvince)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDistrict)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSubDistrict)).EndInit();
            this.contextMenuStripPopMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridViewProvince;
        private System.Windows.Forms.DataGridView dataGridViewDistrict;
        private System.Windows.Forms.DataGridView dataGridViewSubDistrict;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button addUpadateButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPopMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuUpdate;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuDel;
    }
}