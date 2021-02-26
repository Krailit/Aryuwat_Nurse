namespace AryuwatSystem.Forms
{
    partial class PopBookingDoctorAdd
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
            this.buttonAdd = new System.Windows.Forms.Button();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cboDoctor = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerIn = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerOut = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.checkBoxOff = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonAdd.Location = new System.Drawing.Point(135, 132);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(105, 45);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Save";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // txtNote
            // 
            this.txtNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtNote.Location = new System.Drawing.Point(61, 81);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(257, 45);
            this.txtNote.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(13, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Note :";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnCancel.Location = new System.Drawing.Point(253, 132);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 45);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cboDoctor
            // 
            this.cboDoctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cboDoctor.FormattingEnabled = true;
            this.cboDoctor.Location = new System.Drawing.Point(61, 12);
            this.cboDoctor.MaxDropDownItems = 15;
            this.cboDoctor.Name = "cboDoctor";
            this.cboDoctor.Size = new System.Drawing.Size(257, 28);
            this.cboDoctor.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(24, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Dr. :";
            // 
            // dateTimePickerIn
            // 
            this.dateTimePickerIn.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dateTimePickerIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dateTimePickerIn.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerIn.Location = new System.Drawing.Point(61, 49);
            this.dateTimePickerIn.Name = "dateTimePickerIn";
            this.dateTimePickerIn.ShowUpDown = true;
            this.dateTimePickerIn.Size = new System.Drawing.Size(118, 26);
            this.dateTimePickerIn.TabIndex = 26;
            this.dateTimePickerIn.Value = new System.DateTime(2018, 2, 20, 10, 0, 0, 0);
            this.dateTimePickerIn.ValueChanged += new System.EventHandler(this.dateTimePickerIn_ValueChanged);
            // 
            // dateTimePickerOut
            // 
            this.dateTimePickerOut.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dateTimePickerOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dateTimePickerOut.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerOut.Location = new System.Drawing.Point(200, 49);
            this.dateTimePickerOut.Name = "dateTimePickerOut";
            this.dateTimePickerOut.ShowUpDown = true;
            this.dateTimePickerOut.Size = new System.Drawing.Size(118, 26);
            this.dateTimePickerOut.TabIndex = 27;
            this.dateTimePickerOut.Value = new System.DateTime(2018, 2, 20, 19, 0, 0, 0);
            this.dateTimePickerOut.ValueChanged += new System.EventHandler(this.dateTimePickerOut_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 28;
            this.label1.Text = "Time :";
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnDel.Location = new System.Drawing.Point(60, 132);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(65, 45);
            this.btnDel.TabIndex = 29;
            this.btnDel.Text = "Delete";
            this.btnDel.UseVisualStyleBackColor = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // checkBoxOff
            // 
            this.checkBoxOff.AutoSize = true;
            this.checkBoxOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.checkBoxOff.Location = new System.Drawing.Point(324, 53);
            this.checkBoxOff.Name = "checkBoxOff";
            this.checkBoxOff.Size = new System.Drawing.Size(53, 24);
            this.checkBoxOff.TabIndex = 30;
            this.checkBoxOff.Text = "Off";
            this.checkBoxOff.UseVisualStyleBackColor = true;
            this.checkBoxOff.Click += new System.EventHandler(this.checkBoxOff_Click);
            // 
            // PopBookingDoctorAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 198);
            this.ControlBox = false;
            this.Controls.Add(this.checkBoxOff);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerOut);
            this.Controls.Add(this.dateTimePickerIn);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cboDoctor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PopBookingDoctorAdd";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Booking Doctor Add";
            this.Load += new System.EventHandler(this.PopBookingDoctorAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cboDoctor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerIn;
        private System.Windows.Forms.DateTimePicker dateTimePickerOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.CheckBox checkBoxOff;
    }
}