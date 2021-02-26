namespace AryuwatSystem.Forms
{
    partial class FrmBookingDoctor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBookingDoctor));
            this._contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._miProperties = new System.Windows.Forms.ToolStripMenuItem();
            this._btnRight = new System.Windows.Forms.Button();
            this._btnLeft = new System.Windows.Forms.Button();
            this._btnToday = new System.Windows.Forms.Button();
            this.calendar1 = new Calendar.NET.Calendar();
            this.picExport = new System.Windows.Forms.PictureBox();
            this.picPrint = new System.Windows.Forms.PictureBox();
            this.uBranch1 = new AryuwatSystem.UserControls.UBranch();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.picAddNew = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this._contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAddNew)).BeginInit();
            this.SuspendLayout();
            // 
            // _contextMenuStrip1
            // 
            this._contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this._contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miProperties});
            this._contextMenuStrip1.Name = "_contextMenuStrip1";
            this._contextMenuStrip1.Size = new System.Drawing.Size(231, 34);
            // 
            // _miProperties
            // 
            this._miProperties.Name = "_miProperties";
            this._miProperties.Size = new System.Drawing.Size(230, 30);
            this._miProperties.Text = "Add/Delete/Edit...";
            this._miProperties.Click += new System.EventHandler(this._miProperties_Click);
            // 
            // _btnRight
            // 
            this._btnRight.BackColor = System.Drawing.Color.Transparent;
            this._btnRight.Location = new System.Drawing.Point(140, 9);
            this._btnRight.Name = "_btnRight";
            this._btnRight.Size = new System.Drawing.Size(42, 33);
            this._btnRight.TabIndex = 5;
            this._btnRight.Text = ">";
            this._btnRight.UseVisualStyleBackColor = false;
            this._btnRight.Click += new System.EventHandler(this._btnRight_Click);
            // 
            // _btnLeft
            // 
            this._btnLeft.BackColor = System.Drawing.Color.Transparent;
            this._btnLeft.Location = new System.Drawing.Point(96, 9);
            this._btnLeft.Name = "_btnLeft";
            this._btnLeft.Size = new System.Drawing.Size(42, 33);
            this._btnLeft.TabIndex = 4;
            this._btnLeft.Text = "<";
            this._btnLeft.UseVisualStyleBackColor = false;
            this._btnLeft.Click += new System.EventHandler(this._btnLeft_Click);
            // 
            // _btnToday
            // 
            this._btnToday.BackColor = System.Drawing.Color.Transparent;
            this._btnToday.Location = new System.Drawing.Point(21, 9);
            this._btnToday.Name = "_btnToday";
            this._btnToday.Size = new System.Drawing.Size(72, 33);
            this._btnToday.TabIndex = 3;
            this._btnToday.Text = "Today";
            this._btnToday.UseVisualStyleBackColor = false;
            this._btnToday.Click += new System.EventHandler(this._btnToday_Click);
            // 
            // calendar1
            // 
            this.calendar1.AllowEditingEvents = false;
            this.calendar1.BackColor = System.Drawing.Color.Transparent;
            this.calendar1.CalendarDate = new System.DateTime(2012, 4, 24, 13, 16, 0, 0);
            this.calendar1.CalendarView = Calendar.NET.CalendarViews.Month;
            this.calendar1.DateHeaderFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.calendar1.DayOfWeekFont = new System.Drawing.Font("Arial", 10F);
            this.calendar1.DaysFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.calendar1.DayViewTimeFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.calendar1.DimDisabledEvents = true;
            this.calendar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calendar1.HighlightCurrentDay = true;
            this.calendar1.LoadPresetHolidays = true;
            this.calendar1.Location = new System.Drawing.Point(0, 0);
            this.calendar1.Name = "calendar1";
            this.calendar1.ShowArrowControls = false;
            this.calendar1.ShowDashedBorderOnDisabledEvents = true;
            this.calendar1.ShowDateInHeader = true;
            this.calendar1.ShowDisabledEvents = false;
            this.calendar1.ShowEventTooltips = true;
            this.calendar1.ShowTodayButton = false;
            this.calendar1.Size = new System.Drawing.Size(805, 376);
            this.calendar1.TabIndex = 0;
            this.calendar1.TodayFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.calendar1.DoubleClick += new System.EventHandler(this.calendar1_DoubleClick);
            this.calendar1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.calendar1_MouseClick);
            // 
            // picExport
            // 
            this.picExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picExport.ErrorImage = global::AryuwatSystem.Properties.Resources.recover_excel_files;
            this.picExport.Image = global::AryuwatSystem.Properties.Resources.Print_Screen_256;
            this.picExport.Location = new System.Drawing.Point(195, 6);
            this.picExport.Name = "picExport";
            this.picExport.Size = new System.Drawing.Size(49, 42);
            this.picExport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picExport.TabIndex = 57;
            this.picExport.TabStop = false;
            this.picExport.Click += new System.EventHandler(this.picExport_Click);
            // 
            // picPrint
            // 
            this.picPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picPrint.ErrorImage = global::AryuwatSystem.Properties.Resources.recover_excel_files;
            this.picPrint.Image = global::AryuwatSystem.Properties.Resources.print_printer;
            this.picPrint.Location = new System.Drawing.Point(250, 6);
            this.picPrint.Name = "picPrint";
            this.picPrint.Size = new System.Drawing.Size(45, 42);
            this.picPrint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPrint.TabIndex = 58;
            this.picPrint.TabStop = false;
            this.picPrint.Click += new System.EventHandler(this.picPrint_Click);
            // 
            // uBranch1
            // 
            this.uBranch1.BranchId = "";
            this.uBranch1.BranchName = "";
            this.uBranch1.Location = new System.Drawing.Point(301, 18);
            this.uBranch1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.uBranch1.Name = "uBranch1";
            this.uBranch1.Size = new System.Drawing.Size(227, 24);
            this.uBranch1.TabIndex = 56;
            this.uBranch1.SelectedChanged += new System.EventHandler(this.uBranch1_SelectedChanged);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToOrderColumns = true;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvData.Location = new System.Drawing.Point(0, 376);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvData.Size = new System.Drawing.Size(805, 154);
            this.dgvData.TabIndex = 59;
            this.dgvData.Visible = false;
            // 
            // picAddNew
            // 
            this.picAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picAddNew.BackColor = System.Drawing.Color.Transparent;
            this.picAddNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAddNew.ErrorImage = global::AryuwatSystem.Properties.Resources.recover_excel_files;
            this.picAddNew.Image = global::AryuwatSystem.Properties.Resources.calendar_add_resize;
            this.picAddNew.Location = new System.Drawing.Point(606, 6);
            this.picAddNew.Name = "picAddNew";
            this.picAddNew.Size = new System.Drawing.Size(49, 42);
            this.picAddNew.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAddNew.TabIndex = 60;
            this.picAddNew.TabStop = false;
            this.toolTip1.SetToolTip(this.picAddNew, "บันทึกแบบอัตโนมัติ");
            this.picAddNew.Click += new System.EventHandler(this.picAddNew_Click);
            // 
            // FrmBookingDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(805, 530);
            this.Controls.Add(this.picAddNew);
            this.Controls.Add(this.picPrint);
            this.Controls.Add(this.picExport);
            this.Controls.Add(this.uBranch1);
            this.Controls.Add(this._btnRight);
            this.Controls.Add(this._btnLeft);
            this.Controls.Add(this._btnToday);
            this.Controls.Add(this.calendar1);
            this.Controls.Add(this.dgvData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmBookingDoctor";
            this.Text = "ตารางแพทย์";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmBookingDoctor_FormClosing);
            this.Load += new System.EventHandler(this.FrmBookingDoctor_Load);
            this.Shown += new System.EventHandler(this.FrmBookingDoctor_Shown);
            this._contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAddNew)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Calendar.NET.Calendar calendar1;
        private System.Windows.Forms.ContextMenuStrip _contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem _miProperties;
        private System.Windows.Forms.Button _btnRight;
        private System.Windows.Forms.Button _btnLeft;
        private System.Windows.Forms.Button _btnToday;
        private UserControls.UBranch uBranch1;
        private System.Windows.Forms.PictureBox picExport;
        private System.Windows.Forms.PictureBox picPrint;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.PictureBox picAddNew;
        private System.Windows.Forms.ToolTip toolTip1;
        


    }
}

