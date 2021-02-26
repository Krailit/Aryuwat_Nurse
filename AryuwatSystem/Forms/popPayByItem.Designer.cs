namespace AryuwatSystem.Forms
{
    partial class popPayByItem
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonAdd = new AryuwatSystem.UserControls.ButtonRigth();
            this.buttonDelete = new AryuwatSystem.UserControls.ButtonLeft();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dataGridViewCashTransfer = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CashCurrent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoneyCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayRefID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCashTransfer)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(203, 14);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 32);
            this.btnOK.TabIndex = 153;
            this.btnOK.Text = "Save";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panel1
            // 
            //this.panel1.Controls.Add(this.buttonAdd);
            //this.panel1.Controls.Add(this.buttonDelete);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 132);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(559, 56);
            this.panel1.TabIndex = 154;
            // 
            // buttonAdd
            //// 
            //this.buttonAdd.Location = new System.Drawing.Point(53, 14);
            //this.buttonAdd.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            //this.buttonAdd.Name = "buttonAdd";
            //this.buttonAdd.Size = new System.Drawing.Size(30, 26);
            //this.buttonAdd.TabIndex = 155;
            //this.buttonAdd.Visible = false;
            //// 
            //// buttonDelete
            //// 
            //this.buttonDelete.Location = new System.Drawing.Point(13, 14);
            //this.buttonDelete.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            //this.buttonDelete.Name = "buttonDelete";
            //this.buttonDelete.Size = new System.Drawing.Size(30, 26);
            //this.buttonDelete.TabIndex = 156;
            //this.buttonDelete.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(284, 14);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 32);
            this.btnCancel.TabIndex = 154;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dataGridViewCashTransfer
            // 
            this.dataGridViewCashTransfer.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCashTransfer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewCashTransfer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCashTransfer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CashCurrent,
            this.MoneyCredit,
            this.PayDate,
            this.PayRefID});
            this.dataGridViewCashTransfer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCashTransfer.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewCashTransfer.Name = "dataGridViewCashTransfer";
            this.dataGridViewCashTransfer.Size = new System.Drawing.Size(559, 132);
            this.dataGridViewCashTransfer.TabIndex = 285;
            this.dataGridViewCashTransfer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCashTransfer_CellClick);
            this.dataGridViewCashTransfer.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCashTransfer_CellEndEdit);
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle6.Format = "N2";
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn1.HeaderText = "จำนวนเงิน";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn2.HeaderText = "PayCashDate";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // CashCurrent
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.Format = "N2";
            this.CashCurrent.DefaultCellStyle = dataGridViewCellStyle2;
            this.CashCurrent.HeaderText = "จำนวนเงิน";
            this.CashCurrent.Name = "CashCurrent";
            this.CashCurrent.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CashCurrent.Width = 120;
            // 
            // MoneyCredit
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle3.Format = "N2";
            this.MoneyCredit.DefaultCellStyle = dataGridViewCellStyle3;
            this.MoneyCredit.HeaderText = "เงินโอน";
            this.MoneyCredit.Name = "MoneyCredit";
            this.MoneyCredit.Width = 120;
            // 
            // PayDate
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.PayDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.PayDate.HeaderText = "วันที่";
            this.PayDate.Name = "PayDate";
            this.PayDate.ReadOnly = true;
            this.PayDate.Width = 150;
            // 
            // PayRefID
            // 
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.PayRefID.DefaultCellStyle = dataGridViewCellStyle5;
            this.PayRefID.HeaderText = "ใบยารับเงิน";
            this.PayRefID.Name = "PayRefID";
            // 
            // popPayByItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(559, 188);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridViewCashTransfer);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "popPayByItem";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pay by Item";
            this.Load += new System.EventHandler(this.popPayByItem_Load);
            this.Shown += new System.EventHandler(this.popPayByItem_Shown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCashTransfer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private UserControls.ButtonRigth buttonAdd;
        private UserControls.ButtonLeft buttonDelete;
        private System.Windows.Forms.DataGridView dataGridViewCashTransfer;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CashCurrent;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoneyCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayRefID;
    }
}