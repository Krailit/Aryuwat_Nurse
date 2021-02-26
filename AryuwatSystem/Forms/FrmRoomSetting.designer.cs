using System.Windows.Forms;
using AryuwatSystem.UserControls;
using System.ComponentModel;
using System.Drawing;
using System;
using AryuwatSystem.Properties;
namespace AryuwatSystem.Forms
{
    partial class FrmRoomSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRoomSetting));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBoxActive = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRoom_Name = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRoom_Code = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAmount_Day = new AryuwatSystem.UserControls.TextboxFormatDouble(this.components);
            this.txtDiscountPercen = new AryuwatSystem.UserControls.TextboxFormatDouble(this.components);
            this.txtTotalPrice = new AryuwatSystem.UserControls.TextboxFormatDouble(this.components);
            this.txtProPrice = new AryuwatSystem.UserControls.TextboxFormatDouble(this.components);
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "CustomIcon.png");
            this.imageList1.Images.SetKeyName(1, "TN_psd1084_Red.png");
            this.imageList1.Images.SetKeyName(2, "remove_icon.png");
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1280, 599);
            this.groupBox1.TabIndex = 152;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "รายการที่เลือก :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.txtAmount_Day);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.checkBoxActive);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtRoom_Name);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtRoom_Code);
            this.panel1.Controls.Add(this.txtDiscountPercen);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtTotalPrice);
            this.panel1.Controls.Add(this.txtRemark);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.txtProPrice);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 19);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1274, 577);
            this.panel1.TabIndex = 151;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(935, 527);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 27);
            this.label3.TabIndex = 317;
            this.label3.Text = "วัน";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(394, 527);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(175, 27);
            this.label10.TabIndex = 316;
            this.label10.Text = "จำนวนวัน / Day";
            // 
            // checkBoxActive
            // 
            this.checkBoxActive.AutoSize = true;
            this.checkBoxActive.Checked = true;
            this.checkBoxActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxActive.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.checkBoxActive.Location = new System.Drawing.Point(692, 134);
            this.checkBoxActive.Name = "checkBoxActive";
            this.checkBoxActive.Size = new System.Drawing.Size(79, 23);
            this.checkBoxActive.TabIndex = 315;
            this.checkBoxActive.Text = "Active";
            this.checkBoxActive.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(622, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 23);
            this.label6.TabIndex = 312;
            this.label6.Text = "Room Code";
            // 
            // txtRoom_Name
            // 
            this.txtRoom_Name.BackColor = System.Drawing.Color.Black;
            this.txtRoom_Name.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.txtRoom_Name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtRoom_Name.Location = new System.Drawing.Point(224, 56);
            this.txtRoom_Name.Name = "txtRoom_Name";
            this.txtRoom_Name.Size = new System.Drawing.Size(345, 36);
            this.txtRoom_Name.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(156, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(196, 23);
            this.label5.TabIndex = 310;
            this.label5.Text = "ชื่อห้อง/Room name";
            // 
            // txtRoom_Code
            // 
            this.txtRoom_Code.BackColor = System.Drawing.Color.Black;
            this.txtRoom_Code.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.txtRoom_Code.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtRoom_Code.Location = new System.Drawing.Point(692, 56);
            this.txtRoom_Code.Name = "txtRoom_Code";
            this.txtRoom_Code.ReadOnly = true;
            this.txtRoom_Code.Size = new System.Drawing.Size(327, 36);
            this.txtRoom_Code.TabIndex = 155;
            this.txtRoom_Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(935, 473);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 27);
            this.label1.TabIndex = 278;
            this.label1.Text = "%";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(459, 473);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 27);
            this.label7.TabIndex = 277;
            this.label7.Text = "Discount";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(158, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(258, 32);
            this.label9.TabIndex = 276;
            this.label9.Text = "หมายเหตุ/Remark";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(224, 177);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(795, 132);
            this.txtRemark.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(935, 340);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 27);
            this.label2.TabIndex = 275;
            this.label2.Text = "บาท";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(355, 340);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(214, 27);
            this.label8.TabIndex = 272;
            this.label8.Text = "วงเงิน/Credit Price";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnCancel.ForeColor = System.Drawing.Color.DimGray;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(1139, 521);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 48);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnSave.ForeColor = System.Drawing.Color.DimGray;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(989, 521);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 48);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(935, 405);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 27);
            this.label13.TabIndex = 270;
            this.label13.Text = "บาท";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(219, 405);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(350, 27);
            this.label4.TabIndex = 270;
            this.label4.Text = "ราคาโปรโมชัน/Promotion Price";
            // 
            // txtAmount_Day
            // 
            this.txtAmount_Day.BackColor = System.Drawing.Color.Black;
            this.txtAmount_Day.Font = new System.Drawing.Font("Tahoma", 18F);
            this.txtAmount_Day.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtAmount_Day.Location = new System.Drawing.Point(595, 521);
            this.txtAmount_Day.Name = "txtAmount_Day";
            this.txtAmount_Day.Size = new System.Drawing.Size(334, 36);
            this.txtAmount_Day.TabIndex = 5;
            this.txtAmount_Day.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDiscountPercen
            // 
            this.txtDiscountPercen.BackColor = System.Drawing.Color.Black;
            this.txtDiscountPercen.Font = new System.Drawing.Font("Tahoma", 18F);
            this.txtDiscountPercen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtDiscountPercen.Location = new System.Drawing.Point(595, 467);
            this.txtDiscountPercen.Name = "txtDiscountPercen";
            this.txtDiscountPercen.ReadOnly = true;
            this.txtDiscountPercen.Size = new System.Drawing.Size(334, 36);
            this.txtDiscountPercen.TabIndex = 279;
            this.txtDiscountPercen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.BackColor = System.Drawing.Color.Black;
            this.txtTotalPrice.Font = new System.Drawing.Font("Tahoma", 18F);
            this.txtTotalPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtTotalPrice.Location = new System.Drawing.Point(595, 334);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.Size = new System.Drawing.Size(334, 36);
            this.txtTotalPrice.TabIndex = 3;
            this.txtTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalPrice.TextChanged += new System.EventHandler(this.txtTotalPrice_TextChanged);
            // 
            // txtProPrice
            // 
            this.txtProPrice.BackColor = System.Drawing.Color.Black;
            this.txtProPrice.Font = new System.Drawing.Font("Tahoma", 18F);
            this.txtProPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtProPrice.Location = new System.Drawing.Point(595, 399);
            this.txtProPrice.Name = "txtProPrice";
            this.txtProPrice.Size = new System.Drawing.Size(334, 36);
            this.txtProPrice.TabIndex = 4;
            this.txtProPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtProPrice.TextChanged += new System.EventHandler(this.txtProPrice_TextChanged);
            // 
            // FrmRoomSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 599);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "FrmRoomSetting";
            this.Text = "Room Setting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPromotionMMSetting_FormClosing);
            this.Load += new System.EventHandler(this.FrmPromotionMMSetting_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private GroupBox groupBox1;
        private Panel panel1;
        private Label label9;
        private TextboxFormatDouble txtTotalPrice;
        private TextBox txtRemark;
        private Label label2;
        private Label label8;
        private Button btnCancel;
        private Button btnSave;
        private TextboxFormatDouble txtProPrice;
        private Label label13;
        private Label label4;
        private TextboxFormatDouble txtDiscountPercen;
        private Label label1;
        private Label label7;
        private CheckBox checkBoxActive;
        private Label label6;
        internal TextBox txtRoom_Name;
        private Label label5;
        internal TextBox txtRoom_Code;
        private TextboxFormatDouble txtAmount_Day;
        private Label label3;
        private Label label10;
    }
}