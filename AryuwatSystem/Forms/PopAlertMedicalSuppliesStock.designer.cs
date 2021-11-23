namespace AryuwatSystem.Forms
{
    partial class PopAlertMedicalSuppliesStock
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gv_MinimumStock = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MS_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MS_Section = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MS_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BranchName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.จำนวนคงเหลือขั้นต่ำ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.จำนวนคงเหลือ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkNotiMinimumStock = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gv_MinimumStock)).BeginInit();
            this.SuspendLayout();
            // 
            // gv_MinimumStock
            // 
            this.gv_MinimumStock.AllowUserToAddRows = false;
            this.gv_MinimumStock.AllowUserToDeleteRows = false;
            this.gv_MinimumStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gv_MinimumStock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gv_MinimumStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_MinimumStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MS_CODE,
            this.MS_Section,
            this.MS_Name,
            this.BranchName,
            this.จำนวนคงเหลือขั้นต่ำ,
            this.จำนวนคงเหลือ});
            this.gv_MinimumStock.Location = new System.Drawing.Point(16, 63);
            this.gv_MinimumStock.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gv_MinimumStock.MultiSelect = false;
            this.gv_MinimumStock.Name = "gv_MinimumStock";
            this.gv_MinimumStock.ReadOnly = true;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.gv_MinimumStock.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gv_MinimumStock.RowHeadersVisible = false;
            this.gv_MinimumStock.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gv_MinimumStock.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gv_MinimumStock.RowTemplate.Height = 24;
            this.gv_MinimumStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gv_MinimumStock.ShowCellErrors = false;
            this.gv_MinimumStock.ShowCellToolTips = false;
            this.gv_MinimumStock.ShowEditingIcon = false;
            this.gv_MinimumStock.ShowRowErrors = false;
            this.gv_MinimumStock.Size = new System.Drawing.Size(663, 308);
            this.gv_MinimumStock.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Angsana New", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 37);
            this.label1.TabIndex = 92;
            this.label1.Text = "รายการสินค้า/เวชภัณฑ์ ใกล้จะหมด";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "MS_Code";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn2.HeaderText = "MS_Code";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "MS_Name";
            this.dataGridViewTextBoxColumn3.HeaderText = "ชื่อสินค้า/เวชภัณฑ์";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "BranchName";
            this.dataGridViewTextBoxColumn4.HeaderText = "สาขา";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "จำนวนคงเหลือขั้นต่ำ";
            this.dataGridViewTextBoxColumn5.HeaderText = "จำนวนคงเหลือขั้นต่ำ";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "จำนวนคงเหลือ";
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Red;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn6.HeaderText = "จำนวนคงเหลือ";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // MS_CODE
            // 
            this.MS_CODE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MS_CODE.DataPropertyName = "MS_CODE";
            this.MS_CODE.HeaderText = "รหัสสินค้า/เวชภัณฑ์";
            this.MS_CODE.Name = "MS_CODE";
            this.MS_CODE.ReadOnly = true;
            // 
            // MS_Section
            // 
            this.MS_Section.DataPropertyName = "MS_Section";
            this.MS_Section.HeaderText = "Section";
            this.MS_Section.Name = "MS_Section";
            this.MS_Section.ReadOnly = true;
            // 
            // MS_Name
            // 
            this.MS_Name.DataPropertyName = "MS_Name";
            this.MS_Name.HeaderText = "ชื่อสินค้า/เวชภัณฑ์";
            this.MS_Name.Name = "MS_Name";
            this.MS_Name.ReadOnly = true;
            // 
            // BranchName
            // 
            this.BranchName.DataPropertyName = "BranchName";
            this.BranchName.HeaderText = "สาขา";
            this.BranchName.Name = "BranchName";
            this.BranchName.ReadOnly = true;
            // 
            // จำนวนคงเหลือขั้นต่ำ
            // 
            this.จำนวนคงเหลือขั้นต่ำ.DataPropertyName = "จำนวนคงเหลือขั้นต่ำ";
            this.จำนวนคงเหลือขั้นต่ำ.HeaderText = "จำนวนคงเหลือขั้นต่ำ";
            this.จำนวนคงเหลือขั้นต่ำ.Name = "จำนวนคงเหลือขั้นต่ำ";
            this.จำนวนคงเหลือขั้นต่ำ.ReadOnly = true;
            // 
            // จำนวนคงเหลือ
            // 
            this.จำนวนคงเหลือ.DataPropertyName = "จำนวนคงเหลือ";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Red;
            this.จำนวนคงเหลือ.DefaultCellStyle = dataGridViewCellStyle2;
            this.จำนวนคงเหลือ.HeaderText = "จำนวนคงเหลือ";
            this.จำนวนคงเหลือ.Name = "จำนวนคงเหลือ";
            this.จำนวนคงเหลือ.ReadOnly = true;
            // 
            // chkNotiMinimumStock
            // 
            this.chkNotiMinimumStock.AutoSize = true;
            this.chkNotiMinimumStock.Location = new System.Drawing.Point(576, 12);
            this.chkNotiMinimumStock.Name = "chkNotiMinimumStock";
            this.chkNotiMinimumStock.Size = new System.Drawing.Size(103, 17);
            this.chkNotiMinimumStock.TabIndex = 93;
            this.chkNotiMinimumStock.Text = "ปิดการแจ้งเตือน";
            this.chkNotiMinimumStock.UseVisualStyleBackColor = true;
            this.chkNotiMinimumStock.CheckedChanged += new System.EventHandler(this.chkNotiMinimumStock_CheckedChanged);
            // 
            // PopAlertMedicalSuppliesStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(206)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(699, 388);
            this.Controls.Add(this.chkNotiMinimumStock);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gv_MinimumStock);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PopAlertMedicalSuppliesStock";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.PopAlertMedicalSuppliesStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gv_MinimumStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridView gv_MinimumStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn MS_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn MS_Section;
        private System.Windows.Forms.DataGridViewTextBoxColumn MS_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn BranchName;
        private System.Windows.Forms.DataGridViewTextBoxColumn จำนวนคงเหลือขั้นต่ำ;
        private System.Windows.Forms.DataGridViewTextBoxColumn จำนวนคงเหลือ;
        private System.Windows.Forms.CheckBox chkNotiMinimumStock;
    }
}