namespace AryuwatSystem.Forms
{
    partial class popRFDList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(popRFDList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBoxSearch = new System.Windows.Forms.GroupBox();
            this.dataGridViewREQItem = new System.Windows.Forms.DataGridView();
            this.ReqDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RFD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RFDCust = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReqBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefundType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MS_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ststus = new System.Windows.Forms.DataGridViewImageColumn();
            this.panelSearchTop = new System.Windows.Forms.Panel();
            this.textBoxFind2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonFind = new AryuwatSystem.UserControls.ButtonFind();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerSt = new System.Windows.Forms.DateTimePicker();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.groupBoxSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewREQItem)).BeginInit();
            this.panelSearchTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSearch
            // 
            this.groupBoxSearch.Controls.Add(this.dataGridViewREQItem);
            this.groupBoxSearch.Controls.Add(this.panelSearchTop);
            this.groupBoxSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSearch.Location = new System.Drawing.Point(0, 0);
            this.groupBoxSearch.Name = "groupBoxSearch";
            this.groupBoxSearch.Size = new System.Drawing.Size(1265, 448);
            this.groupBoxSearch.TabIndex = 1;
            this.groupBoxSearch.TabStop = false;
            this.groupBoxSearch.Text = "ค้นหา";
            // 
            // dataGridViewREQItem
            // 
            this.dataGridViewREQItem.AllowUserToAddRows = false;
            this.dataGridViewREQItem.AllowUserToDeleteRows = false;
            this.dataGridViewREQItem.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewREQItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewREQItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ReqDate,
            this.RFD,
            this.RFDCust,
            this.ReqBy,
            this.RefundType,
            this.PayType,
            this.MS_Name,
            this.Ststus});
            this.dataGridViewREQItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewREQItem.Location = new System.Drawing.Point(3, 105);
            this.dataGridViewREQItem.Name = "dataGridViewREQItem";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("TH SarabunPSK", 14.25F);
            this.dataGridViewREQItem.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewREQItem.RowTemplate.ReadOnly = true;
            this.dataGridViewREQItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewREQItem.Size = new System.Drawing.Size(1259, 340);
            this.dataGridViewREQItem.TabIndex = 154;
            this.dataGridViewREQItem.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewREQItem_CellMouseDoubleClick);
            this.dataGridViewREQItem.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridViewREQItem_RowPostPaint);
            // 
            // ReqDate
            // 
            this.ReqDate.HeaderText = "ว/ด/ป";
            this.ReqDate.Name = "ReqDate";
            this.ReqDate.Width = 82;
            // 
            // RFD
            // 
            this.RFD.HeaderText = "RFD";
            this.RFD.Name = "RFD";
            this.RFD.Width = 120;
            // 
            // RFDCust
            // 
            this.RFDCust.HeaderText = "Customer";
            this.RFDCust.Name = "RFDCust";
            this.RFDCust.Width = 150;
            // 
            // ReqBy
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ReqBy.DefaultCellStyle = dataGridViewCellStyle1;
            this.ReqBy.HeaderText = "RFDMoney";
            this.ReqBy.Name = "ReqBy";
            // 
            // RefundType
            // 
            this.RefundType.HeaderText = "สาเหตุ";
            this.RefundType.Name = "RefundType";
            this.RefundType.Width = 180;
            // 
            // PayType
            // 
            this.PayType.HeaderText = "วิธีรับเงิน";
            this.PayType.Name = "PayType";
            this.PayType.Width = 130;
            // 
            // MS_Name
            // 
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MS_Name.DefaultCellStyle = dataGridViewCellStyle2;
            this.MS_Name.HeaderText = "รายการ";
            this.MS_Name.Name = "MS_Name";
            this.MS_Name.Width = 400;
            // 
            // Ststus
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle3.NullValue")));
            this.Ststus.DefaultCellStyle = dataGridViewCellStyle3;
            this.Ststus.HeaderText = "ได้รับเงินแล้ว";
            this.Ststus.MinimumWidth = 50;
            this.Ststus.Name = "Ststus";
            this.Ststus.Width = 70;
            // 
            // panelSearchTop
            // 
            this.panelSearchTop.Controls.Add(this.textBoxFind2);
            this.panelSearchTop.Controls.Add(this.label8);
            this.panelSearchTop.Controls.Add(this.buttonFind);
            this.panelSearchTop.Controls.Add(this.label6);
            this.panelSearchTop.Controls.Add(this.dateTimePickerEnd);
            this.panelSearchTop.Controls.Add(this.label2);
            this.panelSearchTop.Controls.Add(this.dateTimePickerSt);
            this.panelSearchTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearchTop.Location = new System.Drawing.Point(3, 16);
            this.panelSearchTop.Name = "panelSearchTop";
            this.panelSearchTop.Size = new System.Drawing.Size(1259, 89);
            this.panelSearchTop.TabIndex = 0;
            // 
            // textBoxFind2
            // 
            this.textBoxFind2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.textBoxFind2.Location = new System.Drawing.Point(52, 58);
            this.textBoxFind2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxFind2.Name = "textBoxFind2";
            this.textBoxFind2.Size = new System.Drawing.Size(150, 24);
            this.textBoxFind2.TabIndex = 167;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.Location = new System.Drawing.Point(19, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 166;
            this.label8.Text = "Find";
            // 
            // buttonFind
            // 
            this.buttonFind.AutoSize = true;
            this.buttonFind.BackColor = System.Drawing.Color.Transparent;
            this.buttonFind.Location = new System.Drawing.Point(208, 7);
            this.buttonFind.Margin = new System.Windows.Forms.Padding(3, 14, 3, 14);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(45, 43);
            this.buttonFind.TabIndex = 162;
            this.buttonFind.BtnClick += new AryuwatSystem.UserControls.ButtonFind.ButtonClick(this.buttonFind_BtnClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 38);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(31, 16);
            this.label6.TabIndex = 161;
            this.label6.Text = "End";
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.CustomFormat = "dd-MMM-yyyy";
            this.dateTimePickerEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.dateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(52, 30);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.ShowUpDown = true;
            this.dateTimePickerEnd.Size = new System.Drawing.Size(150, 26);
            this.dateTimePickerEnd.TabIndex = 160;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 11);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 159;
            this.label2.Text = "Start";
            // 
            // dateTimePickerSt
            // 
            this.dateTimePickerSt.CustomFormat = "dd-MMM-yyyy";
            this.dateTimePickerSt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.dateTimePickerSt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerSt.Location = new System.Drawing.Point(52, 3);
            this.dateTimePickerSt.Name = "dateTimePickerSt";
            this.dateTimePickerSt.ShowUpDown = true;
            this.dateTimePickerSt.Size = new System.Drawing.Size(150, 26);
            this.dateTimePickerSt.TabIndex = 158;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "chief_of_staff_add_128.png");
            this.imageList1.Images.SetKeyName(1, "chief_of_staff_close_128.png");
            this.imageList1.Images.SetKeyName(2, "chief_of_staff_write_128.png");
            this.imageList1.Images.SetKeyName(3, "checkApp.jpg");
            this.imageList1.Images.SetKeyName(4, "UrgentFlag.png");
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ว/ด/ป";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 82;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "RFD";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Customer";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn4.HeaderText = "RFDMoney";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "สาเหตุ";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 130;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "วิธีรับเงิน";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 130;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn7.HeaderText = "รายการ";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 400;
            // 
            // dataGridViewImageColumn1
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle7.NullValue")));
            this.dataGridViewImageColumn1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewImageColumn1.HeaderText = "ได้รับเงินแล้ว";
            this.dataGridViewImageColumn1.MinimumWidth = 50;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 70;
            // 
            // popRFDList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 448);
            this.Controls.Add(this.groupBoxSearch);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Name = "popRFDList";
            this.Text = "RFDList";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.popRFDList_FormClosing);
            this.groupBoxSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewREQItem)).EndInit();
            this.panelSearchTop.ResumeLayout(false);
            this.panelSearchTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSearch;
        private System.Windows.Forms.DataGridView dataGridViewREQItem;
        private System.Windows.Forms.Panel panelSearchTop;
        private System.Windows.Forms.TextBox textBoxFind2;
        private System.Windows.Forms.Label label8;
        private UserControls.ButtonFind buttonFind;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerSt;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReqDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn RFD;
        private System.Windows.Forms.DataGridViewTextBoxColumn RFDCust;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReqBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefundType;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayType;
        private System.Windows.Forms.DataGridViewTextBoxColumn MS_Name;
        private System.Windows.Forms.DataGridViewImageColumn Ststus;
    }
}