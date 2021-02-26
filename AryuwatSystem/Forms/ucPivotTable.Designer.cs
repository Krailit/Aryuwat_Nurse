namespace AryuwatSystem.Forms
{
    partial class ucPivotTable
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkSumValues = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txttNullValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.cboX = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboY = new System.Windows.Forms.ComboBox();
            this.cboZ = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboFunction = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkSumValues
            // 
            this.chkSumValues.AutoSize = true;
            this.chkSumValues.Location = new System.Drawing.Point(765, 12);
            this.chkSumValues.Name = "chkSumValues";
            this.chkSumValues.Size = new System.Drawing.Size(82, 17);
            this.chkSumValues.TabIndex = 25;
            this.chkSumValues.Text = "Sum Values";
            this.chkSumValues.UseVisualStyleBackColor = true;
            this.chkSumValues.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(698, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Null Value";
            this.label4.Visible = false;
            // 
            // txttNullValue
            // 
            this.txttNullValue.Location = new System.Drawing.Point(753, 37);
            this.txttNullValue.Name = "txttNullValue";
            this.txttNullValue.Size = new System.Drawing.Size(110, 20);
            this.txttNullValue.TabIndex = 23;
            this.txttNullValue.Text = "-";
            this.txttNullValue.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(196, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Row";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnUpdate.Location = new System.Drawing.Point(537, 10);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(69, 47);
            this.btnUpdate.TabIndex = 22;
            this.btnUpdate.Text = "Pivot data";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToOrderColumns = true;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 69);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(907, 457);
            this.dataGridView2.TabIndex = 15;
            this.dataGridView2.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView2_CellFormatting);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(363, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Data";
            // 
            // cboX
            // 
            this.cboX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboX.FormattingEnabled = true;
            this.cboX.Location = new System.Drawing.Point(228, 8);
            this.cboX.Name = "cboX";
            this.cboX.Size = new System.Drawing.Size(110, 21);
            this.cboX.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Column";
            // 
            // cboY
            // 
            this.cboY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboY.FormattingEnabled = true;
            this.cboY.Location = new System.Drawing.Point(228, 37);
            this.cboY.Name = "cboY";
            this.cboY.Size = new System.Drawing.Size(110, 21);
            this.cboY.TabIndex = 17;
            // 
            // cboZ
            // 
            this.cboZ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZ.FormattingEnabled = true;
            this.cboZ.Location = new System.Drawing.Point(396, 10);
            this.cboZ.Name = "cboZ";
            this.cboZ.Size = new System.Drawing.Size(110, 21);
            this.cboZ.TabIndex = 18;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboFunction);
            this.panel1.Controls.Add(this.cboZ);
            this.panel1.Controls.Add(this.cboY);
            this.panel1.Controls.Add(this.cboX);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.chkSumValues);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txttNullValue);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(907, 69);
            this.panel1.TabIndex = 27;
            // 
            // cboFunction
            // 
            this.cboFunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFunction.FormattingEnabled = true;
            this.cboFunction.Items.AddRange(new object[] {
            "Count",
            "Max",
            "Min",
            "SUM"});
            this.cboFunction.Location = new System.Drawing.Point(396, 37);
            this.cboFunction.Name = "cboFunction";
            this.cboFunction.Size = new System.Drawing.Size(110, 21);
            this.cboFunction.Sorted = true;
            this.cboFunction.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(345, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Function";
            // 
            // ucPivotTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.panel1);
            this.Name = "ucPivotTable";
            this.Size = new System.Drawing.Size(907, 526);
            this.Load += new System.EventHandler(this.ucPivotTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSumValues;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txttNullValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboY;
        private System.Windows.Forms.ComboBox cboZ;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboFunction;
    }
}
