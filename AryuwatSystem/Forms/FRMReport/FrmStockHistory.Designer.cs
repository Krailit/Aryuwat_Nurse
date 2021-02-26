namespace AryuwatSystem.Forms.FRMReport
{
    partial class FrmStockHistory
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
            this.radioButtonAll = new System.Windows.Forms.RadioButton();
            this.radioButtonSell = new System.Windows.Forms.RadioButton();
            this.radioButtonReceive = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFindCode = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonPrint1 = new AryuwatSystem.UserControls.ButtonPrint();
            this.txtStartdate = new System.Windows.Forms.MaskedTextBox();
            this.txtEnddate = new System.Windows.Forms.MaskedTextBox();
            this.cboBranch = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonFind2 = new AryuwatSystem.UserControls.ButtonFind();
            this.buttonExport3 = new AryuwatSystem.UserControls.ButtonExport();
            this.dataGridViewGrouperControl1 = new Subro.Controls.DataGridViewGrouperControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxFix = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButtonAll
            // 
            this.radioButtonAll.AutoSize = true;
            this.radioButtonAll.Checked = true;
            this.radioButtonAll.Location = new System.Drawing.Point(216, 11);
            this.radioButtonAll.Name = "radioButtonAll";
            this.radioButtonAll.Size = new System.Drawing.Size(36, 17);
            this.radioButtonAll.TabIndex = 158;
            this.radioButtonAll.TabStop = true;
            this.radioButtonAll.Text = "All";
            this.radioButtonAll.UseVisualStyleBackColor = true;
            this.radioButtonAll.Click += new System.EventHandler(this.radioButtonAll_Click);
            // 
            // radioButtonSell
            // 
            this.radioButtonSell.AutoSize = true;
            this.radioButtonSell.Location = new System.Drawing.Point(216, 45);
            this.radioButtonSell.Name = "radioButtonSell";
            this.radioButtonSell.Size = new System.Drawing.Size(43, 17);
            this.radioButtonSell.TabIndex = 157;
            this.radioButtonSell.Text = "จ่าย";
            this.radioButtonSell.UseVisualStyleBackColor = true;
            this.radioButtonSell.Click += new System.EventHandler(this.radioButtonSell_Click);
            // 
            // radioButtonReceive
            // 
            this.radioButtonReceive.AutoSize = true;
            this.radioButtonReceive.Location = new System.Drawing.Point(216, 28);
            this.radioButtonReceive.Name = "radioButtonReceive";
            this.radioButtonReceive.Size = new System.Drawing.Size(38, 17);
            this.radioButtonReceive.TabIndex = 156;
            this.radioButtonReceive.Text = "รับ";
            this.radioButtonReceive.UseVisualStyleBackColor = true;
            this.radioButtonReceive.Click += new System.EventHandler(this.radioButtonReceive_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(42, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 155;
            this.label2.Text = "End :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 153;
            this.label1.Text = "Start :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Find :";
            // 
            // txtFindCode
            // 
            this.txtFindCode.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtFindCode.Location = new System.Drawing.Point(45, 4);
            this.txtFindCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtFindCode.Name = "txtFindCode";
            this.txtFindCode.Size = new System.Drawing.Size(157, 24);
            this.txtFindCode.TabIndex = 0;
            this.txtFindCode.TextChanged += new System.EventHandler(this.txtFindCode_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 104);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView1.RowTemplate.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1211, 350);
            this.dataGridView1.TabIndex = 133;
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvData_RowPostPaint);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.checkBoxFix);
            this.panel3.Controls.Add(this.buttonPrint1);
            this.panel3.Controls.Add(this.txtStartdate);
            this.panel3.Controls.Add(this.txtEnddate);
            this.panel3.Controls.Add(this.cboBranch);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.radioButtonAll);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.radioButtonSell);
            this.panel3.Controls.Add(this.buttonFind2);
            this.panel3.Controls.Add(this.radioButtonReceive);
            this.panel3.Controls.Add(this.buttonExport3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1211, 73);
            this.panel3.TabIndex = 162;
            // 
            // buttonPrint1
            // 
            this.buttonPrint1.BackColor = System.Drawing.Color.Transparent;
            this.buttonPrint1.Location = new System.Drawing.Point(618, 13);
            this.buttonPrint1.Name = "buttonPrint1";
            this.buttonPrint1.Size = new System.Drawing.Size(40, 40);
            this.buttonPrint1.TabIndex = 3082;
            this.buttonPrint1.BtnClick += new AryuwatSystem.UserControls.ButtonPrint.ButtonClick(this.buttonPrint1_BtnClick);
            // 
            // txtStartdate
            // 
            this.txtStartdate.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtStartdate.Location = new System.Drawing.Point(89, 10);
            this.txtStartdate.Margin = new System.Windows.Forms.Padding(4);
            this.txtStartdate.Mask = "00/00/0000";
            this.txtStartdate.Name = "txtStartdate";
            this.txtStartdate.Size = new System.Drawing.Size(106, 24);
            this.txtStartdate.TabIndex = 3080;
            this.txtStartdate.ValidatingType = typeof(System.DateTime);
            this.txtStartdate.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtStartdate_MouseClick);
            // 
            // txtEnddate
            // 
            this.txtEnddate.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtEnddate.Location = new System.Drawing.Point(89, 38);
            this.txtEnddate.Margin = new System.Windows.Forms.Padding(4);
            this.txtEnddate.Mask = "00/00/0000";
            this.txtEnddate.Name = "txtEnddate";
            this.txtEnddate.Size = new System.Drawing.Size(106, 24);
            this.txtEnddate.TabIndex = 3081;
            this.txtEnddate.ValidatingType = typeof(System.DateTime);
            this.txtEnddate.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtEnddate_MouseClick);
            // 
            // cboBranch
            // 
            this.cboBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBranch.FormattingEnabled = true;
            this.cboBranch.Location = new System.Drawing.Point(327, 13);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(172, 21);
            this.cboBranch.TabIndex = 3075;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label18.Location = new System.Drawing.Point(267, 16);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(60, 17);
            this.label18.TabIndex = 3076;
            this.label18.Text = "Branch :";
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::AryuwatSystem.Properties.Resources.print_printer;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(920, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(57, 51);
            this.button1.TabIndex = 3072;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonFind2
            // 
            this.buttonFind2.AutoSize = true;
            this.buttonFind2.BackColor = System.Drawing.Color.Transparent;
            this.buttonFind2.Location = new System.Drawing.Point(513, 13);
            this.buttonFind2.Margin = new System.Windows.Forms.Padding(79050, 17955, 79050, 17955);
            this.buttonFind2.Name = "buttonFind2";
            this.buttonFind2.Size = new System.Drawing.Size(43, 43);
            this.buttonFind2.TabIndex = 35;
            this.buttonFind2.BtnClick += new AryuwatSystem.UserControls.ButtonFind.ButtonClick(this.buttonFind2_BtnClick);
            // 
            // buttonExport3
            // 
            this.buttonExport3.BackColor = System.Drawing.Color.Transparent;
            this.buttonExport3.Location = new System.Drawing.Point(564, 11);
            this.buttonExport3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.buttonExport3.Name = "buttonExport3";
            this.buttonExport3.Size = new System.Drawing.Size(46, 44);
            this.buttonExport3.TabIndex = 131;
            this.buttonExport3.BtnClick += new AryuwatSystem.UserControls.ButtonExport.ButtonClick(this.buttonExport1_BtnClick);
            // 
            // dataGridViewGrouperControl1
            // 
            this.dataGridViewGrouperControl1.AllowDrop = true;
            this.dataGridViewGrouperControl1.DataGridView = this.dataGridView1;
            this.dataGridViewGrouperControl1.Location = new System.Drawing.Point(217, 5);
            this.dataGridViewGrouperControl1.Name = "dataGridViewGrouperControl1";
            this.dataGridViewGrouperControl1.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.dataGridViewGrouperControl1.Size = new System.Drawing.Size(227, 23);
            this.dataGridViewGrouperControl1.TabIndex = 3075;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dataGridViewGrouperControl1);
            this.panel1.Controls.Add(this.txtFindCode);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1211, 31);
            this.panel1.TabIndex = 163;
            // 
            // checkBoxFix
            // 
            this.checkBoxFix.AutoSize = true;
            this.checkBoxFix.Location = new System.Drawing.Point(270, 46);
            this.checkBoxFix.Name = "checkBoxFix";
            this.checkBoxFix.Size = new System.Drawing.Size(105, 17);
            this.checkBoxFix.TabIndex = 3083;
            this.checkBoxFix.Text = "เฉพาะ 6 รายการ";
            this.checkBoxFix.UseVisualStyleBackColor = true;
            // 
            // FrmStockHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 454);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Name = "FrmStockHistory";
            this.ShowInTaskbar = false;
            this.Text = "Stock History";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmStockHistory_FormClosing);
            this.Load += new System.EventHandler(this.frmStockHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFindCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButtonAll;
        private System.Windows.Forms.RadioButton radioButtonSell;
        private System.Windows.Forms.RadioButton radioButtonReceive;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
        private UserControls.ButtonFind buttonFind2;
        private UserControls.ButtonExport buttonExport3;
        private Subro.Controls.DataGridViewGrouperControl dataGridViewGrouperControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboBranch;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.MaskedTextBox txtStartdate;
        private System.Windows.Forms.MaskedTextBox txtEnddate;
        private UserControls.ButtonPrint buttonPrint1;
        private System.Windows.Forms.CheckBox checkBoxFix;
    }
}