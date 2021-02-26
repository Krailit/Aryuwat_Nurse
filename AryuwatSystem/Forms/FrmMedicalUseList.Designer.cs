namespace AryuwatSystem.Forms
{
    partial class FrmMedicalUseList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMedicalUseList));
            this.dataGridViewSelectList = new System.Windows.Forms.DataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panelName = new System.Windows.Forms.Panel();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSaveCheckCourse = new System.Windows.Forms.Button();
            this.btnPrintList = new System.Windows.Forms.Button();
            this.txtCustomerName = new System.Windows.Forms.Label();
            this.labelCN = new System.Windows.Forms.Label();
            this.lbMO = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBalanceRef = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPriceTotal = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvUsedTrans = new System.Windows.Forms.DataGridView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectList)).BeginInit();
            this.panelName.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsedTrans)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewSelectList
            // 
            this.dataGridViewSelectList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewSelectList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridViewSelectList.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewSelectList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewSelectList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewSelectList.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewSelectList.Location = new System.Drawing.Point(0, 68);
            this.dataGridViewSelectList.Name = "dataGridViewSelectList";
            this.dataGridViewSelectList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridViewSelectList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSelectList.Size = new System.Drawing.Size(952, 230);
            this.dataGridViewSelectList.TabIndex = 151;
            this.dataGridViewSelectList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSelectList_CellClick);
            this.dataGridViewSelectList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSelectList_CellContentClick);
            this.dataGridViewSelectList.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewSelectList_CellMouseMove);
            this.dataGridViewSelectList.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridViewSelectList_RowPostPaint);
            this.dataGridViewSelectList.SelectionChanged += new System.EventHandler(this.dataGridViewSelectList_SelectionChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "chief_of_staff_add_128.png");
            this.imageList1.Images.SetKeyName(1, "chief_of_staff_write_128.png");
            this.imageList1.Images.SetKeyName(2, "delete_256ssss_black.png");
            this.imageList1.Images.SetKeyName(3, "progress_notes_ok_128.png");
            this.imageList1.Images.SetKeyName(4, "progress_notes_add_128.png");
            this.imageList1.Images.SetKeyName(5, "loupe_256ssss.png");
            this.imageList1.Images.SetKeyName(6, "blackboard_write_128ssss_6vC_icon.ico");
            this.imageList1.Images.SetKeyName(7, "Business-Survey-icon.png");
            this.imageList1.Images.SetKeyName(8, "pre_resize.jpg");
            this.imageList1.Images.SetKeyName(9, "newPaper.png");
            this.imageList1.Images.SetKeyName(10, "Print641.png");
            this.imageList1.Images.SetKeyName(11, "Object Size.ico");
            this.imageList1.Images.SetKeyName(12, "JobAlert.png");
            // 
            // panelName
            // 
            this.panelName.Controls.Add(this.txtFilter);
            this.panelName.Controls.Add(this.label5);
            this.panelName.Controls.Add(this.btnSaveCheckCourse);
            this.panelName.Controls.Add(this.btnPrintList);
            this.panelName.Controls.Add(this.txtCustomerName);
            this.panelName.Controls.Add(this.labelCN);
            this.panelName.Controls.Add(this.lbMO);
            this.panelName.Controls.Add(this.label2);
            this.panelName.Controls.Add(this.txtBalanceRef);
            this.panelName.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelName.Location = new System.Drawing.Point(0, 0);
            this.panelName.Name = "panelName";
            this.panelName.Size = new System.Drawing.Size(952, 68);
            this.panelName.TabIndex = 152;
            // 
            // txtFilter
            // 
            this.txtFilter.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtFilter.Location = new System.Drawing.Point(141, 40);
            this.txtFilter.Margin = new System.Windows.Forms.Padding(4);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(121, 24);
            this.txtFilter.TabIndex = 157;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(11, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 18);
            this.label5.TabIndex = 158;
            this.label5.Text = "ค้นหาใบยา/รายการ";
            // 
            // btnSaveCheckCourse
            // 
            this.btnSaveCheckCourse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveCheckCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnSaveCheckCourse.Location = new System.Drawing.Point(801, 9);
            this.btnSaveCheckCourse.Name = "btnSaveCheckCourse";
            this.btnSaveCheckCourse.Size = new System.Drawing.Size(128, 32);
            this.btnSaveCheckCourse.TabIndex = 156;
            this.btnSaveCheckCourse.Text = "Save CheckCourse";
            this.btnSaveCheckCourse.UseVisualStyleBackColor = true;
            this.btnSaveCheckCourse.Visible = false;
            this.btnSaveCheckCourse.Click += new System.EventHandler(this.btnSaveCheckCourse_Click);
            // 
            // btnPrintList
            // 
            this.btnPrintList.Location = new System.Drawing.Point(660, 9);
            this.btnPrintList.Name = "btnPrintList";
            this.btnPrintList.Size = new System.Drawing.Size(75, 23);
            this.btnPrintList.TabIndex = 155;
            this.btnPrintList.Text = "Print รับยา";
            this.btnPrintList.UseVisualStyleBackColor = true;
            this.btnPrintList.Visible = false;
            this.btnPrintList.Click += new System.EventHandler(this.btnPrintList_Click);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.AutoSize = true;
            this.txtCustomerName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(309, 9);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(83, 19);
            this.txtCustomerName.TabIndex = 142;
            this.txtCustomerName.Text = "ชื่อลูกค้า :";
            this.txtCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCN
            // 
            this.labelCN.AutoSize = true;
            this.labelCN.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCN.Location = new System.Drawing.Point(309, 27);
            this.labelCN.Name = "labelCN";
            this.labelCN.Size = new System.Drawing.Size(48, 19);
            this.labelCN.TabIndex = 150;
            this.labelCN.Text = "CN : ";
            this.labelCN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMO
            // 
            this.lbMO.AutoSize = true;
            this.lbMO.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMO.Location = new System.Drawing.Point(11, 9);
            this.lbMO.Name = "lbMO";
            this.lbMO.Size = new System.Drawing.Size(51, 19);
            this.lbMO.TabIndex = 153;
            this.lbMO.Text = "MO : ";
            this.lbMO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(237, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 19);
            this.label2.TabIndex = 152;
            this.label2.Text = "ชื่อลูกค้า";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBalanceRef
            // 
            this.txtBalanceRef.BackColor = System.Drawing.Color.Black;
            this.txtBalanceRef.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalanceRef.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtBalanceRef.Location = new System.Drawing.Point(969, 3);
            this.txtBalanceRef.Name = "txtBalanceRef";
            this.txtBalanceRef.Size = new System.Drawing.Size(141, 27);
            this.txtBalanceRef.TabIndex = 147;
            this.txtBalanceRef.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBalanceRef.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.txtPriceTotal);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 508);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(952, 57);
            this.panel1.TabIndex = 153;
            // 
            // txtPriceTotal
            // 
            this.txtPriceTotal.BackColor = System.Drawing.Color.Black;
            this.txtPriceTotal.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPriceTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtPriceTotal.Location = new System.Drawing.Point(439, 6);
            this.txtPriceTotal.Name = "txtPriceTotal";
            this.txtPriceTotal.Size = new System.Drawing.Size(224, 40);
            this.txtPriceTotal.TabIndex = 271;
            this.txtPriceTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(668, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 33);
            this.label13.TabIndex = 270;
            this.label13.Text = "บาท";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(361, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 33);
            this.label4.TabIndex = 270;
            this.label4.Text = "รวม :";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnCancel.ForeColor = System.Drawing.Color.DimGray;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(830, 6);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(111, 41);
            this.btnCancel.TabIndex = 269;
            this.btnCancel.Text = "ปิด";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvUsedTrans);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 298);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(952, 210);
            this.groupBox1.TabIndex = 155;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ข้อมูลการใช้คอร์ส";
            // 
            // dgvUsedTrans
            // 
            this.dgvUsedTrans.AllowUserToAddRows = false;
            this.dgvUsedTrans.AllowUserToDeleteRows = false;
            this.dgvUsedTrans.AllowUserToOrderColumns = true;
            this.dgvUsedTrans.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsedTrans.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvUsedTrans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsedTrans.Location = new System.Drawing.Point(3, 16);
            this.dgvUsedTrans.Name = "dgvUsedTrans";
            this.dgvUsedTrans.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvUsedTrans.RowTemplate.Height = 35;
            this.dgvUsedTrans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsedTrans.Size = new System.Drawing.Size(946, 191);
            this.dgvUsedTrans.TabIndex = 150;
            this.dgvUsedTrans.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsedTrans_CellClick);
            this.dgvUsedTrans.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsedTrans_CellContentClick);
            this.dgvUsedTrans.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvUsedTrans_CellMouseDoubleClick);
            this.dgvUsedTrans.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvUsedTrans_CellMouseMove);
            this.dgvUsedTrans.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvUsedTrans_RowPostPaint);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 298);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(952, 3);
            this.splitter1.TabIndex = 156;
            this.splitter1.TabStop = false;
            // 
            // FrmMedicalUseList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 565);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewSelectList);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMedicalUseList";
            this.Text = "Course(Record)";
            this.Load += new System.EventHandler(this.FrmMedicalUseList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectList)).EndInit();
            this.panelName.ResumeLayout(false);
            this.panelName.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsedTrans)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSelectList;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panelName;
        internal System.Windows.Forms.TextBox txtBalanceRef;
        private System.Windows.Forms.Label txtCustomerName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPriceTotal;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label labelCN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbMO;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvUsedTrans;
        private System.Windows.Forms.Button btnPrintList;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button btnSaveCheckCourse;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label5;
    }
}