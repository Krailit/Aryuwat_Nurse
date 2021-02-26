using System.Windows.Forms;
using AryuwatSystem.UserControls;
using System.ComponentModel;
using System.Drawing;
using System;
using AryuwatSystem.Properties;
namespace AryuwatSystem.Forms
{
    partial class FrmPromotionMMSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPromotionMMSetting));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButtonByItem = new System.Windows.Forms.RadioButton();
            this.radioButtonGroup = new System.Windows.Forms.RadioButton();
            this.radioNormal = new System.Windows.Forms.RadioButton();
            this.radAmount = new System.Windows.Forms.RadioButton();
            this.radBuffet = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAmount = new AryuwatSystem.UserControls.TextboxFormatDouble(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.checkBoxAll = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkedListBoxProduct = new System.Windows.Forms.CheckedListBox();
            this.txtDiscountPercen = new AryuwatSystem.UserControls.TextboxFormatDouble(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTotalPrice = new AryuwatSystem.UserControls.TextboxFormatDouble(this.components);
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtProPrice = new AryuwatSystem.UserControls.TextboxFormatDouble(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelName = new System.Windows.Forms.Panel();
            this.checkBoxWallet = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cboSurgicalFeeTyp = new System.Windows.Forms.ComboBox();
            this.checkBoxActive = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPro_Name = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPro_Code = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelName.SuspendLayout();
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
            this.groupBox1.Controls.Add(this.panelName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1262, 561);
            this.groupBox1.TabIndex = 152;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "รายการที่เลือก :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.radioNormal);
            this.panel1.Controls.Add(this.radAmount);
            this.panel1.Controls.Add(this.radBuffet);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtAmount);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.checkBoxAll);
            this.panel1.Controls.Add(this.groupBox2);
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
            this.panel1.Location = new System.Drawing.Point(3, 86);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1256, 472);
            this.panel1.TabIndex = 151;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.radioButtonByItem);
            this.panel2.Controls.Add(this.radioButtonGroup);
            this.panel2.Location = new System.Drawing.Point(31, 409);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(453, 33);
            this.panel2.TabIndex = 294;
            // 
            // radioButtonByItem
            // 
            this.radioButtonByItem.AutoSize = true;
            this.radioButtonByItem.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonByItem.Location = new System.Drawing.Point(196, 1);
            this.radioButtonByItem.Name = "radioButtonByItem";
            this.radioButtonByItem.Size = new System.Drawing.Size(232, 29);
            this.radioButtonByItem.TabIndex = 293;
            this.radioButtonByItem.Text = "กำหนดรายผลิตภัณฑ์";
            this.radioButtonByItem.UseVisualStyleBackColor = true;
            this.radioButtonByItem.Click += new System.EventHandler(this.radioButtonByItem_Click);
            // 
            // radioButtonGroup
            // 
            this.radioButtonGroup.AutoSize = true;
            this.radioButtonGroup.Checked = true;
            this.radioButtonGroup.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonGroup.Location = new System.Drawing.Point(17, 1);
            this.radioButtonGroup.Name = "radioButtonGroup";
            this.radioButtonGroup.Size = new System.Drawing.Size(179, 29);
            this.radioButtonGroup.TabIndex = 292;
            this.radioButtonGroup.TabStop = true;
            this.radioButtonGroup.Text = "กำหนดตามกลุ่ม";
            this.radioButtonGroup.UseVisualStyleBackColor = true;
            this.radioButtonGroup.Click += new System.EventHandler(this.radioButtonGroup_Click);
            // 
            // radioNormal
            // 
            this.radioNormal.AutoSize = true;
            this.radioNormal.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioNormal.Location = new System.Drawing.Point(567, 13);
            this.radioNormal.Name = "radioNormal";
            this.radioNormal.Size = new System.Drawing.Size(292, 29);
            this.radioNormal.TabIndex = 289;
            this.radioNormal.Text = "วงเงินปกติ (Fix % รายการ)";
            this.radioNormal.UseVisualStyleBackColor = true;
            // 
            // radAmount
            // 
            this.radAmount.AutoSize = true;
            this.radAmount.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAmount.Location = new System.Drawing.Point(567, 71);
            this.radAmount.Name = "radAmount";
            this.radAmount.Size = new System.Drawing.Size(322, 29);
            this.radAmount.TabIndex = 288;
            this.radAmount.Text = "จำกัดจำนวน (เฉลี่ยตามจำนวน)";
            this.radAmount.UseVisualStyleBackColor = true;
            // 
            // radBuffet
            // 
            this.radBuffet.AutoSize = true;
            this.radBuffet.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radBuffet.Location = new System.Drawing.Point(567, 42);
            this.radBuffet.Name = "radBuffet";
            this.radBuffet.Size = new System.Drawing.Size(359, 29);
            this.radBuffet.TabIndex = 287;
            this.radBuffet.Text = "Buffet (Fix ราคารายการที่กำหนด)";
            this.radBuffet.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(513, 127);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(259, 27);
            this.label11.TabIndex = 285;
            this.label11.Text = "สำหรับโปรที่จำกัดจำนวน";
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.Black;
            this.txtAmount.Font = new System.Drawing.Font("Tahoma", 18F);
            this.txtAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtAmount.Location = new System.Drawing.Point(357, 121);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(150, 36);
            this.txtAmount.TabIndex = 284;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(247, 128);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 27);
            this.label12.TabIndex = 282;
            this.label12.Text = "Amount";
            // 
            // checkBoxAll
            // 
            this.checkBoxAll.AutoSize = true;
            this.checkBoxAll.Location = new System.Drawing.Point(31, 137);
            this.checkBoxAll.Name = "checkBoxAll";
            this.checkBoxAll.Size = new System.Drawing.Size(136, 20);
            this.checkBoxAll.TabIndex = 281;
            this.checkBoxAll.Text = "Select/Unselect all.";
            this.checkBoxAll.UseVisualStyleBackColor = true;
            this.checkBoxAll.CheckedChanged += new System.EventHandler(this.checkBoxAll_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.checkedListBoxProduct);
            this.groupBox2.Location = new System.Drawing.Point(27, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1205, 242);
            this.groupBox2.TabIndex = 280;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Product Group";
            // 
            // checkedListBoxProduct
            // 
            this.checkedListBoxProduct.CheckOnClick = true;
            this.checkedListBoxProduct.ColumnWidth = 320;
            this.checkedListBoxProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxProduct.FormattingEnabled = true;
            this.checkedListBoxProduct.Location = new System.Drawing.Point(3, 19);
            this.checkedListBoxProduct.MultiColumn = true;
            this.checkedListBoxProduct.Name = "checkedListBoxProduct";
            this.checkedListBoxProduct.Size = new System.Drawing.Size(1199, 220);
            this.checkedListBoxProduct.TabIndex = 0;
            // 
            // txtDiscountPercen
            // 
            this.txtDiscountPercen.BackColor = System.Drawing.Color.Black;
            this.txtDiscountPercen.Font = new System.Drawing.Font("Tahoma", 18F);
            this.txtDiscountPercen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtDiscountPercen.Location = new System.Drawing.Point(357, 82);
            this.txtDiscountPercen.Name = "txtDiscountPercen";
            this.txtDiscountPercen.Size = new System.Drawing.Size(150, 36);
            this.txtDiscountPercen.TabIndex = 279;
            this.txtDiscountPercen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(506, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 27);
            this.label1.TabIndex = 278;
            this.label1.Text = "%";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(247, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 27);
            this.label7.TabIndex = 277;
            this.label7.Text = "Discount";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label9.Location = new System.Drawing.Point(945, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(150, 20);
            this.label9.TabIndex = 276;
            this.label9.Text = "หมายเหตุ/Remark";
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.BackColor = System.Drawing.Color.Black;
            this.txtTotalPrice.Font = new System.Drawing.Font("Tahoma", 18F);
            this.txtTotalPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtTotalPrice.Location = new System.Drawing.Point(357, 6);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.Size = new System.Drawing.Size(150, 36);
            this.txtTotalPrice.TabIndex = 274;
            this.txtTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalPrice.TextChanged += new System.EventHandler(this.txtTotalPrice_TextChanged);
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(949, 38);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(280, 125);
            this.txtRemark.TabIndex = 148;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(506, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 27);
            this.label2.TabIndex = 275;
            this.label2.Text = "บาท";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(143, 13);
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
            this.btnCancel.Location = new System.Drawing.Point(1120, 405);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 48);
            this.btnCancel.TabIndex = 269;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnSave.ForeColor = System.Drawing.Color.DimGray;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1005, 405);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 48);
            this.btnSave.TabIndex = 267;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // txtProPrice
            // 
            this.txtProPrice.BackColor = System.Drawing.Color.Black;
            this.txtProPrice.Font = new System.Drawing.Font("Tahoma", 18F);
            this.txtProPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtProPrice.Location = new System.Drawing.Point(357, 44);
            this.txtProPrice.Name = "txtProPrice";
            this.txtProPrice.Size = new System.Drawing.Size(150, 36);
            this.txtProPrice.TabIndex = 271;
            this.txtProPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtProPrice.TextChanged += new System.EventHandler(this.txtProPrice_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(506, 51);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 27);
            this.label13.TabIndex = 270;
            this.label13.Text = "บาท";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(7, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(350, 27);
            this.label4.TabIndex = 270;
            this.label4.Text = "ราคาโปรโมชัน/Promotion Price";
            // 
            // panelName
            // 
            this.panelName.Controls.Add(this.checkBoxWallet);
            this.panelName.Controls.Add(this.label15);
            this.panelName.Controls.Add(this.cboSurgicalFeeTyp);
            this.panelName.Controls.Add(this.checkBoxActive);
            this.panelName.Controls.Add(this.label10);
            this.panelName.Controls.Add(this.dateTimePickerStart);
            this.panelName.Controls.Add(this.label6);
            this.panelName.Controls.Add(this.txtPro_Name);
            this.panelName.Controls.Add(this.label5);
            this.panelName.Controls.Add(this.txtPro_Code);
            this.panelName.Controls.Add(this.label3);
            this.panelName.Controls.Add(this.dateTimePickerEnd);
            this.panelName.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelName.Location = new System.Drawing.Point(3, 19);
            this.panelName.Name = "panelName";
            this.panelName.Size = new System.Drawing.Size(1256, 67);
            this.panelName.TabIndex = 152;
            // 
            // checkBoxWallet
            // 
            this.checkBoxWallet.AutoSize = true;
            this.checkBoxWallet.BackColor = System.Drawing.Color.Tomato;
            this.checkBoxWallet.Location = new System.Drawing.Point(1063, 34);
            this.checkBoxWallet.Name = "checkBoxWallet";
            this.checkBoxWallet.Size = new System.Drawing.Size(104, 20);
            this.checkBoxWallet.TabIndex = 290;
            this.checkBoxWallet.Text = "Money Wallet";
            this.checkBoxWallet.UseVisualStyleBackColor = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label15.Location = new System.Drawing.Point(590, 2);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 23);
            this.label15.TabIndex = 319;
            this.label15.Text = "แผนก";
            // 
            // cboSurgicalFeeTyp
            // 
            this.cboSurgicalFeeTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSurgicalFeeTyp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboSurgicalFeeTyp.FormattingEnabled = true;
            this.cboSurgicalFeeTyp.Location = new System.Drawing.Point(586, 28);
            this.cboSurgicalFeeTyp.Name = "cboSurgicalFeeTyp";
            this.cboSurgicalFeeTyp.Size = new System.Drawing.Size(159, 24);
            this.cboSurgicalFeeTyp.TabIndex = 318;
            // 
            // checkBoxActive
            // 
            this.checkBoxActive.AutoSize = true;
            this.checkBoxActive.Checked = true;
            this.checkBoxActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxActive.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.checkBoxActive.Location = new System.Drawing.Point(1063, 10);
            this.checkBoxActive.Name = "checkBoxActive";
            this.checkBoxActive.Size = new System.Drawing.Size(79, 23);
            this.checkBoxActive.TabIndex = 315;
            this.checkBoxActive.Text = "Active";
            this.checkBoxActive.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(800, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(121, 16);
            this.label10.TabIndex = 314;
            this.label10.Text = "Promotion Start :";
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerStart.Location = new System.Drawing.Point(924, 5);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.ShowUpDown = true;
            this.dateTimePickerStart.Size = new System.Drawing.Size(99, 23);
            this.dateTimePickerStart.TabIndex = 313;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(426, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 23);
            this.label6.TabIndex = 312;
            this.label6.Text = "Code";
            // 
            // txtPro_Name
            // 
            this.txtPro_Name.BackColor = System.Drawing.Color.Black;
            this.txtPro_Name.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPro_Name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtPro_Name.Location = new System.Drawing.Point(12, 27);
            this.txtPro_Name.Name = "txtPro_Name";
            this.txtPro_Name.Size = new System.Drawing.Size(408, 27);
            this.txtPro_Name.TabIndex = 311;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(7, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(286, 23);
            this.label5.TabIndex = 310;
            this.label5.Text = "ชื่อโปรโมชัน/Promotion name";
            // 
            // txtPro_Code
            // 
            this.txtPro_Code.BackColor = System.Drawing.Color.Black;
            this.txtPro_Code.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPro_Code.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtPro_Code.Location = new System.Drawing.Point(426, 27);
            this.txtPro_Code.Name = "txtPro_Code";
            this.txtPro_Code.Size = new System.Drawing.Size(154, 27);
            this.txtPro_Code.TabIndex = 155;
            this.txtPro_Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(811, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 16);
            this.label3.TabIndex = 151;
            this.label3.Text = "Promotion End :";
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(924, 29);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.ShowUpDown = true;
            this.dateTimePickerEnd.Size = new System.Drawing.Size(99, 23);
            this.dateTimePickerEnd.TabIndex = 150;
            // 
            // FrmPromotionMMSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 561);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "FrmPromotionMMSetting";
            this.Text = "Member Package";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPromotionMMSetting_FormClosing);
            this.Load += new System.EventHandler(this.FrmPromotionMMSetting_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panelName.ResumeLayout(false);
            this.panelName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private GroupBox groupBox1;
        private Panel panelName;
        private CheckBox checkBoxActive;
        private Label label10;
        private DateTimePicker dateTimePickerStart;
        private Label label6;
        internal TextBox txtPro_Name;
        private Label label5;
        internal TextBox txtPro_Code;
        private Label label3;
        private DateTimePicker dateTimePickerEnd;
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
        private GroupBox groupBox2;
        private CheckedListBox checkedListBoxProduct;
        private CheckBox checkBoxAll;
        private Label label15;
        private ComboBox cboSurgicalFeeTyp;
        private Label label11;
        private TextboxFormatDouble txtAmount;
        private Label label12;
        private RadioButton radAmount;
        private RadioButton radBuffet;
        private RadioButton radioNormal;
        private CheckBox checkBoxWallet;
        private RadioButton radioButtonByItem;
        private RadioButton radioButtonGroup;
        private Panel panel2;


    }
}