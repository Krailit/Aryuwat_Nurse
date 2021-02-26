namespace AryuwatSystem.Forms
{
    partial class PopInputCourseCard
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
            this.label1Text = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbCN = new System.Windows.Forms.Label();
            this.lbCC = new System.Windows.Forms.Label();
            this.lbDate = new System.Windows.Forms.Label();
            this.lbAmount = new System.Windows.Forms.Label();
            this.lbItem = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1Text
            // 
            this.label1Text.AutoSize = true;
            this.label1Text.Font = new System.Drawing.Font("Cordia New", 18F, System.Drawing.FontStyle.Underline);
            this.label1Text.Location = new System.Drawing.Point(482, 74);
            this.label1Text.Name = "label1Text";
            this.label1Text.Size = new System.Drawing.Size(123, 34);
            this.label1Text.TabIndex = 0;
            this.label1Text.Text = "Course Card ID";
            // 
            // buttonOK
            // 
            this.buttonOK.Font = new System.Drawing.Font("Cordia New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOK.Location = new System.Drawing.Point(488, 15);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(204, 40);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "บันทึกบัตรคอร์ส/Save";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.BackColor = System.Drawing.Color.PaleGreen;
            this.buttonEdit.Font = new System.Drawing.Font("Cordia New", 18F);
            this.buttonEdit.Location = new System.Drawing.Point(16, 15);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(92, 40);
            this.buttonEdit.TabIndex = 3;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = false;
            this.buttonEdit.Visible = false;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbCN);
            this.panel1.Controls.Add(this.lbCC);
            this.panel1.Controls.Add(this.lbDate);
            this.panel1.Controls.Add(this.lbAmount);
            this.panel1.Controls.Add(this.lbItem);
            this.panel1.Controls.Add(this.lbName);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1Text);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Cordia New", 18F);
            this.panel1.Location = new System.Drawing.Point(0, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(717, 344);
            this.panel1.TabIndex = 153;
            // 
            // lbCN
            // 
            this.lbCN.AutoSize = true;
            this.lbCN.Font = new System.Drawing.Font("Cordia New", 16F);
            this.lbCN.Location = new System.Drawing.Point(31, 74);
            this.lbCN.Name = "lbCN";
            this.lbCN.Size = new System.Drawing.Size(18, 31);
            this.lbCN.TabIndex = 15;
            this.lbCN.Text = ".";
            // 
            // lbCC
            // 
            this.lbCC.AutoSize = true;
            this.lbCC.Font = new System.Drawing.Font("Cordia New", 26F);
            this.lbCC.Location = new System.Drawing.Point(482, 106);
            this.lbCC.Name = "lbCC";
            this.lbCC.Size = new System.Drawing.Size(26, 48);
            this.lbCC.TabIndex = 14;
            this.lbCC.Text = ".";
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.Font = new System.Drawing.Font("Cordia New", 18F);
            this.lbDate.Location = new System.Drawing.Point(482, 42);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(19, 34);
            this.lbDate.TabIndex = 13;
            this.lbDate.Text = ".";
            // 
            // lbAmount
            // 
            this.lbAmount.AutoSize = true;
            this.lbAmount.Font = new System.Drawing.Font("Cordia New", 18F);
            this.lbAmount.Location = new System.Drawing.Point(147, 204);
            this.lbAmount.Name = "lbAmount";
            this.lbAmount.Size = new System.Drawing.Size(19, 34);
            this.lbAmount.TabIndex = 12;
            this.lbAmount.Text = ".";
            // 
            // lbItem
            // 
            this.lbItem.AutoSize = true;
            this.lbItem.Font = new System.Drawing.Font("Cordia New", 18F);
            this.lbItem.Location = new System.Drawing.Point(29, 170);
            this.lbItem.Name = "lbItem";
            this.lbItem.Size = new System.Drawing.Size(19, 34);
            this.lbItem.TabIndex = 11;
            this.lbItem.Text = ".";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Cordia New", 18F);
            this.lbName.Location = new System.Drawing.Point(31, 42);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(19, 34);
            this.lbName.TabIndex = 10;
            this.lbName.Text = ".";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cordia New", 18F, System.Drawing.FontStyle.Underline);
            this.label6.Location = new System.Drawing.Point(482, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 34);
            this.label6.TabIndex = 9;
            this.label6.Text = "วันที่/Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cordia New", 18F, System.Drawing.FontStyle.Underline);
            this.label5.Location = new System.Drawing.Point(29, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 34);
            this.label5.TabIndex = 8;
            this.label5.Text = "จำนวน/Amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cordia New", 18F, System.Drawing.FontStyle.Underline);
            this.label4.Location = new System.Drawing.Point(29, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 34);
            this.label4.TabIndex = 7;
            this.label4.Text = "รายการ/Items";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cordia New", 18F, System.Drawing.FontStyle.Underline);
            this.label3.Location = new System.Drawing.Point(29, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 34);
            this.label3.TabIndex = 6;
            this.label3.Text = "ชื่อ/Name";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(717, 68);
            this.panel2.TabIndex = 154;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cordia New", 20F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(70, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(574, 33);
            this.label2.TabIndex = 7;
            this.label2.Text = "เลขบัตรคอร์ส เมื่อบันทึกแล้วจะไม่สามารถ ยกเลิกหรือเปลี่ยนแปลงได้";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Cordia New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(250, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(204, 40);
            this.btnCancel.TabIndex = 155;
            this.btnCancel.Text = "ยกเลิก/Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnDel);
            this.panel3.Controls.Add(this.buttonOK);
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.buttonEdit);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 345);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(717, 67);
            this.panel3.TabIndex = 156;
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.Color.LightCoral;
            this.btnDel.Font = new System.Drawing.Font("Cordia New", 18F);
            this.btnDel.Location = new System.Drawing.Point(114, 15);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(92, 40);
            this.btnDel.TabIndex = 156;
            this.btnDel.Text = "Delete";
            this.btnDel.UseVisualStyleBackColor = false;
            this.btnDel.Visible = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // PopInputCourseCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 412);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PopInputCourseCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "เลขบัตรคอร์ส";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PopInputCourseCard_FormClosing);
            this.Load += new System.EventHandler(this.PopInputCourseCard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1Text;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbCN;
        private System.Windows.Forms.Label lbCC;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.Label lbAmount;
        private System.Windows.Forms.Label lbItem;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnDel;
    }
}